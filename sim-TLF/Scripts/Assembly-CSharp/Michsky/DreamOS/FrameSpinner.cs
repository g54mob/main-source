using System.Collections;
using UnityEngine;

namespace Michsky.DreamOS
{
	public class FrameSpinner : MonoBehaviour
	{
		[Header("Resources")]
		[SerializeField]
		private RectTransform targetTransform;

		[Header("Options")]
		[SerializeField]
		[Range(0.01f, 0.5f)]
		private float frameDelay = 0.1f;

		[SerializeField]
		[Range(1f, 10f)]
		private float moveBy = 10f;

		[SerializeField]
		private float minPos = -150f;

		[SerializeField]
		private float maxPos = 150f;

		[SerializeField]
		private float startDelay = 1f;

		private void OnEnable()
		{
			targetTransform.anchoredPosition = new Vector2(minPos, targetTransform.anchoredPosition.y);
			if (startDelay > 0f)
			{
				StartCoroutine("ProcessDelay");
			}
			else
			{
				StartCoroutine("ProcessRect");
			}
		}

		private IEnumerator ProcessDelay()
		{
			yield return new WaitForSeconds(startDelay);
			StartCoroutine("ProcessRect");
		}

		private IEnumerator ProcessRect()
		{
			yield return new WaitForSeconds(frameDelay);
			targetTransform.anchoredPosition = new Vector2(targetTransform.anchoredPosition.x + moveBy, targetTransform.anchoredPosition.y);
			if (targetTransform.anchoredPosition.x >= maxPos)
			{
				targetTransform.anchoredPosition = new Vector2(minPos, targetTransform.anchoredPosition.y);
			}
			StartCoroutine("ProcessRect");
		}
	}
}
