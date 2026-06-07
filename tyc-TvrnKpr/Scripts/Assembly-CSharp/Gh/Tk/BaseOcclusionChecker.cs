using UnityEngine;

namespace Gh.Tk
{
	public abstract class BaseOcclusionChecker : MonoBehaviour
	{
		private bool _oppressed;

		private bool Oppressed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected abstract void DisableOcclusions();

		public virtual void Start()
		{
		}

		private void Update()
		{
		}

		protected abstract void UpdateInternal();
	}
}
