using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_PistolProjectile_FalconFire : Projectile
{
	private ParticleSystem boundingShotVFX;

	private ParticleEventCall boundingShotParticleEventCall;

	private Timer _expireTimer;

	private Timer _despawnTimer;

	private EME_Pistol1Weapon _trueWeapon;

	private bool _hasExploded;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0073: Expected I, but got O
		//IL_007b: Expected I, but got O
		//IL_008b: Expected O, but got I
		//IL_010b: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0328: Expected O, but got I4
		//IL_00c7: Expected O, but got I
		//IL_013a: Expected O, but got I4
		//IL_013a: Expected O, but got I4
		//IL_00fd: Expected O, but got I4
		//IL_0177: Expected O, but got I4
		//IL_01ed: Expected I, but got O
		//IL_028e: Expected O, but got I4
		//IL_02cb: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		Weapon weapon2 = _weapon;
		_hasExploded = false;
		_isCullable = false;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_0301;
		}
		nint num = (nint)typeof(EME_Pistol1Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v30 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Pistol1Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ r9_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v30 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Pistol1Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ r9_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v49+FFFFFFF8+v90 @ rax_v44*8]");
			if (0 == (nint)typeof(EME_Pistol1Weapon))
			{
				obj3 = 1;
				goto IL_0310;
			}
		}
		obj3 = 0;
		goto IL_0310;
		IL_0301:
		_trueWeapon = (EME_Pistol1Weapon)trueWeapon;
		BaseBody baseBody = body.setCircle(24f, (float?)(object)1, (float?)(object)1);
		_speed = 2f;
		Transform targetTransform = base.AimForNearestEnemy();
		_targetTransform = targetTransform;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num4 = _weapon.PDuration();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_PistolProjectile_FalconFire>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num5 = (nint)this;
		object obj4 = default(object);
		float duration = (float)obj4 * 0.001f;
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		if ((object)boundingShotVFX != null)
		{
			boundingShotVFX.Play(withChildren: true);
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		soundConfig.Detune = -500f;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_gunshot, soundConfig, 200f, 10, flag ? 1 : 0);
		return;
		IL_0310:
		bool flag2 = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag2)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_0301;
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_010a: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null || (_hasExploded ? 1 : 0) != (nint)obj)
		{
			return;
		}
		_hasExploded = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		EnemyController component = gameObject.GetComponent<EnemyController>();
		EME_Pistol1Weapon trueWeapon;
		ArcadeSprite arcadeSprite;
		if ((object)component != null)
		{
			bool flag = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
			trueWeapon = _trueWeapon;
			if (!flag)
			{
				arcadeSprite = component;
				goto IL_0167;
			}
		}
		else
		{
			trueWeapon = _trueWeapon;
		}
		arcadeSprite = this;
		goto IL_0167;
		IL_0167:
		float2 float5 = arcadeSprite.position;
		Vector2 vector = default(Vector2);
		trueWeapon.DoFalconFireExplosionAt(vector);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_explofour, soundConfig, 500f, 1, time);
		Despawn();
	}

	public override void Despawn()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		BaseBody baseBody = body;
		baseBody._enable = false;
		if ((object)boundingShotVFX != null)
		{
			boundingShotVFX.Stop();
		}
		if ((object)boundingShotVFX != null)
		{
			boundingShotVFX.Clear(withChildren: true);
		}
		base.Despawn();
	}
}
