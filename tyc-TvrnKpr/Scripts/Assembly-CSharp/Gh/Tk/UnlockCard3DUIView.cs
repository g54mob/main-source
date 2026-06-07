using System.Collections.Generic;
using DG.Tweening;
using Gh.Tk.UI;
using I18n;
using UnityEngine;

namespace Gh.Tk
{
	public class UnlockCard3DUIView : BaseInteractable3DUIView
	{
		[SerializeField]
		private Transform _placardTransform;

		[SerializeField]
		private TextMeshProI18n _titleText;

		[SerializeField]
		private Transform _placardWithAuthorTransform;

		[SerializeField]
		private TextMeshProI18n _titleWithAuthorText;

		[SerializeField]
		private TextBlock3DUIView _authorText;

		[SerializeField]
		private Transform _iconContainer;

		[SerializeField]
		public bool isCollectButton;

		private BuildableTemplate _template;

		[SerializeField]
		private GameObject _freeBuildObj;

		[SerializeField]
		private List<GameObject> _designVisuals;

		[SerializeField]
		private List<GameObject> _defaultVisuals;

		[SerializeField]
		private Button3DUIView _templateIcon;

		[SerializeField]
		private Container3DUIView _namedCategoryParent;

		[SerializeField]
		private Container3DUIView _iconOnlyCategoryParent;

		[SerializeField]
		private List<GameObject> _categoryIcons;

		[SerializeField]
		private List<GameObject> _categoryLabeledIcons;

		[SerializeField]
		private Button3DUIView _moreCategoriesButton;

		private int _maxCategoryIcons;

		private int _maxCategoryLabeledIcons;

		[Header("Tween Settings")]
		public Vector2 zStartRotationRandomRange;

		public float startScale;

		[SerializeField]
		private Transform _offsetTransform;

		private Tween _cardRevealTween;

		private bool _isCardRevealed;

		[SerializeField]
		private GameObject[] _highlightObjs;

		private Tween _highlightTween;

		[SerializeField]
		private Transform _pedestalTransform;

		private float highlightRotationAmount;

		private float highlightRotationDuration;

		private Ease highlightRotationEase;

		[SerializeField]
		private Transform _placardRootTransform;

		private Tween _placardTween;

		private float _placardScaleDuration;

		private float _placardScaleSustainDuration;

		private Ease _placardScaleInEase;

		private Ease _placardScaleOutEase;

		private Tween _offsetTween;

		private Vector3 _offsetTarget;

		[SerializeField]
		private GameObject _clickedFanfare;

		[SerializeField]
		private BaseInteractable3DUIView _inspectionInteractable;

		public CollectibleCardData CardData { get; private set; }

		public bool IsPlayerInspecting => false;

		public void Clear()
		{
		}

		public void SetData(BuildableTemplate template, string titleKey, string author)
		{
		}

		private GameObject CreateUIModelForBuildable(BuildableTemplate template)
		{
			return null;
		}

		public void SetData(CollectibleCardData cardData, GameObject obj, string titleKey, string author)
		{
		}

		public void SetData(string titleKey, string author)
		{
		}

		private void SetFreeUnlock(bool isFree)
		{
		}

		private void SetDesignUnlock(bool isDesign)
		{
		}

		private void SetTemplateIcon(bool isTemplate)
		{
		}

		private void SetCategories(IEnumerable<string> categories)
		{
		}

		private void UpdateContainers()
		{
		}

		protected override void OnEnable()
		{
		}

		public void SetStartPosition(Vector3 cardStartPosition)
		{
		}

		public void SetOffset(Vector3 offset)
		{
		}

		public void SetRotationOffset(Vector3 rotationOffset)
		{
		}

		private void RevealCard()
		{
		}

		public void SetHighlight(bool isHighlighted)
		{
		}

		private void PlayCardSound()
		{
		}

		private void PlayHighlightAnim()
		{
		}

		private void UndoHighlightAnim()
		{
		}

		protected override void OnDisable()
		{
		}

		public void TweenOffsetTo(Vector3 offsetTarget, float duration)
		{
		}

		public void ShowClickedFanfare()
		{
		}
	}
}
