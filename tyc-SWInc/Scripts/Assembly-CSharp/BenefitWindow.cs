using System;
using Achievements;
using UnityEngine;
using UnityEngine.UI;

public class BenefitWindow : MonoBehaviour
{
	public GUIWindow Window;

	public EmployeeBenefitPanel Benefits;

	[NonSerialized]
	private IBenefitReceiver[] _targets;

	public Image CarColorButton;

	public RectTransform BenefitPanel;

	public bool CloseOnApply;

	public bool IsCompany
	{
		get
		{
			return _targets == null;
		}
	}

	public void Show(IBenefitReceiver[] targets, bool closeOnApply = false)
	{
		_targets = targets;
		Benefits.SetTargets(EmployeeBenefitPanel.Style.Override, _targets);
		CarColorButton.gameObject.SetActive(false);
		BenefitPanel.offsetMin = new Vector2(BenefitPanel.offsetMin.x, 43f);
		AchievementController.SetInteraction(AchievementController.Mechanics.Benefits);
		CloseOnApply = closeOnApply;
		Window.Show();
	}

	public void Toggle()
	{
		if (Window.ToggleReturn())
		{
			_targets = null;
			CarColorButton.gameObject.SetActive(true);
			BenefitPanel.offsetMin = new Vector2(BenefitPanel.offsetMin.x, 74f);
			CarColorButton.color = GameSettings.Instance.CompanyCarColor;
			Benefits.SetTargets(EmployeeBenefitPanel.Style.Reset, GameSettings.Instance);
			TutorialSystem.Instance.StartTutorial("Benefits");
			AchievementController.SetInteraction(AchievementController.Mechanics.Benefits);
			CloseOnApply = false;
		}
	}

	public void ChangeCarColor()
	{
		WindowManager.SpawnColorDialog(delegate(Color x)
		{
			GameSettings.Instance.CompanyCarColor = x;
			CarColorButton.color = x;
		}, GameSettings.Instance.CompanyCarColor);
	}

	public void PreChange()
	{
		if (_targets == null)
		{
			foreach (Actor actor in GameSettings.Instance.sActorManager.Actors)
			{
				actor.CacheBenefits();
			}
			return;
		}
		IBenefitReceiver[] targets = _targets;
		for (int i = 0; i < targets.Length; i++)
		{
			targets[i].CacheBenefits();
		}
	}

	public void OnChange()
	{
		if (_targets == null)
		{
			foreach (Actor actor in GameSettings.Instance.sActorManager.Actors)
			{
				actor.ApplyNewBenefits();
			}
		}
		else
		{
			IBenefitReceiver[] targets = _targets;
			for (int i = 0; i < targets.Length; i++)
			{
				targets[i].ApplyNewBenefits();
			}
		}
		if (CloseOnApply)
		{
			Window.Close();
		}
	}
}
