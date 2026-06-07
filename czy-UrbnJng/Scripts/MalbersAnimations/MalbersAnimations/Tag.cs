using UnityEngine;

namespace MalbersAnimations
{
	[CreateAssetMenu(menuName = "Malbers Animations/Tag", fileName = "New Tag", order = 3000)]
	public class Tag : IDs
	{
		private void OnEnable()
		{
			ID = base.name.GetHashCode();
		}
	}
}
