using System.Collections.Generic;
using Data.Variables.Milestones;
using UnityEngine;

namespace Presentation.StartScene
{
	public class MainMenuIslandsView : MonoBehaviour
	{
		[SerializeField]
		private MonumentBuiltVariableSO _greyMonumentBuilt;

		[SerializeField]
		private MonumentBuiltVariableSO _blueMonumentBuilt;

		[SerializeField]
		private MonumentBuiltVariableSO _yellowMonumentBuilt;

		[SerializeField]
		private GNNGateFinishedVariableSO _gNNGateFinishedVariableSO;

		[SerializeField]
		private GameObject _greyMonumentMarker;

		[SerializeField]
		private GameObject _blueMonumentMarker;

		[SerializeField]
		private GameObject _yellowMonumentMarker;

		[SerializeField]
		private List<GameObject> _gnnGateFinishedMarker;

		[SerializeField]
		private List<GameObject> _gnnGateFinishedDeactivateMarker;

		private void Start()
		{
			_greyMonumentMarker.SetActive(_greyMonumentBuilt.Value);
			_blueMonumentMarker.SetActive(_blueMonumentBuilt.Value);
			_yellowMonumentMarker.SetActive(_yellowMonumentBuilt.Value);
			foreach (GameObject item in _gnnGateFinishedMarker)
			{
				if (item != null)
				{
					item.SetActive(_gNNGateFinishedVariableSO.Value);
				}
			}
			foreach (GameObject item2 in _gnnGateFinishedDeactivateMarker)
			{
				if (item2 != null)
				{
					item2.SetActive(!_gNNGateFinishedVariableSO.Value);
				}
			}
		}
	}
}
