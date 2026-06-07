using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI
{
	public class CharacterItemUI : SelectableUI
	{
		[CompilerGenerated]
		private sealed class _003CWaitAndSelect_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CharacterItemUI _003C_003E4__this;

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
			public _003CWaitAndSelect_003Ed__24(int _003C_003E1__state)
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
		private TextMeshProUGUI _CharacterName;

		[SerializeField]
		private Image _CharacterIcon;

		[SerializeField]
		private Image _WeaponIcon;

		[SerializeField]
		private Image _ShadowIcon;

		[SerializeField]
		private Image _LockIcon;

		[SerializeField]
		private Image _Background;

		[SerializeField]
		private Image _Flash;

		private ICharacterSelector _page;

		private UIUnlockStates? _forcedUnlockState;

		private bool _isTaken;

		private bool _voidWeapon;

		private DataManager _dataManager;

		private PlayerOptions _playerOptions;

		private Color _highlightColor;

		private readonly float _iconUIScale;

		private CharacterItem _charItem;

		private Color _backgroundColor;

		public CharacterItem CharacterItem => null;

		public CharacterType Type => default(CharacterType);

		public void SetData(ICharacterSelector page, DataManager dataManager, PlayerOptions playerOptions, CharacterItem charItem, bool useDefaultSkin = false)
		{
		}

		public void Refresh(bool setInfoPanel = true)
		{
		}

		public void AnimateIn()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndSelect_003Ed__24))]
		private IEnumerator WaitAndSelect()
		{
			return null;
		}

		public void SetTakenByAnotherPlayer(bool taken, Color highlightColor)
		{
		}

		public bool IsTakenByAnotherPlayer()
		{
			return false;
		}

		public void SetSelected()
		{
		}

		public void UnSelect()
		{
		}

		private Sprite GetBackgroundSprite()
		{
			return null;
		}

		public bool IsAvailable()
		{
			return false;
		}

		public bool IsCharAvailable()
		{
			return false;
		}

		public bool IsSkinAvailable()
		{
			return false;
		}

		public bool IsPurchasable()
		{
			return false;
		}

		public bool IsCharPurchasable()
		{
			return false;
		}

		public bool IsSkinPurchasable()
		{
			return false;
		}

		public bool IsUnlockable()
		{
			return false;
		}

		public bool IsCharUnlockable()
		{
			return false;
		}

		public bool IsSkinUnlockable()
		{
			return false;
		}

		public float GetPrice()
		{
			return 0f;
		}

		private float CharMarkup()
		{
			return 0f;
		}

		public void SetInfoPanel()
		{
		}

		public bool HasForcedUnlockState()
		{
			return false;
		}

		public void SetForcedUnlockState(UIUnlockStates? state)
		{
		}

		public bool IsUnlockableAndSecret()
		{
			return false;
		}

		public Sprite GetCharSprite(CharacterType charType, CharacterData charData)
		{
			return null;
		}

		private void UpdateVisualState()
		{
		}

		private void SetVisualStateUnlockable()
		{
		}

		private void SetVisualStatePurchasable()
		{
		}

		private void SetVisualStateAvailable()
		{
		}

		private void SetIconSizes()
		{
		}

		private void SetCharacterSprite()
		{
		}

		protected override void OnSelected()
		{
		}

		private void SetCharacterName()
		{
		}

		private void SetWeaponIconSprite()
		{
		}
	}
}
