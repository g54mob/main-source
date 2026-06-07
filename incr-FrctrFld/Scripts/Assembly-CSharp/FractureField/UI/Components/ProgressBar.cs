using System;
using System.Collections.Generic;
using Reactivity;
using Reactivity.Unity.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FractureField.UI.Components
{
	public class ProgressBar : RComponent
	{
		public class ProgressBarOptions
		{
			public class TextOptions
			{
				public Func<string> Get;

				public List<IReactiveDependency> Dependencies;
			}

			public RLong StartValue;

			public Func<ProgressBarOptions, long> GetStartValue;

			public RLong CurrentValue;

			public Func<ProgressBarOptions, long> GetCurrentValue;

			public RLong TargetValue;

			public Func<ProgressBarOptions, long> GetTargetValue;

			public RBool ShouldUpdate;

			public TextOptions Text;
		}

		[Header("Variables")]
		public ProgressBarColor Color;

		[SerializeField]
		private bool _isManual;

		[Header("References")]
		[SerializeField]
		private Image _bar;

		[SerializeField]
		private TMP_Text _text;

		private ProgressBarOptions _options;

		private bool _shouldUpdate;

		private float PercentProgress => 0f;

		protected override void Awake()
		{
		}

		public void SetColor(ProgressBarColor color = ProgressBarColor.None)
		{
		}

		public void SetPercent(float percent)
		{
		}

		public void SetText(string text)
		{
		}

		public void Setup(ProgressBarOptions options)
		{
		}

		private void SetShouldUpdate()
		{
		}

		private void TryUpdateProgress()
		{
		}

		protected override void OnEnable()
		{
		}

		private void DoUpdateProgress()
		{
		}

		private void DoUpdateText()
		{
		}

		private string GetText(ProgressBarOptions.TextOptions options, RLong defaultValue)
		{
			return null;
		}
	}
}
