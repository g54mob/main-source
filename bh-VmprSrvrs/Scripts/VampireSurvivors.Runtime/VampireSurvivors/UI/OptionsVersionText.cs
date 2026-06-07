using TMPro;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;
using Zenject;

namespace VampireSurvivors.UI
{
	public class OptionsVersionText : MonoBehaviour, IInitializable
	{
		[SerializeField]
		private TextMeshProUGUI _VersionText;

		[SerializeField]
		private VersionData _VersionData;

		[Inject]
		private DataManager _dataManager;

		public void Initialize()
		{
		}

		private void Start()
		{
		}
	}
}
