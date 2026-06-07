using System;
using System.Xml.Linq;
using Assets.Scripts.Levels.Scores;
using ModApi.Common.Extensions;
using ModApi.Levels;
using ModApi.Levels.Scores;

namespace Assets.Scripts.Levels
{
	public class LevelData : ILevelData
	{
		public string Category { get; }

		public string ContractId { get; }

		public string Description { get; }

		public string DisplayName { get; }

		public string FlightStateId { get; }

		public string Icon { get; }

		public string Id { get; }

		public string LaunchCraftId { get; private set; }

		public LevelType LevelType { get; }

		public LevelScoreData ScoreData { get; }

		ILevelScoreData ILevelData.ScoreData => ScoreData;

		public string Script { get; }

		public string TutorialId { get; }

		public LevelData(XElement xml)
		{
			if (xml == null)
			{
				throw new ArgumentNullException("xml");
			}
			Id = (string)xml.Attribute("id");
			FlightStateId = ((string)xml.Attribute("flightStateId")) ?? Id;
			LaunchCraftId = ((string)xml.Attribute("launchCraftId")) ?? null;
			DisplayName = (string)xml.Attribute("displayName");
			Script = (string)xml.Attribute("script");
			LevelType = xml.GetEnumAttribute("type", LevelType.Unknown);
			Category = (string)xml.Attribute("category");
			Icon = (string)xml.Attribute("icon");
			ContractId = (string)xml.Attribute("contractId");
			TutorialId = (string)xml.Attribute("tutorialId");
			Description = (string)xml.Element("Description");
			Description = Description.Replace("\\n", "\n");
			ScoreData = new LevelScoreData(this, xml.Element("Scores"));
		}
	}
}
