using UnityEngine;

public class TooltipManager : MonoBehaviour
{
	public Tooltip targetTooltip;

	private PlayerInteraction playerInteraction;

	private string tutorialOverridePriority = "";

	private string tutorialOverride = "";

	private string nextTooltipText = "";

	private InteractorBase lastFocus;

	private bool interactorRefreshFlag;

	private SettingsManager settings;

	public static TooltipManager instance;

	public bool hideAllTooltips;

	public void SetTutorialOverrideToNone()
	{
		SetTutorialOverride("%NONE");
	}

	public void SetTutorialOverride(string _text, bool _priorityText = true)
	{
		if (_priorityText)
		{
			tutorialOverridePriority = _text;
		}
		else
		{
			tutorialOverride = _text;
		}
	}

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		playerInteraction = PlayerInteraction.instance;
		SceneTransitionManager.instance.onSceneChange.AddListener(ResetAfterSceneLoad);
		settings = SettingsManager.Instance;
	}

	private void ResetAfterSceneLoad()
	{
		tutorialOverride = "";
		tutorialOverridePriority = "";
		nextTooltipText = "";
	}

	private void Update()
	{
		if (playerInteraction != PlayerInteraction.instance)
		{
			playerInteraction = PlayerInteraction.instance;
		}
		if (playerInteraction == null)
		{
			return;
		}
		if (UIFrameManager.instance.ActiveFrame != null)
		{
			nextTooltipText = "";
			interactorRefreshFlag = true;
		}
		else if (hideAllTooltips)
		{
			nextTooltipText = "";
			interactorRefreshFlag = true;
		}
		else if (tutorialOverridePriority != "")
		{
			if (tutorialOverridePriority == "%NONE")
			{
				nextTooltipText = "";
			}
			else
			{
				nextTooltipText = tutorialOverridePriority;
			}
			interactorRefreshFlag = true;
		}
		else if ((bool)playerInteraction.FocussedInteractor && !settings.DisableTooltips)
		{
			if (lastFocus != playerInteraction.FocussedInteractor || interactorRefreshFlag)
			{
				nextTooltipText = playerInteraction.FocussedInteractor.ReturnTooltip();
				lastFocus = playerInteraction.FocussedInteractor;
				interactorRefreshFlag = false;
			}
		}
		else if (tutorialOverride != "")
		{
			nextTooltipText = tutorialOverride;
			interactorRefreshFlag = true;
		}
		else
		{
			nextTooltipText = "";
			lastFocus = null;
		}
		if (nextTooltipText != targetTooltip.currentText)
		{
			targetTooltip.SetTooltip(nextTooltipText);
		}
	}

	public void SetInteractorRefreshFlag()
	{
		interactorRefreshFlag = true;
	}
}
