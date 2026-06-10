using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TooltipController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public delegate void BeforeTooltipSpawn();

	[CompilerGenerated]
	private sealed class _003CMouseOver_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TooltipController _003C_003E4__this;

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
		public _003CMouseOver_003Ed__44(int _003C_003E1__state)
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

	[Header("Init")]
	public bool tooltipEnabled;

	public bool handleOwnBehaviour;

	[Tooltip("If this isn't null, the tooltip will spawn parented to this layer instead of the tooltip canvas.")]
	public RectTransform parentOverride;

	[Header("Text")]
	public bool useMainDictionaryEntry;

	public string mainDictionary;

	public string mainDictionaryKey;

	public bool useDetailDictionaryEntry;

	public string detailDictionary;

	public string detailDictionaryKey;

	public string mainText;

	public string detailText;

	[Header("State")]
	public bool isOver;

	[Tooltip("Added onto the default spawn time (seconds)")]
	[Header("Delay")]
	public float additionalSpawnDelay;

	public float moTimer;

	public GameObject spawnedTooltip;

	public TextMeshProUGUI tooltipText;

	public float fadeIn;

	public CanvasRenderer rend;

	public CanvasRenderer textRend;

	public Vector2 pos;

	public bool useCursorPos;

	public Vector2 cursorPosOffset;

	public bool limitWidth;

	public int extendTooltipWidth;

	private Outline outline;

	public bool enableOutlineMouseOver;

	private Image img;

	public Sprite mouseOverSprite;

	private Sprite originalSprite;

	public ContextMenuController contextMenuBelongingToThis;

	[Tooltip("While active, constantly update the tooltip postion")]
	public bool updateTooltipPosition;

	public static TooltipController activeTooltip;

	public event BeforeTooltipSpawn OnBeforeTooltipSpawn
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Start()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public virtual void OnPointerExit(PointerEventData eventData)
	{
	}

	public virtual void OnButtonHover()
	{
	}

	public virtual void OnButtonExitHover()
	{
	}

	public virtual void SetPointerOver(bool val)
	{
	}

	public virtual void OnMouseEnterCustom()
	{
	}

	public virtual void GetText()
	{
	}

	[IteratorStateMachine(typeof(_003CMouseOver_003Ed__44))]
	private IEnumerator MouseOver()
	{
		return null;
	}

	public void OpenTooltip()
	{
	}

	private Vector2 ClampToWindow(Vector2 rawPointerPosition)
	{
		return default(Vector2);
	}

	public void ClampThisOnscreen()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	public static void RemoveActiveTooltip()
	{
	}

	public void ForceClose()
	{
	}

	public virtual void OnMouseOverCustom()
	{
	}

	public virtual void OnMouseOffCustom()
	{
	}
}
