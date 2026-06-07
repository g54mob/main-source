using System.Collections.Generic;
using Pixeye.Unity;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class ObjectProgressBar3DUIView : BaseProgressBar3DUIView
	{
		[SerializeField]
		private Renderer _backgroundRenderer;

		[SerializeField]
		private Transform _valueScaler;

		private SpriteRenderer _valueSpriteRenderer;

		[SerializeField]
		private Transform _bonusScaler;

		private SpriteRenderer _bonusSpriteRenderer;

		[SerializeField]
		private float _bonusOffsetValue;

		[SerializeField]
		private GameObject _malusGameObject;

		private SpriteRenderer _malusSpriteRenderer;

		[SerializeField]
		private Transform _malusHiderScaler;

		private Renderer _malusHiderRenderer;

		[SerializeField]
		private Transform _indicatorVisual;

		[SerializeField]
		private float _barLength;

		[SerializeField]
		private GameObject verticalIndicatorPrefab;

		[Foldout("Colours", true)]
		public bool useColourGradient;

		public Gradient colourGradient;

		public Color blue;

		public Color yellow;

		public Color green;

		public Color red;

		public Color purple;

		public Color orange;

		public Color aqua;

		[Foldout("Colours", false)]
		[SerializeField]
		private Color _defaultColor;

		private bool _initialColourSet;

		public Color DefaultColor => default(Color);

		public List<Button3DUIView> NamedIndicators { get; private set; }

		private void Awake()
		{
		}

		private void AssignRendereReferences()
		{
		}

		public void SetColour(string colour)
		{
		}

		public void SetColour(Color colour)
		{
		}

		private Color GetBonusColor(Color colour)
		{
			return default(Color);
		}

		private void UpdateValueBar()
		{
		}

		private void UpdateBonusBar()
		{
		}

		private void UpdateMalusBar()
		{
		}

		private void UpdateIndicator()
		{
		}

		public void UpdateNamedIndicators((int position, string codex)[] indicators)
		{
		}

		private void SetIndicatorPosition(Transform indicator, float percentage)
		{
		}

		protected override void Refresh()
		{
		}
	}
}
