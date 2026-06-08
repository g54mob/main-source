using System;
using System.Collections.Generic;
using Kitchen.Layouts;
using KitchenData;

namespace Kitchen
{
	public class LayoutDecorator
	{
		private LayoutBlueprint Blueprint;

		private LayoutProfile Profile;

		private RestaurantSetting Setting;

		public List<CLayoutAppliancePlacement> Decorations;

		public LayoutDecorator(LayoutBlueprint blueprint, LayoutProfile profile, RestaurantSetting setting)
		{
			Blueprint = blueprint;
			Profile = profile;
			Setting = setting;
		}

		public void AttemptDecoration()
		{
			Decorations = new List<CLayoutAppliancePlacement>();
			Decorator decorator = new DiningDecorator().Setup(Blueprint, Profile, null, Decorations);
			Decorator decorator2 = new KitchenDecorator().Setup(Blueprint, Profile, null, Decorations);
			foreach (Room item in Blueprint.Rooms())
			{
				if (item.Type == RoomType.Dining)
				{
					int num = 5;
					while (num-- > 0 && !decorator.Decorate(item))
					{
					}
					if (num <= 0)
					{
						throw new LayoutFailureException("Failed to decorate dining room");
					}
				}
				if (item.Type == RoomType.Kitchen)
				{
					decorator2.Decorate(item);
				}
			}
			foreach (IDecorationConfiguration decorator3 in Setting.Decorators)
			{
				try
				{
					Decorator obj = (Decorator)decorator3.Decorator;
					obj.Setup(Blueprint, Profile, decorator3, Decorations);
					obj.Decorate(default(Room));
				}
				catch (Exception arg)
				{
					throw new LayoutFailureException($"Failed to apply decorator {decorator3.Decorator}: {arg}");
				}
			}
		}
	}
}
