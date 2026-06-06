using UnityEngine;

namespace MalbersAnimations.Weapons
{
	public interface IMWeaponOwner
	{
		Animator Anim { get; }

		bool Aim { get; }

		bool IsRiding { get; }

		bool IsReloading { get; }

		bool IsAttacking { get; }

		bool DrawWeapon { get; }

		bool StoreWeapon { get; }

		bool HasAnimal { get; }

		float HorizontalAngle { get; }

		IAim Aimer { get; }

		Vector3 AimDirection { get; }

		bool AimingSide { get; }

		float IKAimWeight { get; set; }

		GameObject Owner { get; }

		MWeapon Weapon { get; }

		Transform RightHand { get; }

		Transform LeftHand { get; }

		Transform IgnoreTransform { get; set; }

		void Aim_Set(bool value);

		void UnEquip();
	}
}
