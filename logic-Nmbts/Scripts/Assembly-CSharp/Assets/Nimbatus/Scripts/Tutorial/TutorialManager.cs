using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.Achievements;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Tutorial
{
	public class TutorialManager : GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>
	{
		[HideInInspector]
		public bool FirstVisit;

		[HideInInspector]
		public bool ExitingTutorial;

		[HideInInspector]
		public ETutorialDifficulty LastTutorialDifficulty;

		private int _subtutorialIndex = -1;

		[HideInInspector]
		public List<Tutorial> Tutorials = new List<Tutorial>();

		private Dictionary<ETutorialType, bool> _tutorialStatus = new Dictionary<ETutorialType, bool>();

		private float _tutorialStartTime;

		[HideInInspector]
		public Tutorial ActiveTutorial { get; private set; }

		[HideInInspector]
		public Subtutorial Subtutorial
		{
			get
			{
				if (ActiveTutorial != null)
				{
					return ActiveTutorial.Subtutorials[_subtutorialIndex];
				}
				return null;
			}
		}

		internal override string Filename
		{
			get
			{
				return "Tutorial.xml";
			}
		}

		protected override void PreLoad()
		{
			Tutorials = Resources.LoadAll<Tutorial>("Tutorial").ToList();
			_tutorialStatus = new Dictionary<ETutorialType, bool>();
			foreach (Tutorial tutorial in Tutorials)
			{
				_tutorialStatus.Add(tutorial.TutorialType, false);
			}
		}

		public Tutorial GetTutorial(ETutorialType tutorial)
		{
			return Tutorials.FirstOrDefault((Tutorial t) => t.TutorialType == tutorial);
		}

		public bool IsTutorialCompleted(ETutorialType tutorial)
		{
			if (_tutorialStatus.ContainsKey(tutorial))
			{
				return _tutorialStatus[tutorial];
			}
			return false;
		}

		public void SetTutorial(ETutorialType tutorial)
		{
			TerminateTutorial();
			ActiveTutorial = GetTutorial(tutorial);
			StartSubtutorial();
		}

		public bool HasNextSubtutorial()
		{
			return _subtutorialIndex + 1 < ActiveTutorial.Subtutorials.Count;
		}

		public void StartSubtutorial()
		{
			if (!HasNextSubtutorial())
			{
				TutorialSuccessful();
				return;
			}
			_subtutorialIndex++;
			FirstVisit = true;
			_tutorialStartTime = Time.time;
			SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.EnforceTutorialItemRules(Subtutorial);
		}

		public void TutorialSuccessful()
		{
			SaveTutorial();
			TerminateTutorial();
		}

		public void SaveTutorial()
		{
			_tutorialStatus[ActiveTutorial.TutorialType] = true;
			SaveManager.StoreSaveGame(false, false);
			if (_tutorialStatus.Values.All((bool t) => t))
			{
				BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.KnowledgeIsPower);
			}
		}

		public void TerminateTutorial()
		{
			_subtutorialIndex = -1;
			FirstVisit = false;
			if (ActiveTutorial != null)
			{
				LastTutorialDifficulty = ActiveTutorial.Difficulty;
				ActiveTutorial = null;
			}
			ExitingTutorial = true;
		}

		protected override void LoadFromFile(TutorialSaveData data)
		{
			if (data.TutorialStatus == null)
			{
				return;
			}
			foreach (TutorialState item in data.TutorialStatus)
			{
				if (_tutorialStatus.ContainsKey(item.TutorialType))
				{
					_tutorialStatus[item.TutorialType] = item.IsCompleted;
				}
			}
		}

		protected override TutorialSaveData SaveToFile()
		{
			TutorialSaveData tutorialSaveData = new TutorialSaveData();
			tutorialSaveData.TutorialStatus = new List<TutorialState>();
			foreach (KeyValuePair<ETutorialType, bool> item in _tutorialStatus)
			{
				tutorialSaveData.TutorialStatus.Add(new TutorialState(item.Key, item.Value));
			}
			return tutorialSaveData;
		}
	}
}
