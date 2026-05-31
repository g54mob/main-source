using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	[RequireComponent(typeof(Canvas))]
	public abstract class UICanvas : UIObject
	{
		private Canvas _canvasRef;

		private GraphicRaycaster _graphicRaycaster;

		protected override void Awake()
		{
			_canvasRef = GetComponent<Canvas>();
			_graphicRaycaster = GetComponent<GraphicRaycaster>();
			base.Awake();
		}

		protected override bool GetAwakeActive()
		{
			return _canvasRef.enabled;
		}

		protected override void OnUIEnabled()
		{
			_canvasRef.enabled = true;
			if ((bool)_graphicRaycaster)
			{
				_graphicRaycaster.enabled = true;
			}
		}

		protected override void OnUIDisabled()
		{
			_canvasRef.enabled = false;
			if ((bool)_graphicRaycaster)
			{
				_graphicRaycaster.enabled = false;
			}
		}
	}
}
