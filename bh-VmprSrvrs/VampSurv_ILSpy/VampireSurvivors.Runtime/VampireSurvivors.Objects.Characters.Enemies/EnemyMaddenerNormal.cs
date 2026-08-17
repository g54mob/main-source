using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyMaddenerNormal : EnemyAlias
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__16_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CSingleWarning_003Eb__16_0()
		{
			//IL_003d: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = 1200f;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Pizza, soundConfig, 150f, 2, time);
		}
	}

	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public Transform singleWarningTransform;

		public GameObject singleWarningObject;

		public TweenCallback _003C_003E9__2;

		internal unsafe void _003CSingleWarning_003Eb__1()
		{
			//IL_00d6: Expected O, but got Ref
			object obj = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(singleWarningTransform, (Vector3)(&obj), 0.2f);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 0.2f);
			TweenCallback tweenCallback = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				tweenCallback = (_003C_003E9__2 = delegate
				{
					UnityEngine.Object.Destroy(singleWarningObject, 0f);
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
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

		internal void _003CSingleWarning_003Eb__2()
		{
			UnityEngine.Object.Destroy(singleWarningObject, 0f);
		}
	}

	private GameObject _SingleWarningPrefab;

	private float _spinRadius;

	private Tween _onEnterTween;

	private Tween _lowerScreenTween;

	private Tween _spinningTween;

	private Sequence _killTween;

	private Bounds _camBounds;

	private SpriteRenderer _ringSprite;

	private Action _003COnDefeat_003Ek__BackingField;

	public Action OnDefeat
	{
		get
		{
			return _003COnDefeat_003Ek__BackingField;
		}
		set
		{
			_003COnDefeat_003Ek__BackingField = value;
		}
	}

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0402: Expected I, but got O
		//IL_03c9: Expected O, but got Ref
		//IL_0459: Expected O, but got Ref
		//IL_05ce: Expected I, but got O
		//IL_060b: Expected O, but got Ref
		//IL_04c8: Expected O, but got Ref
		//IL_0531: Expected O, but got Ref
		//IL_059c: Expected O, but got Ref
		//IL_0111->IL038a: Incompatible stack heights: 1 vs 0
		//IL_0488->IL038a: Incompatible stack heights: 2 vs 0
		//IL_0135->IL0135: Incompatible stack heights: 1 vs 0
		//IL_028b->IL038a: Incompatible stack heights: 2 vs 0
		//IL_02ad->IL038a: Incompatible stack heights: 2 vs 0
		//IL_02dc->IL038a: Incompatible stack heights: 2 vs 0
		//IL_05c0->IL038a: Incompatible stack heights: 8 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_isImmuneToModification = true;
		base.InitEnemy(enemyType, asRemote);
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		SpriteRenderer ringSprite = _ringSprite;
		_camBounds = (Bounds)bounds.m_Center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v5 (UnityEngine.Bounds)+10]");
		_ = 0;
		if ((object)_ringSprite != null && ((UnityEngine.Object)ringSprite).m_CachedPtr != (IntPtr)0)
		{
			goto IL_0135;
		}
		Transform cachedTransform = _cachedTransform;
		Vector2 vector = default(Vector2);
		if ((object)_cachedTransform != null)
		{
			_ = 0;
			_ = 0;
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)obj3);
			GameObject gameObject = base.gameObject;
			SpriteRenderer component = RenderingExtensions.AddSprite(gameObject, vector, "vfx", "sPFX_ring_64");
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(component, 0f);
			Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
			if ((object)spriteRenderer != null)
			{
				((Renderer)spriteRenderer).SetMaterial(material);
				_ringSprite = spriteRenderer;
				goto IL_0135;
			}
		}
		goto IL_038a;
		IL_038a:
		throw new NullReferenceException();
		IL_0135:
		Transform cachedTransform2 = _cachedTransform;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rax_v43 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		bool flag2 = (object)_cachedTransform == null;
		_ = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ rax_v44 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		bool flag3 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref *(Vector3*)obj4);
		nint num3 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v969 @ rax_v51 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num4 = 0;
		_ = Vector3.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v970 @ rcx_v44 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num5 = 0f * _scaleMul;
		Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, endValue, 0.3f);
		TweenCallback tweenCallback = delegate
		{
			Transform cachedTransform5 = _cachedTransform;
			bool flag10 = ((UnityEngine.Object)cachedTransform5).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform5).m_CachedPtr, ref value);
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v989 @ rax_v52 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tweenerCore != null)
		{
			_onEnterTween = tweenerCore;
			float num6 = (float)vector * 2f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyMaddenerNormal)+2BC]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyMaddenerNormal)+2B4]");
			_ = 0;
			float num7 = num6 * 0.5f;
			GameSessionData gameSessionData = _gameSessionData;
			((EnemyController)this)._003CIsCullable_003Ek__BackingField = false;
			((EnemyController)this)._003CIsTeleportOnCull_003Ek__BackingField = true;
			float spinRadius = num7 - 0.24f;
			_spinRadius = spinRadius;
			if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
			{
				Transform transform = gameSessionData._activeCharacter.transform;
				if ((object)transform != null)
				{
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v61 (UnityEngine.Transform)+10]");
					bool flag4 = (nint)0 == 0;
					object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v61 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj5);
					object cachedTransform3 = _cachedTransform;
					bool flag5 = (object)_cachedTransform == null;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1209 @ rdi_v22 (System.Object)+10]");
					bool flag6 = (nint)0 == 0;
					object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1209 @ rdi_v22 (System.Object)+10]");
					Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj6);
					bool flag7 = (object)_SpriteAnimation == null;
					_SpriteAnimation.SetAnimation("idle");
					object cachedTransform4 = _cachedTransform;
					bool flag8 = (object)_cachedTransform == null;
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1352 @ rdi_v23 (System.Object)+10]");
					bool flag9 = (nint)0 == 0;
					object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1352 @ rdi_v23 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj7);
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1061 Invalid \"Jump target not found in method: 0x187731290\"");
				}
			}
		}
		goto IL_038a;
	}

	public override void Despawn()
	{
		base.Despawn();
		Action action = _003COnDefeat_003Ek__BackingField;
		if (_003COnDefeat_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v5.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		_003COnDefeat_003Ek__BackingField = null;
	}

	protected override void UpdateDepth()
	{
		object enemyRenderer = _EnemyRenderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rbx_v2 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 74 ConditionalJump @-1, v83 @ ZF_v7 (System.Boolean) --- -1 Nop");
		/*Error: End of method reached without returning.*/;
	}

	protected unsafe override void Die()
	{
		//IL_00e9: Expected O, but got I4
		//IL_0357: Expected O, but got Ref
		//IL_01ff: Expected O, but got I4
		//IL_020e: Expected O, but got I4
		//IL_039a: Expected O, but got I4
		//IL_01bf: Expected O, but got I
		((EnemyController)this).Die();
		GameManager gameManager = _gameManager;
		Stage stage = gameManager._stage;
		BackgroundManager fancyBg = stage._fancyBg;
		if ((object)stage._fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0)
		{
			GameManager gameManager2 = _gameManager;
			Stage stage2 = gameManager2._stage;
			BackgroundManager fancyBg2 = stage2._fancyBg;
			if (fancyBg2._003CAlias_003Ek__BackingField)
			{
				_SpriteAnimation.SetAnimation("Alias_Death");
			}
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Deathscream, soundConfig, 150f, 2, time);
		Transform target = _ringSprite.transform;
		Vector3 vector = Vector3.oneVector;
		object obj = default(object);
		float num = (float)obj * 16f;
		Vector3 vector2 = default(Vector3);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&vector2), 0.3f);
		object obj2;
		nint num3;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						vector = (Vector3)(num2 + 0);
					}
					TweenCallback tweenCallback = delegate
					{
						_ringSprite.enabled = false;
					};
					tweenCallback2 = tweenCallback;
					obj2 = 0;
					num3 = 0;
					goto IL_022a;
				}
			}
		}
		TweenCallback tweenCallback3 = delegate
		{
			_ringSprite.enabled = false;
		};
		bool flag = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		obj2 = 0;
		num3 = 0;
		object obj3 = 0;
		Vector3 vector3 = vector;
		nint num4 = 0;
		if (!flag)
		{
			goto IL_022a;
		}
		goto IL_0289;
		IL_0289:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Action action = _003COnDefeat_003Ek__BackingField;
		if (_003COnDefeat_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v722.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		_003COnDefeat_003Ek__BackingField = null;
		return;
		IL_022a:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		bool flag2 = (nint)0 == 0;
		obj3 = obj2;
		vector3 = vector;
		num4 = num3;
		if (!flag2)
		{
			obj3 = obj2;
			vector3 = vector;
			num4 = num3;
		}
		goto IL_0289;
	}

	private unsafe void SingleWarning(Vector2 pos)
	{
		//IL_003e: Expected O, but got I8
		//IL_041f: Expected O, but got Ref
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected O, but got Unknown
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected O, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		//IL_04e9: Expected O, but got I4
		//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Expected O, but got Unknown
		//IL_04d6->IL0336: Incompatible stack heights: 5 vs 0
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals19 = new _003C_003Ec__DisplayClass16_0();
		GameObject singleWarningObject = UnityEngine.Object.Instantiate(_SingleWarningPrefab);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore;
		if (CS_0024_003C_003E8__locals19 != null)
		{
			object obj = 6603577472L;
			CS_0024_003C_003E8__locals19.singleWarningObject = singleWarningObject;
			if ((object)CS_0024_003C_003E8__locals19.singleWarningObject != null)
			{
				Transform transform = CS_0024_003C_003E8__locals19.singleWarningObject.transform;
				if ((object)CS_0024_003C_003E8__locals19.singleWarningObject != null)
				{
					Component componentInChildren = CS_0024_003C_003E8__locals19.singleWarningObject.GetComponentInChildren<SpriteRenderer>(includeInactive: false);
					if ((object)componentInChildren != null)
					{
						Transform singleWarningTransform = componentInChildren.transform;
						CS_0024_003C_003E8__locals19.singleWarningTransform = singleWarningTransform;
						GameObject singleWarningTransform2 = (GameObject)(object)CS_0024_003C_003E8__locals19.singleWarningTransform;
						bool flag = ((UnityEngine.Object)singleWarningTransform2).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localScale_Injected(((UnityEngine.Object)singleWarningTransform2).m_CachedPtr, ref value);
						bool flag2 = ((UnityEngine.Object)componentInChildren).m_CachedPtr == (IntPtr)0;
						Renderer.set_sortingOrder_Injected(((UnityEngine.Object)componentInChildren).m_CachedPtr, 9000);
						Vector2 newPivot = default(Vector2);
						Sprite sprite = SpriteManager.GetSprite("ExclamationMark", newPivot, "UI");
						((SpriteRenderer)componentInChildren).sprite = sprite;
						bool flag3 = (object)transform == null;
						bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Vector2 value2 = default(Vector2);
						Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value2));
						Camera main = Camera.main;
						bool flag5 = (object)main == null;
						Transform parent = main.transform;
						transform.SetParent(parent, worldPositionStays: true);
						TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(CS_0024_003C_003E8__locals19.singleWarningTransform, (Vector3)(&value), 0.2f);
						tweenerCore = TweenSettingsExtensions.SetDelay(t, 1f);
						TweenCallback tweenCallback = _003C_003Ec._003C_003E9__16_0;
						if (_003C_003Ec._003C_003E9__16_0 == null)
						{
							tweenCallback = (_003C_003Ec._003C_003E9__16_0 = delegate
							{
								//IL_003d: Expected O, but got I4
								SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
								soundConfig.Volume = (float?)(object)1;
								soundConfig.Detune = 1200f;
								soundConfig.Rate = 1f;
								float time = default(float);
								PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Pizza, soundConfig, 150f, 2, time);
							});
						}
						TweenCallback tweenCallback3;
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1093 @ rax_v60 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
								if ((nint)0 != 0)
								{
									object obj2 = tweenerCore + 32;
									object obj3 = obj2 >> 12;
									object obj4 = obj3 & 0x1FFFFF;
									object obj5 = obj4 >> 6;
									object obj6 = obj4 & 0x3F;
									nint num2;
									do
									{
										object obj7 = 1 << (int)obj6;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r15_v10+462E0+v1243 @ rdx_v41*8]");
										object obj8 = 0 | obj7;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r15_v10+462E0+v1243 @ rdx_v41*8]");
										nint num = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r15_v10+462E0+v1243 @ rdx_v41*8]");
										if (num == 0)
										{
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r15_v10+462E0+v1243 @ rdx_v41*8]");
										num2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r15_v10+462E0+v1243 @ rdx_v41*8]");
									}
									while (num2 != 0);
									TweenCallback tweenCallback2 = delegate
									{
										//IL_00d6: Expected O, but got Ref
										object obj9 = default(object);
										TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScale(CS_0024_003C_003E8__locals19.singleWarningTransform, (Vector3)(&obj9), 0.2f);
										TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t2, 0.2f);
										TweenCallback tweenCallback5 = CS_0024_003C_003E8__locals19._003C_003E9__2;
										if (CS_0024_003C_003E8__locals19._003C_003E9__2 == null)
										{
											tweenCallback5 = (CS_0024_003C_003E8__locals19._003C_003E9__2 = delegate
											{
												UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals19.singleWarningObject, 0f);
											});
										}
										if (tweenerCore2 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
											if ((nint)0 == 0)
											{
											}
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
										if ((nint)0 == 0)
										{
											_ = 1;
										}
									};
									tweenCallback3 = tweenCallback2;
									goto IL_02c8;
								}
							}
						}
						TweenCallback tweenCallback4 = delegate
						{
							//IL_00d6: Expected O, but got Ref
							object obj9 = default(object);
							TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScale(CS_0024_003C_003E8__locals19.singleWarningTransform, (Vector3)(&obj9), 0.2f);
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t2, 0.2f);
							TweenCallback tweenCallback5 = CS_0024_003C_003E8__locals19._003C_003E9__2;
							if (CS_0024_003C_003E8__locals19._003C_003E9__2 == null)
							{
								tweenCallback5 = (CS_0024_003C_003E8__locals19._003C_003E9__2 = delegate
								{
									UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals19.singleWarningObject, 0f);
								});
							}
							if (tweenerCore2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
								if ((nint)0 == 0)
								{
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
						};
						bool flag6 = tweenerCore == null;
						tweenCallback3 = tweenCallback4;
						if (!flag6)
						{
							goto IL_02c8;
						}
						goto IL_02f7;
					}
				}
			}
		}
		goto IL_0336;
		IL_02c8:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1093 @ rax_v60 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_02f7;
		IL_02f7:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tweenerCore != null)
		{
			return;
		}
		goto IL_0336;
		IL_0336:
		throw new NullReferenceException();
	}

	private void _003CInitEnemy_003Eb__12_0()
	{
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
	}

	private void _003CDie_003Eb__15_0()
	{
		_ringSprite.enabled = false;
	}
}
