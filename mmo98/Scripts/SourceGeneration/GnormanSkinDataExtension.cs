using System.Collections.Generic;
using UnityEngine;

public static class GnormanSkinDataExtension
{
	private static readonly Dictionary<GnormanSkin, GnormanSkinData> data;

	static GnormanSkinDataExtension()
	{
		data = new Dictionary<GnormanSkin, GnormanSkinData>();
		ScriptableAssetEnum scriptableAssetEnum = Resources.Load<ScriptableAssetEnum>("Enums/Customization/GnormanSkin");
		data.Add(GnormanSkin.Default, (GnormanSkinData)scriptableAssetEnum.Data[0].Value);
		data.Add(GnormanSkin.Gold, (GnormanSkinData)scriptableAssetEnum.Data[1].Value);
		data.Add(GnormanSkin.Green, (GnormanSkinData)scriptableAssetEnum.Data[2].Value);
		data.Add(GnormanSkin.rainbow, (GnormanSkinData)scriptableAssetEnum.Data[3].Value);
		data.Add(GnormanSkin.GnomedalfWhite, (GnormanSkinData)scriptableAssetEnum.Data[4].Value);
		data.Add(GnormanSkin.GnomedalfGrey, (GnormanSkinData)scriptableAssetEnum.Data[5].Value);
		data.Add(GnormanSkin.Pink, (GnormanSkinData)scriptableAssetEnum.Data[6].Value);
		data.Add(GnormanSkin.Yellow, (GnormanSkinData)scriptableAssetEnum.Data[7].Value);
		data.Add(GnormanSkin.Brown, (GnormanSkinData)scriptableAssetEnum.Data[8].Value);
	}

	public static GnormanSkinData Value(this GnormanSkin key)
	{
		return data[key];
	}
}
