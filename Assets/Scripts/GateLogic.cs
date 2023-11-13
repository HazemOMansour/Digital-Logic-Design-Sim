using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLogic : MonoBehaviour
{
    int input1;
    int input2;
    public int output;

    private void Start()
    {
        input1 = 0;
        input2 = 0;
        output = 0;
    }


    public void SetInput(string index, int value)
    {
        if(index == "I1")
        {
            input1 = value;
        }
        else
        {
            input2 = value;
        }

    }

    public void SetOutput()
    {
        if(gameObject.tag == "AND")
            output = input1 & input2;
        if(gameObject.tag == "OR")
            output = input1 | input2;
        if (gameObject.tag == "NOT")
        {
            if (input1 == 0)
                output = 1;
            else
                output = 0;
        }
        if(gameObject.tag == "XOR")
            output = input1 ^ input2;
        if(gameObject.tag == "NAND")
        {
            if (input1 == 0 && input2 == 0)
                output = 1;
            if (input1 == 0 && input2 == 1)
                output = 1;
            if (input1 == 1 && input2 == 0)
                output = 1;
            if (input1 == 1 && input2 == 1)
                output = 0;
        }
        if(gameObject.tag == "NOR")
        {
            if (input1 == 0 && input2 == 0)
                output = 1;
            if (input1 == 0 && input2 == 1)
                output = 0;
            if (input1 == 1 && input2 == 0)
                output = 0;
            if (input1 == 1 && input2 == 1)
                output = 0;
        }
        if (gameObject.tag == "XNOR")
        {
            if (input1 == 0 && input2 == 0)
                output = 1;
            if (input1 == 0 && input2 == 1)
                output = 0;
            if (input1 == 1 && input2 == 0)
                output = 0;
            if (input1 == 1 && input2 == 1)
                output = 1;
        }


    }


}
