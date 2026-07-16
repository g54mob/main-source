using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Twitch Library", menuName = "Twitch/Twitch Library", order = 1)]
public class TwitchCommandLibrary : ScriptableObject
{
	public List<TwitchCommand> commandList = new List<TwitchCommand>();
}
