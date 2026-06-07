using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ManipulationDelta : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public Vector Scale => default(Vector);

		public Vector Translation => default(Vector);

		public Vector Expansion => default(Vector);

		public float Rotation => 0f;

		internal ManipulationDelta(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(ManipulationDelta obj)
		{
			return default(HandleRef);
		}

		~ManipulationDelta()
		{
		}

		public virtual void Dispose()
		{
		}

		private float GetScaleHelper()
		{
			return 0f;
		}

		private Point GetTranslationHelper()
		{
			return default(Point);
		}

		private Point GetExpansionHelper()
		{
			return default(Point);
		}

		public ManipulationDelta()
		{
		}
	}
}
