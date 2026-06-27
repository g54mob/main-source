using System;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class PowerUpElementSocket : ElementSocket
	{
		public event Action OnPowerUp;

		protected override void SetNestedElement(ElementBase element)
		{
			base.SetNestedElement(element);
			if (!(base.NestedElement is IPowerUpElement powerUpElement))
			{
				Debug.LogError("Not IPowerUpElement component attached to PowerUpElementSocket");
			}
			else
			{
				powerUpElement.OnPowerUp += ResolveElementPowerUp;
			}
		}

		protected override void ResolveElementDetached()
		{
			if (!(base.NestedElement is IPowerUpElement powerUpElement))
			{
				Debug.LogError("Not IPowerUpElement component detached from PowerUpElementSocket");
			}
			else
			{
				powerUpElement.OnPowerUp -= ResolveElementPowerUp;
			}
			base.ResolveElementDetached();
		}

		private void ResolveElementPowerUp()
		{
			this.OnPowerUp?.Invoke();
		}
	}
}
