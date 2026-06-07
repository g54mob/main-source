using System;
using System.Collections.Generic;
using Assets.Scripts.Environment.Roads;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land
{
	public class VehicleInfoScript : MonoBehaviour
	{
		[Serializable]
		public struct VariableColors
		{
			public Color[] Colors;

			public Material Material;
		}

		[SerializeField]
		private float _mass = 10f;

		private List<Material> _materialInstances;

		[SerializeField]
		private Renderer[] _renderers;

		[SerializeField]
		private float _speedFactor = 1f;

		[SerializeField]
		private bool _useGravityOnRemoteCrafts = true;

		[SerializeField]
		private VariableColors[] _variableMaterials;

		[SerializeField]
		private Transform[] _wheels;

		public float Mass => _mass;

		public Transform[] Wheels => _wheels;

		public SimpleGroundVehicleScript CreateDrivingCar(Rigidbody rigidbody, GameObject lightDamageParticlesPrefab, GameObject criticalDamageParticlesPrefab, float randomColor, IEnumerable<CarSpawnerScript.CarLight> carLightMaterials)
		{
			SimpleGroundVehicleScript simpleGroundVehicleScript = base.gameObject.AddComponent<SimpleGroundVehicleScript>();
			bool flag = false;
			simpleGroundVehicleScript.Initialize(rigidbody, lightDamageParticlesPrefab, criticalDamageParticlesPrefab, _mass, _wheels);
			simpleGroundVehicleScript.UseGravityOnRemoteCrafts = _useGravityOnRemoteCrafts;
			_materialInstances = new List<Material>();
			Renderer[] renderers = _renderers;
			foreach (Renderer renderer in renderers)
			{
				Material[] sharedMaterials = renderer.sharedMaterials;
				VariableColors[] variableMaterials = _variableMaterials;
				for (int j = 0; j < variableMaterials.Length; j++)
				{
					VariableColors variableColors = variableMaterials[j];
					for (int k = 0; k < sharedMaterials.Length; k++)
					{
						if (sharedMaterials[k] == variableColors.Material)
						{
							string text = sharedMaterials[k].name + " [Instance]";
							sharedMaterials[k] = UnityEngine.Object.Instantiate(sharedMaterials[k]);
							sharedMaterials[k].name = text;
							_materialInstances.Add(sharedMaterials[k]);
							Color color = variableColors.Colors[Mathf.FloorToInt(randomColor * (float)variableColors.Colors.Length)];
							sharedMaterials[k].color = color;
							if (k == 0)
							{
								Color.RGBToHSV(color, out var H, out var S, out var V);
								flag = flag && H < 0.1f && S > 0.8f && V > 0.8f;
							}
							break;
						}
					}
				}
				simpleGroundVehicleScript.SpeedFactor = _speedFactor + (flag ? 0.5f : 0f);
				if (carLightMaterials != null)
				{
					for (int l = 0; l < sharedMaterials.Length; l++)
					{
						foreach (CarSpawnerScript.CarLight carLightMaterial in carLightMaterials)
						{
							if (carLightMaterial.Material.name.StartsWith(sharedMaterials[l].name))
							{
								sharedMaterials[l] = carLightMaterial.Material;
								break;
							}
						}
					}
				}
				renderer.sharedMaterials = sharedMaterials;
			}
			return simpleGroundVehicleScript;
		}

		protected virtual void OnDestroy()
		{
			if (_materialInstances == null)
			{
				return;
			}
			foreach (Material materialInstance in _materialInstances)
			{
				UnityEngine.Object.Destroy(materialInstance);
			}
			_materialInstances.Clear();
		}

		[ContextMenu("Populate Wheel List")]
		private void PopulateWheelList()
		{
			List<Transform> list = new List<Transform>
			{
				Utilities.FindFirstGameObjectMyselfOrChildren("FR", base.gameObject).transform,
				Utilities.FindFirstGameObjectMyselfOrChildren("FL", base.gameObject).transform,
				Utilities.FindFirstGameObjectMyselfOrChildren("BR", base.gameObject).transform,
				Utilities.FindFirstGameObjectMyselfOrChildren("BL", base.gameObject).transform
			};
			_wheels = list.ToArray();
		}
	}
}
