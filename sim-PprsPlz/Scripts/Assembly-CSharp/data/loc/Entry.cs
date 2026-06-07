using haxe.lang;

namespace data.loc
{
	public interface Entry : IHxObject
	{
		string get_text();

		string set_text(string value);

		Display get_display();
	}
}
