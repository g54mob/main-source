using System;
using Battlehub.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace Battlehub.RTHandles
{
	[RequireComponent(typeof(Camera))]
	public class SceneGizmo : MonoBehaviour
	{
		public Camera SceneCamera;

		public Transform Pivot;

		public Vector2 Size = new Vector2(96f, 96f);

		public UnityEvent OrientationChanging;

		public UnityEvent OrientationChanged;

		public UnityEvent ProjectionChanged;

		private float m_aspect;

		private Camera m_camera;

		private float m_xAlpha = 1f;

		private float m_yAlpha = 1f;

		private float m_zAlpha = 1f;

		private float m_animationDuration = 0.2f;

		private GUIStyle m_buttonStyle;

		private Rect m_buttonRect;

		private bool m_mouseOver;

		private Vector3 m_selectedAxis;

		private GameObject m_collidersGO;

		private BoxCollider m_colliderProj;

		private BoxCollider m_colliderUp;

		private BoxCollider m_colliderDown;

		private BoxCollider m_colliderForward;

		private BoxCollider m_colliderBackward;

		private BoxCollider m_colliderLeft;

		private BoxCollider m_colliderRight;

		private Collider[] m_colliders;

		private Vector3 m_position;

		private Quaternion m_rotation;

		private Vector3 m_gizmoPosition;

		private IAnimationInfo m_rotateAnimation;

		private float m_screenHeight;

		private float m_screenWidth;

		private bool IsOrthographic
		{
			get
			{
				return m_camera.orthographic;
			}
			set
			{
				m_camera.orthographic = value;
				SceneCamera.orthographic = value;
				if (ProjectionChanged != null)
				{
					ProjectionChanged.Invoke();
					InitColliders();
				}
			}
		}

		private void Awake()
		{
			if (SceneCamera == null)
			{
				SceneCamera = Camera.main;
			}
			if (Pivot == null)
			{
				Pivot = base.transform;
			}
			m_collidersGO = new GameObject();
			m_collidersGO.transform.SetParent(base.transform, worldPositionStays: false);
			m_collidersGO.transform.position = GetGizmoPosition();
			m_collidersGO.transform.rotation = Quaternion.identity;
			m_collidersGO.name = "Colliders";
			m_colliderProj = m_collidersGO.AddComponent<BoxCollider>();
			m_colliderUp = m_collidersGO.AddComponent<BoxCollider>();
			m_colliderDown = m_collidersGO.AddComponent<BoxCollider>();
			m_colliderLeft = m_collidersGO.AddComponent<BoxCollider>();
			m_colliderRight = m_collidersGO.AddComponent<BoxCollider>();
			m_colliderForward = m_collidersGO.AddComponent<BoxCollider>();
			m_colliderBackward = m_collidersGO.AddComponent<BoxCollider>();
			Collider[] colliders = new BoxCollider[7] { m_colliderProj, m_colliderUp, m_colliderDown, m_colliderRight, m_colliderLeft, m_colliderForward, m_colliderBackward };
			m_colliders = colliders;
			DisableColliders();
			m_camera = GetComponent<Camera>();
			m_camera.clearFlags = CameraClearFlags.Depth;
			m_camera.renderingPath = RenderingPath.Forward;
			m_camera.cullingMask = 0;
			SceneCamera.orthographic = m_camera.orthographic;
			m_screenHeight = Screen.height;
			m_screenWidth = Screen.width;
			UpdateLayout();
			InitColliders();
			UpdateAlpha(ref m_xAlpha, Vector3.right, 1f);
			UpdateAlpha(ref m_yAlpha, Vector3.up, 1f);
			UpdateAlpha(ref m_zAlpha, Vector3.forward, 1f);
		}

		private void Start()
		{
			if (Run.Instance == null)
			{
				GameObject obj = new GameObject();
				obj.name = "Run";
				obj.AddComponent<Run>();
			}
		}

		public void UpdateLayout()
		{
			if (!(m_camera == null))
			{
				m_aspect = m_camera.aspect;
				m_camera.pixelRect = new Rect(SceneCamera.pixelRect.min.x + (float)SceneCamera.pixelWidth - Size.x, SceneCamera.pixelRect.min.y + (float)SceneCamera.pixelHeight - Size.y, Size.x, Size.y);
				m_camera.depth = SceneCamera.depth + 1f;
				m_aspect = m_camera.aspect;
				m_buttonRect = new Rect(SceneCamera.pixelRect.min.x + (float)SceneCamera.pixelWidth - Size.x / 2f - 20f, (float)Screen.height - SceneCamera.pixelRect.yMax + Size.y - 5f, 40f, 30f);
				m_buttonStyle = new GUIStyle();
				m_buttonStyle.alignment = TextAnchor.MiddleCenter;
				m_buttonStyle.normal.textColor = new Color(0.8f, 0.8f, 0.8f, 0.8f);
				m_buttonStyle.fontSize = 12;
			}
		}

		private Vector3 GetGizmoPosition()
		{
			return base.transform.TransformPoint(Vector3.forward * 5f);
		}

		private void OnPostRender()
		{
			RuntimeHandles.DoSceneGizmo(GetGizmoPosition(), Quaternion.identity, m_selectedAxis, Size.y / 96f, m_xAlpha, m_yAlpha, m_zAlpha);
		}

		private void OnGUI()
		{
			if (SceneCamera.orthographic)
			{
				if (GUI.Button(m_buttonRect, "Iso", m_buttonStyle))
				{
					IsOrthographic = false;
				}
			}
			else if (GUI.Button(m_buttonRect, "Persp", m_buttonStyle))
			{
				IsOrthographic = true;
			}
		}

		private void Update()
		{
			if (m_position != base.transform.position || m_rotation != base.transform.rotation)
			{
				InitColliders();
				m_position = base.transform.position;
				m_rotation = base.transform.rotation;
			}
			if (m_screenHeight != (float)Screen.height || m_screenWidth != (float)Screen.width)
			{
				m_screenHeight = Screen.height;
				m_screenWidth = Screen.width;
				UpdateLayout();
			}
			if (m_aspect != m_camera.aspect)
			{
				m_camera.pixelRect = new Rect((float)SceneCamera.pixelWidth - Size.x, (float)SceneCamera.pixelHeight - Size.y, Size.x, Size.y);
				m_aspect = m_camera.aspect;
			}
			float delta = Time.deltaTime / m_animationDuration;
			bool flag = UpdateAlpha(ref m_xAlpha, Vector3.right, delta);
			flag |= UpdateAlpha(ref m_yAlpha, Vector3.up, delta);
			flag |= UpdateAlpha(ref m_zAlpha, Vector3.forward, delta);
			m_camera.transform.rotation = SceneCamera.transform.rotation;
			Vector2 vector = Input.mousePosition;
			vector.y = (float)Screen.height - vector.y;
			bool flag2 = (RuntimeTools.IsSceneGizmoSelected = m_buttonRect.Contains(vector, allowInverse: true));
			if (m_camera.pixelRect.Contains(Input.mousePosition))
			{
				if (!m_mouseOver || flag)
				{
					EnableColliders();
				}
				Collider collider = HitTest();
				if (collider == null || (m_rotateAnimation != null && m_rotateAnimation.InProgress))
				{
					m_selectedAxis = Vector3.zero;
				}
				else if (collider == m_colliderProj)
				{
					m_selectedAxis = Vector3.one;
				}
				else if (collider == m_colliderUp)
				{
					m_selectedAxis = Vector3.up;
				}
				else if (collider == m_colliderDown)
				{
					m_selectedAxis = Vector3.down;
				}
				else if (collider == m_colliderForward)
				{
					m_selectedAxis = Vector3.forward;
				}
				else if (collider == m_colliderBackward)
				{
					m_selectedAxis = Vector3.back;
				}
				else if (collider == m_colliderRight)
				{
					m_selectedAxis = Vector3.right;
				}
				else if (collider == m_colliderLeft)
				{
					m_selectedAxis = Vector3.left;
				}
				if (m_selectedAxis != Vector3.zero || flag2)
				{
					RuntimeTools.IsSceneGizmoSelected = true;
				}
				else
				{
					RuntimeTools.IsSceneGizmoSelected = false;
				}
				if (Input.GetMouseButtonUp(0) && m_selectedAxis != Vector3.zero)
				{
					if (m_selectedAxis == Vector3.one)
					{
						IsOrthographic = !IsOrthographic;
					}
					else
					{
						if ((m_rotateAnimation == null || !m_rotateAnimation.InProgress) && OrientationChanging != null)
						{
							OrientationChanging.Invoke();
						}
						if (m_rotateAnimation != null)
						{
							m_rotateAnimation.Abort();
						}
						Vector3 pivot = Pivot.transform.position;
						Vector3 radiusVector = Vector3.back * (SceneCamera.transform.position - pivot).magnitude;
						Quaternion to = Quaternion.LookRotation(-m_selectedAxis, Vector3.up);
						m_rotateAnimation = new QuaternionAnimationInfo(SceneCamera.transform.rotation, to, 0.4f, AnimationInfo<object, Quaternion>.EaseOutCubic, delegate(object target, Quaternion value, float t, bool completed)
						{
							SceneCamera.transform.position = pivot + value * radiusVector;
							SceneCamera.transform.rotation = value;
							if (completed)
							{
								DisableColliders();
								EnableColliders();
								if (OrientationChanged != null)
								{
									OrientationChanged.Invoke();
								}
							}
						});
						Run.Instance.Animation(m_rotateAnimation);
					}
				}
				m_mouseOver = true;
			}
			else
			{
				if (m_mouseOver)
				{
					DisableColliders();
					RuntimeTools.IsSceneGizmoSelected = false;
				}
				m_mouseOver = false;
			}
		}

		private void EnableColliders()
		{
			m_colliderProj.enabled = true;
			if (m_zAlpha == 1f)
			{
				m_colliderForward.enabled = true;
				m_colliderBackward.enabled = true;
			}
			if (m_yAlpha == 1f)
			{
				m_colliderUp.enabled = true;
				m_colliderDown.enabled = true;
			}
			if (m_xAlpha == 1f)
			{
				m_colliderRight.enabled = true;
				m_colliderLeft.enabled = true;
			}
		}

		private void DisableColliders()
		{
			for (int i = 0; i < m_colliders.Length; i++)
			{
				m_colliders[i].enabled = false;
			}
		}

		private Collider HitTest()
		{
			Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
			float num = float.MaxValue;
			Collider result = null;
			for (int i = 0; i < m_colliders.Length; i++)
			{
				if (m_colliders[i].Raycast(ray, out var hitInfo, m_gizmoPosition.magnitude * 5f) && hitInfo.distance < num)
				{
					num = hitInfo.distance;
					result = hitInfo.collider;
				}
			}
			return result;
		}

		private void InitColliders()
		{
			m_gizmoPosition = GetGizmoPosition();
			float num = RuntimeHandles.GetScreenScale(m_gizmoPosition, m_camera) * Size.y / 96f;
			m_collidersGO.transform.rotation = Quaternion.identity;
			m_collidersGO.transform.position = GetGizmoPosition();
			m_colliderProj.size = new Vector3(0.15f, 0.15f, 0.15f) * num;
			m_colliderUp.size = new Vector3(0.15f, 0.3f, 0.15f) * num;
			m_colliderUp.center = new Vector3(0f, 0.22500001f, 0f) * num;
			m_colliderDown.size = new Vector3(0.15f, 0.3f, 0.15f) * num;
			m_colliderDown.center = new Vector3(0f, -0.22500001f, 0f) * num;
			m_colliderForward.size = new Vector3(0.15f, 0.15f, 0.3f) * num;
			m_colliderForward.center = new Vector3(0f, 0f, 0.22500001f) * num;
			m_colliderBackward.size = new Vector3(0.15f, 0.15f, 0.3f) * num;
			m_colliderBackward.center = new Vector3(0f, 0f, -0.22500001f) * num;
			m_colliderRight.size = new Vector3(0.3f, 0.15f, 0.15f) * num;
			m_colliderRight.center = new Vector3(0.22500001f, 0f, 0f) * num;
			m_colliderLeft.size = new Vector3(0.3f, 0.15f, 0.15f) * num;
			m_colliderLeft.center = new Vector3(-0.22500001f, 0f, 0f) * num;
		}

		private bool UpdateAlpha(ref float alpha, Vector3 axis, float delta)
		{
			if ((double)Math.Abs(Vector3.Dot(SceneCamera.transform.forward, axis)) > 0.9)
			{
				if (alpha > 0f)
				{
					alpha -= delta;
					if (alpha < 0f)
					{
						alpha = 0f;
					}
					return true;
				}
			}
			else if (alpha < 1f)
			{
				alpha += delta;
				if (alpha > 1f)
				{
					alpha = 1f;
				}
				return true;
			}
			return false;
		}
	}
}
