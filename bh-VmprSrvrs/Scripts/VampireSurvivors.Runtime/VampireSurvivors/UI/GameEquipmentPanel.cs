using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI
{
	public class GameEquipmentPanel : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CWaitAndFormat_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameEquipmentPanel _003C_003E4__this;

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
			public _003CWaitAndFormat_003Ed__28(int _003C_003E1__state)
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
		private sealed class _003CWaitAndRebuild_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameEquipmentPanel _003C_003E4__this;

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
			public _003CWaitAndRebuild_003Ed__34(int _003C_003E1__state)
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

		private static Dictionary<VampireSurvivors.Objects.Characters.CharacterController, GameEquipmentPanel> _panels;

		[SerializeField]
		private Image _CharacterImage;

		[SerializeField]
		private Image _CharacterDeadImage;

		[FormerlySerializedAs("_weaponPrefab")]
		[SerializeField]
		private GameObject _WeaponPrefab;

		[FormerlySerializedAs("_weaponContainer")]
		[SerializeField]
		private RectTransform _WeaponContainer;

		[FormerlySerializedAs("_accessoryPrefab")]
		[SerializeField]
		private GameObject _AccessoryPrefab;

		[FormerlySerializedAs("_accessoryContainer")]
		[SerializeField]
		private RectTransform _AccessoryContainer;

		private SignalBus _signalBus;

		private PlayerOptions _playerOptions;

		private DataManager _data;

		private readonly List<GameEquipmentPanelItem> _spawnedWeaponSlots;

		private readonly List<GameEquipmentPanelItem> _spawnedAccessorySlots;

		private List<WeaponType> _extraWeapons;

		private const int MaxAccessorySlots = 6;

		private bool _shouldUpdateFormatting;

		private CharacterType _character;

		private VampireSurvivors.Objects.Characters.CharacterController _characterController;

		private bool _showSprite;

		[Inject]
		private void Construct(SignalBus signal, PlayerOptions playerOptions, DataManager dataManager)
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		public static void ClearPanels()
		{
		}

		public void AddExtra(WeaponType weaponType)
		{
		}

		public List<WeaponType> GetExtraWeapons()
		{
			return null;
		}

		public void Rebuild()
		{
		}

		public void Initialize(VampireSurvivors.Objects.Characters.CharacterController characterController, bool showSprite)
		{
		}

		private void OnEnable()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndFormat_003Ed__28))]
		private IEnumerator WaitAndFormat()
		{
			return null;
		}

		private void Reset()
		{
		}

		private void ClearWeaponSlots()
		{
		}

		private void ClearAccessorySlots()
		{
		}

		private void CreateWeaponSlots()
		{
		}

		private void RebuildWeaponSlots()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndRebuild_003Ed__34))]
		private IEnumerator WaitAndRebuild()
		{
			return null;
		}

		private void AddWeapon(GameplaySignals.WeaponAddedToCharacterSignal sig)
		{
		}

		private void OnCharacterRemovedWeapon(GameplaySignals.WeaponRemovedFromCharacterSignal sig)
		{
		}

		private void CreateAccessorySlots()
		{
		}

		private void RebuildAccessorySlots()
		{
		}

		private void AddAccessory(GameplaySignals.AccessoryAddedToCharacterSignal sig)
		{
		}

		private void OnCharacterRemovedAccessory(GameplaySignals.AccessoryRemovedFromCharacterSignal sig)
		{
		}

		public static GameEquipmentPanel GetPanelForCharacter(VampireSurvivors.Objects.Characters.CharacterController c)
		{
			return null;
		}

		public void BlockWeapon(Weapon weapon, bool blocked)
		{
		}

		public void DisableWeaponIcon(Weapon weapon, bool disable)
		{
		}
	}
}
