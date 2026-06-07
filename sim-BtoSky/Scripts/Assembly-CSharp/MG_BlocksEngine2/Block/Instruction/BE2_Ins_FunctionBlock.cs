using System.Collections;
using System.Collections.Generic;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Utils;
using TMPro;
using UnityEngine;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_FunctionBlock : BE2_InstructionBase, I_BE2_Instruction
	{
		public string defineID;

		public BE2_Ins_DefineFunction defineInstruction;

		private bool _initialized;

		public BE2_Ins_FunctionBlock mirrorFunction;

		public List<BE2_Op_FunctionLocalVariable> localVariables;

		public List<string> localValues = new List<string>();

		public BE2_Ins_FunctionBlock(BE2_Ins_DefineFunction defineInstruction)
		{
			this.defineInstruction = defineInstruction;
		}

		protected override void OnStart()
		{
			if ((bool)defineInstruction)
			{
				defineInstruction.InstructionBase.Block.Layout.SectionsArray[0].Body.UpdateLayout();
				defineID = defineInstruction.defineID;
			}
			localValues = new List<string>();
			I_BE2_BlockSectionHeaderInput[] inputsArray = base.Block.Layout.SectionsArray[0].Header.InputsArray;
			for (int i = 0; i < inputsArray.Length; i++)
			{
				_ = inputsArray[i];
				localValues.Add("");
			}
		}

		protected override void OnEnableInstruction()
		{
			if (!_initialized)
			{
				Initialize(defineInstruction);
			}
		}

		protected override void OnDisableInstruction()
		{
			defineInstruction.onDefineChange.RemoveListener(RebuildFunctionInstance);
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypesBlock.OnFunctionDefinitionRemoved, Remove);
			_initialized = false;
		}

		public void Initialize(BE2_Ins_DefineFunction defineInstruction)
		{
			if ((bool)defineInstruction)
			{
				RebuildFunctionInstance();
				this.defineInstruction = defineInstruction;
				defineInstruction.onDefineChange.AddListener(RebuildFunctionInstance);
				BE2_MainEventsManager.Instance.StartListening(BE2EventTypesBlock.OnFunctionDefinitionRemoved, Remove);
				defineID = defineInstruction.defineID;
				_initialized = true;
			}
		}

		private void Remove(I_BE2_Block block)
		{
			if (defineInstruction.Block == block)
			{
				base.Block.Transform.SetParent(null);
				base.Block.Instruction.InstructionBase.BlocksStack?.PopulateStack();
				BE2_BlockUtils.RemoveBlock(base.Block);
			}
		}

		public void RebuildFunctionInstance()
		{
			localVariables = new List<BE2_Op_FunctionLocalVariable>();
			StartCoroutine(C_RebuildFunctionInstance());
		}

		private IEnumerator C_RebuildFunctionInstance()
		{
			yield return new WaitForEndOfFrame();
			I_BE2_BlockSectionBody body = base.Block.Layout.SectionsArray[0].Body;
			for (int num = body.ChildBlocksCount - 1; num >= 0; num--)
			{
				if ((bool)(body.ChildBlocksArray[num] as Object))
				{
					Object.Destroy(body.ChildBlocksArray[num].Transform.gameObject);
				}
			}
			I_BE2_Block[] childBlocksArray = defineInstruction.Block.Layout.SectionsArray[0].Body.ChildBlocksArray;
			foreach (I_BE2_Block mirrorBlock in childBlocksArray)
			{
				InstantiateNoViewBlockRecursive(mirrorBlock, base.Block.Layout.SectionsArray[0].Body.RectTransform);
			}
		}

		private void InstantiateNoViewBlockRecursive(I_BE2_Block mirrorBlock, Transform parent)
		{
			if (mirrorBlock is BE2_GhostBlock)
			{
				return;
			}
			I_BE2_Block i_BE2_Block = null;
			BE2_Ins_ReferenceFunctionBlock bE2_Ins_ReferenceFunctionBlock = null;
			if (mirrorBlock.Instruction.GetType() == typeof(BE2_Ins_FunctionBlock) && (mirrorBlock.Instruction as BE2_Ins_FunctionBlock).defineInstruction == defineInstruction)
			{
				mirrorFunction = mirrorBlock.Instruction as BE2_Ins_FunctionBlock;
				i_BE2_Block = mirrorBlock.InstantiateNoViewBlock<BE2_Ins_ReferenceFunctionBlock>();
				bE2_Ins_ReferenceFunctionBlock = i_BE2_Block.Instruction as BE2_Ins_ReferenceFunctionBlock;
				bE2_Ins_ReferenceFunctionBlock.Initialize(base.Block.Instruction as BE2_Ins_FunctionBlock);
			}
			else
			{
				i_BE2_Block = mirrorBlock.InstantiateNoViewBlock();
			}
			if (i_BE2_Block == null)
			{
				return;
			}
			int num = 0;
			I_BE2_BlockSection[] sectionsArray = mirrorBlock.Layout.SectionsArray;
			foreach (I_BE2_BlockSection i_BE2_BlockSection in sectionsArray)
			{
				I_BE2_BlockSectionHeader header = i_BE2_BlockSection.Header;
				header.UpdateInputsArray();
				I_BE2_BlockSection i_BE2_BlockSection2 = i_BE2_Block.Layout.SectionsArray[num];
				int num2 = 0;
				I_BE2_BlockSectionHeaderInput[] inputsArray = header.InputsArray;
				foreach (I_BE2_BlockSectionHeaderInput i_BE2_BlockSectionHeaderInput in inputsArray)
				{
					if (i_BE2_BlockSectionHeaderInput is BE2_BlockSectionHeader_Operation)
					{
						I_BE2_Block component = i_BE2_BlockSectionHeaderInput.Transform.GetComponent<I_BE2_Block>();
						InstantiateNoViewBlockRecursive(component, i_BE2_BlockSection2.Header.RectTransform);
					}
					else if (i_BE2_BlockSectionHeaderInput is BE2_BlockSectionHeader_LocalVariable)
					{
						I_BE2_Block component2 = i_BE2_BlockSectionHeaderInput.Transform.GetComponent<I_BE2_Block>();
						InstantiateNoViewBlockRecursive(component2, i_BE2_BlockSection2.Header.RectTransform);
					}
					else
					{
						GameObject obj = new GameObject("input", typeof(RectTransform));
						obj.transform.SetParent(i_BE2_BlockSection2.Header.RectTransform);
						obj.transform.SetAsLastSibling();
						obj.AddComponent<BE2_BlockSectionHeader_ReferenceInput>().referenceInput = i_BE2_BlockSectionHeaderInput;
					}
					num2++;
				}
				i_BE2_BlockSection2.Header.UpdateInputsArray();
				if (!bE2_Ins_ReferenceFunctionBlock)
				{
					I_BE2_BlockSectionBody body = i_BE2_BlockSection.Body;
					if (body != null)
					{
						body.UpdateChildBlocksList();
						int num3 = 0;
						I_BE2_Block[] childBlocksArray = body.ChildBlocksArray;
						foreach (I_BE2_Block mirrorBlock2 in childBlocksArray)
						{
							InstantiateNoViewBlockRecursive(mirrorBlock2, i_BE2_BlockSection2.Body.RectTransform);
							num3++;
						}
						i_BE2_BlockSection2.Body.UpdateChildBlocksList();
					}
				}
				num++;
			}
			i_BE2_Block.Transform.SetParent(parent);
			i_BE2_Block.Transform.SetAsLastSibling();
			if (i_BE2_Block.Instruction.GetType() == typeof(BE2_Op_FunctionLocalVariable))
			{
				StartCoroutine(C_SetLocalVarName(i_BE2_Block, mirrorBlock));
			}
			(i_BE2_Block.Instruction.InstructionBase as BE2_InstructionBase).Initialize();
		}

		private IEnumerator C_SetLocalVarName(I_BE2_Block noViewBlock, I_BE2_Block mirrorBlock)
		{
			yield return new WaitForEndOfFrame();
			BE2_Op_FunctionLocalVariable bE2_Op_FunctionLocalVariable = noViewBlock.Instruction as BE2_Op_FunctionLocalVariable;
			TMP_Text componentInChildren = mirrorBlock.Transform.GetComponentInChildren<TMP_Text>();
			if ((bool)componentInChildren)
			{
				bE2_Op_FunctionLocalVariable.varName = componentInChildren.text;
				localVariables.Add(bE2_Op_FunctionLocalVariable);
			}
		}

		public override void OnPrepareToPlay()
		{
			foreach (BE2_Op_FunctionLocalVariable localVariable in localVariables)
			{
				localVariable.defineInstruction = defineInstruction;
				localVariable.blockToObserve = base.Block as BE2_Block;
			}
		}

		public new void Function()
		{
			for (int i = 0; i < localValues.Count; i++)
			{
				localValues[i] = base.Section0Inputs[i].StringValue;
			}
			ExecuteSection(0);
		}
	}
}
