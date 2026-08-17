using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Coffee.UIEffects;

public abstract class BaseMeshEffect : UIBehaviour, IMeshModifier
{
	private RectTransform _rectTransform;

	private Graphic _graphic;

	private GraphicConnector _connector;

	internal readonly List<UISyncEffect> syncEffects;

	protected GraphicConnector connector
	{
		get
		{
			GraphicConnector result = _connector;
			if (_connector == null)
			{
				Graphic graphic = this.graphic;
				result = (_connector = GraphicConnector.FindConnector(graphic));
			}
			return result;
		}
	}

	public Graphic graphic
	{
		get
		{
			Graphic graphic = _graphic;
			if ((object)_graphic != null && ((UnityEngine.Object)graphic).m_CachedPtr != (IntPtr)0)
			{
				return _graphic;
			}
			return _graphic = GetComponent<Graphic>();
		}
	}

	protected RectTransform rectTransform
	{
		get
		{
			RectTransform rectTransform = _rectTransform;
			if ((object)_rectTransform != null && ((UnityEngine.Object)rectTransform).m_CachedPtr != (IntPtr)0)
			{
				return _rectTransform;
			}
			return _rectTransform = GetComponent<RectTransform>();
		}
	}

	public virtual void ModifyMesh(Mesh mesh)
	{
	}

	public virtual void ModifyMesh(VertexHelper vh)
	{
		Graphic graphic = this.graphic;
		ModifyMesh(vh, graphic);
	}

	public virtual void ModifyMesh(VertexHelper vh, Graphic graphic)
	{
	}

	protected virtual void SetVerticesDirty()
	{
		//IL_000d: Expected I, but got O
		//IL_002d: Expected O, but got I4
		GraphicConnector graphicConnector = connector;
		Graphic verticesDirty = graphic;
		nint num = (nint)graphicConnector;
		graphicConnector.SetVerticesDirty(verticesDirty);
		List<UISyncEffect>.Enumerator enumerator = default(List<UISyncEffect>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	protected override void OnEnable()
	{
		GraphicConnector graphicConnector = connector;
		Graphic graphic = this.graphic;
		graphicConnector.OnEnable(graphic);
		SetVerticesDirty();
	}

	protected override void OnDisable()
	{
		GraphicConnector graphicConnector = connector;
		Graphic graphic = this.graphic;
		graphicConnector.OnDisable(graphic);
		SetVerticesDirty();
	}

	protected virtual void SetEffectParamsDirty()
	{
		//IL_003f: Expected O, but got I4
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj != null)
		{
			SetVerticesDirty();
		}
	}

	protected override void OnDidApplyAnimationProperties()
	{
		//IL_003f: Expected O, but got I4
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj != null)
		{
			SetEffectParamsDirty();
		}
	}

	protected BaseMeshEffect()
	{
		List<UISyncEffect> list = new List<UISyncEffect>(0);
		syncEffects = list;
	}
}
