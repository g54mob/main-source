using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[Since("v3.2.0")]
	public class EmphasisStyle : StateStyle, ISerieComponent, ISerieDataComponent
	{
		public enum FocusType
		{
			None = 0,
			Self = 1,
			Series = 2
		}

		public enum BlurScope
		{
			GridCoord = 0,
			Series = 1,
			Global = 2
		}

		[SerializeField]
		private float m_Scale = 1.1f;

		[SerializeField]
		private FocusType m_Focus;

		[SerializeField]
		private BlurScope m_BlurScope;

		public float scale
		{
			get
			{
				return m_Scale;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Scale, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public FocusType focus
		{
			get
			{
				return m_Focus;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Focus, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public BlurScope blurScope
		{
			get
			{
				return m_BlurScope;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_BlurScope, value))
				{
					SetVerticesDirty();
				}
			}
		}
	}
}
