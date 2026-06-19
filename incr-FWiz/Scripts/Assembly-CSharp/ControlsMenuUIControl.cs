using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControlsMenuUIControl : MonoBehaviour
{
	private SettingsControlBindingReference _bindingReference;

	[Header("UI")]
	[SerializeField]
	private TextMeshProUGUI _controlTitleText;

	[SerializeField]
	private TextMeshProUGUI _controlText;

	[SerializeField]
	private Image _panelImage;

	private ControlsMenuUI _menuUI;

	public Sprite DefaultSprite;

	public Sprite RebindingSprite;

	public SettingsControlBindingReference BindingReference => null;

	public string ActionMapName => null;

	public string ActionName => null;

	public int BindingIndex => 0;

	public InputAction InputAction { get; private set; }

	private void Awake()
	{
	}

	public void Initiate(ControlsMenuUI parent, SettingsControlBindingReference bindingReference)
	{
	}

	public void OnSelectedForRebind()
	{
	}

	public void RefreshDisplay()
	{
	}

	public void OnStartRebind()
	{
	}

	public void OnEndRebind()
	{
	}

	public void SetIsRebinding(bool isRebinding)
	{
	}
}
