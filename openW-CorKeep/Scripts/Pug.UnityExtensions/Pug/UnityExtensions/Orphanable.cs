using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pug.UnityExtensions
{
	public class Orphanable : MonoBehaviour, IPreDisable
	{
		private class Reclaimer : MonoBehaviour
		{
			public List<Orphanable> possessions = new List<Orphanable>(16);

			private void OnEnable()
			{
				foreach (Orphanable possession in possessions)
				{
					possession.Reparent();
				}
			}

			public void OnDestroy()
			{
				foreach (Orphanable possession in possessions)
				{
					possession.DeadParent();
				}
			}
		}

		private class Backup
		{
			public readonly string name;

			public readonly Transform parent;

			public readonly Vector3 localPosition;

			public readonly Vector3 localScale;

			public readonly Quaternion localRotation;

			public Backup(Transform t)
			{
				name = t.name;
				parent = t.parent;
				localPosition = t.localPosition;
				localScale = t.localScale;
				localRotation = t.localRotation;
			}

			public void Apply(Transform t)
			{
				t.name = name;
				t.SetParent(parent.transform, worldPositionStays: false);
				t.localPosition = localPosition;
				t.localScale = localScale;
				t.localRotation = localRotation;
			}
		}

		public float autoReparentTimeout = 5f;

		[NonSerialized]
		private TimerSimple autoReparent;

		[NonSerialized]
		private bool selfDestruct;

		[NonSerialized]
		private Backup backup;

		public GameObject root;

		public bool reparentToNull;

		private bool initialized;

		private static List<GameObject> preallocGameObjects = new List<GameObject>(256);

		private static List<Orphanable> preallocOrphanables = new List<Orphanable>(64);

		private void Start()
		{
			autoReparent = new TimerSimple(autoReparentTimeout);
			Reclaimer reclaimer = base.transform.parent.GetComponent<Reclaimer>();
			if (!reclaimer)
			{
				reclaimer = base.transform.parent.gameObject.AddComponent<Reclaimer>();
			}
			reclaimer.possessions.Add(this);
			backup = new Backup(base.transform);
			base.enabled = false;
			initialized = true;
		}

		private void Detach()
		{
			Transform parent = (reparentToNull ? null : root.transform.parent);
			base.transform.SetParent(parent, worldPositionStays: false);
			autoReparent.Start(autoReparentTimeout);
			base.enabled = true;
		}

		public void Reparent()
		{
			autoReparent.Stop();
			if (selfDestruct)
			{
				base.gameObject.Destroy_Clean();
				return;
			}
			backup.Apply(base.transform);
			base.enabled = false;
		}

		private void FixedUpdate()
		{
			if (autoReparent.isRunning && autoReparent.isTimerElapsed)
			{
				Reparent();
			}
		}

		private void DeadParent()
		{
			backup = null;
			selfDestruct = true;
		}

		public void OnPreDisable()
		{
			if (initialized && !base.enabled)
			{
				Detach();
			}
		}

		public static void ReparentOrphansInScene(Scene scene)
		{
			scene.GetRootGameObjects(preallocGameObjects);
			foreach (GameObject preallocGameObject in preallocGameObjects)
			{
				preallocGameObject.GetComponentsInChildren(includeInactive: true, preallocOrphanables);
				foreach (Orphanable preallocOrphanable in preallocOrphanables)
				{
					if (preallocOrphanable.enabled && preallocOrphanable.initialized)
					{
						preallocOrphanable.Reparent();
					}
				}
			}
			preallocGameObjects.Clear();
			preallocOrphanables.Clear();
		}
	}
}
