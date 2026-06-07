using System;

namespace UMA
{
	[Serializable]
	public struct DnaDef
	{
		public string Name;

		public int val;

		public float Value
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public DnaDef(string name, float value)
		{
			Name = null;
			val = 0;
		}

		public DnaDef(string name, int value)
		{
			Name = null;
			val = 0;
		}
	}
}
