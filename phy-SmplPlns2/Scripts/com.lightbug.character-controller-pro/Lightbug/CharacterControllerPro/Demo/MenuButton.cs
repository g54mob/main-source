using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class MenuButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField]
		private string sceneName = "";

		[SerializeField]
		private Color highlightColor = Color.green;

		[SerializeField]
		private float lerpSpeed = 5f;

		private Color normalColor;

		private Image image;

		private bool enter;

		private void Awake()
		{
			image = GetComponent<Image>();
			if (image == null)
			{
				base.enabled = false;
			}
			else
			{
				normalColor = image.color;
			}
		}

		private void Update()
		{
			image.color = Color.Lerp(image.color, enter ? highlightColor : normalColor, lerpSpeed * Time.deltaTime);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			MainMenuManager.Instance.GoToScene(sceneName);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			enter = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			enter = false;
		}
	}
}
