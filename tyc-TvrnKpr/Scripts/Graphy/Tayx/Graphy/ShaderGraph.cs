using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy
{
	public class ShaderGraph
	{
		public const int ArrayMaxSizeFull = 512;

		public const int ArrayMaxSizeLight = 128;

		public int ArrayMaxSize;

		public Image Image;

		private string Name;

		private string Name_Length;

		public float[] Array;

		public float Average;

		private int averagePropertyId;

		public float GoodThreshold;

		public float CautionThreshold;

		private int goodThresholdPropertyId;

		private int cautionThresholdPropertyId;

		public Color GoodColor;

		public Color CautionColor;

		public Color CriticalColor;

		private int goodColorPropertyId;

		private int cautionColorPropertyId;

		private int criticalColorPropertyId;

		public void InitializeShader()
		{
		}

		public void UpdateArray()
		{
		}

		public void UpdateAverage()
		{
		}

		public void UpdateThresholds()
		{
		}

		public void UpdateColors()
		{
		}

		public void UpdatePoints()
		{
		}
	}
}
