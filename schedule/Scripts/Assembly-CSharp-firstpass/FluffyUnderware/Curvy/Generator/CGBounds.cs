using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	[CGDataInfo(1f, 0.8f, 0.5f, 1f)]
	public class CGBounds : CGData
	{
		protected Bounds? mBounds;

		public Bounds Bounds
		{
			get
			{
				return default(Bounds);
			}
			set
			{
			}
		}

		public float Depth => 0f;

		public CGBounds()
		{
		}

		public CGBounds(Bounds bounds)
		{
		}

		public CGBounds(CGBounds source)
		{
		}

		public virtual void RecalculateBounds()
		{
		}

		public override T Clone<T>()
		{
			return null;
		}

		public static void Copy(CGBounds dest, CGBounds source)
		{
		}
	}
}
