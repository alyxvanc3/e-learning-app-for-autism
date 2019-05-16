using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour, IDragHandler, IDropHandler
{
    private bool _collided = false;
    private bool _initialized = false;
    private Collider2D _colObject;
    private Vector3 _initialPos;

    void Start()
    {
        _colObject = new Collider2D();
        _colObject = null;

        if (!_initialized)
        {
            _initialized = true;
            _initialPos = transform.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        this.transform.SetAsLastSibling();
    }

    void OnDisable()
    {
        InitializePosition();
    }

    public void InitializePosition()
    {
        transform.position = _initialPos;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (_colObject != null && _collided == true)
        {
            if (this.tag == "Untagged" || _colObject.gameObject.tag == "Untagged")
            {
                InitializePosition();
                _collided = false;
            }
            else if (this.tag == _colObject.gameObject.tag)
            {
                transform.position = _colObject.transform.position;
                _collided = false;
                // puanlama ve animasyon
                if (Odullendirme.Instance.dogru == 0)
                {
                    Odullendirme.Instance.AnimDogru();

                }
                else if (Odullendirme.Instance.dogru == 1)
                {
                    Odullendirme.Instance.AnimBasardin();
                }
            }
            else
            {
                InitializePosition();
                _collided = false;
            }
        }
        else
        {
            // 
            transform.position = _initialPos;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col != null)
        {
            _colObject = col;
            _collided = true;
        }       
    }
}