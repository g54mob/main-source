using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Display/Resolution Dropdown")]
	[RequireComponent(typeof(TMP_Dropdown))]
	public sealed class ResolutionDropdown : MonoBehaviour
	{
		[Tooltip("Text separating Horizontal from Vertical Resolution.")]
		public string separator;

		private List<Vector2Int> resolutions;

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
