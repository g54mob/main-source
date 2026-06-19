using UnityEngine;

public class ConvoController : MonoBehaviour
{
	public delegate void TemplateUnloadCallback();

	private TemplateUnloadCallback templateUnloadCallback;

	public float textSpeed = 0.05f;

	public int allowedLineBreaks = 1;

	public bool leaveTemplateOnUnload;

	private GameObject existingTemplateRef;

	private int conversationIndex;

	private string[] conversationList;

	private GameObject currentTemplate;

	private string templatePath = "convoSystem/boxes/";

	private const string templateSymbol = "[load]";

	private const string templateNoBoxSymbol = "[/load]";

	private const string unloadSymbol = "[unload]";

	private const string advanceSymbol = "[advance]";

	private const string triggerSymbol = "[trigger]";

	private const string advanceMainConvo = "[main++]";

	private const string advanceGoodbyeConvo = "[bye++]";

	private const string emotionDefaultSymbol = ":)";

	private const string emotionAngrySymbol = ">:(";

	private const string emotionHappySymbol = ":D";

	private const string emotionWinkySymbol = ";)";

	private const string emotionGaspSymbol = ":o";

	private bool advanceToNextTemplate;

	private bool templateLoaded;

	private string templateToLoad;

	private bool textSpew;

	private string currentTextSpew;

	private int spewPos;

	private float lastSpew;

	private Vector3 easeOutVector = new Vector3(-20f, 0f, 0f);

	private bool convoPaused;

	private Inchworm.EaseCallback unloadCallback;

	private Inchworm inchworm;

	private void Start()
	{
		inchworm = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
	}

	public void Update()
	{
		if (Time.timeScale == 0f || convoPaused || !templateLoaded)
		{
			return;
		}
		bool flag = false;
		if (GameControls.actions.Interact.WasPressed)
		{
			flag = true;
		}
		if (textSpew)
		{
			if (flag)
			{
				SpewAllText();
			}
			else
			{
				SpewText();
			}
			return;
		}
		bool flag2 = false;
		if (conversationIndex < conversationList.Length && conversationList[conversationIndex].Replace("\r", "") == "[advance]")
		{
			conversationIndex++;
			flag2 = true;
		}
		if (templateLoaded && (flag || flag2))
		{
			AdvanceConversation();
		}
	}

	public void InitializeConversation(TextAsset conversation, ConversationSystem convoSystem, GameObject existingTemplate = null)
	{
		existingTemplateRef = existingTemplate;
		conversationIndex = 0;
		conversationList = conversation.text.Split("\n"[0]);
		AdvanceConversation();
	}

	public void SetTemplateUnloadCallback(TemplateUnloadCallback newCallback)
	{
		templateUnloadCallback = newCallback;
	}

	public void PauseConversation()
	{
		convoPaused = true;
	}

	public void ResumeConversation()
	{
		convoPaused = false;
	}

	public void AdvanceConversation()
	{
		if (conversationIndex >= conversationList.Length)
		{
			UnloadTemplate();
			return;
		}
		string line = conversationList[conversationIndex];
		conversationIndex++;
		if (ParseLine(line))
		{
			AdvanceConversation();
		}
	}

	private bool ParseLine(string line)
	{
		line = line.Replace("\r", "");
		if (advanceToNextTemplate && line.Substring(0, "[load]".Length) != "[load]")
		{
			return true;
		}
		if (line.Length > "[load]".Length && line.Substring(0, "[load]".Length) == "[load]")
		{
			return LoadTemplate(line.Substring("[load]".Length + 1));
		}
		if (line.Length > "[/load]".Length && line.Substring(0, "[/load]".Length) == "[/load]")
		{
			return LoadTemplate(line.Substring("[/load]".Length + 1), showBox: false);
		}
		switch (line)
		{
		case "[unload]":
			return UnloadTemplate();
		case ":)":
			currentTemplate.GetComponent<PeopleTemplate>().RequestEmotionChange(Emotion.defaultEmotion);
			return true;
		case ">:(":
			currentTemplate.GetComponent<PeopleTemplate>().RequestEmotionChange(Emotion.angry);
			return true;
		case ":D":
			currentTemplate.GetComponent<PeopleTemplate>().RequestEmotionChange(Emotion.happy);
			return true;
		case ";)":
			currentTemplate.GetComponent<PeopleTemplate>().RequestEmotionChange(Emotion.winking);
			return true;
		case ":o":
			currentTemplate.GetComponent<PeopleTemplate>().RequestEmotionChange(Emotion.gasp);
			return true;
		default:
			_ = line[0];
			DisplayText(line);
			return false;
		}
	}

	private bool LoadTemplate(string template, bool showBox = true)
	{
		advanceToNextTemplate = false;
		templateToLoad = template;
		if (currentTemplate != null)
		{
			templateLoaded = false;
			currentTemplate.GetComponent<PeopleTemplate>().UnloadTemplate(TemplateUnloadedCallback, easeOutVector);
			return false;
		}
		templateToLoad = null;
		if (existingTemplateRef != null)
		{
			currentTemplate = existingTemplateRef;
			existingTemplateRef = null;
		}
		else
		{
			currentTemplate = (GameObject)Object.Instantiate(Resources.Load(templatePath + template));
		}
		currentTemplate.GetComponent<PeopleTemplate>().loadTemplate(TemplateLoadedCallback);
		return false;
	}

	private bool UnloadTemplate()
	{
		if (currentTemplate == null)
		{
			Debug.LogError("Attempting to unload a template but no template has been loaded.");
		}
		else
		{
			templateLoaded = false;
			currentTemplate.GetComponent<PeopleTemplate>().UnloadTemplate(TemplateUnloadedCallback);
		}
		return true;
	}

	public void TemplateLoadedCallback()
	{
		templateLoaded = true;
		currentTemplate.GetComponent<PeopleTemplate>().SetText("", playAudio: false);
		currentTemplate.GetComponent<PeopleTemplate>().UnhideText();
		AdvanceConversation();
	}

	public void TemplateUnloadedCallback()
	{
		currentTemplate.GetComponent<PeopleTemplate>().Unload(!leaveTemplateOnUnload);
		if (!leaveTemplateOnUnload)
		{
			Object.Destroy(currentTemplate);
		}
		currentTemplate = null;
		FinalizeTemplateUnload();
	}

	private void FinalizeTemplateUnload()
	{
		if (templateToLoad != null)
		{
			LoadTemplate(templateToLoad);
		}
		else if (templateUnloadCallback != null)
		{
			templateUnloadCallback();
		}
	}

	private void DisplayText(string text)
	{
		textSpew = true;
		spewPos = 0;
		currentTextSpew = text;
	}

	private void SpewAllText()
	{
		while (spewPos < currentTextSpew.Length && Time.timeScale != 0f)
		{
			SpewText();
		}
	}

	private void SpewText()
	{
		lastSpew += Time.deltaTime;
		if (!(lastSpew < textSpeed))
		{
			lastSpew = 0f;
			string text = currentTextSpew;
			bool playAudio = currentTextSpew[spewPos] != ' ';
			spewPos++;
			currentTemplate.GetComponent<PeopleTemplate>().SetText(text, playAudio);
			currentTemplate.GetComponent<PeopleTemplate>().SetMaxVisibleCharacters(spewPos);
			if (spewPos >= currentTextSpew.Length)
			{
				textSpew = false;
			}
		}
	}

	public void Unload(Inchworm.EaseCallback callback = null)
	{
		unloadCallback = callback;
		inchworm.CancelAllEases(EasesCancelledForUnloadCallback);
	}

	private void SceneUnloadedCallback()
	{
		currentTemplate.GetComponent<PeopleTemplate>().Unload();
	}

	private void EasesCancelledForUnloadCallback()
	{
		currentTemplate.GetComponent<PeopleTemplate>().Unload();
		Object.Destroy(currentTemplate);
		if (unloadCallback != null)
		{
			unloadCallback();
			unloadCallback = null;
		}
	}
}
