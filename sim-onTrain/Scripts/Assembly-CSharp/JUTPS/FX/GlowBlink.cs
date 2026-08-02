using UnityEngine;

namespace JUTPS.FX
{
	[AddComponentMenu("JU TPS/FX/Flashing Glow")]
	public class GlowBlink : MonoBehaviour
	{
		private Renderer[] Meshes;

		public Color EmissiveColor = Color.white;

		[Range(0f, 10f)]
		public float EmissiveIntensity = 0.5f;

		public float Interval = 2f;

		public float Speed = 5f;

		private float EmissiveValue;

		private bool IsBlinking;

		private float currentime;

		private void Start()
		{
			Meshes = base.transform.GetComponentsInChildren<Renderer>();
			Renderer[] meshes = Meshes;
			foreach (Renderer renderer in meshes)
			{
				for (int j = 0; j < renderer.sharedMaterials.Length; j++)
				{
					Material material = Object.Instantiate(renderer.sharedMaterials[j]);
					renderer.sharedMaterials[j] = material;
					renderer.sharedMaterials[j].EnableKeyword("_EMISSION");
				}
			}
		}

		private void Update()
		{
			if (IsBlinking)
			{
				EmissiveValue = Mathf.MoveTowards(EmissiveValue, 1f, Speed * Time.deltaTime);
			}
			else
			{
				EmissiveValue = Mathf.MoveTowards(EmissiveValue, 0f, Speed * Time.deltaTime);
			}
			if (currentime < Interval)
			{
				currentime += Time.deltaTime;
				if (EmissiveValue >= 1f)
				{
					IsBlinking = false;
				}
			}
			else
			{
				IsBlinking = true;
				currentime = 0f;
			}
			Renderer[] meshes = Meshes;
			for (int i = 0; i < meshes.Length; i++)
			{
				Material[] materials = meshes[i].materials;
				for (int j = 0; j < materials.Length; j++)
				{
					materials[j].SetColor("_EmissionColor", EmissiveColor * (EmissiveValue * EmissiveIntensity));
				}
			}
		}

		public void DisableEmission()
		{
			if (Meshes == null)
			{
				return;
			}
			Renderer[] meshes = Meshes;
			for (int i = 0; i < meshes.Length; i++)
			{
				Material[] sharedMaterials = meshes[i].sharedMaterials;
				foreach (Material obj in sharedMaterials)
				{
					obj.DisableKeyword("_EMISSION");
					obj.SetColor("_EmissionColor", Color.clear);
				}
			}
		}

		private void OnDestroy()
		{
			DisableEmission();
		}

		private void OnEnable()
		{
			DisableEmission();
		}
	}
}
