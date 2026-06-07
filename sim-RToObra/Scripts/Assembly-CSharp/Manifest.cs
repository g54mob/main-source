using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Manifest
{
	public enum Gender
	{
		None = 0,
		Male = 1,
		Female = 2,
		Beast = 3
	}

	public class Glue
	{
		public string summary;

		public string sentence;
	}

	public enum Hint
	{
		NameSketch = 0,
		NameDialog = 1,
		NameAccessory = 2,
		RoleSketch = 3,
		RoleRoom = 4,
		RoleDialog = 5,
		RoleScene = 6,
		RoleAppearance = 7,
		RelateScene = 8,
		RelateManifest = 9,
		RelateDialog = 10,
		RelateSketch = 11,
		OriginAppearance = 12,
		OriginAccent = 13,
		OriginLanguage = 14,
		OriginDialog = 15,
		NumberScene = 16,
		Elimination = 17,
		Guess = 18
	}

	public enum Difficulty
	{
		Easy = 0,
		Medium = 1,
		Hard = 2
	}

	public class GenderedString
	{
		public string original;

		public string Mm;

		public string Mf;

		public string Fm;

		public string Ff;

		public string Mb;

		public string Fb;

		public bool hasValue
		{
			get
			{
				return original.HasValue();
			}
		}

		public GenderedString(string original_)
		{
			original = original_;
			Mm = ApplyGender(original, Gender.Male, Gender.Male);
			Mf = ApplyGender(original, Gender.Male, Gender.Female);
			Fm = ApplyGender(original, Gender.Female, Gender.Male);
			Ff = ApplyGender(original, Gender.Female, Gender.Female);
			Mb = ApplyGender(original, Gender.Male, Gender.Beast);
			Fb = ApplyGender(original, Gender.Female, Gender.Beast);
		}

		public string Get(Gender genderA, Gender genderB = Gender.Male)
		{
			if (genderA == Gender.Female)
			{
				switch (genderB)
				{
				case Gender.Female:
					return Ff;
				case Gender.Beast:
					return Fb;
				default:
					return Fm;
				}
			}
			switch (genderB)
			{
			case Gender.Female:
				return Mf;
			case Gender.Beast:
				return Mb;
			default:
				return Mm;
			}
		}
	}

	public class GenderedStringArray
	{
		public GenderedString[] original;

		public string[] Mm;

		public string[] Mf;

		public string[] Fm;

		public string[] Ff;

		public string[] Mb;

		public string[] Fb;

		public GenderedStringArray(GenderedString[] original_)
		{
			original = original_;
			Mm = new string[original.Length];
			Mf = new string[original.Length];
			Fm = new string[original.Length];
			Ff = new string[original.Length];
			Mb = new string[original.Length];
			Fb = new string[original.Length];
			for (int i = 0; i < original.Length; i++)
			{
				Mm[i] = original[i].Mm;
				Mf[i] = original[i].Mf;
				Fm[i] = original[i].Fm;
				Ff[i] = original[i].Ff;
				Mb[i] = original[i].Mb;
				Fb[i] = original[i].Fb;
			}
		}

		public string[] Get(Gender genderA, Gender genderB)
		{
			if (genderA == Gender.Female)
			{
				switch (genderB)
				{
				case Gender.Female:
					return Ff;
				case Gender.Beast:
					return Fb;
				default:
					return Fm;
				}
			}
			switch (genderB)
			{
			case Gender.Female:
				return Mf;
			case Gender.Beast:
				return Mb;
			default:
				return Mm;
			}
		}
	}

	public class Crew
	{
		public int index;

		public string id;

		public string name;

		public string shortName;

		public string jobId;

		public string sketchId;

		public string categoryId;

		public string job;

		public string birthplace;

		public string[] fateIds;

		public string[] clueMomentIds;

		public Gender gender;

		public string[] tallies;

		public int pay;

		public bool insuranceEstateKnown;

		public bool insuranceKilledIntentionally;

		public Difficulty difficulty;
	}

	public class Ent
	{
		public string id;

		public bool canBeSubject;

		public GenderedString name;

		public GenderedString list;

		public GenderedStringArray listColumns;

		public GenderedString title;

		public GenderedString subject;

		public GenderedString killer;

		public GenderedString summary;

		public GenderedString job;

		public Gender gender;

		public Crew crew;

		public bool isCrew
		{
			get
			{
				return crew != null;
			}
		}
	}

	public enum SentencePartKind
	{
		Subject = 0,
		Body = 1,
		Killer = 2
	}

	public class SentencePart
	{
		public SentencePartKind kind;

		public GenderedString text;

		public bool isSubject
		{
			get
			{
				return kind == SentencePartKind.Subject;
			}
		}

		public bool isBody
		{
			get
			{
				return kind == SentencePartKind.Body;
			}
		}

		public bool isKiller
		{
			get
			{
				return kind == SentencePartKind.Killer;
			}
		}
	}

	public class Fate
	{
		public string baseId;

		public string path;

		public bool hasKiller;

		public GenderedString summary;

		public SentencePart[] sentenceParts;

		public string[] Parts(Ent subjectEnt, Ent killerEnt, Gender forceSubjectGender)
		{
			Gender genderA = ((forceSubjectGender != Gender.None) ? forceSubjectGender : subjectEnt.gender);
			Gender gender = ((killerEnt == null) ? Gender.Male : killerEnt.gender);
			string[] array = new string[sentenceParts.Length];
			for (int i = 0; i < array.Length; i++)
			{
				SentencePart sentencePart = sentenceParts[i];
				array[i] = sentencePart.text.Get(genderA, gender);
				array[i] = array[i].Replace("$subject", subjectEnt.subject.Get(genderA));
				if (killerEnt != null)
				{
					array[i] = array[i].Replace("$killer", killerEnt.killer.Get(gender));
				}
			}
			return array;
		}

		public string Summary(Gender subjectGender, Ent killerEnt, string glue)
		{
			if (hasKiller && killerEnt != null)
			{
				return summary.Get(subjectGender, killerEnt.gender) + glue + killerEnt.summary.Get(killerEnt.gender);
			}
			return summary.Get(subjectGender);
		}
	}

	public class FateNode
	{
		public FateNode parent;

		public GenderedString name;

		public GenderedStringArray listColumns;

		public List<FateNode> nodes = new List<FateNode>();

		public Fate fate;

		public bool isRoot
		{
			get
			{
				return parent == null;
			}
		}

		public FateNode(FateNode parent_, string name_, Fate fate_ = null)
		{
			parent = parent_;
			name = new GenderedString(name_);
			fate = fate_;
		}

		public FateNode(List<Fate> fates)
		{
			name = new GenderedString(string.Empty);
			foreach (Fate fate in fates)
			{
				string[] array = fate.path.Split('/');
				FateNode fateNode = this;
				for (int i = 0; i < array.Length - 1; i++)
				{
					fateNode = fateNode.GetOrCreateNode(array[i]);
				}
				fateNode.nodes.Add(new FateNode(fateNode, array[array.Length - 1], fate));
			}
			FinalizeListColumns();
		}

		private void FinalizeListColumns()
		{
			GenderedString genderedString = new GenderedString(string.Empty);
			if (nodes.Count > 0)
			{
				listColumns = new GenderedStringArray(new GenderedString[3]
				{
					genderedString,
					name,
					new GenderedString(">")
				});
			}
			else
			{
				listColumns = new GenderedStringArray(new GenderedString[3] { genderedString, name, genderedString });
			}
			foreach (FateNode node in nodes)
			{
				node.FinalizeListColumns();
			}
		}

		public FateNode GetOrCreateNode(string nodeName)
		{
			foreach (FateNode node in nodes)
			{
				if (node.name.original == nodeName)
				{
					return node;
				}
			}
			FateNode fateNode = new FateNode(this, nodeName);
			nodes.Add(fateNode);
			return fateNode;
		}

		public FateNode FindInTree(Fate f)
		{
			if (f == fate)
			{
				return this;
			}
			foreach (FateNode node in nodes)
			{
				if (node.fate == f)
				{
					return node;
				}
				if (node.nodes.Count != 0)
				{
					FateNode fateNode = node.FindInTree(f);
					if (fateNode != null)
					{
						return fateNode;
					}
				}
			}
			return null;
		}
	}

	private int langGeneration;

	private Glue glue;

	private Ent unknownEnt;

	private FateNode rootFateNode;

	private List<Ent> ents = new List<Ent>();

	private List<Fate> fates = new List<Fate>();

	private List<Crew> crews = new List<Crew>();

	private Dictionary<string, Ent> entsDict = new Dictionary<string, Ent>();

	private Dictionary<string, Fate> fatesDict = new Dictionary<string, Fate>();

	private Dictionary<string, Crew> crewsDict = new Dictionary<string, Crew>();

	private static Manifest it_;

	public static Manifest it
	{
		get
		{
			if (it_ == null || it_.langGeneration != Lang.generation)
			{
				it_ = new Manifest();
			}
			return it_;
		}
	}

	public int crewCount
	{
		get
		{
			return crews.Count;
		}
	}

	private Manifest()
	{
		langGeneration = Lang.generation;
		glue = new Glue();
		glue.sentence = Lang.Get("fate_glue_sentence");
		glue.summary = Lang.Get("fate_glue_summary");
		CsvTable csvTable = new CsvTable(Resources.Load<TextAsset>("Crew").text);
		for (int i = 0; i < csvTable.numRows; i++)
		{
			Crew crew = MakeCrewMember(csvTable, i);
			crews.Add(crew);
			crewsDict.Add(crew.id, crew);
		}
		string[] array = Util.SplitAndTrim(Resources.Load<TextAsset>("FateBaseIds").text, '\n');
		string[] array2 = array;
		foreach (string text in array2)
		{
			Fate fate = new Fate
			{
				baseId = text,
				hasKiller = text.Contains("-killer")
			};
			string text2 = Lang.Get("fate_parts_" + text);
			string[] array3 = Util.SplitAndTrim(text2, '|');
			if (array3.Length < 3)
			{
				Debug.LogWarningFormat("Not enough parts in fate {0}: {1}", text, text2);
				array3 = new string[4]
				{
					"ERROR-" + text,
					"$subject",
					text2,
					(!fate.hasKiller) ? text2 : "$killer"
				};
			}
			fate.path = array3[0];
			fate.summary = new GenderedString(fate.path.Replace("/", glue.summary));
			fate.sentenceParts = new SentencePart[array3.Length - 1];
			for (int k = 0; k < fate.sentenceParts.Length; k++)
			{
				string text3 = array3[k + 1];
				SentencePart sentencePart = new SentencePart
				{
					text = new GenderedString(text3)
				};
				if (text3.Contains("$subject"))
				{
					sentencePart.kind = SentencePartKind.Subject;
				}
				else if (text3.Contains("$killer"))
				{
					sentencePart.kind = SentencePartKind.Killer;
				}
				else
				{
					sentencePart.kind = SentencePartKind.Body;
				}
				fate.sentenceParts[k] = sentencePart;
			}
			fates.Add(fate);
			fatesDict.Add(fate.baseId, fate);
		}
		string[] sortedFateIds = Util.SplitAndTrim(Lang.Get("fate_sort"), ',');
		fates.Sort(delegate(Fate a, Fate b)
		{
			int num4 = Array.IndexOf(sortedFateIds, a.baseId);
			int num5 = Array.IndexOf(sortedFateIds, b.baseId);
			return num4 - num5;
		});
		string[] array4 = Util.SplitAndTrim(Resources.Load<TextAsset>("FateEntIds").text, '\n');
		string[] array5 = array4;
		foreach (string text4 in array5)
		{
			Ent ent = new Ent
			{
				id = text4,
				gender = Gender.Male,
				canBeSubject = (text4 != "beast" && text4 != "enemy"),
				crew = GetCrew(text4)
			};
			string id = "fate_ent_" + ((ent.crew == null) ? text4 : ent.crew.jobId);
			string[] parts = Util.SplitAndTrim(Lang.Get(id), '|');
			string original_ = ChainEntPart(text4, "LIST", parts, 0);
			string text5 = ChainEntPart(text4, "TITLE", parts, 1);
			string text6 = ChainEntPart(text4, "SUBJECT", parts, 2);
			string text7 = ConvertSubjectGenderingToKillerGendering(ChainEntPart(text4, "KILLER", parts, 3));
			if (ent.crew != null)
			{
				ent.list = new GenderedString(ExpandCrewProps(ent.crew, "$num|$name|$job|$birthplace"));
				ent.title = new GenderedString(ExpandCrewProps(ent.crew, text5));
				ent.subject = new GenderedString(ExpandCrewProps(ent.crew, text6));
				ent.killer = new GenderedString(ExpandCrewProps(ent.crew, text7));
				ent.job = new GenderedString(Lang.Get("crew_job_" + ent.crew.jobId));
			}
			else
			{
				ent.list = new GenderedString(original_);
				ent.title = new GenderedString(text5);
				ent.subject = new GenderedString(text6);
				ent.killer = new GenderedString(text7);
				ent.job = new GenderedString(Lang.Get("crew_job_" + ent.id.Replace("?", string.Empty)));
			}
			ents.Add(ent);
			entsDict.Add(text4, ent);
		}
		unknownEnt = null;
		entsDict.TryGetValue("unknown", out unknownEnt);
		foreach (Ent ent2 in ents)
		{
			if (ent2.crew != null)
			{
				ent2.name = new GenderedString(ent2.crew.name);
				ent2.summary = new GenderedString(ent2.crew.shortName);
				ent2.gender = ent2.crew.gender;
			}
			else if (ent2.id == "beast")
			{
				ent2.name = ent2.list;
				ent2.summary = ent2.list;
				ent2.gender = Gender.Beast;
			}
			else if (ent2.id == "enemy" || ent2.id == "unknown")
			{
				ent2.name = ent2.list;
				ent2.summary = ent2.list;
			}
			else
			{
				if (unknownEnt == null || !ent2.id.StartsWith("?"))
				{
					throw new UnityException("Unknown ent: " + ent2.id);
				}
				string text8 = Lang.Get("crew_job_" + ent2.id.Substring(1));
				ent2.name = new GenderedString(text8);
				ent2.list = new GenderedString(string.Format(" |{0}|{1}", unknownEnt.list.original, text8));
				ent2.summary = new GenderedString(text8);
			}
			string[] array6 = Util.SplitAndTrim(ent2.list.original, '|');
			GenderedString[] array7 = new GenderedString[array6.Length];
			for (int num2 = 0; num2 < array6.Length; num2++)
			{
				array7[num2] = new GenderedString(array6[num2]);
			}
			ent2.listColumns = new GenderedStringArray(array7);
		}
		rootFateNode = new FateNode(fates);
		foreach (Crew crew2 in crews)
		{
			string[] fateIds = crew2.fateIds;
			foreach (string text9 in fateIds)
			{
				Fate fate2 = GetFate(text9);
				if (fate2 == null)
				{
					Debug.LogError(string.Format("Invalid crew fate for {0}: {1}", crew2.id, text9));
				}
			}
		}
	}

	public string GetCrewId(int index)
	{
		return (index >= crews.Count) ? string.Empty : crews[index].id;
	}

	public Crew GetCrew(string crewId)
	{
		Crew value = null;
		crewsDict.TryGetValue(crewId, out value);
		return value;
	}

	public string[] GetCrewFateIds(string crewId)
	{
		Crew crew = GetCrew(crewId);
		return (crew != null) ? crew.fateIds : new string[1] { "unknown" };
	}

	public int GetCrewIndex(string crewId)
	{
		Crew crew = GetCrew(crewId);
		return (crew == null) ? (-1) : crew.index;
	}

	public string GetCrewName(string crewId)
	{
		Crew crew = GetCrew(crewId);
		return (crew == null) ? string.Empty : crew.name;
	}

	public string[] GetCrewTallies(string crewId)
	{
		Crew value = null;
		crewsDict.TryGetValue(crewId, out value);
		return (value == null) ? null : value.tallies;
	}

	public Ent GetEnt(string entId)
	{
		Ent value = unknownEnt;
		if (!entId.HasValue())
		{
			return value;
		}
		entsDict.TryGetValue(entId, out value);
		return value;
	}

	public string GetEntName(string actualEntId, string guessedEntId, bool includeJobIfCrew)
	{
		Ent ent = GetEnt(guessedEntId);
		if (ent != null)
		{
			if (ent.isCrew)
			{
				return (!includeJobIfCrew) ? ent.name.Get(ent.crew.gender) : ent.title.Get(ent.crew.gender);
			}
			Gender entGender = GetEntGender(actualEntId);
			return ent.name.Get(entGender);
		}
		return GetEntName("unknown", "unknown", includeJobIfCrew);
	}

	public string GetEntJob(string actualEntId, string guessedEntId)
	{
		Ent ent = GetEnt(guessedEntId);
		if (ent != null)
		{
			if (ent.isCrew)
			{
				return ent.job.Get(ent.crew.gender);
			}
			Gender entGender = GetEntGender(actualEntId);
			return ent.job.Get(entGender);
		}
		return GetEntJob("unknown", "unknown");
	}

	public string GetCrewSketchId(string crewId)
	{
		Crew crew = GetCrew(crewId);
		return (crew == null) ? string.Empty : crew.sketchId;
	}

	public string[] GetCrewClueMomentIds(string crewId)
	{
		Crew crew = GetCrew(crewId);
		return (crew == null) ? null : crew.clueMomentIds;
	}

	public Gender GetCrewGender(string crewId)
	{
		Crew crew = GetCrew(crewId);
		return (crew == null) ? Gender.Male : crew.gender;
	}

	public Gender GetEntGender(string entId, Gender unknownGender = Gender.Male)
	{
		Ent ent = GetEnt(entId);
		return (ent != null && !(ent.id == "unknown")) ? ent.gender : unknownGender;
	}

	public string[] GetFateSentenceParts(string fateId, string actualSubjectId, string guessedSubjectId)
	{
		Fate fate = GetFate((!fateId.HasValue()) ? "unknown" : fateId);
		Ent ent = GetEnt(actualSubjectId);
		Ent ent2 = GetEnt(guessedSubjectId);
		Gender forceSubjectGender = ((!ent2.isCrew) ? ent.gender : ent2.gender);
		Ent ent3 = GetEnt(FateId_KillerId(fateId));
		return fate.Parts(ent2, ent3, forceSubjectGender);
	}

	public string GetFateSentenceComplete(string fateId, string actualSubjectId, string guessedSubjectId)
	{
		string[] fateSentenceParts = GetFateSentenceParts(fateId, actualSubjectId, guessedSubjectId);
		return string.Join(glue.sentence, fateSentenceParts);
	}

	public string GetFateSummary(string fateId, string actualSubjectId, string guessedSubjectId)
	{
		Fate fate = GetFate((!fateId.HasValue()) ? "unknown" : fateId);
		Ent ent = it.GetEnt(actualSubjectId);
		Ent ent2 = it.GetEnt(guessedSubjectId);
		Gender subjectGender = ((!ent2.isCrew) ? ent.gender : ent2.gender);
		Ent ent3 = GetEnt(FateId_KillerId(fateId));
		return fate.Summary(subjectGender, ent3, glue.summary);
	}

	public Fate GetFate(string fateId)
	{
		int num = fateId.IndexOf(":");
		if (num >= 0)
		{
			foreach (Fate fate in fates)
			{
				if (fate.baseId.Length != num || string.Compare(fateId, 0, fate.baseId, 0, num) != 0)
				{
					continue;
				}
				return fate;
			}
			return null;
		}
		Fate value = null;
		fatesDict.TryGetValue(fateId, out value);
		return value;
	}

	public IEnumerable<Ent> IterateEnts(bool forSubject)
	{
		foreach (Ent ent in ents)
		{
			if (!forSubject || (forSubject && ent.canBeSubject))
			{
				yield return ent;
			}
		}
	}

	public IEnumerable<Fate> IterateFates()
	{
		foreach (Fate fate in fates)
		{
			yield return fate;
		}
	}

	public IEnumerable<Crew> IterateCrews()
	{
		foreach (Crew crew in crews)
		{
			yield return crew;
		}
	}

	public FateNode FindFateNode(Fate fate)
	{
		return rootFateNode.FindInTree(fate);
	}

	public bool IsCorrectFate(string crewId, string fateId)
	{
		Crew crew = GetCrew(crewId);
		if (crew == null)
		{
			return false;
		}
		return Array.IndexOf(crew.fateIds, fateId) >= 0;
	}

	public static string FateId_BaseId(string fateId)
	{
		int num = fateId.IndexOf(":");
		if (num >= 0)
		{
			return fateId.Substring(0, num);
		}
		return fateId;
	}

	public static string FateId_KillerId(string fateId)
	{
		int num = fateId.IndexOf(":");
		if (num >= 0)
		{
			return fateId.Substring(num + 1);
		}
		return null;
	}

	public static string FateId_Join(string fateId, string killerId)
	{
		return (!killerId.HasValue()) ? fateId : (FateId_BaseId(fateId) + ":" + killerId);
	}

	public string FateId_ScrubSelfKiller(string entId, string fateId)
	{
		Ent ent = GetEnt(entId);
		if (ent.crew != null)
		{
			string text = FateId_KillerId(fateId);
			if (text == ent.crew.id)
			{
				return FateId_BaseId(fateId);
			}
			return fateId;
		}
		return fateId;
	}

	private static string ChainEntPart(string entId, string partId, string[] parts, int index)
	{
		while (index > 0 && (index >= parts.Length || parts[index] == "=" || parts[index] == string.Empty))
		{
			index--;
		}
		if (index >= parts.Length || parts[index] == "=" || parts[index] == string.Empty)
		{
			return "(" + entId + ":" + partId + ")";
		}
		return parts[index];
	}

	private static string StripMarkup(string str, string start, string end)
	{
		while (true)
		{
			int num = str.IndexOf(start);
			if (num < 0)
			{
				break;
			}
			int num2 = str.IndexOf(end, num + start.Length);
			if (num2 < 0)
			{
				break;
			}
			str = str.Substring(0, num) + str.Substring(num2 + end.Length);
		}
		return str;
	}

	public static string ApplyGender(string str, Gender a, Gender b = Gender.None)
	{
		if (a != Gender.Male)
		{
			str = StripMarkup(str, "<M>", "<>");
		}
		if (a != Gender.Female)
		{
			str = StripMarkup(str, "<F>", "<>");
		}
		if (b != Gender.Male)
		{
			str = StripMarkup(str, "<m>", "<>");
		}
		if (b != Gender.Female)
		{
			str = StripMarkup(str, "<f>", "<>");
		}
		if (b != Gender.Beast)
		{
			str = StripMarkup(str, "<b>", "<>");
		}
		if (str.Contains("<size"))
		{
			str = str.Replace("<M>", string.Empty);
			str = str.Replace("<m>", string.Empty);
			str = str.Replace("<F>", string.Empty);
			str = str.Replace("<f>", string.Empty);
			str = str.Replace("<b>", string.Empty);
			str = str.Replace("<>", string.Empty);
		}
		else
		{
			str = StripMarkup(str, "<", ">");
		}
		return str;
	}

	public static bool HasGender(string str)
	{
		return str.Contains("<M>") || str.Contains("<m>") || str.Contains("<F>") || str.Contains("<f>");
	}

	public static string MakeGenderTagsObvious(string str)
	{
		str = Regex.Replace(str, "<M>[^>]+<>", "<M>---MALE---<>");
		str = Regex.Replace(str, "<m>[^>]+<>", "<m>---male---<>");
		str = Regex.Replace(str, "<F>[^>]+<>", "<F>---FEMALE---<>");
		str = Regex.Replace(str, "<f>[^>]+<>", "<f>---female---<>");
		str = Regex.Replace(str, "<b>[^>]+<>", "<b>---beast---<>");
		return str;
	}

	public static bool ParseCrewName(string stringsDbValue, out string name, out string shortName)
	{
		string[] array = Util.SplitAndTrim(stringsDbValue, '|');
		name = ((array.Length <= 0) ? "-BAD NAME-" : array[0]);
		shortName = ((array.Length <= 1) ? "-BAD SHORTNAME-" : array[1]);
		return array.Length == 2;
	}

	private static Crew MakeCrewMember(CsvTable table, int i)
	{
		Crew crew = new Crew();
		crew.index = i;
		crew.id = table.GetCell(i, "id");
		crew.gender = ((!(table.GetCell(i, "gender").ToLower() == "f")) ? Gender.Male : Gender.Female);
		ParseCrewName(Lang.Get("crew_name_" + crew.id), out crew.name, out crew.shortName);
		crew.birthplace = Lang.ExpandReferences(table.GetCell(i, "birthplace"));
		crew.jobId = table.GetCell(i, "job");
		crew.job = ApplyGender(Lang.Get("crew_job_" + crew.jobId), crew.gender, crew.gender);
		crew.sketchId = table.GetCell(i, "sketch");
		crew.categoryId = table.GetCell(i, "category");
		crew.fateIds = table.GetCell(i, "fate").Split(',');
		crew.clueMomentIds = table.GetCell(i, "clue").Split(' ');
		crew.tallies = Util.SplitAndTrim(table.GetCell(i, "tally"), ',');
		crew.pay = int.Parse(table.GetCell(i, "pay"));
		string cell = table.GetCell(i, "difficulty");
		if (cell == "easy")
		{
			crew.difficulty = Difficulty.Easy;
		}
		else if (cell == "hard")
		{
			crew.difficulty = Difficulty.Hard;
		}
		else
		{
			crew.difficulty = Difficulty.Medium;
		}
		string cell2 = table.GetCell(i, "insurance");
		crew.insuranceEstateKnown = !cell2.Contains("estate-unknown");
		crew.insuranceKilledIntentionally = !cell2.Contains("killed-accidental");
		for (int j = 0; j < crew.fateIds.Length; j++)
		{
			crew.fateIds[j] = crew.fateIds[j].Trim();
		}
		for (int k = 0; k < crew.clueMomentIds.Length; k++)
		{
			string text = crew.clueMomentIds[k].Trim();
			string text2 = text.Trim();
			switch (text2)
			{
			case "&":
			case "|":
				crew.clueMomentIds[k] = text2;
				break;
			default:
				crew.clueMomentIds[k] = Story.it.MatchMomentIdEnd(text2);
				break;
			case "-":
				break;
			}
		}
		return crew;
	}

	private static string ExpandCrewProps(Crew c, string s)
	{
		s = s.Replace("$id", c.id);
		s = s.Replace("$num", (c.index + 1).ToString());
		s = s.Replace("$name", c.name);
		s = s.Replace("$shortname", c.shortName);
		s = s.Replace("$job", c.job);
		s = s.Replace("$birthplace", c.birthplace);
		return s;
	}

	private static string ConvertSubjectGenderingToKillerGendering(string s)
	{
		s = s.Replace("<M>", "<m>");
		s = s.Replace("<F>", "<f>");
		return s;
	}
}
