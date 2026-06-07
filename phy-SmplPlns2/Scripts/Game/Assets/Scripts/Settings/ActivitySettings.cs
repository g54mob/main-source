using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Assets.Scripts.Settings
{
	public class ActivitySettings
	{
		private Dictionary<string, float> _activityScores = new Dictionary<string, float>();

		private List<string> _unlocked;

		public bool HasUnsavedChanges { get; private set; }

		public IReadOnlyList<string> Unlocked => _unlocked;

		public float? GetActivityScore(string activityId)
		{
			if (_activityScores.ContainsKey(activityId))
			{
				return _activityScores[activityId];
			}
			return null;
		}

		public void LoadSettingsFromXml(XElement xml)
		{
			_unlocked = new List<string>();
			foreach (XElement item in xml?.Element("CompletedActivities")?.Elements("Activity") ?? Array.Empty<XElement>())
			{
				string stringAttribute = item.GetStringAttribute("id");
				if (!string.IsNullOrEmpty(stringAttribute))
				{
					float floatAttribute = item.GetFloatAttribute("score");
					_activityScores[stringAttribute] = floatAttribute;
				}
			}
			foreach (XElement item2 in xml?.Element("UnlockedActivities")?.Elements("Activity") ?? Array.Empty<XElement>())
			{
				string stringAttribute2 = item2.GetStringAttribute("id");
				if (!string.IsNullOrEmpty(stringAttribute2))
				{
					_unlocked.Add(stringAttribute2);
				}
			}
			HasUnsavedChanges = false;
		}

		public XElement SaveXml(XElement xml)
		{
			xml.Add(new XElement("CompletedActivities", _activityScores.Select((KeyValuePair<string, float> x) => new XElement("Activity", new XAttribute("id", x.Key), new XAttribute("score", x.Value)))));
			xml.Add(new XElement("UnlockedActivities", _unlocked.Select((string x) => new XElement("Activity", new XAttribute("id", x)))));
			HasUnsavedChanges = false;
			return xml;
		}

		public void SetActivityScore(string activityId, float score)
		{
			_activityScores[activityId] = score;
			HasUnsavedChanges = true;
		}

		public void SetActivityUnlocked(string activityId)
		{
			if (!_unlocked.Contains(activityId))
			{
				_unlocked.Add(activityId);
				HasUnsavedChanges = true;
			}
		}
	}
}
