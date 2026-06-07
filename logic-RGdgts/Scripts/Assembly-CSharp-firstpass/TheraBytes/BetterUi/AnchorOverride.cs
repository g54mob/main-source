using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TheraBytes.BetterUi
{
	[ExecuteAlways]
	public class AnchorOverride : UIBehaviour, IResolutionDependency
	{
		[Serializable]
		public class AnchorReference
		{
			public enum ReferenceLocation
			{
				Disabled = 0,
				Center = 1,
				Pivot = 2,
				LowerLeft = 3,
				UpperRight = 4
			}

			[SerializeField]
			private RectTransform reference;

			[SerializeField]
			private ReferenceLocation minX;

			[SerializeField]
			private ReferenceLocation maxX;

			[SerializeField]
			private ReferenceLocation minY;

			[SerializeField]
			private ReferenceLocation maxY;

			public RectTransform Reference
			{
				get
				{
					return null;
				}
				internal set
				{
				}
			}

			public ReferenceLocation MinX => default(ReferenceLocation);

			public ReferenceLocation MaxX => default(ReferenceLocation);

			public ReferenceLocation MinY => default(ReferenceLocation);

			public ReferenceLocation MaxY => default(ReferenceLocation);
		}

		[Serializable]
		public class AnchorReferenceCollection : IScreenConfigConnection
		{
			[SerializeField]
			private List<AnchorReference> elements;

			[SerializeField]
			private string screenConfigName;

			public List<AnchorReference> Elements => null;

			public string ScreenConfigName
			{
				get
				{
					return null;
				}
				set
				{
				}
			}
		}

		[Serializable]
		public class AnchorReferenceCollectionConfigCollection : SizeConfigCollection<AnchorReferenceCollection>
		{
		}

		[SerializeField]
		private AnchorReferenceCollection anchorsFallback;

		[SerializeField]
		private AnchorReferenceCollectionConfigCollection anchorsConfigs;

		private AnchorReferenceCollection currentAnchors;

		private Canvas canvas;

		private DrivenRectTransformTracker rectTransformTracker;

		private RectTransform RectTransform => null;

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		public void OnResolutionChanged()
		{
		}

		private void Update()
		{
		}

		private static Vector2 GetAnchorPosition(AnchorReference a, Rect rect, AnchorReference.ReferenceLocation location)
		{
			return default(Vector2);
		}

		private bool TryGetAnchor(AnchorReference anchorRef, out Rect anchorObject)
		{
			anchorObject = default(Rect);
			return false;
		}

		private bool IsParentOf(Transform transform)
		{
			return false;
		}
	}
}
