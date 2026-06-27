using System;
using System.Collections.Generic;
using DG.Tweening;
using Helpers.Extensions;
using Restory.Data.ToDoList;
using Restory.ObjectPools;
using Restory.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Restory.UI.Views.ToDoList
{
	public sealed class GUI_ToDoListView : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ICleanableComponent
	{
		public class Factory : PlaceholderFactory<GUI_ToDoListView>
		{
		}

		[SerializeField]
		private TextMeshProUGUI titleCountText;

		[SerializeField]
		private RectTransform rootContainer;

		[SerializeField]
		private RectTransform itemsContainer;

		[SerializeField]
		private float showAnchorPosY;

		[SerializeField]
		[Min(0f)]
		private float hideAnchorPosY = 220f;

		[SerializeField]
		private float fullHideAnchorPosY;

		[SerializeField]
		[Min(0f)]
		private float showHideDuration = 1f;

		[SerializeField]
		private Ease showHideEase = Ease.OutCubic;

		private readonly Dictionary<ToDoItem, GUI_ToDoItemView> itemViews = new Dictionary<ToDoItem, GUI_ToDoItemView>();

		private Sequence currentSequence;

		private GUI_ToDoItemViewPool itemViewPool;

		private TweenSequencesService tweenSequences;

		public float ShowHideDuration => showHideDuration;

		public event Action OnShowAnimationStarted;

		public event Action OnHideAnimationStarted;

		public event Action<GUI_ToDoListView> OnEnter;

		public event Action<GUI_ToDoListView> OnExit;

		[Inject]
		private void Construct(GUI_ToDoItemViewPool itemViewPool, TweenSequencesService tweenSequences)
		{
			this.itemViewPool = itemViewPool;
			this.tweenSequences = tweenSequences;
		}

		public void Show()
		{
			if (currentSequence != null)
			{
				tweenSequences.Kill(currentSequence);
				currentSequence = null;
			}
			currentSequence = tweenSequences.Create();
			currentSequence.SetUpdate(isIndependentUpdate: true);
			currentSequence.AppendCallback(delegate
			{
				rootContainer.SetPivotSamePosition(new Vector2(rootContainer.pivot.x, 0f));
				this.OnShowAnimationStarted?.Invoke();
			});
			currentSequence.Append(rootContainer.DOAnchorPos(new Vector2(rootContainer.anchoredPosition.x, showAnchorPosY), showHideDuration).SetEase(showHideEase));
		}

		public void Hide(bool full)
		{
			if (currentSequence != null)
			{
				tweenSequences.Kill(currentSequence);
				currentSequence = null;
			}
			currentSequence = tweenSequences.Create();
			currentSequence.SetUpdate(isIndependentUpdate: true);
			currentSequence.AppendCallback(delegate
			{
				rootContainer.SetPivotSamePosition(new Vector2(rootContainer.pivot.x, 1f));
				this.OnHideAnimationStarted?.Invoke();
			});
			currentSequence.Append(rootContainer.DOAnchorPos(full ? new Vector2(rootContainer.anchoredPosition.x, fullHideAnchorPosY) : new Vector2(rootContainer.anchoredPosition.x, hideAnchorPosY), showHideDuration).SetEase(showHideEase));
		}

		public void SetTitleInfo(int count, int completedCount)
		{
			titleCountText.text = $"{completedCount}/{count}";
		}

		public void AddItem(ToDoItem item, bool instantly)
		{
			if (!itemViews.ContainsKey(item))
			{
				GUI_ToDoItemView gUI_ToDoItemView = itemViewPool.Get<GUI_ToDoItemView>(itemsContainer);
				itemViews[item] = gUI_ToDoItemView;
				gUI_ToDoItemView.SetData(item);
				if (!instantly)
				{
					gUI_ToDoItemView.StartAddAnimation();
				}
			}
		}

		public void RemoveItem(ToDoItem item)
		{
			if (itemViews.Remove(item, out var value))
			{
				itemViewPool.Release(value);
			}
		}

		public void CompleteItem(ToDoItem item)
		{
			if (itemViews.TryGetValue(item, out var value))
			{
				value.StartOrEnqueueCompleteAnimation(delegate(GUI_ToDoItemView itemView)
				{
					RemoveItem(itemView.Item);
				});
			}
		}

		public void ClearItems()
		{
			foreach (GUI_ToDoItemView value in itemViews.Values)
			{
				itemViewPool.Release(value);
			}
			itemViews.Clear();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			this.OnEnter?.Invoke(this);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			this.OnExit?.Invoke(this);
		}

		public void Clean()
		{
			SetTitleInfo(0, 0);
			ClearItems();
		}
	}
}
