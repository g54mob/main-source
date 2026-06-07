using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class AppBrowserWebsite
{
	public string address;

	public string webTitle;

	public bool isAdress;

	public bool isLanDevice;

	[Header("Polska żaba")]
	public RectTransform _objectWebsite;

	[Header("Jacek placek")]
	public UnityEvent<string, string, UnityEngine.Object> actionOpen;

	public UnityEvent actionClose;

	public void OpenWebsite(string _adress = "def", string _inputAddress = "def", UnityEngine.Object _device = null)
	{
	}

	public void CloseWebsite()
	{
	}
}
