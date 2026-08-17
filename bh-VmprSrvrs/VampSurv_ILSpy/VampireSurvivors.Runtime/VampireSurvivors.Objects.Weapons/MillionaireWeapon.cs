using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class MillionaireWeapon : Weapon, IMillionaire
{
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public MillionaireWeapon _003C_003E4__this;

		public float x;

		public float y;

		public bool left;

		public int amount;

		public Action _003C_003E9__0;

		internal void _003CMillionaire_003Eb__0()
		{
			//IL_0066: Expected I, but got O
			//IL_0074: Expected I, but got O
			//IL_0084: Expected O, but got I
			//IL_0104: Expected O, but got I4
			//IL_00c0: Expected O, but got I
			//IL_00f6: Expected O, but got I4
			if (amount <= 0)
			{
				return;
			}
			int num = 0;
			float2 pos = default(float2);
			do
			{
				Projectile projectile = _003C_003E4__this.SpawnExplosionAt(pos, num, 1, 0f);
				MillionaireProjectile millionaireProjectile;
				if ((object)projectile == null)
				{
					millionaireProjectile = null;
					goto IL_01d5;
				}
				nint num2 = (nint)projectile;
				nint num3 = (nint)typeof(MillionaireProjectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MillionaireProjectile>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MillionaireProjectile>)+130]");
				object obj3;
				if (num4 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rax_v25+FFFFFFF8+v224 @ rax_v21*8]");
					if (0 == (nint)typeof(MillionaireProjectile))
					{
						obj3 = 1;
						goto IL_01ae;
					}
				}
				obj3 = 0;
				goto IL_01ae;
				IL_01ae:
				bool flag = obj3 == null;
				millionaireProjectile = null;
				if (!flag)
				{
					millionaireProjectile = (MillionaireProjectile)projectile;
				}
				goto IL_01d5;
				IL_01d5:
				if ((object)millionaireProjectile != null && ((UnityEngine.Object)millionaireProjectile).m_CachedPtr != (IntPtr)0)
				{
					millionaireProjectile.SetDisplayDirection(left);
				}
				num++;
			}
			while (num < amount);
		}
	}

	private PhaserSprite _rays1;

	private PhaserSprite _rays2;

	private float _coinsQueue;

	private float _coinsTime;

	private const float CoinsDelay = 0.1f;

	private MultiTargetTween _rays1Tween;

	private MultiTargetTween _rays2Tween;

	private Timer _rangedAnimEvent;

	private Action<float> _onCoinPickupCallback;

	public override float PPower()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		bool flag = _currentWeaponData == null;
		float num2 = default(float);
		float num = num2;
		if (!flag)
		{
			float num3 = base.PAmount();
			bool flag2 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
			num = num2;
			if (!flag2)
			{
				num = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num4 = num2 * currentWeaponData._003Cpower_003Ek__BackingField;
					float num5 = num4 * num;
					return num + num5;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnStart()
	{
		base.OnStart();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x1873AAEF0\"");
	}

	public void PlayNextRangedAnim()
	{
		if (_rangedAnimEvent != null)
		{
			_rangedAnimEvent.Cancel();
		}
		float num = base.PInterval();
		Action onComplete = delegate
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
			{
				((Equipment)this)._003COwner_003Ek__BackingField.OnRangedAttackAnim();
			}
		};
		object obj = default(object);
		float num2 = (float)obj - 120f;
		float duration = num2 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer rangedAnimEvent = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_rangedAnimEvent = rangedAnimEvent;
	}

	protected unsafe override void FakeConstruct()
	{
		//IL_0047: Expected O, but got I4
		//IL_006f: Expected O, but got Ref
		//IL_0175: Expected O, but got I4
		//IL_019d: Expected O, but got Ref
		base.FakeConstruct();
		_explosionType = WeaponType.SEC_MILLIONAIRE;
		base._003CCanCrit_003Ek__BackingField = true;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, pos, "vfx", "rays");
		PhaserSprite phaserSprite2 = phaserSprite.setOrigin(0f, (float?)(object)1);
		Transform transform = phaserSprite2.transform;
		Vector2 vector = default(Vector2);
		transform.localEulerAngles = (Vector3)(&vector);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene2._renderer;
			float x = renderer.width * 0.5f;
			PhaserSprite component = phaserSprite2.setPosition(x, 0f);
			PhaserSprite phaserSprite3 = RenderingExtensions.SetScrollFactor(component, 0f);
			PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Add);
			PhaserSprite phaserSprite5 = phaserSprite4.setAlpha(0f);
			PhaserSprite rays = phaserSprite5.setTint(16776960u);
			_rays1 = rays;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				PhaserSprite phaserSprite6 = RenderingExtensions.sprite(s_scene3.add, pos, "vfx", "rays");
				PhaserSprite phaserSprite7 = phaserSprite6.setOrigin(0f, (float?)(object)1);
				Transform transform2 = phaserSprite7.transform;
				transform2.localEulerAngles = (Vector3)(&vector);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene4 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer2 = s_scene4._renderer;
					float x2 = renderer2.width * 0.5f;
					PhaserSprite component2 = phaserSprite7.setPosition(x2, 0f);
					PhaserSprite phaserSprite8 = RenderingExtensions.SetScrollFactor(component2, 0f);
					PhaserSprite phaserSprite9 = phaserSprite8.setBlendMode(BlendMode.Add);
					PhaserSprite phaserSprite10 = phaserSprite9.setAlpha(0f);
					PhaserSprite rays2 = phaserSprite10.setTint(16764159u);
					_rays2 = rays2;
					Action<float> action = null;
					PhaserSprite phaserSprite11 = RenderingExtensions.SetScrollFactor((PhaserSprite)(object)action, 0f, fullscreen: false);
					_onCoinPickupCallback = action;
					GameManager core = GM.Core;
					PhaserSprite phaserSprite12 = RenderingExtensions.SetScrollFactor((PhaserSprite)(object)core._003COnCoinPickup_003Ek__BackingField, 0f, fullscreen: false);
					_coinsQueue = 0f;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void OnCoinPickup(float value = 1f)
	{
		float coinsQueue = value + _coinsQueue;
		_coinsQueue = coinsQueue;
	}

	public override void Cleanup()
	{
		base.Cleanup();
		GameManager core = GM.Core;
		List<Action<float>> list = core._003COnCoinPickup_003Ek__BackingField;
		if (list._size != 0)
		{
			int num = Array.IndexOf((object[])list._items, (object)_onCoinPickupCallback, 0, list._size);
			if (num != -1)
			{
				GameManager core2 = GM.Core;
				bool flag = ((List<object>)(object)core2._003COnCoinPickup_003Ek__BackingField).Remove((object)_onCoinPickupCallback);
			}
		}
		if (_lastShotTimer != null)
		{
			_lastShotTimer.Cancel();
		}
		if (_rangedAnimEvent != null)
		{
			_rangedAnimEvent.Cancel();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0048: Invalid comparison between F4 and O
		//IL_007a: Expected F4, but got O
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
		PlayNextRangedAnim();
		float num = base.PInterval();
		bool flag = (object)_lastFiringInterval == (object)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873AB8E0h\"");
		if (!flag)
		{
			float num2 = base.PInterval();
			_lastFiringInterval = (float)vector;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public void Millionaire(float x, float y, float angle, int times = 4)
	{
		//IL_0067: Expected I4, but got F4
		//IL_0088: Invalid comparison between O and F4
		//IL_00ab: Invalid comparison between F4 and I4
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_03fb: Expected I4, but got O
		//IL_04f7: Expected O, but got I4
		//IL_01af: Expected O, but got I
		//IL_01ea: Expected I, but got O
		//IL_01f8: Expected I, but got O
		//IL_0208: Expected O, but got I
		//IL_0288: Expected O, but got I4
		//IL_0244: Expected O, but got I
		//IL_0295: Expected I4, but got O
		//IL_027a: Expected O, but got I4
		//IL_02e2: Expected O, but got I4
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals22 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals22._003C_003E4__this = this;
		float num = default(float);
		CS_0024_003C_003E8__locals22.x = num;
		CS_0024_003C_003E8__locals22.y = y;
		float num2 = base.PAmount();
		float x2 = CS_0024_003C_003E8__locals22.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		CS_0024_003C_003E8__locals22.amount = (int)num2;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)CS_0024_003C_003E8__locals22.x);
		float num3 = (float)position - CS_0024_003C_003E8__locals22.x;
		bool flag2 = num3 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool left = flag4 & flag3;
		CS_0024_003C_003E8__locals22.left = left;
		WeaponData currentWeaponData = _currentWeaponData;
		currentWeaponData._003CsecondaryPower_003Ek__BackingField = currentWeaponData._003Cpower_003Ek__BackingField;
		object obj2 = default(object);
		object obj = obj2 * CS_0024_003C_003E8__locals22.amount;
		if ((nint)obj > 0)
		{
			bool flag5 = false;
			float num4 = num;
			bool flag8 = default(bool);
			IntPtr intPtr = default(IntPtr);
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			bool flag10;
			do
			{
				WeaponData currentWeaponData2 = _currentWeaponData;
				object obj3 = flag5 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
				Action action;
				if ((nint)obj3 <= 0)
				{
					bool flag6 = false;
					while (true)
					{
						bool flag7 = (flag6 ? 1 : 0) >= CS_0024_003C_003E8__locals22.amount;
						action = (Action)flag8;
						if (flag7)
						{
							break;
						}
						num = CS_0024_003C_003E8__locals22.y;
						Projectile projectile = base.SpawnExplosionAt((float2)(nint)intPtr, flag6 ? 1 : 0, 1, 0f);
						if ((object)projectile == null)
						{
							flag8 = false;
							goto IL_04bf;
						}
						nint num5 = (nint)projectile;
						nint num6 = (nint)typeof(MillionaireProjectile);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MillionaireProjectile>)+130]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						nint num7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MillionaireProjectile>)+130]");
						object obj6;
						if (num7 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ rax_v50+FFFFFFF8+v688 @ rax_v46*8]");
							if (0 == (nint)typeof(MillionaireProjectile))
							{
								obj6 = 1;
								goto IL_0493;
							}
						}
						obj6 = 0;
						goto IL_0493;
						IL_04bf:
						if (flag8)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v526 @ rbx_v9 (System.Boolean)+10]");
							if ((nint)0 != 0)
							{
								((MillionaireProjectile)flag8).SetDisplayDirection(CS_0024_003C_003E8__locals22.left);
							}
						}
						flag6 = (byte)((flag6 ? 1u : 0u) + 1u) != 0;
						continue;
						IL_0493:
						bool flag9 = obj6 == null;
						flag8 = false;
						if (!flag9)
						{
							flag8 = (byte)(int)projectile != 0;
						}
						goto IL_04bf;
					}
				}
				else
				{
					action = CS_0024_003C_003E8__locals22._003C_003E9__0;
					num4 = currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
					if (CS_0024_003C_003E8__locals22._003C_003E9__0 == null)
					{
						action = (CS_0024_003C_003E8__locals22._003C_003E9__0 = delegate
						{
							//IL_0066: Expected I, but got O
							//IL_0074: Expected I, but got O
							//IL_0084: Expected O, but got I
							//IL_0104: Expected O, but got I4
							//IL_00c0: Expected O, but got I
							//IL_00f6: Expected O, but got I4
							if (CS_0024_003C_003E8__locals22.amount > 0)
							{
								int num9 = 0;
								float2 pos = default(float2);
								do
								{
									Projectile projectile2 = CS_0024_003C_003E8__locals22._003C_003E4__this.SpawnExplosionAt(pos, num9, 1, 0f);
									object obj9;
									if ((object)projectile2 != null)
									{
										nint num10 = (nint)projectile2;
										nint num11 = (nint)typeof(MillionaireProjectile);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MillionaireProjectile>)+130]");
										object obj7 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
										nint num12 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MillionaireProjectile>)+130]");
										if (num12 >= 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
											object obj8 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rax_v25+FFFFFFF8+v224 @ rax_v21*8]");
											if (0 == (nint)typeof(MillionaireProjectile))
											{
												obj9 = 1;
												goto IL_01ae;
											}
										}
										obj9 = 0;
										goto IL_01ae;
									}
									MillionaireProjectile millionaireProjectile = null;
									goto IL_01d5;
									IL_01ae:
									bool flag11 = obj9 == null;
									millionaireProjectile = null;
									if (!flag11)
									{
										millionaireProjectile = (MillionaireProjectile)projectile2;
									}
									goto IL_01d5;
									IL_01d5:
									if ((object)millionaireProjectile != null && ((UnityEngine.Object)millionaireProjectile).m_CachedPtr != (IntPtr)0)
									{
										millionaireProjectile.SetDisplayDirection(CS_0024_003C_003E8__locals22.left);
									}
									num9++;
								}
								while (num9 < CS_0024_003C_003E8__locals22.amount);
							}
						});
					}
					float num8 = (float)(flag5 ? 1 : 0) * num4;
					x2 = num8 * 0.001f;
					Timer lastShotTimer = Timers.Register(x2, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
				}
				flag5 = (byte)((flag5 ? 1u : 0u) + 1u) != 0;
				flag10 = (flag5 ? 1 : 0) < (nint)obj;
				flag8 = (byte)(int)action != 0;
			}
			while (flag10);
		}
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			int repeats = CS_0024_003C_003E8__locals22.amount + CS_0024_003C_003E8__locals22.amount;
			RaysVFX(CS_0024_003C_003E8__locals22.left, repeats);
		}
	}

	private unsafe void RaysVFX(bool left, int repeats)
	{
		//IL_00ab: Expected O, but got Ref
		//IL_00be: Expected O, but got I4
		//IL_01c6: Expected O, but got Ref
		//IL_01d9: Expected O, but got I4
		//IL_011b: Expected O, but got Ref
		//IL_04a2: Expected O, but got I4
		//IL_02e0: Expected I, but got O
		//IL_035f: Expected O, but got I4
		//IL_027f: Expected O, but got Ref
		//IL_03c9: Expected I, but got O
		//IL_041f: Expected O, but got I4
		if (_rays1Tween != null)
		{
			_rays1Tween.Kill();
		}
		if (_rays2Tween != null)
		{
			_rays2Tween.Kill();
		}
		object obj = default(object);
		object obj3 = default(object);
		float xScale;
		PhaserSprite phaserSprite6;
		if (!left)
		{
			PhaserSprite phaserSprite = RenderingExtensions.setPositionPixelsScrollFactor0(_rays1, -48f, -48f);
			PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
			Transform transform = phaserSprite2.transform;
			transform.localEulerAngles = (Vector3)(&obj);
			PhaserSprite phaserSprite3 = phaserSprite2.setScale(4f, (float?)(object)1);
			PhaserSprite phaserSprite4 = RenderingExtensions.setPositionPixelsScrollFactor0(_rays2, -48f, -48f);
			PhaserSprite phaserSprite5 = phaserSprite4.setAlpha(0f);
			Transform transform2 = phaserSprite5.transform;
			transform2.localEulerAngles = (Vector3)(&obj);
			object obj2 = obj3;
			xScale = 4f;
			float num = -48f;
			phaserSprite6 = phaserSprite5;
		}
		else
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float x = (float)renderer.pixelWidth + 48f;
			PhaserSprite phaserSprite7 = RenderingExtensions.setPositionPixelsScrollFactor0(_rays1, x, -48f);
			PhaserSprite phaserSprite8 = phaserSprite7.setAlpha(0f);
			Transform transform3 = phaserSprite8.transform;
			transform3.localEulerAngles = (Vector3)(&obj);
			PhaserSprite phaserSprite9 = phaserSprite8.setScale(8f, (float?)(object)1);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			float x2 = (float)renderer2.pixelWidth + 48f;
			PhaserSprite phaserSprite10 = RenderingExtensions.setPositionPixelsScrollFactor0(_rays2, x2, -48f);
			PhaserSprite phaserSprite11 = phaserSprite10.setAlpha(0f);
			Transform transform4 = phaserSprite11.transform;
			transform4.localEulerAngles = (Vector3)(&obj);
			object obj2 = obj3;
			xScale = 8f;
			float num = -48f;
			phaserSprite6 = phaserSprite11;
		}
		PhaserSprite phaserSprite12 = phaserSprite6.setScale(xScale, (float?)(object)1);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_rays1 != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = repeats;
		tweenConfig.duration = 50f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween rays1Tween = Tweens.Add(tweenConfig);
		_rays1Tween = rays1Tween;
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_rays2 != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.yoyo = true;
		tweenConfig2.repeat = repeats;
		tweenConfig2.duration = 50f;
		MultiTargetTween rays2Tween = Tweens.Add(tweenConfig2);
		_rays2Tween = rays2Tween;
	}

	public override void InternalUpdate()
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_00b3: Expected O, but got I4
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		if (!((_coinsTime = deltaTime + _coinsTime) < 0.1f))
		{
			_coinsTime = 0f;
			if (!(_coinsQueue < 1f))
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
				float coinsQueue = _coinsQueue - 1f;
				_coinsQueue = coinsQueue;
				bool flag = 0 < (nint)characterController._lastFacingDirection;
				object obj = 0 - characterController._lastFacingDirection;
				bool flag2 = obj == null;
				bool flag3 = !flag;
				bool flag4 = !flag2;
				object obj2 = flag4 & flag3;
				PhaserScene s_scene = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer = s_scene._renderer;
				float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				float num = renderer.width * 0.25f;
				object obj3 = obj2 ^ 1;
				object obj4 = obj3 * 2;
				object obj5 = obj4 - 1;
				float num2 = (float)obj5 * num;
				float x = num2 + (float)position;
				float y = default(float);
				int times = default(int);
				Millionaire(x, y, 0f, times);
			}
		}
	}

	public override void CheckArcanas()
	{
		//IL_008e: Expected O, but got I4
		//IL_0097: Expected O, but got I4
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj > -1)
		{
			WeaponData currentWeaponData = _currentWeaponData;
			currentWeaponData._003Cpenetrating_003Ek__BackingField = 65535;
			List<Collider> wallsColliders = _wallsColliders;
			_bounces = 3;
			object obj2 = 0;
			object obj3 = 0;
			while ((nint)obj3 < wallsColliders._size)
			{
				List<Collider> wallsColliders2 = _wallsColliders;
				if ((nint)obj2 < wallsColliders2._size)
				{
					Collider[] items = wallsColliders2._items;
					World world = ArcadePhysics.s_world.removeCollider(items[obj2]);
					wallsColliders = _wallsColliders;
					obj2++;
					obj3 = obj2;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			WeaponData currentWeaponData2 = _currentWeaponData;
			currentWeaponData2._003ChitsWalls_003Ek__BackingField = false;
		}
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager2 = gameMan._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			if ((nint)obj4 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		CheckBeginningArcana();
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		if (base._003CCanCrit_003Ek__BackingField)
		{
			base.StandardCritical(second, first);
			return false;
		}
		return base.OnBulletOverlapsEnemy(context, second, first);
	}

	public unsafe void FireVolley(Vector2 pos, int _amount, Transform target = null)
	{
		//IL_0012: Expected F4, but got O
		//IL_0062: Expected O, but got I4
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00b4: Expected O, but got I4
		//IL_010f: Expected I, but got O
		//IL_011d: Expected I, but got O
		//IL_012d: Expected O, but got I
		//IL_01ad: Expected O, but got I4
		//IL_0169: Expected O, but got I
		//IL_019f: Expected O, but got I4
		//IL_0235: Expected I, but got O
		//IL_02cc: Expected O, but got I
		//IL_04c3: Expected F4, but got O
		//IL_048c->IL041c: Incompatible stack heights: 1 vs 0
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = (float)characterController._lastMovementDirection;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
			float num2 = 0f * 57.29578f;
			if (_amount <= 0)
			{
				return;
			}
			object obj = _amount - 3;
			object obj2 = obj >> 31;
			object obj3 = obj - obj2;
			object obj4 = obj3 >> 1;
			object obj5 = obj4 * 4;
			object obj6 = obj4 + obj5;
			object obj7 = _amount - 1;
			float num3 = (float)obj6 + 25f;
			int num4 = 0;
			BulletPool pool = default(BulletPool);
			object obj11 = default(object);
			Vector3 axis = default(Vector3);
			Quaternion value = default(Quaternion);
			while (true)
			{
				float num5 = ((!(num3 > 45f)) ? num3 : 45f);
				float num6 = num5 / (float)_amount;
				float num7 = (float)num4 * num6;
				float num8 = num6 * 0.5f;
				float num9 = num7 + num2;
				float num10 = num8 * (float)obj7;
				float num11 = num9 - num10;
				Projectile projectile = base.FireOneProjectile(pos, num4, target, pool);
				Component component;
				int num12;
				Vector2 vector;
				if ((object)projectile == null)
				{
					num12 = num4;
					component = null;
					vector = pos;
					goto IL_03ff;
				}
				nint num13 = (nint)projectile;
				nint num14 = (nint)typeof(FlashArrowProjectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FlashArrowProjectile>)+130]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v567 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FlashArrowProjectile>)+130]");
				object obj10;
				if (num15 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v567 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ rax_v59+FFFFFFF8+v569 @ rax_v55*8]");
					if (0 == (nint)typeof(FlashArrowProjectile))
					{
						obj10 = 1;
						goto IL_03c2;
					}
				}
				obj10 = 0;
				goto IL_03c2;
				IL_03c2:
				bool flag = obj10 == null;
				num12 = (int)num13;
				component = null;
				vector = (Vector2)typeof(FlashArrowProjectile);
				if (!flag)
				{
					num12 = (int)num13;
					component = projectile;
					vector = (Vector2)typeof(FlashArrowProjectile);
				}
				goto IL_03ff;
				IL_03ff:
				if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
					if (obj11 == null)
					{
						break;
					}
					nint num16 = (nint)component;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v834 @ rdx_v15 (Il2CppClass<UnityEngine.Component>)+2D8] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rbx_v9 (UnityEngine.Component)+28]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v31+18]");
					if ((nint)0 == 0)
					{
						break;
					}
					num = num11 * ((float)Math.PI / 180f);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rbx_v9 (UnityEngine.Component)+28]");
					ref float2 vec = ref *(float2*)((nint)0 + (nint)112);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v31+18]");
					float2 float5 = ((ArcadePhysics)0).velocityFromRotation(num, num10, ref vec);
					_ = 0;
					Transform transform = component.transform;
					Quaternion.AngleAxis_Injected((float)typeof(Vector3), ref axis, out Quaternion _);
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					axis = Vector3.forwardVector;
				}
				num4++;
				if (num4 >= _amount)
				{
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CPlayNextRangedAnim_003Eb__11_0()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnRangedAttackAnim();
		}
	}
}
