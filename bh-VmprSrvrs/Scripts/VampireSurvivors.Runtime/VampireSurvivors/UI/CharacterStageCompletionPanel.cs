using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class CharacterStageCompletionPanel : MonoBehaviour
	{
		[SerializeField]
		private GameObject _StagePrefab;

		[SerializeField]
		private RectTransform _Container;

		private Dictionary<StageType, Image> _stageIcons;

		private DataManager _dataManager;

		private SignalBus _signalBus;

		private PlayerOptions _playerOptions;

		private bool _formatSize;

		[Inject]
		private void Construct(DataManager data, SignalBus signal, PlayerOptions player)
		{
		}

		public void Initialize()
		{
		}

		private void LateUpdate()
		{
		}

		public void TryShow()
		{
		}

		public void SetPanel(CharacterType cType)
		{
		}
	}
}
