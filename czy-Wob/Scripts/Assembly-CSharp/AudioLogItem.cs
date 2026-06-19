using ClockStone;
using TMPro;
using UnityEngine;

public class AudioLogItem : MonoBehaviour
{
	public TextMeshProUGUI textField;

	public AudioObject associatedObject;

	public void SetAudioObject(AudioObject obj)
	{
		associatedObject = obj;
		string text = obj.category.Name + ": " + obj.audioID + ": " + obj.subItem.Clip.name;
		text = ((!(obj.transform.parent != null)) ? (text + "\n    Unparented") : (text + "\n    Parent: " + obj.transform.parent.root.gameObject.name));
		text = text + " (" + MathUtil.Round(obj.volumeTotal, 3) * 100f + "%)";
		textField.text = text;
	}
}
