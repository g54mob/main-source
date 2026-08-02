using System.Collections.Generic;
using Polarith.AI.Move;
using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Environment Updater")]
	public sealed class EnvironmentUpdater : MonoBehaviour
	{
		[Tooltip("All children of these objects are added to the specified 'TargetEnvironment'.")]
		public List<GameObject> GameObjectCollections = new List<GameObject>();

		[Tooltip("The AIMEnvironment.GameObjects of this environment are updated via this component.")]
		public AIMEnvironment TargetEnvironment;

		[Tooltip("If <c>true</c>, the objects are refreshed on every update step.")]
		public bool IsDynamic;

		private void Start()
		{
			if (!IsDynamic)
			{
				ProcessObjects();
				base.enabled = false;
			}
			Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.AddListener(AddPlayerToList);
		}

		private void AddPlayerToList(TSPlayerController tsPlayer)
		{
			GameObjectCollections.Add(tsPlayer.gameObject);
			TargetEnvironment.GameObjects.Add(tsPlayer.gameObject);
		}

		private void ProcessObjects()
		{
		}
	}
}
