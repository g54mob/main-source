using System;
using Assets.Scripts.Terrain.Events;
using Assets.Scripts.Terrain.Pooling;
using Assets.Scripts.Terrain.Rendering;
using ModApi.Planet;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Terrain
{
	public class QuadScript : IQuadSphereQuad
	{
		private static class ShaderPropertyIds
		{
			public static readonly int QuadId = Shader.PropertyToID("_QuadId");
		}

		private static CreateQuadScriptEventArgs _eventArgsCreate = new CreateQuadScriptEventArgs();

		private static UnloadQuadScriptEventArgs _eventArgsUnload = new UnloadQuadScriptEventArgs();

		private static MeshUpdateFlags _meshUpdateFlags = MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds;

		private QuadScript[] _children;

		private QuadScript _parent;

		private QuadSpherePoolItem<QuadScript> _poolItem;

		[SerializeField]
		private QuadSpherePoolItem<Mesh> _quadMesh;

		[SerializeField]
		private int _subdivisionLevel;

		[SerializeField]
		private QuadSpherePoolItem<Mesh> _waterQuadMesh;

		public QuadScript[] Children => _children;

		IQuadSphereQuad[] IQuadSphereQuad.Children => _children;

		public bool HasWater { get; private set; }

		public int Id { get; }

		public bool IsPendingReturnToPool { get; set; }

		public bool IsRefreshPending { get; set; }

		public bool IsRefreshRequired { get; set; }

		public bool IsShore { get; private set; }

		public bool IsSplitJobQueued { get; set; }

		public bool IsSubdivided => _children != null;

		public bool IsSubdivisionPending { get; set; }

		public QuadScript Parent
		{
			get
			{
				return _parent;
			}
			private set
			{
				_parent = value;
			}
		}

		IQuadSphereQuad IQuadSphereQuad.Parent => _parent;

		public Vector3d PlanetPosition { get; set; }

		public Vector3d QuadPosition { get; set; }

		public QuadRendererScript QuadRenderer { get; set; }

		public Quaterniond QuadRotation { get; set; }

		public double QuadScale { get; set; }

		public QuadSphereScript QuadSphere { get; set; }

		IQuadSphere IQuadSphereQuad.QuadSphere => QuadSphere;

		public QuadRenderingData RenderingData { get; private set; }

		public Vector3d SphereNormal { get; set; }

		public int SubdivisionLevel
		{
			get
			{
				return _subdivisionLevel;
			}
			set
			{
				_subdivisionLevel = value;
			}
		}

		public Vector2d UvCenter { get; set; }

		public double UvSize { get; set; }

		public static event EventHandler<CreateQuadScriptEventArgs> CreateQuadCompleted;

		public static event EventHandler<CreateQuadScriptEventArgs> CreateQuadStarted;

		public static event EventHandler<UnloadQuadScriptEventArgs> UnloadQuadCompleted;

		public static event EventHandler<UnloadQuadScriptEventArgs> UnloadQuadStarted;

		public QuadScript(int id)
		{
			Id = id;
			RenderingData = new QuadRenderingData();
			RenderingData.Id = id;
			if (Game.InPlanetStudioScene)
			{
				RenderingData.RaycastMaterialPropertyBlock = new MaterialPropertyBlock();
				RenderingData.RaycastMaterialPropertyBlock.SetFloat(ShaderPropertyIds.QuadId, id);
			}
		}

		public static QuadScript CreateQuad(QuadSphereScript quadSphere, CreateQuadData data, QuadScript parent, int childIndex)
		{
			QuadSpherePoolItem<QuadScript> item = QuadSpherePoolManager.Instance.QuadScriptPool.GetItem();
			QuadScript item2 = item.Item;
			item2._poolItem = item;
			try
			{
				_eventArgsCreate.Initialize(quadSphere, parent, item2, data, childIndex);
				QuadScript.CreateQuadStarted?.Invoke(item2, _eventArgsCreate);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			item2.Initialize(quadSphere, data);
			parent?.AddChild(item2, childIndex);
			try
			{
				QuadScript.CreateQuadCompleted?.Invoke(item2, _eventArgsCreate);
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
			}
			finally
			{
				_eventArgsCreate.Reset();
			}
			quadSphere.OnQuadAdded(item2);
			return item2;
		}

		public void AddChild(QuadScript quad, int index)
		{
			quad.Parent = this;
			if (_children == null)
			{
				_children = new QuadScript[4];
			}
			_children[index] = quad;
		}

		public void ClearChildren()
		{
			_children = null;
		}

		public void Initialize(QuadSphereScript quadSphere, CreateQuadData data)
		{
			QuadSphere = quadSphere;
			PlanetPosition = data.Center;
			UvCenter = data.UVCenter;
			UvSize = data.UVSize;
			QuadPosition = data.Position;
			QuadRotation = data.Rotation;
			QuadScale = data.Scale;
			SubdivisionLevel = data.SubdivisionLevel;
			SphereNormal = data.SphereNormal;
			IsShore = data.HasWater && data.AboveSeaLevel && data.BelowSeaLevel;
			HasWater = data.HasWater;
			IsSubdivisionPending = false;
			IsPendingReturnToPool = false;
			IsSplitJobQueued = false;
			QuadRenderingData renderingData = RenderingData;
			renderingData.BoundingBox = data.AxisAlignedBoundingBox;
			renderingData.BoundingBoxRotation = data.AxisAlignedBoundingBoxRotation;
			renderingData.LocalPosition = data.Center;
			InitializeTerrainMesh(data);
			InitializeWaterMesh(data);
			if (quadSphere.RenderingTechnique == QuadSphereScript.QuadSphereRenderingTechnique.MeshRenderers)
			{
				if (QuadRenderer == null)
				{
					QuadRenderer = QuadRendererScript.Create(this);
				}
				else
				{
					QuadRenderer.Initialize(this);
				}
			}
		}

		[ContextMenu("Refresh Quad")]
		public void RefreshQuad()
		{
			QuadRefreshJob quadRefreshJob = new QuadRefreshJob(QuadSphere.GenerateCreateQuadData);
			quadRefreshJob.Initialize(this);
			quadRefreshJob.Process();
			quadRefreshJob.Complete();
		}

		public void ReturnToPool(bool releaseQuad = true)
		{
			if (releaseQuad)
			{
				try
				{
					_eventArgsUnload.Initialize(this);
					QuadScript.UnloadQuadStarted?.Invoke(this, _eventArgsUnload);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			QuadRenderingData renderingData = RenderingData;
			renderingData.TerrainMesh = null;
			renderingData.TerrainMaterial = null;
			renderingData.WaterMesh = null;
			renderingData.WaterMaterial = null;
			if (_quadMesh != null)
			{
				_quadMesh.ReturnToPool();
				_quadMesh = null;
			}
			if (_waterQuadMesh != null)
			{
				_waterQuadMesh.ReturnToPool();
				_waterQuadMesh = null;
			}
			if (!releaseQuad)
			{
				return;
			}
			QuadSphere.OnQuadRemoved(this);
			if (QuadRenderer != null)
			{
				QuadRendererScript.Destroy(QuadRenderer);
				QuadRenderer = null;
			}
			Parent = null;
			ClearChildren();
			QuadSphere = null;
			_poolItem.ReturnToPool();
			_poolItem = null;
			try
			{
				QuadScript.UnloadQuadCompleted?.Invoke(this, _eventArgsUnload);
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
			}
			finally
			{
				_eventArgsUnload.Reset();
			}
		}

		private void InitializeTerrainMesh(CreateQuadData data)
		{
			if (!data.HasTerrain || data.SubdivisionLevel < QuadSphere.MinSubdivisionLevel)
			{
				data.TerrainMeshData.ReturnToPool();
				data.TerrainMeshData = null;
				return;
			}
			try
			{
				_quadMesh = QuadSpherePoolManager.Instance.TerrainMeshPool.GetItem();
				Mesh item = _quadMesh.Item;
				MeshDataTerrain item2 = data.TerrainMeshData.Item;
				if (item2.VertexType == typeof(MeshDataTerrain.TerrainVertexBasic))
				{
					item.SetVertexBufferData(item2.VerticesBasic, 0, 0, item2.VerticesBasic.Length, 0, _meshUpdateFlags);
				}
				else
				{
					item.SetVertexBufferData(item2.Vertices, 0, 0, item2.Vertices.Length, 0, _meshUpdateFlags);
				}
				item.bounds = item2.Bounds;
				RenderingData.TerrainMesh = item;
				RenderingData.TerrainMaterial = QuadSphere.TerrainGenerator.GetTerrainMaterial(this);
			}
			finally
			{
				data.TerrainMeshData.ReturnToPool();
				data.TerrainMeshData = null;
			}
		}

		private void InitializeWaterMesh(CreateQuadData data)
		{
			if (!data.HasWater || !data.BelowSeaLevel || data.SubdivisionLevel < QuadSphere.MinSubdivisionLevel)
			{
				data.WaterMeshData.ReturnToPool();
				data.WaterMeshData = null;
				return;
			}
			try
			{
				_waterQuadMesh = QuadSpherePoolManager.Instance.WaterMeshPool.GetItem();
				Mesh item = _waterQuadMesh.Item;
				MeshDataWater item2 = data.WaterMeshData.Item;
				item.SetVertexBufferData(item2.Vertices, 0, 0, item2.Vertices.Length, 0, _meshUpdateFlags);
				item.bounds = item2.Bounds;
				RenderingData.WaterMesh = item;
				RenderingData.WaterMaterial = QuadSphere.TerrainGenerator.GetWaterMaterial(this);
			}
			finally
			{
				data.WaterMeshData.ReturnToPool();
				data.WaterMeshData = null;
			}
		}
	}
}
