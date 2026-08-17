using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Doozy.Engine.Layouts;
using Doozy.Engine.Orientation;
using Doozy.Engine.Progress;
using Doozy.Engine.Settings;
using Doozy.Engine.Soundy;
using Doozy.Engine.UI.Animation;
using Doozy.Engine.UI.Base;
using Doozy.Engine.UI.Settings;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Doozy.Engine.UI;

public class UIView : UIComponentBase<UIView>
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<UIButton, bool> _003C_003E9__103_0;

		public static Func<UIButton, bool> _003C_003E9__103_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CRemoveNullChildUIButtons_003Eb__103_0(UIButton uiButton)
		{
			if ((object)uiButton != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [uiButton @ rdx (Doozy.Engine.UI.UIButton)+10]");
				return (nint)0 == 0;
			}
			return true;
		}

		internal bool _003CRemoveNullChildUIButtons_003Eb__103_1(UIButton t)
		{
			if ((object)t != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ rdx (Doozy.Engine.UI.UIButton)+10]");
				bool flag = (nint)0 == 0;
				return !flag;
			}
			return false;
		}

		internal void _003C_002Ecctor_003Eb__126_0(UIView _003Cp0_003E, UIViewBehaviorType _003Cp1_003E)
		{
		}
	}

	private sealed class _003CExecuteGetOrientationEnumerator_003Ed__110(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UIView _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0131: Expected I4, but got O
			if (_003C_003E1__state <= 1)
			{
				_003C_003E1__state = -1;
				OrientationDetector instance = OrientationDetector.Instance;
				if ((object)instance != null)
				{
					if (instance.m_currentOrientation == DetectedOrientation.Unknown)
					{
						OrientationDetector instance2 = OrientationDetector.Instance;
						if ((object)instance2 != null)
						{
							instance2.CheckDeviceOrientation();
							_003C_003E2__current = null;
							_003C_003E1__state = 1;
							return true;
						}
					}
					else
					{
						OrientationDetector instance3 = OrientationDetector.Instance;
						if ((object)instance3 != null && (object)_003C_003E4__this != null)
						{
							_003C_003E4__this.OnOrientationChange(instance3.m_currentOrientation);
							goto IL_011d;
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_011d;
			IL_011d:
			return false;
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

	private sealed class _003CHideEnumerator_003Ed__108(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UIView _003C_003E4__this;

		public bool instantAction;

		private float _003CstartTime_003E5__2;

		private float _003CtotalDuration_003E5__3;

		private float _003CelapsedTime_003E5__4;

		private float _003CstartDelay_003E5__5;

		private bool _003CinvokedOnStart_003E5__6;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0008: Expected O, but got Ref
			//IL_0090: Expected I4, but got I8
			//IL_001d: Expected O, but got I4
			//IL_0077: Expected I4, but got I8
			//IL_00f3: Expected O, but got I
			//IL_0108: Expected O, but got I
			//IL_005a: Expected I4, but got I8
			//IL_013c: Expected O, but got I
			//IL_0152: Expected O, but got I
			//IL_1515: Expected O, but got I
			//IL_0e9a: Expected O, but got I
			//IL_1621: Expected O, but got I
			//IL_018e: Expected O, but got I
			//IL_1336: Expected O, but got I
			//IL_0ed4: Expected O, but got I
			//IL_01a3: Expected O, but got I
			//IL_134b: Expected O, but got I
			//IL_0ee9: Expected O, but got I
			//IL_0266: Expected O, but got I
			//IL_0276: Expected O, but got I
			//IL_1370: Expected O, but got I
			//IL_0241: Expected O, but got I
			//IL_0251: Expected O, but got I
			//IL_13be: Expected O, but got I
			//IL_13d7: Expected O, but got I
			//IL_0fb6: Expected O, but got I
			//IL_0289: Expected O, but got Ref
			//IL_02ac: Expected O, but got I
			//IL_13ed: Expected O, but got I
			//IL_140a: Expected O, but got I4
			//IL_0f30: Expected O, but got I
			//IL_02d4: Expected O, but got I
			//IL_0f7e: Expected O, but got I
			//IL_0f97: Expected O, but got I
			//IL_0fa0: Expected O, but got I4
			//IL_0333: Expected O, but got I
			//IL_0343: Expected O, but got I
			//IL_163e: Expected O, but got Ref
			//IL_165c: Expected O, but got I
			//IL_1670: Expected O, but got I
			//IL_030e: Expected O, but got I
			//IL_031e: Expected O, but got I
			//IL_143d: Expected O, but got I4
			//IL_0358: Expected O, but got I
			//IL_1019: Expected O, but got I4
			//IL_036d: Expected O, but got I
			//IL_1462: Expected O, but got I4
			//IL_1694: Expected O, but got I
			//IL_03c4: Expected O, but got Ref
			//IL_03dc: Expected O, but got Ref
			//IL_0419: Expected O, but got I
			//IL_0429: Expected O, but got I
			//IL_043e: Expected O, but got I
			//IL_044e: Expected O, but got I
			//IL_048b: Expected O, but got I
			//IL_0564: Expected I, but got O
			//IL_058d: Expected O, but got I
			//IL_04ed: Expected O, but got I
			//IL_04a0: Expected O, but got I
			//IL_04b0: Expected O, but got I
			//IL_16a9: Expected O, but got I
			//IL_05a2: Expected O, but got I
			//IL_05b2: Expected O, but got I
			//IL_05c2: Expected O, but got I
			//IL_054c: Expected O, but got I
			//IL_0527: Expected O, but got I
			//IL_0537: Expected O, but got I
			//IL_05ff: Expected O, but got I
			//IL_06c3: Expected I, but got O
			//IL_06ec: Expected O, but got I
			//IL_0686: Expected O, but got I
			//IL_16be: Expected O, but got I
			//IL_069b: Expected O, but got I
			//IL_06ab: Expected O, but got I
			//IL_0701: Expected O, but got I
			//IL_0639: Expected O, but got I
			//IL_0649: Expected O, but got I
			//IL_0716: Expected O, but got I
			//IL_16e2: Expected O, but got I
			//IL_0768: Expected O, but got Ref
			//IL_077b: Expected O, but got Ref
			//IL_07ae: Expected O, but got I
			//IL_07be: Expected O, but got I
			//IL_07d1: Expected O, but got Ref
			//IL_0800: Expected O, but got I
			//IL_0814: Expected O, but got I
			//IL_0829: Expected O, but got I
			//IL_093e: Expected I, but got O
			//IL_0866: Expected O, but got I
			//IL_1734: Expected O, but got I
			//IL_0906: Expected O, but got I
			//IL_091b: Expected O, but got I
			//IL_092b: Expected O, but got I
			//IL_16f7: Expected O, but got I
			//IL_0953: Expected O, but got I
			//IL_0968: Expected O, but got I
			//IL_1758: Expected O, but got I
			//IL_09bf: Expected O, but got Ref
			//IL_09d3: Expected O, but got Ref
			//IL_0a0b: Expected O, but got I
			//IL_0a1b: Expected O, but got I
			//IL_0a30: Expected O, but got I
			//IL_0a40: Expected F4, but got I
			//IL_0a7d: Expected O, but got I
			//IL_176d: Expected O, but got I
			//IL_0acf: Expected O, but got I
			//IL_0a92: Expected F4, but got I
			//IL_1782: Expected O, but got I
			//IL_1792: Expected F4, but got I
			//IL_0ae4: Expected O, but got I
			//IL_0b19: Expected F4, but got I
			//IL_0b64: Expected O, but got I
			//IL_17bc: Expected O, but got I
			//IL_0beb: Expected O, but got I
			//IL_0b79: Expected O, but got I
			//IL_17a7: Expected O, but got I
			//IL_0c00: Expected F4, but got I
			//IL_0c23: Expected O, but got I
			//IL_0bae: Expected F4, but got I
			//IL_17e0: Expected O, but got I
			//IL_0c8b: Expected O, but got I
			//IL_1824: Expected O, but got F4
			//IL_1219: Expected O, but got I
			//IL_122f: Expected O, but got I
			//IL_0d45: Expected O, but got I
			//IL_1276: Expected O, but got I
			//IL_0d5a: Expected O, but got I
			//IL_128c: Expected O, but got I
			//IL_0d7f: Expected O, but got I
			//IL_0de2: Expected O, but got I4
			object obj2 = default(object);
			object obj = (object)(&obj2);
			UIComponentBase<UIView> uIComponentBase = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			object obj4;
			bool flag2;
			if (!flag)
			{
				object obj3 = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj3 == 1)
					{
						_003C_003E1__state = -1;
						flag2 = false;
						goto IL_0e5f;
					}
					goto IL_15d4;
				}
				_003C_003E1__state = -1;
				obj4 = null;
				goto IL_15e2;
			}
			_003C_003E1__state = -1;
			DoozySettings instance = DoozySettings.Instance;
			if (instance.AutoDisableUIInteractions)
			{
				UIComponentBase<UIView>.DisableUIInteractions();
			}
			RectTransform rectTransform = _003C_003E4__this.RectTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rcx_v88+10]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rcx_v89+10]");
			UIAnimator.StopAnimations(rectTransform, AnimationType.Undefined);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+90]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v649 @ rcx_v92+10]");
			if (((UIAnimation)0).Enabled)
			{
				RectTransform rectTransform2 = _003C_003E4__this.RectTransform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+90]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v651 @ rcx_v200+10]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v652 @ rcx_v201+10]");
				UIAnimator.StopAnimations(rectTransform2, AnimationType.Undefined);
			}
			_003C_003E4__this.CheckForLayoutController();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+139]");
			if ((nint)0 != 0)
			{
				((UIComponentBase<>)(object)_003C_003E4__this).UpdateStartPosition();
			}
			RectTransform rectTransform3 = _003C_003E4__this.RectTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+C6]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+68]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+70]");
				object obj12 = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+24]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+2C]");
				object obj12 = 0;
			}
			Vector3 startValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v653 @ rcx_v98+10]");
			Vector3 animationMoveFrom = UIAnimator.GetAnimationMoveFrom(rectTransform3, (UIAnimation)0, startValue);
			RectTransform rectTransform4 = _003C_003E4__this.RectTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+C6]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+68]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+70]");
				object obj15 = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+24]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+2C]");
				object obj15 = 0;
			}
			Vector3 startValue2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ rcx_v102+10]");
			Vector3 animationMoveTo = UIAnimator.GetAnimationMoveTo(rectTransform4, (UIAnimation)0, startValue2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v600 @ rax_v116+10]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rax_v117+18]");
			object obj18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rdx_v66+14]");
			if ((nint)0 != 0)
			{
				((UIComponentBase<>)(object)_003C_003E4__this).ResetPosition();
			}
			RectTransform rectTransform5 = _003C_003E4__this.RectTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
			object obj19 = 0;
			_ = animationMoveTo.z;
			Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			_ = animationMoveTo.x;
			Vector3 startValue3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			_ = animationMoveFrom.x;
			_ = animationMoveFrom.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v656 @ rcx_v110+10]");
			bool flag3 = default(bool);
			UnityAction onStartCallback = default(UnityAction);
			UnityAction onCompleteCallback = default(UnityAction);
			UIAnimator.Move(rectTransform5, (UIAnimation)0, startValue3, endValue, flag3, onStartCallback, onCompleteCallback);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
			object obj20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ rsi_v19+10]");
			object obj21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+38]");
			object obj22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v521 @ rsi_v20+10]");
			if ((nint)0 == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v521 @ rsi_v20+20]");
				object obj23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rax_v227+18]");
				Vector3 vector = (Vector3)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rax_v227+20]");
				obj22 = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v521 @ rsi_v20+10]");
				if ((nint)0 == 2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v521 @ rsi_v20+20]");
					object obj24 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v605 @ rax_v226+3C]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v605 @ rax_v226+18]");
						Vector3 vector = (Vector3)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v605 @ rax_v226+20]");
						obj22 = 0;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+30]");
						Vector3 vector = (Vector3)0;
					}
				}
				else
				{
					nint num = (nint)typeof(UIAnimator);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2561 @ rax_v224 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
					nint num2 = 0;
					Vector3 vector = UIAnimator.DEFAULT_START_ROTATION;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2562 @ rcx_v193 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+14]");
					obj22 = 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
			object obj25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ rsi_v21+10]");
			object obj26 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+30]");
			Vector3 vector2 = (Vector3)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+38]");
			object obj27 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rsi_v22+10]");
			if ((nint)0 == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rsi_v22+20]");
				object obj28 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v221+3C]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v221+24]");
					vector2 = (Vector3)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v221+2C]");
					obj27 = 0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rsi_v22+10]");
				if ((nint)0 == 2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rsi_v22+20]");
					object obj29 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v220+24]");
					vector2 = (Vector3)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v220+2C]");
					obj27 = 0;
				}
				else
				{
					nint num3 = (nint)typeof(UIAnimator);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2648 @ rax_v218 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
					nint num4 = 0;
					vector2 = UIAnimator.DEFAULT_START_ROTATION;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2649 @ rcx_v190 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+14]");
					obj27 = 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
			object obj30 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v608 @ rax_v129+10]");
			object obj31 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rcx_v117+20]");
			object obj32 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rax_v130+14]");
			if ((nint)0 != 0)
			{
				((UIComponentBase<>)(object)_003C_003E4__this).ResetRotation();
			}
			RectTransform rectTransform6 = _003C_003E4__this.RectTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
			object obj33 = 0;
			Vector3 endValue2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			Vector3 startValue4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ rcx_v123+10]");
			UIAnimator.Rotate(rectTransform6, (UIAnimation)0, startValue4, endValue2, flag3, onStartCallback, onCompleteCallback);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
			object obj34 = 0;
			Vector3 startValue5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+3C]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+44]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rdx_v73+10]");
			Vector3 animationScaleFrom = UIAnimator.GetAnimationScaleFrom((UIAnimation)0, startValue5);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
			object obj35 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rsi_v24+10]");
			object obj36 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rsi_v25+10]");
			if ((nint)0 == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rsi_v25+28]");
				object obj37 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ rax_v211+3C]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ rax_v211+24]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ rax_v211+2C]");
					_ = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+3C]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+44]");
					_ = 0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rsi_v25+10]");
				if ((nint)0 == 2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rsi_v25+28]");
					object obj38 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ rax_v209+24]");
					Vector3 vector3 = (Vector3)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ rax_v209+2C]");
					object obj39 = 0;
				}
				else
				{
					nint num5 = (nint)typeof(UIAnimator);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2762 @ rax_v204 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
					nint num6 = 0;
					Vector3 vector3 = UIAnimator.DEFAULT_START_SCALE;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2765 @ rax_v205 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+20]");
					object obj39 = 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
			object obj40 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rax_v141+10]");
			object obj41 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v615 @ rax_v142+28]");
			object obj42 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rdx_v75+14]");
			if ((nint)0 != 0)
			{
				((UIComponentBase<>)(object)_003C_003E4__this).ResetScale();
			}
			RectTransform rectTransform7 = _003C_003E4__this.RectTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
			object obj43 = 0;
			_ = animationScaleFrom.z;
			Vector3 endValue3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			_ = 1f;
			Vector3 startValue6 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			_ = animationScaleFrom.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v666 @ rcx_v134+10]");
			UIAnimator.Scale(rectTransform7, (UIAnimation)0, startValue6, endValue3, flag3, onStartCallback, onCompleteCallback);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
			object obj44 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v617 @ rax_v148+10]");
			object obj45 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+48]");
			float num7 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ rax_v149+10]");
			object obj48;
			if ((nint)0 == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ rax_v149+30]");
				object obj46 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ rcx_v182+18]");
				num7 = 0f;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ rax_v149+10]");
				if ((nint)0 == 2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ rax_v149+30]");
					object obj47 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
					obj48 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ rcx_v181+24]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ rcx_v181+18]");
						num7 = 0f;
					}
					goto IL_1772;
				}
				num7 = 1f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
			obj48 = 0;
			goto IL_1772;
			IL_15e2:
			if (!(_003CtotalDuration_003E5__3 < _003CelapsedTime_003E5__4))
			{
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				float num8 = (_003CelapsedTime_003E5__4 = realtimeSinceStartup - _003CstartTime_003E5__2);
				if (!_003CinvokedOnStart_003E5__6 && num8 > _003CstartDelay_003E5__5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
					object obj49 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rsi_v7+28]");
					UIAction uIAction = (UIAction)0;
					GameObject gameObject = _003C_003E4__this.gameObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rsi_v7+28]");
					if (((UIAction)0).HasSound)
					{
						SoundyController soundyController = SoundyManager.Play(uIAction.SoundData);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rsi_v7+28]");
					Canvas canvas = ((UIAction)0).GetCanvas(gameObject);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rsi_v7+28]");
					((UIAction)0).ExecuteEffect(canvas);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rsi_v7+28]");
					((UIAction)0).InvokeAnimatorEvents();
					bool flag4 = uIAction.GameEvents == null;
					object obj50 = 0;
					if (!flag4)
					{
						List<string> gameEvents = uIAction.GameEvents;
						bool flag5 = gameEvents._size <= 0;
						obj50 = 0;
						if (!flag5)
						{
							GameEventMessage.SendEvents(gameEvents, gameObject);
							obj50 = 0;
						}
					}
					if (uIAction.Event != null)
					{
						uIAction.Event.Invoke();
					}
					if (uIAction.Action != null)
					{
						Action<GameObject> action = uIAction.Action;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2272 @ rax_v33 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
					}
					_003CinvokedOnStart_003E5__6 = true;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+138]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+130]");
					((LayoutController)0).Rebuild(forced: true);
				}
				float num9 = _003CelapsedTime_003E5__4 / _003CtotalDuration_003E5__3;
				float visibilityProgress = 1f - num9;
				_003C_003E4__this.VisibilityProgress = visibilityProgress;
				_003C_003E2__current = obj4;
				_003C_003E1__state = 1;
			}
			else
			{
				WaitForSecondsRealtime waitForSecondsRealtime = null;
				waitForSecondsRealtime.m_WaitUntilTime = -1f;
				waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = 0.05f;
				_003C_003E2__current = waitForSecondsRealtime;
				_003C_003E1__state = 2;
			}
			return true;
			IL_0e5f:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+138]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+130]");
				((LayoutController)0).Rebuild(forced: true);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+128]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
				object obj51 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rsi_v13+20]");
				UIAction uIAction2 = (UIAction)0;
				GameObject gameObject2 = _003C_003E4__this.gameObject;
				if (!instantAction)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rsi_v13+20]");
					if (((UIAction)0).HasSound)
					{
						SoundyController soundyController2 = SoundyManager.Play(uIAction2.SoundData);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rsi_v13+20]");
					Canvas canvas2 = ((UIAction)0).GetCanvas(gameObject2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rsi_v13+20]");
					((UIAction)0).ExecuteEffect(canvas2);
					endValue3 = (Vector3)0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rsi_v13+20]");
				((UIAction)0).InvokeAnimatorEvents();
				if (uIAction2.GameEvents != null)
				{
					List<string> gameEvents2 = uIAction2.GameEvents;
					if (gameEvents2._size > 0)
					{
						GameEventMessage.SendEvents(gameEvents2, gameObject2);
						endValue3 = (Vector3)0;
					}
				}
				if (uIAction2.Event != null)
				{
					uIAction2.Event.Invoke();
				}
				if (uIAction2.Action != null)
				{
					Action<GameObject> action2 = uIAction2.Action;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2133 @ rax_v88 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
				}
			}
			_ = 1;
			_003C_003E4__this.VisibilityProgress = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ACD0");
			object obj52 = default(object);
			if (obj52 != null)
			{
				bool flag6 = ((List<object>)(object)VisibleViews).Remove((object)_003C_003E4__this);
			}
			Canvas canvas3 = _003C_003E4__this.Canvas;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+76]");
			bool enabled = (nint)0 == 0;
			canvas3.enabled = enabled;
			GraphicRaycaster graphicRaycaster = _003C_003E4__this.GraphicRaycaster;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+78]");
			bool enabled2 = (nint)0 == 0;
			graphicRaycaster.enabled = enabled2;
			GameObject gameObject3 = _003C_003E4__this.gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+77]");
			bool active = (nint)0 == 0;
			gameObject3.SetActive(active);
			DoozySettings instance2 = DoozySettings.Instance;
			if (instance2.AutoDisableUIInteractions)
			{
				UIComponentBase<UIView>.EnableUIInteractions();
			}
			RemoveHiddenFromVisibleViews();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+128]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			goto IL_15d4;
			IL_15d4:
			return false;
			IL_1772:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2890 @ rax_v150+10]");
			object obj53 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+48]");
			float num10 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ rax_v151+10]");
			if ((nint)0 == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ rax_v151+30]");
				object obj54 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
				object obj55 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v670 @ rcx_v179+24]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v670 @ rcx_v179+1C]");
					num10 = 0f;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ rax_v151+10]");
				if ((nint)0 == 2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ rax_v151+30]");
					object obj56 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v671 @ rcx_v178+1C]");
					num10 = 0f;
				}
				else
				{
					num10 = 1f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
				object obj55 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rax_v152+10]");
			object obj57 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ rcx_v141+30]");
			object obj58 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v620 @ rax_v153+14]");
			if ((nint)0 != 0)
			{
				((UIComponentBase<>)(object)_003C_003E4__this).ResetAlpha();
			}
			RectTransform rectTransform8 = _003C_003E4__this.RectTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
			object obj59 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rcx_v147+10]");
			UIAnimator.Fade(rectTransform8, (UIAnimation)0, num7, num10, flag3, onStartCallback, onCompleteCallback);
			_003C_003E4__this.HideDeselectButton();
			_ = 2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ACD0");
			object obj60 = default(object);
			if (obj60 != null)
			{
				bool flag7 = ((List<object>)(object)VisibleViews).Remove((object)_003C_003E4__this);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+128]");
			if ((nint)0 != 0)
			{
				if (instantAction)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
					object obj61 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ rsi_v30+28]");
					UIAction uIAction3 = (UIAction)0;
					GameObject gameObject4 = _003C_003E4__this.gameObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ rsi_v30+28]");
					((UIAction)0).InvokeAnimatorEvents();
					if (uIAction3.GameEvents != null)
					{
						List<string> gameEvents3 = uIAction3.GameEvents;
						if (gameEvents3._size > 0)
						{
							GameEventMessage.SendEvents(gameEvents3, gameObject4);
							endValue3 = (Vector3)0;
						}
					}
					if (uIAction3.Event != null)
					{
						uIAction3.Event.Invoke();
					}
					if (uIAction3.Action != null)
					{
						Action<GameObject> action3 = uIAction3.Action;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3224 @ rax_v177 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
					}
				}
				_003C_003E4__this.NotifySystemOfTriggeredBehavior(UIViewBehaviorType.Hide);
			}
			object obj62 = Time.realtimeSinceStartup;
			float num11 = default(float);
			_003CstartTime_003E5__2 = num11;
			bool flag8 = !instantAction;
			float num12 = num7;
			float num13 = num10;
			flag2 = false;
			if (flag8)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
				object obj63 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rax_v169+10]");
				float totalDuration = ((UIAnimation)0).TotalDuration;
				_003CtotalDuration_003E5__3 = totalDuration;
				float realtimeSinceStartup2 = Time.realtimeSinceStartup;
				float num14 = _003CstartTime_003E5__2 - realtimeSinceStartup2;
				_003CelapsedTime_003E5__4 = num14;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+80]");
				object obj64 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rcx_v158+10]");
				float startDelay = ((UIAnimation)0).StartDelay;
				_003CstartDelay_003E5__5 = startDelay;
				_003CinvokedOnStart_003E5__6 = false;
				num12 = num7;
				num13 = num10;
				obj4 = null;
				goto IL_15e2;
			}
			goto IL_0e5f;
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

	private sealed class _003CHideViewNextFrame_003Ed__106(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public string viewCategory;

		public string viewName;

		public bool instantAction;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				HideView(viewCategory, viewName, instantAction);
			}
			return false;
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

	private sealed class _003CHideWithDelayEnumerator_003Ed__109(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public UIView _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_001f: Invalid comparison between F4 and I4
			//IL_00a9: Expected I4, but got I8
			//IL_00e1: Expected I4, but got O
			UIView uIView = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if (delay > 0f)
				{
					WaitForSecondsRealtime waitForSecondsRealtime = null;
					waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = delay;
					waitForSecondsRealtime.m_WaitUntilTime = -1f;
					_003C_003E2__current = waitForSecondsRealtime;
					_003C_003E1__state = 1;
					return true;
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_00cd;
				}
				_003C_003E1__state = -1;
			}
			if ((object)_003C_003E4__this != null)
			{
				_003C_003E4__this.Hide();
				uIView.m_autoHideCoroutine = null;
				goto IL_00cd;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_00cd:
			return false;
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

	private sealed class _003CShowEnumerator_003Ed__107(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UIView _003C_003E4__this;

		public bool instantAction;

		private float _003CstartTime_003E5__2;

		private float _003CtotalDuration_003E5__3;

		private float _003CelapsedTime_003E5__4;

		private float _003CstartDelay_003E5__5;

		private bool _003CinvokedOnStart_003E5__6;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0008: Expected O, but got Ref
			//IL_001c: Expected I4, but got I8
			//IL_0fea: Expected I4, but got I8
			//IL_007d: Expected O, but got I
			//IL_12a5: Expected O, but got I
			//IL_0092: Expected O, but got I
			//IL_12ba: Expected O, but got I
			//IL_1290: Expected O, but got I
			//IL_1855: Expected O, but got F4
			//IL_00c6: Expected O, but got I
			//IL_1385: Expected O, but got I
			//IL_00dc: Expected O, but got I
			//IL_12ff: Expected O, but got I
			//IL_1208: Expected O, but got I
			//IL_134d: Expected O, but got I
			//IL_1366: Expected O, but got I
			//IL_136f: Expected O, but got I4
			//IL_102b: Expected O, but got I
			//IL_0116: Expected O, but got I
			//IL_1040: Expected O, but got I
			//IL_012b: Expected O, but got I
			//IL_1063: Expected O, but got I
			//IL_01bf: Expected O, but got I
			//IL_10b1: Expected O, but got I
			//IL_10ca: Expected O, but got I
			//IL_13e8: Expected O, but got I4
			//IL_10e0: Expected O, but got I
			//IL_10fd: Expected O, but got I4
			//IL_021e: Expected O, but got I
			//IL_022e: Expected O, but got I
			//IL_14e1: Expected F4, but got I
			//IL_01f9: Expected O, but got I
			//IL_0209: Expected O, but got I
			//IL_0241: Expected O, but got Ref
			//IL_0264: Expected O, but got I
			//IL_028a: Expected O, but got I
			//IL_1130: Expected O, but got I4
			//IL_02e9: Expected O, but got I
			//IL_02f9: Expected O, but got I
			//IL_1155: Expected O, but got I4
			//IL_159e: Expected O, but got Ref
			//IL_15bc: Expected O, but got I
			//IL_15d0: Expected O, but got I
			//IL_02c4: Expected O, but got I
			//IL_02d4: Expected O, but got I
			//IL_030e: Expected O, but got I
			//IL_0323: Expected O, but got I
			//IL_15f2: Expected O, but got I
			//IL_0378: Expected O, but got Ref
			//IL_0390: Expected O, but got Ref
			//IL_03cd: Expected O, but got I
			//IL_03dd: Expected O, but got I
			//IL_03f2: Expected O, but got I
			//IL_0402: Expected O, but got I
			//IL_043f: Expected O, but got I
			//IL_0518: Expected I, but got O
			//IL_0541: Expected O, but got I
			//IL_04a1: Expected O, but got I
			//IL_0454: Expected O, but got I
			//IL_0464: Expected O, but got I
			//IL_1607: Expected O, but got I
			//IL_0556: Expected O, but got I
			//IL_0566: Expected O, but got I
			//IL_0576: Expected O, but got I
			//IL_0500: Expected O, but got I
			//IL_04db: Expected O, but got I
			//IL_04eb: Expected O, but got I
			//IL_05b3: Expected O, but got I
			//IL_0677: Expected I, but got O
			//IL_06a0: Expected O, but got I
			//IL_063a: Expected O, but got I
			//IL_161c: Expected O, but got I
			//IL_064f: Expected O, but got I
			//IL_065f: Expected O, but got I
			//IL_06b5: Expected O, but got I
			//IL_05ed: Expected O, but got I
			//IL_05fd: Expected O, but got I
			//IL_06ca: Expected O, but got I
			//IL_163e: Expected O, but got I
			//IL_071a: Expected O, but got Ref
			//IL_0728: Expected O, but got Ref
			//IL_0760: Expected O, but got I
			//IL_0770: Expected O, but got I
			//IL_0785: Expected O, but got I
			//IL_0885: Expected I, but got O
			//IL_089e: Expected F4, but got O
			//IL_080a: Expected O, but got I
			//IL_1665: Expected O, but got I
			//IL_08b9: Expected O, but got I
			//IL_08f6: Expected O, but got I
			//IL_09d3: Expected I, but got O
			//IL_09f3: Expected O, but got I
			//IL_09fc: Expected F4, but got O
			//IL_0996: Expected O, but got I
			//IL_09ab: Expected F4, but got I
			//IL_09bb: Expected O, but got I
			//IL_167a: Expected O, but got I
			//IL_0a11: Expected O, but got I
			//IL_0a26: Expected O, but got I
			//IL_16ab: Expected O, but got I
			//IL_0a71: Expected O, but got Ref
			//IL_0a7f: Expected O, but got Ref
			//IL_0abe: Expected O, but got I
			//IL_0ace: Expected O, but got I
			//IL_0ae3: Expected O, but got I
			//IL_0af3: Expected F4, but got I
			//IL_0b30: Expected O, but got I
			//IL_16c0: Expected O, but got I
			//IL_0b82: Expected O, but got I
			//IL_0b45: Expected F4, but got I
			//IL_16d5: Expected O, but got I
			//IL_16e5: Expected F4, but got I
			//IL_0b97: Expected O, but got I
			//IL_0bcc: Expected F4, but got I
			//IL_0c17: Expected O, but got I
			//IL_170f: Expected O, but got I
			//IL_0c9e: Expected O, but got I
			//IL_0c2c: Expected O, but got I
			//IL_16fa: Expected O, but got I
			//IL_0cb3: Expected F4, but got I
			//IL_0cd6: Expected O, but got I
			//IL_0c61: Expected F4, but got I
			//IL_1731: Expected O, but got I
			//IL_0d3c: Expected O, but got I
			//IL_1754: Expected O, but got I
			//IL_0db4: Expected O, but got I
			//IL_0dc9: Expected O, but got I
			//IL_0dec: Expected O, but got I
			//IL_17a0: Expected O, but got F4
			//IL_17aa: Expected F4, but got O
			//IL_17db: Expected F4, but got O
			//IL_0f4b: Expected O, but got I
			//IL_0f61: Expected O, but got I
			//IL_0e4f: Expected O, but got I4
			//IL_17f2: Expected O, but got F4
			//IL_181d: Expected O, but got I
			//IL_0f1e: Expected O, but got I
			//IL_0f27: Expected F4, but got I4
			//IL_0f31: Expected O, but got I4
			//IL_0f85: Expected O, but got I
			object obj2 = default(object);
			object obj = (object)(&obj2);
			UIComponentBase<UIView> uIComponentBase = _003C_003E4__this;
			bool flag = default(bool);
			UnityAction onStartCallback = default(UnityAction);
			UnityAction onCompleteCallback = default(UnityAction);
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				DoozySettings instance = DoozySettings.Instance;
				if (instance.AutoDisableUIInteractions)
				{
					UIComponentBase<UIView>.DisableUIInteractions();
				}
				RectTransform rectTransform = uIComponentBase.RectTransform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ rcx_v86+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rcx_v87+10]");
				UIAnimator.StopAnimations(rectTransform, AnimationType.Undefined);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+90]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v625 @ rcx_v90+10]");
				if (((UIAnimation)0).Enabled)
				{
					RectTransform rectTransform2 = uIComponentBase.RectTransform;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+90]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v627 @ rcx_v211+10]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v628 @ rcx_v212+10]");
					UIAnimator.StopAnimations(rectTransform2, AnimationType.Undefined);
				}
				Canvas canvas = ((UIView)uIComponentBase).Canvas;
				canvas.enabled = true;
				GraphicRaycaster graphicRaycaster = ((UIView)uIComponentBase).GraphicRaycaster;
				graphicRaycaster.enabled = true;
				((UIView)uIComponentBase).CheckForLayoutController();
				RectTransform rectTransform3 = uIComponentBase.RectTransform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+C6]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+68]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+70]");
					object obj10 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+24]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+2C]");
					object obj10 = 0;
				}
				Vector3 startValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v631 @ rcx_v99+10]");
				Vector3 animationMoveFrom = UIAnimator.GetAnimationMoveFrom(rectTransform3, (UIAnimation)0, startValue);
				RectTransform rectTransform4 = uIComponentBase.RectTransform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+C6]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+68]");
					Vector3 vector = (Vector3)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+70]");
					object obj12 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+24]");
					Vector3 vector = (Vector3)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+2C]");
					object obj12 = 0;
				}
				Vector3 startValue2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ rcx_v103+10]");
				Vector3 animationMoveTo = UIAnimator.GetAnimationMoveTo(rectTransform4, (UIAnimation)0, startValue2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
				object obj13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rax_v121+10]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v573 @ rax_v122+18]");
				object obj15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rdx_v66+14]");
				if ((nint)0 != 0)
				{
					((UIComponentBase<>)(object)uIComponentBase).ResetPosition();
				}
				RectTransform rectTransform5 = uIComponentBase.RectTransform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
				object obj16 = 0;
				_ = animationMoveTo.z;
				Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				_ = animationMoveTo.x;
				Vector3 startValue3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				_ = animationMoveFrom.x;
				_ = animationMoveFrom.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v634 @ rcx_v111+10]");
				UIAnimator.Move(rectTransform5, (UIAnimation)0, startValue3, endValue, flag, onStartCallback, onCompleteCallback);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
				object obj17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ rsi_v19+10]");
				object obj18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+38]");
				object obj19 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v490 @ rsi_v20+10]");
				if ((nint)0 == 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v490 @ rsi_v20+20]");
					object obj20 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rax_v258+18]");
					Vector3 vector2 = (Vector3)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rax_v258+20]");
					obj19 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v490 @ rsi_v20+10]");
					if ((nint)0 == 2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v490 @ rsi_v20+20]");
						object obj21 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ rax_v257+3C]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ rax_v257+18]");
							Vector3 vector2 = (Vector3)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ rax_v257+20]");
							obj19 = 0;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+30]");
							Vector3 vector2 = (Vector3)0;
						}
					}
					else
					{
						nint num = (nint)typeof(UIAnimator);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2602 @ rax_v255 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
						nint num2 = 0;
						Vector3 vector2 = UIAnimator.DEFAULT_START_ROTATION;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2603 @ rcx_v205 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+14]");
						obj19 = 0;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
				object obj22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ rsi_v21+10]");
				object obj23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+30]");
				Vector3 vector3 = (Vector3)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+38]");
				object obj24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rsi_v22+10]");
				if ((nint)0 == 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rsi_v22+20]");
					object obj25 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v578 @ rax_v252+3C]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v578 @ rax_v252+24]");
						vector3 = (Vector3)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v578 @ rax_v252+2C]");
						obj24 = 0;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rsi_v22+10]");
					if ((nint)0 == 2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rsi_v22+20]");
						object obj26 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v579 @ rax_v251+24]");
						vector3 = (Vector3)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v579 @ rax_v251+2C]");
						obj24 = 0;
					}
					else
					{
						nint num3 = (nint)typeof(UIAnimator);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2689 @ rax_v249 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
						nint num4 = 0;
						vector3 = UIAnimator.DEFAULT_START_ROTATION;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2690 @ rcx_v202 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+14]");
						obj24 = 0;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
				object obj27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v135+10]");
				object obj28 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ rcx_v118+20]");
				object obj29 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ rax_v136+14]");
				if ((nint)0 != 0)
				{
					((UIComponentBase<>)(object)uIComponentBase).ResetRotation();
				}
				RectTransform rectTransform6 = uIComponentBase.RectTransform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
				object obj30 = 0;
				Vector3 endValue2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				Vector3 startValue4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rcx_v124+10]");
				UIAnimator.Rotate(rectTransform6, (UIAnimation)0, startValue4, endValue2, flag, onStartCallback, onCompleteCallback);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
				object obj31 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rsi_v24+10]");
				object obj32 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rsi_v25+10]");
				if ((nint)0 == 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rsi_v25+28]");
					nint num5 = 0;
					_ = UIAnimator.DEFAULT_START_SCALE;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rsi_v25+10]");
					if ((nint)0 == 2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rsi_v25+28]");
						object obj33 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v585 @ rax_v241+3C]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v585 @ rax_v241+18]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v585 @ rax_v241+20]");
							_ = 0;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+3C]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+44]");
							_ = 0;
						}
						goto IL_1655;
					}
					nint num6 = (nint)typeof(UIAnimator);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2836 @ rax_v238 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
					nint num5 = 0;
					float num7 = (float)UIAnimator.DEFAULT_START_SCALE;
					_ = UIAnimator.DEFAULT_START_SCALE;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2809 @ rax_v235 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+20]");
				_ = 0;
				goto IL_1655;
			}
			if (_003C_003E1__state != 1)
			{
				goto IL_154c;
			}
			_003C_003E1__state = -1;
			object obj34 = null;
			goto IL_1822;
			IL_1822:
			float num8 = _003CtotalDuration_003E5__3;
			if (!(_003CtotalDuration_003E5__3 < _003CelapsedTime_003E5__4))
			{
				object obj35 = Time.realtimeSinceStartup;
				float num9 = (_003CelapsedTime_003E5__4 = _003CtotalDuration_003E5__3 - _003CstartTime_003E5__2);
				if (!_003CinvokedOnStart_003E5__6 && num9 > _003CstartDelay_003E5__5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
					object obj36 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ rsi_v6+28]");
					UIAction uIAction = (UIAction)0;
					GameObject gameObject = uIComponentBase.gameObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ rsi_v6+28]");
					if (((UIAction)0).HasSound)
					{
						SoundyController soundyController = SoundyManager.Play(uIAction.SoundData);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ rsi_v6+28]");
					Canvas canvas2 = ((UIAction)0).GetCanvas(gameObject);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ rsi_v6+28]");
					((UIAction)0).ExecuteEffect(canvas2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ rsi_v6+28]");
					((UIAction)0).InvokeAnimatorEvents();
					bool flag2 = uIAction.GameEvents == null;
					object obj37 = 0;
					if (!flag2)
					{
						List<string> gameEvents = uIAction.GameEvents;
						bool flag3 = gameEvents._size <= 0;
						obj37 = 0;
						if (!flag3)
						{
							GameEventMessage.SendEvents(gameEvents, gameObject);
							obj37 = 0;
						}
					}
					if (uIAction.Event != null)
					{
						uIAction.Event.Invoke();
					}
					if (uIAction.Action != null)
					{
						Action<GameObject> action = uIAction.Action;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2280 @ rax_v30 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
					}
					_003CinvokedOnStart_003E5__6 = true;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+138]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+130]");
					((LayoutController)0).Rebuild(forced: true);
				}
				float visibilityProgress = _003CelapsedTime_003E5__4 / _003CtotalDuration_003E5__3;
				((UIView)uIComponentBase).VisibilityProgress = visibilityProgress;
				_003C_003E2__current = obj34;
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_1255;
			IL_154c:
			return false;
			IL_16c5:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3048 @ rax_v158+10]");
			object obj38 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+48]");
			float num10 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v159+10]");
			if ((nint)0 == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v159+30]");
				object obj39 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
				object obj40 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rcx_v189+24]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rcx_v189+1C]");
					num10 = 0f;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v159+10]");
				if ((nint)0 == 2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v159+30]");
					object obj41 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v649 @ rcx_v188+1C]");
					num10 = 0f;
				}
				else
				{
					num10 = 1f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
				object obj40 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ rax_v160+10]");
			object obj42 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v650 @ rcx_v143+30]");
			object obj43 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ rax_v161+14]");
			if ((nint)0 != 0)
			{
				((UIComponentBase<>)(object)uIComponentBase).ResetAlpha();
			}
			RectTransform rectTransform7 = uIComponentBase.RectTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
			object obj44 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v651 @ rcx_v149+10]");
			float num11;
			UIAnimator.Fade(rectTransform7, (UIAnimation)0, num11, num10, flag, onStartCallback, onCompleteCallback);
			_ = 3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ACD0");
			object obj45 = default(object);
			if (obj45 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AD40");
			}
			Vector3 vector4;
			if (instantAction)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
				object obj46 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rsi_v32+28]");
				UIAction uIAction2 = (UIAction)0;
				GameObject gameObject2 = uIComponentBase.gameObject;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rsi_v32+28]");
				((UIAction)0).InvokeAnimatorEvents();
				if (uIAction2.GameEvents != null)
				{
					List<string> gameEvents2 = uIAction2.GameEvents;
					if (gameEvents2._size > 0)
					{
						GameEventMessage.SendEvents(gameEvents2, gameObject2);
						vector4 = (Vector3)0;
					}
				}
				if (uIAction2.Event != null)
				{
					uIAction2.Event.Invoke();
				}
				if (uIAction2.Action != null)
				{
					Action<GameObject> action2 = uIAction2.Action;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3448 @ rax_v199 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
				}
			}
			((UIView)uIComponentBase).NotifySystemOfTriggeredBehavior(UIViewBehaviorType.Show);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+88]");
			object obj47 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+88]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rsi_v31+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+88]");
					((Progressor)0).SetValue(0f, instantUpdate: false);
					float num7 = 0f;
					vector4 = (Vector3)0;
				}
			}
			object obj48 = Time.realtimeSinceStartup;
			Vector3 vector5 = default(Vector3);
			_003CstartTime_003E5__2 = (float)vector5;
			bool flag4 = instantAction;
			float num12 = num11;
			float num13 = num10;
			obj34 = null;
			num8 = (float)vector5;
			if (flag4)
			{
				goto IL_1255;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
			object obj49 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v599 @ rax_v182+10]");
			float num14 = (_003CtotalDuration_003E5__3 = ((UIAnimation)0).TotalDuration);
			object obj50 = Time.realtimeSinceStartup;
			float num15 = _003CstartTime_003E5__2 - num14;
			_003CelapsedTime_003E5__4 = num15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
			object obj51 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rcx_v165+10]");
			float startDelay = ((UIAnimation)0).StartDelay;
			_003CstartDelay_003E5__5 = startDelay;
			_003CinvokedOnStart_003E5__6 = false;
			num12 = num11;
			num13 = num10;
			obj34 = null;
			goto IL_1822;
			IL_1255:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+138]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+130]");
				((LayoutController)0).Rebuild(forced: true);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
			object obj52 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rsi_v13+20]");
			UIAction uIAction3 = (UIAction)0;
			GameObject gameObject3 = uIComponentBase.gameObject;
			if (!instantAction)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rsi_v13+20]");
				if (((UIAction)0).HasSound)
				{
					SoundyController soundyController2 = SoundyManager.Play(uIAction3.SoundData);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rsi_v13+20]");
				Canvas canvas3 = ((UIAction)0).GetCanvas(gameObject3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rsi_v13+20]");
				((UIAction)0).ExecuteEffect(canvas3);
				vector4 = (Vector3)0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rsi_v13+20]");
			((UIAction)0).InvokeAnimatorEvents();
			if (uIAction3.GameEvents != null)
			{
				List<string> gameEvents3 = uIAction3.GameEvents;
				if (gameEvents3._size > 0)
				{
					GameEventMessage.SendEvents(gameEvents3, gameObject3);
					vector4 = (Vector3)0;
				}
			}
			if (uIAction3.Event != null)
			{
				uIAction3.Event.Invoke();
			}
			if (uIAction3.Action != null)
			{
				Action<GameObject> action3 = uIAction3.Action;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2135 @ rax_v90 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
			}
			((UIView)uIComponentBase).VisibilityProgress = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ACD0");
			object obj53 = default(object);
			if (obj53 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AD40");
			}
			((UIView)uIComponentBase).StartLoopAnimation();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+58]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+5C]");
				((UIView)uIComponentBase).Hide(0f);
			}
			((UIView)uIComponentBase).ShowSelectDeselectButton();
			DoozySettings instance2 = DoozySettings.Instance;
			if (instance2.AutoDisableUIInteractions)
			{
				UIComponentBase<UIView>.EnableUIInteractions();
			}
			RemoveHiddenFromVisibleViews();
			goto IL_154c;
			IL_1655:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
			object obj54 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rsi_v26+10]");
			object obj55 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rsi_v27+10]");
			if ((nint)0 == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rsi_v27+28]");
				object obj56 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rax_v232+3C]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rax_v232+24]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rax_v232+2C]");
					_ = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+3C]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+44]");
					_ = 0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rsi_v27+10]");
				if ((nint)0 == 2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rsi_v27+28]");
					object obj57 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rax_v230+24]");
					float num7 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rax_v230+2C]");
					object obj58 = 0;
				}
				else
				{
					nint num16 = (nint)typeof(UIAnimator);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2917 @ rax_v226 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
					nint num17 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2918 @ rax_v227 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+20]");
					object obj58 = 0;
					float num7 = (float)UIAnimator.DEFAULT_START_SCALE;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
			object obj59 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v615 @ rax_v149+10]");
			object obj60 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v588 @ rax_v150+28]");
			object obj61 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ rdx_v73+14]");
			if ((nint)0 != 0)
			{
				((UIComponentBase<>)(object)uIComponentBase).ResetScale();
			}
			RectTransform rectTransform8 = uIComponentBase.RectTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
			object obj62 = 0;
			vector4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			Vector3 startValue5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			_ = 1f;
			_ = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ rcx_v136+10]");
			UIAnimator.Scale(rectTransform8, (UIAnimation)0, startValue5, vector4, flag, onStartCallback, onCompleteCallback);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
			object obj63 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v590 @ rax_v156+10]");
			object obj64 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+48]");
			num11 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ rax_v157+10]");
			object obj67;
			if ((nint)0 == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ rax_v157+30]");
				object obj65 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rcx_v192+18]");
				num11 = 0f;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ rax_v157+10]");
				if ((nint)0 == 2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ rax_v157+30]");
					object obj66 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
					obj67 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rcx_v191+24]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rcx_v191+18]");
						num11 = 0f;
					}
					goto IL_16c5;
				}
				num11 = 1f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>)+B0]");
			obj67 = 0;
			goto IL_16c5;
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

	private sealed class _003CShowViewNextFrame_003Ed__105(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public string viewCategory;

		public string viewName;

		public bool instantAction;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				ShowView(viewCategory, viewName, instantAction);
			}
			return false;
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

	public static Action<UIView, UIViewBehaviorType> OnUIViewAction;

	public static readonly List<UIView> VisibleViews;

	public bool AutoHideAfterShow;

	public float AutoHideAfterShowDelay;

	public bool AutoSelectButtonAfterShow;

	public UIViewStartBehavior BehaviorAtStart;

	public Vector3 CustomStartAnchoredPosition;

	public bool DeselectAnyButtonSelectedOnHide;

	public bool DeselectAnyButtonSelectedOnShow;

	public bool DisableCanvasWhenHidden;

	public bool DisableGameObjectWhenHidden;

	public bool DisableGraphicRaycasterWhenHidden;

	public UIViewBehavior HideBehavior;

	public Progressor HideProgressor;

	public UIViewBehavior LoopBehavior;

	public ProgressEvent OnInverseVisibilityChanged;

	public ProgressEvent OnVisibilityChanged;

	public GameObject SelectedButton;

	public UIViewBehavior ShowBehavior;

	public Progressor ShowProgressor;

	public TargetOrientation TargetOrientation;

	public bool UpdateHideProgressorOnShow;

	public bool UpdateShowProgressorOnHide;

	public bool UseCustomStartAnchoredPosition;

	public string ViewCategory;

	public string ViewName;

	private Canvas m_canvas;

	private GraphicRaycaster m_graphicRaycaster;

	private CanvasGroup m_canvasGroup;

	private float m_visibilityProgress;

	private VisibilityState m_visibility;

	private Coroutine m_showCoroutine;

	private Coroutine m_hideCoroutine;

	private Coroutine m_autoHideCoroutine;

	private Coroutine m_disableButtonClickCoroutine;

	private UIButton[] m_childUIButtons;

	private UIView[] m_childUIViews;

	private bool m_initialized;

	private LayoutController m_layoutController;

	private bool m_hasLayoutController;

	private bool m_controlledByLayoutGroup;

	public static string DefaultViewCategory
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980779]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "General";
		}
	}

	public static string DefaultViewName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998077A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "Unnamed";
		}
	}

	private static OrientationDetector OrientationDetector => OrientationDetector.Instance;

	public Canvas Canvas
	{
		get
		{
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Expected O, but got Unknown
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Expected O, but got Unknown
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Expected O, but got Unknown
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Expected O, but got Unknown
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Expected O, but got Unknown
			//IL_015b: Expected O, but got I4
			Canvas canvas = m_canvas;
			Canvas canvas2;
			if ((object)m_canvas == null || ((UnityEngine.Object)canvas).m_CachedPtr == (IntPtr)0)
			{
				canvas2 = GetComponent<Canvas>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				m_canvas = canvas2;
				if (flag)
				{
					goto IL_0129;
				}
				object obj = this + 216;
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = obj3 & 0x3F;
				object obj6 = obj4 * 8;
				object obj7 = 6603864928L + obj6;
				do
				{
					object obj8 = 1 << (int)obj5;
					object obj9 = obj7 | obj8;
					if (obj7 == obj7)
					{
						obj7 = obj9;
					}
				}
				while (obj7 != obj7);
			}
			canvas2 = m_canvas;
			goto IL_0129;
			IL_0129:
			return canvas2;
		}
	}

	public CanvasGroup CanvasGroup
	{
		get
		{
			CanvasGroup canvasGroup = m_canvasGroup;
			if ((object)m_canvasGroup == null || ((UnityEngine.Object)canvasGroup).m_CachedPtr == (IntPtr)0)
			{
				CanvasGroup canvasGroup2 = GetComponent<CanvasGroup>();
				if ((object)canvasGroup2 == null)
				{
					GameObject gameObject = base.gameObject;
					if ((object)gameObject == null)
					{
						return (CanvasGroup)(object)new NullReferenceException();
					}
					canvasGroup2 = gameObject.AddComponent<CanvasGroup>();
				}
				m_canvasGroup = canvasGroup2;
			}
			return m_canvasGroup;
		}
	}

	public unsafe Vector3 CurrentStartPosition
	{
		get
		{
			//IL_005d: Expected F4, but got I
			//IL_0058: Expected native int or pointer, but got O
			//IL_0072: Expected F4, but got I
			//IL_006d: Expected native int or pointer, but got O
			//IL_002e: Expected F4, but got O
			//IL_0029: Expected native int or pointer, but got O
			//IL_0043: Expected F4, but got I
			//IL_003e: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			if (UseCustomStartAnchoredPosition)
			{
				((Vector3*)(nint)vector)->x = (float)CustomStartAnchoredPosition;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Doozy.Engine.UI.UIView)+70]");
				((Vector3*)(nint)vector)->z = 0f;
				return vector;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Doozy.Engine.UI.UIView)+24]");
			((Vector3*)(nint)vector)->x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Doozy.Engine.UI.UIView)+2C]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
	}

	public GraphicRaycaster GraphicRaycaster
	{
		get
		{
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Expected O, but got Unknown
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Expected O, but got Unknown
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Expected O, but got Unknown
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Expected O, but got Unknown
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Expected O, but got Unknown
			//IL_015b: Expected O, but got I4
			GraphicRaycaster graphicRaycaster = m_graphicRaycaster;
			GraphicRaycaster graphicRaycaster2;
			if ((object)m_graphicRaycaster == null || ((UnityEngine.Object)graphicRaycaster).m_CachedPtr == (IntPtr)0)
			{
				graphicRaycaster2 = GetComponent<GraphicRaycaster>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				m_graphicRaycaster = graphicRaycaster2;
				if (flag)
				{
					goto IL_0129;
				}
				object obj = this + 224;
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = obj3 & 0x3F;
				object obj6 = obj4 * 8;
				object obj7 = 6603864928L + obj6;
				do
				{
					object obj8 = 1 << (int)obj5;
					object obj9 = obj7 | obj8;
					if (obj7 == obj7)
					{
						obj7 = obj9;
					}
				}
				while (obj7 != obj7);
			}
			graphicRaycaster2 = m_graphicRaycaster;
			goto IL_0129;
			IL_0129:
			return graphicRaycaster2;
		}
	}

	public float InverseVisibility => 1f - m_visibilityProgress;

	public bool IsHidden
	{
		get
		{
			//IL_0010: Expected O, but got I4
			object obj = m_visibility - 1;
			return obj == null;
		}
	}

	public bool IsHiding
	{
		get
		{
			//IL_0010: Expected O, but got I4
			object obj = m_visibility - 2;
			return obj == null;
		}
	}

	public bool IsShowing
	{
		get
		{
			//IL_0010: Expected O, but got I4
			object obj = m_visibility - 3;
			return obj == null;
		}
	}

	public bool IsVisible => m_visibility == VisibilityState.Visible;

	public VisibilityState Visibility
	{
		get
		{
			return m_visibility;
		}
		set
		{
			m_visibility = value;
			if (value == VisibilityState.Visible)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 15 Invalid \"Jump target not found in method: 0x182BC1BE0\"");
			}
			if (value == VisibilityState.NotVisible)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 30 Invalid \"Jump target not found in method: 0x182BC1BE0\"");
			}
		}
	}

	public float VisibilityProgress
	{
		get
		{
			return m_visibilityProgress;
		}
		set
		{
			//IL_02a2: Invalid comparison between I4 and F4
			//IL_0044: Expected F4, but got I4
			//IL_0059: Expected O, but got I4
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Expected O, but got Unknown
			float visibilityProgress;
			if (!(0f > value))
			{
				bool flag = !(value > 1f);
				visibilityProgress = value;
				if (!flag)
				{
					visibilityProgress = 1f;
				}
			}
			else
			{
				visibilityProgress = 0f;
			}
			m_visibilityProgress = visibilityProgress;
			bool flag2 = m_visibility == VisibilityState.Visible;
			if (flag2)
			{
				goto IL_00a3;
			}
			object obj = m_visibility - 1;
			if (!flag2)
			{
				object obj2 = obj - 1;
				if (!flag2)
				{
					if ((nint)obj2 == 1)
					{
						goto IL_00a3;
					}
					goto IL_017e;
				}
			}
			Progressor hideProgressor = HideProgressor;
			if ((object)HideProgressor != null && ((UnityEngine.Object)hideProgressor).m_CachedPtr != (IntPtr)0)
			{
				float progress = 1f - m_visibilityProgress;
				HideProgressor.SetProgress(progress);
			}
			Progressor progressor;
			float progress2;
			if (UpdateShowProgressorOnHide)
			{
				Progressor showProgressor = ShowProgressor;
				if ((object)ShowProgressor != null && ((UnityEngine.Object)showProgressor).m_CachedPtr != (IntPtr)0)
				{
					progressor = ShowProgressor;
					progress2 = m_visibilityProgress;
					goto IL_036f;
				}
			}
			goto IL_017e;
			IL_017e:
			OnVisibilityChanged.Invoke(m_visibilityProgress);
			float arg = 1f - m_visibilityProgress;
			OnInverseVisibilityChanged.Invoke(arg);
			return;
			IL_036f:
			progressor.SetProgress(progress2);
			goto IL_017e;
			IL_00a3:
			Progressor showProgressor2 = ShowProgressor;
			if ((object)ShowProgressor != null && ((UnityEngine.Object)showProgressor2).m_CachedPtr != (IntPtr)0)
			{
				ShowProgressor.SetProgress(m_visibilityProgress);
			}
			if (UpdateHideProgressorOnShow)
			{
				Progressor hideProgressor2 = HideProgressor;
				if ((object)HideProgressor != null && ((UnityEngine.Object)hideProgressor2).m_CachedPtr != (IntPtr)0)
				{
					progressor = HideProgressor;
					progress2 = 1f - m_visibilityProgress;
					goto IL_036f;
				}
			}
			goto IL_017e;
		}
	}

	private bool HasChildUIViews
	{
		get
		{
			//IL_0042: Expected O, but got I4
			//IL_0052: Expected O, but got I4
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Expected O, but got Unknown
			if (m_childUIViews == null)
			{
				return false;
			}
			UIView[] childUIViews = m_childUIViews;
			object obj = childUIViews.Length - 1;
			object obj2 = childUIViews.Length ^ 1;
			object obj3 = childUIViews.Length ^ obj;
			object obj4 = obj2 & obj3;
			bool flag = (nint)obj4 < 0;
			bool flag2 = (nint)obj < 0;
			bool flag3 = obj == null;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
	}

	private bool DebugComponent
	{
		get
		{
			//IL_0069: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIView)+20]");
			if ((nint)0 != 0)
			{
				return true;
			}
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugUIView;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	protected override void Reset()
	{
		UIViewSettings instance = UIViewSettings.Instance;
		instance.ResetComponent(this);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980779]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ViewCategory = "General";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998077A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ViewName = "Unnamed";
		SelectedButton = null;
		m_visibility = VisibilityState.Visible;
		VisibilityProgress = 1f;
	}

	public unsafe override void Awake()
	{
		//IL_001c: Expected O, but got Ref
		if (UseCustomStartAnchoredPosition)
		{
			RectTransform rectTransform = base.RectTransform;
			if (UseCustomStartAnchoredPosition)
			{
			}
			object obj = default(object);
			rectTransform.anchoredPosition3D = (Vector3)(&obj);
		}
		base.Awake();
		UIViewBehavior showBehavior = ShowBehavior;
		if (showBehavior.LoadSelectedPresetAtRuntime)
		{
			showBehavior.LoadPreset();
		}
		UIViewBehavior hideBehavior = HideBehavior;
		if (hideBehavior.LoadSelectedPresetAtRuntime)
		{
			hideBehavior.LoadPreset();
		}
		UIViewBehavior loopBehavior = LoopBehavior;
		if (loopBehavior.LoadSelectedPresetAtRuntime)
		{
			loopBehavior.LoadPreset();
		}
		m_initialized = false;
		Canvas canvas = Canvas;
		canvas.enabled = false;
		GraphicRaycaster graphicRaycaster = GraphicRaycaster;
		graphicRaycaster.enabled = false;
	}

	public override void Start()
	{
		CheckForLayoutController();
		Initialize();
	}

	private void CheckForLayoutController()
	{
		if (m_controlledByLayoutGroup)
		{
			LayoutController layoutController = m_layoutController;
			if ((object)m_layoutController != null)
			{
				bool flag = ((UnityEngine.Object)layoutController).m_CachedPtr == (IntPtr)0;
				bool hasLayoutController = !flag;
				m_hasLayoutController = hasLayoutController;
				if (((UnityEngine.Object)layoutController).m_CachedPtr != (IntPtr)0)
				{
					m_layoutController.Rebuild(forced: true);
				}
			}
			else
			{
				m_hasLayoutController = false;
			}
			goto IL_022e;
		}
		Transform transform = base.transform;
		Transform parent = transform.parent;
		bool flag3;
		if ((object)parent != null && ((UnityEngine.Object)parent).m_CachedPtr != (IntPtr)0)
		{
			LayoutGroup componentInParent = parent.GetComponentInParent<LayoutGroup>();
			if ((object)componentInParent != null)
			{
				bool flag2 = ((UnityEngine.Object)componentInParent).m_CachedPtr == (IntPtr)0;
				flag3 = !flag2;
				goto IL_0349;
			}
		}
		flag3 = false;
		goto IL_0349;
		IL_0349:
		m_controlledByLayoutGroup = flag3;
		if (flag3)
		{
			LayoutController componentInParent2 = GetComponentInParent<LayoutController>();
			m_layoutController = componentInParent2;
			LayoutController layoutController2 = m_layoutController;
			if ((object)m_layoutController != null)
			{
				bool flag4 = ((UnityEngine.Object)layoutController2).m_CachedPtr == (IntPtr)0;
				bool hasLayoutController2 = !flag4;
				m_hasLayoutController = hasLayoutController2;
				if (((UnityEngine.Object)layoutController2).m_CachedPtr != (IntPtr)0)
				{
					goto IL_022e;
				}
			}
			else
			{
				m_hasLayoutController = false;
			}
			Transform transform2 = base.transform;
			Transform parent2 = transform2.parent;
			GameObject gameObject = parent2.gameObject;
			LayoutController layoutController3 = gameObject.AddComponent<LayoutController>();
			m_layoutController = layoutController3;
		}
		else
		{
			m_hasLayoutController = false;
			m_layoutController = null;
		}
		goto IL_022e;
		IL_022e:
		if (UseCustomStartAnchoredPosition)
		{
			if (m_controlledByLayoutGroup)
			{
				UseCustomStartAnchoredPosition = false;
			}
			if (UseCustomStartAnchoredPosition)
			{
				_ = CustomStartAnchoredPosition;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIView)+70]");
				_ = 0;
				return;
			}
		}
		RectTransform rectTransform = base.RectTransform;
		Vector3 anchoredPosition3D = rectTransform.anchoredPosition3D;
		_ = anchoredPosition3D.x;
		_ = anchoredPosition3D.z;
	}

	public override void OnEnable()
	{
		//IL_00b9: Expected I4, but got O
		//IL_00d0: Expected I4, but got O
		UIButton[] componentsInChildren = GetComponentsInChildren<UIButton>();
		m_childUIButtons = componentsInChildren;
		UIView[] componentsInChildren2 = GetComponentsInChildren<UIView>();
		m_childUIViews = componentsInChildren2;
		DoozySettings instance = DoozySettings.Instance;
		if (instance.UseOrientationDetector)
		{
			OrientationDetector instance2 = OrientationDetector.Instance;
			if ((object)instance2 != null && ((UnityEngine.Object)instance2).m_CachedPtr != (IntPtr)0)
			{
				OrientationDetector instance3 = OrientationDetector.Instance;
				UnityAction<DetectedOrientation> unityAction = null;
				((UIView)(object)unityAction).OnOrientationChange((DetectedOrientation)this);
				((UIView)(object)instance3.OnOrientationEvent).OnOrientationChange((DetectedOrientation)unityAction);
			}
		}
	}

	public override void OnDisable()
	{
		//IL_010f: Expected I4, but got O
		//IL_0147: Expected O, but got I
		//IL_0147: Expected O, but got I
		StopHide();
		StopShow();
		RectTransform rectTransform = base.RectTransform;
		UIAnimator.StopAnimations(rectTransform, AnimationType.Hide);
		RectTransform rectTransform2 = base.RectTransform;
		UIAnimator.StopAnimations(rectTransform2, AnimationType.Show);
		RectTransform rectTransform3 = base.RectTransform;
		UIAnimator.StopAnimations(rectTransform3, AnimationType.Loop);
		base.ResetToStartValues();
		DoozySettings instance = DoozySettings.Instance;
		if (instance.UseOrientationDetector)
		{
			OrientationDetector instance2 = OrientationDetector.Instance;
			if ((object)instance2 != null && ((UnityEngine.Object)instance2).m_CachedPtr != (IntPtr)0)
			{
				OrientationDetector instance3 = OrientationDetector.Instance;
				OrientationEvent onOrientationEvent = instance3.OnOrientationEvent;
				UnityAction<DetectedOrientation> unityAction = null;
				((UIView)(object)unityAction).OnOrientationChange((DetectedOrientation)this);
				MethodInfo methodImpl = ((MulticastDelegate)unityAction).GetMethodImpl();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rsi_v4 (Doozy.Engine.Orientation.OrientationEvent)+10]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rax_v27 (UnityEngine.Events.UnityAction`1<Doozy.Engine.Orientation.DetectedOrientation>)+20]");
				((UnityEngine.Events.InvokableCallList)num).RemoveListener(0, methodImpl);
			}
		}
	}

	public void CancelAutoHide()
	{
		if (m_autoHideCoroutine != null)
		{
			StopCoroutine(m_autoHideCoroutine);
			m_autoHideCoroutine = null;
		}
	}

	public void Hide(bool instantAction = false)
	{
		UIViewBehavior hideBehavior = HideBehavior;
		bool flag = hideBehavior.InstantAnimation;
		bool flag2 = true;
		if (!flag)
		{
			flag2 = instantAction;
		}
		StopShow();
		UIViewBehavior hideBehavior2 = HideBehavior;
		if (!hideBehavior2.Animation.Enabled && !flag2)
		{
			string[] array = new string[5];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string message = string.Concat(array);
			DDebug.Log(message, this);
		}
		else
		{
			if (m_visibility == VisibilityState.Hiding)
			{
				return;
			}
			if (m_visibility == VisibilityState.Visible)
			{
				_003CHideEnumerator_003Ed__108 obj = null;
				obj._003C_003E1__state = 0;
				obj._003C_003E4__this = this;
				obj.instantAction = flag2;
				Coroutine hideCoroutine = StartCoroutine(obj);
				m_hideCoroutine = hideCoroutine;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ACD0");
				object obj2 = default(object);
				if (obj2 != null)
				{
					bool flag3 = ((List<object>)(object)VisibleViews).Remove((object)this);
				}
			}
		}
	}

	public void Hide(float delay)
	{
		_003CHideWithDelayEnumerator_003Ed__109 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.delay = delay;
		Coroutine autoHideCoroutine = StartCoroutine(obj);
		m_autoHideCoroutine = autoHideCoroutine;
	}

	public void InstantHide()
	{
		CheckForLayoutController();
		StopLoopAnimation();
		StopShow();
		StopHide();
		base.ResetToStartValues();
		Canvas canvas = Canvas;
		bool flag = !DisableCanvasWhenHidden;
		canvas.enabled = flag;
		GraphicRaycaster graphicRaycaster = GraphicRaycaster;
		bool flag2 = !DisableGraphicRaycasterWhenHidden;
		graphicRaycaster.enabled = flag2;
		GameObject gameObject = base.gameObject;
		bool active = !DisableGameObjectWhenHidden;
		gameObject.SetActive(active);
		HideDeselectButton();
		m_visibility = VisibilityState.NotVisible;
		VisibilityProgress = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ACD0");
		object obj = default(object);
		if (obj != null)
		{
			bool flag3 = ((List<object>)(object)VisibleViews).Remove((object)this);
		}
		if (m_initialized)
		{
			NotifySystemOfTriggeredBehavior(UIViewBehaviorType.Hide);
		}
		RemoveHiddenFromVisibleViews();
		if (!m_initialized)
		{
			m_initialized = true;
		}
	}

	public void InstantShow()
	{
		CheckForLayoutController();
		StopLoopAnimation();
		StopHide();
		StopShow();
		base.ResetToStartValues();
		Canvas canvas = Canvas;
		canvas.enabled = true;
		GraphicRaycaster graphicRaycaster = GraphicRaycaster;
		graphicRaycaster.enabled = true;
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		m_visibility = VisibilityState.Visible;
		VisibilityProgress = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ACD0");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AD40");
		}
		NotifySystemOfTriggeredBehavior(UIViewBehaviorType.Show);
		if (AutoHideAfterShow)
		{
			Hide(AutoHideAfterShowDelay);
		}
		ShowSelectDeselectButton();
		RemoveHiddenFromVisibleViews();
		if (m_childUIViews != null)
		{
			UIView[] childUIViews = m_childUIViews;
			if (childUIViews.Length > 1)
			{
				IEnumerator routine = ShowViewNextFrame(ViewCategory, ViewName, instantAction: true);
				Coroutine coroutine = StartCoroutine(routine);
			}
		}
	}

	public void NotifySystemOfTriggeredBehavior(UIViewBehaviorType behaviorType)
	{
		if (OnUIViewAction != null)
		{
			Action<UIView, UIViewBehaviorType> onUIViewAction = OnUIViewAction;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v80 @ r10_v2 (System.Action`2<Doozy.Engine.UI.UIView, Doozy.Engine.UI.UIViewBehaviorType>)+18] (should have been resolved before IL gen)");
		}
		UIViewMessage uIViewMessage = null;
		uIViewMessage.View = this;
		uIViewMessage.Type = behaviorType;
		Message.Send(uIViewMessage);
	}

	public override void ResetAlpha()
	{
		//IL_0024: Expected F4, but got I
		CanvasGroup canvasGroup = CanvasGroup;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIView)+48]");
		canvasGroup.alpha = 0f;
	}

	public unsafe override void ResetPosition()
	{
		//IL_0017: Expected O, but got Ref
		RectTransform rectTransform = base.RectTransform;
		if (UseCustomStartAnchoredPosition)
		{
		}
		object obj = default(object);
		rectTransform.anchoredPosition3D = (Vector3)(&obj);
	}

	public void SetVisibility(bool visible)
	{
		if (!visible)
		{
			Hide();
		}
		else
		{
			Show();
		}
	}

	public void SetVisibility(bool visible, bool instantAction)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 13 Invalid \"Jump target not found in method: 0x182BC2F80\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 14 Invalid \"Jump target not found in method: 0x182BC3AE0\"");
	}

	public void Show(bool instantAction = false)
	{
		UIViewBehavior showBehavior = ShowBehavior;
		bool flag = showBehavior.InstantAnimation;
		bool flag2 = true;
		if (!flag)
		{
			flag2 = instantAction;
		}
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		StopHide();
		UIViewBehavior showBehavior2 = ShowBehavior;
		if (!showBehavior2.Animation.Enabled && !flag2)
		{
			string[] array = new string[5];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string message = string.Concat(array);
			DDebug.Log(message, this);
		}
		else
		{
			if (m_visibility == VisibilityState.Showing)
			{
				return;
			}
			if (m_visibility != VisibilityState.Visible)
			{
				_003CShowEnumerator_003Ed__107 obj = null;
				obj._003C_003E1__state = 0;
				obj._003C_003E4__this = this;
				obj.instantAction = flag2;
				Coroutine showCoroutine = StartCoroutine(obj);
				m_showCoroutine = showCoroutine;
				if (m_childUIViews != null)
				{
					UIView[] childUIViews = m_childUIViews;
					if (childUIViews.Length > 1)
					{
						IEnumerator routine = ShowViewNextFrame(ViewCategory, ViewName, flag2);
						Coroutine coroutine = StartCoroutine(routine);
					}
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ACD0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AD40");
				}
			}
		}
	}

	public unsafe void StartLoopAnimation()
	{
		//IL_008f: Expected O, but got Ref
		//IL_00c8: Expected O, but got Ref
		UIViewBehavior loopBehavior = LoopBehavior;
		if (loopBehavior.Animation.Enabled)
		{
			RectTransform rectTransform = base.RectTransform;
			UIViewBehavior loopBehavior2 = LoopBehavior;
			if (UseCustomStartAnchoredPosition)
			{
			}
			Vector3 vector = default(Vector3);
			UnityAction onCompleteCallback = default(UnityAction);
			UIAnimator.MoveLoop(rectTransform, loopBehavior2.Animation, (Vector3)(&vector), null, onCompleteCallback);
			RectTransform rectTransform2 = base.RectTransform;
			UIViewBehavior loopBehavior3 = LoopBehavior;
			UIAnimator.RotateLoop(rectTransform2, loopBehavior3.Animation, (Vector3)(&vector), null, onCompleteCallback);
			RectTransform rectTransform3 = base.RectTransform;
			UIViewBehavior loopBehavior4 = LoopBehavior;
			UIAnimator.ScaleLoop(rectTransform3, loopBehavior4.Animation);
			RectTransform rectTransform4 = base.RectTransform;
			UIViewBehavior loopBehavior5 = LoopBehavior;
			UIAnimator.FadeLoop(rectTransform4, loopBehavior5.Animation);
			NotifySystemOfTriggeredBehavior(UIViewBehaviorType.Loop);
		}
	}

	public void StopLoopAnimation()
	{
		RectTransform rectTransform = base.RectTransform;
		UIAnimator.StopAnimations(rectTransform, AnimationType.Loop);
	}

	public void Toggle(bool instantAction = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 13 Invalid \"Jump target not found in method: 0x182BC3AE0\"");
		Hide(instantAction);
	}

	private void HideDeselectButton()
	{
		if (DeselectAnyButtonSelectedOnHide)
		{
			EventSystem unityEventSystem = UIComponentBase<UIView>.UnityEventSystem;
			unityEventSystem.SetSelectedGameObject(null);
		}
	}

	private void Initialize()
	{
		//IL_0037: Expected O, but got I4
		//IL_0040: Expected O, but got I4
		//IL_00ba: Expected O, but got I4
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		UIButton[] componentsInChildren = GetComponentsInChildren<UIButton>();
		m_childUIButtons = componentsInChildren;
		if (m_childUIButtons != null)
		{
			UIButton[] childUIButtons = m_childUIButtons;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < childUIButtons.Length)
			{
				childUIButtons[obj].UpdateStartValues();
				obj++;
				obj2 = obj;
			}
		}
		UIView[] componentsInChildren2 = GetComponentsInChildren<UIView>();
		m_childUIViews = componentsInChildren2;
		bool flag = BehaviorAtStart == UIViewStartBehavior.DoNothing;
		if (!flag)
		{
			object obj3 = BehaviorAtStart - 1;
			if (!flag)
			{
				if ((nint)obj3 != 1)
				{
					return;
				}
				InstantHide();
				DoozySettings instance = DoozySettings.Instance;
				IEnumerator routine;
				if (!instance.UseOrientationDetector)
				{
					Show();
					if (m_childUIViews == null)
					{
						return;
					}
					UIView[] childUIViews = m_childUIViews;
					if (childUIViews.Length <= 1)
					{
						return;
					}
					IEnumerator enumerator = ShowViewNextFrame(ViewCategory, ViewName);
					routine = enumerator;
				}
				else
				{
					OrientationDetector instance2 = OrientationDetector.Instance;
					if (instance2.m_currentOrientation != DetectedOrientation.Unknown)
					{
						OrientationDetector instance3 = OrientationDetector.Instance;
						OnOrientationChange(instance3.m_currentOrientation);
						return;
					}
					_003CExecuteGetOrientationEnumerator_003Ed__110 obj4 = null;
					obj4._003C_003E1__state = 0;
					obj4._003C_003E4__this = this;
					routine = obj4;
				}
				Coroutine coroutine = StartCoroutine(routine);
			}
			else
			{
				InstantHide();
			}
		}
		else
		{
			ShowSelectDeselectButton();
			UIViewBehavior loopBehavior = LoopBehavior;
			if (loopBehavior.AutoStartLoopAnimation)
			{
				StartLoopAnimation();
			}
			Canvas canvas = Canvas;
			canvas.enabled = true;
			GraphicRaycaster graphicRaycaster = GraphicRaycaster;
			graphicRaycaster.enabled = true;
			m_initialized = true;
		}
	}

	private unsafe void MoveToCustomStartPosition()
	{
		//IL_0017: Expected O, but got Ref
		RectTransform rectTransform = base.RectTransform;
		if (UseCustomStartAnchoredPosition)
		{
		}
		object obj = default(object);
		rectTransform.anchoredPosition3D = (Vector3)(&obj);
	}

	private void LoadPresets()
	{
		UIViewBehavior showBehavior = ShowBehavior;
		if (showBehavior.LoadSelectedPresetAtRuntime)
		{
			showBehavior.LoadPreset();
		}
		UIViewBehavior hideBehavior = HideBehavior;
		if (hideBehavior.LoadSelectedPresetAtRuntime)
		{
			hideBehavior.LoadPreset();
		}
		UIViewBehavior loopBehavior = LoopBehavior;
		if (loopBehavior.LoadSelectedPresetAtRuntime)
		{
			loopBehavior.LoadPreset();
		}
	}

	private void OnOrientationChange(DetectedOrientation newDeviceOrientation)
	{
		if (newDeviceOrientation == DetectedOrientation.Landscape)
		{
			if (TargetOrientation != TargetOrientation.Portrait)
			{
				goto IL_0024;
			}
		}
		else if (newDeviceOrientation != DetectedOrientation.Portrait || TargetOrientation != (TargetOrientation)newDeviceOrientation)
		{
			goto IL_0024;
		}
		HideView(ViewCategory, ViewName, instantAction: true);
		ShowView(ViewCategory, ViewName);
		return;
		IL_0024:
		if (TargetOrientation != TargetOrientation.Any)
		{
			Hide(instantAction: true);
		}
		else
		{
			ShowView(ViewCategory, ViewName);
		}
	}

	private void ShowSelectDeselectButton()
	{
		if (AutoSelectButtonAfterShow)
		{
			GameObject selectedButton = SelectedButton;
			if ((object)SelectedButton != null && ((UnityEngine.Object)selectedButton).m_CachedPtr != (IntPtr)0)
			{
				EventSystem unityEventSystem = UIComponentBase<UIView>.UnityEventSystem;
				unityEventSystem.SetSelectedGameObject(SelectedButton);
				return;
			}
		}
		if (DeselectAnyButtonSelectedOnShow)
		{
			EventSystem unityEventSystem2 = UIComponentBase<UIView>.UnityEventSystem;
			unityEventSystem2.SetSelectedGameObject(null);
		}
	}

	private void StopHide()
	{
		if (m_hideCoroutine != null)
		{
			StopCoroutine(m_hideCoroutine);
			m_hideCoroutine = null;
			m_visibility = VisibilityState.NotVisible;
			VisibilityProgress = 0f;
			RectTransform rectTransform = base.RectTransform;
			UIAnimator.StopAnimations(rectTransform, AnimationType.Hide);
			DoozySettings instance = DoozySettings.Instance;
			if (instance.AutoDisableUIInteractions)
			{
				UIComponentBase<UIView>.EnableUIInteractions();
			}
		}
	}

	private void StopShow()
	{
		if (m_showCoroutine != null)
		{
			StopCoroutine(m_showCoroutine);
			m_showCoroutine = null;
			m_visibility = VisibilityState.Visible;
			VisibilityProgress = 1f;
			RectTransform rectTransform = base.RectTransform;
			UIAnimator.StopAnimations(rectTransform, AnimationType.Show);
			DoozySettings instance = DoozySettings.Instance;
			if (instance.AutoDisableUIInteractions)
			{
				UIComponentBase<UIView>.EnableUIInteractions();
			}
		}
	}

	private void RemoveNullChildUIButtons()
	{
		if (m_childUIButtons == null)
		{
			return;
		}
		UIButton[] childUIButtons = m_childUIButtons;
		if (childUIButtons.Length == 0)
		{
			return;
		}
		Func<UIButton, bool> predicate = _003C_003Ec._003C_003E9__103_0;
		if (_003C_003Ec._003C_003E9__103_0 == null)
		{
			predicate = (_003C_003Ec._003C_003E9__103_0 = delegate(UIButton uiButton)
			{
				if ((object)uiButton != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [uiButton @ rdx (Doozy.Engine.UI.UIButton)+10]");
					return (nint)0 == 0;
				}
				return true;
			});
		}
		if (!Enumerable.Any(childUIButtons, predicate))
		{
			return;
		}
		Func<UIButton, bool> predicate2 = _003C_003Ec._003C_003E9__103_1;
		if (_003C_003Ec._003C_003E9__103_1 == null)
		{
			predicate2 = (_003C_003Ec._003C_003E9__103_1 = delegate(UIButton t)
			{
				if ((object)t != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ rdx (Doozy.Engine.UI.UIButton)+10]");
					bool flag = (nint)0 == 0;
					return !flag;
				}
				return false;
			});
		}
		IEnumerable<UIButton> enumerable = Enumerable.Where(m_childUIButtons, predicate2);
		if (enumerable != null)
		{
			System.Linq.Buffer<object> buffer = new System.Linq.Buffer<object>((IEnumerable<object>)enumerable);
			System.Linq.Buffer<UIButton> buffer2 = default(System.Linq.Buffer<UIButton>);
			UIButton[] childUIButtons2 = buffer2.ToArray();
			m_childUIButtons = childUIButtons2;
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private void UpdateChildUIButtonsStartValues()
	{
		//IL_0032: Expected O, but got I4
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		if (m_childUIButtons != null)
		{
			UIButton[] childUIButtons = m_childUIButtons;
			object obj = 0;
			while ((nint)obj < childUIButtons.Length)
			{
				childUIButtons[obj].UpdateStartValues();
				obj++;
			}
		}
	}

	public static IEnumerator ShowViewNextFrame(string viewCategory, string viewName, bool instantAction = false)
	{
		_003CShowViewNextFrame_003Ed__105 obj = null;
		obj._003C_003E1__state = 0;
		obj.viewCategory = viewCategory;
		obj.viewName = viewName;
		obj.instantAction = instantAction;
		return obj;
	}

	public static IEnumerator HideViewNextFrame(string viewCategory, string viewName, bool instantAction = false)
	{
		_003CHideViewNextFrame_003Ed__106 obj = null;
		obj._003C_003E1__state = 0;
		obj.viewCategory = viewCategory;
		obj.viewName = viewName;
		obj.instantAction = instantAction;
		return obj;
	}

	private IEnumerator ShowEnumerator(bool instantAction)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0110: Expected O, but got I4
		_003CShowEnumerator_003Ed__107 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 32;
			object obj3 = obj2 >> 12;
			object obj4 = obj3 & 0x1FFFFF;
			object obj5 = obj4 >> 6;
			object obj6 = obj4 & 0x3F;
			object obj7 = obj5 * 8;
			object obj8 = 6603864928L + obj7;
			do
			{
				object obj9 = 1 << (int)obj6;
				object obj10 = obj8 | obj9;
				if (obj8 == obj8)
				{
					obj8 = obj10;
				}
			}
			while (obj8 != obj8);
			obj.instantAction = instantAction;
			return obj;
		}
		obj.instantAction = instantAction;
		return obj;
	}

	private IEnumerator HideEnumerator(bool instantAction)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0110: Expected O, but got I4
		_003CHideEnumerator_003Ed__108 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 32;
			object obj3 = obj2 >> 12;
			object obj4 = obj3 & 0x1FFFFF;
			object obj5 = obj4 >> 6;
			object obj6 = obj4 & 0x3F;
			object obj7 = obj5 * 8;
			object obj8 = 6603864928L + obj7;
			do
			{
				object obj9 = 1 << (int)obj6;
				object obj10 = obj8 | obj9;
				if (obj8 == obj8)
				{
					obj8 = obj10;
				}
			}
			while (obj8 != obj8);
			obj.instantAction = instantAction;
			return obj;
		}
		obj.instantAction = instantAction;
		return obj;
	}

	private IEnumerator HideWithDelayEnumerator(float delay)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002e: Expected O, but got I8
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_010a: Expected O, but got I4
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		_003CHideWithDelayEnumerator_003Ed__109 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 40;
			object obj3 = obj2 >> 12;
			object obj4 = 6603864928L;
			object obj5 = obj3 & 0x1FFFFF;
			object obj6 = obj5 >> 6;
			object obj7 = obj5 & 0x3F;
			nint num2;
			do
			{
				object obj8 = 1 << (int)obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				object obj9 = 0 | obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				if (num == 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
				num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r10_v1+v51 @ r8_v2*8]");
			}
			while (num2 != 0);
			obj.delay = delay;
			return obj;
		}
		obj.delay = delay;
		return obj;
	}

	private IEnumerator ExecuteGetOrientationEnumerator()
	{
		_003CExecuteGetOrientationEnumerator_003Ed__110 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public unsafe static List<UIView> GetViews(string viewCategory, string viewName)
	{
		//IL_031f: Expected I, but got O
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		List<UIView> result = new List<UIView>();
		nint num = (nint)typeof(UIComponentBase<UIView>);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v4 (Il2CppClass<Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIView>>)+E4]");
		bool flag = (nint)0 != 0;
		List<UIView> database = UIComponentBase<UIView>.Database;
		List<UIView>.Enumerator enumerator = default(List<UIView>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<UIView>.Enumerator enumerator2 = (List<UIView>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return result;
	}

	public static void HideView(string viewName, bool instantAction = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980779]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 60 Invalid \"Jump target not found in method: 0x182BC57D0\"");
	}

	public static void HideView(string viewCategory, string viewName, bool instantAction = false)
	{
		ExecuteHide(viewCategory, viewName, instantAction);
	}

	public static void HideViewCategory(string viewCategory, bool instantAction = false)
	{
		ExecuteHideCategory(viewCategory, instantAction);
	}

	public unsafe static bool IsViewVisible(string viewCategory, string viewName)
	{
		//IL_02fa: Expected I, but got O
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		nint num = (nint)typeof(UIView);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (Il2CppClass<Doozy.Engine.UI.UIView>)+E4]");
		bool flag = (nint)0 != 0;
		List<UIView> visibleViews = VisibleViews;
		List<UIView>.Enumerator enumerator = default(List<UIView>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<UIView>.Enumerator enumerator2 = (List<UIView>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return false;
	}

	public static void ShowView(string viewName, bool instantAction = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980779]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 60 Invalid \"Jump target not found in method: 0x182BC5B70\"");
	}

	public static void ShowView(string viewCategory, string viewName, bool instantAction = false)
	{
		ExecuteShow(viewCategory, viewName, instantAction);
	}

	public static void ShowViewCategory(string viewCategory, bool instantAction = false)
	{
		ExecuteShowCategory(viewCategory, instantAction);
	}

	private static void ExecuteHide(string viewCategory, string viewName, bool instantAction = false)
	{
		//IL_0013: Expected O, but got I4
		//IL_0437: Expected O, but got I4
		List<UIView> database = UIComponentBase<UIView>.Database;
		object obj = 0;
		List<UIView>.Enumerator enumerator = default(List<UIView>.Enumerator);
		while (enumerator.MoveNext())
		{
			Component component = null;
			obj = 1;
		}
		if (obj != null)
		{
			UIComponentBase<UIView>.RemoveAnyNullReferencesFromTheDatabase();
		}
	}

	private static void ExecuteHideCategory(string viewCategory, bool instantAction = false)
	{
		//IL_0013: Expected O, but got I4
		//IL_02fe: Expected O, but got I4
		List<UIView> database = UIComponentBase<UIView>.Database;
		object obj = 0;
		List<UIView>.Enumerator enumerator = default(List<UIView>.Enumerator);
		while (enumerator.MoveNext())
		{
			Component component = null;
			obj = 1;
		}
		if (obj != null)
		{
			UIComponentBase<UIView>.RemoveAnyNullReferencesFromTheDatabase();
		}
	}

	private static void ExecuteShow(string viewCategory, string viewName, bool instantAction)
	{
		//IL_001c: Expected O, but got I4
		//IL_0025: Expected F4, but got I4
		//IL_0b7c: Expected O, but got I4
		List<UIView> database = UIComponentBase<UIView>.Database;
		List<UIView>.Enumerator database2 = (List<UIView>.Enumerator)UIComponentBase<UIView>.Database;
		object obj = 0;
		float num = 0f;
		List<UIView>.Enumerator enumerator = default(List<UIView>.Enumerator);
		while (enumerator.MoveNext())
		{
			Component component = null;
			obj = 1;
		}
		if (obj != null)
		{
			UIComponentBase<UIView>.RemoveAnyNullReferencesFromTheDatabase();
		}
	}

	private static void ExecuteShowCategory(string viewCategory, bool instantAction = false)
	{
		//IL_001c: Expected O, but got I4
		//IL_0025: Expected F4, but got I4
		//IL_0a43: Expected O, but got I4
		List<UIView> database = UIComponentBase<UIView>.Database;
		List<UIView>.Enumerator database2 = (List<UIView>.Enumerator)UIComponentBase<UIView>.Database;
		object obj = 0;
		float num = 0f;
		List<UIView>.Enumerator enumerator = default(List<UIView>.Enumerator);
		while (enumerator.MoveNext())
		{
			Component component = null;
			obj = 1;
		}
		if (obj != null)
		{
			UIComponentBase<UIView>.RemoveAnyNullReferencesFromTheDatabase();
		}
	}

	private static void RemoveHiddenFromVisibleViews()
	{
		//IL_00a9: Expected O, but got I4
		//IL_0129: Expected O, but got I4
		RemoveNullsFromVisibleViews();
		List<UIView> visibleViews = VisibleViews;
		bool flag = (nint)VisibleViews < 0;
		int num = visibleViews._size - 1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			List<UIView> visibleViews2 = VisibleViews;
			if (num >= visibleViews2._size)
			{
				break;
			}
			UIView[] items = visibleViews2._items;
			UIView uIView = items[num];
			object obj = uIView.m_visibility - 1;
			bool flag2 = (nint)obj < 0;
			if (uIView.m_visibility == VisibilityState.NotVisible)
			{
				flag2 = (nint)VisibleViews < 0;
				VisibleViews.RemoveAt(num);
			}
			num--;
			object obj2 = !flag2;
			if (obj2 == null)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private static void RemoveNullsFromVisibleViews()
	{
		//IL_0133: Expected O, but got I4
		List<UIView> visibleViews = VisibleViews;
		bool flag = (nint)VisibleViews < 0;
		int num = visibleViews._size - 1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			List<UIView> visibleViews2 = VisibleViews;
			if (num >= visibleViews2._size)
			{
				break;
			}
			UIView[] items = visibleViews2._items;
			UIView uIView = items[num];
			bool flag2;
			if ((object)items[num] != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdi_v5 (Doozy.Engine.UI.UIView)+10]");
				flag2 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdi_v5 (Doozy.Engine.UI.UIView)+10]");
				if ((nint)0 != 0)
				{
					goto IL_011a;
				}
			}
			flag2 = (nint)VisibleViews < 0;
			VisibleViews.RemoveAt(num);
			goto IL_011a;
			IL_011a:
			num--;
			object obj = !flag2;
			if (obj == null)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public UIView()
	{
		UIViewBehavior hideBehavior = new UIViewBehavior(AnimationType.Hide);
		HideBehavior = hideBehavior;
		LoopBehavior = new UIViewBehavior(AnimationType.Loop);
		ProgressEvent onInverseVisibilityChanged = new ProgressEvent();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
		OnInverseVisibilityChanged = onInverseVisibilityChanged;
		ProgressEvent onVisibilityChanged = new ProgressEvent();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
		OnVisibilityChanged = onVisibilityChanged;
		ShowBehavior = new UIViewBehavior(AnimationType.Show);
		m_visibilityProgress = 1f;
		base._002Ector();
	}

	static UIView()
	{
		Action<UIView, UIViewBehaviorType> onUIViewAction = delegate
		{
		};
		OnUIViewAction = onUIViewAction;
		List<UIView> visibleViews = new List<UIView>();
		VisibleViews = visibleViews;
	}
}
