using Assets.Nimbatus.Scripts.Tutorial.TutorialScenes;
using I2.Loc;
using UnityEngine;

public class TutorialTargetDestroyedLabel : MonoBehaviour
{
	private UILabel _label;

	private string _translation;

	private void Start()
	{
		_translation = LocalizationManager.GetTermTranslation("Tutorial/TutorialTargetDestroyed");
		_label = GetComponent<UILabel>();
	}

	private void Update()
	{
		GenericTutorialLogic instance = GenericTutorialLogic.Instance;
		if (instance != null && instance.IsTargetDestroyed)
		{
			_label.text = _translation;
		}
	}
}
