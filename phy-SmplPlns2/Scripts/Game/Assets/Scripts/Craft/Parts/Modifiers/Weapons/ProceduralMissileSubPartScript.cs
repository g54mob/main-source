using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Decals;
using Assets.Scripts.Design.Tools;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class ProceduralMissileSubPartScript : PartModifierScript, IMissileSubPart, IPartCollisionHandler
	{
		private class SubPartSet
		{
			public List<GameObject> SubParts { get; private set; } = new List<GameObject>();
		}

		private GameObject _objParent;

		private SubPartSet _subPartSet;

		public static Vector3 BaseFinSize => new Vector3(0.25f, 0.25f, 0.25f);

		public virtual Vector3 BaseSize => new Vector3(0.25f, 0.25f, 0.25f);

		public ProceduralMissileSubPartData Data { get; set; }

		public MissileScript Missile { get; private set; }

		public Transform Transform => base.transform;

		public void AdjustSubPart(ProceduralMissileScript missile)
		{
			if (missile == null)
			{
				missile = GetConnectedMissile();
			}
			_objParent.transform.localScale = missile?.Data.MissileScale ?? new Vector3(0.15f, 0.15f, 1.25f);
			ProceduralMissileSubPartData data = Data;
			_ = data.MinPosition;
			_ = data.MaxPosition;
			float size = data.Size;
			float z = size * data.Length;
			float y = size * data.Height;
			float x = size * data.Thickness;
			int symmetry = data.Symmetry;
			int num = Mathf.Abs(symmetry);
			float angle = data.Angle;
			float num2 = 360f / (float)num;
			Vector3 localScale = new Vector3(x, y, z);
			Vector3 baseSize = ProceduralMissileBuilder.BaseSize;
			localScale.x /= baseSize.x;
			localScale.y /= baseSize.y;
			localScale.z /= baseSize.z;
			localScale.Scale(Data.MissilePartPrefabs.baseSize);
			SubPartSet subPartSet = _subPartSet;
			for (int i = 0; i < num; i++)
			{
				GameObject gameObject = subPartSet.SubParts[i];
				gameObject.transform.localScale = localScale;
				if (Data.SubPartPrefab.attachmentType == MissilePartPrefabs.AttachmentType.Radial)
				{
					float num3 = ((symmetry <= 0) ? ((angle + 90f) * (float)(((i & 1) == 0) ? 1 : (-1))) : (num2 * (float)i + angle));
					gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f - num3);
					float x2 = Mathf.Sin(MathF.PI / 180f * num3) * 0.5f * Data.RadialOffset;
					float y2 = Mathf.Cos(MathF.PI / 180f * num3) * 0.5f * Data.RadialOffset;
					gameObject.transform.localPosition = new Vector3(x2, y2, 0f);
				}
				else
				{
					gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, angle);
					gameObject.transform.localPosition = Vector3.zero;
				}
			}
		}

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart, PreStartInitializationFlags.FlightDefault);
		}

		public void BuildSubParts(ProceduralMissileScript missile)
		{
			ProceduralMissileSubPartData data = Data;
			base.PartScript.PartMaterialScript.ClearRenderers(destroy: true);
			if (_objParent != null)
			{
				UnityEngine.Object.Destroy(_objParent);
			}
			_objParent = new GameObject("SubParts");
			_objParent.transform.SetParent(base.transform);
			_objParent.transform.localScale = Vector3.one;
			_objParent.transform.localRotation = Quaternion.identity;
			_objParent.transform.localPosition = Vector3.zero;
			int num = Mathf.Abs(data.Symmetry);
			SubPartSet subPartSet = (_subPartSet = new SubPartSet());
			for (int i = 0; i < num; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(data.SubPartPrefab.prefab);
				gameObject.transform.SetParent(_objParent.transform, worldPositionStays: false);
				subPartSet.SubParts.Add(gameObject);
			}
			base.PartScript.PrimaryPartCollider = _objParent.GetComponentInChildren<Collider>();
			base.PartScript.EditorColliders.Clear();
			AddRenderersToPartMaterial(_objParent);
			AdjustSubPart(missile);
			base.PartScript.PartMaterialScript.InitializeMaterial();
			Collider componentInChildren = _objParent.GetComponentInChildren<Collider>();
			if (componentInChildren != null)
			{
				ConfigureDecalTargets(componentInChildren.transform);
			}
		}

		public ProceduralMissileScript GetConnectedMissile()
		{
			if (base.PartScript.Part.PartConnections.Count > 0)
			{
				ProceduralMissileData modifier = base.PartScript.Part.PartConnections[0].GetOtherPart(base.PartScript.Part).GetModifier<ProceduralMissileData>();
				if (modifier != null)
				{
					return modifier.Script;
				}
			}
			return null;
		}

		bool IPartCollisionHandler.OnCollision(PartScript partScript, Collision collision, in ContactPoint contactPoint)
		{
			return ((IPartCollisionHandler)Missile).OnCollision(partScript, collision, in contactPoint);
		}

		public override void OnConnectedToPart(AttachPointData thisAttachPoint, PartData targetPart, AttachPointData targetAttachPoint, bool isSymmetryOperation)
		{
			base.OnConnectedToPart(thisAttachPoint, targetPart, targetAttachPoint, isSymmetryOperation);
			ProceduralMissileScript connectedMissile = GetConnectedMissile();
			AdjustSubPart(connectedMissile);
		}

		public void OnMissileBuilt(ProceduralMissileScript missile)
		{
			BuildSubParts(missile);
			if (Data.Part.LoadContext == CraftLoadContext.Flight)
			{
				InitializeFlight(missile);
			}
		}

		public void OnMissileChanged(ProceduralMissileScript missile)
		{
			AdjustSubPart(missile);
		}

		public override void PreviewPartPlacement(AttachPointData myAttachPointBeingUsed, AttachPointData theirAttachPointToPreviewConnectionTo, PartSelection selection)
		{
			base.PreviewPartPlacement(myAttachPointBeingUsed, theirAttachPointToPreviewConnectionTo, selection);
			ProceduralMissileScript modifier = theirAttachPointToPreviewConnectionTo.AttachPointScript.PartScript.GetModifier<ProceduralMissileScript>();
			if (selection.Parts.Count == 1 && modifier != null)
			{
				Transform obj = theirAttachPointToPreviewConnectionTo.AttachPointScript.PartScript.transform;
				Vector3 position = obj.InverseTransformPoint(base.transform.position);
				position.x = 0f;
				position.y = 0f;
				Vector3 vector = obj.TransformPoint(position) - base.transform.position;
				selection.ContainerParent.transform.position += vector;
				AdjustSubPart(modifier);
			}
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			if (GetConnectedMissile() == null)
			{
				BuildSubParts(null);
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			base.RegisterUpdateMethods(in registrar);
		}

		private void AddRenderersToPartMaterial(GameObject gameObject)
		{
			MeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer renderer in componentsInChildren)
			{
				base.PartScript.PartMaterialScript.AddRenderer(renderer);
			}
		}

		private void ConfigureDecalTargets(Transform collider)
		{
			DecalTargetColliderScript decalTargetColliderScript = collider.gameObject.AddMissingComponent<DecalTargetColliderScript>();
			decalTargetColliderScript.DecalTargets.Clear();
			DecalTargetScript componentInChildren = _objParent.GetComponentInChildren<DecalTargetScript>();
			if (componentInChildren != null)
			{
				decalTargetColliderScript.DecalTargets.Add(componentInChildren);
			}
		}

		private void InitializeFlight(ProceduralMissileScript proceduralMissile)
		{
			Missile = proceduralMissile.PartScript.GetModifier<MissileScript>();
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			return UniTask.CompletedTask;
		}
	}
}
