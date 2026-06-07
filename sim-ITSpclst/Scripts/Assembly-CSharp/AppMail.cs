using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppMail : MonoBehaviour
{
	[AppNameDropdown]
	[Header("Component Default")]
	public string nameInAppBase;

	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	public AppBrowser appBrowser;

	[Header("Component")]
	public SystemOScypek systemOs;

	public UsersDatabases usersDatabases;

	public yourComputerInSmallCorp computerInSmallCorp;

	public ComputerNetwork computerNetwork;

	public ComputerVariables computerVariables;

	[Header("App Object")]
	public Transform applicationLayout;

	public Transform mailPrefabs;

	public Transform mailList;

	[HideInInspector]
	public bool appMailisOpen;

	[Header("UI")]
	public TMP_InputField find;

	public Transform FullMessage;

	public TextMeshProUGUI FM_name;

	public TextMeshProUGUI FM_from;

	public TextMeshProUGUI FM_to;

	public TextMeshProUGUI FM_title;

	public TextMeshProUGUI FM_contents;

	public string FM_webAddress;

	public int FM_idPDF;

	public TextMeshProUGUI FM_CountAttachments;

	public GameObject FM_webAttachmentsObject;

	public GameObject FM_pdfAttachmentsObject;

	[SerializeField]
	public TextMeshProUGUI gen_txt;

	[SerializeField]
	public TextMeshProUGUI imp_txt;

	[SerializeField]
	public TextMeshProUGUI del_txt;

	[SerializeField]
	public TextMeshProUGUI task_txt;

	[SerializeField]
	public TextMeshProUGUI job_txt;

	[SerializeField]
	public TextMeshProUGUI spam_txt;

	[SerializeField]
	public Image FM_avatar;

	[Header("Font Style & Size for description mail")]
	public TMP_FontAsset[] fontAssets;

	[HideInInspector]
	public float fontSize;

	[HideInInspector]
	public int fontStyle;

	[Header("Objects")]
	public GameObject app_mail;

	[Header("Objects")]
	public GameObject mail_message;

	public GameObject trash;

	public GameObject nonetworkText;

	public GameObject permanentlyDelete;

	[Header("Variable")]
	public bool isOpen;

	public string activeTagMail;

	private Mail nowOpenedMail;

	public int spamMailCounter;

	public GameObject settings;

	public GameObject applicationStyleView;

	public GameObject notificationView;

	public GameObject[] isCurrent;

	public Image[] bgWallpaperMail;

	public Sprite[] wallpaper;

	public Image bgMailWallpaperGenerla;

	public GameObject notificationSoundOn;

	public GameObject notificationSoundOff;

	public GameObject generalPushOn;

	public GameObject jobblyPushOn;

	public GameObject spamPushOn;

	public Image[] bgFontSize;

	public Image[] bgFontStyle;

	public string hexColorGray;

	public string hexColorBlue;

	public Color newColorGray;

	public Color newColorBlue;

	public Mail nowOpenMail;

	private AppBase appBase;

	private DirectoryManager directoryManager;

	private string AppNameFromApplicationBase;

	private void Start()
	{
	}

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public void RemoveDeletedMail()
	{
	}

	public int CountMailsByTag(string tag)
	{
		return 0;
	}

	public void CountAllMails()
	{
	}

	public void RenderMail(string type)
	{
	}

	public void ClearMail()
	{
	}

	public void RenderListMail(List<Mail> mails, string type)
	{
	}

	public void SetFontForContentMail()
	{
	}

	public void OpenMail(Mail mail)
	{
	}

	public void OpenBrowser()
	{
	}

	public void OpenAndDownloadPdf()
	{
	}

	public void DeleteButton()
	{
	}

	public void CloseButton()
	{
	}

	public void UpdateFindText()
	{
	}

	public void ResetSettingsView()
	{
	}

	public void ResetBGFontSize()
	{
	}

	public void ResetBGFontStyle()
	{
	}

	public void SetBGFontSize()
	{
	}

	public void OpenSettings()
	{
	}

	public void OpenNotification()
	{
	}

	public void SetPushNotificationGeneral()
	{
	}

	public void SetPushNotificationJobbly()
	{
	}

	public void SetPushNotificationSpam()
	{
	}

	public void SetNotificationSound()
	{
	}

	public void CloseSettings()
	{
	}

	public void ResetBg()
	{
	}

	public void SetWallpaper(int number)
	{
	}

	public void SetPaletteCollor()
	{
	}
}
