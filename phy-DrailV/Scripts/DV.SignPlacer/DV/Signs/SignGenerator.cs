using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DV.Signs
{
	public class SignGenerator : MonoBehaviour
	{
		private const string BASE_SIGN_NAME = "[Sign{0}]";

		public SignGeneratorData data;

		public Transform signAnchor;

		public Renderer poleRenderer;

		public float signVerticalSpacing = 0.05f;

		public float rotationLimitsZ = 3f;

		private Vector3 previousSignPos = Vector3.zero;

		private float previousSignHeight;

		private void Start()
		{
			Object.Destroy(this);
		}

		public void GenerateSign()
		{
			if (!signAnchor)
			{
				Debug.LogWarning("Sign anchor not set. Check your references. Aborting...", this);
				return;
			}
			if (data == null || data.signParameters == null || data.signParameters.Length == 0)
			{
				Debug.Log("No signs assigned. Sign generation failed", this);
				return;
			}
			TryRemovePreviouslyGeneratedSigns();
			List<Renderer> list = new List<Renderer>();
			List<Renderer> list2 = new List<Renderer>();
			List<Renderer> list3 = new List<Renderer>();
			int num = 0;
			for (int i = 0; i < data.signParameters.Length; i++)
			{
				if (!data.signParameters[i].sign)
				{
					continue;
				}
				float height = data.signParameters[i].sign.GetHeight();
				Vector3 position = ((num == 0) ? signAnchor.position : CalculateSignOffset(height));
				GameObject gameObject = Object.Instantiate(data.signParameters[i].sign.gameObject, position, Quaternion.identity, signAnchor);
				gameObject.transform.localRotation = Quaternion.identity * GetRandomRotation();
				gameObject.name = $"[Sign{num}]";
				TextMeshPro textObject = gameObject.GetComponent<BaseSign>().GetTextObject();
				if ((Object)(object)textObject != null)
				{
					textObject.text = data.signParameters[i].signText;
				}
				list3.AddRange(InstantiateSignAccessories(data.signParameters[i].accessories, gameObject));
				previousSignPos = position;
				previousSignHeight = height;
				Renderer component = gameObject.GetComponent<Renderer>();
				if (component == null)
				{
					Debug.LogError("Sign doesn't have a renderer", gameObject);
				}
				else
				{
					list.Add(component);
				}
				if ((Object)(object)textObject != null)
				{
					Renderer component2 = ((Component)(object)textObject).GetComponent<Renderer>();
					if (component2 == null)
					{
						Debug.LogError("Sign's text object doesn't have a renderer", (Object)(object)textObject);
					}
					list2.Add(component2);
				}
				num++;
			}
			previousSignPos = Vector3.zero;
			previousSignHeight = 0f;
			if (list.Count == 0)
			{
				Debug.Log("sign rends empty");
			}
			if (list2.Count == 0)
			{
				Debug.Log("sign text rends empty");
			}
			GenerateLODs(list, list2, list3);
		}

		private Quaternion GetRandomRotation()
		{
			float num = Random.Range(0f - rotationLimitsZ, rotationLimitsZ);
			float y = num * 0.5f;
			return Quaternion.Euler(num * 0.1f, y, num);
		}

		private void GenerateLODs(List<Renderer> signRends, List<Renderer> textRends, List<Renderer> accRends)
		{
			LOD[] array = new LOD[3];
			List<Renderer> list = new List<Renderer>();
			List<Renderer> list2 = new List<Renderer>();
			List<Renderer> list3 = new List<Renderer>();
			foreach (Renderer signRend in signRends)
			{
				list.Add(signRend);
				list2.Add(signRend);
				list3.Add(signRend);
			}
			list.Add(poleRenderer);
			list2.Add(poleRenderer);
			foreach (Renderer accRend in accRends)
			{
				list.Add(accRend);
			}
			foreach (Renderer textRend in textRends)
			{
				list.Add(textRend);
			}
			array[0].renderers = list.ToArray();
			array[1].renderers = list2.ToArray();
			array[2].renderers = list3.ToArray();
			array[0].screenRelativeTransitionHeight = 0.02f;
			array[1].screenRelativeTransitionHeight = 0.0075f;
			array[2].screenRelativeTransitionHeight = 0.005f;
			LODGroup component = GetComponent<LODGroup>();
			if (component != null)
			{
				Object.DestroyImmediate(component);
			}
			base.gameObject.AddComponent<LODGroup>().SetLODs(array);
		}

		private List<Renderer> InstantiateSignAccessories(GameObject[] accs, GameObject sign)
		{
			List<Renderer> list = new List<Renderer>();
			if (accs == null)
			{
				return list;
			}
			for (int i = 0; i < accs.Length; i++)
			{
				if ((bool)accs[i])
				{
					GameObject obj = Object.Instantiate(accs[i], sign.transform.position, Quaternion.identity, sign.transform);
					obj.transform.localRotation = Quaternion.identity;
					Renderer[] componentsInChildren = obj.GetComponentsInChildren<Renderer>();
					list.AddRange(componentsInChildren);
				}
			}
			return list;
		}

		private void TryRemovePreviouslyGeneratedSigns()
		{
			BaseSign[] componentsInChildren = GetComponentsInChildren<BaseSign>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Object.DestroyImmediate(componentsInChildren[i].gameObject);
			}
		}

		private Vector3 CalculateSignOffset(float signHeight)
		{
			Vector3 result = previousSignPos;
			result.y -= signVerticalSpacing + (previousSignHeight + signHeight) / 2f;
			return result;
		}
	}
}
