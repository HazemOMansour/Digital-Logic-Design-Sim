using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineValue : MonoBehaviour
{
    public Color startColor = Color.red;
    public Color OFF = Color.red;
    public Color ON = Color.green;
    LineRenderer lineRenderer;

    public int value;
    LineValue othervalue;
    string iotag;
    GameObject LogicGate;
    GateLogic gateLogic;
    string iotag2;
    GameObject LogicGate2;
    GateLogic gateLogic2;
    public bool twoConnections;
    public bool connectedOut;
    bool connectedLine;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startColor = OFF;
        lineRenderer.endColor = OFF;
        value = 0;
    }

    private void Update()
    {
        if(connectedLine) 
        {
            value = othervalue.value;
            SetColor();
          
        }
        if (gateLogic == null)
            return;

        if (iotag == "O" && !twoConnections)
        {
            value = gateLogic.output;
            SetColor();
        }
        else if (iotag == "O" && twoConnections )
        {
            value = gateLogic.output;
            SetColor();
            gateLogic2.SetInput(iotag2, value);
            gateLogic2.SetOutput();
        }
        else
        {
            gateLogic.SetInput(iotag, value);
            gateLogic.SetOutput();
        }
        
    }

    public void ChangeColor()
    {
        if(lineRenderer.startColor == OFF){
            lineRenderer.startColor= ON;
            lineRenderer.endColor= ON;
            value = 1;
        }
        else
        {
            lineRenderer.startColor = OFF;
            lineRenderer.endColor = OFF;
            value = 0;
        }
    }

    public void SetColor()
    {
        if (value == 0)
        {
            lineRenderer.startColor = OFF;
            lineRenderer.endColor = OFF;
        }
        else
        {
            lineRenderer.startColor = ON;
            lineRenderer.endColor = ON;
        }
    }


    public void GateConnection(GameObject gate, string iotag_)
    {
        if (twoConnections)
        {
            LogicGate2 = gate;
            iotag2 = iotag_;
            gateLogic2 = LogicGate2.GetComponent<GateLogic>();
        }
        else
        {
            LogicGate = gate;
            iotag = iotag_;
            gateLogic = LogicGate.GetComponent<GateLogic>();

        }
    }

    public void ConnectLines(GameObject line)
    {
        othervalue = line.GetComponent<LineValue>();
        connectedLine = true;
    }

    public void OnDestroy()
    {
        if (!string.IsNullOrEmpty(iotag)) {
            gateLogic.SetInput(iotag, 0);
        }
        if (!string.IsNullOrEmpty(iotag2))
        {
            gateLogic2.SetInput(iotag2, 0);
         
        }

    }
}
