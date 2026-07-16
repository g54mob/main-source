using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HoverOutline : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public SpriteRenderer outlineSr;

	public Image outlineImage;

	protected void Awake()
	{
		if (outlineSr == null)
		{
			outlineSr = GetComponent<SpriteRenderer>();
		}
		if (outlineImage == null)
		{
			outlineImage = GetComponent<Image>();
		}
		if ((bool)outlineImage)
		{
			outlineImage.material = new Material(outlineImage.material);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if ((bool)outlineImage.material)
		{
			SetOutline(isActive: true, Color.yellow);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if ((bool)outlineImage.material)
		{
			SetOutline(isActive: false, Color.yellow);
		}
	}

	public void SetOutline(bool isActive, Color color)
	{
		if ((bool)outlineSr)
		{
			outlineSr.material.SetFloat("_OutlineThickness", isActive ? 1f : 0f);
			outlineSr.material.SetColor("_OutlineColor", color);
		}
		if ((bool)outlineImage)
		{
			outlineImage.material.SetFloat("_OutlineThickness", isActive ? 1f : 0f);
			outlineImage.material.SetColor("_OutlineColor", color);
		}
	}
}
