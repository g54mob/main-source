using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TutorialCategory
{
	public string categoryTitle;

	public List<TutorialTask> tasks = new List<TutorialTask>();

	[HideInInspector]
	public bool isActive;
}
