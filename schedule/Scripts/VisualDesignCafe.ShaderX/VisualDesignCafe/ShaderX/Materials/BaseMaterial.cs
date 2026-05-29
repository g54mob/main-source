using System;
using UnityEngine;

namespace VisualDesignCafe.ShaderX.Materials
{
	public class BaseMaterial
	{
		private enum StencilUsage
		{
			Clear = 0,
			IsUnlit = 1,
			RequiresDeferredLighting = 2,
			SubsurfaceScattering = 4,
			TraceReflectionRay = 8,
			Decals = 16,
			ObjectMotionVector = 32,
			ExcludeFromTAA = 2,
			DistortionVectors = 4,
			SMAA = 4,
			WaterSurface = 16,
			AfterOpaqueReservedBits = 56,
			UserBit0 = 64,
			UserBit1 = 128,
			HDRPReservedBits = 63
		}

		public readonly Material Material;

		public BaseMaterial(Material material)
		{
		}

		public virtual void Validate(bool clean)
		{
		}

		protected void SetKeyword(string keyword, bool isEnabled)
		{
		}

		protected bool GetKeyword(string keyword)
		{
			return false;
		}

		protected bool TrySetInt(string propertyName, int value, Action validate = null)
		{
			return false;
		}

		protected int TryGetInt(string propertyName)
		{
			return 0;
		}

		protected bool TrySetFloat(string propertyName, float value, Action validate = null)
		{
			return false;
		}

		protected float TryGetFloat(string propertyName)
		{
			return 0f;
		}

		protected bool TrySetTexture(string propertyName, Texture value, Action validate = null)
		{
			return false;
		}

		protected bool TrySetTexture(Texture value, params string[] propertyName)
		{
			return false;
		}

		protected Texture TryGetTexture(string propertyName)
		{
			return null;
		}

		protected Texture TryGetTexture(params string[] propertyName)
		{
			return null;
		}

		protected bool TrySetColor(string propertyName, Color value, Action validate = null)
		{
			return false;
		}

		protected bool TrySetColor(Color value, params string[] propertyName)
		{
			return false;
		}

		protected Color TryGetColor(string propertyName)
		{
			return default(Color);
		}

		protected Color TryGetColor(params string[] propertyName)
		{
			return default(Color);
		}

		protected bool TrySetVector(string propertyName, Vector4 value, Action validate = null)
		{
			return false;
		}

		protected Vector4 TryGetVector(string propertyName)
		{
			return default(Vector4);
		}

		protected void SetDirty()
		{
		}

		protected virtual bool GetMotionVectorsEnabled()
		{
			return false;
		}

		protected virtual void ValidatePasses(bool receivesSSR, bool useSplitLighting)
		{
		}

		private void ComputeStencilProperties(bool receivesLighting, bool forwardOnly, bool receivesSSR, bool useSplitLighting, out int stencilRef, out int stencilWriteMask, out int stencilRefDepth, out int stencilWriteMaskDepth, out int stencilRefGBuffer, out int stencilWriteMaskGBuffer, out int stencilRefMV, out int stencilWriteMaskMV)
		{
			stencilRef = default(int);
			stencilWriteMask = default(int);
			stencilRefDepth = default(int);
			stencilWriteMaskDepth = default(int);
			stencilRefGBuffer = default(int);
			stencilWriteMaskGBuffer = default(int);
			stencilRefMV = default(int);
			stencilWriteMaskMV = default(int);
		}

		private void SetupStencil(bool receivesLighting, bool receivesSSR, bool useSplitLighting)
		{
		}
	}
}
