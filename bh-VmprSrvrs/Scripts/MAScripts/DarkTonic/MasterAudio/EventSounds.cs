using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DarkTonic.MasterAudio
{
	[AudioScriptOrder(-30)]
	[AddComponentMenu("Dark Tonic/Master Audio/Event Sounds")]
	public class EventSounds : MonoBehaviour, ICustomEventReceiver
	{
		public enum UnityUIVersion
		{
			Legacy = 0,
			uGUI = 1
		}

		public enum EventType
		{
			OnStart = 0,
			OnVisible = 1,
			OnInvisible = 2,
			OnCollision = 3,
			OnTriggerEnter = 4,
			OnTriggerExit = 5,
			OnMouseEnter = 6,
			OnMouseClick = 7,
			OnSpawned = 8,
			OnDespawned = 9,
			OnEnable = 10,
			OnDisable = 11,
			OnCollision2D = 12,
			OnTriggerEnter2D = 13,
			OnTriggerExit2D = 14,
			OnParticleCollision = 15,
			UserDefinedEvent = 16,
			OnCollisionExit = 17,
			OnCollisionExit2D = 18,
			OnMouseUp = 19,
			OnMouseExit = 20,
			OnMouseDrag = 21,
			NGUIOnClick = 22,
			NGUIMouseDown = 23,
			NGUIMouseUp = 24,
			NGUIMouseEnter = 25,
			NGUIMouseExit = 26,
			MechanimStateChanged = 27,
			UnitySliderChanged = 28,
			UnityButtonClicked = 29,
			UnityPointerDown = 30,
			UnityPointerUp = 31,
			UnityPointerEnter = 32,
			UnityPointerExit = 33,
			UnityDrag = 34,
			UnityDrop = 35,
			UnityScroll = 36,
			UnityUpdateSelected = 37,
			UnitySelect = 38,
			UnityDeselect = 39,
			UnityMove = 40,
			UnityInitializePotentialDrag = 41,
			UnityBeginDrag = 42,
			UnityEndDrag = 43,
			UnitySubmit = 44,
			UnityCancel = 45,
			UnityToggle = 46,
			OnTriggerStay = 47,
			OnTriggerStay2D = 48,
			CodeTriggeredEvent1 = 49,
			CodeTriggeredEvent2 = 50
		}

		public enum GlidePitchType
		{
			None = 0,
			RaisePitch = 1,
			LowerPitch = 2
		}

		public enum VariationType
		{
			PlaySpecific = 0,
			PlayRandom = 1
		}

		public enum PreviousSoundStopMode
		{
			None = 0,
			Stop = 1,
			FadeOut = 2
		}

		public enum RetriggerLimMode
		{
			None = 0,
			FrameBased = 1,
			TimeBased = 2
		}

		[CompilerGenerated]
		private sealed class _003CCoUpdate_003Ed__129 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public EventSounds _003C_003E4__this;

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
			public _003CCoUpdate_003Ed__129(int _003C_003E1__state)
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

		public MasterAudio.SoundSpawnLocationMode soundSpawnMode;

		public bool disableSounds;

		public bool showPoolManager;

		public bool showNGUI;

		public AudioEvent eventToGizmo;

		public UnityUIVersion unityUIMode;

		public bool logMissingEvents;

		public static List<string> LayerTagFilterEvents;

		public static List<MasterAudio.PlaylistCommand> PlaylistCommandsWithAll;

		public AudioEventGroup startSound;

		public AudioEventGroup visibleSound;

		public AudioEventGroup invisibleSound;

		public AudioEventGroup collisionSound;

		public AudioEventGroup collisionExitSound;

		public AudioEventGroup triggerSound;

		public AudioEventGroup triggerExitSound;

		public AudioEventGroup triggerStaySound;

		public AudioEventGroup mouseEnterSound;

		public AudioEventGroup mouseExitSound;

		public AudioEventGroup mouseClickSound;

		public AudioEventGroup mouseUpSound;

		public AudioEventGroup mouseDragSound;

		public AudioEventGroup spawnedSound;

		public AudioEventGroup despawnedSound;

		public AudioEventGroup enableSound;

		public AudioEventGroup disableSound;

		public AudioEventGroup collision2dSound;

		public AudioEventGroup collisionExit2dSound;

		public AudioEventGroup triggerEnter2dSound;

		public AudioEventGroup triggerStay2dSound;

		public AudioEventGroup triggerExit2dSound;

		public AudioEventGroup particleCollisionSound;

		public AudioEventGroup nguiOnClickSound;

		public AudioEventGroup nguiMouseDownSound;

		public AudioEventGroup nguiMouseUpSound;

		public AudioEventGroup nguiMouseEnterSound;

		public AudioEventGroup nguiMouseExitSound;

		public AudioEventGroup codeTriggeredEvent1Sound;

		public AudioEventGroup codeTriggeredEvent2Sound;

		public AudioEventGroup unitySliderChangedSound;

		public AudioEventGroup unityButtonClickedSound;

		public AudioEventGroup unityPointerDownSound;

		public AudioEventGroup unityDragSound;

		public AudioEventGroup unityPointerUpSound;

		public AudioEventGroup unityPointerEnterSound;

		public AudioEventGroup unityPointerExitSound;

		public AudioEventGroup unityDropSound;

		public AudioEventGroup unityScrollSound;

		public AudioEventGroup unityUpdateSelectedSound;

		public AudioEventGroup unitySelectSound;

		public AudioEventGroup unityDeselectSound;

		public AudioEventGroup unityMoveSound;

		public AudioEventGroup unityInitializePotentialDragSound;

		public AudioEventGroup unityBeginDragSound;

		public AudioEventGroup unityEndDragSound;

		public AudioEventGroup unitySubmitSound;

		public AudioEventGroup unityCancelSound;

		public AudioEventGroup unityToggleSound;

		public List<AudioEventGroup> userDefinedSounds;

		public List<AudioEventGroup> mechanimStateChangedSounds;

		public bool useStartSound;

		public bool useVisibleSound;

		public bool useInvisibleSound;

		public bool useCollisionSound;

		public bool useCollisionExitSound;

		public bool useTriggerEnterSound;

		public bool useTriggerExitSound;

		public bool useTriggerStaySound;

		public bool useMouseEnterSound;

		public bool useMouseExitSound;

		public bool useMouseClickSound;

		public bool useMouseUpSound;

		public bool useMouseDragSound;

		public bool useSpawnedSound;

		public bool useDespawnedSound;

		public bool useEnableSound;

		public bool useDisableSound;

		public bool useCollision2dSound;

		public bool useCollisionExit2dSound;

		public bool useTriggerEnter2dSound;

		public bool useTriggerStay2dSound;

		public bool useTriggerExit2dSound;

		public bool useParticleCollisionSound;

		public bool useNguiOnClickSound;

		public bool useNguiMouseDownSound;

		public bool useNguiMouseUpSound;

		public bool useNguiMouseEnterSound;

		public bool useNguiMouseExitSound;

		public bool useCodeTriggeredEvent1Sound;

		public bool useCodeTriggeredEvent2Sound;

		public bool useUnitySliderChangedSound;

		public bool useUnityButtonClickedSound;

		public bool useUnityPointerDownSound;

		public bool useUnityDragSound;

		public bool useUnityPointerUpSound;

		public bool useUnityPointerEnterSound;

		public bool useUnityPointerExitSound;

		public bool useUnityDropSound;

		public bool useUnityScrollSound;

		public bool useUnityUpdateSelectedSound;

		public bool useUnitySelectSound;

		public bool useUnityDeselectSound;

		public bool useUnityMoveSound;

		public bool useUnityInitializePotentialDragSound;

		public bool useUnityBeginDragSound;

		public bool useUnityEndDragSound;

		public bool useUnitySubmitSound;

		public bool useUnityCancelSound;

		public bool useUnityToggleSound;

		private Slider _slider;

		private Toggle _toggle;

		private Button _button;

		private bool _isVisible;

		private bool _needsCoroutine;

		private float? _triggerEnterTime;

		private float? _triggerEnter2dTime;

		private bool _mouseDragSoundPlayed;

		private PlaySoundResult _mouseDragResult;

		private Transform _trans;

		private readonly List<AudioEventGroup> _validMechanimStateChangedSounds;

		private Animator _anim;

		private bool IsSetToUGUI => false;

		private bool IsSetToLegacyUI => false;

		private void Awake()
		{
		}

		protected virtual void SpawnedOrAwake()
		{
		}

		[IteratorStateMachine(typeof(_003CCoUpdate_003Ed__129))]
		private IEnumerator CoUpdate()
		{
			return null;
		}

		private void Start()
		{
		}

		private void OnBecameVisible()
		{
		}

		private void OnBecameInvisible()
		{
		}

		private void OnEnable()
		{
		}

		private void RestorePersistentSliders()
		{
		}

		private void OnDisable()
		{
		}

		private void OnParticleCollision(GameObject other)
		{
		}

		public void OnPointerEnter(PointerEventData data)
		{
		}

		public void OnPointerExit(PointerEventData data)
		{
		}

		public void OnPointerDown(PointerEventData data)
		{
		}

		public void OnPointerUp(PointerEventData data)
		{
		}

		private void OnDrag(Vector2 delta)
		{
		}

		public void OnDrag(PointerEventData data)
		{
		}

		private void OnDrop(GameObject go)
		{
		}

		public void OnDrop(PointerEventData data)
		{
		}

		public void OnScroll(PointerEventData data)
		{
		}

		public void OnUpdateSelected(BaseEventData data)
		{
		}

		private void OnSelect(bool isSelected)
		{
		}

		public void OnSelect(BaseEventData data)
		{
		}

		public void OnDeselect(BaseEventData data)
		{
		}

		public void OnMove(AxisEventData data)
		{
		}

		public void OnInitializePotentialDrag(PointerEventData data)
		{
		}

		public void OnBeginDrag(PointerEventData data)
		{
		}

		public void OnEndDrag(PointerEventData data)
		{
		}

		public void OnSubmit(BaseEventData data)
		{
		}

		public void OnCancel(BaseEventData data)
		{
		}

		private void SliderChanged(float newValue)
		{
		}

		private void ToggleChanged(bool newValue)
		{
		}

		private void ButtonClicked()
		{
		}

		private void OnMouseEnter()
		{
		}

		private void OnMouseExit()
		{
		}

		private void OnMouseDown()
		{
		}

		private void OnMouseUp()
		{
		}

		private void OnMouseDrag()
		{
		}

		private void OnPress(bool isDown)
		{
		}

		private void OnClick()
		{
		}

		private void OnHover(bool isOver)
		{
		}

		private void OnSpawned()
		{
		}

		private void OnDespawned()
		{
		}

		public void ActivateCodeTriggeredEvent1()
		{
		}

		public void ActivateCodeTriggeredEvent2()
		{
		}

		public void CalculateRadius(AudioEvent anEvent)
		{
		}

		public AudioSource GetNamedOrFirstAudioSource(AudioEvent anEvent)
		{
			return null;
		}

		public List<AudioSource> GetAllVariationAudioSources(AudioEvent anEvent)
		{
			return null;
		}

		public AudioEventGroup GetMechanimAudioEventGroup(string stateName)
		{
			return null;
		}

		public bool PlaySounds(AudioEventGroup eventGrp, EventType eType)
		{
			return false;
		}

		private void OnDrawGizmos()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		private static bool CheckForRetriggerLimit(AudioEventGroup grp)
		{
			return false;
		}

		private void PerformSingleAction(AudioEventGroup grp, AudioEvent aEvent, EventType eType)
		{
		}

		private void LogIfCustomEventMissing(AudioEventGroup eventGroup)
		{
		}

		public void CheckForIllegalCustomEvents()
		{
		}

		public void ReceiveEvent(string customEventName, Vector3 originPoint)
		{
		}

		public bool SubscribesToEvent(string customEventName)
		{
			return false;
		}

		public void RegisterReceiver()
		{
		}

		public void UnregisterReceiver()
		{
		}

		public IList<AudioEventGroup> GetAllEvents()
		{
			return null;
		}

		private void AddUGUIComponents()
		{
		}

		private void AddUGUIHandler<T>(bool useSound) where T : EventSoundsUGUIHandler
		{
		}
	}
}
