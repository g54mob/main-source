using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyDSkull : EnemyDMask
{
	private PhaserSprite _EyesSprite;

	private MultiTargetTween _eyesFadeTween;

	private MultiTargetTween _onEnterTween;

	public string EyesSprite
	{
		get
		{
			PhaserSprite eyesSprite = _EyesSprite;
			if ((object)_EyesSprite != null && (object)eyesSprite._spriteRenderer != null)
			{
				Sprite sprite = eyesSprite._spriteRenderer.sprite;
				if ((object)sprite != null)
				{
					return ((UnityEngine.Object)sprite).GetName();
				}
			}
			return (string)(object)new NullReferenceException();
		}
		set
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A623A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (value != null)
			{
				PhaserSprite phaserSprite = _EyesSprite.setFrame(value, "enemiesM");
			}
			else
			{
				PhaserSprite phaserSprite2 = _EyesSprite.setVisible(visible: false);
			}
		}
	}

	public bool FlipX
	{
		get
		{
			SpriteRenderer enemyRenderer = _EnemyRenderer;
			bool flag = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
		}
		set
		{
			_EnemyRenderer.flipX = value;
		}
	}

	protected unsafe override void OnUpdate()
	{
		//IL_01d4: Expected O, but got I4
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected I4, but got Unknown
		//IL_0099: Expected O, but got I4
		//IL_00da: Expected F4, but got O
		//IL_019f->IL0119: Incompatible stack heights: 1 vs 0
		//IL_01ee->IL0119: Incompatible stack heights: 2 vs 0
		//IL_0080->IL0119: Incompatible stack heights: 2 vs 0
		//IL_00c6->IL0119: Incompatible stack heights: 2 vs 0
		//IL_00f4->IL0119: Incompatible stack heights: 2 vs 0
		UpdateDepth();
		CheckRenderer();
		if ((object)((ArcadeSprite)this)._spriteRenderer != null)
		{
			Transform transform = ((ArcadeSprite)this)._spriteRenderer.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				float ret;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				Transform enemyRenderer = (Transform)(object)_EnemyRenderer;
				if ((object)_EnemyRenderer != null)
				{
					bool flag2 = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
					object obj = Renderer.get_sortingOrder_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr);
					if ((object)_EyesSprite != null)
					{
						int num = obj + 1000;
						PhaserSprite phaserSprite = _EyesSprite.setDepth(num);
						if ((object)_EyesSprite != null)
						{
							PhaserSprite phaserSprite2 = _EyesSprite.setScale(ret, (float?)(object)1);
							float2 float5 = base.position;
							if ((object)_EyesSprite != null)
							{
								_EyesSprite.X = (float)float5;
								if ((object)_EyesSprite != null)
								{
									object obj2 = default(object);
									float y = (float)obj2 - 0.04f;
									_EyesSprite.Y = y;
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

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_005e: Expected I, but got O
		//IL_00d4: Expected I4, but got I8
		//IL_00e2: Expected O, but got I4
		//IL_011e: Expected O, but got I4
		//IL_01b3: Expected I, but got O
		//IL_0217: Expected O, but got I4
		//IL_0272: Expected O, but got I4
		//IL_0272: Expected F4, but got O
		base.InitEnemy(enemyType, asRemote);
		if (_eyesFadeTween != null)
		{
			_eyesFadeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_EyesSprite != null)
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
		tweenConfig.duration = 500f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = -1;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween eyesFadeTween = Tweens.Add(tweenConfig);
		_eyesFadeTween = eyesFadeTween;
		((EnemyController)this)._003CIsCullable_003Ek__BackingField = false;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite = _EyesSprite.setVisible(visible: true);
		if (_onEnterTween != null)
		{
			_onEnterTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.duration = 100f;
		tweenConfig2.scale = (float?)(object)1;
		MultiTargetTween onEnterTween = Tweens.Add(tweenConfig2);
		_onEnterTween = onEnterTween;
		BaseBody baseBody = body;
		ArcadeTransform arcadeTransform = baseBody._transform;
		PhaserSprite phaserSprite2 = _EyesSprite.setOrigin((float)arcadeTransform._origin, (float?)(object)1);
	}

	public override void Despawn()
	{
		((EnemyController)this).Despawn();
		if (base._onEnterTween != null)
		{
			base._onEnterTween.Kill();
		}
		PhaserSprite phaserSprite = _EyesSprite.setVisible(visible: false);
	}

	public void SetEyes(string frameName = null)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A623A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (frameName != null)
		{
			PhaserSprite phaserSprite = _EyesSprite.setFrame(frameName, "enemiesM");
		}
		else
		{
			PhaserSprite phaserSprite2 = _EyesSprite.setVisible(visible: false);
		}
	}

	protected override void UpdateDepth()
	{
		//IL_0070: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		nint num = (nint)typeof(Math);
		int num2 = default(int);
		int sortingOrder = -num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rcx_v4 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 < (nint)0)
		{
			sortingOrder = num2;
		}
		_EnemyRenderer.sortingOrder = sortingOrder;
	}
}
