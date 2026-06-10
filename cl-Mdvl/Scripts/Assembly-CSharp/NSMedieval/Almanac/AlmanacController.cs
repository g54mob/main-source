using System;
using NSEipix.Base;

namespace NSMedieval.Almanac
{
	public class AlmanacController : MonoSingleton<AlmanacController>
	{
		public event Action OnSearchGroupExpansionEvent;

		public void OnSearchGroupExpansion()
		{
			this.OnSearchGroupExpansionEvent?.Invoke();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.OnSearchGroupExpansionEvent = null;
		}
	}
}
