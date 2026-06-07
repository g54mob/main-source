using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Assets.Scripts.XR.UI.InputModules
{
	[AddComponentMenu("Event/Custom Tracked Device Raycaster")]
	[RequireComponent(typeof(Canvas))]
	public class CustomTrackedDeviceRaycaster : BaseRaycaster
	{
		private struct RaycastHitData
		{
			public float distance { get; }

			public Graphic graphic { get; }

			public Vector2 screenPosition { get; }

			public Vector3 worldHitPosition { get; }

			public RaycastHitData(Graphic graphic, Vector3 worldHitPosition, Vector2 screenPosition, float distance)
			{
				this.graphic = graphic;
				this.worldHitPosition = worldHitPosition;
				this.screenPosition = screenPosition;
				this.distance = distance;
			}
		}

		internal static List<CustomTrackedDeviceRaycaster> s_Instances = new List<CustomTrackedDeviceRaycaster>();

		private static readonly List<RaycastHitData> s_SortedGraphics = new List<RaycastHitData>();

		private Camera _lastHitCamera;

		[SerializeField]
		private Camera _secondaryEventCamera;

		[SerializeField]
		private LayerMask m_BlockingMask;

		[NonSerialized]
		private Canvas m_Canvas;

		[FormerlySerializedAs("checkFor2DOcclusion")]
		[SerializeField]
		private bool m_CheckFor2DOcclusion;

		[FormerlySerializedAs("checkFor3DOcclusion")]
		[SerializeField]
		private bool m_CheckFor3DOcclusion;

		[FormerlySerializedAs("ignoreReversedGraphics")]
		[SerializeField]
		private bool m_IgnoreReversedGraphics;

		[Tooltip("Maximum distance (in 3D world space) that rays are traced to find a hit.")]
		[SerializeField]
		private float m_MaxDistance = 1000f;

		[NonSerialized]
		private List<RaycastHitData> m_RaycastResultsCache = new List<RaycastHitData>();

		public static List<CustomTrackedDeviceRaycaster> Instances => s_Instances;

		public LayerMask blockingMask
		{
			get
			{
				return m_BlockingMask;
			}
			set
			{
				m_BlockingMask = value;
			}
		}

		public bool checkFor2DOcclusion
		{
			get
			{
				return m_CheckFor2DOcclusion;
			}
			set
			{
				m_CheckFor2DOcclusion = value;
			}
		}

		public bool checkFor3DOcclusion
		{
			get
			{
				return m_CheckFor3DOcclusion;
			}
			set
			{
				m_CheckFor3DOcclusion = value;
			}
		}

		public override Camera eventCamera
		{
			get
			{
				Camera camera = _lastHitCamera;
				if ((object)camera == null)
				{
					if (!(canvas != null))
					{
						return null;
					}
					camera = canvas.worldCamera;
				}
				return camera;
			}
		}

		public bool ignoreReversedGraphics
		{
			get
			{
				return m_IgnoreReversedGraphics;
			}
			set
			{
				m_IgnoreReversedGraphics = value;
			}
		}

		public float maxDistance
		{
			get
			{
				return m_MaxDistance;
			}
			set
			{
				m_MaxDistance = value;
			}
		}

		public Camera SecondaryEventCamera => _secondaryEventCamera;

		private Canvas canvas
		{
			get
			{
				if (m_Canvas != null)
				{
					return m_Canvas;
				}
				m_Canvas = GetComponent<Canvas>();
				return m_Canvas;
			}
		}

		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
		{
			if (eventData is ExtendedPointerEventData { pointerType: UIPointerType.Tracked } extendedPointerEventData)
			{
				PerformRaycast(extendedPointerEventData, resultAppendList);
			}
		}

		internal void PerformRaycast(ExtendedPointerEventData eventData, List<RaycastResult> resultAppendList)
		{
			_lastHitCamera = null;
			if (canvas == null || eventCamera == null)
			{
				return;
			}
			Ray ray = new Ray(eventData.trackedDevicePosition, eventData.trackedDeviceOrientation * Vector3.forward);
			float num = m_MaxDistance;
			m_RaycastResultsCache.Clear();
			SortedRaycastGraphics(canvas, ray, m_RaycastResultsCache);
			for (int i = 0; i < m_RaycastResultsCache.Count; i++)
			{
				bool flag = true;
				RaycastHitData raycastHitData = m_RaycastResultsCache[i];
				GameObject gameObject = raycastHitData.graphic.gameObject;
				if (m_IgnoreReversedGraphics)
				{
					Vector3 direction = ray.direction;
					Vector3 rhs = gameObject.transform.rotation * Vector3.forward;
					flag = Vector3.Dot(direction, rhs) > 0f;
				}
				if (flag & (raycastHitData.distance < num))
				{
					RaycastResult item = new RaycastResult
					{
						gameObject = gameObject,
						module = this,
						distance = raycastHitData.distance,
						index = resultAppendList.Count,
						depth = raycastHitData.graphic.depth,
						worldPosition = raycastHitData.worldHitPosition,
						screenPosition = raycastHitData.screenPosition,
						worldNormal = -raycastHitData.graphic.transform.forward,
						sortingLayer = canvas.sortingLayerID,
						sortingOrder = canvas.sortingOrder
					};
					resultAppendList.Add(item);
				}
			}
		}

		protected override void OnDisable()
		{
			int num = s_Instances.IndexOf(this);
			if (num != -1)
			{
				s_Instances.RemoveAt(num);
			}
			base.OnDisable();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			s_Instances.Add(this);
		}

		private static bool RayIntersectsRectTransform(RectTransform transform, Ray ray, out Vector3 worldPosition, out float distance)
		{
			Vector3[] array = new Vector3[4];
			transform.GetWorldCorners(array);
			if (new Plane(array[0], array[1], array[2]).Raycast(ray, out var enter))
			{
				Vector3 point = ray.GetPoint(enter);
				Vector3 rhs = array[3] - array[0];
				Vector3 rhs2 = array[1] - array[0];
				float num = Vector3.Dot(point - array[0], rhs);
				if (Vector3.Dot(point - array[0], rhs2) >= 0f && num >= 0f)
				{
					Vector3 rhs3 = array[1] - array[2];
					Vector3 rhs4 = array[3] - array[2];
					float num2 = Vector3.Dot(point - array[2], rhs3);
					float num3 = Vector3.Dot(point - array[2], rhs4);
					if (num2 >= 0f && num3 >= 0f)
					{
						worldPosition = point;
						distance = enter;
						return true;
					}
				}
			}
			worldPosition = Vector3.zero;
			distance = 0f;
			return false;
		}

		private void SortedRaycastGraphics(Canvas canvas, Ray ray, List<RaycastHitData> results)
		{
			IList<Graphic> graphicsForCanvas = GraphicRegistry.GetGraphicsForCanvas(canvas);
			s_SortedGraphics.Clear();
			for (int i = 0; i < graphicsForCanvas.Count; i++)
			{
				Graphic graphic = graphicsForCanvas[i];
				if (graphic.depth == -1 || !graphic.raycastTarget || !RayIntersectsRectTransform(graphic.rectTransform, ray, out var worldPosition, out var distance))
				{
					continue;
				}
				Camera camera = eventCamera;
				Vector2 vector = camera.WorldToScreenPoint(worldPosition);
				if (camera.isActiveAndEnabled && graphic.Raycast(vector, camera))
				{
					s_SortedGraphics.Add(new RaycastHitData(graphic, worldPosition, vector, distance));
					_lastHitCamera = camera;
				}
				else if (_secondaryEventCamera != null && _secondaryEventCamera.isActiveAndEnabled)
				{
					vector = _secondaryEventCamera.WorldToScreenPoint(worldPosition);
					if (graphic.Raycast(vector, _secondaryEventCamera))
					{
						s_SortedGraphics.Add(new RaycastHitData(graphic, worldPosition, vector, distance));
						_lastHitCamera = _secondaryEventCamera;
					}
				}
			}
			s_SortedGraphics.Sort((RaycastHitData g1, RaycastHitData g2) => g2.graphic.depth.CompareTo(g1.graphic.depth));
			results.AddRange(s_SortedGraphics);
		}
	}
}
