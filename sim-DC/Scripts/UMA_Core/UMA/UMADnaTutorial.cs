using System;

namespace UMA
{
	[Serializable]
	public class UMADnaTutorial : UMADna
	{
		public float eyeSpacing;

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

		public override float GetValue(int idx)
		{
			return 0f;
		}

		public override void SetValue(int idx, float value)
		{
		}

		public static string[] GetNames()
		{
			return null;
		}

		public static UMADnaTutorial LoadInstance(string data)
		{
			return null;
		}

		public static string SaveInstance(UMADnaTutorial instance)
		{
			return null;
		}
	}
}
