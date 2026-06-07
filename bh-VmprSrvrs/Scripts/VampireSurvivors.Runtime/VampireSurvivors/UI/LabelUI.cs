using TMPro;
using UnityEngine;

namespace VampireSurvivors.UI
{
	public class LabelUI : MonoBehaviour, IUIObject
	{
		[SerializeField]
		private TextMeshProUGUI _Label;

		public void SetLabel(string text)
		{
		}

		public GameObject GetGameObject()
		{
			return null;
		}
	}
}
