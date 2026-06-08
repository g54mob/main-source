using Stonescript.Compiler;
using UnityEngine;

public class ScriptProfiler : MonoBehaviour
{
	public Script script;

	public long[] times = new long[1000];

	public int[] counts = new int[1000];

	public long[] avgTime = new long[1000];

	public void Sample(int line, long time)
	{
		times[line] += time;
		counts[line]++;
		avgTime[line] = times[line] / counts[line];
	}
}
