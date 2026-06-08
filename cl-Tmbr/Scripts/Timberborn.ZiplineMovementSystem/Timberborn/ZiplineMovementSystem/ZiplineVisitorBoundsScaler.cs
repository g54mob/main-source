using System;
using System.Collections.Immutable;
using Timberborn.BaseComponentSystem;
using UnityEngine;

namespace Timberborn.ZiplineMovementSystem
{
	internal class ZiplineVisitorBoundsScaler : BaseComponent, IAwakableComponent
	{
		private static readonly float Scale = 4f;

		private ImmutableArray<MeshRenderer> _meshRenderers;

		public void Awake()
		{
			_meshRenderers = base.GameObject.GetComponentsInChildren<MeshRenderer>(includeInactive: true).ToImmutableArray();
			ZiplineVisitor component = GetComponent<ZiplineVisitor>();
			component.EnteredZipline += OnEnteredZipline;
			component.ExitedZipline += OnExitedZipline;
		}

		private void OnEnteredZipline(object sender, EventArgs e)
		{
			ImmutableArray<MeshRenderer>.Enumerator enumerator = _meshRenderers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				MeshRenderer current = enumerator.Current;
				Bounds localBounds = current.localBounds;
				localBounds.size *= Scale;
				current.localBounds = localBounds;
			}
		}

		private void OnExitedZipline(object sender, EventArgs e)
		{
			ImmutableArray<MeshRenderer>.Enumerator enumerator = _meshRenderers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.ResetLocalBounds();
			}
		}
	}
}
