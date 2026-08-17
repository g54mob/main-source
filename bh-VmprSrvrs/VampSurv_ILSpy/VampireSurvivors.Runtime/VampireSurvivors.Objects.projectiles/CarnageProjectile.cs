using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Events;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class CarnageProjectile : Projectile
{
	private TrailRenderer _Trail;

	private Tween _expireTimer;

	private Tween _explodeTimer;

	private bool _canExplode;

	private float _saveVelX;

	private float _saveVelY;

	private int _exploIndex;

	protected override void Awake()
	{
		base.Awake();
		WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		//IL_0206: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = base.body.setCircle(8f, (float?)(object)0, (float?)(object)0);
		_speed = 1.1f;
		Transform targetTransform = base.AimForRandomEnemy();
		_targetTransform = targetTransform;
		SetScaleToArea();
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		_exploIndex = 0;
		_canExplode = true;
		setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
		Weapon weapon2 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
		BaseBody baseBody2 = base.body;
		baseBody2._onWorldBounds = true;
		_isCullable = false;
		if (_expireTimer != null)
		{
			TweenExtensions.Kill(_expireTimer);
		}
		float num = _weapon.PDuration();
		TweenCallback callback = FadeOutAndDispose;
		object obj = default(object);
		float delay = (float)obj * 0.001f;
		Tween tween = DOVirtual.DelayedCall(delay, callback, ignoreTimeScale: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		tween.stringId = "DefaultGameTweenId";
		_expireTimer = tween;
		SetupTrails();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MagicMissile, soundConfig, 200f, 10, time);
	}

	public override void InternalUpdate()
	{
		//IL_003c: Expected O, but got I4
		//IL_0098: Expected F4, but got O
		//IL_00e6: Expected F4, but got I
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num = renderer.pixelHeight >> 31;
		object obj = renderer.pixelHeight - num;
		object obj2 = obj >> 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int sortingOrder = default(int);
		_renderer.sortingOrder = sortingOrder;
		_Trail.sortingOrder = sortingOrder;
		BaseBody baseBody = body;
		float saveVelX = (float)baseBody._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018700BEB5h\"");
		if ((object)baseBody._velocity == null)
		{
			saveVelX = _saveVelX;
		}
		_saveVelX = saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v15 (BaseBody)+74]");
		float saveVelY = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018700BED6h\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v15 (BaseBody)+74]");
		if ((nint)0 == 0)
		{
			saveVelY = _saveVelY;
		}
		_saveVelY = saveVelY;
	}

	public override void SetTarget(Transform target)
	{
		//IL_0074: Expected I, but got O
		//IL_0134: Expected F4, but got O
		_targetTransform = target;
		Weapon weapon = _weapon;
		Transform playerTransform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
		float num = AngleFromTargetRadians(target, playerTransform);
		int[] array = new int[10] { 10, -10, 20, -20, 30, -30, 40, -40, 50, -50 };
		int num2 = _indexInWeapon % array.Length;
		nint num3 = (nint)this;
		float projectileSpeed = base.ProjectileSpeed;
		float num4 = (float)array[num2] * ((float)Math.PI / 180f);
		float rotation = num4 + num;
		Vector2 vector = SetVelocityFromRotation(rotation, num);
		CarnageProjectile cachedTransform = (CarnageProjectile)(object)_cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Vector3 axis = default(Vector3);
		Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_0050: Expected O, but got I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_00e7: Expected O, but got I8
		//IL_0233: Expected O, but got I4
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_00b6: Expected O, but got I4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00cc: Expected O, but got I4
		//IL_0168: Expected O, but got I8
		//IL_0137: Expected O, but got I4
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_014d: Expected O, but got I4
		//IL_018e: Expected O, but got F4
		//IL_02ba: Expected I, but got O
		int num = tile._data & 8;
		bool flag = num == 0;
		bool flag2 = num < 0;
		bool flag3 = !flag2;
		object obj = !flag;
		object obj2 = flag3 & obj;
		object obj5;
		if (obj2 == null)
		{
			int num2 = tile._data & 4;
			bool flag4 = num2 == 0;
			bool flag5 = num2 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag6;
			object obj4 = obj3 | flag4;
			obj5 = 1;
			if (obj4 != null)
			{
				goto IL_01cd;
			}
		}
		obj5 = 4294967295L;
		goto IL_01cd;
		IL_024e:
		object obj6;
		float saveVelY = (float)obj6 * _saveVelY;
		_saveVelY = saveVelY;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)_saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		PhaserTile cachedTransform = (PhaserTile)(object)_cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Vector3 euler = default(Vector3);
		Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
		bool flag7 = (object)cachedTransform.position == null;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected((IntPtr)cachedTransform.position, ref value);
		Explode();
		return;
		IL_01cd:
		float saveVelX = (float)obj5 * _saveVelX;
		_saveVelX = saveVelX;
		int num3 = tile._data & 1;
		bool flag8 = num3 == 0;
		bool flag9 = num3 < 0;
		bool flag10 = !flag9;
		object obj7 = !flag8;
		object obj8 = flag10 & obj7;
		if (obj8 == null)
		{
			int num4 = tile._data & 2;
			bool flag11 = num4 == 0;
			bool flag12 = num4 < 0;
			bool flag13 = !flag12;
			object obj9 = !flag13;
			object obj10 = obj9 | flag11;
			obj6 = 1;
			if (obj10 != null)
			{
				goto IL_024e;
			}
		}
		obj6 = 4294967295L;
		goto IL_024e;
	}

	public void Bounce(Body b, bool up, bool down, bool left, bool right)
	{
		if (body == b)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			Explode();
		}
	}

	private void SetupTrails()
	{
		//IL_0209->IL019c: Incompatible stack heights: 2 vs 0
		//IL_011d->IL019c: Incompatible stack heights: 2 vs 0
		//IL_0168->IL019c: Incompatible stack heights: 2 vs 0
		//IL_0259->IL019c: Incompatible stack heights: 3 vs 0
		Sprite sprite = SpriteManager.GetSprite("PfxLine", "vfx");
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			object obj = default(object);
			float num2 = (float)obj * 0.018f;
			if ((object)_Trail != null)
			{
				_Trail.time = 0.5f;
				TrailRenderer trail = _Trail;
				if ((object)_Trail != null)
				{
					bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
					Color value = default(Color);
					TrailRenderer.set_endColor_Injected(((UnityEngine.Object)trail).m_CachedPtr, ref value);
					bool flag2 = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
					Color value2 = default(Color);
					TrailRenderer.set_startColor_Injected(((UnityEngine.Object)trail).m_CachedPtr, ref value2);
					if ((object)_Trail != null)
					{
						_Trail.endWidth = num2;
						_Trail.startWidth = num2;
						RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_Trail, sprite, true);
						if ((object)_Trail != null)
						{
							Material material = ((Renderer)_Trail).GetMaterial();
							RenderingExtensions.SetAlpha(material, 0.6f);
							Renderer trail2 = _Trail;
							if ((object)_Trail != null)
							{
								bool flag3 = ((UnityEngine.Object)trail2).m_CachedPtr == (IntPtr)0;
								TrailRenderer.Clear_Injected(((UnityEngine.Object)trail2).m_CachedPtr);
								if ((object)_Trail != null)
								{
									_Trail.emitting = true;
									TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
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

	private void FadeOutAndDispose()
	{
		//IL_0148: Expected I, but got O
		Material material = ((Renderer)_Trail).GetMaterial();
		TweenerCore<Color, Color, ColorOptions> tweenerCore = ShortcutExtensions.DOFade(material, 0f, 0.1f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_renderer, 0f, 0.1f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v389 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CarnageProjectile>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v10 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T14_JEWELS))
		{
			bool flag = TryFreeze(other);
		}
	}

	private void Explode()
	{
		//IL_022d: Expected O, but got I4
		//IL_00ee: Expected I, but got O
		//IL_00f6: Expected I, but got O
		//IL_0106: Expected O, but got I
		//IL_0377: Expected O, but got I4
		//IL_0186: Expected O, but got I4
		//IL_0142: Expected O, but got I
		//IL_02bd: Expected O, but got I4
		//IL_0178: Expected O, but got I4
		//IL_0397: Expected O, but got I4
		//IL_01c9: Expected O, but got I
		if (!_canExplode)
		{
			return;
		}
		_canExplode = false;
		if (_explodeTimer != null)
		{
			TweenExtensions.Kill(_explodeTimer);
		}
		TweenCallback callback = delegate
		{
			_canExplode = true;
		};
		Tween tween = DOVirtual.DelayedCall(0.2f, callback, ignoreTimeScale: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		tween.stringId = "DefaultGameTweenId";
		_explodeTimer = tween;
		Weapon weapon = _weapon;
		if ((object)_weapon == null)
		{
			goto IL_01d2;
		}
		nint num = (nint)typeof(CarnageWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.CarnageWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.CarnageWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ rax_v32+FFFFFFF8+v388 @ rax_v24*8]");
			if (0 == (nint)typeof(CarnageWeapon))
			{
				obj3 = 1;
				goto IL_033a;
			}
		}
		obj3 = 0;
		goto IL_033a;
		IL_033a:
		bool flag = obj3 == null;
		Weapon weapon2 = null;
		if (!flag)
		{
			weapon2 = _weapon;
		}
		if ((object)weapon2 != null)
		{
			float2 pos = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rax_v27 (VampireSurvivors.Objects.Weapons.Weapon)+178]");
			Projectile projectile = ((BulletPool)0).SpawnAt(pos, _weapon);
		}
		goto IL_01d2;
		IL_01d2:
		int exploIndex = _exploIndex + 1;
		_exploIndex = exploIndex;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		int num4 = _exploIndex & 1;
		bool flag2 = num4 == 0;
		object obj4 = !flag2;
		float detune = ((obj4 != null) ? (-1000f) : 1000f);
		soundConfig.Detune = detune;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ExploGH2, soundConfig, 200f, 4, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Rate = 1f;
		int num5 = _exploIndex & 1;
		bool flag3 = num5 == 0;
		object obj5 = !flag3;
		float detune2 = ((obj5 != null) ? 900f : (-900f));
		soundConfig2.Detune = detune2;
		soundConfig2.Volume = (float?)(object)1;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.ExploGH2, soundConfig2, 200f, 4, time);
	}

	public override void Despawn()
	{
		TrailRenderer trail = _Trail;
		bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
		TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
		_Trail.emitting = false;
		_isCullable = true;
		base.Despawn();
	}

	private void _003CExplode_003Eb__16_0()
	{
		_canExplode = true;
	}
}
