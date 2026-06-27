using System.Collections.Generic;
using UnityEngine;

namespace Restory.Gameplay.Shipment
{
	public class PackageStack : MonoBehaviour
	{
		[SerializeField]
		private List<PackagePoint> packagePoints;

		public IReadOnlyList<PackagePoint> PackagePoints => packagePoints;
	}
}
