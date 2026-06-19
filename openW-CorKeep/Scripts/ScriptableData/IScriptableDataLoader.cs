using System.Collections.Generic;
using System.Threading.Tasks;

public interface IScriptableDataLoader
{
	bool HasDataBlockChanges { get; }

	bool LoadCompleted { get; }

	float LoadCompletedPercentage { get; }

	Task<IEnumerable<ScriptableDataBlock>> LoadAsync();

	IEnumerable<ScriptableDataBlock> Load();

	void Unload();
}
