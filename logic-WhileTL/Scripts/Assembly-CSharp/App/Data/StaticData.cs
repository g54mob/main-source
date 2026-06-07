using System.Collections.Generic;
using DeepTraffic;
using ReinforcementLearning.Environment;
using Unity.Components.Logs;
using UnityEngine;

namespace App.Data
{
	public class StaticData
	{
		public Settings Settings;

		private bool _textsInited;

		public List<TierBasedItem> Titles = new List<TierBasedItem>();

		public List<DateEvent> DateEvents = new List<DateEvent>();

		public List<Language> Languages = new List<Language>();

		public List<TextInGame> Texts = new List<TextInGame>();

		public List<TierBasedItem> Genres = new List<TierBasedItem>();

		public List<TierBasedItem> Authors = new List<TierBasedItem>();

		public List<TierBasedItem> MailTemplates = new List<TierBasedItem>();

		public List<ProjectType> Types = new List<ProjectType>();

		public List<UpgradeStats> PCUpgrades = new List<UpgradeStats>();

		public List<LevelData> Levels = new List<LevelData>();

		public List<AlgoProject> AlgoProjects = new List<AlgoProject>();

		public List<AlgoBlockInf> AlgoBlocks = new List<AlgoBlockInf>();

		public List<ReportTemplate> ReportTemplates = new List<ReportTemplate>();

		public List<ReportTemplate> DayOffTemplates = new List<ReportTemplate>();

		public List<ConstructionBlock> ConstructionBlocks = new List<ConstructionBlock>();

		public List<CatVR> PromoCats = new List<CatVR>();

		public List<PromoCode> PromoCodes = new List<PromoCode>();

		public List<BaseItem> Themes = new List<BaseItem>();

		public List<ElementColor> Colors = new List<ElementColor>();

		public List<Epoch> Epochs = new List<Epoch>();

		public List<Sticker> Stickers = new List<Sticker>();

		public List<QuestCondition> Conditions = new List<QuestCondition>();

		public List<ElementShape> Shapes = new List<ElementShape>();

		public List<LogicColor> LogicsColor = new List<LogicColor>();

		public List<LogicColor> LogicsShape = new List<LogicColor>();

		public List<ConstructionQuest> Quests = new List<ConstructionQuest>();

		public List<Data> Datas = new List<Data>();

		public List<Checkpoint> Checkpoints = new List<Checkpoint>();

		public List<Result> Results = new List<Result>();

		public List<EndGame> EndGame = new List<EndGame>();

		public List<PairColor> ColorDataPairs = new List<PairColor>();

		public List<MoneyLetter> MoneyLetters = new List<MoneyLetter>();

		public List<Startup> Startups = new List<Startup>();

		public List<Credit> Credits = new List<Credit>();

		public List<Server> Servers = new List<Server>();

		public List<User> Users = new List<User>();

		public List<CatVR> CatCost = new List<CatVR>();

		public List<InteriorItem> ShopItems = new List<InteriorItem>();

		public List<CarQuest> CarQuests = new List<CarQuest>();

		public List<Comics> Comicses = new List<Comics>();

		public List<DeepTrafficEnvPresets> CarEnv = new List<DeepTrafficEnvPresets>();

		public List<AgentPresets> CarAgents = new List<AgentPresets>();

		public List<AgentUnlockedParams> CarEnabledParams = new List<AgentUnlockedParams>();

		public List<DeepTrafficControllerPresets> CarController = new List<DeepTrafficControllerPresets>();

		public List<DeepTrafficControllerUnlockedParams> CarControllerEnabledParams = new List<DeepTrafficControllerUnlockedParams>();

		public List<CarConstraint> CarConstraints = new List<CarConstraint>();

		public List<CarMedalCondition> CarMedalConditions = new List<CarMedalCondition>();

		public List<CarCondition> CarConditions = new List<CarCondition>();

		public List<CarDatas> carDatas = new List<CarDatas>();

		public List<CarObjectTreeHierarchy> carObjectTreeHierarchy = new List<CarObjectTreeHierarchy>();

		public List<CarSliderParamsBounds> carSliderParamsBounds = new List<CarSliderParamsBounds>();

		public List<LidarData> LidarData = new List<LidarData>();

		public List<Cheat> Cheats = new List<Cheat>();

		public List<CarAttentionBackground> CarAttentionBackground = new List<CarAttentionBackground>();

		public List<SpriteHolder> Sprites = new List<SpriteHolder>();

		public List<ForumMessageData> ForumMessagesData = new List<ForumMessageData>();

		public List<ForumQuest> ForumQuests = new List<ForumQuest>();

		public List<AchivementData> AchivementDatas = new List<AchivementData>();

		public Dictionary<int, ConstructionBlock> ConstructionBlocksFast = new Dictionary<int, ConstructionBlock>();

		public void InitFastInteractions()
		{
			ConstructionBlocksFast.Clear();
			foreach (ConstructionBlock constructionBlock in ConstructionBlocks)
			{
				ConstructionBlocksFast.Add(constructionBlock.KeyName.GetHashCode(), constructionBlock);
			}
		}

		public void InitCarQuests()
		{
			foreach (CarQuest carQuest in CarQuests)
			{
				_ = carQuest.AgentEnabledKeyName;
				_ = carQuest.AgentKeyName;
				_ = carQuest.CarSliderParamsBoundsKeyName;
				_ = carQuest.ConditionBronze;
				_ = carQuest.CarSliderParamsBounds;
				_ = carQuest.LeftCarDatas;
				_ = carQuest.FrontCarDatas;
				_ = carQuest.BehindCarDatas;
				_ = carQuest.RightCarDatas;
				_ = carQuest.SuperEpochData;
				for (int i = 0; i < 3; i++)
				{
					CarCondition carCondition = carQuest.GetCarCondition(i);
					if (carCondition != null)
					{
						_ = carCondition.CarController;
						_ = carCondition.CarConstraint;
						_ = carCondition.CarMedalCondition;
					}
				}
				_ = carQuest.ControllerEnabledParams;
				_ = carQuest.CarEnabledParams;
				_ = carQuest.CarAgent;
				_ = carQuest.CarEnv;
			}
		}

		public void Init()
		{
			ParseDependencies();
			InitCarQuests();
			InitFastInteractions();
		}

		public void ParseDependencies()
		{
			foreach (ConstructionQuest quest in Quests)
			{
				quest.ParseReqQuests();
			}
			foreach (Startup startup in Startups)
			{
				startup.ParseReqQuests();
				startup.ParseBlockQuests();
			}
			foreach (UpgradeStats pCUpgrade in PCUpgrades)
			{
				pCUpgrade.ParseReqQuests();
			}
			foreach (MoneyLetter moneyLetter in MoneyLetters)
			{
				moneyLetter.ParseReqQuests();
				moneyLetter.ParseBlockQuests();
			}
			foreach (ConstructionBlock constructionBlock in ConstructionBlocks)
			{
				constructionBlock.ParseReqQuests();
			}
			foreach (CatVR item in CatCost)
			{
				item.ParseReqQuests();
			}
			foreach (Credit credit in Credits)
			{
				credit.ParseReqQuests();
			}
			foreach (EndGame item2 in EndGame)
			{
				item2.ParseReqQuests();
			}
			foreach (Checkpoint checkpoint in Checkpoints)
			{
				checkpoint.ParseReqQuests();
				checkpoint.ParseUnlockTasks();
			}
			foreach (Epoch epoch in Epochs)
			{
				epoch.ParseReqQuests();
			}
			foreach (Sticker sticker in Stickers)
			{
				sticker.ParseReqQuests();
			}
			foreach (InteriorItem shopItem in ShopItems)
			{
				shopItem.ParseReqQuests();
			}
			foreach (CarQuest carQuest in CarQuests)
			{
				carQuest.ParseReqQuests();
			}
			foreach (Comics comicse in Comicses)
			{
				comicse.ParseReqQuests();
			}
			foreach (ForumQuest forumQuest in ForumQuests)
			{
				forumQuest.ParseReqQuests();
			}
		}

		public void Update()
		{
			Settings.MaxZoom = Mathf.Max(1f, Settings.MaxZoom);
			UpdateDataFormat();
		}

		public void UpdateDataFormat()
		{
		}

		private void TryInitTexts()
		{
			if (_textsInited)
			{
				return;
			}
			_textsInited = true;
			Model._texts = new Dictionary<string, TextInGame>();
			foreach (TextInGame text2 in Texts)
			{
				string text = text2.Id.ToLowerInvariant();
				if (!Model._texts.TryAdd(text, text2))
				{
					Log.Warning("texts: collision {0}", text);
				}
			}
		}

		public bool TryGetText(string key, out TextInGame value)
		{
			TryInitTexts();
			value = null;
			if (Texts == null)
			{
				return false;
			}
			string text = key.ToLowerInvariant();
			bool flag = Model._texts.TryGetValue(text, out value);
			if (!flag)
			{
				Log.Warning("text '{0}' not found", text);
			}
			return flag;
		}
	}
}
