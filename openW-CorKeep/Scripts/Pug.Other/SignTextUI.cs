using UnityEngine;

public class SignTextUI : UIelement
{
	public GameObject root;

	public TextInputField inputField;

	public SignStateToggle signStateToggle;

	public PugText AuthorText;

	private float inputFieldWasSetTimer;

	private bool pendingProfanityCheck;

	private string signText;

	public override bool isShowing => root.activeInHierarchy;

	private WorldLabel activeSign
	{
		get
		{
			if (!(Manager.main.player != null))
			{
				return null;
			}
			return Manager.main.player.activeWorldLabel;
		}
	}

	private void Awake()
	{
		root.SetActive(value: false);
	}

	public void ShowUI()
	{
		root.SetActive(value: true);
		LateUpdate();
		if (activeSign != null)
		{
			int state = activeSign.GetState();
			if (signStateToggle.stateIndex != state)
			{
				signStateToggle.SetState(state);
			}
		}
	}

	public void HideUI()
	{
		root.SetActive(value: false);
		inputFieldWasSetTimer = 0f;
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		UpdateNameText();
		root.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
	}

	public void SetName()
	{
		PlayerController player = Manager.main.player;
		if (player == null || player.activeWorldLabel == null)
		{
			return;
		}
		pendingProfanityCheck = true;
		WorldLabel activeSign = player.activeWorldLabel;
		string newDescription = (signText = inputField.pugText.GetText());
		Manager.platform.parentalControlManager.RestrictInput(newDescription, delegate(string filteredName)
		{
			if (!(newDescription != signText) && !(activeSign == null))
			{
				player.playerCommandSystem.SetDescription(activeSign.entity, filteredName);
				inputFieldWasSetTimer = 1f;
				pendingProfanityCheck = false;
			}
		});
	}

	public void SetVisibilityState()
	{
		PlayerController player = Manager.main.player;
		if (!(player == null) && !(player.activeWorldLabel == null))
		{
			player.playerCommandSystem.SetWorldLabelVisibility(player.activeWorldLabel.entity, signStateToggle.stateIndex);
		}
	}

	private void UpdateNameText(bool force = false)
	{
		WorldLabel worldLabel = activeSign;
		if (!isShowing || worldLabel == null || pendingProfanityCheck)
		{
			return;
		}
		if (inputFieldWasSetTimer > 0f)
		{
			inputFieldWasSetTimer -= Time.deltaTime;
		}
		else
		{
			if (inputField.inputIsActive)
			{
				return;
			}
			string newSignText = worldLabel.GetName();
			if (string.IsNullOrEmpty(signText) && !string.IsNullOrEmpty(inputField.pugText.GetText()))
			{
				inputField.SetInputText("");
			}
			else
			{
				if (signText == newSignText && !force)
				{
					return;
				}
				signText = newSignText;
				inputField.SetInputText("...");
				pendingProfanityCheck = true;
				Manager.platform.parentalControlManager.RestrictInput(newSignText, delegate(string filteredName)
				{
					if (!(newSignText != signText) && !(activeSign == null))
					{
						inputField.SetInputText(filteredName ?? "");
						pendingProfanityCheck = false;
					}
				});
			}
		}
	}
}
