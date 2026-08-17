using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_WaveWeapon : Weapon
{
	private ParticleSystem _pfxEmitter;

	private ParticleSystem _pfxEmitter2;

	protected Projectile _LinePrefab;

	protected BulletPool _linePool;

	public virtual bool IsEvolved => false;

	protected override int ProjectilePoolSize => 20;

	protected override void OnStart()
	{
		base.OnStart();
		BulletPool linePool = new BulletPool(_LinePrefab, 20);
		_linePool = linePool;
		if (IsEvolved)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyWave;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_linePool, core.Enemies, collideCallback, processCallback, callbackContext);
		}
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_012b: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0117;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									Rapture(component);
								}
								goto IL_0117;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0117:
		return false;
	}

	protected bool OnBulletOverlapsEnemyWave(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0130: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_011c;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									RaptureDamage(component, risky: false);
								}
								goto IL_011c;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_011c:
		return false;
	}

	public void Rapture(EnemyController enemy)
	{
		//IL_0071: Expected I, but got O
		//IL_007f: Expected I, but got O
		//IL_008f: Expected O, but got I
		//IL_010f: Expected O, but got I4
		//IL_00cb: Expected O, but got I
		//IL_0101: Expected O, but got I4
		//IL_0205: Expected O, but got F4
		//IL_0241: Expected O, but got I4
		float2 position = enemy.position;
		float2 position2 = enemy.position;
		float2 float5 = default(float2);
		Projectile projectile = _linePool.SpawnAt(float5, this);
		EME_WaveProjectile_LineVFX eME_WaveProjectile_LineVFX;
		if ((object)projectile == null)
		{
			eME_WaveProjectile_LineVFX = null;
			goto IL_01df;
		}
		nint num = (nint)projectile;
		nint num2 = (nint)typeof(EME_WaveProjectile_LineVFX);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_WaveProjectile_LineVFX>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_WaveProjectile_LineVFX>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rax_v41+FFFFFFF8+v181 @ rax_v37*8]");
			if (0 == (nint)typeof(EME_WaveProjectile_LineVFX))
			{
				obj3 = 1;
				goto IL_01b6;
			}
		}
		obj3 = 0;
		goto IL_01b6;
		IL_01b6:
		bool flag = obj3 == null;
		eME_WaveProjectile_LineVFX = null;
		if (!flag)
		{
			eME_WaveProjectile_LineVFX = (EME_WaveProjectile_LineVFX)projectile;
		}
		goto IL_01df;
		IL_01df:
		if ((object)eME_WaveProjectile_LineVFX != null && ((UnityEngine.Object)eME_WaveProjectile_LineVFX).m_CachedPtr != (IntPtr)0)
		{
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			object obj4 = UnityEngine.Random.value;
			float num4 = (float)float5 - 0.2f;
			soundConfig.Rate = 1f;
			float detune = num4 * 1000f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Eme_sfx_wave1, soundConfig, 100f, 2, time);
			eME_WaveProjectile_LineVFX._targetEnemy = enemy;
			eME_WaveProjectile_LineVFX.Activate();
		}
	}

	public void RaptureDamage(EnemyController enemy, bool risky = true)
	{
		//IL_02ba: Expected O, but got F4
		//IL_02f6: Expected O, but got I4
		//IL_0269: Expected F4, but got O
		//IL_012b: Expected O, but got I4
		//IL_0134: Expected O, but got I4
		//IL_01ef: Expected O, but got I4
		if ((object)enemy == null || ((UnityEngine.Object)enemy).m_CachedPtr == (IntPtr)0 || enemy._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		soundConfig.Rate = 1f;
		float detune = num * 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Eme_sfx_wave2, soundConfig, 100f, 3, time);
		float2 position = enemy.position;
		Vector2 vector = default(Vector2);
		RenderingExtensions.EmitParticleAt(_pfxEmitter, vector, 20);
		float2 position2 = enemy.position;
		RenderingExtensions.EmitParticleAt(_pfxEmitter2, vector, 20);
		bool flag = (object)enemy._003CResRosary_003Ek__BackingField == null;
		Vector2 vector2 = vector;
		Vector2 vector3;
		if (!flag)
		{
			bool flag2 = 1045220557 > 0;
			vector2 = (Vector2)1045220557;
			vector3 = (Vector2)1045220557;
			if (flag2)
			{
				goto IL_0246;
			}
		}
		bool flag3 = enemy._hasATreasure;
		vector3 = vector2;
		if (!flag3)
		{
			bool isEvolved = IsEvolved;
			bool flag4 = (isEvolved ? 1 : 0) < (false ? 1 : 0);
			bool flag5 = !isEvolved;
			if (!isEvolved)
			{
				float value = UnityEngine.Random.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm2,xmm0\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [188A106C8h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm2\"");
				bool flag6 = !flag4;
				bool flag7 = !flag5;
				object obj3 = flag7 & flag6;
				if (obj3 != null)
				{
					enemy.GiveReward();
				}
			}
			else
			{
				enemy.GiveFullReward();
			}
			enemy.PlayVFXFlash(HitVfxType.Beam);
			enemy.Disappear();
			return;
		}
		goto IL_0246;
		IL_0246:
		float num2 = base.PPower();
		enemy.GetDamaged((float)vector3, HitVfxType.Light, 0f, WeaponType.VOID, hasKb: false);
		float num3 = (float)vector3 + base._003CStatsInflictedDamage_003Ek__BackingField;
		base._003CStatsInflictedDamage_003Ek__BackingField = num3;
	}
}
