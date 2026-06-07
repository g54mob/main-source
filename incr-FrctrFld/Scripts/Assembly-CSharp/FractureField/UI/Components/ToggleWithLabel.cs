using Reactivity;
using Reactivity.Unity.Components;
using UnityEngine;
using UnityEngine.UI;

namespace FractureField.UI.Components
{
	public class ToggleWithLabel : RComponent
	{
		public class Options
		{
			public string OnLabel;

			public string OffLabel;

			public RBool Dependency;
		}

		[Header("References")]
		[SerializeField]
		private Toggle _toggle;

		[SerializeField]
		private RImage _background;

		[SerializeField]
		private RText _label;

		private Options _options;

		public void Setup(Options options)
		{
		}

		private void OnDependencyChanged()
		{
		}

		public void ToggleChanged(bool _)
		{
		}
	}
}
