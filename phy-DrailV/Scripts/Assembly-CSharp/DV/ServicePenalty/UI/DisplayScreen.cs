using UnityEngine;

namespace DV.ServicePenalty.UI
{
	public abstract class DisplayScreen : MonoBehaviour, IDisplayScreen
	{
		public abstract void Activate(IDisplayScreen previousScreen);

		public abstract void Disable();

		public abstract void HandleInputAction(InputAction input);
	}
}
