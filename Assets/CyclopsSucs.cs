using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CyclopsSucs : MonoBehaviour
{

    // Start is called before the first frame update

    public GameObject prefab;

    int score = 0;
    public GameObject tex;

    public GameObject rota;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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
                if (hit.rigidbody != null && hit.rigidbody.gameObject.tag == "Targ")
                {
                    Destroy(hit.rigidbody.gameObject);
                    score += 1;

                }
                else if (hit.rigidbody != null && hit.rigidbody.gameObject.tag == "NO")
                {
                    SceneManager.LoadScene("SampleScene");
                }
                else if (hit.rigidbody != null)
                {

                    hit.rigidbody.AddExplosionForce(100, hit.point, 5f);
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                Instantiate(prefab, hit.point, Quaternion.identity);
            }
        }
        if (score == 7)
        {
            tex.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == "Enemy")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
