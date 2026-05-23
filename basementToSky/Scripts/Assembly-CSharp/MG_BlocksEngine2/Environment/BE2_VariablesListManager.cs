using System.Collections.Generic;
using System.Globalization;
using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.UI;
using UnityEngine;

namespace MG_BlocksEngine2.Environment
{
	public class BE2_VariablesListManager : MonoBehaviour, I_BE2_VariablesManager
	{
		public static BE2_VariablesListManager instance;

		public BE2_UI_NewVariableListPanel newListPanel;

		public Dictionary<string, List<string>> lists = new Dictionary<string, List<string>>();

		private void Awake()
		{
			instance = this;
		}

		public bool ContainsList(string listName)
		{
			return lists.ContainsKey(listName);
		}

		public bool ListContainsValue(string listName, string value)
		{
			if (lists.ContainsKey(listName))
			{
				return lists[listName].Contains(value);
			}
			return false;
		}

		public void AddOrUpdateList(string listName, List<string> value)
		{
			if (!lists.ContainsKey(listName))
			{
				lists.Add(listName, value);
				BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnAnyVariableAddedOrRemoved);
			}
			else
			{
				lists[listName] = value;
			}
			BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnAnyVariableValueChanged);
		}

		public void AddValueInList(string listName, string value)
		{
			if (!lists.ContainsKey(listName))
			{
				lists.Add(listName, new List<string> { value });
				BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnAnyVariableAddedOrRemoved);
			}
			else
			{
				lists[listName].Add(value);
			}
			BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnAnyVariableValueChanged);
		}

		public void InsertValueInList(string listName, string value, int index)
		{
			if (lists.ContainsKey(listName) && index >= 0 && lists[listName].Count >= index)
			{
				lists[listName].Insert(index, value);
				BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnAnyVariableValueChanged);
			}
		}

		public void ReplaceValueInList(string listName, string value, int index)
		{
			if (lists.ContainsKey(listName) && index >= 0 && lists[listName].Count > index)
			{
				lists[listName][index] = value;
				BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnAnyVariableValueChanged);
			}
		}

		public void RemoveList(string listName)
		{
			if (lists.ContainsKey(listName))
			{
				lists.Remove(listName);
				BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnAnyVariableAddedOrRemoved);
				BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnAnyVariableValueChanged);
			}
		}

		public void ClearList(string listName)
		{
			if (lists.ContainsKey(listName))
			{
				lists[listName].Clear();
				BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnAnyVariableAddedOrRemoved);
				BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnAnyVariableValueChanged);
			}
		}

		public void RemoveListItem(string listName, int index)
		{
			if (lists.ContainsKey(listName) && index >= 0 && lists[listName].Count > index)
			{
				lists[listName].RemoveAt(index);
				BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnAnyVariableAddedOrRemoved);
				BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnAnyVariableValueChanged);
			}
		}

		public void RemoveListItem(string listName, string value)
		{
			if (lists.ContainsKey(listName) && lists[listName].Contains(value))
			{
				lists[listName].Remove(value);
				BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnAnyVariableAddedOrRemoved);
				BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnAnyVariableValueChanged);
			}
		}

		public int GetValueIndexAtList(string listName, string value)
		{
			if (lists.ContainsKey(listName))
			{
				if (lists[listName].Contains(value))
				{
					return lists[listName].IndexOf(value);
				}
				return -1;
			}
			return -1;
		}

		public List<string> GetListStringValues(string listName)
		{
			if (lists.ContainsKey(listName))
			{
				return lists[listName];
			}
			return new List<string> { "" };
		}

		public string GetListStringValue(string listName, int index)
		{
			List<string> listStringValues = GetListStringValues(listName);
			if (listStringValues.Count > index && index >= 0)
			{
				return listStringValues[index];
			}
			return "";
		}

		public List<float> GetListFloatValues(string listName)
		{
			if (lists.ContainsKey(listName))
			{
				List<float> list = new List<float>();
				{
					foreach (string item2 in lists[listName])
					{
						try
						{
							float item = float.Parse(item2, CultureInfo.InvariantCulture);
							list.Add(item);
						}
						catch
						{
							list.Add(0f);
						}
					}
					return list;
				}
			}
			return new List<float> { 0f };
		}

		public float GetListFloatValue(string listName, int index)
		{
			List<float> listFloatValues = GetListFloatValues(listName);
			if (listFloatValues.Count > index)
			{
				return listFloatValues[index];
			}
			return 0f;
		}

		public List<BE2_InputValues> GetListValues(string listName)
		{
			List<BE2_InputValues> list = new List<BE2_InputValues>();
			if (lists.ContainsKey(listName))
			{
				foreach (string item in lists[listName])
				{
					bool flag = false;
					float floatValue = 0f;
					try
					{
						floatValue = float.Parse(item, CultureInfo.InvariantCulture);
						flag = false;
					}
					catch
					{
						flag = true;
					}
					list.Add(new BE2_InputValues(item, floatValue, flag));
				}
				return list;
			}
			return new List<BE2_InputValues>
			{
				new BE2_InputValues("", 0f, isText: false)
			};
		}

		public BE2_InputValues GetListValue(string listName, int index)
		{
			List<BE2_InputValues> listValues = GetListValues(listName);
			if (listValues.Count > index)
			{
				return listValues[index];
			}
			return new BE2_InputValues("", 0f, isText: false);
		}

		public void CreateAndAddVarToPanel(string listName)
		{
			if ((bool)newListPanel)
			{
				newListPanel.CreateList(listName);
			}
		}
	}
}
