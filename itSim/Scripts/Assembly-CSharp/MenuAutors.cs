using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MenuAutors : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimAutorMenu_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MenuAutors _003C_003E4__this;

		public string menuName;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CAnimAutorMenu_003Ed__13(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CAnimLicensesMenu_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MenuAutors _003C_003E4__this;

		public string menuName;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CAnimLicensesMenu_003Ed__15(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CAnimMenu_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MenuAutors _003C_003E4__this;

		public string menuName;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CAnimMenu_003Ed__11(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCanvasGroupFadeAnimation_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CanvasGroup canvasGroup;

		public float time;

		public TypeAnim animationType;

		public float targetAlpha;

		private float _003CstartAlpha_003E5__2;

		private float _003Celapsed_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCanvasGroupFadeAnimation_003Ed__16(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public float speedAnim;

	[Header("Main")]
	public string nowOpen;

	public bool isAnim;

	public MenuAutorsWindow[] Menu;

	[Header("Authors")]
	public string nowAutorsOpen;

	public bool isAutorsAnim;

	public MenuAutorsWindow[] AutorsMenu;

	[Header("Licenses")]
	public string nowLicensesOpen;

	public bool isLicensesAnim;

	public MenuAutorsWindow[] LicensesMenu;

	public void OpenMenu(string menuName)
	{
	}

	[IteratorStateMachine(typeof(_003CAnimMenu_003Ed__11))]
	private IEnumerator AnimMenu(string menuName)
	{
		return null;
	}

	public void OpenAutorMenu(string menuName)
	{
	}

	[IteratorStateMachine(typeof(_003CAnimAutorMenu_003Ed__13))]
	private IEnumerator AnimAutorMenu(string menuName)
	{
		return null;
	}

	public void OpenLicensesMenu(string menuName)
	{
	}

	[IteratorStateMachine(typeof(_003CAnimLicensesMenu_003Ed__15))]
	private IEnumerator AnimLicensesMenu(string menuName)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCanvasGroupFadeAnimation_003Ed__16))]
	public IEnumerator CanvasGroupFadeAnimation(CanvasGroup canvasGroup, float targetAlpha, float time, TypeAnim animationType)
	{
		return null;
	}
}
