using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;

namespace LitMotion.Adapters
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct RectMotionAdapter : IMotionAdapter<Rect, NoOptions>
	{
		public Rect Evaluate(ref Rect startValue, ref Rect endValue, ref NoOptions options, in MotionEvaluationContext context)
		{
			float x = math.lerp(startValue.x, endValue.x, context.Progress);
			float y = math.lerp(startValue.y, endValue.y, context.Progress);
			float width = math.lerp(startValue.width, endValue.width, context.Progress);
			float height = math.lerp(startValue.height, endValue.height, context.Progress);
			return new Rect(x, y, width, height);
		}

		Rect IMotionAdapter<Rect, NoOptions>.Evaluate(ref Rect startValue, ref Rect endValue, ref NoOptions options, in MotionEvaluationContext context)
		{
			return Evaluate(ref startValue, ref endValue, ref options, in context);
		}
	}
}
