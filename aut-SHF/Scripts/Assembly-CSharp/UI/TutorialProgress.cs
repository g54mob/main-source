using System.Collections.Generic;
using InputControl;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class TutorialProgress : MonoBehaviour
	{
		[Header("Progress")]
		[SerializeField]
		private CanvasGroup progressGroup;

		[SerializeField]
		private TMP_Text tutorialTitle;

		[SerializeField]
		private TMP_Text requiredTime;

		[SerializeField]
		private TMP_Text requiredTimeAll;

		[SerializeField]
		private RectTransform sectionNodeContent;

		[SerializeField]
		private TutorialProgressImage progressImagePrefab;

		[SerializeField]
		private RectTransform loadContent;

		[SerializeField]
		private Image loadImage;

		[SerializeField]
		private CanvasGroup runnerGroup;

		[SerializeField]
		private Color passColor;

		[SerializeField]
		private Color unpassColor;

		[SerializeField]
		private CanvasGroup touchImage;

		[SerializeField]
		private TMP_Text touchText;

		[SerializeField]
		private PadInputConfigure padInputConfigure;

		private bool _startStandby;

		private UnityAction _callback;

		private List<TutorialProgressImage> _sectionNodes;

		public bool IsOpenProgress;

		public void DisplayProgress(eTutorialSectionId id, UnityAction callback = null)
		{
		}

		private void CreateLoad(Vector2 startPos, Vector2 endPos, Color color, int value = 15)
		{
		}

		public void OnClick()
		{
		}
	}
}
