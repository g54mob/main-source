using JUTPS.InventorySystem;
using JUTPS.PhysicsScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JUTPS
{
	[AddComponentMenu("JU TPS/Scene Management/Scene Controller")]
	public class SceneController : MonoBehaviour
	{
		private JUCharacterController pl;

		public bool ReloadLevelWhenDie;

		public float SecondsToRespawnOrReloadLevel = 4f;

		public bool JustRespawnPlayer;

		private Vector3 SpawnPlayerPostion;

		private bool isInitialized;

		private void OnEnable()
		{
			Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.AddListener(Initialize);
		}

		private void OnDisable()
		{
			Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.RemoveListener(Initialize);
		}

		private void Initialize(TSPlayerController tsPlayer)
		{
			pl = tsPlayer.gameObject?.GetComponent<JUCharacterController>();
			SpawnPlayerPostion = ((pl != null) ? pl.transform.position : Vector3.zero);
		}

		private void Update()
		{
			if (!(pl == null))
			{
				if (pl.IsDead && !IsInvoking("ResetLevel") && ReloadLevelWhenDie && !JustRespawnPlayer)
				{
					Invoke("ResetLevel", SecondsToRespawnOrReloadLevel);
				}
				if (pl.IsDead && !IsInvoking("RespawnPlayer") && JustRespawnPlayer)
				{
					Invoke("RespawnPlayer", SecondsToRespawnOrReloadLevel);
				}
			}
		}

		public void ResetLevel()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		public void RespawnPlayer()
		{
			if (pl.TryGetComponent<AdvancedRagdollController>(out var component))
			{
				pl.anim.GetBoneTransform(HumanBodyBones.Hips).SetParent(component.HipsParent);
				component.State = AdvancedRagdollController.RagdollState.BlendToAnim;
				component.TimeToGetUp = 2f;
				component.BlendAmount = 0f;
				component.SetActiveRagdoll(Enabled: false);
				pl.enableMove();
			}
			else
			{
				pl.enableMove();
			}
			pl.transform.position = SpawnPlayerPostion;
			pl.CharacterHealth.Health = pl.CharacterHealth.MaxHealth;
			pl.IsDead = false;
			pl.gameObject.layer = 9;
			pl.GetComponent<Collider>().isTrigger = false;
			pl.GetComponent<Collider>().enabled = true;
			pl.GetComponent<Rigidbody>().useGravity = true;
			pl.GetComponent<Rigidbody>().isKinematic = false;
			pl.GetComponent<Rigidbody>().velocity = base.transform.up * pl.GetComponent<Rigidbody>().velocity.y;
			pl.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
			pl.enabled = true;
			pl.GetComponent<JUInventory>().IsALoot = false;
			pl.anim.enabled = true;
			pl.anim.SetBool(pl.AnimatorParameters.Dying, value: false);
			pl.anim.Play("Locomotion Blend Tree", 0);
			pl.ResetDefaultLayersWeight();
			if (pl.HoldableItemInUseRightHand != null)
			{
				pl.SwitchToItem();
			}
			Debug.Log("Player has respawned");
		}

		public void SetRespawnPosition(Vector3 position)
		{
			SpawnPlayerPostion = position;
		}
	}
}
