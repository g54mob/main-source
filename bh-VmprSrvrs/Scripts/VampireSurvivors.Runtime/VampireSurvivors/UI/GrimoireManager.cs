using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class GrimoireManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject _EvolutionPrefab;

		[SerializeField]
		private List<RectTransform> _Containers;

		[SerializeField]
		private GameObject _ButtonsNoMap;

		[SerializeField]
		private GameObject _ButtonsHasMap;

		[SerializeField]
		private GameObject _Pager;

		[SerializeField]
		private PageManager _PageManager;

		[SerializeField]
		private GameObject _ContainerPrefab;

		[SerializeField]
		private RectTransform _ContainerContainer;

		[SerializeField]
		private CanvasGroup _CanvasGroup;

		[SerializeField]
		private float _DefaultAlpha;

		[SerializeField]
		private float _AlphaWhileArcanaInfoShown;

		private SignalBus _signalBus;

		private PlayerOptions _playerOptions;

		private DataManager _data;

		private GameSessionData _session;

		private List<Equipment> _equipment;

		private List<EvolutionItemUI> _evolutionItems;

		private Dictionary<WeaponType, List<WeaponData>> _weapons;

		private List<EvolutionData> _evolutionData;

		private List<WeaponType> _ownedWeapons;

		private List<GameObject> _spawned;

		private RectTransform _ActiveContainer;

		[Inject]
		private void Construct(SignalBus signal, PlayerOptions player, DataManager data, GameSessionData session)
		{
		}

		public void Init()
		{
		}

		public PageManager GetPageManager()
		{
			return null;
		}

		private void AddNewContainer()
		{
		}

		public void ReduceAlphaOnArcanaInfoShown()
		{
		}

		public void ResetToDefaultAlpha()
		{
		}

		private void SpawnWeapon(EvolutionData d)
		{
		}

		private void SpawnGenericLine(EvolutionData d)
		{
		}

		private void SpawnTriasso(EvolutionData d)
		{
		}

		private void CreateEvolutionList()
		{
		}

		private bool RequiresYellowSign(EvolutionData d)
		{
			return false;
		}

		private bool OwnsWeapon(WeaponType t)
		{
			return false;
		}

		private void Clear()
		{
		}
	}
}
