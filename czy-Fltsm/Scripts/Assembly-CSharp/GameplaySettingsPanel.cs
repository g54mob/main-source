using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameplaySettingsPanel : SettingsPanel
{
	[Header("Gameplay")]
	[Tooltip("Toggle to force mouse and keyboard input.")]
	[SerializeField]
	private Toggle _forceMouseAndKeyboard;

	[Tooltip("Toggle to change edge scrolling.")]
	[SerializeField]
	private Toggle _edgeScrollingToggle;

	[Tooltip("Toggle to horizontal rotation inversion")]
	[SerializeField]
	private Toggle _invertHorizontalRotationToggle;

	[Tooltip("Toggle to vertical rotation inversion")]
	[SerializeField]
	private Toggle _invertVerticalRotationToggle;

	[Tooltip("Toggle to scrolling inversion")]
	[SerializeField]
	private Toggle _invertScrollingToggle;

	[SerializeField]
	private Toggle _toggleGeneralStorageFilters;

	[Space]
	[Tooltip("Slider to set movement sensitivity.")]
	[SerializeField]
	private InteractableSlider _movementSensitivitySlider;

	[Tooltip("Slider to set rotation sensitivity.")]
	[SerializeField]
	private InteractableSlider _rotationSensitivitySlider;

	[Tooltip("Slider to set scrolling sensitivity.")]
	[SerializeField]
	private InteractableSlider _scrollingSensitivitySlider;

	[Tooltip("Slider to set autosave limit.")]
	[SerializeField]
	private InteractableSlider _autosaveLimitSlider;

	[HideInInspector]
	private GameplayPlayerData _gameplayData;

	public override void Load(Settings playerData)
	{
		_gameplayData = playerData.GameplayPlayerData;
		SetValues(_gameplayData);
	}

	public override void ApplyChanges()
	{
	}

	protected override void Reset()
	{
		_gameplayData.ResetSettings();
		SetValues(_gameplayData);
	}

	private void SetValues(GameplayPlayerData gameplayPlayerData)
	{
		_forceMouseAndKeyboard.gameObject.SetActive(FlotsamInputManager.HasKeyboard);
		_forceMouseAndKeyboard.isOn = gameplayPlayerData.ForceMouseAndKeyboard;
		_edgeScrollingToggle.isOn = gameplayPlayerData.EdgeScrolling;
		_invertHorizontalRotationToggle.isOn = gameplayPlayerData.InvertHorizontalRotation;
		_invertVerticalRotationToggle.isOn = gameplayPlayerData.InvertVerticalRotation;
		_invertScrollingToggle.isOn = gameplayPlayerData.InvertScrolling;
		_toggleGeneralStorageFilters.isOn = gameplayPlayerData.ToggleGeneralStorageFilters;
		_movementSensitivitySlider.SetValue(gameplayPlayerData.MovementSensitivity * 100f);
		_rotationSensitivitySlider.SetValue(gameplayPlayerData.RotationSensitivity * 100f);
		_scrollingSensitivitySlider.SetValue(gameplayPlayerData.ScrollingSensitivity * 100f);
		_autosaveLimitSlider.SetValue(gameplayPlayerData.AutosaveLimit);
	}

	public void UpdateForceMouseAndKeyboard()
	{
		_gameplayData.ForceMouseAndKeyboard = _forceMouseAndKeyboard.isOn;
		FlotsamInputManager.SetForceMouseAndKeyboard(_forceMouseAndKeyboard.isOn);
		if (_forceMouseAndKeyboard.isOn)
		{
			EventSystem.current.SetSelectedGameObject(null);
		}
	}

	public void UpdateEdgeScrolling()
	{
		_gameplayData.EdgeScrolling = _edgeScrollingToggle.isOn;
	}

	public void UpdateInvertHorizontalRotation()
	{
		_gameplayData.InvertHorizontalRotation = _invertHorizontalRotationToggle.isOn;
	}

	public void UpdateInvertVerticalRotation()
	{
		_gameplayData.InvertVerticalRotation = _invertVerticalRotationToggle.isOn;
	}

	public void UpdateInvertScrolling()
	{
		_gameplayData.InvertScrolling = _invertScrollingToggle.isOn;
	}

	public void UpdateToggleGeneralStorageItemFilters()
	{
		_gameplayData.ToggleGeneralStorageFilters = _toggleGeneralStorageFilters.isOn;
	}

	public void UpdateMovementSensitivity()
	{
		_gameplayData.MovementSensitivity = _movementSensitivitySlider.ReturnValue(updateTextValue: true) / 100f;
	}

	public void UpdateRotationSensitivity()
	{
		_gameplayData.RotationSensitivity = _rotationSensitivitySlider.ReturnValue(updateTextValue: true) / 100f;
	}

	public void UpdateScrollingSensitivity()
	{
		_gameplayData.ScrollingSensitivity = _scrollingSensitivitySlider.ReturnValue(updateTextValue: true) / 100f;
	}

	public void UpdateAutosaveLimit()
	{
		_gameplayData.AutosaveLimit = (int)_autosaveLimitSlider.ReturnValue(updateTextValue: true);
	}

	public override bool HasChanges()
	{
		return false;
	}
}
