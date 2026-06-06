using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ZLinq.Linq
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IOrderByComparer : IComparer<int>, IDisposable
	{
	}
}
