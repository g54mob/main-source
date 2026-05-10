using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.TechTree;
using CTS.Core;
using CTS.UI;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UsableFurnituresCategory : CTSBehaviour, IRepaint, ILocaleRepaint
	{
		private const string Group_Link = "Link Component";

		[Space(10f)]
		[SerializeField]
		[BoxGroup("Link Component")]
		private TMP_Text _categoryTitleComponent;

		[SerializeField]
		[BoxGroup("Link Component")]
		private Image _categoryIconComponent;

		[SerializeField]
		[BoxGroup("Link Component")]
		private GameObject _uiLockCover;

		[SerializeField]
		[BoxGroup("Link Component")]
		private UI_MachineMgr_MachinePanel _machinePanelPrefab;

		[SerializeField]
		[BoxGroup("Link Component")]
		private Transform _prefabContainer;

		[SerializeField]
		private CTSToggle _contentToggle;

		[InjectScope(EGetScope.Children)]
		[Inject(false)]
		private UI_MachineMgr_CategoryFeature[] _features;

		private LockToggle _toggleLock = new LockToggle();

		private readonly Stack<UI_MachineMgr_MachinePanel> _panelPool = new Stack<UI_MachineMgr_MachinePanel>();

		private readonly Dictionary<Furniture, UI_MachineMgr_MachinePanel> _currentFurnitures = new Dictionary<Furniture, UI_MachineMgr_MachinePanel>();

		private bool _initialized;

		public UsableFurnituresCategoriesSO CategoryData { get; private set; }

		protected override void OnAwake()
		{
			base.OnAwake();
			_toggleLock.Add(_contentToggle);
			if ((bool)CategoryData.TechTreeTechnologySO)
			{
				if (TechTreeManager.FirstLevelHasBeenResearched(CategoryData.TechTreeTechnologySO))
				{
					OnTechnologyResearched(CategoryData.TechTreeTechnologySO);
				}
				else
				{
					TechTreeManager.OnTechnologyResearched += OnTechnologyResearched;
				}
			}
			Furniture.FurniturePlaced += OnFurniturePlaced;
			Furniture.FurnitureDestroyed += OnFurnitureDestroyed;
			foreach (Furniture key in new Dictionary<Furniture, UI_MachineMgr_MachinePanel>(_currentFurnitures).Keys)
			{
				if (!key)
				{
					OnFurnitureDestroyed(key);
				}
			}
			foreach (FurnitureInteractor item in CTSSingleton<LevelParameters>.Instance.Furnitures.Enumerate<FurnitureInteractor>())
			{
				if (!(item.Furniture.Parameters != CategoryData.AssociatedFurniture) && !_currentFurnitures.ContainsKey(item.Furniture))
				{
					OnFurniturePlaced(item.Furniture);
				}
			}
		}

		private void OnDestroy()
		{
			TechTreeManager.OnTechnologyResearched -= OnTechnologyResearched;
			Furniture.FurniturePlaced -= OnFurniturePlaced;
			Furniture.FurnitureDestroyed -= OnFurnitureDestroyed;
		}

		public void AddFurniture(Furniture obj)
		{
			if (obj.Parameters != CategoryData.AssociatedFurniture || _currentFurnitures.ContainsKey(obj))
			{
				return;
			}
			if (obj.Interactor == null)
			{
				Debug.LogException(new NullReferenceException("Cannot create machine mgr machine as the furniture doesn't have an interactor"));
				return;
			}
			UI_MachineMgr_MachinePanel orCreatePanel = GetOrCreatePanel();
			_currentFurnitures[obj] = orCreatePanel;
			orCreatePanel.SetFurniture(obj.Interactor);
			orCreatePanel.gameObject.SetActive(value: true);
			_toggleLock.Unlock();
			if (_currentFurnitures.Count == 1)
			{
				_contentToggle.isOn = true;
			}
		}

		private void OnFurniturePlaced(Furniture obj)
		{
			AddFurniture(obj);
		}

		private void OnFurnitureDestroyed(Furniture obj)
		{
			if (obj.Parameters != CategoryData.AssociatedFurniture)
			{
				return;
			}
			if (_currentFurnitures.TryGetValue(obj, out var value))
			{
				value.SetFurniture(null);
				value.SetSyncing(value: false);
				value.gameObject.SetActive(value: false);
				_panelPool.Push(value);
				_currentFurnitures.Remove(obj);
			}
			if (_currentFurnitures.Count <= 0)
			{
				_toggleLock.Lock();
				if (_toggleLock.Locked)
				{
					_contentToggle.isOn = false;
				}
			}
		}

		private UI_MachineMgr_MachinePanel GetOrCreatePanel()
		{
			if (!_panelPool.TryPop(out var result))
			{
				return CTSFactory.Instantiate(_machinePanelPrefab, _prefabContainer, instantiateInWorldSpace: false, false);
			}
			return result;
		}

		public void Setup(UsableFurnituresCategoriesSO data)
		{
			CategoryData = data;
			UI_MachineMgr_CategoryFeature[] features = _features;
			for (int i = 0; i < features.Length; i++)
			{
				features[i].SetDefaultValues();
			}
			Repaint();
		}

		public void Repaint()
		{
			_categoryIconComponent.overrideSprite = CategoryData.CategoryIcon;
			RepaintLocale();
			RepaintLockCover();
			_toggleLock.SetLock(_currentFurnitures.Count <= 0);
			if (_toggleLock.Locked)
			{
				_contentToggle.isOn = false;
			}
			UI_MachineMgr_CategoryFeature[] features = _features;
			for (int i = 0; i < features.Length; i++)
			{
				features[i].Repaint();
			}
			RepaintFurnitures();
		}

		public void RepaintFurnitures()
		{
			foreach (KeyValuePair<Furniture, UI_MachineMgr_MachinePanel> currentFurniture in _currentFurnitures)
			{
				currentFurniture.Deconstruct(out var _, out var value);
				value.Repaint();
			}
		}

		public void RepaintLockCover()
		{
			if (CategoryData.ForceLock)
			{
				_uiLockCover.SetActive(value: true);
			}
			else if ((bool)CategoryData.TechTreeTechnologySO)
			{
				_uiLockCover.SetActive(!TechTreeManager.FirstLevelHasBeenResearched(CategoryData.TechTreeTechnologySO));
			}
			else
			{
				_uiLockCover.SetActive(value: false);
			}
		}

		private void OnTechnologyResearched(TechTreeTechnologySO itemSO)
		{
			if (!(itemSO != CategoryData.TechTreeTechnologySO))
			{
				Repaint();
			}
		}

		public void RepaintLocale()
		{
			_categoryTitleComponent.text = CategoryData.CategoryName.GetLocalizedStringSafe();
		}
	}
}
