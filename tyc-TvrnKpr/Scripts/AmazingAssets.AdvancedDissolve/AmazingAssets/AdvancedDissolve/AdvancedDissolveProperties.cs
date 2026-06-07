using System;
using System.Collections.Generic;
using UnityEngine;

namespace AmazingAssets.AdvancedDissolve
{
	public static class AdvancedDissolveProperties
	{
		[Serializable]
		public class Cutout
		{
			[Serializable]
			public class Standard
			{
				private class IDs
				{
					public int clip;

					public int map1;

					public int map1Tiling;

					public int map1Offset;

					public int map1Scroll;

					public int map1Intensity;

					public int map1Channel;

					public int map1Invert;

					public int map2;

					public int map2Tiling;

					public int map2Offset;

					public int map2Scroll;

					public int map2Intensity;

					public int map2Channel;

					public int map2Invert;

					public int map3;

					public int map3Tiling;

					public int map3Offset;

					public int map3Scroll;

					public int map3Intensity;

					public int map3Channel;

					public int map3Invert;

					public int mapsBlendType;

					public int mapsTriplanarMappingSpace;

					public int mapsScreenSpaceUVScale;

					public int baseInvert;

					public IDs(int ID)
					{
					}
				}

				public enum Property
				{
					Clip = 0,
					Map1 = 1,
					Map1Tiling = 2,
					Map1Offset = 3,
					Map1Scroll = 4,
					Map1Intensity = 5,
					Map1Channel = 6,
					Map1Invert = 7,
					Map2 = 8,
					Map2Tiling = 9,
					Map2Offset = 10,
					Map2Scroll = 11,
					Map2Intensity = 12,
					Map2Channel = 13,
					Map2Invert = 14,
					Map3 = 15,
					Map3Tiling = 16,
					Map3Offset = 17,
					Map3Scroll = 18,
					Map3Intensity = 19,
					Map3Channel = 20,
					Map3Invert = 21,
					MapsBlendType = 22,
					TriplanarMappingSpace = 23,
					ScreenSpaceUVScale = 24,
					BaseInvert = 25
				}

				public enum MapsBlendType
				{
					Multiply = 0,
					Add = 1
				}

				public enum TriplanarMappingSpace
				{
					World = 0,
					Local = 1
				}

				public enum ScreenSpaceUVScale
				{
					Constant = 0,
					CameraRelative = 1
				}

				public enum MapChannel
				{
					Red = 0,
					Green = 1,
					Blue = 2,
					Alpha = 3
				}

				private static IDs[] ids;

				[Range(0f, 1f)]
				public float clip;

				[Space(10f)]
				public Texture2D map1;

				public Vector3 map1Tiling;

				public Vector3 map1Offset;

				public Vector3 map1Scroll;

				[Range(0f, 1f)]
				public float map1Intensity;

				public MapChannel map1Channel;

				public bool map1Invert;

				[Space(10f)]
				public Texture2D map2;

				public Vector3 map2Tiling;

				public Vector3 map2Offset;

				public Vector3 map2Scroll;

				[Range(0f, 1f)]
				public float map2Intensity;

				public MapChannel map2Channel;

				public bool map2Invert;

				[Space(10f)]
				public Texture2D map3;

				public Vector3 map3Tiling;

				public Vector3 map3Offset;

				public Vector3 map3Scroll;

				[Range(0f, 1f)]
				public float map3Intensity;

				public MapChannel map3Channel;

				public bool map3Invert;

				[Space(10f)]
				public MapsBlendType mapsBlendType;

				public TriplanarMappingSpace triplanarMappingSpace;

				public ScreenSpaceUVScale screenSpaceUVScale;

				public bool baseInvert;

				public void UpdateLocal(List<Material> materials)
				{
				}

				public void UpdateLocal(Material material)
				{
				}

				public void UpdateGlobal(AdvancedDissolveKeywords.GlobalControlID globalControlID)
				{
				}

				public static void UpdateLocalProperty(Material material, Property property, object value)
				{
				}

				public static void UpdateGlobalProperty(AdvancedDissolveKeywords.GlobalControlID globalControlID, Property property, object value)
				{
				}
			}

			[Serializable]
			public class Geometric
			{
				private class IDs
				{
					public int invert;

					public int noise;

					public int xyzAxis;

					public int xyzStyle;

					public int xyzSpace;

					public int xyzRollout;

					public int xyzPivotPointPosition;

					public int position1;

					public int normal1;

					public int radius1;

					public int height1;

					public int size1;

					public int matrixTRS1;

					public int position2;

					public int normal2;

					public int radius2;

					public int height2;

					public int size2;

					public int matrixTRS2;

					public int position3;

					public int normal3;

					public int radius3;

					public int height3;

					public int size3;

					public int matrixTRS3;

					public int position4;

					public int normal4;

					public int radius4;

					public int height4;

					public int size4;

					public int matrixTRS4;

					public IDs(int ID)
					{
					}
				}

				public enum Property
				{
					XYZAxis = 0,
					XYZStyle = 1,
					XYZSpace = 2,
					XYZRollout = 3,
					XYZPosition = 4,
					Position1 = 5,
					Normal1 = 6,
					Radius1 = 7,
					Height1 = 8,
					Size1 = 9,
					MatrixTRS1 = 10,
					Position2 = 11,
					Normal2 = 12,
					Radius2 = 13,
					Height2 = 14,
					Size2 = 15,
					MatrixTRS2 = 16,
					Position3 = 17,
					Normal3 = 18,
					Radius3 = 19,
					Height3 = 20,
					Size3 = 21,
					MatrixTRS3 = 22,
					Position4 = 23,
					Normal4 = 24,
					Radius4 = 25,
					Height4 = 26,
					Size4 = 27,
					MatrixTRS4 = 28,
					Invert = 29,
					Noise = 30
				}

				public enum XYZAxis
				{
					X = 0,
					Y = 1,
					Z = 2
				}

				public enum XYZStyle
				{
					Linear = 0,
					Rollout = 1
				}

				public enum XYZSpace
				{
					World = 0,
					Local = 1
				}

				public static class UpdateLocalProperty
				{
					public static void XYZAxis(Material material, XYZAxis xyzAxis, XYZStyle xyzStyle, XYZSpace xyzSpace, float axisRollout, Vector3 axisPosition)
					{
					}

					public static void Plane(Material material, AdvancedDissolveKeywords.CutoutGeometricCount countID, Vector3 position, Vector3 normal)
					{
					}

					public static void Sphere(Material material, AdvancedDissolveKeywords.CutoutGeometricCount countID, Vector3 position, float radius)
					{
					}

					public static void Cube(Material material, AdvancedDissolveKeywords.CutoutGeometricCount countID, Vector3 position, Quaternion rotation, Vector3 size)
					{
					}

					public static void Capsule(Material material, AdvancedDissolveKeywords.CutoutGeometricCount countID, Vector3 startPosition, Vector3 endPosition, float radius)
					{
					}

					public static void ConeSmooth(Material material, AdvancedDissolveKeywords.CutoutGeometricCount countID, Vector3 startPosition, Vector3 endPosition, float radius)
					{
					}

					public static void Invert(Material material, bool invert)
					{
					}

					public static void Noise(Material material, float noise)
					{
					}
				}

				public static class UpdateGlobalProperty
				{
					public static void XYZAxis(AdvancedDissolveKeywords.GlobalControlID globalControlID, XYZAxis xyzAxis, XYZStyle xyzStyle, XYZSpace xyzSpace, float axisRollout, Vector3 position)
					{
					}

					public static void Plane(AdvancedDissolveKeywords.GlobalControlID globalControlID, AdvancedDissolveKeywords.CutoutGeometricCount countID, Vector3 position, Vector3 normal)
					{
					}

					public static void Sphere(AdvancedDissolveKeywords.GlobalControlID globalControlID, AdvancedDissolveKeywords.CutoutGeometricCount countID, Vector3 position, float radius)
					{
					}

					public static void Cube(AdvancedDissolveKeywords.GlobalControlID globalControlID, AdvancedDissolveKeywords.CutoutGeometricCount countID, Vector3 position, Quaternion rotation, Vector3 size)
					{
					}

					public static void Capsule(AdvancedDissolveKeywords.GlobalControlID globalControlID, AdvancedDissolveKeywords.CutoutGeometricCount countID, Vector3 startPosition, Vector3 endPosition, float radius)
					{
					}

					public static void ConeSmooth(AdvancedDissolveKeywords.GlobalControlID globalControlID, AdvancedDissolveKeywords.CutoutGeometricCount countID, Vector3 startPosition, Vector3 endPosition, float radius)
					{
					}

					public static void Invert(AdvancedDissolveKeywords.GlobalControlID globalControlID, bool invert)
					{
					}

					public static void Noise(AdvancedDissolveKeywords.GlobalControlID globalControlID, float noise)
					{
					}
				}

				private static IDs[] ids;

				private static void UpdateLocal(Material material, Property property, object value)
				{
				}

				private static void UpdateGlobal(AdvancedDissolveKeywords.GlobalControlID globalControlID, Property property, object value)
				{
				}
			}
		}

		[Serializable]
		public class Edge
		{
			[Serializable]
			public class Base
			{
				private class IDs
				{
					public int widthStandard;

					public int widthGeometric;

					public int shape;

					public int color;

					public int colorTransparency;

					public int colorIntensity;

					public IDs(int ID)
					{
					}
				}

				public enum Property
				{
					WidthStandard = 0,
					WidthGeometric = 1,
					Shape = 2,
					Color = 3,
					ColorTransparency = 4,
					ColorIntensity = 5
				}

				public enum Shape
				{
					Solid = 0,
					Smooth = 1,
					Smoother = 2
				}

				private static IDs[] ids;

				[Range(0f, 1f)]
				public float widthCutoutStandard;

				[Range(0f, 1f)]
				public float widthCutoutGeometric;

				public Shape shape;

				[Space(10f)]
				[ColorUsage(false)]
				public Color color;

				[Range(0f, 1f)]
				public float colorTransparency;

				public float colorIntensity;

				public void UpdateLocal(List<Material> materials)
				{
				}

				public void UpdateLocal(Material materia)
				{
				}

				public void UpdateGlobal(AdvancedDissolveKeywords.GlobalControlID globalControlID)
				{
				}

				public static void UpdateLocalProperty(Material material, Property property, object value)
				{
				}

				public static void UpdateGlobalProperty(AdvancedDissolveKeywords.GlobalControlID globalControlID, Property property, object value)
				{
				}
			}

			[Serializable]
			public class AdditionalColor
			{
				private class IDs
				{
					public int color;

					public int colorTransparency;

					public int colorIntensity;

					public int clipInterpolation;

					public int map;

					public int mapTiling;

					public int mapOffset;

					public int mapScroll;

					public int mapReverse;

					public int mapMipMap;

					public int phaseOffset;

					public int alphaOffset;

					public IDs(int ID)
					{
					}
				}

				public enum Property
				{
					Map = 0,
					MapTiling = 1,
					MapOffset = 2,
					MapScroll = 3,
					MapReverse = 4,
					MapMipmap = 5,
					PhaseOffset = 6,
					AlphaOffset = 7,
					Color = 8,
					ColorTransparency = 9,
					ColorIntensity = 10,
					ClipInterpolation = 11
				}

				private static IDs[] ids;

				public Texture2D map;

				public Vector2 mapTiling;

				public Vector2 mapOffset;

				public Vector2 mapScroll;

				public bool mapReverse;

				[Range(0f, 10f)]
				public int mapMipmap;

				public float phaseOffset;

				[Range(-1f, 1f)]
				public float alphaOffset;

				[Space(10f)]
				[ColorUsage(false)]
				public Color color;

				[Range(0f, 1f)]
				public float colorTransparency;

				public float colorIntensity;

				[Space(10f)]
				public bool clipInterpolation;

				public void UpdateLocal(List<Material> materials)
				{
				}

				public void UpdateLocal(Material materia)
				{
				}

				public void UpdateGlobal(AdvancedDissolveKeywords.GlobalControlID globalControlID)
				{
				}

				public static void UpdateLocalProperty(Material material, Property property, object value)
				{
				}

				public static void UpdateGlobalProperty(AdvancedDissolveKeywords.GlobalControlID globalControlID, Property property, object value)
				{
				}
			}

			[Serializable]
			public class UVDistortion
			{
				private class IDs
				{
					public int map;

					public int mapTiling;

					public int mapOffset;

					public int mapScroll;

					public int strength;

					public IDs(int ID)
					{
					}
				}

				public enum Property
				{
					Map = 0,
					MapTiling = 1,
					MapOffset = 2,
					MapScroll = 3,
					Strength = 4
				}

				private static IDs[] ids;

				public Texture2D map;

				public Vector2 mapTiling;

				public Vector2 mapOffset;

				public Vector2 mapScroll;

				public float strength;

				public void UpdateLocal(List<Material> materials)
				{
				}

				public void UpdateLocal(Material materia)
				{
				}

				public void UpdateGlobal(AdvancedDissolveKeywords.GlobalControlID globalControlID)
				{
				}

				public static void UpdateLocalProperty(Material material, Property property, object value)
				{
				}

				public static void UpdateGlobalProperty(AdvancedDissolveKeywords.GlobalControlID globalControlID, Property property, object value)
				{
				}
			}

			[Serializable]
			public class GlobalIllumination
			{
				private class IDs
				{
					public int metaPassMultiplier;

					public IDs(int ID)
					{
					}
				}

				private static IDs[] ids;

				public float metaPassMultiplier;

				public void UpdateLocal(List<Material> materials)
				{
				}

				public void UpdateLocal(Material materia)
				{
				}

				public void UpdateGlobal(AdvancedDissolveKeywords.GlobalControlID globalControlID)
				{
				}

				public static void UpdateLocalProperty(Material material, float value)
				{
				}

				public static void UpdateGlobalProperty(AdvancedDissolveKeywords.GlobalControlID globalControlID, float value)
				{
				}
			}
		}
	}
}
