using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class PlayTogether : MonoBehaviour
	{
		[SerializeField]
		private ActionSequence[] sequences;

		[Button(null, EButtonEnableMode.Always)]
		private void PlaySequences()
		{
			ActionSequence[] array = sequences;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].PlaySequence();
			}
		}
	}
}
