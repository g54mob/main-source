using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using UnityEngine;

public class ChapterController : MonoBehaviour
{
	public delegate void NewPart(bool delay, bool teleport);

	public List<ChapterPreset> allChapters;

	[Header("Loaded")]
	public ChapterPreset loadedChapter;

	public Chapter chapterScript;

	public GameObject chapterObject;

	[ReadOnly]
	public int currentPart;

	[ReadOnly]
	public string currentPartName;

	public bool loadFirstPartOnStart;

	private static ChapterController _instance;

	public static ChapterController Instance => null;

	public event NewPart OnNewPart
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void LoadChapter(ChapterPreset newChapter, bool newLoadFirstPartOnStart)
	{
	}

	public void LoadPart(int partNumber, bool teleportPlayer = false, bool delay = true)
	{
	}

	public void LoadPart(string chapterString)
	{
	}

	public void SkipToChapterPart(int newPart, bool teleport, bool delay)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SkipToNextPart()
	{
	}

	public void ResetThis()
	{
	}
}
