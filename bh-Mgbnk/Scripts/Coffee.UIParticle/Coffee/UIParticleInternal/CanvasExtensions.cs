using UnityEngine;

namespace Coffee.UIParticleInternal
{
	internal static class CanvasExtensions
	{
		public static bool ShouldGammaToLinearInShader(this Canvas canvas)
		{
			return false;
		}

		public static bool ShouldGammaToLinearInMesh(this Canvas canvas)
		{
			return false;
		}

		public static bool IsStereoCanvas(this Canvas canvas)
		{
			return false;
		}

		public static void GetViewProjectionMatrix(this Canvas canvas, out Matrix4x4 vpMatrix)
		{
			vpMatrix = default(Matrix4x4);
		}

		public static void GetViewProjectionMatrix(this Canvas canvas, Camera.MonoOrStereoscopicEye eye, out Matrix4x4 vpMatrix)
		{
			vpMatrix = default(Matrix4x4);
		}

		public static void GetViewProjectionMatrix(this Canvas canvas, out Matrix4x4 vMatrix, out Matrix4x4 pMatrix)
		{
			vMatrix = default(Matrix4x4);
			pMatrix = default(Matrix4x4);
		}

		public static void GetViewProjectionMatrix(this Canvas canvas, Camera.MonoOrStereoscopicEye eye, out Matrix4x4 vMatrix, out Matrix4x4 pMatrix)
		{
			vMatrix = default(Matrix4x4);
			pMatrix = default(Matrix4x4);
		}
	}
}
