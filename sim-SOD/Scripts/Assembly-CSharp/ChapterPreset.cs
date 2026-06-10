using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "chapter_data", menuName = "Database/Chapter Preset")]
public class ChapterPreset : SoCustomComparison
{
	[Header("Settings")]
	[Tooltip("The number of the chapter. This must be exclusive.")]
	public int chapterNumber;

	[Tooltip("The prefab that contains the logic for this chapter")]
	public GameObject scriptObject;

	[Tooltip("The chapter script reference")]
	public string dictionary;

	[Tooltip("Ask to enable the tutorial if this chapter is played.")]
	public bool askToEnableTutorial;

	[Header("Starting Time")]
	public float startingHour;

	public int startingDate;

	public int startingMonth;

	public int startingYear;

	public int yearZeroLeapYearCycle;

	public int dayZero;

	[Header("Starting Weather")]
	[Range(0f, 1f)]
	public float rainAmount;

	[Range(0f, 1f)]
	public float windAmount;

	[Range(0f, 1f)]
	public float snowAmount;

	[Range(0f, 1f)]
	public float fogAmount;

	[Range(0f, 1f)]
	public float lightningAmount;

	public float transitionSpeed;

	[Header("Pre-Simulation")]
	[Tooltip("Simulate at fast forward until a certain point (dictated manually)")]
	public bool usePreSimulation;

	[EnableIf("usePreSimulation")]
	[Tooltip("The minimum amount of time to pre-simulate")]
	public float minimumPreSimLength;

	[Header("Bespoke Audio Events")]
	[ReorderableList]
	public List<AudioEvent> audioEvents;

	[Header("Bespoke Dialog")]
	[ReorderableList]
	public List<DialogPreset> dialogEvents;

	[Header("Crimes")]
	public List<MurderPreset> crimePool;

	public List<MurderMO> MOPool;

	[Tooltip("Included mostly for reference: You can use the chapter controller to switch between these.")]
	[ReorderableList]
	[Header("Chapter Parts")]
	public List<string> partNames;

	[Tooltip("The part to load when the chapter is loaded. You can use this to skip parts for testing.")]
	public int startingPart;

	[Button(null, EButtonEnableMode.Always)]
	public virtual void SkipToChapterPart()
	{
	}
}
