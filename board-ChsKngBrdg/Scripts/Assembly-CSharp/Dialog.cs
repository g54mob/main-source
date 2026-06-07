using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Dialogs")]
public class Dialog : ScriptableObject
{
	public LocalizedString dialogString;

	public float dialogSpeed;

	public bool canSkip = true;
}
