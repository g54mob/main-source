using System;
using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

public class StressDebuggerMaster : MonoBehaviour
{
	public StressDebugSO dataAsset;

	private int lastFixedUpdateFrame = -1;

	private StressDebugSession session;

	public string sessionName;

	[Header("Visualization")]
	public float stressScale = 1f;

	public int sessionIndex;

	public int frameIndex;

	public Gradient stressGradient;

	private void Start()
	{
		if (dataAsset == null)
		{
			Debug.LogError("StressDebuggerMaster doesn't have a data asset assigned", base.gameObject);
			return;
		}
		session = new StressDebugSession();
		session.startTimestamp = DateTime.Now.ToString("yyy MMM dd HH':'mm':'ss");
		if (dataAsset.sessions == null)
		{
			dataAsset.sessions = new List<StressDebugSession>();
		}
		dataAsset.sessions.Add(session);
		TrainCar[] array = UnityEngine.Object.FindObjectsOfType<TrainCar>();
		foreach (TrainCar car in array)
		{
			OnCarSpawned(car);
		}
		SingletonBehaviour<CarSpawner>.Instance.CarSpawned += OnCarSpawned;
	}

	private void OnDestroy()
	{
		SingletonBehaviour<CarSpawner>.Instance.CarSpawned -= OnCarSpawned;
	}

	private void OnCarSpawned(TrainCar car)
	{
		TrainStressDebug trainStressDebug = car.gameObject.AddComponent<TrainStressDebug>();
		trainStressDebug.trainIndex = session.numCars;
		session.numCars++;
		trainStressDebug.StressDataSubmitted += OnStressDataSubmitted;
	}

	private FrameData GetListsObject()
	{
		int num = (int)((double)Time.fixedTime / (double)Time.fixedDeltaTime);
		if (num > lastFixedUpdateFrame)
		{
			lastFixedUpdateFrame = num;
			FrameData frameData = new FrameData();
			frameData.fixedUpdateFrame = lastFixedUpdateFrame;
			frameData.fixedDeltaTime = Time.fixedDeltaTime;
			session.frames.Add(frameData);
			return frameData;
		}
		return session.frames[session.frames.Count - 1];
	}

	private void OnStressDataSubmitted(TrainStressFrameData stressData)
	{
		GetListsObject().trainStressData.Add(stressData);
	}
}
