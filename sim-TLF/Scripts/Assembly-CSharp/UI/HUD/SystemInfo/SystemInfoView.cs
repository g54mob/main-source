using System.Collections.Specialized;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Observables;
using Loxodon.Framework.Views;
using UnityEngine;
using Zenject;

namespace UI.HUD.SystemInfo
{
	public class SystemInfoView : UIView
	{
		[SerializeField]
		private SystemInfoMessageView _messagePrefab;

		[SerializeField]
		private Transform _messagesParent;

		private ObservableList<SystemInfoMessageViewModel> _messages = new ObservableList<SystemInfoMessageViewModel>();

		private SystemInfoViewModel _viewModel;

		[Inject]
		private DiContainer _diContainer;

		protected override void Awake()
		{
			_viewModel = new SystemInfoViewModel();
		}

		protected override void Start()
		{
			BindingSet<SystemInfoView, SystemInfoViewModel> bindingSet = this.CreateBindingSet<SystemInfoView, SystemInfoViewModel>();
			this.SetDataContext(_viewModel);
			bindingSet.Bind(this).For((SystemInfoView v) => v._messages).To((SystemInfoViewModel vm) => vm.Messages)
				.OneWay();
			bindingSet.Build();
			_messages.CollectionChanged += MessahesCollectionChanged;
		}

		private void MessahesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
				SpawnNewMessage(e.NewItems[0] as SystemInfoMessageViewModel);
				break;
			case NotifyCollectionChangedAction.Remove:
			case NotifyCollectionChangedAction.Replace:
			case NotifyCollectionChangedAction.Move:
			case NotifyCollectionChangedAction.Reset:
				break;
			}
		}

		private void SpawnNewMessage(SystemInfoMessageViewModel systemInfoMessageViewModel)
		{
			SystemInfoMessageView systemInfoMessageView = _diContainer.InstantiatePrefabForComponent<SystemInfoMessageView>(_messagePrefab, _messagesParent);
			systemInfoMessageView.SetDataContext(systemInfoMessageViewModel);
			systemInfoMessageView.CreateBinding();
			systemInfoMessageViewModel.StartTimer();
		}
	}
}
