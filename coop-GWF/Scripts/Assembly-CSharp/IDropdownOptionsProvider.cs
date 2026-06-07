using System.Collections.Generic;

public interface IDropdownOptionsProvider
{
	List<string> GetOptions();

	int GetDefaultIndex(List<string> options);
}
