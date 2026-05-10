using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "Machines/Scriptable Sounds", fileName = "New List")]
	public class MachineSoundsScriptableObject : ScriptableObject
	{
		public AudioAsset[] SoundsList;
	}
}
