using System.Collections.Generic;
using I2.Loc;
using Inventory;
using Pug.UnityExtensions;
using Unity.Entities;
using UnityEngine;

public class PetTalentsWindow : UIelement
{
	public const int resetCost = 200;

	public GameObject root;

	public List<PetTalentUIElement> petTalentUIElements;

	public TextInputField textInputField;

	public SpriteRenderer textInputFieldBackground;

	public PugText pointsText;

	public LocalizedString pointsTextTerm;

	private bool hasPlacedAnyPoints;

	public SpriteRenderer resetButtonSR;

	public SpriteRenderer resetButtonCoinSR;

	public PugText resetButtonText;

	public PugText resetButtonCoinText;

	public ButtonUIElement resetButton;

	public SpriteRenderer resetButtonBackground;

	public Transform talentsContainer;

	public Transform talentsBotPos;

	public SpriteRenderer background;

	public BoxCollider backgroundCollider;

	public Transform topEdge;

	public ButtonUIElement openTalentWindowButton;

	public SpriteRenderer openTalentWindowArrow;

	public Color buttonArrowColorEnabled;

	public Color buttonArrowColorDisabled;

	private float textInputWasSetTimer;

	private string petName = "";

	private bool pendingProfanityCheck;

	public PugText AuthorText;

	public override bool isShowing => root.activeSelf;

	private ContainedObjectsBuffer GetContainedPetObjectData()
	{
		PlayerController player = Manager.main.player;
		if (player != null)
		{
			return player.equipmentHandler.petInventoryHandler.GetContainedObjectData(0);
		}
		return default(ContainedObjectsBuffer);
	}

	private string GetPetName()
	{
		if (!InventoryHandler.TryGetExtraInventoryData<NameCD>(GetContainedPetObjectData(), out var data))
		{
			return null;
		}
		return data.Value.ToString();
	}

	private bool HasPetInSlot()
	{
		PlayerController player = Manager.main.player;
		if (player != null)
		{
			return player.equipmentHandler.petInventoryHandler.HasObject(0);
		}
		return false;
	}

	public void Awake()
	{
		HideTalentTree();
	}

	public void ToggleTalentWindow()
	{
		if (isShowing)
		{
			HideTalentTree();
		}
		else
		{
			ShowTalentWindow();
		}
		AudioManager.Sfx(SfxTableID.inventorySFXInfoTab, Manager.main.player.transform.position);
	}

	private void ShowTalentWindow()
	{
		root.SetActive(value: true);
		UpdateWindow();
	}

	public void HideTalentTree()
	{
		root.SetActive(value: false);
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		bool flag = HasPetInSlot();
		openTalentWindowArrow.color = (flag ? buttonArrowColorEnabled : buttonArrowColorDisabled);
		openTalentWindowButton.canBeClicked = flag;
		if (!flag)
		{
			HideTalentTree();
		}
		UpdateWindow();
	}

	private void UpdateWindow()
	{
		if (isShowing)
		{
			UpdateNameText();
			UpdatePointsText();
			UpdateTalents();
			PositionUIElements();
		}
	}

	private void PositionUIElements()
	{
		float y = topEdge.localPosition.y;
		y = UIManager.PositionElementBeneath(textInputField.transform, y, textInputFieldBackground.size.y, 0.25f);
		y = UIManager.PositionElementBeneath(pointsText.transform, y, pointsText.dimensions.size.y, 0f);
		y = UIManager.PositionElementBeneath(talentsContainer, y, 0f - talentsBotPos.localPosition.y, 0.0625f, moveDownHalfOfHeight: false);
		y = UIManager.PositionElementBeneath(resetButtonText.transform, y, resetButtonText.dimensions.size.y, 0.0625f);
		y = UIManager.PositionElementBeneath(resetButton.transform, y, resetButtonBackground.size.y, 0.0625f);
		float num = topEdge.localPosition.y - y + 0.25f;
		background.size = new Vector2(background.size.x, num);
		float num2 = (0f - num) / 2f;
		float num3 = ((num % 0.0625f > 0f) ? (0.0625f - num % 0.0625f) : 0f);
		background.transform.localPosition = new Vector3(0f, num2 - num3, 0f);
		backgroundCollider.size = new Vector3(background.size.x, background.size.y, 0.1f);
	}

	private void UpdateTalents()
	{
		hasPlacedAnyPoints = false;
		ContainedObjectsBuffer containedPetObjectData = GetContainedPetObjectData();
		InventoryHandler.TryGetExtraInventoryBuffer(containedPetObjectData, out DynamicBuffer<PetTalentBuffer> buffer);
		List<PetInfosTable.PetTalentInfo> talents = PetExtensions.GetTalents(Manager.ui.petInfosTable, buffer);
		PetCD petCD = (PugDatabase.HasComponent<PetCD>(containedPetObjectData.objectData) ? PugDatabase.GetComponent<PetCD>(containedPetObjectData.objectData) : default(PetCD));
		for (int i = 0; i < petTalentUIElements.Count; i++)
		{
			petTalentUIElements[i].gameObject.SetActive(value: true);
			petTalentUIElements[i].UpdateTalent(i, talents[i], petCD);
			if (petTalentUIElements[i].GetCurrentPoints() > 0)
			{
				hasPlacedAnyPoints = true;
			}
		}
		if (CanResetTalents())
		{
			resetButtonSR.SetAlpha(1f);
			resetButtonCoinSR.SetAlpha(1f);
			resetButtonCoinText.SetTempColor(Color.white);
		}
		else
		{
			resetButtonSR.SetAlpha(0.25f);
			resetButtonCoinSR.SetAlpha(0.25f);
			resetButtonCoinText.SetTempColor(new Color(1f, 1f, 1f, 0.25f));
		}
		resetButton.canBeClicked = hasPlacedAnyPoints;
	}

	private void UpdateNameText(bool force = false)
	{
		if (pendingProfanityCheck)
		{
			return;
		}
		if (textInputWasSetTimer > 0f)
		{
			textInputWasSetTimer -= Time.deltaTime;
		}
		else
		{
			if (textInputField.inputIsActive)
			{
				return;
			}
			string newPetName = GetPetName();
			if (petName == newPetName && !force)
			{
				return;
			}
			petName = newPetName;
			textInputField.SetInputText("...");
			pendingProfanityCheck = true;
			Manager.platform.parentalControlManager.RestrictInput(newPetName, delegate(string filteredName)
			{
				if (!(newPetName != petName))
				{
					textInputField.SetInputText(filteredName ?? "");
					pendingProfanityCheck = false;
				}
			});
		}
	}

	private void UpdatePointsText()
	{
		ContainedObjectsBuffer containedPetObjectData = GetContainedPetObjectData();
		int availableTalentPoints = PetExtensions.GetAvailableTalentPoints(containedPetObjectData.amount, containedPetObjectData);
		string text = availableTalentPoints.ToString();
		if (pointsText.formatFields.Length < 1 || pointsText.formatFields[0] != text)
		{
			pointsText.formatFields = new string[1] { text };
			pointsText.Render(pointsTextTerm.mTerm);
		}
		pointsText.SetTempColor((availableTalentPoints > 0) ? Color.yellow : Color.white);
	}

	public void ResetTree(bool forceReset)
	{
		PlayerController player = Manager.main.player;
		if ((forceReset || CanResetTalents()) && player != null)
		{
			player.QueueInputAction(new UIInputActionData
			{
				action = UIInputAction.InventoryChange,
				inventoryChangeData = Create.ResetPetTalentTree(player.entity, forceReset)
			});
		}
	}

	private bool CanResetTalents()
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return false;
		}
		ComponentLookup<PetOwnerCD> componentLookup = player.querySystem.GetComponentLookup<PetOwnerCD>(isReadOnly: true);
		BufferLookup<ContainedObjectsBuffer> bufferLookup = player.querySystem.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
		BufferLookup<InventoryBuffer> bufferLookup2 = player.querySystem.GetBufferLookup<InventoryBuffer>(isReadOnly: true);
		BufferLookup<PetTalentBuffer> bufferLookup3 = player.querySystem.GetBufferLookup<PetTalentBuffer>(isReadOnly: true);
		InventoryAuxDataSystemDataCD singleton = player.querySystem.GetSingleton<InventoryAuxDataSystemDataCD>();
		PugDatabase.DatabaseBankCD singleton2 = player.querySystem.GetSingleton<PugDatabase.DatabaseBankCD>();
		if (InventoryUtility.CanResetPetTalents(player.entity, componentLookup, bufferLookup2, bufferLookup, bufferLookup3, singleton, singleton2))
		{
			return hasPlacedAnyPoints;
		}
		return false;
	}

	public void SetName()
	{
		pendingProfanityCheck = true;
		string newPetName = (petName = textInputField.pugText.GetText());
		PlayerController player = Manager.main.player;
		ContainedObjectsBuffer petObjectData = GetContainedPetObjectData();
		Manager.platform.parentalControlManager.RestrictInput(newPetName, delegate(string filteredName)
		{
			if (!(newPetName != petName))
			{
				player.equipmentHandler.petInventoryHandler.SetNameOfInventoryObject(player, 0, petObjectData.objectID, filteredName);
				textInputWasSetTimer = 1f;
				pendingProfanityCheck = false;
			}
		});
	}
}
