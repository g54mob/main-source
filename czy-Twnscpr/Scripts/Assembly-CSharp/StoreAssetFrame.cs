using UnityEngine;

public class StoreAssetFrame : MonoBehaviour
{
	public enum Format
	{
		Png = 0,
		Jpg = 1,
		Tga = 2
	}

	public enum Folder
	{
		StoreAssets = 0,
		Assets = 1
	}

	public Format format;

	public Folder folder;
}
