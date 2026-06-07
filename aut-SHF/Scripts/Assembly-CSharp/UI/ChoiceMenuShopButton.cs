using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class ChoiceMenuShopButton : MonoBehaviour
	{
		public TMP_Text price;

		public Image mainImage;

		public GameObject soldOut;

		public Button buttonComponent;

		public ShopData shopData;

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

		public void InitComponent(ShopData shopData, string iconPath)
		{
		}

		public void UpdatePrice()
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
