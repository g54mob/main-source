using System;
using System.Collections.Generic;
using Controllers;
using KitchenData;
using Shapes;
using UnityEngine;

namespace Kitchen.Modules
{
	public class GridMenuElement : MouseElement, IActivateModule
	{
		[SerializeField]
		[Header("Configuration")]
		protected Rectangle BackingBorder;

		[SerializeField]
		protected Rectangle MouseBackingBorder;

		[SerializeField]
		protected List<Renderer> CosmeticRenderers;

		[SerializeField]
		protected List<Renderer> IconRenderers;

		[SerializeField]
		protected GameObject BackButton;

		[SerializeField]
		protected GameObject NextButton;

		[Header("State")]
		private Material CosmeticMaterial;

		private Material IconMaterial;

		private static readonly int Alpha = Shader.PropertyToID("_Alpha");

		private static readonly int ImageProperty = Shader.PropertyToID("_Image");

		public override Bounds BoundingBox => new Bounds(base.transform.localPosition, new Vector3(BackingBorder.Width, BackingBorder.Height, 0f));

		public event Action OnActivate = delegate
		{
		};

		private void OnEnable()
		{
			if (CosmeticRenderers == null)
			{
				CosmeticRenderers = new List<Renderer>();
			}
			if (CosmeticRenderers.Count > 0)
			{
				CosmeticMaterial = base.MemoryManagerHandle.Register(CosmeticRenderers[0].material);
				foreach (Renderer cosmeticRenderer in CosmeticRenderers)
				{
					cosmeticRenderer.sharedMaterial = CosmeticMaterial;
				}
			}
			if (IconRenderers == null)
			{
				IconRenderers = new List<Renderer>();
			}
			if (IconRenderers.Count <= 0)
			{
				return;
			}
			IconMaterial = base.MemoryManagerHandle.Register(IconRenderers[0].material);
			foreach (Renderer iconRenderer in IconRenderers)
			{
				iconRenderer.sharedMaterial = IconMaterial;
			}
		}

		public void Set(Texture2D texture)
		{
			BackButton.SetActive(value: false);
			NextButton.SetActive(value: false);
			foreach (Renderer cosmeticRenderer in CosmeticRenderers)
			{
				cosmeticRenderer.enabled = false;
			}
			foreach (Renderer iconRenderer in IconRenderers)
			{
				iconRenderer.enabled = true;
			}
			IconMaterial.SetTexture(ImageProperty, texture);
		}

		public void Set(PlayerCosmetic cosmetic)
		{
			BackButton.SetActive(value: false);
			NextButton.SetActive(value: false);
			foreach (Renderer cosmeticRenderer in CosmeticRenderers)
			{
				cosmeticRenderer.enabled = true;
			}
			foreach (Renderer iconRenderer in IconRenderers)
			{
				iconRenderer.enabled = false;
			}
			StartCoroutine(Request.Snapshot(cosmetic.ID, delegate
			{
				Texture2D cosmeticSnapshot = PrefabSnapshot.GetCosmeticSnapshot(cosmetic);
				CosmeticMaterial.SetTexture(ImageProperty, cosmeticSnapshot);
			}));
		}

		public void Set(IGridItem item)
		{
			BackButton.SetActive(value: false);
			NextButton.SetActive(value: false);
			foreach (Renderer cosmeticRenderer in CosmeticRenderers)
			{
				cosmeticRenderer.enabled = true;
			}
			foreach (Renderer iconRenderer in IconRenderers)
			{
				iconRenderer.enabled = false;
			}
			if (item.SnapshotKey == 0)
			{
				CosmeticMaterial.SetTexture(ImageProperty, item.GetSnapshot());
				return;
			}
			StartCoroutine(Request.Snapshot(item.SnapshotKey, delegate
			{
				Texture2D snapshot = item.GetSnapshot();
				CosmeticMaterial.SetTexture(ImageProperty, snapshot);
			}));
		}

		public virtual void SetAsBack()
		{
			BackButton.SetActive(value: true);
			NextButton.SetActive(value: false);
			foreach (Renderer cosmeticRenderer in CosmeticRenderers)
			{
				cosmeticRenderer.enabled = false;
			}
			foreach (Renderer iconRenderer in IconRenderers)
			{
				iconRenderer.enabled = false;
			}
		}

		public virtual void SetAsNext()
		{
			NextButton.SetActive(value: true);
			BackButton.SetActive(value: false);
			foreach (Renderer cosmeticRenderer in CosmeticRenderers)
			{
				cosmeticRenderer.enabled = false;
			}
			foreach (Renderer iconRenderer in IconRenderers)
			{
				iconRenderer.enabled = false;
			}
		}

		public override void SetSelectable(bool selectable, bool keep_full_alpha = false)
		{
			base.SetSelectable(selectable, keep_full_alpha);
			CosmeticMaterial.SetFloat(Alpha, (keep_full_alpha || IsSelectable) ? 1f : 0.2f);
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
