using UnityEngine;

public class Components : MonoBehaviour
{
    public GameObject compsPanel;
    public GameObject andPrefab;
    public GameObject orPrefab;
    public GameObject notPrefab;
    public GameObject xorPrefab;
    public GameObject nandPrefab;
    public GameObject norPrefab;
    public GameObject xnorPrefab;
    GameObject currentPrefab;
    bool notplaced;
    float offset = 10f;


    public void PlaceComps()
    {
        if (notplaced)
        {
            currentPrefab.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, offset);
        }
        if (Input.GetMouseButtonDown(1) && notplaced)
        {
            notplaced = false;
            Destroy(currentPrefab);
            return;
        }
        if (Input.GetMouseButtonDown(0) && notplaced)
        {
            notplaced = false;
            currentPrefab = null;
        }
    }
    public void AndInst()
    {
        compsPanel.SetActive(false);
        currentPrefab = Instantiate(andPrefab, Vector3.zero, Quaternion.identity);
        notplaced = true;
    }
    public void OrInst()
    {
        compsPanel.SetActive(false);
        currentPrefab = Instantiate(orPrefab, Vector3.zero, Quaternion.identity);
        notplaced = true;
    }
    public void NotInst()
    {
        compsPanel.SetActive(false);
        currentPrefab = Instantiate(notPrefab, Vector3.zero, Quaternion.identity);
        notplaced = true;
    }
    public void XorInst()
    {
        compsPanel.SetActive(false);
        currentPrefab = Instantiate(xorPrefab, Vector3.zero, Quaternion.identity);
        notplaced = true;
    }
    public void NandInst()
    {
        compsPanel.SetActive(false);
        currentPrefab = Instantiate(nandPrefab, Vector3.zero, Quaternion.identity);
        notplaced = true;
    }
    public void NorInst()
    {
        compsPanel.SetActive(false);
        currentPrefab = Instantiate(norPrefab, Vector3.zero, Quaternion.identity);
        notplaced = true;
    }
    public void XnorInst()
    {
        compsPanel.SetActive(false);
        currentPrefab = Instantiate(xnorPrefab, Vector3.zero, Quaternion.identity);
        notplaced = true;
    }
}
