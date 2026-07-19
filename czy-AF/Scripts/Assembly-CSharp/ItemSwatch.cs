using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemSwatch : MonoBehaviour
{
	public RawImage swatchIcon;

	public Sprite spriteDefault;

	public Sprite spriteSelected;

	public void SetData(Hashtable h)
	{
		Material material = Swatches.GetMaterial(h["name"] as string);
		base.transform.name = material.name;
		swatchIcon.color = material.color;
		swatchIcon.texture = material.mainTexture;
		if ((bool)h["selected"])
		{
			GetComponent<Image>().sprite = spriteSelected;
		}
		else
		{
			GetComponent<Image>().sprite = spriteDefault;
		}
		GetComponent<Tooltip>().tip = base.transform.name;
	}

	public void Select(Transform selectedSwatch)
	{
		Swatches.SetSwatch(selectedSwatch.name);
		Swatches.swatchList.UpdateElements();
	}
}
