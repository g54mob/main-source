namespace Rewired.Data.Mapping
{
	[CustomClassObfuscation]
	public interface IHardwareControllerMap
	{
		string[] GetElementIdentifierNames();

		int[] GetElementIdentifierIds();

		bool ContainsElementIdentifier(int id);

		int GetMappableElementIdentifierInfo(out string[] names, out int[] ids);
	}
}
