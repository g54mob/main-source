using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ICTool : ToolBase
{
	[CompilerGenerated]
	private sealed class _003C_CompleteMove_003Ed__40 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003C_CompleteMove_003Ed__40(int _003C_003E1__state)
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

	[Header("Creator Box")]
	public Vector2 overrideSize;

	public Dropdown cre_mainCategoryDrop;

	public Dropdown cre_subCategoryDrop;

	public Dropdown cre_chipDrop;

	public OptionDataList subCategoryOptions;

	public OptionDataList chipOptions;

	public Button cre_addButton;

	public Button cre_cancelButton;

	[Header("Chip Prefabs")]
	public GameObject[] prefabs;

	[Header("Create Chip Description")]
	public Image cre_pinImage;

	public Text cre_descText;

	public Text cre_dataSheetHeadingText;

	public Text cre_datasheetText;

	[Header("Editor Box")]
	public Button edit_MoveButton;

	[Header("Editor Chip Description")]
	public Image edit_pinImage;

	public Text edit_descText;

	public Text edit_dataSheetHeadingText;

	public Text edit_datasheetText;

	private int prevMain;

	private int prevSub;

	private OptionDataExtended chipData;

	private readonly int compMask;

	private readonly int defMask;

	private Ray ray;

	private RaycastHit hit;

	private TiePoint curPoint;

	private BaseComponent hitComp;

	public override void OnClick()
	{
	}

	public override void LoadEdit(BaseComponent comp)
	{
	}

	private void ResetDropDowns()
	{
	}

	private void HideChipDescription()
	{
	}

	private void ShowChipDescription()
	{
	}

	public override void UpdateCreateParams()
	{
	}

	private void PopulateSubCategory(int id)
	{
	}

	private void PopulateChipCategory(int mId, int sId)
	{
	}

	private void UpdateChipDescription()
	{
	}

	public void OpenDatasheet(Text t)
	{
	}

	public override void BeginCreate()
	{
	}

	public override void CompleteCreate()
	{
	}

	public override void CancelCreation()
	{
	}

	public override void BeginMove()
	{
	}

	public override void Delete()
	{
	}

	public override void CancelMove()
	{
	}

	public override void CompleteMove()
	{
	}

	public override void UndoValueChanges(params object[] args)
	{
	}

	public override void RedoValueChanges(params object[] args)
	{
	}

	[IteratorStateMachine(typeof(_003C_CompleteMove_003Ed__40))]
	private IEnumerator _CompleteMove()
	{
		return null;
	}

	public override void CreateFromSaveFile(params object[] args)
	{
	}

	public override void UndoDelete(params object[] args)
	{
	}

	public override void RedoCreate(params object[] args)
	{
	}

	public override void CreateFromVarData(params object[] args)
	{
	}

	public override void Update()
	{
	}
}
