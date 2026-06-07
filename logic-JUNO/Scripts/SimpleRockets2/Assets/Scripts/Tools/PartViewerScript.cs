using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Design;
using Assets.Scripts.Terrain.Rendering;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Scenes;
using UnityEngine;

namespace Assets.Scripts.Tools
{
	public class PartViewerScript : MonoBehaviour
	{
		private Camera _camera;

		private CraftScript _craftScript;

		private DesignerPartList _designerPartList;

		private List<Light> _disabledLights;

		private Light[] _partCameraLights;

		private PartTypeList _partTypes;

		private QuadSphereRenderer _renderer;

		public static bool RegeneratePartIcons { get; set; }

		public static bool TakingPictures { get; private set; }

		public static PartViewerScript Create(bool createPartShaderScript)
		{
			PartViewerScript partViewerScript = new GameObject("PartViewer").AddComponent<PartViewerScript>();
			GameObject obj = partViewerScript.gameObject;
			partViewerScript._partTypes = Game.Instance.PartTypes;
			partViewerScript._designerPartList = new DesignerPartList(Game.Instance.PartTypes);
			partViewerScript._designerPartList.Load();
			partViewerScript._camera = new GameObject("Camera").AddComponent<Camera>();
			partViewerScript._camera.transform.SetParent(partViewerScript.transform, worldPositionStays: false);
			partViewerScript._camera.transform.localPosition = -Vector3.forward;
			partViewerScript._camera.enabled = false;
			partViewerScript._camera.fieldOfView = 40f;
			partViewerScript._camera.cullingMask = 512;
			partViewerScript._camera.clearFlags = CameraClearFlags.Color;
			partViewerScript._camera.backgroundColor = new Color(0f, 0f, 0f, 0f);
			partViewerScript._camera.allowMSAA = !Device.IsAndroidBuild;
			partViewerScript._camera.allowHDR = false;
			DesignerLightScript component = Game.Instance.ResourceLoader.InstantiatePrefab("Design/DesignerLights").GetComponent<DesignerLightScript>();
			partViewerScript._partCameraLights = component.GetComponentsInChildren<Light>();
			component.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
			partViewerScript._partCameraLights[0].transform.rotation = Quaternion.Euler(80f, 15f, 0f);
			component.UpdateLights();
			CraftData craft = Game.Instance.CraftLoader.LoadCraftImmediate("__partIcons__");
			partViewerScript._craftScript = CraftBuilder.CreateCraftScript(craft, createBodyScripts: false);
			partViewerScript._craftScript.Transform.SetParent(partViewerScript.transform, worldPositionStays: false);
			MeshRenderer[] componentsInChildren = partViewerScript._craftScript.GetComponentsInChildren<MeshRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = false;
			}
			ParticleSystem[] componentsInChildren2 = partViewerScript._craftScript.GetComponentsInChildren<ParticleSystem>();
			for (int i = 0; i < componentsInChildren2.Length; i++)
			{
				componentsInChildren2[i].Stop();
			}
			if (createPartShaderScript)
			{
				partViewerScript._renderer = QuadSphereRenderer.CreateWithoutQuadsphere(obj, Vector3.zero, partViewerScript._camera.transform, partViewerScript._partCameraLights[0].transform);
				partViewerScript._renderer.UpdateRenderer();
			}
			return partViewerScript;
		}

		public List<IPartScript> LoadParts(DesignerPart designerPart)
		{
			List<IPartScript> list = new List<IPartScript>();
			Assembly assembly = new Assembly(designerPart.AssemblyElement, 15, _partTypes);
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
				component.Transform.localScale = part.Config.PartScale;
				part.PartScript.OnModifiersCreated();
				Utilities.ChangeLayersOfGameObjectAndChildrenRecursive(gameObject, 9);
				ParticleSystem[] componentsInChildren = gameObject.GetComponentsInChildren<ParticleSystem>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].Stop();
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

		public string SavePartPicture(DesignerPart designerPart, Texture2D texture)
		{
			byte[] bytes = texture.EncodeToPNG();
			string partIconFilePath = GetPartIconFilePath(designerPart);
			File.WriteAllBytes(partIconFilePath, bytes);
			return partIconFilePath;
		}

		public void TakeAllPartPictures(bool retakeExisting, bool destroySelfWhenComplete)
		{
			try
			{
				TakingPictures = true;
				RegeneratePartIcons = false;
				foreach (DesignerPart part in _designerPartList.Parts)
				{
					if (part.IconType != DesignerPartIconType.Auto || part.IsSubassembly)
					{
						continue;
					}
					List<IPartScript> list = null;
					try
					{
						if (retakeExisting || string.IsNullOrEmpty(GetPartIconFilePath(part)))
						{
							_renderer?.UpdateRenderer();
							list = LoadParts(part);
							if (list != null && list.Count > 0)
							{
								Texture2D texture = TakePicture(part, list);
								SavePartPicture(part, texture);
							}
							else
							{
								Debug.LogError("An error occurred trying to generate a designer part icon for part '" + (part.Name ?? string.Empty) + "'. The part could not be loaded.");
							}
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						Debug.LogError("An error occurred trying to generate a designer part icon for part '" + (part.Name ?? string.Empty) + "'.");
					}
					finally
					{
						try
						{
							if (list != null)
							{
								foreach (IPartScript item in list)
								{
									if (item != null && item.GameObject != null)
									{
										UnityEngine.Object.DestroyImmediate(item.GameObject);
									}
								}
							}
						}
						catch (Exception exception2)
						{
							Debug.LogException(exception2);
						}
					}
				}
				if (destroySelfWhenComplete)
				{
					UnityEngine.Object.DestroyImmediate(base.gameObject);
				}
				SceneSkybox.UnloadSkybox();
			}
			finally
			{
				TakingPictures = false;
			}
		}

		public Texture2D TakePicture(DesignerPart designerPart, List<IPartScript> parts)
		{
			int num = 100;
			int num2 = 100;
			Bounds bounds = default(Bounds);
			foreach (IPartScript part in parts)
			{
				foreach (PartModifierScript modifier in part.Modifiers)
				{
					modifier.PrepareForPartIcon();
				}
				HideScript[] componentsInChildren = part.GameObject.GetComponentsInChildren<HideScript>();
				foreach (HideScript hideScript in componentsInChildren)
				{
					if (hideScript.HideDuringPartIcons)
					{
						hideScript.gameObject.SetActive(value: false);
					}
				}
				Renderer[] componentsInChildren2 = part.GameObject.GetComponentsInChildren<Renderer>();
				foreach (Renderer renderer in componentsInChildren2)
				{
					if (renderer is SkinnedMeshRenderer)
					{
						bounds.Encapsulate((renderer as SkinnedMeshRenderer).sharedMesh.bounds);
					}
					else
					{
						bounds.Encapsulate(renderer.bounds);
					}
				}
			}
			foreach (IPartScript part2 in parts)
			{
				part2.Transform.RotateAround(bounds.center, Vector3.forward, designerPart.SnapshotPartRotation.z);
				part2.Transform.RotateAround(bounds.center, Vector3.right, designerPart.SnapshotPartRotation.x);
				part2.Transform.RotateAround(bounds.center, Vector3.up, designerPart.SnapshotPartRotation.y);
				part2.Transform.position += designerPart.SnapshotPartOffset;
			}
			OutputPartMeshStatistics(parts, enabled: false);
			Vector3 extents = bounds.extents;
			float magnitude = extents.magnitude;
			float num3 = magnitude / Mathf.Tan(0.5f * _camera.fieldOfView * (MathF.PI / 180f));
			float num4 = (float)num / (float)num2;
			float num5 = 114.59156f * Mathf.Atan(Mathf.Tan(_camera.fieldOfView * (MathF.PI / 180f) / 2f) * num4);
			float num6 = magnitude / Mathf.Tan(0.5f * num5 * (MathF.PI / 180f));
			float num7 = extents.x / num4;
			float num8 = extents.y * num4;
			float num9 = ((!(num7 > num8)) ? num3 : num6);
			Vector3 snapshotRotation = designerPart.SnapshotRotation;
			Vector3 vector = Quaternion.Euler(new Vector3(snapshotRotation.x, snapshotRotation.y, 0f)) * -Vector3.forward;
			_camera.transform.SetPositionAndRotation(bounds.center + vector * num9 * 1f * designerPart.SnapshotDistanceScaler, Quaternion.identity);
			_camera.transform.LookAt(bounds.center);
			_camera.transform.Rotate(new Vector3(0f, 0f, snapshotRotation.z), Space.Self);
			_camera.nearClipPlane = 0.01f;
			_ = _camera.transform.position;
			_partCameraLights[0].enabled = true;
			RenderTexture temporary = RenderTexture.GetTemporary(num, num2, 32, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB);
			temporary.name = "PartViewer_TakePicture";
			temporary.antiAliasing = (Device.IsAndroidBuild ? 1 : 8);
			RenderTexture active = RenderTexture.active;
			_camera.targetTexture = temporary;
			RenderTexture.active = temporary;
			PreRender();
			_camera.Render();
			PostRender();
			Texture2D texture2D = new Texture2D(temporary.width, temporary.height, TextureFormat.ARGB32, mipChain: false, linear: false);
			texture2D.ReadPixels(new Rect(0f, 0f, temporary.width, temporary.height), 0, 0);
			texture2D.Apply();
			_camera.targetTexture = null;
			RenderTexture.active = active;
			RenderTexture.ReleaseTemporary(temporary);
			return texture2D;
		}

		protected virtual void Update()
		{
		}

		private static void OutputPartMeshStatistics(List<IPartScript> parts, bool enabled)
		{
			if (!enabled)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			foreach (IPartScript part in parts)
			{
				MeshRenderer[] componentsInChildren = part.GameObject.GetComponentsInChildren<MeshRenderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					MeshFilter component = componentsInChildren[i].GetComponent<MeshFilter>();
					num += component.mesh.triangles.Length / 3;
					num2 += component.mesh.vertices.Length;
					num3 += component.mesh.subMeshCount;
					num4++;
				}
			}
			string contents = $"{parts[0].Data.PartType.Name}\t{num2}\t{num}\t{num3}\t{num4}\n";
			File.AppendAllText("C:\\temp\\PartMeshStatistics.txt", contents);
		}

		private string GetPartIconFilePath(DesignerPart designerPart)
		{
			string text = designerPart.Name + ".png";
			string text2 = Utilities.CombinePaths(Game.PersistentDataPath, "GameData/Parts/Icons/");
			return Utilities.CombinePaths(text2, text);
		}

		private void PostRender()
		{
			foreach (Light disabledLight in _disabledLights)
			{
				disabledLight.enabled = true;
			}
			Light[] partCameraLights = _partCameraLights;
			for (int i = 0; i < partCameraLights.Length; i++)
			{
				partCameraLights[i].enabled = false;
			}
		}

		private void PreRender()
		{
			_disabledLights = UnityEngine.Object.FindObjectsOfType<Light>().ToList();
			for (int num = _disabledLights.Count - 1; num >= 0; num--)
			{
				Light light = _disabledLights[num];
				if (light.enabled && !_partCameraLights.Contains(light))
				{
					light.enabled = false;
				}
				else
				{
					_disabledLights.Remove(light);
				}
			}
			Light[] partCameraLights = _partCameraLights;
			for (int i = 0; i < partCameraLights.Length; i++)
			{
				partCameraLights[i].enabled = true;
			}
		}
	}
}
