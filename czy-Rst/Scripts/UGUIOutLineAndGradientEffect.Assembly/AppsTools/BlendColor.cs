using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AppsTools
{
	[AddComponentMenu("UI/AppsTools/Blend Color")]
	[RequireComponent(typeof(Graphic))]
	public class BlendColor : BaseMeshEffect
	{
		public enum BlendMode
		{
			Multiply = 0,
			Additive = 1,
			Subtractive = 2,
			Override = 3
		}

		[SerializeField]
		private BlendMode m_blendMode;

		[SerializeField]
		private Color m_color = Color.white;

		public BlendMode blendMode
		{
			get
			{
				return m_blendMode;
			}
			set
			{
				if (m_blendMode != value)
				{
					m_blendMode = value;
					Refresh();
				}
			}
		}

		public Color color
		{
			get
			{
				return m_color;
			}
			set
			{
				if (m_color != value)
				{
					m_color = value;
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
			for (int i = 0; i < vList.Count; i++)
			{
				UIVertex value = vList[i];
				byte a = value.color.a;
				switch (m_blendMode)
				{
				case BlendMode.Multiply:
				{
					ref Color32 reference3 = ref value.color;
					reference3 *= m_color;
					break;
				}
				case BlendMode.Additive:
				{
					ref Color32 reference2 = ref value.color;
					reference2 += m_color;
					break;
				}
				case BlendMode.Subtractive:
				{
					ref Color32 reference = ref value.color;
					reference -= m_color;
					break;
				}
				case BlendMode.Override:
					value.color = m_color;
					break;
				}
				value.color.a = a;
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
