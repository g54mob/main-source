using Data.Buildings;
using Data.FactoryFloor;
using Data.FactoryFloor.Buildings;
using Events;
using Presentation.FactoryFloor.Toolbar;
using UnityEngine;

public class MonumentLockedView : MonoBehaviour
{
	[SerializeField]
	private PlaceBuildingButton _placeBuildingButton;

	[SerializeField]
	private FactoryLayer _factoryLayer;

	[SerializeField]
	private Transform _lockedView;

	[SerializeField]
	private BaseEvent _finishedLoadingSaveEvent;

	private BuildingObjectData _buildingObjectData;

	private bool _isMonument;

	private bool _shouldCheckIfLocked;

	private bool _locked;

	private void OnEnable()
	{
		_buildingObjectData = _placeBuildingButton.BuildingObjectData;
		_isMonument = _buildingObjectData != null && _buildingObjectData.ContainsFactoryObjectBehaviour<MonumentBehaviour>();
		_factoryLayer.OnObjectsInLayerChanged += SetShouldCheckIfMonumentIsLocked;
		_finishedLoadingSaveEvent.Register(SetShouldCheckIfMonumentIsLocked);
		if (!_isMonument)
		{
			base.enabled = false;
		}
		_shouldCheckIfLocked = true;
	}

	private void OnDisable()
	{
		_factoryLayer.OnObjectsInLayerChanged -= SetShouldCheckIfMonumentIsLocked;
		_finishedLoadingSaveEvent.UnRegister(SetShouldCheckIfMonumentIsLocked);
	}

	private void Update()
	{
		if (_shouldCheckIfLocked)
		{
			CheckIfLocked();
		}
	}

	private void CheckIfLocked()
	{
		if (_factoryLayer.GetObjectsFromData(_buildingObjectData).Count > 0)
		{
			SetLocked(locked: true);
		}
		else
		{
			SetLocked(locked: false);
		}
		_shouldCheckIfLocked = false;
	}

	private void SetLocked(bool locked)
	{
		if (_locked != locked)
		{
			_placeBuildingButton.enabled = !locked;
			_lockedView.gameObject.SetActive(locked);
			_locked = locked;
		}
	}

	private void SetShouldCheckIfMonumentIsLocked(FactoryLayer _)
	{
		_shouldCheckIfLocked = true;
	}

	private void SetShouldCheckIfMonumentIsLocked()
	{
		_shouldCheckIfLocked = true;
	}
}
