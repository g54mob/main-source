using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors.Objects
{
	public class YellowSignManager : GameMonoBehaviour
	{
		[SerializeField]
		private Canvas _Canvas;

		[SerializeField]
		private GameObject _Clapper;

		[SerializeField]
		private RectTransform _ZoomTarget;

		[SerializeField]
		private UISpriteAnimation _InAnimation;

		[SerializeField]
		private UISpriteAnimation _OutAnimation;

		[SerializeField]
		private Image _Blackout;

		[SerializeField]
		private RectTransform _Panel;

		[SerializeField]
		private List<Vector3> _PanelPositions;

		[SerializeField]
		private List<Vector3> _PanelScales;

		private int _zoomIndex;

		private SignalBus _signalBus;

		private PlayerOptions _playerOptions;

		private AchievementManager _achievementManager;

		private float _orthoCameraSize;

		private float _orthoCameraIteration;

		private float _orthoCameraZoomTarget;

		private Vector3 _cameraPos;

		private Vector3 _screenPos;

		[Inject]
		private void Construct(SignalBus signalBus, PlayerOptions playerOptions, AchievementManager achievementManager)
		{
		}

		protected override void OnEnable()
		{
		}

		public void DoClaps(Action onComplete = null)
		{
		}

		private Tween Clap(float clapDelay)
		{
			return null;
		}

		private void PlayClapSound()
		{
		}

		private void Zoom()
		{
		}

		private Vector3 GetCameraPosition(float delta)
		{
			return default(Vector3);
		}

		private void UnlockWeapons()
		{
		}
	}
}
