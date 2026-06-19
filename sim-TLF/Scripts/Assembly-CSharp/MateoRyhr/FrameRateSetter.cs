using UnityEngine;

namespace MateoRyhr
{
	public class FrameRateSetter : MonoBehaviour
	{
		[SerializeField]
		private IntVariable TargetFrameRate;

		private void Awake()
		{
			Application.targetFrameRate = TargetFrameRate.Value;
		}
	}
}
