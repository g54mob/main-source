using System;
using Lightbug.CharacterControllerPro.Core;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[AddComponentMenu("Character Controller Pro/Demo/Material Controller")]
	[DefaultExecutionOrder(-10)]
	public class MaterialController : MonoBehaviour
	{
		[SerializeField]
		private MaterialsProperties materialsProperties;

		private CharacterActor characterActor;

		private Volume currentVolume;

		private Surface currentSurface;

		public Surface CurrentSurface => currentSurface;

		public Volume CurrentVolume => currentVolume;

		public event Action<Volume> OnVolumeEnter;

		public event Action<Volume> OnVolumeExit;

		public event Action<Surface> OnSurfaceEnter;

		public event Action<Surface> OnSurfaceExit;

		private void GetSurfaceData()
		{
			if (!characterActor.IsGrounded)
			{
				SetCurrentSurface(materialsProperties.DefaultSurface);
				return;
			}
			GameObject groundObject = characterActor.GroundObject;
			if (groundObject != null)
			{
				if (materialsProperties.GetSurface(groundObject, out var outputSurface))
				{
					SetCurrentSurface(outputSurface);
				}
				else if (groundObject.CompareTag("Untagged"))
				{
					SetCurrentSurface(materialsProperties.DefaultSurface);
				}
			}
		}

		private void SetCurrentSurface(Surface surface)
		{
			if (surface != currentSurface)
			{
				if (this.OnSurfaceExit != null)
				{
					this.OnSurfaceExit(currentSurface);
				}
				if (this.OnSurfaceEnter != null)
				{
					this.OnSurfaceEnter(surface);
				}
			}
			currentSurface = surface;
		}

		private void GetVolumeData()
		{
			GameObject gameObject = characterActor.CurrentTrigger.gameObject;
			if (gameObject == null)
			{
				if (currentVolume != materialsProperties.DefaultVolume)
				{
					if (this.OnVolumeExit != null)
					{
						this.OnVolumeExit(currentVolume);
					}
					SetCurrentVolume(materialsProperties.DefaultVolume);
				}
				return;
			}
			Volume outputVolume;
			bool volume = materialsProperties.GetVolume(gameObject, out outputVolume);
			if (volume)
			{
				SetCurrentVolume(outputVolume);
				return;
			}
			for (int num = characterActor.Triggers.Count - 1; num >= 0; num--)
			{
				volume = materialsProperties.GetVolume(characterActor.Triggers[num].gameObject, out outputVolume);
				if (volume)
				{
					SetCurrentVolume(outputVolume);
				}
			}
			if (!volume)
			{
				SetCurrentVolume(materialsProperties.DefaultVolume);
			}
		}

		private void SetCurrentVolume(Volume volume)
		{
			if (volume != currentVolume)
			{
				if (this.OnVolumeExit != null)
				{
					this.OnVolumeExit(currentVolume);
				}
				if (this.OnVolumeEnter != null)
				{
					this.OnVolumeEnter(volume);
				}
			}
			currentVolume = volume;
		}

		private void Awake()
		{
			characterActor = this.GetComponentInBranch<CharacterActor>();
			if (characterActor == null)
			{
				base.enabled = false;
				return;
			}
			SetCurrentSurface(materialsProperties.DefaultSurface);
			SetCurrentVolume(materialsProperties.DefaultVolume);
		}

		private void FixedUpdate()
		{
			GetSurfaceData();
			GetVolumeData();
		}
	}
}
