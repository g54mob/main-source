using System;
using System.IO;
using System.Xml;
using ModApi.State;

namespace Assets.Scripts.State
{
	public class GameStateInfo
	{
		public string CompanyName { get; set; }

		public int? CraftsInFlight { get; internal set; }

		public DateTime? CreatedDateTime { get; set; }

		public double? FlightStateTime { get; internal set; }

		public string GameStateId { get; }

		public GameStateMode? GameStateMode { get; set; }

		public DateTime? LastModifiedDateTime { get; set; }

		public long? Money { get; set; }

		public string PlanetarySystemXml { get; internal set; }

		public int? TechNodeUnlocked { get; set; }

		public int? TechPoints { get; set; }

		public GameStateInfo(string gameStateId)
		{
			GameStateId = gameStateId;
		}

		public static GameStateInfo Load(string gameStateId)
		{
			string gameStateTagPath = Game.Instance.GameStateManager.GetGameStateTagPath(gameStateId);
			string path = gameStateTagPath + "/GameState.xml";
			string path2 = gameStateTagPath + "/FlightState.xml";
			if (!File.Exists(path))
			{
				return null;
			}
			GameStateInfo gameStateInfo = new GameStateInfo(gameStateId);
			bool flag = false;
			using (FileStream input = File.OpenRead(path))
			{
				using XmlReader xmlReader = XmlReader.Create(input);
				while (xmlReader.Read() && !flag)
				{
					if (!xmlReader.IsStartElement())
					{
						continue;
					}
					string localName = xmlReader.LocalName;
					if (!(localName == "GameState"))
					{
						if (localName == "Career")
						{
							if (xmlReader.MoveToAttribute("money"))
							{
								gameStateInfo.Money = xmlReader.ReadContentAsLong();
							}
							flag = true;
						}
						continue;
					}
					if (xmlReader.MoveToAttribute("companyName"))
					{
						gameStateInfo.CompanyName = xmlReader.ReadContentAsString();
					}
					if (xmlReader.MoveToAttribute("mode"))
					{
						gameStateInfo.GameStateMode = (GameStateMode)Enum.Parse(typeof(GameStateMode), xmlReader.ReadContentAsString());
					}
					if (xmlReader.MoveToAttribute("lastModifiedTime"))
					{
						gameStateInfo.LastModifiedDateTime = xmlReader.ReadContentAsDateTime();
					}
					if (xmlReader.MoveToAttribute("createdTime"))
					{
						gameStateInfo.CreatedDateTime = xmlReader.ReadContentAsDateTime();
					}
					if (gameStateInfo.GameStateMode.HasValue && gameStateInfo.GameStateMode != ModApi.State.GameStateMode.Career)
					{
						flag = true;
					}
				}
			}
			if (File.Exists(path2))
			{
				bool flag2 = false;
				using FileStream input2 = File.OpenRead(path2);
				using XmlReader xmlReader2 = XmlReader.Create(input2);
				while (xmlReader2.Read() && !flag2)
				{
					if (!xmlReader2.IsStartElement())
					{
						continue;
					}
					switch (xmlReader2.LocalName)
					{
					case "FlightState":
						if (xmlReader2.MoveToAttribute("time"))
						{
							gameStateInfo.FlightStateTime = xmlReader2.ReadContentAsDouble();
						}
						break;
					case "PlanetarySystem":
						gameStateInfo.PlanetarySystemXml = xmlReader2.ReadOuterXml();
						break;
					case "Nodes":
						if (xmlReader2.ReadToDescendant("Craft"))
						{
							int num = 1;
							while (xmlReader2.ReadToNextSibling("Craft"))
							{
								num++;
							}
							gameStateInfo.CraftsInFlight = num;
						}
						flag = true;
						break;
					}
				}
			}
			return gameStateInfo;
		}
	}
}
