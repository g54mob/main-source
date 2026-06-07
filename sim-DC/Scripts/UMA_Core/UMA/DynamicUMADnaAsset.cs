using System;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class DynamicUMADnaAsset : ScriptableObject, INameProvider
	{
		public int dnaTypeHash;

		[SerializeField]
		protected string lastKnownAssetPath;

		[SerializeField]
		protected string lastKnownDuplicateAssetPath;

		[SerializeField]
		protected int lastKnownInstanceID;

		public string[] Names;

		public string GetAssetName()
		{
			return null;
		}

		public int GetNameHash()
		{
			return 0;
		}

		public static int GenerateUniqueDnaTypeHash()
		{
			return 0;
		}
	}
}
