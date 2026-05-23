using System.Collections;
using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.UI
{
	[ExecuteInEditMode]
	public class BE2_UI_SelectionBlock : MonoBehaviour
	{
		public GameObject prefabBlock;

		private void OnEnable()
		{
			PerformCleanAndResize();
		}

		public void PerformCleanAndResize()
		{
			if ((bool)prefabBlock)
			{
				StartCoroutine(C_PerformCleanAndResize());
			}
		}

		private IEnumerator C_PerformCleanAndResize()
		{
			PerformResize();
			yield return new WaitForEndOfFrame();
			I_BE2_Block component = prefabBlock.GetComponent<I_BE2_Block>();
			if (!component.BlockIsVariable() && !component.BlockIsFunction())
			{
				PerformClean();
			}
		}

		private void PerformClean()
		{
			LayoutGroup component = base.transform.GetComponent<LayoutGroup>();
			if ((bool)component)
			{
				Object.DestroyImmediate(component);
			}
			base.transform.GetComponent<RectTransform>().sizeDelta = prefabBlock.transform.GetComponent<RectTransform>().sizeDelta;
			for (int i = 0; i < base.transform.childCount; i++)
			{
				Transform child = base.transform.GetChild(i);
				Transform child2 = prefabBlock.transform.GetChild(i);
				LayoutGroup component2 = child.GetComponent<LayoutGroup>();
				if ((bool)component2)
				{
					Object.DestroyImmediate(component2);
				}
				if ((bool)child2.GetComponent<BE2_SpotOuterArea>())
				{
					Object.DestroyImmediate(child.gameObject);
				}
				else
				{
					child.GetComponent<RectTransform>().sizeDelta = child2.GetComponent<RectTransform>().sizeDelta;
				}
				for (int j = 0; j < child.childCount; j++)
				{
					Transform child3 = child.GetChild(j);
					Transform child4 = child2.GetChild(j);
					LayoutGroup component3 = child3.GetComponent<LayoutGroup>();
					if ((bool)component3)
					{
						Object.DestroyImmediate(component3);
					}
					child3.GetComponent<RectTransform>().sizeDelta = child4.GetComponent<RectTransform>().sizeDelta;
					for (int k = 0; k < child3.childCount; k++)
					{
						Transform child5 = child3.GetChild(k);
						Transform child6 = child4.GetChild(k);
						LayoutGroup component4 = child5.GetComponent<LayoutGroup>();
						if ((bool)component4)
						{
							Object.DestroyImmediate(component4);
						}
						if (!child5.GetComponent<ContentSizeFitter>())
						{
							child5.GetComponent<RectTransform>().sizeDelta = child6.GetComponent<RectTransform>().sizeDelta;
						}
						Selectable component5 = child5.GetComponent<Selectable>();
						if ((bool)component5)
						{
							component5.interactable = true;
						}
						Image component6 = child5.GetComponent<Image>();
						if ((bool)component6)
						{
							component6.raycastTarget = false;
						}
						BE2_DropdownDynamicResize component7 = child5.GetComponent<BE2_DropdownDynamicResize>();
						if ((bool)component7)
						{
							Object.DestroyImmediate(component7);
						}
						BE2_InputFieldDynamicResize component8 = child5.GetComponent<BE2_InputFieldDynamicResize>();
						if ((bool)component8)
						{
							Object.DestroyImmediate(component8);
						}
						BE2_Dropdown bE2Component = BE2_Dropdown.GetBE2Component(child5);
						if (bE2Component != null && !bE2Component.isNull)
						{
							bE2Component.enabled = false;
							Image[] componentsInChildren = child5.GetComponentsInChildren<Image>();
							for (int num = componentsInChildren.Length - 1; num >= 0; num--)
							{
								componentsInChildren[num].raycastTarget = false;
							}
						}
						BE2_InputField bE2Component2 = BE2_InputField.GetBE2Component(child5);
						if (bE2Component2 != null && !bE2Component2.isNull)
						{
							bE2Component2.enabled = false;
						}
					}
				}
			}
			RectMask2D[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<RectMask2D>();
			for (int num2 = componentsInChildren2.Length - 1; num2 >= 0; num2--)
			{
				componentsInChildren2[num2].enabled = false;
			}
			TMP_Text[] componentsInChildren3 = base.gameObject.GetComponentsInChildren<TMP_Text>();
			for (int num3 = componentsInChildren3.Length - 1; num3 >= 0; num3--)
			{
				componentsInChildren3[num3].isTextObjectScaleStatic = true;
				componentsInChildren3[num3].raycastTarget = false;
			}
		}

		private void PerformResize()
		{
			for (int i = 0; i < base.transform.childCount; i++)
			{
				Transform child = base.transform.GetChild(i);
				Transform child2 = prefabBlock.transform.GetChild(i);
				for (int j = 0; j < child.childCount; j++)
				{
					Transform child3 = child.GetChild(j);
					child2.GetChild(j);
					for (int k = 0; k < child3.childCount; k++)
					{
						Transform child4 = child3.GetChild(k);
						if (((bool)child4.GetComponent<Text>() || (bool)child4.GetComponent<TMP_Text>()) && !child4.gameObject.GetComponent<ContentSizeFitter>())
						{
							child4.gameObject.AddComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
						}
					}
				}
			}
		}
	}
}
