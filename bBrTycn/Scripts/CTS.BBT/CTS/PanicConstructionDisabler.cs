using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class PanicConstructionDisabler : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private UI_ConstructionSystem _constructionSystem;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			PanicCounter.PanicActive += OnPanicActive;
			OnPanicActive(PanicCounter.IsPanicActive);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			PanicCounter.PanicActive -= OnPanicActive;
		}

		private void OnPanicActive(bool obj)
		{
			if (obj)
			{
				_constructionSystem.CloseConstructionFromAnywhere();
			}
		}
	}
}
