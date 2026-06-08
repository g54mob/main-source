using System.Collections;

public class ArrestSlider : SliderPanel
{
	private static readonly float DURATION = (CreateTables.DEV_MODE ? 2f : 9f);

	private string[][] arrestMessages = new string[9][]
	{
		new string[3] { "Remembering where we put the suspect", "Walking toward suspect", "Apprehending suspect" },
		new string[3] { "Finding handcuffs", "Speeding toward suspect location", "Violently tackling suspect" },
		new string[3] { "Finishing our coffee", "Scoping out the office kitchen", "Traitor spotted" },
		new string[3] { "Locating suspect's phone number", "Dialing suspect", "Approaching tracked location" },
		new string[3] { "Grabbing weapons and armor", "Preparing armed vehicles", "Breaching suspect domicile" },
		new string[3] { "Tracking suspect's IP address", "Racing toward suspect", "Intercepting suspect" },
		new string[3] { "Suspect located", "Fighter jets flying overhead", "Officers parachuting towards suspect" },
		new string[3] { "Entering LZU campus", "Finding correct classroom", "Sprinting towards suspect" },
		new string[3] { "Getting out of bed", "Putting on slippers", "Walking toward suspect" }
	};

	public void StartArrest(ArrestAnimator arrestAnimator, bool isCorrectArrest, string arrestName)
	{
		InitializeSliderPanel(DURATION);
		StartCoroutine(StartLoading(arrestAnimator, isCorrectArrest, arrestName));
	}

	private IEnumerator StartLoading(ArrestAnimator arrestAnimator, bool isCorrectArrest, string arrestName)
	{
		yield return PlayLoading(arrestMessages[LevelManager.GetCurrLevel()]);
		arrestAnimator.PlayAnimations(isCorrectArrest, arrestName);
	}
}
