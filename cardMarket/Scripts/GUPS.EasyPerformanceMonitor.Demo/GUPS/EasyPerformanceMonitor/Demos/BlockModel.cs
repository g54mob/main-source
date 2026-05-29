using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Demos
{
	public class BlockModel
	{
		public byte SizeX { get; private set; }

		public byte SizeY { get; private set; }

		public byte SizeZ { get; private set; }

		public Vector3 Size
		{
			get
			{
				return new Vector3((int)SizeX, (int)SizeY, (int)SizeZ);
			}
			private set
			{
				SizeX = (byte)value.x;
				SizeY = (byte)value.y;
				SizeZ = (byte)value.z;
			}
		}

		public Block[] BlockArray { get; private set; }

		public BlockModel()
		{
			BlockArray = new Block[0];
			Size = Vector3.zero;
		}

		public BlockModel(Block[] _BlockArray, Vector3 _Size)
		{
			BlockArray = _BlockArray;
			Size = _Size;
		}

		public Block GetBlock(int _X, int _Y, int _Z)
		{
			if (_X >= SizeX || _X < 0 || _Y >= SizeY || _Y < 0 || _Z >= SizeZ || _Z < 0)
			{
				return null;
			}
			int num = _X + SizeX * (_Y + SizeY * _Z);
			return BlockArray[num];
		}

		public bool SetBlock(int _X, int _Y, int _Z, Color _Color)
		{
			if (_X >= SizeX || _X < 0 || _Y >= SizeY || _Y < 0 || _Z >= SizeZ || _Z < 0)
			{
				return false;
			}
			int num = _X + SizeX * (_Y + SizeY * _Z);
			BlockArray[num] = new Block(_Color);
			return true;
		}
	}
}
