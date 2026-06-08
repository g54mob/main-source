using System.Collections.Generic;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateBefore(typeof(CreateNewKitchen))]
	[UpdateInGroup(typeof(ChangeModeGroup))]
	public class ProvideStartingEnvelopes : RestaurantSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct SProvided : IComponentData
		{
		}

		protected override void OnUpdate()
		{
			if (HasSingleton<SProvided>() || !Has<SLayout>())
			{
				return;
			}
			base.World.Add<SProvided>();
			if (GetOrCreate<SPlayerLevel>().Level >= 1)
			{
				List<Vector3> postTiles = GetPostTiles();
				int placed_tile = 0;
				if (!FindTile(ref placed_tile, postTiles, out var candidate))
				{
					candidate = GetFallbackTile();
				}
				if (Preferences.Get<bool>(Pref.ProvideStartingEnvelopesAsParcels))
				{
					PostHelpers.CreateApplianceParcel(base.EntityManager, candidate, AssetReference.BookingDesk);
				}
				else
				{
					PostHelpers.CreateBlueprintLetter(base.EntityManager, candidate, AssetReference.BookingDesk, 0f);
				}
			}
		}

		public bool FindTile(ref int placed_tile, List<Vector3> floor_tiles, out Vector3 candidate)
		{
			candidate = Vector3.zero;
			bool flag = false;
			while (!flag && placed_tile < floor_tiles.Count)
			{
				candidate = floor_tiles[placed_tile++];
				if (base.TileManager.GetOccupant(candidate) == default(Entity))
				{
					flag = true;
				}
			}
			if (!flag)
			{
				return false;
			}
			return true;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
