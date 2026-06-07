using Factory;
using UnityEngine;

namespace Motorways
{
	[Serializable(1)]
	public class TileMatrixInt : TileMatrix<int>
	{
		public static TileMatrixInt Create(IScope scope, RectInt dimensions, int defaultValue)
		{
			TileMatrixInt tileMatrixInt = scope.Get<TileMatrixInt>();
			tileMatrixInt.Initialize(dimensions, defaultValue);
			return tileMatrixInt;
		}
	}
}
