using System.Collections.Generic;
using UnityEngine;

namespace MyStuff.Graphics
{
	[CreateAssetMenu(fileName = "GraphicsLibrary", menuName = "Graphics/Graphics Library", order = 3)]
	public sealed class GraphicsLibrary : ScriptableObject
	{
		[Header("=== Preset Library ===")]
		[Tooltip("Default preset to load on startup")]
		[SerializeField]
		private GraphicsPreset defaultPreset;

		[Tooltip("All available presets")]
		[SerializeField]
		private List<GraphicsPreset> presets;

		public GraphicsPreset DefaultPreset => null;

		public IReadOnlyList<GraphicsPreset> Presets => null;

		public GraphicsPreset GetPresetByName(string name)
		{
			return null;
		}

		public bool HasPreset(string name)
		{
			return false;
		}

		public bool AddPreset(GraphicsPreset preset)
		{
			return false;
		}

		public bool RemovePreset(GraphicsPreset preset)
		{
			return false;
		}

		public bool ValidateAllPresets(out List<string> errors)
		{
			errors = null;
			return false;
		}

		public string GetSummary()
		{
			return null;
		}
	}
}
