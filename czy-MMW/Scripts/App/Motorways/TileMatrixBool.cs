using System;
using Factory;
using UnityEngine;

namespace Motorways
{
	[System.Serializable]
	[Factory.Serializable(1)]
	public class TileMatrixBool : TileMatrix<bool>
	{
		public static TileMatrixBool CreateUnscoped(RectInt dimensions, bool defaultValue)
		{
			TileMatrixBool tileMatrixBool = new TileMatrixBool();
			tileMatrixBool.Initialize(dimensions, defaultValue);
			return tileMatrixBool;
		}
	}
}
