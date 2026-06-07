using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class MultiSelectShape
	{
		private Rect _enclosingRect;

		private bool _isVisible;

		private int _minSize = 3;

		public Rect EnclosingRect => _enclosingRect;

		public bool IsVisible
		{
			get
			{
				return _isVisible;
			}
			set
			{
				_isVisible = value;
			}
		}

		public int MinSize
		{
			get
			{
				return _minSize;
			}
			set
			{
				_minSize = Mathf.Max(1, value);
			}
		}

		public void SetEnclosingRectTopLeftPoint(Vector2 topLeftPoint)
		{
			_enclosingRect.xMin = topLeftPoint.x;
			_enclosingRect.yMax = topLeftPoint.y;
		}

		public void SetEnclosingRectBottomRightPoint(Vector2 bottomRightPoint)
		{
			_enclosingRect.xMax = bottomRightPoint.x;
			_enclosingRect.yMin = bottomRightPoint.y;
		}

		public List<GameObject> GetOverlappedObjects(List<GameObject> gameObjects, Camera camera, ObjectBounds.QueryConfig boundsQConfig, MultiSelectOverlapMode overlapMode)
		{
			if (gameObjects.Count == 0 || !IsBigEnoughForOverlap())
			{
				return new List<GameObject>();
			}
			List<GameObject> list = new List<GameObject>(gameObjects.Count);
			if (overlapMode == MultiSelectOverlapMode.Partial)
			{
				foreach (GameObject gameObject in gameObjects)
				{
					Rect other = ObjectBounds.CalcScreenRect(gameObject, camera, boundsQConfig);
					if (_enclosingRect.Overlaps(other, allowInverse: true))
					{
						list.Add(gameObject);
					}
				}
			}
			else
			{
				foreach (GameObject gameObject2 in gameObjects)
				{
					Rect rect = ObjectBounds.CalcScreenRect(gameObject2, camera, boundsQConfig);
					if (_enclosingRect.ContainsAllPoints(rect.GetCornerPoints()))
					{
						list.Add(gameObject2);
					}
				}
			}
			return list;
		}

		public bool OverlapsObject(GameObject gameObject, Camera camera, ObjectBounds.QueryConfig boundsQConfig, MultiSelectOverlapMode overlapMode)
		{
			if (!IsBigEnoughForOverlap())
			{
				return false;
			}
			if (overlapMode == MultiSelectOverlapMode.Partial)
			{
				Rect other = ObjectBounds.CalcScreenRect(gameObject, camera, boundsQConfig);
				return _enclosingRect.Overlaps(other, allowInverse: true);
			}
			Rect rect = ObjectBounds.CalcScreenRect(gameObject, camera, boundsQConfig);
			return _enclosingRect.ContainsAllPoints(rect.GetCornerPoints());
		}

		public void Render(Color fillColor, Color borderColor, Camera camera)
		{
			if (_isVisible)
			{
				Material simpleColor = Singleton<MaterialPool>.Get.SimpleColor;
				simpleColor.SetColor(fillColor);
				simpleColor.SetCullModeOff();
				simpleColor.SetPass(0);
				GLRenderer.DrawRect2D(_enclosingRect, camera);
				simpleColor.SetColor(borderColor);
				simpleColor.SetPass(0);
				GLRenderer.DrawRectBorder2D(_enclosingRect, camera);
			}
		}

		private bool IsBigEnoughForOverlap()
		{
			if (Mathf.Abs(_enclosingRect.width) >= (float)_minSize)
			{
				return Mathf.Abs(_enclosingRect.height) >= (float)_minSize;
			}
			return false;
		}
	}
}
