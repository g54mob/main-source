using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.UI;

public class TreasureReelUI : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Comparison<List<WeaponData>> _003C_003E9__31_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal int _003CMakeTexture_Any_003Eb__31_0(List<WeaponData> a, List<WeaponData> b)
		{
			//IL_011c: Expected I4, but got O
			//IL_00d0: Expected I4, but got I8
			if (a != b)
			{
				if (b != null)
				{
					if (b._size > 0)
					{
						WeaponData[] items = b._items;
						if (b._items != null)
						{
							WeaponData weaponData = items[0];
							if (items[0] != null)
							{
								bool flag = !weaponData._003CisEvolution_003Ek__BackingField;
								int result = -1;
								if (!flag)
								{
									result = 1;
								}
								return result;
							}
						}
					}
					else
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (int)ex;
			}
			return 0;
		}
	}

	private string _ColorString;

	private float _Alpha;

	private float Speed;

	private Animator Anim;

	private Image RewardBeam;

	private GameObject Reward;

	private Image RewardIcon;

	private Image _FlashBackground;

	private RectTransform _Star1;

	private RectTransform _Star2;

	private GameObject _ReelIcon;

	private Texture2D _GeneratedTexture;

	private RawImage _RewardImage;

	private int _minAmountOfPowerups = 12;

	private float _originalWidth;

	private Vector3 _originalPosition;

	private RectTransform _rectTrans;

	private List<Tuple<string, string>> _weaponNamesNew;

	private bool _isActive;

	private static readonly int Reveal1;

	private LevelUpFactory _levelUp;

	private PlayerOptions _playerOptions;

	private Tween _Star1TweenRot;

	private Tween _Star1TweenScale;

	private Tween _Star2TweenRot;

	private Tween _Star2TweenScale;

	private Dictionary<WeaponType, List<WeaponData>> _weapons;

	private void Constructor(LevelUpFactory level, PlayerOptions playerOptions)
	{
		_levelUp = level;
		_playerOptions = playerOptions;
	}

	private unsafe void Start()
	{
		//IL_0067: Expected F4, but got O
		//IL_00ac: Expected O, but got Ref
		//IL_019f->IL0116: Incompatible stack heights: 1 vs 0
		//IL_00d1->IL0116: Incompatible stack heights: 1 vs 0
		//IL_0100->IL0116: Incompatible stack heights: 1 vs 0
		RectTransform component = GetComponent<RectTransform>();
		_rectTrans = component;
		if ((object)RewardBeam != null)
		{
			RectTransform rectTransform = RewardBeam.rectTransform;
			if ((object)rectTransform != null)
			{
				Vector2 sizeDelta = rectTransform.sizeDelta;
				_originalWidth = (float)sizeDelta;
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					_originalPosition = ret;
					_ = 0;
					Color color = ColourHelper.HexToColor(_ColorString);
					if ((object)RewardBeam != null)
					{
						RewardBeam.color = (Color)(&ret);
						Speed = 1f;
						if ((object)Anim != null)
						{
							Anim.keepAnimatorStateOnDisable = false;
							if ((object)Anim != null)
							{
								Anim.writeDefaultValuesOnDisable = true;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void SetRewardIcon(string spriteName, string textureName)
	{
		Sprite sprite = SpriteManager.GetSprite(spriteName, textureName);
		RewardIcon.sprite = sprite;
	}

	public void GenerateWeapons(GameSessionData session, Dictionary<WeaponType, List<WeaponData>> weapons, PrizeType prize, VampireSurvivors.Objects.Characters.CharacterController character)
	{
		_weapons = weapons;
		if (_weaponNamesNew == null)
		{
			List<Tuple<string, string>> weaponNamesNew = new List<Tuple<string, string>>();
			_weaponNamesNew = weaponNamesNew;
		}
		List<Tuple<string, string>> weaponNamesNew2 = _weaponNamesNew;
		int version = weaponNamesNew2._version + 1;
		weaponNamesNew2._version = version;
		weaponNamesNew2._size = 0;
		if (weaponNamesNew2._size > 0)
		{
			Array.Clear(weaponNamesNew2._items, 0, weaponNamesNew2._size);
		}
		object message;
		if (prize != PrizeType.POWERUP)
		{
			VampireSurvivors.Objects.Characters.CharacterController character2 = default(VampireSurvivors.Objects.Characters.CharacterController);
			if (prize != PrizeType.EXISTING_ANY && prize != PrizeType.EXISTING_WEAPON)
			{
				if (prize != PrizeType.FIXED && prize != PrizeType.EVOLUTION)
				{
					MakeTexture_ExistingWeapons(character2);
					goto IL_01c1;
				}
				MakeTexture_Any();
				message = "REEL : Make Texture Fixed or Evo";
			}
			else
			{
				MakeTexture_ExistingWeapons(character2);
				message = "REEL : Make Texture Existings";
			}
		}
		else
		{
			MakeTexture_PowerUps();
			message = "REEL : Make Texture Power up";
		}
		Debug.Log(message);
		goto IL_01c1;
		IL_01c1:
		SetWeapons(_weaponNamesNew);
	}

	private unsafe void MakeTexture_Any(bool shuffle = true)
	{
		//IL_0021: Expected O, but got Ref
		//IL_010d: Expected O, but got I4
		//IL_0115: Expected O, but got Ref
		List<List<WeaponData>> list = new List<List<WeaponData>>();
		Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator = default(Dictionary<WeaponType, List<WeaponData>>.Enumerator);
		object item = default(object);
		while (enumerator.MoveNext())
		{
			bool flag = list == null;
			Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator2 = (Dictionary<WeaponType, List<WeaponData>>.Enumerator)(&enumerator);
			if (!flag)
			{
				int version = list._version + 1;
				list._version = version;
				Dictionary<WeaponType, List<WeaponData>>.Enumerator items = (Dictionary<WeaponType, List<WeaponData>>.Enumerator)list._items;
				int size = list._size;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rcx_v48 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.WeaponType, System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>>+Enumerator<VampireSurvivors.Data.WeaponType, System.Collect…");
				if ((nint)size >= (nint)0)
				{
					((List<object>)(object)list).AddWithResize(item);
					continue;
				}
				int size2 = list._size + 1;
				list._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				continue;
			}
			throw new NullReferenceException();
		}
		if (shuffle)
		{
			VampireSurvivors.App.Tools.Extensions.Shuffle((IList<object>)list);
			Comparison<object> comparison = (Comparison<object>)_003C_003Ec._003C_003E9__31_0;
			if (_003C_003Ec._003C_003E9__31_0 == null)
			{
				comparison = (Comparison<object>)(_003C_003Ec._003C_003E9__31_0 = delegate(List<WeaponData> a, List<WeaponData> b)
				{
					//IL_011c: Expected I4, but got O
					//IL_00d0: Expected I4, but got I8
					if (a != b)
					{
						if (b != null)
						{
							if (b._size > 0)
							{
								WeaponData[] items2 = b._items;
								if (b._items != null)
								{
									WeaponData weaponData = items2[0];
									if (items2[0] != null)
									{
										bool flag2 = !weaponData._003CisEvolution_003Ek__BackingField;
										int result = -1;
										if (!flag2)
										{
											result = 1;
										}
										return result;
									}
								}
							}
							else
							{
								System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							}
						}
						NullReferenceException ex = new NullReferenceException();
						return (int)ex;
					}
					return 0;
				});
			}
			((List<object>)(object)list).Sort(comparison);
		}
		List<List<WeaponData>>.Enumerator enumerator3 = default(List<List<WeaponData>>.Enumerator);
		if (enumerator3.MoveNext())
		{
			List<object> weaponNamesNew = (List<object>)(object)_weaponNamesNew;
			object obj = 0;
			List<List<WeaponData>>.Enumerator enumerator4 = (List<List<WeaponData>>.Enumerator)(&enumerator3);
			throw new NullReferenceException();
		}
	}

	private unsafe void MakeTexture_PowerUps(bool shuffle = true)
	{
		//IL_058b: Expected O, but got I
		//IL_01c7: Expected O, but got I
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		//IL_01e3: Expected O, but got Ref
		//IL_0273: Expected O, but got I
		//IL_0288: Expected O, but got I
		//IL_02e5: Expected O, but got I
		//IL_02fa: Expected O, but got I
		//IL_031c: Expected O, but got I
		//IL_031c: Expected O, but got I
		//IL_03ce: Expected O, but got I4
		List<WeaponType> remainingPowerupsAndWeapons = _levelUp.GetRemainingPowerupsAndWeapons();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v63 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		if ((nint)0 > (nint)0)
		{
			List<object> list = null;
			object obj = default(object);
			object obj2 = default(object);
			object obj4 = default(object);
			IntPtr intPtr = default(IntPtr);
			while (true)
			{
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ stack_-B0_v23+1C]");
					if (obj2 == null)
					{
						object obj3 = obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ stack_-B0_v23+18]");
						if ((nint)obj3 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ stack_-B0_v23+10]");
							object obj5 = 0;
							object obj6 = obj4 + 1;
							string text = ((Enum)(&intPtr)).ToString();
							string message = "Weapon To Show : " + text;
							Debug.Log(message);
							List<object> weaponNamesNew = (List<object>)(object)_weaponNamesNew;
							Dictionary<WeaponType, List<WeaponData>> weapons = _weapons;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v924 @ rdx_v39+20+v507 @ stack_-A8_v21*4]");
							object obj7 = ((Dictionary<System.Int32Enum, object>)(object)weapons).get_Item((System.Int32Enum)0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1612 @ rax_v84 (System.Object)+18]");
							if ((nint)0 > (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1612 @ rax_v84 (System.Object)+10]");
								object obj8 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1383 @ rax_v85+20]");
								object obj9 = 0;
								Dictionary<WeaponType, List<WeaponData>> weapons2 = _weapons;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v924 @ rdx_v39+20+v507 @ stack_-A8_v21*4]");
								object obj10 = ((Dictionary<System.Int32Enum, object>)(object)weapons2).get_Item((System.Int32Enum)0);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1855 @ rax_v86 (System.Object)+18]");
								if ((nint)0 > (nint)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1855 @ rax_v86 (System.Object)+10]");
									object obj11 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1455 @ rax_v87+20]");
									object obj12 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2079 @ rcx_v50+40]");
									nint num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1684 @ rcx_v52+38]");
									Tuple<string, string> tuple = new Tuple<string, string>((string)num, (string)0);
									int version = weaponNamesNew._version + 1;
									weaponNamesNew._version = version;
									Tuple<string, string> items = (Tuple<string, string>)(object)weaponNamesNew._items;
									if (weaponNamesNew._size >= (nint)items.m_Item2)
									{
										weaponNamesNew.AddWithResize((object)tuple);
										obj4 = obj6;
										continue;
									}
									int size = weaponNamesNew._size + 1;
									weaponNamesNew._size = size;
									items._002Ector((string)weaponNamesNew._size, (string)(object)tuple);
									obj4 = obj6;
									continue;
								}
								System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
								throw new NullReferenceException();
							}
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							throw new NullReferenceException();
						}
						break;
					}
					break;
				}
				throw new NullReferenceException();
			}
			bool flag = obj == null;
			list = (List<object>)0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ stack_-B0_v23+1C]");
				if (obj2 == null)
				{
					goto IL_0535;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				list = null;
			}
			throw new NullReferenceException();
		}
		Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator = default(Dictionary<WeaponType, List<WeaponData>>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			Tuple<string, string> tuple2 = null;
			Tuple<string, string> tuple3 = null;
			throw new NullReferenceException();
		}
		goto IL_0535;
		IL_0535:
		if (shuffle)
		{
			VampireSurvivors.App.Tools.Extensions.Shuffle((IList<object>)_weaponNamesNew);
		}
	}

	private unsafe void MakeTexture_ExistingWeapons(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0117: Expected O, but got Ref
		//IL_04dd: Expected O, but got I
		//IL_0070: Expected O, but got I
		//IL_0080: Expected O, but got I
		//IL_017a: Expected O, but got I
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_00fa: Expected O, but got I
		//IL_01f4: Expected O, but got I
		//IL_0209: Expected O, but got I
		//IL_0266: Expected O, but got I
		//IL_027b: Expected O, but got I
		//IL_029d: Expected O, but got I
		//IL_029d: Expected O, but got I
		//IL_034f: Expected O, but got I4
		List<WeaponType> existingNotMaxedWeapons = _levelUp.GetExistingNotMaxedWeapons(character);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		LevelUpFactory levelUpFactory;
		if ((nint)0 <= (nint)0)
		{
			Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator = default(Dictionary<WeaponType, List<WeaponData>>.Enumerator);
			while (enumerator.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rcx_v47+18]");
					if (num >= 0)
					{
						((List<System.Int32Enum>)(object)existingNotMaxedWeapons).AddWithResize((System.Int32Enum)0);
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					object obj3 = (nint)0 + (nint)1;
					_ = 0;
					continue;
				}
				throw new NullReferenceException();
			}
			levelUpFactory = (LevelUpFactory)(&enumerator);
		}
		object obj4 = default(object);
		object obj5 = default(object);
		object obj7 = default(object);
		while (true)
		{
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ stack_-80_v5+1C]");
				if (obj5 == null)
				{
					object obj6 = obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ stack_-80_v5+18]");
					if ((nint)obj6 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ stack_-80_v5+10]");
						object obj8 = 0;
						object obj9 = obj7 + 1;
						List<object> weaponNamesNew = (List<object>)(object)_weaponNamesNew;
						Dictionary<WeaponType, List<WeaponData>> weapons = _weapons;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v694 @ rdx_v10+20+v520 @ stack_-78_v3*4]");
						object obj10 = ((Dictionary<System.Int32Enum, object>)(object)weapons).get_Item((System.Int32Enum)0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v947 @ rax_v21 (System.Object)+18]");
						if ((nint)0 > (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v947 @ rax_v21 (System.Object)+10]");
							object obj11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v921 @ rax_v22+20]");
							object obj12 = 0;
							Dictionary<WeaponType, List<WeaponData>> weapons2 = _weapons;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v694 @ rdx_v10+20+v520 @ stack_-78_v3*4]");
							object obj13 = ((Dictionary<System.Int32Enum, object>)(object)weapons2).get_Item((System.Int32Enum)0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1398 @ rax_v23 (System.Object)+18]");
							if ((nint)0 > (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1398 @ rax_v23 (System.Object)+10]");
								object obj14 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1009 @ rax_v24+20]");
								object obj15 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1366 @ rcx_v13+40]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1259 @ rcx_v15+38]");
								Tuple<string, string> tuple = new Tuple<string, string>((string)num2, (string)0);
								int version = weaponNamesNew._version + 1;
								weaponNamesNew._version = version;
								Tuple<string, string> items = (Tuple<string, string>)(object)weaponNamesNew._items;
								if (weaponNamesNew._size >= (nint)items.m_Item2)
								{
									weaponNamesNew.AddWithResize((object)tuple);
									obj7 = obj9;
									continue;
								}
								int size = weaponNamesNew._size + 1;
								weaponNamesNew._size = size;
								items._002Ector((string)weaponNamesNew._size, (string)(object)tuple);
								obj7 = obj9;
								continue;
							}
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							throw new NullReferenceException();
						}
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						throw new NullReferenceException();
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag = obj4 == null;
		levelUpFactory = (LevelUpFactory)0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ stack_-80_v5+1C]");
			if (obj5 == null)
			{
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			levelUpFactory = null;
		}
		throw new NullReferenceException();
	}

	public unsafe void SetWeapons(List<Tuple<string, string>> weapons)
	{
		//IL_00c0: Expected F4, but got I4
		//IL_0b87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8c: Expected I4, but got Unknown
		//IL_0bb3: Expected O, but got I4
		//IL_0bb3: Expected I4, but got O
		//IL_00df: Expected O, but got Ref
		//IL_0bcc: Expected O, but got I4
		//IL_041e: Expected F4, but got I4
		//IL_052c: Expected O, but got I4
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_048b: Expected O, but got Unknown
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ac: Expected O, but got Unknown
		//IL_04b5: Expected F4, but got I4
		//IL_0c7e: Expected I, but got O
		//IL_0cd7: Expected I, but got O
		//IL_098e: Expected I, but got O
		//IL_09c9: Expected I, but got O
		//IL_07d3: Expected I4, but got O
		//IL_07fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0800: Expected O, but got Unknown
		//IL_086e: Expected I4, but got O
		//IL_0891: Expected O, but got I4
		//IL_0891: Expected I4, but got O
		//IL_0d30: Expected I, but got O
		//IL_0c34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c39: Expected O, but got Unknown
		//IL_0ca2->IL0a61: Incompatible stack heights: 1 vs 0
		//IL_0907->IL0a61: Incompatible stack heights: 1 vs 0
		//IL_0941->IL0a61: Incompatible stack heights: 1 vs 0
		//IL_0977->IL0a61: Incompatible stack heights: 1 vs 0
		//IL_0cfb->IL0a61: Incompatible stack heights: 2 vs 0
		//IL_09bc->IL0a61: Incompatible stack heights: 2 vs 0
		//IL_09ee->IL0a61: Incompatible stack heights: 2 vs 0
		//IL_0a1c->IL0a61: Incompatible stack heights: 2 vs 0
		//IL_0a48->IL0a61: Incompatible stack heights: 2 vs 0
		//IL_0d48->IL0a61: Incompatible stack heights: 3 vs 0
		_weaponNamesNew = weapons;
		Component rewardImage = _RewardImage;
		if ((object)_RewardImage != null)
		{
			GameObject gameObject = _RewardImage.gameObject;
			if ((object)gameObject != null)
			{
				gameObject.SetActive(value: true);
				List<Sprite> list = new List<Sprite>();
				bool flag = weapons == null;
				rewardImage = (Component)(object)list;
				if (!flag)
				{
					float num = 0f;
					List<Tuple<string, string>> list2 = null;
					List<Tuple<string, string>>.Enumerator enumerator = default(List<Tuple<string, string>>.Enumerator);
					if (enumerator.MoveNext())
					{
						Texture2D texture2D = null;
						rewardImage = (Component)(&enumerator);
						throw new NullReferenceException();
					}
					int num2 = list2 + 2;
					int num3 = default(int);
					bool flag2 = default(bool);
					IntPtr intPtr = default(IntPtr);
					bool createUninitialized = default(bool);
					List<Tuple<string, string>> list3 = default(List<Tuple<string, string>>);
					Texture2D generatedTexture = new Texture2D(num2, (int)list3, TextureFormat.ARGB4444, num3, flag2, intPtr, createUninitialized, (MipmapLimitDescriptor)1);
					list3 = (List<Tuple<string, string>>)(_minAmountOfPowerups << 5);
					_GeneratedTexture = generatedTexture;
					bool flag3 = (object)_GeneratedTexture == null;
					rewardImage = (Component)(object)_GeneratedTexture;
					if (!flag3)
					{
						_GeneratedTexture.wrapMode = TextureWrapMode.Repeat;
						bool flag4 = (object)_GeneratedTexture == null;
						rewardImage = (Component)(object)_GeneratedTexture;
						if (!flag4)
						{
							Color[] pixels = _GeneratedTexture.GetPixels();
							bool flag5 = pixels == null;
							float num4 = 0f;
							Component component = null;
							Component component2 = null;
							rewardImage = null;
							if (!flag5)
							{
								while ((nint)component2 < pixels.Length)
								{
									if ((nint)component < pixels.Length)
									{
										object obj = component + 2;
										object obj2 = obj + obj;
										_ = 0;
										component = (Component)(component + 1);
										num4 = 0f;
										component2 = component;
										continue;
									}
									throw new IndexOutOfRangeException();
								}
								bool flag6 = (object)_GeneratedTexture == null;
								rewardImage = component;
								if (!flag6)
								{
									int width = _GeneratedTexture.width;
									int height = _GeneratedTexture.height;
									_GeneratedTexture.SetPixels(0, 0, width, num3, (Color[])flag2, (int)(nint)intPtr);
									Component component3 = null;
									Component component4 = null;
									int num5 = 0;
									rewardImage = (Component)(object)_GeneratedTexture;
									List<Tuple<string, string>> list4 = default(List<Tuple<string, string>>);
									Component component5 = default(Component);
									Vector2 value = default(Vector2);
									while (true)
									{
										List<Tuple<string, string>> weaponNamesNew = _weaponNamesNew;
										if (_weaponNamesNew == null)
										{
											break;
										}
										if ((nint)component4 < weaponNamesNew._size && (nint)component4 < _minAmountOfPowerups)
										{
											if (list != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
												if (list4 != null)
												{
													Texture2D texture = ((Sprite)(object)list4).texture;
													if ((object)texture != null)
													{
														int width2 = texture.width;
														Vector2[] uv = ((Sprite)(object)list4).uv;
														if (uv != null)
														{
															if (uv.Length > 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1278 @ rax_v128 (UnityEngine.Vector2[])+20]");
																int num6 = (int)((nint)width2 / (nint)0);
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
																Texture2D texture2 = ((Sprite)(object)list4).texture;
																if ((object)texture2 != null)
																{
																	int height2 = texture2.height;
																	Vector2[] uv2 = ((Sprite)(object)list4).uv;
																	if (uv2 != null)
																	{
																		if (uv2.Length > 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1362 @ rax_v133 (UnityEngine.Vector2[])+24]");
																			int num7 = (int)((nint)height2 / (nint)0);
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
																			Texture2D texture3 = ((Sprite)(object)list4).texture;
																			Rect rect = ((Sprite)(object)list4).rect;
																			Rect rect2 = ((Sprite)(object)list4).rect;
																			Rect rect3 = ((Sprite)(object)list4).rect;
																			Rect rect4 = ((Sprite)(object)list4).rect;
																			if ((object)texture3 != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0Ch]\"");
																				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r9d,xmm7\"");
																				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm6\"");
																				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm8\"");
																				Color[] pixels2 = texture3.GetPixels((int)list4, 0, width, num3, flag2 ? 1 : 0);
																				Rect rect5 = ((Sprite)(object)list4).rect;
																				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+8]\"");
																				object obj3 = num2 - rect5;
																				num4 = (float)obj3 * 0.5f;
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
																				bool flag7 = (nint)component5 < 0;
																				Component component6 = component3;
																				if (!flag7)
																				{
																					component6 = component5;
																				}
																				Rect rect6 = ((Sprite)(object)list4).rect;
																				Rect rect7 = ((Sprite)(object)list4).rect;
																				if ((object)_GeneratedTexture != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+0Ch]\"");
																					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r9d,xmm6\"");
																					num5 = (object)component4 << 5;
																					_GeneratedTexture.SetPixels((int)component6, num5, width, num3, (Color[])flag2, (int)(nint)intPtr);
																					component4 = (Component)(component4 + 1);
																					component3 = null;
																					rewardImage = (Component)(object)_GeneratedTexture;
																					continue;
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
															throw new IndexOutOfRangeException();
														}
														throw new NullReferenceException();
													}
													throw new NullReferenceException();
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										List<Tuple<string, string>> generatedTexture2 = (List<Tuple<string, string>>)(object)_GeneratedTexture;
										if ((object)_GeneratedTexture == null)
										{
											break;
										}
										bool flag8 = generatedTexture2._items == null;
										Texture.set_filterMode_Injected((IntPtr)generatedTexture2._items, FilterMode.Point);
										bool flag9 = (object)_GeneratedTexture == null;
										rewardImage = (Component)(object)_GeneratedTexture;
										if (flag9)
										{
											break;
										}
										_GeneratedTexture.Apply(updateMipmaps: true, makeNoLongerReadable: false);
										bool flag10 = (object)_RewardImage == null;
										rewardImage = _RewardImage;
										if (flag10)
										{
											break;
										}
										_RewardImage.texture = _GeneratedTexture;
										bool flag11 = (object)_RewardImage == null;
										rewardImage = _RewardImage;
										if (flag11)
										{
											break;
										}
										RectTransform rectTransform = _RewardImage.rectTransform;
										bool flag12 = (object)rectTransform == null;
										rewardImage = _RewardImage;
										if (flag12)
										{
											break;
										}
										bool flag13 = ((List<Tuple<string, string>>)(object)rectTransform)._items == null;
										RectTransform.get_rect_Injected((IntPtr)((List<Tuple<string, string>>)(object)rectTransform)._items, out Rect _);
										rewardImage = (Component)(object)_GeneratedTexture;
										if ((object)_GeneratedTexture == null)
										{
											break;
										}
										nint num8 = (nint)rewardImage;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2985 @ rdx_v58 (Il2CppClass<UnityEngine.Component>)+188] (should have been resolved before IL gen)");
										rewardImage = (Component)(object)_GeneratedTexture;
										if ((object)_GeneratedTexture == null)
										{
											break;
										}
										nint num9 = (nint)rewardImage;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2991 @ rdx_v60 (Il2CppClass<UnityEngine.Component>)+1A8] (should have been resolved before IL gen)");
										if ((object)_RewardImage == null)
										{
											break;
										}
										RectTransform rectTransform2 = _RewardImage.rectTransform;
										if ((object)_RewardImage == null)
										{
											break;
										}
										RectTransform rectTransform3 = _RewardImage.rectTransform;
										if ((object)rectTransform3 == null)
										{
											break;
										}
										bool flag14 = ((List<Tuple<string, string>>)(object)rectTransform3)._items == null;
										RectTransform.get_sizeDelta_Injected((IntPtr)((List<Tuple<string, string>>)(object)rectTransform3)._items, out Vector2 _);
										if ((object)rectTransform2 == null)
										{
											break;
										}
										bool flag15 = ((UnityEngine.Object)rectTransform2).m_CachedPtr == (IntPtr)0;
										RectTransform.set_sizeDelta_Injected(((UnityEngine.Object)rectTransform2).m_CachedPtr, ref value);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void StartScrolling()
	{
		_isActive = true;
	}

	public void StopScrolling()
	{
		_isActive = false;
		GameObject gameObject = _RewardImage.gameObject;
		gameObject.SetActive(value: false);
	}

	private void Update()
	{
		//IL_0102: Expected O, but got F4
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_00ea: Expected O, but got I4
		//IL_009e: Invalid comparison between O and F4
		//IL_00be: Invalid comparison between O and F4
		if (!_isActive)
		{
			return;
		}
		RawImage rewardImage = _RewardImage;
		object obj = Time.deltaTime;
		object obj3 = default(object);
		object obj2 = obj3 * Speed;
		Rect rect = default(Rect);
		object obj4 = (object)rect - obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186DF5275h\"");
		if ((object)rewardImage.m_UVRect == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186DF5275h\"");
			if ((object)rect == obj4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186DF5275h\"");
				if ((object)rect == (object)1f)
				{
					bool flag = (object)rect == (object)1f;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186DF5275h\"");
					if (flag)
					{
						return;
					}
				}
			}
		}
		rewardImage.m_UVRect = (Rect)0;
		rewardImage.SetVerticesDirty();
	}

	public void Reveal()
	{
		Anim.SetBool(Reveal1, value: true);
		_isActive = false;
		GameObject gameObject = _RewardImage.gameObject;
		gameObject.SetActive(value: false);
		DoStarTweens();
	}

	public void HideBeam()
	{
		RectTransform rectTransform = RewardBeam.rectTransform;
		RectTransform rectTransform2 = RewardBeam.rectTransform;
		Vector2 sizeDelta = rectTransform2.sizeDelta;
		Vector2 endValue = default(Vector2);
		TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOSizeDelta(rectTransform, endValue, 0.5f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(RewardBeam, 0f, 0.5f);
	}

	public void Finish()
	{
		Anim.SetBool(Reveal1, value: false);
	}

	public void Reset()
	{
		if ((object)Reward != null)
		{
			Reward.SetActive(value: false);
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(RewardBeam, 0.5f, 0.0001f);
			if ((object)RewardBeam != null)
			{
				RectTransform rectTransform = RewardBeam.rectTransform;
				if ((object)RewardBeam != null)
				{
					RectTransform rectTransform2 = RewardBeam.rectTransform;
					if ((object)rectTransform2 != null)
					{
						Vector2 sizeDelta = rectTransform2.sizeDelta;
						Vector2 sizeDelta2 = default(Vector2);
						rectTransform.sizeDelta = sizeDelta2;
						Transform transform = base.transform;
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void FlashOn()
	{
		_FlashBackground.enabled = true;
	}

	public void FlashOff()
	{
		_FlashBackground.enabled = false;
	}

	private unsafe void DoStarTweens()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0613: Expected O, but got Ref
		//IL_0162: Expected O, but got Ref
		//IL_0670: Expected O, but got Ref
		//IL_0214: Expected O, but got Ref
		//IL_0234: Expected O, but got Ref
		//IL_031c: Expected O, but got Ref
		//IL_03ff: Expected O, but got Ref
		//IL_04dd: Expected O, but got Ref
		//IL_069c->IL05dc: Incompatible stack heights: 1 vs 0
		//IL_01fb->IL05dc: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (_Star1TweenRot != null)
		{
			TweenExtensions.Kill(_Star1TweenRot, complete: true);
		}
		if (_Star2TweenRot != null)
		{
			TweenExtensions.Kill(_Star2TweenRot, complete: true);
		}
		if (_Star1TweenScale != null)
		{
			TweenExtensions.Kill(_Star1TweenScale, complete: true);
		}
		if (_Star2TweenScale != null)
		{
			TweenExtensions.Kill(_Star2TweenScale, complete: true);
		}
		if ((object)_Star1 != null)
		{
			Transform transform = _Star1.transform;
			if ((object)transform != null)
			{
				_ = 1f;
				if (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
				}
				else
				{
					object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj3);
					if ((object)_Star1 != null)
					{
						Transform transform2 = _Star1.transform;
						if ((object)transform2 != null)
						{
							_ = 111f;
							Vector3 localEulerAngles = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
							transform2.localEulerAngles = localEulerAngles;
							if ((object)_Star2 != null)
							{
								Transform transform3 = _Star2.transform;
								if ((object)transform3 != null)
								{
									_ = 1f;
									bool flag = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
									object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
									Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj4);
									if ((object)_Star2 != null)
									{
										Transform transform4 = _Star2.transform;
										if ((object)transform4 != null)
										{
											_ = -144f;
											Vector3 localEulerAngles2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
											transform4.localEulerAngles = localEulerAngles2;
											Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
											_ = 360f;
											TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_Star1, endValue, 10f);
											if (tweenerCore != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v596 @ rax_v31 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v596 @ rax_v31 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
													if ((nint)0 == 0)
													{
														_ = 4294967295L;
														_ = 2;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v596 @ rax_v31 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
														if ((nint)0 == 0)
														{
															_ = 2139095040;
														}
													}
												}
											}
											_Star1TweenRot = tweenerCore;
											Vector3 endValue2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
											_ = 405f;
											TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(_Star2, endValue2, 7f);
											if (tweenerCore2 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v705 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v705 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
													if ((nint)0 == 0)
													{
														_ = 4294967295L;
														_ = 2;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v705 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
														if ((nint)0 == 0)
														{
															_ = 2139095040;
														}
													}
												}
											}
											_Star2TweenRot = tweenerCore2;
											Vector3 endValue3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
											_ = 2.3f;
											TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(_Star1, endValue3, 0.5f);
											if (tweenerCore3 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
													if ((nint)0 == 0)
													{
														_ = 4294967295L;
														_ = 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
														if ((nint)0 == 0)
														{
															_ = 2139095040;
														}
													}
												}
											}
											_Star1TweenScale = tweenerCore3;
											Vector3 endValue4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
											_ = 2.3f;
											TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOScale(_Star2, endValue4, 0.6f);
											if (tweenerCore4 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v954 @ rax_v37 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v954 @ rax_v37 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
													if ((nint)0 == 0)
													{
														_ = 4294967295L;
														_ = 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v954 @ rax_v37 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
														if ((nint)0 == 0)
														{
															_ = 2139095040;
														}
													}
												}
											}
											_Star2TweenScale = tweenerCore4;
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnDestroy()
	{
		if (_Star1TweenRot != null)
		{
			TweenExtensions.Kill(_Star1TweenRot, complete: true);
		}
		if (_Star2TweenRot != null)
		{
			TweenExtensions.Kill(_Star2TweenRot, complete: true);
		}
		if (_Star1TweenScale != null)
		{
			TweenExtensions.Kill(_Star1TweenScale, complete: true);
		}
		if (_Star2TweenScale != null)
		{
			TweenExtensions.Kill(_Star2TweenScale, complete: true);
		}
	}

	public TreasureReelUI()
	{
		Dictionary<WeaponType, List<WeaponData>> weapons = new Dictionary<WeaponType, List<WeaponData>>();
		_weapons = weapons;
	}

	static TreasureReelUI()
	{
		int reveal = Animator.StringToHash("Reveal");
		Reveal1 = reveal;
	}
}
