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
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Neutron2_Projectile : Projectile
{
	private TrailRenderer _Trail;

	private const float Radius = 8f;

	private Timer _expireTimer;

	private Timer _explodeTimer;

	private bool _canExplode;

	private float _saveVelX;

	private float _saveVelY;

	private int _exploIndex;

	protected override void Awake()
	{
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0092: Expected O, but got I4
		//IL_0092: Expected O, but got I4
		//IL_01cc: Expected O, but got I4
		//IL_020c: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = base.body.setCircle(8f, (float?)(object)1, (float?)(object)1);
		_speed = 1.1f;
		Transform targetTransform = base.AimForRandomEnemy();
		_targetTransform = targetTransform;
		SetScaleToArea();
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
			_expireTimer.Cancel();
		}
		float num = _weapon.PDuration();
		Action onComplete = FadeOutAndDispose;
		object obj = default(object);
		float duration = (float)obj * 0.001f;
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		SetupTrails();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MagicMissile, soundConfig, 200f, 10, flag ? 1 : 0);
	}

	public override void InternalUpdate()
	{
		//IL_003c: Expected O, but got I4
		//IL_0084: Expected F4, but got O
		//IL_00d2: Expected F4, but got I
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num = renderer.pixelHeight >> 31;
		object obj = renderer.pixelHeight - num;
		object obj2 = obj >> 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int sortingOrder = default(int);
		_Trail.sortingOrder = sortingOrder;
		BaseBody baseBody = body;
		float saveVelX = (float)baseBody._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018713CE8Fh\"");
		if ((object)baseBody._velocity == null)
		{
			saveVelX = _saveVelX;
		}
		_saveVelX = saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v14 (BaseBody)+74]");
		float saveVelY = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018713CEB0h\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v14 (BaseBody)+74]");
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
		TP_Neutron2_Projectile cachedTransform = (TP_Neutron2_Projectile)(object)_cachedTransform;
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FA19]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("PfxLine", "vfx");
		float num = _weapon.PArea();
		object obj = default(object);
		float num2 = (float)obj * 0.018f;
		_Trail.time = 0.5f;
		TrailRenderer trail = _Trail;
		bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
		Color value = default(Color);
		TrailRenderer.set_endColor_Injected(((UnityEngine.Object)trail).m_CachedPtr, ref value);
		bool flag2 = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
		Color value2 = default(Color);
		TrailRenderer.set_startColor_Injected(((UnityEngine.Object)trail).m_CachedPtr, ref value2);
		_Trail.endWidth = num2;
		_Trail.startWidth = num2;
		RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_Trail, sprite, true);
		Material material = ((Renderer)_Trail).GetMaterial();
		RenderingExtensions.SetAlpha(material, 0.6f);
		object trail2 = _Trail;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rdi_v10 (System.Object)+10]");
		bool flag3 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rdi_v10 (System.Object)+10]");
		TrailRenderer.Clear_Injected((IntPtr)0);
		_Trail.emitting = true;
		TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
	}

	private void FadeOutAndDispose()
	{
		//IL_009e: Expected I, but got O
		Material material = ((Renderer)_Trail).GetMaterial();
		TweenerCore<Color, Color, ColorOptions> tweenerCore = ShortcutExtensions.DOFade(material, 0f, 0.1f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Neutron2_Projectile>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
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
		//IL_020c: Expected O, but got I4
		//IL_00cd: Expected I, but got O
		//IL_00d5: Expected I, but got O
		//IL_00e5: Expected O, but got I
		//IL_034b: Expected O, but got I4
		//IL_0165: Expected O, but got I4
		//IL_0252: Expected F4, but got I4
		//IL_0121: Expected O, but got I
		//IL_029c: Expected O, but got I4
		//IL_0174: Expected I4, but got O
		//IL_0157: Expected O, but got I4
		//IL_036b: Expected O, but got I4
		//IL_02e2: Expected F4, but got I4
		//IL_01a8: Expected O, but got I
		if (!_canExplode)
		{
			return;
		}
		_canExplode = false;
		if (_explodeTimer != null)
		{
			_explodeTimer.Cancel();
		}
		Action onComplete = delegate
		{
			_canExplode = true;
		};
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer explodeTimer = Timers.Register(0.2f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_explodeTimer = explodeTimer;
		Weapon weapon = _weapon;
		if ((object)_weapon == null)
		{
			goto IL_01b1;
		}
		nint num = (nint)typeof(TP_Neutron2_Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Neutron2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Neutron2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rax_v28+FFFFFFF8+v296 @ rax_v19*8]");
			if (0 == (nint)typeof(TP_Neutron2_Weapon))
			{
				obj3 = 1;
				goto IL_030a;
			}
		}
		obj3 = 0;
		goto IL_030a;
		IL_01b1:
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
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ExploGH2, soundConfig, 300f, 3, flag ? 1 : 0);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Rate = 1f;
		int num5 = _exploIndex & 1;
		bool flag3 = num5 == 0;
		object obj5 = !flag3;
		float detune2 = ((obj5 != null) ? 900f : (-900f));
		soundConfig2.Detune = detune2;
		soundConfig2.Volume = (float?)(object)1;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.ExploGH2, soundConfig2, 300f, 3, flag ? 1 : 0);
		return;
		IL_030a:
		bool flag4 = obj3 == null;
		bool flag5 = false;
		if (!flag4)
		{
			flag5 = (byte)(int)_weapon != 0;
		}
		if (flag5)
		{
			float2 pos = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rax_v22 (System.Boolean)+178]");
			Projectile projectile = ((BulletPool)0).SpawnAt(pos, _weapon);
		}
		goto IL_01b1;
	}

	public override void Despawn()
	{
		TrailRenderer trail = _Trail;
		bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
		TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
		_Trail.emitting = false;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_explodeTimer != null)
		{
			_explodeTimer.Cancel();
		}
		_isCullable = true;
		base.Despawn();
	}

	private void _003CExplode_003Eb__17_0()
	{
		_canExplode = true;
	}
}
