using System;
using System.Collections.Generic;
using UnityEngine;

public class CodeAsset : Asset
{
	[Serializable]
	public class Serialized : SerializedAsset
	{
		public string sourceCode;

		public Serialized()
		{
		}

		public Serialized(CodeAsset source)
		{
		}

		public override Asset Instantiate(SerializedAssetMetadata metadata)
		{
			return null;
		}
	}

	private static TextAsset _defaultSourceCode;

	public string sourceCode;

	public HashSet<int> debugBreakpoints;

	public static string defaultSourceCode => null;

	public CodeAsset()
	{
	}

	public CodeAsset(string name)
	{
	}

	public CodeAsset(string name, string sourceCode)
	{
	}

	public override AssetType GetAssetType()
	{
		return default(AssetType);
	}

	public override void Dispose()
	{
	}

	public override SerializedAsset ToSerializedAsset()
	{
		return null;
	}

	public override void InitDefaultEditorAsset()
	{
	}

	public override bool LoadFromFile(string path, Asset[] additionalInitAssets)
	{
		return false;
	}
}
