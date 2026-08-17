using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class OptionsPage : BaseUIPage
{
	private sealed class _003CFrameDelay_003Ed__4(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public OptionsPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_0359: Expected I4, but got O
			//IL_00b7: Expected O, but got I
			//IL_00ed: Expected O, but got I
			//IL_0101: Expected O, but got I
			//IL_0369: Expected O, but got I
			//IL_0193: Expected O, but got I
			BaseUIPage baseUIPage = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			GameObject firstTab;
			GameObject gameObject;
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rsi_v1 (VampireSurvivors.UI.BaseUIPage)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rsi_v1 (VampireSurvivors.UI.BaseUIPage)+E8]");
						((OptionsController)0).Initialize();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rsi_v1 (VampireSurvivors.UI.BaseUIPage)+E8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rsi_v1 (VampireSurvivors.UI.BaseUIPage)+E8]");
							firstTab = ((OptionsController)0).GetFirstTab();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rsi_v1 (VampireSurvivors.UI.BaseUIPage)+E8]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rsi_v1 (VampireSurvivors.UI.BaseUIPage)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rbx_v4+B8]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rbx_v4+B8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v9+18]");
									if ((nint)0 <= (nint)0)
									{
										gameObject = null;
										goto IL_03a3;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v9+18]");
									if ((nint)0 > (nint)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v9+10]");
										object obj3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rax_v9+10]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v59+20]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
												GameObject gameObject2 = default(GameObject);
												gameObject = gameObject2;
												goto IL_03a3;
											}
										}
									}
									else
									{
										System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
									}
								}
							}
						}
					}
				}
				goto IL_034b;
			}
			return false;
			IL_03a3:
			bool flag = (object)firstTab == null;
			Selectable left = null;
			if (!flag)
			{
				bool flag2 = ((UnityEngine.Object)firstTab).m_CachedPtr == (IntPtr)0;
				left = null;
				if (!flag2)
				{
					Selectable component = firstTab.GetComponent<Selectable>();
					left = component;
				}
			}
			bool flag3 = (object)gameObject == null;
			Selectable selectable = null;
			if (!flag3)
			{
				bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				selectable = null;
				if (!flag4)
				{
					Selectable component2 = gameObject.GetComponent<Selectable>();
					selectable = component2;
				}
			}
			Selectable right = default(Selectable);
			_003C_003E4__this.ForceBackButtonNavigation(null, selectable, left, right);
			if ((object)selectable != null && ((UnityEngine.Object)selectable).m_CachedPtr != (IntPtr)0)
			{
				selectable.Select();
			}
			if ((object)BackButtonController.Instance != null)
			{
				Selectable component3 = BackButtonController.Instance.GetComponent<Selectable>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rsi_v1 (VampireSurvivors.UI.BaseUIPage)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B85540");
					return false;
				}
			}
			goto IL_034b;
			IL_034b:
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

	private TextMeshProUGUI LanguageButtonName;

	private OptionsController _Controller;

	protected override void OnShowStart(GameObject g)
	{
		base.OnShowStart(g);
		_003CFrameDelay_003Ed__4 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	protected override void OnHideStart(GameObject g)
	{
		ResetBackButtonNavigation();
	}

	private IEnumerator FrameDelay()
	{
		_003CFrameDelay_003Ed__4 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	protected override void OnHideFinish(GameObject g)
	{
		base.OnHideFinish(g);
		_Controller.ClearAll();
	}

	private void OnEnable()
	{
		RectTransform component = GetComponent<RectTransform>();
		LayoutRebuilder.ForceRebuildLayoutImmediate(component);
	}
}
