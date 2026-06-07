using System.Collections.Generic;
using Gh.Tk.Story.Structure;
using Gh.Tk.UI;
using UnityEngine;

namespace Gh.Tk
{
	public class NewScenarioList3DUIView : MonoBehaviour
	{
		[SerializeField]
		private Container3DUIView _scenarioContainer;

		[SerializeField]
		private GameObject _scenarioButtonPrefab;

		private List<Button3DUIView> _scenarioButtons;

		private GameObject _selectedScenarioButton;

		[SerializeField]
		private ScenarioInfo3DUIView _scenarioInfo;

		private string _levelId;

		private List<string> _noFreeplayLevels;

		private PrefabObjectPool _scenarioButtonPool;

		private BaseInteractable3DUIView _freeplayButton;

		private void Awake()
		{
		}

		public void PopulateScenarioList(string levelId, bool selectFreeplay)
		{
		}

		public void Show()
		{
		}

		public void Hide()
		{
		}

		private void PopulateScenarioList(IEnumerable<ScenarioStoryStartNode> scenarios)
		{
		}

		private void CreateFreeplayButton()
		{
		}

		private string GetPreviousLevelId()
		{
			return null;
		}

		private void CreateScenarioButton(ScenarioStoryStartNode scenario)
		{
		}
	}
}
