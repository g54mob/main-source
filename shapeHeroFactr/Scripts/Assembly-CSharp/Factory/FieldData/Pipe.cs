using System;
using System.Collections.Generic;
using Libs;
using Models;
using ScriptableObjects.ScriptableObjectScripts.Tile;

namespace Factory.FieldData
{
	public class Pipe
	{
		public struct PipeLinkPair : IEquatable<PipeLinkPair>
		{
			public StructureAddr A;

			public StructureAddr B;

			public PipeLinkPair(StructureAddr a, StructureAddr b)
			{
				A = default(StructureAddr);
				B = default(StructureAddr);
			}

			public bool Equals(PipeLinkPair other)
			{
				return false;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		internal readonly FactoryMap factoryMap;

		private Dictionary<PipeLinkPair, int> _pipeLinkPairs;

		private double mechSpeed;

		private int _updateCircuitDataCounter;

		private static readonly eLuggage[] Inks;

		private static readonly eLuggage[] InkBottles;

		public Pipe(FactoryMap factoryMap)
		{
		}

		public void UpdateCircuitData(bool updateAttachment = false, bool recalcStream = false)
		{
		}

		public void Update(double deltaSpeedParTile)
		{
		}

		public static int GetPipeTileIndex(eLuggage ink)
		{
			return 0;
		}

		public static int GetInkBottleIndex(eLuggage ink)
		{
			return 0;
		}

		public static eLuggage InkToBottle(eLuggage ink)
		{
			return default(eLuggage);
		}

		public static eLuggage InkToBottleIfInk(eLuggage ink)
		{
			return default(eLuggage);
		}

		public static eLuggage BottleToInk(eLuggage bottle)
		{
			return default(eLuggage);
		}

		public static eLuggage BottleToInkIfBottle(eLuggage bottle)
		{
			return default(eLuggage);
		}

		public static bool HasInk(eLuggage id)
		{
			return false;
		}

		public static bool HasInkBottle(eLuggage id)
		{
			return false;
		}

		public static DTileBase2[] GetPipeTiles(bool inkLevel = false, bool pipeFunnel = false)
		{
			return null;
		}

		public static DTileBase2 GetPipeTile(eLuggage ink, bool inkLevel = false, bool pipeFunnel = false)
		{
			return null;
		}

		public static void CalcPartsName(Dir.DirFlag pipeLinkDir, out string partsName)
		{
			partsName = null;
		}
	}
}
