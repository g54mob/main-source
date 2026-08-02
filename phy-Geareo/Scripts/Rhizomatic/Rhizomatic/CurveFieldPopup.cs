using System;
using System.Collections.Generic;
using Rhizomatic.Pooling;
using UnityEngine;
using UnityEngine.UI;

namespace Rhizomatic
{
	public class CurveFieldPopup : PoolObject
	{
		public RectTransform root;

		public CurvePointDetailsPopup detailsPopup;

		public Transform pointsParent;

		public RawImage curveImage;

		public CurvePoint pointPrefab;

		public Button submit;

		public float scale;

		public Color backgroundColor;

		public Color lineColor;

		public Color gridColor;

		public Curve currentCurve;

		public Action<Curve> onSubmit;

		private float lastClick;

		private Texture2D texture;

		private List<CurvePoint> selectedPoints;

		private List<CurvePoint> currentPoints;

		private BackHandlerItem backItem;

		private List<CurvePoint> left;

		public void Setup(CurveField field, Action<Curve> onSubmit)
		{
		}

		protected override void OnCreated()
		{
		}

		protected override void OnPooled()
		{
		}

		protected override void Update()
		{
		}

		public void Submit()
		{
		}

		public void Close()
		{
		}

		public void CancelSelection()
		{
		}

		public void OpenDetailsPopup(CurvePoint point)
		{
		}

		public void TryAddPoint()
		{
		}

		public void Fix()
		{
		}

		public void CheckAuto(CurvePoint point)
		{
		}

		public void UpdateView()
		{
		}

		public Vector2 GetMapPosition()
		{
			return default(Vector2);
		}

		public Vector2 ClampPosition(Vector2 pos)
		{
			return default(Vector2);
		}

		public CurvePoint SpawnPoint(Transform parent, Vector3 position)
		{
			return null;
		}

		public void SelectPoint(CurvePoint point)
		{
		}

		public bool IsSelected(CurvePoint point)
		{
			return false;
		}

		public void HandlePointClick(CurvePoint point)
		{
		}

		public void HandlePointDrag(CurvePoint point)
		{
		}

		private void HandleDrag(CurvePoint point)
		{
		}

		public void HandlePointBeginDrag(CurvePoint point)
		{
		}

		public void HandlePointEndDrag(CurvePoint point)
		{
		}

		public Texture2D DrawCurve(Curve curve, Texture2D texture, int thickness, bool grid = false)
		{
			return null;
		}

		public static void DrawGrid(Texture2D texture, Color color, int thickness, int vertical, int horizontal)
		{
		}

		public static void Fill(Texture2D texture, Color color)
		{
		}

		public static void DrawLine(Texture2D texture, Vector2Int point1, Vector2Int point2, Color color, int thickness)
		{
		}
	}
}
