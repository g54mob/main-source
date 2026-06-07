using System.Collections.Generic;
using UnityEngine;

namespace GamingIsLove.Footsteps
{
	[AddComponentMenu("Footstepper/Footstep Manager")]
	public class FootstepManager : MonoBehaviour
	{
		[Tooltip("Prefabs spawned by footstep effects will be disabled instead of destroyed to reuse them again.\nThis can improve performance.")]
		public bool usePrefabPool = true;

		[Tooltip("Prevents the footstep manager from being destroyed when changing scenes.\nUses 'GameObject.DontDestroyOnLoad' to prevent the game object's destruction.")]
		public bool keepAlive;

		[Tooltip("The manager's texture materials are used to find footstep effects based on the texture that was hit by the raycast.\nIt's used if a 'Terrain Footstep Source' didn't find an effect or if the raycast didn't hit any footstep source.")]
		public List<FootstepTextureMaterial> textureMaterials = new List<FootstepTextureMaterial>();

		[Tooltip("Set a player 'Footstepper' component to allow only footsteppers within a defined distance to the player.\nCan be set via code to change the player in-game.")]
		[Space(20f)]
		public Footstepper player;

		[Tooltip("The distance (in world units) to the player any non-player footstepper can play footsteps.")]
		public float allowedDistanceToPlayer = 50f;

		protected static FootstepManager instance;

		protected Dictionary<GameObject, Queue<GameObject>> prefabPool = new Dictionary<GameObject, Queue<GameObject>>();

		public static FootstepManager Instance => instance;

		protected virtual void Awake()
		{
			instance = this;
			if (keepAlive)
			{
				Object.DontDestroyOnLoad(base.gameObject);
			}
		}

		public static bool IsAllowed(Footstepper footstepper)
		{
			if (!(instance == null) && !(instance.player == null) && !(instance.player == footstepper))
			{
				return Vector3.Distance(instance.player.transform.position, footstepper.transform.position) <= instance.allowedDistanceToPlayer;
			}
			return true;
		}

		public Queue<GameObject> GetPool(GameObject prefab)
		{
			if (usePrefabPool)
			{
				if (!prefabPool.TryGetValue(prefab, out var value))
				{
					value = new Queue<GameObject>();
					prefabPool.Add(prefab, value);
				}
				return value;
			}
			return null;
		}

		public virtual FootstepEffect GetFootstepFor(Texture texture, string effectTag)
		{
			if (textureMaterials.Count > 0 && texture != null)
			{
				for (int i = 0; i < textureMaterials.Count; i++)
				{
					FootstepEffect effect = textureMaterials[i].GetEffect(texture, effectTag);
					if (effect != null)
					{
						return effect;
					}
				}
			}
			return null;
		}

		public virtual FootstepEffect GetFootstepFor(Sprite sprite, string effectTag)
		{
			if (textureMaterials.Count > 0 && sprite != null)
			{
				for (int i = 0; i < textureMaterials.Count; i++)
				{
					FootstepEffect effect = textureMaterials[i].GetEffect(sprite, effectTag);
					if (effect != null)
					{
						return effect;
					}
				}
			}
			return null;
		}

		protected virtual void OnDrawGizmos()
		{
			Gizmos.DrawIcon(base.transform.position, "/GamingIsLove/Footsteps/FootstepManager Icon.png");
		}
	}
}
