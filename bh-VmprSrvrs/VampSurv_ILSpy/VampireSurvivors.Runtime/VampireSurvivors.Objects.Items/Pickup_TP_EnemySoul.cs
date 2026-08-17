using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Items;

public class Pickup_TP_EnemySoul : Pickup
{
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public float t;

		public Pickup_TP_EnemySoul _003C_003E4__this;

		public Vector2 v;

		public float turns;

		internal float _003CStartSpiralToPlayer_003Eb__0()
		{
			return t;
		}

		internal void _003CStartSpiralToPlayer_003Eb__1(float x)
		{
			t = x;
		}

		internal unsafe void _003CStartSpiralToPlayer_003Eb__2()
		{
			//IL_0008: Expected O, but got Ref
			//IL_019e: Expected I, but got O
			//IL_004e: Expected O, but got I
			//IL_005c: Expected O, but got Ref
			//IL_00cb: Invalid comparison between I4 and F4
			//IL_0116: Expected F4, but got I4
			//IL_0132: Expected I, but got O
			//IL_0226: Invalid comparison between F4 and I4
			//IL_0248: Expected I, but got F4
			object obj2 = default(object);
			object obj = (object)(&obj2);
			Transform transform = _003C_003E4__this.transform;
			nint num = (nint)typeof(Vector2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rcx_v21 (Il2CppClass<UnityEngine.Vector2>)+B8]");
			nint num2 = 0;
			float num3 = t;
			object obj3 = v - Vector2.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Items.Pickup_TP_EnemySoul+<>c__DisplayClass16_0)+24]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v16 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
			object obj4 = num4 - 0;
			object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			float num5 = turns * (float)Math.PI;
			float num6 = num5 + num5;
			float num7 = num6 * t;
			float num8 = num7 + (float)obj4;
			if (!(0f > t))
			{
				if (num3 > 1f)
				{
					num3 = 1f;
				}
			}
			else
			{
				num3 = 0f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			GameManager core = GM.Core;
			nint num9 = (nint)core._pickupVfx;
			_ = 0;
			_ = 0;
			Transform transform2 = _003C_003E4__this.transform;
			bool flag2 = ((_003C_003Ec__DisplayClass16_0)(object)transform2).t == 0f;
			Transform.get_position_Injected((IntPtr)((_003C_003Ec__DisplayClass16_0)(object)transform2).t, out Vector3 _);
			_ = 0;
			_ = 1;
			_ = 1;
			bool flag3 = (object)core._pickupVfx == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+50]");
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rdi_v11 (System.IntPtr)+10]");
			bool flag4 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rdi_v11 (System.IntPtr)+10]");
			ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
			ParticleSystem.Emit_Injected((IntPtr)0, ref emitParams, 1);
		}

		internal void _003CStartSpiralToPlayer_003Eb__3()
		{
			Pickup_TP_EnemySoul pickup_TP_EnemySoul = _003C_003E4__this;
			if ((object)_003C_003E4__this != null)
			{
				pickup_TP_EnemySoul.IsInLavatrix = false;
				if ((object)_003C_003E4__this != null)
				{
					Transform transform = _003C_003E4__this.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 73 ConditionalJump @-1, v128 @ ZF_v8 (System.Boolean) --- -1 Nop");
						/*Error: End of method reached without returning.*/;
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CStartSpiralToPlayer_003Eb__4()
		{
			Pickup_TP_EnemySoul pickup_TP_EnemySoul = _003C_003E4__this;
			if ((object)_003C_003E4__this != null)
			{
				pickup_TP_EnemySoul.IsInLavatrix = false;
				if ((object)_003C_003E4__this != null)
				{
					Transform transform = _003C_003E4__this.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 73 ConditionalJump @-1, v128 @ ZF_v8 (System.Boolean) --- -1 Nop");
						/*Error: End of method reached without returning.*/;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private TP_Soma_Character character;

	private int[] soulTypes = new int[3] { 0, 1, 2 };

	private string[] soulNames;

	private int _soulType;

	private bool _isUnset;

	public float _Volume;

	private static float[] _detuneValues = new float[64]
	{
		0f, 12f, 0f, 12f, -5f, 7f, -2f, 10f, 0f, 12f,
		0f, 12f, -5f, 7f, -2f, 10f, 3f, 15f, 3f, 15f,
		-2f, 10f, 1f, 13f, 3f, 15f, 3f, 15f, -2f, 10f,
		1f, 13f, 5f, 17f, 5f, 17f, 0f, 12f, 3f, 15f,
		5f, 17f, 5f, 17f, 0f, 12f, 3f, 15f, 7f, 19f,
		7f, 19f, 2f, 14f, 5f, 17f, 7f, 19f, 7f, 19f,
		2f, 14f, 5f, 17f
	};

	private static int _sfxIndex = 0;

	protected float _MaxHpVal;

	protected float _MightVal;

	protected float _GreedVal;

	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		_isUnset = true;
	}

	private static float GetDetune()
	{
		float[] detuneValues = _detuneValues;
		int sfxIndex = _sfxIndex + 1;
		_sfxIndex = sfxIndex;
		float[] detuneValues2 = _detuneValues;
		int num = _sfxIndex % detuneValues2.Length;
		return detuneValues[num] * -100f;
	}

	public override void SetData(ItemType itemType)
	{
		base.SetData(itemType);
		OnRecycle();
	}

	protected virtual void OnRecycle()
	{
		//IL_022b: Expected O, but got I4
		if (_isUnset)
		{
			_isUnset = false;
			_spriteAnimation.CleanAnimations();
			string[] array = soulNames;
			int num = default(int);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(array[0], 1, 4, "ThosePeople", num);
			string[] array2 = soulNames;
			List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames(array2[1], 1, 4, "ThosePeople", num);
			string[] array3 = soulNames;
			List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames(array3[2], 1, 4, "ThosePeople", num);
			string[] array4 = soulNames;
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			_spriteAnimation.AddAnimation(array4[0], animationFrames, 24, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			string[] array5 = soulNames;
			_spriteAnimation.AddAnimation(array5[1], animationFrames2, 24, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			string[] array6 = soulNames;
			_spriteAnimation.AddAnimation(array6[2], animationFrames3, 24, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		}
		int[] array7 = soulTypes;
		object obj = UnityEngine.Random.RandomRangeInt(0, array7.Length);
		int num2 = array7[obj];
		string[] array8 = soulNames;
		_soulType = array7[obj];
		_spriteAnimation.SetAnimation(array8[num2]);
	}

	public unsafe override void GetTaken()
	{
		//IL_0008: Expected O, but got Ref
		//IL_012b: Expected O, but got I4
		//IL_0554: Expected O, but got F4
		//IL_0086: Expected F4, but got I
		//IL_00d2: Expected F4, but got I
		//IL_037b: Expected O, but got I
		//IL_0299: Expected O, but got I
		//IL_05c2: Expected O, but got Ref
		//IL_05f7: Expected O, but got I4
		//IL_05f7: Expected O, but got F4
		//IL_0635: Expected O, but got I
		//IL_03f9: Expected F4, but got O
		//IL_01de: Expected O, but got I
		//IL_075b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0760: Expected Ref, but got Unknown
		//IL_0769: Unknown result type (might be due to invalid IL or missing references)
		//IL_076e: Expected Ref, but got Unknown
		//IL_0777: Unknown result type (might be due to invalid IL or missing references)
		//IL_077c: Expected Ref, but got Unknown
		//IL_043b: Expected O, but got I4
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e4: Expected Ref, but got Unknown
		//IL_06ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f2: Expected Ref, but got Unknown
		//IL_06fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0700: Expected Ref, but got Unknown
		//IL_0663: Unknown result type (might be due to invalid IL or missing references)
		//IL_0668: Expected Ref, but got Unknown
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_0676: Expected Ref, but got Unknown
		//IL_067f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0684: Expected Ref, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (base._003CDisableGet_003Ek__BackingField)
		{
			return;
		}
		float? num = default(float?);
		float num2 = default(float);
		float num3 = default(float);
		bool flag = default(bool);
		if (!(base._003CValue_003Ek__BackingField < 1f))
		{
			_targetPlayer.RecoverHp(1f, showRecovery: true, mulByRegen: true);
			object obj3 = UnityEngine.Random.value;
			_ = 0;
			_ = _Volume;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Recovery, 200f, 3, 0f, num, num2, num3, flag);
			_ = 0;
			_ = _Volume;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
			PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Recovery, 200f, 3, 0f, num, num2, num3, flag);
		}
		base.SetHasSeenItem();
		bool flag2 = !(1f < base._003CValue_003Ek__BackingField);
		float num4 = 1f;
		if (!flag2)
		{
			num4 = base._003CValue_003Ek__BackingField;
		}
		float num5 = num4 * _MightVal;
		base.GetTaken();
		base.SetHasSeenItem();
		base.AddToRunPickups();
		base.GetTaken();
		bool flag3 = _soulType == 0;
		if (flag3)
		{
			goto IL_02e0;
		}
		object obj4 = _soulType - 1;
		GizmoManager gizmoManager;
		string frameName;
		VampireSurvivors.Objects.Characters.CharacterController characterController;
		object obj5;
		if (!flag3)
		{
			if ((nint)obj4 != 1)
			{
				goto IL_02e0;
			}
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
			PlayerModifierStats playerStats = targetPlayer._playerStats;
			float num6 = _GreedVal * num4;
			EggFloat greed = playerStats._003CGreed_003Ek__BackingField + num6;
			playerStats.Greed = greed;
			GameManager core = GM.Core;
			gizmoManager = core._gizmoManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			obj5 = 0;
			_ = 0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
			_ = 0;
			frameName = "Mask";
			characterController = (VampireSurvivors.Objects.Characters.CharacterController)num;
		}
		else
		{
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer2 = _targetPlayer;
			PlayerModifierStats playerStats2 = targetPlayer2._playerStats;
			EggFloat power = playerStats2._003CPower_003Ek__BackingField + num5;
			playerStats2.Power = power;
			GameManager core2 = GM.Core;
			gizmoManager = core2._gizmoManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			obj5 = 0;
			_ = 0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
			_ = 0;
			frameName = "Leaf";
			characterController = (VampireSurvivors.Objects.Characters.CharacterController)num;
		}
		goto IL_05b4;
		IL_07ae:
		TP_Soma_Character tP_Soma_Character;
		WeaponType weapon;
		string selectionType;
		tP_Soma_Character.QueueWeaponSelectionSelector(weapon, selectionType);
		return;
		IL_02e0:
		VampireSurvivors.Objects.Characters.CharacterController targetPlayer3 = _targetPlayer;
		PlayerModifierStats playerStats3 = targetPlayer3._playerStats;
		EggFloat eggFloat = playerStats3._003CGrowth_003Ek__BackingField;
		float value = default(float);
		EggFloat growth = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + num5;
		playerStats3.Growth = growth;
		GameManager core3 = GM.Core;
		gizmoManager = core3._gizmoManager;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		obj5 = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
		_ = 0;
		frameName = "Crown";
		characterController = (VampireSurvivors.Objects.Characters.CharacterController)num;
		goto IL_05b4;
		IL_05b4:
		Color? color = (Color?)(object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
		gizmoManager.DisplayIconOverhead(frameName, "", color, characterController, num2, (Vector2)num3, (string)flag);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		_ = 0;
		_ = 1051931443;
		_ = 1;
		soundConfig.Rate = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
		soundConfig.Volume = (float?)(object)0;
		float detune = GetDetune();
		soundConfig.Detune = detune;
		PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.LittleHeart, soundConfig, 150f, 3, (float)characterController);
		tP_Soma_Character = character;
		bool flag4 = _soulType == 0;
		if (!flag4)
		{
			object obj6 = _soulType - 1;
			if (flag4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5EAA]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				int redSouls = tP_Soma_Character.redSouls + 1;
				tP_Soma_Character.redSouls = redSouls;
				if (tP_Soma_Character.UpdateSoulsCount(ref *(int*)(tP_Soma_Character + 1060), ref *(int*)(tP_Soma_Character + 1076), ref *(int*)(tP_Soma_Character + 1080)))
				{
					selectionType = "normal";
					weapon = WeaponType.CANDYBOX;
					goto IL_07ae;
				}
				return;
			}
			if ((nint)obj6 == 1)
			{
				int yellowSouls = tP_Soma_Character.yellowSouls + 1;
				tP_Soma_Character.yellowSouls = yellowSouls;
				if (tP_Soma_Character.UpdateSoulsCount(ref *(int*)(tP_Soma_Character + 1064), ref *(int*)(tP_Soma_Character + 1084), ref *(int*)(tP_Soma_Character + 1088)))
				{
					GameManager core4 = GM.Core;
					core4._003CGoldFingerManager_003Ek__BackingField.ActivateGoldFinger(tP_Soma_Character);
				}
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5EA9]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		int blueSouls = tP_Soma_Character.blueSouls + 1;
		tP_Soma_Character.blueSouls = blueSouls;
		if (tP_Soma_Character.UpdateSoulsCount(ref *(int*)(tP_Soma_Character + 1056), ref *(int*)(tP_Soma_Character + 1068), ref *(int*)(tP_Soma_Character + 1072)))
		{
			selectionType = "passive";
			weapon = WeaponType.ARMADIO;
			goto IL_07ae;
		}
	}

	public unsafe void StartSpiralToPlayer(VampireSurvivors.Objects.Characters.CharacterController cc)
	{
		//IL_0012: Expected O, but got I8
		//IL_0059: Expected I, but got O
		//IL_0061: Expected I, but got O
		//IL_0071: Expected O, but got I
		//IL_00f1: Expected O, but got I4
		//IL_00ad: Expected O, but got I
		//IL_00e3: Expected O, but got I4
		//IL_06e4: Expected O, but got F4
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Expected O, but got Unknown
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Expected O, but got Unknown
		//IL_072e: Expected O, but got I4
		//IL_073e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0743: Expected O, but got Unknown
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0431: Expected O, but got Unknown
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_044d: Expected O, but got Unknown
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Expected O, but got Unknown
		//IL_0780: Expected O, but got I4
		//IL_0790: Unknown result type (might be due to invalid IL or missing references)
		//IL_0795: Expected O, but got Unknown
		//IL_0623->IL052d: Incompatible stack heights: 1 vs 0
		//IL_052c->IL052c: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals28 = new _003C_003Ec__DisplayClass16_0();
		if (CS_0024_003C_003E8__locals28 == null)
		{
			goto IL_052d;
		}
		object obj = 6603577472L;
		CS_0024_003C_003E8__locals28._003C_003E4__this = this;
		if (IsInLavatrix)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController;
		if ((object)cc == null)
		{
			characterController = null;
			goto IL_057c;
		}
		nint num = (nint)typeof(TP_Soma_Character);
		nint num2 = (nint)cc;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ r8_v45 (Il2CppClass<VampireSurvivors.Objects.Characters.TP_Soma_Character>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ r9_v19 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ r8_v45 (Il2CppClass<VampireSurvivors.Objects.Characters.TP_Soma_Character>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ r9_v19 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v107+FFFFFFF8+v399 @ rax_v102*8]");
			if (0 == (nint)typeof(TP_Soma_Character))
			{
				obj4 = 1;
				goto IL_058b;
			}
		}
		obj4 = 0;
		goto IL_058b;
		IL_04dc:
		Tween tween = default(Tween);
		TweenCallback onKill;
		if (tween._003Cactive_003Ek__BackingField)
		{
			tween.onKill = onKill;
		}
		goto IL_0510;
		IL_057c:
		character = (TP_Soma_Character)characterController;
		TP_Soma_Character tP_Soma_Character = character;
		if ((object)character == null || ((UnityEngine.Object)tP_Soma_Character).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		IsInLavatrix = true;
		base.StopFloat();
		base._003CAutoSafeXY_003Ek__BackingField = false;
		_ShowAboveAll = true;
		Transform transform = base.transform;
		TweenCallback onComplete;
		if ((object)cc != null)
		{
			Transform parent = cc.transform;
			if ((object)transform != null)
			{
				transform.SetParent(parent, worldPositionStays: true);
				CS_0024_003C_003E8__locals28.t = 0f;
				Transform transform2 = base.transform;
				if ((object)transform2 != null)
				{
					bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Vector2 ret;
					Transform.get_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)(&ret));
					Transform transform3 = base.transform;
					if ((object)transform3 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Transform.get_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
						CS_0024_003C_003E8__locals28.v = ret;
						CS_0024_003C_003E8__locals28.turns = 1f;
						object obj5 = UnityEngine.Random.value;
						object obj6 = ret + ret;
						float duration = (float)obj6 + 1f;
						if (lavatrixTween != null)
						{
							DG.Tweening.TweenExtensions.Kill(lavatrixTween);
						}
						DOGetter<float> getter = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
						DOSetter<float> dOSetter = null;
						float x = default(float);
						((_003C_003Ec__DisplayClass16_0)(object)dOSetter)._003CStartSpiralToPlayer_003Eb__1(x);
						TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 1f, duration);
						((_003C_003Ec__DisplayClass16_0)(object)tweenerCore)._003CStartSpiralToPlayer_003Eb__1(x);
						TweenCallback onUpdate = delegate
						{
							//IL_0008: Expected O, but got Ref
							//IL_019e: Expected I, but got O
							//IL_004e: Expected O, but got I
							//IL_005c: Expected O, but got Ref
							//IL_00cb: Invalid comparison between I4 and F4
							//IL_0116: Expected F4, but got I4
							//IL_0132: Expected I, but got O
							//IL_0226: Invalid comparison between F4 and I4
							//IL_0248: Expected I, but got F4
							object obj22 = default(object);
							object obj21 = (object)(&obj22);
							Transform transform4 = CS_0024_003C_003E8__locals28._003C_003E4__this.transform;
							nint num8 = (nint)typeof(Vector2);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rcx_v21 (Il2CppClass<UnityEngine.Vector2>)+B8]");
							nint num9 = 0;
							float t = CS_0024_003C_003E8__locals28.t;
							object obj23 = CS_0024_003C_003E8__locals28.v - Vector2.zeroVector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Items.Pickup_TP_EnemySoul+<>c__DisplayClass16_0)+24]");
							nint num10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v16 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
							object obj24 = num10 - 0;
							object obj25 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj22, 224));
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
							float num11 = CS_0024_003C_003E8__locals28.turns * (float)Math.PI;
							float num12 = num11 + num11;
							float num13 = num12 * CS_0024_003C_003E8__locals28.t;
							float num14 = num13 + (float)obj24;
							if (!(0f > CS_0024_003C_003E8__locals28.t))
							{
								if (t > 1f)
								{
									t = 1f;
								}
							}
							else
							{
								t = 0f;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
							bool flag8 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value);
							GameManager core = GM.Core;
							nint num15 = (nint)core._pickupVfx;
							_ = 0;
							_ = 0;
							Transform transform5 = CS_0024_003C_003E8__locals28._003C_003E4__this.transform;
							bool flag9 = ((_003C_003Ec__DisplayClass16_0)(object)transform5).t == 0f;
							Transform.get_position_Injected((IntPtr)((_003C_003Ec__DisplayClass16_0)(object)transform5).t, out Vector3 _);
							_ = 0;
							_ = 1;
							_ = 1;
							bool flag10 = (object)core._pickupVfx == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+50]");
							_ = 0;
							_ = 0;
							_ = 0;
							_ = 0;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rdi_v11 (System.IntPtr)+10]");
							bool flag11 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rdi_v11 (System.IntPtr)+10]");
							ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
							ParticleSystem.Emit_Injected((IntPtr)0, ref emitParams, 1);
						};
						if (tween != null && tween._003Cactive_003Ek__BackingField)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
							bool flag3 = (nint)0 == 0;
							tween.onUpdate = onUpdate;
							if (!flag3)
							{
								object obj7 = tween + 112;
								object obj8 = obj7 >> 12;
								object obj9 = obj8 & 0x1FFFFF;
								object obj10 = obj9 >> 6;
								object obj11 = obj9 & 0x3F;
								nint num5;
								do
								{
									object obj12 = 1 << (int)obj11;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r14_v7+462E0+v1068 @ rdx_v45*8]");
									object obj13 = 0 | obj12;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r14_v7+462E0+v1068 @ rdx_v45*8]");
									nint num4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r14_v7+462E0+v1068 @ rdx_v45*8]");
									if (num4 == 0)
									{
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r14_v7+462E0+v1068 @ rdx_v45*8]");
									num5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r14_v7+462E0+v1068 @ rdx_v45*8]");
								}
								while (num5 != 0);
								TweenCallback tweenCallback = delegate
								{
									Pickup_TP_EnemySoul pickup_TP_EnemySoul = CS_0024_003C_003E8__locals28._003C_003E4__this;
									if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null)
									{
										pickup_TP_EnemySoul.IsInLavatrix = false;
										if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null)
										{
											Transform transform4 = CS_0024_003C_003E8__locals28._003C_003E4__this.transform;
											if ((object)transform4 != null)
											{
												bool flag8 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
												Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 73 ConditionalJump @-1, v128 @ ZF_v8 (System.Boolean) --- -1 Nop");
												/*Error: End of method reached without returning.*/;
											}
										}
									}
									throw new NullReferenceException();
								};
								onComplete = tweenCallback;
								goto IL_03cf;
							}
						}
						TweenCallback tweenCallback2 = delegate
						{
							Pickup_TP_EnemySoul pickup_TP_EnemySoul = CS_0024_003C_003E8__locals28._003C_003E4__this;
							if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null)
							{
								pickup_TP_EnemySoul.IsInLavatrix = false;
								if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null)
								{
									Transform transform4 = CS_0024_003C_003E8__locals28._003C_003E4__this.transform;
									if ((object)transform4 != null)
									{
										bool flag8 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
										Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 73 ConditionalJump @-1, v128 @ ZF_v8 (System.Boolean) --- -1 Nop");
										/*Error: End of method reached without returning.*/;
									}
								}
							}
							throw new NullReferenceException();
						};
						bool flag4 = tween == null;
						onComplete = tweenCallback2;
						if (!flag4)
						{
							goto IL_03cf;
						}
						goto IL_049e;
					}
				}
			}
		}
		goto IL_052d;
		IL_052d:
		throw new NullReferenceException();
		IL_03cf:
		if (tween._003Cactive_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag5 = (nint)0 == 0;
			tween.onComplete = onComplete;
			if (!flag5)
			{
				object obj14 = tween + 128;
				object obj15 = obj14 >> 12;
				object obj16 = obj15 & 0x1FFFFF;
				object obj17 = obj16 >> 6;
				object obj18 = obj16 & 0x3F;
				nint num7;
				do
				{
					object obj19 = 1 << (int)obj18;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r14_v7+462E0+v1186 @ rdx_v41*8]");
					object obj20 = 0 | obj19;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r14_v7+462E0+v1186 @ rdx_v41*8]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r14_v7+462E0+v1186 @ rdx_v41*8]");
					if (num6 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r14_v7+462E0+v1186 @ rdx_v41*8]");
					num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r14_v7+462E0+v1186 @ rdx_v41*8]");
				}
				while (num7 != 0);
				TweenCallback tweenCallback3 = delegate
				{
					Pickup_TP_EnemySoul pickup_TP_EnemySoul = CS_0024_003C_003E8__locals28._003C_003E4__this;
					if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null)
					{
						pickup_TP_EnemySoul.IsInLavatrix = false;
						if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null)
						{
							Transform transform4 = CS_0024_003C_003E8__locals28._003C_003E4__this.transform;
							if ((object)transform4 != null)
							{
								bool flag8 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 73 ConditionalJump @-1, v128 @ ZF_v8 (System.Boolean) --- -1 Nop");
								/*Error: End of method reached without returning.*/;
							}
						}
					}
					throw new NullReferenceException();
				};
				onKill = tweenCallback3;
				goto IL_04dc;
			}
		}
		goto IL_049e;
		IL_049e:
		TweenCallback tweenCallback4 = delegate
		{
			Pickup_TP_EnemySoul pickup_TP_EnemySoul = CS_0024_003C_003E8__locals28._003C_003E4__this;
			if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null)
			{
				pickup_TP_EnemySoul.IsInLavatrix = false;
				if ((object)CS_0024_003C_003E8__locals28._003C_003E4__this != null)
				{
					Transform transform4 = CS_0024_003C_003E8__locals28._003C_003E4__this.transform;
					if ((object)transform4 != null)
					{
						bool flag8 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 73 ConditionalJump @-1, v128 @ ZF_v8 (System.Boolean) --- -1 Nop");
						/*Error: End of method reached without returning.*/;
					}
				}
			}
			throw new NullReferenceException();
		};
		bool flag6 = tween == null;
		onKill = tweenCallback4;
		if (!flag6)
		{
			goto IL_04dc;
		}
		goto IL_0510;
		IL_0510:
		Tween tween2 = VampireSurvivors.Tools.TweenExtensions.SetGameId(tween);
		lavatrixTween = tween2;
		return;
		IL_058b:
		bool flag7 = obj4 == null;
		characterController = null;
		if (!flag7)
		{
			characterController = cc;
		}
		goto IL_057c;
	}

	public Pickup_TP_EnemySoul()
	{
		string[] array = new string[3];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		soulNames = array;
		_soulType = 1;
		_isUnset = true;
		_Volume = 0.35f;
		_MaxHpVal = 0.1f;
		_MightVal = 0.00075f;
		_GreedVal = 0.0015f;
		base._002Ector();
	}
}
