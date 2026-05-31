using UnityEngine;
using UnityEngine.UI;

namespace PolyAndCode.UI
{
	public class RecyclableScrollRect : ScrollRect
	{
		public enum DirectionType
		{
			Vertical = 0,
			Horizontal = 1
		}

		[HideInInspector]
		public IRecyclableScrollRectDataSource DataSource;

		public bool IsGrid;

		public RectTransform PrototypeCell;

		public bool SelfInitialize;

		public DirectionType Direction;

		[SerializeField]
		private int _segments;

		private RecyclingSystem _recyclingSystem;

		private Vector2 _prevAnchoredPos;

		public int Segments
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected override void Start()
		{
		}

		private void Initialize()
		{
		}

		public void Initialize(IRecyclableScrollRectDataSource dataSource)
		{
		}

		public void OnValueChangedListener(Vector2 normalizedPos)
		{
		}

		public void ReloadData()
		{
		}

		public void ReloadData(IRecyclableScrollRectDataSource dataSource)
		{
		}
	}
}
