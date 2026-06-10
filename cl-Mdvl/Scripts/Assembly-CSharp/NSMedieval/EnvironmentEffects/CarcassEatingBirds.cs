using UnityEngine;

namespace NSMedieval.EnvironmentEffects
{
	public class CarcassEatingBirds : MonoBehaviour
	{
		private Animator anim;

		public void PickRandomAnimation()
		{
			if (!(anim == null))
			{
				int num = Random.Range(0, 100);
				int num2 = ((num < 30) ? ((num < 10) ? 1 : 0) : ((num >= 100) ? 1 : 2));
				int value = num2;
				anim.SetInteger("Rnd", value);
			}
		}

		public void Start()
		{
			if (TryGetComponent<Animator>(out var component))
			{
				anim = component;
			}
		}
	}
}
