using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using PhaserPort;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace VampireSurvivors.Framework.Platforms;

public class AppleArcadeSplashController : MonoBehaviour
{
	[Serializable]
	public class AspectRatioVideoHolder
	{
		public float _AspectRatio;

		public VideoClip _VideoClip;
	}

	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public CanvasGroup splashContainer;

		internal void _003CShowVampireSurvivorsSplash_003Eb__0()
		{
			GameObject gameObject = splashContainer.gameObject;
			gameObject.SetActive(value: true);
		}
	}

	private sealed class _003CDelaySetVideoClip_003Ed__15(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public AppleArcadeSplashController _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_00ce: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_0096: Expected I4, but got I8
			//IL_0052: Expected I4, but got I8
			//IL_0105: Expected I4, but got O
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj == 1)
					{
						_003C_003E1__state = -1;
						if ((object)_003C_003E4__this == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						_003C_003E4__this.SetVideoClipBasedOnAspectRatio();
					}
					return false;
				}
				_003C_003E1__state = -1;
				WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
				_003C_003E2__current = waitForEndOfFrame;
				_003C_003E1__state = 2;
				return true;
			}
			_003C_003E1__state = -1;
			WaitForEndOfFrame waitForEndOfFrame2 = new WaitForEndOfFrame();
			_003C_003E2__current = waitForEndOfFrame2;
			_003C_003E1__state = 1;
			return true;
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

	private VideoPlayer _VideoPlayer;

	private VideoClip _DefaultPortraitClip;

	private VideoClip _DefaultLandscapeClip;

	public List<AspectRatioVideoHolder> _PortraitAspectRatioVideoHolders;

	public List<AspectRatioVideoHolder> _LandscapeAspectRatioVideoHolders;

	private CanvasGroup _VampireSurvivorsSplashContainerPortrait;

	private CanvasGroup _VampireSurvivorsSplashContainerLandscape;

	private bool _hasSkipped;

	private void Awake()
	{
		GameObject gameObject = _VampireSurvivorsSplashContainerPortrait.gameObject;
		gameObject.SetActive(value: false);
		_VampireSurvivorsSplashContainerPortrait.alpha = 0f;
		GameObject gameObject2 = _VampireSurvivorsSplashContainerLandscape.gameObject;
		gameObject2.SetActive(value: false);
		_VampireSurvivorsSplashContainerLandscape.alpha = 0f;
		bool flag = RenderingHelper.TryApplySavedOrientation();
	}

	private void Start()
	{
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		_003CDelaySetVideoClip_003Ed__15 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
		VideoPlayer videoPlayer = _VideoPlayer;
		VideoPlayer.EventHandler b = OnLoopPointReached;
		if ((object)_VideoPlayer == null)
		{
			NullReferenceException ex = new NullReferenceException();
		}
		else
		{
			Delegate obj2 = videoPlayer.loopPointReached;
			object obj3 = _VideoPlayer + 32;
			while (true)
			{
				Delegate obj4 = Delegate.Combine(obj2, b);
				bool flag = (object)obj4 == null;
				Delegate obj5 = null;
				if (!flag)
				{
					bool flag2 = (object)obj4.GetType() != typeof(VideoPlayer.EventHandler);
					obj5 = null;
					if (!flag2)
					{
						obj5 = obj4;
					}
					if ((object)obj5 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj3;
				Delegate obj6;
				if (obj2 == obj3)
				{
					obj3 = obj5;
					obj6 = obj2;
				}
				else
				{
					obj6 = (Delegate)obj3;
				}
				Delegate obj7 = obj2;
				if (!flag3)
				{
					obj7 = obj6;
				}
				bool flag4 = (object)obj7 != obj2;
				obj2 = obj7;
				if (!flag4)
				{
					return;
				}
			}
		}
		throw new InvalidCastException();
	}

	private void Update()
	{
		VideoPlayer videoPlayer = _VideoPlayer;
		bool flag = ((UnityEngine.Object)videoPlayer).m_CachedPtr == (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
		/*Error: End of method reached without returning.*/;
	}

	private void SkipAppleSplash()
	{
		if (!_hasSkipped)
		{
			_hasSkipped = true;
			if (_VideoPlayer.isPlaying)
			{
				_VideoPlayer.Stop();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 61 Invalid \"Jump target not found in method: 0x186B3EAE0\"");
		}
	}

	private void OnLoopPointReached(VideoPlayer source)
	{
		ShowVampireSurvivorsSplash();
	}

	private unsafe void ShowVampireSurvivorsSplash()
	{
		//IL_033a: Expected O, but got I4
		//IL_0352: Expected O, but got I4
		//IL_037c: Expected O, but got Ref
		//IL_038e: Expected O, but got I4
		//IL_03d8: Expected O, but got I4
		_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass13_0();
		object obj = Screen.width;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj2 = Screen.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		object arg2 = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg, arg2);
		object obj3 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "[ShowVampireSurvivorsSplash] Screen Size: Width = {0}, Height = {1}", (System.ParamsArray)(&obj3));
		Debug.Log(message);
		object obj4 = Screen.height;
		object obj5 = Screen.width;
		CanvasGroup splashContainer = ((System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5)) ? _VampireSurvivorsSplashContainerLandscape : _VampireSurvivorsSplashContainerPortrait);
		CS_0024_003C_003E8__locals4.splashContainer = splashContainer;
		Sequence sequence = DOTween.Sequence();
		TweenCallback onStart = delegate
		{
			GameObject gameObject = CS_0024_003C_003E8__locals4.splashContainer.gameObject;
			gameObject.SetActive(value: true);
		};
		if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			((ABSSequentiable)sequence).onStart = onStart;
		}
		TweenerCore<float, float, FloatOptions> t = DOTweenModuleUI.DOFade(CS_0024_003C_003E8__locals4.splashContainer, 1f, 0.35f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, ((Tween)sequence).duration);
		}
		Sequence sequence3 = TweenSettingsExtensions.AppendInterval(sequence, 1.5f);
		TweenerCore<float, float, FloatOptions> t2 = DOTweenModuleUI.DOFade(CS_0024_003C_003E8__locals4.splashContainer, 0f, 0.25f);
		TweenCallback tweenCallback2;
		Tween t3;
		object message2;
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
		{
			Sequence sequence4 = Sequence.DoInsert(sequence, (Tween)t2, ((Tween)sequence).duration);
			TweenCallback tweenCallback = LoadGame;
			tweenCallback2 = tweenCallback;
		}
		else
		{
			TweenCallback tweenCallback3 = LoadGame;
			bool flag = sequence == null;
			tweenCallback2 = tweenCallback3;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				t3 = null;
				message2 = "You can't add elements to a NULL Sequence";
				goto IL_03f7;
			}
		}
		if (((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			if (!((Tween)sequence).creationLocked)
			{
				if (tweenCallback2 != null)
				{
					Sequence sequence5 = Sequence.DoInsertCallback(sequence, tweenCallback2, ((Tween)sequence).duration);
				}
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			t3 = null;
			message2 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			t3 = null;
			message2 = "You can't add elements to an inactive/killed Sequence";
		}
		goto IL_03f7;
		IL_03f7:
		Debugger.LogWarning(message2, t3);
	}

	private void LoadGame()
	{
		//IL_0019: Expected O, but got I4
		AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Preloader", (LoadSceneParameters)0);
	}

	private IEnumerator DelaySetVideoClip()
	{
		_003CDelaySetVideoClip_003Ed__15 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void SetVideoClipBasedOnAspectRatio()
	{
		//IL_01c7: Expected O, but got I4
		//IL_028e: Expected O, but got I4
		//IL_01d5: Expected O, but got I4
		//IL_02a9: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_0096: Expected I, but got O
		//IL_0218: Expected O, but got I4
		//IL_00d0: Expected I, but got O
		//IL_0248: Expected O, but got I4
		//IL_0251: Expected I4, but got F4
		//IL_010a: Expected I, but got O
		//IL_0192: Expected O, but got Ref
		//IL_0144: Expected I, but got O
		//IL_027b: Expected O, but got I4
		//IL_02d1: Expected O, but got I4
		//IL_00b9->IL00b9: Incompatible stack heights: 1 vs 0
		//IL_00f3->IL00f3: Incompatible stack heights: 1 vs 0
		//IL_012d->IL012d: Incompatible stack heights: 1 vs 0
		//IL_0167->IL0167: Incompatible stack heights: 1 vs 0
		object obj = Screen.width;
		object obj2 = Screen.height;
		object obj3 = obj / obj2;
		object obj4 = Screen.height;
		object obj5 = Screen.width;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
		{
			obj3 = obj2 / obj;
		}
		float num = (float)obj3 * 100f;
		double num2 = Math.Floor(num);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm7,xmm0\"");
		float aspectRatio = 0f / 100f;
		object[] array = new object[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj6 = default(object);
		if (obj6 != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			bool flag = obj7 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj8 = Screen.width;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj9 = default(object);
		if (obj9 != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj10 = default(object);
			bool flag2 = obj10 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj11 = Screen.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj12 = default(object);
		if (obj12 != null)
		{
			nint num5 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj13 = default(object);
			bool flag3 = obj13 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj14 = Screen.GetScreenOrientation();
		float num6 = default(float);
		object obj15 = (ScreenOrientation)num6;
		if (obj15 != null)
		{
			nint num7 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj16 = default(object);
			bool flag4 = obj16 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		System.ParamsArray paramsArray = new System.ParamsArray(array);
		object obj17 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "[SetVideoClipBasedOnAspectRatio] Getting video for aspect ratio: {0} (Width: {1} x Height: {2}, Orientation: {3})", (System.ParamsArray)(&obj17));
		Debug.Log(message);
		object obj18 = Screen.height;
		object obj19 = Screen.width;
		object obj20 = obj18 - obj19;
		object obj21 = obj18 ^ obj19;
		object obj22 = obj18 ^ obj20;
		object obj23 = obj21 & obj22;
		bool flag5 = (nint)obj23 < 0;
		bool flag6 = (nint)obj20 < 0;
		bool flag7 = obj20 == null;
		bool flag8 = flag6 == flag5;
		bool flag9 = !flag7;
		bool isPortrait = flag9 & flag8;
		VideoClip videoClipForAspectRatio = GetVideoClipForAspectRatio(aspectRatio, isPortrait);
		_VideoPlayer.clip = videoClipForAspectRatio;
	}

	private float GetAspectRatio()
	{
		//IL_00a8: Expected O, but got I4
		//IL_0063: Expected F4, but got I4
		//IL_00b6: Expected O, but got I4
		//IL_0080: Expected O, but got I4
		object obj = Screen.width;
		float num = Screen.height;
		float num2 = (float)obj / num;
		object obj2 = Screen.height;
		object obj3 = Screen.width;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
			num2 = num / (float)obj;
		}
		float num3 = num2 * 100f;
		double num4 = Math.Floor(num3);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
		return (float)num4 / 100f;
	}

	private unsafe VideoClip GetVideoClipForAspectRatio(float aspectRatio, bool isPortrait)
	{
		//IL_001f: Expected O, but got I4
		//IL_0027: Expected O, but got Ref
		if (isPortrait)
		{
		}
		List<AspectRatioVideoHolder>.Enumerator enumerator = default(List<AspectRatioVideoHolder>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<AspectRatioVideoHolder>.Enumerator enumerator2 = (List<AspectRatioVideoHolder>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		if (isPortrait)
		{
			return _DefaultPortraitClip;
		}
		return _DefaultLandscapeClip;
	}

	public AppleArcadeSplashController()
	{
		List<AspectRatioVideoHolder> portraitAspectRatioVideoHolders = new List<AspectRatioVideoHolder>();
		_PortraitAspectRatioVideoHolders = portraitAspectRatioVideoHolders;
		List<AspectRatioVideoHolder> landscapeAspectRatioVideoHolders = new List<AspectRatioVideoHolder>();
		_LandscapeAspectRatioVideoHolders = landscapeAspectRatioVideoHolders;
	}
}
