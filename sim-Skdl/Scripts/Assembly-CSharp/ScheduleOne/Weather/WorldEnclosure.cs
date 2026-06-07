using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Weather
{
	public class WorldEnclosure : MonoBehaviour
	{
		[Header("Components")]
		[SerializeField]
		private List<BasicEnclosure> _enclosures;

		private List<BasicEnclosure> _blendZones;

		private List<BasicEnclosure> _Enclosures;

		public List<BasicEnclosure> Enclosures => null;

		private void Start()
		{
		}

		public bool WithinEnclosure(Vector3 targetPosition, out float blend)
		{
			blend = default(float);
			return false;
		}
	}
}
