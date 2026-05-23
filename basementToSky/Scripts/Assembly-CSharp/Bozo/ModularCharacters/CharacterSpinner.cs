using UnityEngine;
using UnityEngine.EventSystems;

namespace Bozo.ModularCharacters
{
	public class CharacterSpinner : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler
	{
		public float spinDir;

		public Transform character;

		private Animator anim;

		private float dizzyTimer = 1f;

		private bool spinning;

		public void SetCharacter(Transform character)
		{
			this.character = character;
			anim = character.GetComponentInChildren<Animator>();
		}

		public void OnDrag(PointerEventData eventData)
		{
			spinDir = (0f - eventData.delta.x) * 0.1f;
			character.Rotate(0f, spinDir, 0f);
			dizzyTimer = 0.5f;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			spinning = true;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			spinning = false;
			OnDrag(eventData);
		}

		private void Start()
		{
			SetCharacter(character);
		}

		private void Update()
		{
			if (dizzyTimer <= 0f)
			{
				if (spinDir >= 5f || spinDir <= -5f)
				{
					anim.SetBool("Dizzy", value: true);
				}
				else
				{
					anim.SetBool("Dizzy", value: false);
				}
			}
			if (!spinning)
			{
				character.Rotate(0f, spinDir, 0f);
				spinDir = Mathf.Lerp(spinDir, 0f, Time.deltaTime);
				dizzyTimer -= Time.deltaTime;
			}
		}
	}
}
