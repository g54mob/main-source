using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Michsky.UI.ModernUIPack
{
	public class CustomInputField : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		public GameObject fieldTrigger;

		public TMP_InputField inputText;

		public Animator inputFieldAnimator;

		public bool isEmpty = true;

		public bool isClicked;

		public string inAnim = "In";

		public string outAnim = "Out";

		private void Start()
		{
			inputFieldAnimator = base.gameObject.GetComponent<Animator>();
			inputText = base.gameObject.GetComponent<TMP_InputField>();
			if (inputText.text.Length == 0 || inputText.text.Length <= 0)
			{
				isEmpty = true;
			}
			else
			{
				isEmpty = false;
			}
			if (isEmpty)
			{
				inputFieldAnimator.Play(outAnim);
			}
			else
			{
				inputFieldAnimator.Play(inAnim);
			}
		}

		private void Update()
		{
			if (inputText.text.Length == 1 || inputText.text.Length >= 1)
			{
				isEmpty = false;
				inputFieldAnimator.Play(inAnim);
			}
			else if (!isClicked)
			{
				inputFieldAnimator.Play(outAnim);
			}
		}

		public void Animate()
		{
			isClicked = true;
			inputFieldAnimator.Play(inAnim);
			fieldTrigger.SetActive(value: true);
		}

		public void FieldTrigger()
		{
			if (isEmpty)
			{
				inputFieldAnimator.Play(outAnim);
				fieldTrigger.SetActive(value: false);
				isClicked = false;
			}
			else
			{
				fieldTrigger.SetActive(value: false);
				isClicked = false;
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			Animate();
		}
	}
}
