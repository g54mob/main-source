using System;
using Controllers;
using KitchenData;
using Shapes;
using UnityEngine;

namespace Kitchen.Modules
{
	public class CosmeticSelectorElement : MouseElement, IActivateModule
	{
		[Header("Configuration")]
		[SerializeField]
		protected Rectangle BackingBorder;

		[SerializeField]
		protected Rectangle MouseBackingBorder;

		[SerializeField]
		protected Renderer Image;

		[SerializeField]
		protected Renderer Image2;

		[Header("State")]
		private Material ImageMaterial;

		private Material ImageMaterial2;

		private PlayerCosmetic CurrentCosmetic;

		private static readonly int Alpha = Shader.PropertyToID("_Alpha");

		private static readonly int ImageProperty = Shader.PropertyToID("_Image");

		public override Bounds BoundingBox => new Bounds(base.transform.localPosition, new Vector3(BackingBorder.Width, BackingBorder.Height, 0f));

		public event Action OnActivate = delegate
		{
		};

		private void OnEnable()
		{
			ImageMaterial = base.MemoryManagerHandle.Register(Image.material);
			ImageMaterial2 = base.MemoryManagerHandle.Register(Image2.material);
		}

		public void SetCosmetic(PlayerCosmetic cosmetic)
		{
			CurrentCosmetic = cosmetic;
			StartCoroutine(Request.Snapshot(cosmetic.ID, delegate
			{
				Texture2D cosmeticSnapshot = PrefabSnapshot.GetCosmeticSnapshot(cosmetic);
				ImageMaterial.SetTexture(ImageProperty, cosmeticSnapshot);
				ImageMaterial2.SetTexture(ImageProperty, cosmeticSnapshot);
			}));
		}

		public override void SetSelectable(bool selectable, bool keep_full_alpha = false)
		{
			base.SetSelectable(selectable, keep_full_alpha);
			ImageMaterial.SetFloat(Alpha, (keep_full_alpha || IsSelectable) ? 1f : 0.2f);
		}

		public override bool HandleInteraction(InputState state)
		{
			if (state.MenuSelect == ButtonState.Pressed)
			{
				this.OnActivate();
				return true;
			}
			return false;
		}

		public virtual CosmeticSelectorElement SetSize(float width, float height)
		{
			BackingBorder.Width = width;
			BackingBorder.Height = height;
			MouseBackingBorder.Width = width;
			MouseBackingBorder.Height = height;
			Image.GetComponent<Transform>().localScale = new Vector3(width, height - 0.05f, 1f);
			return this;
		}

		public override void OnMouseUIUp(Vector3 position)
		{
			if (IsSelectable && base.gameObject.activeInHierarchy)
			{
				base.OnMouseUIUp(position);
				this.OnActivate();
			}
		}
	}
}
