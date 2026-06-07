using ModApi.Flight;
using ModApi.Flight.GameView;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.Flight.GameView.Effects
{
	public class RunwayLightsScript : MonoBehaviour, IDynamicStructureMaterial
	{
		private IFlightScene _flightScene;

		private IGameView _gameView;

		[SerializeField]
		private ParticleSystem _system;

		public void UpdateMaterial(float tiling, Color color)
		{
			Vector3 localScale = base.transform.localScale;
			ParticleSystem.MainModule main = _system.main;
			ParticleSystem.ShapeModule shape = _system.shape;
			color.a = new Vector3(color.r, color.g, color.b).magnitude;
			main.startColor = color;
			int num = (main.maxParticles = (int)Mathf.Max(1f, localScale.z));
			shape.radiusSpread = ((num == 1) ? 0f : (1f / (float)(num - 1)));
			main.startSize = Mathf.Abs(localScale.x);
			shape.radius = ((num == 1) ? 0f : Mathf.Abs(localScale.y));
			if (_system.isPlaying)
			{
				_system.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
			}
			_system.Play(withChildren: true);
		}

		protected virtual void Start()
		{
			_flightScene = Game.Instance.FlightScene;
			_gameView = _flightScene?.ViewManager.GameView;
		}

		protected virtual void Update()
		{
			if (!Game.InFlightScene)
			{
				return;
			}
			bool flag = Vector3d.Dot(_flightScene.CraftNode.CraftScript.FlightData.SolarRadiationDirection, _gameView.ReferenceFrame.FrameToPlanetPosition(base.transform.position).normalized) > -0.15;
			if (_system.isPlaying != flag)
			{
				_system.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
				if (flag)
				{
					_system.Play(withChildren: true);
				}
			}
		}
	}
}
