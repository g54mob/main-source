using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I18n;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class TemplateDataDialog3DUIView : BaseDialog3DUIView
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass70_0
		{
			public bool wasSuccessful;

			public TemplateDataDialog3DUIView _003C_003E4__this;

			public string tempImageLocation;

			internal void _003CUploadTemplateData_003Eb__0(string code)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass82_0
		{
			public RenderTexture rt;

			internal RenderTexture _003CCaptureScreenshot_003Eb__0(Camera x)
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CCaptureScreenshot_003Ed__82 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TemplateDataDialog3DUIView _003C_003E4__this;

			private _003C_003Ec__DisplayClass82_0 _003C_003E8__1;

			private int _003CwidthMargin_003E5__2;

			private int _003CheightMargin_003E5__3;

			private Camera[] _003CrenderCams_003E5__4;

			private bool _003CdirectorsToolbarActive_003E5__5;

			private RenderTexture[] _003CpreviousRenderTargets_003E5__6;

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
			public _003CCaptureScreenshot_003Ed__82(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CSaveScreenshotForPlayer_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TemplateDataDialog3DUIView _003C_003E4__this;

			private IEnumerator _003CsecondScreenshotEnumerator_003E5__2;

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
			public _003CSaveScreenshotForPlayer_003Ed__41(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CUploadTemplateData_003Ed__70 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TemplateDataDialog3DUIView _003C_003E4__this;

			private _003C_003Ec__DisplayClass70_0 _003C_003E8__1;

			private IEnumerator _003CscreenshotEnumerator_003E5__2;

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
			public _003CUploadTemplateData_003Ed__70(int _003C_003E1__state)
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

		[SerializeField]
		private Button3DUIView _closeButton;

		[SerializeField]
		private Button3DUIView _saveButton;

		[SerializeField]
		private Button3DUIView _shareButton;

		[SerializeField]
		private Button3DUIView _nextVariantButton;

		[SerializeField]
		private Button3DUIView _previousVariantButton;

		[SerializeField]
		private TMP_InputField _nameText;

		[SerializeField]
		private TMP_Text _sharePageNameText;

		[SerializeField]
		private TMP_InputField _descriptionText;

		[SerializeField]
		private PropBuildButton3DUIView _propBuildButton;

		[SerializeField]
		private BaseInteractable3DUIView _quickRotateTrigger;

		[SerializeField]
		private CheckBox3DUIView _includeVariantsCheckBox;

		[SerializeField]
		private TextMeshProUGUII18n _includeVariantsText;

		[SerializeField]
		private CheckBox3DUIView _useAsVariantCheckBox;

		[SerializeField]
		private TMP_DropdownI18n _variantParentDropdown;

		[SerializeField]
		private CheckBox3DUIView _useAsStandaloneCheckBox;

		[SerializeField]
		private TMP_DropdownI18n _categoryDropdown;

		[SerializeField]
		private TMP_DropdownI18n _subCategoryDropdown;

		[SerializeField]
		private List<TextBlock3DUIView> _authorTexts;

		[SerializeField]
		private List<GameObject> _editLayoutElements;

		[SerializeField]
		private List<GameObject> _sharingLayoutElements;

		[SerializeField]
		private List<GameObject> _serverScreenshotElements;

		[SerializeField]
		private TMP_Text _shareCodeText;

		[SerializeField]
		private Button3DUIView _copyShareCodeButton;

		[SerializeField]
		private Button3DUIView _saveImageButton;

		public Action<BuildableTemplate> onSubmit;

		public Action<BuildableTemplate> onClosedWithoutSaveCallback;

		private bool _didSaveTemplate;

		private Coroutine _saveScreenshotCoroutine;

		[SerializeField]
		private GameObject _lockedVariantTooltipProvider;

		[SerializeField]
		private GameObject _lockedCategoryTooltipProvider;

		[SerializeField]
		private GameObject _lockedSubCategoryTooltipProvider;

		private const string PROPCATEGORY_DECORATION = "decoration";

		private InputMode _lastInputMode;

		[SerializeField]
		private TextMeshProUGUII18n _titleText;

		[Header("Screenshot Output")]
		[SerializeField]
		private int _screenshotWidth;

		[SerializeField]
		private int _screenshotHeight;

		[SerializeField]
		private float _widthMarginPercentage;

		[SerializeField]
		private float _heightMarginPercentage;

		[SerializeField]
		private Vector2 _screenshotCenterOffset;

		private string _outputLocation;

		private byte[] _lastScreenshot;

		[SerializeField]
		private string _screenshotImageFormat;

		[SerializeField]
		private int _jpgQuality;

		private string SelectedCategory => null;

		private string SelectedSubCategory => null;

		public BuildableTemplate TemplateData { get; private set; }

		public static bool IsRetrievingShareCode { get; private set; }

		private void SetEditLayout()
		{
		}

		private void SetPlayerScreenshotLayout()
		{
		}

		private void SetSharingLayout()
		{
		}

		private void SetServerScreenshotLayout()
		{
		}

		protected override void Awake()
		{
		}

		[IteratorStateMachine(typeof(_003CSaveScreenshotForPlayer_003Ed__41))]
		private IEnumerator SaveScreenshotForPlayer()
		{
			return null;
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override void Opened()
		{
		}

		protected override bool CanClose(ShowHideAnimationSpeed speed, bool forceClose)
		{
			return false;
		}

		public override void BackOrClose()
		{
		}

		private void OnCancelled()
		{
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}

		private void ChangeVariantIndex(int adjustment)
		{
		}

		private BuildableTemplate[] GetShareableVariants()
		{
			return null;
		}

		public void SetTemplateData(BuildableTemplate data, bool fullRefresh = true)
		{
		}

		private void UpdateDropdownInteractableStates()
		{
		}

		private void OnIsPressedChanged(object sender, EventArgs<bool> eventArgs)
		{
		}

		public void RotateTemplate(Vector3 adjustmentDegree)
		{
		}

		private void ToggledStandalone(object sender, EventArgs<bool> eventArgs)
		{
		}

		private void ToggledVariantCheckbox(object sender, EventArgs<bool> eventArgs)
		{
		}

		private List<BuildableTemplate> GetPossibleVariants()
		{
			return null;
		}

		private IEnumerable<string> GetAllCategories()
		{
			return null;
		}

		private IEnumerable<string> GetAllSubCategories()
		{
			return null;
		}

		private void SubmitChanges()
		{
		}

		private void ApplyTemplateData()
		{
		}

		[IteratorStateMachine(typeof(_003CUploadTemplateData_003Ed__70))]
		private IEnumerator UploadTemplateData()
		{
			return null;
		}

		public void SetTitle(string title)
		{
		}

		[IteratorStateMachine(typeof(_003CCaptureScreenshot_003Ed__82))]
		private IEnumerator CaptureScreenshot()
		{
			return null;
		}
	}
}
