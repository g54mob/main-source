using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class LanguageChangeLayoutUpdater : MonoBehaviour
{
	private sealed class _003CUpdateLayoutAtEndOfFrame_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LanguageChangeLayoutUpdater _003C_003E4__this;

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
		public _003CUpdateLayoutAtEndOfFrame_003Ed__5(int _003C_003E1__state)
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
			LanguageChangeLayoutUpdater languageChangeLayoutUpdater = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForEndOfFrame();
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				languageChangeLayoutUpdater.UpdateLayout();
				return false;
			}
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

	private RectTransform rectTransform;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
	}

	private void Start()
	{
		LocalizationManager.Instance.OnLanguageChanged += UpdateLayoutDelayed;
	}

	private void OnEnable()
	{
		UpdateLayout();
	}

	private void UpdateLayoutDelayed()
	{
		if (base.gameObject.activeInHierarchy)
		{
			StartCoroutine(UpdateLayoutAtEndOfFrame());
		}
		else
		{
			UpdateLayout();
		}
	}

	private IEnumerator UpdateLayoutAtEndOfFrame()
	{
		return new _003CUpdateLayoutAtEndOfFrame_003Ed__5(0)
		{
			_003C_003E4__this = this
		};
	}

	private void UpdateLayout()
	{
		LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
	}

	private void OnDestroy()
	{
		if ((bool)LocalizationManager.Instance)
		{
			LocalizationManager.Instance.OnLanguageChanged -= UpdateLayoutDelayed;
		}
	}
}
