using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WishlistButtonAnimator : MonoBehaviour
{
	private sealed class _003CTriggerAnimation_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WishlistButtonAnimator _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CTriggerAnimation_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			WishlistButtonAnimator wishlistButtonAnimator = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForSeconds(wishlistButtonAnimator.startInterval);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				break;
			case 2:
				_003C_003E1__state = -1;
				break;
			}
			if (wishlistButtonAnimator.gameObject.activeInHierarchy)
			{
				wishlistButtonAnimator.wishlistAnimator.SetTrigger("rotate");
				_003C_003E2__current = new WaitForSeconds(UnityEngine.Random.Range(wishlistButtonAnimator.randomInterval.x, wishlistButtonAnimator.randomInterval.y));
				_003C_003E1__state = 2;
				return true;
			}
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
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	private float startInterval = 1f;

	[SerializeField]
	private Vector2 randomInterval;

	private Animator wishlistAnimator;

	private void OnEnable()
	{
		wishlistAnimator = GetComponent<Animator>();
		StartCoroutine(TriggerAnimation());
	}

	private IEnumerator TriggerAnimation()
	{
		return new _003CTriggerAnimation_003Ed__4(0)
		{
			_003C_003E4__this = this
		};
	}
}
