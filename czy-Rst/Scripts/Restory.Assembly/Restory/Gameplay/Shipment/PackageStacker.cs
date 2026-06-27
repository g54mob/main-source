using System.Collections.Generic;
using Restory.Gameplay.Effects;
using Restory.Gameplay.Tooltips;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Shipment
{
	public class PackageStacker : MonoBehaviour, IInitializable
	{
		[SerializeField]
		private TooltipIndicator tooltipIndicator;

		[SerializeField]
		private List<PackageStack> packageStacks;

		private VfxService vfxService;

		private List<PackagePoint> packagePointSequence;

		public List<IShipmentPack> Packages
		{
			get
			{
				List<IShipmentPack> list = new List<IShipmentPack>();
				foreach (PackagePoint item in packagePointSequence)
				{
					if (!item.IsEmpty)
					{
						list.Add(item.Package);
					}
				}
				return list;
			}
		}

		[Inject]
		private void Construct(VfxService vfxService)
		{
			this.vfxService = vfxService;
		}

		public void Initialize()
		{
			InitPackagePointSequence();
		}

		public bool HasAvailablePlace(out PackagePoint availablePoint)
		{
			availablePoint = null;
			foreach (PackagePoint item in packagePointSequence)
			{
				if (item.IsEmpty)
				{
					availablePoint = item;
					return true;
				}
			}
			return false;
		}

		public void RemovePackageFromStack(IShipmentPack package)
		{
			foreach (PackagePoint item in packagePointSequence)
			{
				if (item.TryToRemovePackage(package))
				{
					return;
				}
			}
			Debug.LogError("Failed to find package in stack to remove");
		}

		public void UpdateStacks()
		{
			foreach (PackageStack packageStack in packageStacks)
			{
				UpdateStack(packageStack);
			}
		}

		public void ToggleIndicator(bool isActive)
		{
			tooltipIndicator.gameObject.SetActive(isActive);
		}

		private void InitPackagePointSequence()
		{
			int num = 0;
			foreach (PackageStack packageStack in packageStacks)
			{
				if (packageStack.PackagePoints.Count > num)
				{
					num = packageStack.PackagePoints.Count;
				}
			}
			packagePointSequence = new List<PackagePoint>();
			for (int i = 0; i < num; i++)
			{
				foreach (PackageStack packageStack2 in packageStacks)
				{
					if (i < packageStack2.PackagePoints.Count)
					{
						packagePointSequence.Add(packageStack2.PackagePoints[i]);
					}
				}
			}
		}

		private void UpdateStack(PackageStack stack)
		{
			PackagePoint packagePoint = null;
			int num = 0;
			for (int i = 0; i < stack.PackagePoints.Count; i++)
			{
				PackagePoint packagePoint2 = stack.PackagePoints[i];
				if (packagePoint2.IsEmpty)
				{
					num++;
				}
				else
				{
					if (num == 0)
					{
						continue;
					}
					IShipmentPack package = packagePoint2.Package;
					if (!packagePoint2.TryToRemovePackage(package))
					{
						Debug.LogError("Failed to remove replacingPackage from packagePoint");
						num = 0;
						continue;
					}
					PackagePoint packagePoint3 = stack.PackagePoints[i - num];
					packagePoint3.SetPackage(package);
					if (!packagePoint)
					{
						packagePoint = packagePoint3;
					}
				}
			}
			if ((bool)packagePoint)
			{
				vfxService.PlayPlacementEffect(packagePoint.transform);
			}
		}
	}
}
