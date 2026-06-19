using System.Collections.Specialized;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Observables;
using Loxodon.Framework.Views;
using UnityEngine;
using Zenject;

namespace UI.Sites.SkyHigh
{
	public class InProgressDeliveriesView : UIView
	{
		[SerializeField]
		private OrderBlockView _orderBlockPrefab;

		[SerializeField]
		private Transform _blocksParent;

		private InProgressDeliveriesViewModel _viewModel;

		private ObservableList<OrderBlockViewModel> _orderBlocks = new ObservableList<OrderBlockViewModel>();

		[Inject]
		private readonly DiContainer _diContainer;

		protected override void Awake()
		{
			CreateBinding();
		}

		protected override void Start()
		{
			_viewModel.SyncWithOrders();
		}

		public void CreateBinding()
		{
			BindingSet<InProgressDeliveriesView, InProgressDeliveriesViewModel> bindingSet = this.CreateBindingSet<InProgressDeliveriesView, InProgressDeliveriesViewModel>();
			_viewModel = _diContainer.Instantiate<InProgressDeliveriesViewModel>();
			this.SetDataContext(_viewModel);
			bindingSet.Bind(this).For((InProgressDeliveriesView v) => v._orderBlocks).To((InProgressDeliveriesViewModel vm) => vm.OrderBlocks)
				.OneWay();
			bindingSet.Build();
			_orderBlocks.CollectionChanged += OrderBlocksChanged;
		}

		private void OrderBlocksChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
				SpawnNewOrderBlock(e.NewItems[0] as OrderBlockViewModel);
				break;
			case NotifyCollectionChangedAction.Reset:
				ClearBlocks();
				break;
			case NotifyCollectionChangedAction.Remove:
			case NotifyCollectionChangedAction.Replace:
			case NotifyCollectionChangedAction.Move:
				break;
			}
		}

		private void SpawnNewOrderBlock(OrderBlockViewModel orderBlockVM)
		{
			OrderBlockView orderBlockView = Object.Instantiate(_orderBlockPrefab, _blocksParent);
			orderBlockView.SetDataContext(orderBlockVM);
			orderBlockView.CreateBinding();
		}

		private void ClearBlocks()
		{
			foreach (Transform item in _blocksParent)
			{
				item.gameObject.SetActive(value: false);
			}
		}

		private void Update()
		{
			foreach (OrderBlockViewModel orderBlock in _orderBlocks)
			{
				orderBlock.EvaluateProgress();
			}
		}
	}
}
