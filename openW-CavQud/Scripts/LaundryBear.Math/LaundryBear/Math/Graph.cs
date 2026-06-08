using UnityEngine;

namespace LaundryBear.Math
{
	public class Graph
	{
		public static float YMin;

		public static float YMax;

		public const int MAX_HISTORY = 1024;

		public const int MAX_CHANNELS = 3;

		public static Channel[] channel;

		static Graph()
		{
			YMin = -1f;
			YMax = 1f;
			channel = new Channel[3];
			channel[0] = new Channel(Color.red);
			channel[1] = new Channel(Color.green);
			channel[2] = new Channel(Color.blue);
		}
	}
}
