using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Effects - Audio/Sound By Material")]
	public class SoundByMaterial : MonoBehaviour
	{
		public AudioClipReference DefaultSound = new AudioClipReference();

		public List<MaterialSound> materialSounds;

		[SerializeField]
		private AudioSource audioSource;

		protected AudioSource Audio_Source
		{
			get
			{
				if (!audioSource)
				{
					audioSource = GetComponent<AudioSource>();
				}
				return audioSource;
			}
			set
			{
				audioSource = value;
			}
		}

		public virtual void PlayMaterialSound(RaycastHit hitSurface)
		{
			Collider collider = hitSurface.collider;
			if ((bool)collider)
			{
				PlayMaterialSound(collider.sharedMaterial);
			}
		}

		public virtual void PlayMaterialSound(GameObject hitSurface)
		{
			Collider component = hitSurface.GetComponent<Collider>();
			if ((bool)component)
			{
				PlayMaterialSound(component.sharedMaterial);
			}
		}

		public virtual void PlayMaterialSound(Component hitSurface)
		{
			PlayMaterialSound(hitSurface.gameObject);
		}

		public virtual void PlayMaterialSound(Collider hitSurface)
		{
			PlayMaterialSound(hitSurface.sharedMaterial);
		}

		public virtual void PlayMaterialSound(PhysicMaterial hitSurface)
		{
			if (!Audio_Source)
			{
				Audio_Source = base.gameObject.AddComponent<AudioSource>();
				Audio_Source.spatialBlend = 1f;
			}
			MaterialSound materialSound = materialSounds.Find((MaterialSound item) => item.material == hitSurface);
			if (materialSound != null)
			{
				AudioClip clip = materialSound.Sounds[Random.Range(0, materialSound.Sounds.Length)];
				Audio_Source.clip = clip;
				audioSource.Play();
			}
			else
			{
				DefaultSound?.Play(Audio_Source);
			}
		}
	}
}
