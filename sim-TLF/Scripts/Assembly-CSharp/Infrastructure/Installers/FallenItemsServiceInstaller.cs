using AssembleSystem.FallenItems;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
	public class FallenItemsServiceInstaller : MonoInstaller
	{
		[Tooltip("Where fallen items are respawned.")]
		[SerializeField]
		private Transform _dumpsterPoint;

		[Tooltip("Items whose world Y drops below this value are returned to the dumpster.")]
		[SerializeField]
		private float _fallThreshold = -50f;

		[Tooltip("Seconds between checks. Keep above zero to avoid per-frame cost.")]
		[SerializeField]
		private float _checkInterval = 1f;

		[Tooltip("Vertical offset per item so several rescued items don't overlap.")]
		[SerializeField]
		private float _stackSpacing = 0.5f;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<FallenItemsService>().AsSingle().WithArguments(_dumpsterPoint, _fallThreshold, _checkInterval, _stackSpacing);
		}
	}
}
