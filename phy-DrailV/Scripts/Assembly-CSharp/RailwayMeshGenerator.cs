using System;
using System.Collections.Generic;
using System.Linq;
using DV;
using DV.OriginShift;
using DV.PointSet;
using DV.Utils;
using MeshXtensions;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;

public class RailwayMeshGenerator : SingletonBehaviour<RailwayMeshGenerator>
{
	private const int SLEEPER_ANCHOR_SUBMESH_IDX = 0;

	public Transform parent;

	public float spatialHashCellSize = 15f;

	public float spatialHashFindRange = 35f;

	public Transform chunkReference;

	public Mesh anchorMesh;

	[Header("Materials")]
	public Material baseMat;

	public Material railMat;

	public Material sleepersInstancedMat;

	public Material anchorsInstancedMat;

	private Vector2[] leftRailShapePoints;

	private Vector2[] rightRailShapePoints;

	private Vector2[] gravelShapePoints;

	private EquiPointSet trackPointset;

	private EquiPointSet sleepersPointSet;

	private Mesh sleeperMesh;

	private ComputeBuffer sleepersAnchorsTransformBuffer;

	private ComputeBuffer sleepersIndirectArgsBuffer;

	private ComputeBuffer anchorsIndirectArgsBuffer;

	private readonly uint[] sleepersIndirectArgs = new uint[5];

	private readonly uint[] anchorsIndirectArgs = new uint[5];

	private NativeList<float> sleepersAnchorsTransformBufferData;

	private NativeList<Vector3> sleepersAnchorsPositions;

	private NativeArray<Bounds> sleepersAnchorsBounds;

	private const string SLEEPERS_TRANSFORM_BUFFER = "transformBuffer";

	private static readonly int SleepersTransformBuffer = Shader.PropertyToID("transformBuffer");

	private const int SLEEPERS_TRANSFORM_BUFFER_SIZE = 12;

	private const int SLEEPERS_TRANSFORM_BUFFER_STRIDE = 48;

	private bool sleepersUpdated;

	private JobHandle sleepersHandle;

	private int shaderProperty_OriginShift;

	private TrackChunkSpatialHash spatialHash;

	private readonly Dictionary<Vector2Int, List<TrackChunk>> findResults = new Dictionary<Vector2Int, List<TrackChunk>>();

	private readonly Dictionary<Vector2Int, List<TrackChunk>> activeChunks = new Dictionary<Vector2Int, List<TrackChunk>>();

	private readonly List<(MeshSweeperJob, JobHandle, Mesh)> activeJobs = new List<(MeshSweeperJob, JobHandle, Mesh)>();

	private Vector2Int prevCellId = new Vector2Int(int.MinValue, int.MaxValue);

	private bool cellChanged;

	private const string PROF_LateUpdate_sleepers = "LateUpdate sleepers indirect";

	private const string PROF_PlaceSleepersAndAnchors = "UpdateSleepersData";

	public new static string AllowAutoCreate()
	{
		return null;
	}

	private void Start()
	{
		sleepersAnchorsTransformBufferData = new NativeList<float>(Allocator.Persistent);
		sleepersAnchorsPositions = new NativeList<Vector3>(Allocator.Persistent);
		sleepersAnchorsBounds = new NativeArray<Bounds>(new Bounds[1], Allocator.Persistent);
		sleepersIndirectArgsBuffer = new ComputeBuffer(1, sleepersIndirectArgs.Length * 4, ComputeBufferType.DrawIndirect);
		anchorsIndirectArgsBuffer = new ComputeBuffer(1, anchorsIndirectArgs.Length * 4, ComputeBufferType.DrawIndirect);
		shaderProperty_OriginShift = Shader.PropertyToID("_OriginShift");
		RailTrack[] array = (from rt in UnityEngine.Object.FindObjectsOfType<RailTrack>()
			where rt.generateMeshes
			select rt).ToArray();
		Vector2[] points2D = array[0].railType.railShape.GetPoints2D(0.1f);
		Vector2 vector = Vector2.right * (array[0].railType.gauge * 0.5f + array[0].railType.railEdgeOffset);
		leftRailShapePoints = OffsetPoints(points2D, -vector);
		rightRailShapePoints = OffsetPoints(points2D, vector);
		gravelShapePoints = array[0].baseType.baseShape.GetPoints2D();
		sleeperMesh = array[0].baseType.sleeperPrefabs.Select((GameObject go) => go.GetComponentInChildren<MeshFilter>().sharedMesh).First();
		sleepersIndirectArgs[0] = sleeperMesh.GetIndexCount(0);
		sleepersIndirectArgs[2] = sleeperMesh.GetIndexStart(0);
		sleepersIndirectArgs[3] = sleeperMesh.GetBaseVertex(0);
		anchorsIndirectArgs[0] = anchorMesh.GetIndexCount(0);
		anchorsIndirectArgs[2] = anchorMesh.GetIndexStart(0);
		anchorsIndirectArgs[3] = anchorMesh.GetBaseVertex(0);
		spatialHash = new TrackChunkSpatialHash(spatialHashCellSize);
		RailTrack[] array2 = array;
		foreach (RailTrack railTrack in array2)
		{
			trackPointset = railTrack.GetKinkedPointSet();
			sleepersPointSet = EquiPointSet.ResampleEquidistant(trackPointset, railTrack.baseType.sleeperDistance, railTrack.baseType.sleeperDistance * 0.5f, fitEvenly: true);
			for (int num2 = 0; num2 < trackPointset.points.Length; num2++)
			{
				EquiPointSet.Point point = trackPointset.points[num2];
				TrackChunk trackChunk = spatialHash.Add(trackPointset, point);
				trackChunk.isSleepers = false;
				trackChunk.track = railTrack;
			}
			for (int num3 = 0; num3 < sleepersPointSet.points.Length; num3++)
			{
				EquiPointSet.Point point2 = sleepersPointSet.points[num3];
				TrackChunk trackChunk2 = spatialHash.Add(sleepersPointSet, point2);
				trackChunk2.isSleepers = true;
				trackChunk2.track = railTrack;
			}
		}
		spatialHash.DoneAdding();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		sleepersAnchorsTransformBufferData.Dispose();
		sleepersAnchorsBounds.Dispose();
		sleepersAnchorsPositions.Dispose();
		sleepersIndirectArgsBuffer.Dispose();
		anchorsIndirectArgsBuffer.Dispose();
		sleepersAnchorsTransformBuffer?.Dispose();
		sleepersInstancedMat.SetVector(shaderProperty_OriginShift, Vector3.zero);
		anchorsInstancedMat.SetVector(shaderProperty_OriginShift, Vector3.zero);
	}

	private Vector2[] OffsetPoints(Vector2[] sourcePoints, Vector2 offset)
	{
		Vector2[] array = new Vector2[sourcePoints.Length];
		for (int i = 0; i < sourcePoints.Length; i++)
		{
			array[i] = sourcePoints[i] + offset;
		}
		return array;
	}

	private void Update()
	{
		Vector3 vector = chunkReference.AbsolutePosition();
		cellChanged = false;
		Vector2Int cellID = spatialHash.GetCellID(vector);
		if (prevCellId == cellID)
		{
			return;
		}
		prevCellId = cellID;
		cellChanged = true;
		spatialHash.FindInRange(vector, spatialHashFindRange, findResults);
		int num = 0;
		foreach (KeyValuePair<Vector2Int, List<TrackChunk>> activeChunk in activeChunks)
		{
			List<TrackChunk> value = activeChunk.Value;
			if (findResults.ContainsKey(activeChunk.Key) || value.Count == 0)
			{
				continue;
			}
			num++;
			foreach (TrackChunk item in value)
			{
				item.ReleasePoolObjects();
			}
			value.Clear();
		}
		sleepersAnchorsTransformBufferData.Clear();
		sleepersAnchorsPositions.Clear();
		sleepersHandle = default(JobHandle);
		int num2 = 0;
		foreach (KeyValuePair<Vector2Int, List<TrackChunk>> findResult in findResults)
		{
			if (!activeChunks.TryGetValue(findResult.Key, out var value2) || value2.Count == 0)
			{
				num2++;
				if (value2 == null)
				{
					value2 = new List<TrackChunk>();
					activeChunks[findResult.Key] = value2;
				}
				foreach (TrackChunk item2 in findResult.Value)
				{
					value2.Add(item2);
					if (!item2.isSleepers)
					{
						ScheduleGenerateBaseAndRail(item2);
					}
				}
			}
			foreach (TrackChunk item3 in findResult.Value)
			{
				if (item3.isSleepers)
				{
					UpdateSleepersData(item3);
				}
			}
		}
	}

	private void LateUpdate()
	{
		foreach (var (meshSweeperJob, jobHandle, mesh) in activeJobs)
		{
			try
			{
				jobHandle.Complete();
				meshSweeperJob.AfterComplete(mesh);
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
		}
		activeJobs.Clear();
		RenderSleepers();
	}

	public void RenderSleepers()
	{
		if (sleepersUpdated)
		{
			sleepersHandle.Complete();
			sleepersUpdated = false;
			int num = sleepersAnchorsTransformBufferData.Length / 12;
			if (num == 0)
			{
				sleepersAnchorsTransformBuffer?.Dispose();
				sleepersAnchorsTransformBuffer = null;
				return;
			}
			JobHandle jobHandle = default(JobHandle);
			if (cellChanged)
			{
				jobHandle = new ComputeBoundsJob(sleepersAnchorsPositions, sleepersAnchorsBounds).Schedule();
				sleepersIndirectArgs[1] = (uint)num;
				anchorsIndirectArgs[1] = (uint)num;
			}
			ComputeBuffer computeBuffer = sleepersAnchorsTransformBuffer;
			if (computeBuffer == null || computeBuffer.count != num)
			{
				sleepersAnchorsTransformBuffer?.Dispose();
				sleepersAnchorsTransformBuffer = new ComputeBuffer(num, 48);
			}
			sleepersAnchorsTransformBuffer.SetData<float>(sleepersAnchorsTransformBufferData);
			sleepersInstancedMat.SetBuffer(SleepersTransformBuffer, sleepersAnchorsTransformBuffer);
			anchorsInstancedMat.SetBuffer(SleepersTransformBuffer, sleepersAnchorsTransformBuffer);
			sleepersIndirectArgsBuffer.SetData(sleepersIndirectArgs);
			anchorsIndirectArgsBuffer.SetData(anchorsIndirectArgs);
			jobHandle.Complete();
		}
		Bounds bounds = sleepersAnchorsBounds[0];
		bounds.center += OriginShift.currentMove;
		sleepersInstancedMat.SetVector(shaderProperty_OriginShift, OriginShift.currentMove);
		anchorsInstancedMat.SetVector(shaderProperty_OriginShift, OriginShift.currentMove);
		Graphics.DrawMeshInstancedIndirect(sleeperMesh, 0, sleepersInstancedMat, bounds, sleepersIndirectArgsBuffer, 0, null, ShadowCastingMode.Off);
		Graphics.DrawMeshInstancedIndirect(anchorMesh, 0, anchorsInstancedMat, bounds, anchorsIndirectArgsBuffer, 0, null, ShadowCastingMode.Off);
	}

	private void ScheduleGenerateBaseAndRail(TrackChunk chunk)
	{
		Vector3 position = chunk.track.transform.position;
		TrackChunkPoolObject trackChunkPoolObject = TrackChunkPoolObject.TakeFromPool(parent, position);
		TrackChunkPoolObject trackChunkPoolObject2 = TrackChunkPoolObject.TakeFromPool(parent, position);
		TrackChunkPoolObject trackChunkPoolObject3 = TrackChunkPoolObject.TakeFromPool(parent, position);
		trackChunkPoolObject.SetMaterial(baseMat);
		trackChunkPoolObject2.SetMaterial(railMat);
		trackChunkPoolObject3.SetMaterial(railMat);
		chunk.AssignPoolObjects(trackChunkPoolObject, trackChunkPoolObject2, trackChunkPoolObject3);
		Vector3 globalOffset = -chunk.track.transform.position;
		UVType basePathUV = chunk.track.baseType.basePathUV;
		float basePathUVScale = chunk.track.baseType.basePathUVScale;
		UVType baseShapeUV = chunk.track.baseType.baseShapeUV;
		float baseShapeUVScale = chunk.track.baseType.baseShapeUVScale;
		MeshSweeperJob item = new MeshSweeperJob(chunk.pointSet, chunk.minIndex, chunk.maxIndex, globalOffset, gravelShapePoints, basePathUV, basePathUVScale, baseShapeUV, baseShapeUVScale);
		MeshSweeperJob item2 = new MeshSweeperJob(chunk.pointSet, chunk.minIndex, chunk.maxIndex, globalOffset, leftRailShapePoints, UVType.DistanceTiled, 1f, UVType.Equidistant, 1f, capEnd: true);
		MeshSweeperJob item3 = new MeshSweeperJob(chunk.pointSet, chunk.minIndex, chunk.maxIndex, globalOffset, rightRailShapePoints, UVType.DistanceTiled, 1f, UVType.Equidistant, 1f, capEnd: true);
		activeJobs.Add((item, item.ScheduleSelf(), trackChunkPoolObject.mesh));
		activeJobs.Add((item2, item2.ScheduleSelf(), trackChunkPoolObject2.mesh));
		activeJobs.Add((item3, item3.ScheduleSelf(), trackChunkPoolObject3.mesh));
	}

	private void UpdateSleepersData(TrackChunk chunk)
	{
		_ = chunk.maxIndex;
		_ = chunk.minIndex;
		_ = chunk.pointSet.points;
		PlaceSleepersAppendJob jobData = new PlaceSleepersAppendJob(sleepersAnchorsTransformBufferData, sleepersAnchorsPositions, chunk.pointSet, chunk.minIndex, chunk.maxIndex, chunk.track.baseType.randomizeAnchorDirection, chunk.track.baseType.sleeperVerticalOffset);
		sleepersHandle = jobData.Schedule(sleepersHandle);
		sleepersUpdated = true;
	}

	private void OnDrawGizmos()
	{
		foreach (KeyValuePair<Vector2Int, List<TrackChunk>> findResult in findResults)
		{
			Vector2Int key = findResult.Key;
			Gizmos.DrawWireCube(new Vector3(key.x, 0f, key.y) * spatialHashCellSize + OriginShift.currentMove + Vector3.one * spatialHashCellSize / 2f, Vector3.one * spatialHashCellSize);
		}
		if (Application.isPlaying)
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireCube(sleepersAnchorsBounds[0].center + OriginShift.currentMove, sleepersAnchorsBounds[0].size);
		}
	}
}
