using UnityEngine;

public class GraphItDataInternal
{
	public float[] mDataPoints;

	public float mCounter;

	public float mMin;

	public float mMax;

	public float mAvg;

	public float mFastAvg;

	public Color mColor;

	public GraphItDataInternal(int subgraph_index)
	{
		mDataPoints = new float[2048];
		mCounter = 0f;
		mMin = 0f;
		mMax = 0f;
		mAvg = 0f;
		mFastAvg = 0f;
		Random.State state = Random.state;
		Random.InitState(subgraph_index + 1);
		mColor = Random.ColorHSV(0f, 1f, 0f, 1f, 0.5f, 1f);
		Random.state = state;
	}
}
