using System;
using Assets.Scripts.Input.Events;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class DragBlueprintTool : DesignerTool
	{
		private BlueprintScript _blueprintScript;

		private bool _pinching;

		private Vector2 _pinchStartPos;

		private Vector2 _pinchStartSize;

		public bool IsSelected { get; set; }

		public event Action ScaleChanged;

		public DragBlueprintTool(Designer designer, CameraController cameraController)
			: base(designer, cameraController)
		{
			base.AllowPartSelection = false;
			base.AllowFingerAid = false;
			base.ShowSelectionHighlight = false;
			base.CanPinch = true;
		}

		public override void HandleInput(InputEvent e)
		{
			if (!_pinching)
			{
				float num = 2f * Camera.main.orthographicSize / (float)Screen.height;
				Vector2 vector = e.DeltaPosition * num;
				if (e.InputButton == InputButton.Primary)
				{
					_blueprintScript.Move(vector);
				}
				else if (e.InputButton == InputButton.Secondary)
				{
					base.CameraController.Move(-vector);
				}
			}
		}

		public override void HandlePinch(PinchEvent e)
		{
			if (e.InputState == InputState.Begin)
			{
				_pinching = true;
				_pinchStartPos = _blueprintScript.Offset;
				_pinchStartSize = _blueprintScript.Size;
			}
			else if (e.InputState == InputState.Updated)
			{
				_pinching = true;
				float num = (e.TotalDistanceDelta + e.StartDistance) / e.StartDistance;
				float num2 = 2f * Camera.main.orthographicSize / (float)Screen.height;
				_blueprintScript.Size = _pinchStartSize * num;
				_blueprintScript.Offset = _pinchStartPos + e.TotalMidpointDelta * num2;
				this.ScaleChanged?.Invoke();
			}
			else
			{
				_pinching = false;
			}
		}

		public void Setup(BlueprintScript blueprintScript)
		{
			_blueprintScript = blueprintScript;
		}

		public override void Start()
		{
			IsSelected = true;
			base.Start();
		}

		public override void Stop()
		{
			IsSelected = false;
			base.Stop();
		}

		public override void Update()
		{
			base.Update();
			if (!base.CameraController.IsOrthographic || _blueprintScript == null || !_blueprintScript.IsShown)
			{
				base.Designer.Tools.SelectMovePartTool();
			}
		}
	}
}
