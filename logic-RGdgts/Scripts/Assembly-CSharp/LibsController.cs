using System;
using System.Collections.Generic;
using UI.Common;
using UI.Elements;
using UnityEngine;

public class LibsController : Controller, ILogOrigin
{
	public class Lib : IElementColoredButtonParameters
	{
		public class Asset
		{
			public string name;

			public string fileName;

			public AssetType assetType;

			public Lib lib;

			public string filePath => null;

			public Asset(string name, string fileName, AssetType assetType, Lib lib)
			{
			}
		}

		public enum Origin
		{
			External = 0,
			Official = 1
		}

		public struct Infos
		{
			public string documentationUrl;

			public string license;

			public Origin origin;
		}

		public string name;

		public Infos infos;

		public Dictionary<string, Asset> assets;

		public Lib(string name)
		{
		}

		public string GetButtonName()
		{
			return null;
		}

		public Sprite GetButtonIcon()
		{
			return null;
		}

		public Sprite GetButtonSprite(ElementParameters par)
		{
			return null;
		}

		public string GetButtonString(ElementParameters par)
		{
			return null;
		}

		public void AddOnButtonChangeAction(UnityEngine.Object owner, Action<IElementColoredButtonParameters> onChange)
		{
		}

		public bool IsSecondaryColor()
		{
			return false;
		}
	}

	[NonSerialized]
	[HideInInspector]
	public Dictionary<string, Lib> libs;

	private string libsPath;

	public override void Init()
	{
	}
}
