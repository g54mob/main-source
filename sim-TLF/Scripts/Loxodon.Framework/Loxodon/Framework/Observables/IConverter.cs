namespace Loxodon.Framework.Observables
{
	public interface IConverter<From, To>
	{
		To Create(From from);

		void Update(From from, To to);
	}
}
