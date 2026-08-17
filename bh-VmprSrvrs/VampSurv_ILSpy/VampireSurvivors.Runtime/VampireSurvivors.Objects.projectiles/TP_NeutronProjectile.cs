using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_NeutronProjectile : Projectile
{
	private float _displaySpritePxSize = 128f;

	private float _innerRadius = 0.32f;

	private MultiTargetTween _tween1;

	private PhaserSprite _displaySprite;

	private int frameIndex;

	private float frameTime;

	private bool _isActivated;

	private MultiTargetTween _tween2;

	private bool _canUpdate;

	private bool _isUnionWeapon;

	protected override void Awake()
	{
		base.Awake();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite displaySprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Neutron00");
		_displaySprite = displaySprite;
		PhaserSprite phaserSprite = _displaySprite.setDepth(2000);
		PhaserSprite phaserSprite2 = _displaySprite.setVisible(visible: false);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_02b3: Expected O, but got I4
		//IL_0031: Expected O, but got I4
		//IL_0031: Expected O, but got I4
		//IL_0080: Expected O, but got Ref
		//IL_00f8: Expected O, but got I4
		//IL_0142: Expected O, but got I4
		//IL_01d5: Expected I, but got O
		//IL_022b: Expected O, but got I4
		//IL_0247: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		float radius = _displaySpritePxSize * 0.5f;
		BaseBody baseBody = body.setCircle(radius, (float?)(object)0, (float?)(object)0);
		frameIndex = 0;
		_isActivated = false;
		ArcadeSprite arcadeSprite2 = setAlpha(1f);
		Transform transform = _sprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
		ArcadeSprite arcadeSprite3 = setDepth(2000);
		_isCullable = false;
		_canUpdate = false;
		ArcadeSprite arcadeSprite4 = setVisible(visible: false);
		Weapon weapon2 = _weapon;
		object obj2 = ((Equipment)weapon2)._equipmentType - 1600;
		bool isUnionWeapon = obj2 == null;
		_isUnionWeapon = isUnionWeapon;
		PhaserSprite phaserSprite = _displaySprite.setVisible(visible: true);
		PhaserSprite phaserSprite2 = phaserSprite.setScale(4f, (float?)(object)0);
		PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0.35f);
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_displaySprite != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = 150f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_006d: Expected O, but got I4
			//IL_008d: Expected O, but got F4
			//IL_00bb: Expected O, but got I4
			bool flag = !_isUnionWeapon;
			if (!flag)
			{
			}
			object obj4 = !flag;
			int maxInstances = 1;
			if (obj4 == null)
			{
				maxInstances = 3;
			}
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			object obj5 = UnityEngine.Random.value;
			object obj6 = default(object);
			float num2 = (float)obj6 - 0.5f;
			float detune = num2 * 200f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_NeutronBomb, soundConfig, 200f, maxInstances, time);
			_canUpdate = true;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween2 = tween;
	}

	public override void InternalUpdate()
	{
		//IL_0034: Expected O, but got I4
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		if (!_canUpdate)
		{
			return;
		}
		bool flag = frameIndex == 0;
		Renderer renderer;
		MaterialType type;
		if (!flag)
		{
			object obj = frameIndex - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 != 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
						Sprite sprite = default(Sprite);
						ArcadeSprite arcadeSprite = setFrame(sprite);
						ArcadeSprite arcadeSprite2 = setVisible(visible: true);
						Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
						((Renderer)_renderer).SetMaterial(material);
						ActivateBomb();
						goto IL_01a8;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
					Sprite sprite2 = default(Sprite);
					ArcadeSprite arcadeSprite3 = setFrame(sprite2);
					ArcadeSprite arcadeSprite4 = setVisible(visible: true);
					renderer = _renderer;
					type = MaterialType.Vfx;
					goto IL_024c;
				}
				object obj3 = "TP_VFX_Neutron03";
			}
			else
			{
				object obj3 = "TP_VFX_Neutron02";
			}
		}
		else
		{
			object obj3 = "TP_VFX_Neutron01";
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite3 = default(Sprite);
		ArcadeSprite arcadeSprite5 = setFrame(sprite3);
		ArcadeSprite arcadeSprite6 = setVisible(visible: true);
		renderer = _renderer;
		type = MaterialType.DefaultSprite;
		goto IL_024c;
		IL_01a8:
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		if (!((frameTime = num + frameTime) < 32f))
		{
			int num2 = frameIndex + 1;
			frameIndex = num2;
			frameTime = 0f;
		}
		return;
		IL_024c:
		Material material2 = MaterialManager.GetMaterial(type);
		renderer.SetMaterial(material2);
		goto IL_01a8;
	}

	private void ActivateBomb()
	{
		//IL_00f5: Expected I, but got O
		//IL_0158: Expected O, but got I4
		//IL_0166: Expected O, but got I4
		//IL_0174: Expected O, but got I4
		if (_isActivated)
		{
			return;
		}
		BaseBody baseBody = body;
		_isActivated = true;
		baseBody._enable = true;
		float duration;
		if (!_isUnionWeapon)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			if (renderer.width > renderer2.height)
			{
				duration = 1650f;
				goto IL_0219;
			}
		}
		float num = _weapon.PArea();
		duration = 400f;
		goto IL_0219;
		IL_0219:
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num2 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = duration;
			tweenConfig.scale = (float?)(object)1;
			tweenConfig.alpha = (float?)(object)1;
			tweenConfig.angle = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				//IL_001f: Expected O, but got I4
				ArcadeSprite arcadeSprite = setAlpha(0f);
				ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
				BaseBody baseBody2 = body;
				baseBody2._enable = false;
				Despawn();
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween tween = Tweens.Add(tweenConfig);
			_tween1 = tween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void PlaySfx()
	{
		//IL_0062: Expected O, but got I4
		//IL_0082: Expected O, but got F4
		//IL_00b0: Expected O, but got I4
		bool flag = !_isUnionWeapon;
		if (!flag)
		{
		}
		object obj = !flag;
		int maxInstances = 1;
		if (obj == null)
		{
			maxInstances = 3;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj2 = UnityEngine.Random.value;
		object obj3 = default(object);
		float num = (float)obj3 - 0.5f;
		float detune = num * 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_NeutronBomb, soundConfig, 200f, maxInstances, time);
	}

	public override void Despawn()
	{
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__11_0()
	{
		//IL_006d: Expected O, but got I4
		//IL_008d: Expected O, but got F4
		//IL_00bb: Expected O, but got I4
		bool flag = !_isUnionWeapon;
		if (!flag)
		{
		}
		object obj = !flag;
		int maxInstances = 1;
		if (obj == null)
		{
			maxInstances = 3;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj2 = UnityEngine.Random.value;
		object obj3 = default(object);
		float num = (float)obj3 - 0.5f;
		float detune = num * 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_NeutronBomb, soundConfig, 200f, maxInstances, time);
		_canUpdate = true;
	}

	private void _003CActivateBomb_003Eb__13_0()
	{
		//IL_001f: Expected O, but got I4
		ArcadeSprite arcadeSprite = setAlpha(0f);
		ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		BaseBody baseBody = body;
		baseBody._enable = false;
		Despawn();
	}
}
