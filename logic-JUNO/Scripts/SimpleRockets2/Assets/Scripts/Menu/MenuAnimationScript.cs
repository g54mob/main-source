using System;
using System.Collections.Generic;
using Assets.Scripts.Craft;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Menu
{
	public class MenuAnimationScript : MonoBehaviour
	{
		private List<Tweener> _animations = new List<Tweener>();

		private CraftScript _craft;

		[SerializeField]
		private CanvasGroup _gameMenuCanvasGroup;

		[SerializeField]
		private CanvasGroup _mainMenuCanvasGroup;

		[SerializeField]
		private MenuScript _menuScript;

		[SerializeField]
		private ObjectViewerScript _objectViewer;

		[SerializeField]
		private MenuPlanetScript _planet;

		[SerializeField]
		private Transform _planetTargetPosition;

		private Vector3 _startPositionPlanet = Vector3.zero;

		private Vector3 _startPositionSun = Vector3.zero;

		[SerializeField]
		private MenuSunScript _sun;

		[SerializeField]
		private Transform _sunTargetPosition;

		public bool MainMenuVisible { get; private set; }

		public void OnCraftLoaded(CraftScript craftScript)
		{
			_craft = craftScript;
		}

		public void ShowMainMenu(bool show, float timeScale = 1f, Action onCompleteCallback = null)
		{
			KillAnimations();
			Vector3 vector = _sun.transform.position - _sunTargetPosition.position;
			Vector3 vector2 = _startPositionSun - _sunTargetPosition.position;
			float num = Mathf.Clamp01(vector.magnitude / vector2.magnitude);
			if (!show)
			{
				MainMenuVisible = false;
				float num2 = Mathf.Clamp(num * 5f, 1f, 5f) * timeScale;
				_gameMenuCanvasGroup.gameObject.SetActive(value: true);
				_gameMenuCanvasGroup.alpha = 0f;
				_gameMenuCanvasGroup.blocksRaycasts = false;
				AddAnimation(DOTween.To(() => _mainMenuCanvasGroup.alpha, delegate(float x)
				{
					_mainMenuCanvasGroup.alpha = x;
				}, 0f, 0.5f * timeScale)).OnComplete(delegate
				{
					_mainMenuCanvasGroup.gameObject.SetActive(value: false);
				});
				AddAnimation(DOTween.To(() => _gameMenuCanvasGroup.alpha, delegate(float x)
				{
					_gameMenuCanvasGroup.alpha = x;
				}, 1f, 1f * timeScale)).SetDelay(num2 * 0.5f).OnComplete(delegate
				{
					_gameMenuCanvasGroup.blocksRaycasts = true;
					onCompleteCallback();
				});
				_planet.gameObject.SetActive(!_menuScript.MissingFiles);
				float num3 = 0.15f * num2;
				AddAnimation(DOTween.To(() => _planet.Eclipse, delegate(float x)
				{
					_planet.Eclipse = x;
				}, 0f, num3));
				AddAnimation(DOTween.To(() => _planet.transform.position, delegate(Vector3 x)
				{
					_planet.transform.position = x;
				}, _planetTargetPosition.position, num2)).SetEase(Ease.InOutCubic);
				AddAnimation(DOTween.To(() => _sun.Eclipse, delegate(float x)
				{
					_sun.Eclipse = x;
				}, 0f, 0.5f * timeScale)).SetDelay(num3);
				AddAnimation(DOTween.To(() => _sun.transform.position, delegate(Vector3 x)
				{
					_sun.transform.position = x;
				}, _sunTargetPosition.position, num2)).SetEase(Ease.InOutCubic);
				_objectViewer.gameObject.SetActive(value: true);
				_objectViewer.PreviewObject(_craft?.gameObject, num2 * 0.5f, destroyWhenFinished: false);
			}
			else
			{
				MainMenuVisible = true;
				float num4 = Mathf.Clamp((1f - num) * 2f, 1f, 5f) * timeScale;
				_mainMenuCanvasGroup.gameObject.SetActive(value: true);
				AddAnimation(DOTween.To(() => _mainMenuCanvasGroup.alpha, delegate(float x)
				{
					_mainMenuCanvasGroup.alpha = x;
				}, 1f, 0.25f * timeScale).SetDelay(num4)).OnComplete(delegate
				{
					onCompleteCallback();
				});
				AddAnimation(DOTween.To(() => _gameMenuCanvasGroup.alpha, delegate(float x)
				{
					_gameMenuCanvasGroup.alpha = x;
				}, 0f, 0.25f * timeScale)).OnComplete(delegate
				{
					_gameMenuCanvasGroup.gameObject.SetActive(value: false);
					_gameMenuCanvasGroup.blocksRaycasts = false;
				});
				AddAnimation(DOTween.To(() => _sun.Eclipse, delegate(float x)
				{
					_sun.Eclipse = x;
				}, 1f, 0.25f * timeScale).SetDelay(num4 - 0.25f * timeScale));
				AddAnimation(DOTween.To(() => _sun.transform.position, delegate(Vector3 x)
				{
					_sun.transform.position = x;
				}, _startPositionSun, num4));
				AddAnimation(DOTween.To(() => _planet.Eclipse, delegate(float x)
				{
					_planet.Eclipse = x;
				}, 1f, 0.25f * timeScale).SetDelay(num4 + 0.25f * timeScale)).OnComplete(delegate
				{
					_planet.gameObject.SetActive(value: false);
				});
				AddAnimation(DOTween.To(() => _planet.transform.position, delegate(Vector3 x)
				{
					_planet.transform.position = x;
				}, _startPositionPlanet, num4));
				_objectViewer.PreviewObject(null);
			}
		}

		protected virtual void Awake()
		{
			Game.EnsureInitialized();
			_startPositionPlanet = _planet.transform.position;
			_startPositionSun = _sun.transform.position;
			_gameMenuCanvasGroup.gameObject.SetActive(value: false);
			_gameMenuCanvasGroup.blocksRaycasts = false;
		}

		private Tweener AddAnimation(Tweener tweener)
		{
			_animations.Add(tweener);
			return tweener;
		}

		private void KillAnimations()
		{
			foreach (Tweener animation in _animations)
			{
				animation.Kill();
			}
			_animations.Clear();
		}
	}
}
