using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Terrain.Rendering;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Career.Research.UI
{
	public class PartLoaderScript : MonoBehaviour
	{
		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private Light _craftLight;

		private CraftScript _craftScript;

		private QuadSphereRenderer _renderer;

		public Transform LoadDesignerPart(string designerPartName, Vector3 position, float targetScale, Action<GameObject> callback = null)
		{
			GameObject gameObject = new GameObject("Part - " + designerPartName);
			try
			{
				DesignerPart designerPart = Game.Instance.CachedDesignerParts.Parts.Where((DesignerPart x) => x.Name == designerPartName).FirstOrDefault();
				List<IPartScript> list = LoadParts(designerPart, changeLayer: false);
				foreach (IPartScript item in list)
				{
					item.Transform.SetParent(gameObject.transform, worldPositionStays: true);
				}
				StartCoroutine(UpdateScale(targetScale, gameObject, list, position, callback));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			return gameObject.transform;
		}

		public List<IPartScript> LoadParts(DesignerPart designerPart, bool changeLayer = true)
		{
			List<IPartScript> list = new List<IPartScript>();
			Assembly assembly = new Assembly(designerPart.AssemblyElement, 15, Game.Instance.PartTypes);
			if (assembly.Parts.Count == 0)
			{
				return list;
			}
			foreach (PartData part in assembly.Parts)
			{
				GameObject gameObject = CraftBuilder.CreatePartGameObject(part, _craftScript);
				IPartScript component = gameObject.GetComponent<IPartScript>();
				if (component == null)
				{
					Debug.LogError($"Unable to create the part game object for designer part '{designerPart.Name}' and part id '{part.Id}'.");
					UnityEngine.Object.DestroyImmediate(gameObject);
					continue;
				}
				list.Add(component);
				CraftBuilder.CreateModifierScripts(part);
				part.PartScript.OnModifiersCreated();
				if (changeLayer)
				{
					Utilities.ChangeLayersOfGameObjectAndChildrenRecursive(gameObject, 9);
				}
				ParticleSystem[] componentsInChildren = gameObject.GetComponentsInChildren<ParticleSystem>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].Stop();
				}
				foreach (PartModifierScript modifier in part.PartScript.Modifiers)
				{
					modifier.PrepareForPartIcon();
				}
			}
			_craftScript.Data.Assembly.Absorb(assembly);
			foreach (PartData part2 in assembly.Parts)
			{
				if (part2.CommandPod == null)
				{
					part2.CommandPod = _craftScript.RootPart.Data;
				}
			}
			return list;
		}

		protected void Start()
		{
			SetupParts();
		}

		private static IEnumerator UpdateScale(float targetScale, GameObject container, List<IPartScript> parts, Vector3 position, Action<GameObject> callback)
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			if (!(container != null))
			{
				yield break;
			}
			Physics.SyncTransforms();
			Bounds bounds = Utilities.CalculateBounds(parts[0].GameObject, includeSkinnedMeshRenderers: true);
			for (int i = 1; i < parts.Count; i++)
			{
				bounds = Utilities.ExpandBounds(bounds, Utilities.CalculateBounds(parts[i].GameObject, includeSkinnedMeshRenderers: true));
			}
			foreach (IPartScript part in parts)
			{
				part.Transform.SetParent(null, worldPositionStays: true);
			}
			container.transform.position = bounds.center;
			foreach (IPartScript part2 in parts)
			{
				part2.Transform.SetParent(container.transform, worldPositionStays: true);
			}
			container.transform.localScale = Vector3.one * (targetScale / bounds.size.magnitude);
			container.transform.position = position;
			callback?.Invoke(container);
		}

		private void SetupParts()
		{
			CraftData craft = Game.Instance.CraftLoader.LoadCraftImmediate("__partIcons__");
			_craftScript = CraftBuilder.CreateCraftScript(craft, createBodyScripts: false);
			_craftScript.Transform.SetParent(base.transform, worldPositionStays: false);
			MeshRenderer[] componentsInChildren = _craftScript.GetComponentsInChildren<MeshRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = false;
			}
			ParticleSystem[] componentsInChildren2 = _craftScript.GetComponentsInChildren<ParticleSystem>();
			for (int i = 0; i < componentsInChildren2.Length; i++)
			{
				componentsInChildren2[i].Stop();
			}
			_renderer = QuadSphereRenderer.CreateWithoutQuadsphere(base.gameObject, Vector3.zero, _camera.transform, _craftLight.transform);
			_renderer.UpdateRenderer();
		}
	}
}
