using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CurvedUI
{
	public class CurvedUIRaycaster : GraphicRaycaster
	{
		[SerializeField]
		private bool showDebug;

		private bool overrideEventData = true;

		private Canvas myCanvas;

		private CurvedUISettings mySettings;

		private Vector3 cyllinderMidPoint;

		private List<GameObject> objectsUnderPointer = new List<GameObject>();

		private Vector2 lastCanvasPos = Vector2.zero;

		private GameObject colliderContainer;

		private PointerEventData lastFrameEventData;

		private PointerEventData curEventData;

		private PointerEventData eventDataToUse;

		private Ray cachedRay;

		private Graphic gph;

		private List<GameObject> selectablesUnderGaze = new List<GameObject>();

		private List<GameObject> selectablesUnderGazeLastFrame = new List<GameObject>();

		private float objectsUnderGazeLastChangeTime;

		private bool gazeClickExecuted;

		private bool pointingAtCanvas;

		private bool pointingAtCanvasLastFrame;

		[NonSerialized]
		private List<Graphic> m_RaycastResults = new List<Graphic>();

		[NonSerialized]
		private static readonly List<Graphic> s_SortedGraphics = new List<Graphic>();

		private Image GazeProgressImage => CurvedUIInputModule.Instance.GazeTimedClickProgressImage;

		public bool PointingAtCanvas => pointingAtCanvas;

		protected override void Awake()
		{
			base.Awake();
			mySettings = GetComponentInParent<CurvedUISettings>();
			if (!(mySettings == null))
			{
				myCanvas = mySettings.GetComponent<Canvas>();
				cyllinderMidPoint = new Vector3(0f, 0f, 0f - mySettings.GetCyllinderRadiusInCanvasSpace());
				base.ignoreReversedGraphics = false;
			}
		}

		protected override void Start()
		{
			if (!(mySettings == null))
			{
				CheckEventCamera();
				CreateCollider();
			}
		}

		protected virtual void Update()
		{
			if (mySettings == null)
			{
				return;
			}
			if (CurvedUIInputModule.ControlMethod == CurvedUIInputModule.CUIControlMethod.GAZE && CurvedUIInputModule.Instance.GazeUseTimedClick)
			{
				if (pointingAtCanvas)
				{
					if (!pointingAtCanvasLastFrame)
					{
						ResetGazeTimedClick();
					}
					ProcessGazeTimedClick();
					selectablesUnderGazeLastFrame.Clear();
					selectablesUnderGazeLastFrame.AddRange(selectablesUnderGaze);
					selectablesUnderGaze.Clear();
					selectablesUnderGaze.AddRange(objectsUnderPointer);
					selectablesUnderGaze.RemoveAll((GameObject obj) => obj.GetComponent<Selectable>() == null || !obj.GetComponent<Selectable>().interactable);
					if ((bool)GazeProgressImage)
					{
						if (GazeProgressImage.type != Image.Type.Filled)
						{
							GazeProgressImage.type = Image.Type.Filled;
						}
						GazeProgressImage.fillAmount = (Time.time - objectsUnderGazeLastChangeTime).RemapAndClamp(CurvedUIInputModule.Instance.GazeClickTimerDelay, CurvedUIInputModule.Instance.GazeClickTimer + CurvedUIInputModule.Instance.GazeClickTimerDelay, 0f, 1f);
					}
				}
				else if (!pointingAtCanvas && pointingAtCanvasLastFrame)
				{
					ResetGazeTimedClick();
					if ((bool)GazeProgressImage)
					{
						GazeProgressImage.fillAmount = 0f;
					}
				}
			}
			pointingAtCanvasLastFrame = pointingAtCanvas;
			pointingAtCanvas = false;
		}

		private void ProcessGazeTimedClick()
		{
			if (selectablesUnderGazeLastFrame.Count == 0 || selectablesUnderGazeLastFrame.Count != selectablesUnderGaze.Count)
			{
				ResetGazeTimedClick();
				return;
			}
			for (int i = 0; i < selectablesUnderGazeLastFrame.Count && i < selectablesUnderGaze.Count; i++)
			{
				if (selectablesUnderGazeLastFrame[i].GetInstanceID() != selectablesUnderGaze[i].GetInstanceID())
				{
					ResetGazeTimedClick();
					return;
				}
			}
			if (!gazeClickExecuted && Time.time > objectsUnderGazeLastChangeTime + CurvedUIInputModule.Instance.GazeClickTimer + CurvedUIInputModule.Instance.GazeClickTimerDelay)
			{
				Click();
				gazeClickExecuted = true;
			}
		}

		private void ResetGazeTimedClick()
		{
			objectsUnderGazeLastChangeTime = Time.time;
			gazeClickExecuted = false;
		}

		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
		{
			if (mySettings == null)
			{
				base.Raycast(eventData, resultAppendList);
			}
			else
			{
				if (!mySettings.Interactable)
				{
					return;
				}
				if (!CheckEventCamera())
				{
					Debug.LogWarning("CurvedUI: No WORLD CAMERA assigned to Canvas " + base.gameObject.name + " to use for event processing!", myCanvas.gameObject);
					return;
				}
				cachedRay = CurvedUIInputModule.Instance.GetEventRay(myCanvas.worldCamera);
				if (CurvedUIInputModule.ControlMethod == CurvedUIInputModule.CUIControlMethod.GAZE)
				{
					UpdateSelectedObjects(eventData);
				}
				else if (CurvedUIInputModule.ControlMethod == CurvedUIInputModule.CUIControlMethod.WORLD_MOUSE)
				{
					cachedRay = new Ray(myCanvas.worldCamera.transform.position, mySettings.CanvasToCurvedCanvas(CurvedUIInputModule.Instance.WorldSpaceMouseInCanvasSpace) - myCanvas.worldCamera.transform.position);
				}
				if (curEventData == null)
				{
					curEventData = new PointerEventData(EventSystem.current);
				}
				if (!overrideEventData)
				{
					curEventData.pointerEnter = eventData.pointerEnter;
					curEventData.rawPointerPress = eventData.rawPointerPress;
					curEventData.pointerDrag = eventData.pointerDrag;
					curEventData.pointerCurrentRaycast = eventData.pointerCurrentRaycast;
					curEventData.pointerPressRaycast = eventData.pointerPressRaycast;
					curEventData.hovered.Clear();
					curEventData.hovered.AddRange(eventData.hovered);
					curEventData.eligibleForClick = eventData.eligibleForClick;
					curEventData.pointerId = eventData.pointerId;
					curEventData.position = eventData.position;
					curEventData.delta = eventData.delta;
					curEventData.pressPosition = eventData.pressPosition;
					curEventData.clickTime = eventData.clickTime;
					curEventData.clickCount = eventData.clickCount;
					curEventData.scrollDelta = eventData.scrollDelta;
					curEventData.useDragThreshold = eventData.useDragThreshold;
					curEventData.dragging = eventData.dragging;
					curEventData.button = eventData.button;
				}
				if (mySettings.Angle != 0 && mySettings.enabled)
				{
					Vector2 o_canvasPos = eventData.position;
					switch (mySettings.Shape)
					{
					case CurvedUISettings.CurvedUIShape.CYLINDER:
						if (!RaycastToCyllinderCanvas(cachedRay, out o_canvasPos))
						{
							return;
						}
						break;
					case CurvedUISettings.CurvedUIShape.CYLINDER_VERTICAL:
						if (!RaycastToCyllinderVerticalCanvas(cachedRay, out o_canvasPos))
						{
							return;
						}
						break;
					case CurvedUISettings.CurvedUIShape.RING:
						if (!RaycastToRingCanvas(cachedRay, out o_canvasPos))
						{
							return;
						}
						break;
					case CurvedUISettings.CurvedUIShape.SPHERE:
						if (!RaycastToSphereCanvas(cachedRay, out o_canvasPos))
						{
							return;
						}
						break;
					}
					pointingAtCanvas = true;
					eventDataToUse = (overrideEventData ? eventData : curEventData);
					if (eventDataToUse.pressPosition == eventDataToUse.position)
					{
						eventDataToUse.pressPosition = o_canvasPos;
					}
					eventDataToUse.position = o_canvasPos;
					if (CurvedUIInputModule.ControlMethod == CurvedUIInputModule.CUIControlMethod.STEAMVR_LEGACY)
					{
						eventDataToUse.delta = o_canvasPos - lastCanvasPos;
						lastCanvasPos = o_canvasPos;
					}
				}
				objectsUnderPointer = eventData.hovered;
				lastFrameEventData = eventData;
				FlatRaycast(overrideEventData ? eventData : curEventData, resultAppendList);
			}
		}

		public virtual bool RaycastToCyllinderCanvas(Ray ray3D, out Vector2 o_canvasPos, bool OutputInCanvasSpace = false)
		{
			if (showDebug)
			{
				Debug.DrawLine(ray3D.origin, ray3D.GetPoint(1000f), Color.red);
			}
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(ray3D, out hitInfo, float.PositiveInfinity, GetRaycastLayerMask()))
			{
				if (overrideEventData && hitInfo.collider.gameObject != base.gameObject && (colliderContainer == null || hitInfo.collider.transform.parent != colliderContainer.transform))
				{
					o_canvasPos = Vector2.zero;
					return false;
				}
				Vector3 vector = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(hitInfo.point);
				Vector3 normalized = (vector - cyllinderMidPoint).normalized;
				float value = 0f - AngleSigned(normalized.ModifyY(0f), (mySettings.Angle < 0) ? Vector3.back : Vector3.forward, Vector3.up);
				Vector2 size = myCanvas.GetComponent<RectTransform>().rect.size;
				Vector2 vector2 = new Vector3(0f, 0f, 0f);
				vector2.x = value.Remap((float)(-mySettings.Angle) / 2f, (float)mySettings.Angle / 2f, (0f - size.x) / 2f, size.x / 2f);
				vector2.y = vector.y;
				if (OutputInCanvasSpace)
				{
					o_canvasPos = vector2;
				}
				else
				{
					o_canvasPos = myCanvas.worldCamera.WorldToScreenPoint(myCanvas.transform.localToWorldMatrix.MultiplyPoint3x4(vector2));
				}
				if (showDebug)
				{
					Debug.DrawLine(hitInfo.point, hitInfo.point.ModifyY(hitInfo.point.y + 10f), Color.green);
					Debug.DrawLine(hitInfo.point, myCanvas.transform.localToWorldMatrix.MultiplyPoint3x4(cyllinderMidPoint), Color.yellow);
				}
				return true;
			}
			o_canvasPos = Vector2.zero;
			return false;
		}

		public virtual bool RaycastToCyllinderVerticalCanvas(Ray ray3D, out Vector2 o_canvasPos, bool OutputInCanvasSpace = false)
		{
			if (showDebug)
			{
				Debug.DrawLine(ray3D.origin, ray3D.GetPoint(1000f), Color.red);
			}
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(ray3D, out hitInfo, float.PositiveInfinity, GetRaycastLayerMask()))
			{
				if (overrideEventData && hitInfo.collider.gameObject != base.gameObject && (colliderContainer == null || hitInfo.collider.transform.parent != colliderContainer.transform))
				{
					o_canvasPos = Vector2.zero;
					return false;
				}
				Vector3 vector = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(hitInfo.point);
				Vector3 normalized = (vector - cyllinderMidPoint).normalized;
				float value = 0f - AngleSigned(normalized.ModifyX(0f), (mySettings.Angle < 0) ? Vector3.back : Vector3.forward, Vector3.left);
				Vector2 size = myCanvas.GetComponent<RectTransform>().rect.size;
				Vector2 vector2 = new Vector3(0f, 0f, 0f);
				vector2.y = value.Remap((float)(-mySettings.Angle) / 2f, (float)mySettings.Angle / 2f, (0f - size.y) / 2f, size.y / 2f);
				vector2.x = vector.x;
				if (OutputInCanvasSpace)
				{
					o_canvasPos = vector2;
				}
				else
				{
					o_canvasPos = myCanvas.worldCamera.WorldToScreenPoint(myCanvas.transform.localToWorldMatrix.MultiplyPoint3x4(vector2));
				}
				if (showDebug)
				{
					Debug.DrawLine(hitInfo.point, hitInfo.point.ModifyY(hitInfo.point.y + 10f), Color.green);
					Debug.DrawLine(hitInfo.point, myCanvas.transform.localToWorldMatrix.MultiplyPoint3x4(cyllinderMidPoint), Color.yellow);
				}
				return true;
			}
			o_canvasPos = Vector2.zero;
			return false;
		}

		public virtual bool RaycastToRingCanvas(Ray ray3D, out Vector2 o_canvasPos, bool OutputInCanvasSpace = false)
		{
			LayerMask raycastLayerMask = GetRaycastLayerMask();
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(ray3D, out hitInfo, float.PositiveInfinity, raycastLayerMask))
			{
				if (overrideEventData && hitInfo.collider.gameObject != base.gameObject && (colliderContainer == null || hitInfo.collider.transform.parent != colliderContainer.transform))
				{
					o_canvasPos = Vector2.zero;
					return false;
				}
				Vector3 trans = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(hitInfo.point);
				Vector3 normalized = trans.ModifyZ(0f).normalized;
				Vector2 size = myCanvas.GetComponent<RectTransform>().rect.size;
				float num = 0f - AngleSigned(normalized.ModifyZ(0f), Vector3.up, Vector3.back);
				Vector2 vector = new Vector2(0f, 0f);
				if (showDebug)
				{
					Debug.Log("angle: " + num);
				}
				if (num < 0f)
				{
					vector.x = num.Remap(0f, -mySettings.Angle, (0f - size.x) / 2f, size.x / 2f);
				}
				else
				{
					vector.x = num.Remap(360f, 360 - mySettings.Angle, (0f - size.x) / 2f, size.x / 2f);
				}
				vector.y = trans.magnitude.Remap((float)mySettings.RingExternalDiameter * 0.5f * (1f - mySettings.RingFill), (float)mySettings.RingExternalDiameter * 0.5f, (0f - size.y) * 0.5f * (float)((!mySettings.RingFlipVertical) ? 1 : (-1)), size.y * 0.5f * (float)((!mySettings.RingFlipVertical) ? 1 : (-1)));
				if (OutputInCanvasSpace)
				{
					o_canvasPos = vector;
				}
				else
				{
					o_canvasPos = myCanvas.worldCamera.WorldToScreenPoint(myCanvas.transform.localToWorldMatrix.MultiplyPoint3x4(vector));
				}
				return true;
			}
			o_canvasPos = Vector2.zero;
			return false;
		}

		public virtual bool RaycastToSphereCanvas(Ray ray3D, out Vector2 o_canvasPos, bool OutputInCanvasSpace = false)
		{
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(ray3D, out hitInfo, float.PositiveInfinity, GetRaycastLayerMask()))
			{
				if (overrideEventData && hitInfo.collider.gameObject != base.gameObject && (colliderContainer == null || hitInfo.collider.transform.parent != colliderContainer.transform))
				{
					o_canvasPos = Vector2.zero;
					return false;
				}
				Vector2 size = myCanvas.GetComponent<RectTransform>().rect.size;
				float num = (mySettings.PreserveAspect ? mySettings.GetCyllinderRadiusInCanvasSpace() : (size.x / 2f));
				Vector3 vector = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(hitInfo.point);
				Vector3 vector2 = new Vector3(0f, 0f, mySettings.PreserveAspect ? (0f - num) : 0f);
				Vector3 normalized = (vector - vector2).normalized;
				Vector3 vector3 = Vector3.Cross(normalized, normalized.ModifyY(0f)).normalized * ((normalized.y < 0f) ? 1 : (-1));
				float value = 0f - AngleSigned(normalized.ModifyY(0f), (mySettings.Angle > 0) ? Vector3.forward : Vector3.back, (mySettings.Angle > 0) ? Vector3.up : Vector3.down);
				float value2 = 0f - AngleSigned(normalized, normalized.ModifyY(0f), vector3);
				float num2 = (float)Mathf.Abs(mySettings.Angle) * 0.5f;
				float num3 = Mathf.Abs(mySettings.PreserveAspect ? (num2 * size.y / size.x) : ((float)mySettings.VerticalAngle * 0.5f));
				Vector2 vector4 = new Vector2(value.Remap(0f - num2, num2, (0f - size.x) * 0.5f, size.x * 0.5f), value2.Remap(0f - num3, num3, (0f - size.y) * 0.5f, size.y * 0.5f));
				if (showDebug)
				{
					string[] obj = new string[6]
					{
						"h: ",
						value.ToString(),
						" / v: ",
						value2.ToString(),
						" poc: ",
						null
					};
					Vector2 vector5 = vector4;
					obj[5] = vector5.ToString();
					Debug.Log(string.Concat(obj));
					Debug.DrawRay(myCanvas.transform.localToWorldMatrix.MultiplyPoint3x4(vector2), myCanvas.transform.localToWorldMatrix.MultiplyVector(normalized) * Mathf.Abs(num), Color.red);
					Debug.DrawRay(myCanvas.transform.localToWorldMatrix.MultiplyPoint3x4(vector2), myCanvas.transform.localToWorldMatrix.MultiplyVector(vector3) * 300f, Color.magenta);
				}
				if (OutputInCanvasSpace)
				{
					o_canvasPos = vector4;
				}
				else
				{
					o_canvasPos = myCanvas.worldCamera.WorldToScreenPoint(myCanvas.transform.localToWorldMatrix.MultiplyPoint3x4(vector4));
				}
				return true;
			}
			o_canvasPos = Vector2.zero;
			return false;
		}

		private void FlatRaycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
		{
			if (myCanvas == null)
			{
				return;
			}
			IList<Graphic> graphicsForCanvas = GraphicRegistry.GetGraphicsForCanvas(myCanvas);
			if (graphicsForCanvas == null || graphicsForCanvas.Count == 0)
			{
				return;
			}
			Camera camera = eventCamera;
			int num = ((myCanvas.renderMode != RenderMode.ScreenSpaceOverlay && !(camera == null)) ? camera.targetDisplay : myCanvas.targetDisplay);
			Vector3 vector = Display.RelativeMouseAt(eventData.position);
			if (vector != Vector3.zero)
			{
				if ((int)vector.z != num)
				{
					return;
				}
			}
			else
			{
				vector = eventData.position;
			}
			m_RaycastResults.Clear();
			FlatRaycastAndSort(myCanvas, camera, vector, graphicsForCanvas, m_RaycastResults);
			Ray ray = default(Ray);
			if (camera != null)
			{
				ray = camera.ScreenPointToRay(vector);
			}
			float num2 = float.MaxValue;
			int count = m_RaycastResults.Count;
			for (int i = 0; i < count; i++)
			{
				GameObject gameObject = m_RaycastResults[i].gameObject;
				Transform transform = gameObject.transform;
				Vector3 forward = transform.forward;
				float num3 = Vector3.Dot(forward, transform.position - ray.origin) / Vector3.Dot(forward, ray.direction);
				if (!(num3 < 0f) && !(num3 >= num2))
				{
					RaycastResult item = new RaycastResult
					{
						gameObject = gameObject,
						module = this,
						distance = num3,
						screenPosition = vector,
						index = resultAppendList.Count,
						depth = m_RaycastResults[i].depth,
						sortingLayer = myCanvas.sortingLayerID,
						sortingOrder = myCanvas.sortingOrder
					};
					resultAppendList.Add(item);
				}
			}
		}

		private static void FlatRaycastAndSort(Canvas canvas, Camera eventCamera, Vector2 pointerPosition, IList<Graphic> foundGraphics, List<Graphic> results)
		{
			int count = foundGraphics.Count;
			for (int i = 0; i < count; i++)
			{
				Graphic graphic = foundGraphics[i];
				if (graphic.depth != -1 && graphic.raycastTarget && !graphic.canvasRenderer.cull && RectTransformUtility.RectangleContainsScreenPoint(graphic.rectTransform, pointerPosition, eventCamera) && (!(eventCamera != null) || !(eventCamera.WorldToScreenPoint(graphic.rectTransform.position).z > eventCamera.farClipPlane)) && graphic.Raycast(pointerPosition, eventCamera))
				{
					s_SortedGraphics.Add(graphic);
				}
			}
			s_SortedGraphics.Sort((Graphic g1, Graphic g2) => g2.depth.CompareTo(g1.depth));
			count = s_SortedGraphics.Count;
			for (int num = 0; num < count; num++)
			{
				results.Add(s_SortedGraphics[num]);
			}
			s_SortedGraphics.Clear();
		}

		protected void CreateCollider()
		{
			List<Collider> list = new List<Collider>();
			list.AddRange(GetComponents<Collider>());
			for (int i = 0; i < list.Count; i++)
			{
				UnityEngine.Object.Destroy(list[i]);
			}
			if (!mySettings.BlocksRaycasts || (mySettings.Shape == CurvedUISettings.CurvedUIShape.SPHERE && !mySettings.PreserveAspect && mySettings.VerticalAngle == 0))
			{
				return;
			}
			switch (mySettings.Shape)
			{
			case CurvedUISettings.CurvedUIShape.CYLINDER:
				if (mySettings.ForceUseBoxCollider || GetComponent<Rigidbody>() != null || GetComponentInParent<Rigidbody>() != null)
				{
					if (colliderContainer != null)
					{
						UnityEngine.Object.Destroy(colliderContainer);
					}
					colliderContainer = CreateConvexCyllinderCollider();
				}
				else
				{
					SetupMeshColliderUsingMesh(CreateCyllinderColliderMesh());
				}
				break;
			case CurvedUISettings.CurvedUIShape.CYLINDER_VERTICAL:
				if (mySettings.ForceUseBoxCollider || GetComponent<Rigidbody>() != null || GetComponentInParent<Rigidbody>() != null)
				{
					if (colliderContainer != null)
					{
						UnityEngine.Object.Destroy(colliderContainer);
					}
					colliderContainer = CreateConvexCyllinderCollider(vertical: true);
				}
				else
				{
					SetupMeshColliderUsingMesh(CreateCyllinderColliderMesh(vertical: true));
				}
				break;
			case CurvedUISettings.CurvedUIShape.RING:
				base.gameObject.AddComponent<BoxCollider>().size = new Vector3(mySettings.RingExternalDiameter, mySettings.RingExternalDiameter, 1f);
				break;
			case CurvedUISettings.CurvedUIShape.SPHERE:
				if (GetComponent<Rigidbody>() != null || GetComponentInParent<Rigidbody>() != null)
				{
					Debug.LogWarning("CurvedUI: Sphere shape canvases as children of rigidbodies do not support user input. Switch to Cyllinder shape or remove the rigidbody from parent.", base.gameObject);
				}
				SetupMeshColliderUsingMesh(CreateSphereColliderMesh());
				break;
			}
		}

		private void SetupMeshColliderUsingMesh(Mesh meshie)
		{
			MeshFilter meshFilter = this.AddComponentIfMissing<MeshFilter>();
			MeshCollider meshCollider = base.gameObject.AddComponent<MeshCollider>();
			meshFilter.mesh = meshie;
			meshCollider.sharedMesh = meshie;
		}

		private GameObject CreateConvexCyllinderCollider(bool vertical = false)
		{
			GameObject gameObject = new GameObject("_CurvedUIColliders");
			gameObject.layer = base.gameObject.layer;
			gameObject.transform.SetParent(base.transform);
			gameObject.transform.ResetTransform();
			Mesh mesh = new Mesh();
			Vector3[] array = new Vector3[4];
			(myCanvas.transform as RectTransform).GetWorldCorners(array);
			mesh.vertices = array;
			if (vertical)
			{
				array[0] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[1]);
				array[1] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[2]);
				array[2] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[0]);
				array[3] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[3]);
			}
			else
			{
				array[0] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[1]);
				array[1] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[0]);
				array[2] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[2]);
				array[3] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[3]);
			}
			mesh.vertices = array;
			List<Vector3> list = new List<Vector3>();
			int num = Mathf.Max(8, Mathf.RoundToInt((float)(mySettings.BaseCircleSegments * Mathf.Abs(mySettings.Angle)) / 360f));
			for (int i = 0; i < num; i++)
			{
				list.Add(Vector3.Lerp(mesh.vertices[0], mesh.vertices[2], (float)i * 1f / (float)(num - 1)));
			}
			if (mySettings.Angle != 0)
			{
				Rect rect = myCanvas.GetComponent<RectTransform>().rect;
				float cyllinderRadiusInCanvasSpace = mySettings.GetCyllinderRadiusInCanvasSpace();
				for (int j = 0; j < list.Count; j++)
				{
					Vector3 value = list[j];
					if (vertical)
					{
						float f = list[j].y / rect.size.y * (float)mySettings.Angle * (MathF.PI / 180f);
						value.y = Mathf.Sin(f) * cyllinderRadiusInCanvasSpace;
						value.z += Mathf.Cos(f) * cyllinderRadiusInCanvasSpace - cyllinderRadiusInCanvasSpace;
						list[j] = value;
					}
					else
					{
						float f2 = list[j].x / rect.size.x * (float)mySettings.Angle * (MathF.PI / 180f);
						value.x = Mathf.Sin(f2) * cyllinderRadiusInCanvasSpace;
						value.z += Mathf.Cos(f2) * cyllinderRadiusInCanvasSpace - cyllinderRadiusInCanvasSpace;
						list[j] = value;
					}
				}
			}
			float x = mySettings.GetTesslationSize(modifiedByQuality: false).x / 10f;
			for (int k = 0; k < list.Count - 1; k++)
			{
				GameObject gameObject2 = new GameObject("Box collider");
				gameObject2.layer = base.gameObject.layer;
				gameObject2.transform.SetParent(gameObject.transform);
				gameObject2.transform.ResetTransform();
				gameObject2.AddComponent<BoxCollider>();
				if (vertical)
				{
					gameObject2.transform.localPosition = new Vector3(0f, (list[k + 1].y + list[k].y) * 0.5f, (list[k + 1].z + list[k].z) * 0.5f);
					gameObject2.transform.localScale = new Vector3(x, Vector3.Distance(array[0], array[1]), Vector3.Distance(list[k + 1], list[k]));
					gameObject2.transform.localRotation = Quaternion.LookRotation(list[k + 1] - list[k], array[0] - array[1]);
				}
				else
				{
					gameObject2.transform.localPosition = new Vector3((list[k + 1].x + list[k].x) * 0.5f, 0f, (list[k + 1].z + list[k].z) * 0.5f);
					gameObject2.transform.localScale = new Vector3(x, Vector3.Distance(array[0], array[1]), Vector3.Distance(list[k + 1], list[k]));
					gameObject2.transform.localRotation = Quaternion.LookRotation(list[k + 1] - list[k], array[0] - array[1]);
				}
			}
			return gameObject;
		}

		private Mesh CreateCyllinderColliderMesh(bool vertical = false)
		{
			Mesh mesh = new Mesh();
			Vector3[] array = new Vector3[4];
			(myCanvas.transform as RectTransform).GetWorldCorners(array);
			mesh.vertices = array;
			if (vertical)
			{
				array[0] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[1]);
				array[1] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[2]);
				array[2] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[0]);
				array[3] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[3]);
			}
			else
			{
				array[0] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[1]);
				array[1] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[0]);
				array[2] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[2]);
				array[3] = myCanvas.transform.worldToLocalMatrix.MultiplyPoint3x4(mesh.vertices[3]);
			}
			mesh.vertices = array;
			List<Vector3> list = new List<Vector3>();
			int num = Mathf.Max(8, Mathf.RoundToInt((float)(mySettings.BaseCircleSegments * Mathf.Abs(mySettings.Angle)) / 360f));
			for (int i = 0; i < num; i++)
			{
				list.Add(Vector3.Lerp(mesh.vertices[0], mesh.vertices[2], (float)i * 1f / (float)(num - 1)));
				list.Add(Vector3.Lerp(mesh.vertices[1], mesh.vertices[3], (float)i * 1f / (float)(num - 1)));
			}
			if (mySettings.Angle != 0)
			{
				Rect rect = myCanvas.GetComponent<RectTransform>().rect;
				float cyllinderRadiusInCanvasSpace = mySettings.GetCyllinderRadiusInCanvasSpace();
				for (int j = 0; j < list.Count; j++)
				{
					Vector3 value = list[j];
					if (vertical)
					{
						float f = list[j].y / rect.size.y * (float)mySettings.Angle * (MathF.PI / 180f);
						value.y = Mathf.Sin(f) * cyllinderRadiusInCanvasSpace;
						value.z += Mathf.Cos(f) * cyllinderRadiusInCanvasSpace - cyllinderRadiusInCanvasSpace;
						list[j] = value;
					}
					else
					{
						float f2 = list[j].x / rect.size.x * (float)mySettings.Angle * (MathF.PI / 180f);
						value.x = Mathf.Sin(f2) * cyllinderRadiusInCanvasSpace;
						value.z += Mathf.Cos(f2) * cyllinderRadiusInCanvasSpace - cyllinderRadiusInCanvasSpace;
						list[j] = value;
					}
				}
			}
			mesh.vertices = list.ToArray();
			List<int> list2 = new List<int>();
			for (int k = 0; k < list.Count / 2 - 1; k++)
			{
				if (vertical)
				{
					list2.Add(k * 2);
					list2.Add(k * 2 + 1);
					list2.Add(k * 2 + 2);
					list2.Add(k * 2 + 1);
					list2.Add(k * 2 + 3);
					list2.Add(k * 2 + 2);
				}
				else
				{
					list2.Add(k * 2 + 2);
					list2.Add(k * 2 + 1);
					list2.Add(k * 2);
					list2.Add(k * 2 + 2);
					list2.Add(k * 2 + 3);
					list2.Add(k * 2 + 1);
				}
			}
			mesh.triangles = list2.ToArray();
			return mesh;
		}

		private Mesh CreateSphereColliderMesh()
		{
			Mesh mesh = new Mesh();
			Vector3[] array = new Vector3[4];
			(myCanvas.transform as RectTransform).GetWorldCorners(array);
			List<Vector3> list = new List<Vector3>(array);
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = mySettings.transform.worldToLocalMatrix.MultiplyPoint3x4(list[i]);
			}
			if (mySettings.Angle != 0)
			{
				int count = list.Count;
				for (int j = 0; j < count; j += 4)
				{
					ModifyQuad(list, j, mySettings.GetTesslationSize(modifiedByQuality: false));
				}
				list.RemoveRange(0, count);
				float num = mySettings.VerticalAngle;
				float num2 = mySettings.Angle;
				Vector2 size = (myCanvas.transform as RectTransform).rect.size;
				float num3 = mySettings.GetCyllinderRadiusInCanvasSpace();
				if (mySettings.PreserveAspect)
				{
					num = (float)mySettings.Angle * (size.y / size.x);
				}
				else
				{
					num3 = size.x / 2f;
				}
				for (int k = 0; k < list.Count; k++)
				{
					float num4 = (list[k].x / size.x).Remap(-0.5f, 0.5f, (180f - num2) / 2f - 90f, 180f - (180f - num2) / 2f - 90f);
					num4 *= MathF.PI / 180f;
					float num5 = (list[k].y / size.y).Remap(-0.5f, 0.5f, (180f - num) / 2f, 180f - (180f - num) / 2f);
					num5 *= MathF.PI / 180f;
					list[k] = new Vector3(Mathf.Sin(num5) * Mathf.Sin(num4) * num3, (0f - num3) * Mathf.Cos(num5), Mathf.Sin(num5) * Mathf.Cos(num4) * num3 + (mySettings.PreserveAspect ? (0f - num3) : 0f));
				}
			}
			mesh.vertices = list.ToArray();
			List<int> list2 = new List<int>();
			for (int l = 0; l < list.Count; l += 4)
			{
				list2.Add(l);
				list2.Add(l + 1);
				list2.Add(l + 2);
				list2.Add(l + 3);
				list2.Add(l);
				list2.Add(l + 2);
			}
			mesh.triangles = list2.ToArray();
			return mesh;
		}

		private bool IsInLayerMask(int layer, LayerMask layermask)
		{
			return (int)layermask == ((int)layermask | (1 << layer));
		}

		private LayerMask GetRaycastLayerMask()
		{
			return CurvedUIInputModule.Instance.RaycastLayerMask;
		}

		private float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n)
		{
			return Mathf.Atan2(Vector3.Dot(n, Vector3.Cross(v1, v2)), Vector3.Dot(v1, v2)) * 57.29578f;
		}

		private bool ShouldStartDrag(Vector2 pressPos, Vector2 currentPos, float threshold, bool useDragThreshold)
		{
			if (!useDragThreshold)
			{
				return true;
			}
			return (pressPos - currentPos).sqrMagnitude >= threshold * threshold;
		}

		protected virtual void ProcessMove(PointerEventData pointerEvent)
		{
			GameObject newEnterTarget = pointerEvent.pointerCurrentRaycast.gameObject;
			HandlePointerExitAndEnter(pointerEvent, newEnterTarget);
		}

		protected void UpdateSelectedObjects(PointerEventData eventData)
		{
			bool flag = false;
			foreach (GameObject item in eventData.hovered)
			{
				if (item == eventData.selectedObject)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				eventData.selectedObject = null;
			}
			foreach (GameObject item2 in eventData.hovered)
			{
				if (item2 == null)
				{
					continue;
				}
				gph = item2.GetComponent<Graphic>();
				if (item2.GetComponent<Selectable>() != null && gph != null && gph.depth != -1 && gph.raycastTarget)
				{
					if (eventData.selectedObject != item2)
					{
						eventData.selectedObject = item2;
					}
					break;
				}
			}
			if (mySettings.ControlMethod == CurvedUIInputModule.CUIControlMethod.GAZE && eventData.IsPointerMoving() && eventData.pointerDrag != null && !eventData.dragging && ShouldStartDrag(eventData.pressPosition, eventData.position, EventSystem.current.pixelDragThreshold, eventData.useDragThreshold))
			{
				ExecuteEvents.Execute(eventData.pointerDrag, eventData, ExecuteEvents.beginDragHandler);
				eventData.dragging = true;
			}
		}

		protected void HandlePointerExitAndEnter(PointerEventData currentPointerData, GameObject newEnterTarget)
		{
			if (newEnterTarget == null || currentPointerData.pointerEnter == null)
			{
				for (int i = 0; i < currentPointerData.hovered.Count; i++)
				{
					ExecuteEvents.Execute(currentPointerData.hovered[i], currentPointerData, ExecuteEvents.pointerExitHandler);
				}
				currentPointerData.hovered.Clear();
				if (newEnterTarget == null)
				{
					currentPointerData.pointerEnter = newEnterTarget;
					return;
				}
			}
			if (currentPointerData.pointerEnter == newEnterTarget && (bool)newEnterTarget)
			{
				return;
			}
			GameObject gameObject = FindCommonRoot(currentPointerData.pointerEnter, newEnterTarget);
			if (currentPointerData.pointerEnter != null)
			{
				Transform parent = currentPointerData.pointerEnter.transform;
				while (parent != null && (!(gameObject != null) || !(gameObject.transform == parent)))
				{
					ExecuteEvents.Execute(parent.gameObject, currentPointerData, ExecuteEvents.pointerExitHandler);
					currentPointerData.hovered.Remove(parent.gameObject);
					parent = parent.parent;
				}
			}
			currentPointerData.pointerEnter = newEnterTarget;
			if (newEnterTarget != null)
			{
				Transform parent2 = newEnterTarget.transform;
				while (parent2 != null && parent2.gameObject != gameObject)
				{
					ExecuteEvents.Execute(parent2.gameObject, currentPointerData, ExecuteEvents.pointerEnterHandler);
					currentPointerData.hovered.Add(parent2.gameObject);
					parent2 = parent2.parent;
				}
			}
		}

		protected static GameObject FindCommonRoot(GameObject g1, GameObject g2)
		{
			if (g1 == null || g2 == null)
			{
				return null;
			}
			Transform parent = g1.transform;
			while (parent != null)
			{
				Transform parent2 = g2.transform;
				while (parent2 != null)
				{
					if (parent == parent2)
					{
						return parent.gameObject;
					}
					parent2 = parent2.parent;
				}
				parent = parent.parent;
			}
			return null;
		}

		private bool GetScreenSpacePointByRay(Ray ray, out Vector2 o_positionOnCanvas)
		{
			switch (mySettings.Shape)
			{
			case CurvedUISettings.CurvedUIShape.CYLINDER:
				return RaycastToCyllinderCanvas(ray, out o_positionOnCanvas);
			case CurvedUISettings.CurvedUIShape.CYLINDER_VERTICAL:
				return RaycastToCyllinderVerticalCanvas(ray, out o_positionOnCanvas);
			case CurvedUISettings.CurvedUIShape.RING:
				return RaycastToRingCanvas(ray, out o_positionOnCanvas);
			case CurvedUISettings.CurvedUIShape.SPHERE:
				return RaycastToSphereCanvas(ray, out o_positionOnCanvas);
			default:
				o_positionOnCanvas = Vector2.zero;
				return false;
			}
		}

		private bool CheckEventCamera()
		{
			if (myCanvas.worldCamera == null)
			{
				if ((bool)CurvedUIInputModule.Instance && (bool)CurvedUIInputModule.Instance.EventCamera)
				{
					myCanvas.worldCamera = CurvedUIInputModule.Instance.EventCamera;
				}
				else if ((bool)Camera.main)
				{
					myCanvas.worldCamera = Camera.main;
				}
			}
			return myCanvas.worldCamera != null;
		}

		public void RebuildCollider()
		{
			cyllinderMidPoint = new Vector3(0f, 0f, 0f - mySettings.GetCyllinderRadiusInCanvasSpace());
			CreateCollider();
		}

		public List<GameObject> GetObjectsUnderPointer()
		{
			if (objectsUnderPointer == null)
			{
				objectsUnderPointer = new List<GameObject>();
			}
			return objectsUnderPointer;
		}

		public List<GameObject> GetObjectsUnderScreenPos(Vector2 screenPos, Camera eventCamera = null)
		{
			if (eventCamera == null)
			{
				eventCamera = myCanvas.worldCamera;
			}
			return GetObjectsHitByRay(eventCamera.ScreenPointToRay(screenPos));
		}

		public List<GameObject> GetObjectsHitByRay(Ray ray)
		{
			List<GameObject> list = new List<GameObject>();
			if (!GetScreenSpacePointByRay(ray, out var o_positionOnCanvas))
			{
				return list;
			}
			List<Graphic> list2 = new List<Graphic>();
			IList<Graphic> graphicsForCanvas = GraphicRegistry.GetGraphicsForCanvas(myCanvas);
			for (int i = 0; i < graphicsForCanvas.Count; i++)
			{
				Graphic graphic = graphicsForCanvas[i];
				if (graphic.depth != -1 && graphic.raycastTarget && RectTransformUtility.RectangleContainsScreenPoint(graphic.rectTransform, o_positionOnCanvas, eventCamera) && graphic.Raycast(o_positionOnCanvas, eventCamera))
				{
					list2.Add(graphic);
				}
			}
			list2.Sort((Graphic g1, Graphic g2) => g2.depth.CompareTo(g1.depth));
			for (int num = 0; num < list2.Count; num++)
			{
				list.Add(list2[num].gameObject);
			}
			list2.Clear();
			return list;
		}

		public void Click()
		{
			for (int i = 0; i < GetObjectsUnderPointer().Count; i++)
			{
				if ((bool)GetObjectsUnderPointer()[i].GetComponent<Slider>())
				{
					Slider component = GetObjectsUnderPointer()[i].GetComponent<Slider>();
					RectTransformUtility.ScreenPointToLocalPointInRectangle(component.handleRect.parent as RectTransform, lastFrameEventData.position, myCanvas.worldCamera, out var localPoint);
					localPoint -= component.handleRect.parent.GetComponent<RectTransform>().rect.position;
					if (component.direction == Slider.Direction.LeftToRight || component.direction == Slider.Direction.RightToLeft)
					{
						component.normalizedValue = localPoint.x / (component.handleRect.parent as RectTransform).rect.width;
					}
					else
					{
						component.normalizedValue = localPoint.y / (component.handleRect.parent as RectTransform).rect.height;
					}
					GetObjectsUnderPointer()[i].GetComponent<Slider>().fillRect.GetComponent<Graphic>().SetAllDirty();
				}
				else
				{
					ExecuteEvents.Execute(GetObjectsUnderPointer()[i], lastFrameEventData, ExecuteEvents.pointerDownHandler);
					ExecuteEvents.Execute(GetObjectsUnderPointer()[i], lastFrameEventData, ExecuteEvents.pointerClickHandler);
					ExecuteEvents.Execute(GetObjectsUnderPointer()[i], lastFrameEventData, ExecuteEvents.pointerUpHandler);
				}
			}
		}

		private void ModifyQuad(List<Vector3> verts, int vertexIndex, Vector2 requiredSize)
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < 4; i++)
			{
				list.Add(verts[vertexIndex + i]);
			}
			Vector3 vector = list[2] - list[1];
			Vector3 vector2 = list[1] - list[0];
			int num = Mathf.CeilToInt(vector.magnitude * (1f / Mathf.Max(1f, requiredSize.x)));
			int num2 = Mathf.CeilToInt(vector2.magnitude * (1f / Mathf.Max(1f, requiredSize.y)));
			float y = 0f;
			for (int j = 0; j < num2; j++)
			{
				float num3 = ((float)j + 1f) / (float)num2;
				float x = 0f;
				for (int k = 0; k < num; k++)
				{
					float num4 = ((float)k + 1f) / (float)num;
					verts.Add(TesselateQuad(list, x, y));
					verts.Add(TesselateQuad(list, x, num3));
					verts.Add(TesselateQuad(list, num4, num3));
					verts.Add(TesselateQuad(list, num4, y));
					x = num4;
				}
				y = num3;
			}
		}

		private Vector3 TesselateQuad(List<Vector3> quad, float x, float y)
		{
			Vector3 zero = Vector3.zero;
			List<float> list = new List<float>
			{
				(1f - x) * (1f - y),
				(1f - x) * y,
				x * y,
				x * (1f - y)
			};
			for (int i = 0; i < 4; i++)
			{
				zero += quad[i] * list[i];
			}
			return zero;
		}
	}
}
