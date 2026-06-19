using Pinwheel.Jupiter;
using Services.Save.Time;
using Services.Time;
using UnityEngine;
using Zenject;

namespace Installers
{
	public class TimeServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private JDayNightCycle _dayNightCycle;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<TimeService>().AsSingle().WithArguments(_dayNightCycle);
			base.Container.BindInterfacesAndSelfTo<TimeSaveService>().FromNew().AsSingle()
				.NonLazy();
		}
	}
}
