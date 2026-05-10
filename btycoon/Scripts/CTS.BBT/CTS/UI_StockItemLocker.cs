using CTS.BBT;
using CTS.BBT.TechTree;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class UI_StockItemLocker : CTSBehaviour
	{
		[SerializeField]
		[BoxGroup("Link GameObjects")]
		protected GameObject _lockGameObject;

		[SerializeField]
		private SoftReference<StockItemSO> _itemToCheck;

		[SerializeField]
		protected bool _showTargetOnLock = true;

		protected StockItemSO _itemSO;

		protected override void OnEnabled()
		{
			TechTreeManager.OnTechnologyResearched += OnTechnologyResearched;
			UpdateVisual();
		}

		private void Start()
		{
			_itemSO = _itemToCheck.Get();
			UpdateVisual();
		}

		protected override void OnDisabled()
		{
			TechTreeManager.OnTechnologyResearched -= OnTechnologyResearched;
		}

		protected virtual bool IsLocked()
		{
			if (_itemToCheck.Get().ForceLockInStore)
			{
				return true;
			}
			if ((bool)_itemSO.TechTreeTechnologyRequiered)
			{
				return !TechTreeManager.FirstLevelHasBeenResearched(_itemSO.TechTreeTechnologyRequiered);
			}
			return false;
		}

		protected virtual void UpdateVisual()
		{
			if (!(_itemSO == null))
			{
				if (!IsLocked())
				{
					_lockGameObject.SetActive(!_showTargetOnLock);
				}
				else
				{
					_lockGameObject.SetActive(_showTargetOnLock);
				}
			}
		}

		private void OnTechnologyResearched(TechTreeTechnologySO itemSO)
		{
			if (!(_itemSO.TechTreeTechnologyRequiered != itemSO))
			{
				UpdateVisual();
			}
		}
	}
}
