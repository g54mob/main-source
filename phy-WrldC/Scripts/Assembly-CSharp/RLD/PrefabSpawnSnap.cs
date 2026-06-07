using UnityEngine;

namespace RLD
{
	public class PrefabSpawnSnap : MonoBehaviour
	{
		private bool _isSnapSessionActive;

		private GameObject _targetHierarchy;

		private ObjectSurfaceSnap.SnapConfig _snapConfig;

		private int _objectSurfaceLayers = -1;

		private void Awake()
		{
			_snapConfig.AlignAxis = true;
			_snapConfig.AlignmentAxis = TransformAxis.PositiveY;
			MonoSingleton<RLDApp>.Get.Initialized += OnAppInitialized;
		}

		private void Update()
		{
			if (!_isSnapSessionActive)
			{
				return;
			}
			if (EvaluateSessionEndCondition())
			{
				EndSnapSession();
				return;
			}
			IInputDevice device = MonoSingleton<RTInputDevice>.Get.Device;
			if (device.WasMoved())
			{
				OnInputDeviceMoved(device);
			}
		}

		private bool EvaluateSessionEndCondition()
		{
			if (MonoSingleton<RTInputDevice>.Get.Device.WasButtonPressedInCurrentFrame(0))
			{
				return true;
			}
			return false;
		}

		private void OnInputDeviceMoved(IInputDevice inputDevice)
		{
			SceneRaycastFilter sceneRaycastFilter = new SceneRaycastFilter();
			sceneRaycastFilter.LayerMask = _objectSurfaceLayers;
			sceneRaycastFilter.AllowedObjectTypes.Add(GameObjectType.Mesh);
			sceneRaycastFilter.AllowedObjectTypes.Add(GameObjectType.Terrain);
			sceneRaycastFilter.IgnoreObjects.AddRange(_targetHierarchy.GetAllChildrenAndSelf());
			SceneRaycastHit sceneRaycastHit = MonoSingleton<RTScene>.Get.Raycast(inputDevice.GetRay(MonoSingleton<RTFocusCamera>.Get.TargetCamera), SceneRaycastPrecision.BestFit, sceneRaycastFilter);
			if (!sceneRaycastHit.WasAnythingHit)
			{
				return;
			}
			if (sceneRaycastHit.WasAnObjectHit)
			{
				GameObjectType gameObjectType = sceneRaycastHit.ObjectHit.HitObject.GetGameObjectType();
				if (gameObjectType != GameObjectType.Mesh && gameObjectType != GameObjectType.Terrain)
				{
					return;
				}
				_snapConfig.SurfaceHitNormal = sceneRaycastHit.ObjectHit.HitNormal;
				_snapConfig.SurfaceHitPlane = sceneRaycastHit.ObjectHit.HitPlane;
				_snapConfig.SurfaceHitPoint = sceneRaycastHit.ObjectHit.HitPoint;
				_snapConfig.SurfaceObject = sceneRaycastHit.ObjectHit.HitObject;
				_snapConfig.SurfaceType = ((gameObjectType == GameObjectType.Mesh) ? ObjectSurfaceSnap.Type.Mesh : ObjectSurfaceSnap.Type.UnityTerrain);
			}
			else
			{
				_snapConfig.SurfaceHitNormal = sceneRaycastHit.GridHit.HitNormal;
				_snapConfig.SurfaceHitPlane = sceneRaycastHit.GridHit.HitPlane;
				_snapConfig.SurfaceHitPoint = sceneRaycastHit.GridHit.HitPoint;
				_snapConfig.SurfaceType = ObjectSurfaceSnap.Type.SceneGrid;
			}
			_targetHierarchy.transform.position = _snapConfig.SurfaceHitPoint;
			ObjectSurfaceSnap.SnapHierarchy(_targetHierarchy, _snapConfig);
		}

		private void BeginSnapSession(GameObject targetHierarchy)
		{
			_isSnapSessionActive = true;
			_targetHierarchy = targetHierarchy;
		}

		private void EndSnapSession()
		{
			_targetHierarchy = null;
			_isSnapSessionActive = false;
		}

		private void OnAppInitialized()
		{
			MonoSingleton<RTPrefabLibDb>.Get.PrefabSpawned += OnPrefabSpawned;
			MonoSingleton<RTObjectSelection>.Get.CanClickSelectDeselect += OnCanChangeObjectSelection;
			MonoSingleton<RTObjectSelection>.Get.CanMultiSelectDeselect += OnCanChangeObjectSelection;
		}

		private void OnPrefabSpawned(RTPrefab prefab, GameObject spawnedObject)
		{
			BeginSnapSession(spawnedObject);
		}

		private void OnCanChangeObjectSelection(YesNoAnswer answer)
		{
			if (_isSnapSessionActive)
			{
				answer.No();
			}
			else
			{
				answer.Yes();
			}
		}
	}
}
