public class Overlays
{
	public enum Type
	{
		None = 0,
		Energy = 1,
		Beauty = 2,
		Weight = 3,
		Architect = 4
	}

	private static Type _type;

	public static Type OverlayType
	{
		get
		{
			return _type;
		}
		set
		{
			if (_type != value)
			{
				_type = value;
				OverlayEvent.DispatchUpdated(_type);
			}
		}
	}
}
