using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public abstract class ShaderEffect : Effect
	{
		private GCHandle _constantsHandle;

		internal ShaderEffect(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(ShaderEffect obj)
		{
			return default(HandleRef);
		}

		protected ShaderEffect()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		~ShaderEffect()
		{
		}

		protected void SetConstantBuffer<T>(T constants) where T : class
		{
		}

		protected NoesisShader CreateShader()
		{
			return null;
		}

		public void SetShader(NoesisShader shader)
		{
		}

		protected void SetPadding(float left, float top, float right, float bottom)
		{
		}

		protected void SetPixelShader(IntPtr value)
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
