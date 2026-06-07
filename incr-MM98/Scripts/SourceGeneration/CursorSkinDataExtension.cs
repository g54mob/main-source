using System.Collections.Generic;
using UnityEngine;

public static class CursorSkinDataExtension
{
	private static readonly Dictionary<CursorSkin, CursorData> data;

	static CursorSkinDataExtension()
	{
		data = new Dictionary<CursorSkin, CursorData>();
		ScriptableAssetEnum scriptableAssetEnum = Resources.Load<ScriptableAssetEnum>("Enums/Customization/CursorSkin");
		data.Add(CursorSkin.Standard, (CursorData)scriptableAssetEnum.Data[0].Value);
		data.Add(CursorSkin.Art, (CursorData)scriptableAssetEnum.Data[1].Value);
		data.Add(CursorSkin.Baseball, (CursorData)scriptableAssetEnum.Data[2].Value);
		data.Add(CursorSkin.Burger, (CursorData)scriptableAssetEnum.Data[3].Value);
		data.Add(CursorSkin.Cheese, (CursorData)scriptableAssetEnum.Data[4].Value);
		data.Add(CursorSkin.Cookie, (CursorData)scriptableAssetEnum.Data[5].Value);
		data.Add(CursorSkin.Flame, (CursorData)scriptableAssetEnum.Data[6].Value);
		data.Add(CursorSkin.Globe, (CursorData)scriptableAssetEnum.Data[7].Value);
		data.Add(CursorSkin.Gold, (CursorData)scriptableAssetEnum.Data[8].Value);
		data.Add(CursorSkin.Paw, (CursorData)scriptableAssetEnum.Data[9].Value);
		data.Add(CursorSkin.Pin, (CursorData)scriptableAssetEnum.Data[10].Value);
		data.Add(CursorSkin.Rocket, (CursorData)scriptableAssetEnum.Data[11].Value);
		data.Add(CursorSkin.Sword, (CursorData)scriptableAssetEnum.Data[12].Value);
		data.Add(CursorSkin.Zombie, (CursorData)scriptableAssetEnum.Data[13].Value);
	}

	public static CursorData Value(this CursorSkin key)
	{
		return data[key];
	}
}
