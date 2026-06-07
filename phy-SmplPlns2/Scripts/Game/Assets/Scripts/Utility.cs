using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Flight.Proximity;
using Assets.Scripts.UI;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using Shapes;
using Unity.IO.Compression;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts
{
	public static class Utility
	{
		private static class Profile
		{
			public static readonly ProfilerMarker CompressCraftXml = new ProfilerMarker("Utility.CompressCraftXml");

			public static readonly ProfilerMarker LoadCompressedCraftXml = new ProfilerMarker("Utility.LoadCompressedCraftXml");

			public static readonly ProfilerMarker LoadCraftXmlFromBytes = new ProfilerMarker("Utility.LoadCraftXmlFromBytes");

			public static readonly ProfilerMarker LoadCraftXmlFromBytesCommon = new ProfilerMarker("Utility.LoadCraftXmlFromBytesCommon");
		}

		private static readonly int[] _boxIndices = new int[24]
		{
			0, 1, 1, 2, 2, 3, 3, 0, 4, 5,
			5, 6, 6, 7, 7, 4, 0, 4, 1, 5,
			2, 6, 3, 7
		};

		public static Vector3? CalculateRaySeaLevelIntersection(Ray ray, float seaLevelY, float maxDistance = 0f)
		{
			if ((double)Mathf.Abs(ray.direction.y) > 1E-06)
			{
				float num = (0f - (ray.origin.y - seaLevelY)) / ray.direction.y;
				if (num >= 0f && (maxDistance == 0f || num < maxDistance))
				{
					return ray.origin + num * ray.direction;
				}
			}
			return null;
		}

		public static byte[] CompressCraftXml(XElement xml)
		{
			using (Profile.CompressCraftXml.Auto())
			{
				using MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml.ToString()));
				using MemoryStream memoryStream2 = new MemoryStream();
				using (GZipStream gZipStream = new GZipStream(memoryStream2, CompressionMode.Compress))
				{
					memoryStream.CopyTo(gZipStream);
					gZipStream.Close();
				}
				return memoryStream2.ToArray();
			}
		}

		public static Vector3 ConvertAbsoluteToFloatingOriginPosition(Vector3 absolutePosition)
		{
			return absolutePosition - GameWorld.Instance.FloatingOriginOffset;
		}

		public static Vector3 ConvertFloatingOriginToAbsolutePosition(Vector3 floatingOriginPosition)
		{
			return floatingOriginPosition + GameWorld.Instance.FloatingOriginOffset;
		}

		public static void DrawBoxFromPoints(Span<float3> points)
		{
			for (int i = 0; i < 24; i += 2)
			{
				Draw.Line(points[_boxIndices[i]], points[_boxIndices[i + 1]]);
			}
		}

		public static void DrawCuboid(Bounds bounds)
		{
			float3 float5 = bounds.center;
			float3 float6 = bounds.extents;
			for (int i = 0; i < 3; i++)
			{
				int index = (i + 1) % 3;
				int index2 = (i + 2) % 3;
				for (int j = -1; j < 2; j += 2)
				{
					for (int k = -1; k < 2; k += 2)
					{
						float3 float7 = 0f;
						float7[index] = j;
						float7[index2] = k;
						float7[i] = -1f;
						float3 float8 = float6 * float7;
						float7[i] = 1f;
						float3 float9 = float6 * float7;
						Draw.Line(float5 + float8, float5 + float9);
					}
				}
			}
		}

		public static float? GetHeightAboveTerrain(Vector3 floatingOriginPosition)
		{
			float? result = null;
			foreach (Terrain terrain in ProximityLoader.Instance.Terrains)
			{
				float? heightAboveTerrain = Utilities.GetHeightAboveTerrain(terrain, floatingOriginPosition);
				if (heightAboveTerrain.HasValue)
				{
					result = heightAboveTerrain.Value;
				}
			}
			return result;
		}

		public static Pose GetPartPose(this PartData part)
		{
			if (!(part.PartScript != null))
			{
				return new Pose(part.Position, Quaternion.Euler(part.Rotation));
			}
			return part.PartScript.transform.GetWorldPose();
		}

		public static Vector3? GetTerrainIntersection(Ray ray, float maxDistance, int layerMask = 1048576)
		{
			if (Physics.Raycast(ray, out var hitInfo, maxDistance, layerMask))
			{
				return hitInfo.point;
			}
			return null;
		}

		public static Vector3? GetTerrainOrSeaIntersection(Ray ray, float seaLevelY, float maxDistance, int layerMask = 1048576)
		{
			Vector3? result = CalculateRaySeaLevelIntersection(ray, GameWorld.Instance.FloatingOriginSeaLevel.GetValueOrDefault(), maxDistance);
			if (Physics.Raycast(ray, out var hitInfo, maxDistance, layerMask) && (!result.HasValue || hitInfo.distance < (ray.origin - result.Value).magnitude))
			{
				result = hitInfo.point;
			}
			return result;
		}

		public static XElement LoadCompressedCraftXml(byte[] bytes)
		{
			using (Profile.LoadCompressedCraftXml.Auto())
			{
				using MemoryStream stream = new MemoryStream(bytes);
				using MemoryStream memoryStream = new MemoryStream();
				using (GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress))
				{
					gZipStream.CopyTo(memoryStream);
					gZipStream.Close();
				}
				return LoadCraftXmlFromBytesCommon(memoryStream.ToArray());
			}
		}

		public static XElement LoadCraftXmlFromBytes(byte[] bytes)
		{
			using (Profile.LoadCraftXmlFromBytes.Auto())
			{
				try
				{
					return LoadCraftXmlFromBytesCommon(bytes);
				}
				catch (Exception)
				{
					return LoadCompressedCraftXml(bytes);
				}
			}
		}

		public static void SetPartPose(this PartData part, Pose pose)
		{
			if (part.PartScript != null)
			{
				part.PartScript.transform.SetGlobalPose(pose);
				return;
			}
			throw new InvalidOperationException("cannot set pose on non-instantiated part");
		}

		public static void ShowDialogOnTaskException(this UniTask task, Func<Exception, string> errorMessage)
		{
			UniTask.Void(async delegate
			{
				try
				{
					await task;
				}
				catch (Exception ex)
				{
					Debug.LogException(ex);
					string text = errorMessage(ex);
					Debug.LogError(text);
					Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, text);
				}
			});
		}

		private static XElement LoadCraftXmlFromBytesCommon(byte[] bytes)
		{
			using (Profile.LoadCraftXmlFromBytesCommon.Auto())
			{
				using MemoryStream input = new MemoryStream(bytes);
				using XmlTextReader reader = new XmlTextReader(input);
				return XDocument.Load(reader).Root;
			}
		}
	}
}
