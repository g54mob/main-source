using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ModIO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	public class ModListRow : MonoBehaviour, ISelectHandler, IEventSystemHandler
	{
		[CompilerGenerated]
		private sealed class _003COnSelectFrameDelay_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ModListRow _003C_003E4__this;

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
			public _003COnSelectFrameDelay_003Ed__12(int _003C_003E1__state)
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
		[Header("UI Elements")]
		private GameObject ErrorPanel;

		[SerializeField]
		private GameObject LoadingPanel;

		[SerializeField]
		private GameObject RowPanel;

		[SerializeField]
		private GameObject MainSelectableHighlights;

		[SerializeField]
		private GameObject ModListItemPrefab;

		[SerializeField]
		private Transform ModListItemContainer;

		[Header("Selectables")]
		[SerializeField]
		private Selectable AboveSelection;

		[SerializeField]
		private Selectable BelowSelection;

		internal static Vector2 currentSelectedPosition;

		private List<ListItem> items;

		private SearchFilter lastUsedFilter;

		public void OnSelect(BaseEventData eventData)
		{
		}

		[IteratorStateMachine(typeof(_003COnSelectFrameDelay_003Ed__12))]
		private IEnumerator OnSelectFrameDelay()
		{
			return null;
		}

		public void SelectFromPosition(Vector2 position)
		{
		}

		public void SwipeRow(bool right)
		{
		}

		public void AttemptToPopulateRowWithMods(SearchFilter filter)
		{
		}

		public void RetryGetMods()
		{
		}

		private void GetModsResponse(ResultAnd<ModPage> response)
		{
		}

		private void PopulateRowFromModPage(ModPage page)
		{
		}
	}
}
