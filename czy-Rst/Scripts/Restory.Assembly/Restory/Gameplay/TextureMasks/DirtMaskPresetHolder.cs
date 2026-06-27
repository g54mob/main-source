using UnityEngine;

namespace Restory.Gameplay.TextureMasks
{
	public class DirtMaskPresetHolder : MonoBehaviour
	{
		[SerializeField]
		private MaskPresetInfoBase preset;

		public MaskPresetInfoBase Preset => preset;
	}
}
