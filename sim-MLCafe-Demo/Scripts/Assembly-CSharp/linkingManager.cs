using UnityEngine;

public class linkingManager : MonoBehaviour
{
	[SerializeField]
	private string openLink;

	public void OpenLink()
	{
		Application.OpenURL(openLink);
	}
}
