using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[AddComponentMenu("Malbers/Animal Controller/Mode Sequence")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/main-components/manimal-controller/mode-sequence")]
	public class ModeSequence : MonoBehaviour
	{
		[RequiredField]
		public MAnimal animal;

		[Tooltip("While the sequence is playing the animal cannot be controlled")]
		public bool disableControl = true;

		[Tooltip("The Sequence will be Play on Start. To play Manually call the method 'PlaySequence()' ")]
		public bool PlayOnStart;

		[Tooltip("Play a mode using the mode list. Use Combine Index  (Mode_ID * 1000 + Ability_Index) (See Animal Modes) ")]
		public List<int> sequence = new List<int>();

		private int index;

		private bool playing;

		public void PlaySequence()
		{
			int num = sequence[index];
			int num2 = Mathf.Abs(num / 1000);
			int abilityIndex = ((num2 == 0) ? (-99) : (num % 100));
			if (animal.Mode_TryActivate(num2, abilityIndex))
			{
				index++;
				playing = true;
				if (disableControl)
				{
					animal.Lock(value: true);
				}
			}
			else
			{
				Debug.LogWarning($"The current Mode sequence {num} cannot be played.");
				EndSequence();
			}
		}

		private void OnModeEnd(int mode, int ability)
		{
			if (playing)
			{
				if (index < sequence.Count)
				{
					PlaySequence();
				}
				else
				{
					EndSequence();
				}
			}
		}

		private void EndSequence()
		{
			playing = false;
			index = 0;
			if (disableControl)
			{
				animal.Lock(value: false);
			}
		}

		private void OnEnable()
		{
			animal.OnModeEnd.AddListener(OnModeEnd);
			if (PlayOnStart)
			{
				PlaySequence();
			}
		}

		private void OnDisable()
		{
			animal.OnModeEnd.RemoveListener(OnModeEnd);
		}

		private void Reset()
		{
			animal = this.FindComponent<MAnimal>();
		}
	}
}
