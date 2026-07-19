using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemTexture : MonoBehaviour
{
	public RawImage thumbnail;

	public bool folder;

	public Texture2D texture;

	public GameObject folderIcon;

	public Text folderText;

	public void SetData(Hashtable h)
	{
		base.transform.name = (string)h["name"];
		folder = (bool)h["folder"];
		folderIcon.SetActive(folder);
		folderIcon.GetComponent<Switch>().SetSprite(0);
		if (folder && base.name != "/back")
		{
			folderText.text = base.transform.name;
			folderText.gameObject.SetActive(value: true);
		}
		else
		{
			folderText.gameObject.SetActive(value: false);
		}
		if (base.name == "/back")
		{
			folderIcon.SetActive(value: true);
			folderIcon.GetComponent<Switch>().SetSprite(1);
		}
		thumbnail.gameObject.SetActive(!folder);
		Texture2D texture2D = (Texture2D)h["texture"];
		thumbnail.texture = texture2D;
		texture = texture2D;
		GetComponent<Tooltip>().tip = base.transform.name;
		if ((string)h["tooltip"] != null)
		{
			GetComponent<Tooltip>().tip = (string)h["tooltip"];
		}
	}

	public void Select(Transform selectedTexture)
	{
		if (selectedTexture.name == "/back")
		{
			Textures.LoadFolder();
			return;
		}
		if (folder)
		{
			Textures.LoadFolder(selectedTexture.name);
			return;
		}
		if (Swatches.swatch.mainTexture == texture)
		{
			Swatches.SetTexture(null);
		}
		else
		{
			Swatches.SetTexture(texture);
		}
		Swatches.UpdateMaterials();
	}
}
