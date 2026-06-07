using System;
using System.Collections.Generic;
using Achievements;
using UnityEngine;

[Serializable]
public class ResearchWork : WorkItem
{
	private ActiveWorkerManager _workerManager = new ActiveWorkerManager();

	public float Progress;

	public int Max;

	public float UpgFactor = 1f;

	public string Spec;

	public int Year;

	public bool Finished;

	public override Color BackColor
	{
		get
		{
			return new Color(0.95f, 0.4f, 0.13f);
		}
	}

	public ResearchWork(string name)
		: base(name, null, 0u, null)
	{
	}

	public ResearchWork()
	{
	}

	public ResearchWork(string spec, int year)
		: base("Researching".Loc(), null, 0u, null)
	{
		Spec = spec;
		Year = year;
		Max = Mathf.CeilToInt(GameSettings.Instance.simulation.GetTechMonths(spec));
	}

	public override string GetWorkTypeName()
	{
		return "Research";
	}

	public override void DoWork(Actor actor, float effect, float delta, bool secondary)
	{
		if (MarketSimulation.Active.TechLevels[Spec].Last().Year > Year)
		{
			NotificationManager.AddNotification(new NotificationMessage("ResearchTooSlow".Loc(Spec.LocTry(), Year + 1900), "Research", NotificationManager.NotificationType.Warning));
			Kill();
			return;
		}
		_workerManager.UpdateWorker(actor.DID, SDateTime.Now());
		effect = Utilities.PerDay(effect * GameData.GetProjectEffectiveness(_workerManager.Count, Max) * actor.GetPCAddonBonus(Employee.EmployeeRole.Designer) * actor.employee.GetSkill(Employee.EmployeeRole.Designer) * actor.LeaderEffectivenessFactor(3), delta);
		Progress = Mathf.Min(Max, Progress + effect * 8f);
		if (Progress == (float)Max && !Finished)
		{
			Finished = true;
			guiItem.InitButtons();
		}
		RecordSkill(Employee.EmployeeRole.Designer, actor, delta);
	}

	public override Employee.EmployeeRole? GetBoostRole(Actor act, bool secondary)
	{
		if (act.employee.IsRole(Employee.RoleBit.Designer, secondary))
		{
			return Employee.EmployeeRole.Designer;
		}
		return null;
	}

	public override HasWorkReturn HasWork(Actor actor, bool secondary, bool actualCheck)
	{
		if (Finished)
		{
			return HasWorkReturn.Finished;
		}
		HasWorkReturn hasWorkReturn = actor.employee.IsRoleSecondary(Employee.RoleBit.Designer, secondary);
		if (hasWorkReturn != HasWorkReturn.NotApplicable)
		{
			if (actor.employee.GetSpecialization(Employee.EmployeeRole.Designer, Spec) >= 3)
			{
				return hasWorkReturn;
			}
			return HasWorkReturn.NotApplicable;
		}
		return hasWorkReturn;
	}

	public void FinishNow()
	{
		if (!Finished)
		{
			return;
		}
		AchievementController.SetInteraction(AchievementController.Mechanics.Research);
		GameSettings.Instance.MyCompany.AddResearch(Spec, Year);
		TechLevel tech = GameSettings.Instance.simulation.AddTechLevel(Spec, Year, SDateTime.Now());
		if (tech != null)
		{
			WindowManager.Instance.ShowMessageBox("PatentPrompt".Loc(Spec.LocTry(), TechLevel.PatentPrice.Currency()), true, DialogWindow.DialogType.Question, delegate
			{
				LegalWork legalWork = new LegalWork(tech);
				GameSettings.Instance.MyCompany.AddWorkItem(legalWork);
				GameSettings.Instance.ApplyDefaultTeams(legalWork, string.Concat(legalWork.Type, "Team"));
			});
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("NoPatentPrompt".Loc(Spec.LocTry(), Year + 1900), true, DialogWindow.DialogType.Information);
		}
		HUD.Instance.researchWindow.UpdateLists();
		Kill();
	}

	public override float StressMultiplier()
	{
		return 0.5f;
	}

	public override string Category()
	{
		return Spec.LocTry() + " - " + (Year + 1900);
	}

	public override string CurrentStage()
	{
		if (!Finished)
		{
			return "Researching".Loc();
		}
		return "Finished".Loc();
	}

	public override string GetProgressLabel()
	{
		SDateTime? researchETA = MarketSimulation.Active.GetResearchETA(Spec, Year + 1);
		if (researchETA.HasValue)
		{
			return "CompetitorResearchETA".Loc() + ": " + researchETA.Value.ToQuarterString();
		}
		return base.GetProgressLabel();
	}

	public override string GetIcon()
	{
		return "Research";
	}

	public override float GetProgress()
	{
		return Progress / (float)Max;
	}

	public override string HightlightButton()
	{
		if (GetProgress() != 1f)
		{
			return null;
		}
		return "Finish";
	}

	public override Actor.WorkParticle EmitType(Actor actor, bool secondary)
	{
		return Actor.WorkParticle.Research;
	}

	public override IEnumerable<KeyValuePair<string, Action>> GetButtons()
	{
		yield return new KeyValuePair<string, Action>("Assign", delegate
		{
			Assign("Research");
		});
		if (Finished)
		{
			yield return new KeyValuePair<string, Action>("Finish", FinishNow);
		}
		yield return new KeyValuePair<string, Action>("Cancel", delegate
		{
			WindowManager.Instance.ShowMessageBox("ResearchCancelWarning".Loc(), true, DialogWindow.DialogType.Warning, delegate
			{
				Kill(true);
			}, "ResearchCancel");
		});
	}

	public override void GetNeeds(Dictionary<HRManagement.EdNeed, int>[] needs)
	{
		int optimalEmployees = GameData.GetOptimalEmployees(Max);
		needs.GetNeed(Employee.EmployeeRole.Designer).AddUp(new HRManagement.EdNeed(Spec, 3), optimalEmployees);
	}

	public override string GetTypeName()
	{
		return "ResearchWork";
	}

	public override string GetGroupType()
	{
		return "Research";
	}

	public override string GetGroupProject()
	{
		return "Research".Loc();
	}

	public override bool HasProjectGrouping()
	{
		return false;
	}

	public override string GetSubjectName()
	{
		return Spec.LocTry();
	}

	public override string GetGroupProjectLabel()
	{
		return Category();
	}

	public override string GetGroupTypeLabel()
	{
		return Category();
	}
}
