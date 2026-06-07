using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class ResearchMenuButton : MonoBehaviour
	{
		public TMP_Text price;

		public Image mainImage;

		public GameObject check;

		public Button buttonComponent;

		[NonSerialized]
		public ResearchTreeDataUnit researchData;

		[NonSerialized]
		public List<ResearchTreeDataUnit> childList;

		public bool ValidPurchase => false;

		public event UnityAction OnClickAction
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event UnityAction OnPointerOverAction
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event UnityAction OnPointerExitAction
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void InitComponent(ResearchTreeDataUnit researchData)
		{
		}

		public void UpdatePrice()
		{
		}

		public void Purchase()
		{
		}

		public void ResetEvent()
		{
		}

		public void OnClick()
		{
		}

		public void OnPointerOver()
		{
		}

		public void OnPointerExit()
		{
		}
	}
}
