using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace FIMSpace.FOptimizing
{
	public class Optimizers_DynamicClock
	{
		private int[] avgTicks;

		private int avgCounter;

		private Stopwatch watch;

		private static WaitForEndOfFrame waitForLateUpdate = null;

		private static readonly WaitForSecondsRealtime wait0001 = new WaitForSecondsRealtime(0.001f);

		private static readonly WaitForSecondsRealtime wait0005 = new WaitForSecondsRealtime(0.005f);

		private static readonly WaitForSecondsRealtime wait001 = new WaitForSecondsRealtime(0.01f);

		private static readonly WaitForSecondsRealtime wait005 = new WaitForSecondsRealtime(0.05f);

		private static readonly WaitForSecondsRealtime wait01 = new WaitForSecondsRealtime(0.1f);

		private static readonly WaitForSecondsRealtime wait02 = new WaitForSecondsRealtime(0.2f);

		private static readonly WaitForSecondsRealtime wait04 = new WaitForSecondsRealtime(0.4f);

		private static readonly WaitForSecondsRealtime wait08 = new WaitForSecondsRealtime(0.8f);

		private static readonly WaitForSecondsRealtime wait14 = new WaitForSecondsRealtime(1.4f);

		private static readonly WaitForSecondsRealtime wait2 = new WaitForSecondsRealtime(2f);

		private static readonly WaitForSecondsRealtime wait3 = new WaitForSecondsRealtime(3f);

		private static readonly WaitForSecondsRealtime wait5 = new WaitForSecondsRealtime(5f);

		private readonly float delayTolerance;

		private readonly float updateRatio;

		private readonly float maxDelay;

		public OptimizersManager Manager { get; private set; }

		public List<Optimizer_Base> Optimizers { get; private set; }

		public EOptimizingDistance OptimizingDistanceType { get; private set; }

		public long FrameTicksConsumption { get; private set; }

		public long LastMSConsumption { get; private set; }

		public long LastTicksConsumption { get; private set; }

		public int LastTickFrame { get; private set; }

		public int DelaysCount { get; private set; }

		public float AdaptedDelay { get; private set; }

		public Optimizers_DynamicClock(OptimizersManager manager, EOptimizingDistance type, List<Optimizer_Base> optimizers)
		{
			Manager = manager;
			OptimizingDistanceType = type;
			Optimizers = optimizers;
			if (waitForLateUpdate == null)
			{
				waitForLateUpdate = new WaitForEndOfFrame();
			}
			watch = new Stopwatch();
			AdaptedDelay = 0.01f;
			LastMSConsumption = 0L;
			FrameTicksConsumption = 0L;
			LastTicksConsumption = 0L;
			DelaysCount = 0;
			int num = 10;
			switch ((int)type)
			{
			case 0:
				updateRatio = 0.1f;
				maxDelay = 0.3f;
				num = 10;
				delayTolerance = 3.5f;
				break;
			case 1:
				updateRatio = 0.4f;
				maxDelay = 1.1f;
				num = 7;
				delayTolerance = 1.6f;
				break;
			case 2:
				updateRatio = 0.75f;
				maxDelay = 1.5f;
				num = 5;
				delayTolerance = 1.3f;
				break;
			case 3:
				updateRatio = 1.25f;
				maxDelay = 3f;
				num = 4;
				delayTolerance = 1.15f;
				break;
			case 4:
				updateRatio = 2.25f;
				maxDelay = 6f;
				num = 4;
				delayTolerance = 1f;
				break;
			}
			avgTicks = new int[num];
			for (int i = 0; i < avgTicks.Length; i++)
			{
				avgTicks[i] = 0;
			}
			AdaptedDelay = updateRatio + 0.001f;
		}

		public IEnumerator WatchUpdate()
		{
			yield return null;
			yield return null;
			while (true)
			{
				if (Optimizers.Count == 0)
				{
					yield return null;
				}
				long totalElapsed = 0L;
				long totalTicks = 0L;
				DelaysCount = 0;
				float num = Mathf.Lerp(1f, 2.375f, Manager.UpdateBoost);
				int ticksLimit = (int)(5000f * num * delayTolerance);
				if (!Manager)
				{
					break;
				}
				watch.Start();
				if ((bool)Manager.TargetCamera)
				{
					for (int i = Optimizers.Count - 1; i >= 0; i--)
					{
						if (Optimizers[i] == null)
						{
							Optimizers.RemoveAt(i);
						}
						else
						{
							Manager.CheckElement(Optimizers[i], i);
							if (watch.ElapsedTicks > ticksLimit)
							{
								watch.Stop();
								yield return null;
								DelaysCount++;
								totalElapsed += watch.ElapsedMilliseconds;
								totalTicks += watch.ElapsedTicks;
								FrameTicksConsumption = watch.ElapsedTicks;
								watch.Reset();
								watch.Start();
							}
						}
					}
				}
				watch.Stop();
				LastMSConsumption = totalElapsed + watch.ElapsedMilliseconds;
				LastTicksConsumption = totalTicks + watch.ElapsedTicks;
				AddAverage((int)LastTicksConsumption);
				UpdateAdaptation();
				if (AdaptedDelay < 0.001f)
				{
					yield return null;
				}
				else
				{
					float elapsed = 0f;
					while (elapsed < AdaptedDelay)
					{
						elapsed += Time.unscaledDeltaTime;
						yield return null;
					}
				}
				FrameTicksConsumption = watch.ElapsedTicks;
				watch.Reset();
				LastTickFrame = Time.frameCount;
			}
			UnityEngine.Debug.LogError("[OPTIMIZERS] Manager is not existing anymore! Stopping dynamic clock! (" + OptimizingDistanceType.ToString() + ")");
			UnityEngine.Debug.Log("Break");
		}

		private void UpdateAdaptation()
		{
			float num = maxDelay;
			float num2 = 1f;
			if (Manager.UpdateBoost > 0f)
			{
				num2 = 1f + Manager.UpdateBoost * 2f;
				num = maxDelay / (1f + Manager.UpdateBoost);
				if (OptimizingDistanceType < EOptimizingDistance.Far)
				{
					num /= 1f + Manager.UpdateBoost;
					num2 = 1f + Manager.UpdateBoost * 5f;
				}
				else if (OptimizingDistanceType == EOptimizingDistance.Far)
				{
					num /= 1f + Manager.UpdateBoost / 2f;
					num2 = 1f + Manager.UpdateBoost * 3f;
				}
				else if (OptimizingDistanceType == EOptimizingDistance.Farthest)
				{
					num /= 1f + Manager.UpdateBoost / 1.5f;
					num2 = 1f + Manager.UpdateBoost * 2.5f;
				}
			}
			AdaptedDelay = (float)GetAverage() / 30000f * updateRatio / num2;
			if (AdaptedDelay > num)
			{
				AdaptedDelay = num;
			}
		}

		private WaitForSecondsRealtime GetMostAccurateWait(float val)
		{
			if (val < 0.0002f)
			{
				return null;
			}
			if (val < Time.deltaTime)
			{
				return null;
			}
			if (val < 0.002f)
			{
				return wait0001;
			}
			if (val < 0.01f)
			{
				return wait0005;
			}
			if (val < 0.02f)
			{
				return wait001;
			}
			if (val < 0.075f)
			{
				return wait005;
			}
			if (val < 0.175f)
			{
				return wait01;
			}
			if (val < 0.3f)
			{
				return wait02;
			}
			if (val < 0.55f)
			{
				return wait04;
			}
			if (val < 0.875f)
			{
				return wait08;
			}
			if (val < 1.75f)
			{
				return wait14;
			}
			if (val < 2.75f)
			{
				return wait2;
			}
			if (val < 4f)
			{
				return wait3;
			}
			return wait5;
		}

		private void AddAverage(int ticks)
		{
			avgTicks[avgCounter] = ticks;
			avgCounter++;
			if (avgCounter >= avgTicks.Length)
			{
				avgCounter = 0;
			}
		}

		public int GetAverage()
		{
			int num = 0;
			for (int i = 0; i < avgTicks.Length; i++)
			{
				num += avgTicks[i];
			}
			return num / avgTicks.Length;
		}
	}
}
