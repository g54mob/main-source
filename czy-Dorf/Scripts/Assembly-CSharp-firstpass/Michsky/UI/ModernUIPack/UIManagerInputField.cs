using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	[ExecuteInEditMode]
	public class UIManagerInputField : MonoBehaviour
	{
		public UIManager UIManagerAsset;

		public List<GameObject> images = new List<GameObject>();

		public List<GameObject> texts = new List<GameObject>();

		private bool dynamicUpdateEnabled;

		private void OnEnable()
		{
			if (UIManagerAsset == null)
			{
				try
				{
					UIManagerAsset = Resources.Load<UIManager>("MUIP Manager");
				}
				catch
				{
					Debug.LogWarning("No UI Manager found. Assign it manually, otherwise you'll get errors about it.", this);
				}
			}
		}

		private void Awake()
		{
			if (!dynamicUpdateEnabled)
			{
				base.enabled = true;
				UpdateInputField();
			}
		}

		private void LateUpdate()
		{
			if (UIManagerAsset != null)
			{
				if (UIManagerAsset.enableDynamicUpdate)
				{
					dynamicUpdateEnabled = true;
					UpdateInputField();
				}
				else
				{
					dynamicUpdateEnabled = false;
				}
			}
		}

		private void UpdateInputField()
		{
			for (int i = 0; i < images.Count; i++)
			{
				Image component = images[i].GetComponent<Image>();
				component.color = new Color(UIManagerAsset.inputFieldColor.r, UIManagerAsset.inputFieldColor.g, UIManagerAsset.inputFieldColor.b, component.color.a);
			}
			for (int j = 0; j < texts.Count; j++)
			{
				TextMeshProUGUI component2 = texts[j].GetComponent<TextMeshProUGUI>();
				component2.color = new Color(UIManagerAsset.inputFieldColor.r, UIManagerAsset.inputFieldColor.g, UIManagerAsset.inputFieldColor.b, component2.color.a);
				component2.font = UIManagerAsset.inputFieldFont;
				component2.fontSize = UIManagerAsset.inputFieldFontSize;
			}
		}
	}
}
