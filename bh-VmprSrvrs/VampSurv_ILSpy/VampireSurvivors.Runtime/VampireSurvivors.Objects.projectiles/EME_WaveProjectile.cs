using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Events;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_WaveProjectile : Projectile
{
	private Tween _scaleTween;

	private float _saveVelX;

	private float _saveVelY;

	private Timer _bounceTimer;

	private bool _canBounce;

	protected override void Awake()
	{
		base.Awake();
		WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
	}

	protected override void OnDestroy()
	{
		if (body != null)
		{
			BaseBody baseBody = body;
			baseBody._gameObject = null;
		}
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_006c: Expected O, but got I4
		//IL_0092: Expected O, but got I4
		//IL_0092: Expected O, but got I4
		//IL_0172: Expected I4, but got O
		//IL_030d: Expected O, but got F4
		//IL_037d: Expected O, but got Ref
		//IL_01ec: Expected I, but got O
		//IL_039b->IL02bd: Incompatible stack heights: 1 vs 0
		//IL_03b8->IL02bd: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_objectsHit != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			_speed = 1f;
			_canBounce = true;
			SetScaleToArea(0.5f);
			BaseBody baseBody = base.body;
			if (base.body != null)
			{
				baseBody._bounce = (float2)1065353216;
				_ = 1065353216;
				_isCullable = false;
				setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
				Weapon weapon2 = _weapon;
				if ((object)_weapon != null)
				{
					VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null && base.body != null)
					{
						Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
						BaseBody baseBody2 = base.body;
						if (base.body != null)
						{
							baseBody2._onWorldBounds = true;
							Transform transform = base.AimForRandomEnemy();
							int num = (int)_cachedTransform;
							object obj = UnityEngine.Random.value;
							Vector3 euler = default(Vector3);
							Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdi_v8 (System.Int32)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdi_v8 (System.Int32)+10]");
							Quaternion value = default(Quaternion);
							Transform.set_localRotation_Injected((IntPtr)0, ref value);
							if (_scaleTween != null)
							{
								TweenExtensions.Kill(_scaleTween);
							}
							TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&euler), 0.5f);
							if ((object)_weapon != null)
							{
								float num2 = _weapon.PDuration();
								float delay = (float)Vector3.zeroVector * 0.001f;
								TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, delay);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v741 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_WaveProjectile>)+370]");
								TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
								nint num3 = (nint)this;
								if (tweenerCore != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ rax_v45 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ rax_v45 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
										if ((nint)0 != 0)
										{
											_ = 1;
											_ = 0;
										}
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								if (tweenerCore != null)
								{
									_scaleTween = tweenerCore;
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

	public override void InternalUpdate()
	{
		//IL_001c: Expected F4, but got O
		//IL_006a: Expected F4, but got I
		BaseBody baseBody = body;
		float saveVelX = (float)baseBody._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187245504h\"");
		if ((object)baseBody._velocity == null)
		{
			saveVelX = _saveVelX;
		}
		_saveVelX = saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1 (BaseBody)+74]");
		float saveVelY = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187245525h\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1 (BaseBody)+74]");
		if ((nint)0 == 0)
		{
			saveVelY = _saveVelY;
		}
		_saveVelY = saveVelY;
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_015a: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		bool flag = default(bool);
		if (!flag && _canBounce != flag)
		{
			_canBounce = flag;
			if (_bounceTimer != null)
			{
				_bounceTimer.Cancel();
			}
			Action onComplete = delegate
			{
				_canBounce = true;
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer bounceTimer = Timers.Register(0.030000001f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_bounceTimer = bounceTimer;
			BaseBody baseBody = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
			object obj = default(object);
			float num = (float)obj * -1f;
			object obj2 = default(object);
			float num2 = (float)obj2 * -1f;
			float projectileSpeed = base.ProjectileSpeed;
			object obj3 = default(object);
			float num3 = num * (float)obj3;
			float num4 = num2 * (float)obj3;
			ArcadeSprite sprite = _sprite;
			BaseBody baseBody2 = sprite.body;
			baseBody2._velocity = (float2)num3;
		}
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_004b: Expected O, but got I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_00e2: Expected O, but got I8
		//IL_01f5: Expected O, but got I4
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected O, but got Unknown
		//IL_00b1: Expected O, but got I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00c7: Expected O, but got I4
		//IL_0163: Expected O, but got I8
		//IL_0132: Expected O, but got I4
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0148: Expected O, but got I4
		//IL_0189: Expected O, but got F4
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
				goto IL_018f;
			}
		}
		obj5 = 4294967295L;
		goto IL_018f;
		IL_0210:
		object obj6;
		float saveVelY = (float)obj6 * _saveVelY;
		_saveVelY = saveVelY;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)_saveVelX;
		return;
		IL_018f:
		float saveVelX = (float)obj5 * _saveVelX;
		_saveVelX = saveVelX;
		int num3 = tile._data & 1;
		bool flag7 = num3 == 0;
		bool flag8 = num3 < 0;
		bool flag9 = !flag8;
		object obj7 = !flag7;
		object obj8 = flag9 & obj7;
		if (obj8 == null)
		{
			int num4 = tile._data & 2;
			bool flag10 = num4 == 0;
			bool flag11 = num4 < 0;
			bool flag12 = !flag11;
			object obj9 = !flag12;
			object obj10 = obj9 | flag10;
			obj6 = 1;
			if (obj10 != null)
			{
				goto IL_0210;
			}
		}
		obj6 = 4294967295L;
		goto IL_0210;
	}

	private void Bounce(Body bdy, bool up, bool down, bool left, bool right)
	{
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		_scaleTween = null;
		base.Despawn();
	}

	private void _003COnHasHitAnObject_003Eb__9_0()
	{
		_canBounce = true;
	}
}
