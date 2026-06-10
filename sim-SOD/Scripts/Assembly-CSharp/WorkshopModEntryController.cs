using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkshopModEntryController : MonoBehaviour
{
	[Header("Setup")]
	public ModSettingsData mod;

	public Sprite enabledSprite;

	public Sprite disabledSprite;

	public Sprite updatePendingSprite;

	[Header("State")]
	public float updateTimer;

	[Header("Componets")]
	public TextMeshProUGUI nameText;

	public TextMeshProUGUI versionText;

	public Image iconImg;

	public ButtonController enableDisableButton;

	public ButtonController moveUpButton;

	public ButtonController moveDownButton;

	public void Setup()
	{
	}
}
