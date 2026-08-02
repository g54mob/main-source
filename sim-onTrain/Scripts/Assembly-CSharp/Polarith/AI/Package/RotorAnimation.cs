using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Rotor Animation")]
	public sealed class RotorAnimation : MonoBehaviour
	{
		private Animator animator;

		private CopterPhysics physics;

		private void Start()
		{
			animator = GetComponent<Animator>();
			physics = GetComponent<CopterPhysics>();
		}

		private void Update()
		{
			if (animator != null && physics != null)
			{
				animator.SetFloat("Thrust", physics.Thrust);
				if (physics.Thrust >= 0f)
				{
					animator.speed = physics.Thrust;
				}
			}
		}
	}
}
