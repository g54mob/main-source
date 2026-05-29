using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CTS.Core;
using CTS.Core.Pooling;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.Emotes
{
	[Constructor("Construct")]
	public class EmotePlayer : CTSBehaviour, IPoolable, IPoolCallbackReceiver
	{
		private enum EState
		{
			InPool = 0,
			Appearing = 1,
			Staying = 2,
			Disappearing = 3
		}

		[Header("Default Values")]
		[SerializeField]
		protected float _fontSize = 16f;

		[SerializeField]
		protected float _iconSize = 24f;

		[SerializeField]
		protected float _appearDuration = 0.2f;

		[SerializeField]
		protected float _stayDuration = 0.5f;

		[SerializeField]
		protected float _disappearDuration = 0.25f;

		[SerializeField]
		protected AnimationCurve _appearEase = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		protected Color _textColor = Color.white;

		[SerializeField]
		protected Color _backgroundColor = Color.black;

		[SerializeField]
		protected Sprite _defaultBackground;

		[SerializeField]
		protected Material _defaultSpriteMaterial;

		[SerializeField]
		protected Material _defaultBackgroundMaterial;

		[SerializeField]
		protected float _padding = 8f;

		[SerializeField]
		protected float _height = 1f;

		[Header("Constants")]
		[SerializeField]
		private float _textLR_PaddingOffset = 16f;

		[SerializeField]
		private float _disappearScale = 1.5f;

		[SerializeField]
		private float _textPixelPerUnit = 8f;

		private readonly Queue<Emote> _queue = new Queue<Emote>();

		private TextMeshProUGUI _textRef;

		private Image _spriteRef;

		private Image _backgroundImageRef;

		private RectTransform _textSpriteRef;

		private Transform _scaleTransform;

		private bool _clearPoolQuickly;

		private Coroutine _currentRoutine;

		private Vector2 _currentTargetSize;

		private Camera _mainCamera;

		private EState _currentState;

		private Camera MainCamera
		{
			get
			{
				if (!_mainCamera)
				{
					_mainCamera = Camera.main;
				}
				return _mainCamera;
			}
		}

		public Emote CurrentEmote { get; private set; }

		PoolGuid IPoolable.PoolGuid { get; set; }

		public YieldInstruction WaitForCompletion()
		{
			return _currentRoutine;
		}

		private void Construct([InjectScope(EGetScope.Children)] TextMeshProUGUI textRef, Image background)
		{
			_textRef = textRef;
			_textRef.text = "<sprite=1>";
			_textRef.fontSize = 16f;
			SetContentAlpha(0f);
			_backgroundImageRef = background;
			SetBackgroundAlpha(0f);
			_spriteRef = _backgroundImageRef.transform.GetChild(1).GetComponent<Image>();
			_scaleTransform = base.transform.GetChild(0);
			_scaleTransform.localScale = Vector3.one * _disappearScale;
		}

		public void Kill()
		{
			while (_queue.Count > 0)
			{
				Emote emote = _queue.Peek();
				if (emote.IsPlaying)
				{
					_queue.Dequeue();
				}
				emote.Kill();
			}
			CurrentEmote?.Kill();
		}

		protected override void OnDisabled()
		{
			if (base.gameObject.activeSelf)
			{
				Pooler.Push(this);
			}
		}

		private void LateUpdate()
		{
			_scaleTransform.rotation = MainCamera.transform.rotation;
		}

		public void TransferPool(EmotePlayer origin)
		{
			while (origin._queue.Count > 0)
			{
				_queue.Enqueue(origin._queue.Dequeue());
			}
		}

		void IPoolCallbackReceiver.OnPulled()
		{
		}

		void IPoolCallbackReceiver.OnPushed()
		{
			_currentState = EState.InPool;
			CurrentEmote = null;
			if (_currentRoutine != null)
			{
				StopCoroutine(_currentRoutine);
			}
			_currentRoutine = null;
			EmoteManager.UnlinkPlayer(this);
			OnPushedToPool();
		}

		protected virtual void OnPushedToPool()
		{
		}

		public TEmote Play<TEmote>(int iconIndex, TEmote emote) where TEmote : Emote, new()
		{
			if (emote == null)
			{
				emote = new TEmote();
			}
			SetDefaultValues(emote);
			emote.SetIcon(iconIndex);
			EnqueueAndPlay(emote);
			return emote;
		}

		public TEmote Play<TEmote>(string text, TEmote emote) where TEmote : Emote, new()
		{
			if (emote == null)
			{
				emote = new TEmote();
			}
			SetDefaultValues(emote);
			emote.SetText(text);
			EnqueueAndPlay(emote);
			return emote;
		}

		public TEmote Play<TEmote>(Sprite sprite, TEmote emote) where TEmote : Emote, new()
		{
			if (emote == null)
			{
				emote = new TEmote();
			}
			SetDefaultValues(emote);
			emote.SetSprite(sprite);
			EnqueueAndPlay(emote);
			return emote;
		}

		private void EnqueueAndPlay(Emote emote)
		{
			_queue.Enqueue(emote);
			if (_currentRoutine == null)
			{
				_currentRoutine = StartCoroutine(ShowRoutine());
			}
		}

		public void RemoveFromQueue(Emote emote)
		{
			if (!_queue.Contains(emote))
			{
				return;
			}
			Queue<Emote> queue = new Queue<Emote>();
			while (_queue.Count > 0)
			{
				Emote emote2 = _queue.Dequeue();
				if (emote2 == emote)
				{
					emote.SetPlayer(null);
					emote.SetTransform(null);
				}
				else
				{
					queue.Enqueue(emote2);
				}
			}
			_queue.Clear();
			while (queue.Count > 0)
			{
				_queue.Enqueue(queue.Dequeue());
			}
		}

		private void SetDefaultValues(Emote emote)
		{
			emote.SetPlayer(this);
			emote.SetSpriteMaterial(_defaultSpriteMaterial);
			emote.SetBackgroundMaterial(_defaultBackgroundMaterial);
			emote.SetDefaultVisuals(emote.IsRound ? _iconSize : _fontSize, _textColor, _backgroundColor, _defaultBackground, _padding, _height);
			emote.SetDefaultDurations(_appearDuration, _stayDuration, _disappearDuration, _appearEase);
		}

		public void SetText(string text)
		{
			_textRef.enabled = true;
			_spriteRef.enabled = false;
			_textRef.SetText(text);
			_textRef.ForceMeshUpdate(ignoreActiveState: true);
			_currentTargetSize = _textRef.GetRenderedValues() + new Vector2(_textLR_PaddingOffset, 0f);
			if (_currentState == EState.Staying)
			{
				SetRectSize(_currentTargetSize.x + CurrentEmote.Padding, _currentTargetSize.y + CurrentEmote.Padding);
			}
		}

		public void SetSprite(Sprite sprite)
		{
			_spriteRef.enabled = true;
			_textRef.enabled = false;
			_spriteRef.sprite = sprite;
		}

		public void SetSpriteMaterial(Material mat)
		{
			_spriteRef.material = mat;
		}

		public void SetBackgroundMaterial(Material mat)
		{
			_backgroundImageRef.material = mat;
		}

		public void SetContentSize(float size)
		{
			if (_textRef.enabled)
			{
				_textRef.fontSize = size;
			}
			else
			{
				_spriteRef.rectTransform.sizeDelta = new Vector2(size, size);
			}
		}

		private void SetContentAlpha(float alpha)
		{
			if (_textRef.enabled)
			{
				Color color = _textRef.color;
				_textRef.color = new Color(color.r, color.g, color.b, alpha);
			}
			else
			{
				Color color2 = _spriteRef.color;
				_spriteRef.color = new Color(color2.r, color2.g, color2.b, alpha);
			}
		}

		private void SetBackgroundAlpha(float alpha)
		{
			Color color = _backgroundImageRef.color;
			_backgroundImageRef.color = new Color(color.r, color.g, color.b, alpha);
		}

		private void SetRectSize(float x, float y)
		{
			_backgroundImageRef.rectTransform.sizeDelta = new Vector2(x, y);
		}

		public void SetContentColor(Color color)
		{
			if (_textRef.enabled)
			{
				Color color2 = _textRef.color;
				_textRef.color = new Color(color.r, color.g, color.b, color2.a);
			}
			else
			{
				Color color3 = _spriteRef.color;
				_spriteRef.color = new Color(color.r, color.g, color.b, color3.a);
			}
		}

		public void SetBackgroundColor(Color color)
		{
			Color color2 = _backgroundImageRef.color;
			_backgroundImageRef.color = new Color(color.r, color.g, color.b, color2.a);
		}

		public void SetBackgroundSprite(Sprite sprite)
		{
			_backgroundImageRef.sprite = sprite;
		}

		public void SetHeight(float height)
		{
			_scaleTransform.localPosition = Vector3.up * (height * 100f);
		}

		private static float EvaluateCurve(AnimationCurve curve, float time)
		{
			return Mathf.InverseLerp(0.5f, 1f, curve.Evaluate(time / 2f + 0.5f));
		}

		private IEnumerator ShowRoutine()
		{
			while (_queue.Count > 0)
			{
				Emote currentEmote = (CurrentEmote = _queue.Dequeue());
				if (_queue.Count == 0)
				{
					_clearPoolQuickly = false;
				}
				Init(currentEmote);
				_currentState = EState.Appearing;
				yield return AppearBackground(currentEmote);
				yield return AppearContent(currentEmote);
				_currentState = EState.Staying;
				yield return StayShown(currentEmote);
				_currentState = EState.Disappearing;
				yield return Disappear(currentEmote);
				if (currentEmote.IsInfinite)
				{
					_queue.Enqueue(currentEmote);
				}
				else
				{
					currentEmote.SetPlayer(null);
					currentEmote.SetTransform(null);
				}
				yield return null;
			}
			_clearPoolQuickly = false;
			_currentRoutine = null;
			Pooler.Push(this);
		}

		protected virtual void Init(Emote emote)
		{
			if ((bool)emote.Sprite)
			{
				SetSprite(emote.Sprite);
			}
			else
			{
				SetText(emote.Text);
			}
			SetContentSize(emote.ContentSize);
			SetContentColor(emote.ContentColor);
			SetContentAlpha(0f);
			SetBackgroundAlpha(0f);
			SetRectSize(1f, 1f);
			SetHeight(emote.Height);
			SetBackgroundColor(emote.BackgroundColor);
			SetBackgroundSprite(emote.BackgroundSprite);
			SetBackgroundMaterial(emote.BackgroundMaterial);
			SetSpriteMaterial(emote.SpriteMaterial);
			_backgroundImageRef.pixelsPerUnitMultiplier = (emote.IsRound ? 1f : _textPixelPerUnit);
			_scaleTransform.localScale = Vector3.one;
		}

		private IEnumerator AppearBackground(Emote emote)
		{
			SetBackgroundAlpha(1f);
			Vector2 vector = Vector2.one;
			float padding;
			for (float time = 0f; time < 1f; time += Time.unscaledDeltaTime / emote.AppearDuration)
			{
				padding = emote.Padding;
				float x = vector.x * EvaluateCurve(emote.AppearEase, time) + padding;
				float y = vector.y + padding;
				SetRectSize(x, y);
				yield return null;
				vector = (_textRef.enabled ? _currentTargetSize : _spriteRef.rectTransform.sizeDelta);
				if (emote.IsRound)
				{
					vector.x = vector.y;
				}
			}
			padding = emote.Padding;
			SetRectSize(vector.x + padding, vector.y + padding);
		}

		private IEnumerator AppearContent(Emote emote)
		{
			if (emote.IsRound && (object)emote.Sprite == null)
			{
				_textRef.alignment = TextAlignmentOptions.Midline;
			}
			else
			{
				_textRef.alignment = TextAlignmentOptions.Center;
			}
			for (float time = 0f; time < 1f; time += Time.unscaledDeltaTime / emote.AppearDuration)
			{
				SetContentAlpha(EvaluateCurve(emote.AppearEase, time));
				yield return null;
			}
			SetContentAlpha(1f);
		}

		private IEnumerator StayShown(Emote emote)
		{
			for (float time = 0f; time < GetDuration(); time += emote.DeltaTime)
			{
				yield return null;
			}
			float GetDuration()
			{
				if (_clearPoolQuickly)
				{
					return 0f;
				}
				if (emote.IsInfinite && _queue.Any((Emote em) => !em.IsInfinite))
				{
					return 0f;
				}
				return emote.StayDuration;
			}
		}

		private IEnumerator Disappear(Emote emote)
		{
			for (float time = 1f; time > 0f; time -= Time.unscaledDeltaTime / emote.DisappearDuration)
			{
				SetContentAlpha(time);
				SetBackgroundAlpha(time);
				_scaleTransform.localScale = Vector3.one * Mathf.Lerp(_disappearScale, 1f, time);
				yield return null;
			}
			SetContentAlpha(0f);
			SetBackgroundAlpha(0f);
			_scaleTransform.localScale = Vector3.one;
			SetRectSize(1f, 1f);
		}
	}
}
