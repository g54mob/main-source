using TMPro;
using UnityEngine;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Display/Quality Level Dropdown")]
	[RequireComponent(typeof(TMP_Dropdown))]
	public sealed class QualityLevelDropdown : MonoBehaviour
	{
		private TMP_Dropdown dropdown;

		private void Awake()
		{
		}

		private void OnValueChange(int _value)
		{
		}
	}
}
