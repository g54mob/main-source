using UnityEngine;
using UnityEngine.UI;

public class ModeButtonController : MonoBehaviour
{
	public CoreButtonUnityGUI buildButton;

	public CoreButtonUnityGUI playButton;

	public CoreButtonUnityGUI editButton;

	public Image editButtonIcon;

	public Image editButtonBacking;

	[Header("Active Color Block")]
	public ColorBlock activeModeColorBlock;

	[Header("Inactive Color Block")]
	public ColorBlock inactiveModeColorBlock;

	public GUIManagerPens guiRef;

	private Vector3 activeScale = Vector3.one;

	private Vector3 inactiveScale = new Vector3(0.75f, 0.75f, 0.75f);

	private float activeAlpha = 1f;

	private float inactiveAlpha = 0.5f;

	private bool playButtonActive;

	private bool editButtonActive;

	private bool buildButtonActive;

	private DogHome homeRef;

	private PenFocus focusRef;

	private void Start()
	{
		focusRef = Camera.main.GetComponent<PenFocus>();
		homeRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		DisableEditButton();
		DisablePlayButton();
		DisableBuildButton();
	}

	private void Update()
	{
		UpdateButtonStates();
	}

	public void OnPlayButtonPressed()
	{
		homeRef.RequestExitBuildMode();
	}

	public void OnBuildButtonPressed()
	{
		homeRef.RequestEnterBuildMode();
	}

	public void OnEditButtonPressed()
	{
		guiRef.OnInstantPenEditButtonPressed();
	}

	private void UpdateButtonStates()
	{
		if (!homeRef.IsInBuildMode())
		{
			bool flag = focusRef.GetFocusedRoom() != null;
			if (!flag)
			{
				flag = focusRef.GetFollowTarget() != null;
			}
			if (flag && !focusRef.IsCamModeExterior())
			{
				flag = false;
			}
			if (editButtonActive && !flag)
			{
				DisableEditButton();
			}
			else if (!editButtonActive && flag)
			{
				EnableEditButton();
			}
			if (!buildButtonActive)
			{
				EnableBuildButton();
			}
			if (playButtonActive)
			{
				DisablePlayButton();
			}
			return;
		}
		if (!playButtonActive)
		{
			EnablePlayButton();
		}
		if (ObjectPlacementManager.IsInPlacementMode())
		{
			if (!editButtonActive)
			{
				EnableEditButton();
			}
			if (!buildButtonActive)
			{
				EnableBuildButton();
			}
		}
		else
		{
			if (editButtonActive)
			{
				DisableEditButton();
			}
			if (buildButtonActive)
			{
				DisableBuildButton();
			}
		}
	}

	private void DisableEditButton()
	{
		editButton.interactable = false;
		editButton.useGlobalGUIActiveStatus = false;
		Color color = editButtonIcon.color;
		editButtonIcon.color = new Color(color.r, color.g, color.b, inactiveAlpha);
		editButtonBacking.enabled = false;
		editButtonActive = false;
	}

	private void EnableEditButton()
	{
		editButton.interactable = true;
		editButton.useGlobalGUIActiveStatus = true;
		Color color = editButtonIcon.color;
		editButtonIcon.color = new Color(color.r, color.g, color.b, activeAlpha);
		editButtonBacking.enabled = true;
		editButtonActive = true;
	}

	private void EnableBuildButton()
	{
		buildButtonActive = true;
		buildButton.transform.parent.localScale = inactiveScale;
		buildButton.interactable = true;
		buildButton.useGlobalGUIActiveStatus = true;
		buildButton.colors = inactiveModeColorBlock;
		buildButton.enabled = false;
		buildButton.enabled = true;
	}

	private void DisableBuildButton()
	{
		buildButtonActive = false;
		buildButton.transform.parent.localScale = activeScale;
		buildButton.interactable = false;
		buildButton.useGlobalGUIActiveStatus = false;
		buildButton.colors = activeModeColorBlock;
	}

	private void EnablePlayButton()
	{
		playButtonActive = true;
		playButton.transform.parent.localScale = inactiveScale;
		playButton.interactable = true;
		playButton.useGlobalGUIActiveStatus = true;
		playButton.colors = inactiveModeColorBlock;
		playButton.enabled = false;
		playButton.enabled = true;
	}

	private void DisablePlayButton()
	{
		playButtonActive = false;
		playButton.transform.parent.localScale = activeScale;
		playButton.interactable = false;
		playButton.useGlobalGUIActiveStatus = false;
		playButton.colors = activeModeColorBlock;
	}
}
