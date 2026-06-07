using System;
using UnityEngine;

namespace MalbersAnimations
{
	public interface IRider
	{
		bool IsRiding { get; }

		bool Mounted { get; }

		bool IsOnHorse { get; }

		bool CanMount { get; }

		bool CanDismount { get; }

		bool IsMounting { get; }

		bool IsDismounting { get; }

		bool IsAiming { get; set; }

		Action<RiderAction> RiderStatus { get; set; }

		GameObject Mount { get; }

		void ReinRightHand(bool value);

		void ReinLeftHand(bool value);
	}
}
