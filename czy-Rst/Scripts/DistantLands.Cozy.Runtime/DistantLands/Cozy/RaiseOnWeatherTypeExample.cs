using DistantLands.Cozy.Data;
using UnityEngine;

namespace DistantLands.Cozy
{
	public class RaiseOnWeatherTypeExample : MonoBehaviour
	{
		public EventFX weatherType;

		private void OnEnable()
		{
			weatherType.onCall += OnStart;
			weatherType.onCall += OnStart;
		}

		private void OnDisable()
		{
			weatherType.onCall -= OnStart;
			weatherType.onEnd -= OnEnd;
		}

		public void OnStart()
		{
		}

		public void OnEnd()
		{
		}
	}
}
