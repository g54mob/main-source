using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	[CreateAssetMenu(fileName = "PartStateColors", menuName = "SimpleRockets 2/Parts/Part State Colors")]
	public class PartStateColors : ScriptableObject, IPartStateColors
	{
		[SerializeField]
		private Color _attached;

		[SerializeField]
		private Color _colliding;

		[SerializeField]
		private Color _disconnectedPrimary;

		[SerializeField]
		private Color _disconnectedSecondary;

		[SerializeField]
		private Color _highlighted;

		[SerializeField]
		private Color _selected;

		public Color Attached => _attached;

		public Color Colliding => _colliding;

		public Color DisconnectedPrimary => _disconnectedPrimary;

		public Color DisconnectedSecondary => _disconnectedSecondary;

		public Color Highlighted => _highlighted;

		public Color Selected => _selected;
	}
}
