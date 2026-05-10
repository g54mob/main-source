using TMPro;
using UnityEngine;

namespace ShellanderGames.WeaponWheel
{
	public class SgWeaponInfoDemo : MonoBehaviour
	{
		public GameObject content;

		public TextMeshProUGUI textComponent;

		public SgWeaponWheel weaponWheel;

		public string prefix;

		private void Awake()
		{
		}

		private void EventCallback(SgWeaponWheelEvent wheelEvent)
		{
		}

		private void OnHighlight(string name)
		{
		}
	}
}
