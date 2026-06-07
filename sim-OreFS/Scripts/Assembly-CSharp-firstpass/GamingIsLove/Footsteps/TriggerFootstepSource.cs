using System.Collections.Generic;
using UnityEngine;

namespace GamingIsLove.Footsteps
{
	[AddComponentMenu("Footstepper/Trigger Footstep Source")]
	public class TriggerFootstepSource : FootstepSource
	{
		[Tooltip("The footstep material defines the footstep effects (audio clips and prefabs) of this trigger.")]
		public FootstepMaterial material;

		protected List<Footstepper> inTrigger = new List<Footstepper>();

		public override FootstepEffect GetFootstepAt(Vector3 position, string effectTag)
		{
			if (material != null)
			{
				return material.GetEffect(effectTag);
			}
			return null;
		}

		protected virtual void OnTriggerEnter(Collider other)
		{
			Footstepper component = other.transform.GetComponent<Footstepper>();
			if (component != null)
			{
				component.AddOverrideSource(this);
				inTrigger.Add(component);
			}
		}

		protected virtual void OnTriggerExit(Collider other)
		{
			Footstepper component = other.transform.GetComponent<Footstepper>();
			if (component != null)
			{
				component.RemoveOverrideSource(this);
				inTrigger.Remove(component);
			}
		}

		protected virtual void OnTriggerEnter2D(Collider2D other)
		{
			Footstepper component = other.transform.GetComponent<Footstepper>();
			if (component != null)
			{
				component.AddOverrideSource(this);
				inTrigger.Add(component);
			}
		}

		protected virtual void OnTriggerExit2D(Collider2D other)
		{
			Footstepper component = other.transform.GetComponent<Footstepper>();
			if (component != null)
			{
				component.RemoveOverrideSource(this);
				inTrigger.Remove(component);
			}
		}

		protected virtual void OnDisable()
		{
			for (int i = 0; i < inTrigger.Count; i++)
			{
				if (inTrigger[i] != null)
				{
					inTrigger[i].RemoveOverrideSource(this);
				}
			}
			inTrigger.Clear();
		}

		protected virtual void OnDrawGizmos()
		{
			Gizmos.DrawIcon(base.transform.position, "/GamingIsLove/Footsteps/TriggerFootstepSource Icon.png");
		}
	}
}
