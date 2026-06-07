using System.Collections.Generic;
using Data.Operator;
using Presentation.UI;
using Presentation.UI.Toolbar;
using UnityEngine;

namespace Presentation.FactoryFloor.Toolbar
{
	public class OperatorBar : AbstractOperatorBar
	{
		[SerializeField]
		private RectTransform _buttonParent;

		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private GameObject _dividerPrefab;

		[SerializeField]
		private Transform _shortcutGroupPrefab;

		private bool _hasBuiltOperatorBar;

		private readonly List<GameObject> _instantiatedGameObjects = new List<GameObject>();

		private readonly List<ToolBarButtonShortcut> _toolbarButtonShortcuts = new List<ToolBarButtonShortcut>();

		private OperatorBarDatabase _operatorBarData;

		protected override void InitalizeInternal()
		{
			InitOperatorBar();
			_factoryObjectDatabase.OperatorBarDatabaseCollection.OnRefresh += InitOperatorBar;
		}

		private void OnDestroy()
		{
			_factoryObjectDatabase.OperatorBarDatabaseCollection.OnRefresh -= InitOperatorBar;
			DestroyOperatorBar();
		}

		private void InitOperatorBar()
		{
			switch (base.BuildMode)
			{
			case BuildMode.Operators:
				_operatorBarData = _factoryObjectDatabase.OperatorBarDatabaseCollection.OperatorBarData;
				break;
			case BuildMode.Cosmetics:
				_operatorBarData = _factoryObjectDatabase.OperatorBarDatabaseCollection.CosmeticsBarData;
				break;
			case BuildMode.Cosmetics2:
				_operatorBarData = _factoryObjectDatabase.OperatorBarDatabaseCollection.CosmeticsBar2Data;
				break;
			case BuildMode.Dev:
				_operatorBarData = _factoryObjectDatabase.OperatorBarDatabaseCollection.DevBarData;
				break;
			}
			BuildOperatorBar();
		}

		public override void Show()
		{
			base.gameObject.SetActive(value: true);
		}

		public override void Hide()
		{
			if (!_hasBuiltOperatorBar)
			{
				InitOperatorBar();
			}
			base.gameObject.SetActive(value: false);
		}

		private void BuildOperatorBar()
		{
			if (_hasBuiltOperatorBar)
			{
				DestroyOperatorBar();
			}
			for (int i = 0; i < _operatorBarData.OperatorBarCategories.Count; i++)
			{
				BuildCategory(_operatorBarData.OperatorBarCategories[i], i == 0);
			}
			_hasBuiltOperatorBar = true;
		}

		private void DestroyOperatorBar()
		{
			foreach (ToolBarButtonShortcut toolbarButtonShortcut in _toolbarButtonShortcuts)
			{
				toolbarButtonShortcut.UnInit();
			}
			_toolbarButtonShortcuts.Clear();
			for (int num = _instantiatedGameObjects.Count - 1; num >= 0; num--)
			{
				Object.Destroy(_instantiatedGameObjects[num]);
			}
			_instantiatedGameObjects.Clear();
			_hasBuiltOperatorBar = false;
		}

		private void BuildCategory(OperatorBarCategory operatorButtons, bool first)
		{
			if (!first)
			{
				_instantiatedGameObjects.Add(Object.Instantiate(_dividerPrefab, _buttonParent));
			}
			Transform transform = _buttonParent;
			for (int i = 0; i < operatorButtons.OperatorBarButtonActivators.Count; i++)
			{
				OperatorBarButtonSO operatorBarButton = operatorButtons.OperatorBarButtonActivators[i].OperatorBarButton;
				if (!operatorBarButton.PartOfInputActionGroup || (operatorBarButton.PartOfInputActionGroup && operatorBarButton.IsGroupStart))
				{
					transform = Object.Instantiate(_shortcutGroupPrefab, _buttonParent);
					_instantiatedGameObjects.Add(transform.gameObject);
				}
				OperatorBarButton operatorBarButton2 = Object.Instantiate(operatorBarButton.Prefab, transform);
				operatorBarButton2.GetComponentInChildren<ButtonShortCut>()?.Init();
				ToolBarButtonShortcut componentInChildren = operatorBarButton2.GetComponentInChildren<ToolBarButtonShortcut>();
				if (componentInChildren != null)
				{
					componentInChildren.Init();
					_toolbarButtonShortcuts.Add(componentInChildren);
				}
				operatorBarButton2.GetComponentInChildren<ToolBarButton>()?.Init(operatorBarButton, base.BuildMode);
				operatorBarButton2.SetColor(operatorButtons.CategoryColor);
				operatorBarButton2.SetActive(operatorButtons.OperatorBarButtonActivators[i].IsActive);
				_instantiatedGameObjects.Add(operatorBarButton2.gameObject);
			}
		}
	}
}
