using System;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class SelectionGroupToggleSingleButtonChallenge : SelectionGroupToggleSingleButton
{
	public static Action<SelectionGroupToggleSingleButtonChallenge> A_ChallengeHovered;

	public TextMeshProUGUI t_name;

	public TextMeshProUGUI t_silver;

	public GameObject completedIcon;

	public GameObject completedOverlay;

	private bool _003CisShowing_003Ek__BackingField;

	private ChallengeData _003CchallengeData_003Ek__BackingField;

	public bool isShowing
	{
		get
		{
			return _003CisShowing_003Ek__BackingField;
		}
		private set
		{
			_003CisShowing_003Ek__BackingField = value;
		}
	}

	public ChallengeData challengeData
	{
		get
		{
			return _003CchallengeData_003Ek__BackingField;
		}
		private set
		{
			_003CchallengeData_003Ek__BackingField = value;
		}
	}

	public void Set(ChallengeData challengeData)
	{
		_003CchallengeData_003Ek__BackingField = challengeData;
		if (challengeData.CanShow())
		{
			string displayName = _003CchallengeData_003Ek__BackingField.GetDisplayName();
			t_name.text = displayName;
			string silverMultiplier = _003CchallengeData_003Ek__BackingField.GetSilverMultiplier();
			string text = "<sprite name=silver> " + silverMultiplier + "x";
			t_silver.text = text;
			bool active = MyAchievements.IsUnlocked(_003CchallengeData_003Ek__BackingField);
			completedIcon.SetActive(active);
			bool active2 = MyAchievements.IsUnlocked(_003CchallengeData_003Ek__BackingField);
			completedOverlay.SetActive(active2);
			disabledOverlay.SetActive(value: false);
			base._003CcanSelect_003Ek__BackingField = true;
		}
		else
		{
			t_name.text = "??";
			t_silver.text = "";
			bool active3 = MyAchievements.IsUnlocked(_003CchallengeData_003Ek__BackingField);
			completedIcon.SetActive(active3);
			bool active4 = MyAchievements.IsUnlocked(_003CchallengeData_003Ek__BackingField);
			completedOverlay.SetActive(active4);
			disabledOverlay.SetActive(value: true);
			base._003CcanSelect_003Ek__BackingField = false;
		}
	}

	private void SetVisible()
	{
		string displayName = _003CchallengeData_003Ek__BackingField.GetDisplayName();
		t_name.text = displayName;
		string silverMultiplier = _003CchallengeData_003Ek__BackingField.GetSilverMultiplier();
		string text = "<sprite name=silver> " + silverMultiplier + "x";
		t_silver.text = text;
		bool active = MyAchievements.IsUnlocked(_003CchallengeData_003Ek__BackingField);
		completedIcon.SetActive(active);
		bool active2 = MyAchievements.IsUnlocked(_003CchallengeData_003Ek__BackingField);
		completedOverlay.SetActive(active2);
		disabledOverlay.SetActive(value: false);
		base._003CcanSelect_003Ek__BackingField = true;
	}

	private void SetHidden()
	{
		t_name.text = "??";
		t_silver.text = "";
		bool active = MyAchievements.IsUnlocked(_003CchallengeData_003Ek__BackingField);
		completedIcon.SetActive(active);
		bool active2 = MyAchievements.IsUnlocked(_003CchallengeData_003Ek__BackingField);
		completedOverlay.SetActive(active2);
		disabledOverlay.SetActive(value: true);
		base._003CcanSelect_003Ek__BackingField = false;
	}

	public override void StartHover()
	{
		isHovering = true;
		Action<SelectionGroupToggleSingleButtonChallenge> a_ChallengeHovered = A_ChallengeHovered;
		if (A_ChallengeHovered != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v29 @ rax_v3 (System.Action`1<SelectionGroupToggleSingleButtonChallenge>)+18] (should have been resolved before IL gen)");
		}
	}

	public override void StopHover()
	{
		isHovering = false;
	}

	public SelectionGroupToggleSingleButtonChallenge()
	{
		base._003CcanSelect_003Ek__BackingField = true;
		((MyButton)this)._002Ector();
	}
}
