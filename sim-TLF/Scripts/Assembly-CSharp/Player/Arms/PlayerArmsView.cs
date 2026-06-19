using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Observables;
using Loxodon.Framework.Views;
using UnityEngine;

namespace Player.Arms
{
	public class PlayerArmsView : View
	{
		[SerializeField]
		private GameObject _metalCan;

		[SerializeField]
		private GameObject _glassBottle;

		[SerializeField]
		private GameObject _drill;

		[SerializeField]
		private GameObject _spanner;

		[SerializeField]
		private GameObject _screw;

		[SerializeField]
		private GameObject _ratchet;

		[SerializeField]
		private GameObject _canister;

		[SerializeField]
		private GameObject _flareGun;

		private ObservableProperty<bool> _glassBottleEnabled = new ObservableProperty<bool>(value: false);

		private void Start()
		{
			PlayerArmsViewModel service = Context.GetApplicationContext().GetService<PlayerArmsViewModel>();
			this.BindingContext().DataContext = service;
			BindingSet<PlayerArmsView, PlayerArmsViewModel> bindingSet = this.CreateBindingSet<PlayerArmsView, PlayerArmsViewModel>();
			bindingSet.Bind(_glassBottle).For((GameObject v) => v.activeSelf).To((PlayerArmsViewModel vm) => vm.GlassBottleEnabled)
				.OneWay();
			bindingSet.Bind(_metalCan).For((GameObject v) => v.activeSelf).To((PlayerArmsViewModel vm) => vm.MetalCanEnabled)
				.OneWay();
			bindingSet.Bind(_drill).For((GameObject v) => v.activeSelf).To((PlayerArmsViewModel vm) => vm.DrillEnabled)
				.OneWay();
			bindingSet.Bind(_spanner).For((GameObject v) => v.activeSelf).To((PlayerArmsViewModel vm) => vm.SpannerEnabled)
				.OneWay();
			bindingSet.Bind(_screw).For((GameObject v) => v.activeSelf).To((PlayerArmsViewModel vm) => vm.ScrewEnabled)
				.OneWay();
			bindingSet.Bind(_ratchet).For((GameObject v) => v.activeSelf).To((PlayerArmsViewModel vm) => vm.RatchetEnabled)
				.OneWay();
			bindingSet.Bind(_canister).For((GameObject v) => v.activeSelf).To((PlayerArmsViewModel vm) => vm.CanisterEnabled)
				.OneWay();
			bindingSet.Bind(_flareGun).For((GameObject v) => v.activeSelf).To((PlayerArmsViewModel vm) => vm.FlareGunEnabled)
				.OneWay();
			bindingSet.Build();
		}
	}
}
