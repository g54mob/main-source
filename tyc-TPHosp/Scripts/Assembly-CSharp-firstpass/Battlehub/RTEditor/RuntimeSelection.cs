using System.Linq;
using UnityEngine;

namespace Battlehub.RTEditor
{
	public static class RuntimeSelection
	{
		private static Object m_activeObject;

		private static Object[] m_objects;

		public static GameObject activeGameObject
		{
			get
			{
				return activeObject as GameObject;
			}
			set
			{
				activeObject = value;
			}
		}

		public static Object activeObject
		{
			get
			{
				return m_activeObject;
			}
			set
			{
				if (m_activeObject != value)
				{
					m_activeObject = value;
					Object[] unselectedObjects = m_objects;
					if (m_activeObject != null)
					{
						m_objects = new Object[1] { value };
					}
					else
					{
						m_objects = new Object[0];
					}
					if (RuntimeSelection.SelectionChanged != null)
					{
						RuntimeSelection.SelectionChanged(unselectedObjects);
					}
				}
			}
		}

		public static Object[] objects
		{
			get
			{
				return m_objects;
			}
			set
			{
				Object[] array = m_objects;
				if (value == null)
				{
					m_objects = null;
					m_activeObject = null;
				}
				else
				{
					m_objects = value.ToArray();
					if (m_activeObject == null || !m_objects.Contains(m_activeObject))
					{
						m_activeObject = m_objects.OfType<GameObject>().FirstOrDefault();
					}
				}
				if (array == m_objects || RuntimeSelection.SelectionChanged == null)
				{
					return;
				}
				if (array == null || m_objects == null)
				{
					RuntimeSelection.SelectionChanged(array);
					return;
				}
				if (array.Length != m_objects.Length)
				{
					RuntimeSelection.SelectionChanged(array);
					return;
				}
				for (int i = 0; i < m_objects.Length; i++)
				{
					if (m_objects[i] != array[i])
					{
						RuntimeSelection.SelectionChanged(array);
						break;
					}
				}
			}
		}

		public static GameObject[] gameObjects
		{
			get
			{
				if (m_objects == null)
				{
					return null;
				}
				return m_objects.OfType<GameObject>().ToArray();
			}
		}

		public static Transform activeTransform
		{
			get
			{
				if (m_activeObject == null)
				{
					return null;
				}
				if (m_activeObject is GameObject)
				{
					return ((GameObject)m_activeObject).transform;
				}
				return null;
			}
			set
			{
				if ((bool)value)
				{
					m_activeObject = value.gameObject;
				}
				else
				{
					m_activeObject = null;
				}
			}
		}

		public static event RuntimeSelectionChanged SelectionChanged;

		public static void Select(Object activeGameObject, Object[] selection)
		{
			m_activeObject = activeGameObject;
			objects = selection;
		}
	}
}
