using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
	public static LevelSelectManager instance;

	private LevelInteractor[] levelInteractors;

	private BonusLevelInteractor[] bonusLevelInteractors;

	public Vector3 spawnOnLevelOffsetPositon;

	public PlayerMovement playerMovement;

	public TMP_Text levelTitle;

	public TMP_Text levelHighscore;

	public TMP_Text beatenState;

	public string notBeatenYet = "Not beaten yet.";

	public string successfullyBeaten = "Successfully beaten.";

	public string scorePrefix = "Your Best: ";

	public GameObject tooltipObject;

	public Image tooltipImage;

	public TMP_Text tooltipTitle;

	public TMP_Text tooltipDescription;

	private Equippable showingTooltipFor;

	public Canvas levelSelectedCanvas;

	public Camera camMain;

	private LevelInteractor openedLevel;

	private int iFrames;

	private bool fixedLoadout;

	public Equippable ShowingTooltipFor => showingTooltipFor;

	public bool PreLevelMenuIsOpen => openedLevel != null;

	public void ShowTooltip(Equippable _eq)
	{
		showingTooltipFor = _eq;
		tooltipObject.SetActive(_eq != null);
		if (!(_eq == null))
		{
			tooltipImage.sprite = _eq.icon;
			tooltipTitle.text = _eq.displayName;
			tooltipDescription.text = _eq.description;
			float num = camMain.pixelRect.height / levelSelectedCanvas.pixelRect.height;
			tooltipObject.transform.position = Input.mousePosition * num;
		}
	}

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		levelInteractors = GetComponentsInChildren<LevelInteractor>();
		bonusLevelInteractors = GetComponentsInChildren<BonusLevelInteractor>();
		ShowTooltip(null);
	}

	private void MovePlayerToTheLevelYouCameFrom()
	{
	}

	public void PlayButtonPressed()
	{
		if (PreLevelMenuIsOpen)
		{
			if (openedLevel.levelInfo.fixedLoadout.Count > 0)
			{
				PerkManager.instance.CurrentlyEquipped.Clear();
				PerkManager.instance.CurrentlyEquipped.AddRange(openedLevel.levelInfo.fixedLoadout);
			}
			SceneTransitionManager.instance.TransitionFromLevelSelectToLevel(openedLevel.levelInfo.sceneName);
		}
	}
}
