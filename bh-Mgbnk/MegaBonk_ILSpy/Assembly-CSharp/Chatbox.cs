using System;
using Assets.Scripts.UI.Debug;
using Assets.Scripts.UI.HUD.Chatbox;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Chatbox : MonoBehaviour
{
	public enum EChatUserType
	{
		Game,
		Server,
		Player,
		OtherPlayerStatus,
		Lobby
	}

	public CanvasGroup overlay;

	public bool isTyping;

	private bool cooldown;

	public TextMeshProUGUI messages;

	public TMP_InputField inputField;

	public ScrollRect ScrollRect;

	private float chatFadeTimer;

	private float chatFadeTime = 8f;

	public static Action<ulong, string, string> A_NewMessage;

	private static string storedChat;

	public static Chatbox Instance;

	private const int chatTokenMax = 5;

	private const float chatTokenAddInterval = 1.5f;

	private float chatSentAtTime;

	private float currentTokens = 5f;

	private void Awake()
	{
		if (!Instance)
		{
			Instance = this;
			messages.text = storedChat;
		}
		else
		{
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
		}
	}

	private void OnDestroy()
	{
		string text = messages.text;
		storedChat = text;
	}

	private void Update()
	{
		//IL_0252: Invalid comparison between F4 and I4
		//IL_027e: Expected F4, but got I4
		//IL_0196: Invalid comparison between I4 and F4
		//IL_01b5: Invalid comparison between I4 and F4
		CanvasGroup canvasGroup;
		float alpha2;
		if (SaveManager._003CInstance_003Ek__BackingField != null)
		{
			if (!WindowManager.HasOpenWindow() && !DebugConsole.Instance.IsActive())
			{
				if (Input.GetKeyDownInt(KeyCode.Return))
				{
					if (isTyping)
					{
						SendMessage();
					}
					else
					{
						isTyping = true;
						inputField.Select();
						TMP_InputField tMP_InputField = inputField;
						GameObject gameObject = tMP_InputField.m_Placeholder.gameObject;
						gameObject.SetActive(value: false);
						chatFadeTimer = chatFadeTime;
						overlay.alpha = 1f;
					}
				}
				if (Input.GetKeyDownInt(KeyCode.Escape))
				{
					StopTyping();
				}
			}
			if (isTyping)
			{
				return;
			}
			float alpha = overlay.alpha;
			if (!(0f < alpha) && !(0f < chatFadeTimer))
			{
				return;
			}
			float deltaTime = Time.deltaTime;
			canvasGroup = overlay;
			float num = (chatFadeTimer -= deltaTime);
			alpha2 = ((1f > num) ? num : 1f);
		}
		else
		{
			float alpha3 = overlay.alpha;
			if (alpha3 < 0f)
			{
				return;
			}
			canvasGroup = overlay;
			alpha2 = 0f;
		}
		canvasGroup.alpha = alpha2;
	}

	private void CheckFade()
	{
		//IL_003a: Invalid comparison between I4 and F4
		//IL_0059: Invalid comparison between I4 and F4
		if (isTyping)
		{
			return;
		}
		float alpha = overlay.alpha;
		if (0f < alpha || 0f < chatFadeTimer)
		{
			float deltaTime = Time.deltaTime;
			float num = (chatFadeTimer -= deltaTime);
			bool flag = !(1f > num);
			float alpha2 = 1f;
			if (!flag)
			{
				alpha2 = num;
			}
			overlay.alpha = alpha2;
		}
	}

	private void CheckInput()
	{
		if (WindowManager.HasOpenWindow() || DebugConsole.Instance.IsActive())
		{
			return;
		}
		if (Input.GetKeyDownInt(KeyCode.Return))
		{
			if (isTyping)
			{
				SendMessage();
			}
			else
			{
				isTyping = true;
				inputField.Select();
				TMP_InputField tMP_InputField = inputField;
				GameObject gameObject = tMP_InputField.m_Placeholder.gameObject;
				gameObject.SetActive(value: false);
				chatFadeTimer = chatFadeTime;
				overlay.alpha = 1f;
			}
		}
		if (Input.GetKeyDownInt(KeyCode.Escape))
		{
			StopTyping();
		}
	}

	private void StartTyping()
	{
		isTyping = true;
		inputField.Select();
		TMP_InputField tMP_InputField = inputField;
		GameObject gameObject = tMP_InputField.m_Placeholder.gameObject;
		gameObject.SetActive(value: false);
		chatFadeTimer = chatFadeTime;
		overlay.alpha = 1f;
	}

	private void StopTyping()
	{
		isTyping = false;
		inputField.text = "";
		inputField.ReleaseSelection();
		EventSystem current = EventSystem.current;
		current.SetSelectedGameObject(null);
		TMP_InputField tMP_InputField = inputField;
		GameObject gameObject = tMP_InputField.m_Placeholder.gameObject;
		gameObject.SetActive(value: true);
	}

	private void SendMessage()
	{
		//IL_0199: Invalid comparison between I4 and F4
		//IL_0169: Expected I8, but got I4
		TMP_InputField tMP_InputField = inputField;
		StopTyping();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F20]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		float time = Time.time;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
		double num = Math.Floor(0.0);
		double num2 = num + (double)currentTokens;
		bool flag = !(num2 > 5.0);
		float num3 = (float)num2;
		if (!flag)
		{
			num3 = 5f;
		}
		ulong fromUser;
		string msg;
		if (0f < num3)
		{
			float num4 = num3 - 1f;
			if (num4 > 5f)
			{
				num4 = 5f;
			}
			currentTokens = num4;
			float time2 = Time.time;
			chatSentAtTime = time2;
			if (string.IsNullOrWhiteSpace(tMP_InputField.m_Text) || !(tMP_InputField.m_Text != ""))
			{
				return;
			}
			string text = ChatUtility.SanitizeString(tMP_InputField.m_Text);
			if (!(text != ""))
			{
				return;
			}
			ScrollRect.verticalNormalizedPosition = 0f;
			fromUser = SteamManager.steamId;
			msg = text;
		}
		else
		{
			msg = "Your message was not sent. You're sending too many messages.";
			fromUser = 1uL;
		}
		AppendMessage(fromUser, msg);
	}

	public void AppendMessage(ulong fromUser, string msg)
	{
		string text = ChatboxUtility.ColorPlayerName(fromUser);
		string text2 = ChatUtility.SanitizeString(msg);
		string text3 = ChatUtility.RemoveRichEmbedding(text2);
		string text4 = messages.text;
		string text5 = text4 + "\n" + text + " : " + text3;
		messages.text = text5;
		string text6 = messages.text;
		if (text6._stringLength > 4500)
		{
			string text7 = messages.text;
			string text8 = text7.Substring(2500);
			messages.text = text8;
		}
		chatFadeTimer = chatFadeTime;
		Action<ulong, string, string> a_NewMessage = A_NewMessage;
		if (A_NewMessage != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v281 @ r10_v1 (System.Action`3<System.UInt64, System.String, System.String>)+18] (should have been resolved before IL gen)");
		}
	}

	public bool TrySendMessage()
	{
		//IL_0106: Invalid comparison between I4 and F4
		//IL_00e4: Expected I8, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F20]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		float time = Time.time;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
		double num = Math.Floor(0.0);
		double num2 = num + (double)currentTokens;
		bool flag = !(num2 > 5.0);
		float num3 = (float)num2;
		if (!flag)
		{
			num3 = 5f;
		}
		if (0f < num3)
		{
			float num4 = num3 - 1f;
			if (num4 > 5f)
			{
				num4 = 5f;
			}
			currentTokens = num4;
			float time2 = Time.time;
			chatSentAtTime = time2;
			return true;
		}
		AppendMessage(1uL, "Your message was not sent. You're sending too many messages.");
		return false;
	}

	public void AppendMessage(EChatUserType fromUser, string msg)
	{
		//IL_000e: Expected I8, but got I4
		AppendMessage((ulong)fromUser, msg);
	}

	private void Cooldown()
	{
		cooldown = false;
	}

	public static bool IsTyping()
	{
		//IL_001d: Expected I4, but got O
		Chatbox instance = Instance;
		if ((object)Instance != null)
		{
			return instance.isTyping;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
