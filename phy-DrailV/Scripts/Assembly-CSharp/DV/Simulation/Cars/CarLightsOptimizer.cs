using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DV.Simulation.Cars
{
	public class CarLightsOptimizer : MonoBehaviour
	{
		public abstract class OptimizationGroup
		{
			public float disableSqrDistance;

			public bool enabled;

			public bool shouldForceOptimize;

			public abstract IEnumerable<GameObject> OptimizingGameObjects { get; }

			public abstract int NumberOfObjects { get; }

			protected OptimizationGroup(float disableSqrDistance)
			{
				this.disableSqrDistance = disableSqrDistance;
				enabled = false;
				shouldForceOptimize = true;
			}
		}

		public class FixedOptimizationGroup : OptimizationGroup
		{
			[SerializeField]
			private GameObject[] gameObjectsToOptimize;

			public override IEnumerable<GameObject> OptimizingGameObjects => gameObjectsToOptimize;

			public override int NumberOfObjects => gameObjectsToOptimize.Length;

			public FixedOptimizationGroup(GameObject[] gameObjectsToOptimize, float disableSqrDistance)
				: base(disableSqrDistance)
			{
				this.gameObjectsToOptimize = gameObjectsToOptimize;
			}
		}

		public class DynamicOptimizationGroup : OptimizationGroup
		{
			private HashSet<GameObject> gameObjectsToOptimize;

			public override IEnumerable<GameObject> OptimizingGameObjects => gameObjectsToOptimize;

			public override int NumberOfObjects => gameObjectsToOptimize.Count;

			public DynamicOptimizationGroup(float disableSqrDistance)
				: base(disableSqrDistance)
			{
				gameObjectsToOptimize = new HashSet<GameObject>();
			}

			public bool Add(GameObject go)
			{
				if (go == null)
				{
					Debug.LogError("Trying to add a null object to DynamicOptimizationGroup. Skipping.");
					return false;
				}
				return gameObjectsToOptimize.Add(go);
			}

			public bool Remove(GameObject go)
			{
				if (go == null)
				{
					Debug.LogError("Trying to remove a null object from DynamicOptimizationGroup. Skipping.");
					return false;
				}
				return gameObjectsToOptimize.Remove(go);
			}
		}

		[SerializeField]
		private GameObject[] cabLights;

		[SerializeField]
		private GameObject[] headLightGlass;

		[SerializeField]
		private float cabLightDisableSqrDistance = 2500f;

		[SerializeField]
		private float headLightGlassDisableSqrDistance = 2500f;

		[SerializeField]
		private float headlightsDisableSqrDistance = 1000000f;

		[SerializeField]
		private float glaresDisableSqrDistance = 4000000f;

		[SerializeField]
		private float beamsDisableSqrDistance = 250000f;

		[SerializeField]
		private HeadlightBeamController beamController;

		[SerializeField]
		private float checkPeriod = 0.3f;

		[SerializeField]
		private Transform positionCheckTransform;

		private Coroutine optimizationCoro;

		private bool initialized;

		public FixedOptimizationGroup CabLightsOptimizationGroup { get; private set; }

		public FixedOptimizationGroup HeadlightGlassOptimizationGroup { get; private set; }

		public DynamicOptimizationGroup HeadlightsOptimizationGroup { get; private set; }

		public DynamicOptimizationGroup GlaresOptimizationGroup { get; private set; }

		public DynamicOptimizationGroup BeamsOptimizationGroup { get; private set; }

		public void Initialize()
		{
			if (!initialized)
			{
				_ = beamController == null;
				if (positionCheckTransform == null)
				{
					positionCheckTransform = base.transform;
				}
				if (cabLights == null || cabLights.Length == 0)
				{
					CabLightsOptimizationGroup = null;
				}
				else
				{
					CabLightsOptimizationGroup = new FixedOptimizationGroup(cabLights, cabLightDisableSqrDistance);
				}
				if (headLightGlass == null || headLightGlass.Length == 0)
				{
					Debug.LogWarning("HeadlightGlassOptimizationGroup weren't set", this);
					HeadlightGlassOptimizationGroup = null;
				}
				else
				{
					HeadlightGlassOptimizationGroup = new FixedOptimizationGroup(headLightGlass, headLightGlassDisableSqrDistance);
				}
				HeadlightsOptimizationGroup = new DynamicOptimizationGroup(headlightsDisableSqrDistance);
				GlaresOptimizationGroup = new DynamicOptimizationGroup(glaresDisableSqrDistance);
				BeamsOptimizationGroup = new DynamicOptimizationGroup(beamsDisableSqrDistance);
				if (base.gameObject.activeInHierarchy && optimizationCoro == null)
				{
					optimizationCoro = StartCoroutine(OptimizerCoro());
				}
				initialized = true;
			}
		}

		private void OnEnable()
		{
			if (initialized)
			{
				optimizationCoro = StartCoroutine(OptimizerCoro());
			}
		}

		private void OnDisable()
		{
			if (optimizationCoro != null)
			{
				StopCoroutine(optimizationCoro);
			}
			optimizationCoro = null;
		}

		public void UpdateDynamicHeadlights(GameObject headlight, bool add)
		{
			UpdateDynamicOptimizationGroup(headlight, add, HeadlightsOptimizationGroup);
		}

		public void UpdateDynamicGlare(GameObject glare, bool add)
		{
			UpdateDynamicOptimizationGroup(glare, add, GlaresOptimizationGroup);
		}

		public void UpdateDynamicBeam(GameObject beam, bool add)
		{
			UpdateDynamicOptimizationGroup(beam, add, BeamsOptimizationGroup);
		}

		private void UpdateDynamicOptimizationGroup(GameObject go, bool add, DynamicOptimizationGroup optimizationGroup)
		{
			if ((add ? optimizationGroup.Add(go) : optimizationGroup.Remove(go)) && optimizationGroup.NumberOfObjects > 0)
			{
				optimizationGroup.shouldForceOptimize = true;
			}
		}

		private IEnumerator OptimizerCoro()
		{
			while (true)
			{
				yield return WaitFor.Seconds(checkPeriod);
				float sqrDistance;
				if (!(PlayerManager.PlayerTransform == null))
				{
					Vector3 position = PlayerManager.ActiveCamera.transform.position;
					Vector3 position2 = positionCheckTransform.position;
					sqrDistance = (position - position2).sqrMagnitude;
					if (CabLightsOptimizationGroup != null)
					{
						Optimize(CabLightsOptimizationGroup);
					}
					if (HeadlightGlassOptimizationGroup != null)
					{
						Optimize(HeadlightGlassOptimizationGroup);
					}
					if (HeadlightsOptimizationGroup != null)
					{
						Optimize(HeadlightsOptimizationGroup);
					}
					if (GlaresOptimizationGroup != null)
					{
						Optimize(GlaresOptimizationGroup);
					}
					if (BeamsOptimizationGroup != null && Optimize(BeamsOptimizationGroup) && beamController != null)
					{
						beamController.ToggleActive(BeamsOptimizationGroup.enabled);
					}
				}
				continue;
				bool flag;
				bool Optimize(OptimizationGroup og)
				{
					flag = sqrDistance < og.disableSqrDistance;
					if (og.enabled == flag && !og.shouldForceOptimize)
					{
						return false;
					}
					foreach (GameObject optimizingGameObject in og.OptimizingGameObjects)
					{
						if (!(optimizingGameObject == null))
						{
							optimizingGameObject.SetActive(flag);
						}
					}
					og.enabled = flag;
					og.shouldForceOptimize = false;
					return true;
				}
				bool Optimize(OptimizationGroup og)
				{
					flag = sqrDistance < og.disableSqrDistance;
					if (og.enabled == flag && !og.shouldForceOptimize)
					{
						return false;
					}
					foreach (GameObject optimizingGameObject2 in og.OptimizingGameObjects)
					{
						optimizingGameObject = optimizingGameObject2;
						if (!(optimizingGameObject == null))
						{
							optimizingGameObject.SetActive(flag);
						}
					}
					og.enabled = flag;
					og.shouldForceOptimize = false;
					return true;
				}
			}
		}
	}
}
