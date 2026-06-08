using UnityEngine;

public class Clue
{
	public Sprite photoClue;

	public AudioClip audioClue;

	public bool IsPhotoClue()
	{
		return photoClue != null;
	}

	public bool IsAudioClue()
	{
		return audioClue != null;
	}
}
