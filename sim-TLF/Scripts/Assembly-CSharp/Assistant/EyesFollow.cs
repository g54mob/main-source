using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assistant
{
	public class EyesFollow : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
	{
		public Image eyeImage;

		public Transform center;

		public AssistantAnimator assistantAnimator;

		[SerializeField]
		private int _waitMs = 500;

		[Header("Sprites")]
		public Sprite eyeCenter;

		public Sprite eyeLeft;

		public Sprite eyeRight;

		public Sprite eyeUp;

		public Sprite eyeDown;

		public Sprite eyeUpLeft;

		public Sprite eyeUpRight;

		public Sprite eyeDownLeft;

		public Sprite eyeDownRight;

		private bool isHovered;

		private void LateUpdate()
		{
			if (isHovered)
			{
				Vector2 vector = Input.mousePosition;
				Vector2 vector2 = RectTransformUtility.WorldToScreenPoint(null, center.position);
				Vector2 normalized = (vector - vector2).normalized;
				if (Mathf.Abs(normalized.x) < 0.5f && Mathf.Abs(normalized.y) < 0.5f)
				{
					eyeImage.sprite = eyeCenter;
				}
				else if (normalized.x > 0.5f && Mathf.Abs(normalized.y) < 0.5f)
				{
					eyeImage.sprite = eyeRight;
				}
				else if (normalized.x < -0.5f && Mathf.Abs(normalized.y) < 0.5f)
				{
					eyeImage.sprite = eyeLeft;
				}
				else if (normalized.y > 0.5f && Mathf.Abs(normalized.x) < 0.5f)
				{
					eyeImage.sprite = eyeUp;
				}
				else if (normalized.y < -0.5f && Mathf.Abs(normalized.x) < 0.5f)
				{
					eyeImage.sprite = eyeDown;
				}
				else if (normalized.x > 0.5f && normalized.y > 0.5f)
				{
					eyeImage.sprite = eyeUpRight;
				}
				else if (normalized.x < -0.5f && normalized.y > 0.5f)
				{
					eyeImage.sprite = eyeUpLeft;
				}
				else if (normalized.x > 0.5f && normalized.y < -0.5f)
				{
					eyeImage.sprite = eyeDownRight;
				}
				else if (normalized.x < -0.5f && normalized.y < -0.5f)
				{
					eyeImage.sprite = eyeDownLeft;
				}
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			isHovered = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			isHovered = false;
			eyeImage.sprite = eyeCenter;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			BlushAndToDeafult().Forget();
		}

		private async UniTaskVoid BlushAndToDeafult()
		{
			isHovered = false;
			assistantAnimator.SetEyesClosed(value: true);
			assistantAnimator.SetBrowsSurprised();
			assistantAnimator.EnableBlush(value: true);
			assistantAnimator.SetMouthAngry();
			await UniTask.Delay(_waitMs);
			assistantAnimator.SetEyesClosed(value: false);
			assistantAnimator.SetBrowsAngry();
			assistantAnimator.EnableBlush(value: false);
			assistantAnimator.SetSmileNeutral();
		}
	}
}
