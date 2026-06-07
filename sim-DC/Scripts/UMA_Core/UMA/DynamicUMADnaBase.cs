using System;
using System.Collections.Generic;

namespace UMA
{
	[Serializable]
	public abstract class DynamicUMADnaBase : UMADnaBase
	{
		public DynamicUMADnaAsset _dnaAsset;

		public string dnaAssetName;

		[NonSerialized]
		public bool didDnaAssetUpdate;

		[NonSerialized]
		public bool didDnaTypeHashUpdate;

		public float[] _values;

		public string[] _names;

		protected static Dictionary<string, DynamicUMADnaAsset> DynamicDNADictionary;

		public abstract DynamicUMADnaAsset dnaAsset { get; set; }

		public abstract override int Count { get; }

		public abstract override float[] Values { get; set; }

		public abstract override string[] Names { get; }

		protected static void InitializeDynamicDNADictionary()
		{
		}

		public static void DefineDynamicDNAType(DynamicUMADnaAsset asset)
		{
		}

		public abstract float GetValue(string dnaName, bool failSilently = false);

		public abstract override float GetValue(int idx);

		public abstract void SetValue(string name, float value);

		public abstract override void SetValue(int idx, float value);

		public abstract int ImportUMADnaValues(UMADnaBase umaDna);

		public virtual void SetDnaTypeHash(int typeHash)
		{
		}

		public virtual void FindMissingDnaAsset(string dnaAssetName)
		{
		}

		public virtual void SetMissingDnaAsset(DynamicUMADnaAsset[] foundAssets)
		{
		}
	}
}
