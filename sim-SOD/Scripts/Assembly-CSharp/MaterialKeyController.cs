using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class MaterialKeyController : MonoBehaviour
{
	public enum SliderPickerType
	{
		grub = 0,
		plants = 1,
		artPortrait = 2,
		artLandscape = 3,
		artSquare = 4,
		artPoster = 5,
		artLitter = 6,
		artWallGrimeTop = 7,
		artWallGrimeBottom = 8,
		artDynamicClue = 9,
		artGraffiti = 10
	}

	public delegate void ColourKeyUpdate();

	[Header("Components")]
	public RectTransform rect;

	public WindowContentController wcc;

	public ButtonController placementButton;

	public InfoWindow colourWindow;

	public ColourPickerController colourPick;

	[Header("Colour Select")]
	public TextMeshProUGUI mainColourSelectText;

	public ButtonController mainColourButton;

	public RectTransform mainColourUnused;

	public ButtonController colour1Button;

	public RectTransform colour1Unused;

	public ButtonController colour2Button;

	public RectTransform colour2Unused;

	public ButtonController colour3Button;

	public RectTransform colour3Unused;

	[Header("Details Select")]
	public TextMeshProUGUI detailsColourSelectText;

	[Header("Grub Select")]
	public SliderPickerType sliderType;

	public TextMeshProUGUI grubSelectText;

	public SliderController grubSlider;

	[Header("State")]
	public bool isSetup;

	public Toolbox.MaterialKey matKey;

	private int colourEdit;

	public event ColourKeyUpdate OnColourKeyUpdate
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Setup(WindowContentController newContentController)
	{
	}

	public void SetPageSize(Vector2 newSize)
	{
	}

	public void UpdateButtonsBasedOnFurniture(FurniturePreset furn)
	{
	}

	public void UpdateButtonsBasedOnMaterial(Material mat, bool setColour, SliderPickerType sliderType = SliderPickerType.grub, bool forceGrub = false, float forcedGrub = 0f)
	{
	}

	public void SetButtonsToKey(Toolbox.MaterialKey key)
	{
	}

	public void ColourSelectButton(int val)
	{
	}

	public void OnNewColourSelect(Color newColour)
	{
	}

	public void OnGrubUpdate()
	{
	}

	public void ChangeColourKey()
	{
	}

	public void PlacementButton()
	{
	}

	public void UpdatePlacementText()
	{
	}

	public void CancelButton()
	{
	}

	private void OnDestroy()
	{
	}
}
