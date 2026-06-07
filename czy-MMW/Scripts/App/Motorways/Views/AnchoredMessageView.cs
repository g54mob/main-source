using System;
using System.Collections.Generic;
using Client;
using Easing;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Audio;
using Motorways.Models;
using Motorways.Themes;
using Server;
using TMPro;
using UnityEngine;

namespace Motorways.Views
{
	public class AnchoredMessageView : MonoBehaviour, IView, IThemeComponent, IReusable, AnchoredMessageModel.IObserver
	{
		public class Builder : IViewBuilder
		{
			public void CreateView(ViewClient client, ISimulation simulation, IModel model, Fix64 timestamp)
			{
				AnchoredMessageView anchoredMessageView = client.Scope.Get<AnchoredMessageView>();
				anchoredMessageView.InitializeWithModel(model as AnchoredMessageModel);
				client.AddView(anchoredMessageView);
			}
		}

		public LineRenderer signPost;

		public LocalizedTextUI text;

		public TMP_Text textMesh;

		public SpriteRenderer messageBoard;

		public SpriteRenderer arrowSprite;

		public float arrowSize = 0.5f;

		public AnimationCurve arrowSpriteAlphaCurve;

		private const float TransitionInDuration = 1.2f;

		private const float TransitionOutDuration = 0.8f;

		private float _animationTimer;

		private bool _isAppearing = true;

		private bool _isAnimating = true;

		private bool _forceTransitionInEases;

		private bool _showingDismissArrow;

		private AnchoredMessageAnchorType _anchorType;

		private Vector3 _worldAnchor;

		private TileDirection _direction;

		private Vector2 _anchorOffset;

		private Vector2 _uiAnchorPivot;

		private RectTransform _parentTransform;

		private bool _isKilled;

		private const float PostWidth = 0.1f;

		private const float TextWidthPadding = 0.5f;

		private const float TextHeightPadding = 0.3f;

		private const float ScreenPadding = 0.1f;

		private const float PostLength = 3f;

		private const float DefaultCameraSize = 6f;

		[Dependency]
		private IScope _scope;

		[Dependency]
		private GameCamera _gameCamera;

		[Dependency]
		protected GameUIScreen _gameUI;

		[Dependency]
		private IAudioSystem _audioSystem;

		[Dependency]
		private LocaleDatabase _localeDatabase;

		private bool _hasFiredAudioAppear;

		private Vector3 _audioSignPosition;

		private Func<float, float> MessageBoardEasing
		{
			get
			{
				if (_isAppearing || _forceTransitionInEases)
				{
					return Easings.ElasticEaseOut;
				}
				return Easings.BackEaseOut;
			}
		}

		public void Reset()
		{
			_parentTransform = null;
			_animationTimer = 0f;
			_isAppearing = true;
			_isAnimating = true;
			_forceTransitionInEases = false;
			_showingDismissArrow = false;
			_anchorType = AnchoredMessageAnchorType.Screen;
			_worldAnchor = default(Vector3);
			_direction = TileDirection.North;
			_anchorOffset = default(Vector2);
			_uiAnchorPivot = default(Vector2);
			base.transform.position = default(Vector3);
			_localeDatabase.RemoveLocalizedObject(text);
			_isKilled = false;
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_isKilled)
			{
				return TickResult.Destroy;
			}
			float orthographicSize = _gameCamera.OrthographicSize;
			float num = orthographicSize / 6f;
			Vector3 size = textMesh.bounds.size;
			size.x = Mathf.Max(size.x, 0f);
			size.y = Mathf.Max(size.y, 0f);
			size.x += 1f;
			if (_showingDismissArrow)
			{
				size.x += arrowSize;
			}
			size.y += 0.6f;
			float num2 = Screen.safeArea.width / Screen.safeArea.height;
			float num3 = orthographicSize * num2;
			float num4 = size.x * 0.5f;
			float x = _gameCamera.transform.position.x;
			float num5 = x - num3 + (num4 + 0.1f) * num;
			float num6 = x + num3 - (num4 + 0.1f) * num;
			Vector3 vector;
			Vector3 vector2;
			Vector3 vector3;
			if (_anchorType == AnchoredMessageAnchorType.Screen)
			{
				vector = Vector3.zero;
				vector2 = Vector3.zero;
				vector3 = _gameCamera.transform.position;
				Vector2 vector4 = _anchorOffset * orthographicSize;
				vector3.x += vector4.x;
				vector3.y += vector4.y;
				vector3.z = 0f;
			}
			else if (_anchorType == AnchoredMessageAnchorType.World)
			{
				vector = _worldAnchor;
				vector3 = _worldAnchor;
				if (_direction == TileDirection.West || _direction == TileDirection.East)
				{
					if (_direction == TileDirection.West)
					{
						float num7 = _worldAnchor.x - (3f + num4) * num;
						float num8 = Mathf.Max(num7, num5);
						if (num8 < vector.x)
						{
							vector3.x = num8;
						}
						else
						{
							num8 = Mathf.Min(_worldAnchor.x + (3f + num4) * num, num6);
							if (num8 > vector.x)
							{
								vector3.x = num8;
							}
							else
							{
								vector3.x = num7;
							}
						}
					}
					else
					{
						float num9 = _worldAnchor.x + (3f + num4) * num;
						float num10 = Mathf.Min(num9, num6);
						if (num10 > vector.x)
						{
							vector3.x = num10;
						}
						else
						{
							num10 = Mathf.Max(_worldAnchor.x - (3f + num4) * num, num5);
							if (num10 < vector.x)
							{
								vector3.x = num10;
							}
							else
							{
								vector3.x = num9;
							}
						}
					}
				}
				else
				{
					float y = _gameCamera.transform.position.y;
					float b = y + orthographicSize - size.y * num - 0.1f * num;
					float b2 = y - orthographicSize + size.y * num + 0.1f * num;
					float num11 = _worldAnchor.y + 3f * num;
					float num12 = Mathf.Min(num11, b);
					if (num12 > vector.y)
					{
						vector3.y = num12;
					}
					else
					{
						num12 = Mathf.Max(_worldAnchor.y - 3f * num, b2);
						if (num12 < vector.y)
						{
							vector3.y = num12;
						}
						else
						{
							vector3.y = num11;
						}
					}
				}
				vector2 = vector3;
			}
			else
			{
				Vector3[] array = new Vector3[4];
				_parentTransform.GetWorldCorners(array);
				vector = new Vector3(Mathf.Lerp(array[0].x, array[2].x, _uiAnchorPivot.x), Mathf.Lerp(array[0].y, array[1].y, _uiAnchorPivot.y), 0f);
				Vector3 zero = Vector3.zero;
				Bounds screenBounds = _gameCamera.GetScreenBounds();
				Vector2 vector5 = new Vector2((vector.x - screenBounds.min.x) / screenBounds.size.x, (vector.y - screenBounds.min.y) / screenBounds.size.y);
				Vector3 vector6;
				if (!(vector5.y > 0.85f))
				{
					vector6 = ((!(vector5.x < 0.5f)) ? new Vector3(-1f, 0f, 0f) : new Vector3(1f, 0f, 0f));
				}
				else
				{
					vector6 = new Vector3(0f, -1f, 0f);
					float num13 = Mathf.Clamp(vector.x, num5, num6);
					zero.x = num13 - vector.x;
				}
				float num14 = 3f + Mathf.Abs(vector6.x) * size.x * 0.5f;
				vector2 = vector + vector6 * (num14 * num);
				vector3 = vector2 + zero;
			}
			float num15 = 1f;
			float t = 1f;
			float num16 = 1f;
			float a = 1f;
			if (_isAnimating)
			{
				if (!_hasFiredAudioAppear)
				{
					_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.TextMessageShown, _gameCamera.GetPanFromWorld(vector3).x));
					_hasFiredAudioAppear = true;
				}
				_animationTimer += timeInterval.Delta * (1f / (_isAppearing ? 1.2f : (-0.8f)));
				if (_animationTimer >= 1f && _isAppearing)
				{
					_isAnimating = false;
				}
				else
				{
					if (_animationTimer <= 0f && !_isAppearing)
					{
						_isAnimating = false;
						return TickResult.Destroy;
					}
					float animationTimer = _animationTimer;
					float p = Mathf.Clamp01((animationTimer - 0.1f) / 0.2f);
					float arg = animationTimer;
					float p2 = Mathf.Clamp01((animationTimer - 0.3f) / 0.4f);
					t = Easings.QuarticEaseIn(p);
					num16 = MessageBoardEasing(arg);
					a = Easings.Linear(p2);
					Color color = arrowSprite.color;
					color.a = a;
					arrowSprite.color = color;
				}
			}
			else
			{
				Color color2 = arrowSprite.color;
				color2.a = arrowSpriteAlphaCurve.Evaluate(Time.time);
				arrowSprite.color = color2;
			}
			if (signPost.enabled)
			{
				signPost.SetPosition(0, vector2);
				signPost.SetPosition(1, Vector3.Lerp(vector2, vector, t));
				LineRenderer lineRenderer = signPost;
				float startWidth = (signPost.endWidth = 0.1f * num15 * num);
				lineRenderer.startWidth = startWidth;
			}
			messageBoard.transform.localScale = new Vector3(num, num, 1f);
			messageBoard.transform.position = vector3;
			float num18 = size.x * num16;
			float y2 = Mathf.Min(num18, size.y);
			messageBoard.size = new Vector2(num18, y2);
			float x2 = num18 / 2f - arrowSize;
			arrowSprite.transform.localPosition = new Vector3(x2, 0f, 0f);
			Color color3 = textMesh.color;
			color3.a = a;
			textMesh.color = color3;
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public void Kill()
		{
			messageBoard.transform.localScale = Vector3.zero;
			_isKilled = true;
		}

		private void Initialize()
		{
			text.HandleParentAllocated(_scope);
			textMesh.alpha = 0f;
			messageBoard.size = new Vector2(0f, 0f);
			_animationTimer = 0f;
			_isAppearing = true;
			_isAnimating = true;
			_forceTransitionInEases = false;
			_hasFiredAudioAppear = false;
			_audioSignPosition = new Vector3(0f, 0f, 0f);
		}

		public void InitializeWithModel(AnchoredMessageModel model)
		{
			int newCount = 0;
			Dictionary<string, string> dictionary = null;
			if (model.IntParameter.HasValue)
			{
				newCount = model.IntParameter.Value;
				dictionary = new Dictionary<string, string> { 
				{
					"Num",
					model.IntParameter.Value.ToString()
				} };
			}
			StandaloneLocString messageText;
			if (dictionary != null)
			{
				StringKey stringKey = _scope.Get<StringKey>();
				stringKey.InitWithStringId(model.Message, newCount, dictionary);
				messageText = StandaloneLocString.CreateString(_scope, stringKey);
			}
			else
			{
				messageText = StandaloneLocString.CreateString(_scope, model.Message);
			}
			switch (model.AnchorType)
			{
			case AnchoredMessageAnchorType.Screen:
				InitializeWithScreenAnchor(messageText, model.Offset, model.CameraLayer);
				break;
			case AnchoredMessageAnchorType.World:
				InitializeWithWorldAnchor(messageText, model.WorldAnchor, model.Direction);
				break;
			case AnchoredMessageAnchorType.UI:
			{
				RectTransform rectTransform = null;
				switch (model.UIAnchor)
				{
				case UIMessageAnchor.DrawModeToggle:
					rectTransform = _gameUI.drawButtonAnchors.GetComponent<RectTransform>();
					break;
				case UIMessageAnchor.Concrete:
					rectTransform = _gameUI.UpgradeBar.GetRectTransformForUpgrade(UpgradeType.Concrete);
					break;
				case UIMessageAnchor.TrafficLight:
					rectTransform = _gameUI.UpgradeBar.GetRectTransformForUpgrade(UpgradeType.TrafficLight);
					break;
				case UIMessageAnchor.Motorway:
					rectTransform = _gameUI.UpgradeBar.GetRectTransformForUpgrade(UpgradeType.Motorway);
					break;
				case UIMessageAnchor.Score:
					rectTransform = _gameUI.ScoreTextAnchor.GetComponent<RectTransform>();
					break;
				case UIMessageAnchor.Clock:
					rectTransform = _gameUI.ClockAnchor.GetComponent<RectTransform>();
					break;
				}
				InitializeWithUIAnchor(messageText, rectTransform, model.UIAnchorPivot);
				break;
			}
			}
			_localeDatabase.AddLocalizedObject(text);
			SetDismissArrowVisibility(model.ShowDismissArrow);
			model.Subscribe(this);
		}

		public void InitializeWithScreenAnchor(StandaloneLocString messageText, Vector2 screenOffset, CameraLayer cameraLayer = CameraLayer.Default)
		{
			Initialize();
			text.LocString = messageText;
			_anchorType = AnchoredMessageAnchorType.Screen;
			_anchorOffset = screenOffset;
			signPost.enabled = false;
			InitializeCameraLayer(cameraLayer);
			SetDismissArrowVisibility(visible: false);
		}

		public void InitializeWithWorldAnchor(StandaloneLocString messageText, Vector3 worldAnchor, TileDirection direction = TileDirection.North)
		{
			Initialize();
			text.LocString = messageText;
			_anchorType = AnchoredMessageAnchorType.World;
			_worldAnchor = worldAnchor;
			_direction = direction;
			signPost.enabled = true;
			InitializeCameraLayer(CameraLayer.Default);
			SetDismissArrowVisibility(visible: false);
		}

		public void InitializeWithUIAnchor(StandaloneLocString messageText, RectTransform transform, Vector2 transformPivot)
		{
			Initialize();
			text.LocString = messageText;
			_anchorType = AnchoredMessageAnchorType.UI;
			_parentTransform = transform;
			_uiAnchorPivot = transformPivot;
			signPost.enabled = true;
			InitializeCameraLayer(CameraLayer.Default);
			SetDismissArrowVisibility(visible: false);
		}

		public void OnAnimationRelease()
		{
			if (_isAnimating && _isAppearing)
			{
				_forceTransitionInEases = true;
			}
			else
			{
				_animationTimer = 1f;
			}
			_isAppearing = false;
			_isAnimating = true;
			_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.TextMessageShown, _gameCamera.GetPanFromWorld(_audioSignPosition).x, -1f, condition: false));
		}

		public void SetDismissArrowVisibility(bool visible)
		{
			arrowSprite.gameObject.SetActive(visible);
			Vector4 margin = textMesh.margin;
			margin.z = (visible ? (arrowSize * 2f) : margin.x);
			textMesh.margin = margin;
			_showingDismissArrow = visible;
		}

		public void InitializeCameraLayer(CameraLayer cameraLayer)
		{
			int layer = ((cameraLayer == CameraLayer.Default) ? LayerMask.NameToLayer("UI") : LayerMask.NameToLayer("Overlay"));
			base.gameObject.layer = layer;
			signPost.gameObject.layer = layer;
			textMesh.gameObject.layer = layer;
			messageBoard.gameObject.layer = layer;
		}

		public void InitializeTheme(IThemeDatabase themeDatabase)
		{
			text.GetComponent<ThemedComponent>().InitializeTheme(themeDatabase);
		}

		public void ApplyTheme(ITheme theme)
		{
			text.GetComponent<ThemedComponent>().ApplyTheme(theme);
		}

		public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			return ThemeBlendingResult.StopBlending;
		}

		public void ReleaseTheme(IThemeDatabase themeDatabase)
		{
			text.GetComponent<ThemedComponent>().ReleaseTheme(themeDatabase);
		}
	}
}
