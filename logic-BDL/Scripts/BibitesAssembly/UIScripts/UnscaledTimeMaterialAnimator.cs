using UnityEngine;

namespace UIScripts
{
	public class UnscaledTimeMaterialAnimator : MonoBehaviour
	{
		public bool modulate;

		public float period;

		private float time;

		private static readonly int UnscaledTime = Shader.PropertyToID("_unscaledTime");

		private void Update()
		{
			time += Time.unscaledDeltaTime;
			time = (modulate ? (time % period) : time);
			Shader.SetGlobalFloat(UnscaledTime, time);
		}
	}
}
