using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Loot;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.VFX;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Framework;

public class ArcanaManager_Support
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<Pickup> _003C_003E9__30_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COnGiftLanded_003Eb__30_0(Pickup p)
		{
			if ((object)p != null && ((UnityEngine.Object)p).m_CachedPtr != (IntPtr)0)
			{
				p._003CAutoSafeXY_003Ek__BackingField = true;
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass28_0
	{
		public ArcanaManager_Support _003C_003E4__this;

		public float2 startPosition;

		public float radius;

		public Action _003C_003E9__0;

		internal void _003CSendHailFromTheFutureGift_003Eb__0()
		{
			//IL_0064: Expected O, but got I
			//IL_01a9: Expected O, but got F4
			//IL_01e9: Expected O, but got F4
			//IL_00b3: Invalid comparison between I and F4
			ArcanaManager_Support arcanaManager_Support = _003C_003E4__this;
			List<float> hailFromFutureChances = arcanaManager_Support._hailFromFutureChances;
			int hailFromFutureIndex = arcanaManager_Support._hailFromFutureIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
			int num = (int)((nint)hailFromFutureIndex % (nint)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
			bool flag = (nint)num >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v6 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			ArcanaManager_Support arcanaManager_Support2 = _003C_003E4__this;
			int hailFromFutureIndex2 = arcanaManager_Support2._hailFromFutureIndex + 1;
			arcanaManager_Support2._hailFromFutureIndex = hailFromFutureIndex2;
			object obj2 = UnityEngine.Random.value;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm2,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm2,qword ptr [188A107E0h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm2,qword ptr [188A107E0h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			object obj3 = UnityEngine.Random.value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v12+20+v98 @ rdx_v10 (System.Int32)*4]");
			ItemType itemType;
			if (0f > 0.05f)
			{
				itemType = ItemType.COINBAG1;
			}
			else
			{
				GameManager core = GM.Core;
				ArcanaManager_Support arcanaManager_Support3 = _003C_003E4__this;
				ItemType itemFromExportedTable = core._lootManager.GetItemFromExportedTable(arcanaManager_Support3._003CHailFromTheFutureWeightedStore_003Ek__BackingField);
				itemType = itemFromExportedTable;
			}
			GameManager core2 = GM.Core;
			Vector2 endPosition = default(Vector2);
			WeaponType weaponType = default(WeaponType);
			if (!core2._multiplayer.IsOnlineMultiplayer)
			{
				_003C_003E4__this.SendGift(endPosition, endPosition, itemType, weaponType);
				return;
			}
			Debug.Log("Sending Gift With Timer");
			OnlineStageManager._instance.SendGift(endPosition, endPosition, itemType, weaponType);
		}
	}

	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public ArcanaManager_Support _003C_003E4__this;

		public SpinningIcosahedron gift;

		public ItemType itemType;

		public WeaponType weaponType;

		public Vector2 endPosition;

		internal void _003CSendGift_003Eb__0()
		{
			float x = default(float);
			float y = default(float);
			_003C_003E4__this.OnGiftLanded(gift, itemType, weaponType, x, y);
		}
	}

	private const float goldenRatio = 1.618034f;

	private static int _foodSfxIndex = 0;

	private static float[] _foodDetunes = new float[64]
	{
		0f, 12f, 0f, 12f, -5f, 7f, -2f, 10f, 0f, 12f,
		0f, 12f, -5f, 7f, -2f, 10f, 3f, 15f, 3f, 15f,
		-2f, 10f, 1f, 13f, 3f, 15f, 3f, 15f, -2f, 10f,
		1f, 13f, 5f, 17f, 5f, 17f, 0f, 12f, 3f, 15f,
		5f, 17f, 5f, 17f, 0f, 12f, 3f, 15f, 7f, 19f,
		7f, 19f, 2f, 14f, 5f, 17f, 7f, 19f, 7f, 19f,
		2f, 14f, 5f, 17f
	};

	private List<float> _sapphireMistChances;

	private int _sapphireMistIndex;

	private float _sapphireMistBaseChance;

	private WeightedStore _003CHailFromTheFutureWeightedStore_003Ek__BackingField;

	private float _baseCandyboxChance;

	private float _foundCandyboxes;

	private float _baseArmadioChance;

	private float _foundArmadios;

	private List<float> _hailFromFutureChances;

	private int _hailFromFutureIndex;

	private Dictionary<WeaponType, List<float>> _breadBonusList;

	private Dictionary<WeaponType, int> _bonusTimes;

	private Timer _food_sequentialTimer;

	private float _food_angleInc;

	private float _food_angleMul;

	private float _food_BonusTimer;

	private float _food_BonusDelay;

	private List<VampireSurvivors.Objects.Characters.CharacterController> _food_CharacterBonuses;

	public WeightedStore HailFromTheFutureWeightedStore
	{
		get
		{
			return _003CHailFromTheFutureWeightedStore_003Ek__BackingField;
		}
		set
		{
			_003CHailFromTheFutureWeightedStore_003Ek__BackingField = value;
		}
	}

	private static float GetDetune()
	{
		float[] foodDetunes = _foodDetunes;
		int foodSfxIndex = _foodSfxIndex + 1;
		_foodSfxIndex = foodSfxIndex;
		float[] foodDetunes2 = _foodDetunes;
		int num = _foodSfxIndex % foodDetunes2.Length;
		return foodDetunes[num] * 100f;
	}

	public void Initialize()
	{
		List<float> sapphireMistChances = Weapon.MakeChanceArray(1000);
		_sapphireMistChances = sapphireMistChances;
		_sapphireMistIndex = 0;
		_baseCandyboxChance = 0.05f;
		List<float> hailFromFutureChances = Weapon.MakeChanceArray(1000);
		_hailFromFutureChances = hailFromFutureChances;
		_hailFromFutureIndex = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 140 Invalid \"Jump target not found in method: 0x1877CC3B0\"");
	}

	public void MakeHailFromTheFutureWeightedStore(bool force = false)
	{
		bool flag = _003CHailFromTheFutureWeightedStore_003Ek__BackingField != null;
		bool flag2 = force;
		if (!flag)
		{
			flag2 = true;
		}
		if (flag2)
		{
			GameManager core = GM.Core;
			if (core._lootManager != null)
			{
				ItemType[] items = new ItemType[9]
				{
					ItemType.COINBAGMAX,
					ItemType.ROSARY,
					ItemType.VACUUM,
					ItemType.NFT,
					ItemType.OROLOGION,
					ItemType.GOLDFINGER,
					ItemType.GILDED,
					ItemType.SORBETTO,
					ItemType.PICKUP_REROLL_DICE
				};
				WeightedStore weightedStore = core._lootManager.ExportCustomLootTable(items, ignorePlayerLevel: true);
				_003CHailFromTheFutureWeightedStore_003Ek__BackingField = weightedStore;
			}
		}
	}

	public bool IsSapphireMistSuccessful(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0053: Expected O, but got I
		//IL_00a5: Invalid comparison between F4 and I
		//IL_00cb: Invalid comparison between F4 and I4
		List<float> sapphireMistChances = _sapphireMistChances;
		int sapphireMistIndex = _sapphireMistIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num = (int)((nint)sapphireMistIndex % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			int sapphireMistIndex2 = _sapphireMistIndex + 1;
			_sapphireMistIndex = sapphireMistIndex2;
			float num2 = character.PLuck();
			object obj2 = default(object);
			float num3 = (float)obj2 * _sapphireMistBaseChance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v7+20+v56 @ rdx_v5 (System.Int32)*4]");
			bool flag = num3 < 0f;
			float num4 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v7+20+v56 @ rdx_v5 (System.Int32)*4]");
			float num5 = num4 - 0f;
			bool flag2 = num5 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		bool result = default(bool);
		return result;
	}

	public void SendHailFromTheFutureGift(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_05fe: Expected O, but got F4
		//IL_00ec: Invalid comparison between F4 and O
		//IL_0148: Invalid comparison between F4 and O
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected O, but got Unknown
		//IL_0677: Expected O, but got F4
		//IL_06b7: Expected O, but got F4
		//IL_02e8: Expected O, but got F4
		//IL_0326: Expected O, but got I
		//IL_06da: Expected O, but got I
		//IL_0405: Invalid comparison between F4 and O
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Expected O, but got Unknown
		//IL_0445: Expected F4, but got O
		//IL_074d: Expected O, but got F4
		//IL_04e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ec: Expected O, but got Unknown
		//IL_052b: Expected O, but got I4
		//IL_0534: Expected O, but got I4
		//IL_05b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bc: Expected O, but got Unknown
		//IL_05c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ca: Expected O, but got Unknown
		//IL_05d2: Invalid comparison between F4 and O
		_003C_003Ec__DisplayClass28_0 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass28_0();
		CS_0024_003C_003E8__locals12._003C_003E4__this = this;
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		object obj = UnityEngine.Random.value;
		float num = character.PLuck();
		float num2 = _foundCandyboxes + 1f;
		float num3 = _baseCandyboxChance / num2;
		object obj2 = default(object);
		float num4 = (float)obj2 * num3;
		float num5 = character.PLuck();
		GameManager core = GM.Core;
		ItemType itemFromExportedTable = core._lootManager.GetItemFromExportedTable(_003CHailFromTheFutureWeightedStore_003Ek__BackingField);
		float num6 = _foundArmadios + 1f;
		float num7 = _baseArmadioChance / num6;
		float num8 = num7 * (float)obj2;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num8) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) && !(6f < _foundArmadios))
		{
			float foundArmadios = _foundArmadios + 1f;
			_foundArmadios = foundArmadios;
			goto IL_0603;
		}
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
		ItemType itemType = itemFromExportedTable;
		if (!flag)
		{
			bool flag2 = 6f < _foundCandyboxes;
			itemType = itemFromExportedTable;
			if (!flag2)
			{
				float foundCandyboxes = _foundCandyboxes + 1f;
				_foundCandyboxes = foundCandyboxes;
				goto IL_0603;
			}
		}
		goto IL_0611;
		IL_06f2:
		float num9;
		if (!(num9 > 1f))
		{
			return;
		}
		object obj3 = 1;
		object obj4 = 150;
		bool useRealTime;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		bool canPause;
		do
		{
			Action onComplete = CS_0024_003C_003E8__locals12._003C_003E9__0;
			if (CS_0024_003C_003E8__locals12._003C_003E9__0 == null)
			{
				onComplete = (CS_0024_003C_003E8__locals12._003C_003E9__0 = delegate
				{
					//IL_0064: Expected O, but got I
					//IL_01a9: Expected O, but got F4
					//IL_01e9: Expected O, but got F4
					//IL_00b3: Invalid comparison between I and F4
					ArcanaManager_Support arcanaManager_Support = CS_0024_003C_003E8__locals12._003C_003E4__this;
					List<float> hailFromFutureChances = arcanaManager_Support._hailFromFutureChances;
					int hailFromFutureIndex = arcanaManager_Support._hailFromFutureIndex;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
					int num21 = (int)((nint)hailFromFutureIndex % (nint)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
					bool flag5 = (nint)num21 >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v6 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj13 = 0;
					ArcanaManager_Support arcanaManager_Support2 = CS_0024_003C_003E8__locals12._003C_003E4__this;
					int hailFromFutureIndex2 = arcanaManager_Support2._hailFromFutureIndex + 1;
					arcanaManager_Support2._hailFromFutureIndex = hailFromFutureIndex2;
					object obj14 = UnityEngine.Random.value;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm2,xmm0\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm2,qword ptr [188A107E0h]\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm2,qword ptr [188A107E0h]\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					object obj15 = UnityEngine.Random.value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v12+20+v98 @ rdx_v10 (System.Int32)*4]");
					ItemType itemType3;
					if (0f > 0.05f)
					{
						itemType3 = ItemType.COINBAG1;
					}
					else
					{
						GameManager core4 = GM.Core;
						ArcanaManager_Support arcanaManager_Support3 = CS_0024_003C_003E8__locals12._003C_003E4__this;
						ItemType itemFromExportedTable2 = core4._lootManager.GetItemFromExportedTable(arcanaManager_Support3._003CHailFromTheFutureWeightedStore_003Ek__BackingField);
						itemType3 = itemFromExportedTable2;
					}
					GameManager core5 = GM.Core;
					Vector2 vector5 = default(Vector2);
					WeaponType weaponType2 = default(WeaponType);
					if (!core5._multiplayer.IsOnlineMultiplayer)
					{
						CS_0024_003C_003E8__locals12._003C_003E4__this.SendGift(vector5, vector5, itemType3, weaponType2);
					}
					else
					{
						Debug.Log("Sending Gift With Timer");
						OnlineStageManager._instance.SendGift(vector5, vector5, itemType3, weaponType2);
					}
				});
			}
			float duration = (float)obj4 * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause);
			obj3++;
			obj4 += 150;
		}
		while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num9) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3));
		return;
		IL_0611:
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float num10 = renderer2.height;
		if (!(renderer2.height > renderer.width))
		{
			object obj5 = renderer.width & -2147483649L;
			if ((nint)obj5 <= 2139095040)
			{
				goto IL_062d;
			}
		}
		num10 = renderer.width;
		goto IL_062d;
		IL_0603:
		itemType = ItemType.WEAPON;
		goto IL_0611;
		IL_06df:
		GameManager core2 = GM.Core;
		ArcanaManager arcanaManager = core2._arcanaManager;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
		object obj6 = default(object);
		float num11;
		if (obj6 != null)
		{
			num11 += 3f;
		}
		object obj7 = UnityEngine.Random.value;
		float num13;
		float num12 = num13 * num11;
		if (!(5f > num12))
		{
			object obj8 = num12 & -2147483649L;
			bool flag3 = (nint)obj8 <= 2139095040;
			num9 = 5f;
			if (flag3)
			{
				goto IL_06f2;
			}
		}
		num9 = num12;
		goto IL_06f2;
		IL_062d:
		float radius = num10 * 0.45f;
		CS_0024_003C_003E8__locals12.radius = radius;
		float2 position = character.position;
		CS_0024_003C_003E8__locals12.startPosition = position;
		object obj9 = UnityEngine.Random.value;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm2,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm2,qword ptr [188A107E0h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm2,qword ptr [188A107E0h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		object obj10 = UnityEngine.Random.value;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		float num14 = 0f - 0.5f;
		float num15 = renderer3.height + renderer3.height;
		float num16 = num14 + num14;
		float num17 = num15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v2 (VampireSurvivors.Framework.ArcanaManager_Support+<>c__DisplayClass28_0)+1C]");
		float num18 = num17 + 0f;
		float num19 = num16 + (float)CS_0024_003C_003E8__locals12.startPosition;
		CS_0024_003C_003E8__locals12.startPosition = (float2)num19;
		GameManager core3 = GM.Core;
		Vector2 vector = default(Vector2);
		WeaponType weaponType = default(WeaponType);
		Vector2 vector3;
		if (!core3._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v2 (VampireSurvivors.Framework.ArcanaManager_Support+<>c__DisplayClass28_0)+1C]");
			object obj11 = 0;
			SendGift(vector, vector, itemType, weaponType);
			canPause = false;
			Vector2 vector2 = vector;
			vector3 = vector;
			ItemType itemType2 = itemType;
			Vector2 vector4 = vector;
			useRealTime = (byte)weaponType != 0;
		}
		else
		{
			Debug.Log("Sending Gift Without Timer");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v2 (VampireSurvivors.Framework.ArcanaManager_Support+<>c__DisplayClass28_0)+1C]");
			object obj11 = 0;
			OnlineStageManager._instance.SendGift(vector, vector, itemType, weaponType);
			canPause = false;
			Vector2 vector2 = vector;
			vector3 = vector;
			ItemType itemType2 = itemType;
			Vector2 vector4 = vector;
			useRealTime = (byte)weaponType != 0;
		}
		float num20 = character.PAmount();
		num13 = (float)character._level / 40f;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num13) <= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector3))
		{
			object obj12 = num13 & -2147483649L;
			bool flag4 = (nint)obj12 <= 2139095040;
			num11 = (float)vector3;
			if (flag4)
			{
				goto IL_06df;
			}
		}
		num11 = num13;
		goto IL_06df;
	}

	public unsafe void SendGift(Vector2 startPosition, Vector2 endPosition, ItemType itemType, WeaponType weaponType)
	{
		//IL_0288: Expected I, but got O
		//IL_02ca: Expected I, but got O
		//IL_031c: Expected I, but got O
		//IL_0147: Expected O, but got Ref
		//IL_02e7->IL020d: Incompatible stack heights: 2 vs 0
		//IL_0352->IL020d: Incompatible stack heights: 5 vs 0
		//IL_01d3->IL020d: Incompatible stack heights: 5 vs 0
		_003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals16 = new _003C_003Ec__DisplayClass29_0();
		if (CS_0024_003C_003E8__locals16 != null)
		{
			CS_0024_003C_003E8__locals16._003C_003E4__this = this;
			CS_0024_003C_003E8__locals16.endPosition = endPosition;
			CS_0024_003C_003E8__locals16.itemType = itemType;
			WeaponType weaponType2 = default(WeaponType);
			CS_0024_003C_003E8__locals16.weaponType = weaponType2;
			if ((object)HeroVfxManager._factory != null)
			{
				ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.SpinningIcosahedron);
				if ((object)pool != null)
				{
					SpinningIcosahedron objectComponent = pool.GetObjectComponent<SpinningIcosahedron>();
					CS_0024_003C_003E8__locals16.gift = objectComponent;
					SpinningIcosahedron gift = CS_0024_003C_003E8__locals16.gift;
					if ((object)CS_0024_003C_003E8__locals16.gift != null)
					{
						ArcanaManager_Support trailRendererTransform = (ArcanaManager_Support)(object)gift._trailRendererTransform;
						bool flag = trailRendererTransform._sapphireMistChances == null;
						Vector3 value = default(Vector3);
						Transform.set_localScale_Injected((IntPtr)trailRendererTransform._sapphireMistChances, ref value);
						ArcanaManager_Support icosahedronTransform = (ArcanaManager_Support)(object)gift._icosahedronTransform;
						bool flag2 = icosahedronTransform._sapphireMistChances == null;
						Vector3 value2 = default(Vector3);
						Transform.set_localScale_Injected((IntPtr)icosahedronTransform._sapphireMistChances, ref value2);
						if ((object)CS_0024_003C_003E8__locals16.gift != null)
						{
							Transform transform = CS_0024_003C_003E8__locals16.gift.transform;
							bool flag3 = (object)transform == null;
							bool flag4 = ((ArcanaManager_Support)(object)transform)._sapphireMistChances == null;
							Transform.set_position_Injected((IntPtr)((ArcanaManager_Support)(object)transform)._sapphireMistChances, ref value2);
							bool flag5 = (object)CS_0024_003C_003E8__locals16.gift == null;
							Transform transform2 = CS_0024_003C_003E8__locals16.gift.transform;
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMove(transform2, (Vector3)(&value), 2f);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if (tweenerCore != null)
							{
								TweenCallback tweenCallback = delegate
								{
									float x = default(float);
									float y = default(float);
									CS_0024_003C_003E8__locals16._003C_003E4__this.OnGiftLanded(CS_0024_003C_003E8__locals16.gift, CS_0024_003C_003E8__locals16.itemType, CS_0024_003C_003E8__locals16.weaponType, x, y);
								};
								GameManager core = GM.Core;
								if ((object)GM.Core != null)
								{
									if (core._isPaused)
									{
										Tween tween = TweenExtensions.Pause((Tween)tweenerCore);
									}
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnGiftLanded(SpinningIcosahedron gift, ItemType itemToSpawn, WeaponType weaponType, float x, float y)
	{
		//IL_010b: Expected I, but got O
		//IL_0113: Expected I, but got O
		//IL_0123: Expected O, but got I
		//IL_015f: Expected O, but got I
		//IL_019c: Expected O, but got I
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_02ec: Expected I, but got O
		//IL_02f4: Expected I, but got O
		//IL_0304: Expected O, but got I
		//IL_01ef: Expected O, but got I
		//IL_022c: Expected O, but got I
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		gift.ShrinkAndRecycle();
		GameManager core = GM.Core;
		float x2 = default(float);
		float y2 = default(float);
		core._gizmoManager.ShowHighlightAt(x2, y2);
		Vector2 pos = default(Vector2);
		if (itemToSpawn != ItemType.COINBAG1)
		{
			if (itemToSpawn == ItemType.COIN)
			{
				goto IL_026f;
			}
			float value = default(float);
			ItemType relicType = default(ItemType);
			bool validatePickups = default(bool);
			Pickup pickup = GM.Core.MakeStagePickup(pos, itemToSpawn, weaponType, value, relicType, validatePickups);
			if ((object)pickup == null || ((UnityEngine.Object)pickup).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			if (itemToSpawn != ItemType.WEAPON)
			{
				pickup._003CAutoSafeXY_003Ek__BackingField = true;
				return;
			}
			nint num = (nint)typeof(PickupWeapon);
			nint num2 = (nint)pickup;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v33+FFFFFFF8+v118 @ rax_v32*8]");
				if (0 == (nint)typeof(PickupWeapon))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v33+FFFFFFF8+v628 @ rcx_v29*8]");
					object obj4 = 0 - typeof(PickupWeapon);
					bool flag = obj4 == null;
					bool flag2 = !flag;
					Pickup pickup2 = null;
					if (flag2)
					{
						_ = 0;
						nint num4 = (nint)typeof(PickupWeapon);
						nint num5 = (nint)pickup;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
						if (num6 < 0)
						{
							goto IL_02ae;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v36+FFFFFFF8+v122 @ rax_v35*8]");
					if (0 == (nint)typeof(PickupWeapon))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v36+FFFFFFF8+v510 @ rcx_v33*8]");
						object obj8 = 0 - typeof(PickupWeapon);
						bool flag3 = obj8 == null;
						bool flag4 = !flag3;
						Pickup pickup3 = null;
						if (flag4)
						{
							_ = 1;
							return;
						}
						goto IL_026f;
					}
				}
			}
			goto IL_02ae;
		}
		Action<Pickup> callback = _003C_003Ec._003C_003E9__30_0;
		if (_003C_003Ec._003C_003E9__30_0 == null)
		{
			callback = (_003C_003Ec._003C_003E9__30_0 = delegate(Pickup p)
			{
				if ((object)p != null && ((UnityEngine.Object)p).m_CachedPtr != (IntPtr)0)
				{
					p._003CAutoSafeXY_003Ek__BackingField = true;
				}
			});
		}
		GM.Core.MakeRedCoinBag(pos, 0f, callback);
		return;
		IL_026f:
		GM.Core.MakeCoin(pos);
		return;
		IL_02ae:
		throw new NullReferenceException();
	}

	public void OnFoodPickedUp(VampireSurvivors.Objects.Characters.CharacterController character, ItemType itemType, float value)
	{
		//IL_00ae: Expected O, but got I4
		//IL_0280: Expected O, but got I4
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		object obj;
		bool flag;
		if (itemType != ItemType.ROAST && itemType != ItemType.TP_WALL_CHICKEN)
		{
			if (itemType == ItemType.NFT || itemType == ItemType.SORBETTO)
			{
				obj = 0;
				flag = true;
				goto IL_0178;
			}
			float value2 = UnityEngine.Random.value;
			float num = character.PLuck();
			float num2 = value2 * 0.2f;
			bool flag2 = num2 < value2;
			flag = !flag2;
		}
		else
		{
			float num3 = character.PRegen();
			GameManager gameManager = character._gameManager;
			float num2 = default(float);
			float num4 = num2 + 1f;
			float num5 = num4 * value;
			ArcanaManager arcanaManager = gameManager._arcanaManager;
			List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj2 = default(object);
				if ((nint)obj2 != -1)
				{
					num2 = num5 + num5;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm6\"");
			bool flag3 = itemType < ItemType.COINBAGMAX;
			flag = (byte)itemType != 0;
			if (!flag3)
			{
				flag = true;
			}
		}
		bool flag4 = (flag ? 1 : 0) <= (false ? 1 : 0);
		obj = 0;
		if (flag4)
		{
			return;
		}
		goto IL_0178;
		IL_0178:
		do
		{
			List<object> food_CharacterBonuses = (List<object>)(object)_food_CharacterBonuses;
			int version = food_CharacterBonuses._version + 1;
			food_CharacterBonuses._version = version;
			object[] items = food_CharacterBonuses._items;
			if (food_CharacterBonuses._size >= items.Length)
			{
				food_CharacterBonuses.AddWithResize((object)character);
			}
			else
			{
				int size = food_CharacterBonuses._size + 1;
				food_CharacterBonuses._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			obj++;
		}
		while ((nint)obj < (flag ? 1 : 0));
	}

	public unsafe void Update()
	{
		//IL_0149: Expected O, but got I
		//IL_041d: Expected I4, but got O
		//IL_0421: Expected O, but got I4
		//IL_01b8: Expected O, but got I
		//IL_01e1: Expected F4, but got I
		//IL_046a: Expected O, but got I4
		//IL_0319: Expected F4, but got I
		//IL_036e: Expected O, but got F4
		//IL_036e: Expected O, but got Ref
		//IL_0388->IL0388: Incompatible stack heights: 2 vs 0
		List<VampireSurvivors.Objects.Characters.CharacterController> food_CharacterBonuses = _food_CharacterBonuses;
		if (food_CharacterBonuses._size > 0)
		{
			float num = 200f - (float)food_CharacterBonuses._size;
			bool flag = !(8f < num);
			float food_BonusDelay = 8f;
			if (!flag)
			{
				food_BonusDelay = num;
			}
			_food_BonusDelay = food_BonusDelay;
			float deltaTime = PauseSystem.DeltaTime;
			float num2 = deltaTime * 1000f;
			if (!((_food_BonusTimer = num2 + _food_BonusTimer) < _food_BonusDelay))
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> food_CharacterBonuses2 = _food_CharacterBonuses;
				_food_BonusTimer = 0f;
				bool flag2 = food_CharacterBonuses2._size <= 0;
				VampireSurvivors.Objects.Characters.CharacterController[] items = food_CharacterBonuses2._items;
				float num3 = _food_angleInc / (float)Math.PI;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
				float num4 = _food_angleMul * _food_angleInc;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float num5 = _food_angleMul * _food_angleInc;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Dictionary<WeaponType, List<float>> breadBonusList = _breadBonusList;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rbp_v7 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.WeaponType, System.Collections.Generic.List`1<System.Single>>)+20]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rbp_v7 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.WeaponType, System.Collections.Generic.List`1<System.Single>>)+28]");
				object obj = num6 - 0;
				object obj2 = UnityEngine.Random.RandomRangeInt(0, (int)obj);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FF0DA0");
				WeaponType weaponType = default(WeaponType);
				int num7 = _bonusTimes.get_Item(weaponType);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ stack_-70+18]");
				int num8 = (int)(-1);
				if (num7 < num8)
				{
					num8 = num7;
				}
				int num9 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ stack_-70+18]");
				bool flag3 = (nint)num9 >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ stack_-70+10]");
				object obj3 = 0;
				VampireSurvivors.Objects.Characters.CharacterController character = items[0];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r8_v8+20+v212 @ rcx_v19 (System.Int32)*4]");
				AddAttribute(character, weaponType, 0f);
				int num10 = _bonusTimes.get_Item(weaponType);
				int value = num10 + 1;
				bool flag4 = ((Dictionary<System.Int32Enum, int>)(object)_bonusTimes).TryInsert((System.Int32Enum)weaponType, value, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
				if ((_food_angleInc += 0.12f) > 12f)
				{
					float food_angleMul = _food_angleMul * -1f;
					_food_angleInc = 0f;
					_food_angleMul = food_angleMul;
				}
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
				{
					Volume = (float?)(object)1,
					Rate = 2f
				};
				float[] foodDetunes = _foodDetunes;
				int foodSfxIndex = _foodSfxIndex + 1;
				_foodSfxIndex = foodSfxIndex;
				float[] foodDetunes2 = _foodDetunes;
				int num11 = _foodSfxIndex % foodDetunes2.Length;
				float detune = foodDetunes[num11] * 100f;
				soundConfig.Detune = detune;
				float num12 = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Roast, soundConfig, 200f, 5, num12);
				GameManager core = GM.Core;
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r8_v8+20+v212 @ rcx_v19 (System.Int32)*4]");
				string value2 = System.Number.FormatSingle(0f, null, currentInfo);
				Color coopColour = items[0].GetCoopColour();
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
				object obj4 = default(object);
				float displayTimeMultiplier = default(float);
				Vector2 vOffset = default(Vector2);
				core._gizmoManager.DisplayWeaponIconOverhead(weaponType, value2, (Color?)(object)(&obj4), (VampireSurvivors.Objects.Characters.CharacterController)num12, displayTimeMultiplier, vOffset);
				_food_CharacterBonuses.RemoveAt(0);
			}
		}
		else
		{
			_food_angleMul = 1f;
			_food_angleInc = 0f;
		}
	}

	private void AddAttribute(VampireSurvivors.Objects.Characters.CharacterController character, WeaponType weaponType, float value)
	{
		//IL_000e: Expected O, but got I4
		//IL_0038: Expected O, but got I8
		//IL_0052: Expected O, but got I8
		object obj = weaponType + -50;
		if ((nint)obj <= 16)
		{
			object obj2 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rdx_v1+734EC0C+v2 @ r8_v1*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v24 @ rcx_v2 (should have been resolved before IL gen)");
		}
	}

	public ArcanaManager_Support()
	{
		//IL_0036: Expected O, but got I
		//IL_0090: Expected O, but got I
		//IL_138c: Expected O, but got I
		//IL_00fa: Expected O, but got I
		//IL_13b4: Expected O, but got I
		//IL_0164: Expected O, but got I
		//IL_01cb: Expected O, but got I
		//IL_0225: Expected O, but got I
		//IL_13dc: Expected O, but got I
		//IL_028f: Expected O, but got I
		//IL_1404: Expected O, but got I
		//IL_02f9: Expected O, but got I
		//IL_0331: Expected O, but got I
		//IL_038b: Expected O, but got I
		//IL_1456: Expected O, but got I
		//IL_03f5: Expected O, but got I
		//IL_147e: Expected O, but got I
		//IL_045f: Expected O, but got I
		//IL_0497: Expected O, but got I
		//IL_04f1: Expected O, but got I
		//IL_14d0: Expected O, but got I
		//IL_055b: Expected O, but got I
		//IL_14f8: Expected O, but got I
		//IL_05c5: Expected O, but got I
		//IL_05fd: Expected O, but got I
		//IL_0657: Expected O, but got I
		//IL_154a: Expected O, but got I
		//IL_06c1: Expected O, but got I
		//IL_1572: Expected O, but got I
		//IL_072b: Expected O, but got I
		//IL_0763: Expected O, but got I
		//IL_07bd: Expected O, but got I
		//IL_07f5: Expected O, but got I
		//IL_084f: Expected O, but got I
		//IL_15ee: Expected O, but got I
		//IL_08bd: Expected O, but got I
		//IL_1616: Expected O, but got I
		//IL_092b: Expected O, but got I
		//IL_0967: Expected O, but got I
		//IL_09c1: Expected O, but got I
		//IL_1668: Expected O, but got I
		//IL_0a2b: Expected O, but got I
		//IL_1690: Expected O, but got I
		//IL_0a95: Expected O, but got I
		//IL_0acd: Expected O, but got I
		//IL_0b27: Expected O, but got I
		//IL_16e2: Expected O, but got I
		//IL_0b91: Expected O, but got I
		//IL_170a: Expected O, but got I
		//IL_0bfb: Expected O, but got I
		//IL_0c33: Expected O, but got I
		//IL_0c8d: Expected O, but got I
		//IL_175c: Expected O, but got I
		//IL_0cf7: Expected O, but got I
		//IL_1784: Expected O, but got I
		//IL_0d61: Expected O, but got I
		//IL_0d99: Expected O, but got I
		//IL_0df3: Expected O, but got I
		//IL_17d6: Expected O, but got I
		//IL_0e5d: Expected O, but got I
		//IL_17fe: Expected O, but got I
		//IL_0ec7: Expected O, but got I
		//IL_0eff: Expected O, but got I
		//IL_0f59: Expected O, but got I
		_sapphireMistBaseChance = 0.28f;
		_baseCandyboxChance = 0.025f;
		_baseArmadioChance = 0.025f;
		Dictionary<WeaponType, List<float>> dictionary = new Dictionary<WeaponType, List<float>>();
		List<float> list = new List<float>();
		list._002Ector();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v8+18]");
		if (num >= 0)
		{
			list.AddWithResize(0.5f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1056964608;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rcx_v10+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rcx_v12+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(0.01f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1008981770;
		}
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)65, (object)list, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		List<float> list2 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rcx_v19+18]");
		if (num4 >= 0)
		{
			list2.AddWithResize(1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1065353216;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdx_v11+18]");
		if (num5 >= 0)
		{
			list2.AddWithResize(0.5f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1056964608;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rcx_v23+18]");
		if (num6 >= 0)
		{
			list2.AddWithResize(0.05f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1028443341;
		}
		bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)57, (object)list2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		List<float> list3 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rdx_v15+18]");
		if (num7 >= 0)
		{
			list3.AddWithResize(50f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1112014848;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rdx_v16+18]");
		if (num8 >= 0)
		{
			list3.AddWithResize(25f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1103626240;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rdx_v17+18]");
		if (num9 >= 0)
		{
			list3.AddWithResize(1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 1065353216;
		}
		bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)56, (object)list3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		List<float> list4 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v35 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v35 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v35 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rdx_v20+18]");
		if (num10 >= 0)
		{
			list4.AddWithResize(1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v35 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 1065353216;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v35 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v35 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v35 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rdx_v21+18]");
		if (num11 >= 0)
		{
			list4.AddWithResize(0.25f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v35 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 1048576000;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v35 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v35 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v35 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rdx_v22+18]");
		if (num12 >= 0)
		{
			list4.AddWithResize(0.05f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v35 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 1028443341;
		}
		bool flag4 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)55, (object)list4, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		List<float> list5 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1771 @ rax_v44 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1771 @ rax_v44 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1771 @ rax_v44 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rdx_v25+18]");
		if (num13 >= 0)
		{
			list5.AddWithResize(1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1771 @ rax_v44 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 1065353216;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1771 @ rax_v44 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1771 @ rax_v44 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1771 @ rax_v44 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rdx_v26+18]");
		if (num14 >= 0)
		{
			list5.AddWithResize(0.5f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1771 @ rax_v44 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 1056964608;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1771 @ rax_v44 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1771 @ rax_v44 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1771 @ rax_v44 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rdx_v27+18]");
		if (num15 >= 0)
		{
			list5.AddWithResize(0.05f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1771 @ rax_v44 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 1028443341;
		}
		bool flag5 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)63, (object)list5, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		List<float> list6 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1871 @ rax_v53 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1871 @ rax_v53 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1871 @ rax_v53 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rdx_v30+18]");
		if (num16 >= 0)
		{
			list6.AddWithResize(0.5f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1871 @ rax_v53 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 1056964608;
		}
		bool flag6 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)59, (object)list6, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		List<float> list7 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1911 @ rax_v60 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1911 @ rax_v60 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1911 @ rax_v60 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rdx_v33+18]");
		if (num17 >= 0)
		{
			list7.AddWithResize(-0.05f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1911 @ rax_v60 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj34 = (nint)0 + (nint)1;
			_ = 3175926989L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1911 @ rax_v60 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1911 @ rax_v60 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1911 @ rax_v60 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rdx_v34+18]");
		if (num18 >= 0)
		{
			list7.AddWithResize(-0.02f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1911 @ rax_v60 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj36 = (nint)0 + (nint)1;
			_ = 3164854026L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1911 @ rax_v60 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1911 @ rax_v60 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1911 @ rax_v60 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rdx_v35+18]");
		if (num19 >= 0)
		{
			list7.AddWithResize(-0.01f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1911 @ rax_v60 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj38 = (nint)0 + (nint)1;
			_ = 3156465418L;
		}
		bool flag7 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)53, (object)list7, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		List<float> list8 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v69 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v69 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v69 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rcx_v81+18]");
		if (num20 >= 0)
		{
			list8.AddWithResize(0.2f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v69 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj40 = (nint)0 + (nint)1;
			_ = 1045220557;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v69 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v69 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v69 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rdx_v39+18]");
		if (num21 >= 0)
		{
			list8.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v69 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj42 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v69 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v69 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v69 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rdx_v40+18]");
		if (num22 >= 0)
		{
			list8.AddWithResize(0.01f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2011 @ rax_v69 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj44 = (nint)0 + (nint)1;
			_ = 1008981770;
		}
		bool flag8 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)58, (object)list8, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		List<float> list9 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2111 @ rax_v78 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2111 @ rax_v78 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2111 @ rax_v78 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rdx_v43+18]");
		if (num23 >= 0)
		{
			list9.AddWithResize(0.2f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2111 @ rax_v78 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj46 = (nint)0 + (nint)1;
			_ = 1045220557;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2111 @ rax_v78 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2111 @ rax_v78 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2111 @ rax_v78 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rdx_v44+18]");
		if (num24 >= 0)
		{
			list9.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2111 @ rax_v78 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj48 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2111 @ rax_v78 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2111 @ rax_v78 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2111 @ rax_v78 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rdx_v45+18]");
		if (num25 >= 0)
		{
			list9.AddWithResize(0.01f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2111 @ rax_v78 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj50 = (nint)0 + (nint)1;
			_ = 1008981770;
		}
		bool flag9 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)61, (object)list9, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		List<float> list10 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2211 @ rax_v87 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2211 @ rax_v87 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj51 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2211 @ rax_v87 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rdx_v48+18]");
		if (num26 >= 0)
		{
			list10.AddWithResize(0.2f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2211 @ rax_v87 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj52 = (nint)0 + (nint)1;
			_ = 1045220557;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2211 @ rax_v87 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2211 @ rax_v87 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj53 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2211 @ rax_v87 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rdx_v49+18]");
		if (num27 >= 0)
		{
			list10.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2211 @ rax_v87 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj54 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2211 @ rax_v87 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2211 @ rax_v87 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj55 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2211 @ rax_v87 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rdx_v50+18]");
		if (num28 >= 0)
		{
			list10.AddWithResize(0.01f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2211 @ rax_v87 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj56 = (nint)0 + (nint)1;
			_ = 1008981770;
		}
		bool flag10 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)60, (object)list10, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		List<float> list11 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2311 @ rax_v96 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2311 @ rax_v96 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj57 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2311 @ rax_v96 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rdx_v53+18]");
		if (num29 >= 0)
		{
			list11.AddWithResize(0.2f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2311 @ rax_v96 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj58 = (nint)0 + (nint)1;
			_ = 1045220557;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2311 @ rax_v96 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2311 @ rax_v96 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj59 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2311 @ rax_v96 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num30 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ rdx_v54+18]");
		if (num30 >= 0)
		{
			list11.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2311 @ rax_v96 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj60 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2311 @ rax_v96 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2311 @ rax_v96 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj61 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2311 @ rax_v96 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rdx_v55+18]");
		if (num31 >= 0)
		{
			list11.AddWithResize(0.01f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2311 @ rax_v96 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj62 = (nint)0 + (nint)1;
			_ = 1008981770;
		}
		bool flag11 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)66, (object)list11, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		List<float> list12 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2411 @ rax_v105 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2411 @ rax_v105 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj63 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2411 @ rax_v105 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rdx_v58+18]");
		if (num32 >= 0)
		{
			list12.AddWithResize(0.2f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2411 @ rax_v105 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj64 = (nint)0 + (nint)1;
			_ = 1045220557;
		}
		list12.Add(0.1f);
		list12.Add(0.01f);
		bool flag12 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)62, (object)list12, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag13 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)50, (object)new List<float> { 0.2f, 0.1f, 0.01f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag14 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)52, (object)new List<float> { 0.2f, 0.1f, 0.01f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag15 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)54, (object)new List<float> { 0.2f, 0.1f, 0.01f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag16 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)51, (object)new List<float> { 0.2f, 0.1f, 0.01f }, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		_breadBonusList = dictionary;
		Dictionary<WeaponType, int> dictionary2 = new Dictionary<WeaponType, int>();
		bool flag17 = ((Dictionary<System.Int32Enum, int>)(object)dictionary2).TryInsert((System.Int32Enum)65, 0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag18 = ((Dictionary<System.Int32Enum, int>)(object)dictionary2).TryInsert((System.Int32Enum)57, 0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag19 = ((Dictionary<System.Int32Enum, int>)(object)dictionary2).TryInsert((System.Int32Enum)56, 0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag20 = ((Dictionary<System.Int32Enum, int>)(object)dictionary2).TryInsert((System.Int32Enum)55, 0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag21 = ((Dictionary<System.Int32Enum, int>)(object)dictionary2).TryInsert((System.Int32Enum)63, 0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag22 = ((Dictionary<System.Int32Enum, int>)(object)dictionary2).TryInsert((System.Int32Enum)59, 0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag23 = ((Dictionary<System.Int32Enum, int>)(object)dictionary2).TryInsert((System.Int32Enum)53, 0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag24 = ((Dictionary<System.Int32Enum, int>)(object)dictionary2).TryInsert((System.Int32Enum)58, 0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag25 = ((Dictionary<System.Int32Enum, int>)(object)dictionary2).TryInsert((System.Int32Enum)61, 0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag26 = ((Dictionary<System.Int32Enum, int>)(object)dictionary2).TryInsert((System.Int32Enum)60, 0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag27 = ((Dictionary<System.Int32Enum, int>)(object)dictionary2).TryInsert((System.Int32Enum)66, 0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag28 = ((Dictionary<System.Int32Enum, int>)(object)dictionary2).TryInsert((System.Int32Enum)62, 0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag29 = ((Dictionary<System.Int32Enum, int>)(object)dictionary2).TryInsert((System.Int32Enum)50, 0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag30 = ((Dictionary<System.Int32Enum, int>)(object)dictionary2).TryInsert((System.Int32Enum)52, 0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag31 = ((Dictionary<System.Int32Enum, int>)(object)dictionary2).TryInsert((System.Int32Enum)54, 0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag32 = ((Dictionary<System.Int32Enum, int>)(object)dictionary2).TryInsert((System.Int32Enum)51, 0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		_bonusTimes = dictionary2;
		_food_angleMul = 1f;
		_food_BonusDelay = 200f;
		List<VampireSurvivors.Objects.Characters.CharacterController> food_CharacterBonuses = new List<VampireSurvivors.Objects.Characters.CharacterController>();
		_food_CharacterBonuses = food_CharacterBonuses;
	}
}
