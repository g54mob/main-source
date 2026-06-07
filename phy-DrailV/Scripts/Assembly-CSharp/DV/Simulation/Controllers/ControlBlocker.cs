using System;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class ControlBlocker : MonoBehaviour
	{
		[Serializable]
		public class BlockerDefinition
		{
			public enum BlockType
			{
				BLOCK_ON_ABOVE_THRESHOLD = 0,
				BLOCK_ON_BELOW_THRESHOLD = 1,
				BLOCK_ON_EQUAL_TO_THRESHOLD = 2
			}

			[PortId(null, null, false)]
			public string blockerPortId;

			public float thresholdValue;

			public BlockType blockType;

			[NonSerialized]
			public bool isBlocked;

			private Port blockerPort;

			public event Action BlockStateChanged;

			public void Init(SimulationFlow simFlow)
			{
				if (!simFlow.TryGetPort(blockerPortId, out blockerPort))
				{
					Debug.LogError("BlockerDefinition isn't initialized properly");
					return;
				}
				OnValueUpdate(blockerPort.Value);
				blockerPort.ValueUpdatedInternally += OnValueUpdate;
			}

			public void Deinit()
			{
				if (blockerPort != null)
				{
					blockerPort.ValueUpdatedInternally -= OnValueUpdate;
				}
			}

			private void OnValueUpdate(float newValue)
			{
				bool flag = false;
				switch (blockType)
				{
				case BlockType.BLOCK_ON_ABOVE_THRESHOLD:
					flag = newValue > thresholdValue;
					break;
				case BlockType.BLOCK_ON_BELOW_THRESHOLD:
					flag = newValue < thresholdValue;
					break;
				case BlockType.BLOCK_ON_EQUAL_TO_THRESHOLD:
					flag = newValue == thresholdValue;
					break;
				default:
					Debug.LogError(string.Format("Unexpected state: Unhandled {0} - {1}. Ignoring request", "BlockType", blockType));
					return;
				}
				if (flag != isBlocked)
				{
					isBlocked = flag;
					this.BlockStateChanged?.Invoke();
				}
			}
		}

		[PortId(PortType.EXTERNAL_IN, PortValueType.CONTROL, true)]
		public string blockedControlPortId;

		public bool resetToZeroOnBlock;

		public BlockerDefinition[] blockers;

		private bool muSlaveBlock;

		private bool muPropagatedBlock;

		[NonSerialized]
		public bool isBlocked;

		public bool MUSlaveBlock
		{
			get
			{
				return muSlaveBlock;
			}
			set
			{
				if (muSlaveBlock != value)
				{
					muSlaveBlock = value;
					OnBlockersChanged();
				}
			}
		}

		public bool MUPropagatedBlock
		{
			get
			{
				return muPropagatedBlock;
			}
			set
			{
				if (muPropagatedBlock != value)
				{
					muPropagatedBlock = value;
					OnBlockersChanged();
				}
			}
		}

		public bool BlockedByBlockersDefinition { get; private set; }

		public event Action<bool> BlockedByBlockersDefinitionChanged;

		public event Action<bool, bool> BlockStateChanged;

		private void OnBlockersChanged()
		{
			bool flag = false;
			BlockerDefinition[] array = blockers;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].isBlocked)
				{
					flag = true;
					break;
				}
			}
			if (BlockedByBlockersDefinition != flag)
			{
				BlockedByBlockersDefinition = flag;
				this.BlockedByBlockersDefinitionChanged?.Invoke(flag);
			}
			flag = flag || MUSlaveBlock || MUPropagatedBlock;
			if (isBlocked != flag)
			{
				isBlocked = flag;
				this.BlockStateChanged?.Invoke(isBlocked, resetToZeroOnBlock);
			}
		}

		public void Init(SimulationFlow simFlow)
		{
			if (!simFlow.TryGetPort(blockedControlPortId, out var _))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: ControlBlocker isn't initialized properly");
				return;
			}
			BlockerDefinition[] array = blockers;
			foreach (BlockerDefinition obj in array)
			{
				obj.BlockStateChanged += OnBlockersChanged;
				obj.Init(simFlow);
			}
		}

		public void Deinit()
		{
			BlockerDefinition[] array = blockers;
			foreach (BlockerDefinition obj in array)
			{
				obj.BlockStateChanged -= OnBlockersChanged;
				obj.Deinit();
			}
		}
	}
}
