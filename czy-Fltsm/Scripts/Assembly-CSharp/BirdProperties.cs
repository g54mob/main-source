using Assets.Code.Animals;
using I2.Loc;
using PajamaLlama.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Agent/Bird")]
public class BirdProperties : AnimalProperties
{
	[SerializeField]
	public Bird Prefab;

	[Header("Balancing")]
	[Tooltip("Cycles that the bird can go without housing before leaving the community.")]
	public int CyclesAllowedWithoutHousing = 6;

	public Sprite HousingIcon;

	[Tooltip("Cycles that the bird can go without food before leaving the community.")]
	public int CyclesAllowedWithoutFood = 2;

	public Sprite FoodIcon;

	[Tooltip("How long it takes for the bird to eat its meal.")]
	public float EatingDuration = 30f;

	[Tooltip("The distance at which a bird can be be scared a way from its perching spot.")]
	public float ScaredDistance = 30f;

	[Header("Audio")]
	[Tooltip("Amount of seconds between hungry audio shouts.")]
	public RangedFloat HungryAudioCountdown = new RangedFloat(20f, 40f);

	[Tooltip("Amount of seconds between stuck audio shouts.")]
	public RangedFloat StuckAudioCountdown = new RangedFloat(20f, 40f);

	public AudioClipProperties ItemDropAudio;

	public AudioClipProperties HungryAudio;

	public AudioClipProperties StuckAudio;

	public AudioClipProperties SleepingAudio;

	[Header("Localization")]
	public LocalizedString IdleStateDescription = null;

	public LocalizedString SleepingStateDescription = null;

	public LocalizedString WaitingForFoodStateDescription = null;

	public LocalizedString EatingStateDescription = null;

	public LocalizedString WaitingForItemStateDescription = null;

	public LocalizedString SalvagingStateDescription = null;

	public LocalizedString ReturningToTownStateDescription = null;

	public LocalizedString LeavingWorldStateDescription = null;
}
