using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public AudioSource sound;
    public AudioClip sprongDoying;
    public AudioClip dinkleDinkle;
    public AudioClip dong;
    public AudioClip errrrrr;
    public AudioClip whaWha;

    public AudioClip[] movin;

    public wobble wob;

    public Image icon;
    public Sprite[] icons;

    // Update is called once per frame
    public void Tool0()
    {
        tool = 0;
        icon.sprite = icons[tool]; 
    }
    public void Tool1()
    {
        tool = 1;
        icon.sprite = icons[tool];
    }
    public void Tool2()
    {
        tool = 2;
        icon.sprite = icons[tool];
    }
    public void Tool3()
    {
        tool = 3;
        icon.sprite = icons[tool];
    }
    public void Tool4()
    {
        tool = 4;
        icon.sprite = icons[tool];
    }
    public void Tool5()
    {
        tool = 5;
        icon.sprite = icons[tool];
    }
    void Respawn()
    {
        wobbler.velocity = new Vector3(0,0,0);
        wobbler.angularVelocity = new Vector3(0, 0, 0);
        wobbler.transform.rotation = new Quaternion(0, 0, 0, 0);
        wobbler.transform.position = new Vector3(UnityEngine.Random.Range(-8f, 8f), 4, UnityEngine.Random.Range(-8f, 8f));
    }

    void FixedUpdate()
    {

        //icon.transform.position = Input.mousePosition;

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

        if (Physics.Raycast(beam, out hit) && Input.GetMouseButton(0) && hit.rigidbody != null)
        {
            if (tool == 0)
            {
                if (!sound.isPlaying)
                {
                    sound.clip = movin[UnityEngine.Random.Range(0, 2)];
                }
                hit.rigidbody.AddExplosionForce(500, hit.point, 50f);
            } else if (tool == 1)
            {
                if (!sound.isPlaying)
                {
                    sound.clip = sprongDoying;
                }
                hit.rigidbody.AddExplosionForce(1000, wobbler.transform.position, 5f);

            }
            else if (tool == 2 && hit.rigidbody.tag == "Finish")
            {
                if (!sound.isPlaying)
                {
                    sound.clip = dinkleDinkle;
                }
                Instantiate(prefab, hit.point, Quaternion.identity);
            }
            else if (tool == 3)
            {
                if (!sound.isPlaying)
                {
                    sound.clip = errrrrr;
                }
                hit.rigidbody.AddExplosionForce(-200, hit.point, 5f);
            }
            else if (tool == 4 && hit.rigidbody.tag == "Finish")
            {
                if (!sound.isPlaying)
                {
                    sound.clip = dong;
                }
                Respawn();
            }
            else if (!sound.isPlaying && tool == 5 && hit.rigidbody.tag == "Finish")
            {
                if (!sound.isPlaying)
                {
                    sound.clip = whaWha;
                }
                hit.rigidbody.AddExplosionForce(50, hit.point, 50f);
                wob.Switch();
            }
            if (!sound.isPlaying && hit.rigidbody.tag == "Finish")
            {
                sound.Play();
            }
            
        }
        if (wobbler.transform.position.z > 12 || wobbler.transform.position.z < -12 || wobbler.transform.position.x > 12 || wobbler.transform.position.z < -12)
        {
            Respawn();
        }
    }
}
