using System;
using UnityEngine;

namespace CTS.Core
{
	public abstract class WorldSelectorInputBase : MonoBehaviour
	{
		public event Action InputSelectPressed;

		public event Action InputDeselectPressed;

		protected void SendSelectInput()
		{
			this.InputSelectPressed?.Invoke();
		}

		protected void SendDeselectInput()
		{
			this.InputDeselectPressed?.Invoke();
		}

		public abstract bool IsMultiSelectionPressed();
	}
}
