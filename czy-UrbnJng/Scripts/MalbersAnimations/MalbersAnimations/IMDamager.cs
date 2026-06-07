using UnityEngine;

namespace MalbersAnimations
{
	public interface IMDamager : IMLayer
	{
		int Index { get; }

		bool Enabled { get; set; }

		GameObject Owner { get; set; }

		void DoDamage(bool value, int profile);
	}
}
