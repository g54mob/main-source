using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
	private class PeonAction
	{
		public float TimeLeft;

		public int Action;

		public float Destination;
	}

	public GameObject ContinueButton;

	public Image BlackImage;

	public List<CharDisplay> Characters = new List<CharDisplay>();

	public List<Flower> Flowers = new List<Flower>();

	public GameObject Rock;

	public GameObject PositionMin;

	public GameObject PositionMax;

	public GameObject AreYouSurePanel;

	public GameObject MainMenuPanel;

	public GameObject SettingPanel;

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

	public static bool SkipMainMenu = true;

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
			GameController.TotalGarbageCreated = 0;
			GameController.TotalTossedGarbage = 0;
			GameController.TotalCloudClick = 0;
			GameController.TotalCloudClickDestroyed = 0;
			GameController.TotalCloudDestroyed = 0;
			GameController.TotalPeonTrashThrow = 0;
			GameController.TotalPeonThrow = 0;
			GameController.TotalBlockedOutput = 0;
			SaveManager.ClearGameSaveData();
			Global.IsNewGame = true;
			BlackImage.color = new Color(0f, 0f, 0f, 0f);
			BlackImage.gameObject.SetActive(value: true);
			SceneManager.LoadScene("MainScene");
		}
	}

	private void Start()
	{
		CharDisplay.HasQuestionBubble = false;
		GameController.Instance = null;
		SettingController.LoadDefault();
		MainMenuPanel.SetActive(value: true);
		RelaxModeToggle.gameObject.SetActive(value: true);
		SettingPanel.SetActive(value: false);
		Global.WentToMainMenu = true;
		foreach (Flower flower in Flowers)
		{
			flower.SetRandomLevel();
		}
		if (SaveManager.HasGameSaveData())
		{
			ContinueButton.SetActive(value: true);
		}
		else
		{
			ContinueButton.SetActive(value: false);
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
		RelaxModeToggle.isOn = CharDisplay.HasRelax;
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

	public void NewGameClick()
	{
		if (SaveManager.HasGameSaveData())
		{
			OpenAreYouSurePanel();
		}
		else
		{
			ReallyNewGameClick();
		}
	}

	public void ReallyNewGameClick()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		GarbageClickEvent();
		SkillTreePanel.DisplayAllNodes = false;
		Sign.PreventEvent = false;
		Garbage.HasBulldozer = false;
		Garbage.BulldozerPosition = 0f;
		GameController.TotalGarbageCreated = 0;
		GameController.TotalTossedGarbage = 0;
		GameController.TotalCloudClick = 0;
		GameController.TotalCloudClickDestroyed = 0;
		GameController.TotalCloudDestroyed = 0;
		GameController.TotalPeonTrashThrow = 0;
		GameController.TotalPeonThrow = 0;
		GameController.TotalBlockedOutput = 0;
		SaveManager.ClearGameSaveData();
		Global.IsNewGame = true;
		BlackImage.color = new Color(0f, 0f, 0f, 0f);
		BlackImage.gameObject.SetActive(value: true);
		BlackImage.DOFade(1f, 1f).SetEase(Ease.InQuad).OnComplete(delegate
		{
			SceneManager.LoadScene("MainScene");
		});
	}

	public void RelaxMode()
	{
		if (!CharDisplay.HasRelax)
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

	public void ContinueClick()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		GarbageClickEvent();
		SaveManager.LoadGameData();
		BlackImage.color = new Color(0f, 0f, 0f, 0f);
		BlackImage.gameObject.SetActive(value: true);
		BlackImage.DOFade(1f, 1f).SetEase(Ease.InQuad).OnComplete(delegate
		{
			SceneManager.LoadScene("MainScene");
		});
	}

	public void QuitClick()
	{
		Application.Quit();
	}

	public void ShowSettingClick()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		MainMenuPanel.SetActive(value: false);
		RelaxModeToggle.gameObject.SetActive(value: false);
		SettingPanel.SetActive(value: true);
		GarbageClickEvent();
	}

	public void ShowMainMenuClick()
	{
		SaveManager.SaveAppData();
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		MainMenuPanel.SetActive(value: true);
		RelaxModeToggle.gameObject.SetActive(value: true);
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

	public void CloseAreYouSurePanel()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		AreYouSurePanel.SetActive(value: false);
		GarbageClickEvent();
	}

	public void OpenAreYouSurePanel()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		AreYouSurePanel.SetActive(value: true);
		GarbageClickEvent();
	}
}
