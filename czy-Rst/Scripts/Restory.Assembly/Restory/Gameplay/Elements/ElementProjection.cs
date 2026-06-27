using System;
using EPOOutline;
using Restory.Data.Outline;
using Restory.Gameplay.Common;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Elements
{
	public class ElementProjection : MonoBehaviour
	{
		[Header("Mesh Settings")]
		[SerializeField]
		private MeshFilter meshFilter;

		[SerializeField]
		private MeshRenderer meshRenderer;

		[Space]
		[Header("Collider Settings")]
		[SerializeField]
		private BoxCollider boxCollider;

		[Space]
		[Header("Outlinable Settings")]
		[SerializeField]
		private Outlinable outlinable;

		[SerializeField]
		private OutlinableAdapter outlinableAdapter;

		[SerializeField]
		private OutlineSettingsPreset dimProjectionPreset;

		[SerializeField]
		private OutlineSettingsPreset brightProjectionPreset;

		[SerializeField]
		private OutlineSettingsPreset filledProjectionPreset;

		[SerializeField]
		private OutlineSettingsPreset dirtyProjectionPreset;

		[SerializeField]
		private OutlineSettingsPreset damagedProjectionPreset;

		private ElementProjectionHighlighter projectionHighlighter;

		private bool isSelected;

		public BoxCollider BoxCollider => boxCollider;

		public MeshFilter MeshFilter => meshFilter;

		public OutlinableAdapter OutlinableAdapter => outlinableAdapter;

		public event Action OnActivated;

		[Inject]
		private void Construct(ElementProjectionHighlighter projectionHighlighter)
		{
			this.projectionHighlighter = projectionHighlighter;
		}

		private void Start()
		{
			outlinable.enabled = true;
		}

		public void ToggleCollider(bool detectable)
		{
			boxCollider.enabled = detectable;
		}

		public void Activate()
		{
			this.OnActivated?.Invoke();
		}

		public void MakeDim()
		{
			outlinableAdapter.OverridePreset = dimProjectionPreset;
		}

		public void MakeBright()
		{
			outlinableAdapter.OverridePreset = brightProjectionPreset;
		}

		public void MakeFilled()
		{
			outlinableAdapter.OverridePreset = filledProjectionPreset;
		}

		public void MakeDirty()
		{
			outlinableAdapter.OverridePreset = dirtyProjectionPreset;
		}

		public void MakeDamaged()
		{
			outlinableAdapter.OverridePreset = damagedProjectionPreset;
		}

		public void Highlight()
		{
			projectionHighlighter.HighlightProjection(this);
		}

		public void SetOutlineLayer(int newLayer)
		{
			outlinable.OutlineLayer = newLayer;
		}
	}
}
