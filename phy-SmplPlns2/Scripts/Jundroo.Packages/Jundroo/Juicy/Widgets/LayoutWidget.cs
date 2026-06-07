using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Xml.Linq;
using Jundroo.Common.Extensions;
using Jundroo.Juicy.Widgets.Extra;
using Jundroo.Juicy.Widgets.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets
{
	public class LayoutWidget : Widget
	{
		public enum SizeFitterOption
		{
			None = 0,
			Horizontal = 1,
			Vertical = 2,
			Both = 3
		}

		private bool _dirtyItemsModel;

		private IEnumerable _itemsModel;

		private DataValueBinding _itemsModelBinding;

		private string _itemsModelPath;

		private string _itemTemplate;

		private SizeFitterOption _sizeFitter;

		public string ItemsModelBindingPath
		{
			get
			{
				return _itemsModelPath;
			}
			set
			{
				if (_itemsModelPath != value)
				{
					_itemsModelPath = value;
					_dirtyItemsModel = true;
				}
			}
		}

		public string ItemTemplate
		{
			get
			{
				return _itemTemplate;
			}
			set
			{
				if (_itemTemplate != value)
				{
					_itemTemplate = value;
					_dirtyItemsModel = true;
				}
			}
		}

		public HorizontalOrVerticalLayoutGroup LayoutGroup { get; private set; }

		public float MaxHeight
		{
			get
			{
				return WidgetSizeFitter.MaxHeight;
			}
			set
			{
				WidgetSizeFitter.MaxHeight = value;
			}
		}

		public float MaxWidth
		{
			get
			{
				return WidgetSizeFitter.MaxWidth;
			}
			set
			{
				WidgetSizeFitter.MaxWidth = value;
			}
		}

		public SizeFitterOption SizeFitter
		{
			get
			{
				return _sizeFitter;
			}
			set
			{
				_sizeFitter = value;
				WidgetSizeFitter widgetSizeFitter = WidgetSizeFitter;
				switch (value)
				{
				case SizeFitterOption.Horizontal:
					widgetSizeFitter.verticalFit = ContentSizeFitter.FitMode.Unconstrained;
					widgetSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
					break;
				case SizeFitterOption.Vertical:
					widgetSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
					widgetSizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
					break;
				case SizeFitterOption.Both:
					widgetSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
					widgetSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
					break;
				}
			}
		}

		protected override AttributeSet AttributeSet => LayoutAttributes.Set;

		private IEnumerable ItemsModel
		{
			get
			{
				return _itemsModel;
			}
			set
			{
				if (_itemsModel == value)
				{
					return;
				}
				if (_itemsModel != null)
				{
					DestroyWidgetsForModels(_itemsModel);
					if (_itemsModel is INotifyCollectionChanged notifyCollectionChanged)
					{
						notifyCollectionChanged.CollectionChanged -= OnItemsChanged;
					}
				}
				_itemsModel = value;
				if (value != null)
				{
					if (!(value is INotifyCollectionChanged notifyCollectionChanged2))
					{
						throw new ArgumentException("ItemsModel must implement INotifyCollectionChanged. ObservableCollection is a solid choice.");
					}
					CreateWidgetsForModels(value);
					notifyCollectionChanged2.CollectionChanged += OnItemsChanged;
				}
			}
		}

		private WidgetSizeFitter WidgetSizeFitter => base.gameObject.AddMissingComponent<WidgetSizeFitter>();

		[ContextMenu("Force Rebuild Layout")]
		public void ForceRebuildLayout()
		{
			SetDirtyFlag(DirtyFlags.UpdateLayout);
			LayoutRebuilder.ForceRebuildLayoutImmediate(base.Rect);
		}

		public override void Initialize(IWidgetContext context, XElement element)
		{
			base.Initialize(context, element);
			LayoutGroup = base.ChildContainer.GetComponent<HorizontalOrVerticalLayoutGroup>();
		}

		public override void UpdateWidget(object dataModel)
		{
			if (_dirtyItemsModel)
			{
				_dirtyItemsModel = false;
				ItemsModel = null;
				if (!string.IsNullOrEmpty(ItemsModelBindingPath))
				{
					_itemsModelBinding = new DataValueBinding(this, AttributeSet, null, ItemsModelBindingPath);
				}
				else
				{
					_itemsModelBinding = null;
				}
			}
			if (_itemsModelBinding != null)
			{
				IEnumerable enumerable = _itemsModelBinding.GetCurrentValue(dataModel) as IEnumerable;
				if (ItemsModel != enumerable)
				{
					ItemsModel = enumerable;
				}
			}
			base.UpdateWidget(dataModel);
		}

		private void CreateWidgetsForModels(IEnumerable newItems)
		{
			foreach (object newItem in newItems)
			{
				base.Context.CreateWidgetFromTemplate(ItemTemplate, this).DataModel = newItem;
			}
		}

		private void DestroyWidgetsForModels(IEnumerable oldItems)
		{
			foreach (object oldItem in oldItems)
			{
				base.Widgets.FirstOrDefault((Widget x) => x.DataModel == oldItem)?.Destroy();
			}
		}

		private void OnItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				CreateWidgetsForModels(e.NewItems);
			}
			else if (e.Action == NotifyCollectionChangedAction.Remove)
			{
				DestroyWidgetsForModels(e.OldItems);
			}
		}
	}
}
