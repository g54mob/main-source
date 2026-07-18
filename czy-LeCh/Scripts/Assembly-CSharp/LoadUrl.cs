using UnityEngine;

public class LoadUrl : MonoBehaviour
{
	public void LoadURL(string url)
	{
		Application.OpenURL(url);
	}
}
