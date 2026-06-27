using System;
using System.Collections.Generic;
using Restory.Data.NPCs;
using Restory.Data.Visits;
using UnityEngine;
using UnityEngine.Pool;

namespace Restory.Gameplay.Visits
{
	public class VisitsQueueFiller
	{
		private VisitsScheduleSettings visitsScheduleSettings;

		public VisitsQueueFiller(VisitsScheduleSettings visitsScheduleSettings)
		{
			this.visitsScheduleSettings = visitsScheduleSettings;
		}

		public void FillQueueWithMorningAndAnyTimeVisits(IEnumerable<StoryNpcVisit> visits, List<NpcVisit> visitsQueueToFill)
		{
			List<StoryNpcVisit> list = CollectionPool<List<StoryNpcVisit>, StoryNpcVisit>.Get();
			List<StoryNpcVisit> list2 = CollectionPool<List<StoryNpcVisit>, StoryNpcVisit>.Get();
			List<StoryNpcVisit> list3 = CollectionPool<List<StoryNpcVisit>, StoryNpcVisit>.Get();
			List<StoryNpcVisit> list4 = CollectionPool<List<StoryNpcVisit>, StoryNpcVisit>.Get();
			List<NpcVisit> list5 = CollectionPool<List<NpcVisit>, NpcVisit>.Get();
			foreach (NpcVisit item in visitsQueueToFill)
			{
				if (!(item is WorkOrderClaimingNpcVisit) && !(item is FreeSaleClaimingNpcVisit))
				{
					Debug.LogError("Visits queue from morning has a visit of type [" + item.GetType().Name + "], which is not [WorkOrderClaimingNpcVisit]. That is currently not supported!");
				}
				else
				{
					list5.Add(item);
				}
			}
			visitsQueueToFill.Clear();
			foreach (StoryNpcVisit visit in visits)
			{
				if (visit == null)
				{
					continue;
				}
				switch (visit.IntendedTimeInterval)
				{
				case VisitTimeInterval.AnyTime:
					switch (visit.VisitType)
					{
					case StoryVisitType.Common:
						list4.Add(visit);
						break;
					case StoryVisitType.Urgent:
						list3.Add(visit);
						break;
					default:
						throw new NotImplementedException();
					}
					break;
				case VisitTimeInterval.Morning:
					switch (visit.VisitType)
					{
					case StoryVisitType.Common:
						list2.Add(visit);
						break;
					case StoryVisitType.Urgent:
						list.Add(visit);
						break;
					default:
						throw new NotImplementedException();
					}
					break;
				default:
					throw new NotImplementedException();
				case VisitTimeInterval.Evening:
					break;
				}
			}
			NpcVisitDayQueueParameters[] visitsOrder = visitsScheduleSettings.MorningSetupVisitsOrder.VisitsOrder;
			for (int i = 0; i < visitsOrder.Length; i++)
			{
				NpcVisitDayQueueParameters npcVisitDayQueueParameters = visitsOrder[i];
				if (npcVisitDayQueueParameters.AlreadyExistsInDayQueue)
				{
					if (!(npcVisitDayQueueParameters.VisitType is WorkOrderClaimingNpcVisit))
					{
						continue;
					}
					foreach (NpcVisit item2 in list5)
					{
						visitsQueueToFill.Add(item2);
					}
				}
				else
				{
					if (!(npcVisitDayQueueParameters.VisitType is StoryNpcVisit storyNpcVisit))
					{
						continue;
					}
					switch (npcVisitDayQueueParameters.Time)
					{
					case VisitTimeInterval.AnyTime:
						switch (storyNpcVisit.VisitType)
						{
						case StoryVisitType.Common:
							foreach (StoryNpcVisit item3 in list4)
							{
								visitsQueueToFill.Add(item3);
							}
							break;
						case StoryVisitType.Urgent:
							foreach (StoryNpcVisit item4 in list3)
							{
								visitsQueueToFill.Add(item4);
							}
							break;
						default:
							throw new NotImplementedException();
						}
						break;
					case VisitTimeInterval.Morning:
						switch (storyNpcVisit.VisitType)
						{
						case StoryVisitType.Common:
							foreach (StoryNpcVisit item5 in list2)
							{
								visitsQueueToFill.Add(item5);
							}
							break;
						case StoryVisitType.Urgent:
							foreach (StoryNpcVisit item6 in list)
							{
								visitsQueueToFill.Add(item6);
							}
							break;
						default:
							throw new NotImplementedException();
						}
						break;
					default:
						throw new NotImplementedException();
					case VisitTimeInterval.Evening:
						break;
					}
				}
			}
			CollectionPool<List<StoryNpcVisit>, StoryNpcVisit>.Release(list);
			CollectionPool<List<StoryNpcVisit>, StoryNpcVisit>.Release(list2);
			CollectionPool<List<StoryNpcVisit>, StoryNpcVisit>.Release(list3);
			CollectionPool<List<StoryNpcVisit>, StoryNpcVisit>.Release(list4);
			CollectionPool<List<NpcVisit>, NpcVisit>.Release(list5);
		}

		public void FillQueueWithEveningVisits(IEnumerable<NpcVisit> visits, List<NpcVisit> visitsQueueToModify)
		{
			List<StoryNpcVisit> list = CollectionPool<List<StoryNpcVisit>, StoryNpcVisit>.Get();
			List<StoryNpcVisit> list2 = CollectionPool<List<StoryNpcVisit>, StoryNpcVisit>.Get();
			List<NpcVisit> list3 = CollectionPool<List<NpcVisit>, NpcVisit>.Get();
			List<RandomNpcVisit> list4 = CollectionPool<List<RandomNpcVisit>, RandomNpcVisit>.Get();
			List<StoryNpcVisit> list5 = CollectionPool<List<StoryNpcVisit>, StoryNpcVisit>.Get();
			List<StoryNpcVisit> list6 = CollectionPool<List<StoryNpcVisit>, StoryNpcVisit>.Get();
			List<NpcVisit> list7 = CollectionPool<List<NpcVisit>, NpcVisit>.Get();
			foreach (NpcVisit item4 in visitsQueueToModify)
			{
				if (!(item4 is RandomNpcVisit item))
				{
					if (!(item4 is WorkOrderClaimingNpcVisit item2))
					{
						if (!(item4 is FreeSaleClaimingNpcVisit item3))
						{
							if (!(item4 is StoryNpcVisit { VisitType: var visitType } storyNpcVisit))
							{
								throw new NotImplementedException();
							}
							switch (visitType)
							{
							case StoryVisitType.Common:
								list2.Add(storyNpcVisit);
								break;
							case StoryVisitType.Urgent:
								list.Add(storyNpcVisit);
								break;
							default:
								throw new NotImplementedException();
							}
						}
						else
						{
							list3.Add(item3);
						}
					}
					else
					{
						list3.Add(item2);
					}
				}
				else
				{
					list4.Add(item);
				}
			}
			foreach (NpcVisit visit in visits)
			{
				if (visit is StoryNpcVisit { IntendedTimeInterval: VisitTimeInterval.Evening, VisitType: var visitType2 } storyNpcVisit2)
				{
					switch (visitType2)
					{
					case StoryVisitType.Common:
						list6.Add(storyNpcVisit2);
						break;
					case StoryVisitType.Urgent:
						list5.Add(storyNpcVisit2);
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}
			visitsQueueToModify.Clear();
			NpcVisitDayQueueParameters[] visitsOrder = visitsScheduleSettings.EveningSetupVisitsOrder.VisitsOrder;
			for (int i = 0; i < visitsOrder.Length; i++)
			{
				NpcVisitDayQueueParameters npcVisitDayQueueParameters = visitsOrder[i];
				if (npcVisitDayQueueParameters.AlreadyExistsInDayQueue)
				{
					NpcVisit visitType3 = npcVisitDayQueueParameters.VisitType;
					if (!(visitType3 is RandomNpcVisit))
					{
						if (!(visitType3 is StoryNpcVisit { VisitType: var visitType4 }))
						{
							if (visitType3 is WorkOrderClaimingNpcVisit || visitType3 is FreeSaleClaimingNpcVisit)
							{
								foreach (NpcVisit item5 in list3)
								{
									visitsQueueToModify.Add(item5);
								}
								continue;
							}
							throw new NotImplementedException();
						}
						switch (visitType4)
						{
						case StoryVisitType.Common:
							foreach (StoryNpcVisit item6 in list2)
							{
								visitsQueueToModify.Add(item6);
							}
							break;
						case StoryVisitType.Urgent:
							foreach (StoryNpcVisit item7 in list)
							{
								visitsQueueToModify.Add(item7);
							}
							break;
						default:
							throw new NotImplementedException();
						}
						continue;
					}
					foreach (RandomNpcVisit item8 in list4)
					{
						visitsQueueToModify.Add(item8);
					}
				}
				else
				{
					if (npcVisitDayQueueParameters.Time != VisitTimeInterval.Evening)
					{
						continue;
					}
					NpcVisit visitType3 = npcVisitDayQueueParameters.VisitType;
					if (visitType3 is RandomNpcVisit)
					{
						continue;
					}
					if (!(visitType3 is StoryNpcVisit { VisitType: var visitType5 }))
					{
						if (visitType3 is WorkOrderClaimingNpcVisit || visitType3 is FreeSaleClaimingNpcVisit)
						{
							foreach (NpcVisit item9 in list7)
							{
								visitsQueueToModify.Add(item9);
							}
							continue;
						}
						throw new NotImplementedException();
					}
					switch (visitType5)
					{
					case StoryVisitType.Common:
						foreach (StoryNpcVisit item10 in list6)
						{
							visitsQueueToModify.Add(item10);
						}
						break;
					case StoryVisitType.Urgent:
						foreach (StoryNpcVisit item11 in list5)
						{
							visitsQueueToModify.Add(item11);
						}
						break;
					default:
						throw new NotImplementedException();
					}
				}
			}
			CollectionPool<List<StoryNpcVisit>, StoryNpcVisit>.Release(list);
			CollectionPool<List<StoryNpcVisit>, StoryNpcVisit>.Release(list2);
			CollectionPool<List<NpcVisit>, NpcVisit>.Release(list3);
			CollectionPool<List<RandomNpcVisit>, RandomNpcVisit>.Release(list4);
			CollectionPool<List<StoryNpcVisit>, StoryNpcVisit>.Release(list5);
			CollectionPool<List<StoryNpcVisit>, StoryNpcVisit>.Release(list6);
			CollectionPool<List<NpcVisit>, NpcVisit>.Release(list7);
		}

		public void AddRandomVisitsToQueue(List<NpcVisit> visitsQueueToModify)
		{
			int count = visitsQueueToModify.Count;
			if (count < visitsScheduleSettings.MaxTotalVisitsPerDay)
			{
				int num = visitsScheduleSettings.MaxTotalVisitsPerDay - count;
				int num2 = UnityEngine.Random.Range(0, num + 1);
				for (int i = 0; i < num2; i++)
				{
					visitsQueueToModify.Add(new RandomNpcVisit());
				}
			}
		}
	}
}
