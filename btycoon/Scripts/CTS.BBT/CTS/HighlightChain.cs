using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	public class HighlightChain
	{
		private struct Highlight
		{
			public Func<bool> IsActive;

			public GameObject Target;
		}

		private readonly List<Highlight> _chain = new List<Highlight>();

		public HighlightChain(GameObject target)
		{
			_chain.Add(new Highlight
			{
				IsActive = () => true,
				Target = target
			});
		}

		public HighlightChain Add(GameObject target, Func<bool> isActive)
		{
			_chain.Add(new Highlight
			{
				Target = target,
				IsActive = isActive
			});
			return this;
		}

		public GameObject GetTarget()
		{
			for (int num = _chain.Count - 1; num >= 0; num--)
			{
				if (_chain[num].IsActive())
				{
					return _chain[num].Target;
				}
			}
			return _chain[0].Target;
		}
	}
}
