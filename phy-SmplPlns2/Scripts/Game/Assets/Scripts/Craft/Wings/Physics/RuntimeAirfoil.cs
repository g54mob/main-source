using System.Runtime.InteropServices;
using Unity.Burst;

namespace Assets.Scripts.Craft.Wings.Physics
{
	public struct RuntimeAirfoil
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void EvaluateAirfoilDelegate(float chordReynolds, float freeStreamMach, in RuntimeAirfoil airfoil, out SlicePolar polar);

		public unsafe void* data;

		public FunctionPointer<EvaluateAirfoilDelegate> function;

		public unsafe readonly ref readonly T GetData<T>() where T : unmanaged
		{
			return ref *(T*)data;
		}
	}
}
