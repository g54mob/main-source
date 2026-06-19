using UnityEngine;

public class ChestInventoryUI : InventoryUI
{
	public Transform labelRoot;

	public TextInputField inputField;

	public SignStateToggle signStateToggle;

	public PugText AuthorText;

	private float inputFieldWasSetTimer;

	private bool pendingProfanityCheck;

	private string signText;

	private WorldLabel activeWorldLabel
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

	public override void ShowContainerUI()
	{
		base.ShowContainerUI();
		labelRoot.gameObject.SetActive(activeWorldLabel != null);
		if (activeWorldLabel != null)
		{
			int state = activeWorldLabel.GetState();
			if (signStateToggle.stateIndex != state)
			{
				signStateToggle.SetState(state);
			}
		}
	}

	protected override void UpdateContainerSize()
	{
		base.UpdateContainerSize();
		bool flag = activeWorldLabel != null;
		labelRoot.gameObject.SetActive(flag);
		if (flag)
		{
			signStateToggle.transform.localPosition = new Vector3(0f - GetSideStartPosition(base.visibleColumns) + 1.5f, signStateToggle.transform.localPosition.y, signStateToggle.transform.localPosition.z);
		}
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		if (activeWorldLabel != null)
		{
			UpdateNameText();
		}
	}

	public override void HideContainerUI()
	{
		inputFieldWasSetTimer = 0f;
		labelRoot.gameObject.SetActive(value: false);
		base.HideContainerUI();
	}

	public void SetName()
	{
		PlayerController player = Manager.main.player;
		if (player == null || player.activeWorldLabel == null)
		{
			return;
		}
		pendingProfanityCheck = true;
		WorldLabel activeChest = player.activeWorldLabel;
		string newDescription = (signText = inputField.pugText.GetText());
		Manager.platform.parentalControlManager.RestrictInput(newDescription, delegate(string filteredName)
		{
			if (!(newDescription != signText) && !(activeChest == null))
			{
				player.playerCommandSystem.SetDescription(activeChest.entity, filteredName);
				inputFieldWasSetTimer = 1f;
				pendingProfanityCheck = false;
			}
		});
	}

	public void SetVisibilityState()
	{
		PlayerController playerController = Manager.main.player;
		if (!(playerController == null) && !(playerController.activeWorldLabel == null))
		{
			playerController.playerCommandSystem.SetWorldLabelVisibility(playerController.activeWorldLabel.entity, signStateToggle.stateIndex);
		}
	}

	private void UpdateNameText(bool force = false)
	{
		WorldLabel worldLabel = activeWorldLabel;
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
			string newChestText = worldLabel.GetName();
			if (string.IsNullOrEmpty(signText) && !string.IsNullOrEmpty(inputField.pugText.GetText()))
			{
				inputField.SetInputText("");
			}
			else
			{
				if (signText == newChestText && !force)
				{
					return;
				}
				signText = newChestText;
				inputField.SetInputText("...");
				pendingProfanityCheck = true;
				Manager.platform.parentalControlManager.RestrictInput(newChestText, delegate(string filteredName)
				{
					if (!(newChestText != signText) && !(activeWorldLabel == null))
					{
						inputField.SetInputText(filteredName ?? "");
						pendingProfanityCheck = false;
					}
				});
			}
		}
	}
}
