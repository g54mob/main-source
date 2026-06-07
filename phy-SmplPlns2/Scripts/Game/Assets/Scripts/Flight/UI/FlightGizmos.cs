using System.Collections.Generic;
using Shapes;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Flight.UI
{
	public class FlightGizmos
	{
		private static List<IFlightGizmo> _gizmos = new List<IFlightGizmo>();

		private static bool _visible;

		public bool Visible
		{
			get
			{
				return _visible;
			}
			set
			{
				if (value)
				{
					EnableFlightGizmos();
				}
				else
				{
					DisableFlightGizmos();
				}
			}
		}

		public static void DisableFlightGizmos()
		{
			if (!_visible)
			{
				return;
			}
			_visible = false;
			RenderPipelineManager.beginCameraRendering -= DrawFlightGizmos;
			foreach (IFlightGizmo gizmo in _gizmos)
			{
				gizmo.OnFlightGizmosEnabled(enabled: false);
			}
		}

		public static void EnableFlightGizmos()
		{
			if (_visible)
			{
				return;
			}
			RenderPipelineManager.beginCameraRendering += DrawFlightGizmos;
			_visible = true;
			foreach (IFlightGizmo gizmo in _gizmos)
			{
				gizmo.OnFlightGizmosEnabled(enabled: true);
			}
		}

		public void OnDestroy()
		{
			Visible = false;
			_gizmos.Clear();
		}

		public void RegisterGizmo(IFlightGizmo gizmo)
		{
			_gizmos.Add(gizmo);
		}

		public void UnregisterGizmo(IFlightGizmo gizmo)
		{
			_gizmos.Remove(gizmo);
		}

		private static void DrawFlightGizmos(ScriptableRenderContext context, Camera camera)
		{
			if (FlightSceneScript.Instance == null || FlightSceneScript.Instance.CameraScript == null || camera != FlightSceneScript.Instance.CameraScript.MainCamera)
			{
				return;
			}
			foreach (IFlightGizmo gizmo in _gizmos)
			{
				using (Draw.Command(camera))
				{
					gizmo.DrawFlightGizmo(camera);
				}
			}
		}
	}
}
