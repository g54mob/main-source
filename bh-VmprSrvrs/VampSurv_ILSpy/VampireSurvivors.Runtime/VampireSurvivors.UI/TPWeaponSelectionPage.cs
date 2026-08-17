using System;
using System.Collections.Generic;
using System.Linq;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI;

public class TPWeaponSelectionPage : BaseWeaponSelectionPage
{
	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public WeaponType v;

		public Func<Equipment, bool> _003C_003E9__2;

		public Func<Equipment, bool> _003C_003E9__3;

		internal bool _003CPopulate_003Eb__0(VampireSurvivors.Objects.Characters.CharacterController player)
		{
			//IL_0123: Expected I4, but got O
			if ((object)player != null)
			{
				CharacterWeaponsManager weaponsManager = player._weaponsManager;
				if ((object)player._weaponsManager != null)
				{
					Func<Equipment, bool> predicate = _003C_003E9__2;
					if (_003C_003E9__2 == null)
					{
						predicate = (_003C_003E9__2 = delegate(Equipment x)
						{
							//IL_0053: Expected I4, but got O
							//IL_0031: Expected O, but got I4
							if ((object)x == null)
							{
								NullReferenceException ex2 = new NullReferenceException();
								return (byte)(int)ex2 != 0;
							}
							object obj = x._equipmentType - v;
							return obj == null;
						});
					}
					int num = Enumerable.Count(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField, (Func<object, bool>)predicate);
					int num2 = num ^ num;
					int num3 = num & num2;
					bool flag = num3 < 0;
					bool flag2 = num < 0;
					bool flag3 = num == 0;
					bool flag4 = flag2 == flag;
					bool flag5 = !flag3;
					return flag5 & flag4;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CPopulate_003Eb__2(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - v;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CPopulate_003Eb__1(VampireSurvivors.Objects.Characters.CharacterController player)
		{
			//IL_0123: Expected I4, but got O
			if ((object)player != null)
			{
				CharacterWeaponsManager weaponsManager = player._weaponsManager;
				if ((object)player._weaponsManager != null)
				{
					Func<Equipment, bool> predicate = _003C_003E9__3;
					if (_003C_003E9__3 == null)
					{
						predicate = (_003C_003E9__3 = delegate(Equipment x)
						{
							//IL_0053: Expected I4, but got O
							//IL_0031: Expected O, but got I4
							if ((object)x == null)
							{
								NullReferenceException ex2 = new NullReferenceException();
								return (byte)(int)ex2 != 0;
							}
							object obj = x._equipmentType - v;
							return obj == null;
						});
					}
					int num = Enumerable.Count(((EquipmentManager)weaponsManager)._003CRemovedEquipment_003Ek__BackingField, (Func<object, bool>)predicate);
					int num2 = num ^ num;
					int num3 = num & num2;
					bool flag = num3 < 0;
					bool flag2 = num < 0;
					bool flag3 = num == 0;
					bool flag4 = flag2 == flag;
					bool flag5 = !flag3;
					return flag5 & flag4;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CPopulate_003Eb__3(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - v;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private Image _Background;

	private TextMeshProUGUI _Title;

	private Image _Frame;

	private GameObject _WeaponPrefab;

	private Transform _SkipButton;

	private Image _Mask;

	private RectTransform _PanelRectTransform;

	private List<WeaponType> _weaponList;

	private List<GameObject> _spawned;

	private WeaponSelectionItemUI _currentSelected;

	private WeaponType _currentType;

	private VampireSurvivors.Objects.Characters.CharacterController _targetCharacter;

	private bool _hasSelected;

	private DataManager _data;

	private PlayerOptions _playerOptions;

	private SignalBus _signalBus;

	private List<WeaponType> _tpSpell;

	private List<WeaponType> _tpSpell_Secret;

	private List<WeaponType> _tpMelee;

	private List<WeaponType> _tpMelee_Secret;

	private List<WeaponType> _tpProjectile;

	private List<WeaponType> _tpProjectile_Secret;

	private List<WeaponType> _tpGlyph;

	private List<WeaponType> _tpGlyph_Secret;

	private List<WeaponType> _tpWhip;

	private List<WeaponType> _tpFamiliars;

	private List<WeaponType> _emeAllWeapons;

	private void InjectData(DataManager data, PlayerOptions player, SignalBus signalBus)
	{
		//IL_0042: Expected O, but got I
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_00b7: Expected O, but got I
		//IL_0248: Expected O, but got I4
		//IL_00a2: Expected O, but got I8
		//IL_0149: Expected O, but got I4
		//IL_0149: Expected O, but got I
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		//IL_0281: Expected O, but got I
		//IL_01f5: Expected O, but got I4
		//IL_01f5: Expected O, but got I
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_02bc: Expected O, but got I
		_data = data;
		_playerOptions = player;
		_signalBus = signalBus;
		Action<OnlineSignals.SelectTPWeapon> action = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ r9_v1 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ r9_v1 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		object obj3;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ r9_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 1)
			{
				obj3 = 6442485696L;
				goto IL_023f;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rax_v6 (System.Action`1<VampireSurvivors.Signals.OnlineSignals+SelectTPWeapon>)+10]");
		obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rax_v6 (System.Action`1<VampireSurvivors.Signals.OnlineSignals+SelectTPWeapon>)+20]");
		_ = 0;
		goto IL_023f;
		IL_023f:
		object obj4 = 24;
		_ = 6447743808L;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rdi_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj5 = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.SelectTPWeapon>)obj5)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.SelectTPWeapon>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj7 = default(object);
		object obj6 = obj7 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ rax_v21 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus2.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action action3 = OnWeaponSkippedRemotely;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ rbx_v7 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj8 = null;
		Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.SkipTpWeapon>)obj8)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.SkipTpWeapon>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj10 = default(object);
		object obj9 = obj10 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus3 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rax_v36 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus3.SubscribeInternal(signalType2, (object)null, (object)0, callback);
	}

	private void OnWeaponSkippedRemotely()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1D00");
		ExitMultiplayerControl();
	}

	private unsafe void OnWeaponSelectedRemotely(OnlineSignals.SelectTPWeapon weapon)
	{
		//IL_002c: Expected I4, but got O
		//IL_004c: Expected O, but got Ref
		//IL_001d: Expected I4, but got O
		object obj = default(object);
		object arg = (WeaponType)obj;
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj2 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Tp Weapon Was Selected Remotely {0}", (System.ParamsArray)(&obj2));
		Debug.Log(message);
		ExecuteWeaponSelection((WeaponType)weapon);
	}

	protected unsafe override void OnShowStart(GameObject g)
	{
		//IL_0282->IL035d: Incompatible stack heights: 5 vs 0
		//IL_02b3->IL035d: Incompatible stack heights: 5 vs 0
		//IL_01b2->IL035d: Incompatible stack heights: 5 vs 0
		//IL_02e0->IL035d: Incompatible stack heights: 5 vs 0
		//IL_0202->IL035d: Incompatible stack heights: 6 vs 0
		//IL_030f->IL035d: Incompatible stack heights: 5 vs 0
		//IL_0247->IL035d: Incompatible stack heights: 7 vs 0
		//IL_034a->IL035d: Incompatible stack heights: 5 vs 0
		//IL_0268->IL029b: Incompatible stack heights: 7 vs 5
		base.OnShowStart(g);
		GameManager core = GM.Core;
		Selectable component;
		if ((object)GM.Core != null)
		{
			_targetCharacter = core._003CEnterWeaponSelectionPlayer_003Ek__BackingField;
			_hasSelected = false;
			Clear();
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null)
			{
				CoopConfig coopConfig = core2.CoopConfig;
				if ((object)core2.CoopConfig != null)
				{
					EnterMultiplayerControl(_targetCharacter, coopConfig._levelupVibrationMilliseconds);
					if ((object)_Frame != null)
					{
						Transform transform = _Frame.transform;
						if ((object)transform != null)
						{
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							float ret;
							Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
							bool flag2 = (object)_Frame == null;
							Transform transform2 = _Frame.transform;
							bool flag3 = (object)transform2 == null;
							bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
							bool flag5 = (object)_Frame == null;
							Transform target = _Frame.transform;
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleX(target, ret, 0.15f);
							Populate();
							if (_spawned != null)
							{
								List<GameObject> spawned = _spawned;
								if (spawned._size > 0)
								{
									if (spawned != null)
									{
										bool flag6 = spawned._size <= 0;
										GameObject[] items = spawned._items;
										if (spawned._items != null)
										{
											bool flag7 = items.Length <= 0;
											if ((object)items[0] != null)
											{
												component = items[0].GetComponent<Selectable>();
												goto IL_029b;
											}
										}
									}
									goto IL_035d;
								}
							}
							if ((object)_SkipButton != null)
							{
								component = _SkipButton.GetComponent<Selectable>();
								goto IL_029b;
							}
						}
					}
				}
			}
		}
		goto IL_035d;
		IL_035d:
		throw new NullReferenceException();
		IL_029b:
		if ((object)component != null)
		{
			component.Select();
			if ((object)_Mask != null)
			{
				_Mask.enabled = false;
				if ((object)_SkipButton != null)
				{
					GameObject gameObject = _SkipButton.gameObject;
					bool active = IsLocalPlayerControllingUi();
					if ((object)gameObject != null)
					{
						gameObject.SetActive(active);
						return;
					}
				}
			}
		}
		goto IL_035d;
	}

	protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
	{
		return _targetCharacter;
	}

	private void Clear()
	{
		//IL_00c4: Expected O, but got I
		List<WeaponType> weaponList = _weaponList;
		if (_weaponList != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			if (_spawned != null)
			{
				List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
				while (enumerator.MoveNext())
				{
					UnityEngine.Object.Destroy(null, 0f);
				}
				weaponList = (List<WeaponType>)(object)_spawned;
				if (_spawned != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
					_ = (nint)0 + (nint)1;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						Array.Clear((Array)num, 0, 0);
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void SetSelected(WeaponSelectionItemUI item)
	{
		_currentSelected = item;
		WeaponSelectionItemUI currentSelected = _currentSelected;
		_currentType = currentSelected._type;
	}

	private unsafe void Populate()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0050: Expected O, but got I4
		//IL_005d: Expected O, but got I8
		//IL_0066: Expected O, but got I4
		//IL_0896: Expected I4, but got O
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_05ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ef: Expected Ref, but got Unknown
		//IL_05f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Expected Ref, but got Unknown
		//IL_0615: Expected I8, but got I4
		//IL_06f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f6: Expected Ref, but got Unknown
		//IL_0700: Unknown result type (might be due to invalid IL or missing references)
		//IL_0705: Expected Ref, but got Unknown
		//IL_071c: Expected I8, but got I4
		//IL_07fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0801: Expected Ref, but got Unknown
		//IL_080b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0810: Expected Ref, but got Unknown
		//IL_0827: Expected I8, but got I4
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Expected Ref, but got Unknown
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ec: Expected Ref, but got Unknown
		//IL_0403: Expected I8, but got I4
		//IL_04e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e8: Expected Ref, but got Unknown
		//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Expected Ref, but got Unknown
		//IL_050e: Expected I8, but got I4
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected Ref, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected Ref, but got Unknown
		//IL_01ed: Expected I8, but got I4
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected Ref, but got Unknown
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected Ref, but got Unknown
		//IL_02f8: Expected I8, but got I4
		//IL_0f75: Expected I, but got O
		//IL_0bd9: Expected O, but got I
		//IL_0a6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a70: Expected O, but got Unknown
		//IL_0c4e: Expected O, but got I
		//IL_0ff7: Expected I, but got O
		//IL_11a0: Expected I4, but got O
		//IL_0ca3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca8: Expected O, but got Unknown
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			string text = core._003CWeaponSelectionType_003Ek__BackingField;
			if (core._003CWeaponSelectionType_003Ek__BackingField != null)
			{
				object obj = core._003CWeaponSelectionType_003Ek__BackingField + 20;
				object obj2 = 0;
				object obj3 = 2166136261L;
				object obj4 = 0;
				while ((nint)obj4 < text._stringLength)
				{
					if ((nint)obj2 < text._stringLength)
					{
						object obj5 = obj ^ obj3;
						obj3 = obj5 * 16777619;
						obj2++;
						obj += 2;
						obj4 = obj2;
						continue;
					}
					goto IL_103f;
				}
				if ((long)obj3 > 2406056114L)
				{
					if ((long)obj3 > 3509924439L)
					{
						if ((long)obj3 == 3673568028L)
						{
							object obj6 = "tp_whip";
							if ((object)core._003CWeaponSelectionType_003Ek__BackingField == "tp_whip")
							{
								goto IL_021b;
							}
							if ("tp_whip" != null)
							{
								int stringLength = text._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rdx_v86+10]");
								if ((nint)stringLength == 0)
								{
									ref byte first = ref *(byte*)(core._003CWeaponSelectionType_003Ek__BackingField + 20);
									ref byte second = ref *(byte*)("tp_whip" + 20);
									ulong length = (ulong)(text._stringLength + text._stringLength);
									if (System.SpanHelpers.SequenceEqual(ref first, ref second, length))
									{
										goto IL_021b;
									}
								}
							}
						}
						else if ((long)obj3 == 3875415017L)
						{
							object obj7 = "tp_projectile";
							if ((object)core._003CWeaponSelectionType_003Ek__BackingField == "tp_projectile")
							{
								goto IL_0326;
							}
							if ("tp_projectile" != null)
							{
								int stringLength2 = text._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdx_v82+10]");
								if ((nint)stringLength2 == 0)
								{
									ref byte first2 = ref *(byte*)(core._003CWeaponSelectionType_003Ek__BackingField + 20);
									ref byte second2 = ref *(byte*)("tp_projectile" + 20);
									ulong length2 = (ulong)(text._stringLength + text._stringLength);
									if (System.SpanHelpers.SequenceEqual(ref first2, ref second2, length2))
									{
										goto IL_0326;
									}
								}
							}
						}
					}
					else if ((long)obj3 == 2763340344L)
					{
						object obj8 = "tp_glyph";
						if ((object)core._003CWeaponSelectionType_003Ek__BackingField == "tp_glyph")
						{
							goto IL_0431;
						}
						if ("tp_glyph" != null)
						{
							int stringLength3 = text._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rdx_v78+10]");
							if ((nint)stringLength3 == 0)
							{
								ref byte first3 = ref *(byte*)(core._003CWeaponSelectionType_003Ek__BackingField + 20);
								ref byte second3 = ref *(byte*)("tp_glyph" + 20);
								ulong length3 = (ulong)(text._stringLength + text._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first3, ref second3, length3))
								{
									goto IL_0431;
								}
							}
						}
					}
					else if ((long)obj3 == 3509924439L)
					{
						object obj9 = "eme_allWeapons";
						if ((object)core._003CWeaponSelectionType_003Ek__BackingField == "eme_allWeapons")
						{
							goto IL_053c;
						}
						if ("eme_allWeapons" != null)
						{
							int stringLength4 = text._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rdx_v74+10]");
							if ((nint)stringLength4 == 0)
							{
								ref byte first4 = ref *(byte*)(core._003CWeaponSelectionType_003Ek__BackingField + 20);
								ref byte second4 = ref *(byte*)("eme_allWeapons" + 20);
								ulong length4 = (ulong)(text._stringLength + text._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first4, ref second4, length4))
								{
									goto IL_053c;
								}
							}
						}
					}
				}
				else if ((nint)obj3 == 724998236)
				{
					object obj10 = "tp_spell";
					if ((object)core._003CWeaponSelectionType_003Ek__BackingField == "tp_spell")
					{
						goto IL_0643;
					}
					if ("tp_spell" != null)
					{
						int stringLength5 = text._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rdx_v70+10]");
						if ((nint)stringLength5 == 0)
						{
							ref byte first5 = ref *(byte*)(core._003CWeaponSelectionType_003Ek__BackingField + 20);
							ref byte second5 = ref *(byte*)("tp_spell" + 20);
							ulong length5 = (ulong)(text._stringLength + text._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first5, ref second5, length5))
							{
								goto IL_0643;
							}
						}
					}
				}
				else if ((nint)obj3 == 1058662282)
				{
					object obj11 = "tp_melee";
					if ((object)core._003CWeaponSelectionType_003Ek__BackingField == "tp_melee")
					{
						goto IL_074a;
					}
					if ("tp_melee" != null)
					{
						int stringLength6 = text._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rdx_v66+10]");
						if ((nint)stringLength6 == 0)
						{
							ref byte first6 = ref *(byte*)(core._003CWeaponSelectionType_003Ek__BackingField + 20);
							ref byte second6 = ref *(byte*)("tp_melee" + 20);
							ulong length6 = (ulong)(text._stringLength + text._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first6, ref second6, length6))
							{
								goto IL_074a;
							}
						}
					}
				}
				else if ((long)obj3 == 2406056114L)
				{
					object obj12 = "tp_familiars";
					if ((object)core._003CWeaponSelectionType_003Ek__BackingField == "tp_familiars")
					{
						goto IL_0855;
					}
					if ("tp_familiars" != null)
					{
						int stringLength7 = text._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rdx_v62+10]");
						if ((nint)stringLength7 == 0)
						{
							ref byte first7 = ref *(byte*)(core._003CWeaponSelectionType_003Ek__BackingField + 20);
							ref byte second7 = ref *(byte*)("tp_familiars" + 20);
							ulong length7 = (ulong)(text._stringLength + text._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first7, ref second7, length7))
							{
								goto IL_0855;
							}
						}
					}
				}
			}
			goto IL_0860;
		}
		goto IL_0f3e;
		IL_074a:
		MakeSpectralSwordConfig();
		goto IL_0860;
		IL_053c:
		MakeEmeraldsConfig();
		goto IL_0860;
		IL_021b:
		MakeMorningStarConfig();
		goto IL_0860;
		IL_0860:
		Image background = _Background;
		Behaviour behaviour;
		if ((object)_Background != null)
		{
			System.Int32Enum int32Enum = (System.Int32Enum)background.m_Sprite;
			if ((object)background.m_Sprite != null)
			{
				behaviour = _Background;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbx_v25 (System.Int32Enum)+10]");
				if ((nint)0 != 0)
				{
					goto IL_10b1;
				}
			}
			else
			{
				behaviour = _Background;
			}
			if ((object)behaviour != null)
			{
				behaviour.enabled = false;
				behaviour = _Frame;
				goto IL_10b1;
			}
		}
		goto IL_0f3e;
		IL_0431:
		MakeEbonyDialogueConfig();
		goto IL_0860;
		IL_0643:
		MakeSpellBookConfig();
		goto IL_0860;
		IL_0326:
		MakeCoatOfArmsConfig();
		goto IL_0860;
		IL_0f3e:
		throw new NullReferenceException();
		IL_10ce:
		throw new IndexOutOfRangeException();
		IL_103f:
		System.ThrowHelper.ThrowIndexOutOfRangeException();
		goto IL_10ce;
		IL_10b1:
		if ((object)behaviour != null)
		{
			behaviour.enabled = true;
			if (_data != null)
			{
				Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
				if (_playerOptions != null)
				{
					PlayerOptionsData config = _playerOptions.Config;
					if (config != null && config._003CUnlockedWeapons_003Ek__BackingField != null)
					{
						object obj14 = default(object);
						IntPtr intPtr = default(IntPtr);
						object obj15 = default(object);
						while (true)
						{
							object obj13 = obj14;
							while (true)
							{
								if (intPtr != (IntPtr)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ stack_-40_v27 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>+Enumerator<VampireSurvivors.Data.WeaponType>>)+1C]");
									if (obj15 != null)
									{
										break;
									}
									object obj16 = obj13;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ stack_-40_v27 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>+Enumerator<VampireSurvivors.Data.WeaponType>>)+18]");
									if ((nint)obj16 >= 0)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ stack_-40_v27 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>+Enumerator<VampireSurvivors.Data.WeaponType>>)+10]");
									System.Int32Enum int32Enum2 = (System.Int32Enum)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ stack_-40_v27 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>+Enumerator<VampireSurvivors.Data.WeaponType>>)+10]");
									if ((nint)0 != 0)
									{
										object obj17 = obj13;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ rbx_v32 (System.Int32Enum)+18]");
										if ((nint)obj17 < 0)
										{
											obj13++;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ rbx_v32 (System.Int32Enum)+20+v134 @ rdx_v35*4]");
											if ((nint)0 == 0)
											{
												continue;
											}
											goto IL_0a95;
										}
										goto IL_10ce;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							break;
							IL_0a95:
							bool flag = convertedWeapons == null;
							if (!flag)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ rbx_v32 (System.Int32Enum)+20+v134 @ rdx_v35*4]");
								int num = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).FindEntry((System.Int32Enum)0);
								obj14 = obj13;
								if (flag)
								{
									continue;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ rbx_v32 (System.Int32Enum)+20+v134 @ rdx_v35*4]");
								object obj18 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
								bool flag2 = obj18 == null;
								obj14 = obj13;
								if (!flag2)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ rbx_v32 (System.Int32Enum)+20+v134 @ rdx_v35*4]");
									object obj19 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
									if (obj19 == null)
									{
										throw new NullReferenceException();
									}
									List<WeaponData> list = ((Dictionary<WeaponType, List<WeaponData>>)obj19).get_Item(WeaponType.VOID);
									if (list == null)
									{
										throw new NullReferenceException();
									}
									_ = 1;
									obj14 = obj13;
								}
								continue;
							}
							throw new NullReferenceException();
						}
						if (intPtr != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ stack_-40_v27 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>+Enumerator<VampireSurvivors.Data.WeaponType>>)+1C]");
							nint num3;
							if (obj15 == null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ stack_-40_v27 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>+Enumerator<VampireSurvivors.Data.WeaponType>>)+18]");
								object obj20 = (nint)0 + (nint)1;
								if (_weaponList != null)
								{
									object obj21 = obj20;
									object obj22 = default(object);
									while (true)
									{
										if (obj22 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-40_v29+1C]");
											if (obj15 != null)
											{
												break;
											}
											object obj23 = obj21;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-40_v29+18]");
											if ((nint)obj23 >= 0)
											{
												break;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-40_v29+10]");
											object obj24 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-40_v29+10]");
											if ((nint)0 != 0)
											{
												object obj25 = obj21;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1499 @ rax_v96+18]");
												if ((nint)obj25 < 0)
												{
													object obj26 = obj21 + 1;
													_003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass34_0();
													if (CS_0024_003C_003E8__locals13 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1499 @ rax_v96+20+v1475 @ stack_-38_v28*4]");
														CS_0024_003C_003E8__locals13.v = WeaponType.VOID;
														bool flag3 = convertedWeapons == null;
														if (!flag3)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1499 @ rax_v96+20+v1475 @ stack_-38_v28*4]");
															int num2 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).FindEntry((System.Int32Enum)0);
															obj21 = obj26;
															if (flag3)
															{
																continue;
															}
															object obj27 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)CS_0024_003C_003E8__locals13.v);
															if (obj27 != null)
															{
																List<WeaponData> list2 = ((Dictionary<WeaponType, List<WeaponData>>)obj27).get_Item(WeaponType.VOID);
																if (list2 != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1713 @ rax_v103 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+88]");
																	bool flag4 = (nint)0 == 0;
																	obj21 = obj26;
																	if (flag4)
																	{
																		continue;
																	}
																	GameManager core2 = GM.Core;
																	if ((object)GM.Core != null)
																	{
																		Func<VampireSurvivors.Objects.Characters.CharacterController, bool> predicate = delegate(VampireSurvivors.Objects.Characters.CharacterController player)
																		{
																			//IL_0123: Expected I4, but got O
																			if ((object)player != null)
																			{
																				CharacterWeaponsManager weaponsManager = player._weaponsManager;
																				if ((object)player._weaponsManager != null)
																				{
																					Func<Equipment, bool> predicate3 = CS_0024_003C_003E8__locals13._003C_003E9__2;
																					if (CS_0024_003C_003E8__locals13._003C_003E9__2 == null)
																					{
																						predicate3 = (CS_0024_003C_003E8__locals13._003C_003E9__2 = delegate(Equipment x)
																						{
																							//IL_0053: Expected I4, but got O
																							//IL_0031: Expected O, but got I4
																							if ((object)x == null)
																							{
																								NullReferenceException ex2 = new NullReferenceException();
																								return (byte)(int)ex2 != 0;
																							}
																							object obj29 = x._equipmentType - CS_0024_003C_003E8__locals13.v;
																							return obj29 == null;
																						});
																					}
																					int num4 = Enumerable.Count(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField, (Func<object, bool>)predicate3);
																					int num5 = num4 ^ num4;
																					int num6 = num4 & num5;
																					bool flag9 = num6 < 0;
																					bool flag10 = num4 < 0;
																					bool flag11 = num4 == 0;
																					bool flag12 = flag10 == flag9;
																					bool flag13 = !flag11;
																					return flag13 & flag12;
																				}
																			}
																			NullReferenceException ex = new NullReferenceException();
																			return (byte)(int)ex != 0;
																		};
																		bool flag5 = Enumerable.Any(core2._mainCharacters, predicate);
																		obj21 = obj26;
																		if (flag5)
																		{
																			continue;
																		}
																		GameManager core3 = GM.Core;
																		if ((object)GM.Core != null)
																		{
																			Func<VampireSurvivors.Objects.Characters.CharacterController, bool> predicate2 = delegate(VampireSurvivors.Objects.Characters.CharacterController player)
																			{
																				//IL_0123: Expected I4, but got O
																				if ((object)player != null)
																				{
																					CharacterWeaponsManager weaponsManager = player._weaponsManager;
																					if ((object)player._weaponsManager != null)
																					{
																						Func<Equipment, bool> predicate3 = CS_0024_003C_003E8__locals13._003C_003E9__3;
																						if (CS_0024_003C_003E8__locals13._003C_003E9__3 == null)
																						{
																							predicate3 = (CS_0024_003C_003E8__locals13._003C_003E9__3 = delegate(Equipment x)
																							{
																								//IL_0053: Expected I4, but got O
																								//IL_0031: Expected O, but got I4
																								if ((object)x == null)
																								{
																									NullReferenceException ex2 = new NullReferenceException();
																									return (byte)(int)ex2 != 0;
																								}
																								object obj29 = x._equipmentType - CS_0024_003C_003E8__locals13.v;
																								return obj29 == null;
																							});
																						}
																						int num4 = Enumerable.Count(((EquipmentManager)weaponsManager)._003CRemovedEquipment_003Ek__BackingField, (Func<object, bool>)predicate3);
																						int num5 = num4 ^ num4;
																						int num6 = num4 & num5;
																						bool flag9 = num6 < 0;
																						bool flag10 = num4 < 0;
																						bool flag11 = num4 == 0;
																						bool flag12 = flag10 == flag9;
																						bool flag13 = !flag11;
																						return flag13 & flag12;
																					}
																				}
																				NullReferenceException ex = new NullReferenceException();
																				return (byte)(int)ex != 0;
																			};
																			bool flag6 = Enumerable.Any(core3._mainCharacters, predicate2);
																			obj21 = obj26;
																			if (!flag6)
																			{
																				object obj28 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)CS_0024_003C_003E8__locals13.v);
																				if (obj28 == null)
																				{
																					throw new NullReferenceException();
																				}
																				List<WeaponData> d = ((Dictionary<WeaponType, List<WeaponData>>)obj28).get_Item(WeaponType.VOID);
																				SpawnWeapon(CS_0024_003C_003E8__locals13.v, (WeaponData)(object)d);
																				obj21 = obj26;
																			}
																			continue;
																		}
																		throw new NullReferenceException();
																	}
																	throw new NullReferenceException();
																}
																throw new NullReferenceException();
															}
															throw new NullReferenceException();
														}
														throw new NullReferenceException();
													}
													throw new NullReferenceException();
												}
												throw new IndexOutOfRangeException();
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									bool flag7 = obj22 == null;
									num3 = 0;
									if (!flag7)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ stack_-40_v29+1C]");
										if (obj15 == null)
										{
											System.Int32Enum int32Enum3 = (System.Int32Enum)_SkipButton;
											if ((object)_SkipButton != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbx_v29 (System.Int32Enum)+10]");
												bool flag8 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbx_v29 (System.Int32Enum)+10]");
												Transform.SetAsLastSibling_Injected((IntPtr)0);
												return;
											}
											goto IL_0f3e;
										}
										System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
										num3 = unchecked((nint)null);
									}
									throw new NullReferenceException();
								}
								goto IL_0f3e;
							}
							System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
							num3 = unchecked((nint)null);
						}
						throw new NullReferenceException();
					}
				}
			}
		}
		goto IL_0f3e;
		IL_0855:
		MakeFamiliarConfig();
		goto IL_0860;
	}

	public override void SelectWeapon(WeaponSelectionItemUI item)
	{
		if (!_hasSelected)
		{
			_hasSelected = true;
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				ExecuteWeaponSelection(item._type);
				return;
			}
			OnlineStageManager instance = OnlineStageManager._instance;
			Action<long, int> action = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5A20");
			long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
			int param = default(int);
			bool flag = instance._sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
		}
	}

	private unsafe void ExecuteWeaponSelection(WeaponType selected)
	{
		//IL_009f: Expected O, but got I
		//IL_010c: Expected O, but got I
		DataManager data = _data;
		if (_data != null)
		{
			Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
			if (convertedWeapons != null)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)selected);
				bool flag = obj == null;
				data = (DataManager)(object)convertedWeapons;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v14 (System.Object)+18]");
					if ((nint)0 <= (nint)0)
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v14 (System.Object)+10]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v14 (System.Object)+10]");
					bool flag2 = (nint)0 == 0;
					data = (DataManager)(object)convertedWeapons;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v15+18]");
						bool flag3 = (nint)0 <= (nint)0;
						data = (DataManager)(object)convertedWeapons;
						if (flag3)
						{
							throw new IndexOutOfRangeException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v15+20]");
						data = (DataManager)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v15+20]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v22 (VampireSurvivors.Data.DataManager)+101]");
							VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
							if ((nint)0 == 0)
							{
								if (SignalBus != null)
								{
									List<WeaponData> list = ((Dictionary<WeaponType, List<WeaponData>>)(object)SignalBus).get_Item((WeaponType)(int)(&characterController));
									goto IL_01d2;
								}
							}
							else if (SignalBus != null)
							{
								List<WeaponData> list2 = ((Dictionary<WeaponType, List<WeaponData>>)(object)SignalBus).get_Item((WeaponType)(int)(&characterController));
								goto IL_01d2;
							}
						}
					}
				}
			}
		}
		goto IL_0244;
		IL_0244:
		throw new NullReferenceException();
		IL_01d2:
		if (_spawned != null)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			if (enumerator.MoveNext())
			{
				GameObject gameObject = null;
				throw new NullReferenceException();
			}
			ExitMultiplayerControl();
			return;
		}
		goto IL_0244;
	}

	public void Skip()
	{
		//IL_0084: Expected I8, but got O
		//IL_009c: Expected I8, but got O
		//IL_0068: Expected O, but got I
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1D00");
			ExitMultiplayerControl();
			return;
		}
		long num = (long)OnlineStageManager._instance;
		Action<long> action = null;
		((OnlineStageManager)(object)action).TpWeaponSkip((long)OnlineStageManager._instance);
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rbx_v3 (System.Int64)+78]");
		bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	private void ExecuteSkip()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1D00");
		ExitMultiplayerControl();
	}

	private void SpawnWeapon(WeaponType t, WeaponData d)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(_WeaponPrefab, _content);
		WeaponSelectionItemUI component = gameObject.GetComponent<WeaponSelectionItemUI>();
		component.SetData(this, t, d);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
		if (!IsLocalPlayerControllingUi())
		{
			component._button.interactable = false;
		}
	}

	private unsafe void MakeSpellBookConfig()
	{
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected Ref, but got Unknown
		if (_tpSpell != null)
		{
			List<System.Int32Enum> weaponList = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_tpSpell);
			_weaponList = (List<WeaponType>)(object)weaponList;
			PlayerOptionsData config = _playerOptions.Config;
			List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rcx_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj = default(object);
				if ((nint)obj != -1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1DB0");
					IEnumerable<System.Int32Enum> enumerable = default(IEnumerable<System.Int32Enum>);
					if (enumerable == null)
					{
						Exception ex = System.Linq.Error.ArgumentNull("source");
						throw ex;
					}
					List<System.Int32Enum> weaponList2 = new List<System.Int32Enum>(enumerable);
					_weaponList = (List<WeaponType>)(object)weaponList2;
				}
			}
			Vector2 sizeDelta = _PanelRectTransform.sizeDelta;
			Vector2 sizeDelta2 = default(Vector2);
			_PanelRectTransform.sizeDelta = sizeDelta2;
			RectTransform component = _Background.GetComponent<RectTransform>();
			component.sizeDelta = sizeDelta2;
			_Frame.enabled = false;
			Sprite sprite = SpriteManager.GetSprite("Spellbook");
			_Background.sprite = sprite;
			if (UnityEngine.UI.SetPropertyUtility.SetStruct(ref *(System.Int32Enum*)(_Background + 240), (System.Int32Enum)0))
			{
				_Background.SetVerticesDirty();
			}
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("weaponLang/{TP_SPELLBOOK}name", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			_Title.text = translation;
			return;
		}
		Exception ex2 = System.Linq.Error.ArgumentNull("source");
		throw ex2;
	}

	private unsafe void MakeCoatOfArmsConfig()
	{
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected Ref, but got Unknown
		if (_tpProjectile != null)
		{
			List<System.Int32Enum> weaponList = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_tpProjectile);
			_weaponList = (List<WeaponType>)(object)weaponList;
			PlayerOptionsData config = _playerOptions.Config;
			List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rcx_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj = default(object);
				if ((nint)obj != -1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1DB0");
					IEnumerable<System.Int32Enum> enumerable = default(IEnumerable<System.Int32Enum>);
					if (enumerable == null)
					{
						Exception ex = System.Linq.Error.ArgumentNull("source");
						throw ex;
					}
					List<System.Int32Enum> weaponList2 = new List<System.Int32Enum>(enumerable);
					_weaponList = (List<WeaponType>)(object)weaponList2;
				}
			}
			Vector2 sizeDelta = _PanelRectTransform.sizeDelta;
			Vector2 sizeDelta2 = default(Vector2);
			_PanelRectTransform.sizeDelta = sizeDelta2;
			RectTransform component = _Background.GetComponent<RectTransform>();
			component.sizeDelta = sizeDelta2;
			_Frame.enabled = true;
			Sprite sprite = SpriteManager.GetSprite("CoatOfArms");
			_Background.sprite = sprite;
			if (UnityEngine.UI.SetPropertyUtility.SetStruct(ref *(System.Int32Enum*)(_Background + 240), (System.Int32Enum)0))
			{
				_Background.SetVerticesDirty();
			}
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("weaponLang/{TP_COATOFARMS}name", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			_Title.text = translation;
			return;
		}
		Exception ex2 = System.Linq.Error.ArgumentNull("source");
		throw ex2;
	}

	private unsafe void MakeMorningStarConfig()
	{
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected Ref, but got Unknown
		if (_tpWhip != null)
		{
			List<System.Int32Enum> weaponList = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_tpWhip);
			_weaponList = (List<WeaponType>)(object)weaponList;
			Vector2 sizeDelta = _PanelRectTransform.sizeDelta;
			Vector2 sizeDelta2 = default(Vector2);
			_PanelRectTransform.sizeDelta = sizeDelta2;
			RectTransform component = _Background.GetComponent<RectTransform>();
			component.sizeDelta = sizeDelta2;
			_Frame.enabled = true;
			Sprite sprite = SpriteManager.GetSprite("MorningStar");
			_Background.sprite = sprite;
			if (UnityEngine.UI.SetPropertyUtility.SetStruct(ref *(System.Int32Enum*)(_Background + 240), (System.Int32Enum)0))
			{
				_Background.SetVerticesDirty();
			}
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("weaponLang/{TP_MORNINGSTAR}name", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			_Title.text = translation;
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private unsafe void MakeSpectralSwordConfig()
	{
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected Ref, but got Unknown
		if (_tpMelee != null)
		{
			List<System.Int32Enum> weaponList = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_tpMelee);
			_weaponList = (List<WeaponType>)(object)weaponList;
			PlayerOptionsData config = _playerOptions.Config;
			List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rcx_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj = default(object);
				if ((nint)obj != -1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1DB0");
					IEnumerable<System.Int32Enum> enumerable = default(IEnumerable<System.Int32Enum>);
					if (enumerable == null)
					{
						Exception ex = System.Linq.Error.ArgumentNull("source");
						throw ex;
					}
					List<System.Int32Enum> weaponList2 = new List<System.Int32Enum>(enumerable);
					_weaponList = (List<WeaponType>)(object)weaponList2;
				}
			}
			Vector2 sizeDelta = _PanelRectTransform.sizeDelta;
			Vector2 sizeDelta2 = default(Vector2);
			_PanelRectTransform.sizeDelta = sizeDelta2;
			RectTransform component = _Background.GetComponent<RectTransform>();
			component.sizeDelta = sizeDelta2;
			_Frame.enabled = true;
			Sprite sprite = SpriteManager.GetSprite("SpectralSword");
			_Background.sprite = sprite;
			if (UnityEngine.UI.SetPropertyUtility.SetStruct(ref *(System.Int32Enum*)(_Background + 240), (System.Int32Enum)0))
			{
				_Background.SetVerticesDirty();
			}
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("weaponLang/{TP_SPECTRALSWORD}name", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			_Title.text = translation;
			return;
		}
		Exception ex2 = System.Linq.Error.ArgumentNull("source");
		throw ex2;
	}

	private unsafe void MakeEbonyDialogueConfig()
	{
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected Ref, but got Unknown
		if (_tpGlyph != null)
		{
			List<System.Int32Enum> weaponList = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_tpGlyph);
			_weaponList = (List<WeaponType>)(object)weaponList;
			PlayerOptionsData config = _playerOptions.Config;
			List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rcx_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj = default(object);
				if ((nint)obj != -1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1DB0");
					IEnumerable<System.Int32Enum> enumerable = default(IEnumerable<System.Int32Enum>);
					if (enumerable == null)
					{
						Exception ex = System.Linq.Error.ArgumentNull("source");
						throw ex;
					}
					List<System.Int32Enum> weaponList2 = new List<System.Int32Enum>(enumerable);
					_weaponList = (List<WeaponType>)(object)weaponList2;
				}
			}
			Vector2 sizeDelta = _PanelRectTransform.sizeDelta;
			Vector2 sizeDelta2 = default(Vector2);
			_PanelRectTransform.sizeDelta = sizeDelta2;
			RectTransform component = _Background.GetComponent<RectTransform>();
			component.sizeDelta = sizeDelta2;
			_Frame.enabled = false;
			Sprite sprite = SpriteManager.GetSprite("Ebony Dialogue");
			_Background.sprite = sprite;
			if (UnityEngine.UI.SetPropertyUtility.SetStruct(ref *(System.Int32Enum*)(_Background + 240), (System.Int32Enum)0))
			{
				_Background.SetVerticesDirty();
			}
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("weaponLang/{TP_DIABOLOGUE}name", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			_Title.text = translation;
			return;
		}
		Exception ex2 = System.Linq.Error.ArgumentNull("source");
		throw ex2;
	}

	private unsafe void MakeFamiliarConfig()
	{
		//IL_00b8: Expected O, but got I4
		//IL_053b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Expected Ref, but got Unknown
		//IL_0138: Expected O, but got I
		//IL_0450: Expected I, but got O
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_0243: Expected O, but got I
		//IL_0253: Expected O, but got I
		//IL_02bc: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		if (_tpFamiliars != null)
		{
			List<System.Int32Enum> weaponList = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_tpFamiliars);
			_weaponList = (List<WeaponType>)(object)weaponList;
			if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
			{
				PlayerOptions playerOptions = _playerOptions;
				PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
				mainGameConfig._003CUnlockedWeapons_003Ek__BackingField._002Ector((IEnumerable<WeaponType>)1589);
				List<WeaponType> list = default(List<WeaponType>);
				if (list != null)
				{
					object obj = default(object);
					object obj2 = default(object);
					object obj4 = default(object);
					while (true)
					{
						object obj6;
						PlayerOptionsData playerOptionsData;
						if (obj != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ stack_-38_v15+1C]");
							if (obj2 != null)
							{
								break;
							}
							object obj3 = obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ stack_-38_v15+18]");
							if ((nint)obj3 >= 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ stack_-38_v15+10]");
							object obj5 = 0;
							obj6 = obj4 + 1;
							PlayerOptions playerOptions2 = _playerOptions;
							if (playerOptions2._onlineClientWithRunDataConfig == null)
							{
								if (playerOptions2._hostGameConfig == null)
								{
									if (playerOptions2._currentAdventureSaveData != null)
									{
										playerOptionsData = playerOptions2._currentAdventureSaveData;
										if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
										{
											goto IL_020e;
										}
									}
									playerOptionsData = playerOptions2._mainGameConfig;
								}
								else
								{
									playerOptionsData = playerOptions2._hostGameConfig;
								}
							}
							else
							{
								playerOptionsData = playerOptions2._onlineClientWithRunDataConfig;
							}
							goto IL_020e;
						}
						throw new NullReferenceException();
						IL_020e:
						List<System.Int32Enum> list2 = (List<System.Int32Enum>)(object)playerOptionsData._003CUnlockedWeapons_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rcx_v54 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rcx_v54 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rcx_v54 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
						List<WeaponType> list3 = (List<WeaponType>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rcx_v54 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ r8_v27+18]");
						if (num2 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdx_v36+20+v127 @ stack_-30_v13*4]");
							list2.AddWithResize((System.Int32Enum)0);
							obj4 = obj6;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rcx_v54 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
							object obj8 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdx_v36+20+v127 @ stack_-30_v13*4]");
							_ = 0;
							obj4 = obj6;
						}
					}
					bool flag = obj == null;
					nint num3 = 0;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ stack_-38_v15+1C]");
						if (obj2 == null)
						{
							goto IL_0311;
						}
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
						num3 = unchecked((nint)null);
					}
					throw new NullReferenceException();
				}
			}
			goto IL_0311;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
		IL_0311:
		Vector2 sizeDelta = _PanelRectTransform.sizeDelta;
		Vector2 sizeDelta2 = default(Vector2);
		_PanelRectTransform.sizeDelta = sizeDelta2;
		RectTransform component = _Background.GetComponent<RectTransform>();
		component.sizeDelta = sizeDelta2;
		_Frame.enabled = false;
		Sprite sprite = SpriteManager.GetSprite("Familiar Forge");
		_Background.sprite = sprite;
		if (UnityEngine.UI.SetPropertyUtility.SetStruct(ref *(System.Int32Enum*)(_Background + 240), (System.Int32Enum)0))
		{
			_Background.SetVerticesDirty();
		}
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("weaponLang/{TP_FAMILIARFORGE}name", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		_Title.text = translation;
	}

	private unsafe void MakeEmeraldsConfig()
	{
		//IL_00c0: Expected O, but got I4
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected Ref, but got Unknown
		if (_emeAllWeapons != null)
		{
			List<System.Int32Enum> weaponList = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_emeAllWeapons);
			_weaponList = (List<WeaponType>)(object)weaponList;
			Vector2 sizeDelta = _PanelRectTransform.sizeDelta;
			Vector2 sizeDelta2 = default(Vector2);
			_PanelRectTransform.sizeDelta = sizeDelta2;
			RectTransform component = _Background.GetComponent<RectTransform>();
			component.sizeDelta = sizeDelta2;
			_Frame.enabled = true;
			bool flag = SpriteLoader.LoadTexture("EME_Selector_Background_Inspiration", "Gameplay", (DlcType?)(object)1);
			Sprite sprite = SpriteManager.GetSprite("EME_Selector_Background_Inspiration");
			_Background.sprite = sprite;
			if (UnityEngine.UI.SetPropertyUtility.SetStruct(ref *(System.Int32Enum*)(_Background + 240), (System.Int32Enum)0))
			{
				_Background.SetVerticesDirty();
			}
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("weaponLang/{EME_SELECTOR}name", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			_Title.text = translation;
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public TPWeaponSelectionPage()
	{
		//IL_0055: Expected O, but got I
		//IL_00af: Expected O, but got I
		//IL_1375: Expected O, but got I
		//IL_0119: Expected O, but got I
		//IL_139d: Expected O, but got I
		//IL_0183: Expected O, but got I
		//IL_13c5: Expected O, but got I
		//IL_01ed: Expected O, but got I
		//IL_13ed: Expected O, but got I
		//IL_0257: Expected O, but got I
		//IL_1415: Expected O, but got I
		//IL_02c1: Expected O, but got I
		//IL_143d: Expected O, but got I
		//IL_032b: Expected O, but got I
		//IL_1465: Expected O, but got I
		//IL_0395: Expected O, but got I
		//IL_03dc: Expected O, but got I
		//IL_0436: Expected O, but got I
		//IL_149c: Expected O, but got I
		//IL_04a0: Expected O, but got I
		//IL_04e7: Expected O, but got I
		//IL_0541: Expected O, but got I
		//IL_14d3: Expected O, but got I
		//IL_05ab: Expected O, but got I
		//IL_14fb: Expected O, but got I
		//IL_0615: Expected O, but got I
		//IL_1523: Expected O, but got I
		//IL_067f: Expected O, but got I
		//IL_154b: Expected O, but got I
		//IL_06e9: Expected O, but got I
		//IL_1573: Expected O, but got I
		//IL_0753: Expected O, but got I
		//IL_159b: Expected O, but got I
		//IL_07bd: Expected O, but got I
		//IL_15c3: Expected O, but got I
		//IL_0827: Expected O, but got I
		//IL_086e: Expected O, but got I
		//IL_08c8: Expected O, but got I
		//IL_15fa: Expected O, but got I
		//IL_0932: Expected O, but got I
		//IL_1622: Expected O, but got I
		//IL_099c: Expected O, but got I
		//IL_164a: Expected O, but got I
		//IL_0a06: Expected O, but got I
		//IL_1672: Expected O, but got I
		//IL_0a70: Expected O, but got I
		//IL_169a: Expected O, but got I
		//IL_0ada: Expected O, but got I
		//IL_0b21: Expected O, but got I
		//IL_0b7b: Expected O, but got I
		//IL_16d1: Expected O, but got I
		//IL_0be5: Expected O, but got I
		//IL_16f9: Expected O, but got I
		//IL_0c4f: Expected O, but got I
		//IL_1721: Expected O, but got I
		//IL_0cb9: Expected O, but got I
		//IL_1749: Expected O, but got I
		//IL_0d23: Expected O, but got I
		//IL_1771: Expected O, but got I
		//IL_0d8e: Expected O, but got I
		//IL_1254: Expected O, but got I
		//IL_12ae: Expected O, but got I
		//IL_17c8: Expected O, but got I
		//IL_1318: Expected O, but got I
		List<WeaponType> weaponList = new List<WeaponType>();
		_weaponList = weaponList;
		_spawned = new List<GameObject>();
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rdx_v8+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1455);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1455;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rdx_v10+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1457);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1457;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdx_v12+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1459);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1459;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rdx_v14+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1461);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1461;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdx_v16+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1463);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1463;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rdx_v18+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1465);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1465;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rdx_v20+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1467);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1467;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rdx_v22+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1469);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1469;
		}
		_tpSpell = list;
		List<WeaponType> list2 = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1577 @ rax_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1577 @ rax_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1577 @ rax_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rdx_v26+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1595);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1577 @ rax_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 1595;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1577 @ rax_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1577 @ rax_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1577 @ rax_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rdx_v28+18]");
		if (num10 >= 0)
		{
			((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)1569);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1577 @ rax_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 1569;
		}
		_tpSpell_Secret = list2;
		List<WeaponType> list3 = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rdx_v32+18]");
		if (num11 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)1411);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 1411;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rdx_v34+18]");
		if (num12 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)1494);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 1494;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rdx_v36+18]");
		if (num13 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)1415);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 1415;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rdx_v38+18]");
		if (num14 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)1419);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 1419;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rdx_v40+18]");
		if (num15 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)1417);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 1417;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rdx_v42+18]");
		if (num16 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)1503);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 1503;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rdx_v44+18]");
		if (num17 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)1508);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj34 = (nint)0 + (nint)1;
			_ = 1508;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rdx_v46+18]");
		if (num18 >= 0)
		{
			((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)1501);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1707 @ rax_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj36 = (nint)0 + (nint)1;
			_ = 1501;
		}
		_tpMelee = list3;
		List<WeaponType> list4 = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rdx_v50+18]");
		if (num19 >= 0)
		{
			((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)1564);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj38 = (nint)0 + (nint)1;
			_ = 1564;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rdx_v52+18]");
		if (num20 >= 0)
		{
			((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)1594);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj40 = (nint)0 + (nint)1;
			_ = 1594;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rdx_v54+18]");
		if (num21 >= 0)
		{
			((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)1554);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj42 = (nint)0 + (nint)1;
			_ = 1554;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rdx_v56+18]");
		if (num22 >= 0)
		{
			((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)1578);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj44 = (nint)0 + (nint)1;
			_ = 1578;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdx_v58+18]");
		if (num23 >= 0)
		{
			((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)1617);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj46 = (nint)0 + (nint)1;
			_ = 1617;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rdx_v60+18]");
		if (num24 >= 0)
		{
			((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)1615);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj48 = (nint)0 + (nint)1;
			_ = 1615;
		}
		_tpMelee_Secret = list4;
		List<WeaponType> list5 = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rdx_v64+18]");
		if (num25 >= 0)
		{
			((List<System.Int32Enum>)(object)list5).AddWithResize((System.Int32Enum)1423);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj50 = (nint)0 + (nint)1;
			_ = 1423;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj51 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdx_v66+18]");
		if (num26 >= 0)
		{
			((List<System.Int32Enum>)(object)list5).AddWithResize((System.Int32Enum)1425);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj52 = (nint)0 + (nint)1;
			_ = 1425;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj53 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rdx_v68+18]");
		if (num27 >= 0)
		{
			((List<System.Int32Enum>)(object)list5).AddWithResize((System.Int32Enum)1421);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj54 = (nint)0 + (nint)1;
			_ = 1421;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj55 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rdx_v70+18]");
		if (num28 >= 0)
		{
			((List<System.Int32Enum>)(object)list5).AddWithResize((System.Int32Enum)1413);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj56 = (nint)0 + (nint)1;
			_ = 1413;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj57 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rdx_v72+18]");
		if (num29 >= 0)
		{
			((List<System.Int32Enum>)(object)list5).AddWithResize((System.Int32Enum)1431);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj58 = (nint)0 + (nint)1;
			_ = 1431;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj59 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num30 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rdx_v74+18]");
		if (num30 >= 0)
		{
			((List<System.Int32Enum>)(object)list5).AddWithResize((System.Int32Enum)1492);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2277 @ rax_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj60 = (nint)0 + (nint)1;
			_ = 1492;
		}
		list5.Add(WeaponType.TP_RPG1);
		list5.Add(WeaponType.TP_WINEGLASS1);
		list5.Add(WeaponType.WHIP);
		list5.Add(WeaponType.AXE);
		list5.Add(WeaponType.KNIFE);
		list5.Add(WeaponType.HOLYWATER);
		list5.Add(WeaponType.DIAMOND);
		list5.Add(WeaponType.HOLYBOOK);
		list5.Add(WeaponType.CROSS);
		list5.Add(WeaponType.LIGHTNING);
		_tpProjectile = list5;
		_tpProjectile_Secret = new List<WeaponType>
		{
			WeaponType.TP_SAVROG_WEAPON,
			WeaponType.TP_NEUTRON_WEAPON,
			WeaponType.TP_HYDROSTORM,
			WeaponType.TP_GRANDCROSS
		};
		_tpGlyph = new List<WeaponType>
		{
			WeaponType.TP_CONFODERE1,
			WeaponType.TP_SPITE1,
			WeaponType.TP_LIGHT1,
			WeaponType.TP_DARK1,
			WeaponType.TP_ENERGY1,
			WeaponType.TP_RAPIDUS1,
			WeaponType.TP_CUSTOS1,
			WeaponType.TP_CUSTOS2,
			WeaponType.TP_CUSTOS3,
			WeaponType.TP_DOMINUS1,
			WeaponType.TP_DOMINUS2,
			WeaponType.TP_DOMINUS3
		};
		_tpGlyph_Secret = new List<WeaponType>
		{
			WeaponType.TP_SUMMON_SPIRIT,
			WeaponType.TP_DARKRIFT,
			WeaponType.TP_SWORD_BROTHERS,
			WeaponType.TP_SOULSTEAL_WEAPON
		};
		_tpWhip = new List<WeaponType>
		{
			WeaponType.TP_ALCHEMYWHIP1,
			WeaponType.TP_SONICWHIP1,
			WeaponType.TP_DRAGONWATER1,
			WeaponType.TP_LEMURIA1,
			WeaponType.TP_WINDWHIP1,
			WeaponType.TP_HOLYWHIP1,
			WeaponType.TP_PLATINUMWHIP1,
			WeaponType.TP_MARTIALWHIP1
		};
		_tpFamiliars = new List<WeaponType>
		{
			WeaponType.TP_ACC_FAMILIAR_UKOBACK,
			WeaponType.TP_ACC_FAMILIAR_BITTERFLY,
			WeaponType.TP_ACC_FAMILIAR_ALLEGEDGHOST,
			WeaponType.TP_ACC_FAMILIAR_IMP,
			WeaponType.TP_ACC_FAMILIAR_WIZARD,
			WeaponType.TP_ACC_FAMILIAR_PUMPKIN,
			WeaponType.TP_ACC_FAMILIAR_FAIRY,
			WeaponType.TP_ACC_FAMILIAR_CARDINAL,
			WeaponType.TP_ACC_FAMILIAR_DRAGON,
			WeaponType.TP_ACC_FAMILIAR_TIGER,
			WeaponType.TP_ACC_FAMILIAR_TURTLE
		};
		List<WeaponType> list6 = new List<WeaponType>
		{
			WeaponType.EME_RAPIER1,
			WeaponType.EME_LONGSWORD1,
			WeaponType.EME_DUAL1,
			WeaponType.EME_GREATSWORD1,
			WeaponType.EME_PUNCH1,
			WeaponType.EME_KICK1,
			WeaponType.EME_CANNON1,
			WeaponType.EME_MECH1,
			WeaponType.EME_PISTOL1,
			WeaponType.EME_KNIFE1,
			WeaponType.EME_KATANA1,
			WeaponType.EME_AXE1,
			WeaponType.EME_BLOOD1,
			WeaponType.EME_SPEAR1
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2654 @ rax_v126 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2654 @ rax_v126 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj61 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2654 @ rax_v126 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rdx_v145+18]");
		if (num31 >= 0)
		{
			((List<System.Int32Enum>)(object)list6).AddWithResize((System.Int32Enum)376);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2654 @ rax_v126 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj62 = (nint)0 + (nint)1;
			_ = 376;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2654 @ rax_v126 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2654 @ rax_v126 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj63 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2654 @ rax_v126 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rdx_v147+18]");
		if (num32 >= 0)
		{
			((List<System.Int32Enum>)(object)list6).AddWithResize((System.Int32Enum)405);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2654 @ rax_v126 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj64 = (nint)0 + (nint)1;
			_ = 405;
		}
		_emeAllWeapons = list6;
		((BaseUIPage)this)._002Ector();
	}
}
