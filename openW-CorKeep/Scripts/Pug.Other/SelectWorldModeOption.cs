using System;
using Unity.Mathematics;
using UnityEngine;

public class SelectWorldModeOption : RadicalMenuOption
{
	[SerializeField]
	private int activeDifficultyIndex;

	public SpriteRenderer hoverSprite;

	public Animator animator;

	public PugText text;

	public PugText descText;

	public Transform leftArrow;

	public Transform rightArrow;

	public GameObject worldGenerationSection;

	public bool readOnly;

	private static WorldMode[] difficultyLevels = new WorldMode[4]
	{
		WorldMode.Normal,
		WorldMode.Hard,
		WorldMode.Creative,
		WorldMode.Casual
	};

	private static string[] difficultyLevelNames = new string[4] { "NormalMode", "HardMode", "CreativeMode", "CasualMode" };

	private static string[] difficultyLevelsDesc = new string[4] { "NormalModeDesc", "HardModeDesc", "CreativeModeDesc", "CasualModeDesc" };

	public override void OnParentMenuActivation()
	{
		base.OnParentMenuActivation();
		hoverSprite.enabled = false;
		UpdateText();
	}

	public override void OnActivated()
	{
		base.OnActivated();
		if (!readOnly)
		{
			OnSkimRight();
		}
	}

	public override void OnSelected()
	{
		base.OnSelected();
		hoverSprite.enabled = true;
	}

	public override void OnDeselected(bool playEffect = true)
	{
		base.OnDeselected(playEffect);
		hoverSprite.enabled = false;
	}

	public override bool OnSkimLeft()
	{
		if (!readOnly)
		{
			SkimLeft();
		}
		return base.OnSkimLeft();
	}

	public void SkimLeft()
	{
		int num = ((activeDifficultyIndex == 0) ? (difficultyLevelNames.Length - 1) : (activeDifficultyIndex - 1));
		SetActiveDifficultyIndex(num);
		UpdateText();
		AudioManager.SfxUI(SfxID.FIXME_menu_select, 1f, reuse: true, 1f, 0.15f, playOnGamepad: true);
		animator.SetTrigger(2063870753);
	}

	public override bool OnSkimRight()
	{
		if (!readOnly)
		{
			SkimRight();
		}
		return base.OnSkimRight();
	}

	public void SkimRight()
	{
		SetActiveDifficultyIndex((activeDifficultyIndex + 1) % difficultyLevelNames.Length);
		UpdateText();
		AudioManager.SfxUI(SfxID.FIXME_menu_select, 1f, reuse: true, 1f, 0.15f, playOnGamepad: true);
		animator.SetTrigger(-1144262676);
	}

	public void SetActiveDifficulty(WorldMode mode)
	{
		int num = Array.IndexOf(difficultyLevels, mode);
		if (num < 0)
		{
			Debug.LogError($"Invalid difficulty mode {mode}");
		}
		else
		{
			SetActiveDifficultyIndex(num);
		}
	}

	private void SetActiveDifficultyIndex(int index)
	{
		activeDifficultyIndex = index;
		UpdateText();
	}

	public WorldMode GetActiveDifficulty()
	{
		return difficultyLevels[activeDifficultyIndex];
	}

	private void UpdateText()
	{
		if (worldGenerationSection != null)
		{
			worldGenerationSection.SetActive(activeDifficultyIndex != 2);
		}
		text.Render(difficultyLevelNames[activeDifficultyIndex]);
		text.SetTempColor(Manager.text.GetModeColor(Mathf.Max(0, (int)GetActiveDifficulty())));
		descText.Render(difficultyLevelsDesc[activeDifficultyIndex]);
		descText.MarkUIComponentAsDirty(render: true);
		float num = text.dimensions.width / 2f + 0.625f;
		num += num % 0.125f;
		leftArrow.localPosition = new Vector3(math.min(-2.3125f, 0f - num), -0.0625f, 0f);
		rightArrow.localPosition = new Vector3(math.max(2.3125f, num), -0.0625f, 0f);
		float y = text.dimensions.size.y + text.dimensions.size.y % 0.125f;
		float x = text.dimensions.size.x + text.dimensions.size.x % 0.125f + 0.375f;
		hoverSprite.size = new Vector2(x, y);
	}
}
