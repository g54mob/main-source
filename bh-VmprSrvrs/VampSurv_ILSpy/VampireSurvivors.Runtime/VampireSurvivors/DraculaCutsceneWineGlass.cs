using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;

namespace VampireSurvivors;

public class DraculaCutsceneWineGlass : ArcadeSprite
{
	private sealed class _003CThrowCoroutine_003Ed__16(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public DraculaCutsceneWineGlass _003C_003E4__this;

		public float delay;

		public Vector2 startPosition;

		public Vector2 endPosition;

		private float _003Ctimer_003E5__2;

		private Quaternion _003CendRotation_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_00a1: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_008d: Expected I4, but got I8
			//IL_0052: Expected I4, but got I8
			//IL_031d: Invalid comparison between I and F4
			//IL_01c2: Expected O, but got I
			//IL_0388: Expected F4, but got I4
			//IL_038c: Expected O, but got F4
			//IL_0395: Invalid comparison between I4 and F4
			//IL_0245: Expected F4, but got I4
			//IL_03b9: Expected O, but got I
			//IL_03f3: Expected F4, but got I4
			//IL_03f7: Expected O, but got F4
			//IL_0400: Invalid comparison between I4 and F4
			//IL_04ef->IL02cd: Incompatible stack heights: 1 vs 0
			//IL_03d9->IL0304: Incompatible stack heights: 1 vs 0
			//IL_02af->IL049d: Incompatible stack heights: 4 vs 0
			ArcadeSprite arcadeSprite = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			bool flag2;
			Quaternion euler = default(Quaternion);
			Quaternion ret;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj != 1)
					{
						goto IL_02cd;
					}
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this == null)
					{
						goto IL_0304;
					}
					IntPtr intPtr = default(IntPtr);
					flag2 = (byte)(nint)intPtr != 0;
					goto IL_030b;
				}
				_003C_003E1__state = -1;
			}
			else
			{
				_003C_003E1__state = -1;
				_003Ctimer_003E5__2 = 0f;
				if ((object)_003C_003E4__this == null)
				{
					goto IL_0304;
				}
				Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)(&euler), out ret);
				_003CendRotation_003E5__3 = ret;
			}
			if (delay > _003Ctimer_003E5__2)
			{
				float deltaTime = PauseSystem.DeltaTime;
				float num = deltaTime + _003Ctimer_003E5__2;
				_003C_003E2__current = null;
				_003Ctimer_003E5__2 = num;
				_003C_003E1__state = 1;
				goto IL_049d;
			}
			if ((object)_003C_003E4__this != null)
			{
				_003C_003E4__this.CheckRenderer();
				if ((object)arcadeSprite._spriteRenderer != null)
				{
					arcadeSprite._spriteRenderer.enabled = true;
					_003Ctimer_003E5__2 = 0f;
					flag2 = true;
					goto IL_030b;
				}
			}
			goto IL_0304;
			IL_02cd:
			return false;
			IL_049d:
			return true;
			IL_0304:
			throw new NullReferenceException();
			IL_030b:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rdi_v1 (ArcadeSprite)+68]");
			Quaternion rotation = default(Quaternion);
			if (0f > _003Ctimer_003E5__2)
			{
				float num2 = PauseSystem.DeltaTime;
				float num3 = num2 + _003Ctimer_003E5__2;
				_003Ctimer_003E5__2 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rdi_v1 (ArcadeSprite)+58]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rdi_v1 (ArcadeSprite)+58]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rcx_v48 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rcx_v48 (System.Object)+10]");
					object obj3 = AnimationCurve.Evaluate_Injected((IntPtr)0, (float)(flag2 ? 1 : 0));
					if (!(0f > num2))
					{
						if (num2 > 1f)
						{
							num2 = 1f;
						}
					}
					else
					{
						num2 = 0f;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rdi_v1 (ArcadeSprite)+60]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rdi_v1 (ArcadeSprite)+60]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v51 (System.Object)+10]");
						bool flag4 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v51 (System.Object)+10]");
						object obj5 = AnimationCurve.Evaluate_Injected((IntPtr)0, (float)(flag2 ? 1 : 0));
						if (0f > num2 || num2 > 1f)
						{
						}
						Quaternion.Lerp_Injected(ref rotation, ref euler, 0f, out ret);
						Transform transform = _003C_003E4__this.transform;
						bool flag5 = (object)transform == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1341 @ rax_v64 (UnityEngine.Transform)+10]");
						bool flag6 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1341 @ rax_v64 (UnityEngine.Transform)+10]");
						Transform.SetPositionAndRotation_Injected((IntPtr)0, ref *(Vector3*)(&euler), ref rotation);
						_003C_003E2__current = null;
						_003C_003E1__state = 2;
						goto IL_049d;
					}
				}
				goto IL_0304;
			}
			Transform transform2 = _003C_003E4__this.transform;
			bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Transform.SetPositionAndRotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&euler), ref rotation);
			_003C_003E4__this.BreakOnImpact();
			goto IL_02cd;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private AnimationCurve _xAnimationCurve;

	private AnimationCurve _yAnimationCurve;

	private float _ThrowDuration;

	private float _ThrowEndRotation;

	private PhaserSprite _ImpactExplosion;

	private ParticleSystem _WineGlassImpactParticles;

	private MultiTargetTween _scaleTween;

	private const string WineGlassSpriteName = "TP_VFX_WineGlass01";

	private const string WineGlassAnimName = "TP_VFX_WineGlass";

	private const string WineGlassParticleSpriteName = "TP_VFX_WineGlass04";

	private const string ThosePeopleTextureName = "ThosePeople";

	private const string ExplodeAnimName = "explode";

	private readonly List<SfxType> _glassLight;

	public void InitWineGlass()
	{
		CheckRenderer();
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_WineGlass01", "ThosePeople");
		base._spriteRenderer.sprite = sprite;
		CheckRenderer();
		base._spriteRenderer.enabled = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 107 Invalid \"Jump target not found in method: 0x186DC6100\"");
		throw new NullReferenceException();
	}

	public void ThrowWineGlass(float delay, Vector2 startPosition, Vector2 endPosition)
	{
		_003CThrowCoroutine_003Ed__16 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.startPosition = startPosition;
		obj.endPosition = endPosition;
		obj.delay = delay;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private void InitImpactExplosion()
	{
		//IL_00b4: Expected O, but got I4
		//IL_00b4: Expected I4, but got O
		//IL_01c4: Expected O, but got I
		PhaserSprite impactExplosion = _ImpactExplosion;
		impactExplosion._spriteRenderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite impactExplosion2 = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_WineGlass01");
		_ImpactExplosion = impactExplosion2;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_WineGlass", 1, 3, vector, text, num, flag);
		PhaserSprite impactExplosion3 = _ImpactExplosion;
		bool autoSetAnimation = default(bool);
		impactExplosion3._spriteAnimation.AddAnimation("explode", animationFrames, 64, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite phaserSprite = _ImpactExplosion.setAlpha(1f);
		PhaserSprite phaserSprite2 = _ImpactExplosion.setVisible(visible: false);
		_ImpactExplosion.angle = 90f;
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_WineGlass04", "ThosePeople");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v621 @ rcx_v25 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		bool flag2 = (object)sprite == null;
		nint num3 = 0;
		if (!flag2)
		{
			num3 = ((UnityEngine.Object)sprite).m_CachedPtr;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBD0]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBD0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v658 @ rax_v29 (should have been resolved before IL gen)");
	}

	private IEnumerator ThrowCoroutine(float delay, Vector2 startPosition, Vector2 endPosition)
	{
		_003CThrowCoroutine_003Ed__16 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.startPosition = startPosition;
		obj.delay = delay;
		obj.endPosition = endPosition;
		return obj;
	}

	private void BreakOnImpact()
	{
		//IL_005f: Expected O, but got I4
		//IL_01b5: Expected I, but got O
		//IL_022d: Expected O, but got I4
		//IL_01a8->IL0277: Incompatible stack heights: 1 vs 0
		//IL_01fa->IL0277: Incompatible stack heights: 2 vs 0
		CheckRenderer();
		if ((object)base._spriteRenderer != null)
		{
			base._spriteRenderer.enabled = false;
			SfxType sfxType = Extensions.PickRnd(_glassLight);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = 100f;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig, 0f, 10, time);
			if ((object)_ImpactExplosion != null)
			{
				PhaserSprite phaserSprite = _ImpactExplosion.setVisible(visible: true);
				PhaserSprite impactExplosion = _ImpactExplosion;
				if ((object)_ImpactExplosion != null && (object)impactExplosion._spriteAnimation != null)
				{
					impactExplosion._spriteAnimation.SetAnimation("explode");
					Renderer wineGlassImpactParticles = (Renderer)(object)_WineGlassImpactParticles;
					if ((object)_WineGlassImpactParticles != null)
					{
						bool flag = ((UnityEngine.Object)wineGlassImpactParticles).m_CachedPtr == (IntPtr)0;
						ParticleSystem.Emit_Internal_Injected(((UnityEngine.Object)wineGlassImpactParticles).m_CachedPtr, 8);
						if (_scaleTween != null)
						{
							_scaleTween.Kill();
						}
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if (array != null)
						{
							nint num = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj = default(object);
							bool flag2 = obj == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null)
							{
								tweenConfig.targets = array;
								tweenConfig.duration = 60f;
								tweenConfig.scale = (float?)(object)1;
								TweenCallback onComplete = delegate
								{
									PhaserSprite phaserSprite2 = _ImpactExplosion.setVisible(visible: false);
								};
								tweenConfig.onComplete = onComplete;
								MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
								_scaleTween = scaleTween;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
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
			_scaleTween.Kill();
		}
		while (((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0)
		{
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(this);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	public DraculaCutsceneWineGlass()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0568: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0590: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_05b8: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_05e0: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_0608: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_0630: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_0658: Expected O, but got I
		//IL_0368: Expected O, but got I
		//IL_0680: Expected O, but got I
		//IL_03d2: Expected O, but got I
		//IL_06a8: Expected O, but got I
		//IL_043c: Expected O, but got I
		//IL_06d0: Expected O, but got I
		//IL_04a6: Expected O, but got I
		//IL_06f8: Expected O, but got I
		//IL_0510: Expected O, but got I
		List<SfxType> list = new List<SfxType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)135);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 135;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)138);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 138;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)139);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 139;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)140);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 140;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)141);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 141;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)145);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 145;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)146);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 146;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)147);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 147;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdx_v20+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)148);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 148;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v22+18]");
		if (num10 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)149);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 149;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v24+18]");
		if (num11 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)151);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 151;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdx_v26+18]");
		if (num12 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)156);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 156;
		}
		_glassLight = list;
		((GameMonoBehaviour)this)._onResumeSent = true;
	}

	private void _003CBreakOnImpact_003Eb__17_0()
	{
		PhaserSprite phaserSprite = _ImpactExplosion.setVisible(visible: false);
	}
}
