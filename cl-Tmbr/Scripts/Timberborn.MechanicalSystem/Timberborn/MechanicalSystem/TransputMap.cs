using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Timberborn.MapStateSystem;
using Timberborn.SingletonSystem;
using UnityEngine;

namespace Timberborn.MechanicalSystem
{
	public class TransputMap : ILoadableSingleton
	{
		private static readonly List<Transput> EmptyTransputs = new List<Transput>();

		private readonly MapSize _mapSize;

		private List<Transput>[,,] _transputs;

		public event EventHandler<Transput> TransputAdded;

		public event EventHandler<Transput> TransputRemoved;

		public TransputMap(MapSize mapSize)
		{
			_mapSize = mapSize;
		}

		public void Load()
		{
			InitializeTransputs();
		}

		public void AddNode(MechanicalNode node)
		{
			ImmutableArray<Transput>.Enumerator enumerator = node.Transputs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Transput current = enumerator.Current;
				SetTransput(current);
			}
		}

		public void RemoveNode(MechanicalNode node)
		{
			ImmutableArray<Transput>.Enumerator enumerator = node.Transputs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Transput current = enumerator.Current;
				UnsetTransput(current);
			}
		}

		public Transput GetFacingTransput(Transput transput)
		{
			if (_mapSize.ContainsInTotal(transput.Target))
			{
				foreach (Transput transputsAtCoordinate in GetTransputsAtCoordinates(transput.Target))
				{
					if (transputsAtCoordinate.Faces(transput))
					{
						return transputsAtCoordinate;
					}
				}
			}
			return null;
		}

		private void InitializeTransputs()
		{
			int x = _mapSize.TotalSize.x;
			int y = _mapSize.TotalSize.y;
			int z = _mapSize.TotalSize.z;
			_transputs = new List<Transput>[x, y, z];
			for (int i = 0; i < x; i++)
			{
				for (int j = 0; j < y; j++)
				{
					for (int k = 0; k < z; k++)
					{
						_transputs[i, j, k] = EmptyTransputs;
					}
				}
			}
		}

		private void SetTransput(Transput transput)
		{
			Vector3Int coordinates = transput.Coordinates;
			List<Transput> list = GetTransputsAtCoordinates(coordinates);
			if (list == EmptyTransputs)
			{
				list = new List<Transput>();
				_transputs[coordinates.x, coordinates.y, coordinates.z] = list;
			}
			list.Add(transput);
			this.TransputAdded?.Invoke(this, transput);
		}

		private void UnsetTransput(Transput transput)
		{
			GetTransputsAtCoordinates(transput.Coordinates).Remove(transput);
			this.TransputRemoved?.Invoke(this, transput);
		}

		private List<Transput> GetTransputsAtCoordinates(Vector3Int coordinates)
		{
			return _transputs[coordinates.x, coordinates.y, coordinates.z];
		}
	}
}
