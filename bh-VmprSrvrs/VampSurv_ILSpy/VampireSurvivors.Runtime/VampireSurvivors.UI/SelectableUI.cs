using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;

namespace VampireSurvivors.UI;

public class SelectableUI : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
{
	public enum SelectableType
	{
		BUTTON,
		ITEM
	}

	public delegate void OnSelection(RectTransform rTrans);

	public delegate void OnSetSelectorVisibility(bool b);

	public delegate void OnSelectionChanged();

	private sealed class _003CDelayedColourRefresh_003Ed__43(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public SelectableUI _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_007f: Expected I4, but got I8
			//IL_00c2: Expected I4, but got O
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
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				_003C_003E4__this.UpdateAlternateSelectionIconColour();
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

	private sealed class _003CWaitForEndOfFrameAndReselect_003Ed__51(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public SelectableUI _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_00c9: Expected I4, but got O
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
				if ((object)_003C_003E4__this != null)
				{
					Selectable component = _003C_003E4__this.GetComponent<Selectable>();
					if ((object)component != null)
					{
						component.Select();
						goto IL_00eb;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_00eb;
			IL_00eb:
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

	private sealed class _003CWaitForEndOfFrameAndReselectPrevious_003Ed__52(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_0106: Expected I4, but got O
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
				SelectableUI currentSelectableUI = CurrentSelectableUI;
				if ((object)CurrentSelectableUI != null && ((UnityEngine.Object)currentSelectableUI).m_CachedPtr != (IntPtr)0)
				{
					if ((object)CurrentSelectableUI != null)
					{
						Selectable component = CurrentSelectableUI.GetComponent<Selectable>();
						if ((object)component != null)
						{
							component.Select();
							goto IL_0128;
						}
					}
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
			}
			goto IL_0128;
			IL_0128:
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

	private sealed class _003CWaitFrame_003Ed__46(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public SelectableUI _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_0130: Expected I4, but got O
			Component component = _003C_003E4__this;
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
				if ((object)_003C_003E4__this == null)
				{
					goto IL_0122;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdi_v1 (UnityEngine.Component)+51]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdi_v1 (UnityEngine.Component)+50]");
					if ((nint)0 != 0)
					{
						EventSystem current = EventSystem.current;
						GameObject gameObject = _003C_003E4__this.gameObject;
						if ((object)current == null)
						{
							goto IL_0122;
						}
						current.SetSelectedGameObject(gameObject);
					}
				}
			}
			return false;
			IL_0122:
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

	private bool _ShowSelector;

	private bool _CanBeSelectedThroughMouse;

	private RectTransform _AlternateSelectionIcon;

	private bool _IgnoreNavigation;

	private bool ForceStupidDumbScrollViewMaskingFix;

	private bool _ShouldUpdatePositionWhenForcingDumbFix;

	private bool _ShouldUpdateSizeWhenForcingDumbFix;

	private bool _ShouldReParentToCanvasWhenFixingMasking;

	public SelectableType selectionType;

	private static OnSelection m_UIButtonSelected;

	private static OnSelection m_UIItemSelected;

	private static OnSelection m_UIItemDestroyed;

	public static SelectableUI CurrentSelectableUI;

	private OnSelectionChanged m_OnBecameSelected;

	private OnSelectionChanged m_OnBecameDeselected;

	private static OnSetSelectorVisibility m_SetSelectorVisibility;

	public bool ReselectIfDefaultSelectedOnPage;

	public bool IsDefaultSelectedOnPage;

	private bool isSelected;

	protected Selectable _selectable;

	private Navigation _originalNavigation;

	private Rewired.Player _player;

	private Transform _initialParent;

	private bool previousMPState;

	public static event OnSelection UIButtonSelected
	{
		add
		{
			Delegate obj = SelectableUI.m_UIButtonSelected;
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(OnSelection);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				bool flag3 = (object)obj == SelectableUI.m_UIButtonSelected;
				Delegate obj4;
				if ((object)obj == SelectableUI.m_UIButtonSelected)
				{
					SelectableUI.m_UIButtonSelected = (OnSelection)obj3;
					obj4 = obj;
				}
				else
				{
					obj4 = SelectableUI.m_UIButtonSelected;
				}
				Delegate obj5 = obj;
				if (!flag3)
				{
					obj5 = obj4;
				}
				bool flag4 = (object)obj5 != obj;
				obj = obj5;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			Delegate obj = SelectableUI.m_UIButtonSelected;
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(OnSelection);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				bool flag3 = (object)obj == SelectableUI.m_UIButtonSelected;
				Delegate obj4;
				if ((object)obj == SelectableUI.m_UIButtonSelected)
				{
					SelectableUI.m_UIButtonSelected = (OnSelection)obj3;
					obj4 = obj;
				}
				else
				{
					obj4 = SelectableUI.m_UIButtonSelected;
				}
				Delegate obj5 = obj;
				if (!flag3)
				{
					obj5 = obj4;
				}
				bool flag4 = (object)obj5 != obj;
				obj = obj5;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public static event OnSelection UIItemSelected
	{
		add
		{
			//IL_004f: Expected I, but got O
			//IL_0065: Expected O, but got I
			Delegate obj = SelectableUI.m_UIItemSelected;
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(OnSelection);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				nint num = (nint)typeof(SelectableUI);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v5 (Il2CppClass<VampireSurvivors.UI.SelectableUI>)+B8]");
				object obj4 = (nint)0 + (nint)8;
				bool flag3 = obj == obj4;
				Delegate obj5;
				if (obj == obj4)
				{
					obj4 = obj3;
					obj5 = obj;
				}
				else
				{
					obj5 = (Delegate)obj4;
				}
				Delegate obj6 = obj;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj;
				obj = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_004f: Expected I, but got O
			//IL_0065: Expected O, but got I
			Delegate obj = SelectableUI.m_UIItemSelected;
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(OnSelection);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				nint num = (nint)typeof(SelectableUI);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v5 (Il2CppClass<VampireSurvivors.UI.SelectableUI>)+B8]");
				object obj4 = (nint)0 + (nint)8;
				bool flag3 = obj == obj4;
				Delegate obj5;
				if (obj == obj4)
				{
					obj4 = obj3;
					obj5 = obj;
				}
				else
				{
					obj5 = (Delegate)obj4;
				}
				Delegate obj6 = obj;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj;
				obj = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public static event OnSelection UIItemDestroyed
	{
		add
		{
			//IL_004f: Expected I, but got O
			//IL_0065: Expected O, but got I
			Delegate obj = SelectableUI.m_UIItemDestroyed;
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(OnSelection);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				nint num = (nint)typeof(SelectableUI);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v5 (Il2CppClass<VampireSurvivors.UI.SelectableUI>)+B8]");
				object obj4 = (nint)0 + (nint)16;
				bool flag3 = obj == obj4;
				Delegate obj5;
				if (obj == obj4)
				{
					obj4 = obj3;
					obj5 = obj;
				}
				else
				{
					obj5 = (Delegate)obj4;
				}
				Delegate obj6 = obj;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj;
				obj = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_004f: Expected I, but got O
			//IL_0065: Expected O, but got I
			Delegate obj = SelectableUI.m_UIItemDestroyed;
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(OnSelection);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				nint num = (nint)typeof(SelectableUI);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v5 (Il2CppClass<VampireSurvivors.UI.SelectableUI>)+B8]");
				object obj4 = (nint)0 + (nint)16;
				bool flag3 = obj == obj4;
				Delegate obj5;
				if (obj == obj4)
				{
					obj4 = obj3;
					obj5 = obj;
				}
				else
				{
					obj5 = (Delegate)obj4;
				}
				Delegate obj6 = obj;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj;
				obj = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public event OnSelectionChanged OnBecameSelected
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 64;
			Delegate obj2 = this.m_OnBecameSelected;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnSelectionChanged);
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
			object obj = this + 64;
			Delegate obj2 = this.m_OnBecameSelected;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnSelectionChanged);
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

	public event OnSelectionChanged OnBecameDeselected
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 72;
			Delegate obj2 = this.m_OnBecameDeselected;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnSelectionChanged);
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
			object obj = this + 72;
			Delegate obj2 = this.m_OnBecameDeselected;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnSelectionChanged);
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

	public static event OnSetSelectorVisibility SetSelectorVisibility
	{
		add
		{
			//IL_004f: Expected I, but got O
			//IL_0065: Expected O, but got I
			Delegate obj = SelectableUI.m_SetSelectorVisibility;
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(OnSetSelectorVisibility);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				nint num = (nint)typeof(SelectableUI);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v5 (Il2CppClass<VampireSurvivors.UI.SelectableUI>)+B8]");
				object obj4 = (nint)0 + (nint)32;
				bool flag3 = obj == obj4;
				Delegate obj5;
				if (obj == obj4)
				{
					obj4 = obj3;
					obj5 = obj;
				}
				else
				{
					obj5 = (Delegate)obj4;
				}
				Delegate obj6 = obj;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj;
				obj = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_004f: Expected I, but got O
			//IL_0065: Expected O, but got I
			Delegate obj = SelectableUI.m_SetSelectorVisibility;
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(OnSetSelectorVisibility);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				nint num = (nint)typeof(SelectableUI);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v5 (Il2CppClass<VampireSurvivors.UI.SelectableUI>)+B8]");
				object obj4 = (nint)0 + (nint)32;
				bool flag3 = obj == obj4;
				Delegate obj5;
				if (obj == obj4)
				{
					obj4 = obj3;
					obj5 = obj;
				}
				else
				{
					obj5 = (Delegate)obj4;
				}
				Delegate obj6 = obj;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj;
				obj = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	protected virtual void Awake()
	{
		Selectable selectable = _selectable;
		if ((object)_selectable == null || ((UnityEngine.Object)selectable).m_CachedPtr == (IntPtr)0)
		{
			Selectable component = GetComponent<Selectable>();
			_selectable = component;
		}
		Selectable selectable2 = _selectable;
		_originalNavigation = selectable2.m_Navigation;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v7 (UnityEngine.UI.Selectable)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v7 (UnityEngine.UI.Selectable)+48]");
		_ = 0;
		ReInput.PlayerHelper players = ReInput.players;
		Rewired.Player player = players.GetPlayer(0);
		_player = player;
	}

	public bool IsSelected()
	{
		return isSelected;
	}

	protected unsafe virtual void OnEnable()
	{
		//IL_01d7: Expected O, but got Ref
		//IL_023b: Expected O, but got I4
		//IL_0255: Expected O, but got I4
		_003CWaitFrame_003Ed__46 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
		RectTransform alternateSelectionIcon = _AlternateSelectionIcon;
		if ((object)_AlternateSelectionIcon != null && ((UnityEngine.Object)alternateSelectionIcon).m_CachedPtr != (IntPtr)0)
		{
			EventSystem current = EventSystem.current;
			GameObject currentSelected = current.m_CurrentSelected;
			GameObject gameObject = base.gameObject;
			bool flag = (object)gameObject == null;
			bool flag2 = (object)current.m_CurrentSelected == null;
			object obj2 = flag2 & flag;
			bool flag3 = obj2 == null;
			object obj3 = !flag3;
			if (obj3 == null)
			{
				bool flag4;
				if ((object)gameObject != null)
				{
					if ((object)current.m_CurrentSelected != null)
					{
						object obj4 = (object)current.m_CurrentSelected - (object)gameObject;
						flag4 = obj4 == null;
					}
					else
					{
						flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					}
				}
				else
				{
					flag4 = ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0;
				}
				if (!flag4)
				{
					goto IL_0177;
				}
			}
			GameObject gameObject2 = _AlternateSelectionIcon.gameObject;
			gameObject2.SetActive(value: true);
			UpdateAlternateSelectionIconColour();
			_003CDelayedColourRefresh_003Ed__43 obj5 = null;
			obj5._003C_003E1__state = 0;
			obj5._003C_003E4__this = this;
			Coroutine coroutine2 = StartCoroutine(obj5);
		}
		goto IL_0177;
		IL_0177:
		if (!_IgnoreNavigation)
		{
			Selectable selectable = _selectable;
			if ((nint)selectable.m_Navigation != 4)
			{
				object obj6 = default(object);
				selectable.navigation = (Navigation)(&obj6);
			}
		}
	}

	private IEnumerator DelayedColourRefresh()
	{
		_003CDelayedColourRefresh_003Ed__43 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public unsafe void UpdateAlternateSelectionIconColour()
	{
		//IL_0035: Expected F4, but got I
		//IL_00a1: Expected O, but got I4
		//IL_00aa: Expected O, but got I4
		//IL_00c5: Expected O, but got Ref
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		int localPlayerCount = MultiplayerManager.s_instance.GetLocalPlayerCount();
		bool flag = localPlayerCount <= 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		float num = 0f;
		if (!flag)
		{
			num = MultiplayerManager.s_instance.GetUIControlColour().r;
		}
		GameObject gameObject = _AlternateSelectionIcon.gameObject;
		Image[] componentsInChildren = gameObject.GetComponentsInChildren<Image>(includeInactive: true);
		object obj = 0;
		object obj2 = 0;
		float num2 = default(float);
		while ((nint)obj2 < componentsInChildren.Length)
		{
			componentsInChildren[obj].color = (Color)(&num);
			MultiplayerManager s_instance = MultiplayerManager.s_instance;
			CoopConfig coopConfig = s_instance._coopConfig;
			componentsInChildren[obj].material = coopConfig._navigationUIMaterial;
			obj++;
			num = num2;
			obj2 = obj;
		}
	}

	protected unsafe virtual void OnDisable()
	{
		//IL_00bd: Expected O, but got Ref
		RectTransform alternateSelectionIcon = _AlternateSelectionIcon;
		if ((object)_AlternateSelectionIcon != null && ((UnityEngine.Object)alternateSelectionIcon).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _AlternateSelectionIcon.gameObject;
			gameObject.SetActive(value: false);
		}
		if (!_IgnoreNavigation)
		{
			Selectable selectable = _selectable;
			if ((nint)selectable.m_Navigation != 4)
			{
				object obj = default(object);
				selectable.navigation = (Navigation)(&obj);
			}
		}
	}

	private IEnumerator WaitFrame()
	{
		_003CWaitFrame_003Ed__46 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void OnSelect(BaseEventData eventData)
	{
		//IL_004c: Expected I, but got O
		//IL_005c: Expected O, but got I
		//IL_0353: Expected O, but got I4
		//IL_0305: Expected O, but got I4
		//IL_030a->IL030a: Incompatible stack heights: 1 vs 0
		bool flag = this.m_OnBecameSelected == null;
		IsDefaultSelectedOnPage = true;
		if (!flag)
		{
			OnSelectionChanged onBecameSelected = this.m_OnBecameSelected;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v45.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		if (selectionType == SelectableType.BUTTON)
		{
			Rewired.Player player = _player;
			Mouse mouse = player.controllers.Mouse;
			nint num = (nint)mouse;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v461 @ r8_v28 (Il2CppClass<Rewired.Mouse>)+1D8]");
			object obj = 0;
			if (mouse.GetButtonDown(0))
			{
				if (!_CanBeSelectedThroughMouse)
				{
					_003CWaitForEndOfFrameAndReselectPrevious_003Ed__52 obj2 = null;
					obj2._003C_003E1__state = 0;
					Coroutine coroutine = StartCoroutine(obj2);
				}
				GameObject gameObject = base.gameObject;
				string text = ((UnityEngine.Object)gameObject).GetName();
				string message = "Not changing selectable because mouse is down : " + text;
				Debug.Log(message);
				return;
			}
		}
		RectTransform component = GetComponent<RectTransform>();
		RectTransform alternateSelectionIcon = _AlternateSelectionIcon;
		if ((object)_AlternateSelectionIcon != null && ((UnityEngine.Object)alternateSelectionIcon).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject2 = _AlternateSelectionIcon.gameObject;
			gameObject2.SetActive(value: true);
			UpdateAlternateSelectionIconColour();
			if (ForceStupidDumbScrollViewMaskingFix)
			{
				RectTransform component2 = GetComponent<RectTransform>();
				LayoutRebuilder.ForceRebuildLayoutImmediate(component2);
				if (_ShouldUpdateSizeWhenForcingDumbFix)
				{
					RectTransform component3 = GetComponent<RectTransform>();
					Vector2 sizeDelta = component3.sizeDelta;
					_AlternateSelectionIcon.sizeDelta = sizeDelta;
				}
				Transform transform = _AlternateSelectionIcon.transform;
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				GameObject gameObject3 = _AlternateSelectionIcon.gameObject;
				LayoutElement layoutElement = gameObject3.AddComponent<LayoutElement>();
				layoutElement.ignoreLayout = true;
				Transform transform2 = _AlternateSelectionIcon.transform;
				Transform parent;
				if (_ShouldReParentToCanvasWhenFixingMasking)
				{
					Canvas canvas = UIHelper.Canvas;
					parent = canvas.transform;
				}
				else
				{
					Transform transform3 = base.transform;
					parent = transform3.parent;
				}
				transform2.SetParent(parent, worldPositionStays: true);
				Transform transform4 = _AlternateSelectionIcon.transform;
				transform4.SetAsLastSibling();
				object obj = 0;
			}
			OnSetSelectorVisibility setSelectorVisibility = SelectableUI.m_SetSelectorVisibility;
			if (SelectableUI.m_SetSelectorVisibility != null)
			{
				bool flag3 = _AlternateSelectionIcon;
				object obj3 = (flag3 ? 1 : 0) ^ 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v709.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
		else
		{
			CurrentSelectableUI = this;
			if (SelectableUI.m_SetSelectorVisibility != null)
			{
				OnSetSelectorVisibility setSelectorVisibility2 = SelectableUI.m_SetSelectorVisibility;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v690.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
		OnSelection onSelection = ((selectionType == SelectableType.BUTTON) ? SelectableUI.m_UIButtonSelected : SelectableUI.m_UIItemSelected);
		if (onSelection != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v808.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		OnSelected();
		CurrentSelectableUI = this;
	}

	protected virtual void OnDestroy()
	{
		if (isSelected)
		{
			OnSelection uIItemDestroyed = SelectableUI.m_UIItemDestroyed;
			if (SelectableUI.m_UIItemDestroyed != null)
			{
				RectTransform component = GetComponent<RectTransform>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v47.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	protected virtual void OnSelected()
	{
	}

	public void OnDeselect(BaseEventData eventData)
	{
		IsDefaultSelectedOnPage = false;
		SelectableUI currentSelectableUI = CurrentSelectableUI;
		if ((object)CurrentSelectableUI == null || ((UnityEngine.Object)currentSelectableUI).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if (this.m_OnBecameDeselected != null)
		{
			OnSelectionChanged onBecameDeselected = this.m_OnBecameDeselected;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v241.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		if (selectionType == SelectableType.ITEM)
		{
			SelectableUI currentSelectableUI2 = CurrentSelectableUI;
			if (currentSelectableUI2.selectionType == SelectableType.BUTTON)
			{
				Rewired.Player player = _player;
				Mouse mouse = player.controllers.Mouse;
				if (mouse.GetButtonDown(0))
				{
					_003CWaitForEndOfFrameAndReselect_003Ed__51 obj = null;
					obj._003C_003E1__state = 0;
					obj._003C_003E4__this = this;
					Coroutine coroutine = StartCoroutine(obj);
					return;
				}
			}
		}
		RectTransform alternateSelectionIcon = _AlternateSelectionIcon;
		if ((object)_AlternateSelectionIcon != null && ((UnityEngine.Object)alternateSelectionIcon).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _AlternateSelectionIcon.gameObject;
			gameObject.SetActive(value: false);
			if (ForceStupidDumbScrollViewMaskingFix)
			{
				Transform transform = _AlternateSelectionIcon.transform;
				Transform parent = base.transform;
				transform.SetParent(parent, worldPositionStays: true);
				Transform transform2 = _AlternateSelectionIcon.transform;
				transform2.SetAsLastSibling();
				LayoutElement component = _AlternateSelectionIcon.GetComponent<LayoutElement>();
				UnityEngine.Object.Destroy(component);
			}
		}
		OnDeselected();
	}

	private IEnumerator WaitForEndOfFrameAndReselect()
	{
		_003CWaitForEndOfFrameAndReselect_003Ed__51 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private static IEnumerator WaitForEndOfFrameAndReselectPrevious()
	{
		_003CWaitForEndOfFrameAndReselectPrevious_003Ed__52 obj = null;
		obj._003C_003E1__state = 0;
		return obj;
	}

	protected virtual void OnDeselected()
	{
	}

	public void Deselect()
	{
		OnSetSelectorVisibility setSelectorVisibility = SelectableUI.m_SetSelectorVisibility;
		if (SelectableUI.m_SetSelectorVisibility != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v29.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public void Update()
	{
		//IL_01a4: Expected O, but got I4
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected I4, but got Unknown
		//IL_021f: Expected O, but got I4
		//IL_0269: Expected O, but got I4
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected I4, but got Unknown
		//IL_03bd->IL032e: Incompatible stack heights: 1 vs 0
		//IL_0388->IL0333: Incompatible stack heights: 2 vs 0
		RectTransform alternateSelectionIcon = _AlternateSelectionIcon;
		if ((object)_AlternateSelectionIcon == null || ((UnityEngine.Object)alternateSelectionIcon).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Vector3 value = default(Vector3);
		if (ForceStupidDumbScrollViewMaskingFix)
		{
			if (_ShouldUpdatePositionWhenForcingDumbFix)
			{
				RectTransform component = GetComponent<RectTransform>();
				Rect worldRect = Extensions.GetWorldRect(component);
				if ((object)_AlternateSelectionIcon == null)
				{
					goto IL_02f3;
				}
				Transform transform = _AlternateSelectionIcon.transform;
				bool flag = (object)transform == null;
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			}
			if (!_ShouldUpdateSizeWhenForcingDumbFix)
			{
				goto IL_014b;
			}
			RectTransform component2 = GetComponent<RectTransform>();
			if ((object)component2 != null)
			{
				Vector2 sizeDelta = component2.sizeDelta;
				if ((object)_AlternateSelectionIcon != null)
				{
					_AlternateSelectionIcon.sizeDelta = sizeDelta;
					goto IL_014b;
				}
			}
			goto IL_02f3;
		}
		goto IL_03db;
		IL_02f3:
		throw new NullReferenceException();
		IL_03db:
		if (MultiplayerManager.s_instance != null)
		{
			int localPlayerCount = MultiplayerManager.s_instance.GetLocalPlayerCount();
			object obj = localPlayerCount - 1;
			int num = localPlayerCount ^ 1;
			int num2 = localPlayerCount ^ obj;
			int num3 = num & num2;
			bool flag3 = num3 < 0;
			bool flag4 = (nint)obj < 0;
			bool flag5 = obj == null;
			bool flag6 = flag4 == flag3;
			bool flag7 = !flag5;
			object obj2 = flag7 & flag6;
			if ((nint)obj2 != (previousMPState ? 1 : 0))
			{
				UpdateAlternateSelectionIconColour();
			}
			if (MultiplayerManager.s_instance != null)
			{
				int localPlayerCount2 = MultiplayerManager.s_instance.GetLocalPlayerCount();
				object obj3 = localPlayerCount2 - 1;
				int num4 = localPlayerCount2 ^ 1;
				int num5 = localPlayerCount2 ^ obj3;
				int num6 = num4 & num5;
				bool flag8 = num6 < 0;
				bool flag9 = (nint)obj3 < 0;
				bool flag10 = obj3 == null;
				bool flag11 = flag9 == flag8;
				bool flag12 = !flag10;
				bool flag13 = flag12 & flag11;
				previousMPState = flag13;
				return;
			}
		}
		goto IL_02f3;
		IL_014b:
		if ((object)_AlternateSelectionIcon == null)
		{
			goto IL_02f3;
		}
		Transform transform2 = _AlternateSelectionIcon.transform;
		bool flag14 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
		goto IL_03db;
	}

	public SelectableUI()
	{
		//IL_0036: Expected I, but got O
		_ShowSelector = true;
		_ShouldUpdatePositionWhenForcingDumbFix = true;
		ReselectIfDefaultSelectedOnPage = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
