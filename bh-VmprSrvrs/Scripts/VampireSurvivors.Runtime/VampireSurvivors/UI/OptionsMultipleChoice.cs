using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class OptionsMultipleChoice : MonoBehaviour, ISelectableUI, IUIObject
	{
		[CompilerGenerated]
		private sealed class _003CFrameDelay_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

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
			public _003CFrameDelay_003Ed__12(int _003C_003E1__state)
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
		private TextMeshProUGUI _Label;

		[SerializeField]
		private GameObject _OptionPrefab;

		[SerializeField]
		private RectTransform _Container;

		private OptionsMultipleChoiceOption _selected;

		private List<GameObject> _spawned;

		private Selectable _above;

		private Selectable _below;

		public void Initialize(string text, List<string> optionLabels, List<Action> callbacks, int selectedIndex)
		{
		}

		public void OptionSelected(OptionsMultipleChoiceOption option)
		{
		}

		public Selectable GetSelectable()
		{
			return null;
		}

		public GameObject GetGameObject()
		{
			return null;
		}

		public void UpdateNavigation(Selectable up, Selectable down, Selectable left, Selectable right)
		{
		}

		[IteratorStateMachine(typeof(_003CFrameDelay_003Ed__12))]
		private IEnumerator FrameDelay()
		{
			return null;
		}
	}
}
