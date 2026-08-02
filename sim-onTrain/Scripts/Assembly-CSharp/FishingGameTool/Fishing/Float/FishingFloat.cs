using System;
using System.Collections.Generic;
using FishingGameTool.CustomAttribute;
using FishingGameTool.Fishing.Loot;
using FishingGameTool.Fishing.LootData;
using UnityEngine;

namespace FishingGameTool.Fishing.Float
{
	[AddComponentMenu("Fishing Game Tool/Fishing Float")]
	[RequireComponent(typeof(Rigidbody))]
	public class FishingFloat : MonoBehaviour
	{
		[Serializable]
		public class FishingFloatAnimationSettings
		{
			[InfoBox("Settings for additional float animation in the water, based on an Animation Curve. An object representing the float must be placed as a child within the main float object for it to function properly.")]
			public Transform _floatRepresentation;

			public AnimationCurve _floatAnimationCurve;

			public float _animForce = 0.1f;

			public float _animSpeed = 0.3f;
		}

		public LayerMask _fishingFloatLayerMask;

		public float _checkerRadius = 0.05f;

		[Space]
		[AddButton("Enable Float Animations", "_enableFloatAnim")]
		public bool _enableFloatAnim;

		[ShowVariable("_enableFloatAnim")]
		public FishingFloatAnimationSettings _fishingFloatAnimationSettings;

		private GameObject _waterObject;

		private void Update()
		{
			HandleFloatAnim();
		}

		private void HandleFloatAnim()
		{
			if (!_enableFloatAnim || _fishingFloatAnimationSettings._floatRepresentation == null || _waterObject == null)
			{
				if (_fishingFloatAnimationSettings._floatRepresentation == null)
				{
					Debug.LogError("No float representation!");
				}
			}
			else
			{
				float num = _fishingFloatAnimationSettings._floatAnimationCurve.Evaluate(Time.time * _fishingFloatAnimationSettings._animSpeed);
				_fishingFloatAnimationSettings._floatRepresentation.localPosition = new Vector3(0f, num * _fishingFloatAnimationSettings._animForce, 0f);
			}
		}

		public SubstrateType CheckSurface(LayerMask fishingLayer)
		{
			Collider[] array = Physics.OverlapSphere(base.transform.position, _checkerRadius, ~(int)_fishingFloatLayerMask);
			if (array.Length != 0)
			{
				if (((int)fishingLayer & (1 << array[0].gameObject.layer)) != 0)
				{
					base.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, base.gameObject.GetComponent<Rigidbody>().velocity.y, 0f);
					_waterObject = array[0].gameObject;
					return SubstrateType.Water;
				}
				return SubstrateType.Land;
			}
			if (CheckInAir(base.transform, fishingLayer))
			{
				return SubstrateType.Land;
			}
			return SubstrateType.InAir;
		}

		public List<FishingLootData> GetLootDataFormWaterObject()
		{
			return _waterObject.GetComponent<FishingLoot>().GetFishingLoot();
		}

		private bool CheckInAir(Transform floatTransform, LayerMask fishingLayer)
		{
			float maxDistance = 0.3f;
			Vector3 direction = -floatTransform.up;
			if (Physics.Raycast(new Ray(floatTransform.position, direction), maxDistance, ~(int)fishingLayer))
			{
				return true;
			}
			return false;
		}
	}
}
