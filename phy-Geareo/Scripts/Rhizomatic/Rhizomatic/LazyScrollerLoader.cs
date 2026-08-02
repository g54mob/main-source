using System.Collections.Generic;
using System.Threading.Tasks;
using Rhizomatic.Reactive;

namespace Rhizomatic
{
	public delegate Task<List<IViewable>> LazyScrollerLoader(int offset);
}
