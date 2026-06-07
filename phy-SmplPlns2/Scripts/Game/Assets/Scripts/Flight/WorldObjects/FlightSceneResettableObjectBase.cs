using Jundroo.Common.Utils;

namespace Assets.Scripts.Flight.WorldObjects
{
	public abstract class FlightSceneResettableObjectBase : IFlightSceneResettableObject
	{
		public string DisplayName { get; }

		public float ResetTimer { get; set; }

		public int UniqueId { get; }

		protected FlightSceneResettableObjectBase(string uniqueId, string displayName, float? resetTime)
			: this(StringUtility.GetStableHashCode(uniqueId), displayName, resetTime)
		{
		}

		protected FlightSceneResettableObjectBase(int uniqueId, string displayName, float? resetTime)
		{
			UniqueId = uniqueId;
			DisplayName = displayName;
			ResetTimer = resetTime ?? float.MaxValue;
		}

		public abstract void ResetObject();
	}
}
