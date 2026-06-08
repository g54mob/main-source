using System;
using UnityEngine;

[Serializable]
public class JsonSerializable
{
	public static implicit operator string(JsonSerializable o)
	{
		return JsonUtility.ToJson(o);
	}
}
