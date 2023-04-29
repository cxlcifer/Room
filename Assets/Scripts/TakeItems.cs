using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItems : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _itemPosition;
    [SerializeField] private LayerMask _layer;
    public bool isItemTaken = false;
    public InteractableItem _item;
    void Update()
    {
        var ray = new Ray(_camera.transform.position, transform.forward);

        if (Physics.Raycast(ray, out var hitInfo,50f,_layer))
        {
            var gameObject = hitInfo.collider.gameObject;

            if (gameObject != null && Input.GetKeyDown(KeyCode.E))
            {
                if (_item != null && isItemTaken)
                {
                    DropItem();
                }
                _item = gameObject.GetComponent<InteractableItem>();
                PickUpItem(_item);
                isItemTaken = true;
               
            }
            
        }

        if (isItemTaken && Input.GetMouseButton(0))
        {
            ThrowItem();
        }
    }

    private void DropItem()
    {
        _item.GetComponent<Rigidbody>().useGravity = true;
        _item.GetComponent<Rigidbody>().isKinematic = false;
        _item.transform.parent = null;
        _item = null;
        isItemTaken = false;
    }
    private void PickUpItem(InteractableItem item)
    {
        _item.GetComponent<Rigidbody>().useGravity = false;
        _item.GetComponent<Rigidbody>().isKinematic = true;
        _item.transform.parent = _itemPosition;
        _item.transform.position = _item.transform.position;
        _item.transform.localPosition = Vector3.zero;
    }

    private void ThrowItem()
    {
        _item.GetComponent<Rigidbody>().useGravity = true;
        _item.GetComponent<Rigidbody>().isKinematic = false;
        _item.GetComponent<Rigidbody>().AddForce(transform.forward*500f);
        _item.transform.parent = null;
        _item = null;
        isItemTaken = false;
    }
    
}
