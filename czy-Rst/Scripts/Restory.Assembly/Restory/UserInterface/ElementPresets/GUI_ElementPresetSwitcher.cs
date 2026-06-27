using System.Linq;
using UnityEngine;

namespace Restory.UserInterface.ElementPresets
{
	public class GUI_ElementPresetSwitcher : MonoBehaviour
	{
		private PresetName activePresetName = PresetName.Normal;

		[SerializeField]
		private ElementPreset[] presets = new ElementPreset[0];

		private ElementPreset activePreset;

		public void ActivatePreset(PresetName presetName, bool forceActivate = false)
		{
			if (presetName != PresetName.None && (activePreset == null || activePreset.Name != presetName || forceActivate))
			{
				ElementPreset elementPreset = presets.FirstOrDefault((ElementPreset x) => x.Name == presetName);
				if (elementPreset != null)
				{
					activePreset?.Revert();
					activePreset = elementPreset;
					activePreset.Apply();
					activePresetName = presetName;
				}
				else
				{
					Debug.LogWarning(string.Format("[{0}] can't find preset to apply: {1}", "GUI_ElementPresetSwitcher", presetName), base.gameObject);
				}
			}
		}
	}
}
