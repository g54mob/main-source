using System;

namespace Loxodon.Framework.Binding.Proxy.Sources
{
	[Serializable]
	public abstract class SourceDescription
	{
		private bool isStatic;

		public virtual bool IsStatic
		{
			get
			{
				return isStatic;
			}
			set
			{
				isStatic = value;
			}
		}
	}
}
