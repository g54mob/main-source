using DV.Utils;
using UnityEngine;

namespace DV.VFX
{
	public class UpdateParticleSystemRenderBounds : MonoBehaviour
	{
		private const float MAX_DIST_BETWEEN_BOUNDS_UPDATE = 4f;

		private ParticleSystem particles;

		private Vector3 lastPos;

		private void Awake()
		{
			particles = GetComponent<ParticleSystem>();
			if (!particles)
			{
				Debug.LogError("Missing ParticleSystem on GameObject, Destroying UpdateParticleSystemRenderBounds.", this);
				Object.Destroy(this);
			}
			else
			{
				SetupListeners(on: true);
				base.enabled = SingletonBehaviour<AppUtil>.Instance.IsTimePaused;
			}
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(on: false);
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				SingletonBehaviour<AppUtil>.Instance.GamePaused += AppUtilOnGamePaused;
				SingletonBehaviour<AppUtil>.Instance.GameUnpaused += AppUtilOnGameUnpaused;
			}
			else
			{
				SingletonBehaviour<AppUtil>.Instance.GamePaused -= AppUtilOnGamePaused;
				SingletonBehaviour<AppUtil>.Instance.GameUnpaused -= AppUtilOnGameUnpaused;
			}
		}

		private void AppUtilOnGameUnpaused()
		{
			base.enabled = false;
		}

		private void AppUtilOnGamePaused()
		{
			base.enabled = true;
		}

		private void Update()
		{
			if (particles.particleCount == 0)
			{
				base.enabled = false;
			}
			else if (Vector3.Distance(lastPos, base.transform.position) > 4f)
			{
				lastPos = base.transform.position;
				particles.Simulate(float.Epsilon, withChildren: false, restart: false);
				particles.Play();
			}
		}
	}
}
