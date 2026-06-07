using System.Collections.Generic;
using SettingScripts;
using SimulationScripts.BibiteScripts;
using UnityEngine;
using Utility;

namespace SimulationScripts.Rendering
{
	public class FieldOfViewDisplay : MonoBehaviour
	{
		private Transform target;

		private FieldOfView fow;

		private Transform selfTransform;

		[SerializeField]
		private SpriteRenderer sr;

		[SerializeField]
		private GameObject weightDisplayPrefab;

		[SerializeField]
		private Transform weightDisplayHolder;

		private Material mat;

		private ItemDictPool<Transform, WeightDisplay> weightDisplayPool;

		private static readonly int ViewAngle = Shader.PropertyToID("_viewAngle");

		private float viewAngle;

		private bool showFOW;

		private bool showTargets;

		private void Awake()
		{
			weightDisplayPool = new ItemDictPool<Transform, WeightDisplay>(weightDisplayPrefab, weightDisplayHolder, 100);
			mat = sr.material;
			selfTransform = base.transform;
			showFOW = UserSettings.ShowBibiteFOW.SubscribeTo<UserSetting<bool>, bool>(UpdateShowBibiteFOW);
			showTargets = UserSettings.ShowBibiteTargets.SubscribeTo<UserSetting<bool>, bool>(UpdateShowTargets);
		}

		private void UpdateShowBibiteFOW(bool val)
		{
			showFOW = val;
			if (target == null)
			{
				return;
			}
			if (!val)
			{
				base.gameObject.SetActive(value: false);
				if (target != null && !val)
				{
					weightDisplayPool.RetireAll();
				}
			}
			else
			{
				base.gameObject.SetActive(value: true);
				selfTransform.position = target.position;
				selfTransform.rotation = target.rotation;
				selfTransform.localScale = 2f * fow.viewRadius * Vector3.one;
			}
		}

		private void UpdateShowTargets(bool val)
		{
			showTargets = val;
			if (target != null && !val)
			{
				weightDisplayPool.RetireAll();
			}
		}

		public void SetTarget(BibiteBody targetBibite = null)
		{
			if (targetBibite == null)
			{
				weightDisplayPool?.RetireAll();
				target = null;
				fow = null;
				base.gameObject.SetActive(value: false);
				return;
			}
			target = targetBibite.transform;
			fow = targetBibite.fow;
			viewAngle = fow.viewAngle;
			mat.SetFloat(ViewAngle, viewAngle / 360f);
			if (showFOW)
			{
				base.gameObject.SetActive(value: true);
				selfTransform.position = target.position;
				selfTransform.rotation = target.rotation;
				selfTransform.localScale = 2f * fow.viewRadius * Vector3.one;
			}
		}

		private void Update()
		{
			if (fow == null || !showFOW)
			{
				return;
			}
			float viewRadius = fow.viewRadius;
			selfTransform.position = target.position;
			selfTransform.rotation = target.rotation;
			selfTransform.localScale = 2f * viewRadius * Vector3.one;
			if (!showTargets)
			{
				return;
			}
			foreach (KeyValuePair<Transform, WeightDisplay> activeItem in weightDisplayPool.activeItems)
			{
				if (activeItem.Key == null)
				{
					weightDisplayPool.ReturnItemDelayed(activeItem.Value);
					continue;
				}
				Vector3 vector = activeItem.Key.position - selfTransform.position;
				if (vector.magnitude > viewRadius)
				{
					weightDisplayPool.ReturnItemDelayed(activeItem.Value);
				}
				else if (Mathf.Abs(Vector2.SignedAngle(selfTransform.up, vector)) > viewAngle / 2f)
				{
					weightDisplayPool.ReturnItemDelayed(activeItem.Value);
				}
			}
			weightDisplayPool.ReturnDelayedItems();
			if (!fow.seenThisFrame)
			{
				return;
			}
			for (int num = fow.nBibite - 1; num >= 0; num--)
			{
				GameObjectWeight gameObjectWeight = fow.bibiteWeights[num];
				if (!(gameObjectWeight.gameObject == null))
				{
					float weight = gameObjectWeight.weight;
					weightDisplayPool.GetItemWithKey(gameObjectWeight.gameObject.transform, delegate(WeightDisplay t)
					{
						t.SetTargetType(TargetType.Bibite);
					}).UpdateWeights(weight, weight / fow.bibiteWeightSum, weight / fow.maxBibiteWeight);
				}
			}
			for (int num2 = fow.nPlants - 1; num2 >= 0; num2--)
			{
				GameObjectWeight gameObjectWeight2 = fow.plantWeights[num2];
				if (!(gameObjectWeight2.gameObject == null))
				{
					float weight2 = gameObjectWeight2.weight;
					weightDisplayPool.GetItemWithKey(gameObjectWeight2.gameObject.transform, delegate(WeightDisplay t)
					{
						t.SetTargetType(TargetType.Plant);
					}).UpdateWeights(weight2, weight2 / fow.plantWeightSum, weight2 / fow.maxPlantWeight);
				}
			}
			for (int num3 = fow.nMeat - 1; num3 >= 0; num3--)
			{
				GameObjectWeight gameObjectWeight3 = fow.meatWeights[num3];
				if (!(gameObjectWeight3.gameObject == null))
				{
					float weight3 = gameObjectWeight3.weight;
					weightDisplayPool.GetItemWithKey(gameObjectWeight3.gameObject.transform, delegate(WeightDisplay t)
					{
						t.SetTargetType(TargetType.Meat);
					}).UpdateWeights(weight3, weight3 / fow.meatWeightSum, weight3 / fow.maxMeatWeight);
				}
			}
		}

		private void OnDestroy()
		{
			UserSettings.ShowBibiteFOW.UnSubscribeTo<UserSetting<bool>, bool>(UpdateShowBibiteFOW);
			UserSettings.ShowBibiteTargets.UnSubscribeTo<UserSetting<bool>, bool>(UpdateShowTargets);
		}
	}
}
