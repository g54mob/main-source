using UnityEngine;

namespace Simulator.Preview3D
{
	public class Preview3DObjects : MonoBehaviour
	{
		[Header("Settings")]
		[SerializeField]
		private Vector3 m_objectsRotation;

		[Header("References")]
		[SerializeField]
		protected Preview3DLayout m_layout;

		protected IPreview3DObject[] m_objects;

		public bool Focused => FocusedObject != null;

		public IPreview3DObject FocusedObject { get; private set; }

		protected void Start()
		{
			m_objects = new IPreview3DObject[m_layout.Count];
		}

		public virtual void UpdateObjects()
		{
			for (int i = 0; i < m_objects.Length; i++)
			{
				UpdateObjectAtIndex(i);
			}
		}

		protected void UpdateObjectAtIndex(int index)
		{
			if (m_objects[index] != null)
			{
				Bounds bounds = m_layout.GetBounds(index);
				Vector3 center = bounds.center;
				center += new Vector3(m_objects[index].NormalizedAnchor.x * bounds.extents.x, m_objects[index].NormalizedAnchor.y * bounds.extents.y);
				Transform obj = m_objects[index].transform;
				obj.position = center;
				obj.localScale = Vector3.one * Mathf.Min(bounds.size.x, bounds.size.y);
				obj.rotation = Quaternion.Euler(m_objectsRotation);
			}
		}

		protected virtual void HideObjects()
		{
			IPreview3DObject[] objects = m_objects;
			foreach (IPreview3DObject preview3DObject in objects)
			{
				if (preview3DObject != null)
				{
					HideObject(preview3DObject);
				}
			}
		}

		protected void HideObject(IPreview3DObject obj)
		{
			obj.transform.localPosition = Vector3.zero;
		}

		protected virtual void ClearObjects(bool destroy)
		{
			for (int i = 0; i < m_objects.Length; i++)
			{
				if (m_objects[i] != null)
				{
					if (destroy)
					{
						Object.Destroy(m_objects[i].transform.gameObject);
					}
					else
					{
						m_objects[i].transform.localPosition = Vector3.zero;
					}
				}
				m_objects[i] = null;
			}
		}

		public bool FocusObjectAtIndex(int index)
		{
			if (m_objects.IsIndexValid(index))
			{
				FocusedObject = m_objects[index];
				return true;
			}
			LoseFocus();
			return false;
		}

		public virtual void LoseFocus()
		{
			FocusedObject = null;
		}

		public void ResetObjectsRotation()
		{
			IPreview3DObject[] objects = m_objects;
			for (int i = 0; i < objects.Length; i++)
			{
				objects[i]?.ResetRotation();
			}
		}

		public void RotateFocusedObject(Vector2 delta)
		{
			if (FocusedObject != null)
			{
				FocusedObject.Rotate(delta);
			}
		}
	}
}
