using UnityEngine;

[CreateAssetMenu(fileName = "New Audio Clip Data", menuName = "Super Text Mesh/Audio Clip Data", order = 1)]
public class STMAudioClipData : ScriptableObject
{
	public bool showFoldout = true;

	public AudioClip[] clips;
}
