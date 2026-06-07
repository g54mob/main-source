using TMPro;
using UnityEngine;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Display/Resolution & RefreshRate Dropdown")]
	[RequireComponent(typeof(TMP_Dropdown))]
	public sealed class ResolutionRefreshRateDropdown : MonoBehaviour
	{
		private Resolution[] resolutions;

		private TMP_Dropdown dropdown;

		private void Awake()
		{
		}

		private void UpdateResolutions()
		{
		}

		private void OnValueChange(int _resolutionIndex)
		{
		}
	}
}
