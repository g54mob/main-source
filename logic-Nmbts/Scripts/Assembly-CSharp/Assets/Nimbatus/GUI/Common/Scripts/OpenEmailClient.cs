using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class OpenEmailClient : MonoBehaviour
	{
		public string Email;

		public string Subject;

		public string Body;

		public void OnClick()
		{
			string text = MyEscapeURL(Subject);
			string text2 = MyEscapeURL(Body);
			Application.OpenURL("mailto:" + Email + "?subject=" + text + "&body=" + text2);
		}

		private string MyEscapeURL(string url)
		{
			return UnityWebRequest.EscapeURL(url).Replace("+", "%20");
		}
	}
}
