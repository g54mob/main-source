using System;

namespace Shapes
{
	internal static class PolylineJoinsExtensions
	{
		public static bool HasJoinMesh(this PolylineJoins join)
		{
			return join switch
			{
				PolylineJoins.Simple => false, 
				PolylineJoins.Miter => false, 
				PolylineJoins.Round => true, 
				PolylineJoins.Bevel => true, 
				_ => throw new ArgumentOutOfRangeException("join", join, null), 
			};
		}

		public static bool HasSimpleJoin(this PolylineJoins join)
		{
			return join switch
			{
				PolylineJoins.Simple => false, 
				PolylineJoins.Miter => false, 
				PolylineJoins.Round => false, 
				PolylineJoins.Bevel => true, 
				_ => throw new ArgumentOutOfRangeException("join", join, null), 
			};
		}
	}
}
