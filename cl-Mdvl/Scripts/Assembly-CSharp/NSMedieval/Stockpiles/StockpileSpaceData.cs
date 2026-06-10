using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Utils.Pool;
using UnityEngine;

namespace NSMedieval.Stockpiles
{
	[FVSerializableKey("StockpileSpaceData", "")]
	public class StockpileSpaceData : IFVSerializable
	{
		[SerializeField]
		private readonly Vec3Int position;

		private ResourcePileInstance pile;

		private List<StockpileReservationInfo> reservationInfos;

		public ResourcePileInstance Pile => pile;

		public Vec3Int Position => position;

		public List<StockpileReservationInfo> ReservationInfos => reservationInfos;

		public StockpileSpaceData(Vec3Int position)
		{
			this.position = position;
		}

		public StockpileSpaceData()
		{
		}

		public StockpileSpaceData(Vec3Int position, ResourcePileInstance pile)
		{
			this.pile = pile;
			this.position = position;
		}

		public void ClearReservations()
		{
			reservationInfos.Clear();
			ListPool<StockpileReservationInfo>.Return(reservationInfos);
			reservationInfos = null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReleaseReservation(CreatureBase creatureBase)
		{
			if (reservationInfos == null || reservationInfos.All((StockpileReservationInfo item) => item.Agent != creatureBase))
			{
				return;
			}
			if (reservationInfos.Count == 1)
			{
				ClearReservations();
				return;
			}
			reservationInfos.RemoveWhere((StockpileReservationInfo item) => item.Agent == creatureBase);
		}

		public bool HasAnyReservations()
		{
			if (reservationInfos != null)
			{
				return reservationInfos.Count > 0;
			}
			return false;
		}

		public StockpileReservationInfo GetReservationInfo(CreatureBase reserver)
		{
			if (reservationInfos == null)
			{
				return default(StockpileReservationInfo);
			}
			return reservationInfos.FirstOrDefault((StockpileReservationInfo item) => item.Agent == reserver);
		}

		public int GetTotalReservedResourceCount()
		{
			if (reservationInfos == null)
			{
				return 0;
			}
			int num = 0;
			foreach (StockpileReservationInfo reservationInfo in reservationInfos)
			{
				num += reservationInfo.Amount;
			}
			return num;
		}

		public void Reserve(StockpileReservationInfo info)
		{
			if (Pile != null && info.Blueprint != Pile.Blueprint)
			{
				Log.Error("info.Blueprint != this.Pile.Blueprint this should never happen", "C:\\GIT\\dev\\Assets\\Scripts\\Stockpile\\StockpileSpaceData.cs");
				return;
			}
			if (reservationInfos == null)
			{
				reservationInfos = ListPool<StockpileReservationInfo>.Get();
			}
			int num = reservationInfos.FindIndex((StockpileReservationInfo item) => item.Agent == info.Agent);
			if (num > 0)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(103, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Stockpile\\StockpileSpaceData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Tried to reserve same stockpile place:");
					messageBuilder.AppendFormatted(position);
					messageBuilder.AppendLiteral(" more then once by the same agent: ");
					messageBuilder.AppendFormatted(info.Agent);
					messageBuilder.AppendLiteral(". Replacing old reservation...");
				}
				Log.Warning(messageBuilder);
				reservationInfos[num] = info;
			}
			else
			{
				reservationInfos.Add(info);
			}
		}

		public void SetPile(ResourcePileInstance pile)
		{
			this.pile = pile;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("position", position);
		}

		public StockpileSpaceData(FVDeserializer deserializer)
		{
			position = deserializer.ReadVec3Int("position");
		}
	}
}
