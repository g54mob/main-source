using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Hub
{
	public class DemoHubManager : MonoBehaviour
	{
		private struct DemoData
		{
			public string Title;

			public string Description;

			public string Scene;

			public string TutorialLink;

			public string DocLink;
		}

		public Text TitleText;

		public Text DescriptionText;

		public GameObject OpenSceneButton;

		public GameObject OpenTutorialLinkButton;

		public GameObject OpenDocLinkButton;

		private string MainDemoWebLink;

		private Dictionary<string, DemoData> _data;

		private string currentSelection;

		private void Awake()
		{
		}

		public void SelectDemo(string Reference)
		{
		}

		public void OpenScene()
		{
		}

		public void OpenTutorialLink()
		{
		}

		public void OpenDocLink()
		{
		}

		public void OpenMainWebLink()
		{
		}
	}
}
