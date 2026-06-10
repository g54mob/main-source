using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.Tools;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	[FVSerializableKey("HumanoidInfo", "WorkerInfo")]
	public class HumanoidInfo : CharacterInfoBase
	{
		[SerializeField]
		private int birthday;

		[SerializeField]
		private string originTown;

		[SerializeField]
		private float religiousAlignment;

		[SerializeField]
		private string backgroundId;

		[SerializeField]
		private int backgorundContextLink;

		[SerializeField]
		private string backStoryId;

		[SerializeField]
		private string pseudonymId;

		[SerializeField]
		private List<WorkerCharacteristicType> ignoredTypes;

		private Background background;

		private BackStory backStory;

		public int Birthday => birthday;

		public string OriginTown
		{
			get
			{
				return originTown;
			}
			set
			{
				originTown = value;
			}
		}

		public float ReligiousAlignment
		{
			get
			{
				return religiousAlignment;
			}
			set
			{
				religiousAlignment = value;
			}
		}

		public string BackgroundId => backgroundId;

		public string BackStoryId => backStoryId;

		public Background Background => background = ((background == null && backgroundId != string.Empty) ? Repository<BackgroundRepository, Background>.Instance.GetByID(backgroundId) : background);

		public BackStory BackStory => backStory = ((backStory == null && backStoryId != string.Empty) ? Repository<BackStoryRepository, BackStory>.Instance.GetByID(backStoryId) : backStory);

		public string PseudonymId => pseudonymId;

		public List<WorkerCharacteristicType> IgnoredTypes => ignoredTypes;

		public int BackgroundContextLink => backgorundContextLink = ((backgorundContextLink == -1) ? UnityEngine.Random.Range(1, MonoSingleton<LocalizationController>.Instance.GetKeyGroupCount("background_context_link_0")) : backgorundContextLink);

		public HumanoidInfo(BodyType bodyType, int age, int birthday, float height, float weightCoefficient, string originTown, string backgroundId, string backstoryId, float religiousAlignment)
			: base(Repository<NameRepository, Names>.Instance.GetFirstName(bodyType), Repository<NameRepository, Names>.Instance.GetLastName(), bodyType, age, height, weightCoefficient, new WorkerPhysicalLook())
		{
			this.birthday = birthday;
			this.originTown = originTown;
			ReligiousAlignment = religiousAlignment;
			this.backgroundId = backgroundId;
			backStoryId = backstoryId;
			pseudonymId = string.Empty;
			ignoredTypes = new List<WorkerCharacteristicType>();
			backgorundContextLink = -1;
			background = null;
			backStory = null;
		}

		public string GetDefaultDisplayName()
		{
			return base.FirstName;
		}

		public void SetIgnoredTypes(List<WorkerCharacteristicType> ignored)
		{
			ignoredTypes = ignored;
		}

		public void SetPseudonym(string id)
		{
			if (string.IsNullOrEmpty(id) || id == "none")
			{
				pseudonymId = string.Empty;
				return;
			}
			pseudonymId = id;
			Pseudonym byID = Repository<PseudonymRepository, Pseudonym>.Instance.GetByID(pseudonymId);
			ReligiousAlignment = Mathf.Clamp01(religiousAlignment + byID.ReligiousAlignment);
		}

		public void SetBackground(Background background)
		{
			backgroundId = background.GetID();
			this.background = background;
			ReligiousAlignment = Mathf.Clamp01(religiousAlignment + background.ReligiousAlignment);
		}

		public void SetBackStory(BackStory backStory)
		{
			backStoryId = backStory.GetID();
			this.backStory = backStory;
			ReligiousAlignment = Mathf.Clamp01(religiousAlignment + backStory.ReligiousAlignment);
		}

		public override string GetPhysicalLookKey()
		{
			return "worker_" + base.BodyType.ToString().ToLower();
		}

		public override string GetFullName()
		{
			return base.FirstName + " " + base.LastName;
		}

		public string GetBirthdayString()
		{
			int daysInSeason = GlobalSaveController.CurrentVillageData.DateAndTime.DaysInSeason;
			int num = birthday % daysInSeason;
			int num2 = (int)Math.Floor((float)birthday / (float)daysInSeason);
			if (num == 0)
			{
				num = daysInSeason;
				num2 = Mathf.Clamp(num2 - 1, 0, GlobalSaveController.CurrentVillageData.DateAndTime.SeasonsCount);
			}
			List<Season> seasons = GlobalSaveController.CurrentVillageData.DateAndTime.Seasons;
			LocalizationController instance = MonoSingleton<LocalizationController>.Instance;
			return TextFormatting.FormatBirthdayText(season: instance.GetText("general_" + seasons[num2 % seasons.Count].Name), text: instance.GetText("birthday_pattern"), birthday: num, age: base.Age);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("birthday", birthday);
			serializer.Write("originTown", originTown);
			serializer.Write("religiousAlignment", religiousAlignment);
			serializer.Write("backgroundId", backgroundId);
			serializer.Write("backgorundContextLink", backgorundContextLink);
			serializer.Write("backStoryId", backStoryId);
			serializer.Write("pseudonymId", pseudonymId);
			serializer.WriteEnum("ignoredTypes", (IList<WorkerCharacteristicType>)ignoredTypes);
		}

		public HumanoidInfo(FVDeserializer deserializer)
			: base(deserializer)
		{
			birthday = deserializer.ReadInt("birthday");
			originTown = deserializer.ReadString("originTown");
			religiousAlignment = deserializer.ReadFloat("religiousAlignment");
			backgroundId = deserializer.ReadString("backgroundId");
			backgorundContextLink = deserializer.ReadInt("backgorundContextLink");
			backStoryId = deserializer.ReadString("backStoryId");
			pseudonymId = deserializer.ReadString("pseudonymId");
			ignoredTypes = deserializer.ReadEnumList<WorkerCharacteristicType>("ignoredTypes");
		}
	}
}
