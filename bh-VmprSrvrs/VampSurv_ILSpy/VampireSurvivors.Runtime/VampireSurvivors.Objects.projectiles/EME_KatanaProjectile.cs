using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_KatanaProjectile : Projectile
{
	private ParticleSystem _SlashVFX;

	private const float XOffset = 0.24f;

	private const float XRepeatOffset = 0.08f;

	private const float YOffset = 0.16f;

	private const float VFXScale = 0.4f;

	private const float VFXDuration = 640f;

	private const float BodyDuration = 420f;

	private float2 _bodySize;

	private float2 _bodyOffset;

	private float2 _offsetFromPlayer;

	private bool _cachedFlipX;

	private Timer _bodyTimer;

	private Timer _expireTimer;

	protected override void Awake()
	{
		base.Awake();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_012a: Expected O, but got I8
		//IL_0483: Expected I4, but got I8
		//IL_0146: Expected O, but got I4
		//IL_04c6: Expected O, but got I4
		//IL_04f3: Expected O, but got I4
		//IL_0508: Unknown result type (might be due to invalid IL or missing references)
		//IL_050d: Expected O, but got Unknown
		//IL_0555: Expected O, but got F4
		//IL_0159: Expected O, but got I4
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected I4, but got Unknown
		//IL_01db: Expected O, but got I4
		//IL_021a: Expected O, but got I4
		//IL_021a: Expected O, but got I4
		//IL_0229: Expected O, but got I4
		//IL_0264: Expected O, but got I4
		//IL_0264: Expected F4, but got O
		//IL_0338: Expected I, but got O
		//IL_03a4: Expected O, but got I4
		//IL_03e4: Expected F4, but got I4
		//IL_0088->IL0088: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		ParticleSystem slashVFX = _SlashVFX;
		if ((object)_SlashVFX != null && ((UnityEngine.Object)slashVFX).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_SlashVFX == null)
			{
				goto IL_03e9;
			}
			Transform transform = _SlashVFX.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			float2 value = default(float2);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
			_SlashVFX.Play(withChildren: true);
		}
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			Weapon weapon2 = _weapon;
			if ((object)_weapon != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
				{
					_cachedFlipX = characterController._isFlipped;
					ParticleSystem particleSystem = (ParticleSystem)4294967295L;
					if (!characterController._isFlipped)
					{
						particleSystem = (ParticleSystem)1;
					}
					int num2 = (int)(index & 0x80000001L);
					if ((characterController._isFlipped ? 1 : 0) < (false ? 1 : 0))
					{
						object obj = num2 - 1;
						object obj2 = obj | -2;
						num2 = obj2 + 1;
					}
					if (num2 != 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-80), the output could be wrong!");
						Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 242 ConditionalJump @-1, v654 @ ZF_v40 (System.Boolean) --- -1 Nop");
						/*Error: End of method reached without returning.*/;
					}
					float2 float5 = default(float2);
					float xScale = (float)particleSystem * (float)float5;
					ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)1);
					Weapon weapon3 = _weapon;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ebp\"");
					_ = 1042536202;
					object obj3 = 1 + 2;
					object obj4 = obj3 + obj3;
					object obj5 = index - obj4;
					float num3 = (float)obj5 * 0.08f;
					float num4 = num3 * (float)float5;
					float num5 = num4 + 0.24f;
					float num6 = num5 * (float)particleSystem;
					_offsetFromPlayer = (float2)num6;
					if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
					{
						float2 float6 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
						base.position = float5;
						BaseBody baseBody = body;
						if (body != null)
						{
							baseBody._enable = true;
							_bodySize = (float2)1065353216;
							_ = 1092616192;
							if (body != null)
							{
								BaseBody baseBody2 = body.setSize((float?)(object)1, (float?)(object)1);
								_bodyOffset = (float2)0;
								_ = 1113325568;
								if (body != null)
								{
									BaseBody baseBody3 = body.setOffset((float)_bodyOffset, (float?)(object)1);
									if (_bodyTimer != null)
									{
										_bodyTimer.Cancel();
									}
									Action onComplete = delegate
									{
										//IL_001f: Expected O, but got I4
										//IL_001f: Expected O, but got I4
										BaseBody baseBody4 = body.setSize((float?)(object)1, (float?)(object)1);
										BaseBody baseBody5 = body;
										baseBody5._enable = false;
									};
									bool flag2 = default(bool);
									MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
									int repeat = default(int);
									TimerType type = default(TimerType);
									Timer bodyTimer = Timers.Register(0.42000002f, onComplete, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
									_bodyTimer = bodyTimer;
									if (_expireTimer != null)
									{
										_expireTimer.Cancel();
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v941 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_KatanaProjectile>)+370]");
									Action onComplete2 = new Action(this, (IntPtr)0);
									nint num7 = (nint)this;
									Timer expireTimer = Timers.Register(0.64000005f, onComplete2, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
									_expireTimer = expireTimer;
									SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
									soundConfig.Rate = 1f;
									soundConfig.Volume = (float?)(object)1;
									float detune = (float)_indexInWeapon * -50f;
									soundConfig.Detune = detune;
									PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_katana, soundConfig, 200f, 10, flag2 ? 1 : 0);
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_03e9;
		IL_03e9:
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		//IL_00a1: Invalid comparison between F4 and I
		//IL_0169: Expected O, but got F4
		//IL_00e7: Expected O, but got I4
		//IL_00e7: Expected O, but got I4
		//IL_00c8: Expected F4, but got I
		//IL_01be: Invalid comparison between F4 and I
		//IL_0146: Expected O, but got I4
		//IL_0146: Expected F4, but got O
		//IL_012b: Expected F4, but got I
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = default(float2);
		base.position = float6;
		BaseBody baseBody = body;
		if (baseBody._enable)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 600f;
			float num2 = num * 0.4f;
			float num3 = num2 + (float)_bodySize;
			float num4 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10CE0]");
			if (num4 > 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10CE0]");
				num3 = 0f;
			}
			_bodySize = (float2)num3;
			BaseBody baseBody2 = body.setSize((float?)(object)1, (float?)(object)1);
			if (_cachedFlipX)
			{
				_bodyOffset = _bodySize;
			}
			float deltaTime2 = PauseSystem.DeltaTime;
			float num5 = deltaTime2 * 750f;
			float num6 = num5 * 0.4f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_KatanaProjectile)+E4]");
			float num7 = 0f - num6;
			float num8 = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A116F0]");
			if (num8 < 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A116F0]");
				num7 = 0f;
			}
			BaseBody baseBody3 = body.setOffset((float)_bodyOffset, (float?)(object)1);
		}
	}

	private void UpdatePosition()
	{
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 float6 = default(float2);
		base.position = float6;
	}

	private void InitBody()
	{
		//IL_001e: Expected O, but got I4
		//IL_0043: Expected O, but got I4
		//IL_0043: Expected O, but got I4
		//IL_0052: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_0073: Expected F4, but got O
		BaseBody baseBody = body;
		baseBody._enable = true;
		_bodySize = (float2)1065353216;
		_ = 1092616192;
		BaseBody baseBody2 = body.setSize((float?)(object)1, (float?)(object)1);
		_bodyOffset = (float2)0;
		_ = 1113325568;
		BaseBody baseBody3 = body.setOffset((float)_bodyOffset, (float?)(object)1);
	}

	private void UpdateBody()
	{
		//IL_0071: Invalid comparison between F4 and I
		//IL_0139: Expected O, but got F4
		//IL_00b7: Expected O, but got I4
		//IL_00b7: Expected O, but got I4
		//IL_0098: Expected F4, but got I
		//IL_018e: Invalid comparison between F4 and I
		//IL_0116: Expected O, but got I4
		//IL_0116: Expected F4, but got O
		//IL_00fb: Expected F4, but got I
		BaseBody baseBody = body;
		if (baseBody._enable)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 600f;
			float num2 = num * 0.4f;
			float num3 = num2 + (float)_bodySize;
			float num4 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10CE0]");
			if (num4 > 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10CE0]");
				num3 = 0f;
			}
			_bodySize = (float2)num3;
			BaseBody baseBody2 = body.setSize((float?)(object)1, (float?)(object)1);
			if (_cachedFlipX)
			{
				_bodyOffset = _bodySize;
			}
			float deltaTime2 = PauseSystem.DeltaTime;
			float num5 = deltaTime2 * 750f;
			float num6 = num5 * 0.4f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_KatanaProjectile)+E4]");
			float num7 = 0f - num6;
			float num8 = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A116F0]");
			if (num8 < 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A116F0]");
				num7 = 0f;
			}
			BaseBody baseBody3 = body.setOffset((float)_bodyOffset, (float?)(object)1);
		}
	}

	public override void Despawn()
	{
		ParticleSystem slashVFX = _SlashVFX;
		if ((object)_SlashVFX != null && ((UnityEngine.Object)slashVFX).m_CachedPtr != (IntPtr)0)
		{
			_SlashVFX.Clear(withChildren: true);
		}
		if (_bodyTimer != null)
		{
			_bodyTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__14_0()
	{
		//IL_001f: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
	}
}
