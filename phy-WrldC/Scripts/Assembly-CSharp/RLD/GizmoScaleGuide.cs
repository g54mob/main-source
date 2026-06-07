using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class GizmoScaleGuide
	{
		private GizmoScaleGuideLookAndFeel _lookAndFeel = new GizmoScaleGuideLookAndFeel();

		private GizmoScaleGuideLookAndFeel _sharedLookAndFeel;

		public GizmoScaleGuideLookAndFeel LookAndFeel
		{
			get
			{
				if (_sharedLookAndFeel != null)
				{
					return _sharedLookAndFeel;
				}
				return _lookAndFeel;
			}
		}

		public GizmoScaleGuideLookAndFeel SharedLookAndFeel
		{
			get
			{
				return _sharedLookAndFeel;
			}
			set
			{
				_sharedLookAndFeel = value;
			}
		}

		public void Render(IEnumerable<GameObject> gameObjects, Camera camera)
		{
			if (gameObjects == null)
			{
				return;
			}
			GizmoLineMaterial get = Singleton<GizmoLineMaterial>.Get;
			get.ResetValuesToSensibleDefaults();
			foreach (GameObject gameObject in gameObjects)
			{
				Transform transform = gameObject.transform;
				Vector3 position = transform.position;
				Vector3 right = transform.right;
				Vector3 up = transform.up;
				Vector3 forward = transform.forward;
				float num = 1f;
				if (LookAndFeel.UseZoomFactor)
				{
					num = camera.EstimateZoomFactor(position);
				}
				float num2 = LookAndFeel.AxisLength * num;
				Vector3 startPoint = position - right * num2;
				Vector3 endPoint = position + right * num2;
				get.SetColor(LookAndFeel.XAxisColor);
				get.SetPass(0);
				GLRenderer.DrawLine3D(startPoint, endPoint);
				Vector3 startPoint2 = position - up * num2;
				endPoint = position + up * num2;
				get.SetColor(LookAndFeel.YAxisColor);
				get.SetPass(0);
				GLRenderer.DrawLine3D(startPoint2, endPoint);
				Vector3 startPoint3 = position - forward * num2;
				endPoint = position + forward * num2;
				get.SetColor(LookAndFeel.ZAxisColor);
				get.SetPass(0);
				GLRenderer.DrawLine3D(startPoint3, endPoint);
			}
		}
	}
}
