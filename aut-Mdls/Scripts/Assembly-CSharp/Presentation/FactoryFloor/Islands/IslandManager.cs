#define ENABLE_DEBUG_ERRORS
using Data.FactoryFloor.Maps;
using Events;
using Events.Islands;
using Presentation.Locators;
using UnityEngine;
using Utils;

namespace Presentation.FactoryFloor.Islands
{
	public class IslandManager : MonoBehaviour
	{
		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private CameraLocator _cameraLocator;

		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		[SerializeField]
		private IslandCullStateChangedEventSO _islandCullStateChangedEvent;

		private bool _islandCullingEnabled = true;

		private Transform _cameraTransform;

		private void Start()
		{
			_finishedLoadingSaveEvent.Register(InitalizeIslandEventHandlers);
		}

		private void InitalizeIslandEventHandlers()
		{
			foreach (IslandObject allIsland in _islandLayer.GetAllIslands())
			{
				allIsland.OnIslandChangedCullingState += OnIslandCullStateChanged;
			}
		}

		private void OnDestroy()
		{
			_finishedLoadingSaveEvent.UnRegister(InitalizeIslandEventHandlers);
			foreach (IslandObject allIsland in _islandLayer.GetAllIslands())
			{
				allIsland.OnIslandChangedCullingState -= OnIslandCullStateChanged;
			}
		}

		private void Update()
		{
			UpdateIslandCulling();
		}

		private void UpdateIslandCulling()
		{
			if (!_islandCullingEnabled)
			{
				return;
			}
			if (_cameraTransform == null)
			{
				if (_cameraLocator == null)
				{
					this.LogError("Cannot locate camera for UpdateIslandCulling in IslandManager.", "UpdateIslandCulling", 57);
					_islandCullingEnabled = false;
					return;
				}
				_cameraTransform = _cameraLocator.Camera.transform;
			}
			foreach (IslandObject allIsland in _islandLayer.GetAllIslands())
			{
				allIsland?.EvaluateCullingState(_cameraTransform.position);
			}
		}

		private void OnIslandCullStateChanged(IslandObject island)
		{
			_islandCullStateChangedEvent.Fire(island);
		}
	}
}
