using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Gh.Tk.UI;
using I18n;
using UnityEngine;

namespace Gh.Tk
{
	public class PropBuildButton3DUIView : BuyButton3DUIView, IContextMenuProvider
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass67_0
		{
			public PropBuildButton3DUIView _003C_003E4__this;

			public BuildableTemplate template;

			internal void _003CGetContextMenuItems_003Eb__0()
			{
			}

			internal void _003CGetContextMenuItems_003Eb__1()
			{
			}

			internal void _003CGetContextMenuItems_003Eb__2()
			{
			}

			internal void _003CGetContextMenuItems_003Eb__3()
			{
			}

			internal void _003CGetContextMenuItems_003Eb__4()
			{
			}

			internal void _003CGetContextMenuItems_003Eb__5()
			{
			}

			internal void _003CGetContextMenuItems_003Eb__6()
			{
			}

			internal void _003CGetContextMenuItems_003Eb__10()
			{
			}

			internal void _003CGetContextMenuItems_003Eb__15()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetContextMenuItems_003Ed__67 : IEnumerable<ContextMenuItem>, IEnumerable, IEnumerator<ContextMenuItem>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private ContextMenuItem _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public PropBuildButton3DUIView _003C_003E4__this;

			private _003C_003Ec__DisplayClass67_0 _003C_003E8__1;

			private ContextMenuItem _003CreportButton_003E5__2;

			ContextMenuItem IEnumerator<ContextMenuItem>.Current
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
			public _003CGetContextMenuItems_003Ed__67(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<ContextMenuItem> IEnumerable<ContextMenuItem>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public TextMeshProI18n nameText;

		public GameObject modelSocket;

		public Stars3DUIView starsView;

		public GameObject plusIcon;

		public TextMeshProI18n costText;

		public TextMeshProI18n restrictedText;

		public TextMeshProI18n cannotAffordText;

		public TextMeshProI18n duplicateText;

		[SerializeField]
		private Button3DUIView _showVariantsButton;

		private bool _isVariant;

		[SerializeField]
		private BaseInteractable3DUIView _showContextMenuButton;

		[SerializeField]
		private Button3DUIView _showStylesButton;

		[SerializeField]
		private Button3DUIView _showTemplateIcon;

		[SerializeField]
		private BaseInteractable3DUIView _importErrorIcon;

		private TooltipData _costTooltip;

		[SerializeField]
		private BaseInteractable3DUIView _costTooltipTarget;

		private static readonly Dictionary<string, GameObject> _propVisualDict;

		private static readonly Dictionary<string, GameObject> _variantCopyVisualDict;

		private readonly Dictionary<string, GameObject> _privateModelCache;

		private GameObject _currentSocketObject;

		[SerializeField]
		private Transform _alignmentSocket;

		private static bool _isRetrievingShareCode;

		private static readonly string[] _decorationCatgories;

		private static readonly string[] _templatePropCategories;

		private static TooltipData _variantTooltip;

		private static TooltipData _notAsVariantTooltip;

		public bool IsGalleryMode { get; set; }

		public bool IsEditable { get; set; }

		public BuildableTemplate TemplateData { get; private set; }

		private Dictionary<string, GameObject> ActiveVisualDict => null;

		protected override void Start()
		{
		}

		protected override void OnUIReset(object sender, EventArgs e)
		{
		}

		private void Tavern_MoneyChangedEvent(object sender, EventArgs<int> e)
		{
		}

		private void Tavern_FreePropsChanged(object sender, EventArgs e)
		{
		}

		protected override void OnDestroy()
		{
		}

		public void ShowData(BuildableTemplate templateData, bool isVariant = false)
		{
		}

		private void TemplateData_SwatchChanged(object sender, EventArgs e)
		{
		}

		private void OnShowVariantButtonClicked()
		{
		}

		private void OnSelectedVariantChanged(object sender, EventArgs e)
		{
		}

		private void OnStylesButtonClicked()
		{
		}

		private void ResetVisual()
		{
		}

		public void ClearData()
		{
		}

		public void Invalidate()
		{
		}

		private void UpdateImportErrorIcon()
		{
		}

		private void CheckImportErrors()
		{
		}

		private bool HasImportErrors(StringBuilder sb = null)
		{
			return false;
		}

		public void UpdatePlusIconState()
		{
		}

		private void UpdateVariantButton()
		{
		}

		private void UpdateCanAfford()
		{
		}

		private void UpdateIsEnabled(BuildableTemplate template)
		{
		}

		public override TooltipData GetTooltipData()
		{
			return null;
		}

		private void UpdateBuildCost()
		{
		}

		private void UpdateBuildLimitInfo()
		{
		}

		public void NotifyOnPropBuildAmountChanged(string propKey)
		{
		}

		public string GetEffectiveBuildKey()
		{
			return null;
		}

		private BuildableTemplate GetEffectiveTemplate()
		{
			return null;
		}

		private void UpdateSocketObject(GameObject prefab)
		{
		}

		public void Align()
		{
		}

		public override void OnClicked()
		{
		}

		public void NotifyOnDiscountChanged(string propType)
		{
		}

		protected override void OnHoveredChanged()
		{
		}

		[IteratorStateMachine(typeof(_003CGetContextMenuItems_003Ed__67))]
		public IEnumerable<ContextMenuItem> GetContextMenuItems()
		{
			return null;
		}

		private void ChangePersistedRotation(Quaternion rotation, BuildableTemplate template)
		{
		}

		public void SetUIRotation(Quaternion rotation)
		{
		}

		public void UpdateUIRotation()
		{
		}

		private ContextMenuItem CreateChangeCategoryMenu(BuildableTemplate template)
		{
			return null;
		}

		private ContextMenuItem CreateChangeSubCategoryMenu(BuildableTemplate template)
		{
			return null;
		}

		private IEnumerable<string> GetAvailableSubcategories(BuildableTemplate template)
		{
			return null;
		}

		private ContextMenuItem CreateEditTemplateDataButton(BuildableTemplate template)
		{
			return null;
		}

		private ContextMenuItem CreateDecorationVariantContextMenu(BuildableTemplate template)
		{
			return null;
		}

		private void AssignVariantParent(BuildableTemplate template, BuildableTemplate parent)
		{
		}

		private ContextMenuItem CreateCustomTemplatesVariantChoiceGroup(BuildableTemplate template, bool isDecoration)
		{
			return null;
		}

		private ContextMenuItem CreateOfficialTemplatesVariantChoiceGroup(BuildableTemplate template, bool isDecoration)
		{
			return null;
		}

		private ContextMenuItem CreatePropVariantContextMenu(BuildableTemplate template)
		{
			return null;
		}

		private ContextMenuItem CreateVariantButton(BuildableTemplate template, BuildableTemplate parent)
		{
			return null;
		}

		private TooltipData GetAsVariantTooltip()
		{
			return null;
		}

		private TooltipData GetNotAsVariantTooltip()
		{
			return null;
		}

		public void ClearPrivateModelCache()
		{
		}
	}
}
