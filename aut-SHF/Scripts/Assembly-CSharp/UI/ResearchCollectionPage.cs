using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Audio;
using InputControl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ResearchCollectionPage : BaseCollectionPage
	{
		[Serializable]
		private class ResearchCollectionComponent
		{
			public eResearchCollectionCategory category;

			public RectTransform smallTitle;

			public RectTransform collectionParent;

			public TMP_Text progressText;

			public int progressCountMax;
		}

		[CompilerGenerated]
		private sealed class _003CDelayOneFrameCoroutine_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Action callback;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDelayOneFrameCoroutine_003Ed__23(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public CollectionResearchListElement listElementPrefab;

		public RectTransform detailContent;

		public GameObject textContentsArea;

		public RectTransform treeArea;

		public ResearchCategoryPanelCtrl categoryPanel;

		public CollectionResearchDescriptionCtrl descCtrl;

		public Image detailMasterIcon;

		public TMP_Text detailCollectionCategoryText;

		public GameObject relatedMachineArea;

		public RectTransform relatedMachineItemArea;

		[SerializeField]
		private List<ResearchCollectionComponent> categoryComponents;

		[SerializeField]
		private CursorUIGroup _contentsUIGroup;

		[SerializeField]
		private CursorUIGroup _detailUIGroup;

		[SerializeField]
		private CollectionDialog _dialog;

		[SerializeField]
		private PlaySEElement _sePlayer;

		private CollectionListElement _selectedElement;

		private bool _finishInit;

		private int _selectedNumber;

		public override void Init()
		{
		}

		protected override void InitCollectionCountMax()
		{
		}

		private void MoveDetailGroup()
		{
		}

		public void ReturnMainGroup()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayOneFrameCoroutine_003Ed__23))]
		private IEnumerator DelayOneFrameCoroutine(Action callback = null)
		{
			return null;
		}

		private void UpdateSmallTitleProgressText()
		{
		}

		private void SetProgressTextFormSmallTitle(ResearchCollectionComponent component)
		{
		}

		public override void AddCollection(int enumNumber)
		{
		}

		public override void SelectItem(int enumNumber, bool isSecret = false)
		{
		}

		private void CreateRelatedMachines(MstResearchTreeDataEntities research)
		{
		}

		private bool IsCollectionMachine(eMachine machine)
		{
			return false;
		}

		private void CreateResearchTreeData(MstResearchCategoryEntities categoryData)
		{
		}

		private void CreateResearchTree(ResearchDialog.ResearchTreeCategoryInfo categoryInfo)
		{
		}

		public void OnPointerOverCategory(MstResearchCategoryEntities data)
		{
		}

		public void OnPointerOverItem(MstResearchTreeDataEntities data)
		{
		}

		public void OnPointerExitItem()
		{
		}

		public CollectionListElement CreateResearchListElement(eResearchCategory researchCategory)
		{
			return null;
		}

		public CollectionListElement CreateResearchListElement(MstResearchCategoryEntities researchCategoryData)
		{
			return null;
		}

		public override void SortElements()
		{
		}

		public void UpdateTreeUI()
		{
		}

		protected override int GetSortNum(CollectionListElement item)
		{
			return 0;
		}
	}
}
