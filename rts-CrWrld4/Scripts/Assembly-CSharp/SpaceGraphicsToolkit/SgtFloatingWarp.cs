using UnityEngine;

namespace SpaceGraphicsToolkit
{
	public abstract class SgtFloatingWarp : MonoBehaviour
	{
		public SgtFloatingPoint Point;

		public abstract bool CanAbortWarp { get; }

		public void WarpTo(SgtPosition position, double distance)
		{
		}

		public abstract void WarpTo(SgtPosition position);

		public abstract void AbortWarp();
	}
}
