using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CyclopsSucs : MonoBehaviour
{

    // Start is called before the first frame update

    public GameObject prefab;

    int score = 0;
    public TMP_Text scoreText;

    public Rigidbody wobbler;

    public int tool;

    // Update is called once per frame
    public void Tool0()
    {
        tool = 0;
    }
    public void Tool1()
    {
        tool = 1;
    }
    public void Tool2()
    {
        tool = 2;
    }
    public void Tool3()
    {
        tool = 3;
    }
    public void Tool4()
    {
        tool = 4;
    }
    public void Tool5()
    {
        tool = 5;
    }
    void FixedUpdate()
    {
        if (Math.Max(Math.Max(wobbler.velocity.x, wobbler.velocity.y), wobbler.velocity.z) > 2)
        {
            score += (int)Math.Max(Math.Max(wobbler.velocity.x, wobbler.velocity.y), wobbler.velocity.z);
        }
        scoreText.text = score.ToString();
        if (Input.GetKey("d"))
        {
            transform.Rotate(new Vector3(0, -2, 0));
        }
        if (Input.GetKey("a"))
        {
            transform.Rotate(new Vector3(0, 2, 0));
        }
        Ray beam = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(beam, out hit))
        {
            if (Input.GetMouseButton(0))
            {
                if (hit.rigidbody != null)
                {
                    if (tool == 0)
                    {
                        hit.rigidbody.AddExplosionForce(500, hit.point, 50f);
                    } else if (tool == 1)
                    {
                        hit.rigidbody.AddExplosionForce(500, wobbler.transform.position, 5f);
                    }
                    else if (tool == 2 && hit.rigidbody.tag == "Finish")
                    {
                        Instantiate(prefab, hit.point, Quaternion.identity);
                    }
                    else if (tool == 3)
                    {
                        hit.rigidbody.AddExplosionForce(-500, hit.point, 5f);
                    }
                    //make one that teleports it randomly in the box and deletes the rats under it
                    //add that it does that one if it gets forced out of the box
                }
            }
            /*
            if (Input.GetMouseButtonDown(1))
            {
                Instantiate(prefab, hit.point, Quaternion.identity);
            }*/
        }
    }
}
