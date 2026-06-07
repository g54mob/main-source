using UnityEngine;

namespace Simulator
{
	public class UI_DynamicScaler : MonoBehaviour
	{
		[SerializeField]
		private RectTransform m_rectTransform;

		[SerializeField]
		private Vector2 m_rectSizeReference;

		public void UpdateSizeReference(Vector2 size)
		{
			m_rectSizeReference = size;
			RefreshContent();
		}

		public void RefreshContent()
		{
			if (m_rectSizeReference.x != 0f && m_rectSizeReference.y != 0f)
			{
				float num = m_rectTransform.rect.width / m_rectSizeReference.x;
				float num2 = m_rectTransform.rect.height / m_rectSizeReference.y;
				float num3 = ((num < num2) ? num : num2);
				m_rectTransform.localScale = new Vector3(num3, num3, 1f);
			}
		}

		private void OnRectTransformDimensionsChange()
		{
			RefreshContent();
		}
	}
}
