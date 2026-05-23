using UnityEngine;

namespace Bozo.ModularCharacters
{
	public class OutfitHeightChange : MonoBehaviour
	{
		[SerializeField]
		private float HeightOffset;

		[Header("Heel Options")]
		[SerializeField]
		private bool heelEnabled;

		[SerializeField]
		private string animParameter = "HeelHeight";

		[SerializeField]
		private string blendName = "AnimShape_HeelHeight";

		[Range(0f, 1f)]
		[SerializeField]
		private float heelHeight;

		[SerializeField]
		private float heelHeightOffset;

		private void Start()
		{
			if (!heelEnabled)
			{
				heelHeightOffset = 0f;
				return;
			}
			OutfitSystem componentInParent = GetComponentInParent<OutfitSystem>();
			if (componentInParent == null)
			{
				return;
			}
			Animator animator = componentInParent.animator;
			Outfit component = GetComponent<Outfit>();
			if (component == null)
			{
				return;
			}
			AnimatorControllerParameter[] parameters = animator.parameters;
			foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
			{
				if (animatorControllerParameter.name == animParameter)
				{
					animator.SetFloat(animatorControllerParameter.name, heelHeight);
				}
			}
			if (component.skinnedRenderer == null)
			{
				return;
			}
			int blendShapeIndex = component.skinnedRenderer.sharedMesh.GetBlendShapeIndex(blendName);
			if (blendShapeIndex != -1)
			{
				string[] array = blendName.Split(".");
				if (array.Length > 1)
				{
					blendName = array[1];
				}
				component.skinnedRenderer.SetBlendShapeWeight(blendShapeIndex, heelHeight * 100f);
			}
		}

		private void OnValidate()
		{
			if (!heelEnabled || !Application.isPlaying || !base.gameObject.scene.isLoaded)
			{
				return;
			}
			OutfitSystem componentInParent = GetComponentInParent<OutfitSystem>();
			if (componentInParent == null)
			{
				return;
			}
			Animator animator = componentInParent.animator;
			Outfit component = GetComponent<Outfit>();
			if (component == null || component.skinnedRenderer == null)
			{
				return;
			}
			int blendShapeIndex = component.skinnedRenderer.sharedMesh.GetBlendShapeIndex(blendName);
			MonoBehaviour.print(blendShapeIndex);
			if (blendShapeIndex != -1)
			{
				string[] array = blendName.Split(".");
				if (array.Length > 1)
				{
					blendName = array[1];
				}
				component.skinnedRenderer.SetBlendShapeWeight(blendShapeIndex, heelHeight * 100f);
				float num = Mathf.Lerp(0f, heelHeightOffset, heelHeight);
				float height = HeightOffset + num;
				componentInParent.SetHeight(height);
				animator.SetFloat(animParameter, heelHeight);
			}
		}

		private void OnEnable()
		{
			if (!heelEnabled)
			{
				heelHeightOffset = 0f;
				heelHeight = 0f;
			}
			Invoke("SetHeight", 0f);
		}

		private void OnDisable()
		{
			RemoveHeight();
		}

		private void SetHeight()
		{
			OutfitSystem componentInParent = GetComponentInParent<OutfitSystem>();
			if (!(componentInParent == null))
			{
				float height = HeightOffset + heelHeightOffset;
				componentInParent.SetHeight(height);
				componentInParent.animator.SetFloat(animParameter, heelHeight);
			}
		}

		private void RemoveHeight()
		{
			OutfitSystem componentInParent = GetComponentInParent<OutfitSystem>();
			if (!(componentInParent == null))
			{
				componentInParent.SetHeight(0f);
				componentInParent.animator.SetFloat(animParameter, heelHeight);
			}
		}
	}
}
