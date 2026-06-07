using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace viperOSK
{
	public class OSK_UI_Key : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, I_OSK_Key, ISubmitHandler
	{
		[CompilerGenerated]
		private sealed class _003CClickCoroutine_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OSK_UI_Key _003C_003E4__this;

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
			public _003CClickCoroutine_003Ed__43(int _003C_003E1__state)
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
		private sealed class _003CLongPressCheck_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OSK_UI_Key _003C_003E4__this;

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
			public _003CLongPressCheck_003Ed__37(int _003C_003E1__state)
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

		public OSK_KeyCode key;

		public UnityEvent<OSK_KeyCode, OSK_Receiver> callBack;

		private Action<string, OSK_Receiver> altAction;

		public OSK_KEY_TYPES keyType;

		private OSK_Receiver tmpOutput;

		public TextMeshProUGUI keyName;

		public Selectable bk;

		public bool isPressed;

		public bool isLongPress;

		private Coroutine longPressCoroutine;

		private float lastPressed;

		public float x_size;

		private Color bk_baseColor;

		private Vector2Int layoutLoc;

		private int timesPressed;

		private string keyPressType;

		public OSK_KeyCode GetKeyCode()
		{
			return default(OSK_KeyCode);
		}

		public object GetObject()
		{
			return null;
		}

		public GameObject GetGameObject()
		{
			return null;
		}

		public string GetKeyName()
		{
			return null;
		}

		public float LastPressed()
		{
			return 0f;
		}

		public OSK_KEY_TYPES KeyType()
		{
			return default(OSK_KEY_TYPES);
		}

		public Transform GetKeyTransform()
		{
			return null;
		}

		public void AssignSpecialAction(Action<string, OSK_Receiver> action)
		{
		}

		public void Assign(OSK_KeyCode newKey, OSK_KEY_TYPES ktype, string name = "")
		{
		}

		public void SetLayoutLocation(int x, int y)
		{
		}

		public Vector2Int GetLayoutLocation()
		{
			return default(Vector2Int);
		}

		public void KeyFont(TMP_FontAsset keyfont)
		{
		}

		public void SetColors(Color bk_color, Color label_color)
		{
		}

		public void SetBkColor(Color bk_color, bool reset_base_color = true)
		{
		}

		public void BackScale(Vector3 scale)
		{
		}

		public float getYSize()
		{
			return 0f;
		}

		public float getXSize()
		{
			return 0f;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public void OnPressed()
		{
		}

		public void OnDepressed()
		{
		}

		[IteratorStateMachine(typeof(_003CLongPressCheck_003Ed__37))]
		private IEnumerator LongPressCheck()
		{
			return null;
		}

		public void JoystickPressDown(OSK_Receiver inputfield = null)
		{
		}

		public void JoystickPressUp(OSK_Receiver inputfield = null)
		{
		}

		public void OnKeyPress(string keyDevice, OSK_Receiver inputfield = null)
		{
		}

		public void OnKeyDepress(string keyDevice, OSK_Receiver inputfield = null)
		{
		}

		public void Click(string keyDevice, OSK_Receiver inputfield = null)
		{
		}

		[IteratorStateMachine(typeof(_003CClickCoroutine_003Ed__43))]
		private IEnumerator ClickCoroutine()
		{
			return null;
		}

		public void ShiftUp()
		{
		}

		public void ShiftDown()
		{
		}

		public void Highlight(bool hi, Color c)
		{
		}

		private OSK_UI_Key Dir(int x, int y)
		{
			return null;
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public virtual void OnSubmit(BaseEventData eventData)
		{
		}
	}
}
