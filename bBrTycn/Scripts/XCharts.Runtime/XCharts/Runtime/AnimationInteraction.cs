using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[Since("v3.8.0")]
	public class AnimationInteraction : AnimationInfo
	{
		[SerializeField]
		[Since("v3.8.0")]
		private MLValue m_Width = new MLValue(1.1f);

		[SerializeField]
		[Since("v3.8.0")]
		private MLValue m_Radius = new MLValue(1.1f);

		[SerializeField]
		[Since("v3.8.0")]
		private MLValue m_Offset = new MLValue(MLValue.Type.Absolute, 5f);

		public MLValue width
		{
			get
			{
				return m_Width;
			}
			set
			{
				m_Width = value;
			}
		}

		public MLValue radius
		{
			get
			{
				return m_Radius;
			}
			set
			{
				m_Radius = value;
			}
		}

		public MLValue offset
		{
			get
			{
				return m_Offset;
			}
			set
			{
				m_Offset = value;
			}
		}

		public float GetRadius(float radius)
		{
			return m_Radius.GetValue(radius);
		}

		public float GetWidth(float width)
		{
			return m_Width.GetValue(width);
		}

		public float GetOffset(float total)
		{
			return m_Offset.GetValue(total);
		}

		public float GetOffset()
		{
			return m_Offset.value;
		}
	}
}
