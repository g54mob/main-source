using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModEntryController : MonoBehaviour
{
	[Header("Setup")]
	public ModSettingsData mod;

	public Sprite updatePendingSprite;

	public Sprite localSprite;

	public Sprite modioSprite;

	public Sprite workshopSprite;

	[Header("State")]
	public float updateTimer;

	[Header("Componets")]
	public TextMeshProUGUI nameText;

	public Image iconImg;

	public ButtonController enableDisableButton;

	public ButtonController moveUpButton;

	public ButtonController moveDownButton;

	public ButtonController uploadButton;

	public TooltipController tooltip;

	public void Setup(ModSettingsData newMod)
	{
	}

	private void Update()
	{
	}

	public void StateRefresh()
	{
	}

	public void OnEnableDisableButton()
	{
	}

	public void OnMoveDownButton()
	{
	}

	public void OnMoveUpButton()
	{
	}

	public void OnUploadButton()
	{
	}

	public void OnUploadConfirm()
	{
	}

	public void OnModDocumentation()
	{
	}

	public void OnUploadCancel()
	{
	}
}
