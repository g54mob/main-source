using TMPro;
using UnityEngine;

namespace Assets.Behaviour.Util
{
	public class Translatable : MonoBehaviour
	{
		private void Awake()
		{
			TMP_Text component = GetComponent<TMP_Text>();
			if (!component)
			{
				Debug.LogWarning("Translatable without text component: " + base.gameObject.name);
				return;
			}
			string text = component.text;
			if (!string.IsNullOrEmpty(text))
			{
				if (text[0] != '@')
				{
					Debug.LogWarning("Hardcoded text not translatable: " + text);
				}
				else
				{
					component.TL(text);
				}
			}
		}
	}
}
