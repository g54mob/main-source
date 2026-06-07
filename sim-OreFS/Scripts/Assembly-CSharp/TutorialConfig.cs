using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TutorialConfig", menuName = "Digging/Configs/TutorialConfig")]
public class TutorialConfig : ScriptableObject
{
	public TutorialConfigType configType;

	[Tooltip("Bu config acilirken bekleme yapilmadan direkt acilsin mi?")]
	public bool skipOpeningDelay;

	public List<TutorialStep> tutorialSteps;

	[Header("Chaining")]
	[Tooltip("Bu tutorial tamamlaninca otomatik baslatilacak sonraki tutorial")]
	public TutorialConfig nextTutorialConfig;
}
