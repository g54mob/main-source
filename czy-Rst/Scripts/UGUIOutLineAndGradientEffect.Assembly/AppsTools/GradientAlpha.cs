using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AppsTools
{
	[AddComponentMenu("UI/AppsTools/Gradient Alpha")]
	[RequireComponent(typeof(Graphic))]
	public class GradientAlpha : BaseMeshEffect
	{
		private const int ONE_TEXT_VERTEX = 6;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_alphaTop = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_alphaBottom = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_alphaLeft = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_alphaRight = 1f;

		[SerializeField]
		[Range(-1f, 1f)]
		private float m_gradientOffsetVertical;

		[SerializeField]
		[Range(-1f, 1f)]
		private float m_gradientOffsetHorizontal;

		[SerializeField]
		private bool m_splitTextGradient;

		public float alphaTop
		{
			get
			{
				return m_alphaTop;
			}
			set
			{
				if (m_alphaTop != value)
				{
					m_alphaTop = Mathf.Clamp01(value);
					Refresh();
				}
			}
		}

		public float alphaBottom
		{
			get
			{
				return m_alphaBottom;
			}
			set
			{
				if (m_alphaBottom != value)
				{
					m_alphaBottom = Mathf.Clamp01(value);
					Refresh();
				}
			}
		}

		public float alphaLeft
		{
			get
			{
				return m_alphaLeft;
			}
			set
			{
				if (m_alphaLeft != value)
				{
					m_alphaLeft = Mathf.Clamp01(value);
					Refresh();
				}
			}
		}

		public float alphaRight
		{
			get
			{
				return m_alphaRight;
			}
			set
			{
				if (m_alphaRight != value)
				{
					m_alphaRight = Mathf.Clamp01(value);
					Refresh();
				}
			}
		}

		public float gradientOffsetVertical
		{
			get
			{
				return m_gradientOffsetVertical;
			}
			set
			{
				if (m_gradientOffsetVertical != value)
				{
					m_gradientOffsetVertical = Mathf.Clamp(value, -1f, 1f);
					Refresh();
				}
			}
		}

		public float gradientOffsetHorizontal
		{
			get
			{
				return m_gradientOffsetHorizontal;
			}
			set
			{
				if (m_gradientOffsetHorizontal != value)
				{
					m_gradientOffsetHorizontal = Mathf.Clamp(value, -1f, 1f);
					Refresh();
				}
			}
		}

		public bool splitTextGradient
		{
			get
			{
				return m_splitTextGradient;
			}
			set
			{
				if (m_splitTextGradient != value)
				{
					m_splitTextGradient = value;
					Refresh();
				}
			}
		}

		public override void ModifyMesh(VertexHelper vh)
		{
			if (IsActive())
			{
				List<UIVertex> list = ListPoolEffect<UIVertex>.Get();
				vh.GetUIVertexStream(list);
				ModifyVertices(list);
				vh.Clear();
				vh.AddUIVertexTriangleStream(list);
				ListPoolEffect<UIVertex>.Release(list);
			}
		}

		private void ModifyVertices(List<UIVertex> vList)
		{
			if (!IsActive() || vList == null || vList.Count == 0)
			{
				return;
			}
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			for (int i = 0; i < vList.Count; i++)
			{
				if (i == 0 || (m_splitTextGradient && i % 6 == 0))
				{
					num = vList[i].position.x;
					num2 = vList[i].position.y;
					num3 = vList[i].position.x;
					num4 = vList[i].position.y;
					int num7 = (m_splitTextGradient ? (i + 6) : vList.Count);
					for (int j = i; j < num7 && j < vList.Count; j++)
					{
						UIVertex uIVertex = vList[j];
						num = Mathf.Min(num, uIVertex.position.x);
						num2 = Mathf.Min(num2, uIVertex.position.y);
						num3 = Mathf.Max(num3, uIVertex.position.x);
						num4 = Mathf.Max(num4, uIVertex.position.y);
					}
					num5 = num3 - num;
					num6 = num4 - num2;
				}
				UIVertex value = vList[i];
				float num8 = (float)(int)value.color.a / 255f;
				float num9 = Mathf.Lerp(m_alphaBottom, m_alphaTop, ((num6 > 0f) ? ((value.position.y - num2) / num6) : 0f) + m_gradientOffsetVertical);
				float num10 = Mathf.Lerp(m_alphaLeft, m_alphaRight, ((num5 > 0f) ? ((value.position.x - num) / num5) : 0f) + m_gradientOffsetHorizontal);
				value.color.a = (byte)(Mathf.Clamp01(num8 * num9 * num10) * 255f);
				vList[i] = value;
			}
		}

		private void Refresh()
		{
			if (base.graphic != null)
			{
				base.graphic.SetVerticesDirty();
			}
		}
	}
}
