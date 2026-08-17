using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Hydrostorm_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public TP_Hydrostorm_Weapon _003C_003E4__this;

		public float __unit;

		public float __firstX;

		public float __halfSceen;

		public float __firstY;

		public float __repeatInterval;

		public float __amount;

		public Action _003C_003E9__1;

		internal void _003CFireProjectiles_003Eb__0()
		{
			TP_Hydrostorm_Weapon tP_Hydrostorm_Weapon = _003C_003E4__this;
			tP_Hydrostorm_Weapon._rainEmitter1.Stop();
			TP_Hydrostorm_Weapon tP_Hydrostorm_Weapon2 = _003C_003E4__this;
			tP_Hydrostorm_Weapon2._rainEmitter2.Stop();
			TP_Hydrostorm_Weapon tP_Hydrostorm_Weapon3 = _003C_003E4__this;
			if (_003C_003E4__this.EnableBottleEmitters)
			{
				tP_Hydrostorm_Weapon3._bottleEmitter.Stop();
			}
			TP_Hydrostorm_Weapon tP_Hydrostorm_Weapon4 = _003C_003E4__this;
			tP_Hydrostorm_Weapon4._groundParticlesActive = false;
		}

		internal unsafe void _003CFireProjectiles_003Eb__1()
		{
			//IL_0381: Invalid comparison between F4 and I4
			//IL_003a: Expected O, but got I4
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			//IL_04cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d2: Expected O, but got Unknown
			//IL_0529: Unknown result type (might be due to invalid IL or missing references)
			//IL_052e: Expected O, but got Unknown
			//IL_035a: Invalid comparison between F4 and I4
			//IL_04be->IL036e: Incompatible stack heights: 1 vs 0
			//IL_0107->IL036e: Incompatible stack heights: 1 vs 0
			//IL_040c->IL036e: Incompatible stack heights: 1 vs 0
			//IL_0153->IL036e: Incompatible stack heights: 1 vs 0
			//IL_017c->IL036e: Incompatible stack heights: 1 vs 0
			//IL_01ab->IL036e: Incompatible stack heights: 1 vs 0
			//IL_01da->IL036e: Incompatible stack heights: 1 vs 0
			//IL_0220->IL036e: Incompatible stack heights: 2 vs 0
			//IL_0329->IL036e: Incompatible stack heights: 2 vs 0
			//IL_0260->IL036e: Incompatible stack heights: 2 vs 0
			//IL_0369->IL0463: Incompatible stack heights: 2 vs 0
			//IL_036e->IL0489: Incompatible stack heights: 2 vs 0
			if (!(__amount > 0f))
			{
				return;
			}
			bool flag = false;
			object obj3 = default(object);
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			while (true)
			{
				_003C_003Ec__DisplayClass26_1 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass26_1();
				if (CS_0024_003C_003E8__locals9 == null)
				{
					break;
				}
				CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 = this;
				TP_Hydrostorm_Weapon tP_Hydrostorm_Weapon = _003C_003E4__this;
				object obj = (flag ? 1 : 0) + 1;
				object obj2 = obj * __unit;
				if ((object)_003C_003E4__this == null)
				{
					break;
				}
				ArcadeSprite arcadeSprite = ((Equipment)tP_Hydrostorm_Weapon)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)tP_Hydrostorm_Weapon)._003COwner_003Ek__BackingField == null)
				{
					break;
				}
				Transform cachedTrans = ((ArcadeSprite)((Equipment)tP_Hydrostorm_Weapon)._003COwner_003Ek__BackingField).CachedTrans;
				if ((object)cachedTrans == null)
				{
					break;
				}
				bool flag2 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
				float2 ret;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
				if (arcadeSprite.body != null)
				{
					BaseBody body = arcadeSprite.body;
					ArcadeTransform transform = body._transform;
					if (body._transform == null)
					{
						break;
					}
					transform.position = ret;
				}
				float _firstX = (float)ret + __halfSceen;
				__firstX = _firstX;
				if ((object)GM.Core == null)
				{
					break;
				}
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene == null)
				{
					break;
				}
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer == null)
				{
					break;
				}
				TP_Hydrostorm_Weapon tP_Hydrostorm_Weapon2 = _003C_003E4__this;
				if ((object)_003C_003E4__this == null)
				{
					break;
				}
				ArcadeSprite arcadeSprite2 = ((Equipment)tP_Hydrostorm_Weapon2)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)tP_Hydrostorm_Weapon2)._003COwner_003Ek__BackingField == null)
				{
					break;
				}
				Transform cachedTrans2 = ((ArcadeSprite)((Equipment)tP_Hydrostorm_Weapon2)._003COwner_003Ek__BackingField).CachedTrans;
				if ((object)cachedTrans2 == null)
				{
					break;
				}
				bool flag3 = ((UnityEngine.Object)cachedTrans2).m_CachedPtr == (IntPtr)0;
				float2 ret2;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTrans2).m_CachedPtr, out *(Vector3*)(&ret2));
				if (arcadeSprite2.body != null)
				{
					BaseBody body2 = arcadeSprite2.body;
					ArcadeTransform transform2 = body2._transform;
					if (body2._transform == null)
					{
						break;
					}
					transform2.position = ret2;
				}
				Vector2 _pos = (Vector2)(obj2 + __firstX);
				float num = renderer.height * 0.5f;
				float _firstY = num + (float)obj3;
				__firstY = _firstY;
				CS_0024_003C_003E8__locals9.__pos = _pos;
				CS_0024_003C_003E8__locals9.localIndex = (flag ? 1 : 0);
				object obj4 = flag * __repeatInterval;
				if ((nint)obj4 <= 0)
				{
					TP_Hydrostorm_Weapon tP_Hydrostorm_Weapon3 = _003C_003E4__this;
					if ((object)_003C_003E4__this == null)
					{
						break;
					}
					if (tP_Hydrostorm_Weapon3._isVisible)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
					}
				}
				else
				{
					Transform transform3 = (Transform)(object)_003C_003E4__this;
					Action onComplete = delegate
					{
						//IL_0182: Expected O, but got I4
						//IL_00a8->IL014b: Incompatible stack heights: 1 vs 0
						//IL_00d7->IL014b: Incompatible stack heights: 1 vs 0
						//IL_00f9->IL014b: Incompatible stack heights: 1 vs 0
						_003C_003Ec__DisplayClass26_0 obj5 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null && (object)obj5._003C_003E4__this != null)
						{
							GameObject gameObject = obj5._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj6 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj6 == null)
								{
									return;
								}
								_003C_003Ec__DisplayClass26_0 obj7 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null)
								{
									TP_Hydrostorm_Weapon tP_Hydrostorm_Weapon4 = obj7._003C_003E4__this;
									if ((object)obj7._003C_003E4__this != null && (object)obj7._003C_003E4__this != null)
									{
										if (tP_Hydrostorm_Weapon4._isVisible)
										{
											Vector2 pos = default(Vector2);
											Projectile projectile = obj7._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals9.localIndex, tP_Hydrostorm_Weapon4._targetTransform);
										}
										return;
									}
								}
							}
						}
						throw new NullReferenceException();
					};
					float num2 = (float)(flag ? 1 : 0) * __repeatInterval;
					float duration = num2 * 0.001f;
					Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					if ((object)_003C_003E4__this == null)
					{
						break;
					}
				}
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
				if (!(__amount > (float)(flag ? 1 : 0)))
				{
					return;
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass26_1
	{
		public Vector2 __pos;

		public int localIndex;

		public _003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireProjectiles_003Eb__2()
		{
			//IL_0182: Expected O, but got I4
			//IL_00a8->IL014b: Incompatible stack heights: 1 vs 0
			//IL_00d7->IL014b: Incompatible stack heights: 1 vs 0
			//IL_00f9->IL014b: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass26_0 obj = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null && (object)obj._003C_003E4__this != null)
			{
				GameObject gameObject = obj._003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj2 == null)
					{
						return;
					}
					_003C_003Ec__DisplayClass26_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						TP_Hydrostorm_Weapon tP_Hydrostorm_Weapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null && (object)obj3._003C_003E4__this != null)
						{
							if (tP_Hydrostorm_Weapon._isVisible)
							{
								Vector2 pos = default(Vector2);
								Projectile projectile = obj3._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Hydrostorm_Weapon._targetTransform);
							}
							return;
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private bool _initialisedParticles;

	private ParticleSystem _rainEmitter1;

	private ParticleSystem _rainEmitter2;

	private ParticleSystem _bottleEmitter;

	private ParticleSystem _groundEmitter1;

	private ParticleSystem _groundEmitter2;

	private Timer _rainStopTimer;

	private bool _groundParticlesActive;

	protected virtual uint RainEmitterTint1 => 4474060u;

	protected virtual uint RainEmitterTint2 => 204u;

	protected virtual int RainEmitterQuantity => 40;

	protected unsafe virtual ParticleSystem.MinMaxCurve RainEmitterAlpha
	{
		get
		{
			//IL_0009: Expected native int or pointer, but got O
			//IL_0013: Expected native int or pointer, but got O
			//IL_0026: Expected native int or pointer, but got O
			ParticleSystem.MinMaxCurve minMaxCurve = default(ParticleSystem.MinMaxCurve);
			((ParticleSystem.MinMaxCurve*)(nint)minMaxCurve)->m_Mode = ParticleSystemCurveMode.Constant;
			System.Runtime.CompilerServices.Unsafe.Write(&((ParticleSystem.MinMaxCurve*)(nint)minMaxCurve)->m_CurveMax, null);
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(1f, 0.65f));
			return minMaxCurve;
		}
	}

	protected virtual bool EnableBottleEmitters => false;

	protected virtual bool EnableGroundEmitters => false;

	protected override void Awake()
	{
		base.Awake();
		MakeRainEmitters();
		MakeBottleEmitters();
		MakeGroundEmitters();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		base._003CTotalTime_003Ek__BackingField = num2;
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
		}
	}

	public override void InternalUpdate()
	{
		//IL_00da: Expected I, but got O
		//IL_0048: Expected I4, but got I8
		//IL_006f: Expected I4, but got I8
		base.InternalUpdate();
		if (EnableGroundEmitters && _groundParticlesActive)
		{
			do
			{
				Vector2 randomPositionOnScreen = GetRandomPositionOnScreen();
				nint num = (nint)typeof(RenderingExtensions);
				RenderingExtensions.EmitParticleAt(_groundEmitter1, randomPositionOnScreen, -1);
				Vector2 randomPositionOnScreen2 = GetRandomPositionOnScreen();
				RenderingExtensions.EmitParticleAt(_groundEmitter2, randomPositionOnScreen2, -1);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rcx_v7 (Il2CppClass<VampireSurvivors.App.Tools.RenderingExtensions>)+E4]");
			}
			while ((nint)0 != 0);
		}
		UpdateFiringInterval();
	}

	protected virtual void UpdateFiringInterval()
	{
		float deltaTime = PauseSystem.DeltaTime;
		float num = base.PInterval();
		float num2 = deltaTime * 1000f;
		if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			base.Fire();
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		FireProjectiles();
		PlaySfx();
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public unsafe void FireProjectiles()
	{
		//IL_002d: Expected I, but got O
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals40 = new _003C_003Ec__DisplayClass26_0();
		CS_0024_003C_003E8__locals40._003C_003E4__this = this;
		float hitBoxDelay = base.HitBoxDelay;
		float num = base.PSpeed();
		nint num2 = (nint)this;
		float num3 = 1f / hitBoxDelay;
		float num4 = num3 * hitBoxDelay;
		float num5 = base.PDuration();
		float num6 = hitBoxDelay / num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float _amount = renderer.width / 0.22f;
		CS_0024_003C_003E8__locals40.__amount = _amount;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float _halfSceen = renderer2.width * 0.5f;
		CS_0024_003C_003E8__locals40.__halfSceen = _halfSceen;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float _firstX = (float)position + CS_0024_003C_003E8__locals40.__halfSceen;
		CS_0024_003C_003E8__locals40.__firstX = _firstX;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num7 = renderer3.height * 0.5f;
		float num8 = CS_0024_003C_003E8__locals40.__amount + 1f;
		object obj = default(object);
		float _firstY = num7 + (float)obj;
		float num9 = renderer.width / num8;
		CS_0024_003C_003E8__locals40.__firstY = _firstY;
		float _unit = num9 * -1f;
		CS_0024_003C_003E8__locals40.__unit = _unit;
		WeaponData currentWeaponData = _currentWeaponData;
		CS_0024_003C_003E8__locals40.__repeatInterval = currentWeaponData._003CrepeatInterval_003Ek__BackingField;
		if (_rainStopTimer != null)
		{
			_rainStopTimer.Cancel();
		}
		RenderingExtensions.Start(_rainEmitter1);
		RenderingExtensions.Start(_rainEmitter2);
		if (EnableBottleEmitters)
		{
			RenderingExtensions.Start(_bottleEmitter);
		}
		_groundParticlesActive = true;
		Action onComplete = delegate
		{
			TP_Hydrostorm_Weapon tP_Hydrostorm_Weapon = CS_0024_003C_003E8__locals40._003C_003E4__this;
			tP_Hydrostorm_Weapon._rainEmitter1.Stop();
			TP_Hydrostorm_Weapon tP_Hydrostorm_Weapon2 = CS_0024_003C_003E8__locals40._003C_003E4__this;
			tP_Hydrostorm_Weapon2._rainEmitter2.Stop();
			TP_Hydrostorm_Weapon tP_Hydrostorm_Weapon3 = CS_0024_003C_003E8__locals40._003C_003E4__this;
			if (CS_0024_003C_003E8__locals40._003C_003E4__this.EnableBottleEmitters)
			{
				tP_Hydrostorm_Weapon3._bottleEmitter.Stop();
			}
			TP_Hydrostorm_Weapon tP_Hydrostorm_Weapon4 = CS_0024_003C_003E8__locals40._003C_003E4__this;
			tP_Hydrostorm_Weapon4._groundParticlesActive = false;
		};
		float num10 = num4 + 1f;
		object obj2 = default(object);
		float num11 = num10 * (float)obj2;
		float duration = num11 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer rainStopTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_rainStopTimer = rainStopTimer;
		bool flag = (nint)obj2 <= 0;
		bool flag2 = false;
		if (flag)
		{
			return;
		}
		do
		{
			Action onComplete2 = CS_0024_003C_003E8__locals40._003C_003E9__1;
			if (CS_0024_003C_003E8__locals40._003C_003E9__1 == null)
			{
				onComplete2 = (CS_0024_003C_003E8__locals40._003C_003E9__1 = delegate
				{
					//IL_0381: Invalid comparison between F4 and I4
					//IL_003a: Expected O, but got I4
					//IL_0044: Unknown result type (might be due to invalid IL or missing references)
					//IL_0049: Expected O, but got Unknown
					//IL_04cd: Unknown result type (might be due to invalid IL or missing references)
					//IL_04d2: Expected O, but got Unknown
					//IL_0529: Unknown result type (might be due to invalid IL or missing references)
					//IL_052e: Expected O, but got Unknown
					//IL_035a: Invalid comparison between F4 and I4
					//IL_04be->IL036e: Incompatible stack heights: 1 vs 0
					//IL_0107->IL036e: Incompatible stack heights: 1 vs 0
					//IL_040c->IL036e: Incompatible stack heights: 1 vs 0
					//IL_0153->IL036e: Incompatible stack heights: 1 vs 0
					//IL_017c->IL036e: Incompatible stack heights: 1 vs 0
					//IL_01ab->IL036e: Incompatible stack heights: 1 vs 0
					//IL_01da->IL036e: Incompatible stack heights: 1 vs 0
					//IL_0220->IL036e: Incompatible stack heights: 2 vs 0
					//IL_0329->IL036e: Incompatible stack heights: 2 vs 0
					//IL_0260->IL036e: Incompatible stack heights: 2 vs 0
					//IL_0369->IL0463: Incompatible stack heights: 2 vs 0
					//IL_036e->IL0489: Incompatible stack heights: 2 vs 0
					if (CS_0024_003C_003E8__locals40.__amount > 0f)
					{
						bool flag3 = false;
						object obj5 = default(object);
						bool useRealTime2 = default(bool);
						MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
						int repeat2 = default(int);
						TimerType type2 = default(TimerType);
						while (true)
						{
							_003C_003Ec__DisplayClass26_1 CS_0024_003C_003E8__locals45 = new _003C_003Ec__DisplayClass26_1();
							if (CS_0024_003C_003E8__locals45 == null)
							{
								break;
							}
							CS_0024_003C_003E8__locals45.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals40;
							TP_Hydrostorm_Weapon tP_Hydrostorm_Weapon = CS_0024_003C_003E8__locals40._003C_003E4__this;
							object obj3 = (flag3 ? 1 : 0) + 1;
							object obj4 = obj3 * CS_0024_003C_003E8__locals40.__unit;
							if ((object)CS_0024_003C_003E8__locals40._003C_003E4__this == null)
							{
								break;
							}
							ArcadeSprite arcadeSprite = ((Equipment)tP_Hydrostorm_Weapon)._003COwner_003Ek__BackingField;
							if ((object)((Equipment)tP_Hydrostorm_Weapon)._003COwner_003Ek__BackingField == null)
							{
								break;
							}
							Transform cachedTrans = ((ArcadeSprite)((Equipment)tP_Hydrostorm_Weapon)._003COwner_003Ek__BackingField).CachedTrans;
							if ((object)cachedTrans == null)
							{
								break;
							}
							bool flag4 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
							float2 ret;
							Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
							if (arcadeSprite.body != null)
							{
								BaseBody body = arcadeSprite.body;
								ArcadeTransform arcadeTransform = body._transform;
								if (body._transform == null)
								{
									break;
								}
								arcadeTransform.position = ret;
							}
							float _firstX2 = (float)ret + CS_0024_003C_003E8__locals40.__halfSceen;
							CS_0024_003C_003E8__locals40.__firstX = _firstX2;
							if ((object)GM.Core == null)
							{
								break;
							}
							PhaserScene s_scene4 = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene == null)
							{
								break;
							}
							PhaserScene.Renderer renderer4 = s_scene4._renderer;
							if (s_scene4._renderer == null)
							{
								break;
							}
							TP_Hydrostorm_Weapon tP_Hydrostorm_Weapon2 = CS_0024_003C_003E8__locals40._003C_003E4__this;
							if ((object)CS_0024_003C_003E8__locals40._003C_003E4__this == null)
							{
								break;
							}
							ArcadeSprite arcadeSprite2 = ((Equipment)tP_Hydrostorm_Weapon2)._003COwner_003Ek__BackingField;
							if ((object)((Equipment)tP_Hydrostorm_Weapon2)._003COwner_003Ek__BackingField == null)
							{
								break;
							}
							Transform cachedTrans2 = ((ArcadeSprite)((Equipment)tP_Hydrostorm_Weapon2)._003COwner_003Ek__BackingField).CachedTrans;
							if ((object)cachedTrans2 == null)
							{
								break;
							}
							bool flag5 = ((UnityEngine.Object)cachedTrans2).m_CachedPtr == (IntPtr)0;
							float2 ret2;
							Transform.get_position_Injected(((UnityEngine.Object)cachedTrans2).m_CachedPtr, out *(Vector3*)(&ret2));
							if (arcadeSprite2.body != null)
							{
								BaseBody body2 = arcadeSprite2.body;
								ArcadeTransform arcadeTransform2 = body2._transform;
								if (body2._transform == null)
								{
									break;
								}
								arcadeTransform2.position = ret2;
							}
							Vector2 _pos = (Vector2)(obj4 + CS_0024_003C_003E8__locals40.__firstX);
							float num14 = renderer4.height * 0.5f;
							float _firstY2 = num14 + (float)obj5;
							CS_0024_003C_003E8__locals40.__firstY = _firstY2;
							CS_0024_003C_003E8__locals45.__pos = _pos;
							CS_0024_003C_003E8__locals45.localIndex = (flag3 ? 1 : 0);
							object obj6 = flag3 * CS_0024_003C_003E8__locals40.__repeatInterval;
							if ((nint)obj6 <= 0)
							{
								TP_Hydrostorm_Weapon tP_Hydrostorm_Weapon3 = CS_0024_003C_003E8__locals40._003C_003E4__this;
								if ((object)CS_0024_003C_003E8__locals40._003C_003E4__this == null)
								{
									break;
								}
								if (tP_Hydrostorm_Weapon3._isVisible)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
								}
							}
							else
							{
								Transform transform = (Transform)(object)CS_0024_003C_003E8__locals40._003C_003E4__this;
								Action onComplete3 = delegate
								{
									//IL_0182: Expected O, but got I4
									//IL_00a8->IL014b: Incompatible stack heights: 1 vs 0
									//IL_00d7->IL014b: Incompatible stack heights: 1 vs 0
									//IL_00f9->IL014b: Incompatible stack heights: 1 vs 0
									_003C_003Ec__DisplayClass26_0 obj7 = CS_0024_003C_003E8__locals45.CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals45.CS_0024_003C_003E8__locals1 != null && (object)obj7._003C_003E4__this != null)
									{
										GameObject gameObject = obj7._003C_003E4__this.gameObject;
										if ((object)gameObject != null)
										{
											bool flag6 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
											object obj8 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
											if (obj8 == null)
											{
												return;
											}
											_003C_003Ec__DisplayClass26_0 obj9 = CS_0024_003C_003E8__locals45.CS_0024_003C_003E8__locals1;
											if (CS_0024_003C_003E8__locals45.CS_0024_003C_003E8__locals1 != null)
											{
												TP_Hydrostorm_Weapon tP_Hydrostorm_Weapon4 = obj9._003C_003E4__this;
												if ((object)obj9._003C_003E4__this != null && (object)obj9._003C_003E4__this != null)
												{
													if (tP_Hydrostorm_Weapon4._isVisible)
													{
														Vector2 pos = default(Vector2);
														Projectile projectile = obj9._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals45.localIndex, tP_Hydrostorm_Weapon4._targetTransform);
													}
													return;
												}
											}
										}
									}
									throw new NullReferenceException();
								};
								float num15 = (float)(flag3 ? 1 : 0) * CS_0024_003C_003E8__locals40.__repeatInterval;
								float duration3 = num15 * 0.001f;
								Timer timer2 = Timers.Register(duration3, onComplete3, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
								if ((object)CS_0024_003C_003E8__locals40._003C_003E4__this == null)
								{
									break;
								}
							}
							flag3 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
							if (!(CS_0024_003C_003E8__locals40.__amount > (float)(flag3 ? 1 : 0)))
							{
								return;
							}
						}
						throw new NullReferenceException();
					}
				});
			}
			float num12 = (float)(flag2 ? 1 : 0) * num4;
			float num13 = num12 + 1f;
			float duration2 = num13 * 0.001f;
			Timer timer = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
		}
		while ((flag2 ? 1 : 0) < (nint)obj2);
	}

	private void FireOneRainProjectile(Vector2 pos, int index, Transform target)
	{
		if (_isVisible)
		{
			Projectile projectile = base.FireOneProjectile(pos, index, target);
		}
	}

	protected virtual void PlaySfx()
	{
		//IL_0033: Expected F4, but got I4
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_DivineStorm, 1000f, 3, 0f, volume, rate, detune, loop, 1f);
	}

	private void PlayBottlePfx(bool play)
	{
		if (EnableBottleEmitters)
		{
			if (!play)
			{
				_bottleEmitter.Stop();
			}
			else
			{
				RenderingExtensions.Start(_bottleEmitter);
			}
		}
	}

	private unsafe void MakeRainEmitters()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected F4, but got Unknown
		//IL_01fe: Expected O, but got I4
		//IL_0225: Expected O, but got I4
		//IL_024c: Expected O, but got I4
		//IL_0265: Expected O, but got Ref
		//IL_028c: Expected O, but got I
		//IL_02a6: Expected native int or pointer, but got O
		//IL_02c0: Expected O, but got I
		//IL_0302: Expected O, but got I
		//IL_09d1: Expected O, but got I
		//IL_0a0b: Expected O, but got I
		//IL_0a45: Expected O, but got I
		//IL_03c5: Expected O, but got I
		//IL_03e1: Expected O, but got I4
		//IL_042a: Expected O, but got I
		//IL_0569: Expected O, but got I4
		//IL_0590: Expected O, but got I4
		//IL_05b7: Expected O, but got I4
		//IL_05d0: Expected O, but got Ref
		//IL_05f1: Expected O, but got I
		//IL_060b: Expected native int or pointer, but got O
		//IL_0625: Expected O, but got I
		//IL_0667: Expected O, but got I
		//IL_0a89: Expected O, but got I
		//IL_0ac3: Expected O, but got I
		//IL_0afd: Expected O, but got I
		//IL_072a: Expected O, but got I
		//IL_0746: Expected O, but got I4
		//IL_078f: Expected O, but got I
		//IL_0b5a: Expected O, but got Ref
		//IL_0b9d: Expected O, but got Ref
		//IL_0bdb: Expected O, but got I
		//IL_0c50: Expected O, but got Ref
		//IL_0c1a: Expected O, but got I
		//IL_0c87: Expected O, but got Ref
		//IL_0cae: Expected O, but got Ref
		//IL_0925: Expected O, but got Ref
		//IL_0947: Expected O, but got Ref
		//IL_0969: Expected O, but got Ref
		//IL_0c74->IL096a: Incompatible stack heights: 3 vs 0
		//IL_08dd->IL0c42: Incompatible stack heights: 4 vs 3
		//IL_0916->IL0c79: Incompatible stack heights: 4 vs 3
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					Rectangle rectangle = new Rectangle();
					float num = renderer.screenWidth * 0.5f;
					float width = renderer.screenWidth * 1.5f;
					rectangle._y = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
					float x = num ^ 0;
					rectangle._x = x;
					rectangle._width = width;
					rectangle._height = 0.64f;
					ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
					List<string> list = new List<string>();
					if (list != null)
					{
						int version = list._version + 1;
						list._version = version;
						string[] items = list._items;
						if (list._items != null)
						{
							if (list._size >= items.Length)
							{
								((List<object>)(object)list).AddWithResize((object)"WhiteDot");
							}
							else
							{
								int size = list._size + 1;
								list._size = size;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							if (particleSystemConfig != null)
							{
								particleSystemConfig._frame = list;
								ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
								particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
								_ = 0;
								minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
								particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
								_ = 0;
								minMaxCurve = new ParticleSystem.MinMaxCurve(105f);
								particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
								_ = 0;
								_ = 1;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+140]");
								particleSystemConfig._blendMode = (BlendMode?)(object)0;
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(400f, 500f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
								particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
								_ = 0;
								_ = 0;
								int rainEmitterQuantity = RainEmitterQuantity;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+140]");
								particleSystemConfig._quantity = (int?)(object)0;
								minMaxCurve = new ParticleSystem.MinMaxCurve(32f);
								_ = 0;
								_ = 0;
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
								particleSystemConfig._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
								_ = 0;
								minMaxCurve = new ParticleSystem.MinMaxCurve(1f);
								_ = 0;
								_ = 0;
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
								particleSystemConfig._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
								_ = 0;
								ParticleSystem.MinMaxCurve rainEmitterAlpha = RainEmitterAlpha;
								_ = 0;
								_ = rainEmitterAlpha.m_Mode;
								_ = rainEmitterAlpha.m_CurveMax;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-10]");
								particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+10]");
								_ = 0;
								EmitZone emitZone = new EmitZone();
								emitZone._type = EmitZoneType.Random;
								emitZone._source = rectangle;
								particleSystemConfig._emitZone = emitZone;
								_ = 0;
								_ = 1112014848;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+140]");
								particleSystemConfig._frequency = (float?)(object)0;
								minMaxCurve = new ParticleSystem.MinMaxCurve(826f);
								particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
								_ = 0;
								_ = 0;
								uint rainEmitterTint = RainEmitterTint1;
								particleSystemConfig._on = true;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+140]");
								particleSystemConfig._tint = (uint?)(object)0;
								ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
								List<string> list2 = new List<string>();
								if (list2 != null)
								{
									int version2 = list2._version + 1;
									list2._version = version2;
									string[] items2 = list2._items;
									if (list2._items != null)
									{
										if (list2._size >= items2.Length)
										{
											((List<object>)(object)list2).AddWithResize((object)"WhiteDot");
										}
										else
										{
											int size2 = list2._size + 1;
											list2._size = size2;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										if (particleSystemConfig2 != null)
										{
											particleSystemConfig2._frame = list2;
											minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
											particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
											_ = 0;
											minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
											particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
											_ = 0;
											minMaxCurve = new ParticleSystem.MinMaxCurve(105f);
											particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
											_ = 0;
											ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176));
											_ = 0;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+140]");
											particleSystemConfig2._blendMode = (BlendMode?)(object)0;
											_ = 0;
											_ = 0;
											System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(400f, 500f));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
											particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
											_ = 0;
											_ = 0;
											int rainEmitterQuantity2 = RainEmitterQuantity;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+140]");
											particleSystemConfig2._quantity = (int?)(object)0;
											minMaxCurve = new ParticleSystem.MinMaxCurve(32f);
											_ = 0;
											_ = 0;
											_ = 0;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
											particleSystemConfig2._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+28]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
											_ = 0;
											minMaxCurve = new ParticleSystem.MinMaxCurve(1f);
											_ = 0;
											_ = 0;
											_ = 0;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+40]");
											particleSystemConfig2._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+50]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+60]");
											_ = 0;
											ParticleSystem.MinMaxCurve rainEmitterAlpha2 = RainEmitterAlpha;
											_ = 0;
											_ = rainEmitterAlpha2.m_Mode;
											_ = rainEmitterAlpha2.m_CurveMax;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+68]");
											particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+78]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+88]");
											_ = 0;
											EmitZone emitZone2 = new EmitZone();
											emitZone2._type = EmitZoneType.Random;
											emitZone2._source = rectangle;
											particleSystemConfig2._emitZone = emitZone2;
											_ = 0;
											_ = 1120403456;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+140]");
											particleSystemConfig2._frequency = (float?)(object)0;
											minMaxCurve = new ParticleSystem.MinMaxCurve(826f);
											particleSystemConfig2._gravity = (ParticleSystem.MinMaxCurve)0;
											_ = 0;
											_ = 0;
											uint rainEmitterTint2 = RainEmitterTint2;
											particleSystemConfig2._on = true;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+140]");
											particleSystemConfig2._tint = (uint?)(object)0;
											bool flag = (object)GM.Core == null;
											Camera main = Camera.main;
											Transform parent = main.transform;
											ParticleSystem rainEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent, "_rainEmitter1_Hydrostorm");
											_rainEmitter1 = rainEmitter;
											Transform transform = _rainEmitter1.transform;
											_ = 10f;
											bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
											object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
											Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj3);
											RenderingExtensions.SetDepth(_rainEmitter1, 3000);
											Camera main2 = Camera.main;
											Transform parent2 = main2.transform;
											ParticleSystem rainEmitter2 = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig2, parent2, "_rainEmitter2_Hydrostorm");
											_rainEmitter2 = rainEmitter2;
											Transform transform2 = _rainEmitter2.transform;
											_ = 10f;
											bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
											object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
											Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj4);
											RenderingExtensions.SetDepth(_rainEmitter2, 3000);
											_ = _rainEmitter1;
											_ = _rainEmitter1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
											object obj5 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
												bool flag4 = obj5 == null;
											}
											object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 328));
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3264 @ rax_v138 (should have been resolved before IL gen)");
											if ((object)_rainEmitter2 != null)
											{
												_ = _rainEmitter2;
												_ = _rainEmitter2;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
												object obj7 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
													bool flag5 = obj7 == null;
												}
												object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 328));
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3351 @ rax_v143 (should have been resolved before IL gen)");
												minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
												ParticleSystem.MinMaxCurve minMaxCurve4 = default(ParticleSystem.MinMaxCurve);
												RenderingExtensions.SetSpeedX(_rainEmitter1, (ParticleSystem.MinMaxCurve)(&minMaxCurve4));
												minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
												RenderingExtensions.SetSpeedY(_rainEmitter1, (ParticleSystem.MinMaxCurve)(&minMaxCurve4));
												minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
												RenderingExtensions.SetSpeedX(_rainEmitter2, (ParticleSystem.MinMaxCurve)(&minMaxCurve4));
												minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
												RenderingExtensions.SetSpeedY(_rainEmitter2, (ParticleSystem.MinMaxCurve)(&minMaxCurve4));
												return;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void MakeBottleEmitters()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected F4, but got Unknown
		//IL_04ce: Expected O, but got I4
		//IL_04e7: Expected O, but got Ref
		//IL_050e: Expected O, but got I
		//IL_0528: Expected native int or pointer, but got O
		//IL_076b: Expected O, but got I4
		//IL_059d: Expected O, but got I
		//IL_07e1: Expected O, but got I
		//IL_0820: Expected O, but got I
		//IL_087f: Expected O, but got Ref
		//IL_0897: Expected O, but got Ref
		//IL_08b1: Expected native int or pointer, but got O
		//IL_08c4: Expected O, but got Ref
		//IL_08d1: Expected O, but got Ref
		//IL_06b9: Expected O, but got Ref
		//IL_06f5: Expected O, but got Ref
		//IL_086c->IL0711: Incompatible stack heights: 2 vs 0
		//IL_0672->IL0848: Incompatible stack heights: 3 vs 2
		//IL_06ab->IL0871: Incompatible stack heights: 3 vs 2
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					Rectangle rectangle = new Rectangle();
					float num = renderer.screenWidth * 0.5f;
					float width = renderer.screenWidth * 1.25f;
					rectangle._y = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
					float x = num ^ 0;
					rectangle._x = x;
					rectangle._width = width;
					rectangle._height = 0.64f;
					ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("items");
					List<string> list = new List<string>();
					if (list != null)
					{
						int version = list._version + 1;
						list._version = version;
						string[] items = list._items;
						if (list._items != null)
						{
							if (list._size >= items.Length)
							{
								((List<object>)(object)list).AddWithResize((object)"HolyWater");
							}
							else
							{
								int size = list._size + 1;
								list._size = size;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							int version2 = list._version + 1;
							list._version = version2;
							string[] items2 = list._items;
							if (list._items != null)
							{
								if (list._size >= items2.Length)
								{
									((List<object>)(object)list).AddWithResize((object)"Water2");
								}
								else
								{
									int size2 = list._size + 1;
									list._size = size2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								int version3 = list._version + 1;
								list._version = version3;
								string[] items3 = list._items;
								if (list._items != null)
								{
									if (list._size >= items3.Length)
									{
										((List<object>)(object)list).AddWithResize((object)"TP_HYDROSTORM");
									}
									else
									{
										int size3 = list._size + 1;
										list._size = size3;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									}
									int version4 = list._version + 1;
									list._version = version4;
									string[] items4 = list._items;
									if (list._items != null)
									{
										if (list._size >= items4.Length)
										{
											((List<object>)(object)list).AddWithResize((object)"TP_HYDROSTORM2");
										}
										else
										{
											int size4 = list._size + 1;
											list._size = size4;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										int version5 = list._version + 1;
										list._version = version5;
										string[] items5 = list._items;
										if (list._items != null)
										{
											if (list._size >= items5.Length)
											{
												((List<object>)(object)list).AddWithResize((object)"Tear");
											}
											else
											{
												int size5 = list._size + 1;
												list._size = size5;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											}
											if (particleSystemConfig != null)
											{
												particleSystemConfig._frame = list;
												ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(1500f);
												particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
												_ = 0;
												_ = 1;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+50]");
												particleSystemConfig._quantity = (int?)(object)0;
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1.25f, 1.25f));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
												_ = 0;
												particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
												_ = 0;
												EmitZone emitZone = new EmitZone();
												emitZone._type = EmitZoneType.Random;
												emitZone._source = rectangle;
												particleSystemConfig._emitZone = emitZone;
												_ = 0;
												particleSystemConfig._on = true;
												_ = 1128792064;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+50]");
												particleSystemConfig._frequency = (float?)(object)0;
												bool flag = (object)GM.Core == null;
												Camera main = Camera.main;
												Transform parent = main.transform;
												ParticleSystem bottleEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent, "_bottleEmitter_Hydrostorm");
												_bottleEmitter = bottleEmitter;
												Transform transform = _bottleEmitter.transform;
												bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
												Vector3 value = default(Vector3);
												Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
												RenderingExtensions.SetDepth(_bottleEmitter, 3000);
												_ = _bottleEmitter;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
												object obj3 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
													bool flag3 = obj3 == null;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1527 @ rax_v63 (should have been resolved before IL gen)");
												if ((object)_bottleEmitter != null)
												{
													_ = _bottleEmitter;
													_ = _bottleEmitter;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC98]");
													object obj4 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC98]");
													if ((nint)0 == 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
														bool flag4 = obj4 == null;
													}
													object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1614 @ rax_v68 (should have been resolved before IL gen)");
													ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 32));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve((float)Math.PI * -3f / 4f, -4.712389f));
													ParticleSystem.RotationOverLifetimeModule rotationOverLifetimeModule = (ParticleSystem.RotationOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
													((ParticleSystem.RotationOverLifetimeModule*)rotationOverLifetimeModule)->z = (ParticleSystem.MinMaxCurve)(&minMaxCurve);
													minMaxCurve = new ParticleSystem.MinMaxCurve(200f);
													ParticleSystem.MinMaxCurve value2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
													_ = 0;
													_ = 0;
													RenderingExtensions.SetSpeedX(_bottleEmitter, value2);
													minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
													ParticleSystem.MinMaxCurve value3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
													_ = 0;
													_ = 0;
													RenderingExtensions.SetSpeedY(_bottleEmitter, value3);
													return;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void MakeGroundEmitters()
	{
		//IL_0008: Expected O, but got Ref
		//IL_017e: Expected O, but got Ref
		//IL_0198: Expected native int or pointer, but got O
		//IL_074b: Expected O, but got I4
		//IL_01b0: Expected O, but got Ref
		//IL_01d7: Expected O, but got I
		//IL_01f1: Expected native int or pointer, but got O
		//IL_020b: Expected O, but got I
		//IL_0239: Expected O, but got I4
		//IL_0252: Expected O, but got Ref
		//IL_026c: Expected native int or pointer, but got O
		//IL_0768: Expected O, but got I4
		//IL_029e: Expected O, but got Ref
		//IL_02b8: Expected native int or pointer, but got O
		//IL_07a2: Expected O, but got I
		//IL_0461: Expected O, but got Ref
		//IL_047b: Expected native int or pointer, but got O
		//IL_07dc: Expected O, but got I
		//IL_04b9: Expected O, but got Ref
		//IL_04da: Expected O, but got I
		//IL_04f4: Expected native int or pointer, but got O
		//IL_050e: Expected O, but got I
		//IL_053c: Expected O, but got I4
		//IL_0555: Expected O, but got Ref
		//IL_056f: Expected native int or pointer, but got O
		//IL_0816: Expected O, but got I
		//IL_05a7: Expected O, but got Ref
		//IL_05c1: Expected native int or pointer, but got O
		//IL_0848: Expected O, but got I
		//IL_0620: Expected O, but got I
		//IL_0687: Expected I4, but got I8
		//IL_069b: Expected I4, but got I8
		//IL_087e: Expected O, but got I
		//IL_0917: Expected O, but got Ref
		//IL_08d1: Expected O, but got I
		//IL_0934: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (!EnableGroundEmitters)
		{
			return;
		}
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"ProjectileFlameHoly2");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"ProjectileFlameBlue2");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(1f, 1f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1A0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(90f, 90f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+60]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+70]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(600f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
		_ = 0;
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.25f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
		_ = 0;
		particleSystemConfig._on = true;
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		int version3 = list2._version + 1;
		list2._version = version3;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"ProjectileFlameHoly2");
		}
		else
		{
			int size3 = list2._size + 1;
			list2._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list2._version + 1;
		list2._version = version4;
		string[] items4 = list2._items;
		if (list2._size >= items4.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"ProjectileFlameBlue2");
		}
		else
		{
			int size4 = list2._size + 1;
			list2._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+D0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
		_ = 0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1A0]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(90f, 90f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
		_ = 0;
		minMaxCurve3 = new ParticleSystem.MinMaxCurve(600f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0.2f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+100]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+110]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-10]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+10]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0.25f, 0.5f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+120]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+130]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
		_ = 0;
		_ = 0;
		particleSystemConfig2._on = true;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1A0]");
		particleSystemConfig2._blendMode = (BlendMode?)(object)0;
		ParticleSystem groundEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, null, "_groundEmitter1_Hydrostorm");
		_groundEmitter1 = groundEmitter;
		ParticleSystem groundEmitter2 = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig2, null, "_groundEmitter2_Hydrostorm");
		_groundEmitter2 = groundEmitter2;
		RenderingExtensions.SetDepth(_groundEmitter1, -1999);
		RenderingExtensions.SetDepth(_groundEmitter2, -1999);
		_ = _groundEmitter1;
		_ = _groundEmitter1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 432));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2116 @ rax_v74 (should have been resolved before IL gen)");
		_ = _groundEmitter2;
		_ = _groundEmitter2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj5 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
		}
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 432));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2203 @ rax_v79 (should have been resolved before IL gen)");
	}

	private void UpdateGroundParticles()
	{
		//IL_00ce: Expected I, but got O
		//IL_0042: Expected I4, but got I8
		//IL_0069: Expected I4, but got I8
		if (EnableGroundEmitters && _groundParticlesActive)
		{
			do
			{
				Vector2 randomPositionOnScreen = GetRandomPositionOnScreen();
				nint num = (nint)typeof(RenderingExtensions);
				RenderingExtensions.EmitParticleAt(_groundEmitter1, randomPositionOnScreen, -1);
				Vector2 randomPositionOnScreen2 = GetRandomPositionOnScreen();
				RenderingExtensions.EmitParticleAt(_groundEmitter2, randomPositionOnScreen2, -1);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rcx_v6 (Il2CppClass<VampireSurvivors.App.Tools.RenderingExtensions>)+E4]");
			}
			while ((nint)0 != 0);
		}
	}

	private Vector2 GetRandomPositionOnScreen()
	{
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		Vector2 vector = default(Vector2);
		float minInclusive = (float)bounds.m_Center - (float)vector;
		float maxInclusive = (float)vector + (float)bounds.m_Center;
		float num = UnityEngine.Random.Range(minInclusive, maxInclusive);
		float num2 = (float)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (UnityEngine.Bounds)+10]");
		float minInclusive2 = num2 - 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (UnityEngine.Bounds)+10]");
		float maxInclusive2 = 0f + (float)vector;
		float num3 = UnityEngine.Random.Range(minInclusive2, maxInclusive2);
		return vector;
	}

	public override void Cleanup()
	{
		base.Cleanup();
		StopEmitters();
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		if (!visible)
		{
			StopEmitters();
		}
	}

	private void StopEmitters()
	{
		ParticleSystem rainEmitter = _rainEmitter1;
		if ((object)_rainEmitter1 != null && ((UnityEngine.Object)rainEmitter).m_CachedPtr != (IntPtr)0)
		{
			RenderingExtensions.StopEmitting(_rainEmitter1);
		}
		ParticleSystem rainEmitter2 = _rainEmitter2;
		if ((object)_rainEmitter2 != null && ((UnityEngine.Object)rainEmitter2).m_CachedPtr != (IntPtr)0)
		{
			RenderingExtensions.StopEmitting(_rainEmitter2);
		}
		ParticleSystem groundEmitter = _groundEmitter1;
		if ((object)_groundEmitter1 != null && ((UnityEngine.Object)groundEmitter).m_CachedPtr != (IntPtr)0)
		{
			RenderingExtensions.StopEmitting(_groundEmitter1);
		}
		ParticleSystem groundEmitter2 = _groundEmitter2;
		if ((object)_groundEmitter2 != null && ((UnityEngine.Object)groundEmitter2).m_CachedPtr != (IntPtr)0)
		{
			RenderingExtensions.StopEmitting(_groundEmitter2);
		}
		ParticleSystem bottleEmitter = _bottleEmitter;
		if ((object)_bottleEmitter != null && ((UnityEngine.Object)bottleEmitter).m_CachedPtr != (IntPtr)0)
		{
			RenderingExtensions.StopEmitting(_bottleEmitter);
		}
	}
}
