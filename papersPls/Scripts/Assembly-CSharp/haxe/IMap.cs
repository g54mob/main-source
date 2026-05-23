using haxe.lang;

namespace haxe
{
	public interface IMap : IHxObject
	{
		object get(object k);

		void set(object k, object v);

		bool exists(object k);

		bool remove(object k);

		object keys();

		object iterator();

		object keyValueIterator();

		IMap copy();

		string toString();

		void clear();
	}
}
