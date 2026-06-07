using System;
using System.Collections.Generic;
using UnityEngine;

namespace Libs
{
	public static class Dir
	{
		public enum Rot
		{
			R = 0,
			U = 1,
			L = 2,
			D = 3,
			R2 = 4,
			U2 = 5,
			L2 = 6,
			D2 = 7,
			R3 = 8,
			U3 = 9,
			L3 = 10,
			D3 = 11,
			R4 = 12,
			U4 = 13,
			L4 = 14,
			D4 = 15
		}

		[Obsolete]
		public enum RotObsolete
		{
			右 = 0,
			上 = 1,
			左 = 2,
			下 = 3
		}

		[Flags]
		public enum DirFlag
		{
			N = 0,
			R = 1,
			U = 2,
			L = 4,
			D = 8
		}

		public enum RotCombineType
		{
			RightAngleOnly = 0,
			TwinAngle = 1
		}

		private static Dictionary<Rot, string> _rotStringCache;

		public static DirFlag Reverse(this DirFlag self)
		{
			return default(DirFlag);
		}

		public static DirFlag Opposite(this DirFlag self)
		{
			return default(DirFlag);
		}

		public static Vector2Int[] GetDirAddr(Vector2Int addr, DirFlag dirFlag, Rot rot)
		{
			return null;
		}

		public static Vector2Int GetDirAddrFirst(Vector2Int addr, DirFlag dir, Rot rot)
		{
			return default(Vector2Int);
		}

		public static bool CheckDirAddr(Vector2Int neighbor, Vector2Int addr, DirFlag dir, Rot rot)
		{
			return false;
		}

		public static List<Vector2Int> GetDirAddrList(Vector2Int addr, DirFlag dir, Rot rot)
		{
			return null;
		}

		public static List<Vector2Int> AddrList(this DirFlag self, Vector2Int addr)
		{
			return null;
		}

		public static (int[], int) AnticlockwiseAddrs(Vector2Int[] addrs)
		{
			return default((int[], int));
		}

		public static Rot LookAt(Vector2Int self, Vector2Int target)
		{
			return default(Rot);
		}

		public static string LookAtString(Vector2Int self, Vector2Int? target)
		{
			return null;
		}

		public static DirFlag LookAtToDirFlag(Vector2Int self, Vector2Int target)
		{
			return default(DirFlag);
		}

		public static Rot GetCombinedRot(Rot baseAngle, Rot rot, RotCombineType type)
		{
			return default(Rot);
		}

		public static Rot GetSwapRot(Rot old)
		{
			return default(Rot);
		}

		public static Rot GetNextRot(Rot old, bool hasToggle)
		{
			return default(Rot);
		}

		public static Rot GetPrevRot(Rot old, bool hasToggle)
		{
			return default(Rot);
		}

		public static Rot GetNextInRot(Rot old)
		{
			return default(Rot);
		}

		public static Rot GetPrevInRot(Rot old)
		{
			return default(Rot);
		}

		public static Rot GetNextOutRot(Rot old)
		{
			return default(Rot);
		}

		public static Rot GetPrevOutRot(Rot old)
		{
			return default(Rot);
		}

		public static bool IsEqualBaseRot(Rot a, Rot b)
		{
			return false;
		}

		public static Rot RotParse(string rot)
		{
			return default(Rot);
		}

		public static string RotToString(this Rot self)
		{
			return null;
		}
	}
}
