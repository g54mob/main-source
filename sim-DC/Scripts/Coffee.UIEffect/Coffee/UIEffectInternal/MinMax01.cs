using System;
using UnityEngine;

namespace Coffee.UIEffectInternal
{
	[Serializable]
	public struct MinMax01
	{
		[SerializeField]
		private float m_Min;

		[SerializeField]
		private float m_Max;

		public float min
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float max
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float average => 0f;

		public MinMax01(float min, float max)
		{
			m_Min = 0f;
			m_Max = 0f;
		}

		public bool Approximately(MinMax01 other)
		{
			return false;
		}
	}
}
