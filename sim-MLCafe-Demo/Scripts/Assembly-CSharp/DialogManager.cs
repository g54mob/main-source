using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
	[SerializeField]
	private DialogSequence dialogMissing;

	[SerializeField]
	private DialogSequence customerDialogProdcutSizes;

	[SerializeField]
	private List<DialogSequence> customerDialogReactions;

	[SerializeField]
	private List<DialogSequence> customerDialogChatting;

	[SerializeField]
	private List<TutorialSection> smoghDialogTutorial;

	[SerializeField]
	private List<DialogSequence> smoghDialogReactions;

	[SerializeField]
	private List<DialogSequence> smoghDialogCasual;

	[Header("Dialog Properties")]
	[SerializeField]
	private float textAnimationSpeed = 0.05f;

	[SerializeField]
	private bool useTextAnimation = true;

	[Header("Auto Dialog")]
	[SerializeField]
	private bool autoplayDialogSequence = true;

	[SerializeField]
	private float dialogStayDuration = 3f;

	private static DialogManager instance;

	public static void SetTextAnimationSpeed(float value)
	{
		instance.textAnimationSpeed = value;
	}

	public static float GetTextAnimationSpeed()
	{
		return instance.textAnimationSpeed;
	}

	public static float GetTextAnimationSpeedMaximum()
	{
		return 200f;
	}

	public static float GetTextAnimationSpeedMinimum()
	{
		return 0f;
	}

	public static void SetTextAnimation(bool enable)
	{
		instance.useTextAnimation = enable;
	}

	public static bool IsAnimationActivated()
	{
		return instance.useTextAnimation;
	}

	public static void SetDialogAutoplay(bool autoplay)
	{
		instance.autoplayDialogSequence = autoplay;
	}

	public static bool IsAutoplayActive()
	{
		return instance.autoplayDialogSequence;
	}

	public static void SetDialogDuration(float value)
	{
		instance.dialogStayDuration = value;
	}

	public static float GetDialogDuration()
	{
		return instance.dialogStayDuration;
	}

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		Object.DontDestroyOnLoad(instance);
	}

	private void Start()
	{
		InputManager.OnCancelMenuWindow.AddListener(PopupMessageManager.GetDialogPopUp().ExitEscape);
		InputManager.OnMainClick.AddListener(PopupMessageManager.GetDialogPopUp().NextDialog);
	}

	public static DialogManager GetInstance()
	{
		return instance;
	}

	public static bool IsValidated()
	{
		return instance != null;
	}

	public static string GetMissingDialog()
	{
		return instance.dialogMissing.GetFirstKey();
	}

	public static DialogSequence GetCustomerDialogProductSizes()
	{
		return instance.customerDialogProdcutSizes;
	}

	public static List<DialogSequence> GetCustomerDialogReactions()
	{
		return instance.customerDialogReactions;
	}

	public static List<DialogSequence> GetCustomerDialogChatting()
	{
		return instance.customerDialogChatting;
	}

	public static List<DialogSequence> GetSmoghDialogReactions()
	{
		return instance.smoghDialogReactions;
	}

	public static List<DialogSequence> GetSmoghDialogCasual()
	{
		return instance.smoghDialogCasual;
	}
}
