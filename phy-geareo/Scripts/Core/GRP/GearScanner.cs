using UnityEngine;

namespace GRP
{
	public abstract class GearScanner
	{
		public static GearScanner[,] scanners;

		public abstract GearContact CheckContact(IGear a, IGear b);

		public abstract GearJoint CreateJoint(IGear a, IGear b, GearContact contact);

		static GearScanner()
		{
		}

		public static GearScanner GetScanner(GearType a, GearType b)
		{
			return null;
		}

		public static bool ContainsInBetween(Transform gear, Vector3 start, Vector3 end, Vector3 point)
		{
			return false;
		}

		public static void DrawMyLine(Vector3 point, Vector3 start, Vector3 end, float attachDistance)
		{
		}

		public static float ProjectPointToSegmentDistance(Vector3 P, Vector3 A, Vector3 B)
		{
			return 0f;
		}

		public static Vector3 ProjectPointToSegment(Vector3 P, Vector3 A, Vector3 B)
		{
			return default(Vector3);
		}
	}
}
