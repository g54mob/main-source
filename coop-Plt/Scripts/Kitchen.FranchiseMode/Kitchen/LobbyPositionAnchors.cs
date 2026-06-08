using System.Collections.Generic;
using UnityEngine;

namespace Kitchen
{
	public static class LobbyPositionAnchors
	{
		public static Vector3 Office = new Vector3(-1f, 0f, -3f);

		public static Vector3 Kitchen = new Vector3(-1f, 0f, 7f);

		public static Vector3 Contracts = new Vector3(-3f, 0f, 5f);

		public static Vector3 Garage = new Vector3(-9f, 0f, -3f);

		public static Vector3 Workshop = new Vector3(-6f, 0f, 4f);

		public static Vector3 StartMarker = new Vector3(-8.5f, 0f, -7.5f);

		public static Vector3 Stats = new Vector3(7f, 0f, -4f);

		public static List<Vector3> Bedrooms = new List<Vector3>
		{
			new Vector3(10f, 0f, 6f),
			new Vector3(10f, 0f, 3f),
			new Vector3(10f, 0f, 0f),
			new Vector3(10f, 0f, -3f)
		};
	}
}
