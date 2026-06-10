using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ModIO.Implementation;
using ModIOBrowser;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.mod.io.UI.Examples
{
	public class ExampleTitleScene : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CSetupTranslationDropDown_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ExampleTitleScene _003C_003E4__this;

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
			public _003CSetupTranslationDropDown_003Ed__6(int _003C_003E1__state)
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

		[SerializeField]
		private Selectable DefaultSelection;

		[SerializeField]
		private ExampleSettingsPanel exampleSettingsPanel;

		public string verticalControllerInput;

		public List<string> mouseInput;

		public MultiTargetDropdown languageSelectionDropdown;

		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CSetupTranslationDropDown_003Ed__6))]
		private IEnumerator SetupTranslationDropDown()
		{
			return null;
		}

		public void OnTranslationDropdownChange()
		{
		}

		public void OpenMods()
		{
		}

		public void OpenSettings()
		{
		}

		public void OpenTitle()
		{
		}

		public void Quit()
		{
		}

		public void DeselectOtherTitles()
		{
		}

		private void Update()
		{
		}
	}
}
