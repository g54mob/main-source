using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.UI;
using MG_BlocksEngine2.Utils;
using UnityEngine;

namespace MG_BlocksEngine2.EditorScript
{
	public class BE2_Inspector : MonoBehaviour
	{
		private static BE2_Inspector _instance;

		public GameObject BlockTemplate;

		public GameObject SimpleTemplate;

		public GameObject TriggerTemplate;

		public GameObject OperationTemplate;

		public GameObject SectionTemplate;

		public GameObject HeaderTemplate;

		public GameObject HeaderMiddleTemplate;

		public GameObject BodyEndTemplate;

		public GameObject BodyMiddleTemplate;

		public GameObject OuterAreaTemplate;

		public GameObject DropdownTemplate;

		public GameObject InputFieldTemplate;

		public GameObject LabelTextTemplate;

		public string instructionName;

		public BlockTypeEnum blockType;

		public Color blockColor;

		public string blockHeaderMarkup;

		public string[] inputValues;

		public string newInstructionPath = "[dataPath]/BlocksEngine2/Scripts/EngineCore/Instruction/BlockInstructions/Custom/";

		public string newBlockPrefabPath = "Assets/BlocksEngine2/Prefabs/Resources/Blocks/Custom/";

		public bool usePersistentPathOnBuild = true;

		public string savedCodesPath = "[dataPath]/BlocksEngine2/Saves/";

		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private RenderMode _canvasRenderMode;

		public bool autoSetDragDropDetectionDistance = true;

		public static BE2_Inspector Instance
		{
			get
			{
				if (!_instance)
				{
					_instance = UnityEngine.Object.FindObjectOfType<BE2_Inspector>();
				}
				return _instance;
			}
			set
			{
				_instance = value;
			}
		}

		public Camera Camera
		{
			get
			{
				if (!_camera)
				{
					_camera = Camera.main;
				}
				return _camera;
			}
			set
			{
				_camera = value;
			}
		}

		public RenderMode CanvasRenderMode
		{
			get
			{
				return _canvasRenderMode;
			}
			set
			{
				BE2_Canvas[] array = UnityEngine.Object.FindObjectsOfType<BE2_Canvas>();
				foreach (BE2_Canvas obj in array)
				{
					obj.Canvas.renderMode = value;
					obj.Canvas.worldCamera = Camera;
					obj.Canvas.planeDistance = 10f;
				}
				_canvasRenderMode = value;
			}
		}

		public void TryAddInstructionToBlock(string className, GameObject blockGO)
		{
			if (TryGetType(className) == null)
			{
				Debug.Log("- Instruction not added");
				return;
			}
			blockGO.AddComponent(TryGetType(className));
			Debug.Log("+ Instruction added");
		}

		public Type TryGetType(string typeName)
		{
			Type type = Type.GetType(typeName);
			if (type != null)
			{
				return type;
			}
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				type = assemblies[i].GetType(typeName);
				if (type != null)
				{
					return type;
				}
			}
			return null;
		}

		public void AddBlockToSelectionMenu(Transform blockTransform)
		{
			StartCoroutine(C_AddBlockToSelectionMenu(blockTransform));
		}

		private IEnumerator C_AddBlockToSelectionMenu(Transform blockTransform)
		{
			yield return new WaitForEndOfFrame();
			BE2_UI_BlocksSelectionViewer bE2_UI_BlocksSelectionViewer = UnityEngine.Object.FindObjectOfType<BE2_UI_BlocksSelectionViewer>();
			bE2_UI_BlocksSelectionViewer.UpdateSelectionPanels();
			bE2_UI_BlocksSelectionViewer.AddBlockToPanel(blockTransform, bE2_UI_BlocksSelectionViewer.selectionPanelsList[bE2_UI_BlocksSelectionViewer.selectionPanelsList.Count - 1]);
		}

		public Transform BuildAndInstantiateBlock(string instructionName)
		{
			GameObject gameObject = ((blockType == BlockTypeEnum.simple) ? UnityEngine.Object.Instantiate(SimpleTemplate, new Vector3(219f, -219f, 0f), Quaternion.identity, UnityEngine.Object.FindObjectOfType<BE2_ProgrammingEnv>().transform) : ((blockType == BlockTypeEnum.trigger) ? UnityEngine.Object.Instantiate(TriggerTemplate, new Vector3(219f, -219f, 0f), Quaternion.identity, UnityEngine.Object.FindObjectOfType<BE2_ProgrammingEnv>().transform) : ((blockType != BlockTypeEnum.operation) ? UnityEngine.Object.Instantiate(BlockTemplate, new Vector3(219f, -219f, 0f), Quaternion.identity, UnityEngine.Object.FindObjectOfType<BE2_ProgrammingEnv>().transform) : UnityEngine.Object.Instantiate(OperationTemplate, new Vector3(219f, -219f, 0f), Quaternion.identity, UnityEngine.Object.FindObjectOfType<BE2_ProgrammingEnv>().transform))));
			gameObject.name = "Block Cst " + instructionName;
			gameObject.transform.localPosition = new Vector3(219f, -219f, 0f);
			Transform transform = gameObject.transform;
			I_BE2_Block component = gameObject.GetComponent<I_BE2_Block>();
			I_BE2_BlockLayout component2 = gameObject.GetComponent<I_BE2_BlockLayout>();
			if (blockType == BlockTypeEnum.loop)
			{
				component.Type = BlockTypeEnum.loop;
			}
			component2.Color = blockColor;
			string[] array = blockHeaderMarkup.Split('\n');
			int num = 0;
			for (int i = 0; i < array.Length; i++)
			{
				GameObject gameObject2;
				GameObject gameObject3;
				if (i == 0)
				{
					gameObject2 = transform.GetChild(0).gameObject;
					gameObject3 = gameObject2.transform.GetChild(0).gameObject;
				}
				else
				{
					gameObject2 = UnityEngine.Object.Instantiate(SectionTemplate, Vector3.zero, Quaternion.identity, transform);
					gameObject3 = UnityEngine.Object.Instantiate(HeaderMiddleTemplate, Vector3.zero, Quaternion.identity, gameObject2.transform);
				}
				if (blockType == BlockTypeEnum.condition || blockType == BlockTypeEnum.loop)
				{
					if (i == array.Length - 1)
					{
						UnityEngine.Object.Instantiate(BodyEndTemplate, Vector3.zero, Quaternion.identity, gameObject2.transform);
					}
					else
					{
						UnityEngine.Object.Instantiate(BodyMiddleTemplate, Vector3.zero, Quaternion.identity, gameObject2.transform);
					}
				}
				List<string> list = new List<string>();
				string text = "";
				bool flag = false;
				for (int j = 0; j < array[i].Length; j++)
				{
					if (array[i][j] == '$')
					{
						list.Add(text);
						text = "";
						flag = true;
					}
					if (flag && array[i][j] == ' ')
					{
						list.Add(text);
						text = "";
						flag = false;
					}
					text += array[i][j];
				}
				list.Add(text);
				for (int k = 0; k < list.Count; k++)
				{
					if (list[k] == "$text")
					{
						BE2_InputField.GetBE2Component(UnityEngine.Object.Instantiate(InputFieldTemplate, Vector3.zero, Quaternion.identity, gameObject3.transform).transform).text = inputValues[num].TrimEnd(' ').TrimStart(' ');
						num++;
					}
					else if (list[k] == "$dropdown")
					{
						BE2_Dropdown bE2Component = BE2_Dropdown.GetBE2Component(UnityEngine.Object.Instantiate(DropdownTemplate, Vector3.zero, Quaternion.identity, gameObject3.transform).transform);
						bE2Component.ClearOptions();
						string[] array2 = inputValues[num].Split(',');
						foreach (string text2 in array2)
						{
							bE2Component.AddOption(text2.TrimEnd(' ').TrimStart(' '));
						}
						num++;
					}
					else
					{
						BE2_Text.GetBE2Text(UnityEngine.Object.Instantiate(LabelTextTemplate, Vector3.zero, Quaternion.identity, gameObject3.transform).transform).text = list[k].TrimEnd(' ').TrimStart(' ');
					}
				}
			}
			if (blockType == BlockTypeEnum.condition || blockType == BlockTypeEnum.loop)
			{
				UnityEngine.Object.Instantiate(OuterAreaTemplate, Vector3.zero, Quaternion.identity, transform);
			}
			gameObject.GetComponent<I_BE2_BlockLayout>().UpdateLayout();
			Debug.Log("+ Block created");
			return transform;
		}

		public List<int> AllIndexesOf(string str, string value)
		{
			List<int> list = new List<int>();
			int startIndex = 0;
			while (true)
			{
				startIndex = str.IndexOf(value, startIndex);
				if (startIndex == -1)
				{
					break;
				}
				list.Add(startIndex);
				startIndex += value.Length;
			}
			return list;
		}

		public string CreateInstructionScript(string instructionName)
		{
			Debug.Log("+ Start creating instruction");
			string text = BE2_Paths.TranslateMarkupPath(BE2_Paths.NewInstructionPath);
			StreamReader streamReader = new StreamReader(Application.dataPath + "/7_Assets/BlocksEngine2/Scripts/EditorScripts/InstructionScriptTemplate.txt");
			string text2 = streamReader.ReadToEnd();
			streamReader.Close();
			string[] array = text2.Split("\n"[0]);
			string text3 = "BE2_Cst_" + instructionName;
			string path = text + text3 + ".cs";
			if (!File.Exists(path))
			{
				using StreamWriter streamWriter = new StreamWriter(path);
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text4;
					if ((text4 = array2[i]).Contains("[instructionName]"))
					{
						text4 = text4.Replace("[instructionName]", text3);
					}
					streamWriter.WriteLine(text4);
				}
			}
			else
			{
				Debug.Log("- Instruction already exists");
			}
			return text3;
		}
	}
}
