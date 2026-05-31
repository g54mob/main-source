using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class CrossPubManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject _parentToggles;

		[SerializeField]
		private GameObject _parentGames;

		[SerializeField]
		private ToggleGroup _toggleGroup;

		[SerializeField]
		private GameObject _prefabGames;

		[SerializeField]
		private GameObject _prefabToggles;

		[SerializeField]
		private List<GamesSO> _crossGamesList;

		private void Awake()
		{
			foreach (GamesSO crossGames in _crossGamesList)
			{
				GameObject gameObject = Object.Instantiate(_prefabGames, _parentGames.transform);
				GameObject obj = Object.Instantiate(_prefabToggles, _parentToggles.transform);
				GamePanel component = gameObject.GetComponent<GamePanel>();
				CrossToggle component2 = obj.GetComponent<CrossToggle>();
				component2.CTSTogle.group = _toggleGroup;
				_toggleGroup.RegisterToggle(component2.CTSTogle);
				component2.SetUpGamePanel(gameObject);
				component.SetUp(crossGames);
			}
		}
	}
}
