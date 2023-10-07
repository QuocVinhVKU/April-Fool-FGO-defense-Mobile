using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Spawniving : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject CharPrefab;
    public GameObject ObjectSpawend;

    private bool isDrop = false;

    private int cost;
    [SerializeField] private TextMeshProUGUI price;

    private void Start()
    {
        cost = CharPrefab.GetComponent<Servant>().cost;
        price.text = cost.ToString();
    }

    void FixedUpdate()
    {
        if(ObjectSpawend != null && !isDrop)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ObjectSpawend.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0);
        }
        
    }

    public void PointedDown(bool CheckStop)
    {
        if (CheckStop == true && GameManager.instance.currency.curency >= cost)
        {
            isDrop = false;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject Obj;
            Obj = Instantiate(CharPrefab, worldPosition, Quaternion.Euler(0, 0, 0));

            ObjectSpawend = Obj;
            FadeImg(true);
            ObjectSpawend.transform.localPosition = new Vector3(ObjectSpawend.transform.localPosition.x, ObjectSpawend.transform.localPosition.y, 1);
            ObjectSpawend.transform.position = worldPosition;
            ObjectSpawend.transform.localScale = new Vector3(1, 1, 1);
            DisableChildCollider();
            
        }
        else if (CheckStop == false)
        {
            if (GameManager.instance.currency.curency < cost) return;
            isDrop = true;
            EnableChildCollider();
            FadeImg(false);
            StartCoroutine(DelayDestroySpawned());
        }
    }
    IEnumerator DelayDestroySpawned()
    {
        yield return new WaitForSeconds(0.05f);
        if (ObjectSpawend.GetComponent<Servant>().isSpawnedServant == false)
        {
            Destroy(ObjectSpawend);
        }
        else
        {
            ObjectSpawend.GetComponent<Servant>().plantServant.Play();
            GameManager.instance.currency.Use(cost);
        }
    }
    void EnableChildCollider()
    {
        try
        {
            Collider2D[] colls = ObjectSpawend.GetComponentsInChildren<Collider2D>();

            foreach (Collider2D coll in colls)
            {
                coll.enabled = true;
            }
        }
        catch { }
    }
    void DisableChildCollider()
    {
        Collider2D[] colls = ObjectSpawend.GetComponentsInChildren<Collider2D>();

        foreach (Collider2D coll in colls)
        {
            coll.enabled = false;
        }
    }
    void FadeImg(bool fade)
    {
        try
        {
            SpriteRenderer[] spr = ObjectSpawend.GetComponentsInChildren<SpriteRenderer>();
            if (fade)
            {
                foreach (SpriteRenderer s in spr)
                {
                    Color a = s.color;
                    a.a = 0.65f;
                    s.color = a;
                }
            }
            else
            {
                foreach (SpriteRenderer s in spr)
                {
                    // change alpha
                    Color a = s.color;
                    a.a = 1f;
                    s.color = a;
                }
            }
        }
        catch { }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PointedDown(false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        PointedDown(true);
    }
}
