using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Connection;
using Coherence.Entities;
using Coherence.Log;
using Coherence.Toolkit;
using Coherence.Toolkit.ReplicationServer;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Signals;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors;

public class OnlineStageManager : MonoBehaviour
{
	private class GlimmerQueueEntry(CoherenceSync player, bool isActiveEquipment, int weaponIndex)
	{
		public CoherenceSync Player = player;

		public bool IsActiveEquipment = isActiveEquipment;

		public int WeaponIndex = weaponIndex;
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__216_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COpenMainArcanaPage_003Eb__216_0()
		{
			GM.Core.QueueOpenArcana(ArcanaUiType.MAIN);
		}
	}

	private sealed class _003C_003Ec__DisplayClass110_0
	{
		public OnlineLevelUpData levelUpData;

		internal unsafe void _003COnlineLevelUp_003Eb__0()
		{
			//IL_0013: Expected O, but got Ref
			object obj = default(object);
			GM.Core.AddOnlineLevelUpToQueue((OnlineLevelUpData)(&obj));
		}
	}

	private sealed class _003C_003Ec__DisplayClass115_0
	{
		public WeaponType weaponTypeValue;

		public CoherenceSync receivingCharacter;

		internal void _003CFinishLevelUp_003Eb__0()
		{
			VampireSurvivors.Objects.Characters.CharacterController component = receivingCharacter.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			GM.Core.OnlineFinishLevelUp(weaponTypeValue, component);
		}
	}

	private sealed class _003C_003Ec__DisplayClass117_0
	{
		public OnlineStageManager _003C_003E4__this;

		public ItemType itemTypeValue;

		public CoherenceSync receivingCharacter;

		internal void _003CFinishLevelUpWithItem_003Eb__0()
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			//IL_0084: Expected I, but got O
			//IL_00a3: Expected O, but got I
			OnlineStageManager onlineStageManager = _003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController component = receivingCharacter.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		}
	}

	private sealed class _003C_003Ec__DisplayClass121_0
	{
		public OnlineStageManager _003C_003E4__this;

		public int limitBreakIndex;

		public bool alwaysRandomLimitBreak;

		public CoherenceSync receivingCharacter;

		internal void _003CFinishLevelUpWithLimitBreak_003Eb__0()
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			//IL_0084: Expected I, but got O
			//IL_00a3: Expected O, but got I
			OnlineStageManager onlineStageManager = _003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController component = receivingCharacter.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		}
	}

	private sealed class _003C_003Ec__DisplayClass123_0
	{
		public OnlineStageManager _003C_003E4__this;

		public WeaponType weaponTypeValue;

		internal void _003CBanishWeaponOnline_003Eb__0()
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0070: Expected I, but got O
			//IL_008f: Expected O, but got I
			OnlineStageManager onlineStageManager = _003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		}
	}

	private sealed class _003C_003Ec__DisplayClass137_0
	{
		public WeaponType weaponTypeValue;

		public VampireSurvivors.Objects.Characters.CharacterController character;

		internal void _003CFriendshipAmuletLevelUpWeaponForCharacter_003Eb__0()
		{
			FriendshipAmulet.ApplyFriendshipAmuletLevelUp(weaponTypeValue, character);
		}
	}

	private sealed class _003C_003Ec__DisplayClass139_0
	{
		public OnlineStageManager _003C_003E4__this;

		public WeaponType weapon;

		public ItemType item;

		public int index;

		public int price;

		public VampireSurvivors.Objects.Characters.CharacterController purchasingPlayer;

		internal void _003CMerchantPurchase_003Eb__0()
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			//IL_0075: Expected I, but got O
			//IL_0094: Expected O, but got I
			OnlineStageManager onlineStageManager = _003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		}
	}

	private sealed class _003C_003Ec__DisplayClass143_0
	{
		public OnlineStageManager _003C_003E4__this;

		public bool discard;

		internal void _003CCloseItemFoundPage_003Eb__0()
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0070: Expected I, but got O
			//IL_008f: Expected O, but got I
			OnlineStageManager onlineStageManager = _003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		}
	}

	private sealed class _003C_003Ec__DisplayClass145_0
	{
		public OnlineStageManager _003C_003E4__this;

		public int selectedArcana;

		internal void _003CSelectArcana_003Eb__0()
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0070: Expected I, but got O
			//IL_008f: Expected O, but got I
			OnlineStageManager onlineStageManager = _003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		}
	}

	private sealed class _003C_003Ec__DisplayClass147_0
	{
		public OnlineStageManager _003C_003E4__this;

		public int selectedArcana;

		public int edition;

		public int subCardType;

		internal void _003CSelectCharacterCard_003Eb__0()
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0070: Expected I, but got O
			//IL_008f: Expected O, but got I
			OnlineStageManager onlineStageManager = _003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		}
	}

	private sealed class _003C_003Ec__DisplayClass163_0
	{
		public OnlineStageManager _003C_003E4__this;

		public WeaponType weapon;

		internal void _003CSelectTpWeapon_003Eb__0()
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0070: Expected I, but got O
			//IL_008f: Expected O, but got I
			OnlineStageManager onlineStageManager = _003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		}
	}

	private sealed class _003C_003Ec__DisplayClass165_0
	{
		public OnlineStageManager _003C_003E4__this;

		public WeaponType weapon;

		internal void _003CSelectWeaponFromCandyBox_003Eb__0()
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0070: Expected I, but got O
			//IL_008f: Expected O, but got I
			OnlineStageManager onlineStageManager = _003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		}
	}

	private sealed class _003C_003Ec__DisplayClass168_0
	{
		public OnlineStageManager _003C_003E4__this;

		public PowerUpType bonus;

		internal void _003CLevelUpBonusSelection_003Eb__0()
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0070: Expected I, but got O
			//IL_008f: Expected O, but got I
			OnlineStageManager onlineStageManager = _003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		}
	}

	private sealed class _003C_003Ec__DisplayClass173_0
	{
		public CoherenceSync nearestPlayer;

		internal void _003COpenPiano_003Eb__0()
		{
			VampireSurvivors.Objects.Characters.CharacterController component = nearestPlayer.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			GM.Core.QueueEnterPianoScene(component);
		}
	}

	private sealed class _003C_003Ec__DisplayClass193_0
	{
		public OnlineStageManager _003C_003E4__this;

		public string serializedSymbols;

		internal void _003CSetMadMoonSymbols_003Eb__0()
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			//IL_0075: Expected I, but got O
			//IL_0094: Expected O, but got I
			OnlineStageManager onlineStageManager = _003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		}
	}

	private sealed class _003C_003Ec__DisplayClass195_0
	{
		public OnlineStageManager _003C_003E4__this;

		public int newStage;

		internal void _003CDirecterStageSwitch_003Eb__0()
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0070: Expected I, but got O
			//IL_008f: Expected O, but got I
			OnlineStageManager onlineStageManager = _003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		}
	}

	private sealed class _003C_003Ec__DisplayClass199_0
	{
		public OnlineStageManager _003C_003E4__this;

		public int seed;

		internal void _003CWestwoodsSpin_003Eb__0()
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0070: Expected I, but got O
			//IL_008f: Expected O, but got I
			OnlineStageManager onlineStageManager = _003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		}
	}

	private sealed class _003C_003Ec__DisplayClass203_0
	{
		public OnlineStageManager _003C_003E4__this;

		public CoherenceSync pausingPlayer;

		internal void _003CGenericPause_003Eb__0()
		{
			_003C_003E4__this.PerformGenericPause(pausingPlayer);
		}
	}

	private sealed class _003C_003Ec__DisplayClass205_0
	{
		public CoherenceSync resumingPlayer;

		public bool freeze;

		internal void _003CFreezePlayer_003Eb__0()
		{
			VampireSurvivors.Objects.Characters.CharacterController component = resumingPlayer.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			component.FreezePlayer(freeze);
		}
	}

	private sealed class _003C_003Ec__DisplayClass226_0
	{
		public BackgroundDevilRoom devilRoom;

		public CoherenceSync player;

		internal void _003CDarkassoCutscene_003Eb__0()
		{
			VampireSurvivors.Objects.Characters.CharacterController component = player.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			devilRoom.TriggerCutscene(component);
		}
	}

	private sealed class _003CIterateSeats_003Ed__77 : IEnumerable<PlayerInfo>, IEnumerable, IEnumerator<PlayerInfo>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private PlayerInfo _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public OnlineStageManager _003C_003E4__this;

		PlayerInfo IEnumerator<PlayerInfo>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CIterateSeats_003Ed__77(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
			int num = default(int);
			_003C_003El__initialThreadId = num;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0206: Expected I4, but got I8
			//IL_026b: Expected I4, but got O
			//IL_0039: Expected O, but got I4
			//IL_01a0: Expected I4, but got I8
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_013a: Expected I4, but got I8
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Expected O, but got Unknown
			//IL_00cc: Expected I4, but got I8
			//IL_00b7: Expected I4, but got I8
			OnlineStageManager onlineStageManager = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					object obj2 = obj - 1;
					if (!flag)
					{
						object obj3 = obj2 - 1;
						bool result;
						if (!flag)
						{
							bool flag2 = (nint)obj3 != 1;
							result = false;
							if (!flag2)
							{
								_003C_003E1__state = -1;
								return false;
							}
						}
						else
						{
							_003C_003E1__state = -1;
							if ((object)_003C_003E4__this == null)
							{
								goto IL_025d;
							}
							PlayerInfo playerInfo = _003C_003E4__this.ReturnPlayerInfoForSeat(onlineStageManager._fourthSeat);
							_003C_003E2__current = playerInfo;
							_003C_003E1__state = 4;
							result = true;
						}
						return result;
					}
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						PlayerInfo playerInfo2 = _003C_003E4__this.ReturnPlayerInfoForSeat(onlineStageManager._thirdSeat);
						_003C_003E2__current = playerInfo2;
						_003C_003E1__state = 3;
						return true;
					}
				}
				else
				{
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						PlayerInfo playerInfo3 = _003C_003E4__this.ReturnPlayerInfoForSeat(onlineStageManager._secondSeat);
						_003C_003E2__current = playerInfo3;
						_003C_003E1__state = 2;
						return true;
					}
				}
			}
			else
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					PlayerInfo playerInfo4 = _003C_003E4__this.ReturnPlayerInfoForSeat(onlineStageManager._firstSeat);
					_003C_003E2__current = playerInfo4;
					_003C_003E1__state = 1;
					return true;
				}
			}
			goto IL_025d;
			IL_025d:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}

		IEnumerator<PlayerInfo> IEnumerable<PlayerInfo>.GetEnumerator()
		{
			if (_003C_003E1__state == -2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
				object obj = default(object);
				if (_003C_003El__initialThreadId == (nint)obj)
				{
					_003C_003E1__state = 0;
					return this;
				}
			}
			_003CIterateSeats_003Ed__77 obj2 = null;
			obj2._003C_003E1__state = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
			int num = default(int);
			obj2._003C_003El__initialThreadId = num;
			obj2._003C_003E4__this = _003C_003E4__this;
			return obj2;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (_003C_003E1__state == -2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
				object obj = default(object);
				if (_003C_003El__initialThreadId == (nint)obj)
				{
					_003C_003E1__state = 0;
					return this;
				}
			}
			_003CIterateSeats_003Ed__77 obj2 = null;
			obj2._003C_003E1__state = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
			int num = default(int);
			obj2._003C_003El__initialThreadId = num;
			obj2._003C_003E4__this = _003C_003E4__this;
			return obj2;
		}
	}

	private sealed class _003C_WaitToStartOnline_003Ed__94(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public OnlineStageManager _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0078: Expected I4, but got I8
			//IL_010f: Expected I4, but got O
			//IL_00f1: Expected O, but got I
			object obj = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForSeconds waitForSeconds = null;
				waitForSeconds.m_Seconds = 1f;
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Action action = _003C_003E4__this.LoadGameplayScene;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+78]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+78]");
						bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All);
						return false;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private List<WeaponType> _003CChosenLevelUpWeapons_003Ek__BackingField;

	private List<ItemType> _003CChosenLevelUpItems_003Ek__BackingField;

	private List<VampireSurvivors.Objects.Characters.CharacterController> _003CChosenAmuletTargets_003Ek__BackingField;

	private List<WeightedLimitBreak> _003CChosenLimitBreaks_003Ek__BackingField;

	private bool _003CListenForHostDisconnection_003Ek__BackingField;

	public Action<int, PlayerInfo> OnSeatAssigned;

	public Action OnBecomeAuthority;

	[NonSerialized]
	public uint _firstSeat;

	[NonSerialized]
	public uint _secondSeat;

	[NonSerialized]
	public uint _thirdSeat;

	[NonSerialized]
	public uint _fourthSeat;

	private uint _003CRandomEventsSeed_003Ek__BackingField;

	private uint _003CMinorArcanasSeed_003Ek__BackingField;

	private uint _003CSurvarotsSeed_003Ek__BackingField;

	private uint _003CUiPageSeed_003Ek__BackingField;

	private CoherenceSync _sync;

	private bool _signalledGameStart;

	private bool _signalledInitializeGameSession;

	private bool _signalledInitStage;

	private bool _isResumingGame;

	private Coherence.Log.Logger _logger;

	private IReplicationServer _replicationServer;

	private List<byte[]> _powerUpChunks;

	private Unity.Mathematics.Random _minorArcanasRng;

	private Unity.Mathematics.Random _survarotsRng;

	private Unity.Mathematics.Random _uiPageRng;

	private SignalBus _signalBus;

	private long _lastCalculatedSimulationFrame;

	private bool _sentOpenTerrace;

	private static OnlineStageManager _instance;

	private bool _sentPauseRequest;

	public static OnlineStageManager Instance => _instance;

	public bool IsHost
	{
		get
		{
			//IL_00c0: Expected I4, but got O
			//IL_0098: Expected O, but got I
			CoherenceSync sync = _sync;
			if ((object)_sync != null)
			{
				NetworkEntityState networkEntityState = sync._003CEntityState_003Ek__BackingField;
				if (sync._003CEntityState_003Ek__BackingField != null)
				{
					ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
					if (networkEntityState._003CAuthorityType_003Ek__BackingField == null)
					{
						goto IL_00b2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v4 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					if ((nint)0 != 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v4 (Coherence.Toolkit.ObservableAuthorityType)+10]");
						object obj = -3;
						return obj == null;
					}
				}
				return true;
			}
			goto IL_00b2;
			IL_00b2:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public CoherenceSync Sync => _sync;

	public int NumberOfConnectedPlayers
	{
		get
		{
			//IL_0095: Expected I4, but got O
			CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
			if ((object)CoherenceBridgeStore.masterBridge != null)
			{
				CoherenceClientConnectionManager coherenceClientConnectionManager = masterBridge._003CClientConnections_003Ek__BackingField;
				if (masterBridge._003CClientConnections_003Ek__BackingField != null)
				{
					Dictionary<Entity, CoherenceClientConnection> connectionsByEntityId = coherenceClientConnectionManager.connectionsByEntityId;
					if (coherenceClientConnectionManager.connectionsByEntityId != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rcx_v8 (System.Collections.Generic.Dictionary`2<Coherence.Entities.Entity, Coherence.Toolkit.CoherenceClientConnection>)+20]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rcx_v8 (System.Collections.Generic.Dictionary`2<Coherence.Entities.Entity, Coherence.Toolkit.CoherenceClientConnection>)+28]");
						return (int)(num - 0);
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	public List<WeaponType> ChosenLevelUpWeapons
	{
		get
		{
			return _003CChosenLevelUpWeapons_003Ek__BackingField;
		}
		private set
		{
			_003CChosenLevelUpWeapons_003Ek__BackingField = value;
		}
	}

	public List<ItemType> ChosenLevelUpItems
	{
		get
		{
			return _003CChosenLevelUpItems_003Ek__BackingField;
		}
		private set
		{
			_003CChosenLevelUpItems_003Ek__BackingField = value;
		}
	}

	public List<VampireSurvivors.Objects.Characters.CharacterController> ChosenAmuletTargets
	{
		get
		{
			return _003CChosenAmuletTargets_003Ek__BackingField;
		}
		private set
		{
			_003CChosenAmuletTargets_003Ek__BackingField = value;
		}
	}

	public List<WeightedLimitBreak> ChosenLimitBreaks
	{
		get
		{
			return _003CChosenLimitBreaks_003Ek__BackingField;
		}
		private set
		{
			_003CChosenLimitBreaks_003Ek__BackingField = value;
		}
	}

	public bool ListenForHostDisconnection
	{
		get
		{
			return _003CListenForHostDisconnection_003Ek__BackingField;
		}
		set
		{
			_003CListenForHostDisconnection_003Ek__BackingField = value;
		}
	}

	public uint RandomEventsSeed
	{
		get
		{
			return _003CRandomEventsSeed_003Ek__BackingField;
		}
		set
		{
			_003CRandomEventsSeed_003Ek__BackingField = value;
		}
	}

	public uint MinorArcanasSeed
	{
		get
		{
			return _003CMinorArcanasSeed_003Ek__BackingField;
		}
		set
		{
			_003CMinorArcanasSeed_003Ek__BackingField = value;
		}
	}

	public uint SurvarotsSeed
	{
		get
		{
			return _003CSurvarotsSeed_003Ek__BackingField;
		}
		set
		{
			_003CSurvarotsSeed_003Ek__BackingField = value;
		}
	}

	public uint UiPageSeed
	{
		get
		{
			return _003CUiPageSeed_003Ek__BackingField;
		}
		set
		{
			_003CUiPageSeed_003Ek__BackingField = value;
		}
	}

	public Unity.Mathematics.Random MinorArcanasRng => _minorArcanasRng;

	public Unity.Mathematics.Random SurvarotsRng => _survarotsRng;

	public int StageEventSpawned
	{
		get
		{
			//IL_0143: Expected I4, but got O
			GameManager core = GM.Core;
			if ((object)GM.Core != null && ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0)
			{
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null)
				{
					Stage stage = core2._stage;
					if ((object)core2._stage == null || ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0)
					{
						goto IL_012f;
					}
					GameManager core3 = GM.Core;
					if ((object)GM.Core != null)
					{
						Stage stage2 = core3._stage;
						if ((object)core3._stage != null)
						{
							StageEventManager stageEventManager = stage2._stageEventManager;
							if (stage2._stageEventManager != null)
							{
								return stageEventManager._003CSpawned_003Ek__BackingField;
							}
							goto IL_012f;
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (int)ex;
			}
			goto IL_012f;
			IL_012f:
			return 0;
		}
		set
		{
			GameManager core = GM.Core;
			if ((object)GM.Core == null || ((UnityEngine.Object)core).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			GameManager core2 = GM.Core;
			Stage stage = core2._stage;
			if ((object)core2._stage != null && ((UnityEngine.Object)stage).m_CachedPtr != (IntPtr)0)
			{
				GameManager core3 = GM.Core;
				Stage stage2 = core3._stage;
				if (stage2._stageEventManager != null)
				{
					GameManager core4 = GM.Core;
					Stage stage3 = core4._stage;
					StageEventManager stageEventManager = stage3._stageEventManager;
					stageEventManager._003CSpawned_003Ek__BackingField = value;
				}
			}
		}
	}

	public bool ControlTimeScale
	{
		get
		{
			//IL_0049: Expected I4, but got O
			CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
			if ((object)CoherenceBridgeStore.masterBridge != null)
			{
				return masterBridge.controlTimeScale;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		set
		{
			CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
			masterBridge.controlTimeScale = value;
		}
	}

	private void Construct(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	public int NextUiPageInt()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected I4, but got Unknown
		object obj = (object)_uiPageRng << 13;
		object obj2 = obj ^ (object)_uiPageRng;
		int result = (int)(_uiPageRng ^ 0x80000000L);
		object obj3 = obj2 >> 17;
		object obj4 = obj2 ^ obj3;
		object obj5 = obj4 << 5;
		Unity.Mathematics.Random uiPageRng = (Unity.Mathematics.Random)(obj5 ^ obj4);
		_uiPageRng = uiPageRng;
		return result;
	}

	public IEnumerable<PlayerInfo> IterateSeats()
	{
		//IL_0021: Expected I4, but got I8
		_003CIterateSeats_003Ed__77 obj = null;
		obj._003C_003E1__state = -2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
		int num = default(int);
		obj._003C_003El__initialThreadId = num;
		obj._003C_003E4__this = this;
		return obj;
	}

	public static bool IsHostInTheGame()
	{
		//IL_009e: Expected I4, but got O
		OnlineStageManager instance = _instance;
		if ((object)_instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
		{
			OnlineStageManager instance2 = _instance;
			if ((object)_instance == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			PlayerInfo playerInfo = _instance.ReturnPlayerInfoForSeat(instance2._firstSeat);
			if ((object)playerInfo != null)
			{
				bool flag = ((UnityEngine.Object)playerInfo).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
		}
		return false;
	}

	public unsafe List<VampireSurvivors.Objects.Characters.CharacterController> GetPlayerCharacters()
	{
		//IL_0017: Expected O, but got Ref
		//IL_001c: Expected I, but got O
		//IL_005c: Expected I, but got O
		//IL_00fd: Expected O, but got I4
		//IL_00aa: Expected O, but got I
		//IL_00b3: Expected O, but got I4
		//IL_023c: Expected O, but got I
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Expected O, but got Unknown
		//IL_011d: Expected I, but got O
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_031f: Expected I, but got O
		//IL_0149: Expected I, but got O
		//IL_0157: Expected I, but got O
		//IL_018a: Expected I, but got O
		//IL_036c: Expected I, but got O
		//IL_01b6: Expected I, but got O
		//IL_01c4: Expected I, but got O
		//IL_0214: Expected I, but got O
		List<VampireSurvivors.Objects.Characters.CharacterController> list = new List<VampireSurvivors.Objects.Characters.CharacterController>();
		IEnumerable<PlayerInfo> enumerable = IterateSeats();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = unchecked((nint)null);
		object obj3 = default(object);
		object obj13 = default(object);
		PlayerInfo playerInfo = default(PlayerInfo);
		while (true)
		{
			object obj5;
			object obj12;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj3 != null)
				{
					bool flag = obj2 == null;
					num = unchecked((nint)null);
					if (!flag)
					{
						object obj4 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r10_v5+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_00ea;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r10_v5+B0]");
						obj5 = 0;
						object obj6 = 0;
						while (true)
						{
							object obj7 = obj6 + obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r8_v9+v370 @ rax_v49*8]");
							if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
							{
								break;
							}
							obj6++;
							object obj8 = obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r10_v5+12E]");
							if ((nint)obj8 < 0)
							{
								continue;
							}
							goto IL_00ea;
						}
						object obj9 = obj6 + obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r8_v9+8+v426 @ rcx_v37*8]");
						object obj10 = (nint)0 << 4;
						object obj11 = obj10 + 312;
						obj12 = obj11 + obj4;
						goto IL_0385;
					}
					throw new NullReferenceException();
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				break;
			}
			throw new NullReferenceException();
			IL_00ea:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj5 = 0;
			obj12 = obj13;
			goto IL_0385;
			IL_0385:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v431 @ rdx_v12] (should have been resolved before IL gen)");
			num = (nint)typeof(UnityEngine.Object);
			bool flag2 = (object)playerInfo == null;
			nint num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			if (flag2)
			{
				continue;
			}
			bool flag3 = ((UnityEngine.Object)playerInfo).m_CachedPtr == (IntPtr)0;
			num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			num = (nint)typeof(UnityEngine.Object);
			if (flag3)
			{
				continue;
			}
			VampireSurvivors.Objects.Characters.CharacterController characterController = playerInfo.CharacterController;
			num = (nint)typeof(UnityEngine.Object);
			bool flag4 = (object)characterController == null;
			num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			if (flag4)
			{
				continue;
			}
			bool flag5 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
			num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			num = (nint)typeof(UnityEngine.Object);
			if (!flag5)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController2 = playerInfo.CharacterController;
				if (list == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B050");
				num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			}
		}
		return list;
	}

	public unsafe int GetSeatNumberForCharacter(VampireSurvivors.Objects.Characters.CharacterController characterController)
	{
		//IL_0017: Expected O, but got Ref
		//IL_0025: Expected I, but got O
		//IL_0065: Expected I, but got O
		//IL_0239: Expected I4, but got I8
		//IL_00b4: Expected I, but got O
		//IL_02bf: Expected O, but got I4
		//IL_02d9: Expected O, but got I4
		//IL_01aa: Expected I, but got O
		//IL_0160: Expected I, but got O
		IEnumerable<PlayerInfo> enumerable = IterateSeats();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		int num = 0;
		nint num2 = unchecked((nint)null);
		object obj3 = default(object);
		PlayerInfo playerInfo = default(PlayerInfo);
		while (true)
		{
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj3 != null)
				{
					bool flag = obj2 == null;
					num2 = unchecked((nint)null);
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99E70");
						if ((object)playerInfo != null)
						{
							bool flag2 = ((UnityEngine.Object)playerInfo).m_CachedPtr == (IntPtr)0;
							num2 = (nint)typeof(UnityEngine.Object);
							if (!flag2)
							{
								VampireSurvivors.Objects.Characters.CharacterController characterController2 = playerInfo.CharacterController;
								bool flag3 = (object)characterController2 == null;
								bool flag4 = (object)characterController == null;
								object obj4 = flag3 & flag4;
								bool flag5 = obj4 == null;
								object obj5 = !flag5;
								if (obj5 == null)
								{
									bool flag6;
									if ((object)characterController != null)
									{
										if ((object)characterController2 != null)
										{
											object obj6 = (object)characterController2 - (object)characterController;
											flag6 = obj6 == null;
										}
										else
										{
											flag6 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
											num2 = (nint)typeof(UnityEngine.Object);
										}
									}
									else
									{
										if ((object)characterController2 == null)
										{
											break;
										}
										flag6 = ((UnityEngine.Object)characterController2).m_CachedPtr == (IntPtr)0;
										num2 = (nint)typeof(UnityEngine.Object);
									}
									if (!flag6)
									{
										goto IL_01af;
									}
								}
								if (obj != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
								}
								return num;
							}
						}
						goto IL_01af;
					}
					throw new NullReferenceException();
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				return -1;
			}
			throw new NullReferenceException();
			IL_01af:
			num++;
		}
		throw new NullReferenceException();
	}

	public unsafe PlayerInfo GetPlayerInfoForCharacter(VampireSurvivors.Objects.Characters.CharacterController characterController)
	{
		//IL_0017: Expected O, but got Ref
		//IL_001c: Expected I, but got O
		//IL_005c: Expected I, but got O
		//IL_008c: Expected I, but got O
		//IL_00b8: Expected I, but got O
		//IL_02c5: Expected O, but got I4
		//IL_02df: Expected O, but got I4
		//IL_018b: Expected I, but got O
		//IL_01bb: Expected I, but got O
		//IL_0164: Expected I, but got O
		IEnumerable<PlayerInfo> enumerable = IterateSeats();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = unchecked((nint)null);
		object obj3 = default(object);
		PlayerInfo playerInfo = default(PlayerInfo);
		while (true)
		{
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj3 != null)
				{
					bool flag = obj2 == null;
					num = unchecked((nint)null);
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99E70");
						num = (nint)typeof(UnityEngine.Object);
						if ((object)playerInfo == null)
						{
							continue;
						}
						bool flag2 = ((UnityEngine.Object)playerInfo).m_CachedPtr == (IntPtr)0;
						num = (nint)typeof(UnityEngine.Object);
						if (flag2)
						{
							continue;
						}
						VampireSurvivors.Objects.Characters.CharacterController characterController2 = playerInfo.CharacterController;
						bool flag3 = (object)characterController2 == null;
						bool flag4 = (object)characterController == null;
						object obj4 = flag3 & flag4;
						bool flag5 = obj4 == null;
						object obj5 = !flag5;
						if (obj5 == null)
						{
							bool flag6;
							if ((object)characterController != null)
							{
								if ((object)characterController2 != null)
								{
									object obj6 = (object)characterController2 - (object)characterController;
									flag6 = obj6 == null;
								}
								else
								{
									flag6 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
									num = (nint)typeof(UnityEngine.Object);
								}
							}
							else
							{
								bool flag7 = (object)characterController2 == null;
								num = (nint)typeof(UnityEngine.Object);
								if (flag7)
								{
									throw new NullReferenceException();
								}
								flag6 = ((UnityEngine.Object)characterController2).m_CachedPtr == (IntPtr)0;
								num = (nint)typeof(UnityEngine.Object);
							}
							if (!flag6)
							{
								continue;
							}
						}
						if (obj != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
						}
						break;
					}
					throw new NullReferenceException();
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				return null;
			}
			throw new NullReferenceException();
		}
		return playerInfo;
	}

	public unsafe VampireSurvivors.Objects.Characters.CharacterController GetCharacterForSeatNumber(int seatNumber)
	{
		//IL_0017: Expected O, but got Ref
		//IL_0020: Expected O, but got I4
		//IL_0025: Expected I, but got O
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_00b0: Expected I, but got O
		//IL_00da: Expected I, but got O
		IEnumerable<PlayerInfo> enumerable = IterateSeats();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		object obj3 = 0;
		nint num = unchecked((nint)null);
		object obj4 = default(object);
		PlayerInfo playerInfo = default(PlayerInfo);
		VampireSurvivors.Objects.Characters.CharacterController result;
		while (true)
		{
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj4 != null)
				{
					if (obj2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99E70");
						if ((object)playerInfo != null)
						{
							bool flag = ((UnityEngine.Object)playerInfo).m_CachedPtr == (IntPtr)0;
							num = (nint)typeof(UnityEngine.Object);
							if (!flag)
							{
								bool flag2 = (nint)obj3 == seatNumber;
								num = (nint)typeof(UnityEngine.Object);
								if (flag2)
								{
									result = playerInfo.CharacterController;
									if (obj != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
									}
									break;
								}
							}
						}
						obj3++;
						continue;
					}
					throw new NullReferenceException();
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				result = null;
				break;
			}
			throw new NullReferenceException();
		}
		return result;
	}

	public unsafe List<CharacterType> GetCharacterSelections()
	{
		//IL_0017: Expected O, but got Ref
		//IL_001c: Expected I, but got O
		//IL_005c: Expected I, but got O
		//IL_00fd: Expected O, but got I4
		//IL_00aa: Expected O, but got I
		//IL_00b3: Expected O, but got I4
		//IL_01d3: Expected O, but got I
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected O, but got Unknown
		//IL_011d: Expected I, but got O
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_02b6: Expected I, but got O
		//IL_014c: Expected I, but got O
		//IL_015a: Expected I, but got O
		//IL_0185: Expected I, but got O
		//IL_01ab: Expected I, but got O
		List<CharacterType> list = new List<CharacterType>();
		IEnumerable<PlayerInfo> enumerable = IterateSeats();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = unchecked((nint)null);
		object obj3 = default(object);
		object obj13 = default(object);
		object obj14 = default(object);
		while (true)
		{
			object obj5;
			object obj12;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj3 != null)
				{
					bool flag = obj2 == null;
					num = unchecked((nint)null);
					if (!flag)
					{
						object obj4 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v5+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_00ea;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v5+B0]");
						obj5 = 0;
						object obj6 = 0;
						while (true)
						{
							object obj7 = obj6 + obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r8_v9+v330 @ rax_v37*8]");
							if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
							{
								break;
							}
							obj6++;
							object obj8 = obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v5+12E]");
							if ((nint)obj8 < 0)
							{
								continue;
							}
							goto IL_00ea;
						}
						object obj9 = obj6 + obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r8_v9+8+v386 @ rcx_v28*8]");
						object obj10 = (nint)0 << 4;
						object obj11 = obj10 + 312;
						obj12 = obj11 + obj4;
						goto IL_02ec;
					}
					throw new NullReferenceException();
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				break;
			}
			throw new NullReferenceException();
			IL_00ea:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj5 = 0;
			obj12 = obj13;
			goto IL_02ec;
			IL_02ec:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v391 @ rdx_v12] (should have been resolved before IL gen)");
			num = (nint)typeof(UnityEngine.Object);
			bool flag2 = obj14 == null;
			nint num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			if (flag2)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ rax_v21+10]");
			bool flag3 = (nint)0 == 0;
			num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			num = (nint)typeof(UnityEngine.Object);
			if (!flag3)
			{
				bool flag4 = list == null;
				num = (nint)typeof(UnityEngine.Object);
				if (flag4)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
				num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			}
		}
		return list;
	}

	public unsafe List<VampireSurvivors.Objects.Characters.CharacterController> GetOrderedCharacterControllers()
	{
		//IL_0017: Expected O, but got Ref
		//IL_001c: Expected I, but got O
		//IL_005c: Expected I, but got O
		//IL_00fd: Expected O, but got I4
		//IL_00aa: Expected O, but got I
		//IL_00b3: Expected O, but got I4
		//IL_01cf: Expected O, but got I
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected O, but got Unknown
		//IL_011d: Expected I, but got O
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_02b2: Expected I, but got O
		//IL_0149: Expected I, but got O
		//IL_0157: Expected I, but got O
		//IL_01a7: Expected I, but got O
		List<VampireSurvivors.Objects.Characters.CharacterController> list = new List<VampireSurvivors.Objects.Characters.CharacterController>();
		IEnumerable<PlayerInfo> enumerable = IterateSeats();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = unchecked((nint)null);
		object obj3 = default(object);
		object obj13 = default(object);
		PlayerInfo playerInfo = default(PlayerInfo);
		while (true)
		{
			object obj5;
			object obj12;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj3 != null)
				{
					bool flag = obj2 == null;
					num = unchecked((nint)null);
					if (!flag)
					{
						object obj4 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v5+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_00ea;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v5+B0]");
						obj5 = 0;
						object obj6 = 0;
						while (true)
						{
							object obj7 = obj6 + obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r8_v9+v333 @ rax_v38*8]");
							if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
							{
								break;
							}
							obj6++;
							object obj8 = obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v5+12E]");
							if ((nint)obj8 < 0)
							{
								continue;
							}
							goto IL_00ea;
						}
						object obj9 = obj6 + obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r8_v9+8+v389 @ rcx_v29*8]");
						object obj10 = (nint)0 << 4;
						object obj11 = obj10 + 312;
						obj12 = obj11 + obj4;
						goto IL_02e8;
					}
					throw new NullReferenceException();
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				break;
			}
			throw new NullReferenceException();
			IL_00ea:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj5 = 0;
			obj12 = obj13;
			goto IL_02e8;
			IL_02e8:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v394 @ rdx_v12] (should have been resolved before IL gen)");
			num = (nint)typeof(UnityEngine.Object);
			bool flag2 = (object)playerInfo == null;
			nint num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			if (flag2)
			{
				continue;
			}
			bool flag3 = ((UnityEngine.Object)playerInfo).m_CachedPtr == (IntPtr)0;
			num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			num = (nint)typeof(UnityEngine.Object);
			if (!flag3)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = playerInfo.CharacterController;
				if (list == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B050");
				num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			}
		}
		return list;
	}

	public int GetMySeatNumber()
	{
		//IL_01b6: Expected I4, but got O
		//IL_0191: Expected I4, but got I8
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		if ((object)CoherenceBridgeStore.masterBridge != null && masterBridge._003CClient_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj = default(object);
			if ((int)_firstSeat == (nint)obj)
			{
				return 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
			object obj2 = default(object);
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v13+C0]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					object obj3 = default(object);
					if ((int)_secondSeat == (nint)obj3)
					{
						return 1;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
					object obj4 = default(object);
					if (obj4 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v19+C0]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							object obj5 = default(object);
							if ((int)_thirdSeat == (nint)obj5)
							{
								return 2;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
							CoherenceBridge coherenceBridge = default(CoherenceBridge);
							if ((object)coherenceBridge != null)
							{
								ClientID clientID = coherenceBridge.ClientID;
								bool flag = (int)_fourthSeat == (nint)clientID;
								int result = 3;
								if (!flag)
								{
									result = -1;
								}
								return result;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public PlayerInfo GetMyPlayerInfo()
	{
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		if ((object)CoherenceBridgeStore.masterBridge != null)
		{
			CoherenceClientConnectionManager coherenceClientConnectionManager = masterBridge._003CClientConnections_003Ek__BackingField;
			if (masterBridge._003CClientConnections_003Ek__BackingField != null && coherenceClientConnectionManager.bridge != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj = default(object);
				if (obj == null || coherenceClientConnectionManager.myClientConnection == null)
				{
					return null;
				}
				CoherenceSync sync = coherenceClientConnectionManager.myClientConnection.Sync;
				if ((object)sync != null)
				{
					return sync.GetComponent<PlayerInfo>();
				}
			}
		}
		return (PlayerInfo)(object)new NullReferenceException();
	}

	public PlayerInfo GetHostPlayerInfo()
	{
		return ReturnPlayerInfoForSeat(_firstSeat);
	}

	public unsafe int GetHighestAverageLatencyMs()
	{
		//IL_0017: Expected O, but got Ref
		//IL_0025: Expected I, but got O
		//IL_0065: Expected I, but got O
		//IL_010e: Expected O, but got I4
		//IL_00b3: Expected O, but got I
		//IL_0295: Expected O, but got I4
		//IL_01f2: Expected O, but got I4
		//IL_0208: Expected O, but got I
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_0126: Expected I, but got O
		//IL_02e1: Expected I, but got O
		//IL_0155: Expected I, but got O
		//IL_0163: Expected I, but got O
		//IL_0198: Expected I, but got O
		//IL_01a6: Expected I, but got O
		//IL_01d2: Expected I, but got O
		//IL_01e0: Expected I, but got O
		IEnumerable<PlayerInfo> enumerable = IterateSeats();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		int num = 0;
		nint num2 = unchecked((nint)null);
		object obj3 = default(object);
		object obj11 = default(object);
		object obj12 = default(object);
		while (true)
		{
			object obj10;
			object obj5;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj3 != null)
				{
					bool flag = obj2 == null;
					num2 = unchecked((nint)null);
					if (!flag)
					{
						object obj4 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ r10_v4+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_00f3;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ r10_v4+B0]");
						obj5 = 0;
						int num3 = 0;
						while (true)
						{
							object obj6 = num3 + num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ r8_v8+v297 @ rax_v32*8]");
							if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
							{
								break;
							}
							num3++;
							int num4 = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ r10_v4+12E]");
							if ((nint)num4 < (nint)0)
							{
								continue;
							}
							goto IL_00f3;
						}
						object obj7 = num3 + num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ r8_v8+8+v353 @ rcx_v24*8]");
						object obj8 = (nint)0 << 4;
						object obj9 = obj8 + 312;
						obj10 = obj9 + obj4;
						goto IL_030c;
					}
					throw new NullReferenceException();
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				break;
			}
			throw new NullReferenceException();
			IL_00f3:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj10 = obj11;
			obj5 = 0;
			goto IL_030c;
			IL_030c:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v358 @ rdx_v10] (should have been resolved before IL gen)");
			num2 = (nint)typeof(UnityEngine.Object);
			bool flag2 = obj12 == null;
			nint num5 = (nint)typeof(IEnumerator<PlayerInfo>);
			if (flag2)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rax_v17+10]");
			bool flag3 = (nint)0 == 0;
			num5 = (nint)typeof(IEnumerator<PlayerInfo>);
			num2 = (nint)typeof(UnityEngine.Object);
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rax_v17+78]");
				bool flag4 = (nint)0 <= (nint)num;
				num5 = (nint)typeof(IEnumerator<PlayerInfo>);
				num2 = (nint)typeof(UnityEngine.Object);
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rax_v17+78]");
					num = 0;
					num5 = (nint)typeof(IEnumerator<PlayerInfo>);
					num2 = (nint)typeof(UnityEngine.Object);
				}
			}
		}
		return num;
	}

	public unsafe long GetStartingOnlineClientFrame()
	{
		//IL_0008: Expected O, but got Ref
		//IL_006e: Expected O, but got I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_048b: Expected I, but got O
		//IL_0534: Unknown result type (might be due to invalid IL or missing references)
		//IL_0539: Expected I8, but got Unknown
		//IL_0555: Expected O, but got Ref
		//IL_0499: Expected O, but got F4
		//IL_00ff: Expected O, but got Ref
		//IL_04cc: Expected I, but got F4
		//IL_013e: Expected O, but got Ref
		//IL_0160: Expected O, but got Ref
		//IL_0173: Expected native int or pointer, but got O
		//IL_019d: Expected O, but got Ref
		//IL_01ba: Expected O, but got Ref
		//IL_01cd: Expected native int or pointer, but got O
		//IL_01f7: Expected O, but got Ref
		//IL_0214: Expected O, but got Ref
		//IL_0227: Expected native int or pointer, but got O
		//IL_0251: Expected O, but got Ref
		//IL_0276: Expected O, but got Ref
		//IL_0289: Expected native int or pointer, but got O
		//IL_02b3: Expected O, but got Ref
		//IL_02d0: Expected O, but got Ref
		//IL_02e3: Expected native int or pointer, but got O
		//IL_030d: Expected O, but got Ref
		//IL_032c: Expected O, but got Ref
		//IL_033f: Expected native int or pointer, but got O
		//IL_036a: Expected O, but got I8
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Expected I8, but got Unknown
		//IL_03bf: Expected O, but got Ref
		//IL_03e5: Expected O, but got Ref
		//IL_03f8: Expected native int or pointer, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000C1F0");
		int highestAverageLatencyMs = GetHighestAverageLatencyMs();
		PlayerInfo myPlayerInfo = GetMyPlayerInfo();
		object obj3 = myPlayerInfo._averageLatencyMs + highestAverageLatencyMs;
		object obj4 = obj3 + 100;
		float num = (float)obj4 * 0.001f;
		nint num2 = (nint)typeof(CoherenceBridgeStore);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ rax_v25 (Il2CppClass<Coherence.Toolkit.CoherenceBridgeStore>)+B8]");
		nint num3 = 0;
		CoherenceBridge masterBridge2 = CoherenceBridgeStore.masterBridge;
		float num5;
		if (!masterBridge2.controlTimeScale)
		{
			object obj5 = Time.timeScale;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
			if (num3 == 0)
			{
				num3 = (nint)Time.timeScale;
				object obj6 = default(object);
				float num4 = (float)obj6 * 0.5f;
				num5 = num4 * num;
				goto IL_051d;
			}
		}
		num5 = num;
		goto IL_051d;
		IL_051d:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		object obj7 = default(object);
		long num6 = num3 + obj7;
		(string, object)[] array = new(string, object)[9];
		object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object item = default(object);
		(string, object) tuple = ("Current Frame", item);
		bool flag = array == null;
		_ = 0;
		object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object item2 = default(object);
		(string, object) tuple2 = ("Max Latency (ms)", item2);
		_ = 0;
		object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
		_ = myPlayerInfo._averageLatencyMs;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		(string, object) tuple3 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 113));
		_ = 0;
		object item3 = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple3, ("My Latency (ms)", item3));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-71]");
		_ = 0;
		object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		(string, object) tuple4 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 97));
		_ = 0;
		object item4 = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple4, ("Sum Latency (ms)", item4));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-61]");
		_ = 0;
		object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		(string, object) tuple5 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
		_ = 0;
		object item5 = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple5, ("Total Latency To Account For (s)", item5));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-51]");
		_ = 0;
		object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7F]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		(string, object) tuple6 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
		_ = 0;
		object item6 = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple6, ("Expected Frames To Account For", item6));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-41]");
		_ = 0;
		object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		(string, object) tuple7 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
		_ = 0;
		object item7 = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple7, ("Calculated Starting Frame", item7));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-31]");
		_ = 0;
		object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
		_ = _lastCalculatedSimulationFrame;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		(string, object) tuple8 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
		_ = 0;
		object item8 = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple8, ("Last Calculated Starting Frame", item8));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-21]");
		_ = 0;
		object obj16 = num6 - _lastCalculatedSimulationFrame;
		long num7 = num6 ^ _lastCalculatedSimulationFrame;
		long num8 = num6 ^ obj16;
		long num9 = num7 & num8;
		bool flag2 = num9 < 0;
		bool flag3 = (nint)obj16 < 0;
		object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
		_ = flag3 != flag2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		(string, object) tuple9 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
		_ = 0;
		object item9 = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple9, ("Is Sum Less Than Last Calculated Frame?", item9));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-11]");
		_ = 0;
		bool flag4 = _logger == null;
		_logger.Info("Calculating Starting Online Client Frame", array);
		if (num6 < _lastCalculatedSimulationFrame)
		{
			num6 = _lastCalculatedSimulationFrame;
		}
		_lastCalculatedSimulationFrame = num6;
		return num6;
	}

	public bool IsHostClientConnection(CoherenceClientConnection clientConn)
	{
		//IL_0040: Expected I4, but got O
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		if (clientConn != null)
		{
			object obj = clientConn._003CClientId_003Ek__BackingField - _firstSeat;
			return obj == null;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void InjectDeps(IReplicationServer replicationServer)
	{
		_replicationServer = replicationServer;
	}

	public unsafe bool AreAllPlayersInsideGameplayUi(int uiPageId)
	{
		//IL_0017: Expected O, but got Ref
		//IL_0025: Expected I, but got O
		//IL_0065: Expected I, but got O
		//IL_010e: Expected O, but got I4
		//IL_00b3: Expected O, but got I
		//IL_00bc: Expected O, but got I4
		//IL_01e6: Expected O, but got I
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0126: Expected I, but got O
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_0311: Expected I, but got O
		//IL_0155: Expected I, but got O
		//IL_0163: Expected I, but got O
		//IL_021b: Expected O, but got I
		//IL_0245: Expected I, but got O
		//IL_0253: Expected I, but got O
		//IL_01b0: Expected I, but got O
		//IL_01be: Expected I, but got O
		IEnumerable<PlayerInfo> enumerable = IterateSeats();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		bool flag = true;
		nint num = unchecked((nint)null);
		object obj3 = default(object);
		object obj13 = default(object);
		object obj14 = default(object);
		while (true)
		{
			object obj12;
			object obj5;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj3 != null)
				{
					bool flag2 = obj2 == null;
					num = unchecked((nint)null);
					if (!flag2)
					{
						object obj4 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ r10_v4+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_00f3;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ r10_v4+B0]");
						obj5 = 0;
						object obj6 = 0;
						while (true)
						{
							object obj7 = obj6 + obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r8_v8+v318 @ rax_v34*8]");
							if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
							{
								break;
							}
							obj6++;
							object obj8 = obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ r10_v4+12E]");
							if ((nint)obj8 < 0)
							{
								continue;
							}
							goto IL_00f3;
						}
						object obj9 = obj6 + obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r8_v8+8+v374 @ rcx_v24*8]");
						object obj10 = (nint)0 << 4;
						object obj11 = obj10 + 312;
						obj12 = obj11 + obj4;
						goto IL_033c;
					}
					throw new NullReferenceException();
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				break;
			}
			throw new NullReferenceException();
			IL_00f3:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj12 = obj13;
			obj5 = 0;
			goto IL_033c;
			IL_033c:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v379 @ rdx_v10] (should have been resolved before IL gen)");
			num = (nint)typeof(UnityEngine.Object);
			bool flag3 = obj14 == null;
			nint num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			if (flag3)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rax_v17+10]");
			bool flag4 = (nint)0 == 0;
			num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			num = (nint)typeof(UnityEngine.Object);
			if (!flag4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rax_v17+91]");
				if ((nint)0 == 0)
				{
					flag = false;
					num2 = (nint)typeof(IEnumerator<PlayerInfo>);
					num = (nint)typeof(UnityEngine.Object);
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rax_v17+24]");
				object obj15 = -uiPageId;
				bool flag5 = obj15 == null;
				flag &= flag5;
				num2 = (nint)typeof(IEnumerator<PlayerInfo>);
				num = (nint)typeof(UnityEngine.Object);
			}
		}
		return flag;
	}

	public void SendLoadGameplayScene()
	{
		Action action = LockOnlineUI;
		bool flag = _sync.SendCommand(action, MessageTarget.All);
		_003C_WaitToStartOnline_003Ed__94 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator _WaitToStartOnline()
	{
		_003C_WaitToStartOnline_003Ed__94 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void ReloadCurrentScene()
	{
		//IL_0028: Expected O, but got I4
		Debug.Log("<color=green>Going to ScenePreloader scene</color>");
		Scene scene = SceneManager.LoadScene("ScenePreloader", (LoadSceneParameters)1);
	}

	public void LockOnlineUI()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0061: Expected I, but got O
		//IL_007d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	public void LoadGameplayScene()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0083: Expected I, but got O
		//IL_009f: Expected O, but got I
		PlayerInfo myPlayerInfo = GetMyPlayerInfo();
		myPlayerInfo._003CUpdateAverageLatency_003Ek__BackingField = false;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	public void InitializeGameSession(long startingSimulationFrame)
	{
		(string, object)[] args = Array.Empty<(string, object)>();
		_logger.Info("Received InitializeGameSession Signal", args);
		Action onSyncedTimer = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5BC0");
		};
		FireSyncTimer(startingSimulationFrame, onSyncedTimer);
	}

	public void InitializeStageLogic(long startingSimulationFrame)
	{
		Action onSyncedTimer = GM.Core.InitializeStageLogicOnline;
		FireSyncTimer(startingSimulationFrame, onSyncedTimer);
	}

	public void StartGameplay(long startingSimulationFrame)
	{
		SubscribeToSignals();
		Action onSyncedTimer = GM.Core.StartOnlineGame;
		FireSyncTimer(startingSimulationFrame, onSyncedTimer);
	}

	private void SubscribeToSignals()
	{
		//IL_00aa: Expected O, but got I4
		//IL_00aa: Expected O, but got I
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_0126: Expected O, but got I
		Action action = OnEnteredUi;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA57A0");
		Action action2 = OnEnteredUi;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action3 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.OnEnteredUISignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.OnEnteredUISignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v15 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		(string, object)[] args = Array.Empty<(string, object)>();
		_logger.Info("Subscribed to OnEnteredUISignal and BackButtonPressed Signals", args);
	}

	public void SendOpenTreasureCommand()
	{
		//IL_003b: Expected I8, but got O
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		Action<long> action = null;
		((OnlineStageManager)(object)action).OpenTreasure((long)this);
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void OpenTreasure(long startingSimFrame)
	{
		GameManager core = GM.Core;
		Action onSyncedTimer = core._003COpenTreasurePage_003Ek__BackingField.StartPlaying;
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendClaimTreasureRequestCommand()
	{
		Action action = ClaimTreasureRequest;
		bool flag = _sync.SendCommand(action, MessageTarget.AuthorityOnly);
	}

	public void ClaimTreasureRequest()
	{
		//IL_00b6: Expected I8, but got O
		GameManager core = GM.Core;
		OpenTreasurePage openTreasurePage = core._003COpenTreasurePage_003Ek__BackingField;
		if (!openTreasurePage._receivedClaimRequest)
		{
			openTreasurePage._receivedClaimRequest = true;
			OnlineStageManager instance = _instance;
			long startingOnlineClientFrame = _instance.GetStartingOnlineClientFrame();
			Action<long> action = null;
			((OnlineStageManager)(object)action).ClaimTreasure((long)_instance);
			bool flag = instance._sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
		}
	}

	public void SendClaimTreasureCommand()
	{
		//IL_003b: Expected I8, but got O
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		Action<long> action = null;
		((OnlineStageManager)(object)action).ClaimTreasure((long)this);
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void ClaimTreasure(long startingSimFrame)
	{
		GameManager core = GM.Core;
		Action onSyncedTimer = core._003COpenTreasurePage_003Ek__BackingField.TreasureCompleted;
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public unsafe void SendOnlineLevelUpCommand(bool shouldSwapToLevelUpUi, bool adjustXpFactors, List<WeaponType> chosenWeapons, List<ItemType> chosenItems, List<VampireSurvivors.Objects.Characters.CharacterController> amuletTargets, List<WeightedLimitBreak> limitBreaks)
	{
		//IL_0008: Expected O, but got Ref
		//IL_02b5: Expected O, but got I
		//IL_001d: Expected O, but got I
		//IL_0075: Expected O, but got I
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_00ed: Expected O, but got I4
		//IL_02cf: Expected O, but got I
		//IL_0053: Expected O, but got I4
		//IL_00fb: Expected O, but got I4
		//IL_012f: Expected O, but got Ref
		//IL_01cd: Expected O, but got I
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		//IL_0242: Expected O, but got I
		//IL_0329: Expected O, but got I4
		//IL_022d: Expected O, but got I8
		object obj2 = default(object);
		object obj = (object)(&obj2);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		byte[] array = SerializationUtils.SerializeEnum(chosenWeapons);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+67]");
		byte[] array2 = SerializationUtils.SerializeEnum((List<ItemType>)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+6F]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+6F]");
		object obj4;
		if ((nint)0 == 0)
		{
			obj4 = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdi_v2+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdi_v2+18]");
			object obj5 = num ^ 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdi_v2+18]");
			object obj6 = 0 & obj5;
			bool flag = (nint)obj6 < 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdi_v2+18]");
			bool flag2 = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdi_v2+18]");
			bool flag3 = (nint)0 == 0;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			obj4 = flag5 & flag4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+77]");
		byte[] array3 = SerializationUtils.SerializeLimitBreaks((List<WeightedLimitBreak>)0);
		_ = 0;
		_ = 0;
		if (obj4 == null)
		{
			obj3 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+77]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+4F]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+57]");
		_ = 0;
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		_ = gameSessionData._activeCharacter;
		OnlineLevelUpData levelUpData = (OnlineLevelUpData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1-79]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1-69]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1-59]");
		_ = 0;
		List<(string, object)> list = BuildLevelUpLogArgs(levelUpData);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5860");
		(string, object)[] args = default((string, object)[]);
		_logger.Info("Sending level Up Command", args);
		Action<long, bool, bool, CoherenceSync, byte[], byte[], bool, byte[]> action = null;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ r10_v3 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ r10_v3 (Il2CppMethodInfo)+4C]");
		object obj7 = (nint)0 >> 4;
		object obj8 = obj7 & 1;
		object obj9;
		if (obj8 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ r10_v3 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 8)
			{
				obj9 = 6447857024L;
				goto IL_0320;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v681 @ rax_v20 (System.Action`8<System.Int64, System.Boolean, System.Boolean, Coherence.Toolkit.CoherenceSync, System.Byte[], System.Byte[], System.Boolean, System.Byte[]>)+10]");
		obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v681 @ rax_v20 (System.Action`8<System.Int64, System.Boolean, System.Boolean, Coherence.Toolkit.CoherenceSync, System.Byte[], System.Byte[], System.Boolean, System.Byte[]>)+20]");
		_ = 0;
		goto IL_0320;
		IL_0320:
		object obj10 = 24;
		_ = 6447856784L;
		GameManager core2 = GM.Core;
		GameSessionData gameSessionData2 = core2._gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData2._activeCharacter;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F727D0");
	}

	private unsafe static List<(string, object)> BuildLevelUpLogArgs(OnlineLevelUpData levelUpData)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_003b: Expected O, but got I4
		//IL_0044: Expected O, but got I4
		//IL_01f3: Expected O, but got I4
		//IL_01fc: Expected O, but got I4
		//IL_06c2: Expected O, but got Ref
		//IL_06e4: Expected O, but got Ref
		//IL_06f7: Expected native int or pointer, but got O
		//IL_03a1: Expected O, but got I4
		//IL_03aa: Expected O, but got I4
		//IL_070f: Expected O, but got Ref
		//IL_0737: Expected O, but got Ref
		//IL_054f: Expected O, but got I4
		//IL_075e: Expected O, but got Ref
		//IL_0771: Expected native int or pointer, but got O
		//IL_0784: Expected O, but got Ref
		//IL_0080: Expected O, but got I
		//IL_0238: Expected O, but got I
		//IL_0093: Expected O, but got Ref
		//IL_00b0: Expected O, but got Ref
		//IL_00c4: Expected native int or pointer, but got O
		//IL_024b: Expected O, but got Ref
		//IL_0268: Expected O, but got Ref
		//IL_027c: Expected native int or pointer, but got O
		//IL_00dc: Expected O, but got Ref
		//IL_0117: Expected O, but got Ref
		//IL_012d: Expected I4, but got O
		//IL_07e3: Expected O, but got Ref
		//IL_0805: Expected O, but got Ref
		//IL_0818: Expected native int or pointer, but got O
		//IL_03f3: Expected O, but got Ref
		//IL_0421: Expected O, but got Ref
		//IL_0435: Expected native int or pointer, but got O
		//IL_0294: Expected O, but got Ref
		//IL_02cf: Expected O, but got Ref
		//IL_02e5: Expected I4, but got O
		//IL_0144: Expected O, but got Ref
		//IL_0156: Expected native int or pointer, but got O
		//IL_0830: Expected O, but got Ref
		//IL_0598: Expected O, but got Ref
		//IL_05c6: Expected O, but got Ref
		//IL_05da: Expected native int or pointer, but got O
		//IL_044d: Expected O, but got Ref
		//IL_02fc: Expected O, but got Ref
		//IL_030e: Expected native int or pointer, but got O
		//IL_016e: Expected O, but got Ref
		//IL_0198: Expected O, but got I
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_05f2: Expected O, but got Ref
		//IL_048d: Expected O, but got Ref
		//IL_04a0: Expected I4, but got O
		//IL_04b2: Expected O, but got Ref
		//IL_04c4: Expected native int or pointer, but got O
		//IL_0326: Expected O, but got Ref
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Expected O, but got Unknown
		//IL_0878: Expected O, but got Ref
		//IL_089a: Expected O, but got Ref
		//IL_08ad: Expected native int or pointer, but got O
		//IL_0632: Expected O, but got Ref
		//IL_0645: Expected I4, but got O
		//IL_0657: Expected O, but got Ref
		//IL_0669: Expected native int or pointer, but got O
		//IL_04dc: Expected O, but got Ref
		//IL_04ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Expected O, but got Unknown
		//IL_08c5: Expected O, but got Ref
		//IL_0681: Expected O, but got Ref
		//IL_06a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a9: Expected O, but got Unknown
		//IL_090a: Expected O, but got Ref
		//IL_0935: Expected O, but got Ref
		//IL_0948: Expected native int or pointer, but got O
		//IL_0960: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		List<(string, object)> list = new List<(string, object)>();
		bool flag = levelUpData._003CChosenLevelUpWeapons_003Ek__BackingField == null;
		IntPtr intPtr = default(IntPtr);
		nint num = intPtr;
		if (!flag)
		{
			List<WeaponType> list2 = levelUpData._003CChosenLevelUpWeapons_003Ek__BackingField;
			object obj3 = levelUpData._003CChosenLevelUpWeapons_003Ek__BackingField + 24;
			object obj4 = 0;
			object obj5 = 0;
			object arg = default(object);
			while (true)
			{
				bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
				num = 0;
				if (flag2)
				{
					break;
				}
				object obj6 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r13_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)obj6 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r13_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj7 = 0;
					object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					System.ParamsArray paramsArray = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg));
					System.ParamsArray args = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
					_ = 0;
					string item = string.FormatHelper((IFormatProvider)null, "Weapon {0}", args);
					object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rdi_v24+20+v92 @ r15_v25*4]");
					_ = 0;
					object item2 = (WeaponType)obj9;
					(string, object) tuple = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple, (item, item2));
					(string, object) item3 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
					_ = 0;
					list.Add(item3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
					obj3 = 0;
					obj4++;
					obj5 = obj4;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new IndexOutOfRangeException();
			}
		}
		bool flag3 = levelUpData._003CChosenLevelUpItems_003Ek__BackingField == null;
		nint num2 = num;
		if (!flag3)
		{
			List<ItemType> list3 = levelUpData._003CChosenLevelUpItems_003Ek__BackingField;
			object obj10 = 0;
			object obj11 = 0;
			object arg2 = default(object);
			while (true)
			{
				object obj12 = obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rcx_v65 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				bool flag4 = (nint)obj12 >= 0;
				num2 = num;
				if (flag4)
				{
					break;
				}
				object obj13 = obj10;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rcx_v65 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				if ((nint)obj13 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rcx_v65 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
					object obj14 = 0;
					object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					System.ParamsArray paramsArray2 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray2, new System.ParamsArray(arg2));
					System.ParamsArray args2 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
					_ = 0;
					string item4 = string.FormatHelper((IFormatProvider)null, "Item {0}", args2);
					object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v521 @ rdi_v21+20+v185 @ r15_v22*4]");
					_ = 0;
					object item5 = (ItemType)obj16;
					(string, object) tuple2 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple2, (item4, item5));
					(string, object) item6 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
					_ = 0;
					list.Add(item6);
					obj10++;
					num = 0;
					obj11 = obj10;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new IndexOutOfRangeException();
			}
		}
		bool flag5 = levelUpData._003CChosenAmuletTargets_003Ek__BackingField == null;
		nint num3 = num2;
		if (!flag5)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> list4 = levelUpData._003CChosenAmuletTargets_003Ek__BackingField;
			object obj17 = 0;
			object obj18 = 0;
			object arg3 = default(object);
			while (true)
			{
				bool flag6 = (nint)obj18 >= list4._size;
				num3 = num2;
				if (flag6)
				{
					break;
				}
				if ((nint)obj17 < list4._size)
				{
					VampireSurvivors.Objects.Characters.CharacterController[] items = list4._items;
					object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
					VampireSurvivors.Objects.Characters.CharacterController characterController = items[obj17];
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					System.ParamsArray paramsArray3 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray3, new System.ParamsArray(arg3));
					System.ParamsArray args3 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
					_ = 0;
					string item7 = string.FormatHelper((IFormatProvider)null, "Amulet Target {0}", args3);
					object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
					_ = characterController._characterType;
					object item8 = (CharacterType)obj20;
					(string, object) tuple3 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple3, (item7, item8));
					(string, object) item9 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
					_ = 0;
					list.Add(item9);
					obj17++;
					num2 = 0;
					obj18 = obj17;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new IndexOutOfRangeException();
			}
		}
		if (levelUpData._003CChosenLimitBreaks_003Ek__BackingField != null)
		{
			List<WeightedLimitBreak> list5 = levelUpData._003CChosenLimitBreaks_003Ek__BackingField;
			object obj21 = 0;
			object arg4 = default(object);
			List<(string, object)> result = default(List<(string, object)>);
			while ((nint)obj21 < list5._size)
			{
				if ((nint)obj21 < list5._size)
				{
					WeightedLimitBreak[] items2 = list5._items;
					object obj22 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
					WeightedLimitBreak weightedLimitBreak = items2[obj21];
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					System.ParamsArray paramsArray4 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray4, new System.ParamsArray(arg4));
					System.ParamsArray args4 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
					_ = 0;
					string item10 = string.FormatHelper((IFormatProvider)null, "Limit Break {0}", args4);
					object obj23 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
					_ = weightedLimitBreak.WeaponType;
					object item11 = (WeaponType)obj23;
					(string, object) tuple4 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple4, (item10, item11));
					(string, object) item12 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
					_ = 0;
					list.Add(item12);
					obj21++;
					num3 = 0;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
		}
		object obj24 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		_ = levelUpData._003CShouldSwapToLevelUpUi_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		(string, object) tuple5 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		_ = 0;
		object item13 = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple5, ("Should Swap To Level Up UI", item13));
		(string, object) item14 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
		_ = 0;
		list.Add(item14);
		object obj25 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		_ = levelUpData._003CAdjustXpFactors_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		(string, object) tuple6 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		_ = 0;
		object item15 = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple6, ("Adjust Xp Factors", item15));
		(string, object) item16 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-9]");
		_ = 0;
		list.Add(item16);
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		object obj26 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		_ = activeCharacter._xp;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		(string, object) tuple7 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 0;
		object item17 = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple7, ("Current Character Xp", item17));
		(string, object) item18 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7]");
		_ = 0;
		list.Add(item18);
		GameManager core2 = GM.Core;
		LevelUpFactory levelUpFactory = core2._levelUpFactory;
		object obj27 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		_ = levelUpFactory._currentXpFactor;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		(string, object) tuple8 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
		_ = 0;
		object item19 = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple8, ("Required Xp To Level Up", item19));
		(string, object) item20 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+17]");
		_ = 0;
		list.Add(item20);
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = levelUpData._003CTargetCharacter_003Ek__BackingField;
		_ = typeof(CharacterType);
		Enum obj28 = (Enum)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		_ = -1;
		_ = characterController2._characterType;
		string item21 = obj28.ToString();
		(string, object) tuple9 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple9, (ValueTuple<string, object>)("Character Leveling Up", item21));
		(string, object) item22 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
		_ = 0;
		list.Add(item22);
		return list;
	}

	public unsafe void OnlineLevelUp(long startingSimFrame, bool shouldSwapToLevelUpUi, bool adjustXpFactors, CoherenceSync activeCharacter, byte[] chosenWeapons, byte[] chosenItems, bool hasAmuletTargets, byte[] limitBreaks)
	{
		//IL_0008: Expected O, but got Ref
		//IL_01f9: Expected O, but got I
		//IL_006b: Expected O, but got I
		//IL_008a: Expected O, but got I
		//IL_00b8: Expected O, but got I
		//IL_00db: Expected O, but got I
		//IL_0115: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_003C_003Ec__DisplayClass110_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass110_0();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+6F]");
		if ((nint)0 != 0)
		{
			GameManager core = GM.Core;
			List<VampireSurvivors.Objects.Characters.CharacterController> list = core._levelUpFactory.FindFriendshipAmuletTargets(checkAmuletBag: false);
			List<VampireSurvivors.Objects.Characters.CharacterController> list2 = list;
			bool flag = false;
		}
		else
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> list2 = null;
			bool flag = shouldSwapToLevelUpUi;
		}
		_ = 0;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
		List<WeaponType> list3 = SerializationUtils.DeserializeEnum<WeaponType>((byte[])0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
		List<ItemType> list4 = SerializationUtils.DeserializeEnum<ItemType>((byte[])0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+77]");
		List<WeightedLimitBreak> list5 = SerializationUtils.DeserializeLimitBreaks((byte[])0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+57]");
		VampireSurvivors.Objects.Characters.CharacterController component = ((Component)0).GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-71]");
		CS_0024_003C_003E8__locals2.levelUpData = (OnlineLevelUpData)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-61]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-41]");
		_ = 0;
		OnlineLevelUpData levelUpData = (OnlineLevelUpData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		_ = CS_0024_003C_003E8__locals2.levelUpData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v2 (VampireSurvivors.OnlineStageManager+<>c__DisplayClass110_0)+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v2 (VampireSurvivors.OnlineStageManager+<>c__DisplayClass110_0)+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v2 (VampireSurvivors.OnlineStageManager+<>c__DisplayClass110_0)+40]");
		_ = 0;
		List<(string, object)> list6 = BuildLevelUpLogArgs(levelUpData);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5860");
		(string, object)[] args = default((string, object)[]);
		_logger.Info("Received Level Up Command", args);
		Action onSyncedTimer = delegate
		{
			//IL_0013: Expected O, but got Ref
			object obj3 = default(object);
			GM.Core.AddOnlineLevelUpToQueue((OnlineLevelUpData)(&obj3));
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer, canBePaused: false);
	}

	public void ProcessOnlineLevelUpData(OnlineLevelUpData levelUpData)
	{
		_003CChosenLevelUpWeapons_003Ek__BackingField = levelUpData._003CChosenLevelUpWeapons_003Ek__BackingField;
		_003CChosenLevelUpItems_003Ek__BackingField = levelUpData._003CChosenLevelUpItems_003Ek__BackingField;
		_003CChosenAmuletTargets_003Ek__BackingField = levelUpData._003CChosenAmuletTargets_003Ek__BackingField;
		_003CChosenLimitBreaks_003Ek__BackingField = levelUpData._003CChosenLimitBreaks_003Ek__BackingField;
	}

	public void SendLevelUpWithoutScreen()
	{
		//IL_003b: Expected I8, but got O
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		Action<long> action = null;
		((OnlineStageManager)(object)action).LevelUpWithoutScreen((long)this);
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void LevelUpWithoutScreen(long startingSimFrame)
	{
		Action onSyncedTimer = GM.Core.LevelUpWithoutScreen;
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendFinishLevelUpCommand(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController player)
	{
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		Action<long, int, CoherenceSync> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5950");
		int param = default(int);
		object param2 = default(object);
		bool flag = _sync.SendCommand((Action<long, int, object>)action, MessageTarget.All, startingOnlineClientFrame, param, param2);
	}

	public void FinishLevelUp(long startingSimFrame, int weaponType, CoherenceSync receivingCharacter)
	{
		_003C_003Ec__DisplayClass115_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass115_0();
		CS_0024_003C_003E8__locals4.receivingCharacter = receivingCharacter;
		CS_0024_003C_003E8__locals4.weaponTypeValue = (WeaponType)weaponType;
		Action onSyncedTimer = delegate
		{
			VampireSurvivors.Objects.Characters.CharacterController component = CS_0024_003C_003E8__locals4.receivingCharacter.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			GM.Core.OnlineFinishLevelUp(CS_0024_003C_003E8__locals4.weaponTypeValue, component);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendFinishLevelUpWithItemCommand(ItemType itemType, VampireSurvivors.Objects.Characters.CharacterController player)
	{
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		Action<long, int, CoherenceSync> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5950");
		int param = default(int);
		object param2 = default(object);
		bool flag = _sync.SendCommand((Action<long, int, object>)action, MessageTarget.All, startingOnlineClientFrame, param, param2);
	}

	public void FinishLevelUpWithItem(long startingSimFrame, int itemType, CoherenceSync receivingCharacter)
	{
		_003C_003Ec__DisplayClass117_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass117_0();
		CS_0024_003C_003E8__locals5._003C_003E4__this = this;
		CS_0024_003C_003E8__locals5.receivingCharacter = receivingCharacter;
		CS_0024_003C_003E8__locals5.itemTypeValue = (ItemType)itemType;
		Action onSyncedTimer = delegate
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			//IL_0084: Expected I, but got O
			//IL_00a3: Expected O, but got I
			OnlineStageManager onlineStageManager = CS_0024_003C_003E8__locals5._003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController component = CS_0024_003C_003E8__locals5.receivingCharacter.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendFinishLevelupWithFriendshipAmuletCommand()
	{
		//IL_003b: Expected I8, but got O
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		Action<long> action = null;
		((OnlineStageManager)(object)action).FinishLevelUpWithFriendshipAmulet((long)this);
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void FinishLevelUpWithFriendshipAmulet(long startingSimFrame)
	{
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0061: Expected I, but got O
			//IL_007d: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendFinishLevelUpWithLimitBreak(int limitBreakIndex, bool alwaysRandomLimitBreak, VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_0020: Expected O, but got I
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0095: Expected O, but got I
		//IL_00e7: Expected O, but got I4
		//IL_0080: Expected O, but got I8
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		Action<long, int, bool, CoherenceSync> action = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r10_v1 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r10_v1 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		object obj3;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r10_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 4)
			{
				obj3 = 6447794656L;
				goto IL_00de;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v3 (System.Action`4<System.Int64, System.Int32, System.Boolean, Coherence.Toolkit.CoherenceSync>)+10]");
		obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v3 (System.Action`4<System.Int64, System.Int32, System.Boolean, Coherence.Toolkit.CoherenceSync>)+20]");
		_ = 0;
		goto IL_00de;
		IL_00de:
		object obj4 = 24;
		_ = 6447794512L;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F64C80");
	}

	public void FinishLevelUpWithLimitBreak(long startingSimFrame, int limitBreakIndex, bool alwaysRandomLimitBreak, CoherenceSync receivingCharacter)
	{
		_003C_003Ec__DisplayClass121_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass121_0();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		CoherenceSync receivingCharacter2 = default(CoherenceSync);
		CS_0024_003C_003E8__locals6.receivingCharacter = receivingCharacter2;
		CS_0024_003C_003E8__locals6.limitBreakIndex = limitBreakIndex;
		CS_0024_003C_003E8__locals6.alwaysRandomLimitBreak = alwaysRandomLimitBreak;
		Action onSyncedTimer = delegate
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			//IL_0084: Expected I, but got O
			//IL_00a3: Expected O, but got I
			OnlineStageManager onlineStageManager = CS_0024_003C_003E8__locals6._003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController component = CS_0024_003C_003E8__locals6.receivingCharacter.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendBanishWeaponCommand(WeaponType weaponType)
	{
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		Action<long, int> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5A20");
		int param = default(int);
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
	}

	public void BanishWeaponOnline(long startingSimFrame, int weaponType)
	{
		_003C_003Ec__DisplayClass123_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass123_0();
		CS_0024_003C_003E8__locals3._003C_003E4__this = this;
		CS_0024_003C_003E8__locals3.weaponTypeValue = (WeaponType)weaponType;
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0070: Expected I, but got O
			//IL_008f: Expected O, but got I
			OnlineStageManager onlineStageManager = CS_0024_003C_003E8__locals3._003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendRequestLevelUpReRoll()
	{
		Action action = RequestLevelUpReRoll;
		bool flag = _sync.SendCommand(action, MessageTarget.AuthorityOnly);
	}

	public void RequestLevelUpReRoll()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	public void SendLevelUpReRollOnline(List<WeaponType> chosenWeapons)
	{
		byte[] param = SerializationUtils.SerializeEnum(chosenWeapons);
		Action<byte[]> action = LevelUpReRollOnline;
		bool flag = _sync.SendCommand((Action<object>)action, MessageTarget.All, param);
	}

	public void LevelUpReRollOnline(byte[] chosenWeapons)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0073: Expected I, but got O
		//IL_008f: Expected O, but got I
		List<WeaponType> list = SerializationUtils.DeserializeEnum<WeaponType>(chosenWeapons);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	public void SendLevelUpSkipOnline()
	{
		//IL_003b: Expected I8, but got O
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		Action<long> action = null;
		((OnlineStageManager)(object)action).LevelUpSkipOnline((long)this);
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void LevelUpSkipOnline(long startingSimFrame)
	{
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendRequestLevelUpPassOnline()
	{
		Action action = RequestLevelUpPassOnline;
		bool flag = _sync.SendCommand(action, MessageTarget.AuthorityOnly);
	}

	public void RequestLevelUpPassOnline()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	public void SendLevelUpPassOnline(VampireSurvivors.Objects.Characters.CharacterController activePlayer, bool showStats)
	{
		(string, object)[] args = new(string, object)[2];
		CharacterType characterType = default(CharacterType);
		object item = characterType;
		(string, object) tuple = ("Passing To Character", item);
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object item2 = default(object);
		(string, object) tuple2 = ("Show Stats", item2);
		_ = 0;
		_logger.Info("Sending Level Up Pass", args);
		Action<CoherenceSync, bool> action = LevelUpPassOnline;
		bool param = default(bool);
		bool flag = _sync.SendCommand((Action<object, bool>)action, MessageTarget.All, activePlayer._coherenceSync, param);
	}

	public void LevelUpPassOnline(CoherenceSync activePlayer, bool showStats)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_009d: Expected I, but got O
		//IL_00b9: Expected O, but got I
		VampireSurvivors.Objects.Characters.CharacterController component = activePlayer.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
		GameManager core = GM.Core;
		core._gameSessionData.ActiveCharacter = component;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	public void StartFriendshipAmulet()
	{
		Action action = RequestFriendshipAmulet;
		bool flag = _sync.SendCommand(action, MessageTarget.AuthorityOnly);
	}

	public void RequestFriendshipAmulet()
	{
		//IL_00d1: Expected I, but got O
		//IL_0152: Expected I8, but got O
		//IL_0066: Expected I4, but got O
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._characters != null)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			while (enumerator.MoveNext())
			{
				WeaponType? randomWeaponToLevelUp = FriendshipAmulet.GetRandomWeaponToLevelUp(null);
				if ((object)randomWeaponToLevelUp != null)
				{
					WeaponType weaponType = (WeaponType)((object?)randomWeaponToLevelUp >> 32);
					SendFriendshipAmuletLevelUpWeaponForCharacter(weaponType, null);
				}
			}
			long startingOnlineClientFrame = GetStartingOnlineClientFrame();
			Action<long> action = null;
			((OnlineStageManager)(object)action).FinishLevelUpWithFriendshipAmulet((long)this);
			if ((object)_sync != null)
			{
				bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void SendFriendshipAmuletLevelUpWeaponForCharacter(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_0047: Expected I, but got O
		Coherence.Log.Logger logger = _logger;
		(string, object)[] args = new(string, object)[2];
		WeaponType weaponType2 = default(WeaponType);
		object item = weaponType2;
		(string, object) tuple = ("Weapon", item);
		_ = 0;
		object item2 = (CharacterType)weaponType2;
		(string, object) tuple2 = ("Player", item2);
		_ = 0;
		nint num = (nint)logger;
		logger.Info("Sending friendship amulet level up", args);
		Action<long, int, CoherenceSync> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5950");
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		int param = default(int);
		object param2 = default(object);
		bool flag = _sync.SendOrderedCommand((Action<long, int, object>)action, MessageTarget.All, startingOnlineClientFrame, param, param2);
	}

	public void FriendshipAmuletLevelUpWeaponForCharacter(long simFrame, int weaponType, CoherenceSync player)
	{
		_003C_003Ec__DisplayClass137_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass137_0();
		int weaponTypeValue = default(int);
		CS_0024_003C_003E8__locals4.weaponTypeValue = (WeaponType)weaponTypeValue;
		VampireSurvivors.Objects.Characters.CharacterController component = player.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
		CS_0024_003C_003E8__locals4.character = component;
		(string, object)[] args = new(string, object)[2];
		WeaponType weaponType2 = default(WeaponType);
		object item = weaponType2;
		(string, object) tuple = ("Weapon", item);
		_ = 0;
		object item2 = (CharacterType)weaponType2;
		(string, object) tuple2 = ("Player", item2);
		_ = 0;
		_logger.Info("Received friendship amulet level up", args);
		Action onSyncedTimer = delegate
		{
			FriendshipAmulet.ApplyFriendshipAmuletLevelUp(CS_0024_003C_003E8__locals4.weaponTypeValue, CS_0024_003C_003E8__locals4.character);
		};
		FireSyncTimer(simFrame, onSyncedTimer);
	}

	public void SendMerchantPurchase(WeaponType weapon, ItemType item, int index, int price, VampireSurvivors.Objects.Characters.CharacterController purchasingPlayer)
	{
		//IL_0020: Expected O, but got I
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0095: Expected O, but got I
		//IL_00dd: Expected O, but got I4
		//IL_0080: Expected O, but got I8
		Action<long, int, int, int, int, CoherenceSync> action = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r9_v1 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r9_v1 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		object obj3;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r9_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 6)
			{
				obj3 = 6447803152L;
				goto IL_00d4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v2 (System.Action`6<System.Int64, System.Int32, System.Int32, System.Int32, System.Int32, Coherence.Toolkit.CoherenceSync>)+10]");
		obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v2 (System.Action`6<System.Int64, System.Int32, System.Int32, System.Int32, System.Int32, Coherence.Toolkit.CoherenceSync>)+20]");
		_ = 0;
		goto IL_00d4;
		IL_00d4:
		object obj4 = 24;
		_ = 6447802976L;
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F698A0");
	}

	public void MerchantPurchase(long simFrame, int weaponType, int itemType, int index, int price, CoherenceSync player)
	{
		_003C_003Ec__DisplayClass139_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass139_0();
		CS_0024_003C_003E8__locals7._003C_003E4__this = this;
		int index2 = default(int);
		CS_0024_003C_003E8__locals7.index = index2;
		int price2 = default(int);
		CS_0024_003C_003E8__locals7.price = price2;
		CS_0024_003C_003E8__locals7.weapon = (WeaponType)weaponType;
		CS_0024_003C_003E8__locals7.item = (ItemType)itemType;
		Component component2 = default(Component);
		VampireSurvivors.Objects.Characters.CharacterController component = component2.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
		CS_0024_003C_003E8__locals7.purchasingPlayer = component;
		Action onSyncedTimer = delegate
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			//IL_0075: Expected I, but got O
			//IL_0094: Expected O, but got I
			OnlineStageManager onlineStageManager = CS_0024_003C_003E8__locals7._003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		};
		FireSyncTimer(simFrame, onSyncedTimer);
	}

	public void SendCloseMerchant()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).CloseMerchant((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void CloseMerchant(long simFrame)
	{
		Action onSyncedTimer = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0040");
		};
		FireSyncTimer(simFrame, onSyncedTimer);
	}

	public void SendCloseItemFoundPage(bool discard)
	{
		Action<long, bool> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5AF0");
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool param = default(bool);
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
	}

	public void CloseItemFoundPage(long startingSimFrame, bool discard)
	{
		_003C_003Ec__DisplayClass143_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass143_0();
		CS_0024_003C_003E8__locals3._003C_003E4__this = this;
		CS_0024_003C_003E8__locals3.discard = discard;
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0070: Expected I, but got O
			//IL_008f: Expected O, but got I
			OnlineStageManager onlineStageManager = CS_0024_003C_003E8__locals3._003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendSelectArcana(ArcanaType arcanaType)
	{
		Action<long, int> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5A20");
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		int param = default(int);
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
	}

	public void SelectArcana(long startingSimFrame, int selectedArcana)
	{
		_003C_003Ec__DisplayClass145_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass145_0();
		CS_0024_003C_003E8__locals3._003C_003E4__this = this;
		CS_0024_003C_003E8__locals3.selectedArcana = selectedArcana;
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0070: Expected I, but got O
			//IL_008f: Expected O, but got I
			OnlineStageManager onlineStageManager = CS_0024_003C_003E8__locals3._003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendSelectCharacterCard(ArcanaType arcanaType, SkillCardEdition edition, ArcanaType? subCardType)
	{
		//IL_0020: Expected O, but got I
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0095: Expected O, but got I
		//IL_011d: Expected O, but got I4
		//IL_0080: Expected O, but got I8
		Action<long, int, int, int> action = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ r9_v1 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ r9_v1 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		object obj3;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ r9_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 4)
			{
				obj3 = 6447794864L;
				goto IL_0114;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Action`4<System.Int64, System.Int32, System.Int32, System.Int32>)+10]");
		obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (System.Action`4<System.Int64, System.Int32, System.Int32, System.Int32>)+20]");
		_ = 0;
		goto IL_0114;
		IL_0114:
		object obj4 = 24;
		_ = 6447794720L;
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		object obj5 = (object?)subCardType >> 32;
		object obj6 = ~obj5;
		object obj7 = obj6 >> 31;
		object obj8 = (object?)subCardType & obj7;
		if (obj8 == null || (object)subCardType != null)
		{
			int param = default(int);
			int param2 = default(int);
			int param3 = default(int);
			bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param, param2, param3);
		}
		else
		{
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		}
	}

	public void SelectCharacterCard(long startingSimFrame, int selectedArcana, int edition, int subCardType)
	{
		_003C_003Ec__DisplayClass147_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass147_0();
		CS_0024_003C_003E8__locals5._003C_003E4__this = this;
		int subCardType2 = default(int);
		CS_0024_003C_003E8__locals5.subCardType = subCardType2;
		CS_0024_003C_003E8__locals5.selectedArcana = selectedArcana;
		CS_0024_003C_003E8__locals5.edition = edition;
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0070: Expected I, but got O
			//IL_008f: Expected O, but got I
			OnlineStageManager onlineStageManager = CS_0024_003C_003E8__locals5._003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendReRollMinorArcanas()
	{
		Action action = ReRollMinorArcanas;
		bool flag = _sync.SendCommand(action, MessageTarget.All);
	}

	public void ReRollMinorArcanas()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	public void SendReRollCharacterCards()
	{
		Action action = ReRollCharacterCards;
		bool flag = _sync.SendCommand(action, MessageTarget.All);
	}

	public void ReRollCharacterCards()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	public void SendBoosterSurvarots()
	{
		Action action = BoosterSurvarots;
		bool flag = _sync.SendCommand(action, MessageTarget.All);
	}

	public void BoosterSurvarots()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	public void SendSkipMinorArcanas()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).SkipMinorArcanas((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void SkipMinorArcanas(long startingSimFrame)
	{
		Action onSyncedTimer = delegate
		{
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97770");
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendSkipSurvarots()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).SkipSurvarots((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void SkipSurvarots(long startingSimFrame)
	{
		Action onSyncedTimer = delegate
		{
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA19D0");
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendSkipTreasureAnimation()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).SkipTreasureAnimation((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void SkipTreasureAnimation(long startingSimFrame)
	{
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendTpWeaponSkip()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).TpWeaponSkip((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void TpWeaponSkip(long startingSimFrame)
	{
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendTpWeaponSelection(WeaponType weapon)
	{
		Action<long, int> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5A20");
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		int param = default(int);
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
	}

	public void SelectTpWeapon(long startingSimFrame, int weaponType)
	{
		_003C_003Ec__DisplayClass163_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass163_0();
		CS_0024_003C_003E8__locals3._003C_003E4__this = this;
		CS_0024_003C_003E8__locals3.weapon = (WeaponType)weaponType;
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0070: Expected I, but got O
			//IL_008f: Expected O, but got I
			OnlineStageManager onlineStageManager = CS_0024_003C_003E8__locals3._003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendCandyBoxWeaponSelection(WeaponType weapon)
	{
		Action<long, int> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5A20");
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		int param = default(int);
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
	}

	public void SelectWeaponFromCandyBox(long startingSimFrame, int weaponType)
	{
		_003C_003Ec__DisplayClass165_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass165_0();
		CS_0024_003C_003E8__locals3._003C_003E4__this = this;
		CS_0024_003C_003E8__locals3.weapon = (WeaponType)weaponType;
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0070: Expected I, but got O
			//IL_008f: Expected O, but got I
			OnlineStageManager onlineStageManager = CS_0024_003C_003E8__locals3._003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendCandyBoxSkip()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).CandyBoxSkip((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void SendLevelUpBonusSelection(PowerUpType levelUpBonus)
	{
		Action<long, int> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5A20");
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		int param = default(int);
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
	}

	public void LevelUpBonusSelection(long startingSimFrame, int powerUpBonus)
	{
		_003C_003Ec__DisplayClass168_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass168_0();
		CS_0024_003C_003E8__locals3._003C_003E4__this = this;
		CS_0024_003C_003E8__locals3.bonus = (PowerUpType)powerUpBonus;
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0070: Expected I, but got O
			//IL_008f: Expected O, but got I
			OnlineStageManager onlineStageManager = CS_0024_003C_003E8__locals3._003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void CandyBoxSkip(long startingSimFrame)
	{
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendLevelBonusSelectionSkip()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).LevelBonusSelectionSkip((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void LevelBonusSelectionSkip(long startingSimFrame)
	{
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendOpenPiano(VampireSurvivors.Objects.Characters.CharacterController nearestPlayer)
	{
		Action<long, CoherenceSync> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA56D0");
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F6D7F0");
	}

	public void OpenPiano(long startingSimFrame, CoherenceSync nearestPlayer)
	{
		_003C_003Ec__DisplayClass173_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass173_0();
		CS_0024_003C_003E8__locals2.nearestPlayer = nearestPlayer;
		Action onSyncedTimer = delegate
		{
			VampireSurvivors.Objects.Characters.CharacterController component = CS_0024_003C_003E8__locals2.nearestPlayer.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			GM.Core.QueueEnterPianoScene(component);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendSuccessfulPiano()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).SuccessfulPiano((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void SuccessfulPiano(long startingSimFrame)
	{
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendExitPiano()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).ExitPiano((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void ExitPiano(long startingSimFrame)
	{
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendRightCoffinOpened()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).RightCoffinOpened((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void RightCoffinOpened(long startingSimFrame)
	{
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendTouchedPianoKey(int key)
	{
		//IL_0031: Expected I4, but got O
		Action<int> action = null;
		((OnlineStageManager)(object)action).TouchedPianoKey((int)this);
		bool flag = _sync.SendCommand(action, MessageTarget.Other, key);
	}

	public void TouchedPianoKey(int touchedPianoKey)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0061: Expected I, but got O
		//IL_007d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	public void SendRevealCharacter()
	{
		Action action = RevealCharacter;
		bool flag = _sync.SendCommand(action, MessageTarget.All);
	}

	public void RevealCharacter()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	public void SendCollectCharacter()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).CollectCharacter((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void CollectCharacter(long startingSimFrame)
	{
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendSelectDirecterTooEasy()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).SelectDirecterTooEasy((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void SelectDirecterTooEasy(long startingSimFrame)
	{
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendSelectDirecterTooHard()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).SelectDirecterTooHard((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void SelectDirecterTooHard(long startingSimFrame)
	{
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendSelectDirecterOkButton()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).SelectDirecterOkButton((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void SelectDirecterOkButton(long startingSimFrame)
	{
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendSetMadMoonSymbols(string serializedSymbols)
	{
		Action<string, long> action = SetMadMoonSymbols;
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		long param = default(long);
		bool flag = _sync.SendCommand((Action<object, long>)action, MessageTarget.All, serializedSymbols, param);
	}

	public void SetMadMoonSymbols(string serializedSymbols, long startingSimFrame)
	{
		_003C_003Ec__DisplayClass193_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass193_0();
		CS_0024_003C_003E8__locals3._003C_003E4__this = this;
		CS_0024_003C_003E8__locals3.serializedSymbols = serializedSymbols;
		Action onSyncedTimer = delegate
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			//IL_0075: Expected I, but got O
			//IL_0094: Expected O, but got I
			OnlineStageManager onlineStageManager = CS_0024_003C_003E8__locals3._003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendDirecterStageSwitch(int newStage)
	{
		Action<long, int> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5A20");
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		int param = default(int);
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
	}

	public void DirecterStageSwitch(long startingSimFrame, int newStage)
	{
		_003C_003Ec__DisplayClass195_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass195_0();
		CS_0024_003C_003E8__locals3._003C_003E4__this = this;
		CS_0024_003C_003E8__locals3.newStage = newStage;
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0070: Expected I, but got O
			//IL_008f: Expected O, but got I
			OnlineStageManager onlineStageManager = CS_0024_003C_003E8__locals3._003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendEnterTheBossi()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).EnterTheBossi((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void EnterTheBossi(long startingSimFrame)
	{
		Action onSyncedTimer = GM.Core.EnterTheBossi;
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendWestwoodsSpin()
	{
		//IL_005c: Expected I4, but got I8
		//IL_0060: Expected O, but got I4
		Action<long, int> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5A20");
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		object obj = UnityEngine.Random.RandomRangeInt(-2147483648, 2147483647);
		int param = default(int);
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
	}

	public void WestwoodsSpin(long startingSimFrame, int seed)
	{
		_003C_003Ec__DisplayClass199_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass199_0();
		CS_0024_003C_003E8__locals3._003C_003E4__this = this;
		CS_0024_003C_003E8__locals3.seed = seed;
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0070: Expected I, but got O
			//IL_008f: Expected O, but got I
			OnlineStageManager onlineStageManager = CS_0024_003C_003E8__locals3._003C_003E4__this;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			onlineStageManager._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendPauseRequest(VampireSurvivors.Objects.Characters.CharacterController pausingPlayer)
	{
		GameManager core = GM.Core;
		if (core._003CCanPause_003Ek__BackingField)
		{
			Coherence.Log.Logger logger = _logger;
			(string, object)[] args = new(string, object)[2];
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object item = default(object);
			(string, object) tuple = ("Sent Pause Request", item);
			_ = 0;
			bool flag = default(bool);
			object item2 = (flag ? CharacterType.ANTONIO : CharacterType.VOID);
			(string, object) tuple2 = ("Pausing Player", item2);
			_ = 0;
			logger.Info("Attempting Send Pause Request", args);
			if (!_sentPauseRequest)
			{
				(string, object)[] args2 = new(string, object)[1];
				CharacterType characterType = default(CharacterType);
				object item3 = characterType;
				(string, object) tuple3 = ("Pausing Player", item3);
				_ = 0;
				_logger.Info("Sending Pause Request", args2);
				_sentPauseRequest = true;
				Action<CoherenceSync> action = PauseRequest;
				bool flag2 = _sync.SendCommand((Action<object>)action, MessageTarget.AuthorityOnly, pausingPlayer._coherenceSync);
			}
		}
	}

	public void PauseRequest(CoherenceSync pausingPlayer)
	{
		//IL_0039: Expected I, but got O
		Coherence.Log.Logger logger = _logger;
		(string, object)[] args = new(string, object)[1];
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object item = default(object);
		(string, object) tuple = ("Is Game Paused", item);
		_ = 0;
		nint num = (nint)logger;
		logger.Info("Received Pause Request and sending generic pause", args);
		Action<long, CoherenceSync> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA56D0");
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F6D7F0");
	}

	public void GenericPause(long startingSimFrame, CoherenceSync pausingPlayer)
	{
		//IL_0090: Expected O, but got I
		_003C_003Ec__DisplayClass203_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass203_0();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		CoherenceSync pausingPlayer2 = default(CoherenceSync);
		CS_0024_003C_003E8__locals6.pausingPlayer = pausingPlayer2;
		CoherenceSync pausingPlayer3 = CS_0024_003C_003E8__locals6.pausingPlayer;
		NetworkEntityState networkEntityState = pausingPlayer3._003CEntityState_003Ek__BackingField;
		if (pausingPlayer3._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v26 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v26 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v26 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				VampireSurvivors.Objects.Characters.CharacterController component = CS_0024_003C_003E8__locals6.pausingPlayer.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
				component.FreezePlayer(freeze: true);
				return;
			}
		}
		GameManager core = GM.Core;
		if (!core._isPaused)
		{
			(string, object)[] args = new(string, object)[1];
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object item = default(object);
			(string, object) tuple = ("Is Game Paused", item);
			_ = 0;
			_logger.Info("Firing Pausing Game Timer", args);
			Action onSyncedTimer = delegate
			{
				CS_0024_003C_003E8__locals6._003C_003E4__this.PerformGenericPause(CS_0024_003C_003E8__locals6.pausingPlayer);
			};
			FireSyncTimer(startingSimFrame, onSyncedTimer);
		}
	}

	public void SendFreezeMyPlayer(bool freeze)
	{
		//IL_0020: Expected O, but got I
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0095: Expected O, but got I
		//IL_00ef: Expected O, but got I4
		//IL_0080: Expected O, but got I8
		Action<long, bool, CoherenceSync> action = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r9_v1 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r9_v1 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		object obj3;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ r9_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 3)
			{
				obj3 = 6447778624L;
				goto IL_00e6;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Action`3<System.Int64, System.Boolean, Coherence.Toolkit.CoherenceSync>)+10]");
		obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Action`3<System.Int64, System.Boolean, Coherence.Toolkit.CoherenceSync>)+20]");
		_ = 0;
		goto IL_00e6;
		IL_00e6:
		object obj4 = 24;
		_ = 6447778480L;
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		PlayerInfo myPlayerInfo = GetMyPlayerInfo();
		VampireSurvivors.Objects.Characters.CharacterController characterController = myPlayerInfo.CharacterController;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F6E4C0");
	}

	public void FreezePlayer(long startingSimFrame, bool freeze, CoherenceSync resumingPlayer)
	{
		_003C_003Ec__DisplayClass205_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass205_0();
		CS_0024_003C_003E8__locals4.resumingPlayer = resumingPlayer;
		CS_0024_003C_003E8__locals4.freeze = freeze;
		Action onSyncedTimer = delegate
		{
			VampireSurvivors.Objects.Characters.CharacterController component = CS_0024_003C_003E8__locals4.resumingPlayer.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			component.FreezePlayer(CS_0024_003C_003E8__locals4.freeze);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendForceCloseUi()
	{
		//IL_003b: Expected I8, but got O
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		Action<long> action = null;
		((OnlineStageManager)(object)action).ForceCloseUi((long)this);
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void ForceCloseUi(long startingSimFrame)
	{
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendTransitionToHolyForbidden()
	{
		//IL_0028: Expected I8, but got O
		(string, object)[] args = Array.Empty<(string, object)>();
		_logger.Info("Sending Holy Forbidden Transition", args);
		Action<long> action = null;
		((OnlineStageManager)(object)action).TransitionToHolyForbidden((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void TransitionToHolyForbidden(long startingSimFrame)
	{
		Action onSyncedTimer = TransitionToHolyForbidden;
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendTransitionTP_ADV_001_Stage_DEATHFIGHT()
	{
		//IL_0028: Expected I8, but got O
		(string, object)[] args = Array.Empty<(string, object)>();
		_logger.Info("Sending TP_ADV_001_Stage_DEATHFIGHT Transition", args);
		Action<long> action = null;
		((OnlineStageManager)(object)action).TransitionTP_ADV_001_Stage_DEATHFIGHT((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void TransitionTP_ADV_001_Stage_DEATHFIGHT(long startingSimFrame)
	{
		Action onSyncedTimer = TransitionToTP_ADV_001_Stage_DEATHFIGHT;
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	private void TransitionToTP_ADV_001_Stage_DEATHFIGHT()
	{
		GM.Core.TransitionToTP_ADV_001_Stage_DEATHFIGHT();
	}

	public void SendTransitionToFoscari2()
	{
		//IL_0028: Expected I8, but got O
		(string, object)[] args = Array.Empty<(string, object)>();
		_logger.Info("Sending Foscari2 Transition", args);
		Action<long> action = null;
		((OnlineStageManager)(object)action).TransitionToFoscari2((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void TransitionToFoscari2(long startingSimFrame)
	{
		Action onSyncedTimer = GM.Core.TransitionToFoscari2;
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendOpenMainArcanaPage()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).OpenMainArcanaPage((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendOrderedCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void OpenMainArcanaPage(long startingSimFrame)
	{
		Action onSyncedTimer = _003C_003Ec._003C_003E9__216_0;
		if (_003C_003Ec._003C_003E9__216_0 == null)
		{
			onSyncedTimer = (_003C_003Ec._003C_003E9__216_0 = delegate
			{
				GM.Core.QueueOpenArcana(ArcanaUiType.MAIN);
			});
		}
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendArcanaModeTransition()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).ArcanaModeTransition((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void ArcanaModeTransition(long startingSimFrame)
	{
		Action onSyncedTimer = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendBackground3GRAZIELLAUnlock()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).Background3GRAZIELLAUnlock((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void Background3GRAZIELLAUnlock(long startingSimFrame)
	{
		//IL_0061: Expected I, but got O
		//IL_0069: Expected I, but got O
		//IL_0079: Expected O, but got I
		//IL_00f9: Expected O, but got I4
		//IL_00b5: Expected O, but got I
		//IL_00eb: Expected O, but got I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		object fancyBg = stage._fancyBg;
		object obj;
		if ((object)stage._fancyBg == null)
		{
			obj = null;
			goto IL_011f;
		}
		nint num = (nint)typeof(Background3);
		nint num2 = (nint)fancyBg;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Stages.Background3>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v4 (Il2CppClass<System.Object>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Stages.Background3>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v4 (Il2CppClass<System.Object>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v12+FFFFFFF8+v97 @ rax_v8*8]");
			if (0 == (nint)typeof(Background3))
			{
				obj4 = 1;
				goto IL_014b;
			}
		}
		obj4 = 0;
		goto IL_014b;
		IL_014b:
		bool flag = obj4 == null;
		obj = null;
		if (!flag)
		{
			obj = stage._fancyBg;
		}
		goto IL_011f;
		IL_011f:
		Action onSyncedTimer = ((Background3)obj).AwardGRAZIELLAUnlock;
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendBackground1NeoUnlock()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).SendBackground1NeoUnlock((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void SendBackground1NeoUnlock(long startingSimFrame)
	{
		//IL_0061: Expected I, but got O
		//IL_0069: Expected I, but got O
		//IL_0079: Expected O, but got I
		//IL_00f9: Expected O, but got I4
		//IL_00b5: Expected O, but got I
		//IL_00eb: Expected O, but got I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		object fancyBg = stage._fancyBg;
		object obj;
		if ((object)stage._fancyBg == null)
		{
			obj = null;
			goto IL_011f;
		}
		nint num = (nint)typeof(Background1);
		nint num2 = (nint)fancyBg;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Stages.Background1>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v4 (Il2CppClass<System.Object>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Stages.Background1>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v4 (Il2CppClass<System.Object>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v12+FFFFFFF8+v97 @ rax_v8*8]");
			if (0 == (nint)typeof(Background1))
			{
				obj4 = 1;
				goto IL_014b;
			}
		}
		obj4 = 0;
		goto IL_014b;
		IL_014b:
		bool flag = obj4 == null;
		obj = null;
		if (!flag)
		{
			obj = stage._fancyBg;
		}
		goto IL_011f;
		IL_011f:
		Action onSyncedTimer = ((Background1)obj).AwardNeoUnlock;
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendAdvanceDevilRoomLevel()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).AdvanceDevilRoomLevel((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void AdvanceDevilRoomLevel(long startingSimFrame)
	{
		//IL_0061: Expected I, but got O
		//IL_0069: Expected I, but got O
		//IL_0079: Expected O, but got I
		//IL_00f9: Expected O, but got I4
		//IL_00b5: Expected O, but got I
		//IL_00eb: Expected O, but got I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		object fancyBg = stage._fancyBg;
		object obj;
		if ((object)stage._fancyBg == null)
		{
			obj = null;
			goto IL_011f;
		}
		nint num = (nint)typeof(BackgroundDevilRoom);
		nint num2 = (nint)fancyBg;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundDevilRoom>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v4 (Il2CppClass<System.Object>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundDevilRoom>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v4 (Il2CppClass<System.Object>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v12+FFFFFFF8+v97 @ rax_v8*8]");
			if (0 == (nint)typeof(BackgroundDevilRoom))
			{
				obj4 = 1;
				goto IL_014b;
			}
		}
		obj4 = 0;
		goto IL_014b;
		IL_014b:
		bool flag = obj4 == null;
		obj = null;
		if (!flag)
		{
			obj = stage._fancyBg;
		}
		goto IL_011f;
		IL_011f:
		Action onSyncedTimer = ((BackgroundDevilRoom)obj).AdvanceLevel;
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendDarkassoCutscene(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		Action<long, CoherenceSync> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA56D0");
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		object param = default(object);
		bool flag = _sync.SendCommand((Action<long, object>)action, MessageTarget.All, startingOnlineClientFrame, param);
	}

	public void DarkassoCutscene(long startingSimFrame, CoherenceSync player)
	{
		//IL_0073: Expected I, but got O
		//IL_007b: Expected I, but got O
		//IL_008b: Expected O, but got I
		//IL_010b: Expected O, but got I4
		//IL_00c7: Expected O, but got I
		//IL_00fd: Expected O, but got I4
		_003C_003Ec__DisplayClass226_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass226_0();
		CS_0024_003C_003E8__locals4.player = player;
		GameManager core = GM.Core;
		Stage stage = core._stage;
		BackgroundDevilRoom fancyBg = (BackgroundDevilRoom)stage._fancyBg;
		BackgroundDevilRoom devilRoom;
		if ((object)stage._fancyBg == null)
		{
			devilRoom = null;
			goto IL_016b;
		}
		nint num = (nint)typeof(BackgroundDevilRoom);
		nint num2 = (nint)fancyBg;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundDevilRoom>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ r10_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundDevilRoom>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundDevilRoom>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ r10_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundDevilRoom>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rax_v23+FFFFFFF8+v236 @ rax_v18*8]");
			if (0 == (nint)typeof(BackgroundDevilRoom))
			{
				obj3 = 1;
				goto IL_017d;
			}
		}
		obj3 = 0;
		goto IL_017d;
		IL_017d:
		bool flag = obj3 == null;
		devilRoom = null;
		if (!flag)
		{
			devilRoom = (BackgroundDevilRoom)stage._fancyBg;
		}
		goto IL_016b;
		IL_016b:
		CS_0024_003C_003E8__locals4.devilRoom = devilRoom;
		Action onSyncedTimer = delegate
		{
			VampireSurvivors.Objects.Characters.CharacterController component = CS_0024_003C_003E8__locals4.player.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			CS_0024_003C_003E8__locals4.devilRoom.TriggerCutscene(component);
		};
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendGift(Vector2 startPosition, Vector2 endPosition, ItemType itemType, WeaponType weaponType)
	{
		//IL_0020: Expected O, but got I
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0095: Expected O, but got I
		//IL_00fb: Expected O, but got I4
		//IL_0080: Expected O, but got I8
		Action<Vector2, Vector2, int, int> action = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		object obj3;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 4)
			{
				obj3 = 6447799184L;
				goto IL_00f2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Action`4<UnityEngine.Vector2, UnityEngine.Vector2, System.Int32, System.Int32>)+10]");
		obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Action`4<UnityEngine.Vector2, UnityEngine.Vector2, System.Int32, System.Int32>)+20]");
		_ = 0;
		goto IL_00f2;
		IL_00f2:
		object obj4 = 24;
		_ = 6447799008L;
		Vector2 param = default(Vector2);
		int param2 = default(int);
		int param3 = default(int);
		bool flag = _sync.SendCommand(action, MessageTarget.All, startPosition, param, param2, param3);
	}

	public unsafe void ProcessGift(Vector2 startPosition, Vector2 endPosition, int itemType, int weaponType)
	{
		//IL_003e: Expected I, but got O
		//IL_00e0: Expected I4, but got O
		//IL_00a6: Expected I, but got O
		//IL_010e: Expected I, but got O
		//IL_01c8: Expected O, but got Ref
		//IL_0176: Expected I, but got O
		object[] array = new object[4];
		Vector2 vector = default(Vector2);
		object obj = vector;
		if (obj != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj3 = vector;
		if (obj3 != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj5 = (ItemType)vector;
		if (obj5 != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		int num4 = default(int);
		object obj7 = (WeaponType)num4;
		if (obj7 != null)
		{
			nint num5 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj8 = default(object);
			if (obj8 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		System.ParamsArray paramsArray = new System.ParamsArray(array);
		object obj9 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Processing Gift: {0} {1} {2} {3}", (System.ParamsArray)(&obj9));
		Debug.Log(message);
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		WeaponType weaponType2 = default(WeaponType);
		arcanaManager.arcanaManager_Support.SendGift(startPosition, endPosition, (ItemType)itemType, weaponType2);
	}

	public void SendStartSabotagion(float duration, int chosenEventTarget, Vector2 targetLocation, string newsFeedText, bool isPickleRush)
	{
		//IL_0020: Expected O, but got I
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0095: Expected O, but got I
		//IL_00ff: Expected O, but got I4
		//IL_0080: Expected O, but got I8
		Action<float, int, Vector2, string, bool> action = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		object obj3;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r10_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 5)
			{
				obj3 = 6447802048L;
				goto IL_00f6;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Action`5<System.Single, System.Int32, UnityEngine.Vector2, System.String, System.Boolean>)+10]");
		obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Action`5<System.Single, System.Int32, UnityEngine.Vector2, System.String, System.Boolean>)+20]");
		_ = 0;
		goto IL_00f6;
		IL_00f6:
		object obj4 = 24;
		_ = 6447801872L;
		int param = default(int);
		Vector2 param2 = default(Vector2);
		object param3 = default(object);
		bool param4 = default(bool);
		bool flag = _sync.SendCommand((Action<float, int, Vector2, object, bool>)action, MessageTarget.All, duration, param, param2, param3, param4);
	}

	public void StartSabotagion(float duration, int chosenEventTarget, Vector2 targetLocation, string newsFeedText, bool isPickleRush)
	{
		GameManager core = GM.Core;
		Stage stage = core._stage;
		stage._stageEventManager.StartSabotagion(duration, chosenEventTarget, targetLocation, newsFeedText, isPickleRush);
	}

	public void SendStartCoopGaeaEvent()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).StartCoopGaeaEvent((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void StartCoopGaeaEvent(long startingSimFrame)
	{
		//IL_0061: Expected I, but got O
		//IL_0069: Expected I, but got O
		//IL_0079: Expected O, but got I
		//IL_00f9: Expected O, but got I4
		//IL_00b5: Expected O, but got I
		//IL_00eb: Expected O, but got I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		object fancyBg = stage._fancyBg;
		object obj;
		if ((object)stage._fancyBg == null)
		{
			obj = null;
			goto IL_011f;
		}
		nint num = (nint)typeof(BackgroundCoop);
		nint num2 = (nint)fancyBg;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundCoop>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v4 (Il2CppClass<System.Object>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundCoop>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v4 (Il2CppClass<System.Object>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v12+FFFFFFF8+v97 @ rax_v8*8]");
			if (0 == (nint)typeof(BackgroundCoop))
			{
				obj4 = 1;
				goto IL_014b;
			}
		}
		obj4 = 0;
		goto IL_014b;
		IL_014b:
		bool flag = obj4 == null;
		obj = null;
		if (!flag)
		{
			obj = stage._fancyBg;
		}
		goto IL_011f;
		IL_011f:
		Action onSyncedTimer = ((BackgroundCoop)obj).StartGaeaEvent;
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendCoopSetFirstEnmemyKilled()
	{
		//IL_0031: Expected I8, but got O
		Action<long> action = null;
		((OnlineStageManager)(object)action).CoopSetFirstEnmemyKilled((long)this);
		long startingOnlineClientFrame = GetStartingOnlineClientFrame();
		bool flag = _sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void CoopSetFirstEnmemyKilled(long startingSimFrame)
	{
		//IL_0061: Expected I, but got O
		//IL_0069: Expected I, but got O
		//IL_0079: Expected O, but got I
		//IL_00f9: Expected O, but got I4
		//IL_00b5: Expected O, but got I
		//IL_00eb: Expected O, but got I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		object fancyBg = stage._fancyBg;
		object obj;
		if ((object)stage._fancyBg == null)
		{
			obj = null;
			goto IL_011f;
		}
		nint num = (nint)typeof(BackgroundCoop);
		nint num2 = (nint)fancyBg;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundCoop>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v4 (Il2CppClass<System.Object>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundCoop>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v4 (Il2CppClass<System.Object>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v12+FFFFFFF8+v97 @ rax_v8*8]");
			if (0 == (nint)typeof(BackgroundCoop))
			{
				obj4 = 1;
				goto IL_014b;
			}
		}
		obj4 = 0;
		goto IL_014b;
		IL_014b:
		bool flag = obj4 == null;
		obj = null;
		if (!flag)
		{
			obj = stage._fancyBg;
		}
		goto IL_011f;
		IL_011f:
		Action onSyncedTimer = ((BackgroundCoop)obj).SetFirstEnmemyKilled;
		FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendOpenTerrace()
	{
		if (!_sentOpenTerrace)
		{
			_sentOpenTerrace = true;
			Action action = OpenTerrace;
			bool flag = _sync.SendCommand(action, MessageTarget.All);
		}
	}

	public void OpenTerrace()
	{
		//IL_0054: Expected I, but got O
		//IL_005c: Expected I, but got O
		//IL_006c: Expected O, but got I
		//IL_00ec: Expected O, but got I4
		//IL_00a8: Expected O, but got I
		//IL_00de: Expected O, but got I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		Background5 fancyBg = (Background5)stage._fancyBg;
		if ((object)stage._fancyBg == null)
		{
			return;
		}
		nint num = (nint)typeof(Background5);
		nint num2 = (nint)fancyBg;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.Background5>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.Background5>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.Background5>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.Background5>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v10+FFFFFFF8+v79 @ rax_v5*8]");
			if (0 == (nint)typeof(Background5))
			{
				obj3 = 1;
				goto IL_011c;
			}
		}
		obj3 = 0;
		goto IL_011c;
		IL_011c:
		bool flag = obj3 == null;
		Background5 background = null;
		if (!flag)
		{
			background = (Background5)stage._fancyBg;
		}
		background?.OpenTerrace();
	}

	public void SendMazerellaUnlockTorinoSecret()
	{
		Action action = MazerellaUnlockTorinoSecret;
		bool flag = _sync.SendCommand(action, MessageTarget.All);
	}

	public void MazerellaUnlockTorinoSecret()
	{
		//IL_0054: Expected I, but got O
		//IL_005c: Expected I, but got O
		//IL_006c: Expected O, but got I
		//IL_00ec: Expected O, but got I4
		//IL_00a8: Expected O, but got I
		//IL_00de: Expected O, but got I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		BackgroundMazerella fancyBg = (BackgroundMazerella)stage._fancyBg;
		if ((object)stage._fancyBg == null)
		{
			return;
		}
		nint num = (nint)typeof(BackgroundMazerella);
		nint num2 = (nint)fancyBg;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundMazerella>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundMazerella>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundMazerella>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundMazerella>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v10+FFFFFFF8+v79 @ rax_v5*8]");
			if (0 == (nint)typeof(BackgroundMazerella))
			{
				obj3 = 1;
				goto IL_011c;
			}
		}
		obj3 = 0;
		goto IL_011c;
		IL_011c:
		bool flag = obj3 == null;
		BackgroundMazerella backgroundMazerella = null;
		if (!flag)
		{
			backgroundMazerella = (BackgroundMazerella)stage._fancyBg;
		}
		backgroundMazerella?.UnlockTorino();
	}

	public void OnlineSetEnemyFollowerData(short enemyType, bool wasCartRider)
	{
		//IL_006f: Expected O, but got I
		//IL_0089: Expected O, but got I
		GameManager core = GM.Core;
		Dictionary<EnemyType, List<EnemyData>> convertedEnemyData = core._dataManager.GetConvertedEnemyData();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedEnemyData).get_Item((System.Int32Enum)enemyType);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v11 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v11 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v12+20]");
			core._latestKilledEnemyThatCanBeFollowerData = (EnemyData)0;
			core._latestKilledEnemyWasCartRider = wasCartRider;
			core._latestKilledEnemyThatCanBeFollowerType = (EnemyType)enemyType;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void OnlineSetRecycledEnemyFollowerData(short enemyType, bool wasCartRider, CoherenceSync followedCharacterSync)
	{
		GM.Core.FromOnlineSetRecycledEnemyFollowerData(enemyType, wasCartRider, followedCharacterSync);
	}

	public void SendTurnOnVaccuum(VampireSurvivors.Objects.Characters.CharacterController target)
	{
		//IL_000e: Expected I4, but got O
		(string, object)[] args = new(string, object)[1];
		object obj = default(object);
		object item = (CharacterType)obj;
		(string, object) tuple = ("Target", item);
		_ = 0;
		_logger.Info("Sending Turn On Vaccuum", args);
		Action<CoherenceSync> action = TurnOnVaccuum;
		bool flag = _sync.SendCommand((Action<object>)action, MessageTarget.All, target._coherenceSync);
	}

	public void TurnOnVaccuum(CoherenceSync target)
	{
		VampireSurvivors.Objects.Characters.CharacterController component = target.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
		GM.Core.TurnOnVacuum(component);
	}

	public void SendSnapYellows(PickupWeapon gRing, PickupWeapon sRing, PickupWeapon lMeta, PickupWeapon rMeta, VampireSurvivors.Objects.Characters.CharacterController player)
	{
		Action<CoherenceSync, CoherenceSync, CoherenceSync, CoherenceSync, CoherenceSync> action = SnapYellows;
		object param = default(object);
		object param2 = default(object);
		object param3 = default(object);
		object param4 = default(object);
		bool flag = _sync.SendCommand((Action<object, object, object, object, object>)action, MessageTarget.All, ((NetworkPickup)gRing)._coherenceSync, param, param2, param3, param4);
	}

	public void SnapYellows(CoherenceSync gRing, CoherenceSync sRing, CoherenceSync lMeta, CoherenceSync rMeta, CoherenceSync player)
	{
		//IL_0054: Expected I, but got O
		//IL_005c: Expected I, but got O
		//IL_006c: Expected O, but got I
		//IL_00ec: Expected O, but got I4
		//IL_00a8: Expected O, but got I
		//IL_00de: Expected O, but got I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		Background5 fancyBg = (Background5)stage._fancyBg;
		if ((object)stage._fancyBg == null)
		{
			return;
		}
		nint num = (nint)typeof(Background5);
		nint num2 = (nint)fancyBg;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Stages.Background5>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Stages.Background5>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Stages.Background5>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Stages.Background5>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rax_v18+FFFFFFF8+v227 @ rax_v6*8]");
			if (0 == (nint)typeof(Background5))
			{
				obj3 = 1;
				goto IL_01d3;
			}
		}
		obj3 = 0;
		goto IL_01d3;
		IL_01d3:
		bool flag = obj3 == null;
		Background5 background = null;
		if (!flag)
		{
			background = (Background5)stage._fancyBg;
		}
		if ((object)background != null)
		{
			Component component2 = default(Component);
			VampireSurvivors.Objects.Characters.CharacterController component = component2.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
			Weapon weaponByType = component._weaponsManager.GetWeaponByType(WeaponType.SHROUD);
			Weapon weaponByType2 = component._weaponsManager.GetWeaponByType(WeaponType.CORRIDOR);
			PickupWeapon component3 = gRing.GetComponent<PickupWeapon>();
			PickupWeapon component4 = sRing.GetComponent<PickupWeapon>();
			PickupWeapon component5 = lMeta.GetComponent<PickupWeapon>();
			Component component7 = default(Component);
			PickupWeapon component6 = component7.GetComponent<PickupWeapon>();
			PickupWeapon rMeta2 = default(PickupWeapon);
			VampireSurvivors.Objects.Characters.CharacterController player2 = default(VampireSurvivors.Objects.Characters.CharacterController);
			Weapon cs = default(Weapon);
			Weapon ic = default(Weapon);
			background.PerformSnapYellows(component3, component4, component5, rMeta2, player2, cs, ic);
		}
	}

	public unsafe void FireSyncTimer(long startingSimFrame, Action onSyncedTimer, bool canBePaused = true)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0312: Expected O, but got Ref
		//IL_032f: Expected O, but got Ref
		//IL_0342: Expected native int or pointer, but got O
		//IL_00b5: Expected O, but got Ref
		//IL_00d2: Expected O, but got Ref
		//IL_00e5: Expected native int or pointer, but got O
		//IL_0355: Expected O, but got F4
		//IL_010f: Expected O, but got Ref
		//IL_012c: Expected O, but got Ref
		//IL_013f: Expected native int or pointer, but got O
		//IL_0169: Expected O, but got Ref
		//IL_0186: Expected O, but got Ref
		//IL_0199: Expected native int or pointer, but got O
		//IL_01e2: Expected O, but got Ref
		//IL_01f5: Expected native int or pointer, but got O
		//IL_0219: Expected I, but got O
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Expected O, but got Unknown
		//IL_02c4: Expected O, but got I
		//IL_02d8: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000C1F0");
		object obj4 = default(object);
		object obj3 = startingSimFrame - obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm6,r12\"");
		float num = 0f / 60f;
		CoherenceBridge masterBridge2 = CoherenceBridgeStore.masterBridge;
		if (!masterBridge2.controlTimeScale)
		{
			object obj5 = Time.timeScale;
			object obj6 = default(object);
			num *= (float)obj6;
		}
		Coherence.Log.Logger logger = _logger;
		(string, object)[] args = new(string, object)[5];
		object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		(string, object) tuple = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		_ = 0;
		object item = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple, ("Current Frame", item));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-39]");
		_ = 0;
		object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		(string, object) tuple2 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		_ = 0;
		object item2 = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple2, ("Starting Frame", item2));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
		_ = 0;
		object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		(string, object) tuple3 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = 0;
		object item3 = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple3, ("Frame Diff", item3));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-19]");
		_ = 0;
		object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		(string, object) tuple4 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		_ = 0;
		object item4 = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple4, ("Time Diff In Seconds", item4));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-9]");
		_ = 0;
		MethodInfo methodImpl = ((MulticastDelegate)onSyncedTimer).GetMethodImpl();
		object item5 = methodImpl.Name;
		(string, object) tuple5 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple5, ("Action", item5));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+7]");
		_ = 0;
		nint num2 = (nint)logger;
		logger.Info("Synchronization Event", args);
		if ((nint)obj3 >= 0)
		{
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(num, onSyncedTimer, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			timer.Resume();
			return;
		}
		float num3 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj11 = num3 ^ 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-41]");
		PauseSystem.DesynchronizedTimeInSeconds = (float?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onSyncedTimer.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		PauseSystem.DesynchronizedTimeInSeconds = (float?)(object)0;
	}

	private void TransitionToHolyForbidden()
	{
		//IL_0054: Expected I, but got O
		//IL_005c: Expected I, but got O
		//IL_006c: Expected O, but got I
		//IL_00ec: Expected O, but got I4
		//IL_00a8: Expected O, but got I
		//IL_00de: Expected O, but got I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		BackgroundWater fancyBg = (BackgroundWater)stage._fancyBg;
		if ((object)stage._fancyBg == null)
		{
			return;
		}
		nint num = (nint)typeof(BackgroundWater);
		nint num2 = (nint)fancyBg;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundWater>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundWater>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundWater>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundWater>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v10+FFFFFFF8+v79 @ rax_v5*8]");
			if (0 == (nint)typeof(BackgroundWater))
			{
				obj3 = 1;
				goto IL_011c;
			}
		}
		obj3 = 0;
		goto IL_011c;
		IL_011c:
		bool flag = obj3 == null;
		BackgroundWater backgroundWater = null;
		if (!flag)
		{
			backgroundWater = (BackgroundWater)stage._fancyBg;
		}
		backgroundWater?.TransitionToHolyForbidden();
	}

	private unsafe void PerformGenericPause(CoherenceSync pausingPlayer)
	{
		//IL_00a7: Expected O, but got Ref
		//IL_00a7: Expected O, but got I
		(string, object)[] args = new(string, object)[1];
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object item = default(object);
		(string, object) tuple = ("Is Game Paused", item);
		_ = 0;
		_logger.Info("Pausing Game", args);
		if ((object)pausingPlayer != null && ((UnityEngine.Object)pausingPlayer).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController component = pausingPlayer.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
		}
		object core = GM.Core;
		Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> action = GM.Core.GenericOnlinePause;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rdi_v4 (System.Object)+1F0]");
		object obj = default(object);
		((List<UiTransition>)0).Add((UiTransition)(&obj));
	}

	private void OnEnteredUi()
	{
		(string, object)[] args = Array.Empty<(string, object)>();
		_logger.Info("Resetting pause variables", args);
		_sentPauseRequest = false;
	}

	private void OnStageSelectedRemotely(int oldStage, int newStage)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA03B0");
	}

	private void OnSeatAssignedRemotely(uint oldId, uint newId)
	{
		//IL_008b: Expected O, but got I4
		//IL_007d: Expected O, but got I4
		//IL_0058: Expected O, but got I4
		//IL_006f: Expected O, but got I4
		if (newId != _secondSeat)
		{
			if (newId != _thirdSeat)
			{
				bool flag = newId != _fourthSeat;
				object obj = 0;
				if (!flag)
				{
					obj = 3;
				}
			}
			else
			{
				object obj = 2;
			}
		}
		else
		{
			object obj = 1;
		}
		Action<int, PlayerInfo> onSeatAssigned = OnSeatAssigned;
		if (OnSeatAssigned != null)
		{
			PlayerInfo playerInfo = ReturnPlayerInfoForSeat(newId);
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v55 @ rdi_v1 (System.Action`2<System.Int32, VampireSurvivors.PlayerInfo>)+18] (should have been resolved before IL gen)");
		}
	}

	private PlayerInfo ReturnPlayerInfoForSeat(uint seat)
	{
		//IL_0041: Expected O, but got I
		//IL_0082: Expected O, but got I4
		//IL_00b3: Expected O, but got I
		//IL_00e5: Expected O, but got I4
		//IL_0102: Expected O, but got I
		//IL_0102: Expected O, but got I
		if (seat == 0)
		{
			goto IL_0178;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v5+80]");
			CoherenceClientConnectionManager coherenceClientConnectionManager = (CoherenceClientConnectionManager)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v5+80]");
			if ((nint)0 != 0)
			{
				Dictionary<ClientID, Entity> entityIdByClientId = coherenceClientConnectionManager.entityIdByClientId;
				if (coherenceClientConnectionManager.entityIdByClientId != null)
				{
					int num = coherenceClientConnectionManager.entityIdByClientId.FindEntry((ClientID)seat);
					if (num >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rbx_v4 (System.Collections.Generic.Dictionary`2<Coherence.Connection.ClientID, Coherence.Entities.Entity>)+18]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rbx_v4 (System.Collections.Generic.Dictionary`2<Coherence.Connection.ClientID, Coherence.Entities.Entity>)+18]");
						if ((nint)0 == 0)
						{
							goto IL_0197;
						}
						object obj3 = num + num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v5+80]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rcx_v9+2C+v281 @ rdx_v5*8]");
						CoherenceClientConnection coherenceClientConnection = ((CoherenceClientConnectionManager)num2).Get((Entity)0);
						if (coherenceClientConnection != null)
						{
							CoherenceSync sync = coherenceClientConnection.Sync;
							if ((object)sync != null && ((UnityEngine.Object)sync).m_CachedPtr != (IntPtr)0)
							{
								return sync.GetComponent<PlayerInfo>();
							}
						}
					}
					goto IL_0178;
				}
			}
		}
		goto IL_0197;
		IL_0178:
		return null;
		IL_0197:
		return (PlayerInfo)(object)new NullReferenceException();
	}

	private unsafe void Awake()
	{
		//IL_00a5: Expected O, but got I
		//IL_04b1: Expected O, but got Ref
		//IL_0336: Expected O, but got I4
		//IL_0395: Expected O, but got I4
		//IL_03fe: Expected O, but got I4
		//IL_0214: Expected O, but got I4
		//IL_0273: Expected O, but got I4
		//IL_02d2: Expected O, but got I4
		UnityEngine.Object.DontDestroyOnLoad(this);
		Coherence.Log.Logger logger = Log.GetLogger<OnlineStageManager>();
		_logger = logger;
		_instance = this;
		CoherenceSync component = GetComponent<CoherenceSync>();
		_sync = component;
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		UnityEvent<CoherenceBridge, ConnectionCloseReason> onDisconnected = masterBridge.onDisconnected;
		UnityAction<CoherenceBridge, ConnectionCloseReason> action = OnDisconnected;
		UnityEngine.Events.BaseInvokableCall baseInvokableCall = UnityEvent<CoherenceBridge, ConnectionCloseReason>.GetDelegate(action);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rbx_v3 (UnityEngine.Events.UnityEvent`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionCloseReason>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A5D0D0");
		_ = 1;
		CoherenceBridge masterBridge2 = CoherenceBridgeStore.masterBridge;
		Action<CoherenceClientConnection> value = OnClientDisconnected;
		masterBridge2._003CClientConnections_003Ek__BackingField.OnDestroyed += value;
		CoherenceSync sync = _sync;
		NetworkEntityState networkEntityState = sync._003CEntityState_003Ek__BackingField;
		if (sync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rcx_v64 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 == 1)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		CoherenceSync sync2 = _sync;
		if (sync2._003CEntityState_003Ek__BackingField != null)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		object arg2 = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg, arg2);
		object obj2 = default(object);
		string log = string.FormatHelper((IFormatProvider)null, "OnlineStageManager: Authority: {0}. Orphaned: {1}", (System.ParamsArray)(&obj2));
		(string, object)[] args = Array.Empty<(string, object)>();
		_logger.Info(log, args);
		if (IsHost)
		{
			OnStateAuthority();
			int num = (int)(_003CMinorArcanasSeed_003Ek__BackingField << 13);
			int num2 = (int)_003CMinorArcanasSeed_003Ek__BackingField ^ num;
			int num3 = num2 >> 17;
			int num4 = num2 ^ num3;
			int num5 = num4 << 5;
			int num6 = num5 ^ num4;
			_minorArcanasRng = (Unity.Mathematics.Random)num6;
			int num7 = (int)(_003CSurvarotsSeed_003Ek__BackingField << 13);
			int num8 = (int)_003CSurvarotsSeed_003Ek__BackingField ^ num7;
			int num9 = num8 >> 17;
			int num10 = num8 ^ num9;
			int num11 = num10 << 5;
			int num12 = num11 ^ num10;
			_survarotsRng = (Unity.Mathematics.Random)num12;
			int num13 = (int)(_003CUiPageSeed_003Ek__BackingField << 13);
			int num14 = (int)_003CUiPageSeed_003Ek__BackingField ^ num13;
			int num15 = num14 >> 17;
			int num16 = num14 ^ num15;
			int num17 = num16 << 5;
			int num18 = num17 ^ num16;
			_uiPageRng = (Unity.Mathematics.Random)num18;
		}
		else
		{
			int num19 = (int)(_003CMinorArcanasSeed_003Ek__BackingField << 13);
			int num20 = (int)_003CMinorArcanasSeed_003Ek__BackingField ^ num19;
			int num21 = num20 >> 17;
			int num22 = num20 ^ num21;
			int num23 = num22 << 5;
			int num24 = num23 ^ num22;
			_minorArcanasRng = (Unity.Mathematics.Random)num24;
			int num25 = (int)(_003CSurvarotsSeed_003Ek__BackingField << 13);
			int num26 = (int)_003CSurvarotsSeed_003Ek__BackingField ^ num25;
			int num27 = num26 >> 17;
			int num28 = num26 ^ num27;
			int num29 = num28 << 5;
			int num30 = num29 ^ num28;
			_survarotsRng = (Unity.Mathematics.Random)num30;
			CoherenceSync sync3 = _sync;
			int num31 = (int)(_003CUiPageSeed_003Ek__BackingField << 13);
			int num32 = (int)_003CUiPageSeed_003Ek__BackingField ^ num31;
			int num33 = num32 >> 17;
			int num34 = num32 ^ num33;
			int num35 = num34 << 5;
			int num36 = num35 ^ num34;
			_uiPageRng = (Unity.Mathematics.Random)num36;
			UnityAction call = OnStateAuthority;
			sync3.OnStateAuthority.AddListener(call);
		}
	}

	private void InitRngs()
	{
		//IL_005f: Expected O, but got I4
		//IL_00be: Expected O, but got I4
		//IL_011d: Expected O, but got I4
		int num = (int)(_003CMinorArcanasSeed_003Ek__BackingField << 13);
		int num2 = (int)_003CMinorArcanasSeed_003Ek__BackingField ^ num;
		int num3 = num2 >> 17;
		int num4 = num2 ^ num3;
		int num5 = num4 << 5;
		int num6 = num5 ^ num4;
		_minorArcanasRng = (Unity.Mathematics.Random)num6;
		int num7 = (int)(_003CSurvarotsSeed_003Ek__BackingField << 13);
		int num8 = (int)_003CSurvarotsSeed_003Ek__BackingField ^ num7;
		int num9 = num8 >> 17;
		int num10 = num8 ^ num9;
		int num11 = num10 << 5;
		int num12 = num11 ^ num10;
		_survarotsRng = (Unity.Mathematics.Random)num12;
		int num13 = (int)(_003CUiPageSeed_003Ek__BackingField << 13);
		int num14 = (int)_003CUiPageSeed_003Ek__BackingField ^ num13;
		int num15 = num14 >> 17;
		int num16 = num14 ^ num15;
		int num17 = num16 << 5;
		int num18 = num17 ^ num16;
		_uiPageRng = (Unity.Mathematics.Random)num18;
	}

	public void ResetGameSession()
	{
		(string, object)[] args = Array.Empty<(string, object)>();
		_logger.Info("Resetting Game Session Variables", args);
		_signalledGameStart = false;
		_signalledInitStage = false;
		PlayerInfo myPlayerInfo = GetMyPlayerInfo();
		if ((object)myPlayerInfo != null && ((UnityEngine.Object)myPlayerInfo).m_CachedPtr != (IntPtr)0)
		{
			Debug.Log("Resetting Player Info Session Variables");
			myPlayerInfo._sceneLoaded = false;
			myPlayerInfo._stageInitialized = false;
		}
	}

	private void Update()
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null && ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0 && IsHost)
		{
			GameManager core2 = GM.Core;
			if (!core2._isGameRunning && !_signalledGameStart)
			{
				SignalInitGameSession();
				SignalInitStage();
				SignalGameStart();
			}
		}
	}

	private unsafe void SignalInitGameSession()
	{
		//IL_0026: Expected O, but got Ref
		//IL_002f: Expected O, but got I4
		//IL_0034: Expected I, but got O
		//IL_0074: Expected I, but got O
		//IL_0115: Expected O, but got I4
		//IL_00c2: Expected O, but got I
		//IL_00cb: Expected O, but got I4
		//IL_02b0: Expected I8, but got O
		//IL_01d9: Expected O, but got I
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Expected O, but got Unknown
		//IL_0135: Expected I, but got O
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_0390: Expected I, but got O
		//IL_0164: Expected I, but got O
		//IL_0172: Expected I, but got O
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_01a3: Expected I, but got O
		//IL_01b1: Expected I, but got O
		if (_signalledInitializeGameSession)
		{
			return;
		}
		IEnumerable<PlayerInfo> enumerable = IterateSeats();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		object obj3 = 1;
		nint num = unchecked((nint)null);
		object obj4 = default(object);
		object obj15 = default(object);
		object obj16 = default(object);
		while (true)
		{
			object obj6;
			object obj13;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj4 != null)
				{
					bool flag = obj2 == null;
					num = unchecked((nint)null);
					if (!flag)
					{
						object obj5 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ r10_v7+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_0102;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ r10_v7+B0]");
						obj6 = 0;
						object obj7 = 0;
						while (true)
						{
							object obj8 = obj7 + obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ r8_v20+v467 @ rcx_v40*8]");
							if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
							{
								break;
							}
							obj7++;
							object obj9 = obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ r10_v7+12E]");
							if ((nint)obj9 < 0)
							{
								continue;
							}
							goto IL_0102;
						}
						object obj10 = obj7 + obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ r8_v20+8+v555 @ rcx_v42*8]");
						object obj11 = (nint)0 << 4;
						object obj12 = obj11 + 312;
						obj13 = obj12 + obj5;
						goto IL_03bb;
					}
					throw new NullReferenceException();
				}
				bool flag2 = obj == null;
				object obj14 = obj2;
				if (!flag2)
				{
					obj14 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				break;
			}
			throw new NullReferenceException();
			IL_0102:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj6 = 0;
			obj13 = obj15;
			goto IL_03bb;
			IL_03bb:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v560 @ rdx_v24] (should have been resolved before IL gen)");
			num = (nint)typeof(UnityEngine.Object);
			bool flag3 = obj16 == null;
			nint num2 = (nint)typeof(IEnumerator<PlayerInfo>);
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rax_v39+10]");
				bool flag4 = (nint)0 == 0;
				num2 = (nint)typeof(IEnumerator<PlayerInfo>);
				num = (nint)typeof(UnityEngine.Object);
				if (!flag4)
				{
					object obj17 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rax_v39+59]");
					obj3 = obj17 & 0;
					num2 = (nint)typeof(IEnumerator<PlayerInfo>);
					num = (nint)typeof(UnityEngine.Object);
				}
			}
		}
		if (obj3 != null)
		{
			_signalledInitializeGameSession = true;
			(string, object)[] args = new(string, object)[1];
			int numberOfConnectedPlayers = NumberOfConnectedPlayers;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object item = default(object);
			(string, object) tuple = ("Number Of Connected Players", item);
			_logger.Info("Signalling InitializeGameSession", args);
			Action<long> action = null;
			((OnlineStageManager)(object)action).InitializeGameSession((long)this);
			long startingOnlineClientFrame = GetStartingOnlineClientFrame();
			long param = startingOnlineClientFrame + 60;
			bool flag5 = _sync.SendCommand(action, MessageTarget.All, param);
		}
	}

	private unsafe void SignalInitStage()
	{
		//IL_003e: Expected O, but got Ref
		//IL_0047: Expected O, but got I4
		//IL_004c: Expected I, but got O
		//IL_0129: Expected O, but got I4
		//IL_00d6: Expected O, but got I
		//IL_00df: Expected O, but got I4
		//IL_02a4: Expected I8, but got O
		//IL_01ed: Expected O, but got I
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0149: Expected I, but got O
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_039a: Expected I, but got O
		//IL_0178: Expected I, but got O
		//IL_0186: Expected I, but got O
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_01b7: Expected I, but got O
		//IL_01c5: Expected I, but got O
		if (_signalledInitStage)
		{
			return;
		}
		IEnumerable<PlayerInfo> enumerable = IterateSeats();
		if (enumerable != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj2 = default(object);
			object obj = (object)(&obj2);
			object obj3 = 1;
			nint num = unchecked((nint)null);
			object obj4 = default(object);
			object obj14 = default(object);
			object obj16 = default(object);
			while (true)
			{
				object obj6;
				object obj13;
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					if (obj4 == null)
					{
						break;
					}
					if (obj2 != null)
					{
						object obj5 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ r10_v7+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_0116;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ r10_v7+B0]");
						obj6 = 0;
						object obj7 = 0;
						while (true)
						{
							object obj8 = obj7 + obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ r8_v13+v425 @ rcx_v31*8]");
							if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
							{
								break;
							}
							obj7++;
							object obj9 = obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ r10_v7+12E]");
							if ((nint)obj9 < 0)
							{
								continue;
							}
							goto IL_0116;
						}
						object obj10 = obj7 + obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ r8_v13+8+v481 @ rcx_v33*8]");
						object obj11 = (nint)0 << 4;
						object obj12 = obj11 + 312;
						obj13 = obj12 + obj5;
						goto IL_03c5;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
				IL_03c5:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v486 @ rdx_v17] (should have been resolved before IL gen)");
				num = (nint)typeof(UnityEngine.Object);
				bool flag = obj14 == null;
				nint num2 = (nint)typeof(IEnumerator<PlayerInfo>);
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rax_v25+10]");
					bool flag2 = (nint)0 == 0;
					num2 = (nint)typeof(IEnumerator<PlayerInfo>);
					num = (nint)typeof(UnityEngine.Object);
					if (!flag2)
					{
						object obj15 = obj3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rax_v25+5A]");
						obj3 = obj15 & 0;
						num2 = (nint)typeof(IEnumerator<PlayerInfo>);
						num = (nint)typeof(UnityEngine.Object);
					}
				}
				continue;
				IL_0116:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj6 = 0;
				obj13 = obj16;
				goto IL_03c5;
			}
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			if (obj3 == null)
			{
				return;
			}
			_signalledInitStage = true;
			long startingOnlineClientFrame = GetStartingOnlineClientFrame();
			(string, object)[] args = Array.Empty<(string, object)>();
			if (_logger != null)
			{
				_logger.Info("Signalling InitializeStageLogic", args);
				Action<long> action = null;
				((OnlineStageManager)(object)action).InitializeStageLogic((long)this);
				if ((object)_sync != null)
				{
					long param = startingOnlineClientFrame + 60;
					bool flag3 = _sync.SendCommand(action, MessageTarget.All, param);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void SignalGameStart()
	{
		//IL_0017: Expected O, but got Ref
		//IL_0020: Expected O, but got I4
		//IL_0025: Expected I, but got O
		//IL_010a: Expected O, but got I4
		//IL_00af: Expected O, but got I
		//IL_00b8: Expected O, but got I4
		//IL_027d: Expected I8, but got O
		//IL_01c6: Expected O, but got I
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_0122: Expected I, but got O
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_0378: Expected I, but got O
		//IL_0151: Expected I, but got O
		//IL_015f: Expected I, but got O
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_0190: Expected I, but got O
		//IL_019e: Expected I, but got O
		IEnumerable<PlayerInfo> enumerable = IterateSeats();
		if (enumerable != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj2 = default(object);
			object obj = (object)(&obj2);
			object obj3 = 1;
			nint num = unchecked((nint)null);
			object obj4 = default(object);
			object obj14 = default(object);
			object obj16 = default(object);
			while (true)
			{
				object obj13;
				object obj6;
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					if (obj4 == null)
					{
						break;
					}
					if (obj2 != null)
					{
						object obj5 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r10_v7+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_00ef;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r10_v7+B0]");
						obj6 = 0;
						object obj7 = 0;
						while (true)
						{
							object obj8 = obj7 + obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ r8_v13+v387 @ rcx_v31*8]");
							if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
							{
								break;
							}
							obj7++;
							object obj9 = obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ r10_v7+12E]");
							if ((nint)obj9 < 0)
							{
								continue;
							}
							goto IL_00ef;
						}
						object obj10 = obj7 + obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ r8_v13+8+v462 @ rcx_v33*8]");
						object obj11 = (nint)0 << 4;
						object obj12 = obj11 + 312;
						obj13 = obj12 + obj5;
						goto IL_03a3;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
				IL_03a3:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v467 @ rdx_v17] (should have been resolved before IL gen)");
				num = (nint)typeof(UnityEngine.Object);
				bool flag = obj14 == null;
				nint num2 = (nint)typeof(IEnumerator<PlayerInfo>);
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ rax_v25+10]");
					bool flag2 = (nint)0 == 0;
					num2 = (nint)typeof(IEnumerator<PlayerInfo>);
					num = (nint)typeof(UnityEngine.Object);
					if (!flag2)
					{
						object obj15 = obj3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ rax_v25+5B]");
						obj3 = obj15 & 0;
						num2 = (nint)typeof(IEnumerator<PlayerInfo>);
						num = (nint)typeof(UnityEngine.Object);
					}
				}
				continue;
				IL_00ef:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj13 = obj16;
				obj6 = 0;
				goto IL_03a3;
			}
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			if (obj3 == null)
			{
				return;
			}
			long startingOnlineClientFrame = GetStartingOnlineClientFrame();
			_signalledGameStart = true;
			(string, object)[] args = Array.Empty<(string, object)>();
			if (_logger != null)
			{
				_logger.Info("Signalling StartGameplay", args);
				Action<long> action = null;
				((OnlineStageManager)(object)action).StartGameplay((long)this);
				if ((object)_sync != null)
				{
					long param = startingOnlineClientFrame + 60;
					bool flag3 = _sync.SendCommand(action, MessageTarget.All, param);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnStateAuthority()
	{
		//IL_0050: Expected O, but got I
		//IL_0222: Invalid comparison between I4 and F4
		//IL_0267: Expected O, but got I
		//IL_0398: Invalid comparison between I4 and F4
		//IL_00be: Expected O, but got I8
		//IL_02bd: Expected O, but got I
		//IL_03c3: Invalid comparison between I4 and F4
		//IL_011a: Expected O, but got I8
		//IL_0313: Expected O, but got I
		//IL_03ee: Invalid comparison between I4 and F4
		//IL_0176: Expected O, but got I8
		//IL_01d2: Expected O, but got I8
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		Action<CoherenceClientConnection> value = OnClientJoined;
		masterBridge._003CClientConnections_003Ek__BackingField.OnCreated += value;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		CoherenceClientConnectionManager coherenceClientConnectionManager = masterBridge._003CClientConnections_003Ek__BackingField;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			coherenceClientConnectionManager = (CoherenceClientConnectionManager)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v185 @ rax_v25 (should have been resolved before IL gen)");
		if (0f > 1f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm0\"");
		}
		uint num = default(uint);
		_003CRandomEventsSeed_003Ek__BackingField = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
			coherenceClientConnectionManager = (CoherenceClientConnectionManager)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v280 @ rax_v28 (should have been resolved before IL gen)");
		if (0f > 1f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm0\"");
		}
		uint num2 = default(uint);
		_003CMinorArcanasSeed_003Ek__BackingField = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex3 = new MissingMethodException();
				throw ex3;
			}
			coherenceClientConnectionManager = (CoherenceClientConnectionManager)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v363 @ rax_v31 (should have been resolved before IL gen)");
		if (0f > 1f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm0\"");
		}
		uint num3 = default(uint);
		_003CSurvarotsSeed_003Ek__BackingField = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj4 == null)
			{
				MissingMethodException ex4 = new MissingMethodException();
				throw ex4;
			}
			coherenceClientConnectionManager = (CoherenceClientConnectionManager)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v446 @ rax_v34 (should have been resolved before IL gen)");
		if (0f > 1f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm0\"");
		}
		uint num4 = default(uint);
		_003CUiPageSeed_003Ek__BackingField = num4;
		ReassignSeats();
		Action onBecomeAuthority = OnBecomeAuthority;
		if (OnBecomeAuthority != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v522.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private unsafe void ReassignSeats()
	{
		//IL_00c5: Expected O, but got I
		//IL_00f8: Expected O, but got Ref
		//IL_0153: Expected I, but got O
		//IL_01de: Expected O, but got I4
		//IL_018b: Expected O, but got I
		//IL_043c: Expected O, but got I4
		//IL_033f: Expected O, but got I4
		//IL_0355: Expected O, but got I
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected O, but got Unknown
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected O, but got Unknown
		//IL_0213: Expected I, but got O
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Expected Ref, but got Unknown
		//IL_0292: Expected I4, but got O
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Expected Ref, but got Unknown
		//IL_02d9: Expected I4, but got O
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected Ref, but got Unknown
		//IL_0320: Expected I4, but got O
		if (!IsHost)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v5+C0]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				uint firstSeat = default(uint);
				_firstSeat = firstSeat;
				_secondSeat = 0u;
				_fourthSeat = 0u;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
				object obj2 = default(object);
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rax_v20+80]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rax_v20+80]");
						IEnumerable<CoherenceClientConnection> otherClients = ((CoherenceClientConnectionManager)0).GetOtherClients();
						if (otherClients != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							CoherenceClientConnection coherenceClientConnection = default(CoherenceClientConnection);
							object obj3 = (object)(&coherenceClientConnection);
							CoherenceClientConnection coherenceClientConnection2 = null;
							object obj4 = default(object);
							object obj11 = default(object);
							CoherenceClientConnection coherenceClientConnection3 = default(CoherenceClientConnection);
							PlayerInfo playerInfo = default(PlayerInfo);
							while (true)
							{
								object obj5;
								object obj10;
								if (coherenceClientConnection != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
									if (obj4 != null)
									{
										bool flag = coherenceClientConnection == null;
										coherenceClientConnection2 = null;
										if (!flag)
										{
											nint num = (nint)coherenceClientConnection;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ r10_v7 (Il2CppClass<Coherence.Toolkit.CoherenceClientConnection>)+12E]");
											if ((nint)0 >= (nint)0)
											{
												goto IL_01cb;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ r10_v7 (Il2CppClass<Coherence.Toolkit.CoherenceClientConnection>)+B0]");
											obj5 = 0;
											uint num2 = 0u;
											while (true)
											{
												object obj6 = num2 + num2;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ r8_v14+v615 @ rax_v54*8]");
												if (0 == (nint)typeof(IEnumerator<CoherenceClientConnection>))
												{
													break;
												}
												num2++;
												uint num3 = num2;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ r10_v7 (Il2CppClass<Coherence.Toolkit.CoherenceClientConnection>)+12E]");
												if ((nint)(int)num3 < (nint)0)
												{
													continue;
												}
												goto IL_01cb;
											}
											object obj7 = num2 + num2;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ r8_v14+8+v674 @ rcx_v42*8]");
											object obj8 = (nint)0 << 4;
											object obj9 = obj8 + 312;
											obj10 = obj9 + num;
											goto IL_049e;
										}
										throw new NullReferenceException();
									}
									if (obj3 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
									}
									break;
								}
								throw new NullReferenceException();
								IL_01cb:
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
								obj5 = 0;
								obj10 = obj11;
								goto IL_049e;
								IL_049e:
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v679 @ rdx_v18] (should have been resolved before IL gen)");
								if (coherenceClientConnection3 != null)
								{
									bool flag2 = (nint)coherenceClientConnection3._003CClientId_003Ek__BackingField == (int)_firstSeat;
									nint num4 = (nint)typeof(IEnumerator<CoherenceClientConnection>);
									coherenceClientConnection2 = (CoherenceClientConnection)(object)typeof(ClientID);
									if (flag2)
									{
										continue;
									}
									CoherenceSync sync = coherenceClientConnection3.Sync;
									if ((object)sync != null)
									{
										PlayerInfo component = sync.GetComponent<PlayerInfo>();
										bool flag3 = TryToAssignSeat(ref *(uint*)(this + 92), (uint)(int)coherenceClientConnection3._003CClientId_003Ek__BackingField, 1, playerInfo);
										num4 = 1;
										if (!flag3)
										{
											bool flag4 = TryToAssignSeat(ref *(uint*)(this + 96), (uint)(int)coherenceClientConnection3._003CClientId_003Ek__BackingField, 2, playerInfo);
											num4 = 2;
											if (!flag4)
											{
												bool flag5 = TryToAssignSeat(ref *(uint*)(this + 100), (uint)(int)coherenceClientConnection3._003CClientId_003Ek__BackingField, 3, playerInfo);
												num4 = 3;
											}
										}
										continue;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							Action<int, PlayerInfo> onSeatAssigned = OnSeatAssigned;
							if (OnSeatAssigned != null)
							{
								PlayerInfo myPlayerInfo = GetMyPlayerInfo();
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v112 @ rbx_v11 (System.Action`2<System.Int32, VampireSurvivors.PlayerInfo>)+18] (should have been resolved before IL gen)");
							}
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnDisconnected(CoherenceBridge _, ConnectionCloseReason __)
	{
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj, 0f);
	}

	private void OnDestroy()
	{
		//IL_00c8: Expected O, but got I
		//IL_00c8: Expected O, but got I
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		Action<CoherenceClientConnection> value = OnClientJoined;
		masterBridge._003CClientConnections_003Ek__BackingField.OnCreated -= value;
		CoherenceBridge masterBridge2 = CoherenceBridgeStore.masterBridge;
		Action<CoherenceClientConnection> value2 = OnClientDisconnected;
		masterBridge2._003CClientConnections_003Ek__BackingField.OnDestroyed -= value2;
		CoherenceBridge masterBridge3 = CoherenceBridgeStore.masterBridge;
		UnityEvent<CoherenceBridge, ConnectionCloseReason> onDisconnected = masterBridge3.onDisconnected;
		UnityAction<CoherenceBridge, ConnectionCloseReason> unityAction = OnDisconnected;
		MethodInfo methodImpl = ((MulticastDelegate)unityAction).GetMethodImpl();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rsi_v4 (UnityEngine.Events.UnityEvent`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionCloseReason>)+10]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v23 (UnityEngine.Events.UnityAction`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionCloseReason>)+20]");
		((UnityEngine.Events.InvokableCallList)num).RemoveListener(0, methodImpl);
		Action action = OnEnteredUi;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA57A0");
		CoherenceSync sync = _sync;
		UnityEvent onStateAuthority = sync.OnStateAuthority;
		UnityAction unityAction2 = OnStateAuthority;
		MethodInfo methodImpl2 = ((MulticastDelegate)unityAction2).GetMethodImpl();
		((UnityEventBase)onStateAuthority).m_Calls.RemoveListener(((Delegate)unityAction2).m_target, methodImpl2);
		_instance = null;
		if (_replicationServer != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800061F0");
		}
	}

	private void OnClientDisconnected(CoherenceClientConnection clientConn)
	{
		if ((nint)clientConn._003CClientId_003Ek__BackingField == (int)_firstSeat && !IsHost)
		{
			GameManager core = GM.Core;
			if ((object)GM.Core != null && ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0 && _003CListenForHostDisconnection_003Ek__BackingField)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
				CoherenceBridge coherenceBridge = default(CoherenceBridge);
				coherenceBridge.Disconnect();
				ConnectionException connectionException = new ConnectionException("Host has left the game. Disconnecting");
				GM.Core.OnConnectionError(null, connectionException);
				return;
			}
		}
		ReassignSeats();
	}

	private unsafe void OnClientJoined(CoherenceClientConnection clientConn)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Ref, but got Unknown
		//IL_0078: Expected I4, but got O
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected Ref, but got Unknown
		//IL_00b6: Expected I4, but got O
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected Ref, but got Unknown
		//IL_00f4: Expected I4, but got O
		if ((nint)clientConn._003CClientId_003Ek__BackingField != (int)_firstSeat)
		{
			CoherenceSync sync = clientConn.Sync;
			PlayerInfo component = sync.GetComponent<PlayerInfo>();
			PlayerInfo playerInfo = default(PlayerInfo);
			if (!TryToAssignSeat(ref *(uint*)(this + 92), (uint)(int)clientConn._003CClientId_003Ek__BackingField, 1, playerInfo) && !TryToAssignSeat(ref *(uint*)(this + 96), (uint)(int)clientConn._003CClientId_003Ek__BackingField, 2, playerInfo))
			{
				bool flag = TryToAssignSeat(ref *(uint*)(this + 100), (uint)(int)clientConn._003CClientId_003Ek__BackingField, 3, playerInfo);
			}
		}
	}

	private unsafe bool TryToAssignSeat(ref uint seat, uint newClient, int seatNumber, PlayerInfo playerInfo)
	{
		//IL_003e: Expected O, but got Ref
		if (seat == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			object arg2 = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg, arg2);
			object obj = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "Client Joined. Assigning seat: {0} to {1}", (System.ParamsArray)(&obj));
			Debug.Log(message);
			ref uint reference = ref *(uint*)newClient;
			Action<int, PlayerInfo> onSeatAssigned = OnSeatAssigned;
			if (OnSeatAssigned != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v164 @ rax_v9 (System.Action`2<System.Int32, VampireSurvivors.PlayerInfo>)+18] (should have been resolved before IL gen)");
			}
			return true;
		}
		return false;
	}

	private void OnApplicationQuit()
	{
		if (_replicationServer != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800061F0");
		}
	}

	private void ShutDown()
	{
		if (_replicationServer != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800061F0");
		}
	}

	public OnlineStageManager()
	{
		//IL_0016: Expected I8, but got I4
		//IL_002b: Expected I, but got O
		_003CListenForHostDisconnection_003Ek__BackingField = true;
		_lastCalculatedSimulationFrame = -1L;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CInitializeGameSession_003Eb__98_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5BC0");
	}

	private void _003CFinishLevelUpWithFriendshipAmulet_003Eb__119_0()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0061: Expected I, but got O
		//IL_007d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	private void _003CLevelUpSkipOnline_003Eb__129_0()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	private void _003CCloseMerchant_003Eb__141_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0040");
	}

	private void _003CSkipMinorArcanas_003Eb__155_0()
	{
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97770");
	}

	private void _003CSkipSurvarots_003Eb__157_0()
	{
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA19D0");
	}

	private void _003CSkipTreasureAnimation_003Eb__159_0()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	private void _003CTpWeaponSkip_003Eb__161_0()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	private void _003CCandyBoxSkip_003Eb__169_0()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	private void _003CLevelBonusSelectionSkip_003Eb__171_0()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	private void _003CSuccessfulPiano_003Eb__175_0()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	private void _003CExitPiano_003Eb__177_0()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	private void _003CRightCoffinOpened_003Eb__179_0()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	private void _003CCollectCharacter_003Eb__185_0()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	private void _003CSelectDirecterTooEasy_003Eb__187_0()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	private void _003CSelectDirecterTooHard_003Eb__189_0()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	private void _003CSelectDirecterOkButton_003Eb__191_0()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	private void _003CForceCloseUi_003Eb__207_0()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	private void _003CArcanaModeTransition_003Eb__218_0()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}
}
