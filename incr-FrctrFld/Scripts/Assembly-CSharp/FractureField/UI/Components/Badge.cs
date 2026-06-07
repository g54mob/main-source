using Reactivity;
using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.UI.Components
{
	public class Badge : RComponent
	{
		public class BadgeOptions
		{
			public Computed<BadgeColor> GetColor;

			public BadgeColor Color;

			public CString GetValue;

			public CBool GetExclamation;
		}

		[Header("References")]
		[SerializeField]
		private RImage _container;

		[SerializeField]
		private RText _text;

		private bool _initialized;

		private Ref<BadgeOptions> Options { get; }

		protected override void Awake()
		{
		}

		public void Setup(BadgeOptions options)
		{
		}
	}
}
