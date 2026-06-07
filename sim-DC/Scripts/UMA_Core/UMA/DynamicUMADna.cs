namespace UMA
{
	public class DynamicUMADna : DynamicUMADnaBase
	{
		public override DynamicUMADnaAsset dnaAsset
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override int Count => 0;

		public override float[] Values
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override string[] Names => null;

		public DynamicUMADna()
		{
		}

		public DynamicUMADna(int typeHash)
		{
		}

		public static string[] GetNames()
		{
			return null;
		}

		public override int ImportUMADnaValues(UMADnaBase umaDna)
		{
			return 0;
		}

		private void ValidateValues(string[] requiredNames)
		{
		}

		public override float GetValue(string dnaName, bool failSilently = false)
		{
			return 0f;
		}

		public override float GetValue(int idx)
		{
			return 0f;
		}

		public override void SetValue(string dnaName, float value)
		{
		}

		public override void SetValue(int idx, float value)
		{
		}

		public override void FindMissingDnaAsset(string dnaAssetName)
		{
		}

		public static DynamicUMADna LoadInstance(string data)
		{
			return null;
		}

		public static string SaveInstance(DynamicUMADnaBase instance)
		{
			return null;
		}
	}
}
