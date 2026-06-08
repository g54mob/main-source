using Timberborn.BaseComponentSystem;
using Timberborn.Illumination;
using Timberborn.MechanicalSystem;
using Timberborn.TickSystem;

namespace Timberborn.MechanicalSystemUI
{
	public class MechanicalNodeIlluminator : TickableComponent, IAwakableComponent
	{
		private IlluminatorToggle _illuminatorToggle;

		private MechanicalNode _mechanicalNode;

		private bool _wasEnabled;

		public void Awake()
		{
			_illuminatorToggle = GetComponent<Illuminator>().CreateToggle();
			_mechanicalNode = GetComponent<MechanicalNode>();
		}

		public override void StartTickable()
		{
			UpdateIllumination();
		}

		public override void Tick()
		{
			UpdateIllumination();
		}

		private void UpdateIllumination()
		{
			bool activeAndPowered = _mechanicalNode.ActiveAndPowered;
			if (activeAndPowered != _wasEnabled)
			{
				ToggleIllumination(activeAndPowered);
				_wasEnabled = activeAndPowered;
			}
		}

		private void ToggleIllumination(bool isEnabled)
		{
			if (isEnabled)
			{
				_illuminatorToggle.TurnOn();
			}
			else
			{
				_illuminatorToggle.TurnOff();
			}
		}
	}
}
