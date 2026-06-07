using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FrameDistributor : MonoBehaviour
{
	private class DistributeObject
	{
		public List<IDistributee> Objects;

		public int Start;

		public int End;

		public float Delta;

		public ThreadCountdown Counter;

		public DistributeObject(List<IDistributee> objects, ThreadCountdown counter)
		{
			Objects = objects;
			Counter = counter;
		}

		public void SetClip(int start, int end)
		{
			Start = start;
			End = end;
		}
	}

	[NonSerialized]
	private List<IDistributee> Objects = new List<IDistributee>();

	[NonSerialized]
	private int LastItem;

	public int MaxObjectsPerFrame = 50;

	public bool RunEverything;

	public bool RunSecond;

	public bool Threaded;

	public bool PauseWithGame;

	public bool EverythingPerSecond;

	[NonSerialized]
	private ThreadCountdown _counter = new ThreadCountdown(0);

	[NonSerialized]
	private List<DistributeObject> _threadStatePool = new List<DistributeObject>();

	private void RunThread(object state)
	{
		DistributeObject distributeObject = (DistributeObject)state;
		int num = Mathf.Min(distributeObject.End, distributeObject.Objects.Count);
		for (int i = distributeObject.Start; i < num; i++)
		{
			if (RunSecond)
			{
				Objects[i].UpdateNow2(distributeObject.Delta);
			}
			else
			{
				Objects[i].UpdateNow(distributeObject.Delta);
			}
		}
		distributeObject.Counter.FinishTask();
	}

	private void FixedUpdate()
	{
		if (PauseWithGame && GameSettings.GameSpeed == 0f)
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		if (RunEverything)
		{
			for (int i = 0; i < Objects.Count; i++)
			{
				if (RunSecond)
				{
					Objects[i].UpdateNow2(deltaTime);
				}
				else
				{
					Objects[i].UpdateNow(deltaTime);
				}
			}
		}
		else if (Threaded)
		{
			if (Objects.Count > 0)
			{
				int num = Mathf.CeilToInt((float)Objects.Count / (float)MaxObjectsPerFrame);
				_counter.Reset(num);
				for (int j = _threadStatePool.Count; j < num; j++)
				{
					_threadStatePool.Add(new DistributeObject(Objects, _counter));
				}
				for (int k = 0; k < num; k++)
				{
					DistributeObject distributeObject = _threadStatePool[k];
					distributeObject.Delta = deltaTime;
					distributeObject.SetClip(k * MaxObjectsPerFrame, k * MaxObjectsPerFrame + MaxObjectsPerFrame);
					ThreadPool.QueueUserWorkItem(RunThread, distributeObject);
				}
				_counter.Wait();
			}
		}
		else
		{
			if (Objects.Count <= 0)
			{
				return;
			}
			int num2 = (EverythingPerSecond ? Mathf.CeilToInt((float)Objects.Count * deltaTime) : MaxObjectsPerFrame);
			float delta = deltaTime * (float)Mathf.CeilToInt((float)Objects.Count / (float)num2);
			if (LastItem >= Objects.Count)
			{
				LastItem = 0;
			}
			bool flag = false;
			for (int l = 0; l < num2; l++)
			{
				int num3 = LastItem + l;
				if (num3 >= Objects.Count)
				{
					LastItem = 0;
					flag = true;
					break;
				}
				if (Objects[num3].NeedUpdate(!RunSecond))
				{
					if (RunSecond)
					{
						Objects[num3].UpdateNow2(delta);
					}
					else
					{
						Objects[num3].UpdateNow(delta);
					}
				}
			}
			if (!flag)
			{
				LastItem += num2;
				if (LastItem >= Objects.Count)
				{
					LastItem = 0;
				}
			}
		}
	}

	public void RegisterObject(IDistributee obj)
	{
		Objects.Add(obj);
	}

	public void UnregisterObject(IDistributee obj)
	{
		Objects.Remove(obj);
	}
}
