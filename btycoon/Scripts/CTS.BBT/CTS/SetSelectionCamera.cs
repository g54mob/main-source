using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class SetSelectionCamera : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private Camera _cameraToSet;

		protected override void OnAwake()
		{
			base.OnAwake();
			if (CTSSingleton<WorldSelector>.TryGetInstance(out var outInstance) && outInstance.ActiveCamera == null)
			{
				outInstance.ActiveCamera = _cameraToSet;
			}
		}
	}
}
