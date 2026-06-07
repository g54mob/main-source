using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy
{
	public class G_GraphShader
	{
		public const int ArrayMaxSizeFull = 512;

		public const int ArrayMaxSizeLight = 128;

		public int ArrayMaxSize;

		public float[] ShaderArrayValues;

		public Image Image;

		private string Name;

		private string Name_Length;

		public float Average;

		private int m_averagePropertyId;

		public float GoodThreshold;

		public float CautionThreshold;

		private int m_goodThresholdPropertyId;

		private int m_cautionThresholdPropertyId;

		public Color GoodColor;

		public Color CautionColor;

		public Color CriticalColor;

		private int m_goodColorPropertyId;

		private int m_cautionColorPropertyId;

		private int m_criticalColorPropertyId;

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
