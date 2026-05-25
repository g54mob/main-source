using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HumanAPI
{
	[AddComponentMenu("Human/Level/Level", 10)]
	public class Level : MonoBehaviour
	{
		public delegate void PreRespawnDelegate(int checkpoint, bool startingLevel);

		public uint netHash = 57005u;

		public bool keepSkybox;

		public bool noClouds;

		public Transform spawnPoint;

		public Color fogColor;

		public float fogDensity;

		public bool nonLinearCheckpoints;

		public bool HasWeather;

		public float MaxHumanVelocity = 150f;

		[NonSerialized]
		public Transform[] checkpoints;

		[NonSerialized]
		public PreRespawnDelegate prerespawn;

		[NonSerialized]
		public bool respawnLocked;

		private bool isActive;

		private bool isClient;

		private List<Checkpoint> checkpointsList;

		public List<Rigidbody[]> chains = new List<Rigidbody[]>();

		public Vector3[] cachedPos;

		public Quaternion[] cachedRot;

		public bool active
		{
			get
			{
				return isActive;
			}
		}

		protected virtual void OnEnable()
		{
			fogColor = RenderSettings.fogColor;
			fogDensity = RenderSettings.fogDensity;
			isClient = Dependencies.Get<IGame>().LevelLoaded(this);
			Checkpoint[] componentsInChildren = GetComponentsInChildren<Checkpoint>();
			checkpointsList = new List<Checkpoint>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].subObjective == 0)
				{
					checkpointsList.Add(componentsInChildren[i]);
				}
			}
			checkpoints = new Transform[checkpointsList.Count];
			checkpointsList = checkpointsList.OrderBy((Checkpoint x) => x.number).ToList();
			if (checkpointsList[0].number != 0)
			{
				checkpointsList[0].number = 0;
				for (int num = 1; num < checkpointsList.Count; num++)
				{
					checkpointsList[num].number = num;
				}
			}
			for (int num2 = 0; num2 < checkpointsList.Count; num2++)
			{
				checkpoints[checkpointsList[num2].number] = checkpointsList[num2].transform;
			}
			for (int num3 = 0; num3 < checkpoints.Length; num3++)
			{
				if (checkpoints[num3] == null)
				{
					throw new InvalidOperationException("Checkpoint " + num3 + " missing");
				}
			}
		}

		public virtual void Reset(int checkpoint, int subObjectives)
		{
			IPreReset[] componentsInChildren = GetComponentsInChildren<IPreReset>(true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].PreResetState(checkpoint);
			}
			IReset[] componentsInChildren2 = GetComponentsInChildren<IReset>(true);
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				componentsInChildren2[j].ResetState(checkpoint, subObjectives);
			}
			IPostReset[] componentsInChildren3 = GetComponentsInChildren<IPostReset>(true);
			for (int k = 0; k < componentsInChildren3.Length; k++)
			{
				componentsInChildren3[k].PostResetState(checkpoint);
			}
		}

		public void PostEndReset(int checkpoint)
		{
			IPostEndReset[] componentsInChildren = GetComponentsInChildren<IPostEndReset>(true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].PostEndResetState(checkpoint);
			}
		}

		public virtual void BeginLevel()
		{
			isActive = true;
			HumanBase[] array = UnityEngine.Object.FindObjectsOfType<HumanBase>();
			HumanBase[] array2 = array;
			foreach (HumanBase humanBase in array2)
			{
				IBeginLevel[] componentsInChildren = humanBase.GetComponentsInChildren<IBeginLevel>();
				IBeginLevel[] array3 = componentsInChildren;
				foreach (IBeginLevel beginLevel in array3)
				{
					beginLevel.BeginLevel();
				}
			}
		}

		public virtual void CompleteLevel()
		{
			isActive = false;
			Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].isTrigger)
				{
					componentsInChildren[i].enabled = false;
				}
			}
		}

		public Transform GetCheckpointTransform(int checkpoint)
		{
			return checkpoints[checkpoint];
		}

		public Checkpoint GetCheckpoint(int checkpointID)
		{
			return checkpointsList[checkpointID];
		}

		protected virtual void Awake()
		{
			chains = new List<Rigidbody[]>();
			Rigidbody[] componentsInChildren = GetComponentsInChildren<Rigidbody>();
			Rigidbody[] array = componentsInChildren;
			foreach (Rigidbody rigidbody in array)
			{
				Rigidbody[] componentsInParent = rigidbody.GetComponentsInParent<Rigidbody>();
				if (componentsInParent.Length > 0)
				{
					chains.Add(componentsInParent);
				}
			}
			cachedPos = new Vector3[chains.Count];
			cachedRot = new Quaternion[chains.Count];
			for (int j = 0; j < chains.Count; j++)
			{
				Rigidbody rigidbody2 = chains[j][0];
				cachedPos[j] = rigidbody2.position;
				cachedRot[j] = rigidbody2.rotation;
			}
		}

		private void LateUpdate()
		{
			if (isClient)
			{
				return;
			}
			for (int i = 0; i < chains.Count; i++)
			{
				Rigidbody[] array = chains[i];
				Rigidbody rigidbody = array[0];
				if (rigidbody.IsSleeping())
				{
					for (int j = 1; j < array.Length; j++)
					{
						if (!array[j].IsSleeping())
						{
							rigidbody.transform.position = cachedPos[i];
							rigidbody.transform.rotation = cachedRot[i];
							break;
						}
					}
				}
				else
				{
					cachedPos[i] = rigidbody.position;
					cachedRot[i] = rigidbody.rotation;
				}
			}
		}

		public void ForceRecacheRigid(Rigidbody bodyToRecache)
		{
			for (int i = 0; i < chains.Count; i++)
			{
				if (chains[i].Length > 0 && chains[i][0] == bodyToRecache)
				{
					cachedPos[i] = bodyToRecache.position;
					cachedRot[i] = bodyToRecache.rotation;
				}
			}
		}
	}
}
