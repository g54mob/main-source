using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class MachineLoadCrime : FurnitureCrime
	{
		[InjectScope(EGetScope.Parent)]
		[SerializeField]
		[Inject(false)]
		private MachineBase _machine;

		protected override void OnAwake()
		{
			base.OnAwake();
			_machine.LoadingStateChanged += OnLoadingStateChanged;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_machine.LoadingStateChanged -= OnLoadingStateChanged;
		}

		private void OnLoadingStateChanged(bool loaded)
		{
			base.gameObject.SetActive(loaded && _furniture.Controller.IsPlaced);
		}

		protected override void OnPlacementChanged(bool placed)
		{
			base.gameObject.SetActive(placed && _machine.HasAVictim);
		}
	}
}
