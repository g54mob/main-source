namespace Jundroo.Juicy.Widgets.Serialization
{
	public abstract class Attribute
	{
		public string Name { get; private set; }

		public abstract string SchemaType { get; }

		public Attribute(string name)
		{
			Name = name;
		}

		public abstract void Apply(Widget w, string s);
	}
}
