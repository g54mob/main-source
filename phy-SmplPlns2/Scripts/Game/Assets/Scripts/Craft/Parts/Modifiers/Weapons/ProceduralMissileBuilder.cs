using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Decals;
using Jundroo.Common.Extensions;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class ProceduralMissileBuilder
	{
		private class NoseData
		{
			public float Length { get; set; }

			public string PrefabName { get; set; }

			public SeekerType SeekerType { get; set; }

			public NoseData(SeekerType seekerType, string prefabName, float scale)
			{
				SeekerType = seekerType;
				PrefabName = prefabName;
				Length = scale;
			}
		}

		public const float BaseLength = 3f;

		public const float BaseNoseLength = 5f;

		public const float BaseRadius = 0.08f;

		private GameObject _body;

		private GameObject _engine;

		private NoseData _nose;

		private GameObject _seeker;

		public static Vector3 BaseSize => new Vector3(0.16f, 0.16f, 1.2f);

		private static NoseData[] Noses { get; } = new NoseData[6]
		{
			new NoseData(SeekerType.ActiveRadar, "ActiveRadar", 0.55f),
			new NoseData(SeekerType.AntiRadiation, "AntiRadiation", 0.4f),
			new NoseData(SeekerType.Infrared, "Infrared", 0.23f),
			new NoseData(SeekerType.Laser, "Laser", 0.23f),
			new NoseData(SeekerType.SemiActiveRadar, "SemiActiveRadar", 0.4f),
			new NoseData(SeekerType.Unguided, "Unguided", 0.375f)
		};

		public void AdjustMissile(GameObject obj, ProceduralMissileData data, bool repositionConnectedParts, List<IMissileSubPart> missileParts)
		{
			Dictionary<IMissileSubPart, Vector3> dictionary = null;
			if (repositionConnectedParts)
			{
				dictionary = new Dictionary<IMissileSubPart, Vector3>();
				foreach (IMissileSubPart missilePart in missileParts)
				{
					dictionary[missilePart] = obj.transform.InverseTransformPoint(missilePart.Transform.position);
				}
			}
			Vector3 baseSize = BaseSize;
			baseSize.Scale(new Vector3(data.RadiusScale, data.RadiusScale, 1f) * data.Size);
			obj.transform.localScale = baseSize;
			ScaleSeeker(data, baseSize);
			_seeker.transform.localPosition = new Vector3(0f, 0f, 1f);
			_engine.transform.localScale = new Vector3(1f, 1f, baseSize.x / baseSize.z);
			_engine.transform.localPosition = new Vector3(0f, 0f, -1f);
			if (data.Part.LoadContext == CraftLoadContext.Designer)
			{
				AttachPointScript attachPointScript = data.Part.PartScript.AttachPointScripts.First();
				Vector3 position = attachPointScript.transform.position;
				attachPointScript.transform.localPosition = new Vector3(0f, baseSize.x * 0.5f, data.AttachPosition * baseSize.z * 0.5f);
				foreach (IMissileSubPart missilePart2 in missileParts)
				{
					missilePart2.OnMissileChanged(data.Script);
				}
				if (repositionConnectedParts)
				{
					Vector3 vector = position - attachPointScript.transform.position;
					data.Part.PartScript.transform.position += vector;
				}
			}
			Transform transform = obj.transform.parent.Find("Collider");
			float num = _nose.Length * baseSize.z * data.RadiusScale * data.NoseLength;
			transform.transform.localScale = new Vector3(baseSize.x, baseSize.z + num / 2f, baseSize.y);
			transform.transform.localPosition = new Vector3(0f, 0f, num / 2f);
			data.MissileLength = transform.transform.localScale.y * 2f;
			if (!repositionConnectedParts)
			{
				return;
			}
			foreach (KeyValuePair<IMissileSubPart, Vector3> item in dictionary)
			{
				item.Key.Transform.position = obj.transform.TransformPoint(item.Value);
			}
		}

		public void BuildMissile(GameObject obj, ProceduralMissileData data, List<IMissileSubPart> missileParts)
		{
			_body = Game.Instance.ResourceLoader.InstantiatePrefab("Craft/Parts/ProceduralMissile/Body/Basic", obj.transform);
			_body.transform.localScale = Vector3.one;
			_body.transform.localRotation = Quaternion.identity;
			_body.transform.localPosition = Vector3.zero;
			AddRenderersToPartMaterial(data, _body, 0);
			if (data.EngineData.Type == MissileEngineType.ThrustVector)
			{
				_engine = Game.Instance.ResourceLoader.InstantiatePrefab("Craft/Parts/ProceduralMissile/Engine/ThrustVector", obj.transform);
			}
			else if (data.EngineData.Type == MissileEngineType.Jet)
			{
				_engine = Game.Instance.ResourceLoader.InstantiatePrefab("Craft/Parts/ProceduralMissile/Engine/Jet", obj.transform);
			}
			else
			{
				_engine = Game.Instance.ResourceLoader.InstantiatePrefab("Craft/Parts/ProceduralMissile/Engine/Solid", obj.transform);
			}
			_engine.transform.localRotation = Quaternion.identity;
			AddRenderersToPartMaterial(data, _engine, null);
			InstantiateSeeker(obj, data);
			foreach (IMissileSubPart missilePart in missileParts)
			{
				missilePart.OnMissileBuilt(data.Script);
			}
			Transform collider = obj.transform.parent.Find("Collider");
			ConfigureDecalTargets(collider);
			AdjustMissile(obj, data, repositionConnectedParts: false, missileParts);
		}

		private static void AddRenderersToPartMaterial(ProceduralMissileData data, GameObject gameObject, int? material)
		{
			MeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer renderer in componentsInChildren)
			{
				if (material.HasValue)
				{
					data.Part.PartScript.PartMaterialScript.AddRenderer(renderer, null, null, new int[1] { material.Value }, excludeFromCombine: true, excludeFromDrag: false);
				}
				else
				{
					data.Part.PartScript.PartMaterialScript.AddRenderer(renderer);
				}
			}
		}

		private void ConfigureDecalTargets(Transform collider)
		{
			DecalTargetColliderScript decalTargetColliderScript = collider.gameObject.AddMissingComponent<DecalTargetColliderScript>();
			decalTargetColliderScript.DecalTargets.Clear();
			DecalTargetScript componentInChildren = _body.GetComponentInChildren<DecalTargetScript>();
			if (componentInChildren != null)
			{
				decalTargetColliderScript.DecalTargets.Add(componentInChildren);
			}
		}

		private void InstantiateSeeker(GameObject obj, ProceduralMissileData data)
		{
			_nose = null;
			if (string.IsNullOrEmpty(data.NoseTypeOverride))
			{
				_nose = Noses.FirstOrDefault((NoseData x) => x.SeekerType == data.Seeker.Type);
				if (_nose == null)
				{
					_nose = Noses.FirstOrDefault();
				}
			}
			else
			{
				_nose = Noses.First((NoseData x) => x.PrefabName == data.NoseTypeOverride);
			}
			_seeker = Game.Instance.ResourceLoader.InstantiatePrefab("Craft/Parts/ProceduralMissile/Nose/" + _nose.PrefabName, obj.transform);
			_seeker.transform.localRotation = Quaternion.identity;
			AddRenderersToPartMaterial(data, _seeker, null);
		}

		private void ScaleSeeker(ProceduralMissileData data, Vector3 missileScale)
		{
			float num = missileScale.x / missileScale.z * data.NoseLength * 5f;
			_seeker.transform.localScale = new Vector3(1f, 1f, num);
			Transform transform = Utilities.FindFirstGameObjectMyselfOrChildren("Lens", _seeker)?.transform;
			if (transform != null)
			{
				transform.localScale = new Vector3(1f, 1f, missileScale.x / num);
			}
			ScaleMeshNormalsScript[] componentsInChildren = _seeker.GetComponentsInChildren<ScaleMeshNormalsScript>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].ScaleNormals();
			}
		}
	}
}
