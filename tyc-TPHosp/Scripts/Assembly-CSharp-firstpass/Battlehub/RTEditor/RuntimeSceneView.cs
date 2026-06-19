using System;
using System.Linq;
using Battlehub.RTHandles;
using Battlehub.UIControls;
using Battlehub.Utils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Battlehub.RTEditor
{
	public class RuntimeSceneView : MonoBehaviour, IDropHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
	{
		private bool m_isPointerOverSceneView;

		public Texture2D ViewTexture;

		public Texture2D MoveTexture;

		public Camera Camera;

		public Transform Pivot;

		private bool m_pan;

		private bool m_rotate;

		private bool m_handleInput;

		private bool m_lockInput;

		private Vector3 m_lastMousePosition;

		private MouseOrbit m_mouseOrbit;

		public float RotationSensitivity = 1f;

		public float ZoomSensitivity = 8f;

		public float PanSensitivity = 100f;

		private PositionHandle m_positionHandle;

		private RotationHandle m_rotationHandle;

		private ScaleHandle m_scaleHandle;

		public bool IsPointerOver => m_isPointerOverSceneView;

		private void Awake()
		{
			if (Camera == null)
			{
				Camera = Camera.main;
			}
			if (Run.Instance == null)
			{
				GameObject obj = new GameObject();
				obj.name = "Run";
				obj.AddComponent<Run>();
			}
			RuntimeTools.Current = RuntimeTool.View;
			GameObject gameObject = new GameObject();
			gameObject.name = "PositionHandle";
			gameObject.transform.SetParent(base.transform, worldPositionStays: false);
			m_positionHandle = gameObject.AddComponent<PositionHandle>();
			gameObject.SetActive(value: false);
			GameObject gameObject2 = new GameObject();
			gameObject2.name = "RotationHandle";
			gameObject2.transform.SetParent(base.transform, worldPositionStays: false);
			m_rotationHandle = gameObject2.AddComponent<RotationHandle>();
			gameObject2.SetActive(value: false);
			GameObject gameObject3 = new GameObject();
			gameObject3.name = "ScaleHandle";
			gameObject3.transform.SetParent(base.transform, worldPositionStays: false);
			m_scaleHandle = gameObject3.AddComponent<ScaleHandle>();
			gameObject3.SetActive(value: false);
			RuntimeSelection.SelectionChanged += OnRuntimeSelectionChanged;
			RuntimeTools.ToolChanged += OnRuntimeToolChanged;
			UnityEditorToolsListener.ToolChanged += OnUnityEditorToolChanged;
			RuntimeTools.Current = RuntimeTool.Move;
			Camera.fieldOfView = 60f;
			OnProjectionChanged();
		}

		private void OnDestroy()
		{
			RuntimeTools.Current = RuntimeTool.None;
			RuntimeSelection.SelectionChanged -= OnRuntimeSelectionChanged;
			RuntimeTools.ToolChanged -= OnRuntimeToolChanged;
			UnityEditorToolsListener.ToolChanged -= OnUnityEditorToolChanged;
		}

		private void Start()
		{
			m_mouseOrbit = Camera.gameObject.GetComponent<MouseOrbit>();
			if (m_mouseOrbit == null)
			{
				m_mouseOrbit = Camera.gameObject.AddComponent<MouseOrbit>();
			}
			UnlockInput();
			m_mouseOrbit.enabled = false;
		}

		private void Update()
		{
			HandleInput();
		}

		public void LockInput()
		{
			m_lockInput = true;
		}

		public void UnlockInput()
		{
			m_lockInput = false;
			if (m_mouseOrbit != null)
			{
				Pivot.position = Camera.transform.position + Camera.transform.forward * m_mouseOrbit.Distance;
				m_mouseOrbit.Target = Pivot;
				m_mouseOrbit.SyncAngles();
			}
		}

		public void OnProjectionChanged()
		{
			float num = Camera.fieldOfView * ((float)Math.PI / 180f);
			float orthographicSize = (Camera.transform.position - Pivot.position).magnitude * Mathf.Sin(num / 2f);
			Camera.orthographicSize = orthographicSize;
		}

		private void OnRuntimeToolChanged()
		{
			SetCursor();
			if (RuntimeSelection.activeTransform == null)
			{
				return;
			}
			if (m_positionHandle != null)
			{
				m_positionHandle.gameObject.SetActive(value: false);
				if (RuntimeTools.Current == RuntimeTool.Move)
				{
					m_positionHandle.transform.position = RuntimeSelection.activeTransform.position;
					m_positionHandle.Targets = (from g in RuntimeSelection.gameObjects
						where g.GetComponent<ExposeToEditor>()
						select g.transform into g
						orderby RuntimeSelection.activeTransform == g descending
						select g).ToArray();
					m_positionHandle.gameObject.SetActive(m_positionHandle.Targets.Length != 0);
				}
			}
			if (m_rotationHandle != null)
			{
				m_rotationHandle.gameObject.SetActive(value: false);
				if (RuntimeTools.Current == RuntimeTool.Rotate)
				{
					m_rotationHandle.transform.position = RuntimeSelection.activeTransform.position;
					m_rotationHandle.Targets = (from g in RuntimeSelection.gameObjects
						where g.GetComponent<ExposeToEditor>()
						select g.transform into g
						orderby RuntimeSelection.activeTransform == g descending
						select g).ToArray();
					m_rotationHandle.gameObject.SetActive(m_rotationHandle.Targets.Length != 0);
				}
			}
			if (!(m_scaleHandle != null))
			{
				return;
			}
			m_scaleHandle.gameObject.SetActive(value: false);
			if (RuntimeTools.Current == RuntimeTool.Scale)
			{
				m_scaleHandle.transform.position = RuntimeSelection.activeTransform.position;
				m_scaleHandle.Targets = (from g in RuntimeSelection.gameObjects
					where g.GetComponent<ExposeToEditor>()
					select g.transform into g
					orderby RuntimeSelection.activeTransform == g descending
					select g).ToArray();
				m_scaleHandle.gameObject.SetActive(m_scaleHandle.Targets.Length != 0);
			}
		}

		private void OnUnityEditorToolChanged()
		{
		}

		private void OnRuntimeSelectionChanged(UnityEngine.Object[] unselected)
		{
			if (RuntimeSelection.activeGameObject == null || RuntimePrefabs.IsPrefab(RuntimeSelection.activeGameObject.transform))
			{
				if (m_positionHandle != null)
				{
					m_positionHandle.gameObject.SetActive(value: false);
				}
				if (m_rotationHandle != null)
				{
					m_rotationHandle.gameObject.SetActive(value: false);
				}
				if (m_scaleHandle != null)
				{
					m_scaleHandle.gameObject.SetActive(value: false);
				}
			}
			else
			{
				OnRuntimeToolChanged();
			}
		}

		private void HandleInput()
		{
			if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2))
			{
				m_handleInput = false;
				m_mouseOrbit.enabled = false;
				m_rotate = false;
				SetCursor();
			}
			else
			{
				if (m_lockInput)
				{
					return;
				}
				if (Input.GetKeyDown(KeyCode.F))
				{
					Focus();
				}
				bool flag = Input.GetMouseButton(2) || Input.GetMouseButton(1) || (Input.GetMouseButton(0) && RuntimeTools.Current == RuntimeTool.View);
				bool flag2 = Input.GetKey(KeyCode.AltGr) || Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
				if (flag != m_pan)
				{
					m_pan = flag;
					if (m_pan && RuntimeTools.Current != RuntimeTool.View)
					{
						m_rotate = false;
					}
					SetCursor();
				}
				else if (flag2 != m_rotate)
				{
					m_rotate = flag2;
					SetCursor();
				}
				bool flag3 = (RuntimeTools.IsLocked = m_rotate || flag);
				if (!flag3)
				{
					if (Input.GetKeyDown(KeyCode.Q))
					{
						RuntimeTools.Current = RuntimeTool.View;
					}
					else if (Input.GetKeyDown(KeyCode.W))
					{
						RuntimeTools.Current = RuntimeTool.Move;
					}
					else if (Input.GetKeyDown(KeyCode.E))
					{
						RuntimeTools.Current = RuntimeTool.Rotate;
					}
					else if (Input.GetKeyDown(KeyCode.R))
					{
						RuntimeTools.Current = RuntimeTool.Scale;
					}
				}
				if (!m_isPointerOverSceneView)
				{
					return;
				}
				if (Input.GetKeyDown(KeyCode.X))
				{
					if (RuntimeTools.PivotRotation == RuntimePivotRotation.Local)
					{
						RuntimeTools.PivotRotation = RuntimePivotRotation.Global;
					}
					else
					{
						RuntimeTools.PivotRotation = RuntimePivotRotation.Local;
					}
				}
				if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
				{
					m_handleInput = !m_positionHandle.IsDragging;
					m_lastMousePosition = Input.mousePosition;
					if (m_rotate)
					{
						m_mouseOrbit.enabled = true;
					}
				}
				if (Input.GetAxis("Mouse ScrollWheel") != 0f && (!EventSystem.current || !EventSystem.current.IsPointerOverGameObject() || m_isPointerOverSceneView))
				{
					m_mouseOrbit.Zoom();
				}
				if (m_handleInput && flag3 && m_pan && (!m_rotate || RuntimeTools.Current != RuntimeTool.View))
				{
					Pan();
				}
			}
		}

		private void Focus()
		{
			if (RuntimeSelection.activeTransform == null)
			{
				return;
			}
			Bounds bounds = CalculateBounds(RuntimeSelection.activeTransform);
			float num = Camera.fieldOfView * ((float)Math.PI / 180f);
			float num2 = Mathf.Max(bounds.extents.y, bounds.extents.x, bounds.extents.z) * 2f;
			float num3 = Mathf.Abs(num2 / Mathf.Sin(num / 2f));
			Pivot.position = bounds.center;
			Run.Instance.Animation(new Vector3AnimationInfo(Camera.transform.position, Pivot.position - num3 * Camera.transform.forward, 0.5f, AnimationInfo<object, Vector3>.EaseOutCubic, delegate(object target, Vector3 value, float t, bool completed)
			{
				if ((bool)Camera)
				{
					Camera.transform.position = value;
				}
			}));
			Run.Instance.Animation(new FloatAnimationInfo(m_mouseOrbit.Distance, num3, 0.5f, AnimationInfo<object, Vector3>.EaseOutCubic, delegate(object target, float value, float t, bool completed)
			{
				if ((bool)m_mouseOrbit)
				{
					m_mouseOrbit.Distance = value;
				}
			}));
			Run.Instance.Animation(new FloatAnimationInfo(Camera.orthographicSize, num2, 0.5f, AnimationInfo<object, Vector3>.EaseOutCubic, delegate(object target, float value, float t, bool completed)
			{
				if ((bool)Camera)
				{
					Camera.orthographicSize = value;
				}
			}));
		}

		private Bounds CalculateBounds(Transform t)
		{
			Renderer componentInChildren = t.GetComponentInChildren<Renderer>();
			if ((bool)componentInChildren)
			{
				Bounds totalBounds = componentInChildren.bounds;
				if (totalBounds.size == Vector3.zero && totalBounds.center != componentInChildren.transform.position)
				{
					totalBounds = TransformBounds(componentInChildren.transform.localToWorldMatrix, totalBounds);
				}
				CalculateBounds(t, ref totalBounds);
				if (totalBounds.extents == Vector3.zero)
				{
					totalBounds.extents = new Vector3(0.5f, 0.5f, 0.5f);
				}
				return totalBounds;
			}
			return new Bounds(t.position, new Vector3(0.5f, 0.5f, 0.5f));
		}

		private void CalculateBounds(Transform t, ref Bounds totalBounds)
		{
			foreach (Transform item in t)
			{
				Renderer component = item.GetComponent<Renderer>();
				if ((bool)component)
				{
					Bounds bounds = component.bounds;
					if (bounds.size == Vector3.zero && bounds.center != component.transform.position)
					{
						bounds = TransformBounds(component.transform.localToWorldMatrix, bounds);
					}
					totalBounds.Encapsulate(bounds.min);
					totalBounds.Encapsulate(bounds.max);
				}
				CalculateBounds(item, ref totalBounds);
			}
		}

		public static Bounds TransformBounds(Matrix4x4 matrix, Bounds bounds)
		{
			Vector3 center = matrix.MultiplyPoint(bounds.center);
			Vector3 extents = bounds.extents;
			Vector3 vector = matrix.MultiplyVector(new Vector3(extents.x, 0f, 0f));
			Vector3 vector2 = matrix.MultiplyVector(new Vector3(0f, extents.y, 0f));
			Vector3 vector3 = matrix.MultiplyVector(new Vector3(0f, 0f, extents.z));
			extents.x = Mathf.Abs(vector.x) + Mathf.Abs(vector2.x) + Mathf.Abs(vector3.x);
			extents.y = Mathf.Abs(vector.y) + Mathf.Abs(vector2.y) + Mathf.Abs(vector3.y);
			extents.z = Mathf.Abs(vector.z) + Mathf.Abs(vector2.z) + Mathf.Abs(vector3.z);
			return new Bounds
			{
				center = center,
				extents = extents
			};
		}

		private void Pan()
		{
			Vector3 vector = m_lastMousePosition - Input.mousePosition;
			vector /= Mathf.Sqrt(Camera.pixelHeight * Camera.pixelHeight + Camera.pixelWidth * Camera.pixelWidth);
			vector *= PanSensitivity;
			vector = Camera.cameraToWorldMatrix.MultiplyVector(vector);
			Camera.transform.position += vector;
			Pivot.position += vector;
			m_lastMousePosition = Input.mousePosition;
		}

		void IDropHandler.OnDrop(PointerEventData eventData)
		{
			GameObject pointerDrag = eventData.pointerDrag;
			if (!(pointerDrag != null))
			{
				return;
			}
			ItemContainer component = pointerDrag.GetComponent<ItemContainer>();
			if (!(component != null) || component.Item == null)
			{
				return;
			}
			object item = component.Item;
			if (item == null || !(item is GameObject))
			{
				return;
			}
			GameObject gameObject = item as GameObject;
			if (RuntimePrefabs.IsPrefab(gameObject.transform))
			{
				Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
				float distance = 15f;
				Vector3 point = ray.GetPoint(distance);
				GameObject obj = UnityEngine.Object.Instantiate(gameObject);
				ExposeToEditor component2 = obj.GetComponent<ExposeToEditor>();
				if (component2 != null)
				{
					component2.SetName(gameObject.name);
				}
				obj.transform.position = point;
				obj.transform.rotation = gameObject.transform.rotation;
				obj.transform.localScale = gameObject.transform.localScale;
				RuntimeSelection.activeGameObject = obj;
			}
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			m_isPointerOverSceneView = true;
			SetCursor();
		}

		private void SetCursor()
		{
			if (!m_isPointerOverSceneView)
			{
				Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
			}
			else if (m_pan)
			{
				if (m_rotate && RuntimeTools.Current == RuntimeTool.View)
				{
					Cursor.SetCursor(ViewTexture, Vector2.zero, CursorMode.Auto);
				}
				else
				{
					Cursor.SetCursor(MoveTexture, Vector2.zero, CursorMode.Auto);
				}
			}
			else if (m_rotate)
			{
				Cursor.SetCursor(ViewTexture, Vector2.zero, CursorMode.Auto);
			}
			else if (RuntimeTools.Current == RuntimeTool.View)
			{
				Cursor.SetCursor(MoveTexture, Vector2.zero, CursorMode.Auto);
			}
			else
			{
				Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
			}
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
			m_isPointerOverSceneView = false;
		}
	}
}
