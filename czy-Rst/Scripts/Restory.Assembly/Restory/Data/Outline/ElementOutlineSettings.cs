using UnityEngine;

namespace Restory.Data.Outline
{
	[CreateAssetMenu(fileName = "ElementOutlineSettings", menuName = "Restory/ElementOutlineSettings")]
	public class ElementOutlineSettings : ScriptableObject
	{
		[SerializeField]
		private OutlineSettingsPreset activatableOutline;

		[SerializeField]
		private OutlineSettingsPreset notActivatableOutline;

		[SerializeField]
		private OutlineSettingsPreset installingOutline;

		[SerializeField]
		private OutlineSettingsPreset threadedElementOutline;

		[SerializeField]
		private OutlineSettingsPreset dirtyElementOutline;

		[SerializeField]
		private OutlineSettingsPreset damagedElementOutline;

		public OutlineSettingsPreset ActivatableOutline => activatableOutline;

		public OutlineSettingsPreset NotActivatableOutline => notActivatableOutline;

		public OutlineSettingsPreset InstallingOutline => installingOutline;

		public OutlineSettingsPreset ThreadedElementOutline => threadedElementOutline;

		public OutlineSettingsPreset DirtyElementOutline => dirtyElementOutline;

		public OutlineSettingsPreset DamagedElementOutline => damagedElementOutline;
	}
}
