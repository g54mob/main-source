using UnityEngine;

namespace MalbersAnimations.Weapons
{
	public interface IShootableWeapon : IMWeapon, IMDamager, IMLayer, IObjectCore
	{
		GameObject Projectile { get; set; }

		bool IsReloading { get; set; }

		int TotalAmmo { get; set; }

		int AmmoInChamber { get; set; }

		int ChamberSize { get; set; }
	}
}
