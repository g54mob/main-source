using UnityEngine;

namespace Simulator.Preview3D
{
	public class Preview3DCamera : MonoBehaviour, IActivable
	{
		[SerializeField]
		private Camera m_camera;

		[SerializeField]
		private Preview3DLayout m_layout;

		public void ShowAllObjects()
		{
			m_camera.orthographicSize = 1f;
			base.transform.position = new Vector3(1f, 1f, -5f);
		}

		public void FocusOnObject(int index)
		{
			m_camera.orthographicSize = 0.25f;
			Vector2Int coords = m_layout.GetCoords(index);
			base.transform.position = new Vector3(0.25f + (float)coords.x * (m_layout.Size.x + m_layout.Spacing.x), 0.25f + (float)coords.y * (m_layout.Size.y + m_layout.Spacing.y), -5f);
		}

		public void SetActive(bool active)
		{
			m_camera.enabled = active;
		}
	}
}
