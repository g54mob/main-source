using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyMaddener : EnemyAlias
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__19_0;

		public static TweenCallback _003C_003E9__22_0;

		public static TweenCallback _003C_003E9__23_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CGetDamaged_003Eb__19_0()
		{
		}

		internal void _003CExecuteKill_003Eb__22_0()
		{
			//IL_0241: Expected F4, but got I4
			//IL_024a: Expected F4, but got I4
			//IL_0253: Expected F4, but got I4
			//IL_0017: Invalid comparison between F4 and I4
			//IL_00c5: Invalid comparison between F4 and I4
			GameManager core = GM.Core;
			List<CharacterController> characters = core._characters;
			float num = 0f;
			float num2 = 0f;
			CharacterController characterController = default(CharacterController);
			CharacterController characterController2 = default(CharacterController);
			for (float num3 = 0f; num3 < (float)characters._size; num3 = num)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				if (!characterController.IsDisconnectedFromOnlinePlay)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					if (!characterController2._isDead && !characterController2.IsDisconnectedFromOnlinePlay)
					{
						num2++;
					}
				}
				num++;
			}
			if (num2 > 0f)
			{
				GameManager core2 = GM.Core;
				List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
				if (enumerator.MoveNext())
				{
					CharacterController characterController3 = null;
					throw new NullReferenceException();
				}
			}
		}

		internal void _003CSingleWarning_003Eb__23_0()
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

	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public Vector3 playerPos;

		public EnemyMaddener _003C_003E4__this;

		internal void _003CStartKill_003Eb__0()
		{
			EnemyMaddener enemyMaddener = _003C_003E4__this;
			EnemyMaddener cachedTransform = (EnemyMaddener)(object)enemyMaddener._cachedTransform;
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
			_003C_003E4__this.ExecuteKill();
		}
	}

	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public EnemyMaddener _003C_003E4__this;

		public Vector3 offset;

		internal void _003CGetDamaged_003Eb__1(float f)
		{
			//IL_01d9->IL014d: Incompatible stack heights: 3 vs 0
			if ((object)GM.Core != null)
			{
				CharacterController playerOne = GM.Core.PlayerOne;
				if ((object)playerOne == null || ((UnityEngine.Object)playerOne).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				EnemyMaddener enemyMaddener = _003C_003E4__this;
				if ((object)_003C_003E4__this != null)
				{
					object cachedTransform = enemyMaddener._cachedTransform;
					if ((object)GM.Core != null)
					{
						CharacterController playerOne2 = GM.Core.PlayerOne;
						if ((object)playerOne2 != null)
						{
							Transform transform = playerOne2.transform;
							if ((object)transform != null)
							{
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
								bool flag2 = (object)enemyMaddener._cachedTransform == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdi_v9 (System.Object)+10]");
								bool flag3 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdi_v9 (System.Object)+10]");
								Vector3 value = default(Vector3);
								Transform.set_position_Injected((IntPtr)0, ref value);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass23_0
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

	private bool _isSpinning;

	private bool _isRunning;

	private bool _isPursuing;

	private bool _rosaried;

	private float _spinAngle;

	private float _spinRadius;

	private float _runningTweenValue;

	private Tween _lowerScreenTween;

	private Tween _spinningTween;

	private Sequence _killTween;

	private Bounds _camBounds;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_006a: Expected O, but got I4
		//IL_00d2: Expected O, but got I4
		//IL_0121: Expected O, but got I4
		//IL_009d: Expected O, but got I
		//IL_0088: Expected O, but got I
		_isImmuneToModification = true;
		base.InitEnemy(enemyType, asRemote);
		Camera main = Camera.main;
		_camBounds = (Bounds)CameraExtensions.OrthographicBounds(main).m_Center;
		_spinAngle = (float)Math.PI / 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v5 (UnityEngine.Bounds)+10]");
		_ = 0;
		_isSpinning = true;
		_runningTweenValue = -1f;
		((EnemyController)this)._003CIsCullable_003Ek__BackingField = false;
		ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)0);
		object obj = Screen.width;
		object obj2 = Screen.height;
		object obj3;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyMaddener)+2B4]");
			obj3 = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyMaddener)+2B8]");
			obj3 = 0;
		}
		float num = (float)obj3 * 2f;
		float num2 = num * 0.5f;
		float spinRadius = num2 - 0.24f;
		_spinRadius = spinRadius;
		OnUpdate();
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0035: Expected I, but got O
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected O, but got Unknown
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_0403: Expected O, but got I
		//IL_044e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0453: Expected O, but got Unknown
		//IL_01f5: Expected O, but got I
		//IL_0135: Expected F4, but got I
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Expected O, but got Unknown
		//IL_03b5: Expected O, but got I
		//IL_017f: Expected O, but got I
		//IL_0333->IL028f: Incompatible stack heights: 1 vs 0
		//IL_046d->IL03a4: Incompatible stack heights: 4 vs 2
		//IL_03f3->IL03a4: Incompatible stack heights: 4 vs 2
		//IL_0233->IL0233: Incompatible stack heights: 5 vs 2
		((EnemyController)this)._003CSpeed_003Ek__BackingField = 0f;
		base.OnUpdate();
		object obj2 = default(object);
		if ((object)GM.Core != null)
		{
			CharacterController playerOne = GM.Core.PlayerOne;
			if ((object)playerOne != null)
			{
				nint num = (nint)this;
				bool flag = !playerOne._isFlipped;
				base.SetFlipX(flag);
				if ((object)GM.Core != null)
				{
					CharacterController playerOne2 = GM.Core.PlayerOne;
					if ((object)playerOne2 != null)
					{
						Transform transform = playerOne2.transform;
						if ((object)transform != null)
						{
							_ = 0;
							_ = 0;
							bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							object obj = obj2 - 64;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj);
							Transform cachedTransform = _cachedTransform;
							if ((object)_cachedTransform != null)
							{
								_ = 0;
								_ = 0;
								bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
								object obj3 = obj2 - 48;
								Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)obj3);
								if (!_isSpinning)
								{
									bool num4;
									bool num5;
									object obj7 = default(object);
									if (!_isRunning)
									{
										if (!_isPursuing)
										{
											return;
										}
										object cachedTransform2 = _cachedTransform;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-3C]");
										float num2 = 0f;
										float num3 = _runningTweenValue * 0.48f;
										bool flag4 = (object)_cachedTransform == null;
										num4 = flag4;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rdi_v23 (System.Object)+10]");
										object obj4 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rdi_v23 (System.Object)+10]");
										bool flag5 = (nint)0 == 0;
										num5 = flag5;
										object obj5 = 0;
										object obj6 = obj7;
									}
									else
									{
										object cachedTransform3 = _cachedTransform;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-3C]");
										object obj8 = 0 - _spinRadius;
										float num2 = (float)obj8 + 0.48f;
										bool flag6 = (object)_cachedTransform == null;
										num4 = flag6;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ rdi_v21 (System.Object)+10]");
										object obj4 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ rdi_v21 (System.Object)+10]");
										bool flag7 = (nint)0 == 0;
										num5 = flag7;
										object obj5 = 0;
										bool flag8 = (nint)0 != 0;
										object obj6 = obj7;
										if (!flag8)
										{
											bool flag9 = (nint)0 == 0;
											goto IL_0233;
										}
									}
									object obj9 = obj2 - 64;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1044 @ rax_v61 (should have been resolved before IL gen)");
									return;
								}
								goto IL_0233;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0233:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		object cachedTransform4 = _cachedTransform;
		bool flag10 = (object)_cachedTransform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ rdi_v19 (System.Object)+10]");
		bool flag11 = (nint)0 == 0;
		object obj10 = obj2 - 64;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ rdi_v19 (System.Object)+10]");
		Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj10);
	}

	public void Spinnn()
	{
		_isSpinning = true;
		if (_spinningTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_spinningTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float val = default(float);
		((EnemyMaddener)(object)dOSetter)._003CSpinnn_003Eb__14_1(val);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 7.853982f, 3.0400002f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 8;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+A0]");
						float num = 0f * 8f;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 4;
					_ = 0;
				}
			}
		}
		_spinningTween = tweenerCore;
	}

	public void StartLowerScreenMotion()
	{
		_isSpinning = false;
		if (_lowerScreenTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_lowerScreenTween);
		}
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdi_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdi_v1 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyMaddener)+2B4]");
		float num = 0f * 2f;
		float num2 = num * 0.5f;
		float num3 = num2 + (float)ret;
		float endValue = num3 + 2f;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMoveX(_cachedTransform, endValue, 1f);
		TweenCallback tweenCallback = StartRunningTween;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		_lowerScreenTween = tweenerCore;
	}

	public void StartPursuit()
	{
		_isRunning = false;
		_runningTweenValue = -1f;
		if ((object)GM.Core != null)
		{
			CharacterController playerOne = GM.Core.PlayerOne;
			if ((object)playerOne != null)
			{
				Transform transform = playerOne.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					Sequence sequence = DOTween.Sequence();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyMaddener)+2B4]");
					float num = 0f * 2f;
					float num2 = num * 0.25f;
					float num3 = (float)ret - num2;
					float num4 = _runningTweenValue * 0.48f;
					float endValue = num3 + num4;
					TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOMoveX(_cachedTransform, endValue, 0.2f);
					if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
					{
						Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, 0f);
					}
					float endValue2 = default(float);
					TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOMoveY(_cachedTransform, endValue2, 0.2f);
					if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
					{
						Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)t2, 0f);
					}
					TweenCallback onComplete = delegate
					{
						_isPursuing = true;
					};
					if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
					{
						sequence.onComplete = onComplete;
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void StartKill()
	{
		//IL_0147: Expected F4, but got I
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass17_0();
		if (CS_0024_003C_003E8__locals6 != null)
		{
			CS_0024_003C_003E8__locals6._003C_003E4__this = this;
			_isPursuing = false;
			if ((object)GM.Core != null)
			{
				CharacterController playerOne = GM.Core.PlayerOne;
				if ((object)playerOne != null)
				{
					Transform transform = playerOne.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
						CS_0024_003C_003E8__locals6.playerPos = ret;
						_ = 0;
						Sequence sequence = DOTween.Sequence();
						TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOMoveX(endValue: (float)CS_0024_003C_003E8__locals6.playerPos - 4f, target: _cachedTransform, duration: 0.2f);
						if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
						{
							Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, 0f);
						}
						Transform cachedTransform = _cachedTransform;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (VampireSurvivors.Objects.Characters.Enemies.EnemyMaddener+<>c__DisplayClass17_0)+14]");
						TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOMoveY(cachedTransform, 0f, 0.2f);
						if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
						{
							Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)t2, 0f);
						}
						TweenCallback onComplete = delegate
						{
							EnemyMaddener enemyMaddener = CS_0024_003C_003E8__locals6._003C_003E4__this;
							EnemyMaddener cachedTransform2 = (EnemyMaddener)(object)enemyMaddener._cachedTransform;
							bool flag2 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref value);
							CS_0024_003C_003E8__locals6._003C_003E4__this.ExecuteKill();
						};
						if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
						{
							sequence.onComplete = onComplete;
						}
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void StopAllTimers()
	{
		if (_lowerScreenTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_lowerScreenTween);
		}
		if (_spinningTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_spinningTween);
		}
	}

	public unsafe override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0055: Expected I4, but got O
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_007b: Expected native int or pointer, but got O
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0137: Expected native int or pointer, but got O
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Expected O, but got Unknown
		//IL_0485: Unknown result type (might be due to invalid IL or missing references)
		//IL_048a: Expected O, but got Unknown
		//IL_04d8: Expected O, but got I
		//IL_0308: Expected O, but got I4
		//IL_0257->IL0394: Incompatible stack heights: 1 vs 0
		//IL_0282->IL0394: Incompatible stack heights: 1 vs 0
		//IL_02ac->IL0394: Incompatible stack heights: 1 vs 0
		//IL_0374->IL0374: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = obj2 - 71;
		_003C_003Ec__DisplayClass19_0 obj3 = new _003C_003Ec__DisplayClass19_0();
		if (obj3 != null)
		{
			obj3._003C_003E4__this = this;
			object obj4 = obj - 89;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1+6F]");
			_ = 0;
			object arg = (WeaponType)obj4;
			System.ParamsArray paramsArray = (System.ParamsArray)(obj - 49);
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg));
			System.ParamsArray args = (System.ParamsArray)(obj - 17);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1-31]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1-21]");
			_ = 0;
			string message = string.FormatHelper((IFormatProvider)null, "[GURU] EnemyMaddener.GetDamaged - DamageType: {0}", args);
			Debug.LogWarning(message);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1+6F]");
			WeaponType weaponType = default(WeaponType);
			bool flag3 = default(bool);
			if ((nint)0 == 25)
			{
				object obj5 = obj - 97;
				_ = _rosaried;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				System.ParamsArray paramsArray2 = (System.ParamsArray)(obj - 49);
				_ = 0;
				_ = 0;
				object arg2 = default(object);
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray2, new System.ParamsArray(arg2));
				System.ParamsArray args2 = (System.ParamsArray)(obj - 17);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1-31]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1-21]");
				_ = 0;
				string message2 = string.FormatHelper((IFormatProvider)null, "[GURU] EnemyMaddener has been rosaried: {0}", args2);
				Debug.LogWarning(message2);
				if (!_rosaried)
				{
					Debug.LogWarning("[GURU] EnemeyMaddener custom damage by RosaryX, should walk away now");
					_rosaried = true;
					if ((object)_SpriteAnimation != null)
					{
						_SpriteAnimation.SetAnimation("idle");
						object cachedTransform = _cachedTransform;
						if ((object)_cachedTransform != null)
						{
							_ = 0;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v13 (System.Object)+10]");
							bool flag = (nint)0 == 0;
							object obj6 = obj - 89;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbx_v13 (System.Object)+10]");
							Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj6);
							Vector2 vector = default(Vector2);
							SingleWarning(vector);
							_isSpinning = false;
							_isPursuing = false;
							if (_killTween != null)
							{
								DG.Tweening.TweenExtensions.Kill(_killTween);
							}
							if ((object)GM.Core != null)
							{
								CharacterController playerOne = GM.Core.PlayerOne;
								if ((object)playerOne != null)
								{
									Transform transform = playerOne.transform;
									if ((object)transform != null)
									{
										_ = 0;
										_ = 0;
										bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
										object obj7 = obj - 65;
										Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj7);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1-3D]");
										float num = 0f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1-55]");
										float f = num - 0f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1-39]");
										nint num2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1-51]");
										object obj8 = num2 - 0;
										obj3.offset = vector;
										Action onComplete = _003C_003Ec._003C_003E9__19_0;
										if (_003C_003Ec._003C_003E9__19_0 == null)
										{
											onComplete = (_003C_003Ec._003C_003E9__19_0 = delegate
											{
											});
										}
										Action<float> action = null;
										((_003C_003Ec__DisplayClass19_0)(object)action)._003CGetDamaged_003Eb__1(f);
										int repeat = default(int);
										TimerType type = default(TimerType);
										Timer timer = Timers.Register(3.0000002f, onComplete, action, isLooped: false, (byte)weaponType != 0, (MonoBehaviour)flag3, repeat, type, isOnlineTimer: false, canPause: false);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyMaddener)+2B4]");
										float num3 = 0f * 2f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1-59]");
										float endValue = 0f - num3;
										TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOMoveX(_cachedTransform, endValue, 2f);
										TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 3.0000002f);
										return;
									}
								}
							}
						}
					}
					goto IL_0394;
				}
			}
			HitVfxType showHitVfx2 = default(HitVfxType);
			base.GetDamaged(value, showHitVfx2, damageKb, weaponType, flag3);
			return;
		}
		goto IL_0394;
		IL_0394:
		throw new NullReferenceException();
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

	private void StartRunningTween()
	{
		_isRunning = true;
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float val = default(float);
		((EnemyMaddener)(object)dOSetter)._003CStartRunningTween_003Eb__21_1(val);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 1f, 4f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 8;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+A0]");
						float num = 0f * 8f;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
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
	}

	private void ExecuteKill()
	{
		if (_killTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_killTween);
		}
		Sequence killTween = DOTween.Sequence();
		_killTween = killTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyMaddener)+2B4]");
		float num = 0f * 2f;
		float endValue = num * 0.5f;
		TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOMoveX(_cachedTransform, endValue, 2f);
		if (TweenSettingsExtensions.ValidateAddToSequence(_killTween, (Tween)t, false))
		{
			Sequence sequence = Sequence.DoInsert(_killTween, (Tween)t, 0f);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyMaddener)+2B8]");
		float num2 = 0f * 2f;
		float endValue2 = num2 * 0.5f;
		TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOMoveY(_cachedTransform, endValue2, 2f);
		if (TweenSettingsExtensions.ValidateAddToSequence(_killTween, (Tween)t2, false))
		{
			Sequence sequence2 = Sequence.DoInsert(_killTween, (Tween)t2, 0f);
		}
		Sequence killTween2 = _killTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		killTween2.stringId = "DefaultGameTweenId";
		Sequence killTween3 = _killTween;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__22_0;
		if (_003C_003Ec._003C_003E9__22_0 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__22_0 = delegate
			{
				//IL_0241: Expected F4, but got I4
				//IL_024a: Expected F4, but got I4
				//IL_0253: Expected F4, but got I4
				//IL_0017: Invalid comparison between F4 and I4
				//IL_00c5: Invalid comparison between F4 and I4
				GameManager core = GM.Core;
				List<CharacterController> characters = core._characters;
				float num3 = 0f;
				float num4 = 0f;
				CharacterController characterController = default(CharacterController);
				CharacterController characterController2 = default(CharacterController);
				for (float num5 = 0f; num5 < (float)characters._size; num5 = num3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					if (!characterController.IsDisconnectedFromOnlinePlay)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						if (!characterController2._isDead && !characterController2.IsDisconnectedFromOnlinePlay)
						{
							num4++;
						}
					}
					num3++;
				}
				if (num4 > 0f)
				{
					GameManager core2 = GM.Core;
					List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
					if (enumerator.MoveNext())
					{
						CharacterController characterController3 = null;
						throw new NullReferenceException();
					}
				}
			});
		}
		if (_killTween != null && ((Tween)killTween3)._003Cactive_003Ek__BackingField)
		{
			killTween3.onComplete = onComplete;
		}
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
		_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals19 = new _003C_003Ec__DisplayClass23_0();
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
						TweenCallback tweenCallback = _003C_003Ec._003C_003E9__23_0;
						if (_003C_003Ec._003C_003E9__23_0 == null)
						{
							tweenCallback = (_003C_003Ec._003C_003E9__23_0 = delegate
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

	private float _003CSpinnn_003Eb__14_0()
	{
		return _spinAngle;
	}

	private void _003CSpinnn_003Eb__14_1(float val)
	{
		_spinAngle = val;
	}

	private void _003CStartPursuit_003Eb__16_0()
	{
		_isPursuing = true;
	}

	private float _003CStartRunningTween_003Eb__21_0()
	{
		return _runningTweenValue;
	}

	private void _003CStartRunningTween_003Eb__21_1(float val)
	{
		_runningTweenValue = val;
	}
}
