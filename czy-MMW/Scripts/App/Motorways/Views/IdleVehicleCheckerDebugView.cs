using Client;
using Factory;
using Factory.Pools;
using UnityEngine;

namespace Motorways.Views
{
	public class IdleVehicleCheckerDebugView : MonoBehaviour, IView, IReusable
	{
		private const int IdleIndicatorFontSize = 50;

		private const int IdleIndicatorFontInitialSize = 400;

		[Dependency]
		private MotorwaysGame _motorwaysGame;

		[Dependency]
		private GameCamera _camera;

		[Dependency]
		private ViewIndex _viewIndex;

		private GUIStyle _textStyle;

		private GUIStyle _idleCircleStyle;

		private void Awake()
		{
			_textStyle = new GUIStyle
			{
				fontSize = 25
			};
			_idleCircleStyle = new GUIStyle
			{
				fontSize = 50,
				fontStyle = FontStyle.Bold
			};
		}

		public TickResult Tick(TimeInterval tickTime, float stepAlpha)
		{
			return TickResult.StopTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public void Reset()
		{
			_idleCircleStyle = new GUIStyle
			{
				fontSize = 50,
				fontStyle = FontStyle.Bold
			};
		}
	}
}
