using UnityEngine;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/Particles/MMDelayParticles")]
	[ExecuteAlways]
	public class MMDelayParticles : MonoBehaviour
	{
		[Header("Delay")]
		public float Delay;

		public bool DelayChildren;

		public bool ApplyDelayOnStart;

		[MMInspectorButton("ApplyDelay")]
		public bool ApplyDelayButton;

		protected Component[] particleSystems;

		protected virtual void Start()
		{
		}

		protected virtual void ApplyDelay()
		{
		}
	}
}
