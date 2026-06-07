using DV.CabControls;
using DV.Interaction;
using UnityEngine;

namespace DV.Items
{
	public abstract class MagazineAmmo : MonoBehaviour
	{
		[SerializeField]
		private MagazineAmmoType ammoType;

		public bool isSpent;

		public MagazineAmmoType AmmoType => ammoType;

		public abstract ItemBase Item { get; protected set; }

		public abstract ItemUseTarget AmmoUseTarget { get; protected set; }
	}
}
