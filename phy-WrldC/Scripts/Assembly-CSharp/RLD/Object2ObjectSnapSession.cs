using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class Object2ObjectSnapSession
	{
		private enum State
		{
			Inactive = 0,
			Active = 1
		}

		private enum SitSurfaceType
		{
			Invalid = 0,
			Grid = 1,
			Object = 2
		}

		private struct SitSurface
		{
			public SitSurfaceType SurfaceType;

			public Vector3 SitPoint;

			public Plane SitPlane;
		}

		private State _state;

		private List<GameObject> _targetObjects;

		private List<GameObject> _targetParents;

		private AABB _targetAABB;

		private SitSurface _sitSurface;

		private bool _sitBelowSurface;

		private Object2ObjectSnapSettings _sharedSettings;

		private Object2ObjectSnapHotkeys _sharedHotkeys;

		private List<LocalTransformSnapshot> _preTargetTransformSnapshots;

		public Object2ObjectSnapSettings SharedSettings
		{
			get
			{
				return _sharedSettings;
			}
			set
			{
				if (value != null)
				{
					_sharedSettings = value;
				}
			}
		}

		public Object2ObjectSnapHotkeys SharedHotkeys
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

		public bool IsActive => _state != State.Inactive;

		public event Object2ObjectSnapSessionBeginHandler SessionBegin;

		public event Object2ObjectSnapSessionEndHandler SessionEnd;

		public void Update(IEnumerable<GameObject> targetObjects)
		{
			if (SharedHotkeys == null || SharedSettings == null)
			{
				return;
			}
			if (_state == State.Inactive)
			{
				if (SharedHotkeys.ToggleSnap.IsActiveInFrame())
				{
					Begin(targetObjects);
				}
			}
			else if (SharedHotkeys.ToggleSnap.IsActiveInFrame())
			{
				End();
			}
			if (IsActive)
			{
				if (SharedHotkeys.ToggleSitBelowSurface.IsActiveInFrame())
				{
					_sitBelowSurface = !_sitBelowSurface;
				}
				if (MonoSingleton<RTInputDevice>.Get.Device.WasMoved() && IdentifySitSurface())
				{
					SnapTargets();
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
			if (_state != State.Inactive || SharedSettings == null || SharedHotkeys == null || targetObjects == null)
			{
				return false;
			}
			_targetObjects = new List<GameObject>(targetObjects);
			if (_targetObjects.Count == 0)
			{
				return false;
			}
			_targetParents = GameObjectEx.FilterParentsOnly(_targetObjects);
			if (!CalculateTargetAABB() || !IdentifySitSurface())
			{
				_targetObjects.Clear();
				_targetParents.Clear();
				return false;
			}
			_state = State.Active;
			_preTargetTransformSnapshots = LocalTransformSnapshot.GetSnapshotCollection(_targetParents);
			if (this.SessionBegin != null)
			{
				this.SessionBegin();
			}
			return true;
		}

		private void SnapTargets()
		{
			if (!CalculateTargetAABB())
			{
				return;
			}
			Vector3 center = _targetAABB.Center;
			_targetAABB.Center = _sitSurface.SitPoint;
			Plane plane = _sitSurface.SitPlane;
			if (_sitBelowSurface)
			{
				plane = plane.InvertNormal();
			}
			Vector3 vector = ObjectSurfaceSnap.CalculateSitOnSurfaceOffset(_targetAABB, plane, 0f);
			_targetAABB.Center += vector;
			Vector3 vector2 = _targetAABB.Center - center;
			foreach (GameObject targetParent in _targetParents)
			{
				targetParent.transform.position += vector2;
			}
			if (SharedHotkeys.EnableFlexiSnap.IsActive())
			{
				return;
			}
			Object2ObjectSnap.Config snapConfig = default(Object2ObjectSnap.Config);
			snapConfig.Prefs = ((!SharedHotkeys.EnableMoreControl.IsActive()) ? Object2ObjectSnap.Prefs.TryMatchArea : Object2ObjectSnap.Prefs.None);
			snapConfig.AreaMatchEps = 0.01f;
			snapConfig.SnapRadius = SharedSettings.SnapRadius;
			snapConfig.DestinationLayers = SharedSettings.SnapDestinationLayers;
			snapConfig.IgnoreDestObjects = new List<GameObject>();
			snapConfig.IgnoreDestObjects.AddRange(_targetParents);
			foreach (GameObject targetParent2 in _targetParents)
			{
				snapConfig.IgnoreDestObjects.AddRange(targetParent2.GetAllChildren());
			}
			Object2ObjectSnap.Snap(_targetParents, snapConfig);
		}

		private bool CalculateTargetAABB()
		{
			_targetAABB = ObjectBounds.CalcHierarchyCollectionWorldAABB(queryConfig: new ObjectBounds.QueryConfig
			{
				ObjectTypes = (GameObjectType.Mesh | GameObjectType.Sprite)
			}, roots: _targetParents);
			return _targetAABB.IsValid;
		}

		private bool IdentifySitSurface()
		{
			_sitSurface.SurfaceType = SitSurfaceType.Invalid;
			SceneRaycastFilter sceneRaycastFilter = new SceneRaycastFilter();
			if (SharedSettings.CanClimbObjects)
			{
				sceneRaycastFilter.AllowedObjectTypes.Add(GameObjectType.Mesh);
			}
			foreach (GameObject targetParent in _targetParents)
			{
				sceneRaycastFilter.IgnoreObjects.AddRange(targetParent.GetAllChildrenAndSelf());
			}
			IInputDevice device = MonoSingleton<RTInputDevice>.Get.Device;
			SceneRaycastHit sceneRaycastHit = MonoSingleton<RTScene>.Get.Raycast(device.GetRay(MonoSingleton<RTFocusCamera>.Get.TargetCamera), SceneRaycastPrecision.BestFit, sceneRaycastFilter);
			if (!sceneRaycastHit.WasAnythingHit)
			{
				return false;
			}
			if (sceneRaycastHit.WasAnObjectHit && sceneRaycastHit.WasGridHit)
			{
				if (sceneRaycastHit.ObjectHit.HitEnter < sceneRaycastHit.GridHit.HitEnter)
				{
					_sitSurface.SitPlane = sceneRaycastHit.ObjectHit.HitPlane;
					_sitSurface.SitPoint = sceneRaycastHit.ObjectHit.HitPoint;
					_sitSurface.SurfaceType = SitSurfaceType.Object;
				}
				else
				{
					_sitSurface.SitPlane = sceneRaycastHit.GridHit.HitPlane;
					_sitSurface.SitPoint = sceneRaycastHit.GridHit.HitPoint;
					_sitSurface.SurfaceType = SitSurfaceType.Grid;
				}
			}
			else if (sceneRaycastHit.WasAnObjectHit)
			{
				_sitSurface.SitPlane = sceneRaycastHit.ObjectHit.HitPlane;
				_sitSurface.SitPoint = sceneRaycastHit.ObjectHit.HitPoint;
				_sitSurface.SurfaceType = SitSurfaceType.Object;
			}
			else if (sceneRaycastHit.WasGridHit)
			{
				_sitSurface.SitPlane = sceneRaycastHit.GridHit.HitPlane;
				_sitSurface.SitPoint = sceneRaycastHit.GridHit.HitPoint;
				_sitSurface.SurfaceType = SitSurfaceType.Grid;
			}
			return true;
		}
	}
}
