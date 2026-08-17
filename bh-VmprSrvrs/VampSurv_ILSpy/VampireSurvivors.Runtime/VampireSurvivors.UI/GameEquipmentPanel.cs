using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Signals;
using VampireSurvivors.UI.Player;
using Zenject;

namespace VampireSurvivors.UI;

public class GameEquipmentPanel : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<GameEquipmentPanelItem, bool> _003C_003E9__34_0;

		public static Func<GameEquipmentPanelItem, bool> _003C_003E9__34_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CWaitAndRebuild_003Eb__34_0(GameEquipmentPanelItem x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._type - 71;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CWaitAndRebuild_003Eb__34_1(GameEquipmentPanelItem x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._type - 72;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass43_0
	{
		public Weapon weapon;

		public Func<GameEquipmentPanelItem, bool> _003C_003E9__0;

		internal bool _003CDisableWeaponIcon_003Eb__0(GameEquipmentPanelItem item)
		{
			//IL_007f: Expected I4, but got O
			//IL_005d: Expected O, but got I4
			if ((object)item != null)
			{
				Weapon weapon = this.weapon;
				if ((object)this.weapon != null)
				{
					object obj = item._type - ((Equipment)weapon)._equipmentType;
					return obj == null;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003CWaitAndFormat_003Ed__28(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public GameEquipmentPanel _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_00bc: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				RectTransform component = _003C_003E4__this.GetComponent<RectTransform>();
				LayoutRebuilder.ForceRebuildLayoutImmediate(component);
				Canvas.ForceUpdateCanvases();
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

	private sealed class _003CWaitAndRebuild_003Ed__34(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public GameEquipmentPanel _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ca: Expected O, but got Unknown
			//IL_049f: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a4: Expected O, but got Unknown
			//IL_02f8->IL02f8: Incompatible stack heights: 19 vs 17
			GameEquipmentPanel gameEquipmentPanel = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				bool flag = (object)_003C_003E4__this == null;
				bool flag2 = (object)gameEquipmentPanel._WeaponContainer == null;
				GridLayoutGroup component = gameEquipmentPanel._WeaponContainer.GetComponent<GridLayoutGroup>();
				bool flag3 = (object)gameEquipmentPanel._WeaponPrefab == null;
				Image component2 = gameEquipmentPanel._WeaponPrefab.GetComponent<Image>();
				bool flag4 = (object)component2 == null;
				Sprite sprite = component2.m_Sprite;
				bool flag5 = (object)component2.m_Sprite == null;
				bool flag6 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
				Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret);
				Sprite sprite2 = component2.m_Sprite;
				bool flag7 = (object)component2.m_Sprite == null;
				bool flag8 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
				Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out Rect ret2);
				bool flag9 = (object)component == null;
				object obj = component + 104;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
				bool flag10 = (object)gameEquipmentPanel._AccessoryContainer == null;
				GridLayoutGroup component3 = gameEquipmentPanel._AccessoryContainer.GetComponent<GridLayoutGroup>();
				bool flag11 = (object)gameEquipmentPanel._AccessoryPrefab == null;
				Image component4 = gameEquipmentPanel._AccessoryPrefab.GetComponent<Image>();
				bool flag12 = (object)component4 == null;
				Sprite sprite3 = component4.m_Sprite;
				bool flag13 = (object)component4.m_Sprite == null;
				bool flag14 = ((UnityEngine.Object)sprite3).m_CachedPtr == (IntPtr)0;
				Sprite.get_rect_Injected(((UnityEngine.Object)sprite3).m_CachedPtr, out ret2);
				Sprite sprite4 = component4.m_Sprite;
				bool flag15 = (object)component4.m_Sprite == null;
				bool flag16 = ((UnityEngine.Object)sprite4).m_CachedPtr == (IntPtr)0;
				Sprite.get_rect_Injected(((UnityEngine.Object)sprite4).m_CachedPtr, out ret);
				bool flag17 = (object)component3 == null;
				object obj2 = component3 + 104;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
				Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__34_0;
				if (_003C_003Ec._003C_003E9__34_0 == null)
				{
					predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__34_0 = delegate(GameEquipmentPanelItem x)
					{
						//IL_0052: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj5 = x._type - 71;
						return obj5 == null;
					});
				}
				object obj3 = Enumerable.FirstOrDefault(gameEquipmentPanel._spawnedAccessorySlots, predicate);
				Func<object, bool> predicate2 = (Func<object, bool>)_003C_003Ec._003C_003E9__34_1;
				if (_003C_003Ec._003C_003E9__34_1 == null)
				{
					predicate2 = (Func<object, bool>)(_003C_003Ec._003C_003E9__34_1 = delegate(GameEquipmentPanelItem x)
					{
						//IL_0052: Expected I4, but got O
						//IL_0030: Expected O, but got I4
						if ((object)x == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj5 = x._type - 72;
						return obj5 == null;
					});
				}
				object obj4 = Enumerable.FirstOrDefault(gameEquipmentPanel._spawnedAccessorySlots, predicate2);
				if (obj3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1118 @ rax_v56 (System.Object)+10]");
					if ((nint)0 != 0 && obj4 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1196 @ rax_v60 (System.Object)+10]");
						if ((nint)0 != 0)
						{
							Transform transform = ((Component)obj3).transform;
							bool flag18 = (object)transform == null;
							transform.SetSiblingIndex(0);
							Transform transform2 = ((Component)obj4).transform;
							bool flag19 = (object)transform2 == null;
							transform2.SetSiblingIndex(1);
						}
					}
				}
				gameEquipmentPanel._shouldUpdateFormatting = true;
				return false;
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

	private static Dictionary<VampireSurvivors.Objects.Characters.CharacterController, GameEquipmentPanel> _panels;

	private Image _CharacterImage;

	private Image _CharacterDeadImage;

	private GameObject _WeaponPrefab;

	private RectTransform _WeaponContainer;

	private GameObject _AccessoryPrefab;

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

	private void Construct(SignalBus signal, PlayerOptions playerOptions, DataManager dataManager)
	{
		_signalBus = signal;
		_playerOptions = playerOptions;
		_data = dataManager;
	}

	private void OnDestroy()
	{
		//IL_0098: Expected O, but got I4
		//IL_0098: Expected O, but got I
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		Func<KeyValuePair<VampireSurvivors.Objects.Characters.CharacterController, GameEquipmentPanel>, bool> predicate = delegate
		{
			//IL_00f9: Expected O, but got I
			//IL_0133: Expected O, but got I4
			//IL_014d: Expected O, but got I4
			//IL_00e9: Expected I4, but got O
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Objects.Characters.CharacterController, VampireSurvivors.UI.GameEquipmentPanel>)+8]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Objects.Characters.CharacterController, VampireSurvivors.UI.GameEquipmentPanel>)+8]");
			bool flag2 = (nint)0 == 0;
			bool flag3 = (object)this == null;
			object obj8 = flag3 & flag2;
			bool flag4 = obj8 == null;
			object obj9 = !flag4;
			if (obj9 == null)
			{
				if ((object)this != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Objects.Characters.CharacterController, VampireSurvivors.UI.GameEquipmentPanel>)+8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Objects.Characters.CharacterController, VampireSurvivors.UI.GameEquipmentPanel>)+8]");
						object obj10 = 0 - this;
						return obj10 == null;
					}
					return ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Objects.Characters.CharacterController, VampireSurvivors.UI.GameEquipmentPanel>)+8]");
				if ((nint)0 == 0)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rbx_v2+10]");
				return (nint)0 == 0;
			}
			return true;
		};
		if (Enumerable.Any(_panels, predicate))
		{
			bool flag = ((Dictionary<object, object>)(object)_panels).Remove((object)_characterController);
		}
		Action<GameplaySignals.WeaponAddedToCharacterSignal> action = null;
		((GameEquipmentPanel)(object)action).AddWeapon((GameplaySignals.WeaponAddedToCharacterSignal)this);
		((GameEquipmentPanel)(object)_signalBus).AddWeapon((GameplaySignals.WeaponAddedToCharacterSignal)action);
		Action<GameplaySignals.AccessoryAddedToCharacterSignal> action2 = null;
		((GameEquipmentPanel)(object)action2).AddWeapon((GameplaySignals.WeaponAddedToCharacterSignal)this);
		((GameEquipmentPanel)0).AddWeapon((GameplaySignals.WeaponAddedToCharacterSignal)1);
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)action2, throwIfMissing);
		Action<GameplaySignals.WeaponRemovedFromCharacterSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E560");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token, throwIfMissing);
		Action<GameplaySignals.AccessoryRemovedFromCharacterSignal> token2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E640");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType3 = default(Type);
		_signalBus.UnsubscribeInternal(signalType3, (object)null, (object)token2, throwIfMissing);
	}

	private void Update()
	{
		if (_showSprite)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = _characterController;
			bool flag = characterController._isDead || characterController.IsDisconnectedFromOnlinePlay;
			_CharacterDeadImage.enabled = flag;
		}
	}

	private void LateUpdate()
	{
		if (!_shouldUpdateFormatting)
		{
			return;
		}
		Transform transform = base.transform;
		if ((object)transform == null || ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Transform transform2 = base.transform;
		Transform parent = transform2.parent;
		if ((object)parent != null && ((UnityEngine.Object)parent).m_CachedPtr != (IntPtr)0)
		{
			Transform transform3 = base.transform;
			Transform parent2 = transform3.parent;
			RectTransform component = parent2.GetComponent<RectTransform>();
			if ((object)component != null)
			{
				Extensions.RefreshLayoutGroupsImmediateAndRecursive(component);
			}
			Canvas.ForceUpdateCanvases();
			_shouldUpdateFormatting = false;
		}
	}

	public static void ClearPanels()
	{
		_panels.Clear();
	}

	public void AddExtra(WeaponType weaponType)
	{
		//IL_0028: Expected O, but got I
		//IL_0081: Expected O, but got I
		List<System.Int32Enum> extraWeapons = (List<System.Int32Enum>)(object)_extraWeapons;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v3+18]");
		if (num >= 0)
		{
			extraWeapons.AddWithResize((System.Int32Enum)weaponType);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj2 = (nint)0 + (nint)1;
		}
		RebuildWeaponSlots();
		RebuildAccessorySlots();
	}

	public List<WeaponType> GetExtraWeapons()
	{
		return _extraWeapons;
	}

	public void Rebuild()
	{
		RebuildWeaponSlots();
		RebuildAccessorySlots();
	}

	public void Initialize(VampireSurvivors.Objects.Characters.CharacterController characterController, bool showSprite)
	{
		//IL_01db: Expected O, but got I4
		//IL_01db: Expected O, but got I
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_03d6: Expected O, but got I
		//IL_0287: Expected O, but got I4
		//IL_0287: Expected O, but got I
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_040f: Expected O, but got I
		//IL_0333: Expected O, but got I4
		//IL_0333: Expected O, but got I
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Expected O, but got Unknown
		//IL_0448: Expected O, but got I
		if (!characterController.IsDisconnectedFromOnlinePlay && _signalBus != null)
		{
			_showSprite = showSprite;
			_character = characterController._characterType;
			_characterController = characterController;
			if (!showSprite)
			{
				GameObject gameObject = _CharacterImage.gameObject;
				gameObject.SetActive(value: false);
			}
			else
			{
				GameObject gameObject2 = _CharacterImage.gameObject;
				gameObject2.SetActive(value: true);
				CharacterData currentSkinData = characterController._currentSkinData;
				Sprite sprite = SpriteManager.GetSprite(currentSkinData._003CspriteName_003Ek__BackingField, currentSkinData._003CtextureName_003Ek__BackingField);
				_CharacterImage.sprite = sprite;
			}
			CreateWeaponSlots();
			CreateAccessorySlots();
			Action<GameplaySignals.WeaponAddedToCharacterSignal> action = null;
			((GameEquipmentPanel)(object)action).AddWeapon((GameplaySignals.WeaponAddedToCharacterSignal)this);
			((GameEquipmentPanel)(object)_signalBus).AddWeapon((GameplaySignals.WeaponAddedToCharacterSignal)action);
			Action<GameplaySignals.AccessoryAddedToCharacterSignal> action2 = null;
			((GameEquipmentPanel)(object)action2).AddWeapon((GameplaySignals.WeaponAddedToCharacterSignal)this);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rbx_v8 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
			}
			object obj = null;
			Action<object> action3 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.AccessoryAddedToCharacterSignal>)obj)._003CSubscribeId_003Eb__0;
			((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.AccessoryAddedToCharacterSignal>)0)._003CSubscribeId_003Eb__0((object)1);
			object obj3 = default(object);
			object obj2 = obj3 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			SignalBus signalBus = _signalBus;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v22 (System.Object)+10]");
			Type signalType = default(Type);
			Action<object> callback = default(Action<object>);
			signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
			Action<GameplaySignals.WeaponRemovedFromCharacterSignal> action4 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E560");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rbx_v12 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
			}
			object obj4 = null;
			Action<object> action5 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.WeaponRemovedFromCharacterSignal>)obj4)._003CSubscribeId_003Eb__0;
			((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.WeaponRemovedFromCharacterSignal>)0)._003CSubscribeId_003Eb__0((object)1);
			object obj6 = default(object);
			object obj5 = obj6 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			SignalBus signalBus2 = _signalBus;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rax_v37 (System.Object)+10]");
			Type signalType2 = default(Type);
			signalBus2.SubscribeInternal(signalType2, (object)null, (object)0, callback);
			Action<GameplaySignals.AccessoryRemovedFromCharacterSignal> action6 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E640");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbx_v16 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
			}
			object obj7 = null;
			Action<object> action7 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.AccessoryRemovedFromCharacterSignal>)obj7)._003CSubscribeId_003Eb__0;
			((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.AccessoryRemovedFromCharacterSignal>)0)._003CSubscribeId_003Eb__0((object)1);
			object obj9 = default(object);
			object obj8 = obj9 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			SignalBus signalBus3 = _signalBus;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v52 (System.Object)+10]");
			Type signalType3 = default(Type);
			signalBus3.SubscribeInternal(signalType3, (object)null, (object)0, callback);
			bool flag = ((Dictionary<object, object>)(object)_panels).TryInsert((object)_characterController, (object)this, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			RebuildWeaponSlots();
			RebuildAccessorySlots();
			HealthBarUi componentInChildren = GetComponentInChildren<HealthBarUi>(includeInactive: true);
			componentInChildren._character = characterController;
		}
	}

	private void OnEnable()
	{
		_003CWaitAndFormat_003Ed__28 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator WaitAndFormat()
	{
		_003CWaitAndFormat_003Ed__28 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void Reset()
	{
		//IL_0034: Expected O, but got I4
		//IL_0034: Expected O, but got I
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		ClearWeaponSlots();
		ClearAccessorySlots();
		Action<GameplaySignals.WeaponAddedToCharacterSignal> action = null;
		((GameEquipmentPanel)(object)action).AddWeapon((GameplaySignals.WeaponAddedToCharacterSignal)this);
		((GameEquipmentPanel)0).AddWeapon((GameplaySignals.WeaponAddedToCharacterSignal)1);
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)action, throwIfMissing);
		Action<GameplaySignals.AccessoryAddedToCharacterSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E480");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rbx_v6 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rbx_v7 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token, throwIfMissing);
		Action<GameplaySignals.WeaponRemovedFromCharacterSignal> token2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E560");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rbx_v10 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rbx_v11 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType3 = default(Type);
		_signalBus.UnsubscribeInternal(signalType3, (object)null, (object)token2, throwIfMissing);
		Action<GameplaySignals.AccessoryRemovedFromCharacterSignal> token3 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E640");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rbx_v14 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ rbx_v15 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj8 = default(object);
		object obj7 = obj8 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType4 = default(Type);
		_signalBus.UnsubscribeInternal(signalType4, (object)null, (object)token3, throwIfMissing);
	}

	private void ClearWeaponSlots()
	{
		//IL_0039->IL0125: Incompatible stack heights: 1 vs 0
		if (_spawnedWeaponSlots != null)
		{
			List<GameEquipmentPanelItem>.Enumerator enumerator = default(List<GameEquipmentPanelItem>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbx_v7 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbx_v7 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				UnityEngine.Object.Destroy(obj2, 0f);
			}
			List<GameEquipmentPanelItem> spawnedWeaponSlots = _spawnedWeaponSlots;
			if (_spawnedWeaponSlots != null)
			{
				int version = spawnedWeaponSlots._version + 1;
				spawnedWeaponSlots._version = version;
				spawnedWeaponSlots._size = 0;
				if (spawnedWeaponSlots._size > 0)
				{
					Array.Clear(spawnedWeaponSlots._items, 0, spawnedWeaponSlots._size);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void ClearAccessorySlots()
	{
		//IL_0039->IL0125: Incompatible stack heights: 1 vs 0
		if (_spawnedAccessorySlots != null)
		{
			List<GameEquipmentPanelItem>.Enumerator enumerator = default(List<GameEquipmentPanelItem>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbx_v7 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbx_v7 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				UnityEngine.Object.Destroy(obj2, 0f);
			}
			List<GameEquipmentPanelItem> spawnedAccessorySlots = _spawnedAccessorySlots;
			if (_spawnedAccessorySlots != null)
			{
				int version = spawnedAccessorySlots._version + 1;
				spawnedAccessorySlots._version = version;
				spawnedAccessorySlots._size = 0;
				if (spawnedAccessorySlots._size > 0)
				{
					Array.Clear(spawnedAccessorySlots._items, 0, spawnedAccessorySlots._size);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void CreateWeaponSlots()
	{
		//IL_008e: Expected O, but got I4
		//IL_005a: Expected O, but got I4
		//IL_0208: Expected O, but got I4
		//IL_0185: Expected O, but got I4
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected O, but got Unknown
		GameManager core = GM.Core;
		int playerCount = core._multiplayer.GetPlayerCount();
		object obj;
		if (playerCount <= 1)
		{
			bool isOnlineMultiplayer = core._multiplayer.IsOnlineMultiplayer;
			bool flag = !isOnlineMultiplayer;
			obj = 6;
			if (flag)
			{
				goto IL_01ed;
			}
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = _characterController;
		obj = characterController._maxWeaponBonus + characterController._maxWeaponCount;
		goto IL_01ed;
		IL_01ed:
		bool flag2 = (nint)obj <= 0;
		object obj2 = 0;
		if (flag2)
		{
			return;
		}
		do
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(_WeaponPrefab, _WeaponContainer);
			GameEquipmentPanelItem component = gameObject.GetComponent<GameEquipmentPanelItem>();
			List<object> spawnedWeaponSlots = (List<object>)(object)_spawnedWeaponSlots;
			int version = spawnedWeaponSlots._version + 1;
			spawnedWeaponSlots._version = version;
			object[] items = spawnedWeaponSlots._items;
			if (spawnedWeaponSlots._size >= items.Length)
			{
				spawnedWeaponSlots.AddWithResize((object)component);
			}
			else
			{
				int size = spawnedWeaponSlots._size + 1;
				spawnedWeaponSlots._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = _characterController;
			object obj3 = characterController2._maxWeaponBonus + characterController2._maxWeaponCount;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				component.SetBlocked(blocked: true);
			}
			obj2++;
		}
		while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj));
	}

	private void RebuildWeaponSlots()
	{
		//IL_05f0: Expected O, but got I4
		//IL_026d: Expected O, but got I
		//IL_02f6: Expected O, but got I4
		//IL_043f: Expected O, but got I
		//IL_039a: Expected O, but got I
		ClearWeaponSlots();
		CreateWeaponSlots();
		VampireSurvivors.Objects.Characters.CharacterController characterController = _characterController;
		bool flag = (object)_characterController == null;
		int num = 0;
		int num2 = 0;
		if (!flag)
		{
			while (true)
			{
				CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
				if ((object)characterController._weaponsManager == null)
				{
					break;
				}
				List<Equipment> list = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
				if (((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField == null)
				{
					break;
				}
				if (num2 < list._size)
				{
					VampireSurvivors.Objects.Characters.CharacterController characterController2 = _characterController;
					if ((object)_characterController == null)
					{
						break;
					}
					CharacterWeaponsManager weaponsManager2 = characterController2._weaponsManager;
					if ((object)characterController2._weaponsManager == null)
					{
						break;
					}
					List<Equipment> list2 = ((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField;
					if (((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField == null)
					{
						break;
					}
					if (num >= list2._size)
					{
						goto IL_0527;
					}
					Equipment[] items = list2._items;
					if (list2._items == null)
					{
						break;
					}
					if (num < items.Length)
					{
						Equipment equipment = items[num];
						if ((object)items[num] == null)
						{
							break;
						}
						GameManager core = GM.Core;
						if ((object)GM.Core == null || core._dataManager == null)
						{
							break;
						}
						Dictionary<WeaponType, List<WeaponData>> convertedWeapons = core._dataManager.GetConvertedWeapons();
						if (convertedWeapons == null)
						{
							break;
						}
						object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)equipment._equipmentType);
						if (obj == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v40 (System.Object)+18]");
						if ((nint)0 <= (nint)0)
						{
							goto IL_0527;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v40 (System.Object)+10]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v40 (System.Object)+10]");
						if ((nint)0 == 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v41+18]");
						if ((nint)0 > (nint)0)
						{
							List<GameEquipmentPanelItem> spawnedWeaponSlots = _spawnedWeaponSlots;
							if (_spawnedWeaponSlots == null)
							{
								break;
							}
							object obj3 = spawnedWeaponSlots._size - 1;
							if (num > (nint)obj3)
							{
								GameObject gameObject = UnityEngine.Object.Instantiate(_WeaponPrefab, _WeaponContainer);
								if ((object)gameObject == null)
								{
									break;
								}
								GameEquipmentPanelItem component = gameObject.GetComponent<GameEquipmentPanelItem>();
								if ((object)component == null)
								{
									break;
								}
								VampireSurvivors.Objects.Characters.CharacterController characterController3 = _characterController;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v41+20]");
								component.Initialize(characterController3, (WeaponData)0, equipment._equipmentType);
								if (_spawnedWeaponSlots == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E8A0");
							}
							else
							{
								if (_spawnedWeaponSlots == null)
								{
									break;
								}
								GameEquipmentPanelItem gameEquipmentPanelItem = _spawnedWeaponSlots.get_Item(num);
								if ((object)gameEquipmentPanelItem == null)
								{
									break;
								}
								VampireSurvivors.Objects.Characters.CharacterController characterController4 = _characterController;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v41+20]");
								gameEquipmentPanelItem.Initialize(characterController4, (WeaponData)0, equipment._equipmentType);
							}
							characterController = _characterController;
							num++;
							if ((object)_characterController == null)
							{
								break;
							}
							num2 = num;
							continue;
						}
					}
					goto IL_052d;
				}
				if (((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(this);
					break;
				}
				IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)this).m_CachedPtr);
				GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				if ((object)gameObject2 == null)
				{
					break;
				}
				bool flag2 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
				object obj4 = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr);
				if (obj4 != null)
				{
					IEnumerator routine = WaitAndRebuild();
					Coroutine coroutine = StartCoroutine(routine);
				}
				_shouldUpdateFormatting = true;
				return;
				IL_052d:
				throw new IndexOutOfRangeException();
				IL_0527:
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				goto IL_052d;
			}
		}
		throw new NullReferenceException();
	}

	private IEnumerator WaitAndRebuild()
	{
		_003CWaitAndRebuild_003Ed__34 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void AddWeapon(GameplaySignals.WeaponAddedToCharacterSignal sig)
	{
		RebuildWeaponSlots();
		_shouldUpdateFormatting = true;
	}

	private void OnCharacterRemovedWeapon(GameplaySignals.WeaponRemovedFromCharacterSignal sig)
	{
		RebuildWeaponSlots();
		_shouldUpdateFormatting = true;
	}

	private void CreateAccessorySlots()
	{
		//IL_001c: Expected O, but got I4
		//IL_006e: Expected O, but got I4
		//IL_0045: Expected O, but got I4
		//IL_004e: Expected O, but got I4
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		VampireSurvivors.Objects.Characters.CharacterController characterController = _characterController;
		object obj = characterController._maxAccessoryBonus + characterController._maxAccessoryCount;
		object obj2;
		if ((nint)obj > 6)
		{
			obj2 = 0;
			obj = 6;
		}
		else
		{
			bool flag = (nint)obj <= 0;
			obj2 = 0;
			if (flag)
			{
				return;
			}
		}
		do
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(_AccessoryPrefab, _AccessoryContainer);
			GameEquipmentPanelItem component = gameObject.GetComponent<GameEquipmentPanelItem>();
			List<object> spawnedAccessorySlots = (List<object>)(object)_spawnedAccessorySlots;
			int version = spawnedAccessorySlots._version + 1;
			spawnedAccessorySlots._version = version;
			object[] items = spawnedAccessorySlots._items;
			if (spawnedAccessorySlots._size >= items.Length)
			{
				spawnedAccessorySlots.AddWithResize((object)component);
			}
			else
			{
				int size = spawnedAccessorySlots._size + 1;
				spawnedAccessorySlots._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			obj2++;
		}
		while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj));
	}

	private unsafe void RebuildAccessorySlots()
	{
		//IL_0653: Expected O, but got Ref
		//IL_00ae: Expected O, but got I4
		//IL_00b6: Expected O, but got Ref
		//IL_0250: Expected O, but got I
		//IL_02c3: Expected O, but got I
		//IL_02e2: Expected O, but got I
		//IL_0305: Expected O, but got I
		//IL_0389: Expected O, but got I
		//IL_03fa: Expected O, but got I4
		//IL_0593: Expected O, but got I
		//IL_04b3: Expected O, but got I
		ClearAccessorySlots();
		CreateAccessorySlots();
		List<WeaponType> list = new List<WeaponType>();
		list._002Ector();
		VampireSurvivors.Objects.Characters.CharacterController characterController = _characterController;
		bool flag = (object)_characterController == null;
		List<WeaponType> list2 = list;
		if (!flag)
		{
			CharacterAccessoriesManager accessoriesManager = characterController._accessoriesManager;
			bool flag2 = (object)characterController._accessoriesManager == null;
			list2 = list;
			if (!flag2)
			{
				bool flag3 = ((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField == null;
				list2 = list;
				if (!flag3)
				{
					List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
					if (enumerator.MoveNext())
					{
						object obj = 0;
						list2 = (List<WeaponType>)(&enumerator);
						throw new NullReferenceException();
					}
					bool flag4 = list == null;
					list2 = (List<WeaponType>)(&enumerator);
					if (!flag4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						((List<System.Int32Enum>)(object)list).InsertRange(0, (IEnumerable<System.Int32Enum>)_extraWeapons);
						int num = 0;
						List<WeaponType> list3 = list;
						int num2 = 0;
						while (true)
						{
							int num3 = num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ r14_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
							if ((nint)num3 < (nint)0)
							{
								int num4 = num;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
								if ((nint)num4 < (nint)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
									list2 = (List<WeaponType>)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
									if ((nint)0 == 0)
									{
										break;
									}
									list2 = (List<WeaponType>)(object)GM.Core;
									if ((object)GM.Core == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ rcx_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+108]");
									bool flag5 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ rcx_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+108]");
									list2 = (List<WeaponType>)0;
									if (flag5)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ rcx_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+108]");
									Dictionary<WeaponType, List<WeaponData>> convertedWeapons = ((DataManager)0).GetConvertedWeapons();
									bool flag6 = convertedWeapons == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ rcx_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+108]");
									list2 = (List<WeaponType>)0;
									if (flag6)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ rcx_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+20+v108 @ rdi_v9 (System.Int32)*4]");
									object obj2 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
									bool flag7 = obj2 == null;
									list2 = (List<WeaponType>)(object)convertedWeapons;
									if (flag7)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v34 (System.Object)+18]");
									if ((nint)0 > (nint)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v34 (System.Object)+10]");
										object obj3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v34 (System.Object)+10]");
										bool flag8 = (nint)0 == 0;
										list2 = (List<WeaponType>)(object)convertedWeapons;
										if (flag8)
										{
											break;
										}
										List<GameEquipmentPanelItem> spawnedAccessorySlots = _spawnedAccessorySlots;
										bool flag9 = _spawnedAccessorySlots == null;
										list2 = (List<WeaponType>)(object)convertedWeapons;
										if (flag9)
										{
											break;
										}
										object obj4 = spawnedAccessorySlots._size - 1;
										if (num > (nint)obj4)
										{
											GameObject gameObject = UnityEngine.Object.Instantiate(_AccessoryPrefab, _AccessoryContainer);
											bool flag10 = (object)gameObject == null;
											list2 = (List<WeaponType>)(object)_AccessoryPrefab;
											if (flag10)
											{
												break;
											}
											GameEquipmentPanelItem component = gameObject.GetComponent<GameEquipmentPanelItem>();
											bool flag11 = (object)component == null;
											list2 = (List<WeaponType>)(object)gameObject;
											if (flag11)
											{
												break;
											}
											VampireSurvivors.Objects.Characters.CharacterController characterController2 = _characterController;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v35+20]");
											nint num5 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v43 (UnityEngine.GameObject)+20+v108 @ rdi_v9 (System.Int32)*4]");
											component.Initialize(characterController2, (WeaponData)num5, WeaponType.VOID);
											list2 = (List<WeaponType>)(object)_spawnedAccessorySlots;
											if (_spawnedAccessorySlots == null)
											{
												break;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E8A0");
											num++;
											list3 = list;
											num2 = num;
										}
										else
										{
											bool flag12 = _spawnedAccessorySlots == null;
											list2 = (List<WeaponType>)(object)_spawnedAccessorySlots;
											if (flag12)
											{
												break;
											}
											GameEquipmentPanelItem gameEquipmentPanelItem = _spawnedAccessorySlots.get_Item(num);
											bool flag13 = (object)gameEquipmentPanelItem == null;
											list2 = (List<WeaponType>)(object)_spawnedAccessorySlots;
											if (flag13)
											{
												break;
											}
											VampireSurvivors.Objects.Characters.CharacterController characterController3 = _characterController;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v35+20]");
											nint num6 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ rcx_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+20+v108 @ rdi_v9 (System.Int32)*4]");
											gameEquipmentPanelItem.Initialize(characterController3, (WeaponData)num6, WeaponType.VOID);
											num++;
											num2 = num;
										}
										continue;
									}
								}
								System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							}
							else
							{
								_shouldUpdateFormatting = true;
							}
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void AddAccessory(GameplaySignals.AccessoryAddedToCharacterSignal sig)
	{
		RebuildAccessorySlots();
		IEnumerator routine = WaitAndRebuild();
		Coroutine coroutine = StartCoroutine(routine);
		_shouldUpdateFormatting = true;
	}

	private void OnCharacterRemovedAccessory(GameplaySignals.AccessoryRemovedFromCharacterSignal sig)
	{
		RebuildAccessorySlots();
		IEnumerator routine = WaitAndRebuild();
		Coroutine coroutine = StartCoroutine(routine);
		_shouldUpdateFormatting = true;
	}

	public static GameEquipmentPanel GetPanelForCharacter(VampireSurvivors.Objects.Characters.CharacterController c)
	{
		if (_panels != null)
		{
			int num = _panels.FindEntry(c);
			if (num < 0)
			{
				return null;
			}
			if (_panels != null)
			{
				return _panels.get_Item(c);
			}
		}
		return (GameEquipmentPanel)(object)new NullReferenceException();
	}

	public void BlockWeapon(Weapon weapon, bool blocked)
	{
		List<GameEquipmentPanelItem>.Enumerator enumerator = default(List<GameEquipmentPanelItem>.Enumerator);
		if ((object)weapon != null && ((UnityEngine.Object)weapon).m_CachedPtr != (IntPtr)0 && enumerator.MoveNext())
		{
			GameEquipmentPanelItem gameEquipmentPanelItem = null;
			throw new NullReferenceException();
		}
	}

	public unsafe void DisableWeaponIcon(Weapon weapon, bool disable)
	{
		//IL_00ee: Expected O, but got Ref
		//IL_00b7: Expected I, but got O
		//IL_0149: Expected I, but got O
		//IL_01dc: Expected O, but got I4
		//IL_0181: Expected O, but got I
		//IL_018a: Expected O, but got I4
		//IL_01fc: Expected I, but got O
		//IL_0224: Expected O, but got I
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Expected O, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		_003C_003Ec__DisplayClass43_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass43_0();
		CS_0024_003C_003E8__locals8.weapon = weapon;
		Weapon weapon2 = CS_0024_003C_003E8__locals8.weapon;
		if ((object)CS_0024_003C_003E8__locals8.weapon == null || ((UnityEngine.Object)weapon2).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Func<GameEquipmentPanelItem, bool> predicate = CS_0024_003C_003E8__locals8._003C_003E9__0;
		if (CS_0024_003C_003E8__locals8._003C_003E9__0 == null)
		{
			Func<GameEquipmentPanelItem, bool> func = (CS_0024_003C_003E8__locals8._003C_003E9__0 = delegate(GameEquipmentPanelItem item)
			{
				//IL_007f: Expected I4, but got O
				//IL_005d: Expected O, but got I4
				if ((object)item != null)
				{
					Weapon weapon3 = CS_0024_003C_003E8__locals8.weapon;
					if ((object)CS_0024_003C_003E8__locals8.weapon != null)
					{
						object obj12 = item._type - ((Equipment)weapon3)._equipmentType;
						return obj12 == null;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			});
			nint num = unchecked((nint)null);
			predicate = func;
		}
		IEnumerable<GameEquipmentPanelItem> enumerable = Enumerable.Where(_spawnedWeaponSlots, predicate);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameEquipmentPanelItem gameEquipmentPanelItem = default(GameEquipmentPanelItem);
		object obj = (object)(&gameEquipmentPanelItem);
		GameEquipmentPanelItem gameEquipmentPanelItem2 = null;
		object obj2 = default(object);
		object obj11 = default(object);
		GameEquipmentPanelItem gameEquipmentPanelItem3 = default(GameEquipmentPanelItem);
		while (true)
		{
			object obj10;
			object obj3;
			if ((object)gameEquipmentPanelItem != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj2 != null)
				{
					bool flag = (object)gameEquipmentPanelItem == null;
					gameEquipmentPanelItem2 = null;
					if (flag)
					{
						break;
					}
					nint num2 = (nint)gameEquipmentPanelItem;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ r10_v7 (Il2CppClass<VampireSurvivors.UI.GameEquipmentPanelItem>)+12E]");
					if ((nint)0 < (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ r10_v7 (Il2CppClass<VampireSurvivors.UI.GameEquipmentPanelItem>)+B0]");
						obj3 = 0;
						object obj4 = 0;
						while (true)
						{
							object obj5 = obj4 + obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v574 @ r8_v13+v585 @ rax_v33*8]");
							if (0 == (nint)typeof(IEnumerator<GameEquipmentPanelItem>))
							{
								break;
							}
							obj4++;
							object obj6 = obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ r10_v7 (Il2CppClass<VampireSurvivors.UI.GameEquipmentPanelItem>)+12E]");
							if ((nint)obj6 < 0)
							{
								continue;
							}
							goto IL_01c1;
						}
						object obj7 = obj4 + obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v574 @ r8_v13+8+v641 @ rcx_v28*8]");
						object obj8 = (nint)0 << 4;
						object obj9 = obj8 + 312;
						obj10 = obj9 + num2;
						goto IL_0327;
					}
					goto IL_01c1;
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				return;
			}
			throw new NullReferenceException();
			IL_01c1:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj10 = obj11;
			obj3 = 0;
			goto IL_0327;
			IL_0327:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v646 @ rdx_v14] (should have been resolved before IL gen)");
			gameEquipmentPanelItem3.SetDisabledIcon(disable);
			nint num = (nint)typeof(IEnumerator<GameEquipmentPanelItem>);
		}
		throw new NullReferenceException();
	}

	public GameEquipmentPanel()
	{
		List<GameEquipmentPanelItem> spawnedWeaponSlots = new List<GameEquipmentPanelItem>();
		_spawnedWeaponSlots = spawnedWeaponSlots;
		List<GameEquipmentPanelItem> spawnedAccessorySlots = new List<GameEquipmentPanelItem>();
		_spawnedAccessorySlots = spawnedAccessorySlots;
		List<WeaponType> extraWeapons = new List<WeaponType>();
		_extraWeapons = extraWeapons;
	}

	static GameEquipmentPanel()
	{
		Dictionary<VampireSurvivors.Objects.Characters.CharacterController, GameEquipmentPanel> panels = new Dictionary<VampireSurvivors.Objects.Characters.CharacterController, GameEquipmentPanel>();
		_panels = panels;
	}

	private bool _003COnDestroy_003Eb__19_0(KeyValuePair<VampireSurvivors.Objects.Characters.CharacterController, GameEquipmentPanel> kvp)
	{
		//IL_00f9: Expected O, but got I
		//IL_0133: Expected O, but got I4
		//IL_014d: Expected O, but got I4
		//IL_00e9: Expected I4, but got O
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Objects.Characters.CharacterController, VampireSurvivors.UI.GameEquipmentPanel>)+8]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Objects.Characters.CharacterController, VampireSurvivors.UI.GameEquipmentPanel>)+8]");
		bool flag = (nint)0 == 0;
		bool flag2 = (object)this == null;
		object obj2 = flag2 & flag;
		bool flag3 = obj2 == null;
		object obj3 = !flag3;
		if (obj3 == null)
		{
			if ((object)this != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Objects.Characters.CharacterController, VampireSurvivors.UI.GameEquipmentPanel>)+8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Objects.Characters.CharacterController, VampireSurvivors.UI.GameEquipmentPanel>)+8]");
					object obj4 = 0 - this;
					return obj4 == null;
				}
				return ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Objects.Characters.CharacterController, VampireSurvivors.UI.GameEquipmentPanel>)+8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rbx_v2+10]");
				return (nint)0 == 0;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return true;
	}
}
