using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Items;

public class Pickup_Bonus_FrozenSoul : NetworkPickup, ICountedPickup
{
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public Pickup_Bonus_FrozenSoul _003C_003E4__this;

		public float _RegenVal;

		public float _GrowthVal;

		internal unsafe void _003CGetTaken_003Eb__0()
		{
			//IL_00c9: Expected O, but got Ref
			//IL_00e5: Expected O, but got I4
			//IL_012f: Expected F4, but got O
			Pickup_Bonus_FrozenSoul pickup_Bonus_FrozenSoul = _003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer = pickup_Bonus_FrozenSoul._targetPlayer;
			PlayerModifierStats playerStats = targetPlayer._playerStats;
			EggFloat eggFloat = playerStats._003CRegen_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + _RegenVal;
			playerStats._003CRegen_003Ek__BackingField = eggFloat2;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			object obj = default(object);
			VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			string textureName = default(string);
			core._gizmoManager.DisplayIconOverhead("HeartRuby", "", (Color?)(object)(&obj), characterController, displayTimeMultiplier, vOffset, textureName);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float detune = GetDetune();
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_powerUp12, soundConfig, 150f, 3, (float)characterController);
		}

		internal unsafe void _003CGetTaken_003Eb__1()
		{
			//IL_00c9: Expected O, but got Ref
			//IL_00e5: Expected O, but got I4
			//IL_012f: Expected F4, but got O
			Pickup_Bonus_FrozenSoul pickup_Bonus_FrozenSoul = _003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer = pickup_Bonus_FrozenSoul._targetPlayer;
			PlayerModifierStats playerStats = targetPlayer._playerStats;
			EggFloat eggFloat = playerStats._003CGrowth_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + _GrowthVal;
			playerStats._003CGrowth_003Ek__BackingField = eggFloat2;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			object obj = default(object);
			VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			string textureName = default(string);
			core._gizmoManager.DisplayIconOverhead("Crown", "", (Color?)(object)(&obj), characterController, displayTimeMultiplier, vOffset, textureName);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float detune = GetDetune();
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_powerUp12, soundConfig, 150f, 3, (float)characterController);
		}
	}

	private int _003CAmountOnCollection_003Ek__BackingField;

	private static int _sfxIndex = 0;

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

	protected float _MaxHpMul;

	protected float _RegenMul;

	protected float _GrowthMul;

	private int _prevDepth;

	public int AmountOnCollection
	{
		get
		{
			return _003CAmountOnCollection_003Ek__BackingField;
		}
		set
		{
			_003CAmountOnCollection_003Ek__BackingField = value;
		}
	}

	private static float GetDetune()
	{
		float[] detuneValues = _detuneValues;
		int sfxIndex = _sfxIndex + 1;
		_sfxIndex = sfxIndex;
		float[] detuneValues2 = _detuneValues;
		int num = _sfxIndex % detuneValues2.Length;
		return detuneValues[num] * 100f;
	}

	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
	}

	public unsafe override void GetTaken()
	{
		//IL_0177: Expected O, but got Ref
		//IL_0193: Expected O, but got I4
		//IL_01dd: Expected F4, but got O
		//IL_021a: Expected I4, but got O
		//IL_021a: Expected O, but got F4
		//IL_021a: Expected I4, but got O
		//IL_025c: Expected I4, but got O
		//IL_025c: Expected O, but got F4
		//IL_025c: Expected I4, but got O
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals7._003C_003E4__this = this;
		if (!((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			float regenVal = _RegenMul * ((Pickup)this)._003CValue_003Ek__BackingField;
			float num = _MaxHpMul * ((Pickup)this)._003CValue_003Ek__BackingField;
			CS_0024_003C_003E8__locals7._RegenVal = regenVal;
			float growthVal = _GrowthMul * ((Pickup)this)._003CValue_003Ek__BackingField;
			CS_0024_003C_003E8__locals7._GrowthVal = growthVal;
			base.SetHasSeenItem();
			base.AddToRunPickups();
			if (!_taken)
			{
				((Pickup)this).GetTaken();
				_taken = true;
			}
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
			PlayerModifierStats playerStats = targetPlayer._playerStats;
			EggFloat eggFloat = playerStats._003CMaxHp_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + num;
			playerStats._003CMaxHp_003Ek__BackingField = eggFloat2;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			object obj = default(object);
			VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
			float num2 = default(float);
			Vector2 vector = default(Vector2);
			string textureName = default(string);
			core._gizmoManager.DisplayIconOverhead("HeartBlack", "", (Color?)(object)(&obj), characterController, num2, vector, textureName);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float detune = GetDetune();
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_powerUp12, soundConfig, 150f, 3, (float)characterController);
			Action onComplete = delegate
			{
				//IL_00c9: Expected O, but got Ref
				//IL_00e5: Expected O, but got I4
				//IL_012f: Expected F4, but got O
				Pickup_Bonus_FrozenSoul pickup_Bonus_FrozenSoul = CS_0024_003C_003E8__locals7._003C_003E4__this;
				VampireSurvivors.Objects.Characters.CharacterController targetPlayer2 = pickup_Bonus_FrozenSoul._targetPlayer;
				PlayerModifierStats playerStats2 = targetPlayer2._playerStats;
				EggFloat eggFloat3 = playerStats2._003CRegen_003Ek__BackingField;
				float value2 = default(float);
				EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
				value2 = eggFloat3._val + CS_0024_003C_003E8__locals7._RegenVal;
				playerStats2._003CRegen_003Ek__BackingField = eggFloat4;
				GameManager core2 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
				object obj2 = default(object);
				VampireSurvivors.Objects.Characters.CharacterController characterController2 = default(VampireSurvivors.Objects.Characters.CharacterController);
				float displayTimeMultiplier = default(float);
				Vector2 vOffset = default(Vector2);
				string textureName2 = default(string);
				core2._gizmoManager.DisplayIconOverhead("HeartRuby", "", (Color?)(object)(&obj2), characterController2, displayTimeMultiplier, vOffset, textureName2);
				SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
				soundConfig2.Volume = (float?)(object)1;
				soundConfig2.Rate = 1f;
				float detune2 = GetDetune();
				soundConfig2.Detune = detune2;
				PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.sfx_powerUp12, soundConfig2, 150f, 3, (float)characterController2);
			};
			Timer timer = TimerHelper.RegisterMillisUI(200f, onComplete, null, isLooped: false, (byte)(int)characterController != 0, (MonoBehaviour)num2, (int)vector);
			Action onComplete2 = delegate
			{
				//IL_00c9: Expected O, but got Ref
				//IL_00e5: Expected O, but got I4
				//IL_012f: Expected F4, but got O
				Pickup_Bonus_FrozenSoul pickup_Bonus_FrozenSoul = CS_0024_003C_003E8__locals7._003C_003E4__this;
				VampireSurvivors.Objects.Characters.CharacterController targetPlayer2 = pickup_Bonus_FrozenSoul._targetPlayer;
				PlayerModifierStats playerStats2 = targetPlayer2._playerStats;
				EggFloat eggFloat3 = playerStats2._003CGrowth_003Ek__BackingField;
				float value2 = default(float);
				EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
				value2 = eggFloat3._val + CS_0024_003C_003E8__locals7._GrowthVal;
				playerStats2._003CGrowth_003Ek__BackingField = eggFloat4;
				GameManager core2 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
				object obj2 = default(object);
				VampireSurvivors.Objects.Characters.CharacterController characterController2 = default(VampireSurvivors.Objects.Characters.CharacterController);
				float displayTimeMultiplier = default(float);
				Vector2 vOffset = default(Vector2);
				string textureName2 = default(string);
				core2._gizmoManager.DisplayIconOverhead("Crown", "", (Color?)(object)(&obj2), characterController2, displayTimeMultiplier, vOffset, textureName2);
				SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
				soundConfig2.Volume = (float?)(object)1;
				soundConfig2.Rate = 1f;
				float detune2 = GetDetune();
				soundConfig2.Detune = detune2;
				PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.sfx_powerUp12, soundConfig2, 150f, 3, (float)characterController2);
			};
			Timer timer2 = TimerHelper.RegisterMillisUI(400f, onComplete2, null, isLooped: false, (byte)(int)characterController != 0, (MonoBehaviour)num2, (int)vector);
			_targetPlayer.RecoverHp(1f, showRecovery: true, mulByRegen: true);
		}
	}

	public override void UpdateDepth()
	{
		//IL_002a: Expected O, but got I4
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		object obj = 1 - renderer.pixelHeight;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		if (num != _prevDepth)
		{
			_prevDepth = num;
			_itemRenderer.sortingOrder = num;
		}
	}

	public override void Despawn()
	{
		//IL_0023: Expected O, but got I4
		//IL_0090: Expected I4, but got I8
		BaseBody baseBody = body;
		baseBody._enable = false;
		setVelocity(0f, (float?)(object)0);
		PhysicsManager sInstance = PhysicsManager._sInstance;
		sInstance._pickupGroup.remove(this);
		PhysicsManager sInstance2 = PhysicsManager._sInstance;
		sInstance2._goToPlayerPickupGroup.remove(this);
		if (body != null)
		{
			body.destroy();
			body = null;
		}
		_prevDepth = -1;
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			ReturnPickupToPool();
		}
		else
		{
			OnlineDespawn();
		}
	}

	protected override void ReturnPickupToPool()
	{
		GameManager gameManager = _gameManager;
		ObjectPool frozenSoulPool = _gameManager.FrozenSoulPool;
		GameObject obj = base.gameObject;
		frozenSoulPool.Release(obj);
		bool flag = ((HashSet<object>)(object)gameManager._frozenSouls).Remove((object)this);
	}

	protected override void PreOnlineVacuum()
	{
		GameManager gameManager = _gameManager;
		bool flag = ((HashSet<object>)(object)gameManager._frozenSouls).Remove((object)this);
	}

	protected override void PreOnlineTake()
	{
		GameManager gameManager = _gameManager;
		bool flag = ((HashSet<object>)(object)gameManager._frozenSouls).Remove((object)this);
	}

	public Pickup_Bonus_FrozenSoul()
	{
		//IL_003b: Expected I4, but got I8
		_003CAmountOnCollection_003Ek__BackingField = 1;
		_MaxHpMul = 0.06f;
		_RegenMul = 0.0003f;
		_GrowthMul = 0.0003f;
		_prevDepth = -1;
		base._002Ector();
	}
}
