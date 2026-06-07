using System;
using System.Collections.Generic;
using Gh.Tk.Story;

namespace Gh.Tk
{
	[PersistenceOptIn]
	public class GazetteManager : IPersistable, ICustomSaveState
	{
		public static int minDeliveryHour;

		public static int maxDeliveryHour;

		public List<string> globalPrices;

		public Dictionary<string, List<string>> globalSideStoryLists;

		public List<GazetteMainStory> globalMainStories;

		public List<string> prices;

		public Dictionary<string, List<string>> levelSideStoryLists;

		public List<GazetteMainStory> mainStories;

		private const int _sideStoryMax = 3;

		[PersistenceOptIn]
		public List<GazetteMainStory> _usedStories;

		[PersistenceOptIn]
		public List<string> _usedPrices;

		[PersistenceOptIn]
		public List<string> _usedSideStories;

		private const int CUSTOM_SIDE_STORY_CHANCE = 20;

		[PersistenceOptIn]
		private float _lastGazetteDayF;

		private float _dayFBetweenGazettes;

		private Queue<UINotificationData> _scheduledGazettes;

		private int[] _gazetteDeliveryHours;

		public static GazetteManager Instance => null;

		public static bool CanSpawnGazette => false;

		[PersistenceOptIn]
		public int IssueNumber { get; set; }

		[PersistenceOptIn]
		public List<string> CustomRandomSideStories { get; set; }

		private GazetteManager()
		{
		}

		~GazetteManager()
		{
		}

		public void Init()
		{
		}

		public void Init(string level)
		{
		}

		public UINotificationData GenerateGazette()
		{
			return null;
		}

		public UINotificationData BuildGazetteNotification(string topStoryTitleKey, string topStoryTextKey, string topStoryImage = null, string priceOverrideKey = null, string[] sideStoriesOverrideKeys = null, ActiveStory story = null)
		{
			return null;
		}

		private string ChoosePriceLocalizedKey()
		{
			return null;
		}

		private string ChooseSideStoryKey(ActiveStory story)
		{
			return null;
		}

		private string PickStoryFromLists(Dictionary<string, List<string>> sideStoryLists)
		{
			return null;
		}

		public void ScheduleGazette(UINotificationData gazetteNotification)
		{
		}

		private void OnHourChanged(object sender, EventArgs e)
		{
		}

		public void SpawnGazette(UINotificationData scheduledGazette)
		{
		}

		public virtual void SaveState(IDataStore data)
		{
		}

		public virtual void RestoreState(IDataStore data)
		{
		}
	}
}
