using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TMP_SelectionController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler, IPointerUpHandler
{
	[CompilerGenerated]
	private sealed class _003CLateStart_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TMP_SelectionController _003C_003E4__this;

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
		public _003CLateStart_003Ed__21(int _003C_003E1__state)
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

	public TextMeshProUGUI m_TextMeshPro;

	private Canvas m_Canvas;

	private Camera m_Camera;

	private bool isHoveringObject;

	private int m_selectedLink;

	private Matrix4x4 m_matrix;

	private TMP_MeshInfo[] m_cachedMeshInfoVertexData;

	public List<LinkButtonController> linkButtons;

	public Color hoverColour;

	private Color hoverOriginal;

	public Color highlightColour;

	private bool originalUseGradient;

	private TMP_ColorGradient originalGradient;

	public Dictionary<int, bool> markedLinks;

	private int lastPage;

	private void Awake()
	{
	}

	public void UpdateOriginalFontSettings()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void ON_TEXT_CHANGED(UnityEngine.Object obj)
	{
	}

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CLateStart_003Ed__21))]
	private IEnumerator LateStart()
	{
		return null;
	}

	private void LateUpdate()
	{
	}

	public void NewHover(int linkIndex)
	{
	}

	public void EndHover(int linkIndex)
	{
	}

	public void UpdateLinkDiscovery()
	{
	}

	public void RefreshLinkButtons(bool updateNavigation = true)
	{
	}

	private LinkButtonController DrawButton(Vector3 bottomLeft, float width, float height, string linkID, string buttonName)
	{
		return null;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	private void RestoreCachedVertexAttributes(int index)
	{
	}
}
