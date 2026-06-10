using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Animation
{
	public class OverrideBoneAnimation : MonoBehaviour
	{
		[SerializeField]
		private Transform boneToOverride;

		[SerializeField]
		private Transform overridePosition;

		private bool overrideAnimationActive;

		public Transform OverridePosition
		{
			set
			{
				overridePosition = value;
			}
		}

		public void StartOverrideAnimation()
		{
			overrideAnimationActive = true;
		}

		public void EndOverrideAnimation()
		{
			overrideAnimationActive = false;
		}

		private void OverrideAnimationUpdate(float dt)
		{
			if (!(boneToOverride == null) && !(overridePosition == null) && overrideAnimationActive)
			{
				boneToOverride.position = overridePosition.position;
			}
		}

		private void OnEnable()
		{
			MonoSingleton<SceneController>.Instance.LateTick += OverrideAnimationUpdate;
		}

		public void OnDisable()
		{
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.LateTick -= OverrideAnimationUpdate;
			}
		}
	}
}
