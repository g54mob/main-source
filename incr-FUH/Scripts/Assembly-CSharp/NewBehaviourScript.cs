using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using V1;

public class NewBehaviourScript : MonoBehaviour
{
	private class PeonAction
	{
		public float TimeLeft;

		public int Action;

		public float Destination;
	}

	public Image BlackImage;

	public List<CharDisplay> Characters = new List<CharDisplay>();

	public List<Flower> Flowers = new List<Flower>();

	public GameObject Rock;

	public GameObject PositionMin;

	public GameObject PositionMax;

	public GameObject AreYouSurePanel;

	public GameObject MainMenuPanel;

	public GameObject SettingPanel;

	public GameObject GamePanel;

	public GameObject NewGamePanel;

	public int _currentStatus;

	public DateTime _lastChange;

	public GameObject GarbageTemplate;

	public GameObject SettingButton;

	public GameObject BackButton;

	public AudioSource PanelChangeAudio;

	public AudioSource PanelChangeAudio2;

	public SettingController SettingController;

	private List<PeonAction> _peonActions = new List<PeonAction>();

	public Toggle RelaxModeToggle;

	public Toggle ExtendedEditionToggle;

	public UIButton Game1Button;

	public UIButton Game2Button;

	public UIButton Game3Button;

	public GameObject Game1DeleteButton;

	public GameObject Game2DeleteButton;

	public GameObject Game3DeleteButton;

	public TMP_Text Game1Date;

	public TMP_Text Game2Date;

	public TMP_Text Game3Date;

	public static bool SkipMainMenu = true;

	private int _saveGameId;

	private void Awake()
	{
		if (Installation.SkipMainMenu() && SkipMainMenu)
		{
			CharDisplay.HasQuestionBubble = false;
			GameController.Instance = null;
			Global.WentToMainMenu = true;
			SkipMainMenu = false;
			SkillTreePanel.DisplayAllNodes = false;
			Sign.PreventEvent = false;
			Garbage.HasBulldozer = false;
			Garbage.BulldozerPosition = 0f;
			GameController.CurrentSaveId = 1;
			GameController.TotalGarbageCreated = 0;
			GameController.TotalTossedGarbage = 0;
			GameController.TotalCloudClick = 0;
			GameController.TotalCloudClickDestroyed = 0;
			GameController.TotalCloudDestroyed = 0;
			GameController.TotalPeonTrashThrow = 0;
			GameController.TotalPeonThrow = 0;
			GameController.TotalBlockedOutput = 0;
			SaveManager.ClearGameSaveData(1);
			Global.IsNewGame = true;
			BlackImage.color = new Color(0f, 0f, 0f, 0f);
			BlackImage.gameObject.SetActive(value: true);
			SceneManager.LoadScene("MainScene");
		}
	}

	private void Start()
	{
		CharDisplay.HasQuestionBubble = false;
		CharDisplay.HasEndless = false;
		GameController.Instance = null;
		SettingController.LoadDefault();
		MainMenuPanel.SetActive(value: true);
		ExtendedEditionToggle.gameObject.SetActive(!Installation.IsDemo());
		GamePanel.SetActive(value: false);
		SettingPanel.SetActive(value: false);
		Global.WentToMainMenu = true;
		foreach (Flower flower in Flowers)
		{
			flower.SetRandomLevel();
		}
		foreach (CharDisplay character in Characters)
		{
			_ = character;
			PeonAction peonAction = new PeonAction();
			peonAction.TimeLeft = 5f;
			peonAction.Action = 2;
			peonAction.Destination = 0f;
			_peonActions.Add(peonAction);
		}
		_lastChange = DateTime.Now;
		Music2Controller.Instance.PlayBeginingMusic();
	}

	private void Update()
	{
		for (int i = 0; i < Characters.Count; i++)
		{
			_peonActions[i].TimeLeft -= Time.deltaTime;
			if (_peonActions[i].Action == 0)
			{
				Characters[i].ChangeMovement(CharDisplay.MovementEnum.MovingHandDown);
				float num = _peonActions[i].Destination - Characters[i].transform.position.x;
				float num2 = 4f * Time.deltaTime;
				if (num < 0f)
				{
					num2 = 0f - num2;
					Characters[i].ChangeSide(CharDisplay.SideEnum.Left);
				}
				else
				{
					Characters[i].ChangeSide(CharDisplay.SideEnum.Right);
				}
				if (Math.Abs(num) < Math.Abs(num2))
				{
					Characters[i].transform.position = new Vector3(_peonActions[i].Destination, Characters[i].transform.position.y, Characters[i].transform.position.z);
					_peonActions[i].TimeLeft = 0f;
				}
				else
				{
					Characters[i].transform.position = new Vector3(Characters[i].transform.position.x + num2, Characters[i].transform.position.y, Characters[i].transform.position.z);
				}
			}
			if (!(_peonActions[i].TimeLeft <= 0f))
			{
				continue;
			}
			Characters[i].ChangeMovement(CharDisplay.MovementEnum.IdleHandDown);
			if (_peonActions[i].Action == 1)
			{
				_peonActions[i].Action = 2;
				_peonActions[i].TimeLeft = UnityEngine.Random.Range(3, 10);
				Characters[i].ChangeEye(CharDisplay.EyeSpriteEnum.Normal);
				continue;
			}
			if (_peonActions[i].Action == 3)
			{
				_peonActions[i].Action = 2;
				_peonActions[i].TimeLeft = UnityEngine.Random.Range(3, 10);
				Characters[i].ChangeEye(CharDisplay.EyeSpriteEnum.Normal);
				Characters[i].ChangeMouth(CharDisplay.MouthSpriteEnum.Normal);
				continue;
			}
			switch ((UnityEngine.Random.Range(1, 15) >= 2) ? 1 : 0)
			{
			case 1:
				_peonActions[i].Action = 1;
				_peonActions[i].TimeLeft = 1f;
				Characters[i].ChangeEye(CharDisplay.EyeSpriteEnum.Closed);
				break;
			case 0:
				_peonActions[i].Action = 0;
				_peonActions[i].TimeLeft = 999999f;
				_peonActions[i].Destination = UnityEngine.Random.Range(PositionMin.transform.position.x, PositionMax.transform.position.x);
				break;
			}
		}
		if (CharDisplay.HasHat && !ExtendedEditionToggle.isOn)
		{
			ExtendedEditionToggle.isOn = true;
		}
	}

	private void ChangeAllPeon(Vector3 dropPos)
	{
		for (int i = 0; i < Characters.Count; i++)
		{
			_peonActions[i].Action = 3;
			_peonActions[i].TimeLeft = 1.5f;
			Characters[i].ChangeMovement(CharDisplay.MovementEnum.IdleHandDown);
			Characters[i].ChangeEye(CharDisplay.EyeSpriteEnum.Normal);
			Characters[i].ChangeMouth(CharDisplay.MouthSpriteEnum.OpenBig);
			if (dropPos.x < Characters[i].transform.position.x)
			{
				Characters[i].ChangeSide(CharDisplay.SideEnum.Left);
			}
			else
			{
				Characters[i].ChangeSide(CharDisplay.SideEnum.Right);
			}
		}
	}

	public void StartButtonClick()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		LoadGameInfo();
		MainMenuPanel.SetActive(value: false);
		GamePanel.SetActive(value: true);
		SettingPanel.SetActive(value: false);
		GarbageClickEvent();
	}

	public void RelaxMode()
	{
		if (RelaxModeToggle.isOn)
		{
			GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_on);
			CharDisplay.HasRelax = true;
		}
		else
		{
			GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_off);
			CharDisplay.HasRelax = false;
		}
	}

	public void ExtendedEdition()
	{
		if (ExtendedEditionToggle.isOn)
		{
			GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_on);
			CharDisplay.HasHat = true;
		}
		else
		{
			GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_off);
			CharDisplay.HasHat = false;
		}
	}

	public void QuitClick()
	{
		Application.Quit();
	}

	public void ShowSettingClick()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		MainMenuPanel.SetActive(value: false);
		ExtendedEditionToggle.gameObject.SetActive(value: false);
		GamePanel.SetActive(value: false);
		SettingPanel.SetActive(value: true);
		GarbageClickEvent();
	}

	public void ShowMainMenuClick()
	{
		SaveManager.SaveAppData();
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		MainMenuPanel.SetActive(value: true);
		ExtendedEditionToggle.gameObject.SetActive(value: true);
		GamePanel.SetActive(value: false);
		SettingPanel.SetActive(value: false);
		GarbageClickEvent();
	}

	private void GarbageClickEvent()
	{
		Vector3 vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		vector.z = 0f;
		ChangeAllPeon(vector);
		DisplayRandomGarbage(vector);
	}

	private void DisplayRandomGarbage(Vector3 v)
	{
		for (int i = 0; i < 10; i++)
		{
			GameObject go = UnityEngine.Object.Instantiate(GarbageTemplate, base.transform);
			go.transform.position = v;
			go.GetComponent<Rigidbody2D>().AddForce(new Vector2(UnityEngine.Random.Range(-200f, 200f), UnityEngine.Random.Range(0f, 100f)));
			go.GetComponent<Garbage>().EnableAudio();
			go.SetActive(value: true);
			go.transform.Find("Image").GetComponent<SpriteRenderer>().DOFade(0f, 2f)
				.SetDelay(20f)
				.OnComplete(delegate
				{
					UnityEngine.Object.Destroy(go);
				});
		}
	}

	public void OpenSteam()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		if (!Installation.IsSteamConnected() || !ApiManager.Instance.OpenSteamForWishlist())
		{
			Application.OpenURL(Global.SteamUrl);
		}
	}

	public void OpenItch()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		Application.OpenURL(Global.ItchUrl);
	}

	public void PlayGame1()
	{
		_saveGameId = 1;
		PlayGame();
	}

	public void PlayGame2()
	{
		_saveGameId = 2;
		PlayGame();
	}

	public void PlayGame3()
	{
		_saveGameId = 3;
		PlayGame();
	}

	private void PlayGame()
	{
		if (SaveManager.HasGameSaveData(_saveGameId))
		{
			GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
			GarbageClickEvent();
			GameController.CurrentSaveId = _saveGameId;
			SaveManager.LoadGameData(_saveGameId);
			BlackImage.color = new Color(0f, 0f, 0f, 0f);
			BlackImage.gameObject.SetActive(value: true);
			BlackImage.DOFade(1f, 1f).SetEase(Ease.InQuad).OnComplete(delegate
			{
				SceneManager.LoadScene("MainScene");
			});
		}
		else
		{
			OpenNewGamePanel();
		}
	}

	public void DeleteGame1()
	{
		_saveGameId = 1;
		DeleteGame();
	}

	public void DeleteGame2()
	{
		_saveGameId = 2;
		DeleteGame();
	}

	public void DeleteGame3()
	{
		_saveGameId = 3;
		DeleteGame();
	}

	private void DeleteGame()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		AreYouSurePanel.SetActive(value: true);
		GarbageClickEvent();
	}

	public void ReallyDeleteGame()
	{
		SaveManager.ClearGameSaveData(_saveGameId);
		LoadGameInfo();
		CloseReallyDelete();
	}

	public void CloseReallyDelete()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		AreYouSurePanel.SetActive(value: false);
		GarbageClickEvent();
	}

	private void LoadGameInfo()
	{
		if (SaveManager.HasGameSaveData(1))
		{
			MainData gameData = SaveManager.GetGameData(1);
			Game1DeleteButton.SetActive(value: true);
			Game1Date.text = gameData.PrestigeCount + "/" + GameController.GetMaxPrestigeCount();
			if (gameData.IsRelax == 1 && gameData.Special == 8492)
			{
				TMP_Text game1Date = Game1Date;
				game1Date.text = game1Date.text + " " + LanguageText.GetText("Relax") + ", " + LanguageText.GetText("Extended");
			}
			else if (gameData.IsRelax == 1)
			{
				TMP_Text game1Date2 = Game1Date;
				game1Date2.text = game1Date2.text + " " + LanguageText.GetText("Relax");
			}
			else if (gameData.Special == 8492)
			{
				TMP_Text game1Date3 = Game1Date;
				game1Date3.text = game1Date3.text + " " + LanguageText.GetText("Extended");
			}
		}
		else
		{
			Game1DeleteButton.SetActive(value: false);
			Game1Date.text = "";
		}
		if (SaveManager.HasGameSaveData(2))
		{
			MainData gameData2 = SaveManager.GetGameData(2);
			Game2DeleteButton.SetActive(value: true);
			Game2Date.text = gameData2.PrestigeCount + "/" + GameController.GetMaxPrestigeCount();
			if (gameData2.IsRelax == 1 && gameData2.Special == 8492)
			{
				TMP_Text game1Date = Game2Date;
				game1Date.text = game1Date.text + " " + LanguageText.GetText("Relax") + ", " + LanguageText.GetText("Extended");
			}
			else if (gameData2.IsRelax == 1)
			{
				TMP_Text game2Date = Game2Date;
				game2Date.text = game2Date.text + " " + LanguageText.GetText("Relax");
			}
			else if (gameData2.Special == 8492)
			{
				TMP_Text game2Date2 = Game2Date;
				game2Date2.text = game2Date2.text + " " + LanguageText.GetText("Extended");
			}
		}
		else
		{
			Game2DeleteButton.SetActive(value: false);
			Game2Date.text = "";
		}
		if (SaveManager.HasGameSaveData(3))
		{
			MainData gameData3 = SaveManager.GetGameData(3);
			Game3DeleteButton.SetActive(value: true);
			Game3Date.text = gameData3.PrestigeCount + "/" + GameController.GetMaxPrestigeCount();
			if (gameData3.IsRelax == 1 && gameData3.Special == 8492)
			{
				TMP_Text game1Date = Game3Date;
				game1Date.text = game1Date.text + " " + LanguageText.GetText("Relax") + ", " + LanguageText.GetText("Extended");
			}
			else if (gameData3.IsRelax == 1)
			{
				TMP_Text game3Date = Game3Date;
				game3Date.text = game3Date.text + " " + LanguageText.GetText("Relax");
			}
			else if (gameData3.Special == 8492)
			{
				TMP_Text game3Date2 = Game3Date;
				game3Date2.text = game3Date2.text + " " + LanguageText.GetText("Extended");
			}
		}
		else
		{
			Game3DeleteButton.SetActive(value: false);
			Game3Date.text = "";
		}
	}

	private void OpenNewGamePanel()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		RelaxModeToggle.isOn = false;
		ExtendedEditionToggle.isOn = false;
		CharDisplay.HasRelax = false;
		CharDisplay.HasHat = false;
		NewGamePanel.SetActive(value: true);
		GarbageClickEvent();
	}

	public void CloseNewGamePanel()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		RelaxModeToggle.isOn = false;
		ExtendedEditionToggle.isOn = false;
		CharDisplay.HasRelax = false;
		CharDisplay.HasHat = false;
		NewGamePanel.SetActive(value: false);
		GarbageClickEvent();
	}

	public void ReallyNewGame()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		GarbageClickEvent();
		SkillTreePanel.DisplayAllNodes = false;
		Sign.PreventEvent = false;
		Garbage.HasBulldozer = false;
		Garbage.BulldozerPosition = 0f;
		FlyingMinion.FlyingSpeed = 0;
		GameController.CurrentSaveId = _saveGameId;
		GameController.TotalGarbageCreated = 0;
		GameController.TotalTossedGarbage = 0;
		GameController.TotalCloudClick = 0;
		GameController.TotalCloudClickDestroyed = 0;
		GameController.TotalCloudDestroyed = 0;
		GameController.TotalPeonTrashThrow = 0;
		GameController.TotalPeonThrow = 0;
		GameController.TotalBlockedOutput = 0;
		SaveManager.ClearGameSaveData(_saveGameId);
		Global.IsNewGame = true;
		BlackImage.color = new Color(0f, 0f, 0f, 0f);
		BlackImage.gameObject.SetActive(value: true);
		BlackImage.DOFade(1f, 1f).SetEase(Ease.InQuad).OnComplete(delegate
		{
			SceneManager.LoadScene("MainScene");
		});
	}
}
