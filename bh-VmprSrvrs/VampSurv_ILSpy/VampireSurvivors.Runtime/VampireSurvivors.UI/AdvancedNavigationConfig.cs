using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class AdvancedNavigationConfig : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
{
	private sealed class _003CWaitAFrame_003Ed__8(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public AdvancedNavigationConfig _003C_003E4__this;

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
				_003C_003E4__this.UpdateConfig();
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

	private Selectable _selectable;

	private List<Selectable> _OnUp;

	private List<Selectable> _OnDown;

	private List<Selectable> _OnLeft;

	private List<Selectable> _OnRight;

	private unsafe void Awake()
	{
		//IL_0014: Expected O, but got Ref
		Selectable component = GetComponent<Selectable>();
		_selectable = component;
		object obj = default(object);
		_selectable.navigation = (Navigation)(&obj);
	}

	private unsafe void UpdateConfig()
	{
		//IL_02b7: Expected O, but got Ref
		if ((object)_selectable != null && _OnUp != null)
		{
			List<Selectable> list = _OnUp;
			List<Selectable>.Enumerator enumerator = default(List<Selectable>.Enumerator);
			while (enumerator.MoveNext())
			{
				Component component = null;
			}
			if (_OnDown != null)
			{
				list = _OnDown;
				List<Selectable>.Enumerator enumerator2 = default(List<Selectable>.Enumerator);
				while (enumerator2.MoveNext())
				{
					Component component2 = null;
				}
				if (_OnLeft != null)
				{
					list = _OnLeft;
					List<Selectable>.Enumerator enumerator3 = default(List<Selectable>.Enumerator);
					while (enumerator3.MoveNext())
					{
						Component component3 = null;
					}
					if (_OnRight != null)
					{
						list = _OnRight;
						List<Selectable>.Enumerator enumerator4 = default(List<Selectable>.Enumerator);
						while (enumerator4.MoveNext())
						{
							Component component4 = null;
						}
						if ((object)_selectable != null)
						{
							_selectable.navigation = (Navigation)(&list);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void OnSelect(BaseEventData eventData)
	{
		_003CWaitAFrame_003Ed__8 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator WaitAFrame()
	{
		_003CWaitAFrame_003Ed__8 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void OnDeselect(BaseEventData eventData)
	{
	}

	public AdvancedNavigationConfig()
	{
		List<Selectable> onUp = new List<Selectable>();
		_OnUp = onUp;
		List<Selectable> onDown = new List<Selectable>();
		_OnDown = onDown;
		List<Selectable> onLeft = new List<Selectable>();
		_OnLeft = onLeft;
		List<Selectable> onRight = new List<Selectable>();
		_OnRight = onRight;
	}
}
