using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class UIErrorBar : MonoBehaviour
	{
		private Sequence tween;

		[SerializeField]
		private RectTransform errorRedBar;

		[SerializeField]
		private TextMeshProUGUI errorText;

		[SerializeField]
		private Image errorredBarImage;

		private MiniTool.MessageType messageType;

		private Ease customEase;

		private float startTime;

		private int startErrorBarY;

		private int endErrorBarY;

		private bool errorShowing;

		private Coroutine blinkCo;

		public bool isMoving => false;

		public void Init()
		{
		}

		public void GiveErrorMessageList(List<string> errorMessages, MiniTool.MessageType messageType)
		{
		}

		public void GiveErrorMessage(string errorMessage, MiniTool.MessageType messageType)
		{
		}

		private void InitTween()
		{
		}

		public void StopTween()
		{
		}

		public void StopTweenWhenClosingApp()
		{
		}

		public IEnumerator BlinkCO()
		{
			return null;
		}

		public void ResumeMovement()
		{
		}

		public void PauseMovement()
		{
		}

		public void SetMovementSpeed(float speed)
		{
		}
	}
}
