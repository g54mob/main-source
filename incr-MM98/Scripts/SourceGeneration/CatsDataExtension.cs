using System.Collections.Generic;
using UnityEngine;

public static class CatsDataExtension
{
	private static readonly Dictionary<Cats, CatData> data;

	static CatsDataExtension()
	{
		data = new Dictionary<Cats, CatData>();
		ScriptableAssetEnum scriptableAssetEnum = Resources.Load<ScriptableAssetEnum>("Enums/Customization/Cats");
		data.Add(Cats.Karma1, (CatData)scriptableAssetEnum.Data[0].Value);
		data.Add(Cats.Karma2, (CatData)scriptableAssetEnum.Data[1].Value);
		data.Add(Cats.Karma3, (CatData)scriptableAssetEnum.Data[2].Value);
		data.Add(Cats.Karma4, (CatData)scriptableAssetEnum.Data[3].Value);
		data.Add(Cats.Hiro1, (CatData)scriptableAssetEnum.Data[4].Value);
		data.Add(Cats.Hiro2, (CatData)scriptableAssetEnum.Data[5].Value);
		data.Add(Cats.Hiro3, (CatData)scriptableAssetEnum.Data[6].Value);
		data.Add(Cats.Hiro4, (CatData)scriptableAssetEnum.Data[7].Value);
		data.Add(Cats.Kiwi1, (CatData)scriptableAssetEnum.Data[8].Value);
		data.Add(Cats.Kiwi2, (CatData)scriptableAssetEnum.Data[9].Value);
		data.Add(Cats.Kiwi3, (CatData)scriptableAssetEnum.Data[10].Value);
		data.Add(Cats.Kiwi4, (CatData)scriptableAssetEnum.Data[11].Value);
		data.Add(Cats.Chokotoff1, (CatData)scriptableAssetEnum.Data[12].Value);
		data.Add(Cats.Chokotoff2, (CatData)scriptableAssetEnum.Data[13].Value);
		data.Add(Cats.Chokotoff3, (CatData)scriptableAssetEnum.Data[14].Value);
		data.Add(Cats.Chokotoff4, (CatData)scriptableAssetEnum.Data[15].Value);
	}

	public static CatData Value(this Cats key)
	{
		return data[key];
	}
}
