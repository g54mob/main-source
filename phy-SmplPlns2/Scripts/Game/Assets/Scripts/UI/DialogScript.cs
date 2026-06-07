using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI
{
	public abstract class DialogScript : WidgetScript, IDialog
	{
		public bool IsClosed { get; private set; }

		public virtual bool IsModal => true;

		public virtual object UserData { get; set; }

		public event DialogDelegate Closed;

		public virtual void Close()
		{
			if (!IsClosed)
			{
				IsClosed = true;
				Game.Instance.UserInterface.UnregisterDialog(this);
				if (this.Closed != null)
				{
					this.Closed(this);
					this.Closed = null;
				}
				DestroyDialog();
			}
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
		}

		protected virtual void DestroyDialog()
		{
			base.Widget.Destroy();
		}

		protected virtual void Start()
		{
		}
	}
}
