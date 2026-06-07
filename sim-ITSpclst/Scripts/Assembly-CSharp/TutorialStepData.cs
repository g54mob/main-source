using System;
using System.Collections.Generic;
using UnityEngine.Events;

[Serializable]
public class TutorialStepData
{
	public string nameStep;

	public List<bool> data;

	public UnityEvent actionUpdate;
}
