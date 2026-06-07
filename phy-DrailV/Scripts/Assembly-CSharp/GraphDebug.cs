using System.Collections.Generic;
using UnityEngine;

public class GraphDebug
{
	public static float YMin;

	public static float YMax;

	public const int MAX_HISTORY = 1024;

	public static List<GraphDebugChannel> channels;

	private static Color[] colors;

	static GraphDebug()
	{
		YMin = -1f;
		YMax = 1f;
		colors = new Color[8]
		{
			Color.red,
			Color.green,
			Color.blue,
			Color.magenta,
			Color.yellow,
			Color.black,
			Color.cyan,
			Color.gray
		};
		channels = new List<GraphDebugChannel>();
	}

	private static Color GetColorForIndex(int i)
	{
		return colors[i % colors.Length];
	}

	public static GraphDebugChannel GetChannel()
	{
		GraphDebugChannel graphDebugChannel = new GraphDebugChannel(GetColorForIndex(channels.Count));
		channels.Add(graphDebugChannel);
		return graphDebugChannel;
	}
}
