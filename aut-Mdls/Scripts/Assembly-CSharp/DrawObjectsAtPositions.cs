using System.Collections.Generic;
using CustomAttributes.PrefabPlaceBrushTool;
using NaughtyAttributes;
using UnityEngine;

public class DrawObjectsAtPositions : MonoBehaviour
{
	protected struct GrassInstanceData
	{
		public Matrix4x4 Matrix;

		public Matrix4x4 MatrixInverse;

		public static int Size()
		{
			return 128;
		}
	}

	protected const uint NO_OUTLINE_RENDERMASK = 4u;

	protected const float RENDER_PARAM_BOUNDS_Y = 5f;

	[SerializeField]
	protected IslandInstancedObjectsData _scenePaintObjectData;

	[SerializeField]
	private EraseGrassEventSO _eraseGrassEvent;

	[SerializeField]
	private UneraseGrassEventSO _uneraseGrassEvent;

	[Header("Art settings")]
	[Expandable]
	[SerializeField]
	protected IslandsDrawnObjectsData _islandsDrawnObjectsData;

	protected IslandInstancedObjectsData _rtObjectData;

	private Dictionary<ObjectsAndMatricesData, Dictionary<Vector2Int, List<int>>> _islandInstancesPerTile = new Dictionary<ObjectsAndMatricesData, Dictionary<Vector2Int, List<int>>>();

	private readonly Dictionary<ObjectsAndMatricesData, List<bool>> _skipGrassIndices = new Dictionary<ObjectsAndMatricesData, List<bool>>();

	private bool _needUpdateSkipIndices;

	private Dictionary<ObjectsAndMatricesData, GraphicsBuffer> _prefilledBuffers = new Dictionary<ObjectsAndMatricesData, GraphicsBuffer>();

	private Dictionary<ObjectsAndMatricesData, ComputeBuffer> _transformBuffers = new Dictionary<ObjectsAndMatricesData, ComputeBuffer>();

	private Dictionary<ObjectsAndMatricesData, List<GrassInstanceData>> _grassInstanceMatrices = new Dictionary<ObjectsAndMatricesData, List<GrassInstanceData>>();

	private List<Vector3Int> _queuedGrassAdds = new List<Vector3Int>();

	private List<Vector3Int> _queuedGrassErasures = new List<Vector3Int>();

	protected bool _initialized;

	protected bool _queuedGrassChanges;

	protected virtual void Start()
	{
		_initialized = false;
		_rtObjectData = Object.Instantiate(_scenePaintObjectData);
		Initialize();
	}

	protected void Initialize()
	{
		FlushBuffers();
		BuildPerTileLookups();
		RebuildGrassMatrices();
		RebuildCommandBuffers();
		_eraseGrassEvent.Register(HandleEraseGrassEvent);
		_uneraseGrassEvent.Register(HandleUneraseGrassEvent);
		_initialized = true;
	}

	protected virtual void OnDestroy()
	{
		_eraseGrassEvent.UnRegister(HandleEraseGrassEvent);
		_uneraseGrassEvent.UnRegister(HandleUneraseGrassEvent);
		FlushBuffers();
		DestroyGrassInstances();
	}

	private void DestroyGrassInstances()
	{
		foreach (KeyValuePair<ObjectsAndMatricesData, List<GrassInstanceData>> grassInstanceMatrix in _grassInstanceMatrices)
		{
			if (grassInstanceMatrix.Value != null)
			{
				grassInstanceMatrix.Value.Clear();
			}
		}
		_grassInstanceMatrices.Clear();
	}

	private void FlushBuffers()
	{
		foreach (KeyValuePair<ObjectsAndMatricesData, GraphicsBuffer> prefilledBuffer in _prefilledBuffers)
		{
			prefilledBuffer.Value.Release();
		}
		foreach (KeyValuePair<ObjectsAndMatricesData, ComputeBuffer> transformBuffer in _transformBuffers)
		{
			transformBuffer.Value.Release();
		}
		_prefilledBuffers.Clear();
		_transformBuffers.Clear();
	}

	protected virtual void Update()
	{
		if (_queuedGrassChanges)
		{
			_queuedGrassChanges = false;
			SetSkipIndices(_queuedGrassAdds, value: true);
			SetSkipIndices(_queuedGrassErasures, value: false);
			_queuedGrassAdds.Clear();
			_queuedGrassErasures.Clear();
		}
		if (_initialized)
		{
			DrawUsingCommandBuffers();
		}
	}

	protected void BuildPerTileLookups()
	{
		foreach (ObjectsAndMatricesData objectsAndMatrix in _rtObjectData.ObjectsAndMatrices)
		{
			_skipGrassIndices[objectsAndMatrix] = new List<bool>();
			Dictionary<Vector2Int, List<int>> dictionary = new Dictionary<Vector2Int, List<int>>();
			for (int i = 0; i < objectsAndMatrix.TransformMatrices.Count; i++)
			{
				_skipGrassIndices[objectsAndMatrix].Add(item: false);
				Vector3 position = objectsAndMatrix.TransformMatrices[i].GetPosition();
				Vector2Int zero = Vector2Int.zero;
				zero.x = Mathf.FloorToInt(position.x);
				zero.y = Mathf.FloorToInt(position.z);
				if (!dictionary.ContainsKey(zero))
				{
					dictionary[zero] = new List<int>();
				}
				dictionary[zero].Add(i);
			}
			_islandInstancesPerTile[objectsAndMatrix] = dictionary;
		}
	}

	protected void HandleEraseGrassEvent(List<Vector3Int> tilePositions)
	{
		_queuedGrassAdds.AddRange(tilePositions);
		_queuedGrassChanges = true;
	}

	protected void HandleUneraseGrassEvent(List<Vector3Int> tilePositions)
	{
		_queuedGrassErasures.AddRange(tilePositions);
		_queuedGrassChanges = true;
	}

	private void SetSkipIndices(List<Vector3Int> tilePositions, bool value)
	{
		foreach (Vector3Int tilePosition in tilePositions)
		{
			Vector2Int key = new Vector2Int(tilePosition.x, tilePosition.z);
			foreach (KeyValuePair<ObjectsAndMatricesData, Dictionary<Vector2Int, List<int>>> item in _islandInstancesPerTile)
			{
				if (!item.Value.ContainsKey(key))
				{
					continue;
				}
				foreach (int item2 in item.Value[key])
				{
					_skipGrassIndices[item.Key][item2] = value;
				}
				_needUpdateSkipIndices = true;
			}
		}
	}

	private void RebuildGrassMatrices()
	{
		_grassInstanceMatrices = new Dictionary<ObjectsAndMatricesData, List<GrassInstanceData>>();
		foreach (ObjectsAndMatricesData objectsAndMatrix in _rtObjectData.ObjectsAndMatrices)
		{
			_grassInstanceMatrices[objectsAndMatrix] = new List<GrassInstanceData>();
			for (int i = 0; i < objectsAndMatrix.TransformMatrices.Count; i++)
			{
				GrassInstanceData item = new GrassInstanceData
				{
					Matrix = objectsAndMatrix.TransformMatrices[i],
					MatrixInverse = objectsAndMatrix.TransformMatrices[i].inverse
				};
				_grassInstanceMatrices[objectsAndMatrix].Add(item);
			}
		}
	}

	private void RebuildCommandBuffers()
	{
		foreach (ObjectsAndMatricesData objectsAndMatrix in _rtObjectData.ObjectsAndMatrices)
		{
			List<GrassInstanceData> list = new List<GrassInstanceData>();
			int num = 0;
			for (int i = 0; i < objectsAndMatrix.TransformMatrices.Count; i++)
			{
				if (!_skipGrassIndices[objectsAndMatrix][i])
				{
					list.Add(_grassInstanceMatrices[objectsAndMatrix][i]);
					num++;
				}
			}
			if (num == 0)
			{
				if (_prefilledBuffers.ContainsKey(objectsAndMatrix))
				{
					_prefilledBuffers.Remove(objectsAndMatrix);
				}
				continue;
			}
			GraphicsBuffer graphicsBuffer = ((!_prefilledBuffers.ContainsKey(objectsAndMatrix)) ? new GraphicsBuffer(GraphicsBuffer.Target.IndirectArguments, num, 20) : _prefilledBuffers[objectsAndMatrix]);
			GraphicsBuffer.IndirectDrawIndexedArgs indirectDrawIndexedArgs = new GraphicsBuffer.IndirectDrawIndexedArgs
			{
				baseVertexIndex = 0u,
				indexCountPerInstance = objectsAndMatrix.Mesh.GetIndexCount(0),
				instanceCount = (uint)num,
				startIndex = 0u,
				startInstance = 0u
			};
			graphicsBuffer.SetData(new GraphicsBuffer.IndirectDrawIndexedArgs[1] { indirectDrawIndexedArgs });
			ComputeBuffer computeBuffer = ((!_transformBuffers.ContainsKey(objectsAndMatrix)) ? new ComputeBuffer(num, GrassInstanceData.Size(), ComputeBufferType.Structured) : _transformBuffers[objectsAndMatrix]);
			computeBuffer.SetData(list);
			objectsAndMatrix.RenderParams.material.SetBuffer("_PerInstanceData", computeBuffer);
			RenderParams renderParams = objectsAndMatrix.RenderParams;
			renderParams.worldBounds = GetRenderParamsWorldBounds();
			renderParams.layer = objectsAndMatrix.LayerMask;
			renderParams.renderingLayerMask = 4u;
			objectsAndMatrix.RenderParams = renderParams;
			_prefilledBuffers[objectsAndMatrix] = graphicsBuffer;
			_transformBuffers[objectsAndMatrix] = computeBuffer;
		}
	}

	protected virtual Bounds GetRenderParamsWorldBounds()
	{
		return new Bounds(Vector3.zero, 10000f * Vector3.one);
	}

	private void DrawUsingCommandBuffers()
	{
		if (_needUpdateSkipIndices)
		{
			_needUpdateSkipIndices = false;
			RebuildCommandBuffers();
		}
		foreach (KeyValuePair<ObjectsAndMatricesData, GraphicsBuffer> prefilledBuffer in _prefilledBuffers)
		{
			Graphics.RenderMeshIndirect(prefilledBuffer.Key.RenderParams, prefilledBuffer.Key.Mesh, prefilledBuffer.Value);
		}
	}
}
