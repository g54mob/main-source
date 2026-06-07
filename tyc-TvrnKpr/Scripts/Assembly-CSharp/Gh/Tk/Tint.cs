using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public abstract class Tint : MonoBehaviour
	{
		private MaterialPropertyBlock _propertyBlock;

		private List<Renderer> _renderers;

		protected bool IsTintEnabled;

		protected GameObjectX TargetObject;

		private static readonly int Tint1;

		public void OnEnable()
		{
		}

		public virtual void EnableTint(bool enable)
		{
		}

		protected abstract Color GetColor();

		protected virtual void UpdateTint()
		{
		}

		public void UpdateRenderers()
		{
		}

		protected virtual IEnumerable<Renderer> GetTintableRenderers()
		{
			return null;
		}

		protected IEnumerable<Renderer> GetValidRenderers(GameObject go)
		{
			return null;
		}
	}
}
