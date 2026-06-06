using UnityEngine;

[CreateAssetMenu(fileName = "EditorIcons", menuName = "Data/Icons")]
public class EditorIcons : ScriptableObject
{
	private static EditorIcons _cached;

	[field: SerializeField]
	public Texture2D FolderIcon { get; private set; }

	[field: SerializeField]
	public Texture2D ExecuteIcon { get; private set; }

	[field: SerializeField]
	public Texture2D ReloadEnabledIcon { get; private set; }

	[field: SerializeField]
	public Texture2D ReloadDisabledIcon { get; private set; }

	public static EditorIcons Instance => _cached;
}
