using System;
using UnityEngine;

public class ConeSampler : MonoBehaviour
{
	public enum TimingMode
	{
		SamplesPerFrame = 0,
		OneSampleEveryNFrames = 1
	}

	public float coneAngle = 20f;

	public float maxDistance = 10f;

	public bool useCustomHitWeightFunction;

	public Func<RaycastHit, float> weightFunction;

	public TimingMode timingMode;

	public int timingRate = 1;

	public int sampleBufferSize = 30;

	public LayerMask sampleLayers;

	[Header("Debug")]
	public bool drawDebugRays;

	[NonSerialized]
	[Tooltip("Average value (buffer sum divided by sampleSize)")]
	public float average;

	private float[] buffer;

	private float sum;

	private int bufferIndex;

	private int frameCounter;

	private RaycastHit hit;

	private void Start()
	{
		buffer = new float[sampleBufferSize];
	}

	private void Update()
	{
		if (timingMode == TimingMode.SamplesPerFrame)
		{
			for (int i = 0; i < timingRate; i++)
			{
				DoSample();
			}
			return;
		}
		frameCounter++;
		if (frameCounter >= timingRate)
		{
			frameCounter = 0;
			DoSample();
		}
	}

	private void DoSample()
	{
		Vector3 direction = Quaternion.AngleAxis(UnityEngine.Random.Range(0, 360), base.transform.forward) * Quaternion.AngleAxis(UnityEngine.Random.Range(0f, coneAngle), base.transform.right) * base.transform.forward;
		bool num = Physics.Raycast(base.transform.position, direction, out hit, maxDistance, sampleLayers.value);
		sum -= buffer[bufferIndex];
		float num2 = ((!num) ? 0f : (useCustomHitWeightFunction ? weightFunction(hit) : 1f));
		buffer[bufferIndex] = num2;
		sum += num2;
		bufferIndex = (bufferIndex + 1) % buffer.Length;
		average = sum / (float)sampleBufferSize;
	}
}
