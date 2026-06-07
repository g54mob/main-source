using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Shapes
{
	internal struct RenderState : IEquatable<RenderState>
	{
		public Shader shader;

		public string[] keywords;

		public CompareFunction zTest;

		public float zOffsetFactor;

		public int zOffsetUnits;

		public CompareFunction stencilComp;

		public StencilOp stencilOpPass;

		public byte stencilRefID;

		public byte stencilReadMask;

		public byte stencilWriteMask;

		public RenderState(Material mat)
		{
			shader = null;
			keywords = null;
			zTest = default(CompareFunction);
			zOffsetFactor = 0f;
			zOffsetUnits = 0;
			stencilComp = default(CompareFunction);
			stencilOpPass = default(StencilOp);
			stencilRefID = 0;
			stencilReadMask = 0;
			stencilWriteMask = 0;
		}

		public Material CreateMaterial()
		{
			return null;
		}

		private static bool StrArrEquals(string[] a, string[] b)
		{
			return false;
		}

		public bool Equals(RenderState other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
