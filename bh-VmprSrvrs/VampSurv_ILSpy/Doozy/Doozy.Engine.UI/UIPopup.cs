using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Doozy.Engine.Extensions;
using Doozy.Engine.Progress;
using Doozy.Engine.Settings;
using Doozy.Engine.Soundy;
using Doozy.Engine.Touchy;
using Doozy.Engine.UI.Animation;
using Doozy.Engine.UI.Base;
using Doozy.Engine.UI.Settings;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Doozy.Engine.UI;

public class UIPopup : UIComponentBase<UIPopup>
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003C_002Ecctor_003Eb__124_0(UIPopup _003Cp0_003E, AnimationType _003Cp1_003E)
		{
		}
	}

	private sealed class _003CExecuteHideDeselectButtonEnumerator_003Ed__116(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UIPopup _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_00a4: Expected I4, but got I8
			//IL_015c: Expected I4, but got O
			UIPopup uIPopup = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					goto IL_014e;
				}
				if ((uIPopup.AutoSelectPreviouslySelectedButtonAfterHide ? 1 : 0) != _003C_003E1__state)
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
			}
			else if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					goto IL_014e;
				}
				GameObject previousSelectedButton = uIPopup.m_previousSelectedButton;
				if ((object)uIPopup.m_previousSelectedButton != null && ((UnityEngine.Object)previousSelectedButton).m_CachedPtr != (IntPtr)0)
				{
					EventSystem unityEventSystem = UIComponentBase<UIPopup>.UnityEventSystem;
					if ((object)unityEventSystem == null)
					{
						goto IL_014e;
					}
					unityEventSystem.SetSelectedGameObject(uIPopup.m_previousSelectedButton);
				}
			}
			return false;
			IL_014e:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
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

	private sealed class _003CExecuteShowSelectDeselectButtonEnumerator_003Ed__115(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UIPopup _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_017e: Expected I4, but got O
			UIPopup uIPopup = _003C_003E4__this;
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
				EventSystem unityEventSystem = UIComponentBase<UIPopup>.UnityEventSystem;
				if ((object)unityEventSystem == null || (object)_003C_003E4__this == null)
				{
					goto IL_0170;
				}
				uIPopup.m_previousSelectedButton = unityEventSystem.m_CurrentSelected;
				if (uIPopup.AutoSelectButtonAfterShow)
				{
					GameObject selectedButton = uIPopup.SelectedButton;
					if ((object)uIPopup.SelectedButton != null && ((UnityEngine.Object)selectedButton).m_CachedPtr != (IntPtr)0)
					{
						EventSystem unityEventSystem2 = UIComponentBase<UIPopup>.UnityEventSystem;
						if ((object)unityEventSystem2 == null)
						{
							goto IL_0170;
						}
						unityEventSystem2.SetSelectedGameObject(uIPopup.SelectedButton);
					}
				}
			}
			return false;
			IL_0170:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
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

	private sealed class _003CHideEnumerator_003Ed__113(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UIPopup _003C_003E4__this;

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
			//IL_0109: Expected I4, but got I8
			//IL_1e84: Expected I4, but got O
			//IL_001d: Expected O, but got I4
			//IL_00ec: Expected I4, but got I8
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
			//IL_00cf: Expected I4, but got I8
			//IL_0185: Expected O, but got I
			//IL_0076: Expected I4, but got I8
			//IL_1e21: Expected O, but got I4
			//IL_01f1: Expected O, but got I
			//IL_15f7: Expected O, but got I
			//IL_0226: Expected O, but got I
			//IL_1bc0: Expected O, but got I
			//IL_1832: Expected I, but got O
			//IL_162c: Expected O, but got I
			//IL_1874: Expected O, but got I
			//IL_025b: Expected O, but got I
			//IL_1bf5: Expected O, but got I
			//IL_18bb: Expected O, but got I
			//IL_1715: Expected O, but got I
			//IL_1c3a: Expected O, but got I
			//IL_1693: Expected O, but got I
			//IL_02a7: Expected O, but got I
			//IL_02b7: Expected O, but got I
			//IL_1c88: Expected O, but got I
			//IL_1ca1: Expected O, but got I
			//IL_16e1: Expected O, but got I
			//IL_16fa: Expected O, but got I
			//IL_1cb7: Expected O, but got I
			//IL_1cd4: Expected O, but got I4
			//IL_02ec: Expected O, but got I
			//IL_031f: Expected O, but got Ref
			//IL_035a: Expected O, but got I
			//IL_035a: Expected O, but got I
			//IL_036e: Expected O, but got I
			//IL_03a3: Expected O, but got I
			//IL_1d07: Expected O, but got I4
			//IL_03d6: Expected O, but got Ref
			//IL_0411: Expected O, but got I
			//IL_0411: Expected O, but got I
			//IL_0425: Expected O, but got I
			//IL_045a: Expected O, but got I
			//IL_1d4e: Expected O, but got I4
			//IL_19cb: Expected O, but got I4
			//IL_048f: Expected O, but got I
			//IL_1ef0: Expected O, but got I
			//IL_04e9: Expected O, but got I
			//IL_0535: Expected O, but got I
			//IL_0577: Expected O, but got Ref
			//IL_058f: Expected O, but got Ref
			//IL_05d4: Expected O, but got I
			//IL_05d4: Expected O, but got I
			//IL_05e4: Expected O, but got I
			//IL_0619: Expected O, but got I
			//IL_0629: Expected O, but got I
			//IL_065e: Expected O, but got I
			//IL_069b: Expected O, but got I
			//IL_07b4: Expected I, but got O
			//IL_07dd: Expected O, but got I
			//IL_071d: Expected O, but got I
			//IL_1f4a: Expected O, but got I
			//IL_06d0: Expected O, but got I
			//IL_06e0: Expected O, but got I
			//IL_07f2: Expected O, but got I
			//IL_0802: Expected O, but got I
			//IL_079c: Expected O, but got I
			//IL_0777: Expected O, but got I
			//IL_0787: Expected O, but got I
			//IL_0837: Expected O, but got I
			//IL_0847: Expected O, but got I
			//IL_0884: Expected O, but got I
			//IL_0988: Expected I, but got O
			//IL_09b1: Expected O, but got I
			//IL_092b: Expected O, but got I
			//IL_1fa4: Expected O, but got I
			//IL_0960: Expected O, but got I
			//IL_0970: Expected O, but got I
			//IL_09c6: Expected O, but got I
			//IL_08de: Expected O, but got I
			//IL_08ee: Expected O, but got I
			//IL_09fb: Expected O, but got I
			//IL_1fd9: Expected O, but got I
			//IL_0a55: Expected O, but got I
			//IL_0aa1: Expected O, but got I
			//IL_0ade: Expected O, but got Ref
			//IL_0af1: Expected O, but got Ref
			//IL_0b2c: Expected O, but got I
			//IL_0b2c: Expected O, but got I
			//IL_0b3c: Expected O, but got I
			//IL_0b71: Expected O, but got I
			//IL_0ba6: Expected O, but got I
			//IL_0bb4: Expected O, but got Ref
			//IL_0be3: Expected O, but got I
			//IL_0bf7: Expected O, but got I
			//IL_0c2c: Expected O, but got I
			//IL_0c3c: Expected O, but got I
			//IL_0c9e: Expected O, but got I
			//IL_0dcb: Expected I, but got O
			//IL_0df4: Expected O, but got I
			//IL_0d6e: Expected O, but got I
			//IL_2033: Expected O, but got I
			//IL_0da3: Expected O, but got I
			//IL_0db3: Expected O, but got I
			//IL_0cf8: Expected O, but got I
			//IL_0e09: Expected O, but got I
			//IL_0e3e: Expected O, but got I
			//IL_207f: Expected O, but got I
			//IL_0e98: Expected O, but got I
			//IL_0ee4: Expected O, but got I
			//IL_0f1c: Expected O, but got Ref
			//IL_0f2a: Expected O, but got Ref
			//IL_0f7a: Expected O, but got I
			//IL_0f7a: Expected O, but got I
			//IL_0f8a: Expected O, but got I
			//IL_0fbf: Expected O, but got I
			//IL_0fcf: Expected O, but got I
			//IL_1004: Expected F4, but got I
			//IL_1061: Expected O, but got I
			//IL_20b4: Expected O, but got I
			//IL_10d3: Expected O, but got I
			//IL_20c9: Expected O, but got I
			//IL_20d9: Expected O, but got I
			//IL_20e9: Expected F4, but got I
			//IL_1096: Expected F4, but got I
			//IL_1108: Expected O, but got I
			//IL_113d: Expected F4, but got I
			//IL_1188: Expected O, but got I
			//IL_211e: Expected O, but got I
			//IL_212e: Expected O, but got I
			//IL_121f: Expected O, but got I
			//IL_1277: Expected O, but got I
			//IL_1254: Expected F4, but got I
			//IL_11e2: Expected F4, but got I
			//IL_2163: Expected O, but got I
			//IL_12d1: Expected O, but got I
			//IL_12f8: Expected O, but got I
			//IL_1353: Expected O, but got I
			//IL_1353: Expected O, but got I
			//IL_19f6: Expected O, but got I
			//IL_13d5: Expected O, but got I
			//IL_1a51: Expected O, but got I
			//IL_140a: Expected O, but got I
			//IL_1a98: Expected O, but got I
			//IL_144f: Expected O, but got I
			//IL_1af3: Expected O, but got I
			object obj2 = default(object);
			object obj = (object)(&obj2);
			UIComponentBase<UIPopup> uIComponentBase = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			int num;
			int num2;
			bool flag2 = default(bool);
			UnityAction onStartCallback = default(UnityAction);
			UnityAction onCompleteCallback = default(UnityAction);
			float num15;
			if (!flag)
			{
				object obj3 = _003C_003E1__state - 1;
				if (flag)
				{
					_003C_003E1__state = -1;
					num = 0;
					goto IL_1ec0;
				}
				object obj4 = obj3 - 1;
				if (flag)
				{
					_003C_003E1__state = -1;
					num2 = 0;
					goto IL_15a3;
				}
				if ((nint)obj4 != 1)
				{
					goto IL_1ead;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					GameObject gameObject = _003C_003E4__this.gameObject;
					UnityEngine.Object.Destroy(gameObject);
					return false;
				}
			}
			else
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					RectTransform rectTransform = _003C_003E4__this.RectTransform;
					RectTransformExtensions.FullScreen(rectTransform, resetScaleToOne: true);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+C0]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+C0]");
						((UIContainer)0).FullScreen(resetScaleToOne: true);
						DoozySettings instance = DoozySettings.Instance;
						if ((object)instance != null)
						{
							if (instance.AutoDisableUIInteractions)
							{
								UIComponentBase<UIPopup>.DisableUIInteractions();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
								object obj6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rax_v99+10]");
									object obj7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rax_v99+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rax_v98+30]");
										nint num3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rdx_v50+10]");
										UIAnimator.StopAnimations((RectTransform)num3, AnimationType.Undefined);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
										object obj8 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
											object obj9 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
											if ((nint)0 != 0)
											{
												Vector3 startValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rax_v102+3C]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rax_v102+44]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rax_v102+30]");
												nint num4 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ r8_v39+10]");
												Vector3 animationMoveFrom = UIAnimator.GetAnimationMoveFrom((RectTransform)num4, (UIAnimation)0, startValue);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
												object obj10 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
													object obj11 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
													if ((nint)0 != 0)
													{
														Vector3 startValue2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rax_v105+3C]");
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rax_v105+44]");
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rax_v105+30]");
														nint num5 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ r8_v41+10]");
														Vector3 animationMoveTo = UIAnimator.GetAnimationMoveTo((RectTransform)num5, (UIAnimation)0, startValue2);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
														object obj12 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v108+10]");
															object obj13 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v108+10]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rax_v109+18]");
																object obj14 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rax_v109+18]");
																if ((nint)0 != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdx_v54+14]");
																	if ((nint)0 != 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																		object obj15 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																		if ((nint)0 == 0)
																		{
																			goto IL_1e76;
																		}
																		object obj16 = obj15;
																		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2322 @ rax_v223+1C8] (should have been resolved before IL gen)");
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																	object obj17 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																	if ((nint)0 != 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																		object obj18 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																		if ((nint)0 != 0)
																		{
																			_ = animationMoveTo.z;
																			Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
																			_ = animationMoveTo.x;
																			Vector3 startValue3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
																			_ = animationMoveFrom.x;
																			_ = animationMoveFrom.z;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v385 @ rax_v112+30]");
																			nint num6 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rax_v113+10]");
																			UIAnimator.Move((RectTransform)num6, (UIAnimation)0, startValue3, endValue, flag2, onStartCallback, onCompleteCallback);
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																			object obj19 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																			if ((nint)0 != 0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																				object obj20 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rsi_v16+10]");
																				object obj21 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																				if ((nint)0 != 0)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rax_v116+50]");
																					object obj22 = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rsi_v16+10]");
																					if ((nint)0 != 0)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rsi_v17+10]");
																						if ((nint)0 == 1)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rsi_v17+20]");
																							object obj23 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rsi_v17+20]");
																							if ((nint)0 == 0)
																							{
																								goto IL_1e76;
																							}
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rax_v220+18]");
																							Vector3 vector = (Vector3)0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rax_v220+20]");
																							obj22 = 0;
																						}
																						else
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rsi_v17+10]");
																							if ((nint)0 == 2)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rsi_v17+20]");
																								object obj24 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rsi_v17+20]");
																								if ((nint)0 == 0)
																								{
																									goto IL_1e76;
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rax_v219+3C]");
																								if ((nint)0 != 0)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rax_v219+18]");
																									Vector3 vector = (Vector3)0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rax_v219+20]");
																									obj22 = 0;
																								}
																								else
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rax_v116+48]");
																									Vector3 vector = (Vector3)0;
																								}
																							}
																							else
																							{
																								nint num7 = (nint)typeof(UIAnimator);
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2393 @ rax_v217 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
																								nint num8 = 0;
																								Vector3 vector = UIAnimator.DEFAULT_START_ROTATION;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2394 @ rcx_v158 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+14]");
																								obj22 = 0;
																							}
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																						object obj25 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																						if ((nint)0 != 0)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																							object obj26 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rsi_v18+10]");
																							object obj27 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																							if ((nint)0 != 0)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rax_v120+48]");
																								Vector3 vector2 = (Vector3)0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rax_v120+50]");
																								object obj28 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rsi_v18+10]");
																								if ((nint)0 != 0)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rsi_v19+10]");
																									if ((nint)0 == 1)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rsi_v19+20]");
																										object obj29 = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rsi_v19+20]");
																										if ((nint)0 == 0)
																										{
																											goto IL_1e76;
																										}
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rax_v214+3C]");
																										if ((nint)0 != 0)
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rax_v214+24]");
																											vector2 = (Vector3)0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rax_v214+2C]");
																											obj28 = 0;
																										}
																									}
																									else
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rsi_v19+10]");
																										if ((nint)0 == 2)
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rsi_v19+20]");
																											object obj30 = 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rsi_v19+20]");
																											if ((nint)0 == 0)
																											{
																												goto IL_1e76;
																											}
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rax_v213+24]");
																											vector2 = (Vector3)0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rax_v213+2C]");
																											obj28 = 0;
																										}
																										else
																										{
																											nint num9 = (nint)typeof(UIAnimator);
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2480 @ rax_v211 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
																											nint num10 = 0;
																											vector2 = UIAnimator.DEFAULT_START_ROTATION;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2481 @ rcx_v155 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+14]");
																											obj28 = 0;
																										}
																									}
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																									object obj31 = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																									if ((nint)0 != 0)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rax_v124+10]");
																										object obj32 = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rax_v124+10]");
																										if ((nint)0 != 0)
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rcx_v93+20]");
																											object obj33 = 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rcx_v93+20]");
																											if ((nint)0 != 0)
																											{
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rax_v125+14]");
																												if ((nint)0 != 0)
																												{
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																													object obj34 = 0;
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																													if ((nint)0 == 0)
																													{
																														goto IL_1e76;
																													}
																													object obj35 = obj34;
																													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2520 @ rax_v208+1D8] (should have been resolved before IL gen)");
																												}
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																												object obj36 = 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																												if ((nint)0 != 0)
																												{
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																													object obj37 = 0;
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																													if ((nint)0 != 0)
																													{
																														Vector3 endValue2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
																														Vector3 startValue4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v389 @ rax_v128+30]");
																														nint num11 = 0;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rax_v129+10]");
																														UIAnimator.Rotate((RectTransform)num11, (UIAnimation)0, startValue4, endValue2, flag2, onStartCallback, onCompleteCallback);
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																														object obj38 = 0;
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																														if ((nint)0 != 0)
																														{
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																															object obj39 = 0;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																															if ((nint)0 != 0)
																															{
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v133+54]");
																																object obj40 = 0;
																																Vector3 startValue5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v133+54]");
																																_ = 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v133+5C]");
																																_ = 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ rax_v132+10]");
																																Vector3 animationScaleFrom = UIAnimator.GetAnimationScaleFrom((UIAnimation)0, startValue5);
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																																object obj41 = 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																																if ((nint)0 != 0)
																																{
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																																	object obj42 = 0;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rsi_v21+10]");
																																	object obj43 = 0;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																																	if ((nint)0 != 0)
																																	{
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rsi_v21+10]");
																																		if ((nint)0 != 0)
																																		{
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rsi_v22+10]");
																																			if ((nint)0 == 1)
																																			{
																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rsi_v22+28]");
																																				object obj44 = 0;
																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rsi_v22+28]");
																																				if ((nint)0 == 0)
																																				{
																																					goto IL_1e76;
																																				}
																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rax_v204+3C]");
																																				if ((nint)0 != 0)
																																				{
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rax_v204+24]");
																																					obj40 = 0;
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rax_v204+24]");
																																					_ = 0;
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rax_v204+2C]");
																																					_ = 0;
																																				}
																																				else
																																				{
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rax_v136+54]");
																																					_ = 0;
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rax_v136+5C]");
																																					_ = 0;
																																				}
																																			}
																																			else
																																			{
																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rsi_v22+10]");
																																				if ((nint)0 == 2)
																																				{
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rsi_v22+28]");
																																					object obj45 = 0;
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rsi_v22+28]");
																																					if ((nint)0 == 0)
																																					{
																																						goto IL_1e76;
																																					}
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ rax_v202+24]");
																																					Vector3 vector3 = (Vector3)0;
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ rax_v202+2C]");
																																					object obj46 = 0;
																																				}
																																				else
																																				{
																																					nint num12 = (nint)typeof(UIAnimator);
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2599 @ rax_v198 (Il2CppClass<Doozy.Engine.UI.Animation.UIAnimator>)+B8]");
																																					nint num13 = 0;
																																					Vector3 vector3 = UIAnimator.DEFAULT_START_SCALE;
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2600 @ rax_v199 (Il2CppStaticFields<Doozy.Engine.UI.Animation.UIAnimator>)+20]");
																																					object obj46 = 0;
																																				}
																																				object obj47 = default(object);
																																				obj40 = obj47;
																																			}
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																																			object obj48 = 0;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																																			if ((nint)0 != 0)
																																			{
																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rax_v140+10]");
																																				object obj49 = 0;
																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rax_v140+10]");
																																				if ((nint)0 != 0)
																																				{
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rax_v141+28]");
																																					object obj50 = 0;
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rax_v141+28]");
																																					if ((nint)0 != 0)
																																					{
																																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rdx_v60+14]");
																																						if ((nint)0 != 0)
																																						{
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																																							object obj51 = 0;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																																							if ((nint)0 == 0)
																																							{
																																								goto IL_1e76;
																																							}
																																							object obj52 = obj51;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2663 @ rax_v194+1E8] (should have been resolved before IL gen)");
																																						}
																																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																																						object obj53 = 0;
																																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																																						if ((nint)0 != 0)
																																						{
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																																							object obj54 = 0;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																																							if ((nint)0 != 0)
																																							{
																																								Vector3 endValue3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
																																								Vector3 startValue6 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
																																								_ = 1f;
																																								_ = animationScaleFrom.x;
																																								_ = animationScaleFrom.z;
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ rax_v144+30]");
																																								nint num14 = 0;
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ rax_v145+10]");
																																								UIAnimator.Scale((RectTransform)num14, (UIAnimation)0, startValue6, endValue3, flag2, onStartCallback, onCompleteCallback);
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																																								object obj55 = 0;
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																																								if ((nint)0 != 0)
																																								{
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																																									object obj56 = 0;
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rax_v148+10]");
																																									object obj57 = 0;
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
																																									if ((nint)0 != 0)
																																									{
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rcx_v109+38]");
																																										num15 = 0f;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rax_v148+10]");
																																										if ((nint)0 != 0)
																																										{
																																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v149+10]");
																																											object obj60;
																																											if ((nint)0 == 1)
																																											{
																																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v149+30]");
																																												object obj58 = 0;
																																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v149+30]");
																																												if ((nint)0 == 0)
																																												{
																																													goto IL_1e76;
																																												}
																																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ rcx_v148+18]");
																																												num15 = 0f;
																																											}
																																											else
																																											{
																																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v149+10]");
																																												if ((nint)0 == 2)
																																												{
																																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v149+30]");
																																													object obj59 = 0;
																																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v149+30]");
																																													if ((nint)0 == 0)
																																													{
																																														goto IL_1e76;
																																													}
																																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																																													obj60 = 0;
																																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rcx_v147+24]");
																																													if ((nint)0 != 0)
																																													{
																																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rcx_v147+18]");
																																														num15 = 0f;
																																													}
																																													goto IL_20b9;
																																												}
																																												num15 = 1f;
																																											}
																																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
																																											obj60 = 0;
																																											goto IL_20b9;
																																										}
																																									}
																																								}
																																							}
																																						}
																																					}
																																				}
																																			}
																																		}
																																	}
																																}
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_1e76;
			IL_21af:
			_003C_003E4__this.NotifySystemOfTriggeredBehavior(AnimationType.Hide);
			goto IL_1558;
			IL_1558:
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			_003CstartTime_003E5__2 = realtimeSinceStartup;
			bool flag3 = !instantAction;
			float num16 = num15;
			float num18;
			float num17 = num18;
			num2 = 0;
			if (!flag3)
			{
				goto IL_15a3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
			object obj61 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rax_v167+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rax_v167+10]");
					float totalDuration = ((UIAnimation)0).TotalDuration;
					_003CtotalDuration_003E5__3 = totalDuration;
					float realtimeSinceStartup2 = Time.realtimeSinceStartup;
					float num19 = _003CstartTime_003E5__2 - realtimeSinceStartup2;
					_003CelapsedTime_003E5__4 = num19;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
					object obj62 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rcx_v128+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rcx_v128+10]");
							float startDelay = ((UIAnimation)0).StartDelay;
							_003CstartDelay_003E5__5 = startDelay;
							_003CinvokedOnStart_003E5__6 = false;
							num16 = num15;
							num17 = num18;
							num = 0;
							goto IL_1ec0;
						}
					}
				}
			}
			goto IL_1e76;
			IL_1de5:
			float num20 = _003CelapsedTime_003E5__4 / _003CtotalDuration_003E5__3;
			float visibilityProgress = 1f - num20;
			_003C_003E4__this.VisibilityProgress = visibilityProgress;
			_003C_003E2__current = num;
			_003C_003E1__state = 1;
			goto IL_22b8;
			IL_15a3:
			if ((object)_003C_003E4__this != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+138]");
				if ((nint)0 == 0)
				{
					goto IL_21f3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
				object obj63 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rsi_v12+20]");
					UIAction uIAction = (UIAction)0;
					GameObject gameObject2 = _003C_003E4__this.gameObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rsi_v12+20]");
					if ((nint)0 != 0)
					{
						if (!instantAction)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rsi_v12+20]");
							if (((UIAction)0).HasSound)
							{
								SoundyController soundyController = SoundyManager.Play(uIAction.SoundData);
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rsi_v12+20]");
							Canvas canvas = ((UIAction)0).GetCanvas(gameObject2);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rsi_v12+20]");
							((UIAction)0).ExecuteEffect(canvas);
							_003CExecuteHideDeselectButtonEnumerator_003Ed__116 obj64 = null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rsi_v12+20]");
						((UIAction)0).InvokeAnimatorEvents();
						if (uIAction.GameEvents != null)
						{
							List<string> gameEvents = uIAction.GameEvents;
							if (uIAction.GameEvents == null)
							{
								goto IL_1e76;
							}
							if (gameEvents._size > 0)
							{
								if ((object)gameObject2 == null)
								{
									goto IL_1e76;
								}
								GameEventMessage.SendEvents(uIAction.GameEvents, gameObject2);
								_003CExecuteHideDeselectButtonEnumerator_003Ed__116 obj64 = null;
							}
						}
						if (uIAction.Event != null)
						{
							uIAction.Event.Invoke();
						}
						if (uIAction.Action != null)
						{
							Action<GameObject> action = uIAction.Action;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2079 @ rax_v80 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
						}
						goto IL_21f3;
					}
				}
			}
			goto IL_1e76;
			IL_20b9:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2730 @ rax_v150+10]");
			object obj65 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
			object obj66 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ rax_v151+38]");
			num18 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2730 @ rax_v150+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rcx_v112+10]");
				if ((nint)0 == 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rcx_v112+30]");
					object obj67 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rcx_v112+30]");
					if ((nint)0 == 0)
					{
						goto IL_1e76;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v190+24]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v190+1C]");
						num18 = 0f;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rcx_v112+10]");
					if ((nint)0 == 2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rcx_v112+30]");
						object obj68 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rcx_v112+30]");
						if ((nint)0 == 0)
						{
							goto IL_1e76;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rax_v189+1C]");
						num18 = 0f;
					}
					else
					{
						num18 = 1f;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
				object obj69 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rax_v154+10]");
				object obj70 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rax_v154+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rcx_v113+30]");
					object obj71 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rcx_v113+30]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v155+14]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
							object obj72 = 0;
							object obj73 = obj72;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2802 @ rax_v187+1B8] (should have been resolved before IL gen)");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
						object obj74 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
							object obj75 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rax_v158+30]");
								nint num21 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ rax_v159+10]");
								UIAnimator.Fade((RectTransform)num21, (UIAnimation)0, num15, num18, flag2, onStartCallback, onCompleteCallback);
								_003CExecuteHideDeselectButtonEnumerator_003Ed__116 obj76 = null;
								obj76._003C_003E1__state = 0;
								obj76._003C_003E4__this = _003C_003E4__this;
								Coroutine coroutine = _003C_003E4__this.StartCoroutine(obj76);
								_ = 2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+138]");
								bool flag4 = (nint)0 == 0;
								_003CExecuteHideDeselectButtonEnumerator_003Ed__116 obj64 = obj76;
								if (flag4)
								{
									goto IL_1558;
								}
								bool flag5 = !instantAction;
								obj64 = obj76;
								if (flag5)
								{
									goto IL_21af;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
								object obj77 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rsi_v27+28]");
									UIAction uIAction2 = (UIAction)0;
									GameObject gameObject3 = _003C_003E4__this.gameObject;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rsi_v27+28]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rsi_v27+28]");
										((UIAction)0).InvokeAnimatorEvents();
										bool flag6 = uIAction2.GameEvents == null;
										obj64 = obj76;
										if (!flag6)
										{
											List<string> gameEvents2 = uIAction2.GameEvents;
											if (uIAction2.GameEvents == null)
											{
												goto IL_1e76;
											}
											bool flag7 = gameEvents2._size <= 0;
											obj64 = obj76;
											if (!flag7)
											{
												if ((object)gameObject3 == null)
												{
													goto IL_1e76;
												}
												GameEventMessage.SendEvents(uIAction2.GameEvents, gameObject3);
												obj64 = null;
											}
										}
										if (uIAction2.Event != null)
										{
											uIAction2.Event.Invoke();
										}
										if (uIAction2.Action != null)
										{
											Action<GameObject> action2 = uIAction2.Action;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3052 @ rax_v174 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
										}
										goto IL_21af;
									}
								}
							}
						}
					}
				}
			}
			goto IL_1e76;
			IL_22b8:
			return true;
			IL_1ead:
			return false;
			IL_1ec0:
			if (!(_003CtotalDuration_003E5__3 < _003CelapsedTime_003E5__4))
			{
				float realtimeSinceStartup3 = Time.realtimeSinceStartup;
				float num22 = (_003CelapsedTime_003E5__4 = realtimeSinceStartup3 - _003CstartTime_003E5__2);
				if (!_003CinvokedOnStart_003E5__6 && num22 > _003CstartDelay_003E5__5)
				{
					if ((object)_003C_003E4__this != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
						object obj78 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+98]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rsi_v4+28]");
							UIAction uIAction3 = (UIAction)0;
							GameObject gameObject4 = _003C_003E4__this.gameObject;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rsi_v4+28]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rsi_v4+28]");
								if (((UIAction)0).HasSound)
								{
									SoundyController soundyController2 = SoundyManager.Play(uIAction3.SoundData);
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rsi_v4+28]");
								Canvas canvas2 = ((UIAction)0).GetCanvas(gameObject4);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rsi_v4+28]");
								((UIAction)0).ExecuteEffect(canvas2);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rsi_v4+28]");
								((UIAction)0).InvokeAnimatorEvents();
								bool flag8 = uIAction3.GameEvents == null;
								object obj79 = 0;
								if (!flag8)
								{
									List<string> gameEvents3 = uIAction3.GameEvents;
									if (uIAction3.GameEvents == null)
									{
										goto IL_1e76;
									}
									bool flag9 = gameEvents3._size <= 0;
									obj79 = 0;
									if (!flag9)
									{
										if ((object)gameObject4 == null)
										{
											goto IL_1e76;
										}
										GameEventMessage.SendEvents(uIAction3.GameEvents, gameObject4);
										obj79 = 0;
									}
								}
								if (uIAction3.Event != null)
								{
									uIAction3.Event.Invoke();
								}
								if (uIAction3.Action != null)
								{
									Action<GameObject> action3 = uIAction3.Action;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2276 @ rax_v23 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
								}
								_003CinvokedOnStart_003E5__6 = true;
								goto IL_1de5;
							}
						}
					}
				}
				else if ((object)_003C_003E4__this != null)
				{
					goto IL_1de5;
				}
				goto IL_1e76;
			}
			WaitForSecondsRealtime waitForSecondsRealtime = null;
			waitForSecondsRealtime.m_WaitUntilTime = -1f;
			waitForSecondsRealtime._003CwaitTime_003Ek__BackingField = 0.05f;
			_003C_003E2__current = waitForSecondsRealtime;
			_003C_003E1__state = 2;
			goto IL_22b8;
			IL_21f3:
			_ = 1;
			_003C_003E4__this.VisibilityProgress = 0f;
			if (VisiblePopups != null)
			{
				bool flag10 = VisiblePopups.Remove(_003C_003E4__this);
				bool flag11 = !flag10;
				nint num23 = unchecked((nint)null);
				if (!flag11)
				{
					if (VisiblePopups == null)
					{
						goto IL_1e76;
					}
					bool flag12 = ((List<object>)(object)VisiblePopups).Remove((object)_003C_003E4__this);
					num23 = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
				object obj80 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
				if ((nint)0 != 0)
				{
					object obj81 = obj80;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2025 @ rax_v44+178] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+C0]");
					object obj82 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+C0]");
					if ((nint)0 != 0)
					{
						object obj83 = obj82;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2043 @ rax_v46+178] (should have been resolved before IL gen)");
						DoozySettings instance2 = DoozySettings.Instance;
						if ((object)instance2 != null)
						{
							if (instance2.AutoDisableUIInteractions)
							{
								UIComponentBase<UIPopup>.EnableUIInteractions();
							}
							RemoveHiddenFromVisiblePopups();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+138]");
							if ((nint)0 != 0)
							{
								UIPopupManager.RemoveFromQueue(_003C_003E4__this);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+90]");
								if ((nint)0 != 0)
								{
									_003C_003E2__current = num2;
									_003C_003E1__state = 3;
									goto IL_22b8;
								}
							}
							else
							{
								_ = 1;
							}
							goto IL_1ead;
						}
					}
				}
			}
			goto IL_1e76;
			IL_1e76:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
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

	private sealed class _003CHideWithDelayEnumerator_003Ed__114(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public UIPopup _003C_003E4__this;

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
			UIPopup uIPopup = _003C_003E4__this;
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
				uIPopup.m_autoHideCoroutine = null;
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

	private sealed class _003CShowEnumerator_003Ed__112(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UIPopup _003C_003E4__this;

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
			//IL_1379: Expected I4, but got I8
			//IL_0033: Expected O, but got I4
			//IL_13b6: Expected O, but got I
			//IL_009f: Expected I4, but got I8
			//IL_00f3: Expected O, but got I
			//IL_0079: Expected I4, but got I8
			//IL_0108: Expected O, but got I
			//IL_011d: Expected O, but got I
			//IL_0f3a: Expected O, but got I
			//IL_0f4f: Expected O, but got I
			//IL_0149: Expected O, but got I
			//IL_0159: Expected O, but got I
			//IL_0f15: Expected O, but got I4
			//IL_0180: Expected O, but got I
			//IL_101c: Expected O, but got I
			//IL_01a7: Expected O, but got I
			//IL_0f96: Expected O, but got I
			//IL_01bc: Expected O, but got I
			//IL_0fe4: Expected O, but got I
			//IL_0ffd: Expected O, but got I
			//IL_1006: Expected O, but got I4
			//IL_0d45: Expected O, but got I
			//IL_01e2: Expected O, but got Ref
			//IL_01e2: Expected O, but got I
			//IL_01e2: Expected O, but got I
			//IL_01f6: Expected O, but got I
			//IL_0d5a: Expected O, but got I
			//IL_020b: Expected O, but got I
			//IL_0d7f: Expected O, but got I
			//IL_0231: Expected O, but got Ref
			//IL_0231: Expected O, but got I
			//IL_0231: Expected O, but got I
			//IL_0245: Expected O, but got I
			//IL_0dcd: Expected O, but got I
			//IL_0de6: Expected O, but got I
			//IL_025a: Expected O, but got I
			//IL_107f: Expected O, but got I4
			//IL_0dfc: Expected O, but got I
			//IL_0e19: Expected O, but got I4
			//IL_026f: Expected O, but got I
			//IL_1171: Expected F4, but got I
			//IL_143a: Expected O, but got I
			//IL_02d5: Expected O, but got I
			//IL_02a9: Expected O, but got I
			//IL_0e4c: Expected O, but got I4
			//IL_0310: Expected O, but got Ref
			//IL_0310: Expected O, but got Ref
			//IL_0310: Expected O, but got I
			//IL_0310: Expected O, but got I
			//IL_0320: Expected O, but got I
			//IL_0e71: Expected O, but got I4
			//IL_0335: Expected O, but got I
			//IL_1211: Expected O, but got I
			//IL_16c4: Expected O, but got I
			//IL_144f: Expected O, but got I
			//IL_03a4: Expected O, but got I
			//IL_03ed: Expected O, but got I
			//IL_042f: Expected O, but got I
			//IL_1464: Expected O, but got I
			//IL_04a0: Expected O, but got I
			//IL_04b5: Expected O, but got I
			//IL_1479: Expected O, but got I
			//IL_051b: Expected O, but got I
			//IL_04ef: Expected O, but got I
			//IL_14af: Expected O, but got Ref
			//IL_14af: Expected O, but got Ref
			//IL_14af: Expected O, but got I
			//IL_14af: Expected O, but got I
			//IL_14bf: Expected O, but got I
			//IL_0535: Expected O, but got I
			//IL_054a: Expected F4, but got I
			//IL_055f: Expected O, but got Ref
			//IL_055f: Expected O, but got I
			//IL_0573: Expected O, but got I
			//IL_0588: Expected O, but got I
			//IL_05ca: Expected O, but got I
			//IL_066e: Expected F4, but got O
			//IL_0646: Expected O, but got I
			//IL_065b: Expected F4, but got I
			//IL_14d4: Expected O, but got I
			//IL_0604: Expected F4, but got I
			//IL_0683: Expected O, but got I
			//IL_0698: Expected O, but got I
			//IL_14f6: Expected O, but got I
			//IL_06fe: Expected O, but got I
			//IL_06d2: Expected O, but got I
			//IL_0739: Expected O, but got Ref
			//IL_0739: Expected O, but got Ref
			//IL_0739: Expected O, but got I
			//IL_0739: Expected O, but got I
			//IL_0749: Expected O, but got I
			//IL_075e: Expected O, but got I
			//IL_076e: Expected O, but got I
			//IL_0783: Expected F4, but got I
			//IL_07c0: Expected O, but got I
			//IL_150b: Expected O, but got I
			//IL_0812: Expected O, but got I
			//IL_07d5: Expected F4, but got I
			//IL_1520: Expected O, but got I
			//IL_1530: Expected O, but got I
			//IL_1540: Expected F4, but got I
			//IL_0827: Expected O, but got I
			//IL_085c: Expected F4, but got I
			//IL_08a7: Expected O, but got I
			//IL_1555: Expected O, but got I
			//IL_1565: Expected O, but got I
			//IL_091e: Expected O, but got I
			//IL_0956: Expected O, but got I
			//IL_0933: Expected F4, but got I
			//IL_08e1: Expected F4, but got I
			//IL_157a: Expected O, but got I
			//IL_09b7: Expected O, but got I
			//IL_0990: Expected O, but got I
			//IL_09f2: Expected O, but got I
			//IL_09f2: Expected O, but got I
			//IL_0a54: Expected O, but got Ref
			//IL_159f: Expected O, but got I
			//IL_0a72: Expected O, but got I
			//IL_0a87: Expected O, but got I
			//IL_0aac: Expected O, but got I
			//IL_0ac8: Expected O, but got Ref
			//IL_15eb: Expected O, but got F4
			//IL_0afa: Expected O, but got Ref
			//IL_0c1b: Expected O, but got I
			//IL_0c31: Expected O, but got I
			//IL_0b1f: Expected O, but got I4
			//IL_0c78: Expected O, but got I
			//IL_0bee: Expected O, but got I
			//IL_0bf7: Expected F4, but got I4
			//IL_0c01: Expected O, but got I4
			//IL_0c8e: Expected O, but got I
			UIComponentBase<UIPopup> uIComponentBase = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			bool result;
			float visibilityProgress;
			int num;
			float num7 = default(float);
			bool flag3 = default(bool);
			UnityAction onStartCallback = default(UnityAction);
			UnityAction onCompleteCallback = default(UnityAction);
			float num11 = default(float);
			float num13;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					bool flag2 = (nint)obj != 1;
					result = false;
					if (flag2)
					{
						goto IL_13fb;
					}
					_003C_003E1__state = -1;
					visibilityProgress = 1f;
					num = 0;
					goto IL_1400;
				}
				_003C_003E1__state = -1;
				DoozySettings instance = DoozySettings.Instance;
				if (instance.AutoDisableUIInteractions)
				{
					UIComponentBase<UIPopup>.DisableUIInteractions();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1390 @ rax_v148+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1389 @ rax_v147+30]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rdx_v70+10]");
				UIAnimator.StopAnimations((RectTransform)num2, AnimationType.Undefined);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
				object obj5 = 0;
				object obj6 = obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2465 @ rdx_v72+188] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+C0]");
				object obj7 = 0;
				object obj8 = obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2492 @ rdx_v74+188] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1393 @ rax_v155+30]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ r8_v62+10]");
				float num4 = default(float);
				Vector3 animationMoveFrom = UIAnimator.GetAnimationMoveFrom((RectTransform)num3, (UIAnimation)0, (Vector3)(&num4));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1394 @ rax_v159+30]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ r8_v64+10]");
				Vector3 animationMoveTo = UIAnimator.GetAnimationMoveTo((RectTransform)num5, (UIAnimation)0, (Vector3)(&num4));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
				object obj13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v162+10]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1396 @ rax_v163+18]");
				object obj15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rdx_v78+14]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
					object obj16 = 0;
					object obj17 = obj16;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2821 @ rdx_v109+1C8] (should have been resolved before IL gen)");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
				object obj18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
				object obj19 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1440 @ rax_v166+30]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1398 @ rax_v167+10]");
				UIAnimator.Move((RectTransform)num6, (UIAnimation)0, (Vector3)(&num7), (Vector3)(&num4), flag3, onStartCallback, onCompleteCallback);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
				object obj20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rdi_v28+10]");
				object obj21 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rdi_v29+10]");
				if ((nint)0 != 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rdi_v29+10]");
					if ((nint)0 == 2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rdi_v29+20]");
						object obj22 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1402 @ rax_v295+3C]");
						if ((nint)0 == 0)
						{
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
				object obj23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rdi_v30+10]");
				object obj24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rdi_v31+10]");
				if ((nint)0 == 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rdi_v31+20]");
					object obj25 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1404 @ rax_v290+3C]");
					if ((nint)0 == 0)
					{
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rdi_v31+10]");
					if ((nint)0 != 2)
					{
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
				object obj26 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1406 @ rax_v179+10]");
				object obj27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rcx_v132+20]");
				object obj28 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1407 @ rax_v180+14]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
					object obj29 = 0;
					object obj30 = obj29;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3327 @ rdx_v107+1D8] (should have been resolved before IL gen)");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
				object obj31 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
				object obj32 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1444 @ rax_v183+30]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1409 @ rax_v184+10]");
				Vector3 vector = default(Vector3);
				Vector3 vector2 = default(Vector3);
				UIAnimator.Rotate((RectTransform)num8, (UIAnimation)0, (Vector3)(&vector), (Vector3)(&vector2), flag3, onStartCallback, onCompleteCallback);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
				object obj33 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
				object obj34 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1411 @ rax_v189+54]");
				float num9 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1410 @ rax_v188+10]");
				Vector3 animationScaleFrom = UIAnimator.GetAnimationScaleFrom((UIAnimation)0, (Vector3)(&num7));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
				object obj35 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rdi_v33+10]");
				object obj36 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rdi_v34+10]");
				if ((nint)0 == 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rdi_v34+28]");
					object obj37 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1414 @ rax_v279+3C]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1414 @ rax_v279+24]");
						num9 = 0f;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rdi_v34+10]");
					if ((nint)0 == 2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rdi_v34+28]");
						object obj38 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1415 @ rax_v277+24]");
						float num10 = 0f;
					}
					else
					{
						float num10 = (float)UIAnimator.DEFAULT_START_SCALE;
					}
					num9 = num11;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
				object obj39 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1446 @ rax_v196+10]");
				object obj40 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1416 @ rax_v197+28]");
				object obj41 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rdx_v84+14]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
					object obj42 = 0;
					object obj43 = obj42;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3482 @ rdx_v105+1E8] (should have been resolved before IL gen)");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
				object obj44 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
				object obj45 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1447 @ rax_v200+30]");
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1418 @ rax_v201+10]");
				UIAnimator.Scale((RectTransform)num12, (UIAnimation)0, (Vector3)(&num4), (Vector3)(&num7), flag3, onStartCallback, onCompleteCallback);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
				object obj46 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1419 @ rax_v204+10]");
				object obj47 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
				object obj48 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rcx_v148+38]");
				num13 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1420 @ rax_v205+10]");
				object obj51;
				if ((nint)0 == 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1420 @ rax_v205+30]");
					object obj49 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rcx_v196+18]");
					num13 = 0f;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1420 @ rax_v205+10]");
					if ((nint)0 == 2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1420 @ rax_v205+30]");
						object obj50 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
						obj51 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rcx_v195+24]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rcx_v195+18]");
							num13 = 0f;
						}
						goto IL_1510;
					}
					num13 = 1f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
				obj51 = 0;
				goto IL_1510;
			}
			_003C_003E1__state = -1;
			RectTransform rectTransform = _003C_003E4__this.RectTransform;
			RectTransformExtensions.FullScreen(rectTransform, resetScaleToOne: true);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+C0]");
			((UIContainer)0).FullScreen(resetScaleToOne: true);
			_003C_003E2__current = null;
			_003C_003E1__state = 1;
			goto IL_16f9;
			IL_0f2a:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
			object obj52 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rdi_v19+20]");
			UIAction uIAction = (UIAction)0;
			GameObject gameObject = _003C_003E4__this.gameObject;
			Vector3 vector3;
			if (!instantAction)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rdi_v19+20]");
				if (((UIAction)0).HasSound)
				{
					SoundyController soundyController = SoundyManager.Play(uIAction.SoundData);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rdi_v19+20]");
				Canvas canvas = ((UIAction)0).GetCanvas(gameObject);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rdi_v19+20]");
				((UIAction)0).ExecuteEffect(canvas);
				vector3 = (Vector3)0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rdi_v19+20]");
			((UIAction)0).InvokeAnimatorEvents();
			if (uIAction.GameEvents != null)
			{
				List<string> gameEvents = uIAction.GameEvents;
				if (gameEvents._size > 0)
				{
					GameEventMessage.SendEvents(gameEvents, gameObject);
					vector3 = (Vector3)0;
				}
			}
			if (uIAction.Event != null)
			{
				uIAction.Event.Invoke();
			}
			if (uIAction.Action != null)
			{
				Action<GameObject> action = uIAction.Action;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2482 @ rcx_v102 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
			}
			_003C_003E4__this.VisibilityProgress = visibilityProgress;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AB30");
			object obj53 = default(object);
			if (obj53 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ABA0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+61]");
			if ((nint)0 != 0)
			{
				UIPopup uIPopup = _003C_003E4__this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+64]");
				uIPopup.Hide(0f);
			}
			_003CExecuteShowSelectDeselectButtonEnumerator_003Ed__115 obj54 = null;
			obj54._003C_003E1__state = num;
			obj54._003C_003E4__this = _003C_003E4__this;
			Coroutine coroutine = _003C_003E4__this.StartCoroutine(obj54);
			DoozySettings instance2 = DoozySettings.Instance;
			if (instance2.AutoDisableUIInteractions)
			{
				UIComponentBase<UIPopup>.EnableUIInteractions();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+A0]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+88]");
				object obj55 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1385 @ rsi_v11+10]");
				object obj56 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1438 @ rax_v82+18]");
				if ((nint)0 > (nint)0)
				{
					List<UIButton>.Enumerator enumerator = default(List<UIButton>.Enumerator);
					while (enumerator.MoveNext())
					{
						UIButton uIButton = null;
					}
				}
			}
			RemoveHiddenFromVisiblePopups();
			result = false;
			goto IL_13fb;
			IL_1510:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3561 @ rax_v206+10]");
			object obj57 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
			object obj58 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1448 @ rax_v207+38]");
			float num14 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ rcx_v151+10]");
			if ((nint)0 == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ rcx_v151+30]");
				object obj59 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1421 @ rax_v265+24]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1421 @ rax_v265+1C]");
					num14 = 0f;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ rcx_v151+10]");
				if ((nint)0 == 2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ rcx_v151+30]");
					object obj60 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1422 @ rax_v264+1C]");
					num14 = 0f;
				}
				else
				{
					num14 = 1f;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
			object obj61 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1449 @ rax_v210+10]");
			object obj62 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rcx_v152+30]");
			object obj63 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1423 @ rax_v211+14]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
				object obj64 = 0;
				object obj65 = obj64;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3622 @ rdx_v103+1B8] (should have been resolved before IL gen)");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+78]");
			object obj66 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
			object obj67 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1450 @ rax_v214+30]");
			nint num15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1424 @ rax_v215+10]");
			UIAnimator.Fade((RectTransform)num15, (UIAnimation)0, num13, num14, flag3, onStartCallback, onCompleteCallback);
			_ = 3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AB30");
			object obj68 = default(object);
			if (obj68 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ABA0");
			}
			bool flag4 = !instantAction;
			vector3 = (Vector3)(&num7);
			if (!flag4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
				object obj69 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rdi_v39+28]");
				UIAction uIAction2 = (UIAction)0;
				GameObject gameObject2 = _003C_003E4__this.gameObject;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rdi_v39+28]");
				((UIAction)0).InvokeAnimatorEvents();
				bool flag5 = uIAction2.GameEvents == null;
				vector3 = (Vector3)(&num7);
				if (!flag5)
				{
					List<string> gameEvents2 = uIAction2.GameEvents;
					bool flag6 = gameEvents2._size <= 0;
					vector3 = (Vector3)(&num7);
					if (!flag6)
					{
						GameEventMessage.SendEvents(gameEvents2, gameObject2);
						vector3 = (Vector3)0;
					}
				}
				if (uIAction2.Event != null)
				{
					uIAction2.Event.Invoke();
				}
				if (uIAction2.Action != null)
				{
					Action<GameObject> action2 = uIAction2.Action;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3935 @ rcx_v183 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
				}
			}
			_003C_003E4__this.NotifySystemOfTriggeredBehavior(AnimationType.Show);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+A8]");
			object obj70 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+A8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rdi_v38+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+A8]");
					((Progressor)0).SetValue(0f, instantUpdate: false);
					float num10 = 0f;
					vector3 = (Vector3)0;
				}
			}
			object obj71 = Time.realtimeSinceStartup;
			_003CstartTime_003E5__2 = num11;
			bool flag7 = instantAction;
			float num16 = num13;
			float num17 = num14;
			float num18 = num11;
			visibilityProgress = 1f;
			num = 0;
			if (flag7)
			{
				goto IL_0f2a;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
			object obj72 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1429 @ rax_v233+10]");
			float totalDuration = ((UIAnimation)0).TotalDuration;
			_003CtotalDuration_003E5__3 = totalDuration;
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			float num19 = _003CstartTime_003E5__2 - realtimeSinceStartup;
			_003CelapsedTime_003E5__4 = num19;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
			object obj73 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ rcx_v172+10]");
			float startDelay = ((UIAnimation)0).StartDelay;
			_003CstartDelay_003E5__5 = startDelay;
			_003CinvokedOnStart_003E5__6 = false;
			num16 = num13;
			num17 = num14;
			visibilityProgress = 1f;
			num = 0;
			goto IL_1400;
			IL_13fb:
			return result;
			IL_1400:
			num18 = _003CtotalDuration_003E5__3;
			if (_003CtotalDuration_003E5__3 < _003CelapsedTime_003E5__4)
			{
				goto IL_0f2a;
			}
			float realtimeSinceStartup2 = Time.realtimeSinceStartup;
			float num20 = (_003CelapsedTime_003E5__4 = realtimeSinceStartup2 - _003CstartTime_003E5__2);
			if (!_003CinvokedOnStart_003E5__6 && num20 > _003CstartDelay_003E5__5)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rbx_v1 (Doozy.Engine.UI.Base.UIComponentBase`1<Doozy.Engine.UI.UIPopup>)+D0]");
				object obj74 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rdi_v16+28]");
				UIAction uIAction3 = (UIAction)0;
				GameObject gameObject3 = _003C_003E4__this.gameObject;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rdi_v16+28]");
				if (((UIAction)0).HasSound)
				{
					SoundyController soundyController2 = SoundyManager.Play(uIAction3.SoundData);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rdi_v16+28]");
				Canvas canvas2 = ((UIAction)0).GetCanvas(gameObject3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rdi_v16+28]");
				((UIAction)0).ExecuteEffect(canvas2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rdi_v16+28]");
				((UIAction)0).InvokeAnimatorEvents();
				bool flag8 = uIAction3.GameEvents == null;
				object obj75 = 0;
				if (!flag8)
				{
					List<string> gameEvents3 = uIAction3.GameEvents;
					bool flag9 = gameEvents3._size <= 0;
					obj75 = 0;
					if (!flag9)
					{
						GameEventMessage.SendEvents(gameEvents3, gameObject3);
						obj75 = 0;
					}
				}
				if (uIAction3.Event != null)
				{
					uIAction3.Event.Invoke();
				}
				if (uIAction3.Action != null)
				{
					Action<GameObject> action3 = uIAction3.Action;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2640 @ rax_v46 (System.Action`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
				}
				_003CinvokedOnStart_003E5__6 = true;
			}
			float visibilityProgress2 = _003CelapsedTime_003E5__4 / _003CtotalDuration_003E5__3;
			_003C_003E4__this.VisibilityProgress = visibilityProgress2;
			_003C_003E2__current = num;
			_003C_003E1__state = 2;
			goto IL_16f9;
			IL_16f9:
			result = true;
			goto IL_13fb;
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

	private sealed class _003CTriggerShowInNextFrame_003Ed__111(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UIPopup _003C_003E4__this;

		public bool instantAction;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_00e2: Expected I4, but got I8
			//IL_002f: Expected O, but got I4
			//IL_00b6: Expected I4, but got I8
			//IL_006c: Expected I4, but got I8
			//IL_010d: Expected I4, but got O
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
						_003C_003E4__this.Show(instantAction);
					}
					return false;
				}
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			}
			_003C_003E1__state = -1;
			_003C_003E2__current = null;
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

	public const string DEFAULT_POPUP_CANVAS_NAME = "PopupCanvas";

	public const int DEFAULT_POPUP_CANVAS_OVERLAY_SORT_ORDER = 10000;

	public static Action<UIPopup, AnimationType> OnUIPopupAction;

	public static readonly List<UIPopup> VisiblePopups;

	private string _003CPopupName_003Ek__BackingField;

	public bool AddToPopupQueue;

	public bool AutoHideAfterShow;

	public float AutoHideAfterShowDelay;

	public bool AutoSelectButtonAfterShow;

	public bool AutoSelectPreviouslySelectedButtonAfterHide = true;

	public bool BlockBackButton;

	public string CanvasName;

	public UIContainer Container;

	public bool CustomCanvasName;

	public UIPopupContentReferences Data;

	public bool DestroyAfterHide;

	public PopupDisplayOn DisplayTarget;

	public UIPopupBehavior HideBehavior;

	public bool HideOnAnyButton;

	public bool HideOnBackButton;

	public bool HideOnClickAnywhere;

	public bool HideOnClickContainer;

	public bool HideOnClickOverlay;

	public Progressor HideProgressor;

	public ProgressEvent OnInverseVisibilityChanged;

	public ProgressEvent OnVisibilityChanged;

	public UIContainer Overlay;

	public GameObject SelectedButton;

	public UIPopupBehavior ShowBehavior;

	public Progressor ShowProgressor;

	public bool UpdateHideProgressorOnShow;

	public bool UpdateShowProgressorOnHide;

	public bool UseOverlay;

	private Canvas m_canvas;

	private GraphicRaycaster m_graphicRaycaster;

	private GameObject m_previousSelectedButton;

	private float m_visibilityProgress;

	private VisibilityState m_visibilityState;

	private bool m_addedToQueue;

	private Coroutine m_showCoroutine;

	private Coroutine m_hideCoroutine;

	private Coroutine m_autoHideCoroutine;

	private Coroutine m_disableButtonClickCoroutine;

	private UIButton[] m_childUIButtons;

	private bool m_initialized;

	public static bool AnyPopupVisible
	{
		get
		{
			//IL_00ca: Expected I4, but got O
			RemoveNullsFromVisiblePopups();
			List<UIPopup> visiblePopups = VisiblePopups;
			if (VisiblePopups != null)
			{
				int num = visiblePopups._size ^ visiblePopups._size;
				int num2 = visiblePopups._size & num;
				bool flag = num2 < 0;
				bool flag2 = visiblePopups._size < 0;
				bool flag3 = visiblePopups._size == 0;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				return flag5 & flag4;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public static string DefaultPopupName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899806D6]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "Unnamed";
		}
	}

	public static string DefaultTargetCanvasName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998068E]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "MasterCanvas";
		}
	}

	public static UIPopup LastShownPopup
	{
		get
		{
			//IL_0042: Expected O, but got I4
			//IL_008b: Expected O, but got I4
			List<UIPopup> visiblePopups = VisiblePopups;
			if (visiblePopups._size <= 0)
			{
				return null;
			}
			List<UIPopup> visiblePopups2 = VisiblePopups;
			object obj = visiblePopups2._size - 1;
			if ((nint)obj < visiblePopups2._size)
			{
				UIPopup[] items = visiblePopups2._items;
				object obj2 = visiblePopups2._size - 1;
				return items[obj2];
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			UIPopup result = default(UIPopup);
			return result;
		}
	}

	private static TouchDetector Detector => TouchDetector.Instance;

	public bool AddedToQueue
	{
		get
		{
			return m_addedToQueue;
		}
		set
		{
			m_addedToQueue = value;
		}
	}

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
				object obj = this + 232;
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

	public bool DetectsTouch
	{
		get
		{
			if (!HideOnClickAnywhere && (!HasOverlay || !HideOnClickOverlay))
			{
				bool hasContainer = HasContainer;
				if (!hasContainer)
				{
					return hasContainer;
				}
				return HideOnClickContainer;
			}
			return true;
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
				object obj = this + 240;
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

	public bool HasContainer
	{
		get
		{
			if (Container != null)
			{
				UIContainer container = Container;
				RectTransform rectTransform = container.RectTransform;
				if ((object)container.RectTransform != null)
				{
					bool flag = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
					return !flag;
				}
			}
			return false;
		}
	}

	public bool HasOverlay
	{
		get
		{
			if (Overlay != null)
			{
				UIContainer overlay = Overlay;
				RectTransform rectTransform = overlay.RectTransform;
				if ((object)overlay.RectTransform != null)
				{
					bool flag = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
					return !flag;
				}
			}
			return false;
		}
	}

	public float InverseVisibility => 1f - m_visibilityProgress;

	public bool IsHidden
	{
		get
		{
			//IL_0010: Expected O, but got I4
			object obj = m_visibilityState - 1;
			return obj == null;
		}
	}

	public bool IsHiding
	{
		get
		{
			//IL_0010: Expected O, but got I4
			object obj = m_visibilityState - 2;
			return obj == null;
		}
	}

	public bool IsShowing
	{
		get
		{
			//IL_0010: Expected O, but got I4
			object obj = m_visibilityState - 3;
			return obj == null;
		}
	}

	public bool IsVisible => m_visibilityState == VisibilityState.Visible;

	public string PopupName
	{
		get
		{
			return _003CPopupName_003Ek__BackingField;
		}
		private set
		{
			_003CPopupName_003Ek__BackingField = value;
		}
	}

	public VisibilityState Visibility
	{
		get
		{
			return m_visibilityState;
		}
		set
		{
			m_visibilityState = value;
			if (value == VisibilityState.Visible)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 15 Invalid \"Jump target not found in method: 0x182BADC40\"");
			}
			if (value == VisibilityState.NotVisible)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 30 Invalid \"Jump target not found in method: 0x182BADC40\"");
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
			//IL_0309: Invalid comparison between I4 and F4
			//IL_0044: Expected F4, but got I4
			//IL_00c0: Expected O, but got I4
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Expected O, but got Unknown
			float num;
			if (!(0f > value))
			{
				bool flag = !(value > 1f);
				num = value;
				if (!flag)
				{
					num = 1f;
				}
			}
			else
			{
				num = 0f;
			}
			m_visibilityProgress = num;
			if (HasOverlay)
			{
				UIContainer overlay = Overlay;
				if (overlay.Enabled)
				{
					overlay.CanvasGroup.alpha = num;
				}
			}
			bool flag2 = m_visibilityState == VisibilityState.Visible;
			if (flag2)
			{
				goto IL_010a;
			}
			object obj = m_visibilityState - 1;
			if (!flag2)
			{
				object obj2 = obj - 1;
				if (!flag2)
				{
					if ((nint)obj2 == 1)
					{
						goto IL_010a;
					}
					goto IL_01e5;
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
					goto IL_03da;
				}
			}
			goto IL_01e5;
			IL_010a:
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
					goto IL_03da;
				}
			}
			goto IL_01e5;
			IL_01e5:
			OnVisibilityChanged.Invoke(m_visibilityProgress);
			float arg = 1f - m_visibilityProgress;
			OnInverseVisibilityChanged.Invoke(arg);
			return;
			IL_03da:
			progressor.SetProgress(progress2);
			goto IL_01e5;
		}
	}

	private bool DebugComponent
	{
		get
		{
			//IL_0069: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIPopup)+20]");
			if ((nint)0 != 0)
			{
				return true;
			}
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugUIPopup;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	protected override void Reset()
	{
		UIPopupSettings instance = UIPopupSettings.Instance;
		instance.ResetComponent(this);
	}

	public override void Awake()
	{
		m_initialized = false;
		RectTransform rectTransform = base.RectTransform;
		RectTransformExtensions.FullScreen(rectTransform, resetScaleToOne: true);
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899806EB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIPopupBehavior showBehavior = ShowBehavior;
		if (showBehavior.LoadSelectedPresetAtRuntime)
		{
			showBehavior.LoadPreset();
		}
		UIPopupBehavior hideBehavior = HideBehavior;
		if (hideBehavior.LoadSelectedPresetAtRuntime)
		{
			hideBehavior.LoadPreset();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIPopup)+20]");
		if ((nint)0 == 0)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugUIPopup)
			{
				goto IL_010f;
			}
		}
		DDebug.Log("Load Presets", this);
		goto IL_010f;
		IL_010f:
		Container.Init();
		Overlay.Init();
		Initialize();
	}

	public override void OnDisable()
	{
		StopHide();
		StopShow();
		RectTransform rectTransform = base.RectTransform;
		UIAnimator.StopAnimations(rectTransform, AnimationType.Hide);
		RectTransform rectTransform2 = base.RectTransform;
		UIAnimator.StopAnimations(rectTransform2, AnimationType.Show);
		Container.ResetToStartValues();
		UIContainer overlay = Overlay;
		if (overlay.Enabled)
		{
			overlay.ResetToStartValues();
		}
		base.ResetToStartValues();
	}

	private unsafe void Update()
	{
		//IL_0140: Expected O, but got Ref
		//IL_02f6: Expected O, but got Ref
		//IL_04b2: Expected O, but got I4
		//IL_04cc: Expected O, but got I4
		//IL_0518: Expected O, but got I4
		//IL_0532: Expected O, but got I4
		if (!HideOnClickAnywhere && (!HasOverlay || !HideOnClickOverlay) && (!HasContainer || !HideOnClickContainer))
		{
			return;
		}
		TouchDetector instance = TouchDetector.Instance;
		if (!instance._003CTouchInProgress_003Ek__BackingField)
		{
			return;
		}
		object obj2 = default(object);
		object obj3 = default(object);
		if (!HideOnClickAnywhere)
		{
			if (!HasOverlay || !HideOnClickOverlay)
			{
				goto IL_0299;
			}
			TouchDetector instance2 = TouchDetector.Instance;
			object obj = (object)(&obj2);
			obj = instance2.m_currentTouchInfo;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+60]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+80]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+90]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+A0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+B0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+C0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+D0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+E0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v35 (Doozy.Engine.Touchy.TouchDetector)+F0]");
			_ = 0;
			UIContainer overlay = Overlay;
			GameObject gameObject = overlay.RectTransform.gameObject;
			bool flag = (object)gameObject == null;
			bool flag2 = obj3 == null;
			object obj4 = flag2 & flag;
			bool flag3 = obj4 == null;
			object obj5 = !flag3;
			if (obj5 == null)
			{
				bool flag4;
				if ((object)gameObject != null)
				{
					if (obj3 != null)
					{
						object obj6 = obj3 - (object)gameObject;
						flag4 = obj6 == null;
					}
					else
					{
						flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ stack_-38+10]");
					flag4 = (nint)0 == 0;
				}
				if (!flag4)
				{
					goto IL_0299;
				}
			}
		}
		goto IL_044f;
		IL_044f:
		Hide();
		return;
		IL_0299:
		if (!HasContainer || !HideOnClickContainer)
		{
			return;
		}
		TouchDetector instance3 = TouchDetector.Instance;
		object obj7 = (object)(&obj2);
		obj7 = instance3.m_currentTouchInfo;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v15 (Doozy.Engine.Touchy.TouchDetector)+60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v15 (Doozy.Engine.Touchy.TouchDetector)+70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v15 (Doozy.Engine.Touchy.TouchDetector)+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v15 (Doozy.Engine.Touchy.TouchDetector)+90]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v15 (Doozy.Engine.Touchy.TouchDetector)+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v15 (Doozy.Engine.Touchy.TouchDetector)+B0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v15 (Doozy.Engine.Touchy.TouchDetector)+C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v15 (Doozy.Engine.Touchy.TouchDetector)+D0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v15 (Doozy.Engine.Touchy.TouchDetector)+E0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v15 (Doozy.Engine.Touchy.TouchDetector)+F0]");
		_ = 0;
		UIContainer container = Container;
		GameObject gameObject2 = container.RectTransform.gameObject;
		bool flag5 = (object)gameObject2 == null;
		bool flag6 = obj3 == null;
		object obj8 = flag6 & flag5;
		bool flag7 = obj8 == null;
		object obj9 = !flag7;
		if (obj9 == null)
		{
			bool flag8;
			if ((object)gameObject2 != null)
			{
				if (obj3 != null)
				{
					object obj10 = obj3 - (object)gameObject2;
					flag8 = obj10 == null;
				}
				else
				{
					flag8 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ stack_-38+10]");
				flag8 = (nint)0 == 0;
			}
			if (!flag8)
			{
				return;
			}
		}
		goto IL_044f;
	}

	public void CancelAutoHide()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899806E1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (m_autoHideCoroutine == null)
		{
			return;
		}
		StopCoroutine(m_autoHideCoroutine);
		m_autoHideCoroutine = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIPopup)+20]");
		if ((nint)0 == 0)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugUIPopup)
			{
				return;
			}
		}
		DDebug.Log("Cancel Auto Hide", this);
	}

	public UICanvas GetTargetCanvas()
	{
		if (DisplayTarget == PopupDisplayOn.PopupCanvas)
		{
			return GetPopupOverlayCanvas();
		}
		return UICanvas.GetUICanvas(CanvasName);
	}

	public void Hide(float delay)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899806E3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIPopup)+20]");
		if ((nint)0 == 0)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugUIPopup)
			{
				goto IL_010b;
			}
		}
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string text = System.Number.FormatSingle(delay, null, currentInfo);
		string message = "Hide with a " + text + " seconds delay.";
		DDebug.Log(message, this);
		goto IL_010b;
		IL_010b:
		_003CHideWithDelayEnumerator_003Ed__114 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.delay = delay;
		Coroutine autoHideCoroutine = StartCoroutine(obj);
		m_autoHideCoroutine = autoHideCoroutine;
	}

	public void Hide(bool instantAction = false)
	{
		UIPopupBehavior hideBehavior = HideBehavior;
		bool flag = hideBehavior.InstantAnimation;
		bool flag2 = true;
		if (!flag)
		{
			flag2 = instantAction;
		}
		StopShow();
		UIPopupBehavior hideBehavior2 = HideBehavior;
		if (!hideBehavior2.Animation.Enabled && !flag2)
		{
			string text = GetName();
			string message = "You are trying to HIDE the (" + text + ") UIPopup, but you did not enable any HIDE animations. Enable at least one HIDE animation in order to fix this issue.";
			DDebug.Log(message, this);
			return;
		}
		if (m_visibilityState == VisibilityState.Hiding)
		{
			return;
		}
		if (m_visibilityState == VisibilityState.Visible)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIPopup)+20]");
			if ((nint)0 == 0)
			{
				DoozySettings instance = DoozySettings.Instance;
				if (!instance.DebugUIPopup)
				{
					goto IL_01e1;
				}
			}
			DDebug.Log("Hide", this);
			goto IL_01e1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AB30");
		object obj = default(object);
		if (obj != null)
		{
			bool flag3 = ((List<object>)(object)VisiblePopups).Remove((object)this);
		}
		return;
		IL_01e1:
		_003CHideEnumerator_003Ed__113 obj2 = null;
		obj2._003C_003E1__state = 0;
		obj2._003C_003E4__this = this;
		obj2.instantAction = flag2;
		Coroutine hideCoroutine = StartCoroutine(obj2);
		m_hideCoroutine = hideCoroutine;
	}

	public void InstantHide()
	{
		StopShow();
		StopHide();
		Container.ResetToStartValues();
		UIContainer overlay = Overlay;
		if (overlay.Enabled)
		{
			overlay.ResetToStartValues();
		}
		base.ResetToStartValues();
		Container.Disable();
		Overlay.Disable();
		m_visibilityState = VisibilityState.NotVisible;
		VisibilityProgress = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AB30");
		object obj = default(object);
		if (obj != null)
		{
			bool flag = ((List<object>)(object)VisiblePopups).Remove((object)this);
		}
		RemoveHiddenFromVisiblePopups();
		if (!m_initialized)
		{
			m_initialized = true;
		}
	}

	public void ResetTargetCanvasToPopupCanvas(bool reparentImmediately = true)
	{
		DisplayTarget = PopupDisplayOn.PopupCanvas;
		if (reparentImmediately)
		{
			Transform transform = base.transform;
			UICanvas popupOverlayCanvas = GetPopupOverlayCanvas();
			Transform parent = popupOverlayCanvas.transform;
			transform.SetParent(parent, worldPositionStays: true);
			RectTransform rectTransform = base.RectTransform;
			RectTransformExtensions.FullScreen(rectTransform, resetScaleToOne: true);
		}
	}

	public void Show(bool instantAction = false)
	{
		UIPopupBehavior showBehavior = ShowBehavior;
		bool flag = showBehavior.InstantAnimation;
		bool flag2 = true;
		if (!flag)
		{
			flag2 = instantAction;
		}
		ReparentToTargetCanvas();
		StopHide();
		UIPopupBehavior showBehavior2 = ShowBehavior;
		if (!showBehavior2.Animation.Enabled && !flag2)
		{
			string text = GetName();
			string message = "You are trying to SHOW the (" + text + ") UIPopup, but you did not enable any SHOW animations. Enable at least one SHOW animation in order to fix this issue.";
			DDebug.Log(message, this);
			return;
		}
		if (m_visibilityState == VisibilityState.Showing)
		{
			return;
		}
		if (m_visibilityState != VisibilityState.Visible)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIPopup)+20]");
			if ((nint)0 == 0)
			{
				DoozySettings instance = DoozySettings.Instance;
				if (!instance.DebugUIPopup)
				{
					goto IL_01e2;
				}
			}
			DDebug.Log("Show", this);
			goto IL_01e2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AB30");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ABA0");
		}
		return;
		IL_01e2:
		_003CShowEnumerator_003Ed__112 obj2 = null;
		obj2._003C_003E1__state = 0;
		obj2._003C_003E4__this = this;
		obj2.instantAction = flag2;
		Coroutine showCoroutine = StartCoroutine(obj2);
		m_showCoroutine = showCoroutine;
	}

	public void NotifySystemOfTriggeredBehavior(AnimationType animationType)
	{
		if (OnUIPopupAction != null)
		{
			Action<UIPopup, AnimationType> onUIPopupAction = OnUIPopupAction;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v80 @ r10_v2 (System.Action`2<Doozy.Engine.UI.UIPopup, Doozy.Engine.UI.Animation.AnimationType>)+18] (should have been resolved before IL gen)");
		}
		UIPopupMessage uIPopupMessage = null;
		uIPopupMessage.Popup = this;
		uIPopupMessage.AnimationType = animationType;
		Message.Send(uIPopupMessage);
	}

	public void SetPopupName(string popupName)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899806E8]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_003CPopupName_003Ek__BackingField = popupName;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIPopup)+20]");
		if ((nint)0 == 0)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugUIPopup)
			{
				return;
			}
		}
		string message = "Set PopupName: " + popupName;
		DDebug.Log(message, this);
	}

	public void SetTargetCanvasName(string canvasName, bool reparentImmediately = true)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899806E9]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		DisplayTarget = PopupDisplayOn.TargetCanvas;
		CanvasName = canvasName;
		if (reparentImmediately)
		{
			ReparentToTargetCanvas();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIPopup)+20]");
		if ((nint)0 == 0)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugUIPopup)
			{
				return;
			}
		}
		string message = "Set Target Canvas Name: " + canvasName;
		DDebug.Log(message, this);
	}

	private unsafe void Initialize()
	{
		//IL_0018: Expected O, but got Ref
		//IL_008c: Expected O, but got I4
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		string text = GetName();
		int instanceID = GetInstanceID();
		object obj = default(object);
		string text2 = System.Number.FormatInt32(instanceID, (ReadOnlySpan<char>)(&obj), null);
		string popupName = text + text2;
		SetPopupName(popupName);
		UIButton[] componentsInChildren = GetComponentsInChildren<UIButton>();
		m_childUIButtons = componentsInChildren;
		if (m_childUIButtons != null)
		{
			UIButton[] childUIButtons = m_childUIButtons;
			object obj2 = 0;
			while ((nint)obj2 < childUIButtons.Length)
			{
				childUIButtons[obj2].UpdateStartValues();
				obj2++;
			}
		}
		InstantHide();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIPopup)+20]");
		if ((nint)0 == 0)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugUIPopup)
			{
				return;
			}
		}
		DDebug.Log("Initialize", this);
	}

	private void LoadPresets()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899806EB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		UIPopupBehavior showBehavior = ShowBehavior;
		if (showBehavior.LoadSelectedPresetAtRuntime)
		{
			showBehavior.LoadPreset();
		}
		UIPopupBehavior hideBehavior = HideBehavior;
		if (hideBehavior.LoadSelectedPresetAtRuntime)
		{
			hideBehavior.LoadPreset();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Doozy.Engine.UI.UIPopup)+20]");
		if ((nint)0 == 0)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugUIPopup)
			{
				return;
			}
		}
		DDebug.Log("Load Presets", this);
	}

	private void StopHide()
	{
		if (m_hideCoroutine != null)
		{
			StopCoroutine(m_hideCoroutine);
			m_hideCoroutine = null;
			m_visibilityState = VisibilityState.NotVisible;
			VisibilityProgress = 0f;
			RectTransform rectTransform = base.RectTransform;
			UIAnimator.StopAnimations(rectTransform, AnimationType.Hide);
			DoozySettings instance = DoozySettings.Instance;
			if (instance.AutoDisableUIInteractions)
			{
				UIComponentBase<UIPopup>.EnableUIInteractions();
			}
		}
	}

	private void StopShow()
	{
		if (m_showCoroutine != null)
		{
			StopCoroutine(m_showCoroutine);
			m_showCoroutine = null;
			m_visibilityState = VisibilityState.Visible;
			VisibilityProgress = 1f;
			RectTransform rectTransform = base.RectTransform;
			UIAnimator.StopAnimations(rectTransform, AnimationType.Show);
			DoozySettings instance = DoozySettings.Instance;
			if (instance.AutoDisableUIInteractions)
			{
				UIComponentBase<UIPopup>.EnableUIInteractions();
			}
		}
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

	private void UpdateOverlayAlpha(float value)
	{
		if (HasOverlay)
		{
			UIContainer overlay = Overlay;
			if (overlay.Enabled)
			{
				overlay.CanvasGroup.alpha = value;
			}
		}
	}

	private void ReparentToTargetCanvas()
	{
		Transform transform = base.transform;
		UICanvas targetCanvas = GetTargetCanvas();
		Transform parent = targetCanvas.transform;
		transform.SetParent(parent, worldPositionStays: true);
		RectTransform rectTransform = base.RectTransform;
		RectTransformExtensions.FullScreen(rectTransform, resetScaleToOne: true);
	}

	private void ReparentToPopupCanvas()
	{
		Transform transform = base.transform;
		UICanvas popupOverlayCanvas = GetPopupOverlayCanvas();
		Transform parent = popupOverlayCanvas.transform;
		transform.SetParent(parent, worldPositionStays: true);
		RectTransform rectTransform = base.RectTransform;
		RectTransformExtensions.FullScreen(rectTransform, resetScaleToOne: true);
	}

	private IEnumerator TriggerShowInNextFrame(bool instantAction)
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
		_003CTriggerShowInNextFrame_003Ed__111 obj = null;
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
		_003CShowEnumerator_003Ed__112 obj = null;
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
		_003CHideEnumerator_003Ed__113 obj = null;
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
		_003CHideWithDelayEnumerator_003Ed__114 obj = null;
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

	private IEnumerator ExecuteShowSelectDeselectButtonEnumerator()
	{
		_003CExecuteShowSelectDeselectButtonEnumerator_003Ed__115 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private IEnumerator ExecuteHideDeselectButtonEnumerator()
	{
		_003CExecuteHideDeselectButtonEnumerator_003Ed__116 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public static UIPopup GetPopup(string popupName)
	{
		return UIPopupManager.GetPopup(popupName);
	}

	public static UICanvas GetPopupOverlayCanvas()
	{
		//IL_01c1->IL013c: Incompatible stack heights: 1 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899806F7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980697]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if ("PopupCanvas" != null)
		{
			string text = "PopupCanvas".TrimWhiteSpaceHelper(string.TrimType.Both);
			if (text != null && text._stringLength > 0)
			{
				UICanvas uICanvas = (UICanvas.DatabaseContains(text) ? UICanvas.GetUICanvas(text) : UICanvas.CreateUICanvas(text));
				if ((object)uICanvas != null)
				{
					Canvas canvas = uICanvas.Canvas;
					if ((object)canvas != null)
					{
						bool flag = ((UnityEngine.Object)canvas).m_CachedPtr == (IntPtr)0;
						Canvas.set_renderMode_Injected(((UnityEngine.Object)canvas).m_CachedPtr, RenderMode.ScreenSpaceOverlay);
						Canvas canvas2 = uICanvas.Canvas;
						if ((object)canvas2 != null)
						{
							bool flag2 = ((UnityEngine.Object)canvas2).m_CachedPtr == (IntPtr)0;
							Canvas.set_sortingOrder_Injected(((UnityEngine.Object)canvas2).m_CachedPtr, 10000);
							return uICanvas;
						}
					}
				}
			}
			else
			{
				DDebug.Log("You cannot search for an UICanvas without entering a 'canvasName'. The 'canvasName' you passed was an empty string. Returned null.");
			}
		}
		throw new NullReferenceException();
	}

	public static UICanvas GetTargetCanvas(PopupDisplayOn popupDisplayOn, string targetCanvasName)
	{
		if (popupDisplayOn == PopupDisplayOn.PopupCanvas)
		{
			return GetPopupOverlayCanvas();
		}
		return UICanvas.GetUICanvas(targetCanvasName);
	}

	public static bool HidePopup(string popupName, bool instantAction = false)
	{
		//IL_005f: Expected I, but got O
		//IL_02aa: Expected I4, but got O
		if (popupName != null && popupName._stringLength > 0 && AnyPopupVisible)
		{
			nint num = (nint)typeof(UIPopup);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rax_v6 (Il2CppClass<Doozy.Engine.UI.UIPopup>)+E4]");
			bool flag = (nint)0 != 0;
			List<UIPopup> visiblePopups = VisiblePopups;
			if (VisiblePopups != null)
			{
				bool result = false;
				List<UIPopup>.Enumerator enumerator = default(List<UIPopup>.Enumerator);
				if (enumerator.MoveNext())
				{
					UIPopup uIPopup = null;
					throw new NullReferenceException();
				}
				DoozySettings instance = DoozySettings.Instance;
				if ((object)instance != null)
				{
					if (instance.DebugUIPopup)
					{
						string message = "Hide PopupName: " + popupName;
						DDebug.Log(message);
					}
					return result;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	private static void RemoveHiddenFromVisiblePopups()
	{
		//IL_00a9: Expected O, but got I4
		//IL_0129: Expected O, but got I4
		RemoveNullsFromVisiblePopups();
		List<UIPopup> visiblePopups = VisiblePopups;
		bool flag = (nint)VisiblePopups < 0;
		int num = visiblePopups._size - 1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			List<UIPopup> visiblePopups2 = VisiblePopups;
			if (num >= visiblePopups2._size)
			{
				break;
			}
			UIPopup[] items = visiblePopups2._items;
			UIPopup uIPopup = items[num];
			object obj = uIPopup.m_visibilityState - 1;
			bool flag2 = (nint)obj < 0;
			if (uIPopup.m_visibilityState == VisibilityState.NotVisible)
			{
				flag2 = (nint)VisiblePopups < 0;
				VisiblePopups.RemoveAt(num);
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

	private static void RemoveNullsFromVisiblePopups()
	{
		//IL_0133: Expected O, but got I4
		List<UIPopup> visiblePopups = VisiblePopups;
		bool flag = (nint)VisiblePopups < 0;
		int num = visiblePopups._size - 1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			List<UIPopup> visiblePopups2 = VisiblePopups;
			if (num >= visiblePopups2._size)
			{
				break;
			}
			UIPopup[] items = visiblePopups2._items;
			UIPopup uIPopup = items[num];
			bool flag2;
			if ((object)items[num] != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdi_v5 (Doozy.Engine.UI.UIPopup)+10]");
				flag2 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdi_v5 (Doozy.Engine.UI.UIPopup)+10]");
				if ((nint)0 != 0)
				{
					goto IL_011a;
				}
			}
			flag2 = (nint)VisiblePopups < 0;
			VisiblePopups.RemoveAt(num);
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

	public UIPopup()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998068E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		CanvasName = "MasterCanvas";
		HideBehavior = new UIPopupBehavior(AnimationType.Hide);
		HideOnBackButton = true;
		HideOnClickContainer = true;
		ProgressEvent onInverseVisibilityChanged = new ProgressEvent();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
		OnInverseVisibilityChanged = onInverseVisibilityChanged;
		ProgressEvent onVisibilityChanged = new ProgressEvent();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
		OnVisibilityChanged = onVisibilityChanged;
		ShowBehavior = new UIPopupBehavior(AnimationType.Show);
		UseOverlay = true;
		m_visibilityProgress = 1f;
		base._002Ector();
	}

	static UIPopup()
	{
		Action<UIPopup, AnimationType> onUIPopupAction = delegate
		{
		};
		OnUIPopupAction = onUIPopupAction;
		List<UIPopup> visiblePopups = new List<UIPopup>();
		VisiblePopups = visiblePopups;
	}

	private void _003CShowEnumerator_003Eb__112_0()
	{
		Hide();
	}
}
