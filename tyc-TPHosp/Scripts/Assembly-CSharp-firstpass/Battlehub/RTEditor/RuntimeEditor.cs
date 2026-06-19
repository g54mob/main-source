using System.Collections.Generic;
using System.Linq;
using Battlehub.RTHandles;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Battlehub.RTEditor
{
	public class RuntimeEditor : MonoBehaviour
	{
		public UnityEvent Opened;

		public UnityEvent Closed;

		public GameObject[] Prefabs;

		public GameObject Grid;

		public GameObject SceneGizmo;

		public GameObject EditButton;

		public GameObject CloseButton;

		public GameObject EditorRoot;

		public Camera SceneCamera;

		public RuntimeSceneView SceneView;

		public KeyCode MultiselectKey = KeyCode.LeftControl;

		public KeyCode RangeSelectKey = KeyCode.LeftShift;

		public KeyCode DuplicateKey = KeyCode.D;

		public KeyCode DuplicateKey2 = KeyCode.LeftShift;

		private LayerMask m_raycastLayerMask = int.MinValue;

		private int m_raycastLayer = 31;

		private bool m_isOn;

		private static RuntimeEditor m_instance;

		public int RaycastLayer
		{
			get
			{
				return m_raycastLayer;
			}
			set
			{
				m_raycastLayer = value;
				m_raycastLayerMask = 1 << value;
			}
		}

		public bool IsOn
		{
			get
			{
				return m_isOn;
			}
			set
			{
				if (m_isOn != value)
				{
					m_isOn = value;
					if (m_isOn)
					{
						ShowEditor();
					}
					else
					{
						CloseEditor();
					}
				}
			}
		}

		public static RuntimeEditor Instance => m_instance;

		private void Awake()
		{
			ExposeToEditor.Started += OnObjectStarted;
			if (m_instance != null)
			{
				Debug.LogWarning("Another instance of RuntimeEditor exists");
			}
			m_instance = this;
			if (SceneCamera == null)
			{
				SceneCamera = Camera.main;
			}
			SceneView.Camera = SceneCamera;
		}

		private void Start()
		{
			ShowEditor();
			CloseEditor();
			ExposeToEditor.Awaked += OnObjectAwaked;
			ExposeToEditor.Enabled += OnObjectEnabled;
			ExposeToEditor.Disabled += OnObjectDisabled;
			ExposeToEditor.Destroyed += OnObjectDestroyed;
			if (m_isOn)
			{
				ShowEditor();
			}
			else
			{
				CloseEditor();
			}
		}

		private void LateUpdate()
		{
			if (Input.GetKeyDown(DuplicateKey) && Input.GetKey(DuplicateKey2))
			{
				Object[] objects = RuntimeSelection.objects;
				if (objects != null && objects.Length != 0)
				{
					Object[] array = new Object[objects.Length];
					for (int i = 0; i < array.Length; i++)
					{
						GameObject gameObject = objects[i] as GameObject;
						Object obj = Object.Instantiate(objects[i]);
						GameObject gameObject2 = obj as GameObject;
						if (gameObject != null && gameObject2 != null && gameObject.transform.parent != null)
						{
							gameObject2.transform.SetParent(gameObject.transform.parent, worldPositionStays: true);
						}
						array[i] = obj;
					}
					RuntimeSelection.objects = array;
				}
			}
			if (!Input.GetMouseButtonDown(0) || (PositionHandle.Current != null && PositionHandle.Current.IsDragging) || (ScaleHandle.Current != null && ScaleHandle.Current.IsDragging) || (RotationHandle.Current != null && RotationHandle.Current.IsDragging) || (!SceneView.IsPointerOver && EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) || RuntimeTools.IsLocked || RuntimeTools.IsSceneGizmoSelected)
			{
				return;
			}
			bool key = Input.GetKey(RangeSelectKey);
			bool flag = Input.GetKey(MultiselectKey) || key;
			if (Physics.Raycast(SceneCamera.ScreenPointToRay(Input.mousePosition), out var hitInfo, float.MaxValue, m_raycastLayerMask.value))
			{
				ExposeToEditor component = hitInfo.collider.gameObject.GetComponent<ExposeToEditor>();
				if (component != null)
				{
					if (flag)
					{
						List<Object> list = ((RuntimeSelection.objects == null) ? new List<Object>() : RuntimeSelection.objects.ToList());
						if (list.Contains(component.gameObject))
						{
							list.Remove(component.gameObject);
							if (key)
							{
								list.Insert(0, component.gameObject);
							}
						}
						else
						{
							list.Insert(0, component.gameObject);
						}
						RuntimeSelection.Select(component.gameObject, list.ToArray());
					}
					else
					{
						RuntimeSelection.activeObject = component.gameObject;
					}
				}
				else if (!flag)
				{
					RuntimeSelection.activeObject = null;
				}
			}
			else if (!flag)
			{
				RuntimeSelection.activeObject = null;
			}
		}

		private void Destroy()
		{
			ExposeToEditor.Awaked -= OnObjectAwaked;
			ExposeToEditor.Started -= OnObjectStarted;
			ExposeToEditor.Enabled -= OnObjectEnabled;
			ExposeToEditor.Disabled -= OnObjectDisabled;
			ExposeToEditor.Destroyed -= OnObjectDestroyed;
		}

		private void OnApplicationQuit()
		{
			ExposeToEditor.Awaked -= OnObjectAwaked;
			ExposeToEditor.Started -= OnObjectStarted;
			ExposeToEditor.Enabled -= OnObjectEnabled;
			ExposeToEditor.Disabled -= OnObjectDisabled;
			ExposeToEditor.Destroyed -= OnObjectDestroyed;
		}

		private void OnObjectAwaked(ExposeToEditor obj)
		{
		}

		private void OnObjectStarted(ExposeToEditor obj)
		{
			obj.gameObject.layer = m_raycastLayer;
		}

		private void OnObjectEnabled(ExposeToEditor obj)
		{
			obj.gameObject.layer = m_raycastLayer;
		}

		private void OnObjectDisabled(ExposeToEditor obj)
		{
		}

		private void OnObjectDestroyed(ExposeToEditor obj)
		{
		}

		private void ShowEditor()
		{
			if (SceneGizmo != null)
			{
				SceneGizmo.SetActive(value: true);
			}
			if (Grid != null)
			{
				Grid.SetActive(value: true);
			}
			EditButton.SetActive(value: false);
			EditorRoot.SetActive(value: true);
			Opened.Invoke();
		}

		private void CloseEditor()
		{
			if (SceneGizmo != null)
			{
				SceneGizmo.SetActive(value: false);
			}
			if (Grid != null)
			{
				Grid.SetActive(value: false);
			}
			EditButton.SetActive(value: true);
			EditorRoot.SetActive(value: false);
			Closed.Invoke();
		}
	}
}
