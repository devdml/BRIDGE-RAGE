using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] private Brick brickPrefab;

    public Transform[] brickPoint;
    public List<Vector3> emtyPoint = new List<Vector3>();
    public List<Brick> bricks = new List<Brick>();


    private void Start()
    {
        OnInit();
    }
    public void OnInit()
    {
        for (int i = 0; i < brickPoint.Length; i++)
        {
            emtyPoint.Add(brickPoint[i].position);
        }
    }

    public void InitColor(ColorType colorType, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            NewBrick(colorType);
        }
    }

    public void NewBrick(ColorType colorType)
    {
        int rand = Random.Range(1, emtyPoint.Count);
        Brick brick = Instantiate(brickPrefab, emtyPoint[rand], Quaternion.identity);
        brick.Stage = this;
        brick.ChangeColor(colorType);
        emtyPoint.RemoveAt(rand);
        bricks.Add(brick);
    }

    internal void RemoveBrick(Brick brick)
    {
        emtyPoint.Add(brick.transform.position);
        bricks.Remove(brick);
    }

    internal Brick SeekBrickPoint(ColorType colorType)
    {
        Brick brick = null;
        for (int i = 0; i < bricks.Count; i++)
        {
            if (bricks[i].colorType == colorType)
            {
                brick = bricks[i];
                break;
            }
        }
        return brick;
    }
}
