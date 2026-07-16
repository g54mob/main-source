using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource Library", menuName = "Libraries/Resource Library", order = 1)]
public class ResourceLibrary : ScriptableObject
{
	public List<GameObject> prefabs = new List<GameObject>();
}
