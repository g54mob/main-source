using Mirror;
using Polarith.AI.Move;
using UnityEngine;

namespace Polarith.AI.Package.Net
{
	[AddComponentMenu("Polarith AI » Examples/Network/AI Sync")]
	[RequireComponent(typeof(AIMContext))]
	public sealed class AISync : NetworkBehaviour
	{
		[Tooltip("A template for the agent entity (controller, visual representation, game logic) that is spawned on start.")]
		public GameObject Entity;

		private GameObject spawnedEntity;

		private void Start()
		{
			spawnedEntity = Object.Instantiate(Entity, base.transform.position, Quaternion.identity);
			NetworkServer.Spawn(spawnedEntity);
			AIMContext component = GetComponent<AIMContext>();
			PhysicsController2D component2 = spawnedEntity.GetComponent<PhysicsController2D>();
			component2.Context = component;
			component2.enabled = true;
		}

		private void Update()
		{
			if (base.isServer)
			{
				if (spawnedEntity == null)
				{
					Object.Destroy(base.gameObject);
				}
				else
				{
					base.transform.position = spawnedEntity.transform.position;
				}
			}
		}

		public override bool Weaved()
		{
			return true;
		}
	}
}
