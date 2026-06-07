using UnityEngine;

namespace GamingIsLove.Footsteps
{
	[AddComponentMenu("Footstepper/Footstep Trigger")]
	public class FootstepTrigger : MonoBehaviour
	{
		[Tooltip("The footstepper used to play footstep effects.")]
		public Footstepper footstepper;

		[Tooltip("The time in seconds between allowing 2 footsteps from this trigger.")]
		public float timeBetween = 0.1f;

		[Tooltip("Use the footstepper's raycast to determine the position and normal of the surface.\nOtherwise uses the position of this game object.")]
		public bool raycastPosition = true;

		[Tooltip("Limit the layers that can cause footsteps.")]
		[Space(10f)]
		public bool limitLayers;

		[Tooltip("Select the layers that can cause footsteps (only used when 'Limit Layers' is enabled).")]
		public LayerMask layerMask = -1;

		private float timeout;

		protected virtual void Start()
		{
			if (footstepper == null)
			{
				base.enabled = false;
			}
		}

		protected virtual void Update()
		{
			if (timeBetween > 0f)
			{
				timeout -= Time.deltaTime;
			}
		}

		protected virtual bool CheckLayer(GameObject gameObject)
		{
			if (limitLayers)
			{
				return (layerMask.value & (1 << gameObject.layer)) != 0;
			}
			return true;
		}

		protected virtual void OnTriggerEnter(Collider other)
		{
			if (timeout <= 0f && CheckLayer(other.gameObject))
			{
				FootstepSource componentInParent = other.gameObject.GetComponentInParent<FootstepSource>();
				if (componentInParent != null)
				{
					timeout = timeBetween;
					footstepper.PlayFootstep(base.transform, componentInParent, raycastPosition);
				}
			}
		}

		protected virtual void OnTriggerEnter2D(Collider2D other)
		{
			if (timeout <= 0f && CheckLayer(other.gameObject))
			{
				FootstepSource componentInParent = other.gameObject.GetComponentInParent<FootstepSource>();
				if (componentInParent != null)
				{
					timeout = timeBetween;
					footstepper.PlayFootstep(base.transform, componentInParent, raycastPosition);
				}
			}
		}

		protected virtual void OnDrawGizmos()
		{
			Gizmos.DrawIcon(base.transform.position, "/GamingIsLove/Footsteps/FootstepTrigger Icon.png");
		}
	}
}
