using System.Collections.Generic;

public struct KilledEnemiesBufferComparer : IComparer<KilledEnemiesBuffer>
{
	private ObjectDataCDComparer _comparerImplementation;

	public int Compare(KilledEnemiesBuffer x, KilledEnemiesBuffer y)
	{
		return _comparerImplementation.Compare(x.objectData, y.objectData);
	}
}
