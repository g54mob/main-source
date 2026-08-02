using System.Threading.Tasks;
using Rhizomatic.Reactive;

namespace Rhizomatic
{
	public class EmptyPageTransition : PageTransition
	{
		public override Task Open(View view)
		{
			return null;
		}

		public override Task Close(View view)
		{
			return null;
		}
	}
}
