using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using Assets.Scripts.Design;
using Assets.Scripts.Design.Tools.Fuselage;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Styles;
using ModApi.Design;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Fuselage
{
	public class FuselageScript : PartModifierScript<FuselageData>, IDesignerStart, IGameLoopItem, IDesignerLateUpdate
	{
		public delegate void FuselageScriptDelegate(FuselageScript fuselageScript);

		public const string BottomAttachTag = "Bottom";

		public const float MaxLength = 25f;

		public const float MaxRange = 1.2f;

		public const float MinOffsetHeight = 0.005f;

		public const string TopAttachTag = "Top";

		private static AdaptiveMesh _massReference;

		private static AdaptiveMesh _massReferenceCurved;

		private List<AdaptiveMesh> _adaptiveMeshes = new List<AdaptiveMesh>();

		private AttachPoint _attachPointSurface;

		private List<FuselageColliderScript> _colliders = new List<FuselageColliderScript>();

		private MeshDefinitionScript _meshDefinition;

		private bool _pendingDesignerMeshUpdate;

		public List<AdaptiveMesh> AdaptiveMeshes => _adaptiveMeshes;

		public AttachPoint AttachPointBottom { get; private set; }

		public AttachPoint AttachPointRotate { get; private set; }

		public AttachPoint AttachPointTop { get; private set; }

		public bool Backwards
		{
			get
			{
				Vector3 forward = base.transform.forward;
				float num = -0.1f;
				if (!(forward.z < num) && !(forward.y < num))
				{
					return forward.z < num;
				}
				return true;
			}
		}

		public Transform MarkerBottom { get; private set; }

		public Transform MarkerTop { get; private set; }

		public MeshDefinitionScript MeshDefinition => _meshDefinition;

		public bool UpdateAttachPointRotatePosition { get; set; } = true;

		public event FuselageScriptDelegate MeshesUpdated;

		void IDesignerLateUpdate.DesignerLateUpdate(in DesignerFrameData frame)
		{
			if (_pendingDesignerMeshUpdate)
			{
				_pendingDesignerMeshUpdate = false;
				float meshMassMultiplier = base.Data.MeshMassMultiplier;
				OnMeshChanged();
				if (meshMassMultiplier != base.Data.MeshMassMultiplier)
				{
					base.PartScript.CraftScript.SetStructureChanged();
				}
			}
		}

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			base.Data.DesignStart();
		}

		public AttachPoint GetLoadAttachPoint(string tag)
		{
			foreach (AttachPoint attachPoint in base.PartScript.Data.AttachPoints)
			{
				if (attachPoint.Tag == tag && attachPoint.ConnectionType == AttachPointConnectionType.Normal)
				{
					return attachPoint;
				}
			}
			return null;
		}

		public float GetMaxFuelCapacity(float utilization, bool deadCapacity = false)
		{
			return base.Data.Volume * 1000f * utilization * Mathf.Clamp01(deadCapacity ? base.Data.DeadWeightPercentage : (1f - base.Data.DeadWeightPercentage));
		}

		public override void OnAddedToCraftInDesigner(bool isSubassembly)
		{
			if (!isSubassembly)
			{
				UpdateFuel();
			}
		}

		public override void OnConnectedToPart(PartConnectedEventData e)
		{
			if (!base.Data.AutoResize || e.IsProcessingSymmetry || (_attachPointSurface != null && _attachPointSurface.PartConnections.Count != 0))
			{
				return;
			}
			AttachPoint attachPoint = e.ThisAttachPoint;
			float num = 0f;
			if (e.ThisAttachPoint.Tag == "Bottom")
			{
				num = Mathf.Min(base.Data.BottomScale.x, base.Data.BottomScale.y);
				attachPoint = AttachPointBottom;
			}
			else if (e.ThisAttachPoint.Tag == "Top")
			{
				num = Mathf.Min(base.Data.TopScale.x, base.Data.TopScale.y);
				attachPoint = AttachPointTop;
			}
			if (AttachPointTop == attachPoint || AttachPointBottom == attachPoint)
			{
				FuselageJoint fuselageJoint = new FuselageJoint();
				Transform transform = null;
				if (attachPoint == AttachPointTop)
				{
					transform = MarkerTop;
				}
				else if (attachPoint == AttachPointBottom)
				{
					transform = MarkerBottom;
				}
				FuselageScript modifier = e.TargetPart.PartScript.GetModifier<FuselageScript>();
				if (modifier != null && e.TargetAttachPoint.ConnectionType != AttachPointConnectionType.Normal && e.IsProcessedFirst)
				{
					Transform transform2 = null;
					if (e.TargetAttachPoint == modifier.AttachPointTop)
					{
						transform2 = modifier.MarkerTop;
					}
					else if (e.TargetAttachPoint == modifier.AttachPointBottom)
					{
						transform2 = modifier.MarkerBottom;
					}
					if (transform2 != null && transform != null)
					{
						fuselageJoint.AddFuselage(modifier, transform2);
						fuselageJoint.AddFuselage(this, transform);
						fuselageJoint.AdaptSecondFuselage(updateOppositeSide: true);
						UpdateMeshes(updateNormalSmoothing: true);
					}
				}
				else if (e.TargetAttachPoint.Radius > num)
				{
					fuselageJoint.AddFuselage(this, transform);
					fuselageJoint.AddOtherFuselageToJoint(this, attachPoint);
					fuselageJoint.SetSize(new Vector2(e.TargetAttachPoint.Radius, e.TargetAttachPoint.Radius));
					fuselageJoint.UpdateMeshes();
				}
			}
			UpdateFuel();
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			if (Game.InDesignerScene)
			{
				base.Data.OnDesignerCraftStructureChanged();
			}
		}

		public void OnMeshChanged()
		{
			LoadMesh();
			UpdateMeshes(updateNormalSmoothing: true);
			UpdateRenderers(add: true);
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			if (mode == SymmetryMode.Mirror)
			{
				Utilities.Swap(ref base.Data.CornerRadiuses[0], ref base.Data.CornerRadiuses[1]);
				Utilities.Swap(ref base.Data.CornerRadiuses[2], ref base.Data.CornerRadiuses[3]);
				Utilities.Swap(ref base.Data.CornerRadiuses[4], ref base.Data.CornerRadiuses[5]);
				Utilities.Swap(ref base.Data.CornerRadiuses[6], ref base.Data.CornerRadiuses[7]);
				base.Data.Offset = new Vector3(0f - base.Data.Offset.x, base.Data.Offset.y, base.Data.Offset.z);
			}
			UpdateMeshes(updateNormalSmoothing: true);
		}

		public void QueueDesignerMeshUpdate()
		{
			if (!Game.InDesignerScene)
			{
				Debug.LogError("Fuselage mesh updates can only be queued in the designer.");
			}
			else
			{
				_pendingDesignerMeshUpdate = true;
			}
		}

		public bool TryUpdateOffset(Vector3 offset)
		{
			Vector3 vector = ClampOffset(offset);
			base.Data.Offset = vector;
			return Utilities.CompareVector3s(vector, offset);
		}

		public Vector2 TryUpdateScale(Vector2 scale, bool isTopScale)
		{
			if (isTopScale)
			{
				base.Data.TopScale = scale;
			}
			else
			{
				base.Data.BottomScale = scale;
			}
			return scale;
		}

		public void UpdateAttachPoints()
		{
			Vector3 offset = base.Data.Offset;
			float num = 2f * offset.y * base.Data.Deformations.y;
			float num2 = 2f * base.Data.TopScale.y;
			float num3 = ((num2 == 0f) ? 90f : (57.29578f * Mathf.Atan(num / num2)));
			Vector3 vector = new Vector3(-90f + num3, 180f, 0f);
			Vector3 position = offset - new Vector3(0f, 0.5f * num, 0f);
			if (Game.InDesignerScene)
			{
				MarkerTop.SetLocalPositionAndRotation(offset, Quaternion.Euler(vector));
				MarkerBottom.SetLocalPositionAndRotation(-offset, Quaternion.Euler(90f, 0f, 0f));
			}
			foreach (AttachPoint attachPoint in base.PartScript.Data.AttachPoints)
			{
				float num4 = 0f;
				float num5 = Mathf.Min(base.Data.TopScale.x, base.Data.TopScale.y);
				float num6 = Mathf.Min(base.Data.BottomScale.x, base.Data.BottomScale.y);
				switch (attachPoint.Tag)
				{
				case "Bottom":
					SetAttachPointPosition(attachPoint, -offset);
					num4 = num6;
					break;
				case "Top":
					SetAttachPointPosition(attachPoint, position);
					SetAttachPointRotation(attachPoint, vector);
					num4 = num5;
					break;
				case "Front":
					num4 = Mathf.Min(0.5f * (num5 + num6), base.Data.Offset.y);
					if (UpdateAttachPointRotatePosition)
					{
						SetAttachPointPosition(position: new Vector3(0f, 0f, 0.5f * (offset.y + base.Data.TopScale.y - offset.y + base.Data.BottomScale.y)), attachPoint: AttachPointRotate);
					}
					break;
				}
				if (num4 > 0f)
				{
					attachPoint.Scale = 2f * ((num4 < 1f) ? Mathf.Max(0.1f, num4) : Mathf.Sqrt(num4));
				}
			}
		}

		public void UpdateColliderMesh()
		{
			foreach (FuselageColliderScript collider in _colliders)
			{
				UpdateAdaptiveMesh(collider.AdaptiveMesh);
			}
		}

		public void UpdateDesignerNormals()
		{
			List<FuselageScript> fuselagesToUpdate = new List<FuselageScript>();
			ScanConnections(this);
			foreach (FuselageScript item in fuselagesToUpdate)
			{
				foreach (AdaptiveMesh adaptiveMesh in item.AdaptiveMeshes)
				{
					if (!(adaptiveMesh.MeshCollider != null))
					{
						adaptiveMesh.RevertNormalsToLastUpdate();
					}
				}
			}
			FuselageSmoother.BatchDesignerSmooth(fuselagesToUpdate);
			void ScanConnections(FuselageScript script)
			{
				if (!fuselagesToUpdate.Contains(script))
				{
					fuselagesToUpdate.Add(script);
					FuselageScript fuselageScript;
					bool flag;
					(fuselageScript, flag) = script.GetConnectedFuselage("Top");
					if (fuselageScript != null && (flag || script.Data.FlattenNormals == FuselageData.FlattenNormalsOptions.Top || script.Data.FlattenNormals == FuselageData.FlattenNormalsOptions.Both))
					{
						ScanConnections(fuselageScript);
					}
					(fuselageScript, flag) = script.GetConnectedFuselage("Bottom");
					if (fuselageScript != null && (flag || script.Data.FlattenNormals == FuselageData.FlattenNormalsOptions.Bottom || script.Data.FlattenNormals == FuselageData.FlattenNormalsOptions.Both))
					{
						ScanConnections(fuselageScript);
					}
				}
			}
		}

		public void UpdateFuel()
		{
			if (!Game.InDesignerScene)
			{
				return;
			}
			FuelTankScript modifier = base.PartScript.GetModifier<FuelTankScript>();
			if (base.Data.DeadWeightPercentage >= 0f)
			{
				base.Data.DeadWeight = GetMaxFuelCapacity(1f, deadCapacity: true) * 11.34f;
			}
			if (modifier != null)
			{
				float fuelPercentage = base.Data.FuelPercentage;
				modifier.Data.CalculateInitialFuel(GetMaxFuelCapacity(modifier.Data.Utilization), fuelPercentage);
			}
			CrewCompartmentScript modifier2 = base.PartScript.GetModifier<CrewCompartmentScript>();
			if (!(modifier2 != null))
			{
				return;
			}
			modifier2.Data.Capacity = (int)(base.Data.Volume / modifier2.Data.VolumePerIndividual);
			modifier2.Data.CrewExitPosition = new Vector3(0f, 0f, 0.5f * (base.Data.BottomScale.y + base.Data.TopScale.y));
			float num = modifier2.Crew.Count - modifier2.Data.Capacity;
			for (int i = 0; (float)i < num; i++)
			{
				List<EvaScript> crew = modifier2.Crew;
				EvaScript evaScript = crew[crew.Count - 1];
				foreach (PartConnection partConnectionsBetweenPart in PartConnection.GetPartConnectionsBetweenParts(base.PartScript.Data, evaScript.PartScript.Data))
				{
					foreach (PartConnection symmetricPartConnection in Symmetry.GetSymmetricPartConnections(base.PartScript, partConnectionsBetweenPart, includeSourcePart: false))
					{
						symmetricPartConnection.DestroyConnection();
					}
					partConnectionsBetweenPart.DestroyConnection();
				}
			}
		}

		public void UpdateMeshes(bool updateNormalSmoothing = false)
		{
			UpdateAttachPoints();
			foreach (AdaptiveMesh adaptiveMesh in _adaptiveMeshes)
			{
				UpdateAdaptiveMesh(adaptiveMesh);
			}
			if (updateNormalSmoothing)
			{
				UpdateDesignerNormals();
			}
			UpdateColliderMesh();
			if (base.Data.Version >= 3)
			{
				if (Game.InDesignerScene)
				{
					UpdateAdaptiveMesh(base.Data.DepthCurved ? _massReferenceCurved : _massReference, isReference: true);
					(base.Data.Volume, base.Data.InnerVolume, base.PartScript.Data.Config.CenterOfMass) = FuselageData.CalculateVolumeFromMesh((base.Data.DepthCurved ? _massReferenceCurved : _massReference).MeshFilter.mesh);
				}
			}
			else
			{
				base.Data.UpdateVolume();
			}
			UpdateFuel();
			this.MeshesUpdated?.Invoke(this);
		}

		internal (FuselageScript script, bool otherSmoothed) GetConnectedFuselage(string tag)
		{
			foreach (AttachPoint attachPoint in base.PartScript.Data.AttachPoints)
			{
				if (attachPoint.Tag != tag)
				{
					continue;
				}
				foreach (PartConnection partConnection in attachPoint.PartConnections)
				{
					FuselageData fuselageData = partConnection.GetOtherPart(base.PartScript.Data)?.GetModifier<FuselageData>();
					if (fuselageData == null || !(fuselageData.Script != null))
					{
						continue;
					}
					bool flag = partConnection.PartA == fuselageData.Part;
					bool item = false;
					if (fuselageData.FlattenNormals == FuselageData.FlattenNormalsOptions.Both)
					{
						item = true;
					}
					else if (fuselageData.FlattenNormals != FuselageData.FlattenNormalsOptions.None)
					{
						for (int i = 0; i < partConnection.Attachments.Count; i++)
						{
							string text = (flag ? partConnection.Attachments[i].AttachPointA : partConnection.Attachments[i].AttachPointB).Tag;
							if (text == "Top")
							{
								item = fuselageData.FlattenNormals == FuselageData.FlattenNormalsOptions.Top;
								break;
							}
							if (text == "Bottom")
							{
								item = fuselageData.FlattenNormals == FuselageData.FlattenNormalsOptions.Bottom;
							}
						}
					}
					return (script: fuselageData.Script, otherSmoothed: item);
				}
			}
			return (script: null, otherSmoothed: false);
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			if (Game.InDesignerScene)
			{
				if (GameObject.Find("Reference(Clone)") == null)
				{
					_massReference = new AdaptiveMesh(Game.Instance.FuselageMeshes.InstantiateMesh("Reference").GetComponentInChildren<MeshFilter>(), anchorsEnabled: false, tileableTexture: false, useSimpleRadialScaling: false, null);
				}
				if (GameObject.Find("ReferenceCurved(Clone)") == null)
				{
					_massReferenceCurved = new AdaptiveMesh(Game.Instance.FuselageMeshes.InstantiateMesh("ReferenceCurved").GetComponentInChildren<MeshFilter>(), anchorsEnabled: false, tileableTexture: false, useSimpleRadialScaling: false, null);
				}
				MarkerTop = new GameObject("FuselageTop").transform;
				MarkerTop.transform.SetParent(base.transform, worldPositionStays: false);
				MarkerBottom = new GameObject("FuselageBottom").transform;
				MarkerBottom.transform.SetParent(base.transform, worldPositionStays: false);
			}
			foreach (AttachPoint attachPoint in base.PartScript.Data.AttachPoints)
			{
				if (attachPoint.Name == "AttachPointTop")
				{
					AttachPointTop = attachPoint;
				}
				else if (attachPoint.Name == "AttachPointBottom")
				{
					AttachPointBottom = attachPoint;
				}
			}
			foreach (AttachPoint attachPoint2 in base.PartScript.Data.AttachPoints)
			{
				if (attachPoint2.AllowRotation && attachPoint2.Tag == "Front")
				{
					AttachPointRotate = attachPoint2;
				}
				if (attachPoint2.IsSurfaceAttachPoint)
				{
					_attachPointSurface = attachPoint2;
				}
			}
			_colliders.AddRange(GetComponentsInChildren<FuselageColliderScript>());
			foreach (FuselageColliderScript collider in _colliders)
			{
				collider.OnFuselageInitialized();
			}
			LoadMesh();
			UpdateMeshes();
			UpdateRenderers(add: true);
		}

		private static Vector3 ClampOffset(Vector3 offset)
		{
			if (Mathf.Abs(offset.x) > 1.2f)
			{
				offset.x = Mathf.Sign(offset.x) * 1.2f;
			}
			if (offset.y > 25f)
			{
				offset.y = 25f;
			}
			else if (offset.y < 0.005f)
			{
				offset.y = 0.005f;
			}
			if (Mathf.Abs(offset.z) > 1.2f)
			{
				offset.z = Mathf.Sign(offset.z) * 1.2f;
			}
			return offset;
		}

		private void LoadMesh()
		{
			PartStyleData partStyleData = base.PartScript.Data.Styles[base.Data.SubpartIndex];
			string text = partStyleData.Style.Id;
			bool tileableTexture = partStyleData.TextureStyle.Options.HasFlag(PartTextureStyleOptions.DesignerTileableY);
			if (_meshDefinition != null)
			{
				UpdateRenderers(add: false);
				_adaptiveMeshes.Clear();
				Object.DestroyImmediate(_meshDefinition.gameObject);
				_meshDefinition = null;
			}
			FuselageMeshes fuselageMeshes = Game.Instance.FuselageMeshes;
			if (!fuselageMeshes.Exists(text))
			{
				Debug.LogError($"Part {base.PartScript.Data.Name} (ID {base.PartScript.Data.Id}) has Mesh ID that does not exist: {text}");
				text = fuselageMeshes.GetMeshesForFuselageType(base.Data.MeshType)[0];
			}
			MeshDefinitionScript meshDefinitionScript = fuselageMeshes.InstantiateMesh(text);
			if (meshDefinitionScript != null)
			{
				FuselageEnabledScript[] componentsInChildren = meshDefinitionScript.GetComponentsInChildren<FuselageEnabledScript>();
				foreach (FuselageEnabledScript fuselageEnabledScript in componentsInChildren)
				{
					if (fuselageEnabledScript.EnabledWhenMirrored != base.PartScript.Data.Mirrored)
					{
						Object.DestroyImmediate(fuselageEnabledScript.gameObject);
					}
				}
				_meshDefinition = meshDefinitionScript;
				meshDefinitionScript.transform.SetParent(base.transform, worldPositionStays: false);
				meshDefinitionScript.transform.localScale = Vector3.one;
				meshDefinitionScript.transform.localRotation = Quaternion.identity;
				base.Data.MeshMassMultiplier = ((base.Data.Version <= 1) ? meshDefinitionScript.MassMultiplier : ((base.Data.Version == 2) ? meshDefinitionScript.MassMultiplierV2 : meshDefinitionScript.MassMultiplierV3));
				MeshFilter[] componentsInChildren2 = meshDefinitionScript.GetComponentsInChildren<MeshFilter>();
				foreach (MeshFilter obj in componentsInChildren2)
				{
					AdaptiveMesh item = new AdaptiveMesh(meshCollider: obj.GetComponent<MeshCollider>(), meshFilter: obj, anchorsEnabled: meshDefinitionScript.AnchorsEnabled, tileableTexture: tileableTexture, useSimpleRadialScaling: meshDefinitionScript.UseSimpleRadialScaling);
					_adaptiveMeshes.Add(item);
				}
			}
			else
			{
				Debug.LogError("Unable to find fuselage style: " + text);
			}
		}

		private void SetAttachPointPosition(AttachPoint attachPoint, Vector3 position)
		{
			attachPoint.Position = position;
			if (Game.InDesignerScene)
			{
				attachPoint.AttachPointScript.transform.localPosition = attachPoint.Position;
			}
		}

		private void SetAttachPointRotation(AttachPoint attachPoint, Vector3 rotation)
		{
			attachPoint.Rotation = rotation;
			if (Game.InDesignerScene)
			{
				attachPoint.AttachPointScript.transform.localRotation = Quaternion.Euler(attachPoint.Rotation);
			}
		}

		private void UpdateAdaptiveMesh(AdaptiveMesh adaptiveMesh, bool isReference = false)
		{
			adaptiveMesh.DepthCurve = base.Data.DepthCurve;
			adaptiveMesh.Update(base.Data, _meshDefinition, isReference);
		}

		private void UpdateRenderers(bool add)
		{
			MeshRenderer[] componentsInChildren = _meshDefinition.gameObject.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			foreach (MeshRenderer renderer in componentsInChildren)
			{
				if (add)
				{
					base.PartScript.PartMaterialScript.AddRenderer(renderer);
				}
				else
				{
					base.PartScript.PartMaterialScript.RemoveRenderer(renderer);
				}
			}
		}
	}
}
