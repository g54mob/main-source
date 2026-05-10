using CTS.BBT;
using CTS.BBT.TechTree;
using CTS.Core;
using CTS.UI;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class UI_FurnitureTechTree : CTSBehaviour
	{
		[SerializeField]
		[BoxGroup("Link GameObjects")]
		private GameObject _lockCover;

		[SerializeField]
		[BoxGroup("Link GameObjects")]
		private GameObject[] _contentGameObjects;

		[SerializeField]
		[BoxGroup("Link GameObjects")]
		private SoftReference<TechTreeTechnologySO> _technologySO;

		private CTSToggle _buyButton;

		protected override void OnAwake()
		{
			_buyButton = base.gameObject.GetComponent<CTSToggle>();
		}

		protected override void OnEnabled()
		{
			if (TechTreeManager.FirstLevelHasBeenResearched(_technologySO))
			{
				OnTechnologyResearched(_technologySO);
			}
			else
			{
				TechTreeManager.OnTechnologyResearched += OnTechnologyResearched;
			}
		}

		private void Start()
		{
			if (!_technologySO.Value)
			{
				IsLock(value: false);
			}
			else
			{
				IsLock(!TechTreeManager.FirstLevelHasBeenResearched(_technologySO.Value));
			}
		}

		protected override void OnDisabled()
		{
			TechTreeManager.OnTechnologyResearched -= OnTechnologyResearched;
		}

		private void IsLock(bool value)
		{
			if (_lockCover.activeSelf != value)
			{
				GetComponentInParent<FurnitureShopPopulator>()?.ReorderBy(E_OrderSort.ByTagAndStyle);
				_lockCover.SetActive(value);
				_buyButton.enabled = !value;
				GameObject[] contentGameObjects = _contentGameObjects;
				for (int i = 0; i < contentGameObjects.Length; i++)
				{
					contentGameObjects[i].SetActive(!value);
				}
			}
		}

		private void OnTechnologyResearched(TechTreeTechnologySO itemSO)
		{
			if (!(_technologySO.Value != itemSO))
			{
				IsLock(value: false);
				TechTreeManager.OnTechnologyResearched -= OnTechnologyResearched;
			}
		}
	}
}
