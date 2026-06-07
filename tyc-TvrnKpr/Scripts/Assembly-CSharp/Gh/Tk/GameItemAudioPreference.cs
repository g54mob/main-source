using UnityEngine;

namespace Gh.Tk
{
	public class GameItemAudioPreference : MonoBehaviour
	{
		[DropDownChoice(typeof(AudioSwitch.GameItems), "GetAllItems")]
		public string gameItemType;

		private void OnEnable()
		{
		}

		public void ApplyPreference()
		{
		}
	}
}
