using CTS;
using CTS.Core;
using UnityEngine;

public class FurnitureShopSoundManager : MonoBehaviour
{
	[SerializeField]
	private AudioSource _audioSource;

	[SerializeField]
	private AudioAsset _grabSound;

	[SerializeField]
	private AudioAsset _placeSound;

	private void Awake()
	{
		if (!_audioSource)
		{
			_audioSource = GetComponent<AudioSource>();
		}
	}

	private void OnEnable()
	{
		FurnitureController.PlacingFurniture += OnPlacingFurniture;
		FurnitureController.FurniturePickedUp += OnFurniturePickedUp;
	}

	private void OnFurniturePickedUp(FurnitureController obj)
	{
		MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_grabSound);
	}

	private void OnDisable()
	{
		FurnitureController.PlacingFurniture -= OnPlacingFurniture;
		FurnitureController.FurniturePickedUp -= OnFurniturePickedUp;
	}

	private void OnPlacingFurniture(FurnitureController obj)
	{
		MonoSingleton<SoundManager>.Instance.PlayAudioAsset(_placeSound);
	}
}
