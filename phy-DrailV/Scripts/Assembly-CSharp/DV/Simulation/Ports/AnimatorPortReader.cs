using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Ports
{
	public class AnimatorPortReader : MonoBehaviour
	{
		public enum UpdateType
		{
			SET_NORMALIZED_TIME = 0,
			SET_PARAMETER = 1
		}

		public UpdateType updateType;

		[PortId(null, null, false)]
		public string portId;

		public string parameterName;

		[Header("Value modifiers")]
		public float valueMultiplier = 1f;

		public float valueOffset;

		private Animator animator;

		private int propertyHash;

		private Port port;

		public void Init(Port port)
		{
			animator = GetComponent<Animator>();
			if (animator == null)
			{
				Debug.LogError("Can't find Animator on " + base.gameObject.name + ". Ignoring init");
				return;
			}
			propertyHash = Animator.StringToHash(parameterName);
			this.port = port;
			OnValueUpdate(port.Value);
			port.ValueUpdatedInternally += OnValueUpdate;
		}

		public void Deinit()
		{
			if (port != null)
			{
				port.ValueUpdatedInternally -= OnValueUpdate;
			}
		}

		private void OnValueUpdate(float newValue)
		{
			float num = newValue * valueMultiplier + valueOffset;
			switch (updateType)
			{
			case UpdateType.SET_NORMALIZED_TIME:
				animator.Play(0, -1, num.FloorMod(1f));
				break;
			case UpdateType.SET_PARAMETER:
				animator.SetFloat(propertyHash, num);
				break;
			}
		}
	}
}
