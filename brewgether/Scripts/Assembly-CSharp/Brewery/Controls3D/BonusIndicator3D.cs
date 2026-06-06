using UnityEngine;

namespace Brewery.Controls3D
{
	public class BonusIndicator3D : MonoBehaviour
	{
		[Tooltip("The checkmark visual child. Auto-detected from first child if not assigned.")]
		[SerializeField]
		private Transform tick;

		[Header("Animation")]
		[SerializeField]
		private TweenConfig showAnimation;

		[SerializeField]
		private TweenConfig hideAnimation;

		private Vector3 tickOriginalScale;

		private int tweenId;

		private bool isChecked;

		public bool IsChecked => false;

		private void Awake()
		{
		}

		public void SetChecked(bool active)
		{
		}

		public void Snap(bool active)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
