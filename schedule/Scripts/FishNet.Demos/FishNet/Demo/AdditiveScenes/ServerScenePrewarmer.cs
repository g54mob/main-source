using FishNet.Object;
using GameKit.Utilities.Types;
using UnityEngine;

namespace FishNet.Demo.AdditiveScenes
{
	public class ServerScenePrewarmer : NetworkBehaviour
	{
		[SerializeField]
		[Scene]
		private string[] _scenes;

		private bool NetworkInitialize___EarlyFishNet_002EDemo_002EAdditiveScenes_002EServerScenePrewarmerFishNet_002EDemos_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EDemo_002EAdditiveScenes_002EServerScenePrewarmerFishNet_002EDemos_002Edll_Excuted;

		public override void OnStartServer()
		{
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
