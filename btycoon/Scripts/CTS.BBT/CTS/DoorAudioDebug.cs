using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class DoorAudioDebug : MonoBehaviour
	{
		[SerializeField]
		private Door door;

		[Button(null, EButtonEnableMode.Always)]
		private void Open()
		{
			door.ForceOpen();
		}

		[Button(null, EButtonEnableMode.Always)]
		private void Close()
		{
			door.ForceClose();
		}
	}
}
