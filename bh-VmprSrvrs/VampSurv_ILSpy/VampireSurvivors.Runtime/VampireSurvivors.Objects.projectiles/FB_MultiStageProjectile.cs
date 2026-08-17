using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_MultiStageProjectile : Projectile
{
	private SpriteAnimation _anim;

	public float2 _targetPosition;

	public float _timeSinceChangedTarget;

	private TrailRenderer _trail;

	private MultiTargetTween _trailFade;

	private float _MaxAlpha = 0.35f;

	private float _AlphaDiff = 0.65f;

	protected override void Awake()
	{
		base.Awake();
		_speed = 1.75f;
		Sprite sprite = SpriteManager.GetSprite("Multistage Missile-Horizontal-F1", "firstBlood");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		SpriteAnimation anim = _anim;
		if ((object)_anim == null || ((UnityEngine.Object)anim).m_CachedPtr == (IntPtr)0)
		{
			if ((object)_renderer != null)
			{
				SpriteAnimation component = _renderer.GetComponent<SpriteAnimation>();
				_anim = component;
				List<Sprite> list = new List<Sprite>();
				Sprite sprite2 = SpriteManager.GetSprite("Multistage Missile-Horizontal-F1", "firstBlood");
				if (list != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
					Sprite sprite3 = SpriteManager.GetSprite("Multistage Missile-Horizontal-F2", "firstBlood");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
					Sprite sprite4 = SpriteManager.GetSprite("Multistage Missile-Horizontal-F3", "firstBlood");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
					Sprite sprite5 = SpriteManager.GetSprite("Multistage Missile-Horizontal-F4", "firstBlood");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
					if ((object)_anim != null)
					{
						bool shouldLoop = default(bool);
						bool startRandomFrame = default(bool);
						Action onComplete = default(Action);
						bool autoSetAnimation = default(bool);
						_anim.AddAnimation("idle", list, 8, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
						goto IL_01c5;
					}
				}
			}
			throw new NullReferenceException();
		}
		goto IL_01c5;
		IL_01c5:
		GameObject gameObject = _renderer.gameObject;
		TrailRenderer trailRenderer = gameObject.AddComponent<TrailRenderer>();
		Sprite sprite6 = SpriteManager.GetSprite("trail7x12", "vfx");
		RenderingExtensions.SetMaterialToPackedSprite(trailRenderer, sprite6);
		trailRenderer.time = 1f;
		bool flag = ((UnityEngine.Object)trailRenderer).m_CachedPtr == (IntPtr)0;
		Color value = default(Color);
		TrailRenderer.set_startColor_Injected(((UnityEngine.Object)trailRenderer).m_CachedPtr, ref value);
		bool flag2 = ((UnityEngine.Object)trailRenderer).m_CachedPtr == (IntPtr)0;
		Color value2 = default(Color);
		TrailRenderer.set_endColor_Injected(((UnityEngine.Object)trailRenderer).m_CachedPtr, ref value2);
		TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(trailRenderer);
		_trail = trailRenderer;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00c5: Expected O, but got I4
		//IL_00c5: Expected O, but got I4
		//IL_0221: Expected O, but got I4
		//IL_0135: Expected F4, but got I4
		//IL_0047->IL0185: Incompatible stack heights: 1 vs 0
		//IL_00a5->IL0185: Incompatible stack heights: 1 vs 0
		//IL_0162->IL0185: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		ArcadeSprite arcadeSprite = setAlpha(1f);
		TrailRenderer trail = _trail;
		if ((object)_trail != null)
		{
			bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
			TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
			TrailRenderer trailRenderer = RenderingExtensions.SetAlpha(_trail, 1f);
			SpriteAnimation anim = _anim;
			if ((object)_anim != null)
			{
				((BaseSpriteAnimation)anim)._currentAnimation = null;
				Sprite sprite = SpriteManager.GetSprite("Multistage Missile-Horizontal-F1", "FirstBlood");
				ArcadeSprite arcadeSprite2 = setFrame(sprite);
				if (body != null)
				{
					BaseBody baseBody = body.setCircle(8f, (float?)(object)1, (float?)(object)1);
					float xScale = ((index < 0) ? 1f : 1.5f);
					ArcadeSprite arcadeSprite3 = setScale(xScale, (float?)(object)0);
					if (index >= 0)
					{
						float? volume = default(float?);
						float rate = default(float);
						float detune = default(float);
						bool loop = default(bool);
						PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_HomingShot, 100f, 12, 0f, volume, rate, detune, loop, 1f);
					}
					int num = base.depth;
					if ((object)_trail != null)
					{
						int sortingOrder = num - 1;
						_trail.sortingOrder = sortingOrder;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_0227: Invalid comparison between I4 and F4
		//IL_00cb: Expected I, but got O
		//IL_00d3: Expected I, but got O
		//IL_00e3: Expected O, but got I
		//IL_0163: Expected O, but got I4
		//IL_011f: Expected O, but got I
		//IL_0155: Expected O, but got I4
		if (0f > _timeSinceChangedTarget)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (_weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
		int penetrating = _penetrating - 1;
		_penetrating = penetrating;
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)other;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ r8_v7 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ r8_v7 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v25+FFFFFFF8+v308 @ rax_v9*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj4 = 1;
				goto IL_023b;
			}
		}
		obj4 = 0;
		goto IL_023b;
		IL_023b:
		bool flag = obj4 == null;
		IDamageable damageable = null;
		if (!flag)
		{
			damageable = other;
		}
		if (damageable != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rdi_v7 (VampireSurvivors.Interfaces.IDamageable)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rdi_v7 (VampireSurvivors.Interfaces.IDamageable)+1F9]");
				if ((nint)0 != 0)
				{
					_penetrating = 0;
				}
			}
		}
		if (_penetrating <= 0)
		{
			int missilesToSpawn = ((_indexInWeapon >= 0) ? 5 : 0);
			DoExplosion(missilesToSpawn);
		}
	}

	public override void Despawn()
	{
		if (_trailFade != null)
		{
			_trailFade.Kill();
		}
		_trailFade = null;
		base.Despawn();
	}

	private unsafe void DoExplosion(int missilesToSpawn = 5)
	{
		//IL_0124: Expected O, but got I4
		//IL_014a: Expected O, but got I4
		//IL_0214: Expected I, but got O
		//IL_0298: Expected O, but got I4
		//IL_051c: Expected I, but got O
		//IL_06a0: Expected O, but got I4
		//IL_06a0: Expected O, but got I4
		//IL_056a: Expected I, but got O
		//IL_0580: Expected O, but got I
		//IL_0589: Unknown result type (might be due to invalid IL or missing references)
		//IL_058e: Expected O, but got Unknown
		//IL_0604: Expected I, but got O
		//IL_0911: Expected O, but got I4
		//IL_0928: Expected I, but got I8
		//IL_0356: Expected I4, but got I8
		//IL_0356: Expected O, but got F4
		//IL_05e0: Expected I, but got I8
		//IL_03a4: Expected I, but got O
		//IL_03bc: Expected O, but got I
		//IL_0711: Expected O, but got Ref
		//IL_071f: Expected I, but got O
		//IL_043c: Expected O, but got I4
		//IL_0391: Expected O, but got I8
		//IL_03f8: Expected O, but got I
		//IL_07b1: Expected F4, but got I4
		//IL_07b1: Expected F4, but got O
		//IL_07b1: Expected F4, but got I4
		//IL_07b1: Expected O, but got I4
		//IL_042e: Expected O, but got I4
		//IL_0461: Unknown result type (might be due to invalid IL or missing references)
		//IL_0466: Expected O, but got Unknown
		//IL_0961->IL07b6: Incompatible stack heights: 1 vs 0
		//IL_0320->IL07b6: Incompatible stack heights: 1 vs 0
		//IL_0499->IL08e1: Incompatible stack heights: 1 vs 0
		//IL_049e->IL049e: Incompatible stack heights: 1 vs 0
		float scaleToArea = ((_indexInWeapon < 0) ? 1f : 1.5f);
		SetScaleToArea(scaleToArea);
		float2 ret = default(float2);
		int num11 = default(int);
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			float num2 = default(float);
			float alpha;
			if (!(num2 > 5f))
			{
				float num3 = num2 - 1f;
				num2 = num3 / 5f;
				float num4 = 1f - num2;
				float num5 = num4 * _AlphaDiff;
				alpha = num5 + _MaxAlpha;
			}
			else
			{
				alpha = _MaxAlpha;
			}
			ArcadeSprite arcadeSprite = setAlpha(alpha);
			GameManager core = GM.Core;
			if ((object)GM.Core != null && core._playerOptions != null)
			{
				PlayerOptionsData config = core._playerOptions.Config;
				if (config != null)
				{
					bool flag = config._003CFlashingVFXEnabled_003Ek__BackingField;
					object obj = 0;
					if (!flag)
					{
						ArcadeSprite arcadeSprite2 = setAlpha(0.2f);
						obj = 0;
						alpha = 0.2f;
					}
					if (_trailFade != null)
					{
						_trailFade.Kill();
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					if ((object)_trail != null)
					{
						Material material = ((Renderer)_trail).GetMaterial();
						if (array != null)
						{
							if ((object)material != null)
							{
								nint num6 = (nint)array;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj2 = default(object);
								if (obj2 == null)
								{
									ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
									throw ex;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null)
							{
								tweenConfig.targets = array;
								Material material2 = material;
								tweenConfig.duration = 500f;
								tweenConfig.alpha = (float?)(object)1;
								MultiTargetTween trailFade = Tweens.Add(tweenConfig);
								_trailFade = trailFade;
								bool flag2 = missilesToSpawn <= 0;
								TweenConfig tweenConfig2 = null;
								if (flag2)
								{
									goto IL_049e;
								}
								float num7 = default(float);
								float num10 = default(float);
								while (true)
								{
									Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
									if ((object)cachedTrans == null)
									{
										break;
									}
									bool flag3 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
									if (body != null)
									{
										BaseBody baseBody = body;
										ArcadeTransform arcadeTransform = baseBody._transform;
										if (baseBody._transform == null)
										{
											break;
										}
										arcadeTransform.position = ret;
									}
									if ((object)_weapon == null)
									{
										break;
									}
									TweenConfig tweenConfig3 = (TweenConfig)(object)_weapon.FireOneProjectile((Vector2)num7, -1);
									TweenConfig tweenConfig4;
									if (tweenConfig3 == null)
									{
										tweenConfig4 = null;
										material2 = (Material)4294967295L;
										goto IL_08c4;
									}
									nint num8 = (nint)typeof(FB_MultiStageProjectile);
									material2 = (Material)(object)tweenConfig3;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1321 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_MultiStageProjectile>)+130]");
									object obj3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ r8_v15 (UnityEngine.Material)+130]");
									nint num9 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1321 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_MultiStageProjectile>)+130]");
									object obj5;
									if (num9 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ r8_v15 (UnityEngine.Material)+C8]");
										object obj4 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rax_v56+FFFFFFF8+v1323 @ rax_v52*8]");
										if (0 == (nint)typeof(FB_MultiStageProjectile))
										{
											obj5 = 1;
											goto IL_08a2;
										}
									}
									obj5 = 0;
									goto IL_08a2;
									IL_08a2:
									bool flag4 = obj5 == null;
									tweenConfig4 = null;
									if (!flag4)
									{
										tweenConfig4 = tweenConfig3;
									}
									goto IL_08c4;
									IL_08c4:
									if (tweenConfig4 != null)
									{
									}
									tweenConfig2 = (TweenConfig)(tweenConfig2 + 1);
									bool flag5 = (nint)tweenConfig2 < missilesToSpawn;
									num2 = num7;
									alpha = num10;
									num11 = num11;
									if (flag5)
									{
										continue;
									}
									goto IL_049e;
								}
							}
						}
					}
				}
			}
		}
		goto IL_07b6;
		IL_07b6:
		throw new NullReferenceException();
		IL_049e:
		if ((object)_anim == null)
		{
			goto IL_07b6;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @187074010");
		object obj6 = default(object);
		if (obj6 != null)
		{
			goto IL_0637;
		}
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Crush Bomb-Explosion-F", 1, 7, "firstBlood", num11);
		Action action = null;
		nint num12 = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ rcx_v65 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_MultiStageProjectile>)+370]");
		nint method = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ r10_v9 (System.IntPtr)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = method;
		((Delegate)action).m_target = this;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ r10_v9 (System.IntPtr)+4C]");
		object obj7 = (nint)0 >> 4;
		object obj8 = obj7 & 1;
		nint num13;
		if (obj8 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ r10_v9 (System.IntPtr)+52]");
			if ((nint)0 == 0)
			{
				num13 = unchecked((nint)6447293664L);
				goto IL_0908;
			}
		}
		num13 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_0908;
		IL_0908:
		object obj9 = 24;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		bool flag6 = default(bool);
		Action action2 = default(Action);
		bool flag7 = default(bool);
		if ((object)_anim != null)
		{
			_anim.AddAnimation("bang", animationFrames, 16, (byte)num11 != 0, flag6, action2, flag7);
			goto IL_0637;
		}
		goto IL_07b6;
		IL_0637:
		if ((object)_anim != null)
		{
			_anim.SetAnimation("bang");
			if (body != null)
			{
				BaseBody baseBody2 = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
				Transform cachedTrans2 = ((ArcadeSprite)this).CachedTrans;
				if ((object)cachedTrans2 != null)
				{
					Vector3 localEulerAngles = cachedTrans2.localEulerAngles;
					Transform cachedTrans3 = ((ArcadeSprite)this).CachedTrans;
					if ((object)cachedTrans3 != null)
					{
						cachedTrans3.localEulerAngles = (Vector3)(&ret);
						nint num14 = (nint)typeof(float2);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1434 @ rax_v73 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
						nint num15 = 0;
						BaseBody baseBody3 = body;
						if (body != null)
						{
							baseBody3._velocity = float2.zero;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rcx_v59 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
							_ = 0;
							_timeSinceChangedTarget = -1000f;
							PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_Explosion1, 500f, 10, 0f, (float?)(object)num11, flag6 ? 1 : 0, (float)action2, flag7, 1f);
							return;
						}
					}
				}
			}
		}
		goto IL_07b6;
	}
}
