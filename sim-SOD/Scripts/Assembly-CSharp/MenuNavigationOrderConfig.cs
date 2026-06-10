using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class MenuNavigationOrderConfig : MonoBehaviour
{
	public List<Transform> contentParentHierarchy;

	public bool leftMovesUpHierarchy;

	[Button(null, EButtonEnableMode.Always)]
	public void Configure()
	{
	}
}
