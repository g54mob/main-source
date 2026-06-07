using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public abstract class BrushShader : Animatable
	{
		protected enum Target
		{
			Path = 0,
			Path_AA = 1,
			SDF = 2,
			SDF_LCD = 3,
			Opacity = 4
		}

		private GCHandle _constantsHandle;

		internal BrushShader(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(BrushShader obj)
		{
			return default(HandleRef);
		}

		protected BrushShader()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~BrushShader()
		{
		}

		protected void SetConstantBuffer<T>(T constants) where T : class
		{
		}

		protected void SetPixelShader(IntPtr shader, Target target)
		{
		}

		protected NoesisShader CreateShader()
		{
			return null;
		}

		protected void SetShader(NoesisShader shader)
		{
		}

		private void SetPixelShader(IntPtr value, int target)
		{
		}

		private void SetConstantBuffer(IntPtr buffer, uint size)
		{
		}

		protected void InvalidateConstantBuffer()
		{
		}

		internal new static IntPtr Extend(string typeName)
		{
			return (IntPtr)0;
		}
	}
}
