using System;

namespace PugMod
{
	public interface IExperimental
	{
		int RegisterAttributeFunction<TAttr, TDel>(Type type, Func<TDel, TAttr, bool> handler) where TAttr : Attribute where TDel : Delegate;
	}
}
