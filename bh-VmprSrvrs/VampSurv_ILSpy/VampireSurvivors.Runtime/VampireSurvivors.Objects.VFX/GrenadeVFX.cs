using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.VFX;

public class GrenadeVFX : PoolableMonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public PhaserSprite exp;

		internal void _003CAwake_003Eb__0()
		{
			PhaserSprite phaserSprite = exp.setVisible(visible: false);
		}
	}

	private SpriteRenderer _ScreenFillRenderer;

	private SpriteAnimation _BurstAnimation;

	private Timer _timer;

	private Transform _originalParent;

	private List<PhaserSprite> explosionSprites;

	private unsafe void Awake()
	{
		//IL_0098: Expected O, but got I4
		//IL_00b5: Expected O, but got I4
		//IL_0165: Expected I, but got O
		//IL_017b: Expected O, but got I
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected O, but got Unknown
		//IL_01f2: Expected I, but got O
		//IL_043c: Expected O, but got I4
		//IL_0453: Expected I, but got I8
		//IL_01db: Expected I, but got I8
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Expected O, but got Unknown
		//IL_04c8->IL0427: Incompatible stack heights: 1 vs 0
		//IL_033c->IL0427: Incompatible stack heights: 1 vs 0
		//IL_038b->IL0427: Incompatible stack heights: 1 vs 0
		//IL_0421->IL04cd: Incompatible stack heights: 1 vs 0
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_ScreenFillRenderer != null)
		{
			_ScreenFillRenderer.sprite = sprite;
			int num = default(int);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Crush Bomb-Explosion-F", 1, 7, "firstBlood", num);
			List<PhaserSprite> list = new List<PhaserSprite>();
			explosionSprites = list;
			object obj = 0;
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			while (true)
			{
				_003C_003Ec__DisplayClass5_0 obj2 = new _003C_003Ec__DisplayClass5_0();
				PhaserWorld instance = PhaserWorld.Instance;
				if ((object)instance == null)
				{
					break;
				}
				PhaserSprite exp = instance.AddPhaserSprite((Vector2)0, "firstBlood", "Crush Bomb-Explosion-F1");
				if (obj2 == null)
				{
					break;
				}
				obj2.exp = exp;
				PhaserSprite exp2 = obj2.exp;
				if ((object)obj2.exp == null)
				{
					break;
				}
				Action action = null;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r10_v5 (Il2CppMethodInfo)+8]");
				((Delegate)action).method_ptr = (IntPtr)0;
				((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass5_0._003CAwake_003Eb__0);
				((Delegate)action).m_target = obj2;
				((Delegate)action).method_code = (IntPtr)action;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r10_v5 (Il2CppMethodInfo)+4C]");
				object obj3 = (nint)0 >> 4;
				object obj4 = obj3 & 1;
				nint num3;
				if (obj4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r10_v5 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num3 = unchecked((nint)6447293664L);
						goto IL_0433;
					}
				}
				((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
				num3 = ((Delegate)action).method_ptr;
				goto IL_0433;
				IL_0433:
				object obj5 = 24;
				((Delegate)action).extra_arg = unchecked((nint)6447293568L);
				if ((object)exp2._spriteAnimation == null)
				{
					break;
				}
				exp2._spriteAnimation.AddAnimation("bang", animationFrames, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
				if ((object)obj2.exp == null)
				{
					break;
				}
				PhaserSprite phaserSprite = obj2.exp.setVisible(visible: false);
				if ((object)obj2.exp == null)
				{
					break;
				}
				Transform transform = obj2.exp.transform;
				if ((object)transform == null)
				{
					break;
				}
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ rcx_v30 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
				if ((object)obj2.exp == null)
				{
					break;
				}
				PhaserSprite phaserSprite2 = obj2.exp.setDepth(3000);
				List<object> list2 = (List<object>)(object)explosionSprites;
				if (explosionSprites == null)
				{
					break;
				}
				int version = list2._version + 1;
				list2._version = version;
				object[] items = list2._items;
				if (list2._items == null)
				{
					break;
				}
				if (list2._size >= items.Length)
				{
					((List<object>)(object)explosionSprites).AddWithResize((object)obj2.exp);
				}
				else
				{
					int size = list2._size + 1;
					list2._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				obj++;
				if ((nint)obj >= 64)
				{
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void SetParent(Transform newParent)
	{
		Transform transform = base.transform;
		Transform parent = transform.parent;
		_originalParent = parent;
		Transform transform2 = base.transform;
		transform2.SetParent(newParent, worldPositionStays: true);
	}

	public unsafe void Play(float volume = 1.8f)
	{
		//IL_0008: Expected O, but got Ref
		//IL_014d: Expected O, but got I
		//IL_00ab: Expected O, but got I
		//IL_0254: Invalid comparison between F4 and O
		//IL_0b2e: Expected O, but got F4
		//IL_0e3a: Expected O, but got F4
		//IL_0879: Expected I4, but got F4
		//IL_088b: Expected I, but got O
		//IL_08a1: Expected O, but got I
		//IL_08aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_08af: Expected O, but got Unknown
		//IL_0d17: Expected I4, but got F4
		//IL_0925: Expected I, but got O
		//IL_048d: Expected O, but got I
		//IL_049d: Expected O, but got I
		//IL_0d6c: Expected O, but got I4
		//IL_0d83: Expected I, but got I8
		//IL_0844: Expected O, but got I
		//IL_0852: Expected O, but got I4
		//IL_0863: Expected I4, but got F4
		//IL_0bb8: Expected O, but got Ref
		//IL_0901: Expected I, but got I8
		//IL_074a: Expected O, but got I
		//IL_075d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0762: Expected O, but got Unknown
		//IL_0a8c: Expected O, but got Ref
		//IL_056b: Expected O, but got I
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Expected O, but got Unknown
		//IL_035b->IL09a6: Incompatible stack heights: 1 vs 0
		//IL_069d->IL09a6: Incompatible stack heights: 1 vs 0
		//IL_038c->IL09a6: Incompatible stack heights: 1 vs 0
		//IL_0e63->IL09a6: Incompatible stack heights: 1 vs 0
		//IL_03e3->IL09a6: Incompatible stack heights: 2 vs 0
		//IL_0433->IL09a6: Incompatible stack heights: 2 vs 0
		//IL_0709->IL09a6: Incompatible stack heights: 1 vs 0
		//IL_046e->IL09a6: Incompatible stack heights: 2 vs 0
		//IL_0e11->IL09a6: Incompatible stack heights: 3 vs 0
		//IL_04c5->IL09a6: Incompatible stack heights: 3 vs 0
		//IL_0c10->IL09a6: Incompatible stack heights: 4 vs 0
		//IL_052a->IL09a6: Incompatible stack heights: 3 vs 0
		//IL_0782->IL0c15: Incompatible stack heights: 4 vs 0
		//IL_0794->IL09a6: Incompatible stack heights: 4 vs 0
		//IL_0ae4->IL09a6: Incompatible stack heights: 6 vs 0
		//IL_059b->IL09a6: Incompatible stack heights: 6 vs 0
		//IL_05b7->IL0ae9: Incompatible stack heights: 6 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		SetupScreenFill();
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_ScreenFillRenderer, 0.65f, 0.1f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 2;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
						object obj3 = num + 0;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = tweenerCore == null;
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore;
		if (!flag)
		{
			tweenerCore2 = tweenerCore;
			if ((object)_BurstAnimation != null)
			{
				_BurstAnimation.CleanAnimations();
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				_ = 0;
				soundConfig.Rate = 1f;
				soundConfig.Detune = -1000f;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+80]");
				soundConfig.Volume = (float?)(object)0;
				float num2 = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Rosary, soundConfig, 500f, 4, num2);
				List<PhaserSprite> list = explosionSprites;
				bool flag2 = explosionSprites == null;
				tweenerCore2 = (TweenerCore<Color, Color, ColorOptions>)(object)soundConfig;
				if (!flag2)
				{
					float num3 = (float)list._size * 0.5f;
					GameManager core = GM.Core;
					bool flag3 = (object)GM.Core == null;
					tweenerCore2 = null;
					TweenerCore<Color, Color, ColorOptions> tweenerCore3 = null;
					TweenerCore<Color, Color, ColorOptions> tweenerCore4 = null;
					if (!flag3)
					{
						MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
						int repeat = default(int);
						TimerType type = default(TimerType);
						while (true)
						{
							Stage stage = core._stage;
							bool flag4 = (object)core._stage == null;
							tweenerCore2 = tweenerCore4;
							if (flag4)
							{
								break;
							}
							List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
							bool flag5 = stage._spawnedEnemies == null;
							tweenerCore2 = tweenerCore4;
							if (flag5)
							{
								break;
							}
							Vector3 ret2;
							if ((nint)tweenerCore3 < spawnedEnemies._size && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) > System.Runtime.CompilerServices.Unsafe.As<TweenerCore<Color, Color, ColorOptions>, UIntPtr>(ref tweenerCore4))
							{
								GameManager core2 = GM.Core;
								bool flag6 = (object)GM.Core == null;
								tweenerCore2 = tweenerCore4;
								if (flag6)
								{
									break;
								}
								Stage stage2 = core2._stage;
								bool flag7 = (object)core2._stage == null;
								tweenerCore2 = tweenerCore4;
								if (flag7)
								{
									break;
								}
								List<EnemyController> spawnedEnemies2 = stage2._spawnedEnemies;
								bool flag8 = stage2._spawnedEnemies == null;
								tweenerCore2 = tweenerCore4;
								if (flag8)
								{
									break;
								}
								bool flag9 = (nint)tweenerCore4 >= spawnedEnemies2._size;
								EnemyController[] items = spawnedEnemies2._items;
								bool flag10 = spawnedEnemies2._items == null;
								tweenerCore2 = tweenerCore4;
								if (flag10)
								{
									break;
								}
								List<PhaserSprite> list2 = explosionSprites;
								bool flag11 = explosionSprites == null;
								tweenerCore2 = tweenerCore4;
								if (flag11)
								{
									break;
								}
								bool flag12 = (nint)tweenerCore4 >= list2._size;
								PhaserSprite[] items2 = list2._items;
								bool flag13 = list2._items == null;
								tweenerCore2 = tweenerCore4;
								if (flag13)
								{
									break;
								}
								Component component = items2[(object)tweenerCore4];
								object obj4 = items[(object)tweenerCore4];
								bool flag14 = (object)items[(object)tweenerCore4] == null;
								tweenerCore2 = tweenerCore4;
								if (flag14)
								{
									break;
								}
								Transform cachedTrans = ((ArcadeSprite)items[(object)tweenerCore4]).CachedTrans;
								bool flag15 = (object)cachedTrans == null;
								tweenerCore2 = tweenerCore4;
								if (flag15)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rax_v156 (UnityEngine.Transform)+10]");
								bool flag16 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rax_v156 (UnityEngine.Transform)+10]");
								Transform.get_position_Injected((IntPtr)0, out Vector3 _);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rdi_v30 (System.Object)+28]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rdi_v30 (System.Object)+28]");
									object obj5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ rax_v181+28]");
									object obj6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ rax_v181+28]");
									bool flag17 = (nint)0 == 0;
									tweenerCore2 = tweenerCore4;
									if (flag17)
									{
										break;
									}
								}
								bool flag18 = (object)items2[(object)tweenerCore4] == null;
								tweenerCore2 = tweenerCore4;
								if (flag18)
								{
									break;
								}
								Transform transform = items2[(object)tweenerCore4].transform;
								Transform transform2 = items2[(object)tweenerCore4].transform;
								bool flag19 = (object)transform2 == null;
								tweenerCore2 = tweenerCore4;
								if (flag19)
								{
									break;
								}
								_ = 0;
								bool flag20 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret2);
								bool flag21 = (object)transform == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2391 @ rax_v163 (UnityEngine.Transform)+10]");
								bool flag22 = (nint)0 == 0;
								object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2391 @ rax_v163 (UnityEngine.Transform)+10]");
								Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj7);
								PhaserSprite phaserSprite = items2[(object)tweenerCore4].setVisible(visible: true);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ r15_v26 (UnityEngine.Component)+30]");
								bool flag23 = (nint)0 == 0;
								tweenerCore2 = tweenerCore4;
								if (flag23)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ r15_v26 (UnityEngine.Component)+30]");
								((BaseSpriteAnimation)0).SetAnimation("bang");
								tweenerCore2 = (TweenerCore<Color, Color, ColorOptions>)(tweenerCore4 + 1);
								core = GM.Core;
								if ((object)GM.Core == null)
								{
									break;
								}
								tweenerCore3 = tweenerCore2;
								tweenerCore4 = tweenerCore2;
								continue;
							}
							IntPtr main_Injected = Camera.get_main_Injected();
							Camera camera = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Camera>(main_Injected);
							Bounds bounds = CameraExtensions.OrthographicBounds(camera);
							List<PhaserSprite> list3 = explosionSprites;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1353 @ rax_v74 (UnityEngine.Bounds)+10]");
							_ = 0;
							_ = bounds.m_Center;
							bool flag24 = explosionSprites == null;
							tweenerCore2 = tweenerCore4;
							if (flag24)
							{
								break;
							}
							while (true)
							{
								if ((nint)tweenerCore4 < list3._size)
								{
									List<PhaserSprite> list4 = explosionSprites;
									bool flag25 = explosionSprites == null;
									tweenerCore2 = tweenerCore4;
									if (flag25)
									{
										break;
									}
									bool flag26 = (nint)tweenerCore4 >= list4._size;
									PhaserSprite[] items3 = list4._items;
									bool flag27 = list4._items == null;
									tweenerCore2 = tweenerCore4;
									if (flag27)
									{
										break;
									}
									Component component2 = items3[(object)tweenerCore4];
									object obj8 = UnityEngine.Random.value;
									object obj9 = UnityEngine.Random.value;
									bool flag28 = (object)items3[(object)tweenerCore4] == null;
									tweenerCore2 = tweenerCore4;
									if (flag28)
									{
										break;
									}
									Transform transform3 = items3[(object)tweenerCore4].transform;
									Transform transform4 = items3[(object)tweenerCore4].transform;
									bool flag29 = (object)transform4 == null;
									tweenerCore2 = tweenerCore4;
									if (flag29)
									{
										break;
									}
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rax_v127 (UnityEngine.Transform)+10]");
									bool flag30 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rax_v127 (UnityEngine.Transform)+10]");
									Transform.get_position_Injected((IntPtr)0, out ret2);
									bool flag31 = (object)transform3 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2242 @ rax_v126 (UnityEngine.Transform)+10]");
									bool flag32 = (nint)0 == 0;
									object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2242 @ rax_v126 (UnityEngine.Transform)+10]");
									Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj10);
									PhaserSprite phaserSprite2 = items3[(object)tweenerCore4].setVisible(visible: true);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ r15_v25 (UnityEngine.Component)+30]");
									bool flag33 = (nint)0 == 0;
									tweenerCore2 = tweenerCore4;
									if (flag33)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ r15_v25 (UnityEngine.Component)+30]");
									((BaseSpriteAnimation)0).SetAnimation("bang");
									list3 = explosionSprites;
									tweenerCore4 = (TweenerCore<Color, Color, ColorOptions>)(tweenerCore4 + 1);
									if (explosionSprites == null)
									{
										tweenerCore2 = tweenerCore4;
										break;
									}
									continue;
								}
								tweenerCore2 = (TweenerCore<Color, Color, ColorOptions>)(object)_ScreenFillRenderer;
								if ((object)_ScreenFillRenderer == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ rbx_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
								bool canPause;
								bool useRealTime;
								Action action;
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ rbx_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
									Renderer.set_sortingOrder_Injected((IntPtr)0, 10000);
									if ((object)_BurstAnimation == null)
									{
										break;
									}
									SpriteRenderer component3 = _BurstAnimation.GetComponent<SpriteRenderer>();
									bool flag34 = (object)component3 == null;
									tweenerCore2 = (TweenerCore<Color, Color, ColorOptions>)(object)component3;
									if (flag34)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ rax_v82 (UnityEngine.SpriteRenderer)+10]");
									if ((nint)0 == 0)
									{
										UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(component3);
										tweenerCore2 = (TweenerCore<Color, Color, ColorOptions>)(object)component3;
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ rax_v82 (UnityEngine.SpriteRenderer)+10]");
									Renderer.set_sortingOrder_Injected((IntPtr)0, 10000);
									Timer timer = _timer;
									if (_timer == null)
									{
										canPause = false;
										useRealTime = (byte)(int)num2 != 0;
									}
									else
									{
										bool isDone = _timer.IsDone;
										canPause = false;
										useRealTime = (byte)(int)num2 != 0;
										if (!isDone)
										{
											_ = 0;
											float timeElapsed = _timer.GetTimeElapsed();
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+80]");
											timer._timeElapsedBeforeCancel = (float?)(object)0;
											timer._timeElapsedBeforePause = (float?)(object)0;
											canPause = false;
											useRealTime = (byte)(int)num2 != 0;
										}
									}
									action = null;
									nint num4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2028 @ r10_v1 (Il2CppMethodInfo)+8]");
									((Delegate)action).method_ptr = (IntPtr)0;
									((Delegate)action).method = (nint)__ldftn(GrenadeVFX.Cleanup);
									((Delegate)action).m_target = this;
									((Delegate)action).method_code = (IntPtr)action;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2028 @ r10_v1 (Il2CppMethodInfo)+4C]");
									object obj11 = (nint)0 >> 4;
									object obj12 = obj11 & 1;
									nint num5;
									if (obj12 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2028 @ r10_v1 (Il2CppMethodInfo)+52]");
										if ((nint)0 == 0)
										{
											num5 = unchecked((nint)6447293664L);
											goto IL_0d63;
										}
									}
									num5 = ((Delegate)action).method_ptr;
									((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
									goto IL_0d63;
								}
								UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(tweenerCore2);
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 395 ConditionalJump @-1, v405 @ TEMP_v71 (System.Boolean) --- -1 Nop");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 443 ConditionalJump @-1, v407 @ TEMP_v73 (System.Boolean) --- -1 Nop");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 917 ConditionalJump @-1, v413 @ TEMP_v59 (System.Boolean) --- -1 Nop");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 528 ConditionalJump @-1, v1832 @ ZF_v115 (System.Boolean) --- -1 Nop");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 649 ConditionalJump @-1, v1580 @ ZF_v123 (System.Boolean) --- -1 Nop");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 691 ConditionalJump @-1, v1397 @ ZF_v126 (System.Boolean) --- -1 Nop");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 727 ConditionalJump @-1, v1221 @ ZF_v128 (System.Boolean) --- -1 Nop");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1074 ConditionalJump @-1, v2465 @ ZF_v86 (System.Boolean) --- -1 Nop");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1116 ConditionalJump @-1, v2571 @ ZF_v89 (System.Boolean) --- -1 Nop");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1152 ConditionalJump @-1, v2435 @ ZF_v91 (System.Boolean) --- -1 Nop");
								/*Error: End of method reached without returning.*/;
								IL_0d63:
								object obj13 = 24;
								((Delegate)action).extra_arg = unchecked((nint)6447293568L);
								Timer timer2 = Timers.Register(0.5f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause);
								_timer = timer2;
								return;
							}
							break;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Cleanup()
	{
		if (_timer != null)
		{
			_timer.Cancel();
		}
		Transform transform = base.transform;
		transform.SetParent(_originalParent, worldPositionStays: true);
		GameObject obj = base.gameObject;
		base._parentPool.Release(obj);
	}

	private unsafe void SetupScreenFill()
	{
		//IL_01e4: Expected O, but got I4
		//IL_0291: Expected O, but got I4
		//IL_006b->IL00f5: Incompatible stack heights: 3 vs 0
		//IL_02ab->IL00f5: Incompatible stack heights: 3 vs 0
		//IL_00ab->IL00f5: Incompatible stack heights: 3 vs 0
		//IL_00d7->IL00f5: Incompatible stack heights: 3 vs 0
		//IL_0288->IL01da: Incompatible stack heights: 7 vs 3
		SpriteRenderer screenFillRenderer = _ScreenFillRenderer;
		if ((object)_ScreenFillRenderer != null)
		{
			bool flag = ((UnityEngine.Object)screenFillRenderer).m_CachedPtr == (IntPtr)0;
			SpriteRenderer.get_color_Injected(((UnityEngine.Object)screenFillRenderer).m_CachedPtr, out Color ret);
			Camera screenFillRenderer2 = (Camera)(object)_ScreenFillRenderer;
			bool flag2 = (object)_ScreenFillRenderer == null;
			bool flag3 = ((UnityEngine.Object)screenFillRenderer2).m_CachedPtr == (IntPtr)0;
			Color value = default(Color);
			SpriteRenderer.set_color_Injected(((UnityEngine.Object)screenFillRenderer2).m_CachedPtr, ref value);
			Camera main = Camera.main;
			if ((object)main == null || ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			Camera main2 = Camera.main;
			if ((object)main2 != null)
			{
				float orthographicSize = main2.orthographicSize;
				object obj = Screen.height;
				object obj2 = Screen.width;
				if ((object)_ScreenFillRenderer != null)
				{
					Sprite sprite = _ScreenFillRenderer.sprite;
					if ((object)_ScreenFillRenderer != null)
					{
						Transform transform = _ScreenFillRenderer.transform;
						if ((object)sprite != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v61 (UnityEngine.Sprite)+10]");
							bool flag4 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v61 (UnityEngine.Sprite)+10]");
							Sprite.get_bounds_Injected((IntPtr)0, out *(Bounds*)(&ret));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v61 (UnityEngine.Sprite)+10]");
							bool flag5 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v61 (UnityEngine.Sprite)+10]");
							Sprite.get_bounds_Injected((IntPtr)0, out Bounds _);
							bool flag6 = (object)transform == null;
							bool flag7 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SetupBurstAnim()
	{
		_BurstAnimation.CleanAnimations();
	}

	private void ResetParent()
	{
		Transform transform = base.transform;
		transform.SetParent(_originalParent, worldPositionStays: true);
	}

	public GrenadeVFX()
	{
		//IL_0020: Expected I, but got O
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
