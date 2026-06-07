using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Utils
{
	public class ForceLayoutOnStart : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _rectTransform;

		private void Awake()
		{
			if (_rectTransform == null)
			{
				_rectTransform = GetComponent<RectTransform>();
			}
		}

		private void Start()
		{
			StartCoroutine(WaitForUpdate());
		}

		private IEnumerator WaitForUpdate()
		{
			yield return new WaitForEndOfFrame();
			LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
			LayoutRebuilder.MarkLayoutForRebuild(_rectTransform);
		}
	}
}
