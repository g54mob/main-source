using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrototypeDebugPanel : MonoBehaviour
{
	[Header("Components")]
	public ButtonController cityNameInputButton;

	public DropdownController citySizeDropdownController;

	public TextMeshProUGUI seedText;

	public ButtonController generateBuildingsButton;

	[Space(7f)]
	public ButtonController tileEditModeButton;

	public ButtonController streetsEditModeButton;

	public RectTransform tileEditButtons;

	public RectTransform streetEditButtons;

	[Space(7f)]
	public ButtonController buildingNameButton;

	public ButtonController buildingSwapButton;

	[Space(7f)]
	public Slider loadingSlider;

	public TextMeshProUGUI loadingText;

	public ButtonController onContinueButton;

	public ButtonController backButton;

	private GraphicRaycaster _graphicRaycaster;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	public void ResetControllerSelection(bool deselectCurrent = false)
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	public void ShowStreetsHack(bool condition)
	{
	}

	public void ShrinkBuildingsHack(Vector3 vec)
	{
	}

	public void OnChangeCityNameButton()
	{
	}

	private void OnChangeCityNamePopupCancel()
	{
	}

	private void OnChangeCityNamePopupConfirm()
	{
	}

	public void OnGenerateNewSeed()
	{
	}

	public void OnGenerateBuildingsButton()
	{
	}

	public void OnChangeCityGenerationOption()
	{
	}

	public void OnChangeEditModeButton(int newEditMode)
	{
	}

	public void OnChangeEditModeButton(CityEditorController.CityEditorMode newEditMode)
	{
	}

	public void OnSwapBuildingButton()
	{
	}

	public void OnContinueButton()
	{
	}

	public void OnBackButton()
	{
	}

	public void OnNewTileSelected(CityTile newSelection)
	{
	}
}
