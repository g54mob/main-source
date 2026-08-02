using System.Collections;
using UnityEngine;

namespace HQFPSTemplate
{
	public class PlayerDeath : PlayerComponent
	{
		[BHeader("Stuff To Disable On Death", true)]
		[SerializeField]
		private GameObject[] m_ObjectsToDisable;

		[SerializeField]
		private Behaviour[] m_BehavioursToDisable;

		[SerializeField]
		private Collider[] m_CollidersToDisable;

		[BHeader("Player Head Hitbox")]
		[SerializeField]
		private Rigidbody m_Head;

		[BHeader("Respawn", true)]
		[SerializeField]
		private bool m_Respawn = true;

		[SerializeField]
		[EnableIf("m_Respawn", true, 0f)]
		private float m_RespawnDuration = 5f;

		[SerializeField]
		[EnableIf("m_Respawn", true, 0f)]
		private bool m_RestartSceneOnRespawn;

		private Transform m_CameraStartParent;

		private Quaternion m_CameraStartRotation;

		private Vector3 m_CameraStartPosition;

		private Vector3 m_HeadStartPosition;

		private Quaternion m_HeadStartRotation;

		public override void OnEntityStart()
		{
			m_Head.isKinematic = true;
			m_Head.gameObject.SetActive(value: false);
			m_CameraStartRotation = base.Player.Camera.transform.localRotation;
			m_CameraStartPosition = base.Player.Camera.transform.localPosition;
			m_CameraStartParent = base.Player.Camera.transform.parent;
			m_HeadStartPosition = m_Head.transform.localPosition;
			m_HeadStartRotation = m_Head.transform.localRotation;
		}

		private void OnChanged_Health(float health)
		{
			if (health == 0f)
			{
				StartCoroutine(C_OnDeath());
			}
		}

		private IEnumerator C_OnDeath()
		{
			base.Player.DropItem.Try(base.Player.EquippedItem.Get());
			yield return null;
			GameObject[] objectsToDisable = m_ObjectsToDisable;
			foreach (GameObject gameObject in objectsToDisable)
			{
				if (gameObject != null)
				{
					gameObject.SetActive(value: false);
				}
				else
				{
					Debug.LogWarning("Check out PlayerDeath for missing references, an object reference was found null!", this);
				}
			}
			Behaviour[] behavioursToDisable = m_BehavioursToDisable;
			foreach (Behaviour behaviour in behavioursToDisable)
			{
				if (behaviour != null)
				{
					behaviour.enabled = false;
				}
				else
				{
					Debug.LogWarning("Check out PlayerDeath for missing references, a behaviour reference was found null!", this);
				}
			}
			Collider[] collidersToDisable = m_CollidersToDisable;
			foreach (Collider collider in collidersToDisable)
			{
				if (collider != null)
				{
					collider.enabled = false;
				}
				else
				{
					Debug.LogWarning("Check out PlayerDeath for missing references, a collider reference was found null!", this);
				}
			}
			base.Player.Camera.transform.parent = m_Head.transform;
			m_Head.gameObject.SetActive(value: true);
			m_Head.isKinematic = false;
			m_Head.AddForce(Vector3.ClampMagnitude(base.Player.Velocity.Get() * 0.5f, 10f), ForceMode.Force);
			m_Head.AddRelativeTorque(new Vector3(Random.value - 0.5f, Random.value - 0.5f, Random.value - 0.5f) * 35f, ForceMode.Force);
			base.Player.Death.Send();
			if (m_Respawn)
			{
				yield return new WaitForSeconds(m_RespawnDuration);
				Respawn();
			}
		}

		private void Respawn()
		{
			if (m_RestartSceneOnRespawn)
			{
				Singleton<GameManager>.Instance.StartGame();
				return;
			}
			Singleton<GameManager>.Instance.SetPlayerPosition();
			base.Player.Camera.transform.parent = m_CameraStartParent;
			base.Player.Camera.transform.localRotation = m_CameraStartRotation;
			base.Player.Camera.transform.localPosition = m_CameraStartPosition;
			m_Head.isKinematic = true;
			m_Head.transform.localPosition = m_HeadStartPosition;
			m_Head.transform.localRotation = m_HeadStartRotation;
			m_Head.gameObject.SetActive(value: false);
			base.Player.Respawn.Send();
			GameObject[] objectsToDisable = m_ObjectsToDisable;
			for (int i = 0; i < objectsToDisable.Length; i++)
			{
				objectsToDisable[i].SetActive(value: true);
			}
			Behaviour[] behavioursToDisable = m_BehavioursToDisable;
			for (int i = 0; i < behavioursToDisable.Length; i++)
			{
				behavioursToDisable[i].enabled = true;
			}
			Collider[] collidersToDisable = m_CollidersToDisable;
			for (int i = 0; i < collidersToDisable.Length; i++)
			{
				collidersToDisable[i].enabled = true;
			}
			if (base.Player.OnLadder.Active)
			{
				base.Player.OnLadder.TryStop();
			}
			if (base.Player.Run.Active)
			{
				base.Player.Run.ForceStop();
			}
			if (base.Player.Crouch.Active)
			{
				base.Player.Crouch.TryStop();
			}
			if (base.Player.Prone.Active)
			{
				base.Player.Prone.TryStop();
			}
			if (base.Player.Swimming.Active)
			{
				base.Player.Swimming.TryStop();
			}
			base.Player.MoveInput.Set(Vector2Int.zero);
			base.Player.RaycastInfo.Set(null);
			base.Player.Health.Set(100f);
			base.Player.Stamina.Set(100f);
		}
	}
}
