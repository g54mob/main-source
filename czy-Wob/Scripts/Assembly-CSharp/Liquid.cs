using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{
	private LiquidSpreaderInfo currentLiquid = new LiquidSpreaderInfo();

	private float liquidTimer = 20f;

	private float liquidNeeded = 70f;

	private float liquidMax = 240f;

	private float liquidSpreadRate = 5f;

	private float liquidTotalDecreaseRate = 10f;

	private float liquidSpreadChance = 0.0005f;

	private float liquidSpillJiggle = 0.01f;

	private Dictionary<Collider, PhysicMaterial> originalMaterials = new Dictionary<Collider, PhysicMaterial>();

	private List<Collider> originalMaterialKeys = new List<Collider>();

	private LiquidController controllerRef;

	private void Awake()
	{
		controllerRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<LiquidController>(GlobalObject.LIQUID_CONTROLLER);
	}

	private void Update()
	{
		TickLiquids();
		CheckSpreadLiquids();
	}

	private void TickLiquids()
	{
		if (currentLiquid.liquidTotal > 0f)
		{
			currentLiquid.liquidTotal -= Time.deltaTime * liquidTotalDecreaseRate;
			if (currentLiquid.liquidTotal < 0f)
			{
				currentLiquid.liquidTotal = 0f;
			}
		}
		if (!(currentLiquid.currentLiquidTimer <= 0f))
		{
			currentLiquid.currentLiquidTimer -= Time.deltaTime;
			if (currentLiquid.currentLiquidTimer <= 0f)
			{
				RemoveLiquid();
			}
		}
	}

	private int GetHighestPriorityLiquid()
	{
		return 0;
	}

	public void ApplyLiquid(LiquidInfo liquidInfo, bool force = false)
	{
		if (Time.frameCount <= currentLiquid.lastFrameIncrease || currentLiquid.liquidTotal >= liquidMax)
		{
			if (currentLiquid.liquidTotal >= liquidMax)
			{
				currentLiquid.liquidInfo = LiquidMixer.CombineLiquids(currentLiquid.liquidInfo, liquidInfo, 1f / currentLiquid.liquidTotal);
				if (currentLiquid.particleRef != null)
				{
					currentLiquid.particleRef.GetComponent<Renderer>().material.SetColor("_TintColor", currentLiquid.liquidInfo.liquidColor);
				}
			}
			return;
		}
		if (force)
		{
			currentLiquid.liquidInfo = null;
			currentLiquid.liquidTotal = liquidNeeded;
		}
		else
		{
			currentLiquid.liquidTotal += liquidSpreadRate;
		}
		currentLiquid.lastFrameIncrease = Time.frameCount;
		bool flag = false;
		if (currentLiquid.liquidInfo == null || liquidInfo.liquidMaterial != currentLiquid.liquidInfo.liquidMaterial)
		{
			flag = true;
		}
		if (currentLiquid.currentLiquidTimer == 0f)
		{
			flag = !(currentLiquid.liquidTotal < liquidNeeded);
		}
		if (currentLiquid.liquidInfo == null)
		{
			currentLiquid.liquidInfo = new LiquidInfo();
			currentLiquid.liquidInfo.liquidColor = liquidInfo.liquidColor;
			currentLiquid.liquidInfo.liquidType = liquidInfo.liquidType;
			currentLiquid.liquidInfo.puddleColor = liquidInfo.puddleColor;
			currentLiquid.liquidInfo.puddleMat = new Material(liquidInfo.puddleMat);
			currentLiquid.liquidInfo.emissionColor = liquidInfo.emissionColor;
			PhysicMaterial physicMaterial = new PhysicMaterial();
			physicMaterial.name = liquidInfo.liquidMaterial.name;
			physicMaterial.bounciness = liquidInfo.liquidMaterial.bounciness;
			physicMaterial.staticFriction = liquidInfo.liquidMaterial.staticFriction;
			physicMaterial.dynamicFriction = liquidInfo.liquidMaterial.dynamicFriction;
			physicMaterial.frictionCombine = liquidInfo.liquidMaterial.frictionCombine;
			physicMaterial.bounceCombine = liquidInfo.liquidMaterial.bounceCombine;
			currentLiquid.liquidInfo.liquidMaterial = physicMaterial;
		}
		else
		{
			currentLiquid.liquidInfo = LiquidMixer.CombineLiquids(currentLiquid.liquidInfo, liquidInfo, 1f / currentLiquid.liquidTotal);
			if (currentLiquid.particleRef != null)
			{
				currentLiquid.particleRef.GetComponent<Renderer>().material.SetColor("_TintColor", currentLiquid.liquidInfo.liquidColor);
			}
		}
		if (flag)
		{
			ClearLiquidMaterials();
			LiquidRecurse(base.gameObject);
		}
		if (currentLiquid.liquidTotal < liquidNeeded)
		{
			return;
		}
		if (currentLiquid.currentLiquidTimer > 0f)
		{
			currentLiquid.currentLiquidTimer = liquidTimer;
			return;
		}
		currentLiquid.currentLiquidTimer = liquidTimer;
		if (currentLiquid.particleRef == null)
		{
			GameObject gameObject = Object.Instantiate(controllerRef.dripParticles);
			Material material = gameObject.GetComponent<Renderer>().material;
			material.SetColor("_TintColor", currentLiquid.liquidInfo.liquidColor);
			gameObject.GetComponent<Renderer>().material = material;
			currentLiquid.particleRef = gameObject.GetComponent<ParticleSystem>();
			Mesh mesh = null;
			Transform transform = null;
			Transform transform2;
			if (base.gameObject.CompareTag(Tags.DOG))
			{
				transform2 = GetComponent<LegController>().bodyFront.transform;
				transform = GetComponent<DogLooks>().bodyRenderer.transform;
				mesh = GetComponent<DogLooks>().bodyRenderer.GetComponent<SkinnedMeshRenderer>().sharedMesh;
				gameObject.transform.SetParent(transform2);
				gameObject.transform.localPosition = Vector3.right * (transform2.localScale.x / 2f);
			}
			else
			{
				transform2 = base.gameObject.GetComponentInChildren<Rigidbody>().transform;
				MeshFilter component = transform2.GetComponent<MeshFilter>();
				if (component != null)
				{
					mesh = component.mesh;
					transform = transform2;
				}
				gameObject.transform.SetParent(transform2);
				gameObject.transform.localPosition = Vector3.zero;
			}
			if (mesh != null)
			{
				ParticleSystem.ShapeModule shape = currentLiquid.particleRef.shape;
				shape.shapeType = ParticleSystemShapeType.Mesh;
				shape.mesh = mesh;
				gameObject.transform.SetParent(null);
				gameObject.transform.localScale = transform.lossyScale;
				gameObject.transform.SetParent(transform2, worldPositionStays: true);
				gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
			}
		}
		ParticleSystem.MainModule main = currentLiquid.particleRef.main;
		main.loop = true;
		currentLiquid.particleRef.Play();
	}

	private void LiquidRecurse(GameObject obj)
	{
		Collider[] components = obj.GetComponents<Collider>();
		for (int i = 0; i < components.Length; i++)
		{
			if (!originalMaterials.ContainsKey(components[i]))
			{
				originalMaterials[components[i]] = components[i].material;
				originalMaterialKeys.Add(components[i]);
			}
			components[i].material = currentLiquid.liquidInfo.liquidMaterial;
		}
		for (int j = 0; j < obj.transform.childCount; j++)
		{
			LiquidRecurse(obj.transform.GetChild(j).gameObject);
		}
	}

	private void ClearLiquidMaterials()
	{
		for (int i = 0; i < originalMaterialKeys.Count; i++)
		{
			if (!(originalMaterialKeys[i] == null))
			{
				originalMaterialKeys[i].material = originalMaterials[originalMaterialKeys[i]];
			}
		}
		originalMaterials.Clear();
		originalMaterialKeys.Clear();
	}

	private void RemoveLiquid()
	{
		ClearLiquidMaterials();
		currentLiquid.liquidTotal = 0f;
		currentLiquid.liquidInfo = null;
		currentLiquid.currentLiquidTimer = 0f;
		if (currentLiquid.particleRef != null)
		{
			ParticleSystem.MainModule main = currentLiquid.particleRef.main;
			main.loop = false;
		}
	}

	private void CheckSpreadLiquids()
	{
		if (!(currentLiquid.currentLiquidTimer <= 0f) && Random.value <= liquidSpreadChance)
		{
			SpreadLiquid(GetCastPoint());
		}
	}

	private Vector3 GetCastPoint()
	{
		if (base.transform.root.CompareTag(Tags.DOG))
		{
			return base.transform.root.GetComponent<LegController>().bodyFront.transform.position;
		}
		Rigidbody rigidbody = GetComponent<Rigidbody>();
		if (rigidbody == null)
		{
			rigidbody = GetComponentInChildren<Rigidbody>();
			if (rigidbody == null)
			{
				return Vector3.zero;
			}
		}
		return rigidbody.transform.position;
	}

	public void CreatePuddle(bool smallPuddle = false)
	{
		SpreadLiquid(base.transform.position, 10f, smallPuddle);
	}

	private void SpreadLiquid(Vector3 castPoint, float castDist = 2f, bool smallPuddle = false)
	{
		if (castPoint == Vector3.zero || !RaycastUtil.StageRaycast(castPoint, Vector3.down, out var hitInfo, castDist) || hitInfo.transform == null)
		{
			return;
		}
		RoomBase component = hitInfo.transform.root.gameObject.GetComponent<RoomBase>();
		if (!(component == null))
		{
			bool flag = false;
			Vector2Int gridCell = Vector2Int.zero;
			RoomCustomizationObject roomCustomizationObject = controllerRef.puddleObject;
			if (smallPuddle)
			{
				roomCustomizationObject = controllerRef.smallPuddleObject;
			}
			Vector3 vector = hitInfo.point + liquidSpillJiggle * Vector3.up;
			Vector3 vector2 = new Vector3(roomCustomizationObject.footprint.x, 0f, roomCustomizationObject.footprint.z) / 2f;
			Vector2Int gridSquareForPositionAndRoom = ObjectPlacementManager.GetGridSquareForPositionAndRoom(vector - vector2, component, forPlants: false, forPuddles: true);
			if (ObjectPlacementManager.CanPlacePuddle(component, roomCustomizationObject, gridSquareForPositionAndRoom))
			{
				flag = true;
				gridCell = gridSquareForPositionAndRoom;
			}
			if (flag)
			{
				PlacedObjectInfo placedObjectInfo = ObjectPlacementManager.PlacePuddle(component, roomCustomizationObject, gridCell);
				placedObjectInfo.objectRef.GetComponentInChildren<Renderer>().material = GetPuddleMaterial();
				placedObjectInfo.objectRef.GetComponentInChildren<LiquidSpreader>().SetLiquidInfo(currentLiquid.liquidInfo);
			}
		}
	}

	private Material GetPuddleMaterial()
	{
		Material material = new Material(currentLiquid.liquidInfo.puddleMat);
		material.color = currentLiquid.liquidInfo.puddleColor;
		material.SetColor("_EmissionColor", currentLiquid.liquidInfo.emissionColor);
		return material;
	}
}
