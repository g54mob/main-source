using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class CategoryButton : Button
	{
		[Header("Sprite")]
		[SerializeField]
		public Sprite onSprite;

		[SerializeField]
		public Sprite offSprite;

		private int myNumber;

		private UnityAction<int> onClickAction;

		public void Init(int number, UnityAction<int> onClick)
		{
		}

		public void OnClickButton()
		{
		}

		public bool UpdateStatus(int number)
		{
			return false;
		}
	}
}
