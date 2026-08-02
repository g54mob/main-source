using UnityEngine;

namespace GRP
{
	public class WorldPointableCollider : MonoBehaviour
	{
		public bool invisible;

		public int order;

		private WorldPointable[] pointables;

		public WorldPointable pointable { get; private set; }

		private void Awake()
		{
		}

		public void Fetch()
		{
		}

		public void OnDown(WorldPointerEvent evt)
		{
		}

		public void OnUp(WorldPointerEvent evt)
		{
		}

		public void OnDrag(WorldPointerEvent evt)
		{
		}

		public void OnClick(WorldPointerEvent evt)
		{
		}

		public void OnHoverEnter(WorldPointerEvent evt)
		{
		}

		public void OnHoverExit(WorldPointerEvent evt)
		{
		}

		public void OnHover(WorldPointerEvent evt)
		{
		}
	}
}
