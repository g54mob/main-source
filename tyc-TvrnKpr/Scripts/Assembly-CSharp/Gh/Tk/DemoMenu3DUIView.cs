using System.Collections.Generic;
using Gh.Tk.Story.Structure;
using UnityEngine;

namespace Gh.Tk
{
	public class DemoMenu3DUIView : ShowHideAnimation3DUIView
	{
		public List<ScenarioStoryStartNode> demoScenarios;

		[SerializeField]
		private Transform _scenarioButtonContainer;

		[SerializeField]
		private GameObject _scenarioButtonPrefab;

		public Button3DUIView swampDemoButton;

		private void Start()
		{
		}

		protected override void OnEnable()
		{
		}
	}
}
