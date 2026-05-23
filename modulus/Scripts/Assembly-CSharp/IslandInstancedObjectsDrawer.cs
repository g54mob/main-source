using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Islands;
using Presentation.FactoryFloor;
using Presentation.FactoryFloor.Islands;
using UnityEngine;

public class IslandInstancedObjectsDrawer : DrawObjectsAtPositions
{
	[SerializeField]
	private IslandView _islandView;

	private bool _active;

	private Dictionary<ObjectsAndMatricesData, GraphicsBuffer> _prefilledBuffersOperators = new Dictionary<ObjectsAndMatricesData, GraphicsBuffer>();

	private Dictionary<ObjectsAndMatricesData, List<GrassInstanceData>> _grassInstanceMatricesOperators = new Dictionary<ObjectsAndMatricesData, List<GrassInstanceData>>();

	private IslandData _islandData;

	private void Awake()
	{
		if (!(_islandView == null))
		{
			_islandView.OnViewShow += OnIslandViewShow;
			_islandView.OnViewHide += OnIslandViewHide;
			_islandView.OnViewCreated += OnIslandViewCreated;
			_islandView.OnFactoryObjectViewCreatedOnIsland += OnFactoryObjectViewCreatedOnIsland;
			_islandView.OnFactoryObjectViewRemovedOnIsland += OnFactoryObjectViewRemovedOnIsland;
		}
	}

	private void OnFactoryObjectViewCreatedOnIsland(FactoryObjectView factoryObjectView, FactoryObject factoryObject)
	{
		if (factoryObjectView.GrassTiles)
		{
			_islandsDrawnObjectsData.GenerateObjectsFrom(factoryObject, _rtObjectData);
			RebuildGrassMatricesOperators();
			RebuildCommandBuffersOperators();
		}
	}

	private void OnFactoryObjectViewRemovedOnIsland(FactoryObjectView factoryObjectView, FactoryObject factoryObject)
	{
		if (factoryObjectView.GrassTiles)
		{
			_islandsDrawnObjectsData.RemoveObjectsFrom(factoryObject, _rtObjectData);
			RebuildGrassMatricesOperators();
			RebuildCommandBuffersOperators();
		}
	}

	protected override void Start()
	{
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		FlushOperatorBuffers();
		DestroyGrassInstances();
		if (_islandView != null)
		{
			_islandView.OnViewShow -= OnIslandViewShow;
			_islandView.OnViewHide -= OnIslandViewHide;
			_islandView.OnViewCreated -= OnIslandViewCreated;
			_islandView.OnFactoryObjectViewCreatedOnIsland -= OnFactoryObjectViewCreatedOnIsland;
			_islandView.OnFactoryObjectViewRemovedOnIsland -= OnFactoryObjectViewRemovedOnIsland;
		}
		_islandView = null;
		_islandsDrawnObjectsData = null;
	}

	private void DestroyGrassInstances()
	{
		foreach (KeyValuePair<ObjectsAndMatricesData, List<GrassInstanceData>> grassInstanceMatricesOperator in _grassInstanceMatricesOperators)
		{
			if (grassInstanceMatricesOperator.Value != null)
			{
				grassInstanceMatricesOperator.Value.Clear();
			}
		}
		_grassInstanceMatricesOperators.Clear();
	}

	private void FlushOperatorBuffers()
	{
		foreach (KeyValuePair<ObjectsAndMatricesData, GraphicsBuffer> prefilledBuffersOperator in _prefilledBuffersOperators)
		{
			prefilledBuffersOperator.Key.TransformBuffer.Release();
			prefilledBuffersOperator.Value.Release();
		}
		_prefilledBuffersOperators.Clear();
	}

	private void OnIslandViewCreated(IslandData islandData)
	{
		_rtObjectData = Object.Instantiate(_scenePaintObjectData);
		_islandsDrawnObjectsData.BuildIslandsObjMatrices(_rtObjectData, islandData);
		_islandData = islandData;
		FlushOperatorBuffers();
		RebuildGrassMatricesOperators();
		RebuildCommandBuffersOperators();
		Initialize();
	}

	private void RebuildGrassMatricesOperators()
	{
		_grassInstanceMatricesOperators = new Dictionary<ObjectsAndMatricesData, List<GrassInstanceData>>();
		foreach (ObjectsAndMatricesData grassOperatorsObjsAndMat in _rtObjectData.GrassOperatorsObjsAndMats)
		{
			_grassInstanceMatricesOperators[grassOperatorsObjsAndMat] = new List<GrassInstanceData>();
			for (int i = 0; i < grassOperatorsObjsAndMat.TransformMatrices.Count; i++)
			{
				GrassInstanceData item = new GrassInstanceData
				{
					Matrix = grassOperatorsObjsAndMat.TransformMatrices[i],
					MatrixInverse = grassOperatorsObjsAndMat.TransformMatrices[i].inverse
				};
				_grassInstanceMatricesOperators[grassOperatorsObjsAndMat].Add(item);
			}
		}
	}

	private void RebuildCommandBuffersOperators()
	{
		FlushOperatorBuffers();
		foreach (ObjectsAndMatricesData grassOperatorsObjsAndMat in _rtObjectData.GrassOperatorsObjsAndMats)
		{
			List<GrassInstanceData> list = new List<GrassInstanceData>();
			int num = 0;
			for (int i = 0; i < grassOperatorsObjsAndMat.TransformMatrices.Count; i++)
			{
				list.Add(_grassInstanceMatricesOperators[grassOperatorsObjsAndMat][i]);
				num++;
			}
			if (num != 0)
			{
				GraphicsBuffer graphicsBuffer = new GraphicsBuffer(GraphicsBuffer.Target.IndirectArguments, num, 20);
				GraphicsBuffer.IndirectDrawIndexedArgs indirectDrawIndexedArgs = new GraphicsBuffer.IndirectDrawIndexedArgs
				{
					baseVertexIndex = 0u,
					indexCountPerInstance = grassOperatorsObjsAndMat.Mesh.GetIndexCount(0),
					instanceCount = (uint)num,
					startIndex = 0u,
					startInstance = 0u
				};
				graphicsBuffer.SetData(new GraphicsBuffer.IndirectDrawIndexedArgs[1] { indirectDrawIndexedArgs });
				ComputeBuffer computeBuffer = new ComputeBuffer(num, GrassInstanceData.Size(), ComputeBufferType.Structured);
				computeBuffer.SetData(list);
				grassOperatorsObjsAndMat.RenderParams.material.SetBuffer("_PerInstanceData", computeBuffer);
				grassOperatorsObjsAndMat.TransformBuffer = computeBuffer;
				RenderParams renderParams = grassOperatorsObjsAndMat.RenderParams;
				renderParams.worldBounds = GetRenderParamsWorldBounds();
				renderParams.layer = grassOperatorsObjsAndMat.LayerMask;
				renderParams.renderingLayerMask = 4u;
				grassOperatorsObjsAndMat.RenderParams = renderParams;
				_prefilledBuffersOperators[grassOperatorsObjsAndMat] = graphicsBuffer;
			}
		}
	}

	private void OnIslandViewShow()
	{
		Activate(toggle: true);
	}

	private void OnIslandViewHide()
	{
		Activate(toggle: false);
	}

	private void Activate(bool toggle)
	{
		_active = toggle;
	}

	protected override Bounds GetRenderParamsWorldBounds()
	{
		return new Bounds(_islandData.Position, new Vector3(_islandData.WorldSize.x, 5f, _islandData.WorldSize.y));
	}

	protected override void Update()
	{
		if (!_active)
		{
			return;
		}
		base.Update();
		foreach (KeyValuePair<ObjectsAndMatricesData, GraphicsBuffer> prefilledBuffersOperator in _prefilledBuffersOperators)
		{
			Graphics.RenderMeshIndirect(prefilledBuffersOperator.Key.RenderParams, prefilledBuffersOperator.Key.Mesh, prefilledBuffersOperator.Value);
		}
	}
}
