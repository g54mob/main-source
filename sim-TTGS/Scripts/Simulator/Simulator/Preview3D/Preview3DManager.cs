using UnityEngine;

namespace Simulator.Preview3D
{
	public class Preview3DManager : MonoBehaviour
	{
		protected static Preview3DManager _instance;

		[SerializeField]
		protected Preview3DCamera m_camera;

		[SerializeField]
		protected Preview3DLayout m_layout;

		[SerializeField]
		protected Preview3DObjects m_objects;

		public static Preview3DManager Instance => _instance;

		public static bool Loaded { get; private set; }

		public bool Focused => m_objects.Focused;

		protected virtual void Awake()
		{
			if (_instance != null)
			{
				Object.Destroy(base.gameObject);
				return;
			}
			_instance = this;
			Loaded = true;
		}

		protected void OnDestroy()
		{
			if (!(_instance != this))
			{
				Loaded = false;
			}
		}

		protected virtual void OnEnable()
		{
			DisableCamera();
		}

		protected virtual void OnDisable()
		{
		}

		public void DisableCamera()
		{
			m_camera.SetActive(active: false);
		}

		public void FocusOnIndex(int index)
		{
			m_camera.SetActive(active: true);
			if (m_objects.FocusObjectAtIndex(index))
			{
				m_camera.FocusOnObject(index);
			}
			else
			{
				m_camera.ShowAllObjects();
			}
		}

		public void Unfocus()
		{
			m_camera.SetActive(active: true);
			m_camera.ShowAllObjects();
			m_objects.LoseFocus();
		}

		public IPreview3DObject GetFocusedObject()
		{
			return m_objects.FocusedObject;
		}

		public Rect GetImageRectAtIndex(int index)
		{
			return m_layout.GetRect(index);
		}
	}
}
