using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class MachineConveyorBelt : MonoBehaviour
	{
		[SerializeField]
		private MachineBase _machine;

		[SerializeField]
		private VFXBehavior _behavior;

		[SerializeField]
		private float _loadSpeed;

		[SerializeField]
		private float _unloadSpeed;

		private void OnEnable()
		{
			_machine.LoadingStateChanging += StartConveyorBelt;
			_machine.LoadingStateChanged += StopConveyorBelt;
		}

		private void OnDisable()
		{
			_machine.LoadingStateChanging -= StartConveyorBelt;
			_machine.LoadingStateChanged -= StopConveyorBelt;
		}

		public void StartConveyorBelt(bool start)
		{
			foreach (ShaderParameterIncrementor item in _behavior.Updaters<ShaderParameterIncrementor>())
			{
				item.IncrementSpeed = (start ? _loadSpeed : _unloadSpeed);
				item.Enabled = true;
			}
		}

		public void StopConveyorBelt(bool start)
		{
			foreach (ShaderParameterIncrementor item in _behavior.Updaters<ShaderParameterIncrementor>())
			{
				item.Enabled = false;
			}
		}

		public void SetConveyorBelt(float speed)
		{
			foreach (ShaderParameterIncrementor item in _behavior.Updaters<ShaderParameterIncrementor>())
			{
				item.IncrementSpeed = speed;
				item.Enabled = true;
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public void ToggleConveyorBelt()
		{
			if (_behavior.TryGetUpdater<ShaderParameterIncrementor>(out var outUpdater))
			{
				outUpdater.Enabled = !outUpdater.Enabled;
			}
		}
	}
}
