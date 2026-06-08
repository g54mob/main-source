using System.Collections.Generic;

namespace Kitchen.NetworkSupport
{
	public class NestedNetworkLiveness : NetworkLiveness
	{
		private HashSet<ILiveness> Children = new HashSet<ILiveness>();

		public override bool IsLive
		{
			get
			{
				if (base.IsLive)
				{
					return true;
				}
				foreach (ILiveness child in Children)
				{
					if (child.IsLive)
					{
						return true;
					}
				}
				return false;
			}
		}

		public override bool IsGoodQuality
		{
			get
			{
				if (base.IsGoodQuality)
				{
					return true;
				}
				foreach (ILiveness child in Children)
				{
					if (!child.IsGoodQuality)
					{
						return false;
					}
				}
				return true;
			}
		}

		public void Add(ILiveness child)
		{
			Children.Add(child);
		}

		public void Remove(ILiveness child)
		{
			Children.Remove(child);
		}
	}
}
