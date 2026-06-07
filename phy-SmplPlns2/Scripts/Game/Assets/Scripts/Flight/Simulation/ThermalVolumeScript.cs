using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Levels;
using UnityEngine;

namespace Assets.Scripts.Flight.Simulation
{
	public class ThermalVolumeScript : MonoBehaviour
	{
		private class VolumeRigidBody
		{
			public Collider Collider { get; set; }

			public float OriginalAngularDrag { get; set; }

			public float OriginalDrag { get; set; }

			public Rigidbody RigidBody { get; set; }
		}

		public float AngularDrag;

		public float Drag;

		public float Updraft = -0.25f;

		public string VolumeName;

		private List<VolumeRigidBody> _volumeBodies = new List<VolumeRigidBody>();

		public float ThermalUpdraftForce { get; set; }

		protected virtual void OnTriggerEnter(Collider collider)
		{
			if (!(collider.gameObject != base.gameObject))
			{
				return;
			}
			Rigidbody componentInParent = collider.transform.GetComponentInParent<Rigidbody>(includeInactive: true);
			if (componentInParent != null)
			{
				VolumeRigidBody volumeRigidBody = new VolumeRigidBody();
				volumeRigidBody.Collider = collider;
				volumeRigidBody.RigidBody = componentInParent;
				volumeRigidBody.OriginalDrag = componentInParent.linearDamping;
				volumeRigidBody.OriginalAngularDrag = componentInParent.angularDamping;
				componentInParent.linearDamping = Drag;
				componentInParent.angularDamping = AngularDrag;
				_volumeBodies.Add(volumeRigidBody);
			}
			if (LevelBase.CurrentLevel != null)
			{
				PartScript componentInParent2 = collider.transform.GetComponentInParent<PartScript>(includeInactive: true);
				if (componentInParent2 != null)
				{
					LevelBase.CurrentLevel.OnPartEnterThermal(componentInParent2, this);
				}
			}
		}

		protected virtual void OnTriggerExit(Collider collider)
		{
			for (int i = 0; i < _volumeBodies.Count; i++)
			{
				if (_volumeBodies[i].Collider == collider)
				{
					_volumeBodies[i].RigidBody.linearDamping = _volumeBodies[i].OriginalDrag;
					_volumeBodies.RemoveAt(i);
					break;
				}
			}
		}

		protected virtual void Update()
		{
			if (!((double)ThermalUpdraftForce > 0.0))
			{
				return;
			}
			foreach (VolumeRigidBody volumeBody in _volumeBodies)
			{
				if (volumeBody.Collider.bounds.min.y < 0f)
				{
					float num = (0f - volumeBody.Collider.bounds.min.y) / 1f * ThermalUpdraftForce;
					if (num > ThermalUpdraftForce)
					{
						num = ThermalUpdraftForce;
					}
					volumeBody.RigidBody.AddForce(Vector3.up * (num * 0.01f));
				}
			}
		}
	}
}
