using System;
using System.Runtime.CompilerServices;

internal struct GfljHBAovUzdpBJEYAWMmOHvXOVz
{
	private int wOhFbbCjdNIwyKIUYwdAKnCIgHeIA;

	private long bWbUGBTcYlGmudZAiQNYPwXEKJFH;

	private static readonly bool AqlgYhpiawWLohMRvUCdGCpFbOmq;

	public static readonly int rLHQOyRfdJDAlRijVsIrqLCtxudh;

	static GfljHBAovUzdpBJEYAWMmOHvXOVz()
	{
		AqlgYhpiawWLohMRvUCdGCpFbOmq = IntPtr.Size == 8;
		rLHQOyRfdJDAlRijVsIrqLCtxudh = (AqlgYhpiawWLohMRvUCdGCpFbOmq ? 8 : 4);
	}

	public static GfljHBAovUzdpBJEYAWMmOHvXOVz jSizCOLLvVXQoXOWJvvVCGtPBZBJ(byte[] P_0, int P_1)
	{
		GfljHBAovUzdpBJEYAWMmOHvXOVz result = default(GfljHBAovUzdpBJEYAWMmOHvXOVz);
		if (AqlgYhpiawWLohMRvUCdGCpFbOmq)
		{
			result.bWbUGBTcYlGmudZAiQNYPwXEKJFH = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.wOhFbbCjdNIwyKIUYwdAKnCIgHeIA = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static int wdnIPNBlnUYbKQtvHGtzINNFoKwE(GfljHBAovUzdpBJEYAWMmOHvXOVz P_0)
	{
		if (AqlgYhpiawWLohMRvUCdGCpFbOmq)
		{
			return (int)P_0.bWbUGBTcYlGmudZAiQNYPwXEKJFH;
		}
		return P_0.wOhFbbCjdNIwyKIUYwdAKnCIgHeIA;
	}

	[SpecialName]
	public static long wdnIPNBlnUYbKQtvHGtzINNFoKwE(GfljHBAovUzdpBJEYAWMmOHvXOVz P_0)
	{
		if (AqlgYhpiawWLohMRvUCdGCpFbOmq)
		{
			return P_0.bWbUGBTcYlGmudZAiQNYPwXEKJFH;
		}
		return P_0.wOhFbbCjdNIwyKIUYwdAKnCIgHeIA;
	}

	public string heWBXspmZSrJzTEGGPLFcgTaCdIBA()
	{
		if (AqlgYhpiawWLohMRvUCdGCpFbOmq)
		{
			return bWbUGBTcYlGmudZAiQNYPwXEKJFH.ToString();
		}
		return wOhFbbCjdNIwyKIUYwdAKnCIgHeIA.ToString();
	}
}
