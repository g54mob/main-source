using System;
using UnityEngine;

[Serializable]
public class TutorialSubStep
{
	public string subStepDescription;

	public TutorialSubStepType subStepType;

	[Tooltip("Client bu alt adimi tamamlayabilir mi? false ise sadece host tamamlayabilir.")]
	public bool canClientComplete;

	[Header("Count-Based")]
	[Tooltip("Hedef adet (default 1). 10 girilirse '0/10' gosterilir.")]
	public int targetCount = 1;

	[HideInInspector]
	public bool isCompleted;
}
