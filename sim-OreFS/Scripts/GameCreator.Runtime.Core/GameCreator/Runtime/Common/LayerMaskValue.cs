using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class LayerMaskValue
	{
		[SerializeField]
		private int m_Value;

		public int Value => m_Value;

		public override string ToString()
		{
			if (m_Value < 0 || m_Value > 31)
			{
				return "(unknown)";
			}
			string text = LayerMask.LayerToName(m_Value);
			if (string.IsNullOrEmpty(text))
			{
				return "(unnamed)";
			}
			return text;
		}

		public static string GetLayerMaskName(LayerMask mask)
		{
			int value = mask.value;
			switch (value)
			{
			case 0:
				return "Nothing";
			case -1:
				return "Everything";
			default:
			{
				for (int i = 0; i < 32; i++)
				{
					int num = 1 << i;
					if ((num & value) != 0)
					{
						string result = LayerMask.LayerToName(i);
						if ((~num & value) != 0)
						{
							return "(mixed)";
						}
						return result;
					}
				}
				return "(unknown)";
			}
			}
		}
	}
}
