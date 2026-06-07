using UnityEngine;
using UnityEngine.Events;

namespace CraftingAnims
{
	public class CrafterAnimatorController : MonoBehaviour
	{
		public UnityEvent OnFootR;

		public UnityEvent OnFootL;

		public UnityEvent OnStrike;

		public CrafterController crafterController;

		private Animator animator;

		private void Awake()
		{
		}

		public void FootR()
		{
		}

		public void FootL()
		{
		}

		public void Strike()
		{
		}

		private void OnAnimatorMove()
		{
		}
	}
}
