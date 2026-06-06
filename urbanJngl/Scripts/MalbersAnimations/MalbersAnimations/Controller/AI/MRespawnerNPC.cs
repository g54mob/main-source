using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace MalbersAnimations.Controller.AI
{
	[AddComponentMenu("Malbers/Animal Controller/Respawner NPC")]
	public class MRespawnerNPC : MonoBehaviour
	{
		[Tooltip("Animal Prefab to Swpawn")]
		public MAnimal NPC;

		public StateID RespawnState;

		public FloatReference RespawnTime = new FloatReference(10f);

		[Tooltip("If True: it will destroy the MainPlayer GameObject and Respawn a new One")]
		public BoolReference DestroyAfterRespawn = new BoolReference(value: true);

		private MAnimal ActiveAnimal;

		[FormerlySerializedAs("OnRestartGame")]
		public GameObjectEvent OnRespawned = new GameObjectEvent();

		private bool Respawned;

		private MAnimalBrain NPCBrain;

		private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
		{
			FindNPCAnimal();
		}

		public virtual void DontDestroyOnLoad_GameObject(GameObject gameObject)
		{
			Object.DontDestroyOnLoad(gameObject);
		}

		private void OnEnable()
		{
			if (base.isActiveAndEnabled)
			{
				base.transform.parent = null;
				Object.DontDestroyOnLoad(base.transform);
				base.gameObject.name = base.gameObject.name + " Instance";
				SceneManager.sceneLoaded += OnLevelFinishedLoading;
				FindNPCAnimal();
			}
		}

		private void OnDisable()
		{
			SceneManager.sceneLoaded -= OnLevelFinishedLoading;
			if (ActiveAnimal != null)
			{
				ActiveAnimal.OnStateChange.RemoveListener(OnCharacterDead);
			}
		}

		private void FindNPCAnimal()
		{
			if (Respawned)
			{
				return;
			}
			if (NPC != null)
			{
				if (NPC.gameObject.IsPrefab())
				{
					ActiveAnimal = Object.Instantiate(NPC);
				}
				else
				{
					ActiveAnimal = NPC;
				}
				SceneAnimal();
			}
			else
			{
				Debug.LogWarning("[Respawner Removed]. There's no Character assigned", this);
				Object.Destroy(base.gameObject);
			}
		}

		private void SceneAnimal()
		{
			ActiveAnimal.OverrideStartState = RespawnState;
			ActiveAnimal.ResetController();
			ActiveAnimal.enabled = true;
			ActiveAnimal.OnStateChange.AddListener(OnCharacterDead);
			ActiveAnimal.Teleport_Internal(base.transform.position);
			ActiveAnimal.transform.rotation = base.transform.rotation;
			ActiveAnimal.isPlayer.Value = false;
			Respawned = true;
			NPCBrain = ActiveAnimal.GetComponentInChildren<MAnimalBrain>();
			if (NPCBrain != null)
			{
				NPCBrain.enabled = true;
			}
		}

		public void OnCharacterDead(int StateID)
		{
			if (!Respawned || StateID != StateEnum.Death)
			{
				return;
			}
			ActiveAnimal.OnStateChange.RemoveListener(OnCharacterDead);
			Respawned = false;
			if (!(NPC != null))
			{
				return;
			}
			if (NPC.gameObject.IsPrefab())
			{
				this.Delay_Action(RespawnTime, delegate
				{
					DestroyCurrentDeathAnimal();
					this.Delay_Action(delegate
					{
						FindNPCAnimal();
					});
				});
				return;
			}
			Death obj = ActiveAnimal.activeState as Death;
			obj.disableAnimal = false;
			obj.DisableAllComponents = false;
			obj.DisableInternalColliders = false;
			this.Delay_Action(RespawnTime, delegate
			{
				SceneAnimal();
			});
		}

		private void DestroyCurrentDeathAnimal()
		{
			if (ActiveAnimal != null)
			{
				if ((bool)DestroyAfterRespawn)
				{
					Object.Destroy(ActiveAnimal.gameObject);
				}
				else
				{
					DestroyAllComponents(ActiveAnimal);
				}
			}
		}

		private void DestroyAllComponents(MAnimal target)
		{
			if (!target)
			{
				return;
			}
			MonoBehaviour[] componentsInChildren = target.GetComponentsInChildren<MonoBehaviour>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Object.Destroy(componentsInChildren[i]);
			}
			Collider[] componentsInChildren2 = target.GetComponentsInChildren<Collider>();
			if (componentsInChildren2 != null)
			{
				Collider[] array = componentsInChildren2;
				for (int i = 0; i < array.Length; i++)
				{
					Object.Destroy(array[i]);
				}
			}
			Rigidbody componentInChildren = target.GetComponentInChildren<Rigidbody>();
			if (componentInChildren != null)
			{
				Object.Destroy(componentInChildren);
			}
			Animator componentInChildren2 = target.GetComponentInChildren<Animator>();
			if (componentInChildren2 != null)
			{
				Object.Destroy(componentInChildren2);
			}
		}
	}
}
