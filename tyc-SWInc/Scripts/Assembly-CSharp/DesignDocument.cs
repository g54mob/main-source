using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Achievements;
using SINetworking;
using UnityEngine;

[Serializable]
public class DesignDocument : SoftwareWorkItem
{
	public const int MaxIteration = 4;

	public WorkItem Result;

	public SHashSet<uint> EverWorked = new SHashSet<uint>();

	public SHashSet<string> NextPhaseTeam;

	public List<SoftwareProduct> Tools = new List<SoftwareProduct>();

	public Employee LeadDesigner;

	public bool HasFinished;

	public bool ContractStarted;

	public int Iteration;

	public float ReviewAccuracy;

	public float LastProgress;

	public float LeadProgress;

	private float _currentProgress = -1f;

	public SHashSet<KeyValuePair<string, string>> ReviewSpecs;

	public static Color32[][] IterationColors = new Color32[4][]
	{
		new Color32[4]
		{
			new Color32(157, 214, 133, 173),
			new Color32(214, 133, 157, 173),
			new Color32(214, 214, 214, 173),
			new Color32(214, 214, 64, 173)
		},
		new Color32[4]
		{
			new Color32(171, 160, 55, 173),
			new Color32(2, 85, 253, 173),
			new Color32(111, 130, 206, 173),
			new Color32(byte.MaxValue, 248, 57, 173)
		},
		new Color32[4]
		{
			new Color32(185, 170, 53, 173),
			new Color32(0, 80, byte.MaxValue, 173),
			new Color32(121, 139, 211, 173),
			new Color32(254, 251, 52, 173)
		},
		new Color32[4]
		{
			new Color32(97, 210, 250, 173),
			new Color32(215, 70, 113, 173),
			new Color32(58, 186, 225, 173),
			new Color32(254, 41, 107, 173)
		}
	};

	public SoftwareAlpha Parent;

	public const float MaxLeadProg = 0.25f;

	public static float[] BugRates = new float[5] { 1f, 0.95f, 0.8f, 0.6f, 0.3f };

	public static float[] MaxBugFactor = new float[5] { 1f, 0.95f, 0.88f, 0.75f, 0.5f };

	[NonSerialized]
	private bool _hasWarnedAboutLead;

	public override Color BackColor
	{
		get
		{
			return new Color(0f, 0f, 0.75f);
		}
	}

	public override bool AlwaysUseLocalProgressLabel
	{
		get
		{
			return true;
		}
	}

	public override bool CanOutsourceNetwork
	{
		get
		{
			if (Parent == null && (Needs == null || Needs.Values.None((SoftwareProduct x) => x.IsMock)) && (OSs == null || OSs.None((SoftwareProduct x) => x.IsMock)))
			{
				return AddonWorkParent == null;
			}
			return false;
		}
	}

	public override string UnitName
	{
		get
		{
			return "Iteration";
		}
	}

	public override uint MaxUnits
	{
		get
		{
			return 4u;
		}
	}

	public override byte ByteTypeID
	{
		get
		{
			return 6;
		}
	}

	public override bool HasNaturalNetworkEnd
	{
		get
		{
			return true;
		}
	}

	public override IReferenceFix FixReferences()
	{
		Tools.FixMyReferences(true);
		return base.FixReferences();
	}

	public DesignDocument()
	{
	}

	public DesignDocument(string name)
		: base(name)
	{
	}

	public DesignDocument(string name, SoftwareType type, SoftwareCategory category, Dictionary<string, SoftwareProduct> needs, SoftwareProduct[] os, float price, bool subscription, double[] submarkets, SDateTime start, Company company, SoftwareProduct sequelTo, bool inHouse, double loss, IList<FeatureBase> features, Dictionary<string, TechLevel> techs, ContractWork contract, string server, string server2, SoftwareFramework framework, string createFramework, List<SoftwareProduct> tools, bool tut = true, uint workID = 0u, NetworkDeal networkDeal = null)
		: base(name, type, category, needs, os, price, subscription, submarkets, start, company, sequelTo, inHouse, loss, features, techs, contract, server, server2, createFramework, framework, workID, networkDeal)
	{
		AchievementController.SetInteraction(AchievementController.Mechanics.Development);
		Tools = tools;
		if (tut)
		{
			TutorialSystem.Instance.StartTutorial("Design work");
		}
	}

	public DesignDocument(string name, SoftwareAddOn type, SoftwareCategory category, Dictionary<string, SoftwareProduct> needs, float price, SDateTime start, Company company, SoftwareProduct parent, SoftwareWorkItem parentW, double loss, IList<FeatureBase> features, uint[] factors, string server2, List<SoftwareProduct> tools, bool tut = true, uint workID = 0u, NetworkDeal networkDeal = null)
		: base(name, type, category, needs, price, start, company, parent, parentW, loss, features, factors, server2, workID, networkDeal)
	{
		AchievementController.SetInteraction(AchievementController.Mechanics.Development);
		Tools = tools;
		if (tut)
		{
			TutorialSystem.Instance.StartTutorial("Design work");
		}
	}

	public DesignDocument(SoftwareAlpha parent, ReviewWindow.ReviewData data)
		: base(parent, data)
	{
		Parent = parent;
		Parent.Child = this;
		ReviewAccuracy = data.Accuracy;
		ReviewSpecs = new SHashSet<KeyValuePair<string, string>>();
		foreach (KeyValuePair<string, Dictionary<string, float>> datum in data.Data)
		{
			foreach (KeyValuePair<string, float> item in datum.Value)
			{
				ReviewSpecs.Add(new KeyValuePair<string, string>(datum.Key, item.Key));
			}
		}
	}

	public bool NeedsLead()
	{
		if (!base.AddOn && contract == null && deal == 0)
		{
			return Parent == null;
		}
		return false;
	}

	public bool CanUseLead()
	{
		if (!base.AddOn && deal == 0)
		{
			return Parent == null;
		}
		return false;
	}

	public bool CompatibleLead(Employee emp)
	{
		if (GetNetworkDealState() == NetworkDealState.Receiver)
		{
			return !emp.HasDemanded(LeadDesignDemands.Demand.IPOwnership);
		}
		return true;
	}

	public Actor FindBestLeadDesigner(DesignDocument ignore = null)
	{
		float num = -0.5f;
		Actor result = null;
		foreach (Team item in DevTeams.SelectNotNull(GameSettings.GetTeam))
		{
			float score;
			Actor bestLeadDesigner = item.GetBestLeadDesigner(out score, Type, this, ignore);
			if (score > num)
			{
				num = score;
				result = bestLeadDesigner;
			}
		}
		return result;
	}

	public void ResetLeadDesigner()
	{
		if (!CanUseLead())
		{
			return;
		}
		bool flag = NeedsLead();
		if (SequelTo != null && SequelTo.DesignerOwned)
		{
			Employee leadDesigner = SequelTo.LeadDesigner;
			if (((leadDesigner != null) ? leadDesigner.MyActor : null) != null && DevTeams.Contains(SequelTo.LeadDesigner.MyActor.Team))
			{
				LeadDesigner = SequelTo.LeadDesigner;
			}
			else
			{
				LeadDesigner = null;
				if (flag && DevTeams.Count > 0 && !WorkIssueNotification.CheckAggregate(this, WorkIssueNotification.Issue.LeadDesignerOwnerError))
				{
					NotificationManager.AddNotification(new WorkIssueNotification(WorkIssueNotification.Issue.LeadDesignerOwnerError, this));
				}
			}
		}
		else if (flag)
		{
			Employee leadDesigner2 = LeadDesigner;
			Actor actor = FindBestLeadDesigner(this);
			LeadDesigner = (((object)actor != null) ? actor.employee : null);
			if (!AutoDev && leadDesigner2 != null && LeadDesigner != null && leadDesigner2 != LeadDesigner && LeadWork != null && !LeadWork.ContainsKey(LeadDesigner))
			{
				NotificationManager.AddNotification(new WorkItemNotification(this, "LeadDesignerChanged".LocColor(LeadDesigner, this), "Paper", NotificationManager.NotificationType.Neutral));
			}
		}
		else if (LeadDesigner != null && (LeadDesigner.MyActor == null || !LeadDesigner.IsRole(Employee.RoleBit.Designer) || !DevTeams.Contains(LeadDesigner.MyActor.Team) || (SequelTo != null && SequelTo.DesignerOwned && SequelTo.LeadDesigner != LeadDesigner)))
		{
			LeadDesigner = null;
		}
		CheckCompetency();
	}

	public void SetLeadDesigner(Employee emp)
	{
		if (CanUseLead())
		{
			if (!NeedsLead() && emp == null)
			{
				LeadDesigner = null;
				return;
			}
			if (emp == null || emp.MyActor == null || !emp.IsRole(Employee.RoleBit.Designer) || !DevTeams.Contains(emp.MyActor.Team) || (SequelTo != null && SequelTo.DesignerOwned && SequelTo.LeadDesigner != emp))
			{
				ResetLeadDesigner();
				return;
			}
			LeadDesigner = emp;
			CheckCompetency();
		}
	}

	public override void DevTeamChange()
	{
		base.DevTeamChange();
		if (NeedsLead())
		{
			if (LeadDesigner == null || !LeadDesigner.IsRole(Employee.RoleBit.Designer) || LeadDesigner.MyActor == null || !DevTeams.Contains(LeadDesigner.MyActor.Team))
			{
				ResetLeadDesigner();
			}
		}
		else if (CanUseLead())
		{
			ResetLeadDesigner();
		}
		if (Parent != null && !Done)
		{
			Parent.DesignTeams = DevTeams.ToList();
		}
	}

	public static DesignDocument CreateWork(string name, SoftwareType type, SoftwareCategory category, Dictionary<string, SoftwareProduct> needs, SoftwareProduct[] os, float price, bool subscription, double[] submarkets, SDateTime start, Company company, SoftwareProduct sequelTo, bool inHouse, double loss, IList<FeatureBase> features, Dictionary<string, TechLevel> techs, ContractWork contract, string server, string server2, SoftwareFramework framework, string createFramework, List<SoftwareProduct> tools, bool tut = true)
	{
		return new DesignDocument(name, type, category, needs, os, price, subscription, submarkets, start, company, sequelTo, inHouse, loss, features, techs, contract, server, server2, framework, createFramework, tools, tut);
	}

	public double RawProgress()
	{
		double num = 0.0;
		double num2 = 0.0;
		for (int i = 0; i < Features.Length; i++)
		{
			num += Features[i].Progress;
			num2 += Features[i].DevTime;
		}
		if (num2 != 0.0)
		{
			return num / num2;
		}
		return 0.0;
	}

	public override float GetProgress()
	{
		return GetCurrentProgress() - (float)Iteration;
	}

	public override float GetWorkScore()
	{
		return Mathf.Clamp01(GetCurrentProgress());
	}

	public override HasWorkReturn HasWork(Actor actor, bool secondary, bool actualCheck)
	{
		if (GetNetworkDealState() == NetworkDealState.Sender)
		{
			return HasWorkReturn.Ignore;
		}
		if (actualCheck && NeedsLead() && actor.employee != LeadDesigner && Iteration == 0 && GetCurrentProgress() - LastProgress >= 0.25f)
		{
			RemoveWorking(actor.employee);
			return HasWorkReturn.Waiting;
		}
		if (actor.employee.HasDemanded(LeadDesignDemands.Demand.ExclusiveLead))
		{
			if (actualCheck)
			{
				RemoveWorking(actor.employee);
			}
			if (CanUseLead())
			{
				if (LeadDesigner != actor.employee)
				{
					return HasWorkReturn.Ignore;
				}
				if (LastProgress == GetCurrentProgress())
				{
					return HasWorkReturn.Pretend;
				}
				return actor.employee.IsRoleSecondary(Employee.RoleBit.Designer, secondary);
			}
			return HasWorkReturn.Ignore;
		}
		if (NeedsLead() && Iteration == 0 && LeadDesigner == null)
		{
			if (actualCheck)
			{
				RemoveWorking(actor.employee);
			}
			return HasWorkReturn.Ignore;
		}
		if (!Enabled)
		{
			if (actualCheck)
			{
				RemoveWorking(actor.employee);
			}
			return HasWorkReturn.Ignore;
		}
		if (HasFinished)
		{
			if (actualCheck)
			{
				RemoveWorking(actor.employee);
			}
			return HasWorkReturn.Finished;
		}
		HasWorkReturn hasWorkReturn = actor.employee.IsRoleSecondary(Employee.RoleBit.Designer, secondary);
		if (hasWorkReturn == HasWorkReturn.NotApplicable)
		{
			if (actualCheck)
			{
				RemoveWorking(actor.employee);
			}
			return HasWorkReturn.NotApplicable;
		}
		if (actor.employee.HasDemanded(LeadDesignDemands.Demand.ExclusiveLead))
		{
			if (actualCheck)
			{
				RemoveWorking(actor.employee);
			}
			return hasWorkReturn;
		}
		HasWorkReturn result = hasWorkReturn;
		hasWorkReturn = CheckAdequateSpecLevel(actor, secondary, true, actualCheck);
		if (hasWorkReturn != HasWorkReturn.NotApplicable)
		{
			if (actualCheck && actor.isActiveAndEnabled)
			{
				AssignTaskIfNone(actor, secondary, true);
			}
		}
		else if (actor.employee == LeadDesigner)
		{
			if (!((double)LastProgress < RawProgress()))
			{
				return HasWorkReturn.Pretend;
			}
			return result;
		}
		return hasWorkReturn;
	}

	public override string GetProgressLabel()
	{
		if (Parent != null)
		{
			return "";
		}
		if (contract != null || deal != 0)
		{
			return "\n" + "Iteration".Loc() + ": " + (Iteration + 1);
		}
		if (!base.DistributionPlatform)
		{
			return "\n" + "FollowerAmount".Loc(Mathf.RoundToInt(base.Followers).ToString("N0"));
		}
		return "";
	}

	public override string CurrentStage()
	{
		return CurrentStageSub(Iteration, GetCurrentProgress(), LastProgress);
	}

	private string CurrentStageSub(int iteration, float progress, float lastProgress)
	{
		if (Parent != null)
		{
			return "IteratingOn".Loc(Parent.SoftwareName);
		}
		if (contract != null)
		{
			UpdateContractStart(false);
			if (ContractStarted)
			{
				return "DesignStageDesigning".Loc() + "\n" + contract.GetStatus(DevStart);
			}
			return "DesignWaitLabel".Loc();
		}
		if (base.ActiveDeal != null && base.ActiveDeal.Incoming)
		{
			return "DesignStageDesigning".Loc() + "\n" + base.ActiveDeal.GetStatus();
		}
		if (NeedsLead() && iteration == 0 && progress - lastProgress >= 0.25f)
		{
			return "LeadDesignerWait".Loc() + "\n" + "Iteration".Loc() + ": " + (iteration + 1);
		}
		return "DesignStageDesigning".Loc() + "\n" + "Iteration".Loc() + ": " + (iteration + 1);
	}

	public override byte[] SerializeProgressData()
	{
		using (MemoryStream memoryStream = new MemoryStream())
		{
			memoryStream.WriteInt(Iteration);
			memoryStream.WriteFloat(GetCurrentProgress());
			memoryStream.WriteFloat(LastProgress);
			return memoryStream.ToArray();
		}
	}

	public override void DeserializeProgressData(byte[] data)
	{
		NetworkCategory = Category();
		NetworkProgressLabel = GetProgressLabel();
		using (MemoryStream stream = new MemoryStream(data))
		{
			NetworkStage = CurrentStageSub(stream.ReadInt(), stream.ReadFloat(), stream.ReadFloat());
		}
	}

	private void UpdateContractStart(bool activate)
	{
		if (!ContractStarted && (activate || SDateTime.GetMonths(DevStart, SDateTime.Now()) >= 2f))
		{
			ContractStarted = true;
			SDateTime sDateTime = SDateTime.Now();
			DevStart += 2;
			if (sDateTime < DevStart)
			{
				DevStart = sDateTime;
			}
		}
	}

	public override string GetIcon()
	{
		return "Paper";
	}

	public static Color GetIterationColor(int iteration)
	{
		if (Options.ColorBlindness == -1)
		{
			return Options.GetCustomColor(13 + iteration);
		}
		return IterationColors[Options.ColorBlindness][iteration];
	}

	public override Color GetProgressColor()
	{
		return GetIterationColor(Iteration);
	}

	public override Color? GetLastPhaseProgress()
	{
		if (Iteration == 0)
		{
			return null;
		}
		return GetIterationColor(Iteration - 1);
	}

	public void SelectLeadDesigner()
	{
		if (SequelTo != null && SequelTo.DesignerOwned)
		{
			Employee leadDesigner = SequelTo.LeadDesigner;
			if (((leadDesigner != null) ? leadDesigner.MyActor : null) != null && DevTeams.Contains(SequelTo.LeadDesigner.MyActor.Team))
			{
				SetLeadDesigner(SequelTo.LeadDesigner);
				return;
			}
			Utilities.LeadDesignerIP(SequelTo, delegate
			{
				HUD.Instance.leadDesignWindow.Show(from x in DevTeams.SelectNotNull(GameSettings.GetTeam).SelectMany((Team x) => from z in x.GetEmployeesDirect()
						select z.employee)
					where x.IsRole(Employee.RoleBit.Designer) && CompatibleLead(x)
					select x, LeadDesigner, Type, SetLeadDesigner, !NeedsLead());
			});
			return;
		}
		HUD.Instance.leadDesignWindow.Show(from x in DevTeams.SelectNotNull(GameSettings.GetTeam).SelectMany((Team x) => from z in x.GetEmployeesDirect()
				select z.employee)
			where x.IsRole(Employee.RoleBit.Designer) && CompatibleLead(x)
			select x, LeadDesigner, Type, SetLeadDesigner, !NeedsLead());
	}

	public override IEnumerable<KeyValuePair<string, Action>> GetButtons()
	{
		NetworkDealState state = GetNetworkDealState();
		if (state == NetworkDealState.Sender)
		{
			if (!InHouse && !PublisherDeal.HasDeal(this, "Marketing") && !base.DistributionPlatform)
			{
				yield return new KeyValuePair<string, Action>("Market", delegate
				{
					HUD.Instance.marketingWindow.Show(this);
				});
			}
			yield return new KeyValuePair<string, Action>("FinishDeal", delegate
			{
				NetworkCancel(true);
			});
			yield return new KeyValuePair<string, Action>("CancelDeal", delegate
			{
				NetworkCancel(false);
			});
			yield break;
		}
		yield return new KeyValuePair<string, Action>("Assign", delegate
		{
			Assign((contract != null) ? "ContractDesign" : "Design", base.CheckCompetency);
		});
		if (CanUseLead())
		{
			yield return new KeyValuePair<string, Action>("AssignLead", SelectLeadDesigner);
		}
		if (Parent == null)
		{
			if (state == NetworkDealState.Receiver)
			{
				yield return new KeyValuePair<string, Action>("CancelDeal", base.NetworkComplete);
				yield break;
			}
			bool reverseCancel = contract != null;
			if (contract == null && base.ActiveDeal == null && !InHouse && !PublisherDeal.HasDeal(this, "Marketing") && !base.DistributionPlatform)
			{
				yield return new KeyValuePair<string, Action>("Market", delegate
				{
					HUD.Instance.marketingWindow.Show(this);
				});
			}
			else
			{
				reverseCancel |= base.ActiveDeal == null;
			}
			if (reverseCancel && !base.WorkAddOn && GameSettings.HasCompletedMission("Mission003") && (contract != null || GameSettings.HasCompletedMission("Mission05")))
			{
				yield return new KeyValuePair<string, Action>("Cancel", delegate
				{
					WindowManager.Instance.ShowMessageBox("WorkItemCancelConf".LocColor(this), true, DialogWindow.DialogType.Warning, delegate
					{
						Kill(true);
					}, "Cancel work");
				});
			}
			yield return new KeyValuePair<string, Action>("Develop", delegate
			{
				if (base.ActiveDeal == null && RawProgress() < (double)((contract == null) ? 0.25f : (contract.Quality / 2f)) && !Options.IgnoreQuestions.Contains("Promote from design"))
				{
					WindowManager.Instance.ShowMessageBox("DesignSafetyCheck2".Loc(), true, DialogWindow.DialogType.Question, delegate
					{
						PromoteAction();
					}, "Promote from design");
				}
				else
				{
					WindowManager.Instance.ShowMessageBox("DesignPromotionPrompt".Loc(), true, DialogWindow.DialogType.Question, delegate
					{
						PromoteAction();
					}, "GenericDesignPromote");
				}
			});
			if (reverseCancel || base.WorkAddOn || !GameSettings.HasCompletedMission("Mission003") || (contract == null && !GameSettings.HasCompletedMission("Mission05")))
			{
				yield break;
			}
			yield return new KeyValuePair<string, Action>("Cancel", delegate
			{
				WindowManager.Instance.ShowMessageBox("WorkItemCancelConf".LocColor(this), true, DialogWindow.DialogType.Warning, delegate
				{
					Kill(true);
				}, "Cancel work");
			});
		}
		else
		{
			yield return new KeyValuePair<string, Action>((Parent != null) ? "Finish" : "End", delegate
			{
				PromoteAction();
			});
		}
	}

	public override void GetNeeds(Dictionary<HRManagement.EdNeed, int>[] needs)
	{
		GetNeeds(needs, true);
	}

	public override string GetTypeName()
	{
		return "DesignDocument";
	}

	public override string GetGroupType()
	{
		if (Parent == null)
		{
			return "Design";
		}
		return "Iteration";
	}

	public float GetCurrentProgress()
	{
		if (_currentProgress < 0f)
		{
			_currentProgress = (float)RawProgress();
		}
		return _currentProgress;
	}

	public override void DoWork(Actor ac, float effectiveness, float delta, bool secondary)
	{
		EverWorked.Add(ac.DID);
		if (CanUseLead() && ac.employee == LeadDesigner)
		{
			if (NetworkManager.IsConnected && ac.employee.NetworkID == 0)
			{
				NetworkMessaging.RegisterLeadDesigner(ac.employee);
			}
			float currentProgress = GetCurrentProgress();
			float a = 0f;
			float num = 0f;
			if (LastProgress < 1f)
			{
				if (currentProgress > 1f)
				{
					num = currentProgress - 1f;
					a = 1f - LastProgress;
				}
				else
				{
					a = currentProgress - LastProgress;
				}
			}
			else
			{
				num = currentProgress - LastProgress;
			}
			a = Mathf.Min(a, 0.25f);
			float actualInspiration = ac.employee.GetActualInspiration();
			LeadProgress = Mathf.Min(1f, LeadProgress + Mathf.Min(1f, actualInspiration) * a * 1.01f + num * 0.05f);
			bool flag = false;
			if (a > 0f)
			{
				if (actualInspiration < 1f && contract == null && !WorkIssueNotification.CheckAggregate(this, WorkIssueNotification.Issue.LeadDesignerInspirationWarning))
				{
					NotificationManager.AddNotification(new WorkIssueNotification(WorkIssueNotification.Issue.LeadDesignerInspirationWarning, this));
				}
				float num2 = Mathf.Clamp01(ac.employee.Creativity * Mathf.Min(1f, actualInspiration) * ac.employee.GetWeightedLeadSpecFactor(Type));
				CreativityScore = Utilities.Clamp01(CreativityScore + (double)((num2 - 0.5f) * a * 1.01f));
				ac.employee.TakeInspiration(a * 0.95f);
				RegisterLeadWork(ac.employee, a);
				flag = true;
			}
			if (num > 0f)
			{
				num = Mathf.Min(num, 0.25f);
				CreativityScore = Math.Min(1.0, CreativityScore + (double)(0.05f * num));
				ac.employee.TakeInspiration(0f);
				flag = true;
			}
			if (flag && !NeedsLead())
			{
				effectiveness *= 0.5f;
			}
			LastProgress = currentProgress;
			if (ac.employee.HasDemanded(LeadDesignDemands.Demand.ExclusiveLead))
			{
				return;
			}
		}
		if (effectiveness < 0f)
		{
			return;
		}
		if (WorkDevTime < 0f)
		{
			RefreshWorkDevTime();
		}
		float num3 = ac.employee.GetSkill(Employee.EmployeeRole.Designer);
		if (ac.employee.HasTrait(Employee.Trait.FirmwareInc))
		{
			num3 = HWSkillFactor(num3, ac);
		}
		RecordSkill(Employee.EmployeeRole.Designer, num3, delta);
		effectiveness *= num3.WeightOne(0.9f) * ac.GetPCAddonBonus((!ac.employee.IsRole(Employee.RoleBit.Lead)) ? Employee.EmployeeRole.Designer : Employee.EmployeeRole.Lead) * SoftwareType.GetEmployeeCountEffect(Mathf.Max(1, NewWorking.Count), WorkDevTime, true);
		effectiveness *= DifficultyValues.Difficulty.DesignDocumentSpeedBonus;
		float num4 = ac.LeaderEffectivenessFactor(2);
		if (contract != null)
		{
			UpdateContractStart(true);
		}
		float num5 = Utilities.PerHour(1f - SoftwareType.DesignRatio, delta);
		num5 /= (float)GameSettings.DaysPerMonth;
		if (HasFinished)
		{
			return;
		}
		FeatureProgress featureProgress = FindJob(ac, secondary, true, true);
		float num6 = num5 * effectiveness * num4;
		double actuallyAdded;
		if (featureProgress == null)
		{
			if (WorkAllFeatures(ac, num6, Iteration + 1, Employee.EmployeeRole.Designer, out actuallyAdded, false, 0f))
			{
				RefreshWorkDevTime();
			}
			_currentProgress = (float)RawProgress();
		}
		else
		{
			bool change;
			featureProgress.AddProgress(num6, Employee.EmployeeRole.Designer, ac.employee.GetSpecialization(Employee.EmployeeRole.Designer, featureProgress.Feature.Spec) == 3, out change, out actuallyAdded, Iteration + 1);
			if (change)
			{
				RefreshWorkDevTime();
			}
			_currentProgress = (float)RawProgress();
		}
		if (!AllDone(true))
		{
			return;
		}
		if (Parent == null && Iteration < 3)
		{
			NewWorking.Clear();
			Iteration++;
			TotalNetworkUnits += 1f;
			for (int i = 0; i < Features.Length; i++)
			{
				Features[i].ArtDone = (Features[i].CodeDone = false);
			}
			RefreshWorkDevTime();
			_currentProgress = (float)RawProgress();
		}
		else
		{
			TotalNetworkUnits += 1f;
			HasFinished = true;
		}
	}

	public override Employee.EmployeeRole? GetBoostRole(Actor act, bool secondary)
	{
		if (act.employee.IsRole(Employee.RoleBit.Designer, secondary))
		{
			return Employee.EmployeeRole.Designer;
		}
		return null;
	}

	public static void FinishIteration(SoftwareAlpha target, IList<FeatureProgress> progs, float accuracy, HashSet<KeyValuePair<string, string>> specs)
	{
		target.LastIteration = SDateTime.Now();
		int optimalIterations = SoftwareWorkItem.GetOptimalIterations(target.DevTime);
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < target.Features.Length; i++)
		{
			FeatureProgress feature = target.Features[i];
			if (feature.OS)
			{
				continue;
			}
			FeatureProgress featureProgress = progs.FirstOrDefault((FeatureProgress x) => x.Feature == feature.Feature);
			if (featureProgress == null)
			{
				continue;
			}
			bool flag3 = feature.ArtTargetQual < 1.0 && feature.ADevTime > 0.0 && (specs == null || specs.Contains(new KeyValuePair<string, string>("Art", feature.Feature.Spec)));
			bool flag4 = feature.CodeTargetQual < 1.0 && feature.CDevTime > 0.0 && (specs == null || specs.Contains(new KeyValuePair<string, string>("Code", feature.Feature.Spec)));
			if (!(flag3 || flag4))
			{
				continue;
			}
			float lastIterationProg = feature.LastIterationProg;
			double num = Utilities.Clamp01(feature.GetOverallProgress() - (double)lastIterationProg) * (double)accuracy * (featureProgress.Progress / featureProgress.DevTime);
			double num2 = 1.0 - 0.5 * num;
			if (num2 < 1.0)
			{
				if (flag4)
				{
					feature.Progress *= num2;
					feature.CodeDone = false;
					feature.CodeTargetQual = Utilities.Clamp01(feature.CodeTargetQual + 0.5 * num / (double)optimalIterations);
					flag2 = true;
				}
				if (flag3)
				{
					feature.ArtProgress *= num2;
					feature.ArtDone = false;
					feature.ArtTargetQual = Utilities.Clamp01(feature.ArtTargetQual + 0.5 * num / (double)optimalIterations);
					flag = true;
				}
			}
			feature.LastIterationProg = (float)feature.GetOverallProgress();
		}
		if (flag || flag2)
		{
			target.HasFinishedArt &= !flag;
			target.HasFinishedCode &= !flag2;
			target.HasFinished = false;
			target.RefreshWorkDevTime();
		}
	}

	public override object PromoteAction()
	{
		if (Parent != null)
		{
			FinishIteration(Parent, Features, ReviewAccuracy, ReviewSpecs);
			Kill();
			return null;
		}
		if (base.ActiveDeal != null && base.ActiveDeal.Incoming)
		{
			Kill();
			return null;
		}
		if (NeedsLead() && LeadWork == null)
		{
			if (!_hasWarnedAboutLead && !AutoDev)
			{
				_hasWarnedAboutLead = true;
				WindowManager.Instance.ShowMessageBox("DesignNoProgress".Loc(), false, DialogWindow.DialogType.Error);
			}
			return null;
		}
		double num = RawProgress();
		int maxBugs = Mathf.RoundToInt(MaxBugFactor.FuzzyIndex((float)num) * ((float)MaxBugs / 2f));
		float bugRate = BugRates.FuzzyIndex((float)num);
		PublisherInstaMarket();
		double creativityScore = CreativityScore * Utilities.Clamp01(num);
		SoftwareAlpha softwareAlpha = ((!base.AddOn) ? new SoftwareAlpha(base.Name, SWID, Type, SWCategory, Needs, Features, TechLevels, OSs, Price, SubscriptionBased, Submarkets, DevStart, 0f, MyCompany, SequelTo, InHouse, Loss, contract, Server, Server2, (guiItem == null) ? (-1) : guiItem.transform.GetSiblingIndex(), EverWorked, base.Followers, MaxFollowers, FollowerChange, ReleaseDate, maxBugs, bugRate, Framework, FrameworkRoyalty, CreateFramework, DevTeams.ToList(), Tools, creativityScore, _anyMarketing, _workRoyalties) : new SoftwareAlpha(base.Name, SWID, AddonType, SWCategory, Needs, Features, Price, DevStart, 0f, MyCompany, AddonParent, AddonWorkParent, Loss, Server2, (guiItem == null) ? (-1) : guiItem.transform.GetSiblingIndex(), EverWorked, base.Followers, MaxFollowers, FollowerChange, ReleaseDate, maxBugs, bugRate, DevTeams.ToList(), Tools, creativityScore, _anyMarketing, _workRoyalties));
		softwareAlpha.DesignProgress = Mathf.Min(1f, LastProgress);
		if (AddonWorkParent != null)
		{
			AddonWorkParent.AddonWorkChildren.Remove(this);
		}
		for (int i = 0; i < AddonWorkChildren.Count; i++)
		{
			AddonWorkChildren[i].AddonWorkParent = softwareAlpha;
		}
		softwareAlpha.AddonWorkChildren.AddRange(AddonWorkChildren);
		AddonWorkChildren.Clear();
		softwareAlpha.HardwareDesign = HardwareDesign;
		softwareAlpha.LeadWork = LeadWork;
		if (Publishing != null)
		{
			softwareAlpha.Publishing = Publishing;
			Publishing.WorkTarget = softwareAlpha;
			Publishing = null;
		}
		Result = softwareAlpha;
		if (deal == 0 && contract == null && GetWorkOwner().IsLocalPlayer && Type.Name.Equals("Operating System") && !base.AddOn)
		{
			softwareAlpha.CreateMock();
		}
		MyCompany.AddWorkItem(Result);
		if (!AutoDev)
		{
			Result.AddDevTeams(NextPhaseTeam ?? DevTeams);
			if (base.Followers == 0f && !InHouse && contract == null && !PublisherDeal.HasDeal(this, "Marketing") && !base.DistributionPlatform)
			{
				NotificationManager.AddNotification(new WorkItemNotification(softwareAlpha, "NoPreMarketWarning".LocColor(this), "Newspaper", NotificationManager.NotificationType.Warning));
			}
		}
		Result.Collapsed = Collapsed;
		Result.Hidden = base.Hidden;
		Result.Priority = Priority;
		softwareAlpha.CheckCompetency();
		List<MarketingPlan> list = (from x in GameSettings.Instance.MyCompany.WorkItems.OfType<MarketingPlan>()
			where x.TargetItem == this
			select x).ToList();
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			if (AutoDev && list[num2].Type == MarketingPlan.TaskType.PressRelease)
			{
				list[num2].StopMarketing();
			}
			else
			{
				list[num2].TargetItem = (SoftwareWorkItem)Result;
			}
		}
		Kill();
		return Result;
	}

	public override float StressMultiplier()
	{
		return 1f;
	}

	public override void Kill(bool wasCancelled = false)
	{
		if (Parent != null)
		{
			Parent.Child = null;
			base.Kill(wasCancelled);
			return;
		}
		List<MarketingPlan> list = (from x in GameSettings.Instance.MyCompany.WorkItems.OfType<MarketingPlan>()
			where x.TargetItem == this
			select x).ToList();
		for (int num = 0; num < list.Count; num++)
		{
			list[num].Kill();
		}
		GameSettings.Instance.FollowerSimulation.Remove(this);
		if (HUD.Instance.marketingWindow.TargetWork == this)
		{
			HUD.Instance.marketingWindow.Window.Close();
		}
		FixAutoDev();
		base.Kill(wasCancelled);
	}

	protected override void Cancelled()
	{
		base.Cancelled();
		if (Parent == null)
		{
			if (base.Followers > 0f && ReleaseDate.HasValue)
			{
				GameSettings.Instance.MyCompany.AddFans(-Mathf.CeilToInt(base.Followers * 0.75f), SWCategory);
			}
			if (contract != null)
			{
				ContractResult value = new ContractResult(contract, true, 0, 0f, SDateTime.GetDaysFlat(DevStart, SDateTime.Now()), 0f);
				HUD.Instance.contractWindow.ContractResults.Items.Add(value);
			}
			if (base.ActiveDeal != null && AllZero(false))
			{
				HUD.Instance.dealWindow.CancelDeal(base.ActiveDeal, false);
				base.ActiveDeal = null;
			}
		}
	}

	public override string GetWorkTypeName()
	{
		return "Design";
	}

	public override string HightlightButton()
	{
		if (HasFinished)
		{
			if (Parent != null)
			{
				return "Finish";
			}
			return "Develop";
		}
		if (DevTeams.Count > 0 && NeedsLead() && LeadDesigner == null)
		{
			return "AssignLead";
		}
		return null;
	}

	public override Actor.WorkParticle EmitType(Actor actor, bool secondary)
	{
		return Actor.WorkParticle.Letters;
	}

	public override string GetSubjectName()
	{
		return SoftwareName;
	}

	public override void AddLoss(float cost, bool fromNetwork = false)
	{
		if (Parent != null)
		{
			Parent.AddLoss(cost, fromNetwork);
		}
		else
		{
			base.AddLoss(cost, fromNetwork);
		}
	}

	protected override IEnumerable<Employee.EmployeeRole> CompCheck()
	{
		if (!HasFinished)
		{
			yield return Employee.EmployeeRole.Designer;
		}
	}

	public override string ProgressTip()
	{
		return "IterationWorkTip";
	}

	public override string GetTutorial()
	{
		if (contract != null)
		{
			return base.GetTutorial();
		}
		return "Design work";
	}

	public override bool DisableCompCheck()
	{
		if (NeedsLead())
		{
			return LeadDesigner == null;
		}
		return false;
	}

	public override float GetLicenseAmount()
	{
		return 0f;
	}

	public override void OnNetworkComplete(Stream st)
	{
		st.ExecuteArray(delegate(Stream s)
		{
			Employee employee = NetworkManager.Instance.GetNetworkObject(s.ReadUInt()) as Employee;
			float work = s.ReadFloat();
			if (employee != null)
			{
				RegisterLeadWork(employee, work);
			}
		});
		ReadProgress(st);
	}

	public void ReadProgress(Stream st)
	{
		Iteration = st.ReadInt();
		CreativityScore = st.ReadDouble();
		LastProgress = st.ReadFloat();
		LeadProgress = st.ReadFloat();
		st.ExecuteArray(delegate(Stream s)
		{
			uint id = s.ReadUInt();
			double progress = s.ReadDouble();
			FeatureProgress featureProgress = Features.FirstOrDefault((FeatureProgress x) => x.Feature.ID == id);
			if (featureProgress != null)
			{
				featureProgress.Progress = progress;
				featureProgress.UpdateStatus(true, Iteration + 1);
			}
		});
		if (!AllDone(true))
		{
			return;
		}
		if (Parent == null && Iteration < 3)
		{
			NewWorking.Clear();
			Iteration++;
			for (int num = 0; num < Features.Length; num++)
			{
				Features[num].ArtDone = (Features[num].CodeDone = false);
			}
			RefreshWorkDevTime();
			_currentProgress = (float)RawProgress();
		}
		else
		{
			HasFinished = true;
		}
	}

	public override byte[] GetNetworkCompletionData(bool success)
	{
		if (success)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				memoryStream.WriteArray(LeadWork, delegate(Stream s, KeyValuePair<Employee, float> x)
				{
					s.WriteUInt(x.Key.NetworkID);
					s.WriteFloat(x.Value);
				});
				memoryStream.WriteInt(Iteration);
				memoryStream.WriteDouble(CreativityScore);
				memoryStream.WriteFloat(LastProgress);
				memoryStream.WriteFloat(LeadProgress);
				memoryStream.WriteArray(Features, delegate(Stream s, FeatureProgress x)
				{
					s.WriteUInt(x.Feature.ID);
					s.WriteDouble(x.Progress);
				});
				return memoryStream.ToArray();
			}
		}
		return null;
	}

	public override void WriteSubData(Stream st)
	{
		st.WriteStringUTF8(SoftwareName);
		st.WriteUInt(Type.ID);
		st.WriteUInt(SWCategory.ID);
		st.WriteUInt(base.AddOn ? AddonType.ID : 0u);
		st.WriteUInt(base.AddOn ? AddonParent.ID : 0u);
		st.WriteArray(Needs, delegate(Stream s, KeyValuePair<string, SoftwareProduct> x)
		{
			st.WriteStringUTF8(x.Key);
			st.WriteUInt(x.Value.ID);
		});
		st.WriteArray(OSs, delegate(Stream s, SoftwareProduct x)
		{
			s.WriteUInt(x.ID);
		});
		st.WriteFloat(Price);
		st.WriteBool(SubscriptionBased);
		st.WriteArray(Submarkets, delegate(Stream s, double x)
		{
			s.WriteDouble(x);
		});
		DevStart.WriteData(st);
		Stream stream = st;
		SoftwareProduct sequelTo = SequelTo;
		stream.WriteUInt((sequelTo != null) ? sequelTo.ID : 0u);
		st.WriteBool(InHouse);
		st.WriteDouble(Loss);
		st.WriteArray(Features.Where((FeatureProgress x) => !x.OS), delegate(Stream s, FeatureProgress x)
		{
			s.WriteUInt(x.Feature.ID);
			s.WriteUInt(x.Factor);
		});
		st.WriteArray(TechLevels, delegate(Stream s, KeyValuePair<string, TechLevel> x)
		{
			st.WriteStringUTF8(x.Key);
			st.WriteInt(x.Value.Year);
		});
		Stream stream2 = st;
		SoftwareFramework framework = Framework;
		stream2.WriteUInt((framework != null) ? framework.ID : 0u);
		st.WriteStringUTF8(CreateFramework);
		st.WriteArray(Tools, delegate(Stream s, SoftwareProduct x)
		{
			s.WriteUInt(x.ID);
		});
		st.WriteInt(Iteration);
		st.WriteDouble(CreativityScore);
		st.WriteFloat(LastProgress);
		st.WriteFloat(LeadProgress);
		st.WriteArray(Features, delegate(Stream s, FeatureProgress x)
		{
			s.WriteUInt(x.Feature.ID);
			s.WriteDouble(x.Progress);
		});
	}

	public override bool IsDoneForNetworkDeal()
	{
		return HasFinished;
	}

	public override void ReceiveNetworkDealSync(Stream st)
	{
		CreativityScore = st.ReadDouble();
		Iteration = st.ReadInt();
	}

	public override byte[] SubSendNetworkDealSync()
	{
		using (MemoryStream memoryStream = new MemoryStream())
		{
			memoryStream.WriteDouble(CreativityScore);
			memoryStream.WriteInt(Iteration);
			return memoryStream.ToArray();
		}
	}

	public override string GetSoftwareWorkType()
	{
		return "Design";
	}

	public override string GetDetailedTypeName()
	{
		if (Parent == null)
		{
			return base.GetDetailedTypeName();
		}
		return "Iteration".Loc();
	}

	public override string CollapseLabel()
	{
		if (Parent != null)
		{
			return RawProgress().ToPercent();
		}
		if (contract != null && ContractStarted)
		{
			return contract.GetStatus(DevStart) + " - " + "Iteration".Loc() + ": " + (Iteration + 1);
		}
		return "Iteration".Loc() + ": " + (Iteration + 1);
	}
}
