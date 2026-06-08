namespace KitchenData
{
	public static class DecorationTypeExtensions
	{
		public static string Icon(this DecorationType type)
		{
			return "<sprite name=\"" + type switch
			{
				DecorationType.Null => "", 
				DecorationType.Exclusive => "exclusive", 
				DecorationType.Affordable => "affordable", 
				DecorationType.Charming => "cosy", 
				DecorationType.Formal => "formal", 
				DecorationType.Kitchen => "baddecoration", 
				_ => "", 
			} + "\" tint=1>";
		}

		public static bool HasFlagFast(this DecorationType value, DecorationType flag)
		{
			return (value & flag) != 0;
		}

		public static bool Contains(this DecorationType value, DecorationType flag)
		{
			return (~value & flag) == 0;
		}
	}
}
