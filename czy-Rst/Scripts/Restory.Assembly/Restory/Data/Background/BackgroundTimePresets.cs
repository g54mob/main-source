using System;
using System.Collections.Generic;
using UnityEngine;

namespace Restory.Data.Background
{
	[CreateAssetMenu(menuName = "Restory/Background/BackgroundTimePresets", fileName = "BackgroundTimePresets")]
	public class BackgroundTimePresets : ScriptableObject
	{
		[SerializeField]
		private BackgroundTimePreset[] presets = Array.Empty<BackgroundTimePreset>();

		public IReadOnlyCollection<BackgroundTimePreset> Presets => presets;
	}
}
