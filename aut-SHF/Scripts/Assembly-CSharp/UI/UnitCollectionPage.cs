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
	public class UnitCollectionPage : BaseCollectionPage
	{
		[Serializable]
		private struct RankSprite
		{
			public eUnitRank rank;

			public Sprite sprite;
		}

		[Serializable]
		public struct SourceLuggagePattern
		{
			public int sourceCount;

			public List<Vector3> positions;

			public Sprite allowImage;
		}

		[Serializable]
		private class MasterCollectionComponent
		{
			public eWriterId id;

			public UnitCollectionTabCtrl tabCtrl;

			public Sprite tabOnImage;

			public Sprite tabOffImage;

			public GameObject collection;

			public CollectionAreaComponent heroCollectionArea;

			public CollectionAreaComponent spellCollectionArea;

			public CollectionAreaComponent partsCollectionArea;

			public CollectionAreaComponent sweetsCollectionArea;

			public CollectionAreaComponent resourceCollectionArea;

			public List<eLuggage> useLuggageList;
		}

		[Serializable]
		private class CollectionAreaComponent
		{
			public bool alwaysVisible;

			public RectTransform smallTitle;

			public RectTransform collectionParent;

			public List<eLuggage> luggages;

			public TMP_Text progressText;

			public int progressCountMax;

			public TMP_Text progressTextAnother;

			public int progressCountMaxAnother;
		}

		[CompilerGenerated]
		private sealed class _003CDelayOneFrameCoroutine_003Ed__62 : IEnumerator<object>, IEnumerator, IDisposable
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
			public _003CDelayOneFrameCoroutine_003Ed__62(int _003C_003E1__state)
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

		public CollectionListElement listElementPrefab;

		public CollectionHeroListElement unitListElementPrefab;

		public RectTransform listContent;

		public RectTransform unitDetailArea;

		public GameObject unitDescArea;

		public GameObject unitBlendArea;

		public GameObject textContentsArea;

		public Image unitMainImage;

		public Image unitOnlyImage;

		public Image needMachineImage;

		public InfoHeroStatus infoStatus;

		public InfoProduct infoProduct;

		public InfoReleaseConditions infoReleaseConditions;

		public InfoMotifSource infoMotifSource;

		public TMP_Text unitDesc;

		public TMP_Text unitFlavorText;

		public CollectionDetailUnit detailUnitPrefab;

		public Transform sourceLugaggeParent;

		public Transform derivationLuggageParent;

		public List<SourceLuggagePattern> sourceImagePositions;

		public Image sourceArrowImage;

		public Image rankIcon;

		public GameObject abilityArea;

		public List<TMP_Text> abilityTexts;

		[SerializeField]
		private List<RankSprite> _rankSprites;

		[SerializeField]
		private List<MasterCollectionComponent> _masterComponents;

		[SerializeField]
		private CursorUIGroup _contentsUIGroup;

		[SerializeField]
		private CursorUIGroup _detailUIGroup;

		[SerializeField]
		private CollectionDialog _dialog;

		[SerializeField]
		private PlaySEElement _sePlayer;

		private List<CollectionListElement> _luggageCollectionList;

		private const string listTextureAddress = "Assets/Textures/Factory/Luggage/";

		private const string artifactCategoryAddress = "Assets/Textures/Icon/ArtifactCategory/icon_";

		private CollectionListElement _selectedElement;

		private bool _finishInit;

		private int _selectedNumber;

		private bool _finishInitUseLuggages;

		private eWriterId _selectedWriter;

		private List<eLuggage> ignoreLuggages;

		protected override void InitCollectionCountMax()
		{
		}

		private (int, int) GetUnitCountMax(eLuggage luggage)
		{
			return default((int, int));
		}

		public override int GetCollectionCount()
		{
			return 0;
		}

		private int GetLuggagesCollectionCount(CollectionAreaComponent colloctionAreaComponent)
		{
			return 0;
		}

		private (int, int) GetLuggagesCollectionCountAnother(CollectionAreaComponent colloctionAreaComponent)
		{
			return default((int, int));
		}

		private int GetUnitCount(eLuggage luggage)
		{
			return 0;
		}

		private void UpdateSmallTitleProgressText()
		{
		}

		private void SetProgressTextForSmallTitle(CollectionAreaComponent component)
		{
		}

		private void SetProgressTextForSmallTitleAnother(CollectionAreaComponent component)
		{
		}

		private void InitUseLuggages()
		{
		}

		public override void Init()
		{
		}

		public void SwitchTabs(eWriterId id)
		{
		}

		public override void AddCollection(int enumNumber)
		{
		}

		public override void SelectItem(int enumNumber, bool isSecret = false)
		{
		}

		private void SetLuggageAbility(eLuggage luggage)
		{
		}

		public void CreateLuggageListElement(eLuggage luggage)
		{
		}

		private void CreateItem(eLuggage luggage, eLuggageKind kind, eWriterId writerId, CollectionAreaComponent component)
		{
		}

		private void MoveDetailGroup()
		{
		}

		public void ReturnMainGroup()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayOneFrameCoroutine_003Ed__62))]
		private IEnumerator DelayOneFrameCoroutine(Action callback = null)
		{
			return null;
		}

		private void SwitchVisibleCollectionArea(CollectionAreaComponent component)
		{
		}

		public override void SortElements()
		{
		}

		protected override int GetSortNum(CollectionListElement item)
		{
			return 0;
		}

		public void SetNeedMachine(eLuggage luggage)
		{
		}

		public void SetSourceLuggage(eLuggage luggage)
		{
		}

		private List<eLuggage> GetSourceLuggage(eLuggage luggage)
		{
			return null;
		}

		private eWriterId GetUseWriter(eLuggage luggage)
		{
			return default(eWriterId);
		}

		public void SetDerivationLuggage(eLuggage luggage)
		{
		}

		public CollectionDetailUnit CreateDetailUnit(eLuggage luggage, Transform parent, eLuggage target = eLuggage.None)
		{
			return null;
		}

		public void NextUnitTab()
		{
		}

		public void PrevUnitTab()
		{
		}
	}
}
