using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Views;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Sites.MapCom
{
	public class MapComView : UIView
	{
		[SerializeField]
		private Button _setDestinationButton;

		[Inject]
		private DiContainer _diContainer;

		protected override void Awake()
		{
			base.Awake();
		}

		protected override void Start()
		{
			BindingSet<MapComView, MapComViewModel> bindingSet = this.CreateBindingSet<MapComView, MapComViewModel>();
			MapComViewModel mapComViewModel = new MapComViewModel();
			_diContainer.Inject(mapComViewModel);
			this.SetDataContext(mapComViewModel);
			bindingSet.Bind(_setDestinationButton).For((Button v) => v.onClick).To((MapComViewModel vm) => vm.SetDestinationCommand)
				.OneWay();
			bindingSet.Build();
		}
	}
}
