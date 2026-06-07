using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatementParser;
using Tyd;
using UnityEngine;

public static class ArticleGenerator
{
	public class Sentence<T> where T : LineParse.ScriptWorld
	{
		public int Priority;

		public string Group;

		public string AppendTo;

		public LineParse.TreeNode Check;

		public LineParse.TreeNode Extractor;

		public LineParse.TreeNode Evaluator;

		public string LocKey;

		public string[] Sentences;

		public int EvalRange;

		public string Execute(T input)
		{
			int num = ((Evaluator == null) ? Utilities.RandomRange(0, Sentences.Length) : (((float)Execute<double>(Evaluator, input)).Quantize(Sentences.Length / EvalRange) * EvalRange + Utilities.RandomRange(0, EvalRange)));
			string text = (LocKey + num).LocDef(Sentences[num]);
			object[] array = ((Extractor == null) ? null : Execute<object[]>(Extractor, input));
			if (array == null)
			{
				return text;
			}
			try
			{
				return Utilities.RobustStringFormat(text, false, false, array);
			}
			catch (Exception)
			{
				return text;
			}
		}

		public T1 Execute<T1>(LineParse.TreeNode node, T input)
		{
			return (T1)LineParse.Execute(node, input);
		}

		public Sentence(TydTable node)
		{
			Group = node.GetChildValue("Group");
			AppendTo = node.GetChildValue("AppendTo", false);
			Priority = node.GetChildValue("Priority", true, 0);
			Check = GetCode(node, "Check");
			Extractor = GetCode(node, "Extractor");
			Evaluator = GetCode(node, "Evaluator");
			EvalRange = node.GetChildValue("Range", false, 1);
			LocKey = node.GetChildValue("LocKey");
			Sentences = node.GetChild<TydList>("Values").GetChildValues().ToArray();
		}

		private LineParse.TreeNode GetCode(TydTable node, string key)
		{
			string childValue = node.GetChildValue(key, false);
			if (childValue == null)
			{
				return null;
			}
			return LineParse.Parse(childValue);
		}
	}

	[AllowScopeList(Allow = false)]
	public class SoftwareReviewData : ScriptSystem.DefaultScope
	{
		public string ProductName;

		public string LeadDesigner;

		public Company C;

		public float RealQuality;

		public float Expensive;

		public float Cheap;

		public float SellingPotential;

		public float Hype;

		public float BugScore = 1f;

		public float Ratio;

		public float ReachScore = 1f;

		public float FeatScore = 1f;

		public float Rep;

		public float FanBase;

		public float FinalScore;

		public float TechScore;

		public float SubScore;

		public float Progress;

		public float Sequel = 1f;

		public float Creativity = 1f;

		public float DigitalDistribution;

		public bool ToSubscrip;

		public string Comp;

		public bool Addon;

		public float Map(float x, float a, float b, float c, float d, bool clamp = true)
		{
			return x.MapRange(a, b, c, d, clamp);
		}

		public SoftwareReviewData()
		{
		}

		public float GetPlatformDigitalShare()
		{
			if (MarketSimulation.GetPhysicalVsDigital(SDateTime.Now()) < 0.75)
			{
				return (float)MarketSimulation.Active.EvalutateDistributionSums(GameSettings.Instance.MyCompany.GetPlatforms()) / (float)MarketSimulation.Population;
			}
			return 1f;
		}

		private static float GetTechScore(SoftwareCategory cat, FeatureBase[] f, Dictionary<string, TechLevel> t)
		{
			float num = f.SumSafe((FeatureBase x) => x.DevTime);
			Dictionary<string, float> dict = new Dictionary<string, float>();
			for (int num2 = 0; num2 < f.Length; num2++)
			{
				dict.AddUp(f[num2].Spec, f[num2].DevTime / num);
			}
			float num3 = 0f;
			foreach (KeyValuePair<string, TechLevel> item in t)
			{
				num3 += item.Value.GetRelevancy(cat) * dict.GetOrDefault(item.Key, 0f);
			}
			return num3;
		}

		public SoftwareReviewData(SoftwareProduct p)
		{
			ProductName = p.Name;
			C = p.DevCompany;
			Rep = Mathf.Sqrt(p.DevCompany.GetReputation(p.Category));
			if (p.Publishing != null)
			{
				float reputation = p.Publishing.Publisher.GetReputation(p.Category);
				if (reputation > Rep)
				{
					C = p.Publishing.Publisher;
					Rep = reputation;
				}
			}
			RealQuality = (float)p.RealQuality;
			Creativity = (float)p.CreativityScore;
			Sequel = (float)p.SequelBonus.MapRange(0.5, 0.949999988079071, 0.0, 1.0, true);
			FanBase = 1f - Mathf.Pow(1f - Mathf.Clamp01((float)C.Fans / 2000000f), 2f);
			LeadDesigner = ((p.LeadDesigner != null) ? p.LeadDesigner.FullName : "");
			SoftwareType type = p.Type;
			double num = (double)GameSettings.Instance.simulation.GetIdealMarketPrice(p.Category, p.SubscriptionBased) * p.PerceivedValue(SDateTime.Now());
			float num2 = (p.OpenSource ? 1f : MarketSimulation.PriceFact(p.Price, num));
			if (p.OpenSource)
			{
				Expensive = 1f;
				Cheap = 1f;
			}
			else if ((double)p.Price > num)
			{
				Expensive = num2;
				Cheap = 1f;
			}
			else
			{
				Expensive = 1f;
				Cheap = Mathf.Clamp01(num2);
			}
			SellingPotential = (float)(p.GetMarketWeightedQuality(p.GetQuality(SDateTime.Now())) * (double)num2 * (double)Rep);
			Hype = Mathf.Sqrt(Mathf.Clamp01((float)p.Followers / (float)SoftwareWorkItem.GetMaxFollowers(p.SWType, p.SWCat, p.DevCompany, null, null, null, p.GetOSs(), p.Publishing)));
			BugScore = Mathf.Pow(1f - Mathf.Clamp01((float)p.Bugss / (p.DevTime * SoftwareAlpha.BugLimitFactor)), 2f);
			Ratio = SoftwareType.CodeArtRatio(p.Features);
			TechScore = GetTechScore(p.Category, p.Features, p.TechLevels);
			Progress = (float)(p.CodeProgress * (double)Ratio + p.ArtProgress * (double)(1f - Ratio));
			Comp = null;
			double num3 = 0.0;
			foreach (SoftwareProduct allProduct in GameSettings.Instance.simulation.GetAllProducts(false))
			{
				if (allProduct != p && allProduct.Category.Equals(p.Category) && (!type.OSSpecific || p.OSOverlap(allProduct)))
				{
					double marketWeightedQuality = allProduct.GetMarketWeightedQuality(allProduct.GetQuality(SDateTime.Now()));
					if (marketWeightedQuality > num3)
					{
						num3 = marketWeightedQuality;
						Comp = allProduct.Name;
					}
				}
			}
			if (type.OSSpecific)
			{
				SoftwareProduct[] oSs = (from x in GameSettings.Instance.simulation.GetAllProducts(false)
					where "Operating System".Equals(x.Type.Name)
					orderby x.Userbase descending
					select x).Take(3).ToArray();
				ReachScore = Mathf.Clamp01((float)type.GetReach(p.Category, p.GetOSs()) / (float)type.GetReach(p.Category, oSs));
			}
			FeatScore = (float)Utilities.Clamp01(p.RelativeFeatureScore(GameSettings.Instance.simulation, SDateTime.Now()));
			SubScore = (float)p.Category.PerceivedMarketValue(p.Features, p.TechLevels, p.Submarkets, p.GetBigProjectFactor());
			SellingPotential *= ReachScore;
			SellingPotential = Mathf.Sqrt(SellingPotential);
			if (SellingPotential < 0.25f && p.Followers > 1000 && p.Followers > C.Fans)
			{
				SellingPotential = 0.5f;
			}
			FinalScore = (float)Utilities.Clamp01((double)FeatScore.WeightOne(0.75f) * p.RealQuality - (double)(BugScore * 0.5f));
			ToSubscrip = p.SubscriptionBased && p.SequelTo != null && p.GetEntireIP().All((SoftwareProduct x) => x == p || !x.SubscriptionBased);
			DigitalDistribution = (p.Category.Hardware ? 1f : GetPlatformDigitalShare());
		}

		public SoftwareReviewData(AddOnProduct a)
		{
			Addon = true;
			ProductName = a.Name;
			C = a.Owner;
			Rep = Mathf.Sqrt(a.Owner.GetReputation(a.SWCat));
			if (a.Forced && a.Parent.Publishing != null)
			{
				float reputation = a.Parent.Publishing.Publisher.GetReputation(a.SWCat);
				if (reputation > Rep)
				{
					C = a.Parent.Publishing.Publisher;
					Rep = reputation;
				}
			}
			RealQuality = (float)a.RealQuality;
			FanBase = 1f - Mathf.Pow(1f - Mathf.Clamp01((float)C.Fans / 2000000f), 2f);
			double num = a.PerceivedValue(SDateTime.Now());
			double num2 = (double)GameSettings.Instance.simulation.GetIdealMarketPrice(a.Type) * num;
			float num3 = ((a.Price < 0.1f) ? 1f : MarketSimulation.PriceFact(a.Price, num2));
			if (a.Price < 0.1f)
			{
				Expensive = 1f;
				Cheap = 1f;
			}
			else if ((double)a.Price > num2)
			{
				Expensive = num3;
				Cheap = 1f;
			}
			else
			{
				Expensive = 1f;
				Cheap = Mathf.Clamp01(num3);
			}
			SellingPotential = 1f;
			Hype = Mathf.Sqrt(Mathf.Clamp01((float)a.Followers / (float)SoftwareWorkItem.GetMaxFollowers(a.SWType, a.SWCat, a.Owner, a.Type, a.Parent, null, null, a.Forced ? a.Parent.Publishing : null)));
			Ratio = SoftwareType.CodeArtRatio(a.Features, a.FeatureFactors);
			TechScore = 1f;
			Progress = (float)(a.CodeProgress * (double)Ratio + a.ArtProgress * (double)(1f - Ratio));
			Comp = null;
			double num4 = 0.0;
			foreach (AddOnProduct item in a.Parent.Addons[a.Type])
			{
				if (item != a && item.Owner != a.Owner)
				{
					double marketWeightedQuality = item.GetMarketWeightedQuality(item.Quality);
					if (marketWeightedQuality > num4)
					{
						num4 = marketWeightedQuality;
						Comp = item.Name;
					}
				}
			}
			FeatScore = (float)Utilities.Clamp01(num);
			SubScore = (float)a.Type.PerceivedMarketValue(a.Features, a.FeatureFactors, a.SWCat, a.Parent.TechLevels, a.Parent.Submarkets);
			SellingPotential = Mathf.Sqrt(SellingPotential);
			if (SellingPotential < 0.25f && a.Followers > 1000 && a.Followers > C.Fans)
			{
				SellingPotential = 0.5f;
			}
			FinalScore = (float)Utilities.Clamp01((double)FeatScore.WeightOne(0.75f) * a.RealQuality - (double)(BugScore * 0.5f));
			DigitalDistribution = (a.Type.Hardware ? 1f : GetPlatformDigitalShare());
		}
	}

	[AllowScopeList(Allow = false)]
	public class PressBuildReviewData : ScriptSystem.DefaultScope
	{
		public string Company;

		public string Product;

		public float EstQual;

		public float FeatScore;

		public float PressBuildEffect;

		public float Followers;

		public float Rep;

		public int Months;

		public SDateTime? HasRelease;

		public PressBuildReviewData(string company, string product, float estQual, float featScore, float pressBuildEffect, float followers, float rep, int months, SDateTime? hasRelease)
		{
			Company = company;
			Product = product;
			EstQual = estQual;
			FeatScore = featScore;
			PressBuildEffect = pressBuildEffect;
			Followers = followers;
			Rep = rep;
			Months = months;
			HasRelease = hasRelease;
		}
	}

	[AllowScopeList(Allow = false)]
	public class PressReleaseData : ScriptSystem.DefaultScope
	{
		public string Company;

		public string Product;

		public int Phase;

		public SDateTime? ReleaseDate;

		public float Rep;

		public float FeatScore;

		public float PressQuality;

		public float PressOptions;

		public float PressEffect;

		public PressReleaseData(string company, string product, int phase, SDateTime? releaseDate, float rep, float featScore, float pressQuality, float pressOptions, float pressEffect)
		{
			Company = company;
			Product = product;
			Phase = phase;
			ReleaseDate = releaseDate;
			Rep = rep;
			FeatScore = featScore;
			PressQuality = pressQuality;
			PressEffect = pressEffect;
			PressOptions = pressOptions;
		}
	}

	public class SentenceTree<T> where T : LineParse.ScriptWorld
	{
		public Dictionary<string, Sentence<T>> Sentence = new Dictionary<string, Sentence<T>>();

		public Dictionary<string, List<string>> Tree = new Dictionary<string, List<string>>();

		public void AddSentence(string group, Sentence<T> sentence, string appendTo)
		{
			Sentence[group] = sentence;
			Tree[group] = new List<string>();
			if (appendTo != null)
			{
				Tree[appendTo].Add(group);
			}
		}

		public string Execute(T input)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Sentence<T> item in from x in Tree
				select Sentence[x.Key] into x
				where x.AppendTo == null
				orderby x.Priority
				select x)
			{
				stringBuilder.Append(item.Execute(input));
				ExecuteSub(item.Group, input, stringBuilder);
				if (stringBuilder[stringBuilder.Length - 1] != '!' && stringBuilder[stringBuilder.Length - 1] != '?')
				{
					stringBuilder.Append(".");
				}
				stringBuilder.Append(" ");
			}
			return stringBuilder.ToString();
		}

		private void ExecuteSub(string group, T input, StringBuilder result)
		{
			foreach (Sentence<T> item in from x in Tree[@group]
				select Sentence[x] into x
				orderby x.Priority
				select x)
			{
				result.Append(item.Execute(input));
				ExecuteSub(item.Group, input, result);
			}
		}
	}

	public static Dictionary<string, Sentence<SoftwareReviewData>[]> SoftwareReview;

	public static Dictionary<string, Sentence<PressBuildReviewData>[]> PressBuildReview;

	public static Dictionary<string, Sentence<PressReleaseData>[]> PressReleaseReview;

	static ArticleGenerator()
	{
		SoftwareReview = TydFile.FromContent(GameData.LoadFullTextAsset("ArticleGenerator/Software"), null).DocumentNode.Nodes.OfType<TydList>().ToDictionary((TydList x) => x.Name, (TydList x) => (from y in x.Nodes.OfType<TydTable>()
			select new Sentence<SoftwareReviewData>(y)).ToArray());
		PressBuildReview = TydFile.FromContent(GameData.LoadFullTextAsset("ArticleGenerator/PressBuild"), null).DocumentNode.Nodes.OfType<TydList>().ToDictionary((TydList x) => x.Name, (TydList x) => (from y in x.Nodes.OfType<TydTable>()
			select new Sentence<PressBuildReviewData>(y)).ToArray());
		PressReleaseReview = TydFile.FromContent(GameData.LoadFullTextAsset("ArticleGenerator/PressRelease"), null).DocumentNode.Nodes.OfType<TydList>().ToDictionary((TydList x) => x.Name, (TydList x) => (from y in x.Nodes.OfType<TydTable>()
			select new Sentence<PressReleaseData>(y)).ToArray());
	}

	public static string GenerateSoftwareReview(SoftwareProduct p)
	{
		return FinalReviewGenerator.ReviewToNews(FinalReviewGenerator.GenerateReview(new SoftwareReviewData(p)));
	}

	public static string GenerateSoftwareReview(AddOnProduct p)
	{
		return FinalReviewGenerator.ReviewToNews(FinalReviewGenerator.GenerateReview(new SoftwareReviewData(p)));
	}

	public static string GeneratePressBuildReview(PressBuildReviewData p)
	{
		return GenerateArticle(PressBuildReview, new string[2] { "Intro", "Body" }, p);
	}

	public static string GeneratePressReleaseReview(PressReleaseData p)
	{
		return GenerateArticle(PressReleaseReview, new string[2] { "Intro", "Body" }, p);
	}

	private static string GenerateArticle<T>(Dictionary<string, Sentence<T>[]> sentences, string[] order, T subject) where T : LineParse.ScriptWorld
	{
		Dictionary<string, StringBuilder> sections = new Dictionary<string, StringBuilder>();
		foreach (string key in order)
		{
			sections[key] = new StringBuilder();
		}
		foreach (KeyValuePair<string, Sentence<T>[]> sentence2 in sentences)
		{
			Dictionary<string, IGrouping<string, Sentence<T>>> dictionary = (from x in sentence2.Value
				where x.Check == null || x.Execute<bool>(x.Check, subject)
				group x by x.Group).ToDictionary((IGrouping<string, Sentence<T>> x) => x.Key, (IGrouping<string, Sentence<T>> x) => x);
			string random = (from x in dictionary
				where x.Value.Any((Sentence<T> z) => z.AppendTo == null)
				select x.Key).GetRandom();
			SentenceTree<T> tree = new SentenceTree<T>();
			if (random != null)
			{
				Sentence<T> sentence = (from x in dictionary[random]
					where x.AppendTo == null
					orderby x.Priority, Utilities.RandomValue
					select x).FirstOrDefault();
				dictionary.Remove(random);
				tree.AddSentence(random, sentence, null);
				random = (from x in dictionary
					where x.Value.Any((Sentence<T> z) => z.AppendTo == null || tree.Sentence.ContainsKey(z.AppendTo))
					select x.Key).GetRandom();
				if (random != null)
				{
					do
					{
						sentence = (from x in dictionary[random]
							where x.AppendTo == null || tree.Sentence.ContainsKey(x.AppendTo)
							orderby x.Priority, Utilities.RandomValue
							select x).FirstOrDefault();
						dictionary.Remove(random);
						tree.AddSentence(random, sentence, sentence.AppendTo);
						random = (from x in dictionary
							where x.Value.Any((Sentence<T> z) => z.AppendTo == null || tree.Sentence.ContainsKey(z.AppendTo))
							select x.Key).GetRandom();
					}
					while (random != null);
				}
			}
			string value = tree.Execute(subject);
			sections[sentence2.Key].Append(value);
		}
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		foreach (StringBuilder item in order.Select((string x) => sections[x]))
		{
			if (item.Length > 0)
			{
				if (!flag)
				{
					stringBuilder.AppendLine();
					stringBuilder.AppendLine();
				}
				stringBuilder.Append(item.ToString());
				flag = false;
			}
		}
		return stringBuilder.ToString();
	}
}
