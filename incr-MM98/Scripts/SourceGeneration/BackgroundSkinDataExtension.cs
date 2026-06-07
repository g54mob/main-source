using System.Collections.Generic;
using UnityEngine;

public static class BackgroundSkinDataExtension
{
	private static readonly Dictionary<BackgroundSkin, BackgroundData> data;

	static BackgroundSkinDataExtension()
	{
		data = new Dictionary<BackgroundSkin, BackgroundData>();
		ScriptableAssetEnum scriptableAssetEnum = Resources.Load<ScriptableAssetEnum>("Enums/Customization/BackgroundSkin");
		data.Add(BackgroundSkin.Win95Clouds, (BackgroundData)scriptableAssetEnum.Data[0].Value);
		data.Add(BackgroundSkin.Vaporwave, (BackgroundData)scriptableAssetEnum.Data[1].Value);
		data.Add(BackgroundSkin.DigitalRain, (BackgroundData)scriptableAssetEnum.Data[2].Value);
		data.Add(BackgroundSkin.Teal, (BackgroundData)scriptableAssetEnum.Data[3].Value);
		data.Add(BackgroundSkin.NavyBlue, (BackgroundData)scriptableAssetEnum.Data[4].Value);
		data.Add(BackgroundSkin.Burgundy, (BackgroundData)scriptableAssetEnum.Data[5].Value);
		data.Add(BackgroundSkin.DeepPurple, (BackgroundData)scriptableAssetEnum.Data[6].Value);
		data.Add(BackgroundSkin.Black, (BackgroundData)scriptableAssetEnum.Data[7].Value);
		data.Add(BackgroundSkin.Beach, (BackgroundData)scriptableAssetEnum.Data[8].Value);
		data.Add(BackgroundSkin.Lion, (BackgroundData)scriptableAssetEnum.Data[9].Value);
		data.Add(BackgroundSkin.BouncingBall, (BackgroundData)scriptableAssetEnum.Data[10].Value);
		data.Add(BackgroundSkin.Warp, (BackgroundData)scriptableAssetEnum.Data[11].Value);
	}

	public static BackgroundData Value(this BackgroundSkin key)
	{
		return data[key];
	}
}
