public interface IDisplayable
{
	IManufacturable Manufacturing { get; }

	byte[] HardwareDesign { get; }

	int ReleaseYear { get; }

	string GetName();

	string GetCompanyName();
}
