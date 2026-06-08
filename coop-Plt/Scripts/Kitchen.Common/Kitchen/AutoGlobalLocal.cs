using System.Collections.Generic;
using System.Linq;
using KitchenData;
using TMPro;
using UnityEngine;

namespace Kitchen
{
	[RequireComponent(typeof(TextMeshPro))]
	public class AutoGlobalLocal : MonoBehaviour
	{
		private const string CONSOLE_JOIN_PROMPT = "PRESS_ANY_BUTTON";

		private const string NORMAL_JOIN_PROMPT = "JOIN_PROMPT_PRESS";

		public string Text;

		public List<string> Variables = new List<string>();

		private void Awake()
		{
			if (GameData.Main != null && GameData.Main.GlobalLocalisation != null)
			{
				GetComponent<TextMeshPro>().text = GameData.Main.Parse(GameData.Main.GlobalLocalisation[Text, Variables.Cast<object>().ToArray()]);
			}
		}
	}
}
