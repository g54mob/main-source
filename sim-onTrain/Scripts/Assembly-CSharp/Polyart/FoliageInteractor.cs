using UnityEngine;

namespace Polyart
{
	public class FoliageInteractor : MonoBehaviour
	{
		[Range(0f, 10f)]
		public float interactRadius = 2f;

		[Range(0f, 200f)]
		public float interactStrength = 10f;

		private void Update()
		{
			Shader.SetGlobalFloat("_InteractionStrength", interactStrength);
			Shader.SetGlobalFloat("_InteractionRadius", interactRadius);
			Shader.SetGlobalVector("_ActorPosition", base.transform.position);
		}
	}
}
