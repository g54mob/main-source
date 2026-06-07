using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.BladedEngineScripts
{
	public class PropellerCollisionScript : MonoBehaviour
	{
		private BladedEngineScript _bladedEngine;

		private Collider[] _colliders;

		private bool _collidersEnabled;

		private int _fixedUpdateCount;

		private PartScript _partScript;

		protected virtual void Awake()
		{
			_colliders = GetComponentsInChildren<Collider>();
			Collider[] colliders = _colliders;
			for (int i = 0; i < colliders.Length; i++)
			{
				colliders[i].isTrigger = true;
			}
		}

		protected virtual void FixedUpdate()
		{
			_fixedUpdateCount++;
		}

		protected virtual void OnCollisionEnter(Collision collision)
		{
			if (_bladedEngine != null && _bladedEngine.RpmAbs > 50f && !_partScript.Aircraft.RemoteAircraft)
			{
				_bladedEngine.DestroyEngine(null);
			}
		}

		protected virtual void OnTriggerEnter(Collider other)
		{
			Collider[] colliders = _colliders;
			for (int i = 0; i < colliders.Length; i++)
			{
				Physics.IgnoreCollision(colliders[i], other, ignore: true);
			}
		}

		protected virtual void Start()
		{
			_partScript = base.gameObject.GetComponentInParent<PartScript>();
			_bladedEngine = _partScript.GetComponentInChildren<BladedEngineScript>();
			Collider[] componentsInChildren = _partScript.GetComponentsInChildren<Collider>();
			foreach (Collider collider in componentsInChildren)
			{
				Collider[] colliders = _colliders;
				foreach (Collider collider2 in colliders)
				{
					Physics.IgnoreCollision(collider, collider2, ignore: true);
				}
			}
		}

		protected virtual void Update()
		{
			if (_fixedUpdateCount >= 1 && !_collidersEnabled)
			{
				_collidersEnabled = true;
				Collider[] colliders = _colliders;
				for (int i = 0; i < colliders.Length; i++)
				{
					colliders[i].isTrigger = false;
				}
			}
		}
	}
}
