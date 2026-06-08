using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Dorfromantik
{
	[Serializable]
	public class GPUInstanceData
	{
		[SerializeField]
		public RecyclableType type;

		[SerializeField]
		public Biome biome;

		public const int MAXGroupSize = 1022;

		public List<Matrix4x4[]> transformGroups = new List<Matrix4x4[]> { new Matrix4x4[1022] };

		public bool active = true;

		private int _003CCurrentGroupIndex_003Ek__BackingField;

		private int _003CCurrentTransformIndex_003Ek__BackingField = -1;

		private Matrix4x4 emptyMatrix4X4 = Matrix4x4.zero;

		public MaterialPropertyBlock properties;

		public Instanceable referenceInstanceable;

		[SerializeField]
		public Mesh mesh;

		[SerializeField]
		public Material material;

		[SerializeField]
		public bool receiveShadows;

		[SerializeField]
		public ShadowCastingMode shadowCastingMode;

		[SerializeField]
		public int instanceCount;

		[SerializeField]
		private int groupCount = 1;

		[SerializeField]
		private List<int> groupCounts = new List<int> { 0 };

		[SerializeField]
		private bool highlighted;

		[SerializeField]
		private List<Vector2Int> emptyIndices = new List<Vector2Int>();

		[SerializeField]
		public List<FloatOption> floatOptions;

		[SerializeField]
		public List<ColorOption> colorOptions;

		public int CurrentGroupIndex
		{
			get
			{
				return _003CCurrentGroupIndex_003Ek__BackingField;
			}
			private set
			{
				_003CCurrentGroupIndex_003Ek__BackingField = value;
			}
		}

		public int CurrentTransformIndex
		{
			get
			{
				return _003CCurrentTransformIndex_003Ek__BackingField;
			}
			private set
			{
				_003CCurrentTransformIndex_003Ek__BackingField = value;
			}
		}

		public Mesh Mesh
		{
			get
			{
				if (!referenceInstanceable)
				{
					return mesh;
				}
				return referenceInstanceable.GetMesh(SettingsRouter.MeshQualityLevel);
			}
		}

		public void SetInfo(Instanceable referenceInstanceable)
		{
			this.referenceInstanceable = referenceInstanceable;
		}

		public void SetInfo(RecyclableType targetType, Biome biome, bool highlightedInstance)
		{
			type = targetType;
			this.biome = biome;
			highlighted = highlightedInstance;
		}

		public Vector2Int AddTransformMatrix(Matrix4x4 transformMatrixToAdd)
		{
			Vector2Int result;
			if (emptyIndices.Count > 0)
			{
				result = emptyIndices[0];
				emptyIndices.RemoveAt(0);
			}
			else
			{
				CurrentTransformIndex++;
				if (CurrentTransformIndex >= 1022)
				{
					transformGroups.Add(new Matrix4x4[1022]);
					groupCounts.Add(0);
					CurrentTransformIndex = 0;
					groupCount++;
					CurrentGroupIndex++;
				}
				result = new Vector2Int(CurrentGroupIndex, CurrentTransformIndex);
			}
			transformGroups[result.x][result.y] = transformMatrixToAdd;
			instanceCount++;
			groupCounts[result.x]++;
			return result;
		}

		public void RemoveTransform(Vector2Int instanceIndex)
		{
			if (emptyIndices.Contains(instanceIndex))
			{
				Debug.LogError($"wants to add duplicate to {type} {biome}, empty index {instanceIndex}!");
				return;
			}
			transformGroups[instanceIndex.x][instanceIndex.y] = emptyMatrix4X4;
			emptyIndices.Add(instanceIndex);
			instanceCount--;
			groupCounts[instanceIndex.x]--;
		}
	}
}
