using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CurvedUI
{
	public class CUI_ChangeValueOnHold : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		private bool pressed;

		private bool selected;

		[SerializeField]
		private Image bg;

		[SerializeField]
		private Color SelectedColor;

		[SerializeField]
		private Color NormalColor;

		[SerializeField]
		private CanvasGroup IntroCG;

		[SerializeField]
		private CanvasGroup MenuCG;

		private void Update()
		{
			pressed = Input.GetKey(KeyCode.Space) || Input.GetButton("Fire1");
			ChangeVal();
		}

		private void ChangeVal()
		{
			if (GetComponent<Slider>().normalizedValue == 1f)
			{
				IntroCG.alpha -= Time.deltaTime;
				MenuCG.alpha += Time.deltaTime;
			}
			else
			{
				GetComponent<Slider>().normalizedValue += ((pressed && selected) ? Time.deltaTime : (0f - Time.deltaTime));
			}
			IntroCG.blocksRaycasts = IntroCG.alpha > 0f;
		}

		public void OnPointerEnter(PointerEventData data)
		{
			bg.color = SelectedColor;
			bg.GetComponent<CurvedUIVertexEffect>().TesselationRequired = true;
			selected = true;
		}

		public void OnPointerExit(PointerEventData data)
		{
			bg.color = NormalColor;
			bg.GetComponent<CurvedUIVertexEffect>().TesselationRequired = true;
			selected = false;
		}
	}
}
