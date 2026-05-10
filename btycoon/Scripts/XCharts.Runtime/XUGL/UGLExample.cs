using UnityEngine;
using UnityEngine.UI;

namespace XUGL
{
	[ExecuteInEditMode]
	public class UGLExample : MaskableGraphic
	{
		private float m_Width = 800f;

		private float m_Height = 800f;

		private Vector3 m_Center = Vector3.zero;

		private Vector3 m_LeftTopPos = Vector3.zero;

		private Color32 m_BackgroundColor = new Color32(224, 224, 224, byte.MaxValue);

		private Color32 m_DrawColor = new Color32(byte.MaxValue, 132, 142, byte.MaxValue);

		private float[] m_BorderRadius = new float[4] { 5f, 5f, 10f, 10f };

		protected override void Awake()
		{
			base.Awake();
			RectTransform component = GetComponent<RectTransform>();
			component.sizeDelta = new Vector2(500f, 500f);
			component.anchorMin = new Vector2(0.5f, 0.5f);
			component.anchorMax = new Vector2(0.5f, 0.5f);
			component.pivot = new Vector2(0.5f, 0.5f);
			m_Center = Vector3.zero;
			m_LeftTopPos = new Vector3((0f - m_Width) / 2f, m_Height / 2f);
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			vh.Clear();
			UGL.DrawSquare(vh, m_Center, m_Width / 2f, m_BackgroundColor);
			UGL.DrawBorder(vh, m_Center, m_Width, m_Height, 40f, Color.green, Color.red, 0f, m_BorderRadius);
			UGL.DrawCricle(vh, m_LeftTopPos + new Vector3(20f, -20f), 10f, m_DrawColor);
			Vector3 startPoint = new Vector3(m_LeftTopPos.x + 50f, m_LeftTopPos.y - 20f);
			Vector3 endPoint = new Vector3(m_LeftTopPos.x + 250f, m_LeftTopPos.y - 20f);
			UGL.DrawLine(vh, startPoint, endPoint, 3f, m_DrawColor);
			startPoint = new Vector3(m_LeftTopPos.x + 20f, m_LeftTopPos.y - 100f);
			Vector3 middlePoint = new Vector3(m_LeftTopPos.x + 200f, m_LeftTopPos.y - 40f);
			endPoint = new Vector3(m_LeftTopPos.x + 250f, m_LeftTopPos.y - 80f);
			UGL.DrawLine(vh, startPoint, middlePoint, endPoint, 5f, m_DrawColor);
		}
	}
}
