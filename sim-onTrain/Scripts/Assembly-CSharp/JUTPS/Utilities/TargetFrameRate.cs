using UnityEngine;

namespace JUTPS.Utilities
{
	public class TargetFrameRate : MonoBehaviour
	{
		public int TargetFPS = -1;

		private void Start()
		{
			Application.targetFrameRate = TargetFPS;
		}
	}
}
