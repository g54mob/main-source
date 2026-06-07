using System;
using System.Collections.Generic;
using Simulator;
using Simulator.GameWorld;
using Tabletop.GameWorld;

namespace Tabletop
{
	[Serializable]
	public class SaveClass_TabletopClients : ISaveClass
	{
		[Serializable]
		public class TabletopClientState : SaveClass_Clients.ClientState
		{
			public float paintingDuration;

			public float paintingMoneyProduced;

			public float timeSinceLastPaintingMoneyGeneration;

			public bool isPlayingWargame;

			public float wargameDuration;

			public float wargameMoneyProduced;

			public float timeSinceLastWargameMoneyGeneration;

			public TabletopClientState(AIClientBehaviour client, ClientCharacter character)
				: base(client, character)
			{
			}
		}

		public List<TabletopClientState> clients;

		public SaveClass_TabletopClients()
		{
			clients = new List<TabletopClientState>();
		}

		public void StartSaveProcess()
		{
			clients.Clear();
		}

		public void SaveClient(TabletopClientBehaviour client, ClientCharacter character)
		{
			clients.Add(client.GetSaveClientState() as TabletopClientState);
		}
	}
}
