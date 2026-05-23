using Data.FactoryFloor;
using Data.Operator;
using Data.Variables;
using Events;
using Presentation.FactoryFloor.Toolbar;
using UnityEngine;

public class CrimsonitePrinterLockedView : MonoBehaviour
{
	[SerializeField]
	private OperatorBarButton _operatorBarButton;

	[SerializeField]
	private FactoryLayer _factoryLayer;

	[SerializeField]
	private Transform _lockedView;

	[SerializeField]
	private BaseEvent _finishedLoadingSaveEvent;

	[SerializeField]
	private FactoryObjectData _crimsonitePrinterData;

	[SerializeField]
	private IntVariableSO _maxCrimonitePrintersAmount;

	private bool _shouldCheckIfLocked;

	private bool _locked;

	private void OnEnable()
	{
		_factoryLayer.OnObjectsInLayerChanged += SetShouldCheckIfLocked;
		_finishedLoadingSaveEvent.Register(SetShouldCheckIfLocked);
		_shouldCheckIfLocked = true;
	}

	private void OnDisable()
	{
		_factoryLayer.OnObjectsInLayerChanged -= SetShouldCheckIfLocked;
		_finishedLoadingSaveEvent.UnRegister(SetShouldCheckIfLocked);
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
		SetLocked(_factoryLayer.GetObjectsFromData(_crimsonitePrinterData).Count >= _maxCrimonitePrintersAmount.Value);
		_shouldCheckIfLocked = false;
	}

	private void SetLocked(bool locked)
	{
		if (_locked != locked)
		{
			_operatorBarButton.enabled = !locked;
			_lockedView.gameObject.SetActive(locked);
			_locked = locked;
		}
	}

	private void SetShouldCheckIfLocked(FactoryLayer _)
	{
		_shouldCheckIfLocked = true;
	}

	private void SetShouldCheckIfLocked()
	{
		_shouldCheckIfLocked = true;
	}
}
