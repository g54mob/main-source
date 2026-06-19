namespace Loxodon.Framework.Views
{
	public abstract class ToastViewBase : UIView
	{
		protected string content;

		public string Content
		{
			get
			{
				return content;
			}
			set
			{
				if (!string.Equals(content, value))
				{
					content = value;
					OnContentChanged();
				}
			}
		}

		protected abstract void OnContentChanged();
	}
}
