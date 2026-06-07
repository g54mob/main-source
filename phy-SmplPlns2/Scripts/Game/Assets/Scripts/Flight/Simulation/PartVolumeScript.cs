using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Flight.Simulation
{
	public class PartVolumeScript : MonoBehaviour
	{
		public delegate void PartDelegate(PartScript part);

		public class VolumePart
		{
			public Collider Collider { get; set; }

			public PartScript Part { get; set; }
		}

		private List<VolumePart> _volumeParts = new List<VolumePart>();

		public List<VolumePart> VolumeParts => _volumeParts;

		public event PartDelegate PartEntered;

		public bool HasAnyParts()
		{
			return _volumeParts.Count > 0;
		}

		public bool HasPart(PartScript part)
		{
			foreach (VolumePart volumePart in _volumeParts)
			{
				if (volumePart.Part == part)
				{
					return true;
				}
			}
			return false;
		}

		protected virtual void OnTriggerEnter(Collider collider)
		{
			if (collider.gameObject != base.gameObject)
			{
				PartScript componentInParent = collider.transform.GetComponentInParent<PartScript>(includeInactive: true);
				if (componentInParent != null)
				{
					VolumePart volumePart = new VolumePart();
					volumePart.Part = componentInParent;
					volumePart.Collider = collider;
					_volumeParts.Add(volumePart);
					this.PartEntered?.Invoke(componentInParent);
				}
			}
		}

		protected virtual void OnTriggerExit(Collider collider)
		{
			for (int i = 0; i < _volumeParts.Count; i++)
			{
				if (_volumeParts[i].Collider == collider)
				{
					_volumeParts.RemoveAt(i);
					break;
				}
			}
		}
	}
}
