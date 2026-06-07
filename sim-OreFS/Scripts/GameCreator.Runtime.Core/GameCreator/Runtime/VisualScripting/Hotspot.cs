using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameCreator.Runtime.VisualScripting
{
	[HelpURL("https://docs.gamecreator.io/gamecreator/visual-scripting/hotspots")]
	[AddComponentMenu("Game Creator/Visual Scripting/Hotspot")]
	[DefaultExecutionOrder(1)]
	public class Hotspot : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public enum HotspotMode
		{
			InRadius = 0,
			OnInteractionFocus = 1,
			OnInteractionReach = 2,
			AlwaysActive = 3
		}

		private static readonly Color GIZMOS_COLOR = Color.red;

		private const float TRANSITION_SMOOTH_TIME = 0.25f;

		private const float GIZMOS_ALPHA_ON = 0.25f;

		private const float GIZMOS_ALPHA_OFF = 0.1f;

		[SerializeField]
		protected PropertyGetGameObject m_Target = GetGameObjectPlayer.Create();

		[SerializeField]
		private HotspotMode m_Mode;

		[SerializeField]
		private PropertyGetDecimal m_Radius = GetDecimalDecimal.Create(10f);

		[SerializeField]
		protected SpotList m_Spots = new SpotList();

		[NonSerialized]
		private float m_Velocity;

		public static bool ActiveInRadius { get; set; } = true;

		public static bool ActiveInteractive { get; set; } = true;

		public static bool ActiveAlways { get; set; } = true;

		public GameObject Target => m_Target.Get(Args);

		[field: NonSerialized]
		public Args Args { get; private set; }

		[field: NonSerialized]
		public bool IsActive { get; private set; }

		[field: NonSerialized]
		public float Animation { get; private set; }

		[field: NonSerialized]
		public float Distance { get; private set; }

		public event Action EventOnActivate;

		public event Action EventOnDeactivate;

		private void Awake()
		{
			Args = new Args(this);
			m_Spots.OnAwake(this);
		}

		private void Start()
		{
			m_Spots.OnStart(this);
		}

		private void Update()
		{
			if (m_Mode == HotspotMode.OnInteractionFocus || m_Mode == HotspotMode.OnInteractionReach)
			{
				InteractionTracker.Require(base.gameObject);
			}
			bool isActive = IsActive;
			switch (m_Mode)
			{
			case HotspotMode.InRadius:
				UpdateInRadius();
				break;
			case HotspotMode.OnInteractionFocus:
				UpdateInFocus();
				break;
			case HotspotMode.OnInteractionReach:
				UpdateInRange();
				break;
			case HotspotMode.AlwaysActive:
				UpdateAlwaysActive();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			Animation = ((unscaledDeltaTime > float.Epsilon) ? Mathf.SmoothDamp(Animation, IsActive ? 1f : 0f, ref m_Velocity, 0.25f, float.PositiveInfinity, unscaledDeltaTime) : Animation);
			m_Spots.OnUpdate(this);
			if (!isActive)
			{
				if (IsActive)
				{
					this.EventOnActivate?.Invoke();
				}
			}
			else if (!IsActive)
			{
				this.EventOnDeactivate?.Invoke();
			}
		}

		private void OnEnable()
		{
			m_Velocity = 0f;
			Animation = 0f;
			m_Spots.OnEnable(this);
		}

		private void OnDisable()
		{
			m_Velocity = 0f;
			Animation = 0f;
			m_Spots.OnDisable(this);
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData pointerEventData)
		{
			m_Spots.OnPointerEnter(this);
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData pointerEventData)
		{
			m_Spots.OnPointerExit(this);
		}

		public float GetRadius(Args args)
		{
			switch (m_Mode)
			{
			case HotspotMode.InRadius:
				return (float)m_Radius.Get(args);
			case HotspotMode.OnInteractionFocus:
			case HotspotMode.OnInteractionReach:
			{
				Character character = m_Target.Get<Character>(args);
				if (!(character != null))
				{
					return 0f;
				}
				return character.Motion.InteractionRadius;
			}
			case HotspotMode.AlwaysActive:
				return float.PositiveInfinity;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		private void UpdateInRadius()
		{
			if (!ActiveInRadius)
			{
				IsActive = false;
				return;
			}
			GameObject target = Target;
			if (target == null)
			{
				IsActive = false;
				Distance = float.MaxValue;
			}
			else
			{
				Distance = Vector3.Distance(target.transform.position, base.transform.position);
				double num = m_Radius.Get(Args);
				IsActive = (double)Distance <= num;
			}
		}

		private void UpdateInFocus()
		{
			if (!ActiveInteractive)
			{
				IsActive = false;
				return;
			}
			GameObject target = Target;
			Character character = target.Get<Character>();
			if (target == null || character == null)
			{
				IsActive = false;
				Distance = float.MaxValue;
			}
			else
			{
				Distance = Vector3.Distance(target.transform.position, base.transform.position);
				IsActive = character.Interaction.Target?.Instance == base.gameObject;
			}
		}

		private void UpdateInRange()
		{
			if (!ActiveInteractive)
			{
				IsActive = false;
				return;
			}
			GameObject target = Target;
			Character character = target.Get<Character>();
			if (target == null || character == null)
			{
				IsActive = false;
				Distance = float.MaxValue;
				return;
			}
			Distance = Vector3.Distance(target.transform.position, base.transform.position);
			if (base.gameObject == character.Interaction.Target?.Instance)
			{
				IsActive = false;
				return;
			}
			bool isActive = false;
			foreach (ISpatialHash interaction in character.Interaction.Interactions)
			{
				if (interaction is IInteractive interactive && interactive.Instance == base.gameObject)
				{
					isActive = Vector3.Distance(interactive.Position, character.transform.position) <= character.Motion.InteractionRadius;
					break;
				}
			}
			IsActive = isActive;
		}

		private void UpdateAlwaysActive()
		{
			IsActive = ActiveAlways;
			GameObject target = Target;
			Distance = ((target != null) ? Vector3.Distance(target.transform.position, base.transform.position) : 2.1474836E+09f);
		}

		private void OnDrawGizmosSelected()
		{
			float a = Mathf.Lerp(0.1f, 0.25f, IsActive ? 1f : 0f);
			Gizmos.color = new Color(GIZMOS_COLOR.r, GIZMOS_COLOR.g, GIZMOS_COLOR.b, a);
			if (m_Mode == HotspotMode.InRadius)
			{
				GizmosExtension.Octahedron(base.transform.position, base.transform.rotation, (float)m_Radius.EditorValue);
			}
			m_Spots.OnGizmos(this);
			if (Application.isPlaying && Target != null)
			{
				Gizmos.DrawLine(Target.transform.position, base.transform.position);
			}
		}
	}
}
