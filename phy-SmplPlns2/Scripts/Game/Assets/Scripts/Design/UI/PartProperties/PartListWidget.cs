using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public class PartListWidget : CustomPartPropertyWidget
	{
		private List<PartListItemWidget> _items = new List<PartListItemWidget>();

		private List<int> _partIds;

		public void OnItemDeleted(PartListItemWidget item)
		{
			_items.Remove(item);
			_partIds.Remove(item.PartID);
			item.Widget.Hide(delegate
			{
				item.Widget.Destroy();
			}, force: true);
			OnValueChanged();
			OnListChanged();
		}

		public void SetPartList(List<int> partIDs, Assembly assembly)
		{
			_partIds = partIDs;
			foreach (PartListItemWidget item in _items)
			{
				item.Widget.Destroy();
			}
			_items.Clear();
			foreach (int partID in partIDs)
			{
				PartData partById = assembly.GetPartById(partID);
				if (partById != null)
				{
					CreatePartWidget(partById);
				}
			}
			OnListChanged();
		}

		private void AddPartClicked(Widget widget)
		{
			Designer.Instance.Tools.SelectChoosePartTool((PartData x) => !_partIds.Contains(x.Id) && !x.PartScript.HasModifier<DecalScript>() && x.PartScript.DecalTargets.Count != 0, connectedToSelectedPart: false, 0, "No parts to select", delegate(PartData x)
			{
				if (x != null)
				{
					_partIds.Add(x.Id);
					CreatePartWidget(x);
					OnValueChanged();
					OnListChanged();
				}
			}, waitForDoneClicked: false);
		}

		private Widget CreatePartWidget(PartData part)
		{
			Widget widget = base.Widget.Context.CreateWidgetFromTemplate("property-part-list-item", base.Widget);
			PartListItemWidget componentInChildren = widget.GetComponentInChildren<PartListItemWidget>();
			componentInChildren.Initialize(this, part);
			_items.Add(componentInChildren);
			return widget;
		}

		private void OnListChanged()
		{
			base.Widget.FindWidget("empty-text").Visible = _items.Count == 0;
		}

		private void OnValueChanged()
		{
			List<int> partIds = _partIds;
			string text = partIds?.ToString();
			foreach (var symmetricModifier in base.ConfigurableProperty.GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier.PartModifier.OnGenericDesignerPropertyChanging(base.ConfigurableProperty.Member.Name, text);
			}
			base.ConfigurableProperty.SetValue(partIds, convertType: true);
			foreach (var symmetricModifier2 in base.ConfigurableProperty.GetSymmetricModifiers(includeCurrentModifier: true))
			{
				symmetricModifier2.PartModifier.OnGenericDesignerPropertyChanged(base.ConfigurableProperty.Member.Name, text);
			}
			base.ConfigurableProperty.RaiseValueCommitted();
		}
	}
}
