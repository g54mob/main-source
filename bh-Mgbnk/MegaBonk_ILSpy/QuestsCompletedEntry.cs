using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.UI.Animation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestsCompletedEntry : MonoBehaviour
{
	public RawImage icon;

	public TextMeshProUGUI t_name;

	public TextMeshProUGUI t_description;

	public TextMeshProUGUI t_unlock;

	public UiAnimation uiAnimation;

	public MyButton myButton;

	public unsafe void Set(MyAchievement achievement)
	{
		//IL_00a0: Expected O, but got Ref
		Texture texture = achievement.GetIcon();
		icon.texture = texture;
		string displayName = achievement.GetDisplayName();
		t_name.text = displayName;
		string unlockRequirement = achievement.GetUnlockRequirement();
		t_description.text = unlockRequirement;
		string unlockedString = achievement.GetUnlockedString();
		t_unlock.text = unlockedString;
		Transform transform = base.transform;
		object obj = default(object);
		transform.localScale = (Vector3)(&obj);
		uiAnimation.Scale(1f, 0.2f, EEasing.InOutCirc);
		GameObject gameObject = myButton.gameObject;
		gameObject.SetActive(value: true);
	}
}
