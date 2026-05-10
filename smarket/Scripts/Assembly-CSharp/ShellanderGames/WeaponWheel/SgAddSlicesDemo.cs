using UnityEngine;

namespace ShellanderGames.WeaponWheel
{
	public class SgAddSlicesDemo : MonoBehaviour
	{
		[Tooltip("Weapon wheel to update")]
		public SgWeaponWheel weaponWheel;

		[Tooltip("Slices to populate the weapon wheel with")]
		public SgSliceController[] sliceContents;

		[Tooltip("Delay between updates")]
		public float delay;

		private float m_ScheduledDelay;

		private int m_CurrentIndex;

		private int m_ChangeDirection;

		private void Start()
		{
		}

		private void FixedUpdate()
		{
		}
	}
}
