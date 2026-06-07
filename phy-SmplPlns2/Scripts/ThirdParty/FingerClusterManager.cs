using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("FingerGestures/Components/Finger Cluster Manager")]
public class FingerClusterManager : MonoBehaviour
{
	[Serializable]
	public class Cluster
	{
		public int Id;

		public float StartTime;

		public FingerGestures.FingerList Fingers = new FingerGestures.FingerList();

		public void Reset()
		{
			Fingers.Clear();
		}
	}

	public DistanceUnit DistanceUnit;

	public float ClusterRadius = 250f;

	public float TimeTolerance = 0.5f;

	private int lastUpdateFrame = -1;

	private int nextClusterId = 1;

	private List<Cluster> clusters;

	private List<Cluster> clusterPool;

	private FingerGestures.FingerList fingersAdded;

	private FingerGestures.FingerList fingersRemoved;

	public FingerGestures.IFingerList FingersAdded => fingersAdded;

	public FingerGestures.IFingerList FingersRemoved => fingersRemoved;

	public List<Cluster> Clusters => clusters;

	public List<Cluster> GetClustersPool()
	{
		return clusterPool;
	}

	private void Awake()
	{
		clusters = new List<Cluster>();
		clusterPool = new List<Cluster>();
		fingersAdded = new FingerGestures.FingerList();
		fingersRemoved = new FingerGestures.FingerList();
	}

	public void Update()
	{
		if (lastUpdateFrame == Time.frameCount)
		{
			return;
		}
		lastUpdateFrame = Time.frameCount;
		fingersAdded.Clear();
		fingersRemoved.Clear();
		for (int i = 0; i < FingerGestures.Instance.MaxFingers; i++)
		{
			FingerGestures.Finger finger = FingerGestures.GetFinger(i);
			if (finger.IsDown)
			{
				if (!finger.WasDown)
				{
					fingersAdded.Add(finger);
				}
			}
			else if (finger.WasDown)
			{
				fingersRemoved.Add(finger);
			}
		}
		for (int j = 0; j < fingersRemoved.Count; j++)
		{
			FingerGestures.Finger touch = fingersRemoved[j];
			for (int num = clusters.Count - 1; num >= 0; num--)
			{
				Cluster cluster = clusters[num];
				if (cluster.Fingers.Remove(touch) && cluster.Fingers.Count == 0)
				{
					clusters.RemoveAt(num);
					clusterPool.Add(cluster);
				}
			}
		}
		for (int k = 0; k < fingersAdded.Count; k++)
		{
			FingerGestures.Finger finger2 = fingersAdded[k];
			Cluster cluster2 = FindExistingCluster(finger2);
			if (cluster2 == null)
			{
				cluster2 = NewCluster();
				cluster2.StartTime = finger2.StarTime;
			}
			cluster2.Fingers.Add(finger2);
		}
	}

	public Cluster FindClusterById(int clusterId)
	{
		return clusters.Find((Cluster c) => c.Id == clusterId);
	}

	private Cluster NewCluster()
	{
		Cluster cluster = null;
		if (clusterPool.Count == 0)
		{
			cluster = new Cluster();
		}
		else
		{
			int index = clusterPool.Count - 1;
			cluster = clusterPool[index];
			cluster.Reset();
			clusterPool.RemoveAt(index);
		}
		cluster.Id = nextClusterId++;
		clusters.Add(cluster);
		return cluster;
	}

	private Cluster FindExistingCluster(FingerGestures.Finger finger)
	{
		Cluster result = null;
		float num = float.MaxValue;
		float num2 = FingerGestures.Convert(ClusterRadius * ClusterRadius, DistanceUnit, DistanceUnit.Pixels);
		for (int i = 0; i < clusters.Count; i++)
		{
			Cluster cluster = clusters[i];
			if (!(finger.StarTime - cluster.StartTime > TimeTolerance))
			{
				Vector2 averagePosition = cluster.Fingers.GetAveragePosition();
				float num3 = Vector2.SqrMagnitude(finger.Position - averagePosition);
				if (num3 < num && num3 < num2)
				{
					result = cluster;
					num = num3;
				}
			}
		}
		return result;
	}
}
