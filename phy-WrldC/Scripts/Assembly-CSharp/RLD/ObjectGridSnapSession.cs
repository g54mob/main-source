using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class ObjectGridSnapSession
	{
		private enum State
		{
			Inactive = 0,
			SelectPivot = 1,
			Snap = 2
		}

		private List<GameObject> _targetParents = new List<GameObject>();

		private List<GameObject> _targetObjects = new List<GameObject>();

		private List<LocalTransformSnapshot> _preTargetTransformSnapshots;

		private Vector3 _snapPivotPoint;

		private State _state;

		private ObjectGridSnapHotkeys _sharedHotkeys;

		private ObjectGridSnapLookAndFeel _sharedLookAndFeel;

		public bool IsActive => _state != State.Inactive;

		public ObjectGridSnapLookAndFeel SharedLookAndFeel
		{
			get
			{
				return _sharedLookAndFeel;
			}
			set
			{
				if (value != null)
				{
					_sharedLookAndFeel = value;
				}
			}
		}

		public ObjectGridSnapHotkeys SharedHotkeys
		{
			get
			{
				return _sharedHotkeys;
			}
			set
			{
				if (value != null)
				{
					_sharedHotkeys = value;
				}
			}
		}

		public event ObjectGridSnapSessionBeginHandler SessionBegin;

		public event ObjectGridSnapSessionEndHandler SessionEnd;

		public void Render()
		{
			if (_sharedLookAndFeel == null || !IsActive)
			{
				return;
			}
			Material simpleColor = Singleton<MaterialPool>.Get.SimpleColor;
			if (_sharedLookAndFeel.DrawBoxes)
			{
				simpleColor.SetColor(_sharedLookAndFeel.BoxLineColor);
				simpleColor.SetZTestEnabled(enabled: true);
				simpleColor.SetPass(0);
				ObjectBounds.QueryConfig objectBoundsQConfig = GetObjectBoundsQConfig();
				foreach (GameObject targetObject in _targetObjects)
				{
					if (!(targetObject == null))
					{
						OBB box = ObjectBounds.CalcWorldOBB(targetObject, objectBoundsQConfig);
						if (box.IsValid)
						{
							GraphicsEx.DrawWireBox(box);
						}
					}
				}
			}
			Camera current2 = Camera.current;
			Vector2 vector = current2.WorldToScreenPoint(_snapPivotPoint);
			if (_sharedLookAndFeel.PivotShapeType == PivotPointShapeType.Circle)
			{
				simpleColor.SetZTestEnabled(enabled: false);
				simpleColor.SetColor(_sharedLookAndFeel.PivotPointFillColor);
				simpleColor.SetPass(0);
				List<Vector2> list = PrimitiveFactory.Generate2DCircleBorderPointsCW(vector, _sharedLookAndFeel.PivotCircleRadius, 100);
				GLRenderer.DrawTriangleFan2D(vector, list, current2);
				if (_sharedLookAndFeel.DrawPivotBorder)
				{
					simpleColor.SetColor(_sharedLookAndFeel.PivotPointBorderColor);
					simpleColor.SetPass(0);
					GLRenderer.DrawLineLoop2D(list, current2);
				}
			}
			else if (_sharedLookAndFeel.PivotShapeType == PivotPointShapeType.Square)
			{
				simpleColor.SetZTestEnabled(enabled: false);
				simpleColor.SetColor(_sharedLookAndFeel.PivotPointFillColor);
				simpleColor.SetPass(0);
				Rect rect = RectEx.FromCenterAndSize(vector, Vector2Ex.FromValue(_sharedLookAndFeel.PivotSquareSideLength));
				GLRenderer.DrawRect2D(rect, current2);
				if (_sharedLookAndFeel.DrawPivotBorder)
				{
					simpleColor.SetColor(_sharedLookAndFeel.PivotPointBorderColor);
					simpleColor.SetPass(0);
					GLRenderer.DrawRectBorder2D(rect, current2);
				}
			}
		}

		public void Update(IEnumerable<GameObject> targetObjects)
		{
			if (_sharedHotkeys == null)
			{
				return;
			}
			if (_state == State.Inactive)
			{
				if (_sharedHotkeys.BeginGridSnap.IsActive())
				{
					Begin(targetObjects);
				}
			}
			else if (!_sharedHotkeys.BeginGridSnap.IsActive())
			{
				End();
			}
			if (_state != State.Inactive)
			{
				if (MonoSingleton<RTInputDevice>.Get.Device.IsButtonPressed(0))
				{
					_state = State.Snap;
				}
				else
				{
					_state = State.SelectPivot;
				}
				if (_state == State.SelectPivot)
				{
					SelectPivot();
				}
				else if (_state == State.Snap)
				{
					Snap();
				}
			}
		}

		public void End()
		{
			if (_state != State.Inactive)
			{
				_targetObjects.Clear();
				_state = State.Inactive;
				new PostObjectTransformsChangedAction(_preTargetTransformSnapshots, LocalTransformSnapshot.GetSnapshotCollection(_targetParents)).Execute();
				_targetParents.Clear();
				if (this.SessionEnd != null)
				{
					this.SessionEnd();
				}
			}
		}

		private bool Begin(IEnumerable<GameObject> targetObjects)
		{
			if (_state != State.Inactive || _sharedHotkeys == null || targetObjects == null)
			{
				return false;
			}
			if (!IdentifyTargetParents(targetObjects) || !IdentifyTargetObjects(targetObjects))
			{
				_targetParents.Clear();
				_targetObjects.Clear();
				return false;
			}
			_state = State.SelectPivot;
			_preTargetTransformSnapshots = LocalTransformSnapshot.GetSnapshotCollection(_targetParents);
			if (this.SessionBegin != null)
			{
				this.SessionBegin();
			}
			return true;
		}

		private bool IdentifyTargetParents(IEnumerable<GameObject> targetObjects)
		{
			_targetParents = GameObjectEx.FilterParentsOnly(targetObjects);
			if (_targetParents == null || _targetParents.Count == 0)
			{
				return false;
			}
			return true;
		}

		private bool IdentifyTargetObjects(IEnumerable<GameObject> targetObjects)
		{
			_targetObjects.Clear();
			foreach (GameObject targetObject in targetObjects)
			{
				if (!(targetObject == null) && (!(targetObject.GetMesh() == null) || !(targetObject.GetSprite() == null)))
				{
					_targetObjects.Add(targetObject);
				}
			}
			return _targetObjects.Count != 0;
		}

		private void SelectPivot()
		{
			if (!MonoSingleton<RTInputDevice>.Get.Device.HasPointer())
			{
				return;
			}
			ObjectBounds.QueryConfig objectBoundsQConfig = GetObjectBoundsQConfig();
			Vector2 vector = MonoSingleton<RTInputDevice>.Get.Device.GetPositionYAxisUp();
			float num = float.MaxValue;
			foreach (GameObject targetObject in _targetObjects)
			{
				if (targetObject == null)
				{
					continue;
				}
				OBB oBB = ObjectBounds.CalcWorldOBB(targetObject, objectBoundsQConfig);
				if (!oBB.IsValid)
				{
					continue;
				}
				Camera targetCamera = MonoSingleton<RTFocusCamera>.Get.TargetCamera;
				List<Vector3> centerAndCornerPoints = oBB.GetCenterAndCornerPoints();
				List<Vector2> list = targetCamera.ConvertWorldToScreenPoints(centerAndCornerPoints);
				for (int i = 0; i < list.Count; i++)
				{
					float magnitude = (vector - list[i]).magnitude;
					if (magnitude < num)
					{
						num = magnitude;
						_snapPivotPoint = centerAndCornerPoints[i];
					}
				}
			}
		}

		private ObjectBounds.QueryConfig GetObjectBoundsQConfig()
		{
			return new ObjectBounds.QueryConfig
			{
				ObjectTypes = (GameObjectType.Mesh | GameObjectType.Sprite)
			};
		}

		private void Snap()
		{
			Camera targetCamera = MonoSingleton<RTFocusCamera>.Get.TargetCamera;
			XZGridRayHit xZGridRayHit = MonoSingleton<RTScene>.Get.RaycastSceneGridIfVisible(MonoSingleton<RTInputDevice>.Get.Device.GetRay(targetCamera));
			if (xZGridRayHit == null)
			{
				return;
			}
			List<Vector3> centerAndCorners = xZGridRayHit.HitCell.GetCenterAndCorners();
			int pointClosestToPoint = Vector3Ex.GetPointClosestToPoint(centerAndCorners, xZGridRayHit.HitPoint);
			if (pointClosestToPoint < 0)
			{
				return;
			}
			Vector3 vector = centerAndCorners[pointClosestToPoint] - _snapPivotPoint;
			foreach (GameObject targetParent in _targetParents)
			{
				if (!(targetParent == null))
				{
					targetParent.transform.position += vector;
				}
			}
			_snapPivotPoint += vector;
		}
	}
}
