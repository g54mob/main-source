using System.Collections;

namespace Loxodon.Framework.Views
{
	public class CompletedTransition : Transition
	{
		public CompletedTransition(IManageable window)
			: base(window)
		{
			IsDone = true;
		}

		protected override IEnumerator DoTransition()
		{
			yield break;
		}
	}
}
