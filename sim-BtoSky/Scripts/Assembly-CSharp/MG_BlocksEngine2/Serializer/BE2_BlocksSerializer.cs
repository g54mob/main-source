using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using MG_BlocksEngine2.Attribute;
using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.DragDrop;
using MG_BlocksEngine2.EditorScript;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.Utils;
using TMPro;
using UnityEngine;

namespace MG_BlocksEngine2.Serializer
{
	public static class BE2_BlocksSerializer
	{
		private static int counterForEndOfDeserialization;

		public static void SaveCode(string path, I_BE2_ProgrammingEnv targetProgrammingEnv)
		{
			StreamWriter streamWriter = new StreamWriter(path, append: false);
			streamWriter.WriteLine(BlocksCodeToXML(targetProgrammingEnv));
			streamWriter.Close();
			PlayerPrefs.SetString("forceSave", string.Empty);
			PlayerPrefs.Save();
		}

		public static string BlocksCodeToXML(I_BE2_ProgrammingEnv targetProgrammingEnv)
		{
			string text = "";
			targetProgrammingEnv.UpdateBlocksList();
			List<I_BE2_Block> list = new List<I_BE2_Block>();
			list.AddRange(targetProgrammingEnv.BlocksList.OrderBy(OrderOnType));
			foreach (I_BE2_Block item in list)
			{
				text += SerializableToXML(BlockToSerializable(item));
				text += "\n#\n";
			}
			return text;
		}

		private static int OrderOnType(I_BE2_Block block)
		{
			if (block.Type == BlockTypeEnum.define)
			{
				return 0;
			}
			return 1;
		}

		public static BE2_SerializableBlock BlockToSerializable(I_BE2_Block block)
		{
			BE2_SerializableBlock bE2_SerializableBlock = new BE2_SerializableBlock();
			bE2_SerializableBlock.blockName = block.Transform.name;
			bE2_SerializableBlock.position = block.Transform.localPosition;
			Type type = block.Instruction.GetType();
			SerializeAsVariableAttribute serializeAsVariableAttribute = (SerializeAsVariableAttribute)System.Attribute.GetCustomAttribute(type, typeof(SerializeAsVariableAttribute));
			if (serializeAsVariableAttribute != null)
			{
				Type variablesManagerType = serializeAsVariableAttribute.variablesManagerType;
				bE2_SerializableBlock.varManagerName = variablesManagerType.ToString();
				BE2_Text bE2Text = BE2_Text.GetBE2Text(block.Transform.GetChild(0).GetChild(0).GetChild(0));
				bE2_SerializableBlock.varName = bE2Text.text;
			}
			else
			{
				bE2_SerializableBlock.varManagerName = "";
			}
			if (type == typeof(BE2_Op_FunctionLocalVariable))
			{
				BE2_Text bE2Text2 = BE2_Text.GetBE2Text(block.Transform.GetChild(0).GetChild(0).GetChild(0));
				bE2_SerializableBlock.varName = bE2Text2.text;
				bE2_SerializableBlock.isLocalVar = "true";
			}
			if (type == typeof(BE2_Ins_FunctionBlock) || block.Type == BlockTypeEnum.define)
			{
				BE2_Ins_FunctionBlock bE2_Ins_FunctionBlock = block.Instruction as BE2_Ins_FunctionBlock;
				if (bE2_Ins_FunctionBlock != null)
				{
					bE2_SerializableBlock.defineID = bE2_Ins_FunctionBlock.defineID;
				}
				BE2_Ins_DefineFunction bE2_Ins_DefineFunction = block.Instruction as BE2_Ins_DefineFunction;
				if (bE2_Ins_DefineFunction != null)
				{
					bE2_SerializableBlock.defineID = bE2_Ins_DefineFunction.defineID;
					bE2_SerializableBlock.defineItems = new List<DefineItem>();
					int num = 0;
					I_BE2_BlockSectionHeaderItem[] itemsArray = block.Layout.SectionsArray[0].Header.ItemsArray;
					foreach (I_BE2_BlockSectionHeaderItem i_BE2_BlockSectionHeaderItem in itemsArray)
					{
						if (i_BE2_BlockSectionHeaderItem.Transform.name.Contains("[FixedLabel]"))
						{
							num++;
							continue;
						}
						BE2_BlockSectionHeader_Label component = i_BE2_BlockSectionHeaderItem.Transform.GetComponent<BE2_BlockSectionHeader_Label>();
						BE2_BlockSectionHeader_InputField component2 = i_BE2_BlockSectionHeaderItem.Transform.GetComponent<BE2_BlockSectionHeader_InputField>();
						BE2_BlockSectionHeader_LocalVariable component3 = i_BE2_BlockSectionHeaderItem.Transform.GetComponent<BE2_BlockSectionHeader_LocalVariable>();
						BE2_BlockSectionHeader_Custom component4 = i_BE2_BlockSectionHeaderItem.Transform.GetComponent<BE2_BlockSectionHeader_Custom>();
						if ((bool)component)
						{
							bE2_SerializableBlock.defineItems.Add(new DefineItem("label", i_BE2_BlockSectionHeaderItem.Transform.GetComponent<TMP_Text>().text));
						}
						else if ((bool)component2 || (bool)component3)
						{
							bE2_SerializableBlock.defineItems.Add(new DefineItem("variable", i_BE2_BlockSectionHeaderItem.Transform.GetComponentInChildren<TMP_Text>().text));
						}
						else if ((bool)component4)
						{
							bE2_SerializableBlock.defineItems.Add(new DefineItem("custom", component4.serializableValue));
						}
						num++;
					}
				}
			}
			I_BE2_BlockSection[] sectionsArray = block.Layout.SectionsArray;
			foreach (I_BE2_BlockSection i_BE2_BlockSection in sectionsArray)
			{
				BE2_SerializableSection bE2_SerializableSection = new BE2_SerializableSection();
				bE2_SerializableBlock.sections.Add(bE2_SerializableSection);
				I_BE2_BlockSectionHeaderInput[] inputsArray = i_BE2_BlockSection.Header.InputsArray;
				foreach (I_BE2_BlockSectionHeaderInput i_BE2_BlockSectionHeaderInput in inputsArray)
				{
					BE2_SerializableInput bE2_SerializableInput = new BE2_SerializableInput();
					bE2_SerializableSection.inputs.Add(bE2_SerializableInput);
					I_BE2_Block component5 = i_BE2_BlockSectionHeaderInput.Transform.GetComponent<I_BE2_Block>();
					if (component5 != null)
					{
						bE2_SerializableInput.isOperation = true;
						bE2_SerializableInput.operation = BlockToSerializable(component5);
						bE2_SerializableInput.value = i_BE2_BlockSectionHeaderInput.InputValues.stringValue;
					}
					else
					{
						bE2_SerializableInput.isOperation = false;
						bE2_SerializableInput.value = i_BE2_BlockSectionHeaderInput.InputValues.stringValue;
					}
				}
				if (i_BE2_BlockSection.Body != null && block.Instruction.GetType() != typeof(BE2_Ins_FunctionBlock))
				{
					I_BE2_Block[] childBlocksArray = i_BE2_BlockSection.Body.ChildBlocksArray;
					foreach (I_BE2_Block block2 in childBlocksArray)
					{
						bE2_SerializableSection.childBlocks.Add(BlockToSerializable(block2));
					}
				}
			}
			BE2_SerializableOuterArea bE2_SerializableOuterArea = new BE2_SerializableOuterArea();
			if (block.Layout.OuterArea != null)
			{
				I_BE2_Block[] childBlocksArray = block.Layout.OuterArea.childBlocksArray;
				foreach (I_BE2_Block block3 in childBlocksArray)
				{
					bE2_SerializableOuterArea.childBlocks.Add(BlockToSerializable(block3));
				}
			}
			bE2_SerializableBlock.outerArea = bE2_SerializableOuterArea;
			return bE2_SerializableBlock;
		}

		public static string SerializableToXML(BE2_SerializableBlock serializableBlock)
		{
			return BE2_BlockXML.SBlockToXElement(serializableBlock).ToString();
		}

		public static bool LoadCode(string path, I_BE2_ProgrammingEnv targetProgrammingEnv)
		{
			if (File.Exists(path))
			{
				StreamReader streamReader = new StreamReader(path);
				string xmlString = streamReader.ReadToEnd();
				streamReader.Close();
				XMLToBlocksCode(xmlString, targetProgrammingEnv);
				return true;
			}
			return false;
		}

		public static void XMLToBlocksCode(string xmlString, I_BE2_ProgrammingEnv targetProgrammingEnv)
		{
			string[] array = xmlString.Split('#');
			for (int i = 0; i < array.Length; i++)
			{
				BE2_SerializableBlock bE2_SerializableBlock = XMLToSerializable(array[i]);
				bool flag = true;
				if (bE2_SerializableBlock != null && bE2_SerializableBlock.blockName == "Block Ins DefineFunction")
				{
					targetProgrammingEnv.UpdateBlocksList();
					BE2_Ins_DefineFunction bE2_Ins_DefineFunction = null;
					foreach (I_BE2_Block blocks in targetProgrammingEnv.BlocksList)
					{
						bE2_Ins_DefineFunction = blocks.Instruction as BE2_Ins_DefineFunction;
						if (bE2_Ins_DefineFunction != null && bE2_Ins_DefineFunction.defineID == bE2_SerializableBlock.defineID)
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					SerializableToBlock(bE2_SerializableBlock, targetProgrammingEnv);
				}
			}
		}

		public static BE2_SerializableBlock XMLToSerializable(string blockString)
		{
			blockString = blockString.Trim();
			if (blockString.Length > 1)
			{
				return BE2_BlockXML.XElementToSBlock(XElement.Parse(blockString));
			}
			return null;
		}

		private static IEnumerator C_AddInputsAndChildBlocks(I_BE2_Block block, BE2_SerializableBlock serializableBlock, I_BE2_ProgrammingEnv programmingEnv)
		{
			yield return new WaitForEndOfFrame();
			I_BE2_BlockSection[] sectionsArray = block.Layout.SectionsArray;
			for (int i = 0; i < sectionsArray.Length; i++)
			{
				if (block.Instruction.GetType() != typeof(BE2_Ins_DefineFunction))
				{
					I_BE2_BlockSectionHeaderInput[] inputsArray = sectionsArray[i].Header.InputsArray;
					for (int j = 0; j < inputsArray.Length; j++)
					{
						BE2_SerializableInput bE2_SerializableInput = serializableBlock.sections[i].inputs[j];
						if (bE2_SerializableInput.isOperation)
						{
							I_BE2_Block i_BE2_Block = SerializableToBlock(bE2_SerializableInput.operation, programmingEnv);
							if (i_BE2_Block.Instruction.GetType() == typeof(BE2_Op_FunctionLocalVariable))
							{
								i_BE2_Block.Transform.GetComponentInChildren<TMP_Text>().text = bE2_SerializableInput.value;
							}
							BE2_Raycaster.ConnectionPoint connectionPoint = new BE2_Raycaster.ConnectionPoint
							{
								spot = inputsArray[j].Transform.GetComponent<I_BE2_Spot>()
							};
							BE2_DragDropManager.Instance.ConnectionPoint = connectionPoint;
							i_BE2_Block.Transform.GetComponent<I_BE2_Drag>().OnPointerDown();
							i_BE2_Block.Transform.GetComponent<I_BE2_Drag>().OnPointerUp();
						}
						else
						{
							BE2_InputField bE2Component = BE2_InputField.GetBE2Component(inputsArray[j].Transform);
							BE2_Dropdown bE2Component2 = BE2_Dropdown.GetBE2Component(inputsArray[j].Transform);
							if (bE2Component != null && !bE2Component.isNull)
							{
								bE2Component.text = bE2_SerializableInput.value;
							}
							else if (bE2Component2 != null && !bE2Component2.isNull)
							{
								bE2Component2.value = bE2Component2.GetIndexOf(bE2_SerializableInput.value);
							}
						}
						if (serializableBlock.isLocalVar == "true")
						{
							block.Transform.GetChild(0).GetChild(0).GetChild(0)
								.GetComponent<TMP_Text>()
								.text = serializableBlock.varName;
						}
						inputsArray[j].UpdateValues();
					}
				}
				I_BE2_BlockSectionBody body = sectionsArray[i].Body;
				if (body != null)
				{
					foreach (BE2_SerializableBlock childBlock in serializableBlock.sections[i].childBlocks)
					{
						SerializableToBlock(childBlock, programmingEnv).Transform.SetParent(body.RectTransform);
					}
				}
				sectionsArray[i].Header.UpdateItemsArray();
				sectionsArray[i].Header.UpdateInputsArray();
			}
			BE2_OuterArea outerArea = block.Layout.OuterArea;
			if (outerArea != null)
			{
				foreach (BE2_SerializableBlock childBlock2 in serializableBlock.outerArea.childBlocks)
				{
					SerializableToBlock(childBlock2, programmingEnv).Transform.SetParent(outerArea.Transform);
				}
			}
			yield return null;
			counterForEndOfDeserialization--;
		}

		public static I_BE2_Block SerializableToBlock(BE2_SerializableBlock serializableBlock, I_BE2_ProgrammingEnv programmingEnv)
		{
			I_BE2_Block i_BE2_Block = null;
			if (serializableBlock != null)
			{
				string blockName = serializableBlock.blockName;
				GameObject gameObject = BE2_BlockUtils.LoadPrefabBlock(blockName);
				if ((bool)gameObject)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, serializableBlock.position, Quaternion.identity, programmingEnv.Transform);
					gameObject2.name = blockName;
					gameObject2.transform.localPosition = new Vector3(serializableBlock.position.x, serializableBlock.position.y, 0f);
					gameObject2.transform.localEulerAngles = Vector3.zero;
					i_BE2_Block = gameObject2.GetComponent<I_BE2_Block>();
					if ((bool)(i_BE2_Block.Instruction as BE2_Ins_DefineFunction))
					{
						(i_BE2_Block.Instruction as BE2_Ins_DefineFunction).defineID = serializableBlock.defineID;
						foreach (DefineItem defineItem in serializableBlock.defineItems)
						{
							if (defineItem.type == "label")
							{
								UnityEngine.Object.Instantiate(BE2_Inspector.Instance.LabelTextTemplate, Vector3.zero, Quaternion.identity, i_BE2_Block.Layout.SectionsArray[0].Header.RectTransform).GetComponentInChildren<TMP_Text>().text = defineItem.value;
							}
							else if (defineItem.type == "variable")
							{
								UnityEngine.Object.Instantiate(BE2_FunctionBlocksManager.Instance.templateDefineLocalVariable, Vector3.zero, Quaternion.identity, i_BE2_Block.Layout.SectionsArray[0].Header.RectTransform).GetComponentInChildren<TMP_Text>().text = defineItem.value;
							}
							else if (defineItem.type == "custom")
							{
								UnityEngine.Object.Instantiate(BE2_FunctionBlocksManager.Instance.templateDefineCustomHeaderItem, Vector3.zero, Quaternion.identity, i_BE2_Block.Layout.SectionsArray[0].Header.RectTransform).GetComponentInChildren<BE2_BlockSectionHeader_Custom>().serializableValue = defineItem.value;
							}
						}
						BE2_FunctionBlocksManager.Instance.CreateSelectionFunction(serializableBlock.defineItems, i_BE2_Block.Instruction as BE2_Ins_DefineFunction);
					}
					if (i_BE2_Block.Instruction is BE2_Ins_FunctionBlock)
					{
						programmingEnv.UpdateBlocksList();
						BE2_Ins_DefineFunction bE2_Ins_DefineFunction = null;
						foreach (I_BE2_Block blocks in programmingEnv.BlocksList)
						{
							bE2_Ins_DefineFunction = blocks.Instruction as BE2_Ins_DefineFunction;
							if (bE2_Ins_DefineFunction != null && bE2_Ins_DefineFunction.defineID == serializableBlock.defineID)
							{
								break;
							}
						}
						int num = 0;
						bE2_Ins_DefineFunction.Block.Layout.SectionsArray[0].Header.UpdateItemsArray();
						I_BE2_BlockSectionHeaderItem[] itemsArray = bE2_Ins_DefineFunction.Block.Layout.SectionsArray[0].Header.ItemsArray;
						foreach (I_BE2_BlockSectionHeaderItem i_BE2_BlockSectionHeaderItem in itemsArray)
						{
							if (i_BE2_BlockSectionHeaderItem.Transform.name.Contains("[FixedLabel]"))
							{
								num++;
								continue;
							}
							if (i_BE2_BlockSectionHeaderItem is BE2_BlockSectionHeader_Label)
							{
								UnityEngine.Object.Instantiate(BE2_Inspector.Instance.LabelTextTemplate, Vector3.zero, Quaternion.identity, i_BE2_Block.Layout.SectionsArray[0].Header.RectTransform).GetComponent<TMP_Text>().text = i_BE2_BlockSectionHeaderItem.Transform.GetComponent<TMP_Text>().text;
							}
							else if (i_BE2_BlockSectionHeaderItem is BE2_BlockSectionHeader_LocalVariable)
							{
								UnityEngine.Object.Instantiate(BE2_Inspector.Instance.InputFieldTemplate, Vector3.zero, Quaternion.identity, i_BE2_Block.Layout.SectionsArray[0].Header.RectTransform);
							}
							else if (i_BE2_BlockSectionHeaderItem is BE2_BlockSectionHeader_Custom)
							{
								UnityEngine.Object.Instantiate(BE2_FunctionBlocksManager.Instance.templateDefineCustomHeaderItem, Vector3.zero, Quaternion.identity, i_BE2_Block.Layout.SectionsArray[0].Header.RectTransform).GetComponentInChildren<BE2_BlockSectionHeader_Custom>().serializableValue = i_BE2_BlockSectionHeaderItem.Transform.GetComponentInChildren<BE2_BlockSectionHeader_Custom>().serializableValue;
							}
							num++;
						}
						BE2_ExecutionManager.Instance.StartCoroutine(C_InitializeFunctionInstruction(i_BE2_Block.Instruction as BE2_Ins_FunctionBlock, bE2_Ins_DefineFunction));
					}
					if (serializableBlock.varManagerName != null && serializableBlock.varManagerName != "")
					{
						BE2_Text.GetBE2Text(i_BE2_Block.Transform.GetChild(0).GetChild(0).GetChild(0)).text = serializableBlock.varName;
						Type type = Type.GetType(serializableBlock.varManagerName);
						if (type != null)
						{
							(UnityEngine.Object.FindObjectOfType(type) as I_BE2_VariablesManager).CreateAndAddVarToPanel(serializableBlock.varName);
						}
						else
						{
							Debug.Log("Variables manager of type *" + serializableBlock.varManagerName + "* was not found.");
						}
					}
					if (serializableBlock.isLocalVar == "true")
					{
						i_BE2_Block.Transform.GetChild(0).GetChild(0).GetChild(0)
							.GetComponent<TMP_Text>()
							.text = serializableBlock.varName;
					}
					counterForEndOfDeserialization++;
					BE2_ExecutionManager.Instance.StartCoroutine(C_AddInputsAndChildBlocks(i_BE2_Block, serializableBlock, programmingEnv));
					if (i_BE2_Block.Type == BlockTypeEnum.trigger && i_BE2_Block.Type != BlockTypeEnum.define)
					{
						BE2_ExecutionManager.Instance.AddToBlocksStackArray(i_BE2_Block.Instruction.InstructionBase.BlocksStack, programmingEnv.TargetObject);
						i_BE2_Block.Instruction.InstructionBase.BlocksStack.PopulateStack();
					}
				}
				BE2_BlockUtils.UnloadPrefab();
			}
			return i_BE2_Block;
		}

		private static IEnumerator C_InitializeFunctionInstruction(BE2_Ins_FunctionBlock functionInstruction, BE2_Ins_DefineFunction defineInstruction)
		{
			yield return new WaitForEndOfFrame();
			functionInstruction.Initialize(defineInstruction);
			yield return new WaitUntil(() => counterForEndOfDeserialization == 0);
			functionInstruction.RebuildFunctionInstance();
		}
	}
}
