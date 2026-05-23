using System;
using TMPro;
using UnityEngine;

public class SelectionGroupToggleSingleButtonChallenge : SelectionGroupToggleSingleButton
{
	public static Action<SelectionGroupToggleSingleButtonChallenge> A_ChallengeHovered;

	public TextMeshProUGUI t_name;

	public TextMeshProUGUI t_silver;

	public GameObject completedIcon;

	public GameObject completedOverlay;

	public bool isShowing { get; private set; }

	public ChallengeData challengeData { get; private set; }

	public void Set(ChallengeData challengeData)
	{
	}

	private void SetVisible()
	{
	}

	private void SetHidden()
	{
	}

	public override void StartHover()
	{
	}

	public override void StopHover()
	{
	}
}
