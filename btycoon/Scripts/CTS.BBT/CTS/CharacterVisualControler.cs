using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(0)]
	public class CharacterVisualControler : MonoBehaviour
	{
		[field: SerializeField]
		public VisualBody[] Bodies { get; private set; }

		[field: SerializeField]
		public CharacterData CharacterData { get; private set; }

		private void OnDisable()
		{
			for (int i = 0; i < Bodies.Length; i++)
			{
				Bodies[i].Body.RemoveReferences();
			}
		}

		public void RigSelection(CharacterData generateData)
		{
			CharacterData? randomIfMultiflags = CharacterData.GetRandomIfMultiflags(generateData.Gender, generateData.Species, generateData.Ethnics, generateData.SubSpecies);
			if (!randomIfMultiflags.HasValue)
			{
				return;
			}
			CharacterData generateData2 = randomIfMultiflags.Value;
			generateData2.hairMatIndex = generateData.hairMatIndex;
			generateData2.hairMeshIndex = generateData.hairMeshIndex;
			generateData2.eyesMaterialIndex = generateData.eyesMaterialIndex;
			generateData2.headSkinMaterialIndex = generateData.headSkinMaterialIndex;
			generateData2.headBlendIndex = generateData.headBlendIndex;
			generateData2.bodySkinMaterialIndex = generateData.bodySkinMaterialIndex;
			generateData2.bodyDataIndex = generateData.bodyDataIndex;
			generateData2.bodyMaterialGroupIndex = generateData.bodyMaterialGroupIndex;
			base.transform.parent.gameObject.name = generateData2.SubSpecies.ToString() + " / " + generateData2.Gender.ToString() + " / " + generateData2.Species.ToString() + " / " + generateData2.Ethnics;
			VisualBody[] bodies = Bodies;
			foreach (VisualBody visualBody in bodies)
			{
				visualBody.Body.gameObject.SetActive(value: false);
			}
			bodies = Bodies;
			for (int i = 0; i < bodies.Length; i++)
			{
				VisualBody visualBody2 = bodies[i];
				if (visualBody2.Gender == generateData2.Gender)
				{
					visualBody2.Body.gameObject.SetActive(value: true);
					visualBody2.Body.SetReferences(ref generateData2);
					break;
				}
			}
			CharacterData = generateData2;
		}

		public void ChangeClothes(int? bodyId = null, int? bodyMaterial = null)
		{
			CharacterData data = CharacterData;
			if (bodyMaterial.HasValue)
			{
				data.bodyMaterialGroupIndex = bodyMaterial.Value;
			}
			else
			{
				data.bodyMaterialGroupIndex = 0;
			}
			if (bodyId.HasValue)
			{
				data.bodyDataIndex = bodyId.Value;
			}
			else
			{
				data.bodyDataIndex = 0;
			}
			VisualBody[] bodies = Bodies;
			for (int i = 0; i < bodies.Length; i++)
			{
				VisualBody visualBody = bodies[i];
				if (visualBody.Gender == data.Gender)
				{
					visualBody.Body.MeshChanger.SetBody(ref data);
					break;
				}
			}
			CharacterData = data;
		}

		public void ChangeClothes(CharacterBodyDataSO bodyData, int? bodyMaterial = null)
		{
			ChangeClothes((!(bodyData == null)) ? bodyData.ID : 0, bodyMaterial);
		}
	}
}
