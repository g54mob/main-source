using Rewired;
using UnityEngine;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.UI
{
	public class MapZoomController : MonoBehaviour
	{
		[SerializeField]
		private float ZoomInterval;

		[SerializeField]
		private AdvancedUIButtonEvents _ZoomInButton;

		[SerializeField]
		private AdvancedUIButtonEvents _ZoomOutButton;

		[SerializeField]
		private MapManager _mapManager;

		private Rewired.Player _player;

		private MultiplayerManager _multiplayer;

		private bool _ZoomingIn;

		private bool _isZooming;

		private float _timeToNextZoom;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		[Inject]
		private void Construct(MultiplayerManager _mult)
		{
		}

		private void Update()
		{
		}

		private void ZoomInPressed()
		{
		}

		private void ZoomInUnpressed()
		{
		}

		private void ZoomOutPressed()
		{
		}

		private void ZoomOutUnpressed()
		{
		}
	}
}
