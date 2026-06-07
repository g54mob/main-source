using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class AchievementsPage : BaseUIPage
	{
		[CompilerGenerated]
		private sealed class _003CWaitAndReformat_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AchievementsPage _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWaitAndReformat_003Ed__32(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private GameObject _AchievementPrefab;

		[SerializeField]
		private TextMeshProUGUI _Description;

		[SerializeField]
		private TextMeshProUGUI _UnlockDescription;

		[SerializeField]
		private TextMeshProUGUI _Title;

		[SerializeField]
		private TextMeshProUGUI _ObtainedText;

		[SerializeField]
		private Image _InfoBackground;

		[SerializeField]
		private Localize _DescriptionText;

		[SerializeField]
		private Image _Icon;

		[SerializeField]
		private Image _IconBg;

		[SerializeField]
		private Image _MoneyIcon;

		[SerializeField]
		private TickBoxUI _HideCompleted;

		[SerializeField]
		private GameObject _InfoPanel;

		private PlayerOptions _playerOptions;

		private DataManager _dataManager;

		private AchievementManager _achievementManager;

		private AdventureManager _adventureManager;

		private List<GameObject> _spawned;

		private List<AchievementType> _baseGameUnlocked;

		[Inject]
		private void Construct(AchievementManager achievements, PlayerOptions playerOptions, DataManager dataManager, AdventureManager adventureManager)
		{
		}

		protected override void Awake()
		{
		}

		public void SelectAdventureProgress(AdventureAchievementType type, AchievementData achievementData)
		{
		}

		public void SelectAchievement(AchievementType type, AchievementData bad)
		{
		}

		public void Reset()
		{
		}

		public void ToggleCompleted()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		protected override void OnHideStart(GameObject g)
		{
		}

		private void Populate()
		{
		}

		private void UpdateInfoDisplay(AchievementData bad)
		{
		}

		private void PopulateAdventureProgress()
		{
		}

		private void SpawnAdventureProgressUnlock(AdventureAchievementType type, AchievementData data)
		{
		}

		private void PopulateBaseGameAchievements()
		{
		}

		private int GetValidUnlockedAchievementCount()
		{
			return 0;
		}

		[IteratorStateMachine(typeof(_003CWaitAndReformat_003Ed__32))]
		private IEnumerator WaitAndReformat()
		{
			return null;
		}

		private void SpawnAchievement(AchievementType type, AchievementData data)
		{
		}
	}
}
