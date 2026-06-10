using NSEipix.Base;
using NSMedieval.EnvironmentEffects;
using UnityEngine;

namespace NSMedieval.Views.Resources
{
	public class ResourceDestroy : MonoBehaviour
	{
		[SerializeField]
		private GameObject mainGO;

		public void AnimationFinishResourceDestroy()
		{
			Object.Destroy(mainGO);
		}

		public void FireTreeParticles()
		{
			if (!(mainGO == null))
			{
				mainGO.GetComponent<TreeView>()?.FireTreeParticles();
			}
		}

		public void FireTreeFallParticles()
		{
			if (!(mainGO == null))
			{
				mainGO.GetComponent<TreeView>()?.FireTreeFallParticles();
			}
		}

		public void TreeFallCameraShake()
		{
			if (mainGO.transform.localScale.y > 1f)
			{
				MonoSingleton<CameraManager>.Instance.OnCameraShakeEvent(base.transform.position, CameraShakeStrength.Mild);
			}
		}

		public void RemoveParentTreeFallParticles()
		{
			if (!(mainGO == null))
			{
				mainGO.GetComponent<TreeView>()?.RemoveParentTreeFallParticles();
			}
		}
	}
}
