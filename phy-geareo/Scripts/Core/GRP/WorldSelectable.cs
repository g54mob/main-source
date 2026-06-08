using UnityEngine;

namespace GRP
{
	public class WorldSelectable : WorldPointable
	{
		public WorldSelectableConfig config;

		public Renderer hoverRenderer;

		public Transform hoverScale;

		private Material[] originalMaterials;

		private bool isDown;

		private bool isHover;

		private Material lastMat;

		public void SetMat(Material mat)
		{
		}

		private void Update()
		{
		}

		private void UpdateMat()
		{
		}

		private void OnEnable()
		{
		}

		public override void OnHoverEnter(WorldPointerEvent evt)
		{
		}

		public override void OnHoverExit(WorldPointerEvent evt)
		{
		}

		public override void OnDown(WorldPointerEvent evt)
		{
		}

		public override void OnUp(WorldPointerEvent evt)
		{
		}
	}
}
