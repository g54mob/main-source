using Simulator.GameWorld;
using UnityEngine;

namespace Simulator.Menus.Background
{
	public class MenuBackground : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private GameObject m_backgroundWithImage;

		[SerializeField]
		private GameObject m_backgroundWithBlur;

		private void OnEnable()
		{
			EventManager.OnMenuEvent += OnMenuEvent;
		}

		private void OnDisable()
		{
			EventManager.OnMenuEvent -= OnMenuEvent;
		}

		private void OnMenuEvent(EMenuEvent menuEvent)
		{
			switch (menuEvent)
			{
			case EMenuEvent.OPEN:
				if (World.Loaded)
				{
					SetActiveBackgroundWithBlur();
				}
				else
				{
					SetActiveBackgroundWithImage();
				}
				break;
			case EMenuEvent.CLOSE:
				DeactivateBackgrounds();
				break;
			case EMenuEvent.BACK_TO_MENU:
				SetActiveBackgroundWithImage();
				break;
			case EMenuEvent.PREPARE_QUIT:
			case EMenuEvent.QUIT:
				break;
			}
		}

		private void SetActiveBackgroundWithImage()
		{
			m_backgroundWithImage.SetActive(value: true);
			m_backgroundWithBlur.SetActive(value: false);
		}

		private void SetActiveBackgroundWithBlur()
		{
			m_backgroundWithImage.SetActive(value: false);
			m_backgroundWithBlur.SetActive(value: true);
		}

		private void DeactivateBackgrounds()
		{
			m_backgroundWithImage.SetActive(value: false);
			m_backgroundWithBlur.SetActive(value: false);
		}
	}
}
