using System.Collections.Generic;
using MalbersAnimations.Utilities;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Utilities/Ragdoll/Dismember")]
	public class Dismember : MonoBehaviour
	{
		public List<BodyPart> bodyParts;

		public string MaterialItemName;

		protected int CurrentMaterialItemIndex;

		public void Awake()
		{
			if (MaterialItemName != string.Empty)
			{
				MaterialItem materialItem = this.FindComponent<MaterialChanger>().materialList.Find((MaterialItem mat) => mat.Name.ToLower() == MaterialItemName.ToLower());
				if (materialItem != null)
				{
					CurrentMaterialItemIndex = materialItem.current;
					materialItem.OnMaterialChanged.AddListener(UpdateMaterialItemIndex);
				}
			}
		}

		private void UpdateMaterialItemIndex(int value)
		{
			CurrentMaterialItemIndex = value;
		}

		public void _DismemberLimb()
		{
			_DismemberLimb(bodyParts[Random.Range(0, bodyParts.Count)]);
		}

		public void _DismemberLimb(int bodypartIndex)
		{
			if (bodypartIndex < bodyParts.Count && bodypartIndex >= 0)
			{
				_DismemberLimb(bodyParts[bodypartIndex]);
			}
			else
			{
				Debug.LogWarning("Wrong index... or the BodyPart is Empty");
			}
		}

		public void _DismemberLimb(string bodypartName)
		{
			BodyPart bodyPart = bodyParts.Find((BodyPart item) => item.name.ToLower() == bodypartName.ToLower());
			if (bodyPart != null)
			{
				_DismemberLimb(bodyPart);
			}
			else
			{
				Debug.LogWarning("There's no body part named " + bodypartName);
			}
		}

		public void _DismemberLimb(BodyPart bodypart)
		{
			if (bodypart == null)
			{
				Debug.LogWarning("The Body Part is empty");
			}
			else
			{
				if (bodypart.dismembered)
				{
					return;
				}
				GameObject gameObject = null;
				if ((bool)bodypart.member)
				{
					gameObject = (bodypart.Instantiate ? Object.Instantiate(bodypart.member.gameObject) : bodypart.member.gameObject);
					gameObject.SetActive(value: true);
					for (int i = 0; i < bodypart.AttachedLimbBones.Count; i++)
					{
						Collider component = bodypart.AttachedLimbBones[i].GetComponent<Collider>();
						if ((bool)component)
						{
							component.enabled = false;
						}
						bodypart.member.Bones[i].position = bodypart.AttachedLimbBones[i].position;
						bodypart.member.Bones[i].rotation = bodypart.AttachedLimbBones[i].rotation;
						bodypart.member.Bones[i].localScale = bodypart.AttachedLimbBones[i].localScale;
						bodypart.AttachedLimbBones[i].gameObject.SetActive(value: false);
					}
					UpdateMaterialDismemberLimb(gameObject);
				}
				bodypart.dismembered = true;
				if ((bool)bodypart.AttachedLimb)
				{
					bodypart.AttachedLimb.SetActive(value: false);
				}
				if ((bool)gameObject && bodypart.life > 0f)
				{
					Object.Destroy(gameObject, bodypart.life);
				}
			}
		}

		public void UpdateMaterialDismemberLimb(GameObject limb)
		{
			MaterialChanger materialChanger = limb.FindComponent<MaterialChanger>();
			if (materialChanger != null && MaterialItemName != string.Empty && CurrentMaterialItemIndex != -1)
			{
				materialChanger.SetMaterial(MaterialItemName, CurrentMaterialItemIndex);
			}
		}
	}
}
