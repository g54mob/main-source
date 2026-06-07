using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Buildings;
using Data.FactoryFloor.Maps;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.Buildings
{
	public class BuildingOverclockReceiverView : MonoBehaviour
	{
		[SerializeField]
		private GameObject _receiverGameObject;

		[SerializeField]
		private List<GameObject> _boostedReceiverEffects = new List<GameObject>();

		[SerializeField]
		private IslandLayer _islandLayer;

		private Vector3Int _position;

		private FactoryObjectView _objectView;

		private bool _initialized;

		private IslandOverclockData _overclockData;

		private List<OverclockStationBehaviour> _linkedOverclockStations = new List<OverclockStationBehaviour>();

		private Renderer _receiverRenderer;

		private Material _receiverInactiveMaterial;

		private Material _receiverActiveMaterial;

		private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

		public void SetObjectView(FactoryObjectView objectView)
		{
			if (_objectView != null)
			{
				_objectView.FactoryObjectSet -= OnFactoryObjectSet;
				_objectView.FactoryObjectReset -= ObjectViewOnFactoryObjectReset;
			}
			_objectView = objectView;
			_objectView.FactoryObjectSet += OnFactoryObjectSet;
			_objectView.FactoryObjectReset += ObjectViewOnFactoryObjectReset;
			if (_objectView.FactoryObject != null)
			{
				OnFactoryObjectSet(_objectView.FactoryObject, isGameLoading: false);
			}
		}

		private void OnFactoryObjectSet(FactoryObject factoryObject, bool isGameLoading)
		{
			if (_initialized)
			{
				_overclockData.OnIslandOverclockStationsAdded.UnRegisterMainThread(OnOverclockStationAdded);
				_overclockData.OnIslandOverclockStationsRemoved.UnRegisterMainThread(OnOverclockStationsRemoved);
			}
			_position = factoryObject.Position;
			if (_islandLayer.TryGetIslandAtWorldPosition(_position, out var islandObject))
			{
				_initialized = true;
				SetupReceiverMaterials();
				RegisterToOverclockStations(islandObject);
				SetReceiverState();
			}
		}

		private void SetupReceiverMaterials()
		{
			_receiverRenderer = _receiverGameObject.GetComponent<Renderer>();
			_receiverActiveMaterial = _receiverRenderer.sharedMaterial;
			_receiverInactiveMaterial = Object.Instantiate(_receiverActiveMaterial);
			_receiverInactiveMaterial.SetColor(EmissionColor, Color.black);
		}

		private void RegisterToOverclockStations(IslandObject islandObject)
		{
			_overclockData = islandObject.OverclockData;
			_overclockData.OnIslandOverclockStationsAdded.RegisterMainThread(OnOverclockStationAdded);
			_overclockData.OnIslandOverclockStationsRemoved.RegisterMainThread(OnOverclockStationsRemoved);
			foreach (OverclockStationBehaviour item in _overclockData.OverclockStationsOnIsland)
			{
				RegisterToOverclockStateChange(item);
			}
		}

		private void ObjectViewOnFactoryObjectReset(FactoryObjectView _)
		{
			_receiverGameObject.SetActive(value: false);
			if (_initialized)
			{
				_overclockData.OnIslandOverclockStationsAdded.UnRegisterMainThread(OnOverclockStationAdded);
				_overclockData.OnIslandOverclockStationsRemoved.UnRegisterMainThread(OnOverclockStationsRemoved);
			}
			foreach (OverclockStationBehaviour linkedOverclockStation in _linkedOverclockStations)
			{
				linkedOverclockStation.OnOverclockActivationStart.UnRegisterMainThread(SetReceiverState);
				linkedOverclockStation.OnOverclockActivationEnd.UnRegisterMainThread(SetReceiverState);
			}
			_linkedOverclockStations.Clear();
			_overclockData = null;
			_objectView.FactoryObjectSet -= OnFactoryObjectSet;
			_objectView.FactoryObjectReset -= ObjectViewOnFactoryObjectReset;
			_initialized = false;
			_objectView = null;
		}

		private void OnOverclockStationAdded(OverclockStationBehaviour overclockBehaviour)
		{
			if (_initialized)
			{
				RegisterToOverclockStateChange(overclockBehaviour);
				SetReceiverState();
			}
		}

		private void RegisterToOverclockStateChange(OverclockStationBehaviour overclockBehaviour)
		{
			overclockBehaviour.OnOverclockActivationStart.RegisterMainThread(SetReceiverState);
			overclockBehaviour.OnOverclockActivationEnd.RegisterMainThread(SetReceiverState);
			_linkedOverclockStations.Add(overclockBehaviour);
		}

		private void OnOverclockStationsRemoved(OverclockStationBehaviour overclockBehaviour)
		{
			if (_initialized)
			{
				overclockBehaviour.OnOverclockActivationStart.UnRegisterMainThread(SetReceiverState);
				overclockBehaviour.OnOverclockActivationEnd.UnRegisterMainThread(SetReceiverState);
				_linkedOverclockStations.Remove(overclockBehaviour);
				SetReceiverState();
			}
		}

		private void SetReceiverState()
		{
			if (!_initialized)
			{
				return;
			}
			_receiverGameObject.SetActive(_overclockData.IslandHasCompletedOverclockStation());
			foreach (GameObject boostedReceiverEffect in _boostedReceiverEffects)
			{
				boostedReceiverEffect.SetActive(_overclockData.IsOverclocked);
			}
			_receiverRenderer.material = (_overclockData.IsOverclocked ? _receiverActiveMaterial : _receiverInactiveMaterial);
		}
	}
}
