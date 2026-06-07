using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ScheduleOne.Product;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone
{
	public class CounterOfferProductSelector : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDelaySelectSearchPanel_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CounterOfferProductSelector _003C_003E4__this;

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
			public _003CDelaySelectSearchPanel_003Ed__24(int _003C_003E1__state)
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

		public const int ENTRIES_PER_PAGE = 25;

		public RectTransform Container;

		public InputField SearchBar;

		public RectTransform ProductContainer;

		public Text PageLabel;

		public GameObject ProductEntryPrefab;

		public Action<ProductDefinition> onProductPreviewed;

		public Action<ProductDefinition> onProductSelected;

		[Header("Custom UI")]
		public UIScreen uiSelectionScreen;

		public UIPanel uiSearchPanel;

		public UIPanel uiWindowPanel;

		private List<RectTransform> productEntries;

		private Dictionary<ProductDefinition, RectTransform> productEntriesDict;

		private string searchTerm;

		private int pageIndex;

		private int pageCount;

		private List<ProductDefinition> results;

		private ProductDefinition lastPreviewedResult;

		public bool IsOpen { get; private set; }

		public void Awake()
		{
		}

		public void Open()
		{
		}

		[IteratorStateMachine(typeof(_003CDelaySelectSearchPanel_003Ed__24))]
		private IEnumerator DelaySelectSearchPanel()
		{
			return null;
		}

		public void Close()
		{
		}

		private void Update()
		{
		}

		public void SetSearchTerm(string search)
		{
		}

		private void RebuildResultsList()
		{
		}

		private List<ProductDefinition> GetMatchingProducts(string searchTerm)
		{
			return null;
		}

		private void EnsureAllEntriesExist()
		{
		}

		private void CreateProductEntry(ProductDefinition product)
		{
		}

		public void ChangePage(int change)
		{
		}

		private void SetPage(int page)
		{
		}

		private void ProductHovered(ProductDefinition def)
		{
		}

		private void ProductSelected(ProductDefinition def)
		{
		}

		public bool IsMouseOverSelector()
		{
			return false;
		}
	}
}
