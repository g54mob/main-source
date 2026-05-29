using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class AudioConstructionBridge : MonoSingleton<AudioConstructionBridge>
	{
		[Header("Sound Assets")]
		[SerializeField]
		private AudioAsset _doorPlaced;

		[SerializeField]
		private AudioAsset _doorRemoved;

		[SerializeField]
		private AudioAsset _windowPlaced;

		[SerializeField]
		private AudioAsset _windowRemoved;

		[SerializeField]
		private AudioAsset _archPlaced;

		[SerializeField]
		private AudioAsset _archRemoved;

		[SerializeField]
		private AudioAsset _wallPlaced;

		[SerializeField]
		private AudioAsset _wallRemoved;

		[SerializeField]
		private AudioAsset _paint;

		[SerializeField]
		private AudioAsset _placeFondation;

		[SerializeField]
		private AudioAsset _barOpened;

		[SerializeField]
		private AudioAsset _barClosed;

		[SerializeField]
		private AudioAsset _changeWallState;

		protected override void OnSingletonDestroy()
		{
			BuildablePlacementSystem.OnBuildablePlaced -= BuildablePlacementSystem_OnBuildablePlaced;
			BuildableElement.Destroyed -= BuildableElement_Destroyed;
			ConstructionSystem.OnConstructionGenerated -= ConstructionSystem_OnConstructionGenerated;
			SurfaceObjectPaintingSystem.OnBuyPaint -= SurfaceObjectPaintingSystem_OnPaintingChanged;
			LevelParameters.OnBarOpenedStatusChanged -= LevelParameters_OnBarOpenedStatusChanged;
			WallHideButtonUpdater.ChangeWallStateSound -= ChangeWallStateSound;
		}

		private void LevelParameters_OnBarOpenedStatusChanged(bool obj)
		{
			MonoSingleton<SoundManager>.Instance.PlayAudioAsset(obj ? _barOpened : _barClosed);
		}

		private void SurfaceObjectPaintingSystem_OnPaintingChanged()
		{
			MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_paint);
		}

		protected override void SingletonAwake()
		{
			BuildablePlacementSystem.OnBuildablePlaced += BuildablePlacementSystem_OnBuildablePlaced;
			BuildableElement.Destroyed += BuildableElement_Destroyed;
			ConstructionSystem.OnConstructionGenerated += ConstructionSystem_OnConstructionGenerated;
			SurfaceObjectPaintingSystem.OnBuyPaint += SurfaceObjectPaintingSystem_OnPaintingChanged;
			LevelParameters.OnBarOpenedStatusChanged += LevelParameters_OnBarOpenedStatusChanged;
			WallHideButtonUpdater.ChangeWallStateSound += ChangeWallStateSound;
		}

		private void ConstructionSystem_OnConstructionGenerated(int modifiedCount, int fondationCreatedCount, int interiorCreatedCount)
		{
			if (modifiedCount != 0)
			{
				if (interiorCreatedCount > 0 || fondationCreatedCount > 0)
				{
					MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_wallPlaced);
				}
				else if (interiorCreatedCount < 0 || fondationCreatedCount < 0)
				{
					MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_wallRemoved);
				}
			}
		}

		private void BuildableElement_Destroyed(BuildableElement obj)
		{
			switch (obj.BuildableType)
			{
			case BuildableElementSO.EBuildableType.Door:
				MonoSingleton<SoundManager>.Instance.PlaySpatializedAudioAsset(_doorRemoved, obj.transform.position);
				break;
			case BuildableElementSO.EBuildableType.Window:
				MonoSingleton<SoundManager>.Instance.PlaySpatializedAudioAsset(_windowRemoved, obj.transform.position);
				break;
			case BuildableElementSO.EBuildableType.Arch:
				MonoSingleton<SoundManager>.Instance.PlaySpatializedAudioAsset(_archRemoved, obj.transform.position);
				break;
			}
		}

		private void BuildablePlacementSystem_OnBuildablePlaced(BuildableElement obj)
		{
			switch (obj.BuildableType)
			{
			case BuildableElementSO.EBuildableType.Door:
				MonoSingleton<SoundManager>.Instance.PlaySpatializedAudioAsset(_doorPlaced, obj.transform.position);
				break;
			case BuildableElementSO.EBuildableType.Window:
				MonoSingleton<SoundManager>.Instance.PlaySpatializedAudioAsset(_windowPlaced, obj.transform.position);
				break;
			case BuildableElementSO.EBuildableType.Arch:
				MonoSingleton<SoundManager>.Instance.PlaySpatializedAudioAsset(_archPlaced, obj.transform.position);
				break;
			}
		}

		private void ChangeWallStateSound()
		{
			MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_changeWallState);
		}
	}
}
