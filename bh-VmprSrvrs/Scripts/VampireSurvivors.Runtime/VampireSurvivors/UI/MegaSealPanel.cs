using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class MegaSealPanel : MonoBehaviour
	{
		[SerializeField]
		private GameObject _DLCSealPrefab;

		private PlayerOptions _playerOptions;

		private CollectionsPage _page;

		private List<DLCSealItem> _dlcSealItems;

		public bool IsAvailable => false;

		[Inject]
		private void Construct(PlayerOptions player)
		{
		}

		private void Start()
		{
		}

		public void TryShow()
		{
		}

		public void Initialize(CollectionsPage page)
		{
		}

		private void SpawnDLC(ContentGroupType group)
		{
		}

		public void SetBanished(ContentGroupType t, bool isBanished, bool playSound, bool updatePage = true)
		{
		}

		public void UnsealAll(bool playSound = true)
		{
		}

		private bool IsBanished(ContentGroupType group)
		{
			return false;
		}
	}
}
