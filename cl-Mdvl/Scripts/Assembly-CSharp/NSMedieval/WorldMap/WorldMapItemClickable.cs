using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.WorldMap
{
	public class WorldMapItemClickable : MonoBehaviour
	{
		private Vector2Int gridPosition;

		public Vector2Int GridPosition => gridPosition;

		public void SetGridPosition(Vector2Int gridPosition)
		{
			this.gridPosition = gridPosition;
			SetPosition(new Vector3(gridPosition.x, MonoSingleton<WorldMap>.Instance.GetHeightAt(gridPosition), gridPosition.y));
		}

		private void SetPosition(Vector3 position)
		{
			base.transform.localPosition = position;
		}

		public virtual void OnPointerEnter()
		{
		}

		public virtual void OnPointerLeave()
		{
		}

		public virtual void OnClick()
		{
		}
	}
}
