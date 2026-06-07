using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using StatementParser;
using Tyd;
using UnityEngine;

public static class FinalReviewGenerator
{
	public class Reviewer
	{
		public string ID;

		public string Name;

		public Sprite Logo;

		public Dictionary<string, float[]> Weights;

		public string[] Statements;

		public Reviewer(TydTable node)
		{
			ID = node.GetChildValue("ID");
			Name = node.GetChildValue("Name");
			Logo = ObjectDatabase.Instance.GetReviewCompany(node.GetChildValue("Logo"));
			Weights = node.GetChild<TydTable>("Weights", true).Nodes.ToDictionary((TydNode x) => x.Name, GetWeights);
			Statements = node.GetChild<TydList>("Statements", true).GetNodeValues().ToArray();
		}

		private static float[] GetWeights(TydNode t)
		{
			TydString tydString = t as TydString;
			if (tydString != null)
			{
				return new float[2]
				{
					tydString.Value.ConvertToFloat("Review weight"),
					1f
				};
			}
			TydList tydList = t as TydList;
			if (tydList != null)
			{
				float[] array = (from x in tydList.GetNodeValues()
					select x.ConvertToFloat("Review weight")).ToArray();
				if (array.Length == 2)
				{
					return array;
				}
			}
			throw new Exception("Couldn't read review weights");
		}

		public float GetScore(Dictionary<string, float> data)
		{
			float num = 1f;
			float num2 = 0f;
			float num3 = 0f;
			foreach (KeyValuePair<string, float[]> weight in Weights)
			{
				float value;
				if (weight.Value[0] > 0f && data.TryGetValue(weight.Key, out value))
				{
					num3 += weight.Value[0] * value;
					num2 += weight.Value[0];
					num *= value.WeightOne(weight.Value[0]);
				}
			}
			return (num + num3 / num2) / 2f;
		}
	}

	public class Statement
	{
		public string ID;

		public int SubjectID;

		public LineParse.TreeNode Score;

		public LineParse.TreeNode Eval;

		public float InterestConstant;

		public LineParse.TreeNode Interest;

		public LineParse.TreeNode SwitchSelector;

		public Dictionary<float, string[]> Switch;

		public string[] Sentences;

		public Dictionary<string, string> Locs;

		public bool IgnoreScore;

		public Statement(TydTable node)
		{
			ID = node.GetChildValue("ID");
			SubjectID = node.GetChildValue("SubjectID", true, 0);
			TydString child = node.GetChild<TydString>("Eval");
			IgnoreScore = node.GetChildValue("IgnoreScore", false, false);
			if (child != null)
			{
				Eval = LineParse.Parse(child.Value);
			}
			Score = LineParse.Parse(node.GetChildValue("Score"));
			string childValue = node.GetChildValue("Interest");
			if (!childValue.ConvertToFloatTry(out InterestConstant))
			{
				Interest = LineParse.Parse(childValue);
			}
			TydTable child2 = node.GetChild<TydTable>("Switch");
			if (child2 != null)
			{
				SwitchSelector = LineParse.Parse(child2.GetChildValue("Selector"));
				Switch = child2.GetChild<TydList>("Ranges").Nodes.OfType<TydTable>().ToDictionary((TydTable x) => x.GetChildValue("Value", true, 0f), (TydTable x) => x.GetChild<TydList>("Sentences").GetNodeValues().ToArray());
				Locs = new Dictionary<string, string>();
				int num = 0;
				{
					foreach (string[] value in Switch.Values)
					{
						for (int num2 = 0; num2 < value.Length; num2++)
						{
							string key = value[num2];
							Locs[key] = "FinalReview" + ID + num + "-" + num2;
						}
						num++;
					}
					return;
				}
			}
			Sentences = node.GetChild<TydList>("Sentences", true).GetNodeValues().ToArray();
			Locs = Sentences.Select((string x, int i) => new KeyValuePair<string, int>(x, i)).ToDictionary((KeyValuePair<string, int> x) => x.Key, (KeyValuePair<string, int> x) => "FinalReview" + ID + x.Value);
		}

		public string GenerateStatement(ArticleGenerator.SoftwareReviewData data, HashSet<string> usedSentences, System.Random rng)
		{
			if (Eval != null && !(bool)LineParse.Execute(Eval, data))
			{
				return null;
			}
			if (Sentences != null)
			{
				string random = Sentences.Where((string x) => !usedSentences.Contains(x)).GetRandom(rng);
				return Locs[random].LocDef(random);
			}
			double num = (double)LineParse.Execute(SwitchSelector, data);
			foreach (KeyValuePair<float, string[]> item in Switch)
			{
				if (num >= (double)item.Key)
				{
					if (item.Value.Length == 0)
					{
						return null;
					}
					string random2 = item.Value.Where((string x) => !usedSentences.Contains(x)).GetRandom(rng);
					return Locs[random2].LocDef(random2);
				}
			}
			return null;
		}
	}

	public struct Review
	{
		public Reviewer Subject;

		public int Score;

		public float Interest;

		public string Statement;

		public Review(Reviewer subject, int score, float interest, string statement)
		{
			Subject = subject;
			Score = score;
			Interest = interest;
			Statement = statement;
		}
	}

	private static Reviewer[] _reviewers;

	private static Dictionary<string, Statement> _statements;

	private static Dictionary<string, Statement> _addonStatements;

	private static HashSet<string> _usedStatements;

	private static HashSet<string> _usedAddonStatements;

	private static Dictionary<string, float> _score;

	private static Dictionary<string, string> _statementData;

	private static List<KeyValuePair<Reviewer, float>> _revScore;

	private static HashSet<string> _usedSentences;

	private static List<Review> _finalReview;

	private static Regex _statementPlacer;

	private static int CNameCount;

	private static int PNameCount;

	private static int DNameCount;

	private static Dictionary<string, string> _sentenceConnectors;

	private static string[] _isAre;

	public static void ExportLoc(Dictionary<string, string> loc)
	{
		loc["FinalReviewIsAre"] = string.Join("|", _isAre);
		loc["FinalReviewNone"] = "No statement";
		foreach (KeyValuePair<string, string> sentenceConnector in _sentenceConnectors)
		{
			loc[sentenceConnector.Value] = sentenceConnector.Key;
		}
		for (int i = 0; i < _reviewers.Length; i++)
		{
			Reviewer reviewer = _reviewers[i];
			loc["FinalReview" + reviewer.ID] = reviewer.Name;
		}
		foreach (Statement value in _statements.Values)
		{
			foreach (KeyValuePair<string, string> loc2 in value.Locs)
			{
				loc[loc2.Value] = loc2.Key;
			}
		}
		foreach (Statement value2 in _addonStatements.Values)
		{
			if (_statements.ContainsValue(value2))
			{
				continue;
			}
			foreach (KeyValuePair<string, string> loc3 in value2.Locs)
			{
				loc[loc3.Value] = loc3.Key;
			}
		}
	}

	static FinalReviewGenerator()
	{
		_usedStatements = new HashSet<string>();
		_usedAddonStatements = new HashSet<string>();
		_score = new Dictionary<string, float>();
		_statementData = new Dictionary<string, string>();
		_revScore = new List<KeyValuePair<Reviewer, float>>();
		_usedSentences = new HashSet<string>();
		_finalReview = new List<Review>();
		_statementPlacer = new Regex("\\[([^\\]]+)\\]");
		CNameCount = 0;
		PNameCount = 0;
		DNameCount = 0;
		_sentenceConnectors = new Dictionary<string, string>
		{
			{ "{0} {1}, though", "FinalReviewConnect1" },
			{ "{0}, which is a shame because {1}", "FinalReviewConnect2" },
			{ "{0}, but at least {1}", "FinalReviewConnect3" },
			{ "{0} and {1}", "FinalReviewConnect4" },
			{ "{0}, plus {1}", "FinalReviewConnect5" },
			{ "{0}, also {1}", "FinalReviewConnect6" },
			{ "{0}, but {1}", "FinalReviewConnect7" },
			{ "{0}. {1}, though", "FinalReviewConnect8" }
		};
		_isAre = new string[6] { "is", "are", "it", "they", "them", "their" };
		TydDocument documentNode = TydFile.FromContent(GameData.LoadFullTextAsset("ArticleGenerator/FinalReview"), null).DocumentNode;
		_reviewers = (from x in documentNode.GetChild<TydList>("Reviewers").Nodes.OfType<TydTable>()
			select new Reviewer(x)).ToArray();
		_statements = (from x in documentNode.GetChild<TydList>("Statements").Nodes.OfType<TydTable>()
			select new Statement(x)).ToDictionary((Statement x) => x.ID, (Statement x) => x);
		TydList child = documentNode.GetChild<TydList>("AddOnStatements");
		_addonStatements = (from x in child.Nodes.OfType<TydTable>()
			select new Statement(x)).ToDictionary((Statement x) => x.ID, (Statement x) => x);
		foreach (TydString item in child.Nodes.OfType<TydString>())
		{
			_addonStatements[item.Value] = _statements[item.Value];
		}
	}

	private static bool IsPunctuation(char ch)
	{
		if (ch != '.' && ch != '!')
		{
			return ch == '?';
		}
		return true;
	}

	private static string CnLoc(this string s)
	{
		return _sentenceConnectors[s].LocDef(s);
	}

	private static string Connect(string s1, string s2, double sc1, double sc2, bool unCap, System.Random rng)
	{
		double num = Math.Abs(sc1 - sc2);
		if (IsPunctuation(s1[s1.Length - 1]))
		{
			if (num > 0.5 && !IsPunctuation(s2[s2.Length - 1]))
			{
				return string.Format("{0} {1}, though".CnLoc(), s1, s2);
			}
			return s1 + " " + s2;
		}
		if (sc1 > 0.6000000238418579 && sc2 < 0.4000000059604645 && rng.NextDouble() > 0.5)
		{
			return string.Format("{0}, which is a shame because {1}".CnLoc(), s1, unCap ? UnCapitalize(s2) : s2);
		}
		if (sc1 < 0.4000000059604645 && sc2 > 0.6000000238418579 && rng.NextDouble() > 0.5)
		{
			return string.Format("{0}, but at least {1}".CnLoc(), s1, unCap ? UnCapitalize(s2) : s2);
		}
		if (num < 0.25)
		{
			if (rng.NextDouble() > 0.5)
			{
				return string.Format("{0} and {1}".CnLoc(), s1, unCap ? UnCapitalize(s2) : s2);
			}
			return string.Format(((sc1 > 0.5) ? "{0}, plus {1}" : "{0}, also {1}").CnLoc(), s1, unCap ? UnCapitalize(s2) : s2);
		}
		if (num < 0.5)
		{
			if (rng.NextDouble() > 0.5)
			{
				return string.Format("{0}, {1}", s1, unCap ? UnCapitalize(s2) : s2);
			}
			return string.Format("{0}. {1}", s1, s2);
		}
		if (rng.NextDouble() > 0.5 || IsPunctuation(s2[s2.Length - 1]))
		{
			return string.Format("{0}, but {1}".CnLoc(), s1, unCap ? UnCapitalize(s2) : s2);
		}
		return string.Format("{0}. {1}, though".CnLoc(), s1, s2);
	}

	private static string UnCapitalize(string s)
	{
		return s.Substring(0, 1).ToLower() + s.Substring(1);
	}

	private static bool CheckValidScore(float overallScore, double statementScore, float margin)
	{
		if (overallScore < 0.375f)
		{
			return statementScore <= (double)(0.5f + margin);
		}
		if (overallScore >= 0.625f)
		{
			return statementScore >= (double)(0.5f - margin);
		}
		return true;
	}

	public static Review[] GenerateReview(ArticleGenerator.SoftwareReviewData data)
	{
		_usedStatements.Clear();
		_usedAddonStatements.Clear();
		_finalReview.Clear();
		_usedSentences.Clear();
		_score["RealQuality"] = data.RealQuality;
		_score["Cheap"] = data.Cheap;
		_score["Expensive"] = data.Expensive;
		_score["SellingPotential"] = data.SellingPotential;
		_score["Hype"] = data.Hype;
		_score["BugScore"] = data.BugScore;
		_score["ReachScore"] = data.ReachScore;
		_score["FeatScore"] = data.FeatScore;
		_score["Rep"] = data.Rep;
		_score["FanBase"] = data.FanBase;
		_score["TechScore"] = data.TechScore;
		_score["SubScore"] = data.SubScore;
		_score["Progress"] = data.Progress;
		_score["Sequel"] = data.Sequel;
		_score["Subscription"] = (data.ToSubscrip ? 0f : 1f);
		_score["Creativity"] = data.Creativity.MapRange(0f, 0.6f, 0f, 1f, true);
		_statementData["CompanyName"] = data.C.Name;
		_statementData["CompanyNameBe"] = data.C.Name;
		_statementData["ProductName"] = data.ProductName;
		_statementData["Designer"] = data.LeadDesigner;
		_statementData["DesignerPos"] = data.LeadDesigner;
		_statementData["DesignerBe"] = data.LeadDesigner;
		_statementData["Competition"] = data.Comp;
		string res;
		string[] array = ("FinalReviewIsAre".LocTry(out res) ? res.Split('|') : _isAre);
		if (array.Length < 6 && Options.LocalizationFallback && Localization.English != null)
		{
			string[] output;
			string[] array2 = (Localization.English.TryGetValue("FinalReviewIsAre", out output) ? output[0] : "").Split('|');
			if (array2.Length >= 6)
			{
				int num = array.Length;
				array = array.Resize(6);
				for (int i = num; i < 6; i++)
				{
					array[i] = array2[num];
				}
			}
		}
		if (array.Length < 6)
		{
			int num2 = array.Length;
			array = array.Resize(6);
			for (int j = num2; j < 6; j++)
			{
				array[j] = "[NoLoc]";
			}
		}
		_revScore.Clear();
		for (int k = 0; k < _reviewers.Length; k++)
		{
			Reviewer reviewer = _reviewers[k];
			_revScore.Add(new KeyValuePair<Reviewer, float>(reviewer, reviewer.GetScore(_score)));
		}
		for (int l = 0; l < _revScore.Count; l++)
		{
			_finalReview.Add(GenerateStatement(_revScore[l].Key, _revScore[l].Value, data, array));
		}
		_finalReview.Sort((Review x, Review y) => y.Interest.CompareTo(x.Interest));
		_finalReview.RemoveRange(3, _finalReview.Count - 3);
		for (int num3 = 0; num3 < 3; num3++)
		{
			Review r = _finalReview[num3];
			if (r.Interest == -1f)
			{
				_usedStatements.Clear();
				_finalReview[num3] = GenerateStatement(r.Subject, _revScore.First((KeyValuePair<Reviewer, float> x) => x.Key == r.Subject).Value, data, array);
			}
		}
		return _finalReview.ToArray();
	}

	private static Review GenerateStatement(Reviewer r, float rScore, ArticleGenerator.SoftwareReviewData data, string[] isAre)
	{
		System.Random rng = new System.Random(data.ProductName.GetHashCode());
		CNameCount = 0;
		PNameCount = 0;
		DNameCount = 0;
		string text = null;
		int num = -1;
		double num2 = 0.0;
		double num3 = 0.0;
		for (int i = 0; i < r.Statements.Length; i++)
		{
			string text2 = r.Statements[i];
			Statement value;
			if (_usedStatements.Contains(text2) || !_statements.TryGetValue(text2, out value))
			{
				continue;
			}
			text = value.GenerateStatement(data, _usedSentences, rng);
			if (text == null)
			{
				continue;
			}
			num2 = (double)LineParse.Execute(value.Score, data);
			if (value.IgnoreScore || CheckValidScore(rScore, num2, 0f))
			{
				num = value.SubjectID;
				_usedStatements.Add(text2);
				_usedSentences.Add(text);
				num3 += ((value.Interest != null) ? ((double)LineParse.Execute(value.Interest, data)) : ((double)value.InterestConstant));
				text = _statementPlacer.Replace(text, (Match x) => Replacement(x, false, false, false, isAre));
				break;
			}
		}
		if (text != null)
		{
			for (int num4 = 0; num4 < r.Statements.Length; num4++)
			{
				string text3 = r.Statements[num4];
				Statement value2;
				if (_usedAddonStatements.Contains(text3) || !_addonStatements.TryGetValue(text3, out value2) || value2.SubjectID == num)
				{
					continue;
				}
				string text4 = value2.GenerateStatement(data, _usedSentences, rng);
				if (text4 == null)
				{
					continue;
				}
				double num5 = (double)LineParse.Execute(value2.Score, data);
				if (value2.IgnoreScore || CheckValidScore(rScore, num5, 0.2f))
				{
					_usedSentences.Add(text4);
					text = Connect(text, _statementPlacer.Replace(text4, (Match x) => Replacement(x, CNameCount > 0, PNameCount > 0, DNameCount > 0, isAre)), num2, num5, !text4.StartsWith("["), rng);
					num3 += ((value2.Interest != null) ? ((double)LineParse.Execute(value2.Interest, data)) : ((double)value2.InterestConstant));
					_usedAddonStatements.Add(text3);
					break;
				}
			}
		}
		if (text == null)
		{
			text = "FinalReviewNone".Loc();
			num3 = -1.0;
		}
		if (!IsPunctuation(text[text.Length - 1]))
		{
			text += ".";
		}
		return new Review(r, Mathf.Clamp(1 + Mathf.RoundToInt(rScore * 4f), 1, 5), (float)num3, text);
	}

	private static string Replacement(Match m, bool cName, bool pName, bool dName, string[] isAre)
	{
		string value = m.Groups[1].Value;
		if (value.Equals("is"))
		{
			if (!cName)
			{
				return isAre[0];
			}
			return isAre[1];
		}
		if (value.Equals("isD"))
		{
			if (!dName)
			{
				return isAre[0];
			}
			return isAre[1];
		}
		string value2;
		if (_statementData.TryGetValue(value, out value2))
		{
			if (value.Equals("CompanyName"))
			{
				CNameCount++;
				if (cName)
				{
					return isAre[3];
				}
			}
			else if (value.Equals("CompanyNameBe"))
			{
				CNameCount++;
				if (cName)
				{
					return isAre[4];
				}
			}
			else if (value.Equals("ProductName"))
			{
				PNameCount++;
				if (pName)
				{
					return isAre[2];
				}
			}
			else if (value.Equals("Designer"))
			{
				DNameCount++;
				if (dName)
				{
					return isAre[3];
				}
			}
			else
			{
				if (value.Equals("DesignerPos"))
				{
					DNameCount++;
					if (dName)
					{
						return isAre[5];
					}
					return value2 + (value2.EndsWith("s") ? "'" : "'s");
				}
				if (value.Equals("DesignerBe"))
				{
					DNameCount++;
					if (dName)
					{
						return isAre[4];
					}
				}
			}
			return value2;
		}
		return m.Value;
	}

	public static string ReviewToNews(Review[] reviews)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < reviews.Length; i++)
		{
			Review review = reviews[i];
			stringBuilder.AppendLine(string.Format("\"{0}\"", review.Statement));
			stringBuilder.AppendLine(string.Format("{0}/5 - {1}", review.Score, review.Subject.Name));
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}
}
