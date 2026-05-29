using System.Collections.Generic;
using Os.Utils;
using Placemaker.Modules;
using Unity.Mathematics;

namespace Placemaker
{
	public static class ModuleMath
	{
		public const byte uprightOrientationCount = 8;

		public const int voxelMaterialCount = 15;

		public const float arbitraryGroundOffset = 0.2f;

		public const float arbitraryWaterOffset = -0.1f;

		public static readonly SbyteFloat3[] corners;

		public static readonly ByteQube qubeForward;

		public static readonly ByteQube qubeBackward;

		public static readonly ByteQube qubeUpsideDown;

		public static readonly List<Orientation> orientations;

		public static readonly byte[,] orientationMulLookup;

		public static readonly byte[] orientationInverseLookup;

		public static readonly int4x4[] sideMatrices;

		public static readonly int4x4[] invSideMatrices;

		public static readonly int[,] cornerLinkLookup;

		public static readonly float2[] baryVectors;

		public static readonly ByteQube groundByteQube;

		public static readonly ByteQube anyByteQube;

		public const byte emptyByte = 18;

		public const byte waterByte = 17;

		public const byte groundByte = 15;

		public const byte anyByte = 16;

		static ModuleMath()
		{
		}

		public static int GetCornerLinkIndex(int cornerA, int cornerB)
		{
			return 0;
		}

		public static bool AreCornersLinked(int cornerA, int cornerB, int link)
		{
			return false;
		}

		public static Orientation Mul(Orientation parent, Orientation child)
		{
			return default(Orientation);
		}

		public static byte MulOrientations(byte orientationIndex0, byte orientationIndex1)
		{
			return 0;
		}

		public static byte MulOrientations(int orientationIndex0, int orientationIndex1)
		{
			return 0;
		}

		public static byte InvertOrientation(int orientationIndex0)
		{
			return 0;
		}

		public static ByteQube MarkHiddenCornersAmbigous(ByteQube byteQube)
		{
			return default(ByteQube);
		}

		public static ByteQube GetIndexedMaterials(ByteQube materials)
		{
			return default(ByteQube);
		}

		public static int GetMaterialCount(ByteQube materials)
		{
			return 0;
		}

		public static int3 MultiplyPoint(int4x4 m, int3 p)
		{
			return default(int3);
		}

		public static SbyteFloat3 MultiplyPoint(int4x4 m, SbyteFloat3 p)
		{
			return default(SbyteFloat3);
		}

		public static int3 MultiplyVector(int4x4 m, int3 p)
		{
			return default(int3);
		}

		public static SbyteFloat3 MultiplyVector(int4x4 m, SbyteFloat3 p)
		{
			return default(SbyteFloat3);
		}

		public static int3x2 MultiplyBounds(int4x4 m, int3x2 bounds)
		{
			return default(int3x2);
		}

		public static int GetBidirectionalHash(this OrientedModule orientedModule0, OrientedModule orientedModule1)
		{
			return 0;
		}

		public static int GetDoubleHash(this OrientedModule orientedModule0, OrientedModule orientedModule1)
		{
			return 0;
		}
	}
}
