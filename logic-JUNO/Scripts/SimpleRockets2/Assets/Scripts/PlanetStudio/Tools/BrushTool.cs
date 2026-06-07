using System;
using System.Collections.Generic;
using Assets.Scripts.PlanetStudio.Brush;
using Assets.Scripts.PlanetStudio.Brush.Brushes;
using Assets.Scripts.PlanetStudio.Brush.Events;
using ModApi.PlanetStudio;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.PlanetStudio.Tools
{
	public class BrushTool : PlanetStudioTool
	{
		private List<int> _textureIndicesForStroke;

		public PlanetBrush Brush { get; set; }

		public BrushSphereScript BrushSphere => Viewer.BrushSphere;

		public bool IsBrushStrokeActive { get; private set; }

		public float Radius { get; set; }

		public CelestialBodyViewerScript Viewer { get; }

		public event EventHandler<BrushStrokeCompletedEventArgs> BrushStrokeCompleted;

		public event EventHandler<EventArgs> BrushStrokeStarted;

		public BrushTool(CelestialBodyDesignerScript designer)
			: base(designer)
		{
			Viewer = designer.CelestialBodyViewer;
			_textureIndicesForStroke = new List<int>(6);
		}

		public override bool OnDrag(PointerEventData eventData)
		{
			if (Brush != null && eventData.button == PointerEventData.InputButton.Left && IsBrushStrokeActive)
			{
				return ApplyBrush(eventData.position);
			}
			return false;
		}

		public override bool OnPointerDown(PointerEventData eventData)
		{
			if (Brush != null && eventData.button == PointerEventData.InputButton.Left)
			{
				IsBrushStrokeActive = false;
				return ApplyBrush(eventData.position);
			}
			return false;
		}

		public override bool OnPointerUp(PointerEventData eventData)
		{
			if (Brush != null && eventData.button == PointerEventData.InputButton.Left && IsBrushStrokeActive)
			{
				IsBrushStrokeActive = false;
				Brush.EndBrush();
				this.BrushStrokeCompleted?.Invoke(this, new BrushStrokeCompletedEventArgs(_textureIndicesForStroke));
				_textureIndicesForStroke.Clear();
			}
			return false;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			Vector3d? obj = Viewer.RaycastTerrain(UnityEngine.Input.mousePosition)?.normalized;
			BrushSphere.SetBrushInfo((Vector3?)obj, Radius);
		}

		private bool ApplyBrush(Vector2 position)
		{
			if (!BrushSphere.CubemapLoaded)
			{
				return false;
			}
			Vector3d? vector3d = Viewer.RaycastTerrain(position)?.normalized;
			if (vector3d.HasValue)
			{
				if (!IsBrushStrokeActive)
				{
					IsBrushStrokeActive = true;
					_textureIndicesForStroke.Clear();
					this.BrushStrokeStarted?.Invoke(this, EventArgs.Empty);
					Brush.BeginBrush();
				}
				BrushPixelData brushPixelData = BrushSphere.GetBrushPixelData(vector3d.Value.ToVector3(), Radius);
				foreach (BrushPixelFaceData face in brushPixelData.Faces)
				{
					if (!_textureIndicesForStroke.Contains(face.FaceIndex))
					{
						_textureIndicesForStroke.Add(face.FaceIndex);
					}
				}
				Brush.UpdateBrush(brushPixelData);
				return true;
			}
			return false;
		}
	}
}
