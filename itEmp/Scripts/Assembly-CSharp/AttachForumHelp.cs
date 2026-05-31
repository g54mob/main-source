using UnityEngine;

public class AttachForumHelp : MonoBehaviour
{
	[Tooltip("Nazwa layera, który rozpoznaje obiekty 'Computer'")]
	public string computerLayerName;

	[Tooltip("Ścieżka dzieci do obiektu Center Content (np. Browser/Content/Center Content)")]
	public string forumPath;

	[Tooltip("Nazwa obiektu wewnątrz Center Content, do którego chcemy dodać Web_ForumHelp")]
	public string rightBarName;

	[ContextMenu("Scan Current Scene")]
	public void ScanCurrentScene()
	{
	}

	private Transform FindChildByPath(Transform root, string[] pathParts)
	{
		return null;
	}
}
