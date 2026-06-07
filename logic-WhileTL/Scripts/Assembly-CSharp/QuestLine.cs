using System.Collections.Generic;
using App.Data;
using DeepTraffic;
using Newtonsoft.Json;
using UnityEngine;

public static class QuestLine
{
	public class Quest
	{
		public string name;

		public int id = -1;

		public int score;

		public int currentCondition;

		public int taskOpened;

		public BaseQuest quest;

		public Cathub cathub = new Cathub();

		public float moneySpent;

		public int testRunsOnQuest;

		public float timeInQuest;

		public int deployRunsOnQuest;

		public float newspaperTime;

		public int gainReward;

		public int trainRunsInCar;

		public int teachRunsInCar;

		public void IncDeployAnalytics()
		{
			deployRunsOnQuest++;
		}

		public void SetGainedReward(int state)
		{
			gainReward = state;
		}

		public void IncTeachRuns()
		{
			teachRunsInCar++;
		}

		public void IncTrainRuns()
		{
			trainRunsInCar++;
		}

		public bool Is<T>() where T : BaseQuest
		{
			if (quest != null)
			{
				return quest.Is<T>();
			}
			return false;
		}

		public string GetTexts()
		{
			if (quest == null)
			{
				return "";
			}
			return quest.Texts;
		}

		public bool IsHard()
		{
			if (quest == null)
			{
				return false;
			}
			return quest.Hard != 0;
		}

		public int GetRewardFromMedal(int medal)
		{
			if (quest == null)
			{
				return 0;
			}
			return quest.GetRewardFromMedal(medal);
		}

		public int GetRewardFromScore(int score)
		{
			if (score <= 0)
			{
				return 0;
			}
			return quest.GetRewardFromMedal(score - 1);
		}

		public int GetCurCondition()
		{
			return currentCondition;
		}

		public BaseCondition GetCondition(int i)
		{
			return quest.As<BaseGameQuest>().GetCondition(i);
		}

		public CarCondition GetCarCondition(int i)
		{
			return quest.As<CarQuest>().GetCarCondition(i);
		}

		public Cathub GetCatHub()
		{
			if (typeof(ForumQuest) == quest.GetType())
			{
				return GetQuest(((ForumQuest)quest).QuestKeyName).GetCatHub();
			}
			return cathub;
		}

		public void Clear()
		{
			cathub.Clear();
		}

		public void SetDefaultNameParams(BaseQuest bq)
		{
			name = bq.KeyName;
		}

		public void SetQuest(BaseQuest bq)
		{
			quest = bq;
			if (typeof(Comics) == bq.GetType())
			{
				quest.Texts = name;
			}
		}

		public void SetCarQuest(CarQuest cquest)
		{
			if (quest != null)
			{
				if (quest.As<CarQuest>().Update(cquest))
				{
					quest = cquest;
					cquest.wasReseted = 1;
				}
			}
			else
			{
				quest = cquest;
			}
		}

		public void SetReward(bool rew)
		{
			gainReward = (rew ? 1 : 0);
		}

		public string GetName()
		{
			return name;
		}

		public void SetCurrentCondition(int id)
		{
			currentCondition = id;
		}

		public List<UnlockGroup> GetUnlockGroups()
		{
			return quest.ReqUnlockGroups;
		}

		private void SetDefaultLidars()
		{
			if (quest.Is<CarQuest>())
			{
				LidarData bestLidarData = Logic.GetBestLidarData();
				LidarData behindLidar = ((bestLidarData == null) ? null : ((LidarData)bestLidarData.Clone()));
				CarQuest carQuest = quest.As<CarQuest>();
				carQuest.CarEnv.aheadLidar = (carQuest.CarEnv.lanesLidar = (carQuest.CarEnv.behindLidar = behindLidar));
				carQuest.CarEnv.SetDefaultLidars();
			}
		}

		public void SetDefaultCondition()
		{
			if (quest.Is<BaseGameQuest>())
			{
				BaseGameQuest baseGameQuest = quest.As<BaseGameQuest>();
				currentCondition = baseGameQuest.GetMaxExistentCondition();
			}
		}

		public void SetDefaultScore()
		{
			if (quest.Is<BaseGameQuest>())
			{
				BaseGameQuest baseGameQuest = quest.As<BaseGameQuest>();
				score = baseGameQuest.GetMinExistentCondition() + 1;
			}
		}

		public void SetOpened(bool state)
		{
			if (state && taskOpened == 0)
			{
				SetDefaultCondition();
				SetDefaultLidars();
				Logic.GetModel().curPreview.MakeQuestAvailable(name);
			}
			taskOpened = (state ? 1 : 0);
		}

		public bool IsTaskOpened()
		{
			return taskOpened != 0;
		}

		public ConstructionQuest GetTableQuest()
		{
			return quest.As<ConstructionQuest>();
		}

		public BaseQuest GetBaseQuest()
		{
			return quest;
		}

		public CarQuest GetCarQuest()
		{
			return quest.As<CarQuest>();
		}

		public ForumQuest GetForumQuest()
		{
			return quest.As<ForumQuest>();
		}

		public Comics GetComics()
		{
			return quest.As<Comics>();
		}

		public bool SetScore(int score, bool updateComicsScore = true)
		{
			this.score = Mathf.Max(this.score, score);
			Logic.GetModel().curPreview.MakeQuestAvailable(name);
			if (this.score > 0)
			{
				Logic.GetModel().curPreview.MakeQuestDone(name);
				SetOpened(state: true);
				if (updateComicsScore)
				{
					UpdateComicsesScore();
				}
				Logic.CheckEpochAchivments();
			}
			return this.score > 0;
		}

		public List<bool> GetListValidConditions()
		{
			if (!quest.Is<BaseGameQuest>())
			{
				return new List<bool>(new bool[3]);
			}
			return quest.As<BaseGameQuest>().GetListValidConditions();
		}

		public bool IsCompleted()
		{
			if (score > 0 && taskOpened > 0)
			{
				return true;
			}
			if (quest == null)
			{
				return false;
			}
			if (quest.Main == 1 && quest.Locked == 1)
			{
				return UnlockGroup.IsUnlocked(quest.ReqUnlockGroups);
			}
			return false;
		}

		public int GetScore()
		{
			return score;
		}

		private Cathub GetCurCathub()
		{
			if (quest != null && quest.Is<ForumQuest>())
			{
				return GetQuest(quest.As<ForumQuest>().QuestKeyName).GetCatHub();
			}
			return cathub;
		}

		public int GetNumValidCathubSchemes()
		{
			return GetCurCathub().GetNumValidSchemes();
		}

		public bool SetCathubScheme(int i, CathubScheme scheme)
		{
			return GetCurCathub().SetScheme(i, scheme);
		}

		public int GetCathubUseAsCustom()
		{
			return GetCurCathub().GetUseAsCustom();
		}

		public void SetCathubUseAsCustom(int id)
		{
			GetCurCathub().SetUseAsCustom(id);
		}

		public int GetCurrentCathubScheme()
		{
			return GetCurCathub().GetCurrentScheme();
		}

		public CathubScheme GetCathubScheme(int i)
		{
			return GetCurCathub().GetScheme(i);
		}

		public SchemeBlock GetLastOpenCathubSchemeBlock()
		{
			return GetCathubSchemeBlock(GetCurCathub().GetCurrentScheme());
		}

		public SchemeBlock GetCustomCathubSchemeBlock()
		{
			return GetCathubSchemeBlock(GetCurCathub().GetUseAsCustom());
		}

		public SchemeBlock GetCathubSchemeBlock(int index)
		{
			return GetCurCathub().SchemeToSchemeBlock(index);
		}

		public T DeserializeObject<T>(string json)
		{
			return JsonConvert.DeserializeObject<T>(json, Logic.GetGlobalSettings());
		}
	}

	public class QuestData
	{
		public Dictionary<int, Quest> Quests = new Dictionary<int, Quest>();

		public Dictionary<string, Quest> SaveQuests = new Dictionary<string, Quest>();

		public Quest CurQuest;

		public void Clear()
		{
			Data.Quests.Clear();
			CurQuest = null;
		}
	}

	public static QuestData Data = new QuestData();

	public static int GetNumCompleted()
	{
		int num = 0;
		foreach (KeyValuePair<int, Quest> quest in Data.Quests)
		{
			if (quest.Value.IsCompleted())
			{
				num++;
			}
		}
		return num;
	}

	public static int GetSumScore()
	{
		int num = 0;
		foreach (KeyValuePair<int, Quest> quest in Data.Quests)
		{
			num += quest.Value.GetScore();
		}
		return num;
	}

	public static List<string> GetListCompleted()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<int, Quest> quest in Data.Quests)
		{
			if (quest.Value.IsCompleted())
			{
				list.Add(quest.Value.GetName());
			}
		}
		return list;
	}

	public static void UpdateComicsMedal(Quest comics)
	{
		if (!comics.IsTaskOpened())
		{
			comics.SetScore(0, updateComicsScore: false);
			return;
		}
		if (comics.quest == null)
		{
			comics.quest = Logic.GetBaseQuestByKeyName(comics.GetName());
		}
		Comics comics2 = comics.quest.As<Comics>();
		comics2.ReqScoreList.Split(',');
		int sumComicsScore = comics2.GetSumComicsScore();
		int[] scoresBorderInt = comics2.ScoresBorderInt;
		for (int num = scoresBorderInt.Length - 1; num >= 0; num--)
		{
			if (sumComicsScore >= scoresBorderInt[num])
			{
				comics.SetScore(num + 1, updateComicsScore: false);
				return;
			}
		}
		comics.SetScore(0, updateComicsScore: false);
	}

	public static void UpdateComicsesScore()
	{
		foreach (KeyValuePair<int, Quest> quest in Data.Quests)
		{
			if (quest.Value.quest != null && quest.Value.quest.Is<Comics>())
			{
				UpdateComicsMedal(quest.Value);
			}
		}
	}

	public static bool IsCompleted(BaseQuest cq)
	{
		return IsCompleted(cq.KeyName);
	}

	public static bool IsCompleted(string KeyName)
	{
		return GetQuest(KeyName)?.IsCompleted() ?? false;
	}

	public static bool IsLoadedInMemory(string KeyName)
	{
		if (KeyName == null)
		{
			return false;
		}
		Quest quest = GetQuest(KeyName);
		if (quest == null)
		{
			return false;
		}
		if (quest.quest == null)
		{
			return false;
		}
		return GetQuest(KeyName) != null;
	}

	private static void InitQuestOnUpdate(Quest q, BaseQuest cq)
	{
		if (cq.Is<CarQuest>())
		{
			q.SetCarQuest(cq.As<CarQuest>());
		}
		else if (cq.Is<ForumQuest>())
		{
			if (q != null && q.Is<ForumQuest>())
			{
				cq.Update(q.GetForumQuest());
			}
			q.SetQuest(cq);
		}
		else
		{
			q.SetQuest(cq);
		}
	}

	public static Quest UpdateOrAddQuest(BaseQuest cq)
	{
		Quest quest = GetQuest(cq.KeyName);
		if (quest != null)
		{
			InitQuestOnUpdate(quest, cq);
			if (quest.IsCompleted() && quest.gainReward == 0)
			{
				Logic.AddMoney(quest.GetRewardFromScore(quest.GetScore()));
				quest.gainReward = 1;
			}
			return quest;
		}
		Quest quest2 = new Quest();
		quest2.SetDefaultNameParams(cq);
		InitQuestOnUpdate(quest2, cq);
		AddQuest(quest2);
		if (cq.Is<ForumQuest>() && cq.As<ForumQuest>().QuestKeyName != "-")
		{
			UpdateOrAddQuest(Logic.GetBaseQuestByKeyName(cq.As<ForumQuest>().QuestKeyName));
		}
		return quest2;
	}

	public static int GetNumQuests()
	{
		return Data.Quests.Count;
	}

	public static Quest GetQuest(string name)
	{
		return GetQuest(name.GetHashCode());
	}

	public static Quest GetQuest(int nameHash)
	{
		if (Data.Quests.TryGetValue(nameHash, out var value))
		{
			return value;
		}
		return null;
	}

	public static Quest GetCurrentQuest()
	{
		return Data.CurQuest;
	}

	public static CarQuest GetCurrentCarQuest()
	{
		return Data.CurQuest.GetCarQuest();
	}

	public static string GetCurrentQuestName()
	{
		return Data.CurQuest.GetName();
	}

	public static bool SetCurrentQuestScheme(int i)
	{
		CathubScheme currentQuestCathubScheme = GetCurrentQuestCathubScheme(i);
		return SetCurrentQuestScheme(i, currentQuestCathubScheme);
	}

	public static bool SetCurrentQuestScheme(int i, CathubScheme scheme)
	{
		Quest currentQuest = GetCurrentQuest();
		return SetQuestCathubScheme(i, scheme, currentQuest);
	}

	public static bool SetQuestCathubScheme(int i, CathubScheme scheme, Quest quest)
	{
		return quest?.SetCathubScheme(i, scheme) ?? false;
	}

	public static CathubScheme GetCurrentQuestCathubScheme(int i)
	{
		if (GetCurrentQuest() == null)
		{
			return null;
		}
		return GetCurrentQuest().GetCathubScheme(i);
	}

	public static int GetCurrentQuestCathubSchemeIndex()
	{
		return GetCurrentQuest()?.GetCurrentCathubScheme() ?? 0;
	}

	public static int GetCurrentQuestCathubSchemeCustom()
	{
		return GetCurrentQuest()?.GetCathubUseAsCustom() ?? 0;
	}

	public static bool AddQuest(Quest quest)
	{
		Data.Quests.Add(quest.name.GetHashCode(), quest);
		return true;
	}

	public static bool SetCurrentQuest(Quest cq)
	{
		if (cq != null)
		{
			return SetCurrentQuest(cq.name.GetHashCode());
		}
		return false;
	}

	public static bool SetCurrentQuest(BaseQuest cq)
	{
		if (cq != null)
		{
			return SetCurrentQuest(cq.KeyName.GetHashCode());
		}
		return false;
	}

	public static bool SetCurrentQuest(string cqName)
	{
		if (cqName != null)
		{
			return SetCurrentQuest(cqName.GetHashCode());
		}
		return false;
	}

	public static bool SetCurrentQuest(int nameHash)
	{
		Quest quest = GetQuest(nameHash);
		if (quest == null)
		{
			quest = UpdateOrAddQuest(Logic.GetBaseQuestByKeyHash(nameHash));
		}
		Data.CurQuest = quest;
		return true;
	}

	public static void Clear()
	{
		Data.Clear();
	}

	public static string Serialize()
	{
		Data.SaveQuests = new Dictionary<string, Quest>();
		foreach (KeyValuePair<int, Quest> quest in Data.Quests)
		{
			Data.SaveQuests.Add(quest.Value.GetName(), quest.Value);
		}
		return Logic.SerializeObject(Data);
	}

	public static void Deserialize(string json)
	{
		Data = Logic.DeserializeObject<QuestData>(json);
		if (Logic.GetModel().P.unityVersion != Application.unityVersion)
		{
			Data.SaveQuests = new Dictionary<string, Quest>();
			foreach (KeyValuePair<int, Quest> quest in Data.Quests)
			{
				Data.SaveQuests.Add(quest.Value.GetName(), Logic.Clone<Quest>(quest.Value));
			}
		}
		Data.Quests = new Dictionary<int, Quest>();
		foreach (KeyValuePair<string, Quest> saveQuest in Data.SaveQuests)
		{
			Data.Quests.Add(saveQuest.Value.GetName().GetHashCode(), Logic.Clone<Quest>(saveQuest.Value));
			Logic.GetModel().curPreview.MakeQuestAvailable(saveQuest.Value.GetName(), IsLoadedInMemory(saveQuest.Value.GetName()));
			Logic.GetModel().curPreview.MakeQuestDone(saveQuest.Value.GetName(), IsCompleted(saveQuest.Value.GetName()));
		}
		foreach (KeyValuePair<int, Quest> quest2 in Data.Quests)
		{
			if (!Logic.GetModel().globalSaves.passedTasks.ContainsKey(quest2.Value.GetName()))
			{
				Logic.GetModel().globalSaves.passedTasks.Add(quest2.Value.GetName(), GetQuest(quest2.Key).GetScore());
			}
		}
	}
}
