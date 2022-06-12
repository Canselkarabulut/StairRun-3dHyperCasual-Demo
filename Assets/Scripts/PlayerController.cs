using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5;
    public static float _staticSpeed;
    Rigidbody rb;
    public static bool stair = false;
    public static int bagStair;
    GameObject lastbagSpawn;
    Vector3 direction;
    Main _main;
    public static bool _sNextLevelOpen;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _staticSpeed = speed;
        //bagStair = 0;
        direction = new Vector3(0, 0.2f, 0);
    }
    void Update()
    {
        transform.position += new Vector3(0, 0, 1 * _staticSpeed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            StairReduce();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "finish":
                _staticSpeed = 0;
                Main._sAnim.Play("FinishDancePlayer"); //Son Dans
                StartCoroutine(NextSec());
                _sNextLevelOpen = true;
                //2 Saniye sonra nextLevel paneli açýlsýn
                break;
            case "Stair":
                Main._sAnim.SetBool("Run-Stair", true);// Bana deðen merdivense týrman
                break;
            case "PathStair":
                stair = true; // Bana deðen Merdiven yapýnda kullanýlan þeyse artýk merdiven yapabilirsin
                Destroy(collision.gameObject);
                bagSpawn();
                bagStair++;
                break;
            case "Ground":
                Main._sAnim.SetBool("Run-Stair", false); //Bana deðen yerse Run animasyonuna geç
                                                         //    Main._Sanim.SetBool("Stair-Fall", false); //Bana deðen yerse düþme animasyonunu kapat
                break;
            case "Ýnfo":
                Main._staticÝnfoPanel.SetActive(true);
                _staticSpeed = 0;
                Main._sAnim.Play("ÝdlePlayerAnim");
                break;
            case "enemy":
                Main._sAnim.Play("BackFallDie");
                _staticSpeed = 0;
                //2 saniye sonra bitiþ paneli açýlsýn
                StartCoroutine(DieSec());
                break;
            default:
                _sNextLevelOpen = false;
                break;
        }
    }
    public void bagSpawn()
    {
        lastbagSpawn = Instantiate(Main._sSpawnBagStair, Main._sSpawnStair.transform.position + direction, Main._sSpawnStair.transform.rotation, Main._sInSpawn.transform);
        Main._sSpawnStair = lastbagSpawn;
    }
    public void StairReduce()
    {
        Main._staticDestroyPath = lastbagSpawn;
        Main._staticDestroyPath.SetActive(false);
        Main._staticDestroyPath.transform.position -= direction;
    }
    IEnumerator DieSec()
    {
        yield return new WaitForSeconds(2);
        Main._staticDiePanel.SetActive(true);
    }
    IEnumerator NextSec()
    {
        yield return new WaitForSeconds(2.5f);
        Main._staticNextPanel.SetActive(true);
    }
}
