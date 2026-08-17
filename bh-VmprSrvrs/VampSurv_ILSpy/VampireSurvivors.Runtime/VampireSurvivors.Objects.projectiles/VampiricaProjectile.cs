using System;
using System.Threading;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using Zenject;

namespace VampireSurvivors.Objects.Projectiles;

public class VampiricaProjectile : Projectile
{
	private MultiTargetTween _tween;

	private MultiTargetTween _tween2;

	private SpriteRenderer _ghost1;

	private SpriteRenderer _ghost2;

	private bool _doneInit;

	private float _previousArea;

	protected override void Awake()
	{
		//IL_01a5->IL0127: Incompatible stack heights: 1 vs 0
		//IL_006f->IL0127: Incompatible stack heights: 1 vs 0
		//IL_00c4->IL0127: Incompatible stack heights: 2 vs 0
		base.Awake();
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
			if ((object)this != null)
			{
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				SpriteRenderer ghost = RenderingExtensions.AddSprite(gameObject, pos, "vfx", "slash");
				_ghost1 = ghost;
				Transform transform2 = base.transform;
				if ((object)transform2 != null)
				{
					bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
					GameObject gameObject2 = base.gameObject;
					SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject2, pos, "vfx", "slash");
					Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
					if ((object)spriteRenderer != null)
					{
						((Renderer)spriteRenderer).SetMaterial(material);
						_ghost2 = spriteRenderer;
						SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTint(_renderer, 1114129u);
						SpriteRenderer spriteRenderer3 = RenderingExtensions.SetTint(_ghost2, 6684774u);
						SpriteRenderer spriteRenderer4 = RenderingExtensions.SetTint(_ghost1, 16711680u);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0b24: Expected O, but got I4
		//IL_0213: Expected O, but got I4
		//IL_0272: Expected O, but got I4
		//IL_00ab: Expected I, but got O
		//IL_05e2: Expected I, but got O
		//IL_05f5: Expected O, but got I4
		//IL_062a: Expected I, but got O
		//IL_0163: Expected O, but got I4
		//IL_06fe: Expected I4, but got I8
		//IL_0404: Expected O, but got I4
		//IL_0795: Expected O, but got I4
		//IL_0731: Expected O, but got I4
		//IL_073a: Unknown result type (might be due to invalid IL or missing references)
		//IL_073f: Expected O, but got Unknown
		//IL_0748: Unknown result type (might be due to invalid IL or missing references)
		//IL_074d: Expected I4, but got Unknown
		//IL_0760: Expected O, but got I4
		//IL_07d5: Expected O, but got I
		//IL_07db: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e0: Expected O, but got Unknown
		//IL_0cae: Expected I4, but got I8
		//IL_0da7: Expected O, but got I4
		//IL_080f: Expected O, but got I4
		//IL_0818: Unknown result type (might be due to invalid IL or missing references)
		//IL_081d: Expected O, but got Unknown
		//IL_0826: Unknown result type (might be due to invalid IL or missing references)
		//IL_082b: Expected I4, but got Unknown
		//IL_0a3d: Expected O, but got I4
		//IL_0a4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4f: Expected O, but got Unknown
		//IL_0a65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6a: Expected I4, but got Unknown
		//IL_0aa3: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		float num2 = default(float);
		if (!_doneInit)
		{
			if ((object)_weapon != null)
			{
				float num = _weapon.PArea();
				_previousArea = num2;
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				Transform transform = base.transform;
				if (array != null)
				{
					if ((object)transform != null)
					{
						nint num3 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj = default(object);
						if (obj == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig != null)
					{
						tweenConfig.targets = array;
						if ((object)_weapon != null)
						{
							float num4 = _weapon.PArea();
							tweenConfig.duration = 100f;
							tweenConfig.ease = Ease.Linear;
							tweenConfig.scale = (float?)(object)1;
							MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
							if (multiTargetTween != null)
							{
								MultiTargetTween tween = multiTargetTween.SetAutoKill(autoKill: false);
								_tween = tween;
								goto IL_01b8;
							}
						}
					}
				}
			}
			goto IL_0af6;
		}
		goto IL_01b8;
		IL_01b8:
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_ghost1, 1f);
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_ghost2, 1f);
		bool flag = _tween == null;
		object obj2 = 0;
		if (flag)
		{
			goto IL_0438;
		}
		if ((object)_weapon != null)
		{
			float num5 = _weapon.PArea();
			bool flag2 = _previousArea == num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001872FCEC0h\"");
			obj2 = 0;
			if (flag2)
			{
				goto IL_0409;
			}
			if (_tween != null)
			{
				_tween.Kill();
				TweenConfig tweenConfig2 = new TweenConfig();
				object[] array2 = new object[1];
				Transform transform2 = base.transform;
				if (array2 != null)
				{
					if ((object)transform2 != null)
					{
						object obj3 = array2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj4 = default(object);
						if (obj4 == null)
						{
							ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
							throw ex2;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig2 != null && (object)_weapon != null)
					{
						float num6 = _weapon.PArea();
						_ = 1120403456;
						_ = 1;
						_ = 1;
						MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
						if (multiTargetTween2 != null)
						{
							MultiTargetTween tween2 = multiTargetTween2.SetAutoKill(autoKill: false);
							_tween = tween2;
							obj2 = 0;
							goto IL_0409;
						}
					}
				}
			}
		}
		goto IL_0af6;
		IL_0409:
		if (_tween != null)
		{
			_tween.Restart();
			goto IL_0438;
		}
		goto IL_0af6;
		IL_0438:
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[3];
		if (array3 != null)
		{
			if ((object)_renderer != null)
			{
				int value = ((int*)(&array3))->m_value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj5 = default(object);
				if (obj5 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_ghost1 != null)
			{
				int value2 = ((int*)(&array3))->m_value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj6 = default(object);
				if (obj6 == null)
				{
					ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
					throw ex4;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_ghost2 != null)
			{
				int value3 = ((int*)(&array3))->m_value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj7 = default(object);
				if (obj7 == null)
				{
					ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
					throw ex5;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if (tweenConfig3 != null)
			{
				((UnityEngine.Object)(object)tweenConfig3).m_CachedPtr = (IntPtr)array3;
				((MonoBehaviour)(object)tweenConfig3).m_CancellationTokenSource = (CancellationTokenSource)1128792064;
				((GameMonoBehaviour)(object)tweenConfig3)._onPauseSent = true;
				_ = 1120403456;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1214 @ r8_v27 (Il2CppClass<VampireSurvivors.Objects.Projectiles.VampiricaProjectile>)+370]");
				TweenCallback signalBus = new TweenCallback(this, (IntPtr)0);
				nint num7 = (nint)this;
				((Equipment)(object)tweenConfig3)._signalBus = (SignalBus)(object)signalBus;
				MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
				if (multiTargetTween3 != null)
				{
					MultiTargetTween tween3 = multiTargetTween3.SetAutoKill(autoKill: false);
					_tween2 = tween3;
					Weapon weapon2 = _weapon;
					if ((object)_weapon != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
						{
							int num8 = (int)(_indexInWeapon & 0x80000001L);
							if ((nint)((Equipment)weapon2)._003COwner_003Ek__BackingField < 0)
							{
								object obj8 = num8 - 1;
								object obj9 = obj8 | -2;
								num8 = obj9 + 1;
							}
							int num9;
							if (characterController._isFlipped)
							{
								object obj10 = num8 - 1;
								bool flag3 = obj10 == null;
								bool flag4 = !flag3;
								num9 = (flag4 ? 1 : 0);
							}
							else
							{
								object obj11 = num8 - 1;
								bool flag5 = obj11 == null;
								num9 = (flag5 ? 1 : 0);
							}
							Weapon cachedTransform = (Weapon)(object)_cachedTransform;
							if ((object)_cachedTransform != null)
							{
								bool flag6 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
								if (num9 != 0)
								{
								}
								Weapon cachedTransform2 = (Weapon)(object)_cachedTransform;
								bool flag7 = (object)_cachedTransform == null;
								bool flag8 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
								object obj12 = (nint)0 ^ (nint)0;
								object obj13 = 0 & obj12;
								bool flag9 = (nint)obj13 < 0;
								bool flag10 = (nint)0 < (nint)0;
								Vector3 value4 = default(Vector3);
								Transform.set_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref value4);
								int num10 = (int)(_indexInWeapon & 0x80000001L);
								if (flag10 != flag9)
								{
									object obj14 = num10 - 1;
									object obj15 = obj14 | -2;
									num10 = obj15 + 1;
								}
								object obj16 = num10 - 1;
								bool flag11 = obj16 == null;
								bool flag12 = (object)_renderer == null;
								_renderer.flipY = flag11;
								bool flag13 = (object)_ghost1 == null;
								_ghost1.flipY = flag11;
								bool flag14 = (object)_ghost2 == null;
								_ghost2.flipY = flag11;
								bool flag15 = (object)_renderer == null;
								_renderer.flipX = (byte)num9 != 0;
								bool flag16 = (object)_ghost1 == null;
								_ghost1.flipX = (byte)num9 != 0;
								bool flag17 = (object)_ghost2 == null;
								_ghost2.flipX = (byte)num9 != 0;
								bool flag18 = (object)_ghost1 == null;
								Transform transform3 = _ghost1.transform;
								bool flag19 = (object)transform3 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1986 @ rax_v91 (UnityEngine.Transform)+10]");
								bool flag20 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1986 @ rax_v91 (UnityEngine.Transform)+10]");
								Vector3 value5 = default(Vector3);
								Transform.set_localPosition_Injected((IntPtr)0, ref value5);
								bool flag21 = (object)_ghost2 == null;
								Transform transform4 = _ghost2.transform;
								bool flag22 = (object)transform4 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1987 @ rax_v96 (UnityEngine.Transform)+10]");
								bool flag23 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1987 @ rax_v96 (UnityEngine.Transform)+10]");
								Vector3 value6 = default(Vector3);
								Transform.set_localPosition_Injected((IntPtr)0, ref value6);
								Weapon weapon3 = _weapon;
								bool flag24 = (object)_weapon == null;
								bool flag25 = (object)((Equipment)weapon3)._003COwner_003Ek__BackingField == null;
								int num11 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.Depth;
								bool flag26 = (object)GM.Core == null;
								PhaserScene s_scene = ArcadePhysics.s_scene;
								bool flag27 = ArcadePhysics.s_scene == null;
								PhaserScene.Renderer renderer = s_scene._renderer;
								bool flag28 = s_scene._renderer == null;
								bool flag29 = (object)_renderer == null;
								object obj17 = renderer.pixelHeight >> 31;
								object obj18 = renderer.pixelHeight - obj17;
								object obj19 = obj18 >> 1;
								int sortingOrder = num11 + obj19;
								_renderer.sortingOrder = sortingOrder;
								SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
								soundConfig.Rate = 1f;
								soundConfig.Volume = (float?)(object)1;
								soundConfig.Rate = 2f;
								float detune = (float)_indexInWeapon * -100f;
								soundConfig.Detune = detune;
								float time = default(float);
								PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Whip, soundConfig, 0f, 10, time);
								return;
							}
						}
					}
				}
			}
		}
		goto IL_0af6;
		IL_0af6:
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if (_tween != null)
		{
			_tween.Kill();
		}
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		base.Despawn();
	}
}
