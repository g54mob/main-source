using FishNet.Object;
using UnityEngine;

namespace FishNet.Demo.AdditiveScenes
{
	public class LevelLoader : NetworkBehaviour
	{
		private bool NetworkInitialize___EarlyFishNet_002EDemo_002EAdditiveScenes_002ELevelLoaderFishNet_002EDemos_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EDemo_002EAdditiveScenes_002ELevelLoaderFishNet_002EDemos_002Edll_Excuted;

		private void OnTriggerEnter(Collider other)
		{
		}

		private void OnTriggerExit(Collider other)
		{
		}

		private Player GetPlayerOwnedObject(Collider other)
		{
			return null;
		}

		public virtual void NetworkInitialize___Early()
		{
		}

		public virtual void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		public virtual void Awake()
		{
		}
	}
}
