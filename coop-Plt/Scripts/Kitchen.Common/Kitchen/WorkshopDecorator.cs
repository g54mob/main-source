using Kitchen.Layouts;
using KitchenData;

namespace Kitchen
{
	public class WorkshopDecorator : Decorator
	{
		public class DecorationsConfiguration : IDecorationConfiguration
		{
			public IDecorator Decorator => new WorkshopDecorator();
		}

		public override bool Decorate(Room room)
		{
			if (!(Configuration is DecorationsConfiguration))
			{
				return false;
			}
			return true;
		}
	}
}
