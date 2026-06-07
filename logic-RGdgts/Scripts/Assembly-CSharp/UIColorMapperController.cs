using System.Collections.Generic;
using UnityEngine;

public class UIColorMapperController : MonoBehaviour
{
	public bool includeInactive;

	private Dictionary<string, List<UIColorMapper>> _colorMappers;

	public void Init(bool includeSameObject = false)
	{
	}

	public void GatherMappers(bool includeSameObject)
	{
	}

	public void ApplyMapper(string label, bool force = false)
	{
	}
}
