using Client;
using Factory;
using Factory.Pools;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways.Views
{
	public class SimulationToggleDebugView : MonoBehaviour, IView, IReusable
	{
		[Dependency]
		private ClockModel _clockModel;

		[Dependency]
		private CityPlanModel _cityPlanModel;

		[Dependency]
		private Simulation _simulation;

		[Dependency]
		private BuildingsIndicatorView _indicatorView;

		[Dependency]
		private GameUIScreen _gameUIScreen;

		[Dependency]
		private UpgradeDatabaseModel _upgradeDatabaseModel;

		[Dependency]
		private GameBehaviourModel _behaviour;

		[Dependency]
		private NotificationView _notificationView;

		[Dependency]
		private CameraView _cameraView;

		private GUIStyle _boxStyle = new GUIStyle();

		public const string ShouldShowDebugToggleView = "ShouldShowDebugToggleView";

		private const int Padding = 10;

		private const int Margins = 10;

		private bool _isCollapsed;

		private bool ShouldShowView => false;

		private void OnEnable()
		{
			_boxStyle.fontSize = 18;
			_boxStyle.alignment = TextAnchor.MiddleLeft;
			_boxStyle.richText = true;
			_boxStyle.normal.textColor = Color.white;
			_boxStyle.normal.background = DebugViewUtils.DebugWindowBackground;
			_boxStyle.padding = new RectOffset(10, 10, 10, 10);
		}

		private Rect CalculateRectSize(string text)
		{
			GUIContent content = new GUIContent(text);
			Vector2 vector = _boxStyle.CalcSize(content);
			return new Rect(10f, (float)Screen.height - vector.y - 10f, vector.x, vector.y);
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			return TickResult.StopTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public void Reset()
		{
			_boxStyle = new GUIStyle();
		}
	}
}
