using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AppsTools
{
	[AddComponentMenu("UI/AppsTools/Gradient Color")]
	[RequireComponent(typeof(Graphic))]
	public class GradientColor : BaseMeshEffect
	{
		private const int ONE_TEXT_VERTEX = 6;

		[SerializeField]
		private Color m_colorTop = Color.white;

		[SerializeField]
		private Color m_colorBottom = Color.white;

		[SerializeField]
		private Color m_colorLeft = Color.white;

		[SerializeField]
		private Color m_colorRight = Color.white;

		[SerializeField]
		[Range(-1f, 1f)]
		private float m_gradientOffsetVertical;

		[SerializeField]
		[Range(-1f, 1f)]
		private float m_gradientOffsetHorizontal;

		[SerializeField]
		private bool m_splitTextGradient;

		public Color colorTop
		{
			get
			{
				return m_colorTop;
			}
			set
			{
				if (m_colorTop != value)
				{
					m_colorTop = value;
					Refresh();
				}
			}
		}

		public Color colorBottom
		{
			get
			{
				return m_colorBottom;
			}
			set
			{
				if (m_colorBottom != value)
				{
					m_colorBottom = value;
					Refresh();
				}
			}
		}

		public Color colorLeft
		{
			get
			{
				return m_colorLeft;
			}
			set
			{
				if (m_colorLeft != value)
				{
					m_colorLeft = value;
					Refresh();
				}
			}
		}

		public Color colorRight
		{
			get
			{
				return m_colorRight;
			}
			set
			{
				if (m_colorRight != value)
				{
					m_colorRight = value;
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
				Color color = value.color;
				Color color2 = Color.Lerp(m_colorBottom, m_colorTop, ((num6 > 0f) ? ((value.position.y - num2) / num6) : 0f) + m_gradientOffsetVertical);
				Color color3 = Color.Lerp(m_colorLeft, m_colorRight, ((num5 > 0f) ? ((value.position.x - num) / num5) : 0f) + m_gradientOffsetHorizontal);
				value.color = color * color2 * color3;
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
