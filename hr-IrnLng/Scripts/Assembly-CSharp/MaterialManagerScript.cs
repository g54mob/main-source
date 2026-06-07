using UnityEngine;

public class MaterialManagerScript : MonoBehaviour
{
	public enum TexTypes
	{
		Default = 0,
		MarkiplierMode = 1
	}

	public TexTypes TextureType;

	public Material[] MaterialsToChange;

	public Texture2D[] DefaultTextures;

	public Texture2D[] MarkiplierTextures;

	private void Start()
	{
		TextureType = TexTypes.Default;
		ChangeTextures();
	}

	private void Update()
	{
	}

	public void ChangeTextures()
	{
		for (int i = 0; i < MaterialsToChange.Length; i++)
		{
			Texture2D value = Texture2D.blackTexture;
			if (TextureType == TexTypes.Default)
			{
				value = DefaultTextures[i];
			}
			if (TextureType == TexTypes.MarkiplierMode)
			{
				value = MarkiplierTextures[i];
			}
			MaterialsToChange[i].SetTexture("_Main", value);
		}
	}
}
