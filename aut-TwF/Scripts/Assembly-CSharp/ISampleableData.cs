using System.Collections.Generic;

public interface ISampleableData
{
	Dictionary<string, object> GetData();

	void SetData(Dictionary<string, object> data);
}
