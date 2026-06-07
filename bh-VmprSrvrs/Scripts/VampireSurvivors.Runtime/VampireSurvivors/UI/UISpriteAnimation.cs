using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class UISpriteAnimation : MonoBehaviour
	{
		[SerializeField]
		private int FPS;

		[SerializeField]
		private bool PlayManually;

		[SerializeField]
		private bool _UseCustomScaleTween;

		[SerializeField]
		private bool _UseCustomPositionTween;

		[SerializeField]
		private bool _ScaleBasedOnSpriteSize;

		[SerializeField]
		private bool _hideWhenDone;

		public bool _FreezeOnLastFrame;

		public Action OnComplete;

		[SerializeField]
		private Vector3 _StartScale;

		[SerializeField]
		private Vector3 _EndScale;

		[SerializeField]
		private Vector2 _StartPos;

		[SerializeField]
		private Vector2 _EndPos;

		[FormerlySerializedAs("Sprites")]
		public List<Sprite> sprites;

		private RectTransform _rTrans;

		private Image _image;

		private float _currentTimer;

		private float _triggerTimer;

		private int _index;

		private bool _isPlayingManually;

		private Action _onComplete;

		public bool ScaleBasedOnSpriteSizeWithoutMagic;

		public bool IsPaused { get; set; }

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void Play(bool hideWhenDone = false, float startTimer = 0f)
		{
		}

		private void RefreshScale()
		{
		}

		public void SetScaleBasedOnSpriteSize(bool b)
		{
		}

		public void SetCallback(Action cb)
		{
		}

		public void SetFPS(int fps)
		{
		}

		public void RecalculateTriggerTime()
		{
		}

		public void Reset()
		{
		}

		public void Clean()
		{
		}

		public void ResetScale()
		{
		}
	}
}
