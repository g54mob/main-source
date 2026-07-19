namespace UniHumanoid
{
	public static class ChannelExtensions
	{
		public static string ToProperty(this Channel ch)
		{
			return ch switch
			{
				Channel.Xposition => "localPosition.x", 
				Channel.Yposition => "localPosition.y", 
				Channel.Zposition => "localPosition.z", 
				Channel.Xrotation => "localEulerAnglesBaked.x", 
				Channel.Yrotation => "localEulerAnglesBaked.y", 
				Channel.Zrotation => "localEulerAnglesBaked.z", 
				_ => throw new BvhException("no property for " + ch), 
			};
		}

		public static bool IsLocation(this Channel ch)
		{
			switch (ch)
			{
			case Channel.Xposition:
			case Channel.Yposition:
			case Channel.Zposition:
				return true;
			case Channel.Xrotation:
			case Channel.Yrotation:
			case Channel.Zrotation:
				return false;
			default:
				throw new BvhException("no property for " + ch);
			}
		}
	}
}
