using UnityEngine;

namespace Assets.Scripts.Flight.Explosions
{
	public class FlakExplosionScript : MonoBehaviour
	{
		[SerializeField]
		private float _blastForce = 30f;

		[SerializeField]
		private float _blastRadius = 20f;

		[SerializeField]
		private float _criticalBlastRadius = 5f;

		private ExplosiveForceScript _explosiveForceScript;

		[SerializeField]
		private float _lifetime = 5f;

		protected virtual void Start()
		{
			_explosiveForceScript = base.gameObject.AddComponent<ExplosiveForceScript>();
			_explosiveForceScript.BlastForce = _blastForce;
			_explosiveForceScript.BlastRadius = _blastRadius;
			_explosiveForceScript.CriticalBlastRadius = _criticalBlastRadius;
			_explosiveForceScript.Detonate(null, null, null);
			GetComponent<AudioSource>().PlayDelayed(Vector3.Distance(FlightSceneScript.Instance.LocalPlayer?.FramePosition ?? Vector3.zero, base.transform.position) / 340.29f);
			Object.Destroy(base.gameObject, _lifetime);
		}
	}
}
