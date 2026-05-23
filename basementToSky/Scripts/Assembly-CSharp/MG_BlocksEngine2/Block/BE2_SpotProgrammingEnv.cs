using MG_BlocksEngine2.DragDrop;
using UnityEngine;

namespace MG_BlocksEngine2.Block
{
	public class BE2_SpotProgrammingEnv : MonoBehaviour, I_BE2_Spot
	{
		private BE2_DragDropManager _dragDropManager;

		private Transform _transform;

		public string Type => "programmingEnv";

		public Transform Transform
		{
			get
			{
				if (!_transform)
				{
					return base.transform;
				}
				return _transform;
			}
		}

		public Vector2 DropPosition => Vector2.zero;

		public I_BE2_Block Block => null;

		private void Awake()
		{
			_transform = base.transform;
			_dragDropManager = BE2_DragDropManager.Instance;
		}

		public void OnPointerUp()
		{
			_dragDropManager.CurrentDrag?.Transform.SetParent(base.transform);
		}

		private void OnEnable()
		{
			_dragDropManager.AddToSpotsList(this);
		}

		private void OnDisable()
		{
			_dragDropManager.RemoveFromSpotsList(this);
		}
	}
}
