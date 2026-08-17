using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class Pickup_EME_Cat : NetworkPickup
{
	[Serializable]
	private struct CatPickupReward
	{
		public WeaponType RewardType;

		private float _minValue;

		private float _maxValue;

		public float Value => UnityEngine.Random.Range(_minValue, _maxValue);
	}

	private enum CatBehaviourState
	{
		Idle,
		Fleeing,
		Taken
	}

	private enum CatDespawnBehaviourType
	{
		None,
		CheckDistanceWhenFleeing,
		CheckDistanceAlways
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<VampireSurvivors.Objects.Characters.CharacterController, bool> _003C_003E9__36_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003COnRecycle_003Eb__36_0(VampireSurvivors.Objects.Characters.CharacterController player)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)player != null)
			{
				object obj = player._characterType - 148;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private bool _randomiseColour = true;

	private float _aggroRange;

	private float _runSpeed = 1f;

	private CatDespawnBehaviourType _despawnBehaviourType;

	public float _maxDistanceFromPlayerBeforeDespawn;

	private float _healthRecoveredOnPickup;

	private bool _triggerVacuumOnPickup;

	private bool _giveStatRewardOnPickup;

	private CatPickupReward[] _pickupRewards;

	protected VampireSurvivors.Objects.Characters.CharacterController AmeyaPlayer;

	private CatBehaviourState _currentCatBehaviourState;

	private Vector2 _velocity;

	private uint _rewardSeed;

	private uint _catTypeSeed;

	protected Unity.Mathematics.Random _rewardRng;

	protected Unity.Mathematics.Random _catTypeRng;

	private static int _sfxIndex;

	private const string IdleAnimationName = "idle";

	private const string FleeAnimationName = "flee";

	private const string DraggedAnimationName = "dragged";

	protected const string EmeraldsTextureName = "character_eme_witch";

	private readonly float[] _detuneValues = new float[64]
	{
		0f, 12f, 0f, 12f, -5f, 7f, -2f, 10f, 0f, 12f,
		0f, 12f, -5f, 7f, -2f, 10f, 3f, 15f, 3f, 15f,
		-2f, 10f, 1f, 13f, 3f, 15f, 3f, 15f, -2f, 10f,
		1f, 13f, 5f, 17f, 5f, 17f, 0f, 12f, 3f, 15f,
		5f, 17f, 5f, 17f, 0f, 12f, 3f, 15f, 7f, 19f,
		7f, 19f, 2f, 14f, 5f, 17f, 7f, 19f, 7f, 19f,
		2f, 14f, 5f, 17f
	};

	public Action OnGoToPlayer;

	public Action OnDespawn;

	public uint RewardSeed
	{
		get
		{
			return _rewardSeed;
		}
		set
		{
			_rewardSeed = value;
		}
	}

	public uint CatTypeSeed
	{
		get
		{
			return _catTypeSeed;
		}
		set
		{
			_catTypeSeed = value;
		}
	}

	public override bool CanCharacterCollectPickup(CharacterType characterType)
	{
		//IL_000e: Expected O, but got I4
		object obj = characterType - 148;
		return obj == null;
	}

	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
	}

	public override void SetData(ItemType itemType)
	{
		base.SetData(ItemType.EME_CATY);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 12 Invalid \"Jump target not found in method: 0x18734CFE0\"");
	}

	private void OnRecycle()
	{
		//IL_0097: Expected O, but got I
		//IL_0363: Invalid comparison between I4 and F4
		//IL_03a8: Expected O, but got I
		//IL_006b: Expected O, but got I
		//IL_04df: Invalid comparison between I4 and F4
		//IL_00f8: Expected O, but got I8
		//IL_04b1: Expected O, but got I4
		//IL_0154: Expected O, but got I8
		//IL_047a: Expected O, but got I4
		//IL_0483: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Expected O, but got Unknown
		CoherenceSync coherenceSync = _coherenceSync;
		Pickup_EME_Cat pickup_EME_Cat = this;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			pickup_EME_Cat = (Pickup_EME_Cat)(object)networkEntityState._003CAuthorityType_003Ek__BackingField;
			bool flag = (byte)(nint)((UnityEngine.Object)pickup_EME_Cat).m_CachedPtr != 0;
			if (((UnityEngine.Object)pickup_EME_Cat).m_CachedPtr != (IntPtr)1)
			{
				object obj = (nint)((UnityEngine.Object)pickup_EME_Cat).m_CachedPtr - 3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				goto IL_04a6;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			pickup_EME_Cat = (Pickup_EME_Cat)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v301 @ rax_v77 (should have been resolved before IL gen)");
		if (0f > 1f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm0\"");
		}
		uint rewardSeed = default(uint);
		_rewardSeed = rewardSeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
			pickup_EME_Cat = (Pickup_EME_Cat)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v461 @ rax_v80 (should have been resolved before IL gen)");
		if (0f > 1f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm0\"");
		}
		uint catTypeSeed = default(uint);
		_catTypeSeed = catTypeSeed;
		goto IL_04a6;
		IL_04a6:
		_rewardRng = (Unity.Mathematics.Random)0;
		VampireSurvivors.Objects.Characters.CharacterController ameyaPlayer = AmeyaPlayer;
		_currentCatBehaviourState = CatBehaviourState.Idle;
		if ((object)AmeyaPlayer == null || ((UnityEngine.Object)ameyaPlayer).m_CachedPtr == (IntPtr)0)
		{
			GameManager core = GM.Core;
			Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__36_0;
			if (_003C_003Ec._003C_003E9__36_0 == null)
			{
				predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__36_0 = delegate(VampireSurvivors.Objects.Characters.CharacterController player)
				{
					//IL_0052: Expected I4, but got O
					//IL_0030: Expected O, but got I4
					if ((object)player == null)
					{
						NullReferenceException ex3 = new NullReferenceException();
						return (byte)(int)ex3 != 0;
					}
					object obj6 = player._characterType - 148;
					return obj6 == null;
				});
			}
			object ameyaPlayer2 = Enumerable.FirstOrDefault(core._mainCharacters, predicate);
			AmeyaPlayer = (VampireSurvivors.Objects.Characters.CharacterController)ameyaPlayer2;
		}
		_targetPlayer = AmeyaPlayer;
		((Pickup)this)._003CAutoSafeXY_003Ek__BackingField = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F01]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_spriteAnimation.CleanAnimations();
		GetCatAnimations(out var idle, out var flee, out var dragged);
		bool shouldLoop = default(bool);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("idle", idle, 10, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.AddAnimation("flee", flee, 10, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.AddAnimation("dragged", dragged, 10, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("idle");
		object obj4 = UnityEngine.Random.RandomRangeInt(0, 2);
		object obj5 = obj4 - 1;
		bool flag3 = obj5 == null;
		ArcadeSprite arcadeSprite = setFlipX(flag3);
	}

	public override void GetTaken()
	{
		if (!((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			base.SetHasSeenItem();
			base.AddToRunPickups();
			Action onGoToPlayer = OnGoToPlayer;
			if (OnGoToPlayer != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v28.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			if (!_taken)
			{
				((Pickup)this).GetTaken();
				_taken = true;
			}
			OnGoToPlayer = null;
			OnCatPickedUp();
		}
	}

	protected unsafe virtual void OnCatPickedUp()
	{
		//IL_0275: Invalid comparison between F4 and I4
		//IL_0064: Expected O, but got I4
		//IL_00d3: Expected O, but got I4
		//IL_00dd: Expected O, but got I4
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_0120: Expected F4, but got I
		//IL_0169: Expected F4, but got I
		//IL_01d6: Expected O, but got Ref
		//IL_0200: Expected O, but got I4
		//IL_0261: Expected F4, but got O
		if (_giveStatRewardOnPickup)
		{
			int num = (int)(_rewardSeed << 13);
			int num2 = (int)_rewardSeed ^ num;
			int num3 = num2 >> 17;
			int num4 = num2 ^ num3;
			int num5 = num4 << 5;
			int num6 = num5 ^ num4;
			_rewardRng = (Unity.Mathematics.Random)num6;
			CatPickupReward[] pickupRewards = _pickupRewards;
			int num7 = num6 << 13;
			int num8 = num7 ^ num6;
			int num9 = num8 >> 17;
			int num10 = num8 ^ num9;
			int num11 = num10 << 5;
			int num12 = num11 ^ num10;
			object obj = num6 * pickupRewards.Length;
			_rewardRng = (Unity.Mathematics.Random)num12;
			object obj2 = obj >> 32;
			object obj3 = obj2 * 2;
			object obj4 = obj2 + obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r9_v6 (CatPickupReward[])+28+v411 @ rcx_v20*4]");
			float minInclusive = default(float);
			float value = UnityEngine.Random.Range(minInclusive, 0f);
			AddAttribute(_targetPlayer, (WeaponType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref pickupRewards[obj2]), value);
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r9_v6 (CatPickupReward[])+28+v411 @ rcx_v20*4]");
			float value2 = UnityEngine.Random.Range(minInclusive, 0f);
			NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
			string value3 = System.Number.FormatSingle(value2, null, currentInfo);
			Color coopColour = _targetPlayer.GetCoopColour();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			object obj5 = default(object);
			VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			core._gizmoManager.DisplayWeaponIconOverhead((WeaponType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref pickupRewards[obj2]), value3, (Color?)(object)(&obj5), characterController, displayTimeMultiplier, vOffset);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float[] detuneValues = _detuneValues;
			int sfxIndex = _sfxIndex + 1;
			_sfxIndex = sfxIndex;
			float[] detuneValues2 = _detuneValues;
			int num13 = _sfxIndex % detuneValues2.Length;
			float detune = detuneValues[num13] * 100f;
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_powerUp12, soundConfig, 150f, 3, (float)characterController);
		}
		if (_healthRecoveredOnPickup > 0f)
		{
			_targetPlayer.RecoverHp(_healthRecoveredOnPickup, showRecovery: true, mulByRegen: true);
		}
		if (_triggerVacuumOnPickup)
		{
			GM.Core.TurnOnVacuum(_targetPlayer);
		}
	}

	private void SetVelocity(Vector2 velocity)
	{
		BaseBody baseBody = body;
		baseBody._velocity = velocity;
	}

	public void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_004b: Expected O, but got I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_01b0: Expected I, but got O
		//IL_01dd: Expected O, but got I
		//IL_0263: Expected O, but got F4
		//IL_00b1: Expected O, but got I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_0187: Expected O, but got I4
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		//IL_027c: Expected I, but got O
		//IL_02a9: Expected O, but got I
		//IL_032f: Expected O, but got F4
		//IL_011c: Expected O, but got I4
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		int num = tile._data & 8;
		bool flag = num == 0;
		bool flag2 = num < 0;
		bool flag3 = !flag2;
		object obj = !flag;
		object obj2 = flag3 & obj;
		if (obj2 == null)
		{
			int num2 = tile._data & 4;
			bool flag4 = num2 == 0;
			bool flag5 = num2 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag6;
			object obj4 = obj3 | flag4;
			if (obj4 != null)
			{
				goto IL_013c;
			}
		}
		nint num3 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v8 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Items.Pickup_EME_Cat)+1B8]");
		object obj5 = num5 * 0;
		object obj6 = Vector2.rightVector * _velocity;
		object obj7 = obj5 + obj6;
		float num6 = (float)obj7 * -2f;
		float num7 = (float)Vector2.rightVector * num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
		float num8 = 0f * num6;
		float num9 = num7 + (float)_velocity;
		float num10 = num8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Items.Pickup_EME_Cat)+1B8]");
		float num11 = num10 + 0f;
		_velocity = (Vector2)num9;
		goto IL_013c;
		IL_013c:
		int num12 = tile._data & 1;
		bool flag7 = num12 == 0;
		bool flag8 = num12 < 0;
		bool flag9 = !flag8;
		object obj8 = !flag7;
		object obj9 = flag9 & obj8;
		if (obj9 == null)
		{
			int num13 = tile._data & 2;
			bool flag10 = num13 == 0;
			bool flag11 = num13 < 0;
			bool flag12 = !flag11;
			object obj10 = !flag12;
			object obj11 = obj10 | flag10;
			if (obj11 != null)
			{
				return;
			}
		}
		nint num14 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v5 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Items.Pickup_EME_Cat)+1B8]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector2>)+14]");
		object obj12 = num16 * 0;
		object obj13 = _velocity * Vector2.upVector;
		object obj14 = obj12 + obj13;
		float num17 = (float)obj14 * -2f;
		float num18 = (float)Vector2.upVector * num17;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector2>)+14]");
		float num19 = 0f * num17;
		float num20 = num18 + (float)_velocity;
		float num21 = num19;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Items.Pickup_EME_Cat)+1B8]");
		float num22 = num21 + 0f;
		_velocity = (Vector2)num20;
	}

	protected override void OnUpdate()
	{
		//IL_00d1: Expected O, but got I4
		//IL_0235: Invalid comparison between F4 and O
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		VampireSurvivors.Objects.Characters.CharacterController ameyaPlayer = AmeyaPlayer;
		if ((object)AmeyaPlayer == null || ((UnityEngine.Object)ameyaPlayer).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		bool flag;
		bool flag2;
		if (((Pickup)this)._goToPlayer)
		{
			float2 float5 = base.position;
			float2 float6 = AmeyaPlayer.position;
			flag = (byte)(float6 < float5) != 0;
			object obj = float6 - float5;
			flag2 = obj == null;
		}
		else
		{
			bool flag3 = _currentCatBehaviourState == CatBehaviourState.Idle;
			if (flag3)
			{
				if (!_coherenceSync.HasStateAuthority)
				{
					return;
				}
				float2 float7 = base.position;
				float2 float8 = AmeyaPlayer.position;
				object obj2 = float7 - float8;
				object obj4 = default(object);
				object obj5 = default(object);
				object obj3 = obj4 - obj5;
				float num = _aggroRange * _aggroRange;
				object obj6 = obj2 * obj2;
				object obj7 = obj3 * obj3;
				object obj8 = obj6 + obj7;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
					GameManager core = GM.Core;
					Vector2 vector = default(Vector2);
					if (!core._multiplayer.IsOnlineMultiplayer)
					{
						TransitionToFlee(vector);
						return;
					}
					Action<Vector2> action = null;
					((Pickup_EME_Cat)(object)action).TransitionToFlee((Vector2)this);
					bool flag4 = _coherenceSync.SendCommand(action, MessageTarget.All, vector);
				}
				return;
			}
			object obj9 = _currentCatBehaviourState - 1;
			if (!flag3)
			{
				if ((nint)obj9 == 1)
				{
					return;
				}
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
				throw ex;
			}
			if (body == null)
			{
				return;
			}
			BaseBody baseBody = body;
			baseBody._velocity = _velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Items.Pickup_EME_Cat)+1B8]");
			_ = 0;
			BaseBody baseBody2 = body;
			flag = 0 < (nint)baseBody2._velocity;
			object obj10 = 0 - baseBody2._velocity;
			flag2 = obj10 == null;
		}
		bool flag5 = !flag;
		bool flag6 = !flag2;
		bool flag7 = flag6 & flag5;
		ArcadeSprite arcadeSprite = setFlipX(flag7);
	}

	public override void Despawn()
	{
		if (OnDespawn != null)
		{
			Action onDespawn = OnDespawn;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v14.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			OnDespawn = null;
		}
		base.Despawn();
	}

	public void TransitionToFlee(Vector2 velocity)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4EFF]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_velocity = velocity;
		_currentCatBehaviourState = CatBehaviourState.Fleeing;
		_spriteAnimation.SetAnimation("flee");
	}

	protected override void GoToThePlayer()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F00]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_currentCatBehaviourState != CatBehaviourState.Taken)
		{
			_currentCatBehaviourState = CatBehaviourState.Taken;
			_spriteAnimation.SetAnimation("dragged");
			Action onGoToPlayer = OnGoToPlayer;
			if (OnGoToPlayer != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v58.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
		base.GoToThePlayer();
	}

	private void ConfigureAnimations()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F01]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_spriteAnimation.CleanAnimations();
		GetCatAnimations(out var idle, out var flee, out var dragged);
		bool shouldLoop = default(bool);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("idle", idle, 10, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.AddAnimation("flee", flee, 10, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.AddAnimation("dragged", dragged, 10, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
	}

	protected unsafe virtual void GetCatAnimations(out List<Sprite> idle, out List<Sprite> flee, out List<Sprite> dragged)
	{
		//IL_01b4: Expected O, but got I
		//IL_01c4: Expected O, but got I
		//IL_01e4: Expected O, but got I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F02]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v2+B8]");
		object obj2 = 0;
		string text = (string)obj2;
		ItemType catType = GetCatType();
		object obj3 = catType - 101;
		string animName;
		if (!flag)
		{
			object obj4 = obj3 - 1;
			if (!flag)
			{
				object obj5 = obj4 - 1;
				if (!flag)
				{
					object obj6 = obj5 - 1;
					if (!flag)
					{
						if ((nint)obj6 != 1)
						{
							Debug.LogError("Item type isn't a cat!");
							animName = text;
						}
						else
						{
							animName = "eme_cat_red_d0";
							text = "eme_cat_red_i0";
						}
					}
					else
					{
						animName = "eme_cat_white_d0";
						text = "eme_cat_white_i0";
					}
				}
				else
				{
					animName = "eme_cat_black_d0";
					text = "eme_cat_black_i0";
				}
			}
			else
			{
				animName = "eme_cat_blue_d0";
				text = "eme_cat_blue_i0";
			}
		}
		else
		{
			animName = "eme_cat_yellow_d0";
			text = "eme_cat_yellow_i0";
		}
		int zeroPad = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(text, 4, 4, "character_eme_witch", zeroPad);
		ref List<Sprite> reference = ref *(List<Sprite>*)animationFrames;
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames(text, 1, 4, "character_eme_witch", zeroPad);
		ref List<Sprite> reference2 = ref *(List<Sprite>*)animationFrames2;
		List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames(animName, 1, 2, "character_eme_witch", zeroPad);
		ref List<Sprite> reference3 = ref *(List<Sprite>*)animationFrames3;
	}

	protected virtual ItemType GetCatType()
	{
		//IL_007e: Expected O, but got I4
		//IL_00dd: Expected O, but got I4
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		//IL_0102: Expected O, but got I4
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		if (_randomiseColour)
		{
			int num = (int)(_catTypeSeed << 13);
			int num2 = (int)_catTypeSeed ^ num;
			int num3 = num2 >> 17;
			int num4 = num2 ^ num3;
			int num5 = num4 << 5;
			int num6 = num5 ^ num4;
			_catTypeRng = (Unity.Mathematics.Random)num6;
			int num7 = num6 << 13;
			int num8 = num7 ^ num6;
			int num9 = num8 >> 17;
			int num10 = num8 ^ num9;
			int num11 = num10 << 5;
			int num12 = num11 ^ num10;
			object obj = num6 * 4;
			object obj2 = num6 + obj;
			object obj3 = obj2 >> 32;
			_catTypeRng = (Unity.Mathematics.Random)num12;
			bool flag = obj3 == null;
			if (!flag)
			{
				object obj4 = obj3 - 1;
				if (flag)
				{
					return ItemType.EME_CATB;
				}
				object obj5 = obj4 - 1;
				if (flag)
				{
					return ItemType.EME_CATR;
				}
				object obj6 = obj5 - 1;
				if (flag)
				{
					return ItemType.EME_CATW;
				}
				if ((nint)obj6 == 1)
				{
					goto IL_0193;
				}
			}
			return ItemType.EME_CATU;
		}
		goto IL_0193;
		IL_0193:
		return ItemType.EME_CATY;
	}

	private float GetDetune()
	{
		float[] detuneValues = _detuneValues;
		int sfxIndex = _sfxIndex + 1;
		_sfxIndex = sfxIndex;
		float[] detuneValues2 = _detuneValues;
		int num = _sfxIndex % detuneValues2.Length;
		return detuneValues[num] * 100f;
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

	private ItemType _003CGetCatType_003Eg__RandomCatType_007C47_0()
	{
		//IL_005f: Expected O, but got I4
		//IL_00be: Expected O, but got I4
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00e3: Expected O, but got I4
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		int num = (int)(_catTypeSeed << 13);
		int num2 = (int)_catTypeSeed ^ num;
		int num3 = num2 >> 17;
		int num4 = num2 ^ num3;
		int num5 = num4 << 5;
		int num6 = num5 ^ num4;
		_catTypeRng = (Unity.Mathematics.Random)num6;
		int num7 = num6 << 13;
		int num8 = num7 ^ num6;
		int num9 = num8 >> 17;
		int num10 = num8 ^ num9;
		int num11 = num10 << 5;
		int num12 = num11 ^ num10;
		object obj = num6 * 4;
		object obj2 = num6 + obj;
		object obj3 = obj2 >> 32;
		_catTypeRng = (Unity.Mathematics.Random)num12;
		bool flag = obj3 == null;
		if (!flag)
		{
			object obj4 = obj3 - 1;
			if (flag)
			{
				return ItemType.EME_CATB;
			}
			object obj5 = obj4 - 1;
			if (flag)
			{
				return ItemType.EME_CATR;
			}
			object obj6 = obj5 - 1;
			if (flag)
			{
				return ItemType.EME_CATW;
			}
			if ((nint)obj6 == 1)
			{
				return ItemType.EME_CATY;
			}
		}
		return ItemType.EME_CATU;
	}
}
