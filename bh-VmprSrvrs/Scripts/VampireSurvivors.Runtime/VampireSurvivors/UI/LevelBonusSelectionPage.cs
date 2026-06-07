using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI
{
	public class LevelBonusSelectionPage : BaseUIPage
	{
		[CompilerGenerated]
		private sealed class _003CShowRoutine_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LevelBonusSelectionPage _003C_003E4__this;

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
			public _003CShowRoutine_003Ed__25(int _003C_003E1__state)
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
		private sealed class _003CWaitAndSelect_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LevelBonusSelectionPage _003C_003E4__this;

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
			public _003CWaitAndSelect_003Ed__27(int _003C_003E1__state)
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
		private RectTransform _Container;

		[SerializeField]
		private GameObject _WeaponPrefab;

		[SerializeField]
		private RectTransform _Panel;

		[SerializeField]
		private RectTransform _SkipButton;

		[SerializeField]
		private SpriteReel _LeftBanner;

		[SerializeField]
		private SpriteReel _RightBanner;

		[SerializeField]
		private UISpriteAnimation _VFX;

		private DataManager _dataManager;

		private Dictionary<WeaponType, List<WeaponData>> _weapons;

		private LevelBonusSelectionItem _currentSelected;

		private PowerUpType _currentType;

		private List<LevelBonusSelectionItem> _spawned;

		private VampireSurvivors.Objects.Characters.CharacterController _targetCharacter;

		[Inject]
		private void Construct(DataManager data)
		{
		}

		private void OnLevelBonusSkippedRemotely()
		{
		}

		private void OnLevelUpBonusRemotely(OnlineSignals.SelectLevelUpBonus bonus)
		{
		}

		protected void OnDestroy()
		{
		}

		public void SetSelected(LevelBonusSelectionItem item)
		{
		}

		public void Skip()
		{
		}

		public void ConfirmBonus(LevelBonusSelectionItem item)
		{
		}

		private void ExecuteLevelUpBonus(PowerUpType item)
		{
		}

		private void ExecuteSkip()
		{
		}

		private void ApplyChosenBonus(PowerUpType powerUpType)
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CShowRoutine_003Ed__25))]
		private IEnumerator ShowRoutine()
		{
			return null;
		}

		private void Populate()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndSelect_003Ed__27))]
		private IEnumerator WaitAndSelect()
		{
			return null;
		}

		private void SpawnItem(PowerUpType p)
		{
		}

		private void Clear()
		{
		}
	}
}
