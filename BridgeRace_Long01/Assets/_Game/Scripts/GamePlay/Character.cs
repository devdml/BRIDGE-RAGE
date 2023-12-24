using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : ColorData
{
    [SerializeField] public List<Transform> items = new List<Transform>();
    [SerializeField] private Transform holder;
    [SerializeField] private Transform playerPrefab;

    public int BrickCount => items.Count;

    public Stage stage;
    protected virtual void Start()
    {
        ChangeColor(colorType);
    }
    
    
    public void AddBrick(Color color)
    {
        int index = items.Count;
        Transform itemsPlayer = Instantiate(playerPrefab, holder);
        itemsPlayer.localPosition = Vector3.up + index * 0.5f * Vector3.up;
        itemsPlayer.GetComponent<MeshRenderer>().material.color = color;
        items.Add(itemsPlayer);
    }

    public void RemoItem()
    {
        int index = items.Count - 1;

        if (index >= 0)
        {
            Transform itemsPlayer = items[index];
            items.RemoveAt(index);
            Destroy(itemsPlayer.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Brick"))
        {
            Color brickColor = other.GetComponent<MeshRenderer>().material.color;
            Brick brick = other.GetComponent<Brick>();
            if (brick.colorType == colorType)
            {
                brick.OnDespawn();
                AddBrick(brickColor);
                Destroy(brick.gameObject);
            }
        }
    }
}
