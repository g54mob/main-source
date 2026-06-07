using System.Collections.Generic;
using UnityEngine;

public static class BoxArtDataExtension
{
	private static readonly Dictionary<BoxArt, Texture> data;

	static BoxArtDataExtension()
	{
		data = new Dictionary<BoxArt, Texture>();
		ScriptableAssetEnum scriptableAssetEnum = Resources.Load<ScriptableAssetEnum>("Enums/Customization/BoxArt");
		data.Add(BoxArt.Custom, (Texture)scriptableAssetEnum.Data[0].Value);
		data.Add(BoxArt.One, (Texture)scriptableAssetEnum.Data[1].Value);
		data.Add(BoxArt.Two, (Texture)scriptableAssetEnum.Data[2].Value);
		data.Add(BoxArt.Three, (Texture)scriptableAssetEnum.Data[3].Value);
		data.Add(BoxArt.Four, (Texture)scriptableAssetEnum.Data[4].Value);
		data.Add(BoxArt.Five, (Texture)scriptableAssetEnum.Data[5].Value);
		data.Add(BoxArt.Six, (Texture)scriptableAssetEnum.Data[6].Value);
		data.Add(BoxArt.Seven, (Texture)scriptableAssetEnum.Data[7].Value);
		data.Add(BoxArt.Eight, (Texture)scriptableAssetEnum.Data[8].Value);
		data.Add(BoxArt.Nine, (Texture)scriptableAssetEnum.Data[9].Value);
		data.Add(BoxArt.Ten, (Texture)scriptableAssetEnum.Data[10].Value);
	}

	public static Texture Value(this BoxArt key)
	{
		return data[key];
	}
}
