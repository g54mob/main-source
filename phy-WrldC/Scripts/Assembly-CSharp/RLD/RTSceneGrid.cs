using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class RTSceneGrid : MonoSingleton<RTSceneGrid>, IXZGrid
	{
		private enum SnapToPointMode
		{
			Exact = 0,
			ClosestExtremity = 1
		}

		[SerializeField]
		private SceneGridHotkeys _hotkeys = new SceneGridHotkeys();

		[SerializeField]
		private XZGridSettings _settings = new XZGridSettings();

		[SerializeField]
		private XZGridLookAndFeel _lookAndFeel = new XZGridLookAndFeel();

		private List<Camera> _renderIgnoreCameras = new List<Camera>();

		public Quaternion Rotation => Quaternion.Euler(Settings.RotationAngles);

		public Vector3 Right => Rotation * Vector3.right;

		public Vector3 Look => Rotation * Vector3.forward;

		public Vector3 Normal => Rotation * Vector3.up;

		public Plane WorldPlane => new Plane(Normal, Normal * YOffset);

		public Matrix4x4 WorldMatrix => Matrix4x4.TRS(Normal * YOffset, Rotation, Vector3.one);

		public float YOffset
		{
			get
			{
				return Settings.YOffset;
			}
			set
			{
				Settings.YOffset = value;
			}
		}

		public SceneGridHotkeys Hotkeys => _hotkeys;

		public XZGridSettings Settings => _settings;

		public XZGridLookAndFeel LookAndFeel => _lookAndFeel;

		public void Initialize_SystemCall()
		{
			MonoSingleton<RTInputDevice>.Get.Device.DoubleTap += OnInputDeviceDoubleTap;
		}

		public bool IsRenderIgnoreCamera(Camera camera)
		{
			return _renderIgnoreCameras.Contains(camera);
		}

		public void AddRenderIgnoreCamera(Camera camera)
		{
			if (!IsRenderIgnoreCamera(camera))
			{
				_renderIgnoreCameras.Add(camera);
			}
		}

		public void RemoveRenderIgnoreCamera(Camera camera)
		{
			_renderIgnoreCameras.Remove(camera);
		}

		public XZGridCell CellFromWorldPoint(Vector3 worldPoint)
		{
			return XZGridCell.FromPoint(worldPoint, _settings.CellSizeX, _settings.CellSizeZ, this);
		}

		public bool Raycast(Ray ray, out float t)
		{
			return WorldPlane.Raycast(ray, out t);
		}

		public void Update_SystemCall()
		{
			if (!Settings.IsVisible)
			{
				return;
			}
			if (Hotkeys.GridUp.IsActiveInFrame())
			{
				MoveUp();
			}
			else if (Hotkeys.GridDown.IsActiveInFrame())
			{
				MoveDown();
			}
			if (!MonoSingleton<RTInputDevice>.Get.Device.DidDoubleTap && MonoSingleton<RTInputDevice>.Get.Device.WasButtonPressedInCurrentFrame(0) && Hotkeys.SnapToCursorPickPoint.IsActive())
			{
				SceneRaycastHit sceneHitForGridSnap = GetSceneHitForGridSnap();
				if (sceneHitForGridSnap.WasAnObjectHit)
				{
					SnapToObjectHitPoint(sceneHitForGridSnap.ObjectHit, SnapToPointMode.Exact);
				}
			}
		}

		public void Render_SystemCall()
		{
			if (!Settings.IsVisible)
			{
				return;
			}
			Camera current = Camera.current;
			if (IsRenderIgnoreCamera(current))
			{
				return;
			}
			AABB aABB = current.CalculateVolumeAABB();
			Vector3 pos = WorldPlane.ProjectPoint(aABB.Center);
			Vector3 s = aABB.Size * 2f;
			s.y = 1f;
			Matrix4x4 matrix4x = Matrix4x4.TRS(pos, Rotation, s);
			if (LookAndFeel.UseCellFading)
			{
				float num = CalculateCellFadeZoom(current);
				int num2 = MathEx.GetNumDigits((int)num) - 1;
				int num3 = num2 + 1;
				float num4 = Mathf.Pow(10f, num2);
				float num5 = Mathf.Pow(10f, num3);
				Color lineColor = LookAndFeel.LineColor;
				float num6 = (num5 - num) / (num5 - num4);
				float num7 = 1f - num6;
				Material xZGrid_Plane = Singleton<MaterialPool>.Get.XZGrid_Plane;
				xZGrid_Plane.SetFloat("_CamFarPlaneDist", current.farClipPlane);
				xZGrid_Plane.SetVector("_CamWorldPos", current.transform.position);
				xZGrid_Plane.SetVector("_GridOrigin", Vector3.zero);
				xZGrid_Plane.SetVector("_GridRight", Right);
				xZGrid_Plane.SetVector("_GridLook", Look);
				xZGrid_Plane.SetMatrix("_TransformMatrix", matrix4x);
				lineColor.a = LookAndFeel.LineColor.a * num6;
				if (lineColor.a != 0f)
				{
					xZGrid_Plane.SetFloat("_CellSizeX", Settings.CellSizeX * num4);
					xZGrid_Plane.SetFloat("_CellSizeZ", Settings.CellSizeZ * num4);
					xZGrid_Plane.SetColor("_LineColor", lineColor);
					xZGrid_Plane.SetPass(0);
					Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitQuadXZ, matrix4x);
				}
				lineColor.a = LookAndFeel.LineColor.a * num7;
				if (lineColor.a != 0f)
				{
					xZGrid_Plane.SetFloat("_CellSizeX", Settings.CellSizeX * num5);
					xZGrid_Plane.SetFloat("_CellSizeZ", Settings.CellSizeZ * num5);
					xZGrid_Plane.SetColor("_LineColor", lineColor);
					xZGrid_Plane.SetPass(0);
					Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitQuadXZ, matrix4x);
				}
			}
			else
			{
				Material xZGrid_Plane2 = Singleton<MaterialPool>.Get.XZGrid_Plane;
				xZGrid_Plane2.SetFloat("_CamFarPlaneDist", current.farClipPlane);
				xZGrid_Plane2.SetVector("_CamWorldPos", current.transform.position);
				xZGrid_Plane2.SetMatrix("_TransformMatrix", matrix4x);
				xZGrid_Plane2.SetFloat("_CellSizeX", Settings.CellSizeX);
				xZGrid_Plane2.SetFloat("_CellSizeZ", Settings.CellSizeZ);
				xZGrid_Plane2.SetColor("_LineColor", LookAndFeel.LineColor);
				xZGrid_Plane2.SetVector("_GridOrigin", Vector3.zero);
				xZGrid_Plane2.SetVector("_GridRight", Right);
				xZGrid_Plane2.SetVector("_GridLook", Look);
				xZGrid_Plane2.SetPass(0);
				Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitQuadXZ, matrix4x);
			}
		}

		private void MoveUp()
		{
			if (Settings.IsVisible)
			{
				YOffset += Settings.UpDownStep;
			}
		}

		private void MoveDown()
		{
			if (Settings.IsVisible)
			{
				YOffset -= Settings.UpDownStep;
			}
		}

		private float CalculateCellFadeZoom(Camera camera)
		{
			return WorldPlane.GetAbsDistanceToPoint(camera.transform.position);
		}

		private SceneRaycastHit GetSceneHitForGridSnap()
		{
			Ray ray = MonoSingleton<RTInputDevice>.Get.Device.GetRay(MonoSingleton<RTFocusCamera>.Get.TargetCamera);
			SceneRaycastFilter sceneRaycastFilter = new SceneRaycastFilter();
			sceneRaycastFilter.AllowedObjectTypes.Add(GameObjectType.Mesh);
			return MonoSingleton<RTScene>.Get.Raycast(ray, SceneRaycastPrecision.BestFit, sceneRaycastFilter);
		}

		private void OnInputDeviceDoubleTap(IInputDevice inputDevice, Vector2 position)
		{
			if (Hotkeys.SnapToCursorPickPoint.IsActive())
			{
				SceneRaycastHit sceneHitForGridSnap = GetSceneHitForGridSnap();
				if (sceneHitForGridSnap.WasAnObjectHit)
				{
					SnapToObjectHitPoint(sceneHitForGridSnap.ObjectHit, SnapToPointMode.ClosestExtremity);
				}
			}
		}

		private void SnapToObjectHitPoint(GameObjectRayHit objectHit, SnapToPointMode snapMode)
		{
			if (snapMode == SnapToPointMode.Exact)
			{
				float distanceToPoint = new Plane(Normal, Vector3.zero).GetDistanceToPoint(objectHit.HitPoint);
				YOffset = distanceToPoint;
				return;
			}
			OBB oBB = ObjectBounds.CalcWorldOBB(queryConfig: new ObjectBounds.QueryConfig
			{
				ObjectTypes = GameObjectType.Mesh
			}, gameObject: objectHit.HitObject);
			if (!oBB.IsValid)
			{
				return;
			}
			Plane plane = new Plane(Normal, oBB.Center);
			Vector3 point = oBB.Center;
			List<Vector3> list = BoxMath.CalcBoxCornerPoints(oBB.Center, oBB.Size, oBB.Rotation);
			if (Mathf.Sign(plane.GetDistanceToPoint(objectHit.HitPoint)) > 0f)
			{
				int furthestPtInFront = plane.GetFurthestPtInFront(list);
				if (furthestPtInFront >= 0)
				{
					point = list[furthestPtInFront];
				}
			}
			else
			{
				int furthestPtBehind = plane.GetFurthestPtBehind(list);
				if (furthestPtBehind >= 0)
				{
					point = list[furthestPtBehind];
				}
			}
			float distanceToPoint2 = new Plane(Normal, Vector3.zero).GetDistanceToPoint(point);
			YOffset = distanceToPoint2;
		}
	}
}
