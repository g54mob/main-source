using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Production;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	public class NeedResource
	{
		[SerializeField]
		private string resource;

		[SerializeField]
		private int amount;

		[SerializeField]
		private string inRoom;

		[SerializeField]
		private bool isPlant;

		[SerializeField]
		private int plantPhase;

		public string Resource => resource;

		public int Amount => amount;

		public string InRoom => inRoom;

		public static bool CheckNeededResources(NeedResource[] needResources)
		{
			using (ProfilerSampleJanitor.Begin("NeedResource.CheckNeededResources"))
			{
				foreach (NeedResource needResource in needResources)
				{
					if (needResource.isPlant)
					{
						if (string.IsNullOrEmpty(needResource.inRoom) && MonoSingleton<PlantResourceManager>.Instance.GetPlantCount(needResource.resource) < needResource.amount)
						{
							return false;
						}
						int num = 0;
						RoomType byID = Repository<RoomTypeRepository, RoomType>.Instance.GetByID(needResource.inRoom);
						foreach (PlantMapResourceInstance item in MonoSingleton<PlantResourceManager>.Instance.IteratePlants(needResource.resource, needResource.plantPhase))
						{
							Room room = item.GetRoom();
							if (room != null && room.RoomType == byID)
							{
								num++;
								if (num >= needResource.amount)
								{
									break;
								}
							}
						}
						if (num < needResource.amount)
						{
							return false;
						}
						continue;
					}
					ISet<ResourcePileInstance> pilesByResourceId = MonoSingleton<ResourcePileTracker>.Instance.GetPilesByResourceId(needResource.Resource);
					if (pilesByResourceId == null)
					{
						continue;
					}
					bool isEnabled;
					if (pilesByResourceId.Count < needResource.Amount)
					{
						FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(88, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\NeedResource.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("CheckNeededResources returning false - amount ");
							messageBuilder.AppendFormatted(pilesByResourceId.Count);
							messageBuilder.AppendLiteral(" is smaller than min amount ");
							messageBuilder.AppendFormatted(needResource.Amount);
							messageBuilder.AppendLiteral(" for resource ");
							messageBuilder.AppendFormatted(needResource.Resource);
						}
						Log.Debug(messageBuilder);
						return false;
					}
					if (string.IsNullOrEmpty(needResource.InRoom))
					{
						continue;
					}
					bool flag = false;
					foreach (ResourcePileInstance item2 in pilesByResourceId)
					{
						Room room2 = item2.GetRoom();
						if (room2 != null && room2.RoomType != null && room2.RoomType.GetID() == needResource.InRoom)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(66, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\NeedResource.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("CheckNeededResources returning false - no resource ");
							messageBuilder.AppendFormatted(needResource.Resource);
							messageBuilder.AppendLiteral(" found in room ");
							messageBuilder.AppendFormatted(needResource.InRoom);
						}
						Log.Debug(messageBuilder);
						return false;
					}
				}
				return true;
			}
		}

		public override string ToString()
		{
			return $"{resource}, amount: {amount}, room: {inRoom}";
		}
	}
}
