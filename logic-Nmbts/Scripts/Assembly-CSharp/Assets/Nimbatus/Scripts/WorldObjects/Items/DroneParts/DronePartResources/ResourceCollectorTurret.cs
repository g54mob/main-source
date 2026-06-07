using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.Tutorial;
using Assets.Nimbatus.Scripts.Tutorial.TutorialScenes;
using Assets.Nimbatus.Scripts.World.Terrain.Common;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.DronePartResources
{
	public class ResourceCollectorTurret : MonoBehaviour
	{
		public ParticleSystem MuzzleParticles;

		public ResourceParticleSystem CollectParticles;

		public static readonly Queue<Action> MainThreadQueue = new Queue<Action>();

		public void Awake()
		{
			lock (MainThreadQueue)
			{
				MainThreadQueue.Clear();
			}
		}

		public void ShowParticles()
		{
			ParticleSystem.EmissionModule emission = MuzzleParticles.emission;
			emission.enabled = true;
		}

		public void HideParticles()
		{
			ParticleSystem.EmissionModule emission = MuzzleParticles.emission;
			emission.enabled = false;
		}

		public void ShootBeam(Vector3 direction, float range, LayerMask collisionLayer, ResourceHub hub)
		{
			RaycastHit hitInfo;
			bool num = Physics.SphereCast(new Ray(base.transform.position - direction.normalized * 5f, direction), 5f, out hitInfo, range, collisionLayer);
			ParticleSystem.ShapeModule shape = MuzzleParticles.shape;
			ParticleSystem.MainModule main = MuzzleParticles.main;
			if (num)
			{
				if (GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.ActiveTutorial != null)
				{
					shape.radius = hitInfo.distance * 0.9f;
					TutorialResourceJunk component = hitInfo.collider.gameObject.GetComponent<TutorialResourceJunk>();
					if (component != null)
					{
						float amount = 60f * Time.deltaTime;
						if (hub.HasCapacity(EResourceType.CommonOre, amount))
						{
							component.GatherResource(0.225f * Time.deltaTime);
							hub.AddResourceToParts(EResourceType.CommonOre, amount);
							float num2 = component.Collider.radius * 0.6f;
							Vector3 vector = new Vector3(UnityEngine.Random.Range(0f - num2, num2), UnityEngine.Random.Range(0f - num2, num2), 0f);
							SpawnParticles(new Color32(byte.MaxValue, 142, 0, byte.MaxValue), component.transform.position + vector);
						}
					}
				}
				else
				{
					shape.radius = hitInfo.distance * 0.9f;
					TerrainModificationHelper.LerpCollectResources(RuntimeGlobals.WorldController.ForeGroundTerrain, hub, hitInfo.point, 10, Time.fixedDeltaTime * 10f, SpawnParticles, false);
				}
			}
			else
			{
				shape.radius = range * 0.9f;
			}
			main.startLifetime = 0.04f * shape.radius;
		}

		public void Update()
		{
			lock (MainThreadQueue)
			{
				if (MainThreadQueue.Count <= 0)
				{
					return;
				}
				Action action = MainThreadQueue.Dequeue();
				if (action != null)
				{
					try
					{
						action();
						return;
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						return;
					}
				}
			}
		}

		private void SpawnParticles(Color color, Vector3 position)
		{
			lock (MainThreadQueue)
			{
				MainThreadQueue.Enqueue(delegate
				{
					UnityEngine.Object.Instantiate(CollectParticles, position, base.transform.rotation).Init(base.transform, color, Vector2.Distance(base.transform.position, position) / 10f, true, false);
				});
			}
		}

		public void ShootBeams(float range, LayerMask collisionLayer, ResourceHub hub)
		{
			ShootBeam(base.transform.right + base.transform.up * 0.1f, range, collisionLayer, hub);
			ShootBeam(base.transform.right - base.transform.up * 0.1f, range, collisionLayer, hub);
			ShootBeam(base.transform.right, range, collisionLayer, hub);
		}
	}
}
