using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class ButtonGroup : MonoBehaviour
	{
		[SerializeField]
		private Button[] _button;

		private void Awake()
		{
			int i;
			for (i = 0; i < _button.Length; i++)
			{
				_button[i].onClick.AddListener(delegate
				{
					OnButtonClick(i);
				});
			}
		}

		private void OnButtonClick(int p_btnIdx)
		{
			for (int i = 0; i < _button.Length; i++)
			{
				_button[i].interactable = i != p_btnIdx;
			}
		}
	}
}
