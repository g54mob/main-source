using UnityEngine;

namespace ModularOptions
{
	[CreateAssetMenu(fileName = "UISoundData", menuName = "DataContainer/UI/SelectableSound")]
	public class SelectableUISoundData : ScriptableObject
	{
		public AudioClip submitSound;

		public AudioClip selectionSound;

		public AudioClip deselectionSound;
	}
}
