using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public static class UMAUtils
	{
		public enum PipelineType
		{
			Unsupported = 0,
			BuiltInPipeline = 1,
			UniversalPipeline = 2,
			HDPipeline = 3,
			NotSet = 4
		}

		public static Dictionary<string, string> URPTextureTranslation;

		public static Dictionary<string, string> HDRPTextureTranslation;

		public static Dictionary<PipelineType, Dictionary<string, string>> PipelineTranslations;

		public static PipelineType CurrentPipeline;

		public static int StringToHash(string name)
		{
			return 0;
		}

		public static float GaussianRandom(float mean, float dev)
		{
			return 0f;
		}

		public static PipelineType DetectPipeline()
		{
			return default(PipelineType);
		}

		public static void UDIMAdjustUV(Vector2[] dest, Vector2[] src)
		{
		}

		public static Material GetDefaultDiffuseMaterial()
		{
			return null;
		}

		public static string TranslatedSRPTextureName(string BuiltinName)
		{
			return null;
		}

		public static int GetCardinality(BitArray bitArray)
		{
			return 0;
		}

		public static string GetAssetFolder(string path)
		{
			return null;
		}

		public static void DestroyAvatar(Avatar obj)
		{
		}

		public static void DestroySceneObject(Object obj)
		{
		}
	}
}
