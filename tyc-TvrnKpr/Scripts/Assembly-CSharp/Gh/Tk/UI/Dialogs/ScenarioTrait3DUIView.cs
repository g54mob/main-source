using Gh.Tk.Story.Structure;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class ScenarioTrait3DUIView : BaseInteractable3DUIView
	{
		[SerializeField]
		private Transform _iconSocket;

		private static GameObject _defaultIconPrefab;

		private GameObject _iconInstance;

		public void SetTrait(ScenarioTrait trait)
		{
		}

		private void SetIcon(string iconId)
		{
		}
	}
}
