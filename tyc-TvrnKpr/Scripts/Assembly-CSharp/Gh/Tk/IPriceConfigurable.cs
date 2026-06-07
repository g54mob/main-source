namespace Gh.Tk
{
	public interface IPriceConfigurable
	{
		int CurrentPrice { get; set; }

		(int, int) GetAllowedPriceRange();
	}
}
