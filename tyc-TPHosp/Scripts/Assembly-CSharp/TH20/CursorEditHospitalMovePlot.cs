using System;
using UnityEngine;

namespace TH20
{
	public class CursorEditHospitalMovePlot : CursorMode
	{
		private Level _level;

		private HospitalPlot _hospitalPlot;

		private FloorPlan _floorPlan;

		private RoomFloorPlanVisual _floorPlanVisual;

		private GridCoord _originalAnchor;

		private GridCoord _cursorStart;

		private bool _moving;

		public CursorEditHospitalMovePlot(CursorManager cursorManager, Level level, HospitalPlot hospitalPlot)
			: base(cursorManager)
		{
			_level = level;
			OnSelectHospitalPlot(hospitalPlot);
			_cursorManager.SetCursorIcon(CursorIcon.MoveRoom);
			HospitalEditEvents hospitalEditEvents = _level.HospitalEditEvents;
			hospitalEditEvents.OnSelectHospitalPlot = (Action<HospitalPlot>)Delegate.Combine(hospitalEditEvents.OnSelectHospitalPlot, new Action<HospitalPlot>(OnSelectHospitalPlot));
		}

		public override void Destroy()
		{
			_cursorManager.SetCursorIcon(CursorIcon.Default);
			HospitalEditEvents hospitalEditEvents = _level.HospitalEditEvents;
			hospitalEditEvents.OnSelectHospitalPlot = (Action<HospitalPlot>)Delegate.Remove(hospitalEditEvents.OnSelectHospitalPlot, new Action<HospitalPlot>(OnSelectHospitalPlot));
			base.Destroy();
		}

		public override void CursorUpdate(InputManager inputManager)
		{
			bool mouseQuickOnScene = inputManager.GetMouseQuickOnScene(MouseButton.Left);
			bool mouseQuickOnScene2 = inputManager.GetMouseQuickOnScene(MouseButton.Right);
			if (!_moving && mouseQuickOnScene)
			{
				Start();
			}
			else if (_moving && mouseQuickOnScene2)
			{
				Cancel();
			}
			else if (_moving && mouseQuickOnScene)
			{
				Place();
			}
			if (_moving)
			{
				GridCoord gridCoord = _cursorManager.WorldPositionSmoothed.ToGridCoord() - _cursorStart;
				_floorPlan.Anchor = _originalAnchor + gridCoord;
				_floorPlanVisual.UpdateFromRoom(_floorPlan);
			}
		}

		private void OnSelectHospitalPlot(HospitalPlot hospitalPlot)
		{
			Cancel();
			_hospitalPlot = hospitalPlot;
			if (_hospitalPlot.HospitalMap != null)
			{
				_floorPlan = _hospitalPlot.HospitalMap.FloorPlan;
				_floorPlanVisual = _hospitalPlot.HospitalMap.RoomVisual;
			}
		}

		private void Start()
		{
			_moving = true;
			_cursorManager.SetCursorIcon(CursorIcon.MovingRoom);
			_cursorStart = _cursorManager.WorldPositionSmoothed.ToGridCoord();
			if (_hospitalPlot.HospitalMap != null)
			{
				_originalAnchor = _hospitalPlot.HospitalMap.FloorPlan.Anchor;
			}
		}

		private void Cancel()
		{
			if (_moving)
			{
				_moving = false;
				_cursorManager.SetCursorIcon(CursorIcon.MoveRoom);
				_floorPlan.Anchor = _originalAnchor;
				_floorPlanVisual.UpdateFromRoom(_floorPlan);
			}
		}

		private void Place()
		{
			GridCoord gridCoord = _originalAnchor - _floorPlan.Anchor;
			Texture2D floorImage = _hospitalPlot.Definition.FloorImage;
			_moving = false;
			_floorPlan.Anchor = _originalAnchor;
			_cursorManager.SetCursorIcon(CursorIcon.MoveRoom);
			ShiftFloorImage(floorImage, gridCoord.X, gridCoord.Y);
			floorImage.Apply();
			if (_hospitalPlot.HospitalMap != null)
			{
				_hospitalPlot.HospitalMap.Build(animateWalls: false);
				_floorPlan = _hospitalPlot.HospitalMap.FloorPlan;
				_floorPlanVisual = _hospitalPlot.HospitalMap.RoomVisual;
				_level.WorldState.CalculateLighting();
			}
		}

		private static void ShiftFloorImage(Texture2D image, int xo, int yo)
		{
			int width = image.width;
			int height = image.height;
			Color32[] pixels = image.GetPixels32();
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					Color color = Color.clear;
					int num = j + xo;
					int num2 = i + yo;
					if (num >= 0 && num < width && num2 >= 0 && num2 < height)
					{
						color = pixels[num + num2 * width];
					}
					image.SetPixel(j, i, color);
				}
			}
		}
	}
}
