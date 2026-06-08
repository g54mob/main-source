using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	[ExecuteInEditMode]
	public class UIManagerHSelector : MonoBehaviour
	{
		public UIManager UIManagerAsset;

		public List<GameObject> images = new List<GameObject>();

		public List<GameObject> imagesHighlighted = new List<GameObject>();

		public List<GameObject> texts = new List<GameObject>();

		private bool dynamicUpdateEnabled;

		private HorizontalSelector hSelector;

		private void OnEnable()
		{
			try
			{
				hSelector = base.gameObject.GetComponent<HorizontalSelector>();
			}
			catch
			{
			}
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
				UpdateSelector();
			}
		}

		private void LateUpdate()
		{
			if (Application.isEditor && UIManagerAsset != null)
			{
				if (UIManagerAsset.enableDynamicUpdate)
				{
					dynamicUpdateEnabled = true;
					UpdateSelector();
				}
				else
				{
					dynamicUpdateEnabled = false;
				}
			}
		}

		private void UpdateSelector()
		{
			for (int i = 0; i < images.Count; i++)
			{
				Image component = images[i].GetComponent<Image>();
				component.color = new Color(UIManagerAsset.selectorColor.r, UIManagerAsset.selectorColor.g, UIManagerAsset.selectorColor.b, component.color.a);
			}
			for (int j = 0; j < imagesHighlighted.Count; j++)
			{
				Image component2 = imagesHighlighted[j].GetComponent<Image>();
				component2.color = new Color(UIManagerAsset.selectorHighlightedColor.r, UIManagerAsset.selectorHighlightedColor.g, UIManagerAsset.selectorHighlightedColor.b, component2.color.a);
			}
			for (int k = 0; k < texts.Count; k++)
			{
				TextMeshProUGUI component3 = texts[k].GetComponent<TextMeshProUGUI>();
				component3.color = new Color(UIManagerAsset.selectorColor.r, UIManagerAsset.selectorColor.g, UIManagerAsset.selectorColor.b, component3.color.a);
				component3.font = UIManagerAsset.selectorFont;
				component3.fontSize = UIManagerAsset.hSelectorFontSize;
			}
			if (hSelector != null)
			{
				hSelector.invertAnimation = UIManagerAsset.hSelectorInvertAnimation;
				hSelector.loopSelection = UIManagerAsset.hSelectorLoopSelection;
			}
		}
	}
}
