using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VRTK.Highlighters
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Highlighters/VRTK_OutlineObjectCopyHighlighter")]
	public class VRTK_OutlineObjectCopyHighlighter : VRTK_BaseHighlighter
	{
		[Tooltip("The thickness of the outline effect")]
		public float thickness = 1f;

		[Tooltip("The GameObjects to use as the model to outline. If one isn't provided then the first GameObject with a valid Renderer in the current GameObject hierarchy will be used.")]
		public GameObject[] customOutlineModels;

		[Tooltip("A path to a GameObject to find at runtime, if the GameObject doesn't exist at edit time.")]
		public string[] customOutlineModelPaths;

		[Tooltip("If the mesh has multiple sub-meshes to highlight then this should be checked, otherwise only the first mesh will be highlighted.")]
		public bool enableSubmeshHighlight;

		protected Material stencilOutline;

		protected Renderer[] highlightModels;

		protected string[] copyComponents = new string[2] { "UnityEngine.MeshFilter", "UnityEngine.MeshRenderer" };

		public override void Initialise(Color? color = null, GameObject affectObject = null, Dictionary<string, object> options = null)
		{
			objectToAffect = ((affectObject != null) ? affectObject : base.gameObject);
			usesClonedObject = true;
			if (stencilOutline == null)
			{
				stencilOutline = UnityEngine.Object.Instantiate((Material)Resources.Load("OutlineBasic"));
			}
			SetOptions(options);
			ResetHighlighter();
		}

		public override void ResetHighlighter()
		{
			DeleteExistingHighlightModels();
			ResetHighlighterWithCustomModelPaths();
			ResetHighlighterWithCustomModels();
			ResetHighlightersWithCurrentGameObject();
		}

		public override void Highlight(Color? color, float duration = 0f)
		{
			if (highlightModels == null || highlightModels.Length == 0 || !(stencilOutline != null))
			{
				return;
			}
			stencilOutline.SetFloat("_Thickness", thickness);
			stencilOutline.SetColor("_OutlineColor", color.Value);
			for (int i = 0; i < highlightModels.Length; i++)
			{
				if (highlightModels[i] != null)
				{
					highlightModels[i].gameObject.SetActive(value: true);
					highlightModels[i].material = stencilOutline;
				}
			}
		}

		public override void Unhighlight(Color? color = null, float duration = 0f)
		{
			if (objectToAffect == null || highlightModels == null)
			{
				return;
			}
			for (int i = 0; i < highlightModels.Length; i++)
			{
				if (highlightModels[i] != null)
				{
					highlightModels[i].gameObject.SetActive(value: false);
				}
			}
		}

		protected virtual void OnEnable()
		{
			if (customOutlineModels == null)
			{
				customOutlineModels = new GameObject[0];
			}
			if (customOutlineModelPaths == null)
			{
				customOutlineModelPaths = new string[0];
			}
		}

		protected virtual void OnDestroy()
		{
			if (highlightModels != null)
			{
				for (int i = 0; i < highlightModels.Length; i++)
				{
					if (highlightModels[i] != null)
					{
						UnityEngine.Object.Destroy(highlightModels[i]);
					}
				}
			}
			UnityEngine.Object.Destroy(stencilOutline);
		}

		protected virtual void ResetHighlighterWithCustomModels()
		{
			if (customOutlineModels != null && customOutlineModels.Length != 0)
			{
				highlightModels = new Renderer[customOutlineModels.Length];
				for (int i = 0; i < customOutlineModels.Length; i++)
				{
					highlightModels[i] = CreateHighlightModel(customOutlineModels[i], "");
				}
			}
		}

		protected virtual void ResetHighlighterWithCustomModelPaths()
		{
			if (customOutlineModelPaths != null && customOutlineModelPaths.Length != 0)
			{
				highlightModels = new Renderer[customOutlineModelPaths.Length];
				for (int i = 0; i < customOutlineModelPaths.Length; i++)
				{
					highlightModels[i] = CreateHighlightModel(null, customOutlineModelPaths[i]);
				}
			}
		}

		protected virtual void ResetHighlightersWithCurrentGameObject()
		{
			if (highlightModels == null || highlightModels.Length == 0)
			{
				highlightModels = new Renderer[1];
				highlightModels[0] = CreateHighlightModel(null, "");
			}
		}

		protected virtual void SetOptions(Dictionary<string, object> options = null)
		{
			float option = GetOption<float>(options, "thickness");
			if (option > 0f)
			{
				thickness = option;
			}
			GameObject[] option2 = GetOption<GameObject[]>(options, "customOutlineModels");
			if (option2 != null)
			{
				customOutlineModels = option2;
			}
			string[] option3 = GetOption<string[]>(options, "customOutlineModelPaths");
			if (option3 != null)
			{
				customOutlineModelPaths = option3;
			}
		}

		protected virtual void DeleteExistingHighlightModels()
		{
			VRTK_PlayerObject[] componentsInChildren = objectToAffect.GetComponentsInChildren<VRTK_PlayerObject>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].objectType == VRTK_PlayerObject.ObjectTypes.Highlighter)
				{
					UnityEngine.Object.Destroy(componentsInChildren[i].gameObject);
				}
			}
			highlightModels = new Renderer[0];
		}

		protected virtual Renderer CreateHighlightModel(GameObject givenOutlineModel, string givenOutlineModelPath)
		{
			if (givenOutlineModel != null)
			{
				givenOutlineModel = (givenOutlineModel.GetComponent<Renderer>() ? givenOutlineModel : givenOutlineModel.GetComponentInChildren<Renderer>().gameObject);
			}
			else if (givenOutlineModelPath != "")
			{
				Transform transform = objectToAffect.transform.Find(givenOutlineModelPath);
				givenOutlineModel = (transform ? transform.gameObject : null);
			}
			GameObject gameObject = givenOutlineModel;
			if (gameObject == null)
			{
				Renderer componentInChildren = objectToAffect.GetComponentInChildren<Renderer>();
				gameObject = ((componentInChildren != null) ? componentInChildren.gameObject : null);
			}
			if (gameObject == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_OutlineObjectCopyHighlighter", "Renderer", "the same or child", " to add the highlighter to"));
				return null;
			}
			GameObject gameObject2 = new GameObject(objectToAffect.name + "_HighlightModel");
			gameObject2.transform.SetParent(gameObject.transform.parent, worldPositionStays: false);
			gameObject2.transform.localPosition = gameObject.transform.localPosition;
			gameObject2.transform.localRotation = gameObject.transform.localRotation;
			gameObject2.transform.localScale = gameObject.transform.localScale;
			gameObject2.transform.SetParent(objectToAffect.transform);
			Component[] components = gameObject.GetComponents<Component>();
			foreach (Component component in components)
			{
				if (Array.IndexOf(copyComponents, component.GetType().ToString()) >= 0)
				{
					VRTK_SharedMethods.CloneComponent(component, gameObject2);
				}
			}
			MeshFilter component2 = gameObject.GetComponent<MeshFilter>();
			MeshFilter component3 = gameObject2.GetComponent<MeshFilter>();
			Renderer component4 = gameObject2.GetComponent<Renderer>();
			if (component3 != null)
			{
				if (enableSubmeshHighlight)
				{
					HashSet<CombineInstance> hashSet = new HashSet<CombineInstance>();
					for (int j = 0; j < component2.mesh.subMeshCount; j++)
					{
						hashSet.Add(new CombineInstance
						{
							mesh = component2.mesh,
							subMeshIndex = j,
							transform = component2.transform.localToWorldMatrix
						});
					}
					component3.mesh = new Mesh();
					component3.mesh.CombineMeshes(hashSet.ToArray(), mergeSubMeshes: true, useMatrices: false);
				}
				else
				{
					component3.mesh = component2.mesh;
				}
				component4.material = stencilOutline;
				component4.shadowCastingMode = gameObject.transform.GetComponent<Renderer>().shadowCastingMode;
			}
			gameObject2.SetActive(value: false);
			VRTK_PlayerObject.SetPlayerObject(gameObject2, VRTK_PlayerObject.ObjectTypes.Highlighter);
			return component4;
		}
	}
}
