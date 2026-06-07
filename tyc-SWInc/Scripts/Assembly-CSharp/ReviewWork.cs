using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ReviewWork : WorkItem
{
	public const float Speed = 2400f;

	public Dictionary<string, float> ArtResult;

	public Dictionary<string, float> CodeResult;

	public Dictionary<string, float> ArtProg;

	public Dictionary<string, float> CodeProg;

	public int Reviewers;

	public string ReviewCompany;

	public string ProjectName;

	public int Reviews;

	public int OptimalReviews;

	public static float StandardCost = 100f;

	public float CostPerReview;

	public float Next;

	public SDateTime BuildDate;

	public SHashSet<uint> Biased = new SHashSet<uint>();

	public SoftwareAlpha TargetWork;

	public override Color BackColor
	{
		get
		{
			return new Color(1f, 0.349f, 0.945f);
		}
	}

	public override string GetWorkTypeName()
	{
		return "Peer review";
	}

	public override float StressMultiplier()
	{
		return 0.5f;
	}

	public ReviewWork()
	{
	}

	public ReviewWork(string name)
	{
		base.Name = name;
	}

	public ReviewWork(SoftwareAlpha alpha, string company, bool free, int reviewers, HashSet<KeyValuePair<string, string>> specs)
		: base(alpha.SoftwareName, null, 0u, null, alpha.guiItem.transform.GetSiblingIndex() + 1)
	{
		Init(alpha, reviewers, specs);
		ReviewCompany = company;
		GameSettings.Instance.ReviewJobs.Add(this);
		CostPerReview = (free ? 0f : StandardCost);
		RunScripts(alpha.Features, false, false, (SoftwareWorkItem.FeatureProgress x) => x.Feature);
	}

	public ReviewWork(SoftwareAlpha alpha, SimulatedCompany c, int reviewers, HashSet<KeyValuePair<string, string>> specs)
		: base(alpha.SoftwareName, null, 0u, null, alpha.guiItem.transform.GetSiblingIndex() + 1)
	{
		Init(alpha, reviewers, specs);
		ReviewCompany = null;
		base.CompanyWorker = c;
		GameSettings.Instance.ReviewJobs.Add(this);
		CostPerReview = 0f;
		RunScripts(alpha.Features, false, false, (SoftwareWorkItem.FeatureProgress x) => x.Feature);
	}

	private void Init(SoftwareAlpha alpha, int reviewers, HashSet<KeyValuePair<string, string>> specs)
	{
		BuildDate = SDateTime.Now();
		TargetWork = alpha;
		Biased.AddRange(alpha.EverWorked);
		ProjectName = alpha.SoftwareName;
		Reviewers = reviewers;
		OptimalReviews = GetOptimalReviews(alpha, specs);
		base.Name = "ReviewOf".Loc(ProjectName);
		ArtResult = new Dictionary<string, float>();
		CodeResult = new Dictionary<string, float>();
		ArtProg = new Dictionary<string, float>();
		CodeProg = new Dictionary<string, float>();
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		Dictionary<string, float> dictionary2 = new Dictionary<string, float>();
		SoftwareWorkItem.FeatureProgress[] features = alpha.Features;
		foreach (SoftwareWorkItem.FeatureProgress featureProgress in features)
		{
			if (!featureProgress.OS)
			{
				if (featureProgress.Feature.CodeArtRatio > 0f && specs.Contains(new KeyValuePair<string, string>("Code", featureProgress.Feature.Spec)))
				{
					CodeResult.AddUp(featureProgress.Feature.Spec, (float)(featureProgress.Qual * featureProgress.CDevTime));
					dictionary2.AddUp(featureProgress.Feature.Spec, (float)featureProgress.CDevTime);
					CodeProg.AddUp(featureProgress.Feature.Spec, (float)featureProgress.Progress);
				}
				if (featureProgress.Feature.CodeArtRatio < 1f && specs.Contains(new KeyValuePair<string, string>("Art", featureProgress.Feature.Spec)))
				{
					ArtResult.AddUp(featureProgress.Feature.Spec, (float)(featureProgress.Qual2 * featureProgress.ADevTime));
					dictionary.AddUp(featureProgress.Feature.Spec, (float)featureProgress.ADevTime);
					ArtProg.AddUp(featureProgress.Feature.Spec, (float)featureProgress.ArtProgress);
				}
			}
		}
		foreach (KeyValuePair<string, float> item in dictionary2)
		{
			CodeResult[item.Key] /= item.Value;
			CodeProg[item.Key] /= item.Value;
		}
		foreach (KeyValuePair<string, float> item2 in dictionary)
		{
			ArtResult[item2.Key] /= item2.Value;
			ArtProg[item2.Key] /= item2.Value;
		}
	}

	public static int GetOptimalReviews(SoftwareAlpha alpha, HashSet<KeyValuePair<string, string>> specs)
	{
		return Mathf.Max(10, Mathf.CeilToInt(50f * Mathf.Clamp01(alpha.Features.Sum((SoftwareWorkItem.FeatureProgress x) => x.ValidReviewDevTime(specs)) / 12f)));
	}

	public static int GetReviewsPerReviewer(SoftwareAlpha alpha, HashSet<KeyValuePair<string, string>> specs)
	{
		HashSet<KeyValuePair<string, string>> hashSet = new HashSet<KeyValuePair<string, string>>();
		for (int i = 0; i < alpha.Features.Length; i++)
		{
			SoftwareWorkItem.FeatureProgress featureProgress = alpha.Features[i];
			if (featureProgress.OS)
			{
				continue;
			}
			if (featureProgress.Feature.CodeArtRatio > 0f)
			{
				KeyValuePair<string, string> item = new KeyValuePair<string, string>("Code", featureProgress.Feature.Spec);
				if (specs == null || specs.Contains(item))
				{
					hashSet.Add(item);
				}
			}
			if (featureProgress.Feature.CodeArtRatio < 1f)
			{
				KeyValuePair<string, string> item2 = new KeyValuePair<string, string>("Art", featureProgress.Feature.Spec);
				if (specs == null || specs.Contains(item2))
				{
					hashSet.Add(item2);
				}
			}
		}
		return hashSet.Count;
	}

	public override string GetIcon()
	{
		return "Smiley";
	}

	public void Tick(float delta)
	{
		if (!Paused && Reviews < GetMaxReviews())
		{
			Next += Utilities.PerDay(2400f, delta, false);
			while (Next > 1f && Reviews < GetMaxReviews())
			{
				Reviews++;
				Next -= 1f;
			}
			if (Reviews == GetMaxReviews())
			{
				guiItem.InitButtons();
			}
		}
	}

	public override HasWorkReturn HasWork(Actor actor, bool secondary, bool actualCheck)
	{
		return HasWorkReturn.Ignore;
	}

	public override void DoWork(Actor act, float eff, float delta, bool secondary)
	{
	}

	public override float GetWorkBoost(Employee.EmployeeRole role, float currentSkill)
	{
		return 0f;
	}

	public override Employee.EmployeeRole? GetBoostRole(Actor act, bool secondary)
	{
		return null;
	}

	public override string Category()
	{
		if (CostPerReview > 0f)
		{
			return "Cost".Loc() + ": " + ((float)Reviews * CostPerReview).Currency();
		}
		return null;
	}

	public override string CurrentStage()
	{
		return "ReviewsWritten".Loc(Reviews);
	}

	public override float GetProgress()
	{
		return (float)Reviews / (float)GetMaxReviews();
	}

	public void EndReview()
	{
		if (Reviews >= ArtResult.Count + CodeResult.Count)
		{
			Dictionary<string, Dictionary<string, float>> dictionary = new Dictionary<string, Dictionary<string, float>>
			{
				{
					"Art",
					new Dictionary<string, float>()
				},
				{
					"Code",
					new Dictionary<string, float>()
				}
			};
			float num = 0f;
			int num2 = 0;
			int num3 = ArtResult.Count + CodeResult.Count;
			int num4 = OptimalReviews * num3;
			float num5 = Reviews.MapRange(num3, num4, 0f, 1f, true);
			foreach (KeyValuePair<string, float> item in ArtResult)
			{
				float num6 = Utilities.RandomGaussClamped(item.Value, (1f - num5) * 0.2f);
				dictionary["Art"][item.Key] = num6;
				num += num6;
				num2++;
			}
			foreach (KeyValuePair<string, float> item2 in CodeResult)
			{
				float num7 = Utilities.RandomGaussClamped(item2.Value, (1f - num5) * 0.2f);
				dictionary["Code"][item2.Key] = num7;
				num += num7;
				num2++;
			}
			float? creativity = null;
			if (TargetWork.ActiveDeal == null && TargetWork.contract == null)
			{
				creativity = Utilities.RandomGaussClamped((float)TargetWork.CreativityScore, (1f - num5) * 0.2f);
			}
			ReviewWindow.ReviewData reviewData = new ReviewWindow.ReviewData(dictionary, (CodeProg != null) ? new Dictionary<string, Dictionary<string, float>>
			{
				{ "Art", ArtProg },
				{ "Code", CodeProg }
			} : null, BuildDate, num / (float)num2, creativity, num5);
			SoftwareAlpha targetWork = TargetWork;
			if (targetWork != null)
			{
				double num8 = 0.0;
				double num9 = 0.0;
				SoftwareWorkItem.FeatureProgress[] features = targetWork.Features;
				foreach (SoftwareWorkItem.FeatureProgress featureProgress in features)
				{
					num9 += featureProgress.CDevTime;
					if (CodeResult.ContainsKey(featureProgress.Feature.Spec))
					{
						num8 += featureProgress.CDevTime;
					}
				}
				targetWork.PastReviews.Add(reviewData);
				if (num8 > 0.0 && num9 > 0.0)
				{
					targetWork.AddReviewScore((float)((double)num5 * (num8 / num9)));
				}
			}
			targetWork.DidLastReviewIteration = false;
			HUD.Instance.reviewWindow.Show(reviewData, targetWork);
		}
		GameSettings.Instance.ReviewJobs.Remove(this);
		Kill();
	}

	public int GetMaxReviews()
	{
		return (ArtResult.Count + CodeResult.Count) * Reviewers;
	}

	public override string GetTeam(Text label = null)
	{
		return ReviewCompany ?? base.GetTeam(label);
	}

	public override string HightlightButton()
	{
		if (Reviews != GetMaxReviews())
		{
			return null;
		}
		return "Finish";
	}

	public override Actor.WorkParticle EmitType(Actor actor, bool secondary)
	{
		return Actor.WorkParticle.Letters;
	}

	public override string GetSubjectName()
	{
		SoftwareAlpha targetWork = TargetWork;
		if (targetWork == null)
		{
			return "NotApplicableAbbr".Loc();
		}
		return targetWork.SoftwareName;
	}

	public override void AddLoss(float cost, bool fromNetwork = false)
	{
		TargetWork.AddLoss(cost, fromNetwork);
	}

	public override bool CanUseCompany()
	{
		return true;
	}

	public override float CompanyWork(float delta)
	{
		if (Reviews < GetMaxReviews())
		{
			Next += Utilities.PerDay(2400f, delta, false);
			while (Next > 1f && Reviews < GetMaxReviews())
			{
				Reviews++;
				Next -= 1f;
			}
			if (Reviews == GetMaxReviews())
			{
				guiItem.InitButtons();
			}
			return Utilities.PerDay(base.CompanyWorker.BusinessSavy.MapRange(0f, 1f, 2f, 1f) * (float)Reviewers * Employee.AverageWage * Employee.GetRoleSalary(Employee.EmployeeRole.Service), delta, false);
		}
		return 0f;
	}

	public override IEnumerable<KeyValuePair<string, Action>> GetButtons()
	{
		yield return new KeyValuePair<string, Action>((Reviews == GetMaxReviews()) ? "Finish" : "End", EndReview);
	}

	public override void GetNeeds(Dictionary<HRManagement.EdNeed, int>[] needs)
	{
	}

	public override string GetTypeName()
	{
		return "ReviewWork";
	}

	public override string GetGroupType()
	{
		return "Review";
	}

	public override string GetGroupProject()
	{
		return TargetWork.SoftwareName;
	}

	public override bool HasCompanyWork()
	{
		return Reviews < GetMaxReviews();
	}

	public override void Kill(bool wasCancelled = false)
	{
		float num = CostPerReview * (float)Reviews;
		if (num > 0f)
		{
			GameSettings.Instance.MyCompany.MakeTransaction(0f - num, Company.TransactionCategory.Bills, true, "Reviews");
			AddLoss(num);
		}
		RunScripts(TargetWork.Features, true, wasCancelled, (SoftwareWorkItem.FeatureProgress x) => x.Feature);
		base.Kill(wasCancelled);
	}
}
