using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class EntityLocation : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CReportLocationNextFrame_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EntityLocation _003C_003E4__this;

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
		public _003CReportLocationNextFrame_003Ed__24(int _003C_003E1__state)
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

	[Header("References")]
	public Image Image_Stars;

	public Sprite[] Sprites_Stars;

	public Image Image_Armour;

	public Sprite[] Sprites_Armour;

	public Image Image_Icon;

	public CanvasGroup VisibilityGroup;

	[Header("Events")]
	public UnityEvent<EntityLocation> OnDestroyed_Ally;

	public UnityEvent<EntityLocation> OnDestroyed;

	public UnityEvent<EntityLocation> OnTakeDamage_Ally;

	public UnityEvent<EntityLocation> OnTakeDamage;

	public UnityEvent<EntityLocation> OnImmuneToShellHit;

	[HideInInspector]
	public Vector2 LocalPosition;

	[HideInInspector]
	public MapEntity Entity;

	[HideInInspector]
	public static Dictionary<string, MapEntityIcon> PossibleMapIcons;

	private static RectTransform _rootCanvasRect;

	private static bool _warnedNoCanvas;

	private static Vector3 _lastRootPos;

	private static Quaternion _lastRootRot;

	private static Vector3 _lastRootScale;

	private static bool _rootTransformCached;

	public void Awake()
	{
	}

	public void Init(MapEntity entity)
	{
	}

	private void OnDestroy()
	{
	}

	public bool TakeDamage(ShellDefinition shell, int damage, string shellInstanceId = "")
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CReportLocationNextFrame_003Ed__24))]
	private IEnumerator ReportLocationNextFrame()
	{
		return null;
	}

	private void RecalculateAndRegister(bool forceRegister)
	{
	}

	public void OnEntityStateChanged(MapEntityStates oldState, MapEntityStates newState)
	{
	}

	private RectTransform ResolveRootCanvasRect()
	{
		return null;
	}

	private void CacheRootTransform(RectTransform rootRect)
	{
	}
}
