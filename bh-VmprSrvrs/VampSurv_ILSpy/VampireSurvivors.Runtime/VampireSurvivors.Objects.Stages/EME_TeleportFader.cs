using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.Objects.Stages;

public class EME_TeleportFader : MonoBehaviour
{
	private enum FadeState
	{
		Idle,
		FadeIn,
		Hold,
		FadeOut
	}

	private Image _faderImage;

	private Image _whiteFade;

	private float _fadeInTime;

	private float _fadeHoldTime;

	private float _fadeOutTime;

	private float _maxTrianglesAlpha;

	private bool _fadeInTrianglesAlpha;

	private bool _includeBackgroundWhiteFade;

	private AnimationCurve _whiteFadeCurve;

	private float _fadeTimer;

	private FadeState _currentState;

	private static readonly int FadeProgress;

	private Action m_OnFadeInComplete;

	private Action m_OnFadeOutComplete;

	public event Action OnFadeInComplete
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 88;
			Delegate obj2 = this.m_OnFadeInComplete;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 88;
			Delegate obj2 = this.m_OnFadeInComplete;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public event Action OnFadeOutComplete
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 96;
			Delegate obj2 = this.m_OnFadeOutComplete;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 96;
			Delegate obj2 = this.m_OnFadeOutComplete;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public void Init()
	{
		SetFadeProgress(0f);
	}

	public void BeginFade(Action onFadeInComplete, Action onFadeOutComplete)
	{
		this.m_OnFadeInComplete = onFadeInComplete;
		this.m_OnFadeOutComplete = onFadeOutComplete;
		_currentState = FadeState.FadeIn;
	}

	public void UpdateFade()
	{
		//IL_002f: Expected O, but got I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0220: Expected O, but got I4
		//IL_0114: Expected O, but got I4
		bool flag = _currentState == FadeState.Idle;
		if (flag)
		{
			return;
		}
		object obj = _currentState - 1;
		Action action;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (flag)
			{
				float deltaTime = PauseSystem.DeltaTime;
				float num = deltaTime / _fadeHoldTime;
				if (!((_fadeTimer = num + _fadeTimer) < 1f))
				{
					_fadeTimer = 0f;
					_currentState = FadeState.FadeOut;
				}
				return;
			}
			if ((nint)obj2 != 1)
			{
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
				throw ex;
			}
			float deltaTime2 = PauseSystem.DeltaTime;
			float num2 = deltaTime2 / _fadeOutTime;
			float num3 = num2 + _fadeTimer;
			float fadeProgress = 1f - num3;
			_fadeTimer = num3;
			SetFadeProgress(fadeProgress);
			float fadeTimer = _fadeTimer;
			if (_fadeTimer < 1f)
			{
				return;
			}
			_fadeTimer = 0f;
			action = this.m_OnFadeOutComplete;
			object obj3 = 0;
		}
		else
		{
			float deltaTime3 = PauseSystem.DeltaTime;
			float num4 = deltaTime3 / _fadeInTime;
			float num5 = (_fadeTimer = num4 + _fadeTimer);
			SetFadeProgress(num5);
			float fadeTimer = _fadeTimer;
			if (_fadeTimer < 1f)
			{
				return;
			}
			_currentState = FadeState.Hold;
			_fadeTimer = 0f;
			action = this.m_OnFadeInComplete;
			float fadeProgress = num5;
			object obj3 = 0;
		}
		if (action != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v161.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private unsafe void SetFadeProgress(float fadeValue)
	{
		//IL_0141: Invalid comparison between I4 and F4
		//IL_0050: Expected F4, but got I4
		//IL_00b1: Expected O, but got Ref
		//IL_0170: Expected F4, but got Ref
		//IL_0174: Expected O, but got F4
		//IL_0123: Expected O, but got Ref
		//IL_0128->IL015a: Incompatible stack heights: 1 vs 0
		Material materialForRendering = _faderImage.materialForRendering;
		float num = 1f - fadeValue;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		materialForRendering.SetFloatImpl(FadeProgress, num);
		_faderImage.SetMaterialDirty();
		if (_fadeInTrianglesAlpha)
		{
		}
		Color color = _faderImage.color;
		object obj = default(object);
		_faderImage.color = (Color)(&obj);
		if (_includeBackgroundWhiteFade)
		{
			object whiteFadeCurve = _whiteFadeCurve;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rcx_v17 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rcx_v17 (System.Object)+10]");
			object obj2 = AnimationCurve.Evaluate_Injected((IntPtr)0, (float)(nint)(&obj));
			Color color2 = _whiteFade.color;
			_whiteFade.color = (Color)(&obj);
		}
	}

	public void TestFade()
	{
		_fadeTimer = 0f;
		SetFadeProgress(1f);
		BeginFade(null, null);
	}

	public EME_TeleportFader()
	{
		//IL_0020: Expected I, but got O
		_maxTrianglesAlpha = 1f;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	static EME_TeleportFader()
	{
		int fadeProgress = Shader.PropertyToID("_FadeProgress");
		FadeProgress = fadeProgress;
	}
}
