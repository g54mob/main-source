using System.Collections;
using System.Collections.Specialized;
using Loxodon.Framework.Binding.Reflection;

namespace Loxodon.Framework.Binding.Proxy.Sources.Object
{
	public class StringItemNodeProxy : ItemNodeProxy<string>
	{
		public StringItemNodeProxy(ICollection source, string key, IProxyItemInfo itemInfo)
			: base(source, key, itemInfo)
		{
		}

		protected override void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Reset)
			{
				RaiseValueChanged();
				return;
			}
			if (e.NewItems != null && e.NewItems.Count > 0)
			{
				foreach (object newItem in e.NewItems)
				{
					if (regex.IsMatch(newItem.ToString()))
					{
						RaiseValueChanged();
						return;
					}
				}
			}
			if (e.OldItems == null || e.OldItems.Count <= 0)
			{
				return;
			}
			foreach (object oldItem in e.OldItems)
			{
				if (regex.IsMatch(oldItem.ToString()))
				{
					RaiseValueChanged();
					break;
				}
			}
		}
	}
}
