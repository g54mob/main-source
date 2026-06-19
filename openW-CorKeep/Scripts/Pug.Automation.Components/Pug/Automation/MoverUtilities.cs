using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Pug.Automation
{
	public static class MoverUtilities
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int CalculateMoveTimer(in MoverCD moverCD, float2 moveePosition)
		{
			return (int)math.round((float)moverCD.moveTime * math.distancesq(moveePosition, moverCD.stop) / math.distancesq(moverCD.start, moverCD.stop));
		}
	}
}
