using System.Collections;
using UnityEngine;

namespace HQFPSTemplate
{
	public class PlayerInteraction : PlayerComponent
	{
		public enum LoopingMethod
		{
			EveryFrame = 0,
			EveryFrameFixed = 1,
			Periodically = 2
		}

		[SerializeField]
		private LayerMask m_LayerMask;

		[Space]
		[SerializeField]
		[Tooltip("The looping method used for updating the interaction system.")]
		private LoopingMethod m_LoopingMethod;

		[SerializeField]
		[ShowIf("m_LoopingMethod", 2, 10f)]
		private float m_UpdateTime = 0.03f;

		[Space]
		[SerializeField]
		[Tooltip("The maximum distance at which you can interact with objects.")]
		private float m_InteractionDistance = 2f;

		[SerializeField]
		[Range(0f, 60f)]
		private float m_MaxInteractionAngle = 30f;

		private InteractiveObject m_InteractedObject;

		private InteractiveObject m_ClosestObject;

		private Collider[] m_CollidersInRange;

		private Transform m_WorldCamera;

		private int m_ClosestObjectIndex = -1;

		private float m_SmallestAngle;

		private void Start()
		{
			base.Player.Death.AddListener(delegate
			{
				StopAllCoroutines();
			});
			m_WorldCamera = base.Player.Camera.UnityCamera.transform;
		}

		private void OnEnable()
		{
			base.Player.Interact.AddChangeListener(OnChanged_WantsToInteract);
			if (m_LoopingMethod == LoopingMethod.Periodically)
			{
				StartCoroutine(C_UpdateInteraction());
			}
		}

		private void Update()
		{
			if (m_LoopingMethod == LoopingMethod.EveryFrame)
			{
				UpdateInteraction();
			}
		}

		private void FixedUpdate()
		{
			if (m_LoopingMethod == LoopingMethod.EveryFrameFixed)
			{
				UpdateInteraction();
			}
		}

		private IEnumerator C_UpdateInteraction()
		{
			WaitForSeconds wait = new WaitForSeconds(Mathf.Max(m_UpdateTime, 0.01f));
			while (base.enabled)
			{
				UpdateInteraction();
				yield return wait;
			}
		}

		private void OnChanged_WantsToInteract(bool wantsToInteract)
		{
			RaycastInfo raycastInfo = base.Player.RaycastInfo.Get();
			bool previousValue = base.Player.Interact.GetPreviousValue();
			bool flag = wantsToInteract;
			if (raycastInfo != null && raycastInfo.IsInteractive && !previousValue && flag)
			{
				raycastInfo.InteractiveObject.OnInteractionStart(base.Player);
				m_InteractedObject = raycastInfo.InteractiveObject;
			}
			if (m_InteractedObject != null && previousValue && !flag)
			{
				m_InteractedObject.OnInteractionEnd(base.Player);
				m_InteractedObject = null;
			}
		}

		private void UpdateInteraction()
		{
			RaycastInfo raycastInfo = base.Player.RaycastInfo.Get();
			m_SmallestAngle = 1000f;
			m_ClosestObject = null;
			m_ClosestObjectIndex = -1;
			Vector3 position = m_WorldCamera.transform.position;
			Vector3 forward = m_WorldCamera.transform.forward;
			if (Physics.Raycast(position, forward, out var hitInfo, m_InteractionDistance, m_LayerMask, QueryTriggerInteraction.Collide) && hitInfo.collider.TryGetComponent<InteractiveObject>(out var component))
			{
				m_ClosestObject = component;
				m_SmallestAngle = 0f;
				m_ClosestObjectIndex = 0;
				m_CollidersInRange = new Collider[1];
				m_CollidersInRange[0] = hitInfo.collider;
			}
			if (m_ClosestObject == null)
			{
				m_CollidersInRange = Physics.OverlapSphere(m_WorldCamera.transform.position, m_InteractionDistance, m_LayerMask, QueryTriggerInteraction.Collide);
				for (int i = 0; i < m_CollidersInRange.Length; i++)
				{
					if (m_CollidersInRange[i].TryGetComponent<InteractiveObject>(out var component2) && Physics.Linecast(position, component2.transform.position + (component2.transform.position - position).normalized * 0.05f, out var hitInfo2, m_LayerMask) && (hitInfo2.collider == null || hitInfo2.collider == m_CollidersInRange[i]))
					{
						float num = Vector3.Angle(forward, component2.transform.position - position);
						if (num < m_SmallestAngle)
						{
							m_SmallestAngle = num;
							m_ClosestObject = component2;
							m_ClosestObjectIndex = i;
						}
					}
				}
			}
			if (m_SmallestAngle < m_MaxInteractionAngle && ((raycastInfo != null && raycastInfo.Collider != m_CollidersInRange[m_ClosestObjectIndex]) || raycastInfo == null))
			{
				RaycastInfo raycastInfo2 = new RaycastInfo(m_CollidersInRange[m_ClosestObjectIndex], m_ClosestObject);
				base.Player.RaycastInfo.Set(raycastInfo2);
				if (raycastInfo2 != null && raycastInfo2.IsInteractive)
				{
					raycastInfo2.InteractiveObject.OnRaycastStart(base.Player);
				}
				if (raycastInfo != null && raycastInfo.InteractiveObject != null)
				{
					raycastInfo.InteractiveObject.OnRaycastEnd(base.Player);
				}
			}
			else if (m_SmallestAngle > m_MaxInteractionAngle)
			{
				base.Player.RaycastInfo.Set(null);
				if (raycastInfo != null && raycastInfo.IsInteractive && raycastInfo.IsInteractive)
				{
					raycastInfo.InteractiveObject.OnRaycastEnd(base.Player);
				}
			}
			if (m_InteractedObject != null)
			{
				m_InteractedObject.OnInteractionUpdate(base.Player);
			}
		}
	}
}
