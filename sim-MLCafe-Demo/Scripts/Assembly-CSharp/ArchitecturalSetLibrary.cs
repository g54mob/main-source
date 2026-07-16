using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArchitectualSetLibrary", menuName = "Libraries/ArchitectualSetLibrary")]
public class ArchitecturalSetLibrary : ScriptableObject
{
	public List<ArchticturalSet> sets = new List<ArchticturalSet>();
}
