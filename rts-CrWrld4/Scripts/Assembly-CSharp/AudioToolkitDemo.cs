using System.Collections.Generic;
using ClockStone;
using UnityEngine;

public class AudioToolkitDemo : MonoBehaviour
{
	public AudioClip customAudioClip;

	private float musicVolume;

	private float ambienceVolume;

	private bool musicPaused;

	private Vector2 playlistScrollPos;

	private PoolableReference<AudioObject> introLoopOutroAudio;

	private bool wasClipAdded;

	private bool wasCategoryAdded;

	private List<bool> disableGUILevels;

	private void OnGUI()
	{
	}

	private void DrawGuiLeftSide()
	{
	}

	private void DrawGuiRightSide()
	{
	}

	private void DrawGuiBottom()
	{
	}

	private void OnAudioCompleteleyPlayed(AudioObject audioObj)
	{
	}

	private void BeginDisabledGroup(bool condition)
	{
	}

	private void EndDisabledGroup()
	{
	}

	private bool IsGUIDisabled()
	{
		return false;
	}
}
