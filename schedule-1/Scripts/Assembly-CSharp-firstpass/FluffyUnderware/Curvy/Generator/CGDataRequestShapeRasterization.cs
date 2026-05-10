using System;
using JetBrains.Annotations;
using ToolBuddy.Pooling.Collections;

namespace FluffyUnderware.Curvy.Generator
{
	public class CGDataRequestShapeRasterization : CGDataRequestRasterization
	{
		private SubArray<float> relativeDistances;

		public SubArray<float> RelativeDistances
		{
			get
			{
				return default(SubArray<float>);
			}
			set
			{
			}
		}

		[Obsolete("Use RelativeDistances instead")]
		[UsedImplicitly]
		public float[] PathF
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CGDataRequestShapeRasterization(SubArray<float> relativeDistance, float start, float rasterizedRelativeLength, int resolution, float angle, ModeEnum mode = ModeEnum.Even)
			: base(0f, 0f, 0, 0f)
		{
		}

		[Obsolete("Use another constructor instead")]
		[UsedImplicitly]
		public CGDataRequestShapeRasterization(float[] pathF, float start, float rasterizedRelativeLength, int resolution, float angle, ModeEnum mode = ModeEnum.Even)
			: base(0f, 0f, 0, 0f)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
