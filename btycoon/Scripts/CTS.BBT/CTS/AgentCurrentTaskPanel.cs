using System.Collections.Generic;
using CTS.BBT.AI;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class AgentCurrentTaskPanel : AbsAgentPanel
	{
		[SerializeField]
		private TMP_Text currentActionText;

		private static Dictionary<string, string> transtationDictionary;

		public override void ClearAgentInfo()
		{
			if (base._agent != null)
			{
				base._agent.ActionPlayer.OnActionChanged -= DisplayCurrentAction;
			}
		}

		public override void SetAgentInfo()
		{
			base._agent.ActionPlayer.OnActionChanged += DisplayCurrentAction;
			DisplayCurrentAction(null);
		}

		private void DisplayCurrentAction(AgentAction action)
		{
			if (action == null)
			{
				currentActionText.text = "Doing nothing";
			}
			else
			{
				currentActionText.text = GetTextFromActionName(action.Name);
			}
		}

		private static void InitTranstationTable()
		{
			ActionNameTranstationTable actionNameTranstationTable = Resources.LoadAll<ActionNameTranstationTable>("Scriptables\\ActionDictionary")[0];
			transtationDictionary = new Dictionary<string, string>();
			for (int i = 0; i < actionNameTranstationTable.TranstationElement.Length; i++)
			{
				if (!transtationDictionary.ContainsKey(actionNameTranstationTable.TranstationElement[i]._key))
				{
					transtationDictionary.Add(actionNameTranstationTable.TranstationElement[i]._key, actionNameTranstationTable.TranstationElement[i]._text);
				}
			}
		}

		private static string GetTextFromActionName(string p_key)
		{
			if (transtationDictionary == null)
			{
				InitTranstationTable();
			}
			if (p_key == null || !transtationDictionary.ContainsKey(p_key))
			{
				return "";
			}
			return transtationDictionary[p_key];
		}
	}
}
