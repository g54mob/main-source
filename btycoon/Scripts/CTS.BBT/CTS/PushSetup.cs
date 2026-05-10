using System;
using CTS.Core;
using CTS.UI;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class PushSetup : MonoBehaviour
	{
		[SerializeField]
		[BoxGroup("GameObject Links")]
		[Space(10f)]
		private TextMeshProUGUI _iconSpriteTextMesh;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private GameObject _backgroundColorGameObject;

		[SerializeField]
		[BoxGroup("Camera Settings")]
		[Space(10f)]
		private AnimationCurve _cameraAnimationCurve;

		[SerializeField]
		[BoxGroup("Camera Settings")]
		private float _cameraMovementDuration = 0.75f;

		[BoxGroup("Debug Data")]
		[Space(10f)]
		public PushAction _pushAction;

		[BoxGroup("Debug Data")]
		[Space(10f)]
		public Action _scriptToExecute;

		[BoxGroup("Debug Data")]
		public string iconSprite;

		[BoxGroup("Debug Data")]
		public Color backgroundColor;

		[BoxGroup("Debug Data")]
		public Transform transformFocusCamera;

		[BoxGroup("Debug Data")]
		public string alertTitle;

		[BoxGroup("Debug Data")]
		public string alertText;

		[BoxGroup("Debug Data")]
		public string alertTextInfo1;

		[BoxGroup("Debug Data")]
		public string alertTextInfo2;

		private MainCamera _mainCamera;

		private ToolTipsShower _toolTipsShower;

		private float _elapsedTime;

		private float _curveValue;

		public void DisplayPush()
		{
			_iconSpriteTextMesh.text = iconSprite;
			Material material = new Material(_backgroundColorGameObject.GetComponent<Image>().material);
			material.SetColor("_Color", backgroundColor);
			_backgroundColorGameObject.GetComponent<Image>().material = material;
			if (_pushAction == PushAction.ToolTip || _pushAction == PushAction.ToolTipAndCustomAction)
			{
				base.gameObject.GetComponent<ToolTipsShower>().SetTootipsInfoStaticString(alertTitle, alertText);
			}
		}

		public void OnClick()
		{
			if (_pushAction == PushAction.Alert || _pushAction == PushAction.AlertAndFocus)
			{
				MonoSingleton<AlertHandlers>.Instance.DisplayOrHideAlert(alertTitle, alertText, alertTextInfo1, alertTextInfo2);
			}
			if (_pushAction == PushAction.Focus || _pushAction == PushAction.AlertAndFocus)
			{
				MonoSingleton<MainCamera>.Instance.CVarLockType.SetCurrentValue(CameraFollowing.LockType.Tutorial);
				if (transformFocusCamera != null)
				{
					MonoSingleton<CameraFollowing>.Instance.Lock(transformFocusCamera);
				}
				MonoSingleton<MainCamera>.Instance.CVarLockType.SetCurrentValue(CameraFollowing.LockType.Soft);
			}
			if (_pushAction == PushAction.CustomAction || _pushAction == PushAction.ToolTipAndCustomAction)
			{
				_scriptToExecute?.Invoke();
			}
			base.gameObject.SetActive(value: false);
		}
	}
}
