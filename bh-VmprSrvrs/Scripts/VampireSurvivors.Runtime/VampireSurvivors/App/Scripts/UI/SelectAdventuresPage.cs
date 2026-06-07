using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Integration.UnityUI;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors.App.Scripts.UI
{
	public class SelectAdventuresPage : BaseUIPage
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass41_0
		{
			public SelectAdventuresPage _003C_003E4__this;

			public GameObject bg;

			internal void _003CAnimate_003Eb__0()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CAnimate_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SelectAdventuresPage _003C_003E4__this;

			private _003C_003Ec__DisplayClass41_0 _003C_003E8__1;

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
			public _003CAnimate_003Ed__41(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CMoveBackgroundIntoPlaceInANiceFancyWay_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Transform bg;

			public SelectAdventuresPage _003C_003E4__this;

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
			public _003CMoveBackgroundIntoPlaceInANiceFancyWay_003Ed__42(int _003C_003E1__state)
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
		private GameObject _AdventureItemPrefab;

		[SerializeField]
		private RectTransform _AdventureItemContainer;

		[SerializeField]
		private AdventureInfoPanel _InfoPanel;

		[SerializeField]
		private Button _ConfirmButton;

		[SerializeField]
		private GameObject _CoinsUI;

		[SerializeField]
		private GameObject _AdventureStarsCurrencyUI;

		[SerializeField]
		private PixelateEffect _pixelEffect;

		[SerializeField]
		private MainMenuBackgroundManager _MainMenuBackgroundManager;

		[SerializeField]
		private bool DoPixelEffect;

		[SerializeField]
		private AscensionPanel _AscensionPanel;

		[SerializeField]
		private Image _PortraitBreaker;

		[SerializeField]
		private GameObject _PortraitAscensionGroup;

		[SerializeField]
		private RectTransform _CustomBackgroundHolderOnMainMenu;

		[SerializeField]
		private MainMenuPage _MainMenuPage;

		[SerializeField]
		private AchievementPopup _AchievementPopup;

		private AdventureManager _adventureManager;

		private PlayerOptions _playerOptions;

		private DataManager _dataManager;

		private MainMenuBackgroundFactory _backgroundFactory;

		private AdventureProgressManager _adventureProgressManager;

		private AchievementManager _achievementManager;

		private LobbiesManager _lobbiesManager;

		private List<AdventureItemUI> _spawned;

		private AdventureItemUI _selected;

		private AdventureItemUI _ascending;

		private TutorialPopup _spawnedTutorialPopup;

		private RewiredStandaloneInputModule InputModule => null;

		public AdventureManager AdventureManager => null;

		public DataManager DataManager => null;

		public PlayerOptions PlayerOptions => null;

		[Inject]
		private void Construct(AdventureManager adventureManager, PlayerOptions playerOptions, DataManager data, MainMenuBackgroundFactory backgroundFactory, AdventureProgressManager adventureProgressManager, AchievementManager achievementManager, LobbiesManager lobbiesManager)
		{
		}

		protected override void Awake()
		{
		}

		public void SelectAdventure(AdventureItemUI item)
		{
		}

		public void SetAscendingAdventureItem(AdventureItemUI item)
		{
		}

		private void OnAscended(bool result)
		{
		}

		public GameObject GetBackground(AdventureType adventureType)
		{
			return null;
		}

		public void ConfirmAdventure()
		{
		}

		[IteratorStateMachine(typeof(_003CAnimate_003Ed__41))]
		private IEnumerator Animate()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CMoveBackgroundIntoPlaceInANiceFancyWay_003Ed__42))]
		private IEnumerator MoveBackgroundIntoPlaceInANiceFancyWay(Transform bg)
		{
			return null;
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		private void QueueAchievements(List<AchievementData> achievementsUnlocked)
		{
		}

		private void ShowTutorialPopup()
		{
		}

		private void OnTutorialFinished()
		{
		}

		protected override void OnHideStart(GameObject g)
		{
		}

		private void Populate()
		{
		}

		protected override void Update()
		{
		}

		private void GenerateNavigation()
		{
		}

		protected override void OnHideFinish(GameObject g)
		{
		}

		private void ClearItems()
		{
		}

		protected override void OnEnterPressed()
		{
		}

		public void HandleDLCPerPlatform()
		{
		}

		private void UpdateCompletionPanelInfo(AdventureType adventureType)
		{
		}

		private void UpdateAdventureStatesBasedOnHideToggle()
		{
		}
	}
}
