using System.Collections.Generic;
using UnityEngine;

public class AdventureManager : MonoBehaviour
{
	private float adventureCooldown = 180f;

	private float currentAdventureCooldown;

	private Dictionary<AdventureDestinationType, List<Researchable>> indexedResearchables = new Dictionary<AdventureDestinationType, List<Researchable>>();

	private void Update()
	{
		if (currentAdventureCooldown > 0f)
		{
			currentAdventureCooldown -= Time.deltaTime;
			if (currentAdventureCooldown < 0f)
			{
				currentAdventureCooldown = 0f;
			}
		}
	}

	public void OnAdventureFinished()
	{
		currentAdventureCooldown = adventureCooldown;
	}

	public bool CanAdventure()
	{
		return currentAdventureCooldown <= 0f;
	}

	public Researchable GetRandomResearchableForDestination(AdventureDestinationType destinationType)
	{
		return ListUtil.GetRandomElement(indexedResearchables[destinationType]);
	}

	public AdventureResults GetAdventureResults(AdventureDestinationType destination, ulong dogID)
	{
		return new AdventureResults
		{
			flavorText = GetFlavorTextForDestination(destination),
			unlockedObjects = GetObjectUnlockForDestination(destination)
		};
	}

	private string GetFlavorTextForDestination(AdventureDestinationType destination)
	{
		if (destination == AdventureDestinationType.PET_STORE)
		{
			return GetPetStoreFlavorText();
		}
		return "No flavor text for this destination";
	}

	private string GetPetStoreFlavorText()
	{
		switch (Random.Range(1, 6))
		{
		case 1:
			return "As soon as your dog arrived, it immediately set off galavanting through the aisles. So much to see, so much to smell, so much to bite... \n\nHours later it was discovered in the rubber bone wing, firmly asleep in a pile of toppled over merchandise. The store manager thought it was so cute, she offered the dog a parting gift.";
		case 2:
			return "While exploring the gargantuan building, your dog stumbled into what seemed like a forgotten section of the store. No one had been through this aisle in years. \n\nCobweb-littered shelving units displayed curiosities long-since forgotten. Your dog grabbed a small box on its way out. Surely no one would miss it...";
		case 3:
			return "The pet store was holding a special event. Free samples of premium Morph-O Dog Chow. Overcome by this offer, your dog spent the entire day getting back in line and sneaking more samples. \n\nWhat it didn't realize, however, was that this particular type of food came with... additional effects.";
		case 4:
			return "Your dog immediately made a new friend and spent the entire trip playing with them. The two pups made the store their own.\n\nWhen it was finally time to leave, they not only exchanged parting barks, but parting gifts as well. Lasting reminders of their unforgettable day.";
		case 5:
			return "Your dog got lost wandering the vast parking lot and never made it inside the store. On the way back to the car, it stumbled on a similarly lost piece of merchandise. A bit dirty, but no worse for the ware.";
		case 6:
			return "";
		case 7:
			return "";
		case 8:
			return "";
		case 9:
			return "";
		case 10:
			return "";
		default:
			return "Something went wrong...";
		}
	}

	private List<Researchable> GetObjectUnlockForDestination(AdventureDestinationType destination)
	{
		return new List<Researchable> { GetRandomResearchableForDestination(destination) };
	}
}
