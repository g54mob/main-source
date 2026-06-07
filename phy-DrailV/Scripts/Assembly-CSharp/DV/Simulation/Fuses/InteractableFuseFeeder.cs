using DV.CabControls;
using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Fuses
{
	public class InteractableFuseFeeder : MonoBehaviour
	{
		[FuseId]
		public string fuseId;

		private ControlImplBase ctrl;

		private Fuse fuse;

		public void Init(Fuse fuse)
		{
			ctrl = base.gameObject.GetComponent<ControlImplBase>();
			if (ctrl == null)
			{
				Debug.LogError("Can't find ControlImplBase on " + base.gameObject.name + ". Ignoring init");
				return;
			}
			this.fuse = fuse;
			ctrl.SetValue(fuse.State ? 1f : 0f);
			fuse.StateUpdated += PropagateSimValue;
		}

		public void Deinit()
		{
			if (fuse != null)
			{
				fuse.StateUpdated -= PropagateSimValue;
				ctrl.ValueChanged -= OnControlChange;
			}
		}

		public void SetupInputChangedListeners()
		{
			if (fuse != null)
			{
				ctrl.ValueChanged += OnControlChange;
			}
		}

		private void PropagateSimValue(bool newFuseValue)
		{
			float num = (newFuseValue ? 1f : 0f);
			if (ctrl.Value != num)
			{
				ctrl.SetValue(num);
			}
		}

		private void OnControlChange(ValueChangedEventArgs v)
		{
			fuse.ChangeState(v.newValue > 0.5f);
		}
	}
}
