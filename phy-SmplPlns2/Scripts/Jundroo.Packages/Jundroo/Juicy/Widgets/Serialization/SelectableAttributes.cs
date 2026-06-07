using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public static class SelectableAttributes
	{
		public static AttributeSet Set { get; private set; }

		static SelectableAttributes()
		{
			Set = new AttributeSet();
		}

		public static void Generate(AttributeSet set)
		{
			set.AddColorBlock("colors", delegate(ISelectableWidget w, ColorBlock x)
			{
				w.Selectable.colors = x;
			});
			set.AddEnum("navigation", delegate(ISelectableWidget w, Navigation.Mode x)
			{
				Navigation navigation = w.Selectable.navigation;
				navigation.mode = x;
				w.Selectable.navigation = navigation;
			});
		}
	}
}
