using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class ManipulationVelocities : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public float AngularVelocity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Point ExpansionVelocity
		{
			get
			{
				return default(Point);
			}
			set
			{
			}
		}

		public Point LinearVelocity
		{
			get
			{
				return default(Point);
			}
			set
			{
			}
		}

		internal ManipulationVelocities(IntPtr cPtr, bool cMemoryOwn)
		{
		}

		internal static HandleRef getCPtr(ManipulationVelocities obj)
		{
			return default(HandleRef);
		}

		~ManipulationVelocities()
		{
		}

		public virtual void Dispose()
		{
		}

		public ManipulationVelocities()
		{
		}
	}
}
