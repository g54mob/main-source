using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pug.UnityExtensions
{
	public class NuclearPendingAnim
	{
		public struct PendingPlay
		{
			public string name;

			public int layer;

			public float offset;

			public void Apply(Animator a)
			{
				a.Play(name, layer, offset);
			}
		}

		private Animator animator;

		private List<PendingPlay> perLayer = new List<PendingPlay>();

		private List<int> lockedLayers = new List<int>();

		public NuclearPendingAnim(Animator animator)
		{
			this.animator = animator;
		}

		public void Lock()
		{
			lockedLayers.AddRange(perLayer.Select((PendingPlay q) => q.layer));
		}

		public void LockLayers(params int[] layers)
		{
			lockedLayers.AddRange(layers);
		}

		public void Play(string name, int layer = -1, float normalizedTime = 0f)
		{
			if (lockedLayers.Contains(layer))
			{
				Debug.LogWarning($"Dropped {name} on layer {layer} because layer locked", animator);
				return;
			}
			perLayer.RemoveAll((PendingPlay q) => q.layer == layer);
			PendingPlay item = new PendingPlay
			{
				name = name,
				layer = layer,
				offset = normalizedTime
			};
			perLayer.Add(item);
		}

		public void Clear()
		{
			perLayer.Clear();
			lockedLayers.Clear();
		}

		public void LateUpdate()
		{
			foreach (PendingPlay item in perLayer)
			{
				item.Apply(animator);
			}
			Clear();
		}
	}
}
