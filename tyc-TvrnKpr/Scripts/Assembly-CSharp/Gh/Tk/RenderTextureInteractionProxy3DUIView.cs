using System;
using UnityEngine;

namespace Gh.Tk
{
	public class RenderTextureInteractionProxy3DUIView : Button3DUIView
	{
		public Camera proxyCamera;

		public LayerMask interactableLayers;

		[SerializeField]
		private BoxCollider _boxCollider;

		[SerializeField]
		private MeshCollider _meshCollider;

		private BaseInteractable3DUIView _lastHovered;

		public override void OnClicked()
		{
		}

		protected override void OnHoveredChanged()
		{
		}

		public override void OnHovering()
		{
		}

		private void UpdateProxyHover(BaseInteractable3DUIView interactable)
		{
		}

		private new void OnDisable()
		{
		}

		protected override void OnEnable()
		{
		}

		private void ProxyInteraction(Action<GameObject> proxyHitAction)
		{
		}
	}
}
