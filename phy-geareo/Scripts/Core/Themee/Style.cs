using UnityEngine;

namespace Themee
{
	public abstract class Style : MonoBehaviour
	{
		public StyleField _style;

		public StyleField[] overwrites;

		private Theme theme;

		private bool hasSetup;

		protected BakedStyle style { get; private set; }

		private void Awake()
		{
		}

		public void _Build()
		{
		}

		protected virtual void OnValidate()
		{
		}

		protected virtual void Setup()
		{
		}

		protected virtual void Build()
		{
		}
	}
}
