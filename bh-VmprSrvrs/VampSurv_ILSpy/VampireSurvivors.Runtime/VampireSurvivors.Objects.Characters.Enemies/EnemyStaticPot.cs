using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyStaticPot : EnemyController
{
	private MultiTargetTween _onEnterTween;

	private float _invulDelay;

	private float _hitsTaken;

	private bool _isInvul;

	private float _maxHits;

	private int _prevDepth;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0208: Expected O, but got I4
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		//IL_0256: Expected O, but got I4
		base.InitEnemy(enemyType, asRemote);
		base.SetFlipX(flip: false);
		base._003CIsCullable_003Ek__BackingField = true;
		_hitsTaken = 0f;
		_isInvul = false;
		base._003CSpeed_003Ek__BackingField = 0f;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		_maxHits = _maxHp;
		if (_onEnterTween != null)
		{
			_onEnterTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 300f;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween onEnterTween = Tweens.Add(tweenConfig);
		_onEnterTween = onEnterTween;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		ArcadeSprite arcadeSprite2;
		if (!config._003CSelectedInverse_003Ek__BackingField)
		{
			arcadeSprite2 = this;
		}
		else
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			bool flag = config2._003CVisuallyInvertStages_003Ek__BackingField;
			arcadeSprite2 = this;
			if (flag)
			{
				ArcadeSprite arcadeSprite3 = setFlipY(flipY: true);
				goto IL_0246;
			}
		}
		ArcadeSprite arcadeSprite4 = arcadeSprite2.setFlipY(flipY: false);
		goto IL_0246;
		IL_0246:
		ArcadeSprite arcadeSprite5 = setOrigin(0.5f, (float?)(object)1);
	}

	protected override void OnUpdate()
	{
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdi_v1 (System.Object)+10]");
		Quaternion value = default(Quaternion);
		Transform.set_localRotation_Injected((IntPtr)0, ref value);
		if (!base._003CIsDead_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
			int num = default(int);
			if (num != _prevDepth)
			{
				_prevDepth = num;
				_EnemyRenderer.sortingOrder = num;
			}
		}
	}

	protected override void Die()
	{
		base.Die();
		if (_onEnterTween != null)
		{
			_onEnterTween.Pause();
		}
		BaseBody baseBody = body;
		baseBody._enable = false;
	}

	protected override void ProcessWiggle()
	{
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_00f1: Expected O, but got I4
		//IL_01f3: Expected O, but got F4
		//IL_0078: Expected O, but got I4
		//IL_01e1: Expected I4, but got F4
		if (!base._003CIsDead_003Ek__BackingField && !_isInvul)
		{
			float hitsTaken = _hitsTaken + 1f;
			_isInvul = true;
			_hitsTaken = hitsTaken;
			float num2 = default(float);
			bool canPause;
			if (_hitsTaken < _maxHits)
			{
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				soundConfig.Volume = (float?)(object)1;
				float num = _hitsTaken * 100f;
				float detune = num - 500f;
				soundConfig.Detune = detune;
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Bumper2, soundConfig, 100f, 4, num2);
				canPause = false;
			}
			else
			{
				SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
				soundConfig2.Volume = (float?)(object)1;
				soundConfig2.Rate = 1f;
				object obj = UnityEngine.Random.value;
				float num3 = _hitsTaken * -600f;
				float detune2 = num3 - 500f;
				soundConfig2.Detune = detune2;
				PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Pot, soundConfig2, 100f, 4, num2);
				Die();
				canPause = false;
			}
			Action onComplete = delegate
			{
				_isInvul = false;
			};
			float duration = _invulDelay * 0.001f;
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num2 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause);
			base.OnGetDamaged(showHitVfx, hasKb: false);
		}
	}

	public void ChangeFrame()
	{
		//IL_0096: Expected O, but got I4
		//IL_00fc: Expected O, but got F4
		//IL_001c: Expected O, but got I4
		float time = default(float);
		if (_hitsTaken < _maxHits)
		{
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float num = _hitsTaken * 100f;
			float detune = num - 500f;
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Bumper2, soundConfig, 100f, 4, time);
		}
		else
		{
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Rate = 1f;
			object obj = UnityEngine.Random.value;
			float num2 = _hitsTaken * -600f;
			float detune2 = num2 - 500f;
			soundConfig2.Detune = detune2;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Pot, soundConfig2, 100f, 4, time);
			Die();
		}
	}

	public EnemyStaticPot()
	{
		//IL_0031: Expected I4, but got I8
		_invulDelay = 500f;
		_maxHits = 1f;
		_prevDepth = -1;
		base._002Ector();
	}

	private void _003CGetDamaged_003Eb__10_0()
	{
		_isInvul = false;
	}
}
