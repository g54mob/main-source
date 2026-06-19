using System;
using System.Collections.Generic;
using PlayerState;
using UnityEngine;

public class ChatWindow : UIelement, InputManager.TextInputInterface
{
	public enum MessageTextType
	{
		None = 0,
		Received = 1,
		Sent = 2,
		NewItem = 3,
		CaughtItem = 4,
		NewTalentPointAvailable = 5,
		DurabilityLost = 6,
		AdditionalItemGained = 7,
		GainedItem = 8,
		HardcoreDeath = 9,
		ReceivedItems = 10,
		DiedFromStarvation = 11,
		PetLeveledUp = 12,
		GainedSoul = 13,
		StartingClassicWorld = 14,
		ReconnectAttempt = 15,
		ReconnectSuccess = 16,
		EnemiesScaledUp = 17,
		EnemiesScaledDown = 18,
		StreamIntegrationActionInfo = 19,
		TalkToTheCore = 20,
		AchievementsDisabled = 21
	}

	[Serializable]
	public struct MessageTextPrefab
	{
		public MessageTextType type;

		public GameObject prefab;
	}

	public List<MessageTextPrefab> textPrefabs;

	private Dictionary<MessageTextType, GameObject> textPrefabLookup = new Dictionary<MessageTextType, GameObject>();

	private Dictionary<MessageTextType, Queue<PugText>> activePools = new Dictionary<MessageTextType, Queue<PugText>>();

	private Dictionary<MessageTextType, Queue<PugText>> freePools = new Dictionary<MessageTextType, Queue<PugText>>();

	public Transform messageTextParent;

	public PugText inputField;

	public Transform streamIntegrationTextParent;

	public SpriteMask inputMask;

	public SpriteMask outputMask;

	public PugText inputFieldPrompt;

	public Transform inputFieldPromptBackground;

	public Transform inputFieldMask;

	private Queue<PugTextEffectMaxFade> fadeEffects = new Queue<PugTextEffectMaxFade>();

	private NetworkCommSystem commSystem;

	private bool wasTextInputActive;

	private bool textInputActive;

	private int lastReceivedMessage;

	private int inputFieldMarker;

	private const int maxMessageLength = 1000;

	private const float chatFadeOutTimeAfterCloseTextInput = 4f;

	[field: SerializeField]
	[field: Tooltip("Maximum amount of characters this field can get when using on-screen keyboard.")]
	public int MaxCharactersForOnScreenKeyboard { get; private set; } = 255;

	public bool WasAutoActivated
	{
		get
		{
			return wasAutoActivated;
		}
		set
		{
			wasAutoActivated = value;
		}
	}

	private void Awake()
	{
		foreach (MessageTextPrefab textPrefab in textPrefabs)
		{
			textPrefabLookup.Add(textPrefab.type, textPrefab.prefab);
			activePools.Add(textPrefab.type, new Queue<PugText>());
			freePools.Add(textPrefab.type, new Queue<PugText>());
		}
	}

	private void Update()
	{
		if (Manager.menu.anyMenuWasActiveDuringThisUpdate || Manager.ecs.ClientWorld == null || Manager.sceneHandler.isIntro || Manager.sceneHandler.isOutro || Manager.sceneHandler.isTitle)
		{
			if (messageTextParent.gameObject.activeSelf)
			{
				Deactivate(commit: false);
				messageTextParent.gameObject.SetActive(value: false);
			}
			if (streamIntegrationTextParent.gameObject.activeSelf)
			{
				streamIntegrationTextParent.gameObject.SetActive(value: false);
			}
			return;
		}
		NetworkCommSystem existingSystemManaged = Manager.ecs.ClientWorld.GetExistingSystemManaged<NetworkCommSystem>();
		if (existingSystemManaged == null)
		{
			Debug.LogError("No chat system in client world!");
			return;
		}
		if (commSystem != existingSystemManaged)
		{
			ClearAll();
			lastReceivedMessage = 0;
			commSystem = existingSystemManaged;
		}
		if (!messageTextParent.gameObject.activeSelf)
		{
			messageTextParent.gameObject.SetActive(value: true);
			foreach (PugTextEffectMaxFade fadeEffect in fadeEffects)
			{
				fadeEffect.FadeOut();
			}
		}
		if (!streamIntegrationTextParent.gameObject.activeSelf && (Manager.stream.StreamIntegrationManager.IsRoomConnected() || Manager.networking.serverHasStreamIntegration))
		{
			streamIntegrationTextParent.gameObject.SetActive(value: true);
		}
		if (!wasTextInputActive && !Manager.input.textInputWasActiveThisFrame && Manager.main.player != null && Manager.main.player.inputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.OPEN_CHAT))
		{
			Manager.platform.parentalControlManager.CommunicationAllowed(showUI: true, delegate(bool success)
			{
				if (success)
				{
					inputFieldMarker = 0;
					textInputActive = true;
					inputFieldPrompt.gameObject.SetActive(value: true);
					inputFieldPromptBackground.gameObject.SetActive(value: true);
					Manager.input.SetActiveInputField(this);
					Manager.input.DisableInput();
					{
						foreach (PugTextEffectMaxFade fadeEffect2 in fadeEffects)
						{
							fadeEffect2.ResetEffect(rewind: true);
						}
						return;
					}
				}
				string[] formatFields = new string[1] { "unsupported" };
				Manager.menu.centerPopUpText.StartNewDisplaySequence("Consoles/MissingPrivilege", formatFields, menuInputCooldown: true, 0f, 5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, null, null, 10f, 0f, 0, 20f);
			});
		}
		if (wasTextInputActive && !textInputActive)
		{
			foreach (PugTextEffectMaxFade fadeEffect3 in fadeEffects)
			{
				fadeEffect3.fadeOutTime = 4f;
				fadeEffect3.FadeOut();
			}
		}
		wasTextInputActive = textInputActive;
		foreach (NetworkCommSystem.Message message in commSystem.ReceivedMessages)
		{
			if (message.messageNumber <= lastReceivedMessage)
			{
				continue;
			}
			if (message.platform != 0)
			{
				Manager.platform.parentalControlManager.CommunicationAllowed(showUI: false, delegate(bool success)
				{
					if (success)
					{
						Manager.platform.platformImpl.IsUserBlocked(new PlatformUserID(message.platformID), delegate(bool isBlocked)
						{
							if (!isBlocked)
							{
								if (message.isStreamIntegrationMessage)
								{
									Manager.platform.parentalControlManager.RestrictInput(message.message, RenderStreamIntegrationText);
								}
								else
								{
									Manager.platform.parentalControlManager.RestrictInput(message.message, RenderText);
								}
							}
						});
					}
				});
			}
			else
			{
				RenderText(message.message);
			}
			lastReceivedMessage = Mathf.Max(lastReceivedMessage, message.messageNumber);
		}
	}

	private void RenderText(string message)
	{
		Debug.Log("MESSAGE: " + message);
		PugTextEffectMaxFade fadeEffect;
		PugText pugText = AllocPugText(MessageTextType.Received, out fadeEffect);
		pugText.Render(message);
		AddPugText(MessageTextType.Received, pugText);
		if (messageTextParent.gameObject.activeSelf && !textInputActive)
		{
			fadeEffect.FadeOut();
		}
	}

	private void RenderStreamIntegrationText(string message)
	{
		FreePreviousStreamIntegrationMessage();
		PugTextEffectMaxFade fadeEffect;
		PugText pugText = AllocPugText(MessageTextType.StreamIntegrationActionInfo, out fadeEffect, streamIntegrationTextParent);
		pugText.Render(message, rewindEffectAnims: false, force: true);
		activePools[MessageTextType.StreamIntegrationActionInfo].Enqueue(pugText);
		if (streamIntegrationTextParent.gameObject.activeSelf)
		{
			fadeEffect.FadeOut();
		}
	}

	private PugText AllocPugText(MessageTextType type, out PugTextEffectMaxFade fadeEffect, Transform messageTextParentToUse = null)
	{
		Queue<PugText> queue = freePools[type];
		if (!messageTextParentToUse)
		{
			messageTextParentToUse = messageTextParent;
		}
		PugText pugText;
		bool flag;
		if (queue.Count > 0)
		{
			pugText = queue.Dequeue();
			pugText.gameObject.transform.SetParent(messageTextParentToUse);
			flag = true;
		}
		else
		{
			pugText = UnityEngine.Object.Instantiate(textPrefabLookup[type], messageTextParentToUse).GetComponent<PugText>();
			flag = false;
		}
		Transform obj = pugText.transform;
		Vector3 localPosition = obj.localPosition;
		localPosition.y = 0f;
		obj.localPosition = localPosition;
		fadeEffect = pugText.GetComponent<PugTextEffectMaxFade>();
		if (flag)
		{
			fadeEffect.ResetEffect(rewind: true);
		}
		fadeEffects.Enqueue(fadeEffect);
		return pugText;
	}

	private void ClearAll()
	{
		foreach (KeyValuePair<MessageTextType, Queue<PugText>> activePool in activePools)
		{
			MessageTextType key = activePool.Key;
			Queue<PugText> value = activePool.Value;
			while (value.Count > 0)
			{
				PugText pugText = value.Dequeue();
				pugText.gameObject.SetActive(value: false);
				freePools[key].Enqueue(pugText);
				fadeEffects.Dequeue();
			}
		}
	}

	private void AddMessageHeight(float h)
	{
		foreach (KeyValuePair<MessageTextType, Queue<PugText>> activePool in activePools)
		{
			MessageTextType key = activePool.Key;
			Queue<PugText> value = activePool.Value;
			foreach (PugText item in value)
			{
				Transform obj = item.transform;
				Vector3 localPosition = obj.localPosition;
				localPosition.y += h;
				obj.localPosition = localPosition;
			}
			while (value.Count > 0 && value.Peek().transform.localPosition.y > 10f)
			{
				PugText pugText = value.Dequeue();
				pugText.gameObject.SetActive(value: false);
				freePools[key].Enqueue(pugText);
				fadeEffects.Dequeue();
			}
		}
	}

	private void AddPugText(MessageTextType type, PugText text)
	{
		AddMessageHeight(text.dimensions.height);
		activePools[type].Enqueue(text);
	}

	private void AdjustInputFieldPosition()
	{
		float num = inputFieldMask.localScale.x / 16f;
		Transform obj = inputField.transform;
		Vector3 localPosition = obj.localPosition;
		localPosition.x = -1f * Mathf.Max(0f, inputField.dimensions.width - num);
		obj.localPosition = localPosition;
	}

	public string GetInputText()
	{
		return inputField.displayedTextString;
	}

	public void SetInputText(string input)
	{
		if (input.Length > 1000)
		{
			input = input.Substring(0, 1000);
		}
		inputField.Render(input);
		inputFieldMarker = input.Length;
		AdjustInputFieldPosition();
	}

	public void AppendString(string input)
	{
		string text = inputField.GetText();
		if (text.Length < 1000)
		{
			if (text.Length + input.Length > 1000)
			{
				input = input.Substring(0, 1000 - text.Length);
			}
			inputField.SetText(text + input);
			inputField.Render();
			inputFieldMarker = inputField.GetText().Length;
			AdjustInputFieldPosition();
			WasAutoActivated = false;
		}
	}

	public void Deactivate(bool commit)
	{
		bool flag = string.IsNullOrEmpty(inputField.GetText());
		if (commit && commSystem != null && !flag)
		{
			Manager.platform.parentalControlManager.RestrictInput(Manager.saves.GetCharacterCustomization().name.ToString() + ": " + inputField.GetText(), delegate(string filteredText)
			{
				commSystem.SendChatMessage(filteredText);
				PugTextEffectMaxFade fadeEffect;
				PugText pugText = AllocPugText(MessageTextType.Sent, out fadeEffect);
				pugText.Render(filteredText);
				fadeEffect.FadeOut();
				AddPugText(MessageTextType.Sent, pugText);
			});
		}
		textInputActive = false;
		inputFieldPrompt.gameObject.SetActive(value: false);
		inputFieldPromptBackground.gameObject.SetActive(value: false);
		Manager.input.SetActiveInputField(null);
		Manager.input.EnableInput();
		inputField.Render("");
	}

	public void MoveCharMarker(int n)
	{
	}

	public void RemoveCharAtMarker()
	{
		string text = inputField.GetText();
		if (inputFieldMarker < text.Length)
		{
			inputField.SetText(text.Remove(inputFieldMarker, 1));
			inputField.Render();
			AdjustInputFieldPosition();
		}
	}

	public void RemoveCharBehindMarker()
	{
		if (inputFieldMarker > 0)
		{
			inputFieldMarker--;
			RemoveCharAtMarker();
		}
	}

	public string GetHintString()
	{
		return null;
	}

	public bool IsHidden()
	{
		return false;
	}

	public void AddInfoText(string[] formatFields, Rarity rarity, MessageTextType messageTextType, bool setColorFromRarity = true)
	{
		PugTextEffectMaxFade fadeEffect;
		PugText pugText = AllocPugText(messageTextType, out fadeEffect);
		pugText.formatFields = formatFields;
		pugText.Render(rewindEffectAnims: false);
		if (setColorFromRarity)
		{
			Color color = Manager.text.rarityTextColors[(int)(rarity + 1)];
			pugText.style.color = color;
			pugText.SetTempColor(color);
		}
		AddPugText(messageTextType, pugText);
		if (messageTextParent.gameObject.activeSelf && !textInputActive)
		{
			fadeEffect.FadeOut();
		}
	}

	public virtual void BroadcastStreamIntegrationInfoTextToAllPlayers(string text)
	{
		bool flag = string.IsNullOrEmpty(text);
		if (commSystem != null && !flag)
		{
			commSystem.SendChatMessage(text, isStreamIntegrationMessage: true);
			RenderStreamIntegrationText(text);
		}
	}

	public void AddInfoText(string[] formatFields, MessageTextType messageTextType)
	{
		AddInfoText(formatFields, Rarity.Common, messageTextType, setColorFromRarity: false);
	}

	public void AddInfoText(MessageTextType messageTextType)
	{
		AddInfoText(null, Rarity.Common, messageTextType, setColorFromRarity: false);
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		PlayerController player = Manager.main.player;
		if (player != null && player.IsHardcore && EntityUtility.GetComponentData<PlayerStateCD>(player.entity, player.world).HasAnyState(PlayerStateEnum.Death) && !Manager.load.IsSceneTransitionOrLoading())
		{
			messageTextParent.transform.localScale = Vector3.one;
		}
		else
		{
			messageTextParent.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		}
		if (streamIntegrationTextParent.gameObject.activeSelf && streamIntegrationTextParent.childCount > 0)
		{
			streamIntegrationTextParent.GetChild(0).transform.localPosition = Vector3.zero;
		}
		bool flag = Manager.main.currentSceneHandler != null && Manager.main.currentSceneHandler.isInGame;
		inputFieldMask.gameObject.SetActive(flag && !string.IsNullOrEmpty(inputField.GetText()));
	}

	private void FreePreviousStreamIntegrationMessage()
	{
		if (activePools[MessageTextType.StreamIntegrationActionInfo].Count > 0)
		{
			PugText pugText = activePools[MessageTextType.StreamIntegrationActionInfo].Dequeue();
			pugText.gameObject.SetActive(value: false);
			freePools[MessageTextType.StreamIntegrationActionInfo].Enqueue(pugText);
			fadeEffects.Dequeue();
		}
	}
}
