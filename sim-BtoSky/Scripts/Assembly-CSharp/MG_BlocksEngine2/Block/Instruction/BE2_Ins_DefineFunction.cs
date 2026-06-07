using System;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Utils;
using TMPro;
using UnityEngine.Events;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_DefineFunction : BE2_InstructionBase, I_BE2_Instruction
	{
		public string defineID;

		public UnityEvent onDefineChange = new UnityEvent();

		protected override void OnAwake()
		{
			BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypesBlock.OnFunctionDefinitionAdded, base.Block);
			defineID = Guid.NewGuid().ToString();
		}

		protected override void OnStart()
		{
			base.Block.Layout.SectionsArray[0].Header.UpdateInputsArray();
		}

		protected override void OnEnableInstruction()
		{
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypesBlock.OnDropAtStack, HandleDefineChange);
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypesBlock.OnDropAtInputSpot, HandleDefineChange);
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypesBlock.OnDragFromStack, HandleDefineChange);
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypesBlock.OnDragFromInputSpot, HandleDefineChange);
		}

		protected override void OnDisableInstruction()
		{
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypesBlock.OnDropAtStack, HandleDefineChange);
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypesBlock.OnDropAtInputSpot, HandleDefineChange);
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypesBlock.OnDragFromStack, HandleDefineChange);
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypesBlock.OnDragFromInputSpot, HandleDefineChange);
		}

		public void HandleDefineChange(I_BE2_Block block)
		{
			if (block.ParentSection.RectTransform.GetComponentInParent<BE2_Ins_DefineFunction>() == this)
			{
				onDefineChange.Invoke();
			}
		}

		public int GetLocalVariableIndex(string varName)
		{
			int result = -1;
			I_BE2_BlockSectionHeaderInput[] inputsArray = base.Block.Layout.SectionsArray[0].Header.InputsArray;
			int num = inputsArray.Length;
			for (int i = 0; i < num; i++)
			{
				if (inputsArray[i].Transform.GetComponentInChildren<TMP_Text>().text == varName)
				{
					return i;
				}
			}
			return result;
		}

		private void OnDestroy()
		{
			BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypesBlock.OnFunctionDefinitionRemoved, base.Block);
			BE2_BlockUtils.RemoveBlock(base.Block);
		}
	}
}
