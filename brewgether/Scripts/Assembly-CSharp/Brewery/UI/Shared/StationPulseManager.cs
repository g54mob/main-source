using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Brewery.UI.Shared
{
	public class StationPulseManager
	{
		private readonly HashSet<VisualElement> currentlyPulsing;

		private const float PULSE_MIN_SCALE = 0.92f;

		private const float PULSE_MAX_SCALE = 1.12f;

		public int PulsingCount => 0;

		public void StartPulse(VisualElement element)
		{
		}

		public void StopPulse(VisualElement element)
		{
		}

		public void StopAllPulses()
		{
		}

		public bool IsPulsing(VisualElement element)
		{
			return false;
		}
	}
}
