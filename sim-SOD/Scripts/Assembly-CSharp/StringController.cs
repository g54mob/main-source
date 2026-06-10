using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StringController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[CompilerGenerated]
	private sealed class _003CMouseOver_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public StringController _003C_003E4__this;

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
		public _003CMouseOver_003Ed__20(int _003C_003E1__state)
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

	public RectTransform rect;

	public RectTransform fromRect;

	public RectTransform toRect;

	public Image img;

	public Color pulsateColor;

	public Dictionary<Fact, TooltipController> tooltips;

	public CasePanelController.StringConnection connection;

	public ContextMenuController contextMenu;

	public JuiceController juice;

	public List<Evidence.FactLink> debugLinks;

	public float cumulativeReliability;

	public bool isOver;

	public float additionalSpawnDelay;

	public float moTimer;

	[NonSerialized]
	public float fadeIn;

	public void Setup(CasePanelController.StringConnection newConnection)
	{
	}

	public void UpdatePosition()
	{
	}

	public void ForceCloseTooltip()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	[IteratorStateMachine(typeof(_003CMouseOver_003Ed__20))]
	private IEnumerator MouseOver()
	{
		return null;
	}

	public virtual void OnPointerExit(PointerEventData eventData)
	{
	}

	public void UpdateTooltipText(Fact fact)
	{
	}

	public void UpdateStringColour()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public bool UpdateHidden()
	{
		return false;
	}

	public void SetColour(InterfaceControls.EvidenceColours col)
	{
	}

	public void RenameCustomLink()
	{
	}

	public void OnContinueFactName()
	{
	}

	public void RemoveCustomLink()
	{
	}

	public void SetColourRed()
	{
	}

	public void SetColourBlue()
	{
	}

	public void SetColourYellow()
	{
	}

	public void SetColourGreen()
	{
	}

	public void SetColourPurple()
	{
	}

	public void SetColourWhite()
	{
	}

	public void SetColourBlack()
	{
	}

	public void Hide()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void UpdateDebugFactLinks()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DisplayFactIdentifier()
	{
	}
}
