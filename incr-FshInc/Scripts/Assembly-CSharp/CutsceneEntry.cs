using System;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class CutsceneEntry
{
	[Tooltip("The Timeline asset to play. Leave null to only trigger dialogue.")]
	public PlayableAsset timelineAsset;

	[Tooltip("Dialogue shown BEFORE the Timeline begins. Leave null to skip.")]
	public DialogueSequenceSO preDialogue;

	[Tooltip("Dialogue shown AFTER the Timeline ends. Leave null to skip.")]
	public DialogueSequenceSO postDialogue;

	[Tooltip("If true, this cutscene will only play once and be remembered via PlayerPrefs.")]
	public bool playOnce = true;

	[Tooltip("If true, the player can press Space to skip the Timeline portion.")]
	public bool skippable = true;

	[Tooltip("If true, the player cannot cast their rod while this cutscene is playing.")]
	public bool blockFishing = true;

	[Tooltip("If true, the main game UI (Canvas) will be hidden during the cutscene.")]
	public bool hideUI;

	[Tooltip("If true, cinematic black bars will appear at the top and bottom of the screen..")]
	public bool showCinematicBars;

	[Tooltip("If true, the PlayableDirector is stopped after this sequence ends, releasing its hold on animated objects (e.g. letting LightHouseSpin resume). Disable this if the timeline positions objects that need to stay in place after the cutscene (e.g. Kraken appearing).")]
	public bool stopDirectorOnComplete = true;
}
