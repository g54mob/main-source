using UnityEngine;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors
{
	public class AdventureInfoPanel : MonoBehaviour
	{
		[SerializeField]
		private GameObject SpritePrefab;

		[SerializeField]
		private MultipleLineHorizontalList CharacterContainer;

		[SerializeField]
		private MultipleLineHorizontalList WeaponContainer;

		private AdventureData _currentData;

		private AdventureType _currentType;

		private DataManager _data;

		private PlayerOptions _playerOptions;

		private bool _shouldUpdateFormatting;

		[Inject]
		private void Construct(DataManager data, PlayerOptions player)
		{
		}

		public void SetData(AdventureType type)
		{
		}

		public void Hide()
		{
		}

		public void Show()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
