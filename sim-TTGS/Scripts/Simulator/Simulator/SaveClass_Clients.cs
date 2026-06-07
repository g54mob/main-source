using System;
using System.Collections.Generic;
using Simulator.GameWorld;
using UnityEngine;

namespace Simulator
{
	[Serializable]
	public class SaveClass_Clients : ISaveClass
	{
		[Serializable]
		public class ClientState : AISaveState
		{
			public bool insideShop;

			public EClientState clientState;

			public int maxProductToBuy;

			public float maxMoneyToSpend;

			public List<Vector2Int> visitedStands;

			public List<BoughtProductInfo> shoppingBagContent;

			public Vector3 shoppingBagPosition;

			public Quaternion shoppingBagRotation;

			public int currentBuyIterationLeft;

			public ClientState(AIClientBehaviour client, ClientCharacter character)
				: base(client, character)
			{
				insideShop = client.InsideShop;
				clientState = client.ClientState;
				maxProductToBuy = client.MaxProductToBuy;
				maxMoneyToSpend = client.MaxMoneyToSpend;
				shoppingBagContent = new List<BoughtProductInfo>();
				if (client.ClientState != EClientState.CHECKING_OUT)
				{
					foreach (Product item in character.ShoppingBag.GetContent())
					{
						shoppingBagContent.Add(item.GetBoughtProductInfo());
					}
				}
				shoppingBagPosition = character.ShoppingBag.transform.position;
				shoppingBagRotation = character.ShoppingBag.transform.rotation;
			}
		}

		public bool enableSpawn;

		public int spawnScore;

		public float spawnScoreFloat;

		public List<ClientState> clients;

		public SaveClass_Clients()
		{
			enableSpawn = false;
			spawnScore = 0;
			clients = new List<ClientState>();
		}

		public void StartSaveProcess()
		{
			clients = new List<ClientState>();
		}

		public void SaveClient(AIClientBehaviour client, ClientCharacter character)
		{
			clients.Add(client.GetSaveClientState());
		}
	}
}
