using System;
using System.Collections.Generic;
using System.Linq;
using Dreamteck.Splines;
using Jundroo.Common.Meshes;
using Jundroo.Common.Platform;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Splines
{
	public static class SplineMeshBuilder
	{
		private class BuiltChannel
		{
			public SplineMesh.Channel Channel { get; set; }

			public SplineMeshBuilderChannel ChannelConfig { get; set; }

			public BuiltChannel(SplineMeshBuilderChannel channelConfig, SplineMesh.Channel channel)
			{
				ChannelConfig = channelConfig;
				Channel = channel;
			}
		}

		public static void DeleteAllSegments(SplineMeshBuilderConfig config, string assetRootPath)
		{
			if (!string.IsNullOrWhiteSpace(assetRootPath))
			{
				throw new NotSupportedException("Not supported outside of the Unity editor.");
			}
			SplineMeshSegment[] componentsInChildren = config.SegmentRootTransform.GetComponentsInChildren<SplineMeshSegment>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				UnityEngine.Object.DestroyImmediate(componentsInChildren[i].gameObject);
			}
		}

		public static void GenerateMeshes(SplineMeshBuilderConfig config)
		{
			if (config.SplineMesh == null)
			{
				Debug.LogError("Unable to generate meshes. The SplineMesh component is null");
				return;
			}
			if (config.SplineMesh.spline == null)
			{
				Debug.LogError("Unable to generated meshes. The spline component on the SplineMesh component is null");
				return;
			}
			if (config.SaveGeneratedAssets && !Device.IsUnityEditor)
			{
				Debug.LogError("Unable to generated meshes. Generated assets need saved but code is not executing in the Unity editor.");
				return;
			}
			CreateGeneratedAssetsDirectory(config);
			FixScales(config);
			DeleteAllSegments(config);
			SplineMeshSegment[] segments = CreateSegments(config);
			foreach (SplineMeshBuilderPass pass in config.Passes)
			{
				GenerateMeshes(config, pass, segments);
			}
		}

		public static void PreviewSegment(SplineMeshBuilderConfig config, int previewSegmentIndex)
		{
			if (config.SplineMesh == null)
			{
				Debug.LogError("Unable to preview segment. The SplineMesh component is null");
				return;
			}
			if (config.SplineMesh.spline == null)
			{
				Debug.LogError("Unable to preview segment. The spline component on the SplineMesh component is null");
				return;
			}
			FixScales(config);
			PreviewMeshes(config, config.Passes[0], previewSegmentIndex);
		}

		private static SplineMesh.Channel BuildChannel(SplineMeshBuilderConfig config, SplineMeshBuilderChannel channelConfig)
		{
			SplineMesh splineMesh = config.SplineMesh;
			SplineMesh.Channel channel = splineMesh.AddChannel($"Channel {splineMesh.GetChannelCount()}");
			foreach (SplineMeshBuilderMesh mesh in channelConfig.Meshes)
			{
				SplineMesh.Channel.MeshDefinition meshDefinition = new SplineMesh.Channel.MeshDefinition(mesh.Mesh);
				meshDefinition.offset = mesh.Offset;
				meshDefinition.rotation = mesh.Rotation;
				meshDefinition.scale = mesh.Scale;
				channel.AddMesh(meshDefinition);
			}
			channel.type = channelConfig.Type;
			channel.randomOrder = channelConfig.RandomOrder;
			channel.autoCount = false;
			channel.minOffset = config.Offset + channelConfig.Offset;
			channel.minRotation = config.Rotation + channelConfig.Rotation;
			channel.minScale = config.Scale + channelConfig.Scale;
			channel.overrideUVs = SplineMesh.Channel.UVOverride.UniformV_Jundroo;
			channel.uvOffset = channelConfig.UVOffset;
			channel.uvScale = channelConfig.UVScale;
			return channel;
		}

		private static List<BuiltChannel> BuildChannels(SplineMeshBuilderConfig config, SplineMeshBuilderPass pass)
		{
			List<BuiltChannel> list = new List<BuiltChannel>();
			foreach (SplineMeshBuilderChannel channel2 in pass.Channels)
			{
				if (channel2.Meshes.Count != 0 && !channel2.Meshes.All((SplineMeshBuilderMesh x) => x.Mesh == null))
				{
					SplineMesh.Channel channel = BuildChannel(config, channel2);
					list.Add(new BuiltChannel(channel2, channel));
				}
			}
			return list;
		}

		private static void CreateGeneratedAssetsDirectory(SplineMeshBuilderConfig config)
		{
			if (!config.SaveGeneratedAssets)
			{
				return;
			}
			throw new NotSupportedException("Not supported outside of the Unity editor.");
		}

		private static SplineMeshSegment[] CreateSegments(SplineMeshBuilderConfig config)
		{
			SplineMeshSegment[] array = new SplineMeshSegment[config.Segments.Length];
			SplineComputer spline = config.SplineMesh.spline;
			for (int i = 0; i < config.Segments.Length; i++)
			{
				double pointPercent = spline.GetPointPercent(config.Segments[i].StartNode);
				double pointPercent2 = spline.GetPointPercent(config.Segments[i].EndNode);
				double percent = pointPercent + (pointPercent2 - pointPercent) * 0.5;
				SplineSample splineSample = spline.Evaluate(percent);
				SplineMeshSegment splineMeshSegment = SplineMeshSegment.Create(spline, config.SegmentRootTransform, config.Material, i, pointPercent, pointPercent2);
				splineMeshSegment.transform.position = splineSample.position;
				array[i] = splineMeshSegment;
			}
			return array;
		}

		private static void DeleteAllSegments(SplineMeshBuilderConfig config)
		{
			DeleteAllSegments(config, config.SaveGeneratedAssets ? config.GeneratedAssetsRootPath : null);
		}

		private static void FixScales(SplineMeshBuilderConfig config)
		{
			foreach (SplineMeshBuilderPass pass in config.Passes)
			{
				foreach (SplineMeshBuilderChannel channel in pass.Channels)
				{
					if (channel.Scale == Vector3.zero)
					{
						channel.Scale = Vector3.one;
					}
					foreach (SplineMeshBuilderMesh mesh in channel.Meshes)
					{
						if (mesh.Scale == Vector3.zero)
						{
							mesh.Scale = Vector3.one;
						}
					}
				}
			}
		}

		private static void GenerateMeshes(SplineMeshBuilderConfig config, SplineMeshBuilderPass pass, SplineMeshSegment[] segments)
		{
			SplineComputer spline = config.SplineMesh.spline;
			SplineMesh splineMesh = config.SplineMesh;
			MeshFilter component = splineMesh.GetComponent<MeshFilter>();
			ResetSplineMesh(config);
			SplineComputer.SampleMode sampleMode = splineMesh.spline.sampleMode;
			if (sampleMode != config.SplineSampleMode)
			{
				splineMesh.spline.sampleMode = config.SplineSampleMode;
				splineMesh.spline.RebuildImmediate(calculateSamples: true, forceUpdateAll: true);
			}
			try
			{
				splineMesh.uvOffset = config.UVOffset;
				splineMesh.uvScale = config.UVScale;
				splineMesh.useSplineSize = false;
				List<BuiltChannel> list = BuildChannels(config, pass);
				if (list.Count == 0)
				{
					return;
				}
				foreach (SplineMeshSegment splineMeshSegment in segments)
				{
					float num = spline.CalculateLength(splineMeshSegment.SplinePositionStart, splineMeshSegment.SplinePositionEnd);
					foreach (BuiltChannel item in list)
					{
						item.Channel.count = Mathf.RoundToInt(num / 1000f * item.ChannelConfig.MeshCountPerKilometer);
					}
					splineMesh.SetClipRange(splineMeshSegment.SplinePositionStart, splineMeshSegment.SplinePositionEnd);
					splineMesh.RebuildImmediate();
					Mesh mesh = UnityEngine.Object.Instantiate(component.sharedMesh);
					RepositionMesh(mesh, -splineMeshSegment.transform.localPosition);
					StripUnusedMeshData(mesh, config.MeshData);
					MeshWeldUtility.Weld(mesh, 0.001f);
					SaveGeneratedMesh(mesh, config, pass, splineMeshSegment.SegmentIndex);
					if (pass.Type == SplineMeshBuilderPassType.Collider)
					{
						splineMeshSegment.SetMeshCollider(mesh);
					}
					else
					{
						splineMeshSegment.SetMeshLod(mesh, GetLodLevel(pass.Type));
					}
				}
				ResetSplineMesh(config);
				if (component.sharedMesh != null)
				{
					UnityEngine.Object.DestroyImmediate(component.sharedMesh);
					component.sharedMesh = null;
				}
			}
			finally
			{
				if (splineMesh.spline.sampleMode != sampleMode)
				{
					splineMesh.spline.sampleMode = sampleMode;
					splineMesh.spline.RebuildImmediate(calculateSamples: true, forceUpdateAll: true);
				}
			}
		}

		private static int GetLodLevel(SplineMeshBuilderPassType passType)
		{
			if (passType == SplineMeshBuilderPassType.Collider)
			{
				return 0;
			}
			return (int)passType;
		}

		private static void PreviewMeshes(SplineMeshBuilderConfig config, SplineMeshBuilderPass pass, int previewSegmentIndex)
		{
			SplineMesh splineMesh = config.SplineMesh;
			MeshRenderer component = splineMesh.GetComponent<MeshRenderer>();
			ResetSplineMesh(config);
			SplineComputer.SampleMode sampleMode = splineMesh.spline.sampleMode;
			if (sampleMode != config.SplineSampleMode)
			{
				splineMesh.spline.sampleMode = config.SplineSampleMode;
				splineMesh.spline.RebuildImmediate(calculateSamples: true, forceUpdateAll: true);
			}
			try
			{
				splineMesh.uvOffset = config.UVOffset;
				splineMesh.uvScale = config.UVScale;
				splineMesh.useSplineSize = false;
				List<BuiltChannel> list = BuildChannels(config, pass);
				if (list.Count == 0)
				{
					return;
				}
				SplineComputer spline = config.SplineMesh.spline;
				SplineMeshBuilderConfigSegment splineMeshBuilderConfigSegment = config.Segments[previewSegmentIndex];
				double pointPercent = spline.GetPointPercent(splineMeshBuilderConfigSegment.StartNode);
				double pointPercent2 = spline.GetPointPercent(splineMeshBuilderConfigSegment.EndNode);
				float num = spline.CalculateLength(pointPercent, pointPercent2);
				foreach (BuiltChannel item in list)
				{
					item.Channel.count = Mathf.RoundToInt(num / 1000f * item.ChannelConfig.MeshCountPerKilometer);
				}
				splineMesh.SetClipRange(pointPercent, pointPercent2);
				splineMesh.RebuildImmediate();
				component.sharedMaterial = config.Material;
			}
			finally
			{
				if (splineMesh.spline.sampleMode != sampleMode)
				{
					splineMesh.spline.sampleMode = sampleMode;
					splineMesh.spline.RebuildImmediate(calculateSamples: true, forceUpdateAll: true);
				}
			}
		}

		private static void RepositionMesh(Mesh mesh, Vector3 offset)
		{
			Vector3[] vertices = mesh.vertices;
			for (int i = 0; i < vertices.Length; i++)
			{
				vertices[i] += offset;
			}
			mesh.vertices = vertices;
			mesh.RecalculateBounds();
			mesh.UploadMeshData(markNoLongerReadable: false);
		}

		private static void ResetSplineMesh(SplineMeshBuilderConfig config)
		{
			SplineMesh splineMesh = config.SplineMesh;
			int channelCount = splineMesh.GetChannelCount();
			for (int i = 0; i < channelCount; i++)
			{
				splineMesh.RemoveChannel(0);
			}
		}

		private static void SaveGeneratedMesh(Mesh mesh, SplineMeshBuilderConfig config, SplineMeshBuilderPass pass, int segmentIndex)
		{
			if (!config.SaveGeneratedAssets)
			{
				return;
			}
			throw new NotSupportedException("Not supported outside of the Unity editor.");
		}

		private static void StripUnusedMeshData(Mesh mesh, SplineMeshBuilderMeshDataFlags meshData)
		{
			if (!meshData.HasFlag(SplineMeshBuilderMeshDataFlags.Tangents))
			{
				Vector4[] tangents = mesh.tangents;
				if (tangents != null && tangents.Length != 0)
				{
					mesh.tangents = null;
				}
			}
			if (!meshData.HasFlag(SplineMeshBuilderMeshDataFlags.Colors))
			{
				Color[] colors = mesh.colors;
				if (colors != null && colors.Length != 0)
				{
					mesh.colors = null;
				}
			}
			if (!meshData.HasFlag(SplineMeshBuilderMeshDataFlags.UV0))
			{
				Vector2[] uv = mesh.uv;
				if (uv != null && uv.Length != 0)
				{
					mesh.uv = null;
				}
			}
			if (!meshData.HasFlag(SplineMeshBuilderMeshDataFlags.UV1))
			{
				Vector2[] uv2 = mesh.uv2;
				if (uv2 != null && uv2.Length != 0)
				{
					mesh.uv2 = null;
				}
			}
			if (!meshData.HasFlag(SplineMeshBuilderMeshDataFlags.UV2))
			{
				Vector2[] uv3 = mesh.uv3;
				if (uv3 != null && uv3.Length != 0)
				{
					mesh.uv3 = null;
				}
			}
			if (!meshData.HasFlag(SplineMeshBuilderMeshDataFlags.UV3))
			{
				Vector2[] uv4 = mesh.uv4;
				if (uv4 != null && uv4.Length != 0)
				{
					mesh.uv4 = null;
				}
			}
			mesh.UploadMeshData(markNoLongerReadable: false);
		}
	}
}
