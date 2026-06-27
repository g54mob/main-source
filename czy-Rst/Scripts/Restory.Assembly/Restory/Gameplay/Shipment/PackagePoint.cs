using UnityEngine;

namespace Restory.Gameplay.Shipment
{
	public class PackagePoint : MonoBehaviour
	{
		private IShipmentPack package;

		public bool IsEmpty
		{
			get
			{
				if (package != null)
				{
					return package.Transform.parent != base.transform;
				}
				return true;
			}
		}

		public IShipmentPack Package => package;

		public void SetPackage(IShipmentPack package)
		{
			if (!IsEmpty)
			{
				Debug.LogError("Set package to not empty PackagePoint");
			}
			this.package = package;
			this.package.Transform.SetParent(base.transform);
			this.package.Transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
		}

		public bool TryToRemovePackage(IShipmentPack packageToRemove)
		{
			if (IsEmpty || packageToRemove != package)
			{
				return false;
			}
			package = null;
			return true;
		}
	}
}
