using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PcManager : MonoBehaviour
{
	public enum PcWindowState
	{
		None = 0,
		FileExplorer = 1,
		Email = 2,
		Internet = 3,
		Trash = 4,
		Password = 5,
		Document = 6,
		CorruptedTrashWarning = 7
	}

	private enum PasswordStatus
	{
		Idle = 0,
		Success = 1,
		Failed = 2
	}

	public static PcManager Singleton;

	public bool pcIsOn;

	public PcWindowState pcWindowState = PcWindowState.Password;

	[Header("PC UI")]
	[SerializeField]
	private GameObject pcScreen_Desktop;

	[Header("Windows")]
	[SerializeField]
	private GameObject pcScreen_Window_FileExplorer;

	[SerializeField]
	private GameObject pcScreen_Window_Email;

	[SerializeField]
	private GameObject pcScreen_Window_Internet;

	[SerializeField]
	private GameObject pcScreen_Window_SmoothieDoc;

	[SerializeField]
	private GameObject pcScreen_Window_CorruptedTrashWarning;

	[Header("Clickable Icons")]
	[SerializeField]
	private GameObject pcIcon_Disk;

	[SerializeField]
	private GameObject pcIcon_Disk_SelectedBacker;

	[SerializeField]
	private GameObject pcIcon_Trash_SelectedBacker;

	[SerializeField]
	private GameObject pcIcon_Email_SelectedBacker;

	[SerializeField]
	private GameObject pcIcon_Internet_SelectedBacker;

	[SerializeField]
	private GameObject pcIcon_SmoothieDoc_SelectedBacker;

	[Header("Email")]
	[SerializeField]
	private List<GameObject> emails_Bank;

	[SerializeField]
	private List<GameObject> inboxButtons_Bank;

	[SerializeField]
	private int lastSelectedEmail_Index = -1;

	[Header("Bookmarks")]
	[SerializeField]
	private List<GameObject> webpages_Bank;

	[SerializeField]
	private List<GameObject> bookmarkButtons_Bank;

	[SerializeField]
	private int lastSelectedBookmark_Index = -1;

	[Header("Disk Related")]
	[SerializeField]
	private List<GameObject> diskFolders_Bank;

	[SerializeField]
	private Transform diskEjectedSpot;

	public int diskCurrentlyInComputer_Index = -1;

	[SerializeField]
	private GameObject diskCurrentlyInComputer_GameObject;

	private float insertDiscCooldown = 1.5f;

	private float insertDiscCooldown_Curr;

	private bool lastWindowWasDiskExplorer;

	[Header("Other Folder Content")]
	[SerializeField]
	private GameObject folderContents_Trash;

	[Header("Animation")]
	[SerializeField]
	private Animator anim_DiskDrive;

	[SerializeField]
	private Transform anim_DiskDrive_ArtParent;

	private GameObject anim_DuplicatedDiskArt;

	[Header("PC Lights")]
	[SerializeField]
	private Light pcLight_BlueScreen;

	[Header("Password screen")]
	[SerializeField]
	private GameObject passwordScreen_UIGroup;

	[SerializeField]
	private Image passwordScreen_Backer;

	[SerializeField]
	private TMP_Text passwordScreen_HeaderText;

	private bool passwordScreen_TempLockout;

	[SerializeField]
	private Color passwordScreen_Backer_Color_Success;

	[SerializeField]
	private Color passwordScreen_Backer_Color_Failed;

	[SerializeField]
	private Color passwordScreen_Backer_Color_Default;

	public bool hasUnlockedPC;

	[SerializeField]
	private TMP_Text passwordEntering_Text;

	private int passwordEntering_InputIndex;

	private char[] passwordEntered_CharArray = new char[4] { '9', '9', '9', '9' };

	private char[] correctPassword_CharArray = new char[4] { 'b', 'i', 'q', 't' };

	[Header("Black Star Progress Display")]
	[SerializeField]
	private TMP_Text blackStarCounterDisplay;

	[Header("Confession")]
	[SerializeField]
	private AudioSource confession_AudioSource;

	public bool confession_IsPlaying;

	[SerializeField]
	private GameObject censored_TrashCan;

	public GameObject disk_Burned;

	public GameObject burned_MsRainbow;

	public Action OnPCButtonClicked_Action;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	private void Start()
	{
		PuzzleManager singleton = PuzzleManager.Singleton;
		singleton.Action_BlackStars_OnChanged = (Action)Delegate.Combine(singleton.Action_BlackStars_OnChanged, new Action(BlackStars_OnChange));
		GameManager singleton2 = GameManager.Singleton;
		singleton2.OnRoundStart_Action = (Action)Delegate.Combine(singleton2.OnRoundStart_Action, new Action(OnRoundStart));
		GameManager singleton3 = GameManager.Singleton;
		singleton3.OnNightTime_Action = (Action)Delegate.Combine(singleton3.OnNightTime_Action, new Action(OnNightTime));
		UpdateInputtedPasswordString();
		disk_Burned.SetActive(value: false);
		burned_MsRainbow.SetActive(value: false);
	}

	private void OnDestroy()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnNightTime_Action = (Action)Delegate.Remove(singleton.OnNightTime_Action, new Action(OnNightTime));
		PuzzleManager singleton2 = PuzzleManager.Singleton;
		singleton2.Action_BlackStars_OnChanged = (Action)Delegate.Remove(singleton2.Action_BlackStars_OnChanged, new Action(BlackStars_OnChange));
		GameManager singleton3 = GameManager.Singleton;
		singleton3.OnRoundStart_Action = (Action)Delegate.Remove(singleton3.OnRoundStart_Action, new Action(OnRoundStart));
	}

	private void Update()
	{
		HandleInsertDiscCooldown();
	}

	private void HideAllPCScreensAndLights()
	{
		pcScreen_Desktop.SetActive(value: false);
		pcLight_BlueScreen.gameObject.SetActive(value: false);
	}

	private void OnNightTime()
	{
		TurnOnComputer();
	}

	private void TurnOnComputer()
	{
		if (!pcIsOn)
		{
			pcIsOn = true;
			pcScreen_Desktop.SetActive(value: false);
			pcLight_BlueScreen.gameObject.SetActive(value: true);
			HideAllPCWindows();
			OpenWindow(4);
		}
	}

	public void HideAllPCWindows()
	{
		pcScreen_Window_Email.SetActive(value: false);
		pcScreen_Window_FileExplorer.SetActive(value: false);
		pcScreen_Window_Internet.SetActive(value: false);
		pcScreen_Window_SmoothieDoc.SetActive(value: false);
		pcScreen_Window_CorruptedTrashWarning.SetActive(value: false);
		pcIcon_Disk_SelectedBacker.SetActive(value: false);
		pcIcon_Email_SelectedBacker.SetActive(value: false);
		pcIcon_Internet_SelectedBacker.SetActive(value: false);
		pcIcon_Trash_SelectedBacker.SetActive(value: false);
		pcIcon_SmoothieDoc_SelectedBacker.SetActive(value: false);
		passwordScreen_UIGroup.SetActive(value: false);
	}

	public void OpenWindow(int _index)
	{
		HideAllPCWindows();
		HideAllDiskFolders();
		if (_index == 3 && !PuzzleManager.Singleton.HasAllBlackStarPuzzlesCompleted())
		{
			_index = 6;
		}
		switch (_index)
		{
		case -1:
			pcWindowState = PcWindowState.None;
			break;
		case 0:
			pcScreen_Desktop.SetActive(value: true);
			pcWindowState = PcWindowState.FileExplorer;
			pcScreen_Window_FileExplorer.SetActive(value: true);
			pcIcon_Disk_SelectedBacker.SetActive(value: true);
			OpenDisk();
			AudioManager.Singleton.PlaySFX_MouseClick();
			break;
		case 1:
			pcScreen_Desktop.SetActive(value: true);
			pcWindowState = PcWindowState.Email;
			pcScreen_Window_Email.SetActive(value: true);
			pcIcon_Email_SelectedBacker.SetActive(value: true);
			AudioManager.Singleton.PlaySFX_MouseClick();
			break;
		case 2:
			pcScreen_Desktop.SetActive(value: true);
			pcWindowState = PcWindowState.Internet;
			pcScreen_Window_Internet.SetActive(value: true);
			pcIcon_Internet_SelectedBacker.SetActive(value: true);
			AudioManager.Singleton.PlaySFX_MouseClick();
			break;
		case 3:
			pcScreen_Desktop.SetActive(value: true);
			folderContents_Trash.SetActive(value: true);
			pcWindowState = PcWindowState.Trash;
			pcScreen_Window_FileExplorer.SetActive(value: true);
			pcIcon_Trash_SelectedBacker.SetActive(value: true);
			AudioManager.Singleton.PlaySFX_MouseClick();
			if (!PlayerStats.Singleton.hasOpenedTrash)
			{
				VcrIntroManager.Singleton.StartGlitchedOutBlackStarOrbEffect();
				AudioManager.Singleton.PlaySFX_GlitchedAlarm();
				PlayerStats.Singleton.hasOpenedTrash = true;
				HideTrashCanCensor();
				CassettesManager.Singleton.CheckCassetteRequirements();
			}
			break;
		case 4:
			pcScreen_Desktop.SetActive(value: false);
			pcWindowState = PcWindowState.Password;
			passwordScreen_UIGroup.SetActive(value: true);
			UpdateInputtedPasswordString();
			break;
		case 5:
			pcScreen_Desktop.SetActive(value: true);
			pcWindowState = PcWindowState.Document;
			pcIcon_SmoothieDoc_SelectedBacker.SetActive(value: true);
			pcScreen_Window_SmoothieDoc.SetActive(value: true);
			AudioManager.Singleton.PlaySFX_MouseClick();
			break;
		case 6:
			pcScreen_Desktop.SetActive(value: true);
			pcWindowState = PcWindowState.CorruptedTrashWarning;
			pcScreen_Window_CorruptedTrashWarning.SetActive(value: true);
			AudioManager.Singleton.PlaySFX_MouseClick();
			UpdateBlackStarsDisplay();
			break;
		}
	}

	public void Debug_ButtonClickTest()
	{
		Debug.Log("We clicked a pc button! weee!");
	}

	public void HideAllEmails()
	{
		foreach (GameObject item in emails_Bank)
		{
			item.SetActive(value: false);
		}
	}

	public void OpenEmail(int _index)
	{
		HideAllEmails();
		emails_Bank[_index].SetActive(value: true);
		if (lastSelectedEmail_Index != -1)
		{
			inboxButtons_Bank[lastSelectedEmail_Index].transform.GetChild(0).gameObject.SetActive(value: false);
		}
		lastSelectedEmail_Index = _index;
		inboxButtons_Bank[lastSelectedEmail_Index].transform.GetChild(0).gameObject.SetActive(value: true);
		AudioManager.Singleton.PlaySFX_MouseClick();
		InformPlayerStatsWeReadAPcNote(_email: true, _index);
		OnPCButtonClicked_Action?.Invoke();
	}

	public void HideAllWebpages()
	{
		foreach (GameObject item in webpages_Bank)
		{
			item.SetActive(value: false);
		}
	}

	public void OpenWebpage(int _index)
	{
		HideAllWebpages();
		webpages_Bank[_index].SetActive(value: true);
		if (lastSelectedBookmark_Index != -1)
		{
			bookmarkButtons_Bank[lastSelectedBookmark_Index].transform.GetChild(0).gameObject.SetActive(value: false);
		}
		lastSelectedBookmark_Index = _index;
		bookmarkButtons_Bank[lastSelectedBookmark_Index].transform.GetChild(0).gameObject.SetActive(value: true);
		AudioManager.Singleton.PlaySFX_MouseClick();
		InformPlayerStatsWeReadAPcNote(_email: false, _index);
		OnPCButtonClicked_Action?.Invoke();
	}

	private void InformPlayerStatsWeReadAPcNote(bool _email, int _index)
	{
		if (_email)
		{
			switch (_index)
			{
			case 0:
				PlayerStats.Singleton.pc_HasRead_Email_SecurityCodes = true;
				break;
			case 1:
				PlayerStats.Singleton.pc_HasRead_Email_ProductionConcerns = true;
				break;
			case 2:
				PlayerStats.Singleton.pc_HasRead_Email_PoliceRansom = true;
				break;
			case 3:
				PlayerStats.Singleton.pc_HasRead_Email_Meeting = true;
				break;
			case 4:
				PlayerStats.Singleton.pc_HasRead_Email_StudioDisregard = true;
				break;
			}
			return;
		}
		switch (_index)
		{
		case 0:
			PlayerStats.Singleton.pc_HasRead_Website_BarryMissing = true;
			break;
		case 1:
			PlayerStats.Singleton.pc_HasRead_Website_HallowayHeights = true;
			break;
		case 3:
			if (!PlayerStats.Singleton.pc_HasRead_Website_Dissappearances)
			{
				GameManager.Singleton.ShowAdditionalMsRainbowPose(2);
			}
			PlayerStats.Singleton.pc_HasRead_Website_Dissappearances = true;
			break;
		case 4:
			PlayerStats.Singleton.pc_HasRead_Website_Arson = true;
			break;
		case 2:
			break;
		}
	}

	public void InsertDisk(GameObject _diskObject, PickUppable _diskPickup)
	{
		if (insertDiscCooldown_Curr > 0f)
		{
			return;
		}
		try
		{
			PlayerGrabber component = GameManager.Singleton.localPlayerScript.GetComponent<PlayerGrabber>();
			if (component.GetHeldPickuppable() == _diskPickup)
			{
				component.ClearItemInHand();
			}
		}
		catch
		{
		}
		diskCurrentlyInComputer_Index = -1;
		NewDiskInserted_UpdateUI();
		diskCurrentlyInComputer_Index = _diskPickup.disk_Index;
		if ((bool)diskCurrentlyInComputer_GameObject)
		{
			diskCurrentlyInComputer_GameObject.SetActive(value: true);
			diskCurrentlyInComputer_GameObject.transform.position = diskEjectedSpot.position;
			diskCurrentlyInComputer_GameObject.transform.rotation = diskEjectedSpot.rotation;
			Rigidbody component2 = diskCurrentlyInComputer_GameObject.transform.GetComponent<Rigidbody>();
			component2.linearVelocity = Vector3.zero;
			component2.angularVelocity = Vector3.zero;
			component2.AddForce(diskEjectedSpot.transform.forward * 3f, ForceMode.VelocityChange);
		}
		diskCurrentlyInComputer_GameObject = _diskObject;
		if ((bool)anim_DuplicatedDiskArt)
		{
			UnityEngine.Object.Destroy(anim_DuplicatedDiskArt);
			anim_DuplicatedDiskArt = null;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(_diskObject.transform.GetChild(0).gameObject);
		gameObject.transform.SetParent(anim_DiskDrive_ArtParent);
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localRotation = Quaternion.identity;
		anim_DuplicatedDiskArt = gameObject;
		_diskObject.SetActive(value: false);
		anim_DiskDrive.Play("DiskInsert", -1, 0f);
		insertDiscCooldown_Curr = insertDiscCooldown;
		StartCoroutine(WaitASecThen_NewDiskInserted());
	}

	private void HandleInsertDiscCooldown()
	{
		if (insertDiscCooldown_Curr > 0f)
		{
			insertDiscCooldown_Curr -= Time.deltaTime;
		}
		else
		{
			insertDiscCooldown_Curr = 0f;
		}
	}

	private IEnumerator WaitASecThen_NewDiskInserted()
	{
		yield return new WaitForSeconds(1f);
		NewDiskInserted_UpdateUI();
	}

	private void NewDiskInserted_UpdateUI()
	{
		HideAllDiskFolders();
		if (diskCurrentlyInComputer_Index == -1)
		{
			pcIcon_Disk.SetActive(value: false);
			lastWindowWasDiskExplorer = pcWindowState == PcWindowState.FileExplorer;
			if (pcWindowState == PcWindowState.FileExplorer || pcWindowState == PcWindowState.Trash)
			{
				HideAllPCWindows();
			}
		}
		else
		{
			pcIcon_Disk.SetActive(value: true);
			if (lastWindowWasDiskExplorer)
			{
				OpenWindow(0);
			}
		}
	}

	public void HideAllDiskFolders()
	{
		foreach (GameObject item in diskFolders_Bank)
		{
			item.SetActive(value: false);
		}
		folderContents_Trash.SetActive(value: false);
	}

	public void OpenDisk()
	{
		if (diskCurrentlyInComputer_Index != -1)
		{
			HideAllDiskFolders();
			diskFolders_Bank[diskCurrentlyInComputer_Index].SetActive(value: true);
		}
	}

	public void FakeKeyboardKeyPress(int _keyIndex)
	{
		if (!passwordScreen_TempLockout)
		{
			if (passwordEntering_InputIndex >= 4)
			{
				ResetPassword();
			}
			AudioManager.Singleton.PlaySFX_MouseClick();
			char c = '9';
			switch (_keyIndex)
			{
			case 0:
				c = 'q';
				break;
			case 1:
				c = 'w';
				break;
			case 2:
				c = 'e';
				break;
			case 3:
				c = 'r';
				break;
			case 4:
				c = 't';
				break;
			case 5:
				c = 'y';
				break;
			case 6:
				c = 'u';
				break;
			case 7:
				c = 'i';
				break;
			case 8:
				c = 'o';
				break;
			case 9:
				c = 'p';
				break;
			case 10:
				c = 'a';
				break;
			case 11:
				c = 's';
				break;
			case 12:
				c = 'd';
				break;
			case 13:
				c = 'f';
				break;
			case 14:
				c = 'g';
				break;
			case 15:
				c = 'h';
				break;
			case 16:
				c = 'j';
				break;
			case 17:
				c = 'k';
				break;
			case 18:
				c = 'l';
				break;
			case 19:
				c = 'z';
				break;
			case 20:
				c = 'x';
				break;
			case 21:
				c = 'c';
				break;
			case 22:
				c = 'v';
				break;
			case 23:
				c = 'b';
				break;
			case 24:
				c = 'n';
				break;
			case 25:
				c = 'm';
				break;
			}
			passwordEntered_CharArray[passwordEntering_InputIndex] = c;
			passwordEntering_InputIndex++;
			UpdateInputtedPasswordString();
			CheckForCorrectPassword();
		}
	}

	private void UpdateInputtedPasswordString()
	{
		string text = ((passwordEntered_CharArray[0] == '9') ? "_" : passwordEntered_CharArray[0].ToString());
		string text2 = ((passwordEntered_CharArray[1] == '9') ? "_" : passwordEntered_CharArray[1].ToString());
		string text3 = ((passwordEntered_CharArray[2] == '9') ? "_" : passwordEntered_CharArray[2].ToString());
		string text4 = ((passwordEntered_CharArray[3] == '9') ? "_" : passwordEntered_CharArray[3].ToString());
		passwordEntering_Text.text = text + " " + text2 + " " + text3 + " " + text4;
	}

	private void CheckForCorrectPassword()
	{
		for (int i = 0; i < passwordEntered_CharArray.Length; i++)
		{
			if (passwordEntered_CharArray[i] != correctPassword_CharArray[i])
			{
				if (passwordEntering_InputIndex > 3)
				{
					StartCoroutine(Coroutine_HandleTempPasswordLockOut(PasswordStatus.Failed));
				}
				return;
			}
		}
		Debug.Log("Password correct!");
		hasUnlockedPC = true;
		StartCoroutine(Coroutine_HandleTempPasswordLockOut(PasswordStatus.Success));
		if (!AchievementHelper.IsAchievementUnlocked("ACH_UnlockPC"))
		{
			AchievementHelper.UnlockAchievement("ACH_UnlockPC");
		}
	}

	public void ClosePasswordScreenAndShowDesktop()
	{
		pcScreen_Desktop.SetActive(value: true);
		passwordScreen_UIGroup.SetActive(value: false);
	}

	public void ResetPassword()
	{
		for (int i = 0; i < passwordEntered_CharArray.Length; i++)
		{
			passwordEntered_CharArray[i] = '9';
		}
		passwordEntering_InputIndex = 0;
		UpdateInputtedPasswordString();
	}

	private IEnumerator Coroutine_HandleTempPasswordLockOut(PasswordStatus _passStatus)
	{
		passwordScreen_TempLockout = true;
		switch (_passStatus)
		{
		case PasswordStatus.Failed:
			passwordScreen_HeaderText.text = "INVALID PASSWORD";
			passwordScreen_Backer.color = passwordScreen_Backer_Color_Failed;
			break;
		case PasswordStatus.Success:
			passwordScreen_HeaderText.text = "SUCCESS";
			passwordScreen_Backer.color = passwordScreen_Backer_Color_Success;
			break;
		}
		yield return new WaitForSeconds(1.5f);
		passwordScreen_TempLockout = false;
		passwordScreen_Backer.color = passwordScreen_Backer_Color_Default;
		passwordScreen_HeaderText.text = "ENTER PASSWORD";
		ResetPassword();
		ShowDesktopIfPcIsUnlocked();
	}

	public void ShowDesktopIfPcIsUnlocked()
	{
		if (hasUnlockedPC)
		{
			ClosePasswordScreenAndShowDesktop();
		}
	}

	public void HideCorruptedTrashWarning()
	{
		pcScreen_Window_CorruptedTrashWarning.SetActive(value: false);
		pcWindowState = PcWindowState.None;
		AudioManager.Singleton.PlaySFX_MouseClick();
	}

	private void BlackStars_OnChange()
	{
		UpdateBlackStarsDisplay();
		if (PuzzleManager.Singleton.HasAllBlackStarPuzzlesCompleted() && pcWindowState == PcWindowState.CorruptedTrashWarning)
		{
			OpenWindow(-1);
		}
	}

	private void UpdateBlackStarsDisplay()
	{
		blackStarCounterDisplay.text = PuzzleManager.Singleton.GetNumberOfCompletedBlackStarPuzzles() + "/7";
	}

	public void ConfessionMonologue_Play()
	{
		if (!confession_AudioSource.isPlaying)
		{
			AudioManager.Singleton.QuietDownAmbientPlayer(0.4f);
			AudioManager.Singleton.PlaySFX_MouseClick();
			confession_AudioSource.Play();
			confession_IsPlaying = true;
		}
	}

	public void ConfessionMonologue_Stop()
	{
		confession_AudioSource.Stop();
		confession_IsPlaying = false;
		AudioManager.Singleton.ResetQuietedAmbientPlayer();
	}

	private void HandleLoggingConfessionListenedTo()
	{
	}

	public void HideTrashCanCensor()
	{
		censored_TrashCan.SetActive(value: false);
	}

	private void OnRoundStart()
	{
		if (PlayerStats.Singleton.hasOpenedTrash)
		{
			HideTrashCanCensor();
		}
		if (PlayerStats.Singleton.hasListenedToConfession)
		{
			disk_Burned.SetActive(value: true);
			burned_MsRainbow.SetActive(value: true);
			GameManager.Singleton.HideAllAdditionalMsRainbowPoses();
		}
	}
}
