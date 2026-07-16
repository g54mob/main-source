using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundLibrary", menuName = "Libraries/SoundLibrary")]
public class SoundLibrary : ScriptableObject
{
	public List<SoundContainerGroup> soundGroups = new List<SoundContainerGroup>();
}
