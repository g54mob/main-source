using System;
using System.Collections;
using System.Collections.Generic;
using MG_BlocksEngine2.Attribute;
using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.DragDrop;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.Serializer;
using MG_BlocksEngine2.UI;
using UnityEngine;

namespace MG_BlocksEngine2.Utils
{
	public static class BE2_BlockUtils
	{
		public static void RemoveEngineComponents(Transform blockTransform)
		{
			I_BE2_BlockSectionHeaderItem[] componentsInChildren = blockTransform.GetComponentsInChildren<I_BE2_BlockSectionHeaderItem>();
			for (int num = componentsInChildren.Length - 1; num >= 0; num--)
			{
				UnityEngine.Object.DestroyImmediate(componentsInChildren[num] as MonoBehaviour);
			}
			I_BE2_BlockSection[] componentsInChildren2 = blockTransform.GetComponentsInChildren<I_BE2_BlockSection>();
			for (int num2 = componentsInChildren2.Length - 1; num2 >= 0; num2--)
			{
				UnityEngine.Object.DestroyImmediate(componentsInChildren2[num2] as MonoBehaviour);
			}
			I_BE2_BlockSectionBody[] componentsInChildren3 = blockTransform.GetComponentsInChildren<I_BE2_BlockSectionBody>();
			for (int num3 = componentsInChildren3.Length - 1; num3 >= 0; num3--)
			{
				UnityEngine.Object.DestroyImmediate(componentsInChildren3[num3] as MonoBehaviour);
			}
			I_BE2_BlockSectionHeader[] componentsInChildren4 = blockTransform.GetComponentsInChildren<I_BE2_BlockSectionHeader>();
			for (int num4 = componentsInChildren4.Length - 1; num4 >= 0; num4--)
			{
				UnityEngine.Object.DestroyImmediate(componentsInChildren4[num4] as MonoBehaviour);
			}
			BE2_SpotOuterArea componentInChildren = blockTransform.GetComponentInChildren<BE2_SpotOuterArea>();
			if ((bool)componentInChildren)
			{
				UnityEngine.Object.DestroyImmediate(componentInChildren.transform.gameObject);
			}
			I_BE2_Spot[] componentsInChildren5 = blockTransform.GetComponentsInChildren<I_BE2_Spot>();
			for (int num5 = componentsInChildren5.Length - 1; num5 >= 0; num5--)
			{
				UnityEngine.Object.DestroyImmediate(componentsInChildren5[num5] as MonoBehaviour);
			}
			I_BE2_Drag component = blockTransform.GetComponent<I_BE2_Drag>();
			if (component != null)
			{
				UnityEngine.Object.DestroyImmediate(component as MonoBehaviour);
			}
			I_BE2_Instruction component2 = blockTransform.GetComponent<I_BE2_Instruction>();
			if (component2 != null)
			{
				UnityEngine.Object.DestroyImmediate(component2 as MonoBehaviour);
			}
			I_BE2_BlockLayout component3 = blockTransform.GetComponent<I_BE2_BlockLayout>();
			if (component3 != null)
			{
				UnityEngine.Object.DestroyImmediate(component3 as MonoBehaviour);
			}
			I_BE2_Block component4 = blockTransform.GetComponent<I_BE2_Block>();
			if (component4 != null)
			{
				UnityEngine.Object.DestroyImmediate(component4 as MonoBehaviour);
			}
			I_BE2_BlocksStack component5 = blockTransform.GetComponent<I_BE2_BlocksStack>();
			if (component5 != null)
			{
				UnityEngine.Object.DestroyImmediate(component5 as MonoBehaviour);
			}
		}

		public static void AddSelectionMenuComponents(Transform blockTransform)
		{
			GameObject gameObject = blockTransform.gameObject;
			gameObject.AddComponent<BE2_UI_SelectionBlock>();
			gameObject.AddComponent<BE2_DragSelectionBlock>();
		}

		public static void DuplicateBlock(I_BE2_Block block)
		{
			I_BE2_ProgrammingEnv componentInParent = block.Transform.GetComponentInParent<I_BE2_ProgrammingEnv>();
			I_BE2_Block i_BE2_Block = BE2_BlocksSerializer.SerializableToBlock(BE2_BlocksSerializer.BlockToSerializable(block), componentInParent);
			i_BE2_Block.Transform.position = block.Transform.position + new Vector3(10f, 10f, 0f);
			if (i_BE2_Block.Type == BlockTypeEnum.trigger)
			{
				BE2_ExecutionManager.Instance.AddToBlocksStackArray(i_BE2_Block.Instruction.InstructionBase.BlocksStack, componentInParent.TargetObject);
			}
		}

		public static I_BE2_Block GetRootBlock(I_BE2_Block block)
		{
			I_BE2_Block i_BE2_Block = block.ParentSection?.Block;
			if (i_BE2_Block != null)
			{
				return GetRootBlock(i_BE2_Block);
			}
			return block;
		}

		public static void RemoveBlock(I_BE2_Block block)
		{
			if (block.Type == BlockTypeEnum.trigger)
			{
				BE2_ExecutionManager.Instance.RemoveFromBlocksStackList(block.Instruction.InstructionBase.BlocksStack);
			}
			UnityEngine.Object.Destroy(block.Transform.gameObject);
		}

		public static GameObject CreatePrefab(I_BE2_Block block)
		{
			return null;
		}

		public static I_BE2_Instruction GetParentInstructionOfType(I_BE2_Instruction thisInstruction, BlockTypeEnum blockType)
		{
			I_BE2_Instruction result = null;
			I_BE2_BlockSectionBody component = thisInstruction.InstructionBase.Block.Transform.parent.GetComponent<I_BE2_BlockSectionBody>();
			if (component != null)
			{
				I_BE2_Block block = component.BlockSection.Block;
				result = ((block.Type != blockType) ? GetParentInstructionOfType(block.Instruction, blockType) : block.Instruction);
			}
			return result;
		}

		public static GameObject LoadPrefabBlock(string prefabName)
		{
			GameObject gameObject = Resources.Load<GameObject>("Blocks/" + prefabName);
			if (!gameObject)
			{
				gameObject = Resources.Load<GameObject>("Blocks/Custom/" + prefabName);
			}
			if (!gameObject)
			{
				gameObject = Resources.Load<GameObject>("Blocks/FunctionBlock/" + prefabName);
			}
			if (!gameObject)
			{
				gameObject = Resources.Load<GameObject>(BE2_Paths.PathToResources(BE2_Paths.TranslateMarkupPath(BE2_Paths.NewBlockPrefabPath)) + prefabName);
			}
			return gameObject;
		}

		public static void UnloadPrefab()
		{
			Resources.UnloadUnusedAssets();
		}

		public static List<I_BE2_Instruction> GetParentInstructionOfTypeAll(I_BE2_Instruction thisInstruction, BlockTypeEnum blockType)
		{
			List<I_BE2_Instruction> list = new List<I_BE2_Instruction>();
			I_BE2_BlockSectionBody component = thisInstruction.InstructionBase.Block.Transform.parent.GetComponent<BE2_BlockSectionBody>();
			if (component != null)
			{
				I_BE2_Block block = component.BlockSection.Block;
				if (block.Type == blockType)
				{
					list.Add(block.Instruction);
				}
				list.AddRange(GetParentInstructionOfTypeAll(block.Instruction, blockType));
			}
			return list;
		}

		public static bool BlockIsVariable(this I_BE2_Block block)
		{
			if ((SerializeAsVariableAttribute)System.Attribute.GetCustomAttribute(block.Instruction.GetType(), typeof(SerializeAsVariableAttribute)) == null)
			{
				return false;
			}
			return true;
		}

		public static bool BlockIsFunction(this I_BE2_Block block)
		{
			return block.Instruction.GetType() == typeof(BE2_Ins_FunctionBlock);
		}

		public static void CallOnEndOfFrame(this MonoBehaviour monoBehaviour, Action action)
		{
			monoBehaviour.StartCoroutine(InvokeRoutine(action));
		}

		private static IEnumerator InvokeRoutine(Action action)
		{
			yield return new WaitForEndOfFrame();
			action();
		}

		public static I_BE2_Block InstantiateNoViewBlock(this I_BE2_Block block)
		{
			if (block is BE2_GhostBlock)
			{
				return null;
			}
			I_BE2_Block i_BE2_Block = null;
			I_BE2_Instruction i_BE2_Instruction = null;
			GameObject gameObject = new GameObject(block.Transform.name + " noView", typeof(RectTransform));
			BE2_BlockNoViewLayout bE2_BlockNoViewLayout = gameObject.AddComponent<BE2_BlockNoViewLayout>();
			i_BE2_Block = gameObject.AddComponent<BE2_Block>();
			i_BE2_Block.Type = block.Type;
			for (int i = 0; i < block.Layout.SectionsArray.Length; i++)
			{
				I_BE2_BlockSection i_BE2_BlockSection = block.Layout.SectionsArray[i];
				GameObject gameObject2 = new GameObject("section", typeof(RectTransform));
				gameObject2.transform.SetParent(gameObject.transform);
				gameObject2.transform.SetAsLastSibling();
				BE2_NoViewBlockSection bE2_NoViewBlockSection = gameObject2.AddComponent<BE2_NoViewBlockSection>();
				bE2_NoViewBlockSection.index = i;
				if (i_BE2_BlockSection.Header != null)
				{
					GameObject gameObject3 = new GameObject("header", typeof(RectTransform));
					gameObject3.transform.SetParent(gameObject2.transform);
					gameObject3.transform.SetAsLastSibling();
					BE2_NoViewBlockSectionHeader header = gameObject3.AddComponent<BE2_NoViewBlockSectionHeader>();
					bE2_NoViewBlockSection.Header = header;
				}
				if (i_BE2_BlockSection.Body != null)
				{
					GameObject gameObject4 = new GameObject("body", typeof(RectTransform));
					gameObject4.transform.SetParent(gameObject2.transform);
					gameObject4.transform.SetAsLastSibling();
					BE2_NoViewBlockSectionBody body = gameObject4.AddComponent<BE2_NoViewBlockSectionBody>();
					bE2_NoViewBlockSection.Body = body;
				}
			}
			bE2_BlockNoViewLayout.Initialize();
			i_BE2_Instruction = gameObject.AddComponent(block.Instruction.GetType()) as I_BE2_Instruction;
			if (i_BE2_Instruction is BE2_Ins_FunctionBlock)
			{
				(i_BE2_Instruction as BE2_Ins_FunctionBlock).Initialize((block.Instruction as BE2_Ins_FunctionBlock).defineInstruction);
			}
			i_BE2_Block.Instruction = i_BE2_Instruction;
			if (i_BE2_Block.Type == BlockTypeEnum.operation)
			{
				if ((bool)gameObject.GetComponent<BE2_Op_FunctionLocalVariable>())
				{
					gameObject.AddComponent<BE2_BlockSectionHeader_LocalVariable>();
				}
				else
				{
					gameObject.AddComponent<BE2_BlockSectionHeader_Operation>();
				}
			}
			return i_BE2_Block;
		}

		public static I_BE2_Block InstantiateNoViewBlock<T>(this I_BE2_Block block) where T : I_BE2_Instruction
		{
			if (block is BE2_GhostBlock)
			{
				return null;
			}
			I_BE2_Block i_BE2_Block = null;
			I_BE2_Instruction i_BE2_Instruction = null;
			GameObject gameObject = new GameObject(block.Transform.name + " noView", typeof(RectTransform));
			BE2_BlockNoViewLayout bE2_BlockNoViewLayout = gameObject.AddComponent<BE2_BlockNoViewLayout>();
			i_BE2_Block = gameObject.AddComponent<BE2_Block>();
			i_BE2_Block.Type = block.Type;
			for (int i = 0; i < block.Layout.SectionsArray.Length; i++)
			{
				I_BE2_BlockSection i_BE2_BlockSection = block.Layout.SectionsArray[i];
				GameObject gameObject2 = new GameObject("section", typeof(RectTransform));
				gameObject2.transform.SetParent(gameObject.transform);
				gameObject2.transform.SetAsLastSibling();
				BE2_NoViewBlockSection bE2_NoViewBlockSection = gameObject2.AddComponent<BE2_NoViewBlockSection>();
				bE2_NoViewBlockSection.index = i;
				if (i_BE2_BlockSection.Header != null)
				{
					GameObject gameObject3 = new GameObject("header", typeof(RectTransform));
					gameObject3.transform.SetParent(gameObject2.transform);
					gameObject3.transform.SetAsLastSibling();
					BE2_NoViewBlockSectionHeader header = gameObject3.AddComponent<BE2_NoViewBlockSectionHeader>();
					bE2_NoViewBlockSection.Header = header;
				}
				if (i_BE2_BlockSection.Body != null)
				{
					GameObject gameObject4 = new GameObject("body", typeof(RectTransform));
					gameObject4.transform.SetParent(gameObject2.transform);
					gameObject4.transform.SetAsLastSibling();
					BE2_NoViewBlockSectionBody body = gameObject4.AddComponent<BE2_NoViewBlockSectionBody>();
					bE2_NoViewBlockSection.Body = body;
				}
			}
			bE2_BlockNoViewLayout.Initialize();
			i_BE2_Instruction = gameObject.AddComponent(typeof(T)) as I_BE2_Instruction;
			if (i_BE2_Instruction is BE2_Ins_FunctionBlock)
			{
				(i_BE2_Instruction as BE2_Ins_FunctionBlock).Initialize((block.Instruction as BE2_Ins_FunctionBlock).defineInstruction);
			}
			i_BE2_Block.Instruction = i_BE2_Instruction;
			if (i_BE2_Block.Type == BlockTypeEnum.operation)
			{
				gameObject.AddComponent<BE2_BlockSectionHeader_Operation>();
			}
			return i_BE2_Block;
		}
	}
}
