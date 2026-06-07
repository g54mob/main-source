using System.Collections.Generic;
using System.Linq;
using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.DragDrop;
using MG_BlocksEngine2.EditorScript;
using MG_BlocksEngine2.Serializer;
using MG_BlocksEngine2.Utils;
using TMPro;
using UnityEngine;

namespace MG_BlocksEngine2.Environment
{
	public class BE2_VerticalFunctionBlocksManager : BE2_FunctionBlocksManager
	{
		public override void CreateFunctionBlock(List<DefineItem> items)
		{
			I_BE2_ProgrammingEnv i_BE2_ProgrammingEnv = BE2_ExecutionManager.Instance.ProgrammingEnvsList.Find((I_BE2_ProgrammingEnv x) => x.Visible);
			BE2_Ins_DefineFunction component = DefineFunctionBlockTemplate.GetComponent<BE2_Ins_DefineFunction>();
			BE2_Ins_DefineFunction bE2_Ins_DefineFunction = Object.Instantiate(component, Vector3.zero, Quaternion.identity, i_BE2_ProgrammingEnv.Transform);
			I_BE2_BlockLayout component2 = bE2_Ins_DefineFunction.GetComponent<I_BE2_BlockLayout>();
			bE2_Ins_DefineFunction.name = component.name;
			bE2_Ins_DefineFunction.transform.localPosition = positionToInstantiate;
			List<string> list = new List<string>();
			foreach (DefineItem item in items)
			{
				if (item.type == "label")
				{
					Object.Instantiate(BE2_Inspector.Instance.LabelTextTemplate, Vector3.zero, Quaternion.identity, component2.SectionsArray[0].Header.RectTransform).GetComponentInChildren<TMP_Text>().text = item.value;
					continue;
				}
				GameObject obj = Object.Instantiate(templateDefineLocalVariable, Vector3.zero, Quaternion.identity, component2.SectionsArray[0].Header.RectTransform);
				string variableName = item.value;
				int num = list.Where((string s) => s == variableName).Count();
				list.Add(variableName);
				if (num > 0)
				{
					variableName = variableName + " (" + num + ")";
				}
				obj.GetComponentInChildren<TMP_Text>().text = variableName;
			}
			BE2_BlockUtils.UnloadPrefab();
			CreateSelectionFunction(items, bE2_Ins_DefineFunction);
		}

		public override void CreateSelectionFunction(List<DefineItem> items, BE2_Ins_DefineFunction defineBlockIns)
		{
			bool activeSelf = functionBlocksPanel.gameObject.activeSelf;
			functionBlocksPanel.gameObject.SetActive(value: true);
			GameObject gameObject = Object.Instantiate(templateSelectionBlock, Vector3.zero, Quaternion.identity, functionBlocksPanel);
			I_BE2_BlockLayout component = gameObject.GetComponent<I_BE2_BlockLayout>();
			foreach (DefineItem item in items)
			{
				if (item.type == "label")
				{
					Object.Instantiate(BE2_Inspector.Instance.LabelTextTemplate, Vector3.zero, Quaternion.identity, component.SectionsArray[0].Header.RectTransform).GetComponent<TMP_Text>().text = item.value;
					continue;
				}
				GameObject obj = Object.Instantiate(BE2_Inspector.Instance.InputFieldTemplate, Vector3.zero, Quaternion.identity, component.SectionsArray[0].Header.RectTransform);
				obj.GetComponent<TMP_InputField>().text = "";
				BE2_BlockUtils.RemoveEngineComponents(obj.transform);
				obj.AddComponent<BE2_BlockSectionHeader_InputField>();
			}
			component.UpdateLayout();
			gameObject.GetComponent<BE2_DragSelectionFunction>().defineFunctionInstruction = defineBlockIns;
			functionBlocksPanel.gameObject.SetActive(activeSelf);
		}
	}
}
