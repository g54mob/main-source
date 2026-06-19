using System;
using System.Collections.Generic;
using I2.Loc;
using PugMod;
using UnityEngine;

public class CharacterCustomizationOption_Selection : RadicalMenuOption
{
	public CharacterCustomizationMenu customizationMenu;

	public CharacterCustomizationMenu.CustomizableBodyPartType bodyPartType;

	public PlayerController playerController;

	private int _numRoles;

	private int _activeRole;

	public Color unselectedColor;

	public Animator animator;

	public Transform topEdge;

	public bool changesCharacterRole;

	public RolePerksTable perksTable;

	public PugText roleTitleText;

	public PugText roleTitleTextShadow;

	public PugText roleTitleDesc;

	public PugText roleSkillDesc;

	public PugText perksTitle;

	public PugText perksTitleShadow;

	public List<PugText> roleItemDescs;

	public SpriteRenderer roleBorder;

	public BoxCollider roleBorderCollider;

	public SpriteRenderer roleBackground;

	public List<Sprite> roleBackgroundSprites;

	public bool uniqueRoleSpritesEnabled;

	private const string rolesPrefix = "Roles/";

	private const string rolesDescPostfix = "Desc";

	private const string skillDescPrefix = "Skills/";

	private const string skillDescPostfix = "Perk";

	private const string itemDescFormat = "itemDescFormat";

	private const string itemPrefix = "Items/";

	private const string pluralPostfix = "Plural";

	private const string none = "None";

	protected override void Awake()
	{
		base.Awake();
		animator.keepAnimatorStateOnDisable = true;
		_numRoles = Enum.GetNames(typeof(CharacterRole)).Length;
	}

	public override void OnActivated()
	{
		base.OnActivated();
		OnSkimRight();
	}

	public override void OnSelected()
	{
		base.OnSelected();
		labelText.SetTempColor(Color.white);
	}

	public override void OnDeselected(bool playEffect = true)
	{
		base.OnDeselected(playEffect);
		labelText.SetTempColor(unselectedColor);
	}

	public override bool OnSkimLeft()
	{
		SkimLeft();
		return base.OnSkimLeft();
	}

	public void SkimLeft()
	{
		Skim(-1);
		animator.SetTrigger(2063870753);
	}

	public override bool OnSkimRight()
	{
		SkimRight();
		return base.OnSkimRight();
	}

	public void SkimRight()
	{
		Skim(1);
		animator.SetTrigger(-1144262676);
	}

	private void Skim(int direction)
	{
		if (changesCharacterRole)
		{
			_activeRole = perksTable.GetIndex((CharacterRole)playerController.activeCustomization.role);
			_activeRole = ((_activeRole + direction) % _numRoles + _numRoles) % _numRoles;
			UpdateRole();
		}
		else
		{
			customizationMenu.StepCustomizationOption(bodyPartType, direction);
		}
		AudioManager.SfxUI(SfxID.FIXME_menu_select, 1f, reuse: true, 1f, 0.15f, playOnGamepad: true);
	}

	public void ResetRole()
	{
		_activeRole = 0;
		UpdateRole();
	}

	private void UpdateRole()
	{
		if (!changesCharacterRole)
		{
			return;
		}
		CharacterRole role = perksTable.GetRole(_activeRole);
		playerController.activeCustomization.role = (byte)role;
		RolePerksTable.Perks perks = perksTable.GetPerks(role);
		string text = "Roles/" + role;
		roleTitleText.Render(text);
		roleTitleTextShadow.Render(text);
		roleTitleDesc.Render("Roles/" + role.ToString() + "Desc");
		perksTitle.Render();
		perksTitleShadow.Render();
		if (role == CharacterRole.Nomad)
		{
			roleSkillDesc.Render("None");
		}
		else
		{
			roleSkillDesc.formatFields = new string[1] { 3.ToString() };
			roleSkillDesc.Render("Skills/" + perks.starterSkill.ToString() + "Perk");
		}
		foreach (PugText roleItemDesc in roleItemDescs)
		{
			roleItemDesc.gameObject.SetActive(value: false);
		}
		for (int i = 0; i < perks.starterItems.Count; i++)
		{
			if (!API.Authoring.ObjectProperties.TryGetPropertyString(perks.starterItems[i].objectID, "name", out var value))
			{
				value = Enum.GetName(typeof(ObjectID), perks.starterItems[i].objectID);
			}
			if (!string.IsNullOrEmpty(value))
			{
				string text2 = "";
				text2 = ((perks.starterItems[i].amount <= 1) ? LocalizationManager.GetTranslation("Items/" + perks.starterItems[i].objectID) : LocalizationManager.GetTranslation("Items/" + perks.starterItems[i].objectID.ToString() + "Plural"));
				roleItemDescs[i].gameObject.SetActive(value: true);
				roleItemDescs[i].formatFields = new string[2]
				{
					perks.starterItems[i].amount.ToString(),
					text2
				};
				roleItemDescs[i].Render("itemDescFormat");
			}
		}
		float y = topEdge.localPosition.y;
		y = UIManager.PositionElementBeneath(roleTitleText.transform, y, roleTitleText.dimensions.size.y, 0.25f);
		roleTitleTextShadow.transform.localPosition = roleTitleText.transform.localPosition - new Vector3(0f, 0.0625f, 0f);
		y -= 0.0625f;
		y = UIManager.PositionElementBeneath(roleTitleDesc.transform, y, roleTitleDesc.dimensions.size.y, 0f);
		y = UIManager.PositionElementBeneath(perksTitle.transform, y, perksTitle.dimensions.size.y, 0.25f);
		perksTitleShadow.transform.localPosition = perksTitle.transform.localPosition - new Vector3(0f, 0.0625f, 0f);
		y -= 0.0625f;
		y = UIManager.PositionElementBeneath(roleSkillDesc.transform, y, roleSkillDesc.dimensions.size.y, 0.125f);
		foreach (PugText roleItemDesc2 in roleItemDescs)
		{
			y = UIManager.PositionElementBeneath(roleItemDesc2.transform, y, roleItemDesc2.dimensions.size.y, 0.125f);
		}
		float num = topEdge.localPosition.y - y + 0.25f;
		roleBorder.size = new Vector2(roleBorder.size.x, num);
		float num2 = (0f - num) / 2f;
		float num3 = ((num % 0.0625f > 0f) ? (0.0625f - num % 0.0625f) : 0f);
		roleBorderCollider.center = new Vector3(0f, num2 - num3, 0f);
		roleBorderCollider.size = new Vector3(roleBorder.size.x, roleBorder.size.y, 0.1f);
		if (uniqueRoleSpritesEnabled)
		{
			int index = perksTable.GetIndex(role);
			roleBackground.sprite = roleBackgroundSprites[index];
		}
	}

	public void RandomizeRole()
	{
		_activeRole = UnityEngine.Random.Range(0, Enum.GetNames(typeof(CharacterRole)).Length);
		UpdateRole();
	}
}
