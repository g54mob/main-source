using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Multiplayer.Extensions;
using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework
{
	public class NetworkedActivityScoreTiers
	{
		public enum ScoreDisplayType
		{
			Default = 0,
			Time = 1
		}

		public enum ScoreSortingMode : byte
		{
			Default = 1,
			Reversed = 2
		}

		public class ScoreTier
		{
			public float Score { get; set; }

			public int Tier { get; set; }
		}

		public string DisplayFormat { get; private set; }

		public ScoreDisplayType DisplayType { get; private set; }

		public ScoreSortingMode SortingMode { get; private set; }

		public List<ScoreTier> Tiers { get; private set; } = new List<ScoreTier>();

		public static NetworkedActivityScoreTiers LoadFromNetwork(Reader reader)
		{
			NetworkedActivityScoreTiers networkedActivityScoreTiers = new NetworkedActivityScoreTiers();
			networkedActivityScoreTiers.SortingMode = reader.ReadEnum<ScoreSortingMode>();
			networkedActivityScoreTiers.DisplayType = reader.ReadEnum<ScoreDisplayType>();
			networkedActivityScoreTiers.DisplayFormat = reader.ReadStringAllocated();
			byte b = reader.ReadUInt8Unpacked();
			for (int i = 0; i < b; i++)
			{
				float score = reader.ReadSingle();
				networkedActivityScoreTiers.Tiers.Add(new ScoreTier
				{
					Tier = i + 1,
					Score = score
				});
			}
			return networkedActivityScoreTiers;
		}

		public static NetworkedActivityScoreTiers LoadFromXml(XElement xml)
		{
			NetworkedActivityScoreTiers networkedActivityScoreTiers = new NetworkedActivityScoreTiers();
			networkedActivityScoreTiers.SerializeRead(xml);
			return networkedActivityScoreTiers;
		}

		public int CompareScores(float a, float b)
		{
			if (Math.Abs(a - b) < 1E-05f)
			{
				return 0;
			}
			switch (SortingMode)
			{
			case ScoreSortingMode.Default:
				if (!(a < b))
				{
					return 1;
				}
				return -1;
			case ScoreSortingMode.Reversed:
				if (!(a < b))
				{
					return -1;
				}
				return 1;
			default:
				throw new NotImplementedException($"SortingMode '{SortingMode}' is not supported.");
			}
		}

		public string FormatScore(float score)
		{
			string text = string.Empty;
			switch (DisplayType)
			{
			case ScoreDisplayType.Time:
			{
				TimeSpan timeSpan = TimeSpan.FromSeconds(score);
				string arg = $"{(int)timeSpan.TotalMinutes}:{timeSpan.Seconds:00}";
				text = string.Format(DisplayFormat, arg);
				break;
			}
			case ScoreDisplayType.Default:
				text = string.Format(DisplayFormat, score);
				break;
			}
			return text.Replace("[s]", ((int)score != 1) ? "s" : string.Empty);
		}

		public int GetScoreTier(float score)
		{
			int num = 0;
			foreach (ScoreTier tier in Tiers)
			{
				if (CompareScores(score, tier.Score) >= 0)
				{
					num = Mathf.Max(tier.Tier, num);
				}
			}
			return num;
		}

		public void SerializeWrite(Writer writer)
		{
			writer.WriteEnum(SortingMode);
			writer.WriteEnum(DisplayType);
			writer.WriteString(DisplayFormat);
			writer.WriteUInt8Unpacked((byte)Tiers.Count);
			foreach (ScoreTier tier in Tiers)
			{
				writer.WriteSingle(tier.Score);
			}
		}

		private void SerializeRead(XElement xml)
		{
			if (xml == null)
			{
				return;
			}
			SortingMode = xml.GetEnumAttribute("sortMode", ScoreSortingMode.Default);
			DisplayType = xml.GetEnumAttribute("displayType", ScoreDisplayType.Default);
			DisplayFormat = xml.GetStringAttribute("displayFormat", "{0:n0}");
			List<float> floatListAttribute = xml.GetFloatListAttribute("tiers");
			int num = 1;
			foreach (float item in floatListAttribute)
			{
				Tiers.Add(new ScoreTier
				{
					Tier = num++,
					Score = item
				});
			}
		}
	}
}
