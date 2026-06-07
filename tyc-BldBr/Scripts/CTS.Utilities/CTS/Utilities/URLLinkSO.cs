using UnityEngine;

namespace CTS.Utilities
{
	[CreateAssetMenu(fileName = "URL LinkSO", menuName = "BBT/URLLinkSO")]
	public class URLLinkSO : ScriptableObject
	{
		[field: SerializeField]
		public string Url { get; private set; }

		public void OpenURL()
		{
			Application.OpenURL(Url);
		}
	}
}
