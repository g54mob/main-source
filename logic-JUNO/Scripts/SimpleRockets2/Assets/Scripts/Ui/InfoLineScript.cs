using System;
using System.Collections.Generic;
using ModApi;
using UnityEngine;
using UnityEngine.UI;
using Vectrosity;

namespace Assets.Scripts.Ui
{
	public class InfoLineScript : MonoBehaviour
	{
		private Canvas _infoCanvas;

		private Text _infoText;

		private Func<string> _infoTextFunc;

		private VectorLine _line;

		private Func<Vector3> _point1Func;

		private Func<Vector3> _point2Func;

		private Camera _uiCamera;

		public static InfoLineScript Create(Func<Vector3> point1Func, Func<Vector3> point2Func, Func<string> infoTextFunc, Color color, Camera uiCamera, Transform parent, string name)
		{
			Transform obj = new GameObject(name).transform;
			obj.gameObject.layer = parent.gameObject.layer;
			obj.SetParent(parent);
			InfoLineScript infoLineScript = obj.gameObject.AddComponent<InfoLineScript>();
			infoLineScript.Initialize(point1Func, point2Func, infoTextFunc, color, uiCamera);
			return infoLineScript;
		}

		public void Initialize(Func<Vector3> point1Func, Func<Vector3> point2Func, Func<string> infoTextFunc, Color color, Camera uiCamera)
		{
			_uiCamera = uiCamera;
			_point1Func = point1Func;
			_point2Func = point2Func;
			_infoTextFunc = infoTextFunc;
			_infoCanvas = base.gameObject.AddComponent<Canvas>();
			_infoCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
			_infoCanvas.worldCamera = _uiCamera;
			GameObject gameObject = new GameObject("InfoText");
			gameObject.transform.SetParent(base.transform);
			_infoText = gameObject.AddComponent<Text>();
			_infoText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
			_infoText.color = color;
			_infoText.alignment = TextAnchor.MiddleRight;
			_infoText.FontTextureChanged();
			_infoText.gameObject.layer = _infoCanvas.gameObject.layer;
			_line = new VectorLine(base.name + "_line", new List<Vector3>(2), 2f);
			_line.rectTransform.gameObject.layer = base.gameObject.layer;
			_line.color = color;
			Utilities.FixUnityCanvasSortingBug(_infoCanvas);
		}

		public void Update()
		{
			Vector3 value = _point1Func();
			Vector3 vector = _point2Func();
			_line.points3[0] = value;
			_line.points3[1] = vector;
			_line.Draw3DAuto();
			_line.rectTransform.gameObject.transform.SetParent(base.transform);
			Vector3 vector2 = Utilities.GameWorldToScreenPoint(_infoCanvas.worldCamera, vector);
			if (vector2.z >= 0f)
			{
				_infoText.enabled = true;
				_infoText.rectTransform.position = (Vector2)vector2;
				_infoText.text = _infoTextFunc();
			}
			else
			{
				_infoText.enabled = false;
			}
		}
	}
}
