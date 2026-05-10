using System;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class PushHandlers : MonoSingleton<PushHandlers>
	{
		[SerializeField]
		[BoxGroup("Base Settings")]
		[Space(10f)]
		private Color _infoColor;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private Color _dangerColor;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private GameObject _uiPushPrefab;

		[SerializeField]
		[BoxGroup("Audio Settings")]
		[Space(10f)]
		private AudioSource _uiAudioSource;

		[SerializeField]
		[BoxGroup("Audio Settings")]
		private AudioClip[] _uiPushAudioClipList;

		[SerializeField]
		[BoxGroup("Debug Settings")]
		[Space(10f)]
		private Transform _transformDebug;

		private GameObject _tmpPushGameObject;

		private AudioClip _selectedUIPushAudioClip;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		public void PushANotification(string tmpIcon, PushColor tmpColor, string tmpTitle, string tmpText, string tmpSubInfo1, string tmpSubInfo2, AudioClip tmpAudioClip = null)
		{
			RunNotificationSystem(tmpIcon, PushAction.Alert, null, tmpColor, null, tmpAudioClip, tmpTitle, tmpText, tmpSubInfo1, tmpSubInfo2);
		}

		public void PushANotification(string tmpIcon, PushColor tmpColor, string tmpTitle, string tmpText, AudioClip tmpAudioClip)
		{
			RunNotificationSystem(tmpIcon, PushAction.ToolTip, null, tmpColor, null, tmpAudioClip, tmpTitle, tmpText);
		}

		public void PushANotification(string tmpIcon, PushColor tmpColor, Action tmpScriptToExecute, string tmpTitle, string tmpText, AudioClip tmpAudioClip)
		{
			RunNotificationSystem(tmpIcon, PushAction.ToolTipAndCustomAction, tmpScriptToExecute, tmpColor, null, tmpAudioClip, tmpTitle, tmpText);
		}

		public void PushANotification(string tmpIcon, PushColor tmpColor, Transform tmpFocusCamera, AudioClip tmpAudioClip = null)
		{
			RunNotificationSystem(tmpIcon, PushAction.Focus, null, tmpColor, tmpFocusCamera, tmpAudioClip);
		}

		public void PushANotification(string tmpIcon, PushColor tmpColor, Transform tmpFocusCamera, string tmpTitle, string tmpText, string tmpInfo1, string tmpInfo2, AudioClip tmpAudioClip = null)
		{
			RunNotificationSystem(tmpIcon, PushAction.AlertAndFocus, null, tmpColor, tmpFocusCamera, tmpAudioClip, tmpTitle, tmpText, tmpInfo1, tmpInfo2);
		}

		public void PushANotification(string tmpIcon, PushColor tmpColor, Action tmpScriptToExecute, AudioClip tmpAudioClip = null)
		{
			RunNotificationSystem(tmpIcon, PushAction.CustomAction, tmpScriptToExecute, tmpColor, null, tmpAudioClip);
		}

		private void RunNotificationSystem(string tmpIcon, PushAction tmpAction, Action tmpScriptToExecute = null, PushColor tmpColor = PushColor.Info, Transform tmpFocusCamera = null, AudioClip tmpAudioClip = null, string tmpTitle = null, string tmpText = null, string tmpInfo1 = null, string tmpInfo2 = null)
		{
			if (((tmpAction == PushAction.Alert || tmpAction == PushAction.ToolTip || tmpAction == PushAction.AlertAndFocus) && string.IsNullOrEmpty(tmpTitle) && string.IsNullOrEmpty(tmpText)) || ((tmpAction == PushAction.Focus || tmpAction == PushAction.AlertAndFocus) && !tmpFocusCamera))
			{
				return;
			}
			_tmpPushGameObject = UnityEngine.Object.Instantiate(_uiPushPrefab, base.transform);
			if (_tmpPushGameObject.TryGetComponent<PushSetup>(out var component))
			{
				if ((bool)tmpAudioClip)
				{
					_selectedUIPushAudioClip = tmpAudioClip;
				}
				component._pushAction = tmpAction;
				switch (tmpColor)
				{
				case PushColor.Info:
					component.iconSprite = tmpIcon;
					component.backgroundColor = _infoColor;
					_selectedUIPushAudioClip = (tmpAudioClip ? tmpAudioClip : _uiPushAudioClipList[0]);
					break;
				case PushColor.Danger:
					component.iconSprite = tmpIcon;
					component.backgroundColor = _dangerColor;
					_selectedUIPushAudioClip = (tmpAudioClip ? tmpAudioClip : _uiPushAudioClipList[1]);
					break;
				}
				if (tmpAction == PushAction.Alert || tmpAction == PushAction.AlertAndFocus)
				{
					component.alertTitle = tmpTitle;
					component.alertText = tmpText;
					component.alertTextInfo1 = tmpInfo1;
					component.alertTextInfo2 = tmpInfo2;
				}
				if (tmpAction == PushAction.ToolTip || tmpAction == PushAction.ToolTipAndCustomAction)
				{
					component.alertTitle = tmpTitle;
					component.alertText = tmpText;
				}
				if (tmpAction == PushAction.Focus || tmpAction == PushAction.AlertAndFocus)
				{
					component.transformFocusCamera = tmpFocusCamera;
				}
				if (tmpAction == PushAction.CustomAction || tmpAction == PushAction.ToolTipAndCustomAction)
				{
					component._scriptToExecute = tmpScriptToExecute;
				}
				component.DisplayPush();
				_uiAudioSource.clip = _selectedUIPushAudioClip;
				_uiAudioSource.Play();
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void DebugDisplayAPush()
		{
			PushANotification("<sprite=\"Emoji_Notifications\" index=0>", PushColor.Danger, "Problem", "dsfdsf sdf sdf sdf", null, null);
		}

		[Button(null, EButtonEnableMode.Always)]
		private void DebugDisplayAPushWithACustomAction()
		{
			Action tmpScriptToExecute = delegate
			{
				Debug.Log("opfdopfdofopkdfsopkopkfsdopk");
			};
			PushANotification("<sprite=\"Emoji_Notifications\" index=0>", PushColor.Danger, tmpScriptToExecute);
		}

		[Button(null, EButtonEnableMode.Always)]
		private void DebugDisplayAPushWithACustomActionAndToolTip()
		{
			Action tmpScriptToExecute = delegate
			{
				Debug.Log("opfdopfdofopkdfsopkopkfsdopk");
			};
			PushANotification("<sprite=\"Emoji_Notifications\" index=0>", PushColor.Danger, tmpScriptToExecute, "ToolTip Test", "opsdfosdfkofsdk", null);
		}
	}
}
