using System;
using CTS;
using CTS.Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_ConstructionSystem : MonoSingleton<UI_ConstructionSystem>
{
	[SerializeField]
	private UnityEvent _canvasGroupControllerShow;

	[SerializeField]
	private UnityEvent _canvasGroupControllerHide;

	[SerializeField]
	private Toggle _interiorToggle;

	[SerializeField]
	private Toggle _assignationToggle;

	[SerializeField]
	private Toggle _destructionToggle;

	[SerializeField]
	private GameObject _mainStorePanel;

	[SerializeField]
	private UI_BuyableButton _buyablePrefab;

	public bool IsOpen { get; private set; }

	public static event Action OnOpenBuildMode;

	public static event Action OnFondationMode;

	public static event Action OnInteriorMode;

	public static event Action OnCloseBuildMode;

	public static event Action<bool> OnConstructionActived;

	public static event Action<bool> OnDestructionActived;

	public static event Action<bool> OnPaintActived;

	public static event Action<bool> OnBuildableActived;

	public static event Action<bool> OnAssignationActived;

	protected override void SingletonAwake()
	{
		IsOpen = false;
		_interiorToggle.onValueChanged.AddListener(OnInteriorToggleChanged);
		_assignationToggle.onValueChanged.AddListener(OnAssignationToggleChanged);
		_destructionToggle.onValueChanged.AddListener(OnDestructionToggled);
	}

	protected override void OnSingletonDestroy()
	{
		BuildingRoomsContainerManager.OnStageChanged -= OnStageChanged;
		_interiorToggle.onValueChanged.RemoveListener(OnInteriorToggleChanged);
		_assignationToggle.onValueChanged.RemoveListener(OnAssignationToggleChanged);
		_destructionToggle.onValueChanged.RemoveListener(OnDestructionToggled);
	}

	private void Start()
	{
		MonoSingleton<BuildablePlacementSystem>.Instance.enabled = false;
		BuildingRoomsContainerManager.OnStageChanged += OnStageChanged;
		if (MonoSingleton<UI_ConstructionFacture>.TryGetInstance(out var outInstance))
		{
			outInstance.gameObject.SetActive(value: false);
		}
		MonoSingleton<ConstructionSystem>.Instance.CurrentMode = EConstructionMode.None;
		_mainStorePanel.SetActive(value: false);
	}

	private void OnInteriorToggleChanged(bool toggle)
	{
		if (toggle)
		{
			if (_assignationToggle.isOn)
			{
				_assignationToggle.isOn = false;
			}
			if (_destructionToggle.isOn)
			{
				_destructionToggle.isOn = false;
			}
			MonoSingleton<ConstructionSystem>.Instance.CurrentMode = EConstructionMode.Construction;
			UI_ConstructionSystem.OnInteriorMode?.Invoke();
			_mainStorePanel.SetActive(value: true);
			if (!IsOpen)
			{
				OpenBuildMode();
			}
		}
		else if (!_assignationToggle.isOn && !_destructionToggle.isOn)
		{
			MonoSingleton<ConstructionSystem>.Instance.CurrentMode = EConstructionMode.None;
			if (IsOpen)
			{
				CloseBuildMode();
			}
		}
	}

	private void OnAssignationToggleChanged(bool toggle)
	{
		if (toggle)
		{
			if (_interiorToggle.isOn)
			{
				_interiorToggle.isOn = false;
			}
			if (_destructionToggle.isOn)
			{
				_destructionToggle.isOn = false;
			}
			MonoSingleton<ConstructionSystem>.Instance.CurrentMode = EConstructionMode.Assingation;
			UI_ConstructionSystem.OnAssignationActived?.Invoke(obj: true);
			_mainStorePanel.SetActive(value: false);
			CloseBuildMode();
			return;
		}
		if (!_interiorToggle.isOn && !_destructionToggle.isOn)
		{
			MonoSingleton<ConstructionSystem>.Instance.CurrentMode = EConstructionMode.None;
			if (IsOpen)
			{
				CloseBuildMode();
			}
		}
		UI_ConstructionSystem.OnAssignationActived?.Invoke(obj: false);
	}

	private void OnDestructionToggled(bool toggle)
	{
		if (toggle)
		{
			if (_interiorToggle.isOn)
			{
				_interiorToggle.isOn = false;
			}
			if (_assignationToggle.isOn)
			{
				_assignationToggle.isOn = false;
			}
			MonoSingleton<ConstructionSystem>.Instance.CurrentMode = EConstructionMode.Destruction;
			UI_ConstructionSystem.OnDestructionActived?.Invoke(obj: true);
			_mainStorePanel.SetActive(value: false);
			if (!IsOpen)
			{
				OpenBuildMode();
			}
			return;
		}
		if (!_assignationToggle.isOn && !_interiorToggle.isOn)
		{
			MonoSingleton<ConstructionSystem>.Instance.CurrentMode = EConstructionMode.None;
			if (IsOpen)
			{
				CloseBuildMode();
			}
		}
		UI_ConstructionSystem.OnDestructionActived?.Invoke(obj: false);
	}

	private void OnStageChanged(int stage)
	{
		CloseBuildMode();
	}

	public void CloseConstructionFromAnywhere()
	{
		_interiorToggle.isOn = false;
		_assignationToggle.isOn = false;
		_destructionToggle.isOn = false;
	}

	private void OpenBuildMode()
	{
		IsOpen = true;
		_canvasGroupControllerShow?.Invoke();
		UI_ConstructionSystem.OnOpenBuildMode?.Invoke();
		if (MonoSingleton<UI_ConstructionFacture>.TryGetInstance(out var outInstance))
		{
			outInstance.gameObject.SetActive(value: true);
		}
	}

	public void CloseBuildMode()
	{
		IsOpen = false;
		_mainStorePanel.SetActive(value: false);
		_canvasGroupControllerHide?.Invoke();
		UI_ConstructionSystem.OnCloseBuildMode?.Invoke();
		MonoSingleton<UI_ConstructionFacture>.Instance.gameObject.SetActive(value: false);
	}
}
