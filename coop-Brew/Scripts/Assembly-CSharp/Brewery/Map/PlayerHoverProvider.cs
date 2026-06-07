using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Map
{
	[RequireComponent(typeof(NetworkObject))]
	public class PlayerHoverProvider : NetworkBehaviour, IMapIconHoverProvider
	{
		private NetworkVariable<FixedString64Bytes> syncedPlayerName;

		public string GetHoverTitle()
		{
			return null;
		}

		public string GetHoverSubtitle()
		{
			return null;
		}

		public List<HoverInfoSection> GetHoverSections()
		{
			return null;
		}

		public bool ShouldShowHover()
		{
			return false;
		}

		public override void OnNetworkSpawn()
		{
		}

		private string GetPlayerName()
		{
			return null;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
