using System.Collections.Generic;
using UnityEngine;

public class CustomSounds : MonoBehaviour
{
	private static Dictionary<string, string> builtin_sounds;

	public static void Play(string sound, Vector3 pos, float volume)
	{
	}

	public static List<string> GetSounds()
	{
		return null;
	}

	public static void PlayLoop(string sound, UnitManager um, float volume)
	{
	}

	public static void StopLoop(UnitManager um)
	{
	}
}
