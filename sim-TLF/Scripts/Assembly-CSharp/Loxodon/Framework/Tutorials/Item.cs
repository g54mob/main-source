using Loxodon.Framework.Observables;

namespace Loxodon.Framework.Tutorials
{
	public class Item : ObservableObject
	{
		private string title;

		private string iconPath;

		private string content;

		public string Title
		{
			get
			{
				return title;
			}
			set
			{
				Set(ref title, value, "Title");
			}
		}

		public string IconPath
		{
			get
			{
				return iconPath;
			}
			set
			{
				Set(ref iconPath, value, "IconPath");
			}
		}

		public string Content
		{
			get
			{
				return content;
			}
			set
			{
				Set(ref content, value, "Content");
			}
		}

		public override string ToString()
		{
			return $"[Item: Title={Title}, IconPath={IconPath}, Content={Content}]";
		}
	}
}
