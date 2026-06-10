using System;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
	[Serializable]
	public class CreditCategory
	{
		public string name;

		public bool localize;

		public string extra;

		public bool localizeExtra;

		public List<CreditEntry> credits;
	}

	[Serializable]
	public class CreditEntry
	{
		public string title;

		public List<CreditName> names;
	}

	[Serializable]
	public class CreditName
	{
		public string name;

		public string additional;
	}

	[Header("Credits")]
	public List<CreditCategory> credits;

	private static CreditsController _instance;

	public static CreditsController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public string GetFormattedCreditsText()
	{
		return null;
	}
}
