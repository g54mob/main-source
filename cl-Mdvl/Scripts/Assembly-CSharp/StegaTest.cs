using System;
using System.Diagnostics;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using UnityEngine;

public class StegaTest : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			DoBench(10000);
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StegaTest.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Dass ist ein debuzzzz ");
				messageBuilder.AppendFormatted(Time.time);
			}
			Log.Debug(messageBuilder);
		}
	}

	private static void DoBench(int iterations)
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		BenchNoLogging(iterations);
		stopwatch.Stop();
		long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
		Stopwatch stopwatch2 = Stopwatch.StartNew();
		BenchLogging(iterations);
		stopwatch2.Stop();
		long elapsedMilliseconds2 = stopwatch2.ElapsedMilliseconds;
		float num = elapsedMilliseconds2 - elapsedMilliseconds;
		float num2 = num / (float)iterations;
		UnityEngine.Debug.Log($"Baseline {iterations} iters: {elapsedMilliseconds}ms");
		UnityEngine.Debug.Log($"With logging {iterations} iters: {elapsedMilliseconds2}ms");
		UnityEngine.Debug.Log($"Logging overhead {iterations} iters: total {num}ms, per log message {num2:F8}ms");
	}

	private static void BenchNoLogging(int iterations)
	{
		for (int i = 0; i < iterations; i++)
		{
			_ = Time.time;
			_ = DateTime.Now;
			Vector3 vector = UnityEngine.Random.onUnitSphere * UnityEngine.Random.value * 100f;
			Vector3 vector2 = UnityEngine.Random.onUnitSphere * UnityEngine.Random.value * 1000f;
			Vector3.Cross(vector + vector2, vector2);
		}
	}

	private static void BenchLogging(int iterations)
	{
		for (int i = 0; i < iterations; i++)
		{
			float time = Time.time;
			DateTime now = DateTime.Now;
			Vector3 lhs = UnityEngine.Random.onUnitSphere * UnityEngine.Random.value * 100f;
			Vector3 vector = UnityEngine.Random.onUnitSphere * UnityEngine.Random.value * 1000f;
			lhs += vector;
			lhs = Vector3.Cross(lhs, vector);
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(14, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\StegaTest.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Iteracija ");
				messageBuilder.AppendFormatted(i);
				messageBuilder.AppendLiteral(" ");
				messageBuilder.AppendFormatted(time);
				messageBuilder.AppendLiteral(" ");
				messageBuilder.AppendFormatted(now);
				messageBuilder.AppendLiteral(" ");
				messageBuilder.AppendFormatted(lhs);
				messageBuilder.AppendLiteral(" ");
				messageBuilder.AppendFormatted(vector);
			}
			Log.Debug(messageBuilder);
		}
	}
}
