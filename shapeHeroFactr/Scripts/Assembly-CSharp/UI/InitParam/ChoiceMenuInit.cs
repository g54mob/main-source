using UnityEngine.Events;

namespace UI.InitParam
{
	public class ChoiceMenuInit
	{
		public readonly string TitleText;

		public readonly string DescText;

		public readonly ChoiceMenuButtonInitBase[] Items;

		public readonly ChoiceMenuButtonBase ButtonPrefab;

		public readonly UnityAction<int> CallBack;

		public ChoiceMenuInit(string titleText, string descText, ChoiceMenuButtonInitBase[] items, ChoiceMenuButtonBase buttonPrefab, UnityAction<int> callBack)
		{
		}
	}
}
