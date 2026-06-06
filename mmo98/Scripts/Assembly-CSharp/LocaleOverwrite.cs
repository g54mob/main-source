using System.Globalization;
using System.Threading;
using UnityEngine;

public class LocaleOverwrite : MonoBehaviour
{
	public enum LocaleChoice
	{
		en_US = 0,
		en_GB = 1,
		fr_FR = 2,
		de_DE = 3,
		ja_JP = 4,
		es_ES = 5,
		en_IN = 6
	}

	[Header("Settings")]
	public bool overwriteLocale = true;

	public LocaleChoice targetLocale;

	private void Awake()
	{
		if (overwriteLocale)
		{
			ApplyLocale();
		}
	}

	private void OnValidate()
	{
		if (Application.isPlaying && overwriteLocale)
		{
			ApplyLocale();
		}
	}

	private void ApplyLocale()
	{
		string arg = targetLocale.ToString().Replace("_", "-");
		CultureInfo cultureInfo = new CultureInfo(arg);
		Thread.CurrentThread.CurrentCulture = cultureInfo;
		Thread.CurrentThread.CurrentUICulture = cultureInfo;
		CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
		CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
		float num = 1234567.9f;
		Debug.Log($"<b>[Locale Overwrite]</b> Set to {arg}. Number: {num:N} | Currency: {num:C}");
	}
}
