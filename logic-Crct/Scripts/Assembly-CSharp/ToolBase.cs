using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ToolBase : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CEnumeratorAwaitRefresh_003Ed__53 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003CEnumeratorAwaitRefresh_003Ed__53(int _003C_003E1__state)
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

	protected bool active;

	public bool placing;

	protected bool moving;

	[Header("Property Box")]
	public int propertyID;

	public Button[] buttons;

	public Button edit_applyButton;

	[Header("Component")]
	public GameObject prefab;

	public BaseComponent component;

	public BaseComponent editComponent;

	public Transform baseArea;

	[Header("Variables")]
	protected object[] prevVals;

	public virtual void SetActive(bool a)
	{
	}

	public virtual void _IPC_BeginCreate()
	{
	}

	public virtual void _IPC_BeginCreate(string data)
	{
	}

	public virtual void Awake()
	{
	}

	public virtual void OnClick()
	{
	}

	public virtual void LoadEdit(BaseComponent comp)
	{
	}

	public virtual void CloseEdit()
	{
	}

	public virtual void CancelEdit()
	{
	}

	public virtual void DisplayProperty()
	{
	}

	public virtual void DisplayPropertyOverrideSize(Vector2 overrideSize)
	{
	}

	public virtual void HideProperty()
	{
	}

	public virtual void ResetTool()
	{
	}

	public virtual void ResetMobile()
	{
	}

	public virtual void Cancel()
	{
	}

	public virtual void BeginMove()
	{
	}

	public virtual void CompleteMove()
	{
	}

	public virtual void CancelMove()
	{
	}

	public virtual void CancelCreation()
	{
	}

	public virtual void UpdateTransformValues()
	{
	}

	public virtual void BeginCreate()
	{
	}

	public virtual void CompleteCreate()
	{
	}

	public virtual void UndoCreate(params object[] args)
	{
	}

	public virtual void RedoCreate(params object[] args)
	{
	}

	public virtual void CreateFromSaveFile(params object[] args)
	{
	}

	public virtual void CreateFromVarData(params object[] args)
	{
	}

	public virtual void UpdateCreateParams()
	{
	}

	public virtual void UpdateEditParams()
	{
	}

	public virtual void UpdateCreateParams(Selectable sel)
	{
	}

	public virtual void UpdateEditParams(Selectable sel)
	{
	}

	public virtual void CallUpdateToChildren(BaseComponent c, params object[] args)
	{
	}

	public virtual void Delete()
	{
	}

	public virtual void DeleteChildren(int undoId, BaseComponent c)
	{
	}

	public virtual void DeleteChildrenRedo(int undoId, BaseComponent c)
	{
	}

	public virtual void UndoDelete(params object[] args)
	{
	}

	public virtual void RedoDelete(params object[] args)
	{
	}

	public virtual void PreviousValues(BaseComponent c)
	{
	}

	public virtual void RevertValues(BaseComponent c)
	{
	}

	public virtual bool ValuesChanged(BaseComponent c)
	{
		return false;
	}

	public virtual void ApplyChanges()
	{
	}

	public virtual void UndoValueChanges(params object[] args)
	{
	}

	public virtual void RedoValueChanges(params object[] args)
	{
	}

	public virtual void RefreshEdit()
	{
	}

	[IteratorStateMachine(typeof(_003CEnumeratorAwaitRefresh_003Ed__53))]
	public virtual IEnumerator EnumeratorAwaitRefresh(int frames)
	{
		return null;
	}

	public virtual void Update()
	{
	}

	public virtual void EEPROMUpdated()
	{
	}

	public virtual void EEPROMUpdated(BaseComponent comp)
	{
	}
}
