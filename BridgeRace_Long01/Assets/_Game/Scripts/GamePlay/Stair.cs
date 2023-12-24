using Unity.VisualScripting;
using UnityEngine;

public class Stair : ColorData
{
    [SerializeField] private GameObject stepOn;

    public Stage stage;

    private bool isPassed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Character character = other.GetComponent<Character>();
            if (character.items.Count != 0)
            {
                stage = character.stage;   
                ColorType colorData = other.GetComponent<Character>().colorType;
                ColorType stairColor = GetComponent<Stair>().colorType;
                if (!isPassed)
                {
                    stage.NewBrick(character.colorType);
                    ChangeColor(colorData);
                    character.RemoItem();
                    stepOn.gameObject.SetActive(true);
                    isPassed = true;
                }
                else if (isPassed && stairColor != colorData)
                {
                    stage.NewBrick(character.colorType);
                    ChangeColor(colorData);
                    character.RemoItem();
                    isPassed = true;
                }
            }
        }
    }
}
