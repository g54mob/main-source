using UnityEngine;

[CreateAssetMenu(menuName = "GameKit/Interaction option", fileName = "InteractionOption")]
public class InteractionOption : ScriptableObject
{
	[SerializeField]
	private string id = "";

	[SerializeField]
	private string displayName = "";

	[SerializeField]
	private Sprite icon;

	public string Id => id;

	public string DisplayName => displayName;

	public Sprite Icon => icon;
}
