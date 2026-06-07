using UnityEngine;
using UnityEngine.UI;

namespace CurvedUI
{
	public class CUI_AnimateCurvedFillOnStart : MonoBehaviour
	{
		private void Update()
		{
			CurvedUISettings component = GetComponent<CurvedUISettings>();
			Text componentInChildren = GetComponentInChildren<Text>();
			if (Time.time < 1.5f)
			{
				component.RingFill = Mathf.PerlinNoise(Time.time * 30.23234f, Time.time * 30.2313f) * 0.15f;
				componentInChildren.text = "Accesing Mainframe...";
			}
			else if (Time.time < 2.5f)
			{
				component.RingFill = Mathf.Clamp(component.RingFill + Time.deltaTime * 3f, 0f, 1f);
				componentInChildren.text = "Mainframe Active";
			}
		}
	}
}
