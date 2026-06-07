#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using Events;
using NaughtyAttributes;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace Presentation.FactoryFloor
{
	[Obsolete]
	public class GrassGeneration : MonoBehaviour
	{
		private struct GrassInstanceData
		{
			public Matrix4x4 Matrix;

			public Matrix4x4 MatrixInverse;

			public static int Size()
			{
				return 128;
			}
		}

		private static readonly int PerInstanceData = Shader.PropertyToID("_PerInstanceData");

		[FormerlySerializedAs("_paintObjectSceneData")]
		[SerializeField]
		private IslandInstancedObjectsData _islandInstancedObjectsData;

		[SerializeField]
		private GridLocator _gridLocator;

		[SerializeField]
		private int _maxAmountOfGrassXTile = 4;

		[SerializeField]
		private int _minAmountOfGrassXTile = 2;

		[SerializeField]
		private int _maxInstancePerBatch = 1023;

		[SerializeField]
		private PrefabPlaceBrushToolData _prefabPlaceBushToolData;

		[SerializeField]
		private LayerMask _renderingObjectsLayerMask;

		[SerializeField]
		private BaseEvent _generateGrass;

		private List<ObjectsAndMatricesData> _currentPaintOjectsAndMatrices = new List<ObjectsAndMatricesData>();

		private static Dictionary<ObjectsAndMatricesData, GraphicsBuffer> _prefilledBuffers = new Dictionary<ObjectsAndMatricesData, GraphicsBuffer>();

		private void Start()
		{
			_generateGrass.Register(Generate);
		}

		private void Update()
		{
			foreach (ObjectsAndMatricesData currentPaintOjectsAndMatrix in _currentPaintOjectsAndMatrices)
			{
				for (int i = 0; i < currentPaintOjectsAndMatrix.TransformMatrices.Count; i += _maxInstancePerBatch)
				{
					Graphics.RenderMeshInstanced(currentPaintOjectsAndMatrix.RenderParams, currentPaintOjectsAndMatrix.Mesh, 0, currentPaintOjectsAndMatrix.TransformMatrices, Mathf.Min(_maxInstancePerBatch, currentPaintOjectsAndMatrix.TransformMatrices.Count - i), i);
				}
			}
		}

		private void OnDestroy()
		{
			_generateGrass.UnRegister(Generate);
			ClearBuffers();
		}

		[Button(null, EButtonEnableMode.Always)]
		private void Generate()
		{
			ClearBuffers();
			_currentPaintOjectsAndMatrices.Clear();
			GenerateBuffers();
		}

		private static void ClearBuffers()
		{
			foreach (KeyValuePair<ObjectsAndMatricesData, GraphicsBuffer> prefilledBuffer in _prefilledBuffers)
			{
				prefilledBuffer.Value.Release();
			}
			_prefilledBuffers.Clear();
		}

		private void GenerateBush(Vector3 worldPosition)
		{
			GameObject gameObject = _prefabPlaceBushToolData.PrefabsToPlace[0];
			List<(Vector3, float)> list = new List<(Vector3, float)>();
			int num = UnityEngine.Random.Range(_minAmountOfGrassXTile, _maxAmountOfGrassXTile);
			for (int i = 0; i < num; i++)
			{
				int num2 = 10;
				int num3 = 0;
				float num4 = UnityEngine.Random.Range(_prefabPlaceBushToolData.MinMaxScale.x, _prefabPlaceBushToolData.MinMaxScale.y);
				float num5 = UnityEngine.Random.Range(_prefabPlaceBushToolData.MinMaxHeight.x, _prefabPlaceBushToolData.MinMaxHeight.y);
				bool flag = false;
				while (num3 < num2 && !flag)
				{
					num3++;
					Vector3 toDirection = Vector3Int.up;
					Vector3 vector = worldPosition;
					Vector2 vector2 = UnityEngine.Random.insideUnitCircle * 0.5f;
					vector += new Vector3(vector2.x, 0f, vector2.y);
					bool flag2 = false;
					using (List<(Vector3, float)>.Enumerator enumerator = list.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							if ((vector - enumerator.Current.Item1).magnitude < 0.1f)
							{
								flag2 = true;
								break;
							}
						}
					}
					if (!flag2)
					{
						Quaternion rotation = Quaternion.FromToRotation(gameObject.transform.up, toDirection);
						if (_prefabPlaceBushToolData.RotationMode == PrefabPlaceBrushToolData.RotationsMode.RandomRotation)
						{
							float y = UnityEngine.Random.Range(_prefabPlaceBushToolData.MinMaxRotation.x, _prefabPlaceBushToolData.MinMaxRotation.y);
							rotation *= Quaternion.Euler(0f, y, 0f);
						}
						Vector3 scale = new Vector3(gameObject.transform.localScale.x * num4, gameObject.transform.localScale.y * num5, gameObject.transform.localScale.z * num4);
						float magnitude = new Vector3(scale.x, 0f, scale.z).magnitude;
						list.Add((vector, magnitude));
						AddObjectToPaint(gameObject, vector, rotation, scale);
						flag = true;
					}
				}
				if (num3 >= num2)
				{
					break;
				}
			}
		}

		private void AddObjectToPaint(GameObject prefab, Vector3 position, Quaternion rotation, Vector3 scale)
		{
			for (int i = 0; i < _currentPaintOjectsAndMatrices.Count; i++)
			{
				if ((object)_currentPaintOjectsAndMatrices[i].PrefabRef == prefab)
				{
					_currentPaintOjectsAndMatrices[i].TransformMatrices.Add(Matrix4x4.TRS(position, rotation, scale));
					break;
				}
			}
		}

		private void GenerateBuffers()
		{
			foreach (ObjectsAndMatricesData currentPaintOjectsAndMatrix in _currentPaintOjectsAndMatrices)
			{
				GraphicsBuffer.IndirectDrawIndexedArgs indirectDrawIndexedArgs = new GraphicsBuffer.IndirectDrawIndexedArgs
				{
					baseVertexIndex = 0u,
					indexCountPerInstance = currentPaintOjectsAndMatrix.Mesh.GetIndexCount(0),
					instanceCount = (uint)currentPaintOjectsAndMatrix.TransformMatrices.Count,
					startIndex = 0u,
					startInstance = 0u
				};
				GraphicsBuffer graphicsBuffer = new GraphicsBuffer(GraphicsBuffer.Target.IndirectArguments, currentPaintOjectsAndMatrix.TransformMatrices.Count, 20);
				graphicsBuffer.SetData(new GraphicsBuffer.IndirectDrawIndexedArgs[1] { indirectDrawIndexedArgs });
				ComputeBuffer computeBuffer = new ComputeBuffer(currentPaintOjectsAndMatrix.TransformMatrices.Count, GrassInstanceData.Size(), ComputeBufferType.Structured);
				List<GrassInstanceData> list = new List<GrassInstanceData>();
				foreach (Matrix4x4 transformMatrix in currentPaintOjectsAndMatrix.TransformMatrices)
				{
					list.Add(new GrassInstanceData
					{
						Matrix = transformMatrix,
						MatrixInverse = transformMatrix.inverse
					});
				}
				computeBuffer.SetData(list);
				currentPaintOjectsAndMatrix.RenderParams.material.SetBuffer(PerInstanceData, computeBuffer);
				RenderParams renderParams = currentPaintOjectsAndMatrix.RenderParams;
				renderParams.worldBounds = new Bounds(Vector3.zero, 10000f * Vector3.one);
				renderParams.layer = 17;
				currentPaintOjectsAndMatrix.RenderParams = renderParams;
				_prefilledBuffers.Add(currentPaintOjectsAndMatrix, graphicsBuffer);
			}
		}

		private int LayerMaskToLayer(LayerMask layerMask)
		{
			int num = layerMask.value;
			if (num == 0)
			{
				this.LogError("LayerMask does not contain any valid layers.", "LayerMaskToLayer", 216);
				return -1;
			}
			int num2 = 0;
			while (num > 1)
			{
				num >>= 1;
				num2++;
			}
			return num2;
		}
	}
}
