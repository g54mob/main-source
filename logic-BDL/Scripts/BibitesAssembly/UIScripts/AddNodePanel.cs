using System;
using System.Collections.Generic;
using System.Linq;
using SimulationScripts.BibiteScripts;
using TMPro;
using UIScripts.InfoHandles;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIScripts
{
	public class AddNodePanel : MonoBehaviour
	{
		public GameObject itemPrefab;

		[SerializeField]
		private GameObject inputSection;

		[SerializeField]
		private Transform inputHolder;

		[SerializeField]
		private GameObject outputSection;

		[SerializeField]
		private Transform outputHolder;

		[SerializeField]
		private GameObject hiddenSection;

		[SerializeField]
		private Transform hiddenHolder;

		[SerializeField]
		private FloatValueTextHandle nInputs;

		[SerializeField]
		private FloatValueTextHandle nOutputs;

		[SerializeField]
		private FloatValueTextHandle nHidden;

		[SerializeField]
		private TMP_InputField filterField;

		private Dictionary<int, AddNodeItem> availableInputs = new Dictionary<int, AddNodeItem>();

		private Dictionary<int, AddNodeItem> unavailableInputs = new Dictionary<int, AddNodeItem>();

		private Dictionary<int, AddNodeItem> availableOutputs = new Dictionary<int, AddNodeItem>();

		private Dictionary<int, AddNodeItem> unavailableOutputs = new Dictionary<int, AddNodeItem>();

		private Dictionary<int, AddNodeItem> availableFunctions = new Dictionary<int, AddNodeItem>();

		[NonSerialized]
		public RectTransform rt;

		private NEATBrain.NodeArchetype unavailableArchetype;

		private int nI;

		private int nO;

		private int nH;

		private bool hasInit;

		public void Init()
		{
			if (hasInit)
			{
				return;
			}
			foreach (NEATBrain.Inputs value in Enum.GetValues(typeof(NEATBrain.Inputs)))
			{
				AddNodeItem component = UnityEngine.Object.Instantiate(itemPrefab, inputHolder).GetComponent<AddNodeItem>();
				component.InitItem((int)value, value.ToString(), NEATBrain.NodeArchetype.Input);
				component.itemClicked.AddListener(ItemClicked);
				availableInputs.Add((int)value, component);
			}
			foreach (NEATBrain.Outputs value2 in Enum.GetValues(typeof(NEATBrain.Outputs)))
			{
				AddNodeItem component2 = UnityEngine.Object.Instantiate(itemPrefab, outputHolder).GetComponent<AddNodeItem>();
				component2.InitItem((int)value2, value2.ToString(), NEATBrain.NodeArchetype.Output);
				component2.itemClicked.AddListener(ItemClicked);
				availableOutputs.Add((int)value2, component2);
			}
			foreach (NEATBrain.NodeType value3 in Enum.GetValues(typeof(NEATBrain.NodeType)))
			{
				if (value3 != NEATBrain.NodeType.Input)
				{
					AddNodeItem component3 = UnityEngine.Object.Instantiate(itemPrefab, hiddenHolder).GetComponent<AddNodeItem>();
					component3.InitItem((int)value3, value3.ToString(), NEATBrain.NodeArchetype.Hidden);
					component3.itemClicked.AddListener(ItemClicked);
					availableFunctions.Add((int)value3, component3);
				}
			}
			filterField.onValueChanged.AddListener(Filter);
			rt = GetComponent<RectTransform>();
			hasInit = true;
		}

		public void RequestAddNode(Vector2 pos, Vector2 pivot, NEATBrain.NodeArchetype dontShow)
		{
			rt.pivot = pivot;
			rt.anchoredPosition = pos;
			unavailableArchetype = dontShow;
			base.gameObject.SetActive(value: true);
			filterField.text = "";
			Filter("");
			filterField.ActivateInputField();
			EventSystem.current.SetSelectedGameObject(filterField.gameObject);
			filterField.ActivateInputField();
		}

		public void Hide()
		{
			base.gameObject.SetActive(value: false);
		}

		public void Update()
		{
			if (!Input.GetKeyDown(KeyCode.Return) || nI + nO + nH != 1)
			{
				return;
			}
			if (nI == 1)
			{
				ItemClicked(availableInputs.FirstOrDefault((KeyValuePair<int, AddNodeItem> i) => i.Value.present).Value);
			}
			else if (nO == 1)
			{
				ItemClicked(availableOutputs.FirstOrDefault((KeyValuePair<int, AddNodeItem> i) => i.Value.present).Value);
			}
			else if (nH == 1)
			{
				ItemClicked(availableFunctions.FirstOrDefault((KeyValuePair<int, AddNodeItem> i) => i.Value.present).Value);
			}
		}

		public void ItemClicked(AddNodeItem item)
		{
			BibiteBrainEditor.instance.AddNode(item.index + ((item.archetype == NEATBrain.NodeArchetype.Output) ? NEATBrain.NInputs : 0), item.archetype);
		}

		private void Filter(string val)
		{
			nI = 0;
			foreach (KeyValuePair<int, AddNodeItem> availableInput in availableInputs)
			{
				if (availableInput.Value.Filter(val))
				{
					nI++;
				}
			}
			nO = 0;
			foreach (KeyValuePair<int, AddNodeItem> availableOutput in availableOutputs)
			{
				if (availableOutput.Value.Filter(val))
				{
					nO++;
				}
			}
			nH = 0;
			foreach (KeyValuePair<int, AddNodeItem> availableFunction in availableFunctions)
			{
				if (availableFunction.Value.Filter(val))
				{
					nH++;
				}
			}
			nInputs.UpdateValue(nI);
			inputSection.SetActive(nI > 0 && unavailableArchetype != NEATBrain.NodeArchetype.Input);
			nOutputs.UpdateValue(nO);
			outputSection.SetActive(nO > 0 && unavailableArchetype != NEATBrain.NodeArchetype.Output);
			nHidden.UpdateValue(nH);
			hiddenSection.SetActive(nH > 0);
		}

		public void ResetAvailabilities()
		{
			foreach (KeyValuePair<int, AddNodeItem> unavailableInput in unavailableInputs)
			{
				availableInputs.Add(unavailableInput.Key, unavailableInput.Value);
				unavailableInput.Value.SetPresent(value: true);
			}
			unavailableInputs.Clear();
			foreach (KeyValuePair<int, AddNodeItem> unavailableOutput in unavailableOutputs)
			{
				availableOutputs.Add(unavailableOutput.Key, unavailableOutput.Value);
				unavailableOutput.Value.SetPresent(value: true);
			}
			unavailableOutputs.Clear();
		}

		public void SetIndexAvailability(int i, NEATBrain.NodeArchetype archetype, bool available)
		{
			switch (archetype)
			{
			case NEATBrain.NodeArchetype.Input:
				if (!(available ? availableInputs : unavailableInputs).ContainsKey(i))
				{
					(available ? availableInputs : unavailableInputs).Add(i, (available ? unavailableInputs : availableInputs)[i]);
				}
				(available ? unavailableInputs : availableInputs).Remove(i);
				(available ? availableInputs : unavailableInputs)[i].SetPresent(available);
				break;
			case NEATBrain.NodeArchetype.Output:
				i -= NEATBrain.NInputs;
				if (!(available ? availableOutputs : unavailableOutputs).ContainsKey(i))
				{
					(available ? availableOutputs : unavailableOutputs).Add(i, (available ? unavailableOutputs : availableOutputs)[i]);
				}
				(available ? unavailableOutputs : availableOutputs).Remove(i);
				(available ? availableOutputs : unavailableOutputs)[i].SetPresent(available);
				break;
			}
		}
	}
}
