using UnityEngine;

[CreateAssetMenu(fileName = "New Voice Data", menuName = "Super Text Mesh/Voice Data", order = 1)]
public class STMVoiceData : ScriptableObject
{
	[TextArea(3, 10)]
	public string text;
}
