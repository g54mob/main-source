using System;

namespace ModApi.Ui.Inspector
{
	public abstract class ItemModel
	{
		public Func<bool> DetermineVisibility { get; set; }

		public string ElementName { get; set; }

		public bool Enabled { get; set; }

		public InspectorModel InspectorModel { get; set; }

		public IItemElement ItemElement { get; private set; }

		public int PreferredHeight { get; set; }

		public string Tooltip { get; set; }

		public Action<ItemModel> UpdateAction { get; set; }

		public virtual bool Visible { get; set; }

		public event ElementCreatedHandler ElementCreated;

		public ItemModel()
		{
			Visible = true;
			Enabled = true;
		}

		public void NotifyElementCreated(IItemElement element)
		{
			ItemElement = element;
			this.ElementCreated?.Invoke(element);
		}

		public void NotifyElementDestroyed(IItemElement element)
		{
			ItemElement = null;
		}

		public virtual void Update()
		{
			if (UpdateAction != null)
			{
				UpdateAction(this);
			}
		}

		public virtual void UpdateVisbility()
		{
			if (DetermineVisibility != null)
			{
				Visible = DetermineVisibility();
			}
		}
	}
}
