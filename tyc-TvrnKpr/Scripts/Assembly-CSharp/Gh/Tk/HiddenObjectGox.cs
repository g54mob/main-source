using UnityEngine;

namespace Gh.Tk
{
	public class HiddenObjectGox : GameObjectX
	{
		[PersistenceOptIn]
		public string storyFlag;

		public Transform onClickParticle;

		public Transform modelPart;

		public string foundSoundEvent;

		public override void Awake()
		{
		}

		private void OnClicked()
		{
		}

		private void EnableParticleEffect()
		{
		}
	}
}
