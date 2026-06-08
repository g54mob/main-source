using JetBrains.Annotations;
using UnityEngine;

namespace Kitchen
{
	public class AnimatedGenericObjectView : GenericObjectView
	{
		[SerializeField]
		private Animator Animator;

		private bool MarkedForRemoval;

		public override void Remove()
		{
			if (Animator != null)
			{
				Animator.Play("Remove");
			}
		}

		[UsedImplicitly]
		public void RemoveAnimationComplete()
		{
			MarkedForRemoval = true;
		}

		private void Update()
		{
			if (MarkedForRemoval)
			{
				base.Remove();
			}
		}
	}
}
