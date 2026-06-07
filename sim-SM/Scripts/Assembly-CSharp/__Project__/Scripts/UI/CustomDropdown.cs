using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using __Project__.Scripts.ControllerInputModule;

namespace __Project__.Scripts.UI
{
	public class CustomDropdown : TMP_Dropdown
	{
		[CompilerGenerated]
		private sealed class _003CDelayedReset_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CustomDropdown _003C_003E4__this;

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
			public _003CDelayedReset_003Ed__14(int _003C_003E1__state)
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

		private GamepadUISelectable m_parentSelectable;

		private GamePadUIPanel m_parentPanel;

		private GamepadUIFunctionLibrary m_gamepadUIFunctionLibrary;

		private List<CustomDropdown> m_otherDropdowns;

		private GameObject m_lastGamepadSelectedObject;

		private bool m_willSelect;

		private bool m_isInstant;

		protected override void Awake()
		{
		}

		private void SwitchObjectOnConnection(bool isGamepad)
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void DestroyDropdownList(GameObject dropdownList)
		{
		}

		protected override GameObject CreateDropdownList(GameObject templated)
		{
			return null;
		}

		public void SetCachedObject()
		{
		}

		public void InstantClose()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedReset_003Ed__14))]
		private IEnumerator DelayedReset()
		{
			return null;
		}

		public void SelectItem()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
