using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

[Serializable]
public class SoftwareUpdate : SoftwareWorkItem, IServerItem, IReferenceFix
{
	public SoftwareProduct Target;

	public SoftwareFramework TargetFramework;

	public bool HasFinished;

	public bool HasFinishedArt;

	public bool HasFinishedCode;

	public bool FixBugs;

	public float AddedBugs;

	public float FixedBugs;

	private float _sourceControlBoost;

	private ActiveWorkerManager _workerManager = new ActiveWorkerManager();

	public bool IsFramework
	{
		get
		{
			return TargetFramework != null;
		}
	}

	public bool UsesISP
	{
		get
		{
			return false;
		}
	}

	public override Color BackColor
	{
		get
		{
			return new Color(0f, 0.75f, 0f);
		}
	}

	public override bool CanOutsourceNetwork
	{
		get
		{
			return true;
		}
	}

	public override string UnitName
	{
		get
		{
			return "Bug";
		}
	}

	public override bool HasNaturalNetworkEnd
	{
		get
		{
			return true;
		}
	}

	public override byte ByteTypeID
	{
		get
		{
			return 2;
		}
	}

	public override IReferenceFix FixReferences()
	{
		if (IsFramework)
		{
			string name = TargetFramework.Name;
			TargetFramework = (SoftwareFramework)TargetFramework.FixReferences();
			if (TargetFramework == null)
			{
				SelectorController.MissingDataHost.Add(name);
				Kill();
				return null;
			}
		}
		else
		{
			string name2 = Target.Name;
			Target = (SoftwareProduct)Target.FixReferences();
			if (Target == null)
			{
				SelectorController.MissingDataHost.Add(name2);
				Kill();
				return null;
			}
		}
		return base.FixReferences();
	}

	public SoftwareUpdate()
	{
	}

	public SoftwareUpdate(SoftwareProduct target, bool fixBugs, Dictionary<string, TechLevel> tech, Dictionary<string, SoftwareProduct> needs, string scm, int siblingIndex, uint networkID = 0u, NetworkDeal networkDeal = null)
		: base(target, tech, needs, scm, siblingIndex, networkID, networkDeal)
	{
		if (tech != null && tech.Count > 0)
		{
			HasFinishedCode = CodeArtRatio == 0f;
			HasFinishedArt = CodeArtRatio == 1f;
		}
		else
		{
			HasFinishedCode = (HasFinishedArt = (HasFinished = true));
		}
		Target = target;
		FixBugs = fixBugs;
		RegisterServer();
	}

	public SoftwareUpdate(SoftwareFramework target, Dictionary<string, TechLevel> tech, string scm, int siblingIndex, uint networkID = 0u, NetworkDeal networkDeal = null)
		: base(target, tech, scm, siblingIndex, networkID, networkDeal)
	{
		if (tech != null && tech.Count > 0)
		{
			HasFinishedCode = CodeArtRatio == 0f;
			HasFinishedArt = CodeArtRatio == 1f;
		}
		else
		{
			HasFinishedCode = (HasFinishedArt = (HasFinished = true));
		}
		TargetFramework = target;
		FixBugs = false;
		RegisterServer();
	}

	public void RegisterServer()
	{
		if (Server2 != null)
		{
			GameSettings.Instance.RegisterWithServer(Server2, this);
		}
	}

	public override string GetSubjectName()
	{
		if (!IsFramework)
		{
			SoftwareProduct target = Target;
			if (target == null)
			{
				return null;
			}
			return target.Name;
		}
		SoftwareFramework targetFramework = TargetFramework;
		if (targetFramework == null)
		{
			return null;
		}
		return targetFramework.Name;
	}

	public string GetVersion()
	{
		if (!IsFramework)
		{
			return Target.VMajor + "." + ((Features.Length != 0) ? (Target.VMinor + 1 + ".0") : (Target.VMinor + "." + (Target.VRev + 1)));
		}
		return (TargetFramework.Updated + 2).ToString();
	}

	public override string GetWorkTypeName()
	{
		return "Update";
	}

	public override string GetWorkTypeFilter()
	{
		return "Development";
	}

	public override float StressMultiplier()
	{
		return 1f;
	}

	public override HasWorkReturn HasWork(Actor actor, bool secondary, bool actualCheck)
	{
		if (GetNetworkDealState() == NetworkDealState.Sender)
		{
			return HasWorkReturn.Ignore;
		}
		if (AutoDev && !Enabled)
		{
			if (actualCheck)
			{
				RemoveWorking(actor.employee);
			}
			return HasWorkReturn.Ignore;
		}
		HasWorkReturn a = actor.employee.IsRoleSecondary(Employee.RoleBit.Artist, secondary);
		HasWorkReturn hasWorkReturn = actor.employee.IsRoleSecondary(Employee.RoleBit.Programmer, secondary);
		if (WorkItem.CombineWorkResult(a, hasWorkReturn) == HasWorkReturn.NotApplicable)
		{
			if (actualCheck)
			{
				RemoveWorking(actor.employee);
			}
			return HasWorkReturn.NotApplicable;
		}
		HasWorkReturn hasWorkReturn2 = HasWorkReturn.Finished;
		if (!HasFinishedArt || !HasFinishedCode)
		{
			hasWorkReturn2 = CheckAdequateSpecLevel(actor, secondary, false, actualCheck);
			if (actualCheck)
			{
				if (hasWorkReturn2 == HasWorkReturn.True || hasWorkReturn2 == HasWorkReturn.Secondary)
				{
					if (actor.isActiveAndEnabled)
					{
						AssignTaskIfNone(actor, secondary, false, false);
					}
				}
				else
				{
					RemoveWorking(actor.employee);
				}
			}
		}
		else if (actualCheck)
		{
			RemoveWorking(actor.employee);
		}
		if (actualCheck && DoBugs() && (hasWorkReturn == HasWorkReturn.True || hasWorkReturn == HasWorkReturn.Secondary))
		{
			return hasWorkReturn;
		}
		return hasWorkReturn2;
	}

	public override void DoWork(Actor actor, float effectiveness, float delta, bool secondary)
	{
		LastWorked.Add(actor.DID);
		if (actor.GetTeam() == null || float.IsNaN(effectiveness) || float.IsInfinity(effectiveness) || effectiveness < 0f)
		{
			return;
		}
		if (WorkDevTime < 0f)
		{
			RefreshWorkDevTime();
		}
		effectiveness *= DifficultyValues.Difficulty.AlphaSpeedBonus * actor.LeaderEffectivenessFactor(2);
		effectiveness *= 1f + _sourceControlBoost * 0.1f;
		bool flag = DoBugs() && actor.employee.IsRole(Employee.RoleBit.Programmer, secondary);
		int num = 0;
		if (!HasFinished)
		{
			float num2 = effectiveness * SoftwareType.GetEmployeeCountEffect(Mathf.Max(1, NewWorking.Count), WorkDevTime, false);
			float num3 = 1f;
			float num4 = 1f;
			if (flag)
			{
				num3 *= 2f / 3f;
				num4 *= 2f / 3f;
			}
			float num5 = actor.employee.GetSkill(Employee.EmployeeRole.Programmer);
			float num6 = actor.employee.GetSkill(Employee.EmployeeRole.Artist);
			if (actor.employee.HasTrait(Employee.Trait.FirmwareInc))
			{
				num5 = HWSkillFactor(num5, actor);
				num6 = HWSkillFactor(num6, actor);
			}
			if (actor.employee.IsRole(Employee.RoleBit.Artist, secondary) && actor.employee.IsRole(Employee.RoleBit.Programmer, secondary) && CodeArtRatio > 0f && CodeArtRatio < 1f && !HasFinishedArt && !HasFinishedCode)
			{
				float num7 = num5 + num6;
				if (num7 > 0f)
				{
					num3 = num5 / num7;
					num4 = num6 / num7;
				}
			}
			float num8 = Utilities.PerHour(1f - SoftwareType.DesignRatio, delta);
			num8 /= (float)GameSettings.DaysPerMonth;
			FeatureProgress featureProgress = FindJob(actor, secondary, false, true);
			for (int i = 0; i < 2; i++)
			{
				bool flag2 = i == 0;
				if (flag2 && (CodeArtRatio == 0f || HasFinishedCode))
				{
					HasFinishedCode = true;
					continue;
				}
				if (!flag2 && (CodeArtRatio == 1f || HasFinishedArt))
				{
					HasFinishedArt = true;
					continue;
				}
				num++;
				Employee.EmployeeRole role = (flag2 ? Employee.EmployeeRole.Programmer : Employee.EmployeeRole.Artist);
				if (actor.employee.IsRole(role, secondary))
				{
					float num9 = (flag2 ? num5 : num6);
					RecordSkill(role, num9, delta);
					float num10 = (flag2 ? num3 : num4);
					num10 *= actor.GetPCAddonBonus(role);
					float num11 = num9.MapRange(0f, 0.1f, 0.5f, 1f, true);
					float num12 = num2 * num8 * num11 * num10;
					double added = 0.0;
					if (featureProgress == null)
					{
						if (WorkAllFeatures(actor, num12, 1f, role, out added, true, num9.WeightOne(0.25f)))
						{
							RefreshWorkDevTime();
						}
					}
					else if (featureProgress.Valid(flag2))
					{
						bool change;
						double actuallyAdded;
						added = featureProgress.AddProgress(num12, role, actor.employee.GetSpecialization(role, featureProgress.Feature.Spec) == 3, out change, out actuallyAdded, 1.0, false);
						if (change)
						{
							RefreshWorkDevTime();
						}
					}
					if (!IsFramework && flag2 && added > 0.0)
					{
						AddedBugs += (float)(added * (double)MaxBugs * (double)num9.MapRange(0f, 1f, 1f, 0.25f) * (double)(1f - _sourceControlBoost * 0.5f) * Target.CodeQuality.MapRange(0.0, 1.0, 0.5, 0.10000000149011612, true) * 0.05000000074505806);
					}
				}
				if (!flag2 && !HasFinishedArt && AllDone(false, true, false))
				{
					HasFinishedArt = true;
				}
				if (flag2 && !HasFinishedCode && AllDone(false, false))
				{
					HasFinishedCode = true;
				}
			}
			if (!HasFinished && HasFinishedArt && HasFinishedCode)
			{
				HasFinished = true;
			}
		}
		if (flag)
		{
			_workerManager.UpdateWorker(actor.DID, SDateTime.Now());
			effectiveness *= 1f / (float)(num + 1) * SoftwareType.GetEmployeeCountEffect(Mathf.Max(1, _workerManager.Count), Target.DevTime, false) * 8f;
			int fixableBugs = Target.FixableBugs;
			if (fixableBugs > 0)
			{
				float fixedBugs = FixedBugs;
				FixedBugs = Mathf.Clamp(FixedBugs + Utilities.PerHour(effectiveness * actor.GetPCAddonBonus(Employee.EmployeeRole.Programmer), delta) * (4f / (float)GameSettings.DaysPerMonth) * SoftwareAlpha.GetBugSpeedDamp(Mathf.Clamp01(((float)(Target.StartBugss - Target.Bugss) + FixedBugs) / (float)Target.StartBugss)), 0f, fixableBugs);
				TotalNetworkUnits += FixedBugs - fixedBugs;
			}
		}
	}

	public bool DoBugs()
	{
		if (FixBugs)
		{
			return FixedBugs < (float)Target.FixableBugs;
		}
		return false;
	}

	public override Employee.EmployeeRole? GetBoostRole(Actor act, bool secondary)
	{
		bool flag = act.employee.IsRole(Employee.RoleBit.Artist, secondary) && !HasFinishedArt;
		bool flag2 = act.employee.IsRole(Employee.RoleBit.Programmer, secondary) && (!HasFinishedCode || DoBugs());
		if (flag && flag2)
		{
			if (!HasFinishedArt || !HasFinishedCode)
			{
				if (CodeArtRatio == 0f)
				{
					return Employee.EmployeeRole.Artist;
				}
				if (CodeArtRatio == 1f)
				{
					return Employee.EmployeeRole.Programmer;
				}
				return (Utilities.RandomValue > 0.5f) ? Employee.EmployeeRole.Programmer : Employee.EmployeeRole.Artist;
			}
			return Employee.EmployeeRole.Programmer;
		}
		if (flag)
		{
			return Employee.EmployeeRole.Artist;
		}
		if (flag2)
		{
			return Employee.EmployeeRole.Programmer;
		}
		return null;
	}

	public void Finish()
	{
		if (!HasFinished && !AutoDev)
		{
			WindowManager.Instance.ShowMessageBox("UpdateIncompleteWarning".Loc(), true, DialogWindow.DialogType.Warning, ActualFinish);
		}
		else
		{
			ActualFinish();
		}
	}

	private void ActualFinish()
	{
		if (IsFramework)
		{
			if (HasFinished)
			{
				TargetFramework.Update((HasFinished && Features.Length != 0) ? TechLevels : null, SDateTime.Now());
			}
		}
		else
		{
			Target.Update(Mathf.Min(Target.FixableBugs, Mathf.FloorToInt(FixedBugs)), Mathf.RoundToInt(AddedBugs), (HasFinished && Features.Length != 0) ? TechLevels : null, SDateTime.Now());
		}
		Kill();
	}

	public override Actor.WorkParticle EmitType(Actor actor, bool secondary)
	{
		if (HasFinishedArt && HasFinishedCode)
		{
			return Actor.WorkParticle.Binary;
		}
		FeatureProgress value;
		if (NewWorking.TryGetValue(actor.employee, out value) && value != null)
		{
			bool flag = value.ADevTime > 0.0 && !value.ArtDone && actor.employee.IsRole(Employee.RoleBit.Artist, secondary);
			bool flag2 = value.CDevTime > 0.0 && !value.CodeDone && actor.employee.IsRole(Employee.RoleBit.Programmer, secondary);
			if (flag && flag2)
			{
				if (UnityEngine.Random.Range(0, 2) != 0)
				{
					return Actor.WorkParticle.Binary;
				}
				return Actor.WorkParticle.Shapes;
			}
			if (!flag)
			{
				return Actor.WorkParticle.Binary;
			}
			return Actor.WorkParticle.Shapes;
		}
		bool flag3 = CodeArtRatio < 1f && !HasFinishedArt && actor.employee.IsRole(Employee.RoleBit.Artist, secondary);
		bool flag4 = CodeArtRatio > 0f && !HasFinishedCode && actor.employee.IsRole(Employee.RoleBit.Programmer, secondary);
		if (flag3 && flag4)
		{
			if (UnityEngine.Random.Range(0, 2) != 0)
			{
				return Actor.WorkParticle.Binary;
			}
			return Actor.WorkParticle.Shapes;
		}
		if (!flag3)
		{
			return Actor.WorkParticle.Binary;
		}
		return Actor.WorkParticle.Shapes;
	}

	public override IEnumerable<KeyValuePair<string, Action>> GetButtons()
	{
		NetworkDealState state = GetNetworkDealState();
		if (state == NetworkDealState.Sender)
		{
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
			Assign("Update", base.CheckCompetency);
		});
		if (state == NetworkDealState.Receiver)
		{
			yield return new KeyValuePair<string, Action>("CancelDeal", base.NetworkComplete);
			yield break;
		}
		yield return new KeyValuePair<string, Action>("Finish", Finish);
		yield return new KeyValuePair<string, Action>("Cancel", delegate
		{
			WindowManager.Instance.ShowMessageBox("WorkItemCancelConf".LocColor(this), true, DialogWindow.DialogType.Warning, delegate
			{
				Kill(true);
			}, "Cancel work");
		});
	}

	public override void GetNeeds(Dictionary<HRManagement.EdNeed, int>[] needs)
	{
		GetNeeds(needs, false);
	}

	public override string GetTypeName()
	{
		return "SoftwareUpdate";
	}

	public override string GetGroupType()
	{
		return "Update";
	}

	protected override IEnumerable<Employee.EmployeeRole> CompCheck()
	{
		if (!HasFinished)
		{
			yield return Employee.EmployeeRole.Programmer;
			yield return Employee.EmployeeRole.Artist;
		}
	}

	public bool CancelOnUnload()
	{
		return true;
	}

	public float GetLoadRequirement()
	{
		float num = 0f;
		List<Team> devTeams = GetDevTeams();
		for (int i = 0; i < devTeams.Count; i++)
		{
			num += (float)devTeams[i].Count * (DevTime / 24f + (DoBugs() ? 0.1f : 0f));
		}
		return num;
	}

	public void HandleLoad(float load)
	{
		_sourceControlBoost = load;
	}

	public void SerializeServer(string name)
	{
		if (name == null)
		{
			_sourceControlBoost = 0f;
		}
		Server2 = name;
	}

	public override string HightlightButton()
	{
		if (HasFinished && (!FixBugs || Target.FixableBugs == 0 || FixedBugs >= (float)Target.FixableBugs))
		{
			return "Finish";
		}
		return base.HightlightButton();
	}

	public override float GetProgress()
	{
		if (Features.Length != 0 && !HasFinished)
		{
			return (float)GetSpProgress(true, false);
		}
		if (FixBugs && Target.FixableBugs > 0)
		{
			return Mathf.Clamp01(FixedBugs / (float)Target.FixableBugs);
		}
		return 1f;
	}

	public override string Category()
	{
		return "Version".Loc() + " " + GetVersion();
	}

	public override string CurrentStage()
	{
		return CurrentStageSub((float)((Features.Length != 0) ? GetSpProgress(true, false) : (-1.0)), FixBugs ? Mathf.FloorToInt(FixedBugs) : (-1), (!IsFramework) ? Target.FixableBugs : 0);
	}

	private string CurrentStageSub(float prog, int bugs, int max)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (prog >= 0f)
		{
			stringBuilder.AppendLine("Update".Loc() + ": " + Mathf.Floor(prog * 100f) + "%");
		}
		if (bugs >= 0)
		{
			stringBuilder.AppendLine("BugsFixed2".Loc() + ": " + Mathf.Min(max, Mathf.FloorToInt(bugs)) + "/" + max);
		}
		return stringBuilder.ToString().TrimEnd();
	}

	public override byte[] SerializeProgressData()
	{
		using (MemoryStream memoryStream = new MemoryStream())
		{
			memoryStream.WriteFloat((float)((Features.Length != 0) ? GetSpProgress(true, false) : (-1.0)));
			memoryStream.WriteInt(FixBugs ? Mathf.Min(Target.FixableBugs, Mathf.FloorToInt(FixedBugs)) : (-1));
			memoryStream.WriteInt((!IsFramework) ? Target.FixableBugs : 0);
			return memoryStream.ToArray();
		}
	}

	public override void DeserializeProgressData(byte[] data)
	{
		using (MemoryStream stream = new MemoryStream(data))
		{
			NetworkStage = CurrentStageSub(stream.ReadFloat(), stream.ReadInt(), stream.ReadInt());
			NetworkCategory = Category();
			NetworkProgressLabel = GetProgressLabel();
		}
	}

	public override string GetIcon()
	{
		return "Software";
	}

	public override void Kill(bool wasCancelled = false)
	{
		GameSettings.Instance.DeregisterServerItem(this);
		base.Kill(wasCancelled);
	}

	public override void AddLoss(float cost, SoftwareProduct.LossType type, bool immediate, bool fromNetwork = false)
	{
		SoftwareProduct target = Target;
		if (target != null)
		{
			target.AddLoss(cost, type, immediate, fromNetwork);
		}
	}

	public override void AddLicenseCost(SoftwareProduct tool, float cost, bool fromNetwork = false)
	{
		SoftwareProduct target = Target;
		if (target != null)
		{
			target.AddLicenseCost(tool, cost, fromNetwork);
		}
	}

	public new string GetDescription()
	{
		return "UpdateForProduct".Loc(IsFramework ? TargetFramework.Name : Target.Name);
	}

	public override string CollapseLabel()
	{
		if (Features.Length != 0)
		{
			double spProgress = GetSpProgress(true, false);
			if (spProgress < 1.0)
			{
				return CurrentStageSub((float)spProgress, -1, -1);
			}
		}
		return CurrentStageSub(-1f, FixBugs ? Mathf.FloorToInt(FixedBugs) : (-1), (!IsFramework) ? Target.FixableBugs : 0);
	}

	public override string GetActualString()
	{
		return "UpdatingProduct".Loc(base.GetActualString());
	}

	public override void OnNetworkComplete(Stream st)
	{
		AddedBugs = st.ReadFloat();
		FixedBugs = st.ReadFloat();
		LoadProgressData(st);
	}

	public void LoadProgressData(Stream st)
	{
		st.ExecuteArray(delegate(Stream s)
		{
			uint id = s.ReadUInt();
			double progress = s.ReadDouble();
			double artProgress = s.ReadDouble();
			FeatureProgress featureProgress = Features.FirstOrDefault((FeatureProgress x) => x.Feature.ID == id);
			if (featureProgress != null)
			{
				featureProgress.Progress = progress;
				featureProgress.ArtProgress = artProgress;
				featureProgress.UpdateStatus(false);
			}
		});
		if (!HasFinishedArt && AllDone(false, true, false))
		{
			HasFinishedArt = true;
		}
		if (!HasFinishedCode && AllDone(false, false))
		{
			HasFinishedCode = true;
		}
		if (!HasFinished && HasFinishedArt && HasFinishedCode)
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
				memoryStream.WriteFloat(AddedBugs);
				memoryStream.WriteFloat(FixedBugs);
				memoryStream.WriteArray(Features, delegate(Stream s, FeatureProgress x)
				{
					s.WriteUInt(x.Feature.ID);
					s.WriteDouble(x.Progress);
					s.WriteDouble(x.ArtProgress);
				});
				return memoryStream.ToArray();
			}
		}
		return null;
	}

	public override List<KeyValuePair<string, string>> GetInfo()
	{
		List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>
		{
			new KeyValuePair<string, string>("Product".Loc(), IsFramework ? TargetFramework.Name : Target.Name),
			new KeyValuePair<string, string>("Type".Loc(), (IsFramework ? TargetFramework.Category : Target.Category).GetActualString()),
			new KeyValuePair<string, string>("Release".Loc(), (IsFramework ? TargetFramework.Release : Target.Release).ToCompactString()),
			new KeyValuePair<string, string>("Bugs".Loc(), Mathf.Max(0f, IsFramework ? 0f : ((float)Target.FixableBugs - FixedBugs + AddedBugs)).ToString("F0"))
		};
		if (TechLevels != null)
		{
			foreach (KeyValuePair<string, TechLevel> techLevel in TechLevels)
			{
				list.Add(new KeyValuePair<string, string>(techLevel.Value.GetActualString(), (IsFramework ? TargetFramework.TechLevels[techLevel.Key] : Target.TechLevels[techLevel.Key]).ActualYear + " -> " + techLevel.Value.ActualYear));
			}
		}
		return list;
	}

	public override string GetSoftwareWorkType()
	{
		return "Update";
	}

	public override void WriteSubData(Stream st)
	{
		st.WriteBool(IsFramework);
		if (IsFramework)
		{
			st.WriteUInt(TargetFramework.ID);
		}
		else
		{
			st.WriteUInt(Target.ID);
			st.WriteInt(Target.VerifiedBugs);
			st.WriteBool(FixBugs);
			st.WriteFloat(AddedBugs);
			st.WriteFloat(FixedBugs);
		}
		st.WriteArray(TechLevels, delegate(Stream s, KeyValuePair<string, TechLevel> x)
		{
			st.WriteStringUTF8(x.Key);
			st.WriteInt(x.Value.Year);
		});
		if (!IsFramework)
		{
			st.WriteArray(Needs, delegate(Stream s, KeyValuePair<string, SoftwareProduct> x)
			{
				st.WriteStringUTF8(x.Key);
				st.WriteUInt(x.Value.ID);
			});
		}
		st.WriteArray(Features, delegate(Stream s, FeatureProgress x)
		{
			s.WriteUInt(x.Feature.ID);
			s.WriteDouble(x.Progress);
			s.WriteDouble(x.ArtProgress);
		});
	}

	public override bool IsDoneForNetworkDeal()
	{
		if (HasFinished)
		{
			if (FixBugs && Target.FixableBugs != 0)
			{
				return FixedBugs >= (float)Target.FixableBugs;
			}
			return true;
		}
		return false;
	}

	public override IRoyaltyItem GetRoyaltyItem()
	{
		if (!IsFramework)
		{
			return Target;
		}
		return null;
	}
}
