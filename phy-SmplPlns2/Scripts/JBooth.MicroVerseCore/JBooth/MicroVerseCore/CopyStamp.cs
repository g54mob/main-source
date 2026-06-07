using System;
using System.Collections.Generic;
using UnityEngine;

namespace JBooth.MicroVerseCore
{
	public class CopyStamp : ScriptableObject
	{
		[Serializable]
		public class TreeCopyData
		{
			public TreePrototypeSerializable[] prototypes;

			public byte[] randomsData;

			public byte[] positionsData;

			[HideInInspector]
			public Vector2Int dataSize;

			public Texture2D positonsTex { get; set; }

			public Texture2D randomsTex { get; set; }

			public void Unpack()
			{
				if (positonsTex == null && positionsData != null && positionsData.Length != 0)
				{
					positonsTex = new Texture2D(dataSize.x, dataSize.y, TextureFormat.RGBAHalf, mipChain: false, linear: true);
					positonsTex.wrapMode = TextureWrapMode.Clamp;
					positonsTex.LoadRawTextureData(positionsData);
					positonsTex.Apply(updateMipmaps: false, makeNoLongerReadable: true);
					positonsTex.name = "CopyStampTreePositionsMap";
					positonsTex.hideFlags = HideFlags.DontSave;
				}
				if (randomsTex == null && randomsData != null && randomsData.Length != 0)
				{
					randomsTex = new Texture2D(dataSize.x, dataSize.y, TextureFormat.RGBAHalf, mipChain: false, linear: true);
					randomsTex.wrapMode = TextureWrapMode.Clamp;
					randomsTex.LoadRawTextureData(randomsData);
					randomsTex.Apply(updateMipmaps: false, makeNoLongerReadable: true);
					randomsTex.name = "CopyStampRandomsMap";
					randomsTex.hideFlags = HideFlags.DontSave;
				}
			}
		}

		[Serializable]
		public class DetailCopyData
		{
			[Serializable]
			public class Layer
			{
				public byte[] bytes;

				public DetailPrototypeSerializable prototype;

				public Vector2Int dataSize;

				public Texture2D texture { get; set; }
			}

			public List<Layer> layers = new List<Layer>();

			public Layer FindOrCreateLayer(DetailPrototypeSerializable prototype)
			{
				foreach (Layer layer2 in layers)
				{
					if (layer2.prototype.Equals(prototype))
					{
						return layer2;
					}
				}
				Layer layer = new Layer();
				layer.prototype = prototype;
				layers.Add(layer);
				return layer;
			}

			public void Unpack()
			{
				foreach (Layer layer in layers)
				{
					if (layer.texture == null && layer.bytes != null && layer.bytes.Length != 0)
					{
						layer.texture = new Texture2D(layer.dataSize.x, layer.dataSize.y, TextureFormat.R8, mipChain: false, linear: true);
						layer.texture.wrapMode = TextureWrapMode.Clamp;
						layer.texture.LoadRawTextureData(layer.bytes);
						layer.texture.Apply(updateMipmaps: false, makeNoLongerReadable: true);
						layer.texture.name = "CopyStampDetailMap";
						layer.texture.hideFlags = HideFlags.DontSave;
					}
				}
			}
		}

		public TerrainLayer[] layers;

		public Vector2 heightRenorm;

		public TreeCopyData treeData;

		public DetailCopyData detailData;

		[HideInInspector]
		public byte[] heightData;

		[HideInInspector]
		public byte[] indexData;

		[HideInInspector]
		public byte[] weightData;

		[HideInInspector]
		public byte[] holeData;

		[HideInInspector]
		public Vector2Int heightSize;

		[HideInInspector]
		public Vector2Int indexWeightSize;

		[HideInInspector]
		public Vector2Int holeSize;

		public Texture2D heightMap { get; set; }

		public Texture2D indexMap { get; set; }

		public Texture2D weightMap { get; set; }

		public Texture2D holeMap { get; set; }

		public static CopyStamp Create(Texture2D height, Texture2D index, Texture2D weight, Texture2D hole, TerrainLayer[] tLayers, Vector2 heightRenorm, TreeCopyData treeData, DetailCopyData detailData)
		{
			CopyStamp copyStamp = ScriptableObject.CreateInstance<CopyStamp>();
			copyStamp.layers = tLayers;
			copyStamp.heightRenorm = heightRenorm;
			copyStamp.heightData = ((height != null) ? height.GetRawTextureData() : null);
			copyStamp.indexData = ((index != null) ? index.GetRawTextureData() : null);
			copyStamp.weightData = ((weight != null) ? weight.GetRawTextureData() : null);
			copyStamp.holeData = ((hole != null) ? hole.GetRawTextureData() : null);
			if (height != null)
			{
				copyStamp.heightSize = new Vector2Int(height.width, height.height);
			}
			if (index != null && weight != null)
			{
				copyStamp.indexWeightSize = new Vector2Int(index.width, index.height);
			}
			if (hole != null)
			{
				copyStamp.holeSize = new Vector2Int(hole.width, hole.height);
			}
			copyStamp.treeData = treeData;
			copyStamp.detailData = detailData;
			return copyStamp;
		}

		public void Unpack()
		{
			if (heightMap == null && heightData != null && heightData.Length != 0)
			{
				heightMap = new Texture2D(heightSize.x, heightSize.y, TextureFormat.R16, mipChain: false, linear: true);
				heightMap.wrapMode = TextureWrapMode.Clamp;
				heightMap.LoadRawTextureData(heightData);
				heightMap.Apply(updateMipmaps: false, makeNoLongerReadable: true);
				heightMap.name = "CopyStampHeightMap";
				heightMap.hideFlags = HideFlags.DontSave;
			}
			if (indexMap == null && indexData != null && indexData.Length != 0)
			{
				indexMap = new Texture2D(indexWeightSize.x, indexWeightSize.y, TextureFormat.ARGB32, mipChain: false, linear: true);
				indexMap.LoadRawTextureData(indexData);
				indexMap.wrapMode = TextureWrapMode.Clamp;
				indexMap.filterMode = FilterMode.Point;
				indexMap.Apply(updateMipmaps: false, makeNoLongerReadable: true);
				indexMap.name = "CopyStampIndexMap";
				indexMap.hideFlags = HideFlags.DontSave;
			}
			if (weightMap == null && weightData != null && weightData.Length != 0)
			{
				weightMap = new Texture2D(indexWeightSize.x, indexWeightSize.y, TextureFormat.ARGB32, mipChain: false, linear: true);
				weightMap.LoadRawTextureData(weightData);
				weightMap.wrapMode = TextureWrapMode.Clamp;
				weightMap.Apply(updateMipmaps: false, makeNoLongerReadable: true);
				weightMap.name = "CopyStampWeightMap";
				weightMap.hideFlags = HideFlags.DontSave;
			}
			if (holeMap == null && holeData != null && holeData.Length != 0)
			{
				holeMap = new Texture2D(holeSize.x, holeSize.y, TextureFormat.R8, mipChain: false, linear: true);
				holeMap.LoadRawTextureData(holeData);
				holeMap.wrapMode = TextureWrapMode.Clamp;
				holeMap.Apply(updateMipmaps: false, makeNoLongerReadable: true);
				holeMap.name = "CopyStampWeightMap";
				holeMap.hideFlags = HideFlags.DontSave;
			}
			if (treeData != null)
			{
				treeData.Unpack();
			}
			if (detailData != null)
			{
				detailData.Unpack();
			}
		}
	}
}
