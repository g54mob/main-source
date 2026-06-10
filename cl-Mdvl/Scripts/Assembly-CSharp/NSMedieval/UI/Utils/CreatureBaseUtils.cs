using System;
using System.Collections.Generic;
using System.Globalization;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Utils.Pool;

namespace NSMedieval.UI.Utils
{
	public class CreatureBaseUtils
	{
		public static void GenerateProximitySphere(int radius, bool checkSurfaceOnly, out int[] pointsX, out int[] pointsY, out int[] pointsZ)
		{
			List<int> list = ListPool<int>.Get();
			List<int> list2 = ListPool<int>.Get();
			List<int> list3 = ListPool<int>.Get();
			int num = radius * radius;
			int num2 = (radius - 1) * (radius - 1);
			for (int i = -radius; i <= radius; i++)
			{
				for (int j = -radius / 3; j <= radius / 3; j++)
				{
					for (int k = -radius; k <= radius; k++)
					{
						if (i != 0 || j != 0 || k != 0)
						{
							int num3 = i * i + j * j * 9 + k * k;
							if (num3 <= num && (!checkSurfaceOnly || num3 >= num2))
							{
								list.Add(i);
								list2.Add(j);
								list3.Add(k);
							}
						}
					}
				}
			}
			pointsX = list.ToArray();
			pointsY = list2.ToArray();
			pointsZ = list3.ToArray();
			ListPool<int>.Return(list);
			ListPool<int>.Return(list2);
			ListPool<int>.Return(list3);
		}

		public static string GetLocalizedCurrentActionInfo(CreatureBase creatureBase)
		{
			if (creatureBase is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
			{
				if (MonoSingleton<CaravanManager>.Instance.IsWorkerInCaravan(humanoidInstance))
				{
					return UiUtils.Localize.GetText("worker_action_incaravan", humanoidInstance);
				}
				if (humanoidInstance.WorkerBehaviour.IsDrafting)
				{
					return UiUtils.Localize.GetText("worker_action_drafted", humanoidInstance);
				}
				if (humanoidInstance.WorkerBehaviour.IsCrazy)
				{
					return UiUtils.Localize.GetText("hour_type_psychotic_name", humanoidInstance);
				}
			}
			if (creatureBase is AnimalInstance animalInstance)
			{
				return UiUtils.Localize.GetText("worker_action_" + GetGoalName(creatureBase).ToLower(CultureInfo.InvariantCulture), animalInstance.Gender);
			}
			return UiUtils.Localize.GetText("worker_action_" + GetGoalName(creatureBase).ToLower(CultureInfo.InvariantCulture), creatureBase.GetInfo().BodyType);
		}

		public static string GetGoalName(CreatureBase creatureBase)
		{
			string text = creatureBase.GetGoapAgent()?.CurrentGoalName;
			if (string.IsNullOrEmpty(text))
			{
				text = "IdleGoal";
			}
			return text;
		}

		public static string GetCreatureLink(CreatureBase creatureBase, bool isFullName = false)
		{
			if (!(creatureBase is HumanoidInstance humanoidInstance))
			{
				if (creatureBase is AnimalInstance animalInstance)
				{
					return UiUtils.GetAnimalLink(animalInstance, AnimalUtils.GetAnimalName(animalInstance, isFullName));
				}
				return UiUtils.GetCreatureLink(creatureBase);
			}
			return (humanoidInstance.WorkerBehaviour != null) ? UiUtils.GetWorkerLink(humanoidInstance, isFullName ? humanoidInstance.GetFullName() : humanoidInstance.Info.FirstName) : UiUtils.GetNPCLink(humanoidInstance, UiUtils.GetNPCName(humanoidInstance, isFullName));
		}

		public static string GetCreatureName(CreatureBase attacker, bool isFullName = false)
		{
			if (!(attacker is AnimalInstance animalInstance))
			{
				if (attacker is HumanoidInstance humanoidInstance)
				{
					return isFullName ? humanoidInstance.Info.GetFullName() : humanoidInstance.Info.FirstName;
				}
				throw new ArgumentOutOfRangeException("attacker", attacker, null);
			}
			return AnimalUtils.GetAnimalName(animalInstance, isFullName);
		}
	}
}
