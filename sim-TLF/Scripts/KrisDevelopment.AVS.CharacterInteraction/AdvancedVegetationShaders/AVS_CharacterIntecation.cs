using UnityEngine;

namespace AdvancedVegetationShaders
{
	[RequireComponent(typeof(Renderer))]
	[DisallowMultipleComponent]
	public class AVS_CharacterIntecation : MonoBehaviour
	{
		[SerializeField]
		private Transform character;

		[SerializeField]
		[Tooltip("Character's radius")]
		private float radius;

		private Material[] materialInstances = new Material[0];

		private static int characterPositionProperty = Shader.PropertyToID("_AVS_CharacterPosition");

		public void SetCharacter(Transform t, float radius)
		{
			character = t;
			this.radius = radius;
		}

		private void OnEnable()
		{
			Renderer component = GetComponent<Renderer>();
			if (!(component == null))
			{
				Material[] sharedMaterials = component.sharedMaterials;
				materialInstances = new Material[sharedMaterials.Length];
				for (int i = 0; i < sharedMaterials.Length; i++)
				{
					materialInstances[i] = new Material(sharedMaterials[i]);
				}
				component.sharedMaterials = materialInstances;
			}
		}

		private void Update()
		{
			if (!(character == null))
			{
				Material[] array = materialInstances;
				foreach (Material obj in array)
				{
					Vector3 position = character.position;
					obj.SetVector(characterPositionProperty, new Vector4(position.x, position.y, position.z, radius));
				}
			}
		}

		private void OnDisable()
		{
			Material[] array = materialInstances;
			foreach (Material material in array)
			{
				if (material != null)
				{
					Object.Destroy(material);
				}
			}
			materialInstances = new Material[0];
		}
	}
}
