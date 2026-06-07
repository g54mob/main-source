using System;
using ManagementScripts;
using Newtonsoft.Json.Linq;
using PropertiesScripts;
using ScriptHelpers;
using SettingScripts;
using UnityEngine;
using UnityEngine.Events;

namespace SimulationScripts
{
	public class MatterPellet : MonoBehaviour, ISaveable
	{
		public MatterMaterial material;

		private Matter matter;

		public float radiusFactor;

		private static readonly FloatSetting MinPelletSize = ScenarioSettings.Instance.minPelletSize;

		private static float minPelletSize = MinPelletSize.SubscribeTo<FloatSetting, float>(UpdateMinPelletSize);

		private static float drag = ScenarioSettings.Instance.dragCoefficient.SubscribeTo<FloatSetting, float>(UpdateDragValue);

		[NonSerialized]
		public readonly UnityEvent<MatterPellet, float> AfterAmountChange = new UnityEvent<MatterPellet, float>();

		[NonSerialized]
		public readonly UnityEvent<float> AfterEnergyChange = new UnityEvent<float>();

		[NonSerialized]
		public readonly UnityEvent<MatterPellet> onPelletGone = new UnityEvent<MatterPellet>();

		public static bool disableDragOnHeldPellet;

		public bool held;

		private Rigidbody2D rb;

		public float amount
		{
			get
			{
				return matter.Amount;
			}
			private set
			{
				float previousAmount = matter.Amount;
				matter.Amount = value;
				OnAmountChange(previousAmount);
			}
		}

		public float energy
		{
			get
			{
				return matter.energy;
			}
			set
			{
				amount = value / material.EnergyDensity;
			}
		}

		public float sizeFactor => Mathf.Max(matter.Amount, 0f) / 20f;

		public float radius => matter.radius;

		public float cohesiveness => matter.cohesiveness;

		public float EnergyDensity => matter.EnergyDensity;

		public float mass => matter.mass;

		private static void UpdateMinPelletSize(float val)
		{
			minPelletSize = val;
		}

		private static void UpdateDragValue(float val)
		{
			drag = val;
		}

		public void Awake()
		{
			rb = GetComponent<Rigidbody2D>();
			rb.angularDamping = drag / 2f;
			matter = new Matter
			{
				Material = material
			};
			GetComponent<GrabbableObject>()?.onGrab.AddListener(UpdateHeld);
		}

		public void OnDestroy()
		{
			onPelletGone.Invoke(this);
			MatterDecayProcessor.I.TryRemove(this);
			WorldObjectsSpawner.Instance.OnPelletDestroy(this);
		}

		public void InitializePelletWithEnergy(float newEnergy)
		{
			energy = newEnergy;
			StartPellet();
		}

		public void InitializePelletWithAmount(float newAmount)
		{
			amount = newAmount;
			StartPellet();
		}

		private void StartPellet()
		{
			rb.transform.localScale = Vector3.one * Mathf.Sqrt(sizeFactor);
			if (material.decay && !MatterDecayProcessor.I.TryAddUnique(this))
			{
				Debug.LogWarning("MatterPellet.StartPellet: decay already exists");
			}
			UpdateDrag();
			ToggleCollision(ScenarioSettings.Instance.pelletCollision.val);
		}

		public void UpdateDrag()
		{
			rb.linearDamping = ((held && disableDragOnHeldPellet) ? 0f : (drag * radiusFactor / rb.mass));
		}

		public float RemovePellet()
		{
			return RemoveAmount(amount + 1f);
		}

		public float RemoveAmount(float maxAmountToRemove)
		{
			if (amount <= maxAmountToRemove)
			{
				float result = amount;
				amount = 0f;
				UnityEngine.Object.Destroy(base.gameObject);
				return result;
			}
			amount -= maxAmountToRemove;
			return maxAmountToRemove;
		}

		public float RemoveEnergy(float maxEnergyToRemove)
		{
			return material.EnergyOfAmount(RemoveAmount(material.AmountOfEnergy(maxEnergyToRemove)));
		}

		private void OnAmountChange(float previousAmount)
		{
			UpdatePhysicalProperties();
			AfterAmountChange.Invoke(this, matter.Amount - previousAmount);
			AfterEnergyChange.Invoke(material.EnergyOfAmount(matter.Amount - previousAmount));
		}

		public void UpdatePhysicalProperties()
		{
			radiusFactor = Mathf.Sqrt(sizeFactor);
			rb.transform.localScale = Vector3.one * radiusFactor;
			rb.mass = mass;
			UpdateDrag();
		}

		public float ConvertToEnergy(bool withLosses = false, float affinity = 1f)
		{
			return energy * (withLosses ? material.ConversionEfficiency(affinity) : 1f);
		}

		private void UpdateHeld(bool newVal)
		{
			held = newVal;
			UpdateDrag();
		}

		public bool RipChunkOff(float chunkAmount, Vector2? normal = null)
		{
			chunkAmount = Mathf.Min(chunkAmount, amount);
			if (chunkAmount < minPelletSize || amount - chunkAmount < minPelletSize)
			{
				return false;
			}
			RemoveAmount(chunkAmount);
			float num = Mathf.Sqrt(chunkAmount) / MathF.PI;
			Vector2 vector = (normal ?? UnityEngine.Random.insideUnitCircle) * (num + radius);
			Vector2 vector2 = (Vector2)base.transform.position - vector * chunkAmount / (chunkAmount + amount);
			WorldObjectsSpawner instance = WorldObjectsSpawner.Instance;
			MatterMaterial mat = matter.Material;
			Vector3? pos = vector2 + vector;
			Transform parent = base.transform.parent;
			float? num2 = chunkAmount;
			instance.SpawnPelletOfMatter(mat, pos, null, num2, parent).GetComponent<MatterPellet>();
			rb.position = vector2;
			return true;
		}

		public void ToggleCollision(bool val)
		{
			Collider2D component = GetComponent<Collider2D>();
			if (!val)
			{
				component.isTrigger = true;
				rb.freezeRotation = true;
			}
			else
			{
				component.isTrigger = false;
				rb.freezeRotation = false;
			}
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.CompareTag("pellet") && ScenarioSettings.Instance.pelletMerge.val)
			{
				MatterPellet component = other.gameObject.GetComponent<MatterPellet>();
				if (!(component.amount > amount) && !(material != component.material))
				{
					float num = mass;
					amount += component.amount;
					float num2;
					rb.linearVelocity = (rb.linearVelocity * num + other.otherRigidbody.linearVelocity * (num2 = other.otherRigidbody.mass)) / (num + num2);
					UnityEngine.Object.Destroy(component.gameObject);
				}
			}
		}

		public JObject SaveState()
		{
			return new JObject
			{
				["material"] = material.Name,
				["amount"] = amount
			};
		}

		public void LoadState(JObject state)
		{
			matter.Material = MatterMaterialManager.FindMaterial(state["material"].ToString());
			amount = float.Parse(state["amount"].ToString());
		}
	}
}
