using System.Collections.Generic;
using I2.Loc;
using Inventory;
using Pug.UnityExtensions;
using Unity.Entities;
using UnityEngine;

public class SkillTalentTreeUI : UIelement
{
	public const int resetCost = 200;

	public GameObject root;

	public List<SkillTalentUIElement> skillTalentUIElements;

	public PugText title;

	public PugText titleShadow;

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

	private const string skillPrefix = "Skills/";

	public SkillID currentShowingSkillTreeID { get; private set; }

	public override bool isShowing => root.activeSelf;

	public void Awake()
	{
		HideTalentTree();
	}

	public void ToggleTalentTree(SkillID skillToShow)
	{
		if (isShowing && currentShowingSkillTreeID == skillToShow)
		{
			HideTalentTree();
		}
		else
		{
			ShowTalentTree(skillToShow);
		}
	}

	private void ShowTalentTree(SkillID skillToShow)
	{
		root.SetActive(value: true);
		currentShowingSkillTreeID = skillToShow;
		UpdateTree();
	}

	private void HideTalentTree()
	{
		root.SetActive(value: false);
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		UpdateTree();
	}

	private void UpdateTree()
	{
		if (!isShowing)
		{
			return;
		}
		if (Manager.saves.GetAvailableTalentPoints(currentShowingSkillTreeID) < 0)
		{
			ResetTree(forceReset: true);
		}
		UpdateTitleAndPointsText();
		SkillTalentsTable.SkillTalentTree skillTalentTree = Manager.mod.SkillTalentsTable.GetSkillTalentTree(currentShowingSkillTreeID);
		List<int> skillTalentTreesPoints = Manager.saves.GetSkillTalentTreesPoints(currentShowingSkillTreeID);
		bool flag = skillTalentTreesPoints != null;
		hasPlacedAnyPoints = false;
		for (int i = 0; i < skillTalentUIElements.Count; i++)
		{
			int num = ((flag && skillTalentTreesPoints.Count > i) ? skillTalentTreesPoints[i] : 0);
			if (skillTalentTree.skillTalents.Count > i)
			{
				skillTalentUIElements[i].gameObject.SetActive(value: true);
				SkillTalentsTable.SkillTalentInfo skillTalentInfo = skillTalentTree.skillTalents[i];
				skillTalentUIElements[i].UpdateTalent(currentShowingSkillTreeID, i, skillTalentInfo, num);
				if (num > 0)
				{
					hasPlacedAnyPoints = true;
				}
			}
			else
			{
				skillTalentUIElements[i].gameObject.SetActive(value: false);
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
		PositionUIElements();
	}

	private void PositionUIElements()
	{
		float y = topEdge.localPosition.y;
		y = UIManager.PositionElementBeneath(title.transform, y, title.dimensions.size.y, 0.25f);
		titleShadow.transform.localPosition = title.transform.localPosition - new Vector3(0f, 0.0625f, 0f);
		y -= 0.0625f;
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

	private void UpdateTitleAndPointsText()
	{
		string text = "Skills/" + currentShowingSkillTreeID;
		if (title.GetText() != text)
		{
			title.Render(text);
			titleShadow.Render(text);
		}
		int availableTalentPoints = Manager.saves.GetAvailableTalentPoints(currentShowingSkillTreeID);
		string text2 = availableTalentPoints.ToString();
		if (pointsText.formatFields.Length < 1 || pointsText.formatFields[0] != text2)
		{
			pointsText.formatFields = new string[1] { text2 };
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
				inventoryChangeData = Create.ResetSkillTalentTree(player.entity, currentShowingSkillTreeID, forceReset)
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
		BufferLookup<ContainedObjectsBuffer> bufferLookup = player.querySystem.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
		BufferLookup<InventoryBuffer> bufferLookup2 = player.querySystem.GetBufferLookup<InventoryBuffer>(isReadOnly: true);
		BufferLookup<SkillTalentConditionsBuffer> bufferLookup3 = player.querySystem.GetBufferLookup<SkillTalentConditionsBuffer>(isReadOnly: true);
		SkillTalentsTableCD singleton = player.querySystem.GetSingleton<SkillTalentsTableCD>();
		PugDatabase.DatabaseBankCD singleton2 = player.querySystem.GetSingleton<PugDatabase.DatabaseBankCD>();
		if (InventoryUtility.CanResetSkillTalents(player.entity, currentShowingSkillTreeID, bufferLookup2, bufferLookup, bufferLookup3, singleton, singleton2))
		{
			return hasPlacedAnyPoints;
		}
		return false;
	}
}
