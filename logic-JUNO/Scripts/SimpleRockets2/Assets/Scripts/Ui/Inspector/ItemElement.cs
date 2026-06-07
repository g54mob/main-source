using ModApi.Ui.Inspector;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Ui.Inspector
{
	public abstract class ItemElement : IItemElement
	{
		private ItemModel _model;

		public virtual bool Collapsed
		{
			get
			{
				if (!Group.Collapsed)
				{
					return !Group.Visible;
				}
				return true;
			}
		}

		public GameObject GameObject => XmlElement.gameObject;

		public GroupModel Group { get; private set; }

		public int Height { get; set; }

		public virtual bool ModelVisible => _model.Visible;

		public virtual bool Visible
		{
			get
			{
				return XmlElement.Visible;
			}
			set
			{
				if (value != XmlElement.Visible)
				{
					if (value)
					{
						XmlElement.Show();
					}
					else
					{
						XmlElement.Hide();
					}
				}
			}
		}

		public XmlElement XmlElement { get; private set; }

		public ItemElement(XmlElement xmlElement, ItemModel model, GroupModel group)
		{
			XmlElement = xmlElement;
			_model = model;
			Group = group;
			if (!string.IsNullOrEmpty(model.ElementName))
			{
				XmlElement.gameObject.name = model.ElementName;
			}
			if (model.PreferredHeight > 0)
			{
				xmlElement.SetAndApplyAttribute("preferredHeight", model.PreferredHeight.ToString());
			}
		}

		public virtual void OnDesroyed()
		{
			_model.NotifyElementDestroyed(this);
		}

		public virtual void Update()
		{
			if (XmlElement.Tooltip != _model.Tooltip)
			{
				XmlElement.Tooltip = _model.Tooltip;
			}
			_model.Update();
		}

		public virtual void UpdateVisibility()
		{
			_model.UpdateVisbility();
		}
	}
}
