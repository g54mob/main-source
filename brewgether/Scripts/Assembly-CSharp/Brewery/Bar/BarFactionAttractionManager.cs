using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Brewery.Data;
using PlacementSystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Bar
{
	[Obsolete("BarFactionAttractionManager is deprecated and will be reimplemented. All methods return 0/empty.")]
	[RequireComponent(typeof(NetworkObject))]
	public class BarFactionAttractionManager : NetworkBehaviour
	{
		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private static readonly Dictionary<string, float> emptyAttractionCache;

		public IReadOnlyDictionary<string, float> FactionAttractions => null;

		public event Action<Dictionary<string, float>> OnFactionAttractionChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public override void OnNetworkSpawn()
		{
		}

		public void OnDecorationPlaced(PlacedObject placedDecoration)
		{
		}

		public void OnDecorationRemoved(PlacedObject removedDecoration)
		{
		}

		public float GetFactionAttraction(FactionData faction)
		{
			return 0f;
		}

		public float GetFactionAttraction(string factionName)
		{
			return 0f;
		}

		[ContextMenu("Recalculate Faction Attraction (DEPRECATED)")]
		public void RecalculateFactionAttraction()
		{
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
