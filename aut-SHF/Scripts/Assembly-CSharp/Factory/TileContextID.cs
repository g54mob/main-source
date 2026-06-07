using System;
using ScriptableObjects.ScriptableObjectScripts.Tile;
using UnityEngine;

namespace Factory
{
	public readonly struct TileContextID : IEquatable<TileContextID>
	{
		private readonly TileLayer _layer;

		private readonly Vector3Int _position;

		public TileContextID(TileLayer layer, Vector3Int position)
		{
			_layer = default(TileLayer);
			_position = default(Vector3Int);
		}

		public TileContextID(TileContext context)
		{
			_layer = default(TileLayer);
			_position = default(Vector3Int);
		}

		public override bool Equals(object? obj)
		{
			return false;
		}

		public bool Equals(TileContextID other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
