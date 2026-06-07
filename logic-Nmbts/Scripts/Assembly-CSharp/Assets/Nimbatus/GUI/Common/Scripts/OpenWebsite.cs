using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class OpenWebsite : MonoBehaviour
	{
		public string Url;

		public void OnClick()
		{
			Analytics.CustomEvent("Open Website", new Dictionary<string, object> { { "URL", Url } });
			Application.OpenURL(Url);
		}
	}
}
