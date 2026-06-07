using UnityEngine;

namespace AudioSystem
{
	public class WeaponAudioController : MonoBehaviour
	{
		[Header("Audio Events")]
		[Tooltip("Weapon fire sound.")]
		[SerializeField]
		private AudioEventAsset fireEvent;

		[Tooltip("Weapon reload sound.")]
		[SerializeField]
		private AudioEventAsset reloadEvent;

		[Tooltip("Dry fire (empty) sound.")]
		[SerializeField]
		private AudioEventAsset dryFireEvent;

		[Tooltip("Weapon equip sound.")]
		[SerializeField]
		private AudioEventAsset equipEvent;

		[Tooltip("Weapon holster sound.")]
		[SerializeField]
		private AudioEventAsset holsterEvent;

		[Header("Settings")]
		[Tooltip("Whether sounds should be networked.")]
		[SerializeField]
		private bool networkSounds;

		public void PlayFireSound()
		{
		}

		public void PlayReloadSound()
		{
		}

		public void PlayDryFireSound()
		{
		}

		public void PlayEquipSound()
		{
		}

		public void PlayHolsterSound()
		{
		}

		private void PlaySound(AudioEventAsset eventAsset)
		{
		}
	}
}
