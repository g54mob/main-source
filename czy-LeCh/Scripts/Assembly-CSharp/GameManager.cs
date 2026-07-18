using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	private bool buildFinished;

	private bool canFinish;

	private bool canRestart;

	private bool canContinue;

	[SerializeField]
	private Animator worldAnimator;

	[SerializeField]
	private GameObject restartButton;

	[SerializeField]
	private SoundManager soundManager;

	[SerializeField]
	private AudioClip buildFinishedSound;

	[Header("Score System")]
	[SerializeField]
	private int score;

	[SerializeField]
	private int worldBuildingScore;

	[SerializeField]
	private int symmetryScore;

	[SerializeField]
	private int survivalScore;

	[SerializeField]
	private int happinessScore;

	[SerializeField]
	private TextMeshProUGUI worldBuildingScoreText;

	[SerializeField]
	private TextMeshProUGUI symmetryScoreText;

	[SerializeField]
	private TextMeshProUGUI survivalScoreText;

	[SerializeField]
	private TextMeshProUGUI happinessScoreText;

	[SerializeField]
	private TextMeshProUGUI scoreText;

	[SerializeField]
	private List<GridObject> gridObjects;

	[SerializeField]
	private float delayBetweenScoreReveals;

	[SerializeField]
	private List<GridObject> gridObjects_posX;

	[SerializeField]
	private List<GridObject> gridObjects_posZ;

	[SerializeField]
	private GameObject scorePanel;

	[SerializeField]
	private GameObject scoreButton;

	private bool showScore = true;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		if (PlayerPrefs.HasKey("showScore"))
		{
			showScore = PlayerPrefs.GetInt("showScore") == 1;
		}
	}

	private void Update()
	{
		if (Keyboard.current.spaceKey.isPressed)
		{
			if (SettingsManager.Instance.IsSettingsOpen() || TutorialController.Instance.TutorialActive())
			{
				return;
			}
			if (!buildFinished && canFinish)
			{
				SetBuildFinished();
			}
			else if (TileUnlockController.Instance.TileUnlockCanvasActive() && canContinue)
			{
				TileUnlockController.Instance.OnContinueButtonPressed();
				canContinue = false;
				canRestart = false;
			}
			else if (canRestart && !TileUnlockController.Instance.TileUnlockCanvasActive())
			{
				SettingsManager.Instance.OnResetButtonPressed();
			}
		}
		if (!Keyboard.current.spaceKey.isPressed && buildFinished)
		{
			canRestart = true;
			canContinue = true;
		}
	}

	public void TakeScreenshot()
	{
		SteamScreenshots.TriggerScreenshot();
	}

	public void CanFinishBuild()
	{
		canFinish = true;
	}

	public void SetBuildFinished()
	{
		if (GridController.Instance.GetAllGridObjects().Count + Object.FindObjectsOfType<TileObject>().Count((TileObject x) => x.IsWater()) > 0)
		{
			buildFinished = true;
			worldAnimator.Play("anim_build_finished");
			scoreButton.SetActive(value: true);
			StartCoroutine(PlayBuildFinishedAnimations());
		}
	}

	private IEnumerator PlayBuildFinishedAnimations()
	{
		List<TileObject> allTiles = Object.FindObjectsOfType<TileObject>().ToList();
		foreach (TileObject item in allTiles)
		{
			item.ForceBuiltOnAnimationBeforeFinish();
		}
		int rowSize = ((WorldSetupPreview.Instance.GetWorldShape() != WorldShape.circle) ? GridController.Instance.GetWorldSize() : ((int)allTiles.Max((TileObject value) => value.transform.position.x)));
		BuildFinishController.Instance.DecideRandomAnimation();
		BuildFinishController.Instance.PlayFinishSound();
		int index = 0;
		for (int i = 0; i < rowSize; i++)
		{
			for (int num = index; num < (i + 1) * rowSize; num++)
			{
				try
				{
					BuildFinishController.Instance.PlayBuildFinishAnimation(allTiles[num].transform);
				}
				catch
				{
				}
			}
			index += rowSize;
			yield return new WaitForSeconds(BuildFinishController.Instance.GetSelectedAnimation().timeBetweenSeparateTiles);
		}
		yield return new WaitForSeconds(BuildFinishController.Instance.GetSelectedAnimationTime());
		SteamAchievementManager.Instance.CheckForAchievements();
		if (SteamAchievementManager.Instance.HasTilesToShowAsUnlocked())
		{
			TileUnlockController.Instance.HideAllTiles();
			MouseController.Instance.SaveUnlockedTiles();
			SteamAchievementManager.Instance.ShowUnlockedTile();
		}
		else
		{
			EnableRestartButton();
		}
	}

	public void EnableRestartButton()
	{
		restartButton.SetActive(value: true);
	}

	public bool IsBuildFinished()
	{
		return buildFinished;
	}

	public List<GridObject> GetAllGridObjects()
	{
		gridObjects.Clear();
		gridObjects = (from x in Object.FindObjectsOfType<GridObject>()
			where !x.GetIsWaterObject()
			select x).ToList();
		return gridObjects;
	}

	private IEnumerator CalculateScore()
	{
		GetAllGridObjects();
		int worldSize = GridController.Instance.GetWorldSize();
		int totalTiles = worldSize * worldSize;
		int blocksPlaced = gridObjects.Count();
		yield return new WaitForSeconds(delayBetweenScoreReveals);
		worldBuildingScore = Mathf.CeilToInt((float)blocksPlaced / (float)totalTiles * 100f);
		worldBuildingScoreText.text = worldBuildingScore.ToString();
		yield return new WaitForSeconds(delayBetweenScoreReveals);
		symmetryScore = 10 * (GetXSymmetryScore() + GetZSymmetryScore());
		symmetryScoreText.text = symmetryScore.ToString();
		yield return new WaitForSeconds(delayBetweenScoreReveals);
		int num = gridObjects.Sum((GridObject x) => x.GetHumanCount());
		int num2 = gridObjects.Sum((GridObject x) => x.GetFoodCount());
		if (num > 0)
		{
			survivalScore = num - (num - num2) * 100;
			if (survivalScore < 0)
			{
				survivalScore = 0;
			}
		}
		else
		{
			survivalScore = 0;
		}
		survivalScore += survivalScore + gridObjects.Count((GridObject x) => x.GetObjectTypes().Contains(ObjectType.wall)) * 10;
		survivalScoreText.text = survivalScore.ToString();
		yield return new WaitForSeconds(delayBetweenScoreReveals);
		happinessScore = GetHappinessScore();
		happinessScoreText.text = happinessScore.ToString();
		yield return new WaitForSeconds(delayBetweenScoreReveals * 2f);
		score = worldBuildingScore + symmetryScore + survivalScore + happinessScore;
		scoreText.text = score.ToString();
	}

	private int GetXSymmetryScore()
	{
		gridObjects_posX = gridObjects.FindAll((GridObject x) => x.transform.parent.position.x > 0f);
		int num = 0;
		foreach (GridObject gridObject in gridObjects_posX)
		{
			if (gridObjects.Exists((GridObject x) => x.transform.parent.position.x == 0f - gridObject.transform.parent.position.x))
			{
				GridObject gridObject2 = gridObjects.Find((GridObject x) => x.transform.parent.position.x == 0f - gridObject.transform.parent.position.x);
				num = ((gridObject2.GetObjectID() != gridObject.GetObjectID()) ? (num + gridObject.GetSymmetryPoints(gridObject2.GetObjectID())) : (num + 10));
			}
		}
		return num;
	}

	private int GetZSymmetryScore()
	{
		gridObjects_posZ = gridObjects.FindAll((GridObject z) => z.transform.parent.position.z > 0f);
		int num = 0;
		foreach (GridObject gridObject in gridObjects_posZ)
		{
			if (gridObjects.Exists((GridObject x) => x.transform.parent.position.z == 0f - gridObject.transform.parent.position.z))
			{
				GridObject gridObject2 = gridObjects.Find((GridObject x) => x.transform.parent.position.z == 0f - gridObject.transform.parent.position.z);
				num = ((gridObject2.GetObjectID() != gridObject.GetObjectID()) ? (num + gridObject.GetSymmetryPoints(gridObject2.GetObjectID())) : (num + 10));
			}
		}
		return num;
	}

	private int GetHappinessScore()
	{
		int num = 0;
		foreach (GridObject gridObject in gridObjects)
		{
			num += gridObject.GetHappinessScore();
		}
		return num;
	}

	public void ShowScore()
	{
		scorePanel.SetActive(!scorePanel.activeInHierarchy);
	}

	public void SaveScoreVisibility()
	{
		showScore = !showScore;
		PlayerPrefs.SetInt("showScore", showScore ? 1 : 0);
	}
}
