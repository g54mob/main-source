using System.Collections.Generic;
using UnityEngine;

namespace AmazingAssets.AdvancedDissolve
{
	public static class AdvancedDissolveKeywords
	{
		public enum State
		{
			Disabled = 0,
			Enabled = 1
		}

		public enum CutoutStandardSource
		{
			None = 0,
			BaseAlpha = 1,
			CustomMap = 2,
			TwoCustomMaps = 3,
			ThreeCustomMaps = 4,
			UserDefined = 5
		}

		public enum CutoutStandardSourceMapsMappingType
		{
			Default = 0,
			Triplanar = 1,
			ScreenSpace = 2
		}

		public enum CutoutGeometricType
		{
			None = 0,
			XYZAxis = 1,
			Plane = 2,
			Sphere = 3,
			Cube = 4,
			Capsule = 5,
			ConeSmooth = 6
		}

		public enum CutoutGeometricCount
		{
			One = 0,
			Two = 1,
			Three = 2,
			Four = 3
		}

		public enum EdgeBaseSource
		{
			None = 0,
			CutoutStandard = 1,
			CutoutGeometric = 2,
			All = 3
		}

		public enum EdgeAdditionalColorSource
		{
			None = 0,
			BaseColor = 1,
			CustomMap = 2,
			GradientMap = 3,
			GradientColor = 4,
			UserDefined = 5
		}

		public enum EdgeUVDistortionSource
		{
			Default = 0,
			CustomMap = 1
		}

		public enum GlobalControlID
		{
			None = 0,
			One = 1,
			Two = 2,
			Three = 3,
			Four = 4
		}

		private enum EnumID
		{
			State = 0,
			CutoutStandardSource = 1,
			CutoutStandardSourceMapsMappingType = 2,
			CutoutGeometricType = 3,
			CutoutGeometricCount = 4,
			EdgeBaseSource = 5,
			EdgeAdditionalColorSource = 6,
			EdgeUVDistortionSource = 7,
			GlobalControlID = 8
		}

		private static string[][] enumNames;

		private static int[] materialKeywordVariables;

		public static void GetKeywords(Material material, out State state, out CutoutStandardSource cutoutStandardSource, out CutoutStandardSourceMapsMappingType cutoutStandardSourceMapsMappingType, out CutoutGeometricType cutoutGeometricType, out CutoutGeometricCount cutoutGeometricCount, out EdgeBaseSource edgeBaseSource, out EdgeAdditionalColorSource edgeAdditionalColorSource, out EdgeUVDistortionSource edgeUVDistortionSource, out GlobalControlID globalControlID)
		{
			state = default(State);
			cutoutStandardSource = default(CutoutStandardSource);
			cutoutStandardSourceMapsMappingType = default(CutoutStandardSourceMapsMappingType);
			cutoutGeometricType = default(CutoutGeometricType);
			cutoutGeometricCount = default(CutoutGeometricCount);
			edgeBaseSource = default(EdgeBaseSource);
			edgeAdditionalColorSource = default(EdgeAdditionalColorSource);
			edgeUVDistortionSource = default(EdgeUVDistortionSource);
			globalControlID = default(GlobalControlID);
		}

		public static void RemoveAll(Material material, bool ignoreState)
		{
		}

		public static void Reload(Material material)
		{
		}

		public static void GetKeyword(Material material, out State keyword)
		{
			keyword = default(State);
		}

		public static void SetKeyword(Material material, State keyword, bool enable)
		{
		}

		public static void SetKeyword(List<Material> materials, State keyword, bool enable)
		{
		}

		public static void GetKeyword(Material material, out CutoutStandardSource keyword)
		{
			keyword = default(CutoutStandardSource);
		}

		public static void SetKeyword(Material material, CutoutStandardSource keyword, bool enable)
		{
		}

		public static void SetKeyword(List<Material> materials, CutoutStandardSource keyword, bool enable)
		{
		}

		public static void GetKeyword(Material material, out CutoutStandardSourceMapsMappingType keyword)
		{
			keyword = default(CutoutStandardSourceMapsMappingType);
		}

		public static void SetKeyword(Material material, CutoutStandardSourceMapsMappingType keyword, bool enable)
		{
		}

		public static void SetKeyword(List<Material> materials, CutoutStandardSourceMapsMappingType keyword, bool enable)
		{
		}

		public static void GetKeyword(Material material, out CutoutGeometricType keyword)
		{
			keyword = default(CutoutGeometricType);
		}

		public static void SetKeyword(Material material, CutoutGeometricType keyword, bool enable)
		{
		}

		public static void SetKeyword(List<Material> materials, CutoutGeometricType keyword, bool enable)
		{
		}

		public static void GetKeyword(Material material, out CutoutGeometricCount keyword)
		{
			keyword = default(CutoutGeometricCount);
		}

		public static void SetKeyword(Material material, CutoutGeometricCount keyword, bool enable)
		{
		}

		public static void SetKeyword(List<Material> materials, CutoutGeometricCount keyword, bool enable)
		{
		}

		public static void GetKeyword(Material material, out EdgeBaseSource keyword)
		{
			keyword = default(EdgeBaseSource);
		}

		public static void SetKeyword(Material material, EdgeBaseSource keyword, bool enable)
		{
		}

		public static void SetKeyword(List<Material> materials, EdgeBaseSource keyword, bool enable)
		{
		}

		public static void GetKeyword(Material material, out EdgeAdditionalColorSource keyword)
		{
			keyword = default(EdgeAdditionalColorSource);
		}

		public static void SetKeyword(Material material, EdgeAdditionalColorSource keyword, bool enable)
		{
		}

		public static void SetKeyword(List<Material> materials, EdgeAdditionalColorSource keyword, bool enable)
		{
		}

		public static void GetKeyword(Material material, out EdgeUVDistortionSource keyword)
		{
			keyword = default(EdgeUVDistortionSource);
		}

		public static void SetKeyword(Material material, EdgeUVDistortionSource keyword, bool enable)
		{
		}

		public static void SetKeyword(List<Material> materials, EdgeUVDistortionSource keyword, bool enable)
		{
		}

		public static void GetKeyword(Material material, out GlobalControlID keyword)
		{
			keyword = default(GlobalControlID);
		}

		public static void SetKeyword(Material material, GlobalControlID keyword, bool enable)
		{
		}

		public static void SetKeyword(List<Material> materials, GlobalControlID keyword, bool enable)
		{
		}

		public static string ToString(State keyword)
		{
			return null;
		}

		public static string ToString(CutoutStandardSource keyword)
		{
			return null;
		}

		public static string ToString(CutoutStandardSourceMapsMappingType keyword)
		{
			return null;
		}

		public static string ToString(CutoutGeometricType keyword)
		{
			return null;
		}

		public static string ToString(CutoutGeometricCount keyword)
		{
			return null;
		}

		public static string ToString(EdgeBaseSource keyword)
		{
			return null;
		}

		public static string ToString(EdgeAdditionalColorSource keyword)
		{
			return null;
		}

		public static string ToString(EdgeUVDistortionSource keyword)
		{
			return null;
		}

		public static string ToString(GlobalControlID keyword)
		{
			return null;
		}

		private static void SetKeyword(Material material, int enumID, int enumValue, bool enable)
		{
		}

		private static int GetKeywordByMaterialVariable(Material material, int enumID)
		{
			return 0;
		}
	}
}
