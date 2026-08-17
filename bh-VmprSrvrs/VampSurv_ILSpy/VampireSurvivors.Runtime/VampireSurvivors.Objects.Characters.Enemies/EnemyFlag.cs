using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyFlag : EnemyController
{
	protected TrailRenderer _Trail;

	protected Tween _fadeTrailTween;

	protected float _trailTime;

	protected bool _goingRight = true;

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_00ee: Expected O, but got F4
		//IL_015a: Expected O, but got F4
		//IL_0204: Expected O, but got Ref
		//IL_00c3: Expected O, but got I4
		//IL_01f5->IL00de: Incompatible stack heights: 1 vs 0
		//IL_0097->IL00de: Incompatible stack heights: 1 vs 0
		//IL_00b3->IL00cc: Incompatible stack heights: 1 vs 0
		base.InitEnemy(enemyType, asRemote);
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 * (float)Math.PI;
		EnemyData currentEnemyData = _currentEnemyData;
		float num2 = num + num;
		float num3 = (_medusaElapsed = num2 + _medusaElapsed);
		if (_currentEnemyData != null)
		{
			object obj3 = UnityEngine.Random.value;
			float num4 = num3 * currentEnemyData._003Cspeed_003Ek__BackingField;
			float num5 = num4 * 0.2f;
			float num6 = num5 + currentEnemyData._003Cspeed_003Ek__BackingField;
			base._003CSpeed_003Ek__BackingField = num6;
			Rect ret = default(Rect);
			Rect? rect = ((ArcadeSprite)(&ret)).frame;
			if ((object)rect == null)
			{
				ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)0);
				goto IL_00cc;
			}
			if ((object)((ArcadeSprite)this)._spriteRenderer != null)
			{
				Sprite sprite = ((ArcadeSprite)this)._spriteRenderer.sprite;
				if ((object)sprite != null)
				{
					Vector2 pivot = sprite.pivot;
					bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
					Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out ret);
					BaseBody baseBody = body;
					if (body != null && baseBody._transform != null)
					{
						float2 float5 = default(float2);
						baseBody._transform.setOrigin(float5);
						goto IL_00cc;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_00cc:
		InitTrail();
		_medusa = false;
	}

	public override void Disappear()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6247]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		base.Disappear();
		base._003CIsDead_003Ek__BackingField = true;
		_SpriteAnimation.SetAnimation("die");
		FadeTrailOut();
	}

	public override void Despawn()
	{
		SpriteAnimation spriteAnimation = _SpriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = true;
		FadeTrailOut(instant: true);
		base.Despawn();
	}

	protected override void OnUpdate()
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_00ad: Expected O, but got F4
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		UpdateDepth();
		if (!base._003CIsTimeStopped_003Ek__BackingField)
		{
			Vector2 vector = MovementCal();
			bool flag = !_receivingDamage;
			_currentDirection = vector;
			float num2;
			if (!flag)
			{
				float num = base._003CKnockBack_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				object obj = num ^ 0;
				num2 = (float)obj * _damageKb;
			}
			else
			{
				num2 = 1f;
			}
			bool flag2 = (nint)vector < 0;
			bool flag3 = (object)vector == null;
			bool flag4 = !flag2;
			bool flag5 = !flag3;
			bool flag6 = flag5 & flag4;
			base.SetFlipX(flag6);
			UpdateTrailFlip();
			float num3 = GameManager.EnemySpeed * base._003CSpeed_003Ek__BackingField;
			float num4 = num3 * num2;
			float num5 = num4 * base._003CSlow_003Ek__BackingField;
			float num6 = (float)_currentDirection * num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyFlag)+1E4]");
			float num7 = 0f * num5;
			float num8 = num6 * 0.01f;
			float num9 = num7 * 0.01f;
			BaseBody baseBody = body;
			baseBody._velocity = (float2)num8;
		}
	}

	protected unsafe virtual Vector2 MovementCal()
	{
		//IL_01c4: Expected O, but got F4
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected O, but got Unknown
		//IL_0093: Expected O, but got I
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_0144->IL00e9: Incompatible stack heights: 1 vs 0
		//IL_01bb->IL00e4: Incompatible stack heights: 2 vs 0
		if (!base._fixedDirection)
		{
			goto IL_00a1;
		}
		Vector2 vector = _currentDirection;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000187713B7Dh\"");
		bool flag = (object)_currentDirection != null;
		Vector2 vector2 = (Vector2)this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000187713B7Dh\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyFlag)+1E4]");
			bool flag2 = (nint)0 != 0;
			vector2 = (Vector2)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyFlag)+1E4]");
			vector = (Vector2)0;
			if (!flag2)
			{
				goto IL_00a1;
			}
		}
		goto IL_01bb;
		IL_00a1:
		RetargetIfNecessary();
		Transform targetTransform = base._targetTransform;
		if ((object)base._targetTransform != null)
		{
			bool flag3 = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)targetTransform).m_CachedPtr, out Vector3 ret);
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag4 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret2);
				Vector2 currentDirection = ret - ret2;
				object obj = default(object);
				object obj2 = default(object);
				vector = (Vector2)(obj - obj2);
				vector2 = (Vector2)(this + 480);
				_currentDirection = currentDirection;
				((Vector2*)vector2)->Normalize();
				goto IL_01bb;
			}
		}
		throw new NullReferenceException();
		IL_01bb:
		object obj3 = Time.deltaTime;
		float num = (float)vector * 1000f;
		float num2 = base._003CSpeed_003Ek__BackingField / 10416.25f;
		float num3 = num / 16.666f;
		float num4 = num3 * num2;
		float num5 = (_medusaElapsed = num4 + _medusaElapsed);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj4 = num5 ^ 0;
		Vector2 result = default(Vector2);
		return result;
	}

	protected virtual void InitTrail()
	{
		//IL_019a->IL011e: Incompatible stack heights: 1 vs 0
		//IL_00af->IL011e: Incompatible stack heights: 1 vs 0
		//IL_021c->IL011e: Incompatible stack heights: 2 vs 0
		//IL_00e7->IL011e: Incompatible stack heights: 2 vs 0
		EnemyData currentEnemyData = _currentEnemyData;
		if (_currentEnemyData != null)
		{
			Sprite sprite = SpriteManager.GetSprite(currentEnemyData._003CflagName_003Ek__BackingField, currentEnemyData._003CtextureName_003Ek__BackingField);
			object trail = _Trail;
			if ((object)_Trail != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdi_v7 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdi_v7 (System.Object)+10]");
				TrailRenderer.Clear_Injected((IntPtr)0);
				if ((object)_Trail != null)
				{
					_Trail.emitting = true;
					RenderingExtensions.SetMaterialToPackedSprite(_Trail, sprite);
					object trail2 = _Trail;
					if ((object)_Trail != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdi_v9 (System.Object)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdi_v9 (System.Object)+10]");
						TrailRenderer.set_textureMode_Injected((IntPtr)0, LineTextureMode.Stretch);
						float num = base._003CSpeed_003Ek__BackingField * 0.5f;
						float time = (_trailTime = num * 0.01f);
						if ((object)_Trail != null)
						{
							_Trail.time = time;
							if ((object)_Trail != null)
							{
								Material material = ((Renderer)_Trail).GetMaterial();
								RenderingExtensions.SetAlpha(material, 1f);
								TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected virtual void UpdateTrailFlip()
	{
		//IL_0086: Expected F4, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A624A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = (nint)_currentDirection < 0;
		bool flag2 = (object)_currentDirection == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flag5 = flag4 & flag3;
		if (_goingRight != flag5)
		{
			_goingRight = flag5;
			Material material = ((Renderer)_Trail).GetMaterial();
			int num = Shader.PropertyToID("_FlipY");
			bool flag6 = !_goingRight;
			material.SetFloatImpl(num, (float)(flag6 ? 1 : 0));
		}
	}

	protected override void Die()
	{
		base.Die();
		FadeTrailOut();
	}

	protected override void UpdateDepth()
	{
		int height = Screen.height;
		_EnemyRenderer.sortingOrder = height;
	}

	protected void FadeTrailOut(bool instant = false)
	{
		//IL_005e: Expected F4, but got I4
		Tween fadeTrailTween = _fadeTrailTween;
		if (_fadeTrailTween != null && fadeTrailTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_fadeTrailTween);
		}
		float duration = ((!instant) ? 0.3f : 0f);
		Material material = ((Renderer)_Trail).GetMaterial();
		TweenerCore<Color, Color, ColorOptions> fadeTrailTween2 = ShortcutExtensions.DOFade(material, 0f, duration);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TweenCallback tweenCallback = delegate
		{
			TrailRenderer trail = _Trail;
			bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
			TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
			_Trail.emitting = false;
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
		if ((nint)0 != 0)
		{
		}
		_fadeTrailTween = fadeTrailTween2;
		if (instant)
		{
			TweenExtensions.Complete(_fadeTrailTween, withCallbacks: false);
		}
	}

	private void _003CFadeTrailOut_003Eb__13_0()
	{
		TrailRenderer trail = _Trail;
		bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
		TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
		_Trail.emitting = false;
	}
}
