using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public abstract class UI_MachineMgr_MachinePanelFeature : CTSBehaviour
	{
		[SerializeField]
		private GameObject _syncLock;

		protected FurnitureInteractor _furniture { get; private set; }

		public void SetFurniture(FurnitureInteractor furniture)
		{
			if (!(furniture == _furniture))
			{
				if ((bool)_furniture && CanBeDisplayedForFurniture(_furniture))
				{
					OnFurnitureUnset(_furniture);
				}
				_furniture = furniture;
				if ((bool)_furniture && CanBeDisplayedForFurniture(_furniture))
				{
					base.gameObject.SetActive(value: true);
					OnFurnitureSet(_furniture);
					Repaint();
				}
				else
				{
					base.gameObject.SetActive(value: false);
				}
			}
		}

		public abstract bool CanBeDisplayedForFurniture(FurnitureInteractor furniture);

		protected abstract void OnFurnitureSet(FurnitureInteractor furniture);

		protected abstract void OnFurnitureUnset(FurnitureInteractor furniture);

		public void Repaint()
		{
			RepaintSync();
			OnRepaint();
		}

		public void RepaintSync()
		{
			if ((bool)_syncLock)
			{
				if (!_furniture)
				{
					_syncLock.SetActive(value: true);
				}
				else
				{
					_syncLock.SetActive((bool)_furniture.Syncing && _furniture.Syncing.IsSynced);
				}
			}
		}

		protected abstract void OnRepaint();
	}
	public abstract class UI_MachineMgr_MachinePanelFeature<TFurniture> : UI_MachineMgr_MachinePanelFeature where TFurniture : class
	{
		protected TFurniture _currentFurniture => base._furniture as TFurniture;

		public sealed override bool CanBeDisplayedForFurniture(FurnitureInteractor furniture)
		{
			if (furniture is TFurniture furniture2)
			{
				return CanBeDisplayedForFurniture(furniture2);
			}
			return false;
		}

		protected sealed override void OnFurnitureSet(FurnitureInteractor furniture)
		{
			if (furniture is TFurniture furniture2)
			{
				OnFurnitureSet(furniture2);
			}
		}

		protected sealed override void OnFurnitureUnset(FurnitureInteractor furniture)
		{
			if (furniture is TFurniture furniture2)
			{
				OnFurnitureUnset(furniture2);
			}
		}

		protected abstract bool CanBeDisplayedForFurniture(TFurniture furniture);

		protected abstract void OnFurnitureSet(TFurniture furniture);

		protected abstract void OnFurnitureUnset(TFurniture furniture);
	}
}
