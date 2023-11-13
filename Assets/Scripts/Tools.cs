using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    bool pencil;
    bool mouse;
    bool cut;
    bool drag;
    bool place;
    Camera cam;
    LineController lineController;
    Vector3 initPos;
    float zoomStep = 0.7f;
    float maxZoom = 7.5f;
    float minZoom = 3f;
    public GameObject compsPanel;
    Components components;

    private void Start()
    {
        cam = Camera.main;
        lineController = GetComponent<LineController>();
        components = GetComponent<Components>();
        compsPanel.SetActive(false);
    }
    private void Update()
    {
        if (pencil)
            lineController.DrawLines();
        if (mouse)
            lineController.ChangeState();
        if (cut)
            lineController.CutLine();
        if (drag)
            Drag();
        if (place)
            components.PlaceComps();
    }
    void Drag()
    {
        if (Input.GetMouseButtonDown(0))
            initPos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = initPos - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position += difference;
        }
    }

    public void PencilTool()
    {
        compsPanel.SetActive(false);
        cut = false;
        place = false;
        drag = false;
        if (pencil == false)
        {
            pencil = true;
            mouse = false;
        }
        else
        {
            pencil = false;
            mouse = true;
        }
    }
    public void DragTool()
    {
        compsPanel.SetActive(false);
        pencil = false;
        cut = false;
        place = false;
        if (drag == false)
        {
            drag = true;
            mouse = false;
        }
        else
        {
            drag = false;
            mouse = true;
        }
    }
    public void ZoomIn()
    {
        float zoomSize = cam.orthographicSize - zoomStep;
        cam.orthographicSize = Mathf.Clamp(zoomSize, minZoom, maxZoom);
    }

    public void ZoomOut()
    {
        float zoomSize = cam.orthographicSize + zoomStep;
        cam.orthographicSize = Mathf.Clamp(zoomSize, minZoom, maxZoom);
    }
    public void MouseTool()
    {
        compsPanel.SetActive(false);
        drag = false;
        place = false;
        pencil = false;
        cut = false;
        mouse = true;

    }

    public void CutTool()
    {
        compsPanel.SetActive(false);
        pencil = false;
        drag = false;
        place = false;
        if (cut == false)
        {
            cut = true;
            mouse = false;
        }
        else
        {
            cut = false;
            mouse = true;
        }
    }
    public void PlaceTool()
    {
        drag = false;
        pencil = false;
        cut = false;
        compsPanel.SetActive(true);
        place = true;
        mouse = false;
    }
    public void CloseButton()
    {
        place = false;
        compsPanel.SetActive(false);
        mouse = true;
    }

}
