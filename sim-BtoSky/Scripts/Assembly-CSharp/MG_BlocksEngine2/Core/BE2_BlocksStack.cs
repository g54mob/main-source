using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace MG_BlocksEngine2.Core
{
	public class BE2_BlocksStack : MonoBehaviour, I_BE2_BlocksStack
	{
		private int _arrayLength;

		private bool _isActive;

		private bool _isStepPlay;

		public int Pointer { get; set; }

		public I_BE2_Instruction[] InstructionsArray { get; set; }

		public I_BE2_TargetObject TargetObject { get; set; }

		public I_BE2_Instruction TriggerInstruction { get; set; }

		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				if (!IsActive && value)
				{
					if (!_isStepPlay)
					{
						int num = InstructionsArray.Length;
						for (int i = 0; i < num; i++)
						{
							InstructionsArray[i].InstructionBase.OnStackActive();
						}
					}
					_isStepPlay = false;
					I_BE2_Instruction[] instructionsArray = InstructionsArray;
					for (int j = 0; j < instructionsArray.Length; j++)
					{
						instructionsArray[j].InstructionBase.Block.SetShadowActive(value: true);
					}
				}
				else if (IsActive && !value)
				{
					I_BE2_Instruction[] instructionsArray = InstructionsArray;
					for (int j = 0; j < instructionsArray.Length; j++)
					{
						instructionsArray[j].InstructionBase.Block.SetShadowActive(value: false);
					}
				}
				_isActive = value;
			}
		}

		public UnityEvent OnStackStart { get; set; } = new UnityEvent();

		public UnityEvent OnStackLastBlockExecuted { get; set; } = new UnityEvent();

		public UnityEvent<I_BE2_Instruction> OnFunctionStart { get; set; } = new UnityEvent<I_BE2_Instruction>();

		public int OverflowGuard { get; set; }

		public bool IsStepPlay => _isStepPlay;

		private void Awake()
		{
			TriggerInstruction = GetComponent<I_BE2_Instruction>();
			IsActive = false;
		}

		private void Start()
		{
			PopulateStack();
		}

		private void OnEnable()
		{
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPrimaryKeyUpEnd, PopulateStack);
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnStop, StopStack);
			if (TargetObject != null)
			{
				BE2_ExecutionManager.Instance.AddToBlocksStackArray(this, TargetObject);
			}
		}

		private void OnDisable()
		{
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnPrimaryKeyUpEnd, PopulateStack);
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnStop, StopStack);
			BE2_ExecutionManager.Instance?.RemoveFromBlocksStackList(this);
		}

		private void StopStack()
		{
			Pointer = 0;
			IsActive = false;
		}

		public void Execute()
		{
			if (IsActive && _arrayLength > Pointer)
			{
				if (Pointer == 0)
				{
					I_BE2_Block block = TriggerInstruction.InstructionBase.Block;
					BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypesBlock.OnStackExecutionStart, block);
				}
				I_BE2_Instruction i_BE2_Instruction = InstructionsArray[Pointer];
				OnFunctionStart.Invoke(i_BE2_Instruction);
				i_BE2_Instruction.Function();
				OverflowGuard = 0;
			}
			if (InstructionsArray != null && Pointer == InstructionsArray.Length && InstructionsArray.Length != 0)
			{
				I_BE2_Block block2 = InstructionsArray[InstructionsArray.Length - 1].InstructionBase.Block;
				BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypesBlock.OnStackExecutionEnd, block2);
				Pointer = 0;
				IsActive = false;
			}
		}

		public void StepPlay()
		{
			_isStepPlay = true;
			PopulateStack();
			_isActive = true;
		}

		public void Pause()
		{
			_isStepPlay = true;
		}

		public void PopulateStack()
		{
			InstructionsArray = new I_BE2_Instruction[0];
			PopulateStackRecursive(TriggerInstruction.InstructionBase.Block);
			_arrayLength = InstructionsArray.Length;
		}

		private void PopulateStackRecursive(I_BE2_Block parentBlock)
		{
			int num = 0;
			I_BE2_Instruction instruction = parentBlock.Instruction;
			I_BE2_InstructionBase i_BE2_InstructionBase = instruction as I_BE2_InstructionBase;
			i_BE2_InstructionBase.TargetObject = TargetObject;
			i_BE2_InstructionBase.BlocksStack = this;
			I_BE2_BlockSection[] array = i_BE2_InstructionBase.Block.Layout.SectionsArray;
			i_BE2_InstructionBase.LocationsArray = new int[BE2_ArrayUtils.FindAll(ref array, (I_BE2_BlockSection x) => x.Body != null).Length + 1];
			InstructionsArray = BE2_ArrayUtils.AddReturn(InstructionsArray, instruction);
			int num2 = parentBlock.Layout.SectionsArray.Length;
			for (int num3 = 0; num3 < num2; num3++)
			{
				I_BE2_BlockSection i_BE2_BlockSection = parentBlock.Layout.SectionsArray[num3];
				if (i_BE2_BlockSection.Body != null)
				{
					i_BE2_InstructionBase.LocationsArray[num] = InstructionsArray.Length;
					num++;
					i_BE2_BlockSection.Body.UpdateChildBlocksList();
					I_BE2_Block[] childBlocksArray = i_BE2_BlockSection.Body.ChildBlocksArray;
					int num4 = childBlocksArray.Length;
					for (int num5 = 0; num5 < num4; num5++)
					{
						PopulateStackRecursive(childBlocksArray[num5]);
					}
					if (!(instruction is BE2_Ins_FunctionBlock))
					{
						InstructionsArray = BE2_ArrayUtils.AddReturn(InstructionsArray, instruction);
					}
				}
			}
			i_BE2_InstructionBase.LocationsArray[num] = InstructionsArray.Length;
			i_BE2_InstructionBase.PrepareToPlay();
		}
	}
}
