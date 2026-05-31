using System;
using System.Collections.Generic;
using UnityEngine;

public class VirusPlusCodeDatabase : MonoBehaviour
{
	[Serializable]
	private class ActiveCodeListWrapper
	{
		public List<ActiveCode> activeCodeList;
	}

	public static VirusPlusCodeDatabase instance;

	[SerializeField]
	public List<ActiveCode> activeCodeList;

	private void Awake()
	{
	}

	public void ClearData()
	{
	}

	public void AddNewCode(string code)
	{
	}

	public static string GenerateActivationCode()
	{
		return null;
	}

	public void RemoveCode(string code)
	{
	}

	public string ActiveCodeToJson()
	{
		return null;
	}

	public void JsonToActiveCode(string json)
	{
	}
}
