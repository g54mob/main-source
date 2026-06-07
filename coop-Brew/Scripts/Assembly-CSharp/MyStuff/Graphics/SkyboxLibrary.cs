using System.Collections.Generic;
using UnityEngine;

namespace MyStuff.Graphics
{
	[CreateAssetMenu(fileName = "SkyboxLibrary", menuName = "Graphics/Skybox Library", order = 11)]
	public sealed class SkyboxLibrary : ScriptableObject
	{
		[Header("=== Skybox Preset Collection ===")]
		[Tooltip("List of available skybox presets")]
		[SerializeField]
		private List<SkyboxPreset> presets;

		[Tooltip("Default preset to apply on startup")]
		[SerializeField]
		private SkyboxPreset defaultPreset;

		public IReadOnlyList<SkyboxPreset> Presets => null;

		public SkyboxPreset DefaultPreset => null;

		public int PresetCount => 0;

		public SkyboxPreset GetPresetByName(string name)
		{
			return null;
		}

		public SkyboxPreset GetPresetByIndex(int index)
		{
			return null;
		}

		public bool AddPreset(SkyboxPreset preset)
		{
			return false;
		}

		public bool RemovePreset(SkyboxPreset preset)
		{
			return false;
		}

		public void ClearPresets()
		{
		}

		public string[] GetPresetNames()
		{
			return null;
		}

		public void Validate()
		{
		}

		private void OnValidate()
		{
		}
	}
}
