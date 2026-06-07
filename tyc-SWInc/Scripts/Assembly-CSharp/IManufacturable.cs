public interface IManufacturable : IReferenceFix
{
	string ManufactureType();

	string GetPrettyName();

	string GetActualName();

	Manufacturing GetManufacturing();

	bool IsHardware();

	bool MatchPath(string sw, string cat);

	uint GetID();
}
