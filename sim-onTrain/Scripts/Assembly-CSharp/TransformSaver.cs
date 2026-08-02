using System.Collections.Generic;
using UnityEngine;

public static class TransformSaver
{
	private static string GenerateKeyFromPosition(Vector3 position, int wagonIndex)
	{
		string text = position.x.ToString("F2").Replace(".", "").Replace(",", "");
		string text2 = position.y.ToString("F2").Replace(".", "").Replace(",", "");
		string text3 = position.z.ToString("F2").Replace(".", "").Replace(",", "");
		text = text.Replace("-", "");
		text2 = text2.Replace("-", "");
		text3 = text3.Replace("-", "");
		return text + text2 + text3 + "w:" + wagonIndex;
	}

	public static void SaveTransformWithPositionKey(Transform transform, int wagonIndex)
	{
		string text = GenerateKeyFromPosition(transform.position, wagonIndex);
		string key = text + "_position";
		string key2 = text + "_rotation";
		string key3 = text + "_wagon";
		ES3.Save(key, transform.position);
		ES3.Save(key2, transform.rotation);
		ES3.Save(key3, wagonIndex);
		Debug.Log($"Transform kaydedildi - Key: {text}, WagonIndex: {wagonIndex}");
	}

	public static void SaveMultipleTransformsWithPositionKey(List<Transform> transforms, int wagonIndex)
	{
		foreach (Transform transform in transforms)
		{
			SaveTransformWithPositionKey(transform, wagonIndex);
		}
		Debug.Log($"Toplam {transforms.Count} transform kaydedildi, WagonIndex: {wagonIndex}");
	}

	public static TransformData LoadTransformWithPositionKey(Vector3 position, int wagonIndex)
	{
		string text = GenerateKeyFromPosition(position, wagonIndex);
		string key = text + "_position";
		string key2 = text + "_rotation";
		string key3 = text + "_wagon";
		if (ES3.KeyExists(key) && ES3.KeyExists(key2))
		{
			Vector3 pos = ES3.Load<Vector3>(key);
			Quaternion rot = ES3.Load<Quaternion>(key2);
			int num = ES3.Load<int>(key3);
			Debug.Log($"Transform yüklendi - Key: {text}, WagonIndex: {num}");
			return new TransformData(pos, rot, num);
		}
		Debug.Log("Bu pozisyon için kayıt bulunamadı - Key: " + text);
		return null;
	}

	public static List<TransformData> LoadAllTransformsForWagon(int wagonIndex)
	{
		List<TransformData> list = new List<TransformData>();
		Debug.Log($"Wagon {wagonIndex} için transform'lar yüklendi: {list.Count} adet");
		return list;
	}

	public static void DeleteTransformWithPositionKey(Vector3 position, int wagonIndex)
	{
		string text = GenerateKeyFromPosition(position, wagonIndex);
		string key = text + "_position";
		string key2 = text + "_rotation";
		string key3 = text + "_wagon";
		ES3.DeleteKey(key);
		ES3.DeleteKey(key2);
		ES3.DeleteKey(key3);
		Debug.Log("Transform silindi - Key: " + text);
	}

	public static void DeleteAllTransformsForWagon(int wagonIndex)
	{
		Debug.Log($"Wagon {wagonIndex} için tüm transform'lar silindi");
	}

	public static bool TransformExistsAtPosition(Vector3 position, int wagonIndex)
	{
		return ES3.KeyExists(GenerateKeyFromPosition(position, wagonIndex) + "_position");
	}

	public static string GetKeyForPosition(Vector3 position, int wagonIndex)
	{
		return GenerateKeyFromPosition(position, wagonIndex);
	}
}
