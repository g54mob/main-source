using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class RelicPanel : MonoBehaviour
	{
		[SerializeField]
		private GameObject _Prefab;

		[SerializeField]
		private RectTransform _Container;

		private List<GameObject> _spawned;

		private List<ItemType> _spawnedType;

		private DataManager _data;

		private PlayerOptions _playerOptions;

		private bool _hasYellowRelic;

		[Inject]
		private void Construct(DataManager data, PlayerOptions player)
		{
		}

		public void SetRelics(StageData stage, StageType stageType)
		{
		}
	}
}
