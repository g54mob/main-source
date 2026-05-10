using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class StockItemOptionPanel : MonoBehaviour
	{
		[SerializeField]
		private Button prefab;

		[SerializeField]
		private string[] buttonsNames;

		private List<Button> buttons = new List<Button>();

		private void Start()
		{
			CreateButtons();
		}

		private void CreateButtons()
		{
			for (int i = 0; i < buttonsNames.Length; i++)
			{
				Button button = Object.Instantiate(prefab, base.transform);
				button.GetComponentInChildren<TMP_Text>().text = buttonsNames[i];
				buttons.Add(button);
			}
		}
	}
}
