using UnityEngine;

public enum ColorType
{
    Default = 0,
    Blue    = 1,
    Green = 2,
    Yellow = 3,
}

public class ColorData : MonoBehaviour
{
    [SerializeField] private Material[] colorMats;
    public ColorType colorType;
    public MeshRenderer meshRenderer;

    

    public void ChangeColor(ColorType colorType)
    {
        this.colorType = colorType;
        meshRenderer.material = GetColorMat(colorType);
    }

    public Material GetColorMat(ColorType colorType)
    {
        return colorMats[(int)colorType];            
    }

    
}
