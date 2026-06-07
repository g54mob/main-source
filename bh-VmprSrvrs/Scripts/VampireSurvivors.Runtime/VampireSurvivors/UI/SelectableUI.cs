using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class SelectableUI : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
	{
		public enum SelectableType
		{
			BUTTON = 0,
			ITEM = 1
		}

		public delegate void OnSelection(RectTransform rTrans);

		public delegate void OnSetSelectorVisibility(bool b);

		public delegate void OnSelectionChanged();

		[CompilerGenerated]
		private sealed class _003CDelayedColourRefresh_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SelectableUI _003C_003E4__this;

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
			public _003CDelayedColourRefresh_003Ed__43(int _003C_003E1__state)
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
		private sealed class _003CWaitForEndOfFrameAndReselect_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SelectableUI _003C_003E4__this;

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
			public _003CWaitForEndOfFrameAndReselect_003Ed__51(int _003C_003E1__state)
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
		private sealed class _003CWaitForEndOfFrameAndReselectPrevious_003Ed__52 : IEnumerator<object>, IEnumerator, IDisposable
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
			public _003CWaitForEndOfFrameAndReselectPrevious_003Ed__52(int _003C_003E1__state)
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
		private sealed class _003CWaitFrame_003Ed__46 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SelectableUI _003C_003E4__this;

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
			public _003CWaitFrame_003Ed__46(int _003C_003E1__state)
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
		private bool _ShowSelector;

		[SerializeField]
		private bool _CanBeSelectedThroughMouse;

		[SerializeField]
		private RectTransform _AlternateSelectionIcon;

		[SerializeField]
		private bool _IgnoreNavigation;

		[SerializeField]
		private bool ForceStupidDumbScrollViewMaskingFix;

		[SerializeField]
		private bool _ShouldUpdatePositionWhenForcingDumbFix;

		[SerializeField]
		private bool _ShouldUpdateSizeWhenForcingDumbFix;

		[SerializeField]
		private bool _ShouldReParentToCanvasWhenFixingMasking;

		public SelectableType selectionType;

		public static SelectableUI CurrentSelectableUI;

		public bool ReselectIfDefaultSelectedOnPage;

		public bool IsDefaultSelectedOnPage;

		private bool isSelected;

		[SerializeField]
		protected Selectable _selectable;

		private Navigation _originalNavigation;

		private Rewired.Player _player;

		private Transform _initialParent;

		private bool previousMPState;

		public static event OnSelection UIButtonSelected
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event OnSelection UIItemSelected
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event OnSelection UIItemDestroyed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnSelectionChanged OnBecameSelected
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event OnSelectionChanged OnBecameDeselected
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event OnSetSelectorVisibility SetSelectorVisibility
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected virtual void Awake()
		{
		}

		public bool IsSelected()
		{
			return false;
		}

		protected virtual void OnEnable()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedColourRefresh_003Ed__43))]
		private IEnumerator DelayedColourRefresh()
		{
			return null;
		}

		public void UpdateAlternateSelectionIconColour()
		{
		}

		protected virtual void OnDisable()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitFrame_003Ed__46))]
		private IEnumerator WaitFrame()
		{
			return null;
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected virtual void OnSelected()
		{
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForEndOfFrameAndReselect_003Ed__51))]
		private IEnumerator WaitForEndOfFrameAndReselect()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitForEndOfFrameAndReselectPrevious_003Ed__52))]
		private static IEnumerator WaitForEndOfFrameAndReselectPrevious()
		{
			return null;
		}

		protected virtual void OnDeselected()
		{
		}

		public void Deselect()
		{
		}

		public void Update()
		{
		}
	}
}
