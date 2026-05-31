using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenCanvasController : MonoBehaviour
{
	public TMP_Text MoneyText;

	public TMP_Text ResearchText;

	public TMP_Text HoleText;

	public TMP_Text BlueShardText;

	public TMP_Text YellowShardText;

	public TMP_Text RedShardText;

	public GameObject BlueShardSection;

	public GameObject YellowShardSection;

	public GameObject RedShardSection;

	public Slider HoleSlider;

	public Button PrestigeButton;

	public Button EndingButton;

	public Button SkillTreeButton;

	public Button QuestButton;

	public Button BookButton;

	public Sprite QuestHasSprite;

	public Sprite QuestHasNotSprite;

	public TMP_Text WalkingPeonText;

	public Image WalkingPeonImage;

	public TMP_Text InBuildingPeonText;

	public Image InBuildingPeonImage;

	public Image PutOnTopButton;

	public Sprite OnTopSprite;

	public Sprite OnBackSprite;

	public GameObject TopMiddlePanel;

	public static ScreenCanvasController Instance;

	public GameObject StatsPanel;

	public Image BlackFadingImage;

	public TMP_Text MoneyStats;

	public TMP_Text RpStats;

	public TMP_Text HoleStats;

	private bool _cachedSeeStats;

	private bool _cachedSkillIconVisible;

	private bool _cachedQuestIconVisible;

	private int _cachedTotalBook;

	private bool _isNewGame;

	public TMP_Text DebugText;

	private void Awake()
	{
		Instance = this;
		PrestigeButton.gameObject.SetActive(value: false);
		EndingButton.gameObject.SetActive(value: false);
		BlueShardSection.SetActive(value: false);
		YellowShardSection.SetActive(value: false);
		RedShardSection.SetActive(value: false);
		if (GameController.Instance.Money.TotalAmount == 0)
		{
			TopMiddlePanel.SetActive(value: false);
			_isNewGame = true;
			BlackFadingImage.gameObject.SetActive(value: true);
		}
		StatsPanel.SetActive(value: false);
	}

	private void Start()
	{
		if (GameController.Instance.BluePoint.TotalAmount > 0 || GameController.Instance.RedPoint.TotalAmount > 0 || GameController.Instance.YellowPoint.TotalAmount > 0)
		{
			_cachedSkillIconVisible = true;
			SkillTreeButton.gameObject.SetActive(value: true);
		}
		else
		{
			_cachedSkillIconVisible = false;
			SkillTreeButton.gameObject.SetActive(value: false);
		}
		switch (AchievementDefinition.QuestButtonStatus(GameController.Instance.Achievements))
		{
		case 0:
			_cachedQuestIconVisible = false;
			QuestButton.gameObject.SetActive(value: false);
			break;
		case 1:
			_cachedQuestIconVisible = true;
			QuestButton.gameObject.SetActive(value: true);
			QuestButton.image.sprite = QuestHasNotSprite;
			break;
		case 2:
			_cachedQuestIconVisible = true;
			QuestButton.gameObject.SetActive(value: true);
			QuestButton.image.sprite = QuestHasSprite;
			break;
		}
		_cachedTotalBook = GameController.Instance.Book.TotalAmount;
		BookButton.gameObject.SetActive(value: false);
		if (_isNewGame)
		{
			BlackFadingImage.DOFade(0f, 2f).SetDelay(1f).SetEase(Ease.InQuart)
				.OnComplete(delegate
				{
					BlackFadingImage.gameObject.SetActive(value: false);
					TutorialController.Instance.EnablePart(1);
				});
		}
	}

	public void HideBookIcon()
	{
		BookButton.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		if (!_cachedSkillIconVisible && GameController.Instance.BluePoint.TotalAmount > 0)
		{
			GameController.Instance.ToastPanel.AddItem("Gained a blue shard. The upgrade tree can now be unlocked.");
			_cachedSkillIconVisible = true;
			SkillTreeButton.GetComponent<Pulsing>().StartAnimation();
			SkillTreeButton.gameObject.SetActive(value: true);
		}
		switch (AchievementDefinition.QuestButtonStatus(GameController.Instance.Achievements))
		{
		case 0:
			_cachedQuestIconVisible = false;
			QuestButton.gameObject.SetActive(value: false);
			break;
		case 1:
			_cachedQuestIconVisible = true;
			QuestButton.gameObject.SetActive(value: true);
			QuestButton.image.sprite = QuestHasNotSprite;
			break;
		case 2:
			_cachedQuestIconVisible = true;
			QuestButton.gameObject.SetActive(value: true);
			QuestButton.image.sprite = QuestHasSprite;
			break;
		}
		if (_cachedTotalBook != GameController.Instance.Book.TotalAmount)
		{
			_cachedTotalBook = GameController.Instance.Book.TotalAmount;
			BookButton.gameObject.SetActive(value: true);
		}
		if (GameController.Instance.Money.TotalAmount == 0)
		{
			MoneyText.text = "";
		}
		else
		{
			MoneyText.text = "<color=yellow>" + GameController.Instance.Money.Amount.ToNumber() + " $</color>";
		}
		if (GameController.Instance.ResearchPoint.TotalAmount == 0)
		{
			ResearchText.text = "";
		}
		else
		{
			ResearchText.text = "<color=#FFC0CB>" + GameController.Instance.ResearchPoint.Amount.ToNumber() + " RP</color>";
		}
		if (GameController.Instance.Money.TotalAmount > 0 && !TopMiddlePanel.gameObject.activeSelf)
		{
			TopMiddlePanel.transform.localScale = new Vector3(0f, 0f, 1f);
			TopMiddlePanel.gameObject.SetActive(value: true);
			TopMiddlePanel.transform.DOScale(new Vector2(1f, 1f), 0.1f);
		}
		if (GameController.Instance.BluePoint.TotalAmount > 0)
		{
			BlueShardSection.gameObject.SetActive(value: true);
			BlueShardText.text = GameController.Instance.BluePoint.Amount.ToString();
		}
		if (GameController.Instance.YellowPoint.TotalAmount > 0)
		{
			YellowShardSection.gameObject.SetActive(value: true);
			YellowShardText.text = GameController.Instance.YellowPoint.Amount.ToString();
		}
		if (GameController.Instance.RedPoint.TotalAmount > 0)
		{
			RedShardSection.gameObject.SetActive(value: true);
			RedShardText.text = GameController.Instance.RedPoint.Amount.ToString();
		}
		if (GameController.Instance.MaxFilled >= 10000)
		{
			HoleText.text = "<color=green>" + GameController.Instance.HoleFilled.Amount.ToNumber() + "</color> / " + GameController.Instance.MaxFilled.ToNumber();
		}
		else
		{
			HoleText.text = "<color=green>" + GameController.Instance.HoleFilled.Amount.ToNumber() + "</color> / " + GameController.Instance.MaxFilled.ToNumber() + " Filled";
		}
		if (GameController.Instance.PeonController.GetCharacterCount() == 0)
		{
			WalkingPeonText.text = "";
			InBuildingPeonText.text = "";
			WalkingPeonImage.gameObject.SetActive(value: false);
			InBuildingPeonImage.gameObject.SetActive(value: false);
		}
		else
		{
			WalkingPeonImage.gameObject.SetActive(value: true);
			InBuildingPeonImage.gameObject.SetActive(value: true);
			WalkingPeonText.text = GameController.Instance.PeonController.GetCharacterWalkingCount().ToString();
			InBuildingPeonText.text = GameController.Instance.PeonController.GetCharacterWorkerCount().ToString();
		}
		float num = ((GameController.Instance.HoleFilled.Amount != 0) ? ((float)GameController.Instance.HoleFilled.Amount / (float)GameController.Instance.MaxFilled) : 0f);
		if (num > 1f)
		{
			num = 1f;
		}
		HoleSlider.value = num;
		if (GameController.Instance.HoleFilled.Amount >= GameController.Instance.MaxFilled)
		{
			if (!PrestigeButton.gameObject.activeSelf && !EndingButton.gameObject.activeSelf)
			{
				Music2Controller.Instance.PlayEarthquakeMusic();
			}
			if (GameController.Instance.PrestigeCount < GameController.GetMaxPrestigeCount())
			{
				HoleText.gameObject.SetActive(value: false);
				HoleSlider.gameObject.SetActive(value: false);
				PrestigeButton.gameObject.SetActive(value: true);
				EndingButton.gameObject.SetActive(value: false);
			}
			else
			{
				HoleText.gameObject.SetActive(value: false);
				HoleSlider.gameObject.SetActive(value: false);
				PrestigeButton.gameObject.SetActive(value: false);
				EndingButton.gameObject.SetActive(value: true);
			}
		}
		else
		{
			HoleText.gameObject.SetActive(value: true);
			HoleSlider.gameObject.SetActive(value: true);
			PrestigeButton.gameObject.SetActive(value: false);
			EndingButton.gameObject.SetActive(value: false);
		}
	}

	private void FixedUpdate()
	{
		UpdateStats();
		if (GameController.Instance.CanViewOnTop)
		{
			if (GameController.Instance.AreBuildingOnTop)
			{
				PutOnTopButton.sprite = OnTopSprite;
			}
			else
			{
				PutOnTopButton.sprite = OnBackSprite;
			}
			PutOnTopButton.gameObject.SetActive(value: true);
		}
		else
		{
			PutOnTopButton.gameObject.SetActive(value: false);
		}
	}

	public void ProcessEndOfGame()
	{
		EndOfGameController.Stats_TimePlayed = GameController.Instance.TimePlayed;
		EndOfGameController.Stats_TotalGarbageCreated = GameController.TotalGarbageCreated;
		EndOfGameController.Stats_TotalTossedGarbage = GameController.TotalTossedGarbage;
		EndOfGameController.Stats_TotalPeonGarbageTossed = GameController.TotalPeonTrashThrow;
		EndOfGameController.Stats_TotalCloudClick = GameController.TotalCloudClick;
		EndOfGameController.Stats_TotalCloudDestroyed = GameController.TotalCloudDestroyed;
		EndOfGameController.Stats_TotalMoney = GameController.Instance.Money.TotalAmount;
		EndOfGameController.Stats_TotalRP = GameController.Instance.ResearchPoint.TotalAmount;
		EndOfGameController.Stats_TotalYellow = GameController.Instance.YellowPoint.TotalAmount;
		EndOfGameController.Stats_TotalBlue = GameController.Instance.BluePoint.TotalAmount;
		EndOfGameController.Stats_TotalRed = GameController.Instance.RedPoint.TotalAmount;
		EndOfGameController.Stats_TotalBook = GameController.Instance.Book.TotalAmount;
		EndOfGameController.IsBadEnding = true;
		if (Installation.IsDemo())
		{
			SceneManager.LoadScene("EndOfGameScene");
			return;
		}
		if (Temple.GlobalInfo.CanHaveLazerAttribute.IsEnabled)
		{
			foreach (ColumnController column in GameController.Instance.ColumnsController.GetColumns())
			{
				if (column.Buildings != null && column.Buildings.BuildingType == BaseBuilding.BuildingTypeEnum.Temple && column.Buildings.GetLevel() >= 9)
				{
					EndOfGameController.IsBadEnding = false;
				}
			}
		}
		if (EndOfGameController.IsBadEnding)
		{
			AchievementDefinition.ProcessBadEnding(GameController.Instance.Achievements);
		}
		else
		{
			AchievementDefinition.ProcessGoodEnding(GameController.Instance.Achievements);
		}
		SceneManager.LoadScene("EndAnimation");
	}

	private void UpdateStats()
	{
		if (_cachedSeeStats != GameController.SeeStats)
		{
			_cachedSeeStats = GameController.SeeStats;
			StatsPanel.SetActive(_cachedSeeStats);
		}
		if (_cachedSeeStats)
		{
			MoneyStats.text = "<color=yellow>" + GameController.Instance.Money.Get60SecAverage().ToNumber() + " $</color> / min";
			RpStats.text = "<color=#FFC0CB>" + GameController.Instance.ResearchPoint.Get60SecAverage().ToNumber() + " RP</color> / min";
			HoleStats.text = "<color=green>" + GameController.Instance.HoleFilled.Get60SecAverage().ToNumber() + " Fill</color> / min";
		}
	}
}
