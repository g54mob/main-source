using UnityEngine;

namespace MoreMountains.Tools
{
	public struct MMGameEvent
	{
		private static MMGameEvent e;

		public string EventName;

		public int IntParameter;

		public Vector2 Vector2Parameter;

		public Vector3 Vector3Parameter;

		public bool BoolParameter;

		public string StringParameter;

		public static void Trigger(string eventName, int intParameter = 0, Vector2 vector2Parameter = default(Vector2), Vector3 vector3Parameter = default(Vector3), bool boolParameter = false, string stringParameter = "")
		{
			e.EventName = eventName;
			e.IntParameter = intParameter;
			e.Vector2Parameter = vector2Parameter;
			e.Vector3Parameter = vector3Parameter;
			e.BoolParameter = boolParameter;
			e.StringParameter = stringParameter;
			MMEventManager.TriggerEvent(e);
		}
	}
}
