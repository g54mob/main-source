using Assets.Nimbatus.Scripts.Combat;
using Assets.Nimbatus.Scripts.Tutorial.TutorialScenes;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.InteractiveObjects
{
	public class ItemCollector : MonoBehaviour
	{
		public NimbatusParticleEffect CollectParticleEffect;

		public void OnTriggerEnter(Collider other)
		{
			InteractiveWorldObject component = other.gameObject.GetComponent<InteractiveWorldObject>();
			component = component ?? other.attachedRigidbody.gameObject.GetComponent<InteractiveWorldObject>();
			if (!(component != null) || !component.IsCollectable)
			{
				return;
			}
			component.Collect();
			CollectParticleEffect.PlayEffect(other.gameObject.transform.position, Quaternion.identity);
			if (GenericTutorialLogic.Instance != null)
			{
				TutorialMagnetLogic tutorialMagnetLogic = GenericTutorialLogic.Instance as TutorialMagnetLogic;
				if (tutorialMagnetLogic != null)
				{
					tutorialMagnetLogic.collectedObjects++;
				}
			}
		}
	}
}
