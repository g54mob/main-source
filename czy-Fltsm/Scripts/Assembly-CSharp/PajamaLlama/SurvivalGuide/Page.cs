using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace PajamaLlama.SurvivalGuide
{
	internal abstract class Page : IPage, IComparable<IPage>
	{
		private PageIndex _index;

		private List<WidgetContainer> _widgetContainers;

		private LocalizedString _name = null;

		public string ID { get; private set; }

		public string Name => _name.GetOrDefault(_name.mTerm);

		public string CompareString { get; private set; }

		public Sprite Icon { get; private set; }

		public GameObject Parent { get; private set; }

		internal List<WidgetContainer> WidgetContainers
		{
			get
			{
				if (_widgetContainers == null)
				{
					_widgetContainers = GenerateWidgets(SurvivalGuideManager.Properties);
				}
				return _widgetContainers;
			}
		}

		protected Page(string id, LocalizedString name, Sprite icon)
		{
			_name = name;
			ID = SurvivalGuide.GetUniquePageId(id, name);
			Icon = icon;
			CompareString = Name;
		}

		public void SetIndex(PageIndex index)
		{
			_index = index;
		}

		public void GenerateWidgets(GameObject parent)
		{
			Parent = parent;
			Parent.name = ID;
			Transform transform = parent.transform;
			foreach (WidgetContainer widgetContainer in WidgetContainers)
			{
				GenerateWidgetContainer(widgetContainer, transform);
			}
		}

		public void SetActive(bool active)
		{
			if ((bool)Parent)
			{
				Parent.SetActive(active);
			}
			if ((bool)_index)
			{
				_index.SetActivePageIndex(active);
			}
		}

		protected abstract List<WidgetContainer> GenerateWidgets(SurvivalGuideProperties survivalGuideProperties);

		private void GenerateWidgetContainer(WidgetContainer container, Transform parent)
		{
			Transform transform = UnityEngine.Object.Instantiate(container.Layout.Prefab, parent).transform;
			foreach (Tuple<BaseWidget, BaseWidget.BaseParameters> widget in container.Widgets)
			{
				UnityEngine.Object.Instantiate(widget.Item1, transform).Initialize(widget.Item2);
			}
		}

		internal bool Equals(string id)
		{
			return ID.Equals(id, StringComparison.OrdinalIgnoreCase);
		}

		int IComparable<IPage>.CompareTo(IPage other)
		{
			if (CompareString == null)
			{
				return 0;
			}
			return CompareString.CompareTo(other.CompareString);
		}
	}
}
