using System;
using System.Linq;
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
			shader = mat.shader;
			keywords = mat.shaderKeywords;
			zTest = (CompareFunction)mat.GetInt(ShapesMaterialUtils.propZTest);
			zOffsetFactor = mat.GetFloat(ShapesMaterialUtils.propZOffsetFactor);
			zOffsetUnits = mat.GetInt(ShapesMaterialUtils.propZOffsetUnits);
			stencilComp = (CompareFunction)mat.GetInt(ShapesMaterialUtils.propStencilComp);
			stencilOpPass = (StencilOp)mat.GetInt(ShapesMaterialUtils.propStencilOpPass);
			stencilRefID = (byte)mat.GetInt(ShapesMaterialUtils.propStencilID);
			stencilReadMask = (byte)mat.GetInt(ShapesMaterialUtils.propStencilReadMask);
			stencilWriteMask = (byte)mat.GetInt(ShapesMaterialUtils.propStencilWriteMask);
		}

		public Material CreateMaterial()
		{
			Material material = new Material(shader);
			material.shaderKeywords = keywords;
			material.SetInt(ShapesMaterialUtils.propZTest, (int)zTest);
			material.SetFloat(ShapesMaterialUtils.propZOffsetFactor, zOffsetFactor);
			material.SetInt(ShapesMaterialUtils.propZOffsetUnits, zOffsetUnits);
			material.SetInt(ShapesMaterialUtils.propStencilComp, (int)stencilComp);
			material.SetInt(ShapesMaterialUtils.propStencilOpPass, (int)stencilOpPass);
			material.SetInt(ShapesMaterialUtils.propStencilID, stencilRefID);
			material.SetInt(ShapesMaterialUtils.propStencilReadMask, stencilReadMask);
			material.SetInt(ShapesMaterialUtils.propStencilWriteMask, stencilWriteMask);
			material.enableInstancing = true;
			UnityEngine.Object.DontDestroyOnLoad(material);
			return material;
		}

		private static bool StrArrEquals(string[] a, string[] b)
		{
			if (a == null || b == null)
			{
				return a == b;
			}
			if (a.Length == b.Length)
			{
				return a.SequenceEqual(b);
			}
			return false;
		}

		public bool Equals(RenderState other)
		{
			if (object.Equals(shader, other.shader) && StrArrEquals(keywords, other.keywords) && zTest == other.zTest && zOffsetFactor.Equals(other.zOffsetFactor) && zOffsetUnits == other.zOffsetUnits && stencilComp == other.stencilComp && stencilOpPass == other.stencilOpPass && stencilRefID == other.stencilRefID && stencilReadMask == other.stencilReadMask)
			{
				return stencilWriteMask == other.stencilWriteMask;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is RenderState other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = ((shader != null) ? shader.GetHashCode() : 0);
			if (keywords != null)
			{
				string[] array = keywords;
				for (int i = 0; i < array.Length; i++)
				{
					num = (num * 397) ^ (array[i]?.GetHashCode() ?? 0);
				}
			}
			num = (num * 397) ^ (int)zTest;
			num = (num * 397) ^ zOffsetFactor.GetHashCode();
			num = (num * 397) ^ zOffsetUnits;
			num = (num * 397) ^ (int)stencilComp;
			num = (num * 397) ^ (int)stencilOpPass;
			num = (num * 397) ^ stencilRefID.GetHashCode();
			num = (num * 397) ^ stencilReadMask.GetHashCode();
			return (num * 397) ^ stencilWriteMask.GetHashCode();
		}
	}
}
