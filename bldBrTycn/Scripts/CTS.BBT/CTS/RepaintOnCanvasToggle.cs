using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class RepaintOnCanvasToggle : CTSBehaviour
	{
		[SerializeField]
		private SoftReference<IRepaint> _objectToRepaint;

		[SerializeField]
		private CanvasGroupController _parentCanvas;

		[SerializeField]
		private bool _repaintOnOpen;

		[SerializeField]
		private bool _repaintOnClose;

		protected override void OnAwake()
		{
			base.OnAwake();
			_parentCanvas.CanvasShowning += OnCanvasShowing;
		}

		private void OnCanvasShowing(bool isOpening)
		{
			if (isOpening)
			{
				if (_repaintOnOpen)
				{
					_objectToRepaint.Value.Repaint();
				}
			}
			else if (_repaintOnClose)
			{
				_objectToRepaint.Value.Repaint();
			}
		}
	}
}
