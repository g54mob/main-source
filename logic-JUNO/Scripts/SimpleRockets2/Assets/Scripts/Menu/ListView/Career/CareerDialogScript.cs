using System;
using System.Collections;
using System.Collections.Generic;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Menu.ListView.Career
{
	public class CareerDialogScript : MonoBehaviour, IDialog, IListView
	{
		public const string ContractsViewID = "contracts";

		public const string ExplorationViewId = "exploration";

		private bool _closed;

		private Dictionary<string, Func<CareerViewModelBase>> _modelBuilders = new Dictionary<string, Func<CareerViewModelBase>>();

		private Dictionary<string, CareerViewModelBase> _models = new Dictionary<string, CareerViewModelBase>();

		private string _selectedId;

		private CareerViewModelBase _viewModel;

		private XmlLayout _xmlLayout;

		public bool AllowCameraZoom => false;

		public ContractsViewModel Contracts => GetModel("contracts") as ContractsViewModel;

		public ExplorationViewModel Exploration => GetModel("exploration") as ExplorationViewModel;

		public bool PreviewEnabled => false;

		public bool RequiresSceneReload { get; private set; }

		public string SelectedViewId => _selectedId;

		public event DialogDelegate Closed;

		public void Close()
		{
			foreach (CareerViewModelBase value in _models.Values)
			{
				value.OnClosed();
			}
			foreach (CareerViewModelBase value2 in _models.Values)
			{
				if (value2.RequiresSceneReload)
				{
					RequiresSceneReload = true;
					break;
				}
			}
			Game.Instance.GameState.Save();
			UnityEngine.Object.Destroy(base.gameObject);
			this.Closed?.Invoke(this);
		}

		public virtual void Initialize(bool allowChanges)
		{
			Game.Instance.UserInterface.RegisterDialog(this);
			_xmlLayout = base.gameObject.AddComponent<XmlLayout>();
			base.gameObject.AddComponent<XmlLayoutController>().EventTarget = this;
			Game.Instance.UserInterface.BuildUserInterfaceFromResource("Ui/Xml/Career/CareerDialog", _xmlLayout);
			_modelBuilders["contracts"] = () => new ContractsViewModel(allowChanges);
			_modelBuilders["milestones"] = () => new MilestonesViewModel();
			_modelBuilders["exploration"] = () => new ExplorationViewModel();
			StartCoroutine(LoadInitialViewModel());
		}

		private void BuildListView(string id)
		{
			Func<CareerViewModelBase> func = _modelBuilders[id];
			InitializeController(id, func());
		}

		private CareerViewModelBase GetModel(string id)
		{
			if (!_models.ContainsKey(id))
			{
				BuildListView(id);
			}
			return _models[id];
		}

		private T InitializeController<T>(string id, T viewModel) where T : CareerViewModelBase
		{
			XmlElement elementById = _xmlLayout.GetElementById("list-view-panel");
			GameObject obj = new GameObject(id, typeof(RectTransform));
			RectTransform component = obj.GetComponent<RectTransform>();
			component.SetParent(elementById.transform, worldPositionStays: false);
			component.anchorMin = Vector2.zero;
			component.anchorMax = Vector2.one;
			component.sizeDelta = Vector2.zero;
			XmlLayout xmlLayout = obj.AddComponent<XmlLayout>();
			ListViewChildController listViewChildController = obj.AddComponent<ListViewChildController>();
			Game.Instance.UserInterface.BuildUserInterfaceFromResource("Ui/Xml/Career/CareerListView", xmlLayout);
			_models[id] = viewModel;
			listViewChildController.Initialize(viewModel, this);
			viewModel.ListView.gameObject.SetActive(value: false);
			viewModel.ListView.Closed += OnListViewClosed;
			return viewModel;
		}

		private IEnumerator LoadInitialViewModel()
		{
			yield return new WaitForEndOfFrame();
			SelectViewModel("contracts");
		}

		private void OnCategoryClicked(XmlElement element)
		{
			SelectViewModel(element.internalId);
		}

		private void OnCloseButtonClicked()
		{
			Close();
		}

		private void OnListViewClosed(object sender, EventArgs e)
		{
			Close();
		}

		private void SelectViewModel(string id)
		{
			foreach (XmlElement item in _xmlLayout.GetElementsByClass("category"))
			{
				item.RemoveClass("selected");
				item.RemoveClass("btn-primary");
			}
			XmlElement elementByInternalId = _xmlLayout.XmlElement.GetElementByInternalId(id);
			elementByInternalId.AddClass("selected");
			elementByInternalId.AddClass("btn-primary");
			_selectedId = id;
			CareerViewModelBase model = GetModel(id);
			if (_viewModel != null)
			{
				_viewModel.ListView.gameObject.SetActive(value: false);
			}
			_viewModel = model;
			if (_viewModel != null)
			{
				_viewModel.ListView.gameObject.SetActive(value: true);
			}
		}
	}
}
