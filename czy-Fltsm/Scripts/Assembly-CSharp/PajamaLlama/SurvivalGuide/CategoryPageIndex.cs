using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace PajamaLlama.SurvivalGuide
{
	public class CategoryPageIndex : PageIndex
	{
		[FormerlySerializedAs("Accordion")]
		[SerializeField]
		private AccordionElement _accordion;

		[SerializeField]
		private ChildBehaviourCache<PageIndex> _indexPrefab;

		public AccordionElement Accordion => _accordion;

		public List<PageIndex> SubPageIndices { get; private set; } = new List<PageIndex>();

		internal override void Initialize(IPage page)
		{
			base.Initialize(page);
			ICategoryPage obj = (page as ICategoryPage) ?? throw new NotImplementedException();
			SubPageIndices.Clear();
			_indexPrefab.Reset();
			foreach (IPage subPage in obj.SubPages)
			{
				PageIndex pageIndex = _indexPrefab.Get(active: true);
				pageIndex.Initialize(subPage);
				pageIndex.Parent = this;
				SubPageIndices.Add(pageIndex);
			}
			if (_accordion.SelectableGroup.Initialization == SelectableGroup.InitializationMode.Script)
			{
				_accordion.SelectableGroup.Initialize(clearSelected: true);
			}
		}

		internal bool TryGetPageIndexSelectable(out Selectable selectable, IPage page)
		{
			for (int i = 0; i < _indexPrefab.Count; i++)
			{
				PageIndex pageIndex = _indexPrefab[i];
				if (pageIndex.Page == page)
				{
					selectable = pageIndex.Selectable;
					return true;
				}
			}
			selectable = null;
			return false;
		}

		internal bool TryGetPageIndex<T>(out T pageIndex, IPage page) where T : PageIndex
		{
			for (int i = 0; i < _indexPrefab.Count; i++)
			{
				pageIndex = _indexPrefab[i] as T;
				if (pageIndex != null && pageIndex.Page == page)
				{
					return true;
				}
			}
			pageIndex = null;
			return false;
		}

		internal void ToggleOn()
		{
			if ((bool)_accordion)
			{
				_accordion.ToggleOn(instantTransition: true);
			}
		}
	}
}
