using DG.Tweening;
using Dorfromantik.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dorfromantik
{
	public class RadialMenuSection : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField]
		private Ui_BiomeAffected uiBiomeAffected;

		public string descriptionLocalizationKey;

		[SerializeField]
		private Image background;

		[SerializeField]
		private Image icon;

		[SerializeField]
		private UnityEvent onSubmit;

		private RadialMenu radialMenu;

		public bool isEmpty;

		private Tween scaleTween;

		private void Awake()
		{
			radialMenu = GetComponentInParent<RadialMenu>();
		}

		private void Start()
		{
			background.alphaHitTestMinimumThreshold = 0.1f;
		}

		public void Select(bool shouldSelect)
		{
			Tween tween = scaleTween;
			if (tween != null)
			{
				TweenExtensions.Kill(tween);
			}
			ShortcutExtensions.DOScale(base.transform, shouldSelect ? 1.1f : 1f, 0.1f);
			uiBiomeAffected.ApplyNewColorModifier(shouldSelect ? UiColorModifier.Lighter : UiColorModifier.None);
			if ((bool)icon)
			{
				icon.color = (shouldSelect ? Constants.UI.Colors.SelectedBlack : Color.white);
			}
		}

		public void Submit()
		{
			if (!isEmpty)
			{
				Tween tween = scaleTween;
				if (tween != null)
				{
					TweenExtensions.Kill(tween, complete: true);
				}
				scaleTween = ShortcutExtensions.DOPunchScale(base.transform, Vector3.one * 0.2f, 0.3f, 10, 0.8f);
			}
			onSubmit?.Invoke();
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			radialMenu.SubmitRadialSelection();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			radialMenu.SelectSection(this);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (radialMenu.SelectedRadialSection == this)
			{
				radialMenu.SelectSection(null);
			}
		}
	}
}
