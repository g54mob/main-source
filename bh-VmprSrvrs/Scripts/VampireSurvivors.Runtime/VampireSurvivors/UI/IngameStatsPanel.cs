using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.UI
{
	public class IngameStatsPanel : MonoBehaviour
	{
		[SerializeField]
		private List<StatItemUI> _StatObjects;

		private SignalBus _signalBus;

		private GameSessionData _session;

		private DataManager _dataManager;

		private bool _hasInitialized;

		private List<TextMeshProUGUI> _statTextLines;

		[Inject]
		private void Construct(SignalBus signalBus, GameSessionData session, DataManager data)
		{
		}

		public void OnEnable()
		{
		}
	}
}
