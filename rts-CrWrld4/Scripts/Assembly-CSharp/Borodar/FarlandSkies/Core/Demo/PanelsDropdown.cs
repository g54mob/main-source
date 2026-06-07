using UnityEngine;
using UnityEngine.UI;

namespace Borodar.FarlandSkies.Core.Demo
{
	public class PanelsDropdown : MonoBehaviour
	{
		[SerializeField]
		protected GameObject[] Panels;

		private Dropdown _dropdown;

		public void Awake()
		{
		}

		public void OnValueChanged()
		{
		}
	}
}
