using UnityEngine;
using UnityEngine.Rendering;

namespace Shapes
{
	internal abstract class ShapeDrawCall
	{
		public ShapeDrawState drawState;

		public MaterialPropertyBlock mpb;

		public int count;

		public abstract void AddToCommandBuffer(CommandBuffer cmd);
	}
}
