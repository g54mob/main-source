using System;
using App.Data;
using Aux;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class ComputerBuildingController : ActiveComponent
{
	[SceneBind("LineContainer")]
	public RectTransform lineContainer;

	[SceneBind("CompleteButton")]
	private Button completeButton;

	[SceneBind("Computer/SocketIn")]
	private Socket computerSocketIn;

	[SceneBind("Computer/SocketOut1")]
	private Socket computerSocketOut1;

	[SceneBind("Computer/SocketOut2")]
	private Socket computerSocketOut2;

	[SceneBind("PowerSocket/SocketOut")]
	private Socket powerSocketOut;

	[SceneBind("Monitor/SocketIn")]
	private Socket monitorSocketIn;

	[SceneBind("Keyboard/SocketIn")]
	private Socket keyboardSocketIn;

	[SceneBind("FailWindow")]
	private Transform failWindow;

	[SceneBind("OkWindow")]
	private Transform okWindow;

	[SceneBind("OkWindow/OkBtn")]
	private Button closeBtn;

	[SceneBind("FailWindow/HelpInform")]
	private Text failWindowText;

	[SceneBind("FailWindow/OkBtn")]
	private Button failWindowOkBtn;

	[SceneBind("CompleteButtonOpacity")]
	private OpacitySin completeButtonOpacity;

	[SceneBind("Computer/EnabledImage")]
	private Image computerEnabledImage;

	[SceneBind("Keyboard/EnabledImage")]
	private Image keyboardEnabledImage;

	[SceneBind("Monitor/EnabledImage")]
	private Image monitorEnabledImage;

	[SceneBind("FirstTutorialWindow")]
	private Transform firstTutorial;

	[SceneBind("FirstTutorialWindow/BackgroundImage1")]
	private Button closeTutorial1;

	[SceneBind("FirstTutorialWindow/BackgroundImage2")]
	private Button closeTutorial2;

	[SceneBind("FirstTutorialWindow/BackgroundImage3")]
	private Button closeTutorial3;

	[SceneBind("SecondTutorialWindow")]
	private Transform secondTutorial;

	[SceneBind("PowerSocket/PowerSocketOpacity")]
	private Image powerSocketOpacity;

	[SceneBind("Computer/ComputerSocketInOpacity")]
	private Image computerSocketInOpacity;

	[SceneBind("Computer/ComputerSocketInLock")]
	private Image computerSocketIntLock;

	[SceneBind("Blocker")]
	private Image blocker;

	[SceneBind("Cursor")]
	private Image Cursor;

	[SceneBind("SteamDeckPaw")]
	private Image SteamDeckPaw;

	[SceneBind("BlockerLineDelete")]
	private Image BlockerLineDelete;

	private Color activeColor;

	private Color inactiveColor;

	private bool started;

	private const int newElemFixedUpdateThreshold = 20;

	private int fixedUpdatesCompleted;

	private bool monitorKeyboardTurn;

	private int elemBalance;

	private byte runResult;

	private Action callback;

	private const string elementSpriteName = "lightning";

	private bool cursorSetToEnd;

	private byte computerEnabled;

	private byte monitorEnabled;

	private byte keyboardEnabled;

	private byte ComputerEnabled
	{
		get
		{
			return computerEnabled;
		}
		set
		{
			computerEnabled = value;
			computerEnabledImage.gameObject.SetActive(value == 2);
		}
	}

	private byte MonitorEnabled
	{
		get
		{
			return monitorEnabled;
		}
		set
		{
			monitorEnabled = value;
			monitorEnabledImage.gameObject.SetActive(value == 2);
			if (value == 2)
			{
				ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", Logic.GetModel().globalSaves.soundVolume);
			}
		}
	}

	private byte KeyboardEnabled
	{
		get
		{
			return keyboardEnabled;
		}
		set
		{
			keyboardEnabled = value;
			keyboardEnabledImage.gameObject.SetActive(value == 2);
		}
	}

	private bool CheckAllConnected()
	{
		if (powerSocketOut.chain != null && computerSocketOut1.chain != null && computerSocketOut2.chain != null && computerSocketIn.inChains.Count > 0 && monitorSocketIn.inChains.Count > 0)
		{
			return keyboardSocketIn.inChains.Count > 0;
		}
		return false;
	}

	private void CheckScheme()
	{
		if (computerSocketOut1.chain != null && computerSocketOut1.chain.socketOut == computerSocketIn)
		{
			computerSocketOut1.chain.DestroyGameObject();
		}
		if (computerSocketOut2.chain != null && computerSocketOut2.chain.socketOut == computerSocketIn)
		{
			computerSocketOut2.chain.DestroyGameObject();
		}
		if (powerSocketOut.chain != null && powerSocketOut.chain.socketOut == computerSocketIn)
		{
			ComputerEnabled = 1;
			MonitorEnabled = (byte)(((computerSocketOut1.chain != null && computerSocketOut1.chain.socketOut == monitorSocketIn) || (computerSocketOut2.chain != null && computerSocketOut2.chain.socketOut == monitorSocketIn)) ? 1u : 0u);
			KeyboardEnabled = (byte)(((computerSocketOut1.chain != null && computerSocketOut1.chain.socketOut == keyboardSocketIn) || (computerSocketOut2.chain != null && computerSocketOut2.chain.socketOut == keyboardSocketIn)) ? 1u : 0u);
			if (MonitorEnabled > 0 && KeyboardEnabled > 0)
			{
				secondTutorial.gameObject.SetActive(!okWindow.gameObject.activeSelf);
				completeButtonOpacity.gameObject.SetActive(value: true);
			}
		}
		else
		{
			ComputerEnabled = 0;
			MonitorEnabled = 0;
			KeyboardEnabled = 0;
		}
	}

	private void CloseTutorialWindow()
	{
		firstTutorial.gameObject.SetActive(value: false);
	}

	private void CloseWindow()
	{
		if (!ActiveComponent._controller.Transition.gameObject.activeSelf)
		{
			ActiveComponent._controller.Transition.gameObject.SetActive(value: true);
			ActiveComponent._controller.Transition.ActiveOnFade(delegate
			{
				base.gameObject.SetActive(value: false);
			});
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		activeColor = Logic.GetColor("GREEN");
		inactiveColor = Logic.GetColor("GREY");
		okWindow.gameObject.SetActive(value: false);
		closeBtn.onClick.AddListener(CloseWindow);
		completeButton.onClick.AddListener(delegate
		{
			StartElectrons();
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		});
		failWindowOkBtn.onClick.AddListener(delegate
		{
			failWindow.gameObject.SetActive(value: false);
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			blocker.gameObject.SetActive(value: false);
		});
		computerSocketIn.onEndDragAction = (powerSocketOut.onEndDragAction = delegate
		{
			CheckScheme();
			if ((firstTutorial.gameObject.activeSelf || powerSocketOpacity.gameObject.activeInHierarchy || computerSocketInOpacity.gameObject.activeInHierarchy) && ComputerEnabled > 0)
			{
				powerSocketOpacity.gameObject.SetActive(value: false);
				computerSocketInOpacity.gameObject.SetActive(value: false);
				CloseTutorialWindow();
			}
		});
		computerEnabledImage.color = activeColor;
		keyboardEnabledImage.color = activeColor;
		computerSocketInOpacity.gameObject.SetActive(value: false);
		powerSocketOpacity.gameObject.SetActive(value: false);
		computerSocketOut1.gameObject.SetActive(value: false);
		computerSocketOut2.gameObject.SetActive(value: false);
		keyboardSocketIn.gameObject.SetActive(value: false);
		monitorSocketIn.gameObject.SetActive(value: false);
		BlockerLineDelete.gameObject.SetActive(value: false);
	}

	private void StartElectrons()
	{
		blocker.gameObject.SetActive(value: true);
		if (!CheckAllConnected())
		{
			failWindowText.text = TextResources.GetString(CheckAllConnected() ? "CB_WRONG_CONNECT" : "CB_NOT_ALL_CONNECTEDSTARTGAME");
			failWindow.gameObject.SetActive(value: true);
			ActiveComponent.Program.cursor.SetPosition(failWindowOkBtn.transform.position);
			ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_Text_Loop", 0f);
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_WarningPopup");
			runResult = 0;
			return;
		}
		secondTutorial.gameObject.SetActive(value: false);
		completeButtonOpacity.gameObject.SetActive(value: false);
		Chain[] componentsInChildren = lineContainer.GetComponentsInChildren<Chain>();
		ActiveComponent.Model.curSpeed = 2f;
		Chain[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].DropValues();
		}
		started = true;
		fixedUpdatesCompleted = 0;
		elemBalance = 0;
		Helper.ButtonInteractible(completeButton, interactible: false, activeColor, inactiveColor);
	}

	private void RemoveOverflowElement(Socket socket)
	{
		if (socket.chain == null && socket.GetElement() != null)
		{
			elemBalance--;
		}
	}

	private void Update()
	{
		if (!base.IsInited)
		{
			return;
		}
		if (!started && elemBalance == 0)
		{
			CheckScheme();
		}
		if (elemBalance == 0 && !started)
		{
			Helper.ButtonInteractible(completeButton, interactible: true, activeColor, inactiveColor);
			if (runResult == 1)
			{
				failWindowText.text = TextResources.GetString(CheckAllConnected() ? "CB_WRONG_CONNECT" : "CB_NOT_ALL_CONNECTED");
				failWindow.gameObject.SetActive(value: true);
				ActiveComponent.Program.cursor.SetPosition(failWindowOkBtn.transform.position);
				ActiveComponent.Sound.SetLoopVolume("Monokanal/WhileTrueLearn_Text_Loop", 0f);
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_WarningPopup");
				runResult = 0;
			}
			else if (runResult == 2)
			{
				ActiveComponent.Model.P.computerBuildingTutorialCompleted = true;
				okWindow.gameObject.SetActive(value: true);
				if (!cursorSetToEnd)
				{
					ActiveComponent.Program.cursor.SetPosition(closeBtn.transform.position);
				}
				cursorSetToEnd = true;
				secondTutorial.gameObject.SetActive(value: false);
				ActiveComponent.Model.curSpeed = 1f;
				if (callback != null)
				{
					callback();
				}
			}
			if (ComputerEnabled == 2)
			{
				ComputerEnabled = 1;
				if (MonitorEnabled == 2)
				{
					MonitorEnabled = 1;
				}
				if (KeyboardEnabled == 2)
				{
					KeyboardEnabled = 1;
				}
			}
			return;
		}
		RemoveOverflowElement(powerSocketOut);
		RemoveOverflowElement(computerSocketOut1);
		RemoveOverflowElement(computerSocketOut2);
		Element element;
		if (computerSocketIn.inChains.Count > 0)
		{
			element = computerSocketIn.GetElement();
			if (element != null)
			{
				if (started)
				{
					ComputerEnabled = 2;
				}
				if (monitorKeyboardTurn)
				{
					computerSocketOut1.SetElement(element, calcStats: false);
				}
				else
				{
					computerSocketOut2.SetElement(element, calcStats: false);
				}
				monitorKeyboardTurn = !monitorKeyboardTurn;
			}
		}
		element = monitorSocketIn.GetElement();
		if (element != null)
		{
			if (started)
			{
				MonitorEnabled = 2;
			}
			elemBalance--;
		}
		element = keyboardSocketIn.GetElement();
		if (element != null)
		{
			if (started)
			{
				KeyboardEnabled = 2;
			}
			elemBalance--;
		}
		if (started && ComputerEnabled != 1 && MonitorEnabled != 1 && KeyboardEnabled != 1)
		{
			StopElectrons();
		}
	}

	private void StopElectrons()
	{
		started = false;
		runResult = (byte)((ComputerEnabled != 2 || MonitorEnabled != 2 || KeyboardEnabled != 2) ? 1u : 2u);
	}

	private void UpdateToDummy(Socket outSocket)
	{
		if (outSocket.chain.socketOut != null)
		{
			outSocket.enabled = false;
			outSocket.gameObject.GetComponent<ZoomOnMouse>().enabled = false;
			outSocket.gameObject.GetComponent<Button>().enabled = false;
			outSocket.chain.socketOut.enabled = false;
			outSocket.chain.socketOut.gameObject.GetComponent<ZoomOnMouse>().enabled = false;
			outSocket.chain.socketOut.gameObject.GetComponent<Button>().enabled = false;
		}
	}

	private void FixedUpdate()
	{
		if (!base.IsInited)
		{
			return;
		}
		if (!started)
		{
			if (powerSocketOut.chain != null && computerSocketIn.inChains.Count > 0)
			{
				computerSocketOut1.gameObject.SetActive(value: true);
				computerSocketOut2.gameObject.SetActive(value: true);
				keyboardSocketIn.gameObject.SetActive(value: true);
				monitorSocketIn.gameObject.SetActive(value: true);
				if (Cursor != null)
				{
					Cursor.gameObject.SetActive(value: false);
				}
				if (SteamDeckPaw != null)
				{
					SteamDeckPaw.gameObject.SetActive(value: false);
				}
			}
			if (powerSocketOut.chain != null)
			{
				UpdateToDummy(powerSocketOut);
			}
			if (computerSocketOut1.chain != null)
			{
				UpdateToDummy(computerSocketOut1);
			}
			if (computerSocketOut2.chain != null)
			{
				UpdateToDummy(computerSocketOut2);
			}
		}
		else
		{
			if (fixedUpdatesCompleted == 0)
			{
				powerSocketOut.SetElement(new Element("lightning")
				{
					hideColor = true
				}, calcStats: false);
				elemBalance++;
			}
			fixedUpdatesCompleted = (fixedUpdatesCompleted + 1) % 20;
		}
	}

	public void Init(Action callback = null)
	{
		base.Init();
		this.callback = callback;
		byte b = (KeyboardEnabled = 0);
		byte b3 = (MonitorEnabled = b);
		ComputerEnabled = b3;
		started = false;
		failWindow.gameObject.SetActive(value: false);
		Helper.ButtonInteractible(completeButton, interactible: false, activeColor, inactiveColor);
		completeButtonOpacity.gameObject.SetActive(value: false);
		firstTutorial.gameObject.SetActive(value: true);
		secondTutorial.gameObject.SetActive(value: false);
		computerSocketIntLock.gameObject.SetActive(value: false);
		blocker.gameObject.SetActive(value: false);
	}
}
