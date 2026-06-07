using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class GizmoHandle : IGizmoHandle
	{
		public GizmoHandleCanHoverHandler CanHover;

		private int _id;

		private Gizmo _gizmo;

		private GizmoTransform _zoomFactorTransform;

		private Priority _genericHoverPriority = new Priority();

		private Priority _hoverPriority2D = new Priority();

		private Priority _hoverPriority3D = new Priority();

		private List<GizmoHandleShape3D> _3DShapes = new List<GizmoHandleShape3D>();

		private List<GizmoHandleShape2D> _2DShapes = new List<GizmoHandleShape2D>();

		public int Id => _id;

		public Gizmo Gizmo => _gizmo;

		public IGizmoDragSession DragSession { get; set; }

		public Priority GenericHoverPriority => _genericHoverPriority;

		public Priority HoverPriority2D => _hoverPriority2D;

		public Priority HoverPriority3D => _hoverPriority3D;

		public int Num3DShapes => _3DShapes.Count;

		public int Num2DShapes => _2DShapes.Count;

		public bool Has3DShapes => Num3DShapes != 0;

		public bool Has2DShapes => Num2DShapes != 0;

		public bool Is2DHoverable { get; set; }

		public bool Is3DHoverable { get; set; }

		public bool Is2DVisible { get; set; }

		public bool Is3DVisible { get; set; }

		public GizmoHandle(Gizmo gizmo, int id)
		{
			_id = id;
			_gizmo = gizmo;
			_zoomFactorTransform = _gizmo.Transform;
			SetHoverable(isHoverable: true);
			SetVisible(isVisible: true);
		}

		public float GetZoomFactor(Camera camera)
		{
			return camera.EstimateZoomFactor(_zoomFactorTransform.Position3D);
		}

		public void SetZoomFactorTransform(GizmoTransform transform)
		{
			if (transform == null)
			{
				_zoomFactorTransform = _gizmo.Transform;
			}
			else
			{
				_zoomFactorTransform = transform;
			}
		}

		public void SetHoverable(bool isHoverable)
		{
			bool is2DHoverable = (Is3DHoverable = isHoverable);
			Is2DHoverable = is2DHoverable;
		}

		public void SetVisible(bool isVisible)
		{
			bool is2DVisible = (Is3DVisible = isVisible);
			Is2DVisible = is2DVisible;
		}

		public Shape3D Get3DShape(int shapeIndex)
		{
			return _3DShapes[shapeIndex].Shape;
		}

		public Shape2D Get2DShape(int shapeIndex)
		{
			return _2DShapes[shapeIndex].Shape;
		}

		public void SetAll3DShapesVisible(bool visible)
		{
			foreach (GizmoHandleShape3D _3DShape in _3DShapes)
			{
				_3DShape.IsVisible = visible;
			}
		}

		public void Set3DShapeVisible(int shapeIndex, bool isVisible)
		{
			_3DShapes[shapeIndex].IsVisible = isVisible;
		}

		public bool Is3DShapeVisible(int shapeIndex)
		{
			return _3DShapes[shapeIndex].IsVisible;
		}

		public void Set3DShapeHoverable(int shapeIndex, bool isHoverable)
		{
			_3DShapes[shapeIndex].IsHoverable = isHoverable;
		}

		public void SetAll2DShapesVisible(bool visible)
		{
			foreach (GizmoHandleShape2D _2DShape in _2DShapes)
			{
				_2DShape.IsVisible = visible;
			}
		}

		public void Set2DShapeVisible(int shapeIndex, bool isVisible)
		{
			_2DShapes[shapeIndex].IsVisible = isVisible;
		}

		public bool Is2DShapeVisible(int shapeIndex)
		{
			return _2DShapes[shapeIndex].IsVisible;
		}

		public void Set2DShapeHoverable(int shapeIndex, bool isHoverable)
		{
			_2DShapes[shapeIndex].IsHoverable = isHoverable;
		}

		public bool Contains3DShape(Shape3D shape)
		{
			return _3DShapes.FindAll((GizmoHandleShape3D item) => item.Shape == shape).Count != 0;
		}

		public bool Contains2DShape(Shape2D shape)
		{
			return _2DShapes.FindAll((GizmoHandleShape2D item) => item.Shape == shape).Count != 0;
		}

		public int Add3DShape(Shape3D shape)
		{
			if (!Contains3DShape(shape))
			{
				GizmoHandleShape3D item = new GizmoHandleShape3D(shape);
				_3DShapes.Add(item);
				return _3DShapes.Count - 1;
			}
			return -1;
		}

		public int Add2DShape(Shape2D shape)
		{
			if (!Contains2DShape(shape))
			{
				GizmoHandleShape2D item = new GizmoHandleShape2D(shape);
				_2DShapes.Add(item);
				return _2DShapes.Count - 1;
			}
			return -1;
		}

		public void Remove3DShape(Shape3D shape)
		{
			_3DShapes.RemoveAll((GizmoHandleShape3D item) => item.Shape == shape);
		}

		public void Remove2DShape(Shape2D shape)
		{
			_2DShapes.RemoveAll((GizmoHandleShape2D item) => item.Shape == shape);
		}

		public void Render3DSolid()
		{
			if (!Is3DVisible)
			{
				return;
			}
			foreach (GizmoHandleShape3D _3DShape in _3DShapes)
			{
				if (_3DShape.IsVisible)
				{
					_3DShape.Shape.RenderSolid();
				}
			}
		}

		public void Render3DWire()
		{
			if (!Is3DVisible)
			{
				return;
			}
			foreach (GizmoHandleShape3D _3DShape in _3DShapes)
			{
				if (_3DShape.IsVisible)
				{
					_3DShape.Shape.RenderWire();
				}
			}
		}

		public void Render3DSolid(int shapeIndex)
		{
			GizmoHandleShape3D gizmoHandleShape3D = _3DShapes[shapeIndex];
			if (Is3DVisible && gizmoHandleShape3D.IsVisible)
			{
				gizmoHandleShape3D.Shape.RenderSolid();
			}
		}

		public void Render3DWire(int shapeIndex)
		{
			GizmoHandleShape3D gizmoHandleShape3D = _3DShapes[shapeIndex];
			if (Is3DVisible && gizmoHandleShape3D.IsVisible)
			{
				gizmoHandleShape3D.Shape.RenderWire();
			}
		}

		public void Render2DSolid(Camera camera)
		{
			if (!Is2DVisible || !camera.IsPointInFrontNearPlane(Gizmo.Transform.Position3D))
			{
				return;
			}
			foreach (GizmoHandleShape2D _2DShape in _2DShapes)
			{
				if (_2DShape.IsVisible)
				{
					_2DShape.Shape.RenderArea(camera);
				}
			}
		}

		public void Render2DWire(Camera camera)
		{
			if (!Is2DVisible || !camera.IsPointInFrontNearPlane(Gizmo.Transform.Position3D))
			{
				return;
			}
			foreach (GizmoHandleShape2D _2DShape in _2DShapes)
			{
				if (_2DShape.IsVisible)
				{
					_2DShape.Shape.RenderBorder(camera);
				}
			}
		}

		public void Render2DSolid(Camera camera, int shapeIndex)
		{
			GizmoHandleShape2D gizmoHandleShape2D = _2DShapes[shapeIndex];
			if (Is2DVisible && gizmoHandleShape2D.IsVisible && camera.IsPointInFrontNearPlane(Gizmo.Transform.Position3D))
			{
				gizmoHandleShape2D.Shape.RenderArea(camera);
			}
		}

		public void Render2DWire(Camera camera, int shapeIndex)
		{
			GizmoHandleShape2D gizmoHandleShape2D = _2DShapes[shapeIndex];
			if (Is2DVisible && gizmoHandleShape2D.IsVisible && camera.IsPointInFrontNearPlane(Gizmo.Transform.Position3D))
			{
				gizmoHandleShape2D.Shape.RenderBorder(camera);
			}
		}

		public Rect GetVisible2DShapesRect(Camera camera)
		{
			if (Num2DShapes == 0 || !camera.IsPointInFrontNearPlane(Gizmo.Transform.Position3D))
			{
				return default(Rect);
			}
			List<Vector2> list = new List<Vector2>(Num2DShapes * 4);
			foreach (GizmoHandleShape2D _2DShape in _2DShapes)
			{
				if (_2DShape.IsVisible)
				{
					Rect encapsulatingRect = _2DShape.Shape.GetEncapsulatingRect();
					list.AddRange(encapsulatingRect.GetCornerPoints());
				}
			}
			if (list.Count == 0)
			{
				return default(Rect);
			}
			return RectEx.FromPoints(list);
		}

		public AABB GetVisible3DShapesAABB()
		{
			AABB result = AABB.GetInvalid();
			if (Num3DShapes == 0)
			{
				return result;
			}
			foreach (GizmoHandleShape3D _3DShape in _3DShapes)
			{
				if (!_3DShape.IsVisible)
				{
					continue;
				}
				AABB aABB = _3DShape.Shape.GetAABB();
				if (aABB.IsValid)
				{
					if (result.IsValid)
					{
						result.Encapsulate(aABB);
					}
					else
					{
						result = aABB;
					}
				}
			}
			return result;
		}

		public bool IsVisibleToCamera(Camera camera, Plane[] frustumWorldPlanes)
		{
			bool flag = false;
			bool result = false;
			if (Num2DShapes != 0 && camera.IsPointInFrontNearPlane(Gizmo.Transform.Position3D))
			{
				foreach (GizmoHandleShape2D _2DShape in _2DShapes)
				{
					Rect encapsulatingRect = _2DShape.Shape.GetEncapsulatingRect();
					if (camera.pixelRect.Overlaps(encapsulatingRect, allowInverse: true))
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				return true;
			}
			if (Num3DShapes != 0)
			{
				foreach (GizmoHandleShape3D _3DShape in _3DShapes)
				{
					AABB aABB = _3DShape.Shape.GetAABB();
					if (CameraViewVolume.CheckAABB(camera, aABB, frustumWorldPlanes))
					{
						result = true;
						break;
					}
				}
			}
			return result;
		}

		public GizmoHandleHoverData GetHoverData(Ray hoverRay)
		{
			float num = float.MaxValue;
			GizmoHandleHoverData gizmoHandleHoverData = null;
			if (Is2DHoverable && Is2DVisible)
			{
				Vector2 vector = Gizmo.GetWorkCamera().WorldToScreenPoint(hoverRay.origin);
				GizmoHandleShape2D gizmoHandleShape2D = null;
				foreach (GizmoHandleShape2D _2DShape in _2DShapes)
				{
					if (_2DShape.IsVisible && _2DShape.IsHoverable && _2DShape.Shape.ContainsPoint(vector))
					{
						float magnitude = (_2DShape.Shape.GetEncapsulatingRect().center - vector).magnitude;
						if (gizmoHandleShape2D == null || magnitude < num)
						{
							gizmoHandleShape2D = _2DShape;
							num = magnitude;
						}
					}
				}
				if (gizmoHandleShape2D != null)
				{
					gizmoHandleHoverData = new GizmoHandleHoverData(hoverRay, this, vector);
					if (CanHover != null)
					{
						YesNoAnswer yesNoAnswer = new YesNoAnswer();
						CanHover(Id, Gizmo, gizmoHandleHoverData, yesNoAnswer);
						if (yesNoAnswer.HasNo)
						{
							return null;
						}
					}
					return gizmoHandleHoverData;
				}
			}
			if (Is3DHoverable && Is3DVisible)
			{
				num = float.MaxValue;
				GizmoHandleShape3D gizmoHandleShape3D = null;
				foreach (GizmoHandleShape3D _3DShape in _3DShapes)
				{
					if (_3DShape.IsVisible && _3DShape.IsHoverable && _3DShape.Shape.Raycast(hoverRay, out var t) && (gizmoHandleShape3D == null || t < num))
					{
						gizmoHandleShape3D = _3DShape;
						num = t;
					}
				}
				if (gizmoHandleShape3D != null)
				{
					gizmoHandleHoverData = new GizmoHandleHoverData(hoverRay, this, num);
					if (CanHover != null)
					{
						YesNoAnswer yesNoAnswer2 = new YesNoAnswer();
						CanHover(Id, Gizmo, gizmoHandleHoverData, yesNoAnswer2);
						if (yesNoAnswer2.HasNo)
						{
							return null;
						}
					}
					return gizmoHandleHoverData;
				}
			}
			return null;
		}
	}
}
