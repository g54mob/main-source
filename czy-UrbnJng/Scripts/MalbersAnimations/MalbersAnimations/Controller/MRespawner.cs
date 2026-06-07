using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace MalbersAnimations.Controller
{
	[AddComponentMenu("Malbers/Animal Controller/Respawner")]
	public class MRespawner : MonoBehaviour
	{
		public static MRespawner instance;

		[Tooltip("Animal Prefab to Swpawn")]
		[FormerlySerializedAs("playerPrefab")]
		public GameObject player;

		public StateID RespawnState;

		public FloatReference RespawnTime = new FloatReference(4f);

		[Tooltip("If True: it will destroy the MainPlayer GameObject and Respawn a new One")]
		public BoolReference DestroyAfterRespawn = new BoolReference(value: true);

		[Tooltip("The Respawner will be kept between scenes")]
		public BoolReference m_DontDestroyOnLoad = new BoolReference(value: true);

		[Tooltip("Restart Scene After Death")]
		public BoolReference RestartScene = new BoolReference();

		private GameObject InstantiatedPlayer;

		private MAnimal activeAnimal;

		private GameObject oldPlayer;

		[FormerlySerializedAs("OnRestartGame")]
		public GameObjectEvent OnRespawned = new GameObjectEvent();

		private bool Respawned;

		private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
		{
			FindMainAnimal();
		}

		public virtual void SetPlayer(GameObject go)
		{
			player = go;
		}

		private void OnEnable()
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			if (instance == null)
			{
				instance = this;
				base.transform.parent = null;
				if ((bool)m_DontDestroyOnLoad)
				{
					Object.DontDestroyOnLoad(base.gameObject);
				}
				base.gameObject.name = base.gameObject.name + " Instance";
				SceneManager.sceneLoaded += OnLevelFinishedLoading;
				FindMainAnimal();
			}
			else
			{
				Object.Destroy(base.gameObject);
			}
		}

		private void OnDisable()
		{
			if (instance == this)
			{
				SceneManager.sceneLoaded -= OnLevelFinishedLoading;
				if (activeAnimal != null)
				{
					activeAnimal.OnStateChange.RemoveListener(OnCharacterDead);
				}
			}
		}

		public void ResetScene()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			Respawned = false;
		}

		public void ResetRespawner(GameObject newPlayer)
		{
			Respawned = false;
			if (activeAnimal != null)
			{
				activeAnimal.OnStateChange.RemoveListener(OnCharacterDead);
			}
			SetPlayer(newPlayer);
			if (player == null)
			{
				activeAnimal = MAnimal.MainAnimal;
				if ((bool)activeAnimal)
				{
					player = activeAnimal.gameObject;
				}
			}
			if (player != null)
			{
				if (player.IsPrefab())
				{
					InstantiateNewPlayer();
				}
				else if (player.TryGetComponent<MAnimal>(out activeAnimal))
				{
					activeAnimal.OnStateChange.AddListener(OnCharacterDead);
					activeAnimal.OverrideStartState = RespawnState;
					activeAnimal.SetMainPlayer();
					Respawned = true;
				}
			}
		}

		public virtual void FindMainAnimal()
		{
			if (Respawned)
			{
				return;
			}
			if (player == null)
			{
				activeAnimal = MAnimal.MainAnimal;
				if ((bool)activeAnimal)
				{
					player = activeAnimal.gameObject;
				}
			}
			if (player != null)
			{
				if (player.IsPrefab())
				{
					InstantiateNewPlayer();
				}
				else if (player.TryGetComponent<MAnimal>(out activeAnimal))
				{
					SceneAnimal();
				}
			}
			if (player != null && activeAnimal != null)
			{
				Death death = activeAnimal.State_Get<Death>();
				if ((bool)death)
				{
					death.disableAnimal = false;
					death.DisableAllComponents = false;
					death.DisableInternalColliders = false;
					death.DisableMainCollider = false;
				}
			}
		}

		private void SceneAnimal()
		{
			activeAnimal.OnStateChange.AddListener(OnCharacterDead);
			activeAnimal.Teleport_Internal(base.transform.position);
			activeAnimal.transform.rotation = base.transform.rotation;
			activeAnimal.OverrideStartState = RespawnState;
			activeAnimal.InputSource?.Enable(val: true);
			if ((bool)activeAnimal.MainCollider)
			{
				activeAnimal.MainCollider.enabled = true;
			}
			activeAnimal.SetMainPlayer();
			activeAnimal.Anim.Rebind();
			Respawned = true;
		}

		public void OnCharacterDead(int StateID)
		{
			if (!Respawned || StateID != StateEnum.Death)
			{
				return;
			}
			oldPlayer = InstantiatedPlayer;
			activeAnimal.OnStateChange.RemoveListener(OnCharacterDead);
			if (!(player != null))
			{
				return;
			}
			if (player.IsPrefab())
			{
				this.Delay_Action(RespawnTime, delegate
				{
					DestroyDeathPlayer();
					this.Delay_Action(delegate
					{
						InstantiateNewPlayer();
					});
				});
				return;
			}
			if (RestartScene.Value)
			{
				this.Delay_Action(RespawnTime, delegate
				{
					ResetScene();
				});
				return;
			}
			this.Delay_Action(RespawnTime, delegate
			{
				SceneAnimal();
				if (!activeAnimal.enabled)
				{
					activeAnimal.enabled = true;
				}
				else
				{
					activeAnimal.ResetController();
				}
			});
		}

		private void DestroyDeathPlayer()
		{
			if (oldPlayer != null)
			{
				if ((bool)DestroyAfterRespawn)
				{
					Object.Destroy(oldPlayer);
				}
				else
				{
					DestroyAllComponents(oldPlayer);
				}
			}
		}

		private void InstantiateNewPlayer()
		{
			InstantiatedPlayer = Object.Instantiate(player, base.transform.position, base.transform.rotation);
			activeAnimal = InstantiatedPlayer.GetComponent<MAnimal>();
			activeAnimal.OverrideStartState = RespawnState;
			activeAnimal.OnStateChange.AddListener(OnCharacterDead);
			OnRespawned.Invoke(InstantiatedPlayer);
			activeAnimal.SetMainPlayer();
			Respawned = true;
		}

		private void DestroyAllComponents(GameObject target)
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
