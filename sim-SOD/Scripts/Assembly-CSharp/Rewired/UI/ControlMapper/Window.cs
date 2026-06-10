using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Rewired.UI.ControlMapper
{
	[AddComponentMenu(null)]
	[RequireComponent(typeof(CanvasGroup))]
	public class Window : MonoBehaviour
	{
		public class Timer
		{
			private bool _started;

			private float end;

			public bool started => false;

			public bool finished => false;

			public float remaining => 0f;

			public void Start(float length)
			{
			}

			public void Stop()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003COnEnableAsync_003Ed__64 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Window _003C_003E4__this;

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
			public _003COnEnableAsync_003Ed__64(int _003C_003E1__state)
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

		public Image backgroundImage;

		public GameObject content;

		private bool _initialized;

		private int _id;

		private RectTransform _rectTransform;

		private TMP_Text _titleText;

		private List<TMP_Text> _contentText;

		private GameObject _defaultUIElement;

		private Action<int> _updateCallback;

		private Func<int, bool> _isFocusedCallback;

		private Timer _timer;

		private CanvasGroup _canvasGroup;

		public UnityAction cancelCallback;

		private GameObject lastUISelection;

		public bool hasFocus => false;

		public int id => 0;

		public RectTransform rectTransform => null;

		public TMP_Text titleText => null;

		public List<TMP_Text> contentText => null;

		public GameObject defaultUIElement
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Action<int> updateCallback
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Timer timer => null;

		public int width
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int height
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected bool initialized => false;

		private void OnEnable()
		{
		}

		protected virtual void Update()
		{
		}

		public virtual void Initialize(int id, Func<int, bool> isFocusedCallback)
		{
		}

		public void SetSize(int width, int height)
		{
		}

		public void CreateTitleText(GameObject prefab, Vector2 offset)
		{
		}

		public void CreateTitleText(GameObject prefab, Vector2 offset, string text)
		{
		}

		public void AddContentText(GameObject prefab, UIPivot pivot, UIAnchor anchor, Vector2 offset)
		{
		}

		public void AddContentText(GameObject prefab, UIPivot pivot, UIAnchor anchor, Vector2 offset, string text)
		{
		}

		public void AddContentImage(GameObject prefab, UIPivot pivot, UIAnchor anchor, Vector2 offset)
		{
		}

		public void AddContentImage(GameObject prefab, UIPivot pivot, UIAnchor anchor, Vector2 offset, string text)
		{
		}

		public void CreateButton(GameObject prefab, UIPivot pivot, UIAnchor anchor, Vector2 offset, string buttonText, UnityAction confirmCallback, UnityAction cancelCallback, bool setDefault)
		{
		}

		public string GetTitleText(string text)
		{
			return null;
		}

		public void SetTitleText(string text)
		{
		}

		public string GetContentText(int index)
		{
			return null;
		}

		public float GetContentTextHeight(int index)
		{
			return 0f;
		}

		public void SetContentText(string text, int index)
		{
		}

		public void SetUpdateCallback(Action<int> callback)
		{
		}

		public virtual void TakeInputFocus()
		{
		}

		public virtual void Enable()
		{
		}

		public virtual void Disable()
		{
		}

		public virtual void Cancel()
		{
		}

		private void CreateText(GameObject prefab, ref TMP_Text textComponent, string name, UIPivot pivot, UIAnchor anchor, Vector2 offset)
		{
		}

		private void CreateImage(GameObject prefab, string name, UIPivot pivot, UIAnchor anchor, Vector2 offset)
		{
		}

		private GameObject CreateButton(GameObject prefab, string name, UIAnchor anchor, UIPivot pivot, Vector2 offset, out ButtonInfo buttonInfo)
		{
			buttonInfo = null;
			return null;
		}

		[IteratorStateMachine(typeof(_003COnEnableAsync_003Ed__64))]
		private IEnumerator OnEnableAsync()
		{
			return null;
		}

		private void CheckUISelection()
		{
		}

		private void RestoreDefaultOrLastUISelection()
		{
		}

		private void SetUISelection(GameObject selection)
		{
		}
	}
}
