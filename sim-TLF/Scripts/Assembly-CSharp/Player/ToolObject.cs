using System.Collections.Generic;
using Items;
using JSAM;
using UnityEngine;

namespace Player
{
	[CreateAssetMenu(menuName = "Player Usable Object/Tool Object", fileName = "New Tool Object")]
	public class ToolObject : ScriptableObject
	{
		public enum UseType
		{
			Hold = 0,
			Click = 1
		}

		public List<SoundFileObject> EquipSounds;

		public List<SoundFileObject> UseSounds;

		public HandedViewObject HandedView;

		public UseType ToolUseType;

		public ProgressToolType ToolType;

		public float Power;

		public bool AnyUseSoundPlaying()
		{
			foreach (SoundFileObject useSound in UseSounds)
			{
				if (AudioManager.IsSoundPlaying(useSound))
				{
					return true;
				}
			}
			return false;
		}

		public void PlayUseSounds()
		{
			foreach (SoundFileObject useSound in UseSounds)
			{
				AudioManager.PlaySound(useSound);
			}
		}

		public void StopUseSounds()
		{
			foreach (SoundFileObject useSound in UseSounds)
			{
				AudioManager.StopSound(useSound);
			}
		}

		public void PlayEquipSounds()
		{
			foreach (SoundFileObject equipSound in EquipSounds)
			{
				AudioManager.PlaySound(equipSound);
			}
		}

		public void StopEquipSounds()
		{
			foreach (SoundFileObject equipSound in EquipSounds)
			{
				AudioManager.StopSound(equipSound);
			}
		}
	}
}
