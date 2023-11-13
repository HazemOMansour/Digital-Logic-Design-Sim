using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineController : MonoBehaviour
{
    LineRenderer lineRenderer;
    Vector2 startMousePos;
    Vector2 endMousePos;
    bool CanDraw;
    EdgeCollider2D edgeCollider;
    public GameObject linePrefab;
    GameObject currentLine;
    LineValue lineValue;

    RaycastHit2D hit;
    Camera cam;


    void Start()
    {
        cam = Camera.main;
        CanDraw = false;
    }

    
    void Update()
    {
        hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

    }

    void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineValue = currentLine.GetComponent<LineValue>();
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
    }

    void SetEdgeCollider(LineRenderer lineRenderer)
    {
        List<Vector2> edges = new List<Vector2>();

        for (int point = 0; point < lineRenderer.positionCount; point++)
        {
            Vector2 lineRendererPoint = lineRenderer.GetPosition(point);
            edges.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
        }
        
        edgeCollider.SetPoints(edges);
    }

    public void DrawLines()
    {

        if (Input.GetMouseButtonDown(0) && !CanDraw)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            CreateLine();

                
            startMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            CanDraw = true;

            if (hit.collider != null && hit.collider.tag == "O")
            {
                lineValue.connectedOut = true;
                lineValue.GateConnection(hit.collider.transform.parent.gameObject, hit.collider.tag);
               
                
            }
            if (hit.collider != null && hit.collider.tag == "Line")
            {
                lineValue.ConnectLines(hit.collider.gameObject);

            }

            return;
        }
        if (CanDraw)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(currentLine);
                CanDraw = false;
                return;
            }

            endMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            if (Mathf.Abs(endMousePos.x - startMousePos.x) > Mathf.Abs(endMousePos.y - startMousePos.y))
            {
                lineRenderer.SetPosition(0, new Vector2(startMousePos.x, startMousePos.y));
                lineRenderer.SetPosition(1, new Vector2(endMousePos.x, startMousePos.y));
                if (hit.collider != null && (hit.collider.tag == "I1" || hit.collider.tag == "I2"))
                {
                    lineRenderer.SetPosition(1, new Vector2(hit.point.x, hit.point.y));
                }


            }
            else
            {
                lineRenderer.SetPosition(0, new Vector2(startMousePos.x, startMousePos.y));
                lineRenderer.SetPosition(1, new Vector2(startMousePos.x, endMousePos.y));
                if (hit.collider != null && (hit.collider.tag == "I1" || hit.collider.tag == "I2"))
                {
                    lineRenderer.SetPosition(1, new Vector2(hit.point.x, hit.point.y));
                }
            }


            if (Input.GetMouseButtonDown(0) && CanDraw)
            {
                SetEdgeCollider(lineRenderer);
                CanDraw = false;
                
                if (hit.collider != null && hit.collider.tag == "I1")
                {
                    if (lineValue.connectedOut)
                        lineValue.twoConnections = true;
                    lineValue.GateConnection(hit.collider.transform.parent.gameObject, hit.collider.tag);


                }
                else if (hit.collider != null && hit.collider.tag == "I2")
                {   
                    if(lineValue.connectedOut)
                        lineValue.twoConnections = true;
                    lineValue.GateConnection(hit.collider.transform.parent.gameObject, hit.collider.tag);
                }

                return;
            }
            return;
        }
    }


    public void ChangeState()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null && hit.collider.tag == "Line")
                hit.collider.GetComponent<LineValue>().ChangeColor();
        }    

    }

    public void CutLine()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null)
            {
                Destroy(hit.collider.gameObject);
            }
        }
        
    }

}


