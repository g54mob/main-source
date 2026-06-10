using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Chapter : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CChapterActivationDelay_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Chapter _003C_003E4__this;

		private int _003CframeDelay_003E5__2;

		private MethodInfo _003Cmethod_003E5__3;

		private object[] _003Cpassed_003E5__4;

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
		public _003CChapterActivationDelay_003Ed__20(int _003C_003E1__state)
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

	public ChapterPreset preset;

	[NonSerialized]
	public Case thisCase;

	public bool loadedFromSave;

	public bool gameStart;

	public float blackTimer;

	public float blurTimer;

	public float blackFade;

	public float blurFade;

	public NewNode currentPartLocation;

	private bool teleportPlayerToChapter;

	private bool chapterFrameDelay;

	public Dictionary<string, float> invokeOnDelay;

	public void Awake()
	{
	}

	public virtual void OnLoaded()
	{
	}

	public virtual void OnLoadFinalize()
	{
	}

	public virtual void OnObjectsCreated()
	{
	}

	public virtual void OnGameStart()
	{
	}

	public void ClearAllObjectives()
	{
	}

	public void ClearObjective(string clearThis)
	{
	}

	public virtual void OnNewChapterPart(bool delay = false, bool teleportPlayer = false)
	{
	}

	[IteratorStateMachine(typeof(_003CChapterActivationDelay_003Ed__20))]
	private IEnumerator ChapterActivationDelay()
	{
		return null;
	}

	private void OnDestroy()
	{
	}

	public virtual void OnGameWorldLoop()
	{
	}

	public void InvokeAfterDelay(string command, float delayRealSeconds)
	{
	}

	public virtual void SetCurrentPartLocation(NewNode newNode)
	{
	}

	public virtual void PlayerVO(string entryRef, float delay = 0f, bool useParsing = true, bool shouting = false, bool interupt = false, bool forceColour = false, Color color = default(Color))
	{
	}

	public virtual void AddObjective(string entryRef, List<Objective.ObjectiveTrigger> triggers, bool usePointer = false, Vector3 pointerPosition = default(Vector3), InterfaceControls.Icon useIcon = InterfaceControls.Icon.lookingGlass, Objective.OnCompleteAction onCompleteAction = Objective.OnCompleteAction.nextChapterPart, float delay = 0f, bool removePrevious = false, string chapterString = "", bool isSilent = false, bool allowCrouchPromt = false, bool useParsing = true)
	{
	}

	public virtual void AddObjective(string entryRef, Objective.ObjectiveTrigger trigger, bool usePointer = false, Vector3 pointerPosition = default(Vector3), InterfaceControls.Icon useIcon = InterfaceControls.Icon.lookingGlass, Objective.OnCompleteAction onCompleteAction = Objective.OnCompleteAction.nextChapterPart, float delay = 0f, bool removePrevious = false, string chapterString = "", bool isSilent = false, bool allowCrouchPromt = false)
	{
	}

	public virtual StateSaveData.ChaperStateSave GetChapterSaveData()
	{
		return null;
	}

	public virtual void LoadStateSaveData(StateSaveData.ChaperStateSave newData)
	{
	}

	public Interactable LoadInteractableFromData(string reference, ref StateSaveData.ChaperStateSave saveData)
	{
		return null;
	}
}
