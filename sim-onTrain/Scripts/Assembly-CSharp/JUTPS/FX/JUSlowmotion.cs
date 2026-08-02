using UnityEngine;

namespace JUTPS.FX
{
	[AddComponentMenu("JU TPS/FX/Slow Motion")]
	public class JUSlowmotion : MonoBehaviour
	{
		public static JUSlowmotion Instance;

		[Header("Slowmotion Settings")]
		public bool EnableSlowmotion = true;

		private float SlowDownFactor = 0.05f;

		private float SlowDownLenght = 1f;

		protected virtual void Start()
		{
			Instance = this;
			Time.fixedDeltaTime = 0.015f;
		}

		protected virtual void Update()
		{
			if (EnableSlowmotion)
			{
				Time.timeScale += 1f / SlowDownLenght * Time.unscaledDeltaTime;
				Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
				Time.fixedDeltaTime = Mathf.Clamp(Time.fixedDeltaTime, 0.01f, 0.333f);
			}
		}

		public static void DoSlowMotion(float timescale = 0.1f, float duration = 2f)
		{
			if (!(Instance == null))
			{
				if (!Instance.EnableSlowmotion)
				{
					Debug.LogWarning("Called Slow Motion effect but it is not enabled");
					return;
				}
				Instance.SlowDownFactor = timescale;
				Instance.SlowDownLenght = duration;
				Time.timeScale = timescale;
				Time.fixedDeltaTime = Time.timeScale * 0.01f;
				Instance.Invoke("DisableSlowmotion", 0.4f * duration);
			}
		}

		public static void DoSlowMotion()
		{
			if (!(Instance == null))
			{
				if (!Instance.EnableSlowmotion)
				{
					Debug.LogWarning("Called Slow Motion effect but it is not enabled");
					return;
				}
				Instance.SlowDownFactor = 0.1f;
				Instance.SlowDownLenght = 2f;
				Time.timeScale = Instance.SlowDownFactor;
				Time.fixedDeltaTime = Time.timeScale * 0.01f;
				Instance.Invoke("DisableSlowmotion", 0.4f * Instance.SlowDownLenght);
			}
		}

		public void DisableSlowmotion()
		{
			SlowDownFactor = 1f;
			SlowDownLenght = 1f;
			Time.timeScale = 1f;
			Time.fixedDeltaTime = 0.015f;
		}
	}
}
