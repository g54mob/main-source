using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.Utils;
using UnityEngine;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_InstructionBase : MonoBehaviour, I_BE2_InstructionBase
	{
		private I_BE2_BlockLayout _blockLayout;

		private I_BE2_BlockSection[] _sectionsList;

		private I_BE2_BlockSectionHeader _section0header;

		private int _lastLocation;

		private int _overflowLimit = 100;

		public I_BE2_Instruction Instruction { get; set; }

		public I_BE2_Block Block { get; set; }

		public I_BE2_BlocksStack BlocksStack { get; set; }

		public I_BE2_TargetObject TargetObject { get; set; }

		public int[] LocationsArray { get; set; }

		public I_BE2_BlockSectionHeaderInput[] Section0Inputs => _section0header?.InputsArray;

		public I_BE2_InstructionBase InstructionBase { get; set; }

		public bool ExecuteInUpdate { get; }

		protected virtual void OnAwake()
		{
		}

		protected virtual void OnStart()
		{
		}

		protected virtual void OnButtonPlay()
		{
		}

		protected virtual void OnButtonStop()
		{
		}

		public virtual void OnPrepareToPlay()
		{
		}

		public virtual void OnStackActive()
		{
		}

		protected virtual void OnEnableInstruction()
		{
		}

		protected virtual void OnDisableInstruction()
		{
		}

		private void Awake()
		{
			InstructionBase = this;
			Instruction = GetComponent<I_BE2_Instruction>();
			Block = GetComponent<I_BE2_Block>();
			_blockLayout = GetComponent<I_BE2_BlockLayout>();
			if (Block.Type == BlockTypeEnum.trigger)
			{
				BlocksStack = GetComponent<I_BE2_BlocksStack>();
			}
			OnAwake();
		}

		private void Start()
		{
			Initialize();
			OnStart();
		}

		public void Initialize()
		{
			_section0header = Block.Layout.SectionsArray[0].Header;
			_section0header.UpdateInputsArray();
			I_BE2_BlockSection[] array = _blockLayout.SectionsArray;
			LocationsArray = new int[BE2_ArrayUtils.FindAll(ref array, (I_BE2_BlockSection x) => x.Body != null).Length + 1];
			_sectionsList = _blockLayout.SectionsArray;
		}

		private void OnEnable()
		{
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPlay, OnButtonPlay);
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnStop, OnButtonStop);
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPrimaryKeyUpEnd, GetBlockStack);
			OnEnableInstruction();
		}

		private void OnDisable()
		{
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnPlay, OnButtonPlay);
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnStop, OnButtonStop);
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnPrimaryKeyUpEnd, GetBlockStack);
			OnDisableInstruction();
		}

		public void UpdateTargetObject()
		{
			TargetObject = GetComponentInParent<I_BE2_ProgrammingEnv>()?.TargetObject;
		}

		private void GetBlockStack()
		{
			BlocksStack = GetComponentInParent<I_BE2_BlocksStack>();
			if (BlocksStack == null)
			{
				Block.SetShadowActive(value: false);
			}
			else if (BlocksStack.IsActive)
			{
				Block.SetShadowActive(value: true);
			}
		}

		public I_BE2_BlockSectionHeaderInput[] GetSectionInputs(int sectionIndex)
		{
			return _sectionsList[sectionIndex].Header.InputsArray;
		}

		public void PrepareToPlay()
		{
			_lastLocation = LocationsArray[LocationsArray.Length - 1];
			OnPrepareToPlay();
		}

		public void ExecuteSection(int sectionIndex)
		{
			if (BlocksStack.InstructionsArray.Length > LocationsArray[sectionIndex])
			{
				I_BE2_Instruction i_BE2_Instruction = BlocksStack.InstructionsArray[LocationsArray[sectionIndex]];
				if (!BlocksStack.IsStepPlay)
				{
					if (i_BE2_Instruction.InstructionBase.Block.Type == BlockTypeEnum.trigger)
					{
						BlocksStack.OnStackLastBlockExecuted.Invoke();
					}
					if (!i_BE2_Instruction.ExecuteInUpdate && BlocksStack.OverflowGuard < _overflowLimit)
					{
						BlocksStack.OverflowGuard++;
						ExecuteInstruction(i_BE2_Instruction);
					}
					else
					{
						BlocksStack.Pointer = LocationsArray[sectionIndex];
					}
				}
				else if (Block.Type == BlockTypeEnum.trigger || Block.BlockIsFunction())
				{
					BlocksStack.OverflowGuard++;
					ExecuteInstruction(i_BE2_Instruction);
				}
				else
				{
					BlocksStack.Pointer = LocationsArray[sectionIndex];
					BlocksStack.IsActive = false;
				}
			}
			else
			{
				BlocksStack.Pointer = LocationsArray[sectionIndex];
			}
		}

		public void ExecuteNextInstruction()
		{
			if (BlocksStack.InstructionsArray.Length > _lastLocation)
			{
				I_BE2_Instruction i_BE2_Instruction = BlocksStack.InstructionsArray[_lastLocation];
				if (!BlocksStack.IsStepPlay)
				{
					if (i_BE2_Instruction.InstructionBase.Block.Type == BlockTypeEnum.trigger)
					{
						BlocksStack.OnStackLastBlockExecuted.Invoke();
					}
					if (BlocksStack.IsActive && !i_BE2_Instruction.ExecuteInUpdate && BlocksStack.OverflowGuard < _overflowLimit)
					{
						BlocksStack.OverflowGuard++;
						ExecuteInstruction(i_BE2_Instruction);
					}
					else
					{
						BlocksStack.Pointer = ((i_BE2_Instruction.InstructionBase.Block.Type != BlockTypeEnum.trigger) ? _lastLocation : 0);
					}
				}
				else if (Block.Type == BlockTypeEnum.condition || Block.Type == BlockTypeEnum.loop || Block.BlockIsFunction())
				{
					BlocksStack.OverflowGuard++;
					ExecuteInstruction(i_BE2_Instruction);
				}
				else
				{
					BlocksStack.Pointer = _lastLocation;
					BlocksStack.IsActive = false;
				}
			}
			else
			{
				BlocksStack.Pointer = _lastLocation;
				if (BlocksStack.IsStepPlay && (Block.Type == BlockTypeEnum.condition || Block.Type == BlockTypeEnum.loop))
				{
					ExecuteInstruction(BlocksStack.InstructionsArray[0]);
				}
			}
		}

		private void ExecuteInstruction(I_BE2_Instruction instruction)
		{
			BlocksStack.OnFunctionStart.Invoke(instruction);
			instruction.Function();
		}

		public string Operation()
		{
			return "";
		}

		public void Function()
		{
		}

		public void Reset()
		{
		}
	}
}
