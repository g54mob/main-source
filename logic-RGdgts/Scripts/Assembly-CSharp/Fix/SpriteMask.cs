using UnityEngine;

namespace Fix
{
	public class SpriteMask : MonoBehaviour
	{
		public Transform parentMask;

		private int _frontSortingLayerID;

		private int _frontSortingOrder;

		private int _backSortingLayerID;

		private int _backSortingOrder;

		private bool _isCustomRangeActive;

		private SpriteRenderer[] renderers;

		private Material[] materials;

		public int frontSortingLayerID
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int frontSortingOrder
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int backSortingLayerID
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int backSortingOrder
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float alphaCutoff
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Sprite sprite
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool isCustomRangeActive
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public SpriteSortPoint spriteSortPoint
		{
			get
			{
				return default(SpriteSortPoint);
			}
			set
			{
			}
		}

		public new bool enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
