using UnityEngine;

namespace Polarith.AI.Move
{
	public abstract class AIMSensor : ScriptableObject
	{
		public abstract Sensor Sensor { get; }
	}
}
